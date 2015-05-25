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
            this.tradingDayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actionDayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeHHmmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timessfDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeffDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localTimeMsecDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.askPrice1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openInterestDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turnoverDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.averagePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pbTickViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.pgBar = new System.Windows.Forms.PropertyGrid();
            this.pgSplit = new System.Windows.Forms.PropertyGrid();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.pgStatic = new System.Windows.Forms.PropertyGrid();
            this.pgConfig = new System.Windows.Forms.PropertyGrid();
            this.dgvDepth = new System.Windows.Forms.DataGridView();
            this.depthItemViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFile_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFile_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFile_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFile_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools_ExportDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuControl_Play = new System.Windows.Forms.ToolStripMenuItem();
            this.menuControl_Stop = new System.Windows.Forms.ToolStripMenuItem();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTickViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depthItemViewBindingSource)).BeginInit();
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
            this.splitContainer1.Size = new System.Drawing.Size(729, 462);
            this.splitContainer1.SplitterDistance = 514;
            this.splitContainer1.TabIndex = 4;
            // 
            // dgvTick
            // 
            this.dgvTick.AllowDrop = true;
            this.dgvTick.AllowUserToOrderColumns = true;
            this.dgvTick.AutoGenerateColumns = false;
            this.dgvTick.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvTick.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTick.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tradingDayDataGridViewTextBoxColumn,
            this.actionDayDataGridViewTextBoxColumn,
            this.timeHHmmDataGridViewTextBoxColumn,
            this.timessfDataGridViewTextBoxColumn,
            this.timeffDataGridViewTextBoxColumn,
            this.localTimeMsecDataGridViewTextBoxColumn,
            this.lastPriceDataGridViewTextBoxColumn,
            this.askPrice1DataGridViewTextBoxColumn,
            this.volumeDataGridViewTextBoxColumn,
            this.openInterestDataGridViewTextBoxColumn,
            this.turnoverDataGridViewTextBoxColumn,
            this.averagePriceDataGridViewTextBoxColumn});
            this.dgvTick.DataSource = this.pbTickViewBindingSource;
            this.dgvTick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTick.Location = new System.Drawing.Point(0, 0);
            this.dgvTick.Name = "dgvTick";
            this.dgvTick.RowTemplate.Height = 23;
            this.dgvTick.Size = new System.Drawing.Size(514, 462);
            this.dgvTick.TabIndex = 1;
            this.dgvTick.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTick_CellValueChanged);
            this.dgvTick.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvTick_RowPostPaint);
            this.dgvTick.SelectionChanged += new System.EventHandler(this.dgvTick_SelectionChanged);
            this.dgvTick.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvTick_DragDrop);
            this.dgvTick.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvTick_DragEnter);
            // 
            // tradingDayDataGridViewTextBoxColumn
            // 
            this.tradingDayDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.tradingDayDataGridViewTextBoxColumn.DataPropertyName = "TradingDay";
            this.tradingDayDataGridViewTextBoxColumn.HeaderText = "TradingDay";
            this.tradingDayDataGridViewTextBoxColumn.Name = "tradingDayDataGridViewTextBoxColumn";
            this.tradingDayDataGridViewTextBoxColumn.Width = 70;
            // 
            // actionDayDataGridViewTextBoxColumn
            // 
            this.actionDayDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.actionDayDataGridViewTextBoxColumn.DataPropertyName = "ActionDay";
            this.actionDayDataGridViewTextBoxColumn.HeaderText = "ActionDay";
            this.actionDayDataGridViewTextBoxColumn.Name = "actionDayDataGridViewTextBoxColumn";
            this.actionDayDataGridViewTextBoxColumn.Width = 70;
            // 
            // timeHHmmDataGridViewTextBoxColumn
            // 
            this.timeHHmmDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.timeHHmmDataGridViewTextBoxColumn.DataPropertyName = "Time_HHmm";
            this.timeHHmmDataGridViewTextBoxColumn.HeaderText = "Time_HHmm";
            this.timeHHmmDataGridViewTextBoxColumn.Name = "timeHHmmDataGridViewTextBoxColumn";
            this.timeHHmmDataGridViewTextBoxColumn.Width = 50;
            // 
            // timessfDataGridViewTextBoxColumn
            // 
            this.timessfDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.timessfDataGridViewTextBoxColumn.DataPropertyName = "Time_____ssf__";
            this.timessfDataGridViewTextBoxColumn.HeaderText = "Time_____ssf__";
            this.timessfDataGridViewTextBoxColumn.Name = "timessfDataGridViewTextBoxColumn";
            this.timessfDataGridViewTextBoxColumn.Width = 50;
            // 
            // timeffDataGridViewTextBoxColumn
            // 
            this.timeffDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.timeffDataGridViewTextBoxColumn.DataPropertyName = "Time________ff";
            this.timeffDataGridViewTextBoxColumn.HeaderText = "Time________ff";
            this.timeffDataGridViewTextBoxColumn.Name = "timeffDataGridViewTextBoxColumn";
            this.timeffDataGridViewTextBoxColumn.Width = 50;
            // 
            // localTimeMsecDataGridViewTextBoxColumn
            // 
            this.localTimeMsecDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.localTimeMsecDataGridViewTextBoxColumn.DataPropertyName = "LocalTime_Msec";
            this.localTimeMsecDataGridViewTextBoxColumn.HeaderText = "LocalTime_Msec";
            this.localTimeMsecDataGridViewTextBoxColumn.Name = "localTimeMsecDataGridViewTextBoxColumn";
            this.localTimeMsecDataGridViewTextBoxColumn.Width = 50;
            // 
            // lastPriceDataGridViewTextBoxColumn
            // 
            this.lastPriceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.lastPriceDataGridViewTextBoxColumn.DataPropertyName = "LastPrice";
            this.lastPriceDataGridViewTextBoxColumn.HeaderText = "LastPrice";
            this.lastPriceDataGridViewTextBoxColumn.Name = "lastPriceDataGridViewTextBoxColumn";
            this.lastPriceDataGridViewTextBoxColumn.Width = 80;
            // 
            // askPrice1DataGridViewTextBoxColumn
            // 
            this.askPrice1DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.askPrice1DataGridViewTextBoxColumn.DataPropertyName = "AskPrice1";
            this.askPrice1DataGridViewTextBoxColumn.HeaderText = "AskPrice1";
            this.askPrice1DataGridViewTextBoxColumn.Name = "askPrice1DataGridViewTextBoxColumn";
            this.askPrice1DataGridViewTextBoxColumn.Width = 80;
            // 
            // volumeDataGridViewTextBoxColumn
            // 
            this.volumeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.volumeDataGridViewTextBoxColumn.DataPropertyName = "Volume";
            this.volumeDataGridViewTextBoxColumn.HeaderText = "Volume";
            this.volumeDataGridViewTextBoxColumn.Name = "volumeDataGridViewTextBoxColumn";
            // 
            // openInterestDataGridViewTextBoxColumn
            // 
            this.openInterestDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.openInterestDataGridViewTextBoxColumn.DataPropertyName = "OpenInterest";
            this.openInterestDataGridViewTextBoxColumn.HeaderText = "OpenInterest";
            this.openInterestDataGridViewTextBoxColumn.Name = "openInterestDataGridViewTextBoxColumn";
            // 
            // turnoverDataGridViewTextBoxColumn
            // 
            this.turnoverDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.turnoverDataGridViewTextBoxColumn.DataPropertyName = "Turnover";
            this.turnoverDataGridViewTextBoxColumn.HeaderText = "Turnover";
            this.turnoverDataGridViewTextBoxColumn.Name = "turnoverDataGridViewTextBoxColumn";
            this.turnoverDataGridViewTextBoxColumn.Width = 120;
            // 
            // averagePriceDataGridViewTextBoxColumn
            // 
            this.averagePriceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.averagePriceDataGridViewTextBoxColumn.DataPropertyName = "AveragePrice";
            this.averagePriceDataGridViewTextBoxColumn.HeaderText = "AveragePrice";
            this.averagePriceDataGridViewTextBoxColumn.Name = "averagePriceDataGridViewTextBoxColumn";
            // 
            // pbTickViewBindingSource
            // 
            this.pbTickViewBindingSource.DataSource = typeof(QuantBox.Data.Serializer.V2.PbTickView);
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
            this.splitContainer2.Size = new System.Drawing.Size(211, 462);
            this.splitContainer2.SplitterDistance = 250;
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
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer5);
            this.splitContainer3.Panel1MinSize = 100;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(211, 250);
            this.splitContainer3.SplitterDistance = 122;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.pgBar);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.pgSplit);
            this.splitContainer5.Size = new System.Drawing.Size(211, 122);
            this.splitContainer5.SplitterDistance = 98;
            this.splitContainer5.TabIndex = 0;
            // 
            // pgBar
            // 
            this.pgBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgBar.HelpVisible = false;
            this.pgBar.Location = new System.Drawing.Point(0, 0);
            this.pgBar.Name = "pgBar";
            this.pgBar.Size = new System.Drawing.Size(98, 122);
            this.pgBar.TabIndex = 0;
            this.pgBar.ToolbarVisible = false;
            this.pgBar.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgBar_PropertyValueChanged);
            // 
            // pgSplit
            // 
            this.pgSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgSplit.HelpVisible = false;
            this.pgSplit.Location = new System.Drawing.Point(0, 0);
            this.pgSplit.Name = "pgSplit";
            this.pgSplit.Size = new System.Drawing.Size(109, 122);
            this.pgSplit.TabIndex = 0;
            this.pgSplit.ToolbarVisible = false;
            this.pgSplit.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgBar_PropertyValueChanged);
            this.pgSplit.Click += new System.EventHandler(this.pgSplit_Click);
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.pgStatic);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.pgConfig);
            this.splitContainer4.Size = new System.Drawing.Size(211, 124);
            this.splitContainer4.SplitterDistance = 101;
            this.splitContainer4.TabIndex = 0;
            // 
            // pgStatic
            // 
            this.pgStatic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgStatic.HelpVisible = false;
            this.pgStatic.Location = new System.Drawing.Point(0, 0);
            this.pgStatic.Name = "pgStatic";
            this.pgStatic.Size = new System.Drawing.Size(101, 124);
            this.pgStatic.TabIndex = 0;
            this.pgStatic.ToolbarVisible = false;
            this.pgStatic.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgStatic_PropertyValueChanged);
            // 
            // pgConfig
            // 
            this.pgConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgConfig.HelpVisible = false;
            this.pgConfig.Location = new System.Drawing.Point(0, 0);
            this.pgConfig.Name = "pgConfig";
            this.pgConfig.Size = new System.Drawing.Size(106, 124);
            this.pgConfig.TabIndex = 0;
            this.pgConfig.ToolbarVisible = false;
            this.pgConfig.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgStatic_PropertyValueChanged);
            this.pgConfig.Click += new System.EventHandler(this.pgConfig_Click);
            // 
            // dgvDepth
            // 
            this.dgvDepth.AllowUserToOrderColumns = true;
            this.dgvDepth.AutoGenerateColumns = false;
            this.dgvDepth.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvDepth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepth.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.priceDataGridViewTextBoxColumn,
            this.sizeDataGridViewTextBoxColumn,
            this.countDataGridViewTextBoxColumn});
            this.dgvDepth.DataSource = this.depthItemViewBindingSource;
            this.dgvDepth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDepth.Location = new System.Drawing.Point(0, 0);
            this.dgvDepth.Name = "dgvDepth";
            this.dgvDepth.RowTemplate.Height = 23;
            this.dgvDepth.Size = new System.Drawing.Size(211, 208);
            this.dgvDepth.TabIndex = 1;
            this.dgvDepth.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDepth_CellValueChanged);
            this.dgvDepth.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDepth_RowPostPaint);
            // 
            // depthItemViewBindingSource
            // 
            this.depthItemViewBindingSource.DataSource = typeof(QuantBox.Data.Serializer.V2.DepthItemView);
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.toolsToolStripMenuItem,
            this.controlToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(729, 24);
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
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuControl_Play,
            this.menuControl_Stop});
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            this.controlToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.controlToolStripMenuItem.Text = "&Control";
            // 
            // menuControl_Play
            // 
            this.menuControl_Play.Name = "menuControl_Play";
            this.menuControl_Play.Size = new System.Drawing.Size(105, 22);
            this.menuControl_Play.Text = "&Play...";
            this.menuControl_Play.Click += new System.EventHandler(this.menuControl_Play_Click);
            // 
            // menuControl_Stop
            // 
            this.menuControl_Stop.Name = "menuControl_Stop";
            this.menuControl_Stop.Size = new System.Drawing.Size(105, 22);
            this.menuControl_Stop.Text = "&Stop";
            this.menuControl_Stop.Click += new System.EventHandler(this.menuControl_Stop_Click);
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.Width = 60;
            // 
            // sizeDataGridViewTextBoxColumn
            // 
            this.sizeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sizeDataGridViewTextBoxColumn.DataPropertyName = "Size";
            this.sizeDataGridViewTextBoxColumn.HeaderText = "Size";
            this.sizeDataGridViewTextBoxColumn.Name = "sizeDataGridViewTextBoxColumn";
            this.sizeDataGridViewTextBoxColumn.Width = 60;
            // 
            // countDataGridViewTextBoxColumn
            // 
            this.countDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.countDataGridViewTextBoxColumn.DataPropertyName = "Count";
            this.countDataGridViewTextBoxColumn.HeaderText = "Count";
            this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
            this.countDataGridViewTextBoxColumn.Width = 60;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 486);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormMain";
            this.Text = "Protobuf Data Zero(pd0) Inspector";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTickViewBindingSource)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depthItemViewBindingSource)).EndInit();
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
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvTick;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvDepth;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PropertyGrid pgBar;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.PropertyGrid pgStatic;
        private System.Windows.Forms.ToolStripMenuItem menuFile_Export;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuTools_ExportDirectory;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.PropertyGrid pgConfig;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.PropertyGrid pgSplit;
        private System.Windows.Forms.BindingSource pbTickViewBindingSource;
        private System.Windows.Forms.BindingSource depthItemViewBindingSource;
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuControl_Play;
        private System.Windows.Forms.ToolStripMenuItem menuControl_Stop;
        private System.Windows.Forms.DataGridViewTextBoxColumn tradingDayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actionDayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeHHmmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timessfDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeffDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localTimeMsecDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn askPrice1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn openInterestDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn turnoverDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn averagePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;

    }
}

