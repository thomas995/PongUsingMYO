using MyoSharp.Communication;
using MyoSharp.Device;
using MyoSharp.Exceptions;
using MyoSharp.Poses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PongWithMyo
{
    public partial class MYO_Test : Form
    {
        public MYO_Test()
        {
            InitializeComponent();
        }

        // channels the MYOs will connect on
        IChannel myoChannel;
        IChannel myoChannel2;

        // hubs MYOs will connect on
        IHub myoHub;
        IHub myoHub2;

        private void InitializeMyo()
        {
            myoChannel = Channel.Create(ChannelDriver.Create(ChannelBridge.Create(), MyoErrorHandlerDriver.Create(MyoErrorHandlerBridge.Create())));
            myoHub = Hub.Create(myoChannel);

            myoHub.MyoConnected += myoHub_MyoConnected; // runs method when MYO connects
            myoHub.MyoDisconnected -= myoHub_MyoDisconnected; // runs method when MYO disconnects

            myoChannel.StartListening();
        }

        void myoHub_MyoConnected(object sender, MyoEventArgs e)
        {
            MessageBox.Show("Myo is connected");

            e.Myo.Vibrate(VibrationType.Long);
            e.Myo.Unlock(UnlockType.Hold); // keeps the MYO unlocked

            e.Myo.OrientationDataAcquired += MYO_Data_Acquisition;

            var pose = HeldPose.Create(e.Myo, Pose.Fist, Pose.WaveIn, Pose.WaveOut);

            pose.Interval = TimeSpan.FromSeconds(0.5);
            pose.Start();
            // pose.Triggered += pose_Triggered;
        }

        void myoHub_MyoDisconnected(object sender, MyoEventArgs e)
        {
            MessageBox.Show("Myo is disconnected");
            e.Myo.OrientationDataAcquired -= MYO_Data_Acquisition;

        }

        public void MYO_Data_Acquisition(object sender, OrientationDataEventArgs e)
        {
            var pose = HeldPose.Create(e.Myo, Pose.Fist, Pose.DoubleTap);
            const float PI = (float)System.Math.PI;
            var Roll = (e.Roll + PI) / (PI * 2.0f) * 100;
            string data = "Roll: " + Roll.ToString() + Environment.NewLine;
            InvokeData(data);
        }

        private void InvokeData(string data)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(InvokeData), new object[] { data });
                return;
            }
            richTextBox1.Clear();
            richTextBox1.AppendText(data + Environment.NewLine);

        }



        private void btnStartTest_Click(object sender, EventArgs e)
        {
            InitializeMyo();
            richTextBox1.Visible = true;
            richTextBox2.Visible = true;
            btnStartTest.Visible = false;
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to exit the game?", "PongWithMyo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            }
            else if (dialogResult == DialogResult.No)
            {
                // do nothing
            }
        }
    }
}

