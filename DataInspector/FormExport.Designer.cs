namespace DataInspector
{
    partial class FormExport
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
            this.textBox_Input = new System.Windows.Forms.TextBox();
            this.textBox_Output = new System.Windows.Forms.TextBox();
            this.button_Input = new System.Windows.Forms.Button();
            this.button_Output = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Process = new System.Windows.Forms.Button();
            this.checkBox_AllSubfolders = new System.Windows.Forms.CheckBox();
            this.textBox_Log = new System.Windows.Forms.TextBox();
            this.checkBox_SkipExistingFile = new System.Windows.Forms.CheckBox();
            this.numericUpDown_DepthLevel = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_enable_csv = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_enable_kdb = new System.Windows.Forms.CheckBox();
            this.textBox_Host = new System.Windows.Forms.TextBox();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.textBox_UsernameAndPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox_SaveQuote = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DepthLevel)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Input
            // 
            this.textBox_Input.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Input.Location = new System.Drawing.Point(160, 14);
            this.textBox_Input.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_Input.Name = "textBox_Input";
            this.textBox_Input.Size = new System.Drawing.Size(512, 25);
            this.textBox_Input.TabIndex = 0;
            // 
            // textBox_Output
            // 
            this.textBox_Output.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Output.Location = new System.Drawing.Point(148, 52);
            this.textBox_Output.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_Output.Name = "textBox_Output";
            this.textBox_Output.Size = new System.Drawing.Size(512, 25);
            this.textBox_Output.TabIndex = 0;
            // 
            // button_Input
            // 
            this.button_Input.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Input.Location = new System.Drawing.Point(681, 12);
            this.button_Input.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_Input.Name = "button_Input";
            this.button_Input.Size = new System.Drawing.Size(100, 27);
            this.button_Input.TabIndex = 1;
            this.button_Input.Text = "Browse...";
            this.button_Input.UseVisualStyleBackColor = true;
            this.button_Input.Click += new System.EventHandler(this.button_Input_Click);
            // 
            // button_Output
            // 
            this.button_Output.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Output.Location = new System.Drawing.Point(669, 50);
            this.button_Output.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_Output.Name = "button_Output";
            this.button_Output.Size = new System.Drawing.Size(100, 27);
            this.button_Output.TabIndex = 1;
            this.button_Output.Text = "Browse...";
            this.button_Output.UseVisualStyleBackColor = true;
            this.button_Output.Click += new System.EventHandler(this.button_Output_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input directory:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output directory:";
            // 
            // button_Process
            // 
            this.button_Process.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Process.Location = new System.Drawing.Point(800, 13);
            this.button_Process.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_Process.Name = "button_Process";
            this.button_Process.Size = new System.Drawing.Size(100, 27);
            this.button_Process.TabIndex = 3;
            this.button_Process.Text = "Process";
            this.button_Process.UseVisualStyleBackColor = true;
            this.button_Process.Click += new System.EventHandler(this.button_Process_Click);
            // 
            // checkBox_AllSubfolders
            // 
            this.checkBox_AllSubfolders.AutoSize = true;
            this.checkBox_AllSubfolders.Location = new System.Drawing.Point(20, 51);
            this.checkBox_AllSubfolders.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox_AllSubfolders.Name = "checkBox_AllSubfolders";
            this.checkBox_AllSubfolders.Size = new System.Drawing.Size(173, 19);
            this.checkBox_AllSubfolders.TabIndex = 4;
            this.checkBox_AllSubfolders.Text = "In all sub-folders";
            this.checkBox_AllSubfolders.UseVisualStyleBackColor = true;
            // 
            // textBox_Log
            // 
            this.textBox_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Log.Location = new System.Drawing.Point(12, 338);
            this.textBox_Log.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_Log.Multiline = true;
            this.textBox_Log.Name = "textBox_Log";
            this.textBox_Log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Log.Size = new System.Drawing.Size(889, 150);
            this.textBox_Log.TabIndex = 5;
            // 
            // checkBox_SkipExistingFile
            // 
            this.checkBox_SkipExistingFile.AutoSize = true;
            this.checkBox_SkipExistingFile.Enabled = false;
            this.checkBox_SkipExistingFile.Location = new System.Drawing.Point(10, 94);
            this.checkBox_SkipExistingFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox_SkipExistingFile.Name = "checkBox_SkipExistingFile";
            this.checkBox_SkipExistingFile.Size = new System.Drawing.Size(205, 19);
            this.checkBox_SkipExistingFile.TabIndex = 4;
            this.checkBox_SkipExistingFile.Text = "Skip the existing file";
            this.checkBox_SkipExistingFile.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_DepthLevel
            // 
            this.numericUpDown_DepthLevel.Location = new System.Drawing.Point(371, 88);
            this.numericUpDown_DepthLevel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numericUpDown_DepthLevel.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_DepthLevel.Name = "numericUpDown_DepthLevel";
            this.numericUpDown_DepthLevel.Size = new System.Drawing.Size(73, 25);
            this.numericUpDown_DepthLevel.TabIndex = 6;
            this.numericUpDown_DepthLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 93);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Depth Level";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkBox_enable_csv);
            this.groupBox1.Controls.Add(this.button_Output);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_Output);
            this.groupBox1.Controls.Add(this.numericUpDown_DepthLevel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.checkBox_SkipExistingFile);
            this.groupBox1.Location = new System.Drawing.Point(12, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(889, 130);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "csv";
            // 
            // checkBox_enable_csv
            // 
            this.checkBox_enable_csv.AutoSize = true;
            this.checkBox_enable_csv.Location = new System.Drawing.Point(10, 24);
            this.checkBox_enable_csv.Name = "checkBox_enable_csv";
            this.checkBox_enable_csv.Size = new System.Drawing.Size(109, 19);
            this.checkBox_enable_csv.TabIndex = 9;
            this.checkBox_enable_csv.Text = "Eanble CSV";
            this.checkBox_enable_csv.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.checkBox_SaveQuote);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_UsernameAndPassword);
            this.groupBox2.Controls.Add(this.textBox_Port);
            this.groupBox2.Controls.Add(this.textBox_Host);
            this.groupBox2.Controls.Add(this.checkBox_enable_kdb);
            this.groupBox2.Location = new System.Drawing.Point(12, 222);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(889, 100);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "kdb+";
            // 
            // checkBox_enable_kdb
            // 
            this.checkBox_enable_kdb.AutoSize = true;
            this.checkBox_enable_kdb.Location = new System.Drawing.Point(10, 24);
            this.checkBox_enable_kdb.Name = "checkBox_enable_kdb";
            this.checkBox_enable_kdb.Size = new System.Drawing.Size(117, 19);
            this.checkBox_enable_kdb.TabIndex = 9;
            this.checkBox_enable_kdb.Text = "Eanble kdb+";
            this.checkBox_enable_kdb.UseVisualStyleBackColor = true;
            // 
            // textBox_Host
            // 
            this.textBox_Host.Location = new System.Drawing.Point(77, 49);
            this.textBox_Host.Name = "textBox_Host";
            this.textBox_Host.Size = new System.Drawing.Size(138, 25);
            this.textBox_Host.TabIndex = 10;
            this.textBox_Host.Text = "127.0.0.1";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(294, 49);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(63, 25);
            this.textBox_Port.TabIndex = 10;
            this.textBox_Port.Text = "5001";
            // 
            // textBox_UsernameAndPassword
            // 
            this.textBox_UsernameAndPassword.Location = new System.Drawing.Point(522, 49);
            this.textBox_UsernameAndPassword.Name = "textBox_UsernameAndPassword";
            this.textBox_UsernameAndPassword.Size = new System.Drawing.Size(138, 25);
            this.textBox_UsernameAndPassword.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Host:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(234, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Port:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(368, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Username:Password";
            // 
            // checkBox_SaveQuote
            // 
            this.checkBox_SaveQuote.AutoSize = true;
            this.checkBox_SaveQuote.Checked = true;
            this.checkBox_SaveQuote.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_SaveQuote.Location = new System.Drawing.Point(697, 50);
            this.checkBox_SaveQuote.Name = "checkBox_SaveQuote";
            this.checkBox_SaveQuote.Size = new System.Drawing.Size(109, 19);
            this.checkBox_SaveQuote.TabIndex = 14;
            this.checkBox_SaveQuote.Text = "Save Quote";
            this.checkBox_SaveQuote.UseVisualStyleBackColor = true;
            // 
            // FormExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 502);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox_Log);
            this.Controls.Add(this.checkBox_AllSubfolders);
            this.Controls.Add(this.button_Process);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Input);
            this.Controls.Add(this.textBox_Input);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormExport";
            this.Text = "Export";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DepthLevel)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Input;
        private System.Windows.Forms.TextBox textBox_Output;
        private System.Windows.Forms.Button button_Input;
        private System.Windows.Forms.Button button_Output;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Process;
        private System.Windows.Forms.CheckBox checkBox_AllSubfolders;
        private System.Windows.Forms.TextBox textBox_Log;
        private System.Windows.Forms.CheckBox checkBox_SkipExistingFile;
        private System.Windows.Forms.NumericUpDown numericUpDown_DepthLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_enable_csv;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox_enable_kdb;
        private System.Windows.Forms.TextBox textBox_UsernameAndPassword;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.TextBox textBox_Host;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox_SaveQuote;
    }
}