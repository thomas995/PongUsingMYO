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


namespace Server
{
    public partial class Form1 : Form
    {
        // Variables
        private TcpClient client; // var for connections for TCP network services
        public StreamReader myStreamReader; // reads characters from a byte stream
        public StreamWriter myStreamWriter; // writes...
        public string messageRecieve; // Var for the message recieved
        public String messageSend; // Var for the message send
        int noOfConnections = 1;


        public Form1()
        {
            InitializeComponent();

            IPAddress[] myIP_Address = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress address in myIP_Address)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    ServerIPtextBox.Text = address.ToString();
                    txtConnections.Text = noOfConnections.ToString();

                }
            }
        }

        // Starts a server/hosting service for other clients to connect
        private void Startbutton_Click(object sender, EventArgs e)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, int.Parse(ServerPorttextbox.Text)); // uses the IP address in the textbox to be listened to
            listener.Start(); // starts listening if its an IP address
            client = listener.AcceptTcpClient(); // accepts clients listening on IP address
            myStreamReader = new StreamReader(client.GetStream());
            myStreamWriter = new StreamWriter(client.GetStream());
            myStreamWriter.AutoFlush = true;

            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.WorkerSupportsCancellation = true;

            // increases number of connections and informs server side that a user is in the chatroom
            noOfConnections++;
            txtConnections.Text = noOfConnections.ToString();
            ChatScreentextbox.AppendText("A user has connected!");
        }

        // allows the user to connect to a hosting/server IP address in order to enter the chatri
        private void Connectbutton_Click(object sender, EventArgs e)
        {
            client = new TcpClient(); // the variable client is overwritten with a new instance of TcpClient

            // Represents a network endpoint as an IP address and a port number.
            IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse(ClientIPtextbox.Text), int.Parse(ClientPorttextbox.Text));

            try
            {
                client.Connect(IpEnd);

                if (client.Connected)
                {
                    // Lets the user know that they have connected to the local server
                    ChatScreentextbox.AppendText("Connected to server" + "\n");
                    noOfConnections++;
                    txtConnections.Text = noOfConnections.ToString();
                    myStreamWriter = new StreamWriter(client.GetStream());
                    myStreamReader = new StreamReader(client.GetStream());
                    myStreamWriter.AutoFlush = true; // flushes the buffer
                    backgroundWorker1.RunWorkerAsync(); // starts backgroundWorker1
                    backgroundWorker2.WorkerSupportsCancellation = true; // allows backgroundworker2 to be cancelled asynchronously

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // 
            while (client.Connected)
            {
                try
                {
                    // Stream
                    messageRecieve = myStreamReader.ReadLine();

                    this.ChatScreentextbox.Invoke(new MethodInvoker(delegate ()
                    {
                        // send message stating who sent it and their message - 
                        ChatScreentextbox.AppendText("opponent:" + messageRecieve + "\n");
                    }));
                    messageRecieve = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            // if you've connected to the server
            if (client.Connected)
            {
                //enables easy and efficient text output
                myStreamWriter.WriteLine(messageSend);
                this.ChatScreentextbox.Invoke(new MethodInvoker(delegate ()
                {
                    // send message stating who sent it and their message
                    ChatScreentextbox.AppendText("player:" + messageSend + "\n");
                }));
            }
            else
            {
                // error handling message
                MessageBox.Show("SENDING MESSAGE FAILED...");
            }
            backgroundWorker2.CancelAsync();
        }

        private void Sendbutton_Click(object sender, EventArgs e)
        {
            // if not blank, send message in textbox to the other player
            if (Messagetextbox.Text != "")
            {
                messageSend = Messagetextbox.Text;
                backgroundWorker2.RunWorkerAsync();
            }
            //removes what the sender previously wrote into the textbox
            Messagetextbox.Text = "";

        
        }
    }
}
// ADAPTED FROM https://www.youtube.com/watch?v=BDVfpPq3weo&t=188s
