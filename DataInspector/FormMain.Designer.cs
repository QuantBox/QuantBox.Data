namespace DataInspector
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvTick = new System.Windows.Forms.DataGridView();
            this.lastPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depth13DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openInterestDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turnoverDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.averagePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tradingDayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actionDayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeHHmmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timessfDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeffDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timessfDiffDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staticDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tickSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pbTick2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.pgBar = new System.Windows.Forms.PropertyGrid();
            this.pgStatic = new System.Windows.Forms.PropertyGrid();
            this.dgvDepth = new System.Windows.Forms.DataGridView();
            this.bidPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bidSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bidCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.askPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.askSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.askCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depthDetail2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFile_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFile_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFile_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFile_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView_Diff = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView_Restore = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView_Convert = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools_ExportDirectory = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTick2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depthDetail2BindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvTick);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(640, 367);
            this.splitContainer1.SplitterDistance = 452;
            this.splitContainer1.TabIndex = 4;
            // 
            // dgvTick
            // 
            this.dgvTick.AllowUserToOrderColumns = true;
            this.dgvTick.AutoGenerateColumns = false;
            this.dgvTick.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvTick.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTick.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lastPriceDataGridViewTextBoxColumn,
            this.depth13DataGridViewTextBoxColumn,
            this.volumeDataGridViewTextBoxColumn,
            this.openInterestDataGridViewTextBoxColumn,
            this.turnoverDataGridViewTextBoxColumn,
            this.averagePriceDataGridViewTextBoxColumn,
            this.tradingDayDataGridViewTextBoxColumn,
            this.actionDayDataGridViewTextBoxColumn,
            this.timeHHmmDataGridViewTextBoxColumn,
            this.timessfDataGridViewTextBoxColumn,
            this.timeffDataGridViewTextBoxColumn,
            this.timessfDiffDataGridViewTextBoxColumn,
            this.barDataGridViewTextBoxColumn,
            this.staticDataGridViewTextBoxColumn,
            this.tickSizeDataGridViewTextBoxColumn});
            this.dgvTick.DataSource = this.pbTick2BindingSource;
            this.dgvTick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTick.Location = new System.Drawing.Point(0, 0);
            this.dgvTick.Name = "dgvTick";
            this.dgvTick.RowTemplate.Height = 23;
            this.dgvTick.Size = new System.Drawing.Size(452, 367);
            this.dgvTick.TabIndex = 1;
            this.dgvTick.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTick_CellValueChanged);
            this.dgvTick.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvTick_RowPostPaint);
            this.dgvTick.SelectionChanged += new System.EventHandler(this.dgvTick_SelectionChanged);
            // 
            // lastPriceDataGridViewTextBoxColumn
            // 
            this.lastPriceDataGridViewTextBoxColumn.DataPropertyName = "LastPrice";
            this.lastPriceDataGridViewTextBoxColumn.HeaderText = "LastPrice";
            this.lastPriceDataGridViewTextBoxColumn.Name = "lastPriceDataGridViewTextBoxColumn";
            this.lastPriceDataGridViewTextBoxColumn.Width = 76;
            // 
            // depth13DataGridViewTextBoxColumn
            // 
            this.depth13DataGridViewTextBoxColumn.DataPropertyName = "Depth1_3";
            this.depth13DataGridViewTextBoxColumn.HeaderText = "Depth1_3";
            this.depth13DataGridViewTextBoxColumn.Name = "depth13DataGridViewTextBoxColumn";
            this.depth13DataGridViewTextBoxColumn.Visible = false;
            this.depth13DataGridViewTextBoxColumn.Width = 79;
            // 
            // volumeDataGridViewTextBoxColumn
            // 
            this.volumeDataGridViewTextBoxColumn.DataPropertyName = "Volume";
            this.volumeDataGridViewTextBoxColumn.HeaderText = "Volume";
            this.volumeDataGridViewTextBoxColumn.Name = "volumeDataGridViewTextBoxColumn";
            this.volumeDataGridViewTextBoxColumn.Width = 67;
            // 
            // openInterestDataGridViewTextBoxColumn
            // 
            this.openInterestDataGridViewTextBoxColumn.DataPropertyName = "OpenInterest";
            this.openInterestDataGridViewTextBoxColumn.HeaderText = "OpenInterest";
            this.openInterestDataGridViewTextBoxColumn.Name = "openInterestDataGridViewTextBoxColumn";
            this.openInterestDataGridViewTextBoxColumn.Width = 93;
            // 
            // turnoverDataGridViewTextBoxColumn
            // 
            this.turnoverDataGridViewTextBoxColumn.DataPropertyName = "Turnover";
            this.turnoverDataGridViewTextBoxColumn.HeaderText = "Turnover";
            this.turnoverDataGridViewTextBoxColumn.Name = "turnoverDataGridViewTextBoxColumn";
            this.turnoverDataGridViewTextBoxColumn.Width = 75;
            // 
            // averagePriceDataGridViewTextBoxColumn
            // 
            this.averagePriceDataGridViewTextBoxColumn.DataPropertyName = "AveragePrice";
            this.averagePriceDataGridViewTextBoxColumn.HeaderText = "AveragePrice";
            this.averagePriceDataGridViewTextBoxColumn.Name = "averagePriceDataGridViewTextBoxColumn";
            this.averagePriceDataGridViewTextBoxColumn.Width = 96;
            // 
            // tradingDayDataGridViewTextBoxColumn
            // 
            this.tradingDayDataGridViewTextBoxColumn.DataPropertyName = "TradingDay";
            this.tradingDayDataGridViewTextBoxColumn.HeaderText = "TradingDay";
            this.tradingDayDataGridViewTextBoxColumn.Name = "tradingDayDataGridViewTextBoxColumn";
            this.tradingDayDataGridViewTextBoxColumn.Width = 87;
            // 
            // actionDayDataGridViewTextBoxColumn
            // 
            this.actionDayDataGridViewTextBoxColumn.DataPropertyName = "ActionDay";
            this.actionDayDataGridViewTextBoxColumn.HeaderText = "ActionDay";
            this.actionDayDataGridViewTextBoxColumn.Name = "actionDayDataGridViewTextBoxColumn";
            this.actionDayDataGridViewTextBoxColumn.Width = 81;
            // 
            // timeHHmmDataGridViewTextBoxColumn
            // 
            this.timeHHmmDataGridViewTextBoxColumn.DataPropertyName = "Time_HHmm";
            this.timeHHmmDataGridViewTextBoxColumn.HeaderText = "Time_HHmm";
            this.timeHHmmDataGridViewTextBoxColumn.Name = "timeHHmmDataGridViewTextBoxColumn";
            this.timeHHmmDataGridViewTextBoxColumn.Width = 93;
            // 
            // timessfDataGridViewTextBoxColumn
            // 
            this.timessfDataGridViewTextBoxColumn.DataPropertyName = "Time_____ssf__";
            this.timessfDataGridViewTextBoxColumn.HeaderText = "Time_____ssf__";
            this.timessfDataGridViewTextBoxColumn.Name = "timessfDataGridViewTextBoxColumn";
            this.timessfDataGridViewTextBoxColumn.Width = 110;
            // 
            // timeffDataGridViewTextBoxColumn
            // 
            this.timeffDataGridViewTextBoxColumn.DataPropertyName = "Time________ff";
            this.timeffDataGridViewTextBoxColumn.HeaderText = "Time________ff";
            this.timeffDataGridViewTextBoxColumn.Name = "timeffDataGridViewTextBoxColumn";
            this.timeffDataGridViewTextBoxColumn.Width = 109;
            // 
            // timessfDiffDataGridViewTextBoxColumn
            // 
            this.timessfDiffDataGridViewTextBoxColumn.DataPropertyName = "Time_ssf_Diff";
            this.timessfDiffDataGridViewTextBoxColumn.HeaderText = "Time_ssf_Diff";
            this.timessfDiffDataGridViewTextBoxColumn.Name = "timessfDiffDataGridViewTextBoxColumn";
            this.timessfDiffDataGridViewTextBoxColumn.Width = 96;
            // 
            // barDataGridViewTextBoxColumn
            // 
            this.barDataGridViewTextBoxColumn.DataPropertyName = "Bar";
            this.barDataGridViewTextBoxColumn.HeaderText = "Bar";
            this.barDataGridViewTextBoxColumn.Name = "barDataGridViewTextBoxColumn";
            this.barDataGridViewTextBoxColumn.Visible = false;
            this.barDataGridViewTextBoxColumn.Width = 48;
            // 
            // staticDataGridViewTextBoxColumn
            // 
            this.staticDataGridViewTextBoxColumn.DataPropertyName = "Static";
            this.staticDataGridViewTextBoxColumn.HeaderText = "Static";
            this.staticDataGridViewTextBoxColumn.Name = "staticDataGridViewTextBoxColumn";
            this.staticDataGridViewTextBoxColumn.Visible = false;
            this.staticDataGridViewTextBoxColumn.Width = 59;
            // 
            // tickSizeDataGridViewTextBoxColumn
            // 
            this.tickSizeDataGridViewTextBoxColumn.DataPropertyName = "TickSize";
            this.tickSizeDataGridViewTextBoxColumn.HeaderText = "TickSize";
            this.tickSizeDataGridViewTextBoxColumn.Name = "tickSizeDataGridViewTextBoxColumn";
            this.tickSizeDataGridViewTextBoxColumn.Width = 73;
            // 
            // pbTick2BindingSource
            // 
            this.pbTick2BindingSource.DataSource = typeof(QuantBox.Data.Serializer.PbTickView);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            this.splitContainer2.Panel1MinSize = 200;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvDepth);
            this.splitContainer2.Size = new System.Drawing.Size(184, 367);
            this.splitContainer2.SplitterDistance = 200;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.pgBar);
            this.splitContainer3.Panel1MinSize = 100;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.pgStatic);
            this.splitContainer3.Size = new System.Drawing.Size(184, 200);
            this.splitContainer3.SplitterDistance = 100;
            this.splitContainer3.TabIndex = 0;
            // 
            // pgBar
            // 
            this.pgBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgBar.HelpVisible = false;
            this.pgBar.Location = new System.Drawing.Point(0, 0);
            this.pgBar.Name = "pgBar";
            this.pgBar.Size = new System.Drawing.Size(184, 100);
            this.pgBar.TabIndex = 0;
            this.pgBar.ToolbarVisible = false;
            this.pgBar.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgBar_PropertyValueChanged);
            // 
            // pgStatic
            // 
            this.pgStatic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgStatic.HelpVisible = false;
            this.pgStatic.Location = new System.Drawing.Point(0, 0);
            this.pgStatic.Name = "pgStatic";
            this.pgStatic.Size = new System.Drawing.Size(184, 96);
            this.pgStatic.TabIndex = 0;
            this.pgStatic.ToolbarVisible = false;
            this.pgStatic.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgStatic_PropertyValueChanged);
            // 
            // dgvDepth
            // 
            this.dgvDepth.AllowUserToOrderColumns = true;
            this.dgvDepth.AutoGenerateColumns = false;
            this.dgvDepth.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvDepth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepth.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bidPriceDataGridViewTextBoxColumn,
            this.bidSizeDataGridViewTextBoxColumn,
            this.bidCountDataGridViewTextBoxColumn,
            this.askPriceDataGridViewTextBoxColumn,
            this.askSizeDataGridViewTextBoxColumn,
            this.askCountDataGridViewTextBoxColumn});
            this.dgvDepth.DataSource = this.depthDetail2BindingSource;
            this.dgvDepth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDepth.Location = new System.Drawing.Point(0, 0);
            this.dgvDepth.Name = "dgvDepth";
            this.dgvDepth.RowTemplate.Height = 23;
            this.dgvDepth.Size = new System.Drawing.Size(184, 163);
            this.dgvDepth.TabIndex = 1;
            this.dgvDepth.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDepth_CellValueChanged);
            this.dgvDepth.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDepth_RowPostPaint);
            // 
            // bidPriceDataGridViewTextBoxColumn
            // 
            this.bidPriceDataGridViewTextBoxColumn.DataPropertyName = "BidPrice";
            this.bidPriceDataGridViewTextBoxColumn.HeaderText = "BidPrice";
            this.bidPriceDataGridViewTextBoxColumn.Name = "bidPriceDataGridViewTextBoxColumn";
            this.bidPriceDataGridViewTextBoxColumn.Width = 71;
            // 
            // bidSizeDataGridViewTextBoxColumn
            // 
            this.bidSizeDataGridViewTextBoxColumn.DataPropertyName = "BidSize";
            this.bidSizeDataGridViewTextBoxColumn.HeaderText = "BidSize";
            this.bidSizeDataGridViewTextBoxColumn.Name = "bidSizeDataGridViewTextBoxColumn";
            this.bidSizeDataGridViewTextBoxColumn.Width = 67;
            // 
            // bidCountDataGridViewTextBoxColumn
            // 
            this.bidCountDataGridViewTextBoxColumn.DataPropertyName = "BidCount";
            this.bidCountDataGridViewTextBoxColumn.HeaderText = "BidCount";
            this.bidCountDataGridViewTextBoxColumn.Name = "bidCountDataGridViewTextBoxColumn";
            this.bidCountDataGridViewTextBoxColumn.Width = 75;
            // 
            // askPriceDataGridViewTextBoxColumn
            // 
            this.askPriceDataGridViewTextBoxColumn.DataPropertyName = "AskPrice";
            this.askPriceDataGridViewTextBoxColumn.HeaderText = "AskPrice";
            this.askPriceDataGridViewTextBoxColumn.Name = "askPriceDataGridViewTextBoxColumn";
            this.askPriceDataGridViewTextBoxColumn.Width = 74;
            // 
            // askSizeDataGridViewTextBoxColumn
            // 
            this.askSizeDataGridViewTextBoxColumn.DataPropertyName = "AskSize";
            this.askSizeDataGridViewTextBoxColumn.HeaderText = "AskSize";
            this.askSizeDataGridViewTextBoxColumn.Name = "askSizeDataGridViewTextBoxColumn";
            this.askSizeDataGridViewTextBoxColumn.Width = 70;
            // 
            // askCountDataGridViewTextBoxColumn
            // 
            this.askCountDataGridViewTextBoxColumn.DataPropertyName = "AskCount";
            this.askCountDataGridViewTextBoxColumn.HeaderText = "AskCount";
            this.askCountDataGridViewTextBoxColumn.Name = "askCountDataGridViewTextBoxColumn";
            this.askCountDataGridViewTextBoxColumn.Width = 78;
            // 
            // depthDetail2BindingSource
            // 
            this.depthDetail2BindingSource.DataSource = typeof(QuantBox.Data.Serializer.DepthDetailView);
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile_Open,
            this.menuFile_Save,
            this.menuFile_Export,
            this.menuFile_Exit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "&File";
            // 
            // menuFile_Open
            // 
            this.menuFile_Open.Name = "menuFile_Open";
            this.menuFile_Open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuFile_Open.Size = new System.Drawing.Size(163, 22);
            this.menuFile_Open.Text = "&Open...";
            this.menuFile_Open.Click += new System.EventHandler(this.menuFile_Open_Click);
            // 
            // menuFile_Save
            // 
            this.menuFile_Save.Name = "menuFile_Save";
            this.menuFile_Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuFile_Save.Size = new System.Drawing.Size(163, 22);
            this.menuFile_Save.Text = "&Save As...";
            this.menuFile_Save.Click += new System.EventHandler(this.menuFile_SaveAs_Click);
            // 
            // menuFile_Export
            // 
            this.menuFile_Export.Name = "menuFile_Export";
            this.menuFile_Export.Size = new System.Drawing.Size(163, 22);
            this.menuFile_Export.Text = "Export...";
            this.menuFile_Export.Click += new System.EventHandler(this.menuFile_Export_Click);
            // 
            // menuFile_Exit
            // 
            this.menuFile_Exit.Name = "menuFile_Exit";
            this.menuFile_Exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.menuFile_Exit.Size = new System.Drawing.Size(163, 22);
            this.menuFile_Exit.Text = "&Exit";
            this.menuFile_Exit.Click += new System.EventHandler(this.menuFile_Exit_Click);
            // 
            // menuView
            // 
            this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuView_Diff,
            this.menuView_Restore,
            this.menuView_Convert});
            this.menuView.Name = "menuView";
            this.menuView.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.menuView.Size = new System.Drawing.Size(44, 20);
            this.menuView.Text = "&View";
            // 
            // menuView_Diff
            // 
            this.menuView_Diff.Name = "menuView_Diff";
            this.menuView_Diff.Size = new System.Drawing.Size(116, 22);
            this.menuView_Diff.Text = "Diff";
            this.menuView_Diff.Click += new System.EventHandler(this.menuView_Diff_Click);
            // 
            // menuView_Restore
            // 
            this.menuView_Restore.Name = "menuView_Restore";
            this.menuView_Restore.Size = new System.Drawing.Size(116, 22);
            this.menuView_Restore.Text = "Restore";
            this.menuView_Restore.Click += new System.EventHandler(this.menuView_Restore_Click);
            // 
            // menuView_Convert
            // 
            this.menuView_Convert.Name = "menuView_Convert";
            this.menuView_Convert.Size = new System.Drawing.Size(116, 22);
            this.menuView_Convert.Text = "Convert";
            this.menuView_Convert.Click += new System.EventHandler(this.menuView_Convert_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuView,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(640, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTools_ExportDirectory});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // menuTools_ExportDirectory
            // 
            this.menuTools_ExportDirectory.Name = "menuTools_ExportDirectory";
            this.menuTools_ExportDirectory.Size = new System.Drawing.Size(167, 22);
            this.menuTools_ExportDirectory.Text = "Export Directory...";
            this.menuTools_ExportDirectory.Click += new System.EventHandler(this.menuTools_ExportDirectory_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 391);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormMain";
            this.Text = "Inspector";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTick2BindingSource)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depthDetail2BindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFile_Open;
        private System.Windows.Forms.ToolStripMenuItem menuFile_Save;
        private System.Windows.Forms.ToolStripMenuItem menuFile_Exit;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvTick;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvDepth;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.BindingSource pbTick2BindingSource;
        private System.Windows.Forms.ToolStripMenuItem menuView_Diff;
        private System.Windows.Forms.ToolStripMenuItem menuView_Restore;
        private System.Windows.Forms.ToolStripMenuItem menuView_Convert;
        private System.Windows.Forms.PropertyGrid pgBar;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.PropertyGrid pgStatic;
        private System.Windows.Forms.DataGridViewTextBoxColumn bidPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bidSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bidCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn askPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn askSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn askCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource depthDetail2BindingSource;
        private System.Windows.Forms.ToolStripMenuItem menuFile_Export;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuTools_ExportDirectory;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn depth13DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn openInterestDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn turnoverDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn averagePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tradingDayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actionDayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeHHmmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timessfDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeffDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timessfDiffDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn barDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn staticDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tickSizeDataGridViewTextBoxColumn;

    }
}

