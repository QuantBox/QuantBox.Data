using QuantBox.Data.Serializer;
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
using System.Windows.Forms;

namespace DataInspector
{
    public partial class FormMain : Form
    {
        private IEnumerable<PbTick> listTickData;
        private List<PbTickView> listTickView;

        private string strCurrentFileName;
        private int nTickCurrentRowIndex;
        private bool bValueChanged;

        private int ColumnIndex;
        private int RowIndex;
        private bool Selected;
        private int FirstDisplayedScrollingRowIndex;
        private int HorizontalScrollingOffset;

        enum ViewType
        {
            Diff,
            Restore,
            Convert,
        }

        private ViewType eViewType;

        public FormMain()
        {
            InitializeComponent();
        }


        private void CheckSaved()
        {
            if (this.bValueChanged)
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

                PbTickSerializer.WriteCsv(this.listTickData, pathChosen);
            }
        }

        private void ViewToDataByViewType()
        {
            PbTickCodec Codec = new PbTickCodec();
            List<PbTick> tempList;

            switch (eViewType)
            {
                case ViewType.Diff:
                    this.listTickData = Codec.View2Data(this.listTickView, true);
                    break;
                case ViewType.Restore:
                    tempList = Codec.View2Data(this.listTickView, true);
                    this.listTickData = Codec.Diff(tempList);
                    break;
                case ViewType.Convert:
                    tempList = Codec.View2Data(this.listTickView, false);
                    this.listTickData = Codec.Diff(tempList);
                    break;
            }
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

                PbTickSerializer.Write(this.listTickData, pathChosen);
                ValueChanged(false);
            }
        }

        private void dgvTick_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTick.CurrentRow == null)
                return;

            nTickCurrentRowIndex = dgvTick.CurrentRow.Index;
            if (listTickView == null || nTickCurrentRowIndex >= listTickView.Count)
                return;

            PbTickView tick2 = listTickView[nTickCurrentRowIndex];

            BarInfoView bi = tick2.Bar;
            if (bi == null)
            {
                //bi = new BarInfoView();
            }
            pgBar.SelectedObject = bi;

            StaticInfoView si = tick2.Static;
            if (si == null)
            {
                //si = new StaticInfoView();
            }
            pgStatic.SelectedObject = si;

            ConfigInfoView ci = tick2.Config;
            if (ci == null)
            {
                //ci = new ConfigInfoView();
            }
            pgConfig.SelectedObject = ci;

            StockSplitInfoView ssi = tick2.Split;
            if (ssi == null)
            {
                //ssi = new StockSplitInfoView();
            }
            pgSplit.SelectedObject = ssi;

            dgvDepth.DataSource = Int2DoubleConverter.ToList(tick2.Depth1_3);
        }

        private void ValueChanged(bool changed)
        {
            if (changed)
            {
                this.Text = "*" + strCurrentFileName;
            }
            else
            {
                this.Text = strCurrentFileName;
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

            PbTickView tick2 = listTickView[nTickCurrentRowIndex];

            List<DepthDetailView> list = (List<DepthDetailView>)dgvDepth.DataSource;

            tick2.Depth1_3 = Int2DoubleConverter.FromList(list);
        }

        private void SingleCheck(object sender)
        {
            ColumnIndex = dgvTick.CurrentCell.ColumnIndex;
            RowIndex = dgvTick.CurrentCell.RowIndex;
            Selected = dgvTick.CurrentRow.Selected;
            FirstDisplayedScrollingRowIndex = dgvTick.FirstDisplayedScrollingRowIndex;
            HorizontalScrollingOffset = dgvTick.HorizontalScrollingOffset;

            menuView_Diff.Checked = false;
            menuView_Restore.Checked = false;
            menuView_Convert.Checked = false;

            ToolStripMenuItem current = (ToolStripMenuItem)sender;
            current.Checked = true;

            if (current == menuView_Diff)
            {
                eViewType = ViewType.Diff;
            }
            else if (current == menuView_Restore)
            {
                eViewType = ViewType.Restore;
            }
            else
            {
                eViewType = ViewType.Convert;
            }
        }

        private void menuView_Diff_Click(object sender, EventArgs e)
        {
            ViewToDataByViewType();

            SingleCheck(sender);

            PbTickCodec Codec = new PbTickCodec();
            listTickView = Codec.Data2View(this.listTickData, true);
            dgvTick.DataSource = this.listTickView;

            dgvTick.CurrentCell = dgvTick.Rows[RowIndex].Cells[ColumnIndex];
            if (Selected)
                dgvTick.CurrentRow.Selected = Selected;
            dgvTick.FirstDisplayedScrollingRowIndex = FirstDisplayedScrollingRowIndex;
            dgvTick.HorizontalScrollingOffset = HorizontalScrollingOffset;
        }

        private void menuView_Restore_Click(object sender, EventArgs e)
        {
            ViewToDataByViewType();

            SingleCheck(sender);

            PbTickCodec Codec = new PbTickCodec();

            listTickView = Codec.Data2View(Codec.Restore(this.listTickData), true);
            dgvTick.DataSource = listTickView;

            dgvTick.CurrentCell = dgvTick.Rows[RowIndex].Cells[ColumnIndex];
            if (Selected)
                dgvTick.CurrentRow.Selected = Selected;
            dgvTick.FirstDisplayedScrollingRowIndex = FirstDisplayedScrollingRowIndex;
            dgvTick.HorizontalScrollingOffset = HorizontalScrollingOffset;
        }

        private void menuView_Convert_Click(object sender, EventArgs e)
        {
            ViewToDataByViewType();

            SingleCheck(sender);

            PbTickCodec Codec = new PbTickCodec();

            listTickView = Codec.Data2View(Codec.Restore(this.listTickData), false);
            dgvTick.DataSource = listTickView;

            dgvTick.CurrentCell = dgvTick.Rows[RowIndex].Cells[ColumnIndex];
            if (Selected)
                dgvTick.CurrentRow.Selected = Selected;
            dgvTick.FirstDisplayedScrollingRowIndex = FirstDisplayedScrollingRowIndex;
            dgvTick.HorizontalScrollingOffset = HorizontalScrollingOffset;
        }

        private void menuTools_ExportDirectory_Click(object sender, EventArgs e)
        {
            FormExport form2 = new FormExport();
            form2.Show();
        }

        private void dgvTick_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
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
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
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
            string pathChosen = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
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
            Tuple<Stream, string, double> tuple = ReadToStream(pathChosen);
            
            if (tuple == null)
            {
                return;
            }

            Stream stream = tuple.Item1;
            try
            {
                listTickData = PbTickSerializer.Read(stream);

                strCurrentFileName = string.Format("{0} ({1}/{2}={3})",
                    tuple.Item2, tuple.Item3, listTickData.Count(), tuple.Item3 / listTickData.Count());

                ValueChanged(false);

                PbTickCodec Codec = new PbTickCodec();

                listTickView = Codec.Data2View(this.listTickData, true);
                dgvTick.DataSource = this.listTickView;

                SingleCheck(menuView_Diff);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private Tuple<Stream, string, double> ReadToStream(string pathChosen)
        {
            SevenZipExtractor extractor;
            try
            {
                extractor = new SevenZipExtractor(pathChosen);
            }
            catch (Exception ex)
            {
                return DirectReadToStream(pathChosen);
            }
            
            int cnt = extractor.ArchiveFileData.Count;
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
            FileStream stream = File.OpenRead(pathChosen);

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