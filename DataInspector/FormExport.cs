using QuantBox.Data.Serializer;
using QuantBox.Data.Serializer.V2;
using SevenZip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataInspector
{
    public partial class FormExport : Form
    {
        private string strInput;
        private string strOutput;
        private bool bSkip;

        delegate void AppendTextCallback(string text);
        private AppendTextCallback _AppendTextCallback;

        public FormExport()
        {
            InitializeComponent();
            _AppendTextCallback = new AppendTextCallback(AppendText);
        }

        private void button_Input_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.SelectedPath = textBox_Input.Text;
            if (DialogResult.OK == folderDlg.ShowDialog())
            {
                textBox_Input.Text = folderDlg.SelectedPath;
            }
        }

        private void button_Output_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.SelectedPath = textBox_Output.Text;
            if (DialogResult.OK == folderDlg.ShowDialog())
            {
                textBox_Output.Text = folderDlg.SelectedPath;
            }
        }

        private void button_Process_Click(object sender, EventArgs e)
        {
            strInput = textBox_Input.Text;
            strOutput = textBox_Output.Text;
            bSkip = checkBox_SkipExistingFile.Checked;
            if (strOutput.StartsWith(strInput))
            {
                MessageBox.Show("输出目录不能是输入目录的子目录，否则死循环");
                return;
            }

            textBox_Log.Clear();

            Task.Factory.StartNew(() => Do(new DirectoryInfo(strInput),
                checkBox_AllSubfolders.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly));
        }

        private void Do(DirectoryInfo di, SearchOption searchOption)
        {
            foreach (var f in di.GetFiles("*", searchOption))
            {
                // 处理
                string s = f.FullName.Replace(strInput, strOutput + Path.DirectorySeparatorChar) + ".csv";
                var fi = new FileInfo(s);

                if (bSkip)
                {
                    if (fi.Exists)
                    {
                        AppendText(string.Format("{0} - 存在{1}", fi.FullName, Environment.NewLine));
                        continue;
                    }
                }

                try
                {
                    ExportToList(f, fi);
                    
                    AppendText(string.Format("{0} - 成功{1}", fi.FullName, Environment.NewLine));
                }
                catch (Exception ex)
                {
                    AppendText(string.Format("{0} - 失败{1}", fi.FullName, Environment.NewLine));
                    AppendText(string.Format("{0}", ex.Message, Environment.NewLine));
                }
            }
        }

        private void ExportToList(FileInfo file_input,FileInfo file_output)
        {
            Stream _stream = new MemoryStream();
            // 加载文件，支持7z解压
            var fileStream = file_input.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            {
                try
                {
                    using (var zip = new SevenZipExtractor(fileStream))
                    {
                        // 只解压了第0个，如果有多个也只解压第一个
                        zip.ExtractFile(0, _stream);
                        _stream.Seek(0, SeekOrigin.Begin);
                    }
                }
                catch
                {
                    _stream = fileStream;
                    _stream.Seek(0, SeekOrigin.Begin);
                }
            }

            PbTickCodec codec = new PbTickCodec();
            QuantBox.Data.Serializer.PbTickSerializer Serializer = new QuantBox.Data.Serializer.PbTickSerializer();
            List<PbTickView> list = Serializer.Read2View(_stream);
            ListToCSV(list, file_output);
        }

        private static string[] CSVHeaderLine = { "TradingDay", "ActionDay", "Time", "LastPrice", "Volume", "OpenInterest", "Turnover", "AveragePrice" };
        private static string[] CSVHeaderLineEx = { "BidPrice", "BidSize", "AskPrice", "AskSize" };

        private void ListToCSV(List<PbTickView> list, FileInfo file_output)
        {
            using (TextWriter stream = new StreamWriter(file_output.FullName))
            {
                StringBuilder data = new StringBuilder();
                // 头行第一部分
                for (int i = 0; i < CSVHeaderLine.Length; ++i)
                {
                    data.Append(CSVHeaderLine[i]);
                    data.Append(",");
                }
                // 第二部分根据档位计算
                for (int i = 1; i <= numericUpDown_DepthLevel.Value;++i )
                {
                    foreach(var s in CSVHeaderLineEx)
                    {
                        data.Append(s);
                        data.Append(i);
                        data.Append(",");
                    }
                }
                stream.WriteLine(data);

                foreach (var l in list)
                {
                    stream.Write(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},",
                        l.TradingDay,
                        l.ActionDay,
                        getTime(l),
                        l.LastPrice,
                        l.Volume,
                        l.OpenInterest,
                        l.Turnover,
                        l.AveragePrice
                        ));
                    StringBuilder s = new StringBuilder();
                    for (int i = 0; i < numericUpDown_DepthLevel.Value; ++i)
                    {
                        int count = l.DepthList == null ? 0 : l.DepthList.Count;
                        if (count > 0)
                        {
                            int AskPos = DepthListHelper.FindAsk1Position(l.DepthList, l.AskPrice1);
                            int BidPos = AskPos - 1;
                            if(BidPos-i>=0)
                            {
                                s.Append(l.DepthList[BidPos - i].Price);
                                s.Append(",");
                                s.Append(l.DepthList[BidPos - i].Size);
                                s.Append(",");
                            }
                            else
                            {
                                s.Append(",,");
                            }
                            if (AskPos + i < count)
                            {
                                s.Append(l.DepthList[AskPos + i].Price);
                                s.Append(",");
                                s.Append(l.DepthList[AskPos + i].Size);
                                s.Append(",");
                            }
                            else
                            {
                                s.Append(",,");
                            }
                        }
                        else
                        {
                            s.Append(",,,,");
                        }
                    }
                    stream.WriteLine(s);
                }
                stream.Close();
            }
        }

        private static string getTime(PbTickView pbTickView)
        {
            return String.Format("{0}:{1}:{2}.{3}",
                (pbTickView.Time_HHmm / 100).ToString("D2"),
                (pbTickView.Time_HHmm % 100).ToString("D2"),
                (pbTickView.Time_____ssf__ / 10).ToString("D2"),
                ((pbTickView.Time_____ssf__ % 10) * 100 + pbTickView.Time________ff).ToString("D3")
                );
        }

        private void AppendText(string s)
        {
            if (InvokeRequired)
            {
                Invoke(_AppendTextCallback, s);
            }
            else
            {
                textBox_Log.AppendText(s);
            }
        }
    }
}
