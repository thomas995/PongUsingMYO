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
        #region VARIABLES
        // VARIABLES
        IChannel myoChannel;
        IHub myoHub;
        
        int SpeedOfPlayer = 8;

        int PlayerOneMovement;
        int PlayerTwoMovement;

        int BallX = 2;
        int BallY = 2;
        
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
            // InitializeMyo();

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
                Ball.Width-=2;
                Ball.Height-=2;
                // resets the ball back to the center
                Ball.Location = new Point(this.Width / 2, this.Height / 2);
            }
            // if the ball goes above the canvas - player two wins
            if (Ball.Location.Y > this.Height)
            {
                ScoreTwo++; // score for player two goes up by one
                p2score.Text = ScoreTwo.ToString();
                // shrinks the ball slightlyS
                Ball.Width-=2;
                Ball.Height-=2;
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

        private void StopMyo()
        {
            //myoChannel.StopListening();
            //myoChannel.Dispose();
        }
        #endregion

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            #region PLAYER MOVEMENT
            if (e.KeyCode == Keys.Right)
            {
                PlayerOneMovement = SpeedOfPlayer;
            }
            else if((e.KeyCode == Keys.Left))
            {
                PlayerOneMovement = -SpeedOfPlayer;
            }
            else if((e.KeyCode == Keys.A))
            {
                PlayerTwoMovement = -SpeedOfPlayer;
            }
            else if((e.KeyCode == Keys.D))
            {
                PlayerTwoMovement = SpeedOfPlayer;
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
