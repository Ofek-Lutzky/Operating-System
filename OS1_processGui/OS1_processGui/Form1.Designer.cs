
namespace OS1_processGui
{
    partial class FormW
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
            this.killButton = new System.Windows.Forms.Button();
            this.textSearchName = new System.Windows.Forms.TextBox();
            this.seachName = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // killButton
            // 
            this.killButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.killButton.Location = new System.Drawing.Point(312, 428);
            this.killButton.Name = "killButton";
            this.killButton.Size = new System.Drawing.Size(104, 29);
            this.killButton.TabIndex = 0;
            this.killButton.Text = "Kill";
            this.killButton.UseVisualStyleBackColor = true;
            this.killButton.Click += new System.EventHandler(this.killButton_Click);
            // 
            // textSearchName
            // 
            this.textSearchName.Location = new System.Drawing.Point(238, 33);
            this.textSearchName.Name = "textSearchName";
            this.textSearchName.Size = new System.Drawing.Size(322, 27);
            this.textSearchName.TabIndex = 4;
            this.textSearchName.TextChanged += new System.EventHandler(this.textSearchName_TextChanged);
            // 
            // seachName
            // 
            this.seachName.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.seachName.Location = new System.Drawing.Point(566, 33);
            this.seachName.Name = "seachName";
            this.seachName.Size = new System.Drawing.Size(143, 29);
            this.seachName.TabIndex = 8;
            this.seachName.Text = "Search";
            this.seachName.UseVisualStyleBackColor = true;
            this.seachName.Click += new System.EventHandler(this.seachName_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(15, 77);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowHeadersWidth = 51;
            this.dataGrid.RowTemplate.Height = 29;
            this.dataGrid.Size = new System.Drawing.Size(707, 332);
            this.dataGrid.TabIndex = 10;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ID",
            "Process"});
            this.comboBox1.Location = new System.Drawing.Point(112, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(120, 28);
            this.comboBox1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Column:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::OS1_processGui.Properties.Resources.shooting;
            this.pictureBox1.Image = global::OS1_processGui.Properties.Resources.shooting;
            this.pictureBox1.Location = new System.Drawing.Point(515, 415);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(207, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // FormW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::OS1_processGui.Properties.Resources.chris_mai_B5iBCpnSfNA_unsplash;
            this.ClientSize = new System.Drawing.Size(738, 543);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.seachName);
            this.Controls.Add(this.textSearchName);
            this.Controls.Add(this.killButton);
            this.Name = "FormW";
            this.Text = "ProcessManager";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button killButton;
        private System.Windows.Forms.TextBox textSearchName;
        private System.Windows.Forms.Button seachName;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

