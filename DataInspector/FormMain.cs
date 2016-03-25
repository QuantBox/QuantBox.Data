using QuantBox.Data.Serializer.V2;
using SevenZip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace DataInspector
{
    public partial class FormMain : Form
    {
        private IEnumerable<PbTick> listTickData;
        private List<PbTickView> listTickView;

        private string strCurrentFileName;
        private string strCurrentFilePath;
        private int nTickCurrentRowIndex;
        private bool bValueChanged;

        private int ColumnIndex;
        private int RowIndex;
        private bool Selected;
        private int FirstDisplayedScrollingRowIndex;
        private int HorizontalScrollingOffset;

        public FormMain()
        {
            InitializeComponent();
        }


        private void CheckSaved()
        {
            if (bValueChanged)
            {
                bool b = MessageBox.Show("Save changes?", "", MessageBoxButtons.YesNo) == DialogResult.Yes;
                if (b)
                    SaveChanges();
            }
        }

        private void menuFile_Exit_Click(object sender, EventArgs e)
        {
            CheckSaved();
            Application.Exit();
        }

        private void menuFile_Open_Click(object sender, EventArgs e)
        {
            CheckSaved();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Protobuf Data Zero files (*.pd0)|*.pd0|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pathChosen = openFileDialog.FileName;
                ReadFromFile(pathChosen);
            }
        }

        private void menuFile_SaveAs_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void menuFile_Export_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV文件|*.csv";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string pathChosen = saveFileDialog.FileName;

                // 将界面数据生成差分数据
                ViewToDataByViewType();

                PbTickSerializer.WriteCsv(listTickData, pathChosen);
            }
        }

        private void ViewToDataByViewType()
        {
            PbTickCodec Codec = new PbTickCodec();
            listTickData = Codec.View2Data(listTickView, true);
        }

        private void SaveChanges()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Portable Data Zero files (*.pd0)|*.pd0|All files (*.*)|*.*";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string pathChosen = saveFileDialog.FileName;

                ViewToDataByViewType();

                PbTickSerializer pts = new PbTickSerializer();
                pts.Write(listTickData, pathChosen);

                ValueChanged(false);
            }
        }

        private void dgvTick_SelectionChanged(object sender, EventArgs e)
        {
            dgvTick_SelectionChanged();
        }

        private void dgvTick_SelectionChanged()
        {
            if (dgvTick.CurrentRow == null)
                return;

            nTickCurrentRowIndex = dgvTick.CurrentRow.Index;
            if (listTickView == null || nTickCurrentRowIndex >= listTickView.Count)
                return;

            PbTickView tick2 = listTickView[nTickCurrentRowIndex];

            pgBar.SelectedObject = tick2.Bar;
            pgStatic.SelectedObject = tick2.Static;
            pgConfig.SelectedObject = tick2.Config;
            pgSplit.SelectedObject = tick2.Split;

            if (dgvDepth.CurrentCell == null)
            {
                dgvDepth.DataSource = tick2.DepthList;
                return;
            }

            int ColumnIndex = dgvDepth.CurrentCell.ColumnIndex;
            int RowIndex = dgvDepth.CurrentCell.RowIndex;
            bool Selected = dgvDepth.CurrentRow.Selected;
            int FirstDisplayedScrollingRowIndex = dgvDepth.FirstDisplayedScrollingRowIndex;
            int HorizontalScrollingOffset = dgvDepth.HorizontalScrollingOffset;

            dgvDepth.DataSource = tick2.DepthList;

            if (tick2.DepthList != null)
                RowIndex = Math.Min(RowIndex, tick2.DepthList.Count - 1);

            dgvDepth.CurrentCell = dgvDepth.Rows[RowIndex].Cells[ColumnIndex];
            if (Selected)
                dgvDepth.CurrentRow.Selected = Selected;
            dgvDepth.FirstDisplayedScrollingRowIndex = FirstDisplayedScrollingRowIndex;
            dgvDepth.HorizontalScrollingOffset = HorizontalScrollingOffset;


            // 设置背景色
            int pos = DepthListHelper.FindAsk1PositionDescending(tick2.DepthList, tick2.AskPrice1);

            for (int i = 0; i <= pos; ++i)
            {
                for (int j = 0; j < dgvDepth.Rows[i].Cells.Count; ++j)
                {
                    dgvDepth.Rows[i].Cells[j].Style.BackColor = Color.Tomato;
                }
            }
        }

        private void ValueChanged(bool changed)
        {
            if (changed)
            {
                Text = "*" + strCurrentFileName;
            }
            else
            {
                Text = strCurrentFileName;
            }

            bValueChanged = changed;
        }

        private void dgvTick_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (listTickView == null || nTickCurrentRowIndex >= listTickView.Count)
                return;

            ValueChanged(true);
        }

        private void pgBar_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            ValueChanged(true);

            PbTickView tick2 = listTickView[nTickCurrentRowIndex];
            tick2.Bar = (BarInfoView)pgBar.SelectedObject;
        }

        private void pgStatic_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            ValueChanged(true);

            PbTickView tick2 = listTickView[nTickCurrentRowIndex];
            tick2.Static = (StaticInfoView)pgStatic.SelectedObject;
        }

        private void pgSplit_Click(object sender, EventArgs e)
        {
            ValueChanged(true);

            PbTickView tick2 = listTickView[nTickCurrentRowIndex];
            tick2.Split = (StockSplitInfoView)pgSplit.SelectedObject;
        }

        private void pgConfig_Click(object sender, EventArgs e)
        {
            ValueChanged(true);

            PbTickView tick2 = listTickView[nTickCurrentRowIndex];
            tick2.Config = (ConfigInfoView)pgConfig.SelectedObject;
        }

        private void dgvDepth_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (listTickView == null || nTickCurrentRowIndex >= listTickView.Count)
                return;

            ValueChanged(true);
        }

        private void SingleCheck(object sender)
        {
            ColumnIndex = dgvTick.CurrentCell.ColumnIndex;
            RowIndex = dgvTick.CurrentCell.RowIndex;
            Selected = dgvTick.CurrentRow.Selected;
            FirstDisplayedScrollingRowIndex = dgvTick.FirstDisplayedScrollingRowIndex;
            HorizontalScrollingOffset = dgvTick.HorizontalScrollingOffset;


            ToolStripMenuItem current = (ToolStripMenuItem)sender;
            current.Checked = true;
        }

        private void menuTools_ExportDirectory_Click(object sender, EventArgs e)
        {
            FormExport form2 = new FormExport();
            form2.Show();
        }

        private void dgvTick_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgv.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgv.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgv.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void dgvDepth_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgv.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgv.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgv.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void dgvTick_DragDrop(object sender, DragEventArgs e)
        {
            string pathChosen = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            ReadFromFile(pathChosen);
        }

        private void dgvTick_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        #region Decompress To Stream
        private void ReadFromFile(string pathChosen)
        {
            strCurrentFilePath = pathChosen;

            Tuple<Stream, string, double> tuple = ReadToStream(strCurrentFilePath);
            
            if (tuple == null)
            {
                return;
            }

            Stream stream = tuple.Item1;
            try
            {
                QuantBox.Data.Serializer.PbTickSerializer pts = new QuantBox.Data.Serializer.PbTickSerializer();
                listTickData = pts.Read(stream).ToList();

                strCurrentFileName = string.Format("{0} ({1}/{2}={3})",
                    tuple.Item2, tuple.Item3, listTickData.Count(), tuple.Item3 / listTickData.Count());

                ValueChanged(false);

                PbTickCodec Codec = new PbTickCodec();

                listTickView = Codec.Data2View(listTickData, true);
                dgvTick.DataSource = listTickView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private Tuple<Stream, string, double> ReadToStream(string pathChosen)
        {
            int cnt = 0;
            SevenZipExtractor extractor;
            try
            {
                extractor = new SevenZipExtractor(pathChosen);
                cnt = extractor.ArchiveFileData.Count;
            }
            catch (SevenZipException ex)
            {
                MessageBox.Show(ex.ToString());
                return DirectReadToStream(pathChosen);
            }
            catch (ArgumentException ex)
            {
                return DirectReadToStream(pathChosen);
            }
            catch (Exception ex)
            {
                return DirectReadToStream(pathChosen);
            }
            
            List<string> listFileNames = new List<string>();

            for (int i = 0; i < cnt; i++)
            {
                listFileNames.Add(extractor.ArchiveFileNames[i]);
            }

            string fileName = GetFileChosen(listFileNames);
            MemoryStream stream = new MemoryStream();

            try
            {
                extractor.ExtractFile(fileName, stream);
                stream.Position = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

            double fileLength = stream.Length;

            Tuple<Stream, string, double> tuple = new Tuple<Stream, string, double>(stream, fileName, fileLength);
            return tuple;
        }

        private Tuple<Stream, string, double> DirectReadToStream(string pathChosen)
        {
            FileStream stream = File.Open(pathChosen, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            FileInfo fi = new FileInfo(pathChosen);
            int index = pathChosen.LastIndexOf(@"\");
            string fileName = pathChosen.Substring(index + 1, pathChosen.Length - index - 1);
            double fileLength = (double)fi.Length;

            Tuple<Stream, string, double> tuple = new Tuple<Stream, string, double>(stream, fileName, fileLength);
            return tuple;
        }

        private string GetFileChosen(List<string> listFileNames)
        {
            string name;

            FormDecompress formDecompress = new FormDecompress(listFileNames);
            formDecompress.ShowDialog();
            name = formDecompress.FileName;

            return name;
        }

        #endregion


        private System.Timers.Timer _Timer = new System.Timers.Timer();
        private void menuControl_Play_Click(object sender, EventArgs e)
        {
            _Timer.Elapsed += OnTimerElapsed;
            // 每0.5秒遍历一次
            _Timer.Interval = 500;
            _Timer.Start();
        }

        private void menuControl_Stop_Click(object sender, EventArgs e)
        {
            _Timer.Elapsed -= OnTimerElapsed;
            _Timer.Stop();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs args)
        {
            ColumnIndex = dgvTick.CurrentCell.ColumnIndex;
            RowIndex = dgvTick.CurrentCell.RowIndex;
            Selected = dgvTick.CurrentRow.Selected;
            FirstDisplayedScrollingRowIndex = dgvTick.FirstDisplayedScrollingRowIndex;
            HorizontalScrollingOffset = dgvTick.HorizontalScrollingOffset;

            RowIndex = Math.Min(RowIndex+1, dgvTick.RowCount - 1);

            Invoke((EventHandler)delegate
            {
                dgvTick.CurrentCell = dgvTick.Rows[RowIndex].Cells[ColumnIndex];
                if (Selected)
                    dgvTick.CurrentRow.Selected = Selected;
            });
        }

        private void menuFile_Reload_Click(object sender, EventArgs e)
        {
            CheckSaved();

            ColumnIndex = dgvTick.CurrentCell.ColumnIndex;
            RowIndex = dgvTick.CurrentCell.RowIndex;
            Selected = dgvTick.CurrentRow.Selected;
            FirstDisplayedScrollingRowIndex = dgvTick.FirstDisplayedScrollingRowIndex;
            HorizontalScrollingOffset = dgvTick.HorizontalScrollingOffset;

            //RowIndex = Math.Min(RowIndex + 1, dgvTick.RowCount - 1);

            ReadFromFile(strCurrentFilePath);

            Invoke((EventHandler)delegate
            {
                dgvTick.CurrentCell = dgvTick.Rows[RowIndex].Cells[ColumnIndex];
                if (Selected)
                    dgvTick.CurrentRow.Selected = Selected;
                dgvTick.FirstDisplayedScrollingRowIndex = FirstDisplayedScrollingRowIndex;
                dgvTick.HorizontalScrollingOffset = HorizontalScrollingOffset;
            });
        }

        #region Decompress To Folder

        //private void ReadFromFile(string pathChosen)
        //{
        //    string path = "";

        //    try
        //    {
        //        path = Decompress(pathChosen);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //    try
        //    {
        //        listTickData = PbTickSerializer.Read(path);
        //        FileInfo fi = new FileInfo(path);

        //        int index = path.LastIndexOf(@"\");
        //        string safeFileName = path.Substring(index + 1, path.Length - index - 1);

        //        strCurrentFileName = string.Format("{0} ({1}/{2}={3})",
        //            safeFileName, fi.Length, listTickData.Count(), (double)fi.Length / listTickData.Count());

        //        ValueChanged(false);

        //        PbTickCodec Codec = new PbTickCodec();

        //        listTickView = Codec.Data2View(this.listTickData, true);
        //        dgvTick.DataSource = this.listTickView;

        //        SingleCheck(menuView_Diff);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //private string Decompress(string pathChosen)
        //{
        //    int index = pathChosen.LastIndexOf(@".");
        //    string pathOut = pathChosen.Substring(0, index);
        //    string suffix = pathChosen.Substring(index + 1, pathChosen.Length - index - 1);

        //    if (suffix != "7z")
        //    {
        //        return pathChosen;
        //    }

        //    using (SevenZipExtractor tmp = new SevenZipExtractor(pathChosen))
        //    {
        //        int cnt = tmp.ArchiveFileData.Count;

        //        for (int i = 0; i < cnt; i++)
        //        {
        //            tmp.ExtractFiles(pathOut, tmp.ArchiveFileData[i].Index);
        //        }

        //        if (cnt == 1)
        //        {
        //            string decompressedFullPath = pathOut + @"\" + tmp.ArchiveFileData[0].FileName;
        //            return decompressedFullPath;
        //        }
        //        else
        //        {
        //            OpenFileDialog openFileDialog = new OpenFileDialog();
        //            openFileDialog.Filter = "Protobuf Data Zero files (*.pd0)|*.pd0|All files (*.*)|*.*";
        //            openFileDialog.InitialDirectory = pathOut;

        //            if (openFileDialog.ShowDialog() == DialogResult.OK)
        //            {
        //                string decompressedFullPath = openFileDialog.FileName;
        //                return decompressedFullPath;
        //            }
        //            else
        //            {
        //                throw new Exception("No file chosen.");
        //            }
        //        }
        //    }
        //}

        #endregion
    }
}