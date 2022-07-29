
namespace SpreadsheetApp
{
    partial class Form1
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
            this.findAll = new System.Windows.Forms.Button();
            this.ExchangeRow = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.loadBtn = new System.Windows.Forms.Button();
            this.SaveTextBox = new System.Windows.Forms.TextBox();
            this.LoadTextBox = new System.Windows.Forms.TextBox();
            this.findAlltextBox = new System.Windows.Forms.TextBox();
            this.findAllcomboBox = new System.Windows.Forms.ComboBox();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.setAllcomboBox = new System.Windows.Forms.ComboBox();
            this.setAllText = new System.Windows.Forms.TextBox();
            this.SetAll = new System.Windows.Forms.Button();
            this.setAlltextBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.exchangeTextBox2 = new System.Windows.Forms.TextBox();
            this.exchangeTextBox = new System.Windows.Forms.TextBox();
            this.AddRow = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.col2textBox1 = new System.Windows.Forms.TextBox();
            this.col1textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.AddRowtextBox3 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.AddColtextBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(12, 12);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersWidth = 51;
            this.dataGrid.RowTemplate.Height = 29;
            this.dataGrid.Size = new System.Drawing.Size(952, 648);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellContentClick);
            // 
            // findAll
            // 
            this.findAll.Location = new System.Drawing.Point(982, 13);
            this.findAll.Name = "findAll";
            this.findAll.Size = new System.Drawing.Size(94, 29);
            this.findAll.TabIndex = 1;
            this.findAll.Text = "Find All";
            this.findAll.UseVisualStyleBackColor = true;
            this.findAll.Click += new System.EventHandler(this.findAll_Click);
            // 
            // ExchangeRow
            // 
            this.ExchangeRow.Location = new System.Drawing.Point(982, 315);
            this.ExchangeRow.Name = "ExchangeRow";
            this.ExchangeRow.Size = new System.Drawing.Size(146, 29);
            this.ExchangeRow.TabIndex = 3;
            this.ExchangeRow.Text = "Exchange Row";
            this.ExchangeRow.UseVisualStyleBackColor = true;
            this.ExchangeRow.Click += new System.EventHandler(this.ExchangeRow_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(62, 693);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(253, 27);
            this.Save.TabIndex = 7;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(672, 693);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(241, 27);
            this.loadBtn.TabIndex = 8;
            this.loadBtn.Text = "Load";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // SaveTextBox
            // 
            this.SaveTextBox.Location = new System.Drawing.Point(337, 693);
            this.SaveTextBox.Name = "SaveTextBox";
            this.SaveTextBox.Size = new System.Drawing.Size(268, 27);
            this.SaveTextBox.TabIndex = 9;
            // 
            // LoadTextBox
            // 
            this.LoadTextBox.Location = new System.Drawing.Point(945, 693);
            this.LoadTextBox.Name = "LoadTextBox";
            this.LoadTextBox.Size = new System.Drawing.Size(303, 27);
            this.LoadTextBox.TabIndex = 10;
            // 
            // findAlltextBox
            // 
            this.findAlltextBox.Location = new System.Drawing.Point(1136, 49);
            this.findAlltextBox.Name = "findAlltextBox";
            this.findAlltextBox.Size = new System.Drawing.Size(146, 27);
            this.findAlltextBox.TabIndex = 12;
            // 
            // findAllcomboBox
            // 
            this.findAllcomboBox.FormattingEnabled = true;
            this.findAllcomboBox.Items.AddRange(new object[] {
            "true",
            "false"});
            this.findAllcomboBox.Location = new System.Drawing.Point(1136, 82);
            this.findAllcomboBox.Name = "findAllcomboBox";
            this.findAllcomboBox.Size = new System.Drawing.Size(146, 28);
            this.findAllcomboBox.TabIndex = 14;
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(982, 125);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(146, 29);
            this.ClearBtn.TabIndex = 15;
            this.ClearBtn.Text = "Clear Colors";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // setAllcomboBox
            // 
            this.setAllcomboBox.FormattingEnabled = true;
            this.setAllcomboBox.Items.AddRange(new object[] {
            "true",
            "false"});
            this.setAllcomboBox.Location = new System.Drawing.Point(1136, 275);
            this.setAllcomboBox.Name = "setAllcomboBox";
            this.setAllcomboBox.Size = new System.Drawing.Size(146, 28);
            this.setAllcomboBox.TabIndex = 18;
            // 
            // setAllText
            // 
            this.setAllText.Location = new System.Drawing.Point(1136, 207);
            this.setAllText.Name = "setAllText";
            this.setAllText.Size = new System.Drawing.Size(146, 27);
            this.setAllText.TabIndex = 17;
            // 
            // SetAll
            // 
            this.SetAll.Location = new System.Drawing.Point(982, 169);
            this.SetAll.Name = "SetAll";
            this.SetAll.Size = new System.Drawing.Size(94, 29);
            this.SetAll.TabIndex = 16;
            this.SetAll.Text = "Set All";
            this.SetAll.UseVisualStyleBackColor = true;
            this.SetAll.Click += new System.EventHandler(this.SetAll_Click);
            // 
            // setAlltextBox2
            // 
            this.setAlltextBox2.Location = new System.Drawing.Point(1136, 240);
            this.setAlltextBox2.Name = "setAlltextBox2";
            this.setAlltextBox2.Size = new System.Drawing.Size(146, 27);
            this.setAlltextBox2.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1007, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Old String";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1007, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "CaseSensetive";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1007, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "CaseSensetive";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1007, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Search";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1007, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "new String";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1007, 381);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 20);
            this.label6.TabIndex = 28;
            this.label6.Text = "row2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1007, 348);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 20);
            this.label7.TabIndex = 27;
            this.label7.Text = "row1";
            // 
            // exchangeTextBox2
            // 
            this.exchangeTextBox2.Location = new System.Drawing.Point(1136, 374);
            this.exchangeTextBox2.Name = "exchangeTextBox2";
            this.exchangeTextBox2.Size = new System.Drawing.Size(146, 27);
            this.exchangeTextBox2.TabIndex = 26;
            // 
            // exchangeTextBox
            // 
            this.exchangeTextBox.Location = new System.Drawing.Point(1136, 341);
            this.exchangeTextBox.Name = "exchangeTextBox";
            this.exchangeTextBox.Size = new System.Drawing.Size(146, 27);
            this.exchangeTextBox.TabIndex = 25;
            // 
            // AddRow
            // 
            this.AddRow.Location = new System.Drawing.Point(982, 520);
            this.AddRow.Name = "AddRow";
            this.AddRow.Size = new System.Drawing.Size(146, 29);
            this.AddRow.TabIndex = 29;
            this.AddRow.Text = "Add Row";
            this.AddRow.UseVisualStyleBackColor = true;
            this.AddRow.Click += new System.EventHandler(this.AddRow_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1007, 475);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 20);
            this.label8.TabIndex = 34;
            this.label8.Text = "col2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1007, 442);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 20);
            this.label9.TabIndex = 33;
            this.label9.Text = "col1";
            // 
            // col2textBox1
            // 
            this.col2textBox1.Location = new System.Drawing.Point(1136, 468);
            this.col2textBox1.Name = "col2textBox1";
            this.col2textBox1.Size = new System.Drawing.Size(146, 27);
            this.col2textBox1.TabIndex = 32;
            // 
            // col1textBox2
            // 
            this.col1textBox2.Location = new System.Drawing.Point(1136, 435);
            this.col1textBox2.Name = "col1textBox2";
            this.col1textBox2.Size = new System.Drawing.Size(146, 27);
            this.col1textBox2.TabIndex = 31;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(982, 409);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 29);
            this.button1.TabIndex = 30;
            this.button1.Text = "Exchange Column";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1007, 559);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 20);
            this.label10.TabIndex = 36;
            this.label10.Text = "row1";
            // 
            // AddRowtextBox3
            // 
            this.AddRowtextBox3.Location = new System.Drawing.Point(1136, 552);
            this.AddRowtextBox3.Name = "AddRowtextBox3";
            this.AddRowtextBox3.Size = new System.Drawing.Size(146, 27);
            this.AddRowtextBox3.TabIndex = 35;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1007, 640);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 20);
            this.label11.TabIndex = 39;
            this.label11.Text = "col1";
            // 
            // AddColtextBox1
            // 
            this.AddColtextBox1.Location = new System.Drawing.Point(1136, 633);
            this.AddColtextBox1.Name = "AddColtextBox1";
            this.AddColtextBox1.Size = new System.Drawing.Size(146, 27);
            this.AddColtextBox1.TabIndex = 38;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(982, 601);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 29);
            this.button2.TabIndex = 37;
            this.button2.Text = "Add Col";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1303, 753);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.AddColtextBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.AddRowtextBox3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.col2textBox1);
            this.Controls.Add(this.col1textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AddRow);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.exchangeTextBox2);
            this.Controls.Add(this.exchangeTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.setAlltextBox2);
            this.Controls.Add(this.setAllcomboBox);
            this.Controls.Add(this.setAllText);
            this.Controls.Add(this.SetAll);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.findAllcomboBox);
            this.Controls.Add(this.findAlltextBox);
            this.Controls.Add(this.LoadTextBox);
            this.Controls.Add(this.SaveTextBox);
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.ExchangeRow);
            this.Controls.Add(this.findAll);
            this.Controls.Add(this.dataGrid);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button findAll;
        private System.Windows.Forms.Button ExchangeRow;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.TextBox SaveTextBox;
        private System.Windows.Forms.TextBox LoadTextBox;
        private System.Windows.Forms.TextBox findAlltextBox;
        private System.Windows.Forms.ComboBox findAllcomboBox;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.ComboBox setAllcomboBox;
        private System.Windows.Forms.TextBox setAllText;
        private System.Windows.Forms.Button SetAll;
        private System.Windows.Forms.TextBox setAlltextBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox exchangeTextBox2;
        private System.Windows.Forms.TextBox exchangeTextBox;
        private System.Windows.Forms.Button AddRow;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox col2textBox1;
        private System.Windows.Forms.TextBox col1textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox AddRowtextBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox AddColtextBox1;
        private System.Windows.Forms.Button button2;
    }
}

