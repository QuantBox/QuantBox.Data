using QuantBox.Data.Serializer;
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
                string s = f.FullName.Replace(strInput, strOutput) + ".csv";

                AppendText(s + " - ");

                if(bSkip)
                {
                    if(new FileInfo(s).Exists)
                    {
                        AppendText("存在" + Environment.NewLine);
                        continue;
                    }
                }

                try
                {
                    PbTickSerializer.WriteCsv(PbTickSerializer.Read(f.FullName), s);
                    AppendText("成功"+Environment.NewLine);
                }
                catch (Exception ex)
                {
                    AppendText("失败" + Environment.NewLine);
                }
            }
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
