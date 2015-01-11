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
            this.SuspendLayout();
            // 
            // textBox_Input
            // 
            this.textBox_Input.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Input.Location = new System.Drawing.Point(104, 12);
            this.textBox_Input.Name = "textBox_Input";
            this.textBox_Input.Size = new System.Drawing.Size(390, 20);
            this.textBox_Input.TabIndex = 0;
            // 
            // textBox_Output
            // 
            this.textBox_Output.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Output.Location = new System.Drawing.Point(104, 38);
            this.textBox_Output.Name = "textBox_Output";
            this.textBox_Output.Size = new System.Drawing.Size(390, 20);
            this.textBox_Output.TabIndex = 0;
            // 
            // button_Input
            // 
            this.button_Input.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Input.Location = new System.Drawing.Point(500, 10);
            this.button_Input.Name = "button_Input";
            this.button_Input.Size = new System.Drawing.Size(75, 23);
            this.button_Input.TabIndex = 1;
            this.button_Input.Text = "Browse...";
            this.button_Input.UseVisualStyleBackColor = true;
            this.button_Input.Click += new System.EventHandler(this.button_Input_Click);
            // 
            // button_Output
            // 
            this.button_Output.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Output.Location = new System.Drawing.Point(500, 36);
            this.button_Output.Name = "button_Output";
            this.button_Output.Size = new System.Drawing.Size(75, 23);
            this.button_Output.TabIndex = 1;
            this.button_Output.Text = "Browse...";
            this.button_Output.UseVisualStyleBackColor = true;
            this.button_Output.Click += new System.EventHandler(this.button_Output_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input directory:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output directory:";
            // 
            // button_Process
            // 
            this.button_Process.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Process.Location = new System.Drawing.Point(585, 35);
            this.button_Process.Name = "button_Process";
            this.button_Process.Size = new System.Drawing.Size(75, 23);
            this.button_Process.TabIndex = 3;
            this.button_Process.Text = "Process";
            this.button_Process.UseVisualStyleBackColor = true;
            this.button_Process.Click += new System.EventHandler(this.button_Process_Click);
            // 
            // checkBox_AllSubfolders
            // 
            this.checkBox_AllSubfolders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_AllSubfolders.AutoSize = true;
            this.checkBox_AllSubfolders.Location = new System.Drawing.Point(15, 67);
            this.checkBox_AllSubfolders.Name = "checkBox_AllSubfolders";
            this.checkBox_AllSubfolders.Size = new System.Drawing.Size(102, 17);
            this.checkBox_AllSubfolders.TabIndex = 4;
            this.checkBox_AllSubfolders.Text = "In all sub-folders";
            this.checkBox_AllSubfolders.UseVisualStyleBackColor = true;
            // 
            // textBox_Log
            // 
            this.textBox_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Log.Location = new System.Drawing.Point(15, 96);
            this.textBox_Log.Multiline = true;
            this.textBox_Log.Name = "textBox_Log";
            this.textBox_Log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Log.Size = new System.Drawing.Size(673, 211);
            this.textBox_Log.TabIndex = 5;
            // 
            // checkBox_SkipExistingFile
            // 
            this.checkBox_SkipExistingFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_SkipExistingFile.AutoSize = true;
            this.checkBox_SkipExistingFile.Location = new System.Drawing.Point(123, 64);
            this.checkBox_SkipExistingFile.Name = "checkBox_SkipExistingFile";
            this.checkBox_SkipExistingFile.Size = new System.Drawing.Size(119, 17);
            this.checkBox_SkipExistingFile.TabIndex = 4;
            this.checkBox_SkipExistingFile.Text = "Skip the existing file";
            this.checkBox_SkipExistingFile.UseVisualStyleBackColor = true;
            // 
            // FormExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 319);
            this.Controls.Add(this.textBox_Log);
            this.Controls.Add(this.checkBox_SkipExistingFile);
            this.Controls.Add(this.checkBox_AllSubfolders);
            this.Controls.Add(this.button_Process);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Output);
            this.Controls.Add(this.button_Input);
            this.Controls.Add(this.textBox_Output);
            this.Controls.Add(this.textBox_Input);
            this.Name = "FormExport";
            this.Text = "Export";
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
    }
}