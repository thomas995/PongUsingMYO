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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.btnHighScores = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMyoTest = new System.Windows.Forms.Button();
            this.btnStartGameKB = new System.Windows.Forms.Button();
            this.btnMute = new System.Windows.Forms.Button();
            this.btnPlayMusic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(264, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 38);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pong With MYO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnStartGame
            // 
            this.btnStartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartGame.Location = new System.Drawing.Point(206, 96);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(157, 122);
            this.btnStartGame.TabIndex = 6;
            this.btnStartGame.Text = "START GAME        (MYO)";
            this.btnStartGame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // btnHighScores
            // 
            this.btnHighScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHighScores.Location = new System.Drawing.Point(82, 224);
            this.btnHighScores.Name = "btnHighScores";
            this.btnHighScores.Size = new System.Drawing.Size(157, 122);
            this.btnHighScores.TabIndex = 7;
            this.btnHighScores.Text = "HIGH SCORES";
            this.btnHighScores.UseVisualStyleBackColor = true;
            this.btnHighScores.Click += new System.EventHandler(this.btnHighScores_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(595, 224);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(157, 122);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMyoTest
            // 
            this.btnMyoTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyoTest.Location = new System.Drawing.Point(328, 224);
            this.btnMyoTest.Name = "btnMyoTest";
            this.btnMyoTest.Size = new System.Drawing.Size(157, 122);
            this.btnMyoTest.TabIndex = 9;
            this.btnMyoTest.Text = "MYO TEST";
            this.btnMyoTest.UseVisualStyleBackColor = true;
            this.btnMyoTest.Click += new System.EventHandler(this.btnMyoTest_Click);
            // 
            // btnStartGameKB
            // 
            this.btnStartGameKB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartGameKB.Location = new System.Drawing.Point(462, 96);
            this.btnStartGameKB.Name = "btnStartGameKB";
            this.btnStartGameKB.Size = new System.Drawing.Size(157, 122);
            this.btnStartGameKB.TabIndex = 10;
            this.btnStartGameKB.Text = "START GAME     (Keyboard)";
            this.btnStartGameKB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartGameKB.UseVisualStyleBackColor = true;
            this.btnStartGameKB.Click += new System.EventHandler(this.btnStartGameKB_Click);
            // 
            // btnMute
            // 
            this.btnMute.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMute.Location = new System.Drawing.Point(12, 19);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(157, 31);
            this.btnMute.TabIndex = 11;
            this.btnMute.Text = " MUTE MUSIC";
            this.btnMute.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMute.UseVisualStyleBackColor = true;
            this.btnMute.Click += new System.EventHandler(this.btnMute_Click);
            // 
            // btnPlayMusic
            // 
            this.btnPlayMusic.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayMusic.Location = new System.Drawing.Point(12, 19);
            this.btnPlayMusic.Name = "btnPlayMusic";
            this.btnPlayMusic.Size = new System.Drawing.Size(157, 31);
            this.btnPlayMusic.TabIndex = 12;
            this.btnPlayMusic.Text = "  PLAY MUSIC";
            this.btnPlayMusic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlayMusic.UseVisualStyleBackColor = true;
            this.btnPlayMusic.Visible = false;
            this.btnPlayMusic.Click += new System.EventHandler(this.btnPlayMusic_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(823, 358);
            this.Controls.Add(this.btnPlayMusic);
            this.Controls.Add(this.btnMute);
            this.Controls.Add(this.btnStartGameKB);
            this.Controls.Add(this.btnMyoTest);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnHighScores);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Button btnHighScores;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMyoTest;
        private System.Windows.Forms.Button btnStartGameKB;
        private System.Windows.Forms.Button btnMute;
        private System.Windows.Forms.Button btnPlayMusic;
    }
}

