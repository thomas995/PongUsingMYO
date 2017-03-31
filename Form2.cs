using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Windows.Forms;

using MyoSharp.Device;
using MyoSharp.Communication;
using MyoSharp.Exceptions;
using MyoSharp.Poses;
using System.IO;

namespace PongWithMyo 
{
    public partial class Form2 : Form
    {
        #region VARIABLES
        // GAME VARIABLES

        // channels the MYOs will connect on
        IChannel myoChannel;
        IChannel myoChannel2;

        // hubs MYOs will connect on
        IHub myoHub;
        IHub myoHub2;

        int SpeedOfPlayer = 7; // how fast the player will move

        int PlayerOneMovement; // allows Player One to move
        int PlayerTwoMovement; // allows Player Two to move

        int BallX = 3; // speed of the ball going left to right
        int BallY = 3; // speed of the ball going up and down

        int ScoreOne; // Player One's score
        int ScoreTwo; // Player Two's Score

        string Path_PlayerOne = Environment.CurrentDirectory + "/" + "PlayerOneSaves.txt"; // path assigned to saving score
        string Path_PlayerTwo = Environment.CurrentDirectory + "/" + "PlayerTwoSaves.txt"; // path assigned to saving score

        string Path_PlayerOne_SCOREONLY = Environment.CurrentDirectory + "/" + "PlayerOneSCOREONLY.txt"; // path assigned to saving score(score number only)
        string Path_PlayerTwo_SCOREONLY = Environment.CurrentDirectory + "/" + "PlayerTwoSCOREONLY.txt"; // path assigned to saving score(score number only)

        System.Media.SoundPlayer collisionSound = new System.Media.SoundPlayer();

        bool Pause; // True/False variable for Starting/Pausing the game
        #endregion

        public Form2()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeMyo();


            //InitializeMyo2();

            
            Pause = true;
            

        }

        // Removes the users ability to close, minimize or tab the game from the top bar
        private const int WS_SYSMENU = 0x80000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~WS_SYSMENU;
                return cp;
            }
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
            if (Ball.Location.Y < 0)
            {
                ScoreOne++; // score for player one goes up by one
                p1Score.Text = ScoreOne.ToString();
                                
                // resets the ball back to the center
                Ball.Location = new Point(this.Width / 2, this.Height / 2);
            }
            // if the ball goes above the canvas - player two wins
            if (Ball.Location.Y > this.Height)
            {
                ScoreTwo++; // score for player two goes up by one
                p2score.Text = ScoreTwo.ToString();
               
                // resets the ball back to the center
                Ball.Location = new Point(this.Width / 2, this.Height / 2);
            }
            // if ball hits Player one's paddle
            if (Ball.Location.X > Player1.Location.X && Ball.Location.X + Ball.Width < Player1.Location.X + Player1.Width && Ball.Location.Y + Ball.Height > Player1.Location.Y)
            {
                // moves ball in opposite direction
                BallY *= -1;
                // plays noise on collision
                collisionSound.SoundLocation = "pongSE.wav";
                collisionSound.Play();
            }
            // if ball hits Player two's paddle

            if (Ball.Location.X > Player2.Location.X && Ball.Location.X + Ball.Width < Player2.Location.X + Player2.Width && Ball.Location.Y < Player2.Location.Y + Player2.Height)
            {
                BallY *= -1;
                collisionSound.SoundLocation = "pongSE.wav";
                collisionSound.Play();
            }
            // if ball hits left wall
            if (Ball.Location.X < 0)
            {
                BallX *= -1;
            }
            // if ball hits right wall
            if (Ball.Location.X + Ball.Width > this.Width)
            {
                BallX *= -1;
            }   
        }
       
        #endregion
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopMyo(); // when the windows form is closed/terminated      
        }

        // Creates a channel and hub for the MYO to connect to
        private void InitializeMyo()
        {
                myoChannel = Channel.Create(ChannelDriver.Create(ChannelBridge.Create(), MyoErrorHandlerDriver.Create(MyoErrorHandlerBridge.Create())));
                myoHub = Hub.Create(myoChannel);

                myoHub.MyoConnected += myoHub_MyoConnected; // runs method when MYO connects
                myoHub.MyoDisconnected -= myoHub_MyoDisconnected; // runs method when MYO disconnects

                myoChannel.StartListening();  
        }

        // Creates a channel and hub for the second MYO to connect to
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
            MessageBox.Show("Myo is connected"); // pop up to let user know the MYO is connected

            e.Myo.Vibrate(VibrationType.Long); // vibrates the MYO
            e.Myo.Unlock(UnlockType.Hold); // keeps the MYO unlocked

            e.Myo.OrientationDataAcquired += Myo_OrientationDataAcquired;

            var pose = HeldPose.Create(e.Myo, Pose.Fist, Pose.WaveIn, Pose.WaveOut);

            pose.Interval = TimeSpan.FromSeconds(0.5); // checks which pose is being done every half second
            pose.Start();
            // pose.Triggered += pose_Triggered;
        }
        void myoHub2_MyoConnected(object sender, MyoEventArgs f)
        {
             MessageBox.Show("Myo 2 is connected"); // lets the user know that the second MYO is connected

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
            var InitRoll = 38;
            if (e.Myo.Pose == Pose.DoubleTap)
            {
                // Close();
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
                    SpeedOfPlayer = 7;
                    PlayerOneMovement = SpeedOfPlayer;
                }
                //PlayerOneMovement = SpeedOfPlayer;
            }
            else if (Roll >= InitRoll)
            {
                if (Player1.Location.X < 0)
                {
                    PlayerOneMovement = 0;
                }
                else if (Player1.Location.X > 0)
                {
                    SpeedOfPlayer = 7;
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
                this.Close();
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
                    SpeedOfPlayer = 7;
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
                    SpeedOfPlayer = 7;
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

        // Lets the user know that the MYO's have been disconnected
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

            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(InvokeData), new object[] { data });
                return;
            }
        }

        public void InvokeData2(string data2)
        {

            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(InvokeData), new object[] { data2 });
                return;
            }
           
        }

        // When the method is called, stops and drops the channels the MYO's are connected to
        private void StopMyo()
        {
            myoChannel.StopListening();
            myoChannel.Dispose();
            myoChannel2.StopListening();
            myoChannel2.Dispose();
        }

        // only needed for testing with keyboard, will be controlled with MYO
        private void Form1_KeyDown(object sender, KeyEventArgs e) 
        {

            #region PLAYER MOVEMENT
            if (e.KeyCode == Keys.Right)
            {
                if (Player1.Location.X + Player1.Width > this.Width)
                {
                    //PlayerOneMovement = 0;
                }
                else
                {
                    //SpeedOfPlayer = 4;
                    //PlayerOneMovement = SpeedOfPlayer;
                }
            }
            else if ((e.KeyCode == Keys.Left))
            {
                if (Player1.Location.X < 0)
                {
                   // PlayerOneMovement = 0;
                }
                else if (Player1.Location.X > 0)
                {
                    //SpeedOfPlayer = 4;
                   // PlayerOneMovement = -SpeedOfPlayer;
                }
            }

            // When the esc key is pressed, prompt user if they want to save the game before exiting
            else if (e.KeyCode == Keys.Escape)
            {
                Pause = true;
                DialogResult dialogResult = MessageBox.Show("Do you want to save your score before closing the game?", "PongWithMyo", MessageBoxButtons.YesNoCancel);

                if (dialogResult == DialogResult.Yes)
                {
                    if ((File.Exists(Path_PlayerOne)))
                    {

                        StreamWriter SW1;
                        StreamWriter SW1_SO;
                        SW1 = File.AppendText(Path_PlayerOne);
                        SW1_SO = File.AppendText(Path_PlayerOne_SCOREONLY);
                        SW1.WriteLine(ScoreOne + " - Player One(MYO)  " + DateTime.Now);
                        SW1_SO.WriteLine(ScoreOne);
                        MessageBox.Show("Player One's Score Saved Successfully");
                        SW1.Close();
                        SW1_SO.Close();
                    }
                    if (!File.Exists(Path_PlayerOne))
                    {
                        StreamWriter SW1;
                        StreamWriter SW1_SO;
                        SW1 = File.CreateText(Path_PlayerOne);
                        SW1_SO = File.CreateText(Path_PlayerOne_SCOREONLY);
                        SW1.Close();
                        SW1_SO.Close();
                        SW1 = File.AppendText(Path_PlayerOne);
                        SW1_SO = File.AppendText(Path_PlayerOne_SCOREONLY);
                        SW1.WriteLine(ScoreOne + " - Player One(MYO)  " + DateTime.Now);
                        SW1_SO.WriteLine(ScoreOne);
                        MessageBox.Show("Player One's Score Saved Successfully");
                        SW1.Close();
                        SW1_SO.Close();
                    }


                    if (File.Exists(Path_PlayerTwo))
                    {

                        StreamWriter SW2;
                        StreamWriter SW2_SO;
                        SW2 = File.AppendText(Path_PlayerTwo);
                        SW2_SO = File.AppendText(Path_PlayerTwo_SCOREONLY);
                        SW2.WriteLine(ScoreTwo + " - Player Two  " + DateTime.Now);
                        SW2_SO.WriteLine(ScoreTwo);
                        MessageBox.Show("Player Two's Score Saved Successfully");
                        SW2.Close();
                        SW2_SO.Close();
                        
                        //StopMyo();
                        Form1 f1 = new Form1();
                        f1.Show();
                        this.Hide();
                    }
                    if (!File.Exists(Path_PlayerTwo))
                    {

                        StreamWriter SW2;
                        StreamWriter SW2_SO;
                        SW2 = File.CreateText(Path_PlayerTwo);
                        SW2_SO = File.CreateText(Path_PlayerTwo_SCOREONLY);
                        SW2.Close();
                        SW2_SO.Close();
                        SW2 = File.AppendText(Path_PlayerTwo);
                        SW2_SO = File.AppendText(Path_PlayerTwo_SCOREONLY);
                        SW2.WriteLine(ScoreTwo + " - Player Two(MYO)  " + DateTime.Now);
                        SW2_SO.WriteLine(ScoreTwo);
                        MessageBox.Show("Player Two's Score Saved Successfully");
                        SW2.Close();
                        SW2_SO.Close();
                        
                        //StopMyo();
                        Form1 f1 = new Form1();
                        f1.Show();
                        this.Hide();
                    }
                } // YES

                if (dialogResult == DialogResult.No)
                {
                    //StopMyo();
                    Form1 f1 = new Form1();
                    f1.Show();
                    this.Hide();
                }
                else if(dialogResult == DialogResult.Cancel)
                {
                    // do nothing
                }
            }

            else if ((e.KeyCode == Keys.A))
            {
                if (Player2.Location.X < 0)
                {
                    PlayerTwoMovement = 0;
                }
                else if (Player2.Location.X > 0)
                {
                    SpeedOfPlayer = 7;
                    PlayerTwoMovement = -SpeedOfPlayer;
                }
            }
            else if ((e.KeyCode == Keys.D))
            {
                if (Player2.Location.X + Player2.Width > this.Width)
                {
                    PlayerTwoMovement = 0;
                }
                else
                {
                    SpeedOfPlayer = 7;
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
            else if ((e.KeyCode == Keys.Escape))
            {
                PlayerTwoMovement = 0;
                Pause = false;
            }

        }
    }
}
// ADAPTED FROM https://www.codeproject.com/Articles/826194/Controlling-a-Myo-Armband-with-Csharp
