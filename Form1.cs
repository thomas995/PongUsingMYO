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
using MyoSharp.Poses;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PongWithMyo
{
    public partial class Form1 : Form
    {
        #region VARIABLES
        // VARIABLES
        IChannel myoChannel;
        IChannel myoChannel2;

        IHub myoHub;
        IHub myoHub2;
        
        int SpeedOfPlayer = 4;

        int PlayerOneMovement;
        int PlayerTwoMovement;

        int BallX = 1;
        int BallY = 1;
        
        int ScoreOne;
        int ScoreTwo;
        
        bool Pause;
        #endregion

        public Form1()
        {
            InitializeComponent();       
        }
         
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeMyo();

            InitializeMyo2();

            Pause = true;
            MessageBox.Show("TRY TO GET THE BALL PAST THE ENEMY'S PADDLE."+
                "PREVENT THE ENEMY FROM GETTING THE BALL PAST YOUR PADDLE. " +
                "PRESS SPACE TO BEGIN GAME(AND PAUSE THE GAME AT ANY POINT).");
            
        }
        #region CODE FOR PONG LOGIC
        private void timer1_Tick(object sender, EventArgs e)
        {
            // if the game isn't paused
            if (!Pause)
           {
                // set the location for all the objects in the game
                Ball.Location = new Point(Ball.Location.X + BallX, Ball.Location.Y + BallY);
                
                Player1.Location = new Point(Player1.Location.X + PlayerOneMovement, Player1.Location.Y);
                
                Player2.Location = new Point(Player2.Location.X + PlayerTwoMovement, Player2.Location.Y);
            }
            // if the ball goes below the canvas - player one wins
            if(Ball.Location.Y < 0)
            {
                ScoreOne++; // score for player one goes up by one
                p1Score.Text = ScoreOne.ToString();
                // shrinks the ball slightly
                Ball.Width-=1;
                Ball.Height-=1;
                // resets the ball back to the center
                Ball.Location = new Point(this.Width / 2, this.Height / 2);
            }
            // if the ball goes above the canvas - player two wins
            if (Ball.Location.Y > this.Height)
            {
                ScoreTwo++; // score for player two goes up by one
                p2score.Text = ScoreTwo.ToString();
                // shrinks the ball slightlyS
                Ball.Width-=1;
                Ball.Height-=1;
                // resets the ball back to the center
                Ball.Location = new Point(this.Width / 2, this.Height / 2);
            }

            if (Ball.Location.X > Player1.Location.X && Ball.Location.X + Ball.Width < Player1.Location.X + Player1.Width && Ball.Location.Y + Ball.Height > Player1.Location.Y)
            {
                BallY *= -1;
            }
            if (Ball.Location.X > Player2.Location.X && Ball.Location.X + Ball.Width < Player2.Location.X + Player2.Width && Ball.Location.Y < Player2.Location.Y + Player2.Height)
            {
                BallY *= -1;
            }
            if(Ball.Location.X < 0)
            {
                BallX *= -1;
            }
            if(Ball.Location.X + Ball.Width > this.Width)
            {
                BallX *= -1;
            }
          
        }
        #endregion
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopMyo();
            
        }

        private void InitializeMyo()
        {
            myoChannel = Channel.Create(ChannelDriver.Create(ChannelBridge.Create(), MyoErrorHandlerDriver.Create(MyoErrorHandlerBridge.Create())));
            myoHub = Hub.Create(myoChannel);

            myoHub.MyoConnected += myoHub_MyoConnected; 
            myoHub.MyoDisconnected -= myoHub_MyoDisconnected;

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

        private void Myo_OrientationDataAcquired(object sender, OrientationDataEventArgs e)
        {
            var pose = HeldPose.Create(e.Myo, Pose.Fist, Pose.DoubleTap);
            const float PI = (float)System.Math.PI;
            var Roll = (e.Roll + PI) / (PI * 2.0f) * 100;
            string data = "Roll: " + Roll.ToString() + Environment.NewLine;
            InvokeData(data);
            var InitRoll = 50;
            if (e.Myo.Pose == Pose.DoubleTap)
            {
                Close();
            }
            if (e.Myo.Pose == Pose.Fist)
            {
                PlayerOneMovement = 0;
            }
            else if (Roll <= InitRoll) 
            {
                if (Player1.Location.X + Player1.Width > this.Width)
                {
                    PlayerOneMovement = 0;
                }
                else
                {
                    SpeedOfPlayer = 4;
                    PlayerOneMovement = SpeedOfPlayer;
                }
                //PlayerOneMovement = SpeedOfPlayer;
            }
            else if(Roll >= InitRoll)
            {
                if (Player1.Location.X < 0)
                {
                    PlayerOneMovement = 0;
                }
                else if (Player1.Location.X > 0)
                {
                    SpeedOfPlayer = 4;
                    PlayerOneMovement = -SpeedOfPlayer;
                } 
            }
            
        }
        private void Myo2_OrientationDataAcquired(object sender, OrientationDataEventArgs f)
        {
            var pose = HeldPose.Create(f.Myo, Pose.Fist, Pose.DoubleTap);
            const float PI = (float)System.Math.PI;
            var Roll = (f.Roll + PI) / (PI * 2.0f) * 100;
            string data2 = "Roll: " + Roll.ToString() + Environment.NewLine;
            InvokeData2(data2);
            var InitRoll = 50;
            if (f.Myo.Pose == Pose.DoubleTap)
            {
                Close();
            }
            if (f.Myo.Pose == Pose.Fist)
            {
                PlayerTwoMovement = 0;
            }
            else if (Roll <= InitRoll)
            {
                if (Player2.Location.X + Player2.Width > this.Width)
                {
                    PlayerTwoMovement = 0;
                }
                else
                {
                    SpeedOfPlayer = 4;
                    PlayerTwoMovement = SpeedOfPlayer;
                }
                //PlayerOneMovement = SpeedOfPlayer;
            }
            else if (Roll >= InitRoll)
            {
                if (Player2.Location.X < 0)
                {
                    PlayerTwoMovement = 0;
                }
                else if (Player2.Location.X > 0)
                {
                    SpeedOfPlayer = 4;
                    PlayerTwoMovement = -SpeedOfPlayer;
                }
            }

        }
        /* SCRAPPED IDEA FOR POSES DUE TO POOR ACCURACY
        void pose_Triggered(object sene, PoseEventArgs e)
        {
            // InvokeData(e.Pose.ToString());

            if (e.Myo.Pose == Pose.WaveIn)
            {
                PlayerOneMovement = SpeedOfPlayer;
            }
            else if (e.Myo.Pose == Pose.WaveOut)
            {
                PlayerOneMovement = -SpeedOfPlayer;
            }
            else if(e.Myo.Pose == Pose.Unknown)
            {
                PlayerOneMovement = 0;
            }
            else
            {
                PlayerOneMovement = 0;
            }
        }
        */


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


        public void InvokeData(string data)
        {

             if(InvokeRequired)
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
                this.Invoke(new Action<string>(InvokeData), new object[] { data2 });
                return;
            }
            richTextBox2.Clear();
            richTextBox2.AppendText(data2 + Environment.NewLine);

        }
         
        private void StopMyo()
        {
            myoChannel.StopListening();
            myoChannel.Dispose();
            myoChannel2.StartListening();
            myoChannel2.Dispose();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            #region PLAYER MOVEMENT
            if (e.KeyCode == Keys.Right)
            {
                if (Player1.Location.X + Player1.Width > this.Width)
                {
                    PlayerOneMovement = 0;
                }
                else
                {
                    SpeedOfPlayer = 4;
                    PlayerOneMovement = SpeedOfPlayer;
                }
            }
            else if((e.KeyCode == Keys.Left))
            {
                if (Player1.Location.X < 0)
                {
                    PlayerOneMovement = 0;
                }
                else if(Player1.Location.X > 0)
                {
                    SpeedOfPlayer = 4;
                    PlayerOneMovement = -SpeedOfPlayer;
                }
            }
            else if((e.KeyCode == Keys.A))
            {
                if (Player2.Location.X < 0)
                {
                    PlayerTwoMovement = 0;
                }
                else if (Player2.Location.X > 0)
                {
                    SpeedOfPlayer = 4;
                    PlayerTwoMovement = -SpeedOfPlayer;
                }
            }
            else if((e.KeyCode == Keys.D))
            {
                if (Player2.Location.X + Player2.Width > this.Width)
                {
                    PlayerTwoMovement = 0; 
                }
                else
                {
                    SpeedOfPlayer = 4;
                    PlayerTwoMovement = SpeedOfPlayer; 
                }
            }

            #endregion
            #region PAUSING GAME
            else if ((e.KeyCode == Keys.Space))
            {
                if (!Pause)
                {
                    Pause = true;
                }
                else if (Pause)
                {
                    Pause = false;
                }
            }
            #endregion
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                PlayerOneMovement = 0;
            }
            else if ((e.KeyCode == Keys.Left))
            {
                PlayerOneMovement = 0;
            }
            else if ((e.KeyCode == Keys.A))
            {
                PlayerTwoMovement = 0;
            }
            else if ((e.KeyCode == Keys.D))
            {
                PlayerTwoMovement = 0;
            }
        }
    }
}
