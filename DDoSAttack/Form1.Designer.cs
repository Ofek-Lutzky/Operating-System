
namespace DDoSAttack
{
    partial class FormWindow
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
            this.tBBrowsersNumber = new System.Windows.Forms.TextBox();
            this.tBUrl = new System.Windows.Forms.TextBox();
            this.DDoSBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.AttackLabel = new System.Windows.Forms.Label();
            this.BrowsersLab = new System.Windows.Forms.Label();
            this.TargetLab = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tBBrowsersNumber
            // 
            this.tBBrowsersNumber.Location = new System.Drawing.Point(104, 22);
            this.tBBrowsersNumber.Name = "tBBrowsersNumber";
            this.tBBrowsersNumber.Size = new System.Drawing.Size(100, 22);
            this.tBBrowsersNumber.TabIndex = 0;
            // 
            // tBUrl
            // 
            this.tBUrl.Location = new System.Drawing.Point(104, 50);
            this.tBUrl.Name = "tBUrl";
            this.tBUrl.Size = new System.Drawing.Size(441, 22);
            this.tBUrl.TabIndex = 1;
            // 
            // DDoSBtn
            // 
            this.DDoSBtn.Location = new System.Drawing.Point(104, 78);
            this.DDoSBtn.Name = "DDoSBtn";
            this.DDoSBtn.Size = new System.Drawing.Size(441, 23);
            this.DDoSBtn.TabIndex = 2;
            this.DDoSBtn.Text = "Start DDoS Attack";
            this.DDoSBtn.UseVisualStyleBackColor = true;
            this.DDoSBtn.Click += new System.EventHandler(this.DDoSBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(104, 107);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(441, 23);
            this.CloseBtn.TabIndex = 3;
            this.CloseBtn.Text = "Close All";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // AttackLabel
            // 
            this.AttackLabel.AutoSize = true;
            this.AttackLabel.Location = new System.Drawing.Point(12, 25);
            this.AttackLabel.Name = "AttackLabel";
            this.AttackLabel.Size = new System.Drawing.Size(75, 17);
            this.AttackLabel.TabIndex = 4;
            this.AttackLabel.Text = "Attack with";
            // 
            // BrowsersLab
            // 
            this.BrowsersLab.AutoSize = true;
            this.BrowsersLab.Location = new System.Drawing.Point(210, 25);
            this.BrowsersLab.Name = "BrowsersLab";
            this.BrowsersLab.Size = new System.Drawing.Size(66, 17);
            this.BrowsersLab.TabIndex = 5;
            this.BrowsersLab.Text = "Browsers";
            // 
            // TargetLab
            // 
            this.TargetLab.AutoSize = true;
            this.TargetLab.Location = new System.Drawing.Point(12, 53);
            this.TargetLab.Name = "TargetLab";
            this.TargetLab.Size = new System.Drawing.Size(86, 17);
            this.TargetLab.TabIndex = 6;
            this.TargetLab.Text = "Target URL:";
            // 
            // FormWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 149);
            this.Controls.Add(this.TargetLab);
            this.Controls.Add(this.BrowsersLab);
            this.Controls.Add(this.AttackLabel);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.DDoSBtn);
            this.Controls.Add(this.tBUrl);
            this.Controls.Add(this.tBBrowsersNumber);
            this.Name = "FormWindow";
            this.Text = "MultiProcess DDos Attack";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBBrowsersNumber;
        private System.Windows.Forms.TextBox tBUrl;
        private System.Windows.Forms.Button DDoSBtn;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Label AttackLabel;
        private System.Windows.Forms.Label BrowsersLab;
        private System.Windows.Forms.Label TargetLab;
    }
}

