namespace GameOfLife
{
    partial class SettingsDialog
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
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.num_Width = new System.Windows.Forms.NumericUpDown();
            this.num_Height = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.num_Delay = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cbox_UniverseStyle = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_gridColor = new System.Windows.Forms.Button();
            this.btn_deadCellColor = new System.Windows.Forms.Button();
            this.btn_liveCellColor = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Delay)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(22, 182);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 0;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(103, 182);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // num_Width
            // 
            this.num_Width.Location = new System.Drawing.Point(56, 11);
            this.num_Width.Name = "num_Width";
            this.num_Width.Size = new System.Drawing.Size(53, 20);
            this.num_Width.TabIndex = 2;
            // 
            // num_Height
            // 
            this.num_Height.Location = new System.Drawing.Point(56, 37);
            this.num_Height.Name = "num_Height";
            this.num_Height.Size = new System.Drawing.Size(53, 20);
            this.num_Height.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Warning: Modifying universe size\r\nwill result in it being cleared!";
            // 
            // num_Delay
            // 
            this.num_Delay.Location = new System.Drawing.Point(242, 11);
            this.num_Delay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_Delay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_Delay.Name = "num_Delay";
            this.num_Delay.Size = new System.Drawing.Size(56, 20);
            this.num_Delay.TabIndex = 7;
            this.num_Delay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(180, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Delay (ms)";
            // 
            // cbox_UniverseStyle
            // 
            this.cbox_UniverseStyle.AutoSize = true;
            this.cbox_UniverseStyle.Location = new System.Drawing.Point(189, 79);
            this.cbox_UniverseStyle.Name = "cbox_UniverseStyle";
            this.cbox_UniverseStyle.Size = new System.Drawing.Size(109, 17);
            this.cbox_UniverseStyle.TabIndex = 10;
            this.cbox_UniverseStyle.Text = "Toroidal Universe";
            this.cbox_UniverseStyle.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(324, 176);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cbox_UniverseStyle);
            this.tabPage1.Controls.Add(this.num_Width);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.num_Delay);
            this.tabPage1.Controls.Add(this.num_Height);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(316, 150);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Simulation";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.btn_liveCellColor);
            this.tabPage2.Controls.Add(this.btn_deadCellColor);
            this.tabPage2.Controls.Add(this.btn_gridColor);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(316, 150);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Appearance";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_gridColor
            // 
            this.btn_gridColor.Location = new System.Drawing.Point(15, 20);
            this.btn_gridColor.Name = "btn_gridColor";
            this.btn_gridColor.Size = new System.Drawing.Size(33, 27);
            this.btn_gridColor.TabIndex = 0;
            this.btn_gridColor.UseVisualStyleBackColor = true;
            this.btn_gridColor.Click += new System.EventHandler(this.ColorButtonClick);
            // 
            // btn_deadCellColor
            // 
            this.btn_deadCellColor.Location = new System.Drawing.Point(15, 53);
            this.btn_deadCellColor.Name = "btn_deadCellColor";
            this.btn_deadCellColor.Size = new System.Drawing.Size(33, 27);
            this.btn_deadCellColor.TabIndex = 1;
            this.btn_deadCellColor.UseVisualStyleBackColor = true;
            this.btn_deadCellColor.Click += new System.EventHandler(this.ColorButtonClick);
            // 
            // btn_liveCellColor
            // 
            this.btn_liveCellColor.Location = new System.Drawing.Point(15, 86);
            this.btn_liveCellColor.Name = "btn_liveCellColor";
            this.btn_liveCellColor.Size = new System.Drawing.Size(33, 27);
            this.btn_liveCellColor.TabIndex = 2;
            this.btn_liveCellColor.UseVisualStyleBackColor = true;
            this.btn_liveCellColor.Click += new System.EventHandler(this.ColorButtonClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Grid Color";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Dead Cell Color";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Live Cell Color";
            // 
            // SettingsDialog
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(333, 226);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.num_Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Delay)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.NumericUpDown num_Width;
        private System.Windows.Forms.NumericUpDown num_Height;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown num_Delay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbox_UniverseStyle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_liveCellColor;
        private System.Windows.Forms.Button btn_deadCellColor;
        private System.Windows.Forms.Button btn_gridColor;
    }
}