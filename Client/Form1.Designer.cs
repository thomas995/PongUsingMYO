namespace Client
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
            this.ServerIPtextBox = new System.Windows.Forms.TextBox();
            this.ServerPorttextbox = new System.Windows.Forms.TextBox();
            this.ClientPorttextbox = new System.Windows.Forms.TextBox();
            this.ClientIPtextbox = new System.Windows.Forms.TextBox();
            this.Startbutton = new System.Windows.Forms.Button();
            this.Connectbutton = new System.Windows.Forms.Button();
            this.ChatScreentextbox = new System.Windows.Forms.RichTextBox();
            this.Messagetextbox = new System.Windows.Forms.RichTextBox();
            this.Sendbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.txtConnections = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ServerIPtextBox
            // 
            this.ServerIPtextBox.Location = new System.Drawing.Point(105, 57);
            this.ServerIPtextBox.Name = "ServerIPtextBox";
            this.ServerIPtextBox.Size = new System.Drawing.Size(153, 20);
            this.ServerIPtextBox.TabIndex = 0;
            // 
            // ServerPorttextbox
            // 
            this.ServerPorttextbox.Location = new System.Drawing.Point(336, 57);
            this.ServerPorttextbox.Name = "ServerPorttextbox";
            this.ServerPorttextbox.Size = new System.Drawing.Size(153, 20);
            this.ServerPorttextbox.TabIndex = 1;
            // 
            // ClientPorttextbox
            // 
            this.ClientPorttextbox.Location = new System.Drawing.Point(336, 159);
            this.ClientPorttextbox.Name = "ClientPorttextbox";
            this.ClientPorttextbox.Size = new System.Drawing.Size(153, 20);
            this.ClientPorttextbox.TabIndex = 2;
            // 
            // ClientIPtextbox
            // 
            this.ClientIPtextbox.Location = new System.Drawing.Point(105, 159);
            this.ClientIPtextbox.Name = "ClientIPtextbox";
            this.ClientIPtextbox.Size = new System.Drawing.Size(153, 20);
            this.ClientIPtextbox.TabIndex = 3;
            // 
            // Startbutton
            // 
            this.Startbutton.Location = new System.Drawing.Point(533, 57);
            this.Startbutton.Name = "Startbutton";
            this.Startbutton.Size = new System.Drawing.Size(75, 23);
            this.Startbutton.TabIndex = 4;
            this.Startbutton.Text = "START";
            this.Startbutton.UseVisualStyleBackColor = true;
            this.Startbutton.Click += new System.EventHandler(this.Startbutton_Click);
            // 
            // Connectbutton
            // 
            this.Connectbutton.Location = new System.Drawing.Point(533, 156);
            this.Connectbutton.Name = "Connectbutton";
            this.Connectbutton.Size = new System.Drawing.Size(75, 23);
            this.Connectbutton.TabIndex = 5;
            this.Connectbutton.Text = "CONNECT";
            this.Connectbutton.UseVisualStyleBackColor = true;
            this.Connectbutton.Click += new System.EventHandler(this.Connectbutton_Click);
            // 
            // ChatScreentextbox
            // 
            this.ChatScreentextbox.Location = new System.Drawing.Point(105, 190);
            this.ChatScreentextbox.Name = "ChatScreentextbox";
            this.ChatScreentextbox.Size = new System.Drawing.Size(432, 96);
            this.ChatScreentextbox.TabIndex = 6;
            this.ChatScreentextbox.Text = "";
            // 
            // Messagetextbox
            // 
            this.Messagetextbox.Location = new System.Drawing.Point(105, 292);
            this.Messagetextbox.Name = "Messagetextbox";
            this.Messagetextbox.Size = new System.Drawing.Size(351, 38);
            this.Messagetextbox.TabIndex = 7;
            this.Messagetextbox.Text = "";
            // 
            // Sendbutton
            // 
            this.Sendbutton.Location = new System.Drawing.Point(462, 292);
            this.Sendbutton.Name = "Sendbutton";
            this.Sendbutton.Size = new System.Drawing.Size(75, 38);
            this.Sendbutton.TabIndex = 8;
            this.Sendbutton.Text = "SEND";
            this.Sendbutton.UseVisualStyleBackColor = true;
            this.Sendbutton.Click += new System.EventHandler(this.Sendbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "SERVER";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "CLIENT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "IP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(293, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "PORT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "IP";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(293, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "PORT";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // txtConnections
            // 
            this.txtConnections.Location = new System.Drawing.Point(593, 341);
            this.txtConnections.Name = "txtConnections";
            this.txtConnections.Size = new System.Drawing.Size(46, 20);
            this.txtConnections.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(550, 344);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Users:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 366);
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
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ServerIPtextBox;
        private System.Windows.Forms.TextBox ServerPorttextbox;
        private System.Windows.Forms.TextBox ClientPorttextbox;
        private System.Windows.Forms.TextBox ClientIPtextbox;
        private System.Windows.Forms.Button Startbutton;
        private System.Windows.Forms.Button Connectbutton;
        private System.Windows.Forms.RichTextBox ChatScreentextbox;
        private System.Windows.Forms.RichTextBox Messagetextbox;
        private System.Windows.Forms.Button Sendbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.TextBox txtConnections;
        private System.Windows.Forms.Label label7;
    }
}

