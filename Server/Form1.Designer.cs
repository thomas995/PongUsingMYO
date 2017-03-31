namespace Server
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Sendbutton = new System.Windows.Forms.Button();
            this.Messagetextbox = new System.Windows.Forms.RichTextBox();
            this.ChatScreentextbox = new System.Windows.Forms.RichTextBox();
            this.Connectbutton = new System.Windows.Forms.Button();
            this.Startbutton = new System.Windows.Forms.Button();
            this.ClientIPtextbox = new System.Windows.Forms.TextBox();
            this.ClientPorttextbox = new System.Windows.Forms.TextBox();
            this.ServerPorttextbox = new System.Windows.Forms.TextBox();
            this.ServerIPtextBox = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtConnections = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(240, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "PORT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "IP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "PORT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "CLIENT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "SERVER";
            // 
            // Sendbutton
            // 
            this.Sendbutton.Location = new System.Drawing.Point(409, 271);
            this.Sendbutton.Name = "Sendbutton";
            this.Sendbutton.Size = new System.Drawing.Size(75, 38);
            this.Sendbutton.TabIndex = 23;
            this.Sendbutton.Text = "SEND";
            this.Sendbutton.UseVisualStyleBackColor = true;
            this.Sendbutton.Click += new System.EventHandler(this.Sendbutton_Click);
            // 
            // Messagetextbox
            // 
            this.Messagetextbox.Location = new System.Drawing.Point(52, 271);
            this.Messagetextbox.Name = "Messagetextbox";
            this.Messagetextbox.Size = new System.Drawing.Size(351, 38);
            this.Messagetextbox.TabIndex = 22;
            this.Messagetextbox.Text = "";
            // 
            // ChatScreentextbox
            // 
            this.ChatScreentextbox.Location = new System.Drawing.Point(52, 169);
            this.ChatScreentextbox.Name = "ChatScreentextbox";
            this.ChatScreentextbox.Size = new System.Drawing.Size(432, 96);
            this.ChatScreentextbox.TabIndex = 21;
            this.ChatScreentextbox.Text = "";
            // 
            // Connectbutton
            // 
            this.Connectbutton.Location = new System.Drawing.Point(480, 135);
            this.Connectbutton.Name = "Connectbutton";
            this.Connectbutton.Size = new System.Drawing.Size(75, 23);
            this.Connectbutton.TabIndex = 20;
            this.Connectbutton.Text = "CONNECT";
            this.Connectbutton.UseVisualStyleBackColor = true;
            this.Connectbutton.Click += new System.EventHandler(this.Connectbutton_Click);
            // 
            // Startbutton
            // 
            this.Startbutton.Location = new System.Drawing.Point(480, 36);
            this.Startbutton.Name = "Startbutton";
            this.Startbutton.Size = new System.Drawing.Size(75, 23);
            this.Startbutton.TabIndex = 19;
            this.Startbutton.Text = "START";
            this.Startbutton.UseVisualStyleBackColor = true;
            this.Startbutton.Click += new System.EventHandler(this.Startbutton_Click);
            // 
            // ClientIPtextbox
            // 
            this.ClientIPtextbox.Location = new System.Drawing.Point(52, 138);
            this.ClientIPtextbox.Name = "ClientIPtextbox";
            this.ClientIPtextbox.Size = new System.Drawing.Size(153, 20);
            this.ClientIPtextbox.TabIndex = 18;
            // 
            // ClientPorttextbox
            // 
            this.ClientPorttextbox.Location = new System.Drawing.Point(283, 138);
            this.ClientPorttextbox.Name = "ClientPorttextbox";
            this.ClientPorttextbox.Size = new System.Drawing.Size(153, 20);
            this.ClientPorttextbox.TabIndex = 17;
            // 
            // ServerPorttextbox
            // 
            this.ServerPorttextbox.Location = new System.Drawing.Point(283, 36);
            this.ServerPorttextbox.Name = "ServerPorttextbox";
            this.ServerPorttextbox.Size = new System.Drawing.Size(153, 20);
            this.ServerPorttextbox.TabIndex = 16;
            // 
            // ServerIPtextBox
            // 
            this.ServerIPtextBox.Location = new System.Drawing.Point(52, 36);
            this.ServerIPtextBox.Name = "ServerIPtextBox";
            this.ServerIPtextBox.Size = new System.Drawing.Size(153, 20);
            this.ServerIPtextBox.TabIndex = 15;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(518, 343);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Users:";
            // 
            // txtConnections
            // 
            this.txtConnections.Location = new System.Drawing.Point(561, 340);
            this.txtConnections.Name = "txtConnections";
            this.txtConnections.Size = new System.Drawing.Size(46, 20);
            this.txtConnections.TabIndex = 30;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 365);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtConnections);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Sendbutton);
            this.Controls.Add(this.Messagetextbox);
            this.Controls.Add(this.ChatScreentextbox);
            this.Controls.Add(this.Connectbutton);
            this.Controls.Add(this.Startbutton);
            this.Controls.Add(this.ClientIPtextbox);
            this.Controls.Add(this.ClientPorttextbox);
            this.Controls.Add(this.ServerPorttextbox);
            this.Controls.Add(this.ServerIPtextBox);
            this.Name = "Form1";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Sendbutton;
        private System.Windows.Forms.RichTextBox Messagetextbox;
        private System.Windows.Forms.RichTextBox ChatScreentextbox;
        private System.Windows.Forms.Button Connectbutton;
        private System.Windows.Forms.Button Startbutton;
        private System.Windows.Forms.TextBox ClientIPtextbox;
        private System.Windows.Forms.TextBox ClientPorttextbox;
        private System.Windows.Forms.TextBox ServerPorttextbox;
        private System.Windows.Forms.TextBox ServerIPtextBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtConnections;
    }
}

