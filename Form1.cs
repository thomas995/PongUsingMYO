using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MyoSharp.Device;
using MyoSharp.Communication;
using MyoSharp.Exceptions;
using System.Threading;

namespace PongWithMyo
{
    public partial class Form1 : Form
    {

        IChannel myoChannel;
        IHub myoHub;

        public Form1()
        {
            InitializeComponent();
        }

    
        private void Form1_Load(object sender, EventArgs e)
        {
            // InitializeMyo();

            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopMyo();
        }

        private void InitializeMyo()
        {
            myoChannel = Channel.Create(ChannelDriver.Create(ChannelBridge.Create(), MyoErrorHandlerDriver.Create(MyoErrorHandlerBridge.Create())));
            myoHub = Hub.Create(myoChannel);

            myoHub.MyoConnected += myoHub_MyoConnected; 
            myoHub.MyoDisconnected += myoHub_MyoDisconnected;

            myoChannel.StartListening();

            
        }

        #region CONNECT/DISCONNECT MYO
        void myoHub_MyoConnected(object sender, MyoEventArgs e)
        { 
            MessageBox.Show("Myo is connected");

            e.Myo.Vibrate(VibrationType.Long);
        }

        void myoHub_MyoDisconnected(object sender, MyoEventArgs e)
        {
            MessageBox.Show("Myo is disconnected");
        }
        #endregion

        private void StopMyo()
        {
            //myoChannel.StopListening();
            //myoChannel.Dispose();
        }
    }
}
