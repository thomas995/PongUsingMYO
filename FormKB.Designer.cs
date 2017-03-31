namespace PongWithMyo
{
    partial class FormKB
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.p1Score = new System.Windows.Forms.Label();
            this.p2score = new System.Windows.Forms.Label();
            this.Ball = new System.Windows.Forms.PictureBox();
            this.Player1 = new System.Windows.Forms.PictureBox();
            this.Player2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 452);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Player 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Player 2";
            // 
            // p1Score
            // 
            this.p1Score.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.p1Score.AutoSize = true;
            this.p1Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1Score.Location = new System.Drawing.Point(-2, 447);
            this.p1Score.Name = "p1Score";
            this.p1Score.Size = new System.Drawing.Size(27, 29);
            this.p1Score.TabIndex = 11;
            this.p1Score.Text = "0";
            // 
            // p2score
            // 
            this.p2score.AutoSize = true;
            this.p2score.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2score.Location = new System.Drawing.Point(-2, -5);
            this.p2score.Name = "p2score";
            this.p2score.Size = new System.Drawing.Size(27, 29);
            this.p2score.TabIndex = 10;
            this.p2score.Text = "0";
            // 
            // Ball
            // 
            this.Ball.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Ball.BackColor = System.Drawing.Color.Black;
            this.Ball.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Ball.Location = new System.Drawing.Point(534, 217);
            this.Ball.Name = "Ball";
            this.Ball.Size = new System.Drawing.Size(30, 27);
            this.Ball.TabIndex = 9;
            this.Ball.TabStop = false;
            // 
            // Player1
            // 
            this.Player1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Player1.BackColor = System.Drawing.Color.SpringGreen;
            this.Player1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Player1.Location = new System.Drawing.Point(486, 439);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(120, 21);
            this.Player1.TabIndex = 8;
            this.Player1.TabStop = false;
            // 
            // Player2
            // 
            this.Player2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Player2.BackColor = System.Drawing.Color.HotPink;
            this.Player2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Player2.Location = new System.Drawing.Point(486, 9);
            this.Player2.Name = "Player2";
            this.Player2.Size = new System.Drawing.Size(120, 21);
            this.Player2.TabIndex = 7;
            this.Player2.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // FormKB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1044, 475);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.p1Score);
            this.Controls.Add(this.p2score);
            this.Controls.Add(this.Ball);
            this.Controls.Add(this.Player1);
            this.Controls.Add(this.Player2);
            this.Name = "FormKB";
            this.Text = "FormKB";
            this.Load += new System.EventHandler(this.FormKB_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormKB_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormKB_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label p1Score;
        private System.Windows.Forms.Label p2score;
        private System.Windows.Forms.PictureBox Ball;
        private System.Windows.Forms.PictureBox Player1;
        private System.Windows.Forms.PictureBox Player2;
        private System.Windows.Forms.Timer timer1;
    }
}