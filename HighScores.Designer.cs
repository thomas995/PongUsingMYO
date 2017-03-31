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
            this.txtHighScore = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(281, 274);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 31);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtScoresOne
            // 
            this.txtScoresOne.Anchor = System.Windows.Forms.AnchorStyles.Left;
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
            this.txtScoresTwo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtScoresTwo.BackColor = System.Drawing.Color.HotPink;
            this.txtScoresTwo.Location = new System.Drawing.Point(187, 12);
            this.txtScoresTwo.Name = "txtScoresTwo";
            this.txtScoresTwo.Size = new System.Drawing.Size(169, 248);
            this.txtScoresTwo.TabIndex = 3;
            this.txtScoresTwo.Text = "";
            // 
            // txtHighScore
            // 
            this.txtHighScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtHighScore.BackColor = System.Drawing.Color.DarkOrange;
            this.txtHighScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHighScore.Location = new System.Drawing.Point(121, 274);
            this.txtHighScore.Name = "txtHighScore";
            this.txtHighScore.Size = new System.Drawing.Size(119, 31);
            this.txtHighScore.TabIndex = 5;
            this.txtHighScore.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "High Score:";
            // 
            // HighScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 317);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHighScore);
            this.Controls.Add(this.txtScoresTwo);
            this.Controls.Add(this.txtScoresOne);
            this.Controls.Add(this.btnBack);
            this.Name = "HighScores";
            this.Text = "HighScores";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.RichTextBox txtScoresOne;
        private System.Windows.Forms.RichTextBox txtScoresTwo;
        private System.Windows.Forms.RichTextBox txtHighScore;
        private System.Windows.Forms.Label label1;
    }
}