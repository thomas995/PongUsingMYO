namespace PongWithMyo
{
    partial class HighScores
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
            this.btnBack = new System.Windows.Forms.Button();
            this.txtScoresOne = new System.Windows.Forms.RichTextBox();
            this.txtScoresTwo = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(149, 266);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtScoresOne
            // 
            this.txtScoresOne.BackColor = System.Drawing.Color.SpringGreen;
            this.txtScoresOne.ForeColor = System.Drawing.Color.Black;
            this.txtScoresOne.Location = new System.Drawing.Point(12, 12);
            this.txtScoresOne.Name = "txtScoresOne";
            this.txtScoresOne.Size = new System.Drawing.Size(169, 248);
            this.txtScoresOne.TabIndex = 2;
            this.txtScoresOne.Text = "";
            // 
            // txtScoresTwo
            // 
            this.txtScoresTwo.BackColor = System.Drawing.Color.HotPink;
            this.txtScoresTwo.Location = new System.Drawing.Point(187, 12);
            this.txtScoresTwo.Name = "txtScoresTwo";
            this.txtScoresTwo.Size = new System.Drawing.Size(169, 248);
            this.txtScoresTwo.TabIndex = 3;
            this.txtScoresTwo.Text = "";
            // 
            // HighScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 317);
            this.Controls.Add(this.txtScoresTwo);
            this.Controls.Add(this.txtScoresOne);
            this.Controls.Add(this.btnBack);
            this.Name = "HighScores";
            this.Text = "HighScores";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.RichTextBox txtScoresOne;
        private System.Windows.Forms.RichTextBox txtScoresTwo;
    }
}