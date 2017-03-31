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

        private void InitializeMyo2()
        {
            myoChannel2 = Channel.Create(ChannelDriver.Create(ChannelBridge.Create(), MyoErrorHandlerDriver.Create(MyoErrorHandlerBridge.Create())));
            myoHub2 = Hub.Create(myoChannel2);

            myoHub2.MyoConnected += myoHub2_MyoConnected;
            myoHub2.MyoDisconnected -= myoHub2_MyoDisconnected;

            myoChannel2.StartListening();
        }

        void myoHub_MyoConnected(object sender, MyoEventArgs e)
        {
            MessageBox.Show("Myo is connected");

            e.Myo.Vibrate(VibrationType.Long);
            e.Myo.Unlock(UnlockType.Hold); // keeps the MYO unlocked

            e.Myo.OrientationDataAcquired += Myo_OrientationDataAcquired;

            var pose = HeldPose.Create(e.Myo, Pose.Fist, Pose.WaveIn, Pose.WaveOut);

            pose.Interval = TimeSpan.FromSeconds(0.5);
            pose.Start();
            // pose.Triggered += pose_Triggered;
        }

        void myoHub2_MyoConnected(object sender, MyoEventArgs f)
        {
            MessageBox.Show("Myo 2 is connected");

            f.Myo.Vibrate(VibrationType.Long);
            f.Myo.Unlock(UnlockType.Hold); // keeps the MYO unlocked

            f.Myo.OrientationDataAcquired += Myo2_OrientationDataAcquired;

            var pose = HeldPose.Create(f.Myo, Pose.Fist, Pose.WaveIn, Pose.WaveOut);

            pose.Interval = TimeSpan.FromSeconds(0.5);
            pose.Start();
            // pose.Triggered += pose_Triggered; 
        }
        void myoHub_MyoDisconnected(object sender, MyoEventArgs e)
        {
            MessageBox.Show("Myo is disconnected");
            e.Myo.OrientationDataAcquired -= Myo_OrientationDataAcquired;

        }

        void myoHub2_MyoDisconnected(object sender, MyoEventArgs e)
        {
            MessageBox.Show("Myo 2 is disconnected");
            e.Myo.OrientationDataAcquired -= Myo2_OrientationDataAcquired;

        }

        public void Myo_OrientationDataAcquired(object sender, OrientationDataEventArgs e)
        {
            var pose = HeldPose.Create(e.Myo, Pose.Fist, Pose.DoubleTap);
            const float PI = (float)System.Math.PI;
            var Roll = (e.Roll + PI) / (PI * 2.0f) * 100;
            string data = "Roll: " + Roll.ToString() + Environment.NewLine;
            InvokeData(data);
        }

        private void Myo2_OrientationDataAcquired(object sender, OrientationDataEventArgs f)
        {
            // list of poses available to be given actions to
            var pose = HeldPose.Create(f.Myo, Pose.Fist, Pose.DoubleTap);
            // gives a variable the value of pi(3.14...)
            const float PI = (float)System.Math.PI;
            // calculation for getting the value of the MYO's roll
            var Roll = (f.Roll + PI) / (PI * 2.0f) * 100;
            // gives the string the value of what the roll is and converts it to a string
            string data2 = "Roll: " + Roll.ToString() + Environment.NewLine;
            // calls the method while passing the data2 value to it
            InvokeData2(data2);
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

        public void InvokeData2(string data2)
        {

            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(InvokeData2), new object[] { data2 });
                return;
            }
            // clears the textbox each time a new entry is placed into it
            richTextBox2.Clear();
            richTextBox2.AppendText(data2 + Environment.NewLine);
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            
            InitializeMyo();
            InitializeMyo2();

            // once the button is pressed, then the textboxes appear showing the Roll of the MYO
            richTextBox1.Visible = true;
            richTextBox2.Visible = true;
            // makes the button invisible so the user can't use it again
            btnStartTest.Visible = false;
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // prompts the user if they are sure they want to exit from this section of the app
            DialogResult dialogResult = MessageBox.Show("Do you want to exit to the main menu?", "PongWithMyo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // sends the user to form1(home page)
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

