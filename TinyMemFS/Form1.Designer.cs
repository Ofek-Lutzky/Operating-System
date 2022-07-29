
namespace TinyMemFS
{
    partial class TinyMemFSWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.AddBtn = new System.Windows.Forms.Button();
            this.removeBtn = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.encryptBtn = new System.Windows.Forms.Button();
            this.decryptBtn = new System.Windows.Forms.Button();
            this.encText1 = new System.Windows.Forms.TextBox();
            this.decText1 = new System.Windows.Forms.TextBox();
            this.saveText2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LoadFromDiskBtn = new System.Windows.Forms.Button();
            this.SaveToDiskBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.compressBTn = new System.Windows.Forms.Button();
            this.uncompressBtn = new System.Windows.Forms.Button();
            this.setHiddenBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.renameT = new System.Windows.Forms.TextBox();
            this.Sort = new System.Windows.Forms.Button();
            this.sortCombo = new System.Windows.Forms.ComboBox();
            this.compareT = new System.Windows.Forms.TextBox();
            this.compareBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.getSizeBtn = new System.Windows.Forms.Button();
            this.loadDisktext = new System.Windows.Forms.TextBox();
            this.saveDisktext = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hiddenCombo = new System.Windows.Forms.ComboBox();
            this.alreadyHiddenCombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.copyText = new System.Windows.Forms.TextBox();
            this.copyBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(14, 11);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersWidth = 51;
            this.dataGrid.RowTemplate.Height = 29;
            this.dataGrid.Size = new System.Drawing.Size(700, 428);
            this.dataGrid.TabIndex = 0;
            // 
            // AddBtn
            // 
            this.AddBtn.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.AddBtn.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AddBtn.Location = new System.Drawing.Point(868, 76);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(140, 34);
            this.AddBtn.TabIndex = 1;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = false;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // removeBtn
            // 
            this.removeBtn.BackColor = System.Drawing.SystemColors.ControlText;
            this.removeBtn.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.removeBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.removeBtn.Location = new System.Drawing.Point(722, 76);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(140, 34);
            this.removeBtn.TabIndex = 2;
            this.removeBtn.Text = "Remove";
            this.removeBtn.UseVisualStyleBackColor = false;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.SystemColors.ControlText;
            this.Save.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Save.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Save.Location = new System.Drawing.Point(720, 22);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(140, 34);
            this.Save.TabIndex = 3;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // encryptBtn
            // 
            this.encryptBtn.BackColor = System.Drawing.SystemColors.ControlText;
            this.encryptBtn.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.encryptBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.encryptBtn.Location = new System.Drawing.Point(1160, 133);
            this.encryptBtn.Name = "encryptBtn";
            this.encryptBtn.Size = new System.Drawing.Size(140, 34);
            this.encryptBtn.TabIndex = 4;
            this.encryptBtn.Text = "Encrypt";
            this.encryptBtn.UseVisualStyleBackColor = false;
            this.encryptBtn.Click += new System.EventHandler(this.encryptBtn_Click);
            // 
            // decryptBtn
            // 
            this.decryptBtn.BackColor = System.Drawing.SystemColors.ControlText;
            this.decryptBtn.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.decryptBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.decryptBtn.Location = new System.Drawing.Point(1160, 173);
            this.decryptBtn.Name = "decryptBtn";
            this.decryptBtn.Size = new System.Drawing.Size(140, 34);
            this.decryptBtn.TabIndex = 5;
            this.decryptBtn.Text = "Decrypt";
            this.decryptBtn.UseVisualStyleBackColor = false;
            this.decryptBtn.Click += new System.EventHandler(this.decryptBtn_Click);
            // 
            // encText1
            // 
            this.encText1.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.encText1.Location = new System.Drawing.Point(1306, 142);
            this.encText1.Name = "encText1";
            this.encText1.Size = new System.Drawing.Size(217, 25);
            this.encText1.TabIndex = 8;
            // 
            // decText1
            // 
            this.decText1.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.decText1.Location = new System.Drawing.Point(1306, 182);
            this.decText1.Name = "decText1";
            this.decText1.Size = new System.Drawing.Size(217, 25);
            this.decText1.TabIndex = 9;
            // 
            // saveText2
            // 
            this.saveText2.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.saveText2.Location = new System.Drawing.Point(872, 24);
            this.saveText2.Name = "saveText2";
            this.saveText2.Size = new System.Drawing.Size(398, 25);
            this.saveText2.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1369, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 18);
            this.label4.TabIndex = 19;
            this.label4.Text = "Password";
            // 
            // LoadFromDiskBtn
            // 
            this.LoadFromDiskBtn.BackColor = System.Drawing.SystemColors.ControlText;
            this.LoadFromDiskBtn.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LoadFromDiskBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LoadFromDiskBtn.Location = new System.Drawing.Point(722, 174);
            this.LoadFromDiskBtn.Name = "LoadFromDiskBtn";
            this.LoadFromDiskBtn.Size = new System.Drawing.Size(140, 34);
            this.LoadFromDiskBtn.TabIndex = 21;
            this.LoadFromDiskBtn.Text = "Load From Disk";
            this.LoadFromDiskBtn.UseVisualStyleBackColor = false;
            this.LoadFromDiskBtn.Click += new System.EventHandler(this.LoadFromDiskBtn_Click);
            // 
            // SaveToDiskBtn
            // 
            this.SaveToDiskBtn.BackColor = System.Drawing.SystemColors.ControlText;
            this.SaveToDiskBtn.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaveToDiskBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SaveToDiskBtn.Location = new System.Drawing.Point(722, 133);
            this.SaveToDiskBtn.Name = "SaveToDiskBtn";
            this.SaveToDiskBtn.Size = new System.Drawing.Size(140, 34);
            this.SaveToDiskBtn.TabIndex = 20;
            this.SaveToDiskBtn.Text = "Save To Disk";
            this.SaveToDiskBtn.UseVisualStyleBackColor = false;
            this.SaveToDiskBtn.Click += new System.EventHandler(this.SaveToDiskBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Viner Hand ITC", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(1309, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 97);
            this.label3.TabIndex = 24;
            this.label3.Text = "File";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Viner Hand ITC", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(1260, 293);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(247, 97);
            this.label5.TabIndex = 25;
            this.label5.Text = "System";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Stencil", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(991, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 18);
            this.label7.TabIndex = 27;
            this.label7.Text = "Path To save To";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Viner Hand ITC", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(1260, 401);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(220, 53);
            this.label9.TabIndex = 29;
            this.label9.Text = "@#%^@^&#";
            // 
            // compressBTn
            // 
            this.compressBTn.BackColor = System.Drawing.SystemColors.ControlText;
            this.compressBTn.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.compressBTn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.compressBTn.Location = new System.Drawing.Point(1160, 76);
            this.compressBTn.Name = "compressBTn";
            this.compressBTn.Size = new System.Drawing.Size(140, 34);
            this.compressBTn.TabIndex = 30;
            this.compressBTn.Text = "Compress";
            this.compressBTn.UseVisualStyleBackColor = false;
            this.compressBTn.Click += new System.EventHandler(this.compressBTn_Click);
            // 
            // uncompressBtn
            // 
            this.uncompressBtn.BackColor = System.Drawing.SystemColors.ControlText;
            this.uncompressBtn.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uncompressBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.uncompressBtn.Location = new System.Drawing.Point(1306, 76);
            this.uncompressBtn.Name = "uncompressBtn";
            this.uncompressBtn.Size = new System.Drawing.Size(140, 34);
            this.uncompressBtn.TabIndex = 32;
            this.uncompressBtn.Text = "UnCompress";
            this.uncompressBtn.UseVisualStyleBackColor = false;
            this.uncompressBtn.Click += new System.EventHandler(this.uncompressBtn_Click);
            // 
            // setHiddenBtn
            // 
            this.setHiddenBtn.BackColor = System.Drawing.SystemColors.ControlText;
            this.setHiddenBtn.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.setHiddenBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.setHiddenBtn.Location = new System.Drawing.Point(722, 355);
            this.setHiddenBtn.Name = "setHiddenBtn";
            this.setHiddenBtn.Size = new System.Drawing.Size(140, 34);
            this.setHiddenBtn.TabIndex = 34;
            this.setHiddenBtn.Text = "Set Hidden";
            this.setHiddenBtn.UseVisualStyleBackColor = false;
            this.setHiddenBtn.Click += new System.EventHandler(this.setHiddenBtn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlText;
            this.button1.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(722, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 34);
            this.button1.TabIndex = 36;
            this.button1.Text = "Rename";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // renameT
            // 
            this.renameT.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.renameT.Location = new System.Drawing.Point(868, 239);
            this.renameT.Name = "renameT";
            this.renameT.Size = new System.Drawing.Size(217, 25);
            this.renameT.TabIndex = 38;
            // 
            // Sort
            // 
            this.Sort.BackColor = System.Drawing.SystemColors.ControlText;
            this.Sort.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Sort.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Sort.Location = new System.Drawing.Point(722, 315);
            this.Sort.Name = "Sort";
            this.Sort.Size = new System.Drawing.Size(140, 34);
            this.Sort.TabIndex = 39;
            this.Sort.Text = "Sort By:";
            this.Sort.UseVisualStyleBackColor = false;
            this.Sort.Click += new System.EventHandler(this.Sort_Click);
            // 
            // sortCombo
            // 
            this.sortCombo.FormattingEnabled = true;
            this.sortCombo.Items.AddRange(new object[] {
            "Name",
            "Date",
            "Size"});
            this.sortCombo.Location = new System.Drawing.Point(868, 321);
            this.sortCombo.Name = "sortCombo";
            this.sortCombo.Size = new System.Drawing.Size(178, 26);
            this.sortCombo.TabIndex = 40;
            // 
            // compareT
            // 
            this.compareT.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.compareT.Location = new System.Drawing.Point(868, 279);
            this.compareT.Name = "compareT";
            this.compareT.Size = new System.Drawing.Size(217, 25);
            this.compareT.TabIndex = 43;
            // 
            // compareBtn
            // 
            this.compareBtn.BackColor = System.Drawing.SystemColors.ControlText;
            this.compareBtn.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.compareBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.compareBtn.Location = new System.Drawing.Point(722, 275);
            this.compareBtn.Name = "compareBtn";
            this.compareBtn.Size = new System.Drawing.Size(140, 34);
            this.compareBtn.TabIndex = 41;
            this.compareBtn.Text = "Compare";
            this.compareBtn.UseVisualStyleBackColor = false;
            this.compareBtn.Click += new System.EventHandler(this.compareBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(914, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 18);
            this.label1.TabIndex = 44;
            this.label1.Text = "Other File Name";
            // 
            // getSizeBtn
            // 
            this.getSizeBtn.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.getSizeBtn.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.getSizeBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.getSizeBtn.Location = new System.Drawing.Point(1014, 76);
            this.getSizeBtn.Name = "getSizeBtn";
            this.getSizeBtn.Size = new System.Drawing.Size(140, 34);
            this.getSizeBtn.TabIndex = 45;
            this.getSizeBtn.Text = "Get Size";
            this.getSizeBtn.UseVisualStyleBackColor = false;
            this.getSizeBtn.Click += new System.EventHandler(this.getSizeBtn_Click);
            // 
            // loadDisktext
            // 
            this.loadDisktext.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loadDisktext.Location = new System.Drawing.Point(868, 178);
            this.loadDisktext.Name = "loadDisktext";
            this.loadDisktext.Size = new System.Drawing.Size(217, 25);
            this.loadDisktext.TabIndex = 47;
            // 
            // saveDisktext
            // 
            this.saveDisktext.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.saveDisktext.Location = new System.Drawing.Point(868, 142);
            this.saveDisktext.Name = "saveDisktext";
            this.saveDisktext.Size = new System.Drawing.Size(217, 25);
            this.saveDisktext.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Stencil", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(925, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 48;
            this.label2.Text = "File name";
            // 
            // hiddenCombo
            // 
            this.hiddenCombo.FormattingEnabled = true;
            this.hiddenCombo.Items.AddRange(new object[] {
            "True",
            "False"});
            this.hiddenCombo.Location = new System.Drawing.Point(868, 360);
            this.hiddenCombo.Name = "hiddenCombo";
            this.hiddenCombo.Size = new System.Drawing.Size(178, 26);
            this.hiddenCombo.TabIndex = 49;
            // 
            // alreadyHiddenCombo
            // 
            this.alreadyHiddenCombo.FormattingEnabled = true;
            this.alreadyHiddenCombo.Location = new System.Drawing.Point(1054, 360);
            this.alreadyHiddenCombo.Name = "alreadyHiddenCombo";
            this.alreadyHiddenCombo.Size = new System.Drawing.Size(178, 26);
            this.alreadyHiddenCombo.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Stencil", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(1100, 339);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 18);
            this.label6.TabIndex = 51;
            this.label6.Text = "Already Hidden";
            // 
            // copyText
            // 
            this.copyText.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.copyText.Location = new System.Drawing.Point(868, 405);
            this.copyText.Name = "copyText";
            this.copyText.Size = new System.Drawing.Size(217, 25);
            this.copyText.TabIndex = 53;
            // 
            // copyBtn
            // 
            this.copyBtn.BackColor = System.Drawing.SystemColors.ControlText;
            this.copyBtn.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.copyBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.copyBtn.Location = new System.Drawing.Point(722, 401);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(140, 34);
            this.copyBtn.TabIndex = 52;
            this.copyBtn.Text = "Copy";
            this.copyBtn.UseVisualStyleBackColor = false;
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // TinyMemFSWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1531, 496);
            this.Controls.Add(this.copyText);
            this.Controls.Add(this.copyBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.alreadyHiddenCombo);
            this.Controls.Add(this.hiddenCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.loadDisktext);
            this.Controls.Add(this.saveDisktext);
            this.Controls.Add(this.getSizeBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.compareT);
            this.Controls.Add(this.compareBtn);
            this.Controls.Add(this.sortCombo);
            this.Controls.Add(this.Sort);
            this.Controls.Add(this.renameT);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.setHiddenBtn);
            this.Controls.Add(this.uncompressBtn);
            this.Controls.Add(this.compressBTn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LoadFromDiskBtn);
            this.Controls.Add(this.SaveToDiskBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.saveText2);
            this.Controls.Add(this.decText1);
            this.Controls.Add(this.encText1);
            this.Controls.Add(this.decryptBtn);
            this.Controls.Add(this.encryptBtn);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.dataGrid);
            this.Font = new System.Drawing.Font("Stencil", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "TinyMemFSWindow";
            this.Text = "TinyMemFS";
            this.Load += new System.EventHandler(this.TinyMemFSWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button encryptBtn;
        private System.Windows.Forms.Button decryptBtn;
        private System.Windows.Forms.TextBox encText1;
        private System.Windows.Forms.TextBox decText1;
        private System.Windows.Forms.TextBox saveText2;
        private System.Windows.Forms.TextBox removeText1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox STDText;
        private System.Windows.Forms.TextBox LTDText;
        private System.Windows.Forms.Button LoadFromDiskBtn;
        private System.Windows.Forms.Button SaveToDiskBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button compressBTn;
        private System.Windows.Forms.TextBox compressText1;
        private System.Windows.Forms.TextBox uncompressText;
        private System.Windows.Forms.Button uncompressBtn;
        private System.Windows.Forms.TextBox sethiddenText;
        private System.Windows.Forms.Button setHiddenBtn;
        private System.Windows.Forms.TextBox renameT1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox renameT;
        private System.Windows.Forms.Button Sort;
        private System.Windows.Forms.ComboBox sortCombo;
        private System.Windows.Forms.TextBox compareT;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button compareBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button getSizeBtn;
        private System.Windows.Forms.TextBox loadDisktext;
        private System.Windows.Forms.TextBox saveDisktext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox hiddenCombo;
        private System.Windows.Forms.ComboBox alreadyHiddenCombo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox copyText;
        private System.Windows.Forms.Button copyBtn;
    }
}

