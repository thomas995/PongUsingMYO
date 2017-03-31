using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Client
{
    // MOST COMMENTS ARE ON THE FORM ONE FOR SERVER
    public partial class Form1 : Form
    {
        // Variables
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string recieve;
        public String TextToSend;
        int noOfConnections = 1;
        public Form1()
        {
            InitializeComponent();


            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    ServerIPtextBox.Text = address.ToString();
                    txtConnections.Text = noOfConnections.ToString();

                }
            }
        }

        private void Startbutton_Click(object sender, EventArgs e)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, int.Parse(ServerPorttextbox.Text));
            listener.Start();
            client = listener.AcceptTcpClient();
            STR = new StreamReader(client.GetStream());
            STW = new StreamWriter(client.GetStream());
            STW.AutoFlush = true;

            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.WorkerSupportsCancellation = true;
            if(client.Connected)
            {
                // increases number of connections and informs server side that a user is in the chatroom
                noOfConnections++;
                txtConnections.Text = noOfConnections.ToString();
                ChatScreentextbox.AppendText("A user has connected!");

            }
        }

        private void Connectbutton_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse(ClientIPtextbox.Text), int.Parse(ClientPorttextbox.Text));
            noOfConnections++;
            txtConnections.Text = noOfConnections.ToString();
            try
            {
                client.Connect(IpEnd);

                if (client.Connected)
                {
                    ChatScreentextbox.AppendText("Connected to server" + "\n");
                   
                    STW = new StreamWriter(client.GetStream());
                    STR = new StreamReader(client.GetStream());
                    STW.AutoFlush = true;
                    backgroundWorker1.RunWorkerAsync();
                    backgroundWorker2.WorkerSupportsCancellation = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (client.Connected)
            {
                try
                {
                    recieve = STR.ReadLine();
                    this.ChatScreentextbox.Invoke(new MethodInvoker(delegate ()
                    {
                        ChatScreentextbox.AppendText("Opponent:" + recieve + "\n");
                    }));
                    recieve = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (client.Connected)
            {
                STW.WriteLine(TextToSend);
                this.ChatScreentextbox.Invoke(new MethodInvoker(delegate ()
                {
                    ChatScreentextbox.AppendText("Player:" + TextToSend + "\n");
                }));
            }
            else
            {
                MessageBox.Show("Sending failed");
            }
            backgroundWorker2.CancelAsync();
        }

        private void Sendbutton_Click(object sender, EventArgs e)
        {
            if (Messagetextbox.Text != "")
            {
                TextToSend = Messagetextbox.Text;
                backgroundWorker2.RunWorkerAsync();
            }
            Messagetextbox.Text = "";

        }
    }
}
// ADAPTED FROM https://www.youtube.com/watch?v=BDVfpPq3weo&t=188s
