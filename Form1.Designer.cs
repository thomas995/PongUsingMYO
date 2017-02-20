namespace PongWithMyo
{
    partial class Form1
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
            this.PlayerOne = new System.Windows.Forms.PictureBox();
            this.PlayerTwo = new System.Windows.Forms.PictureBox();
            this.Ball = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerTwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayerOne
            // 
            this.PlayerOne.BackColor = System.Drawing.Color.Purple;
            this.PlayerOne.Location = new System.Drawing.Point(133, 12);
            this.PlayerOne.Name = "PlayerOne";
            this.PlayerOne.Size = new System.Drawing.Size(100, 50);
            this.PlayerOne.TabIndex = 0;
            this.PlayerOne.TabStop = false;
            // 
            // PlayerTwo
            // 
            this.PlayerTwo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.PlayerTwo.Location = new System.Drawing.Point(133, 228);
            this.PlayerTwo.Name = "PlayerTwo";
            this.PlayerTwo.Size = new System.Drawing.Size(100, 50);
            this.PlayerTwo.TabIndex = 1;
            this.PlayerTwo.TabStop = false;
            // 
            // Ball
            // 
            this.Ball.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Ball.Location = new System.Drawing.Point(133, 114);
            this.Ball.Name = "Ball";
            this.Ball.Size = new System.Drawing.Size(100, 50);
            this.Ball.TabIndex = 2;
            this.Ball.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 290);
            this.Controls.Add(this.Ball);
            this.Controls.Add(this.PlayerTwo);
            this.Controls.Add(this.PlayerOne);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PlayerOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerTwo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PlayerOne;
        private System.Windows.Forms.PictureBox PlayerTwo;
        private System.Windows.Forms.PictureBox Ball;
    }
}

