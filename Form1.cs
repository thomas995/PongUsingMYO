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
        IChannel myoChannel;
        IHub myoHub;
        
        int PlayerSpeed = 8;
        //int BallSpeed;

        int P1Vel;
        int P2Vel;

        int bVelX = 2;
        int bVelY = 2;
        
        int display = 0;
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
            if (display == 0)
            {
                //MessageBox.Show("PRESS SPACE TO BEGIN GAME");
                display++;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (!Pause)
           {
                Ball.Location = new Point(Ball.Location.X + bVelX, Ball.Location.Y + bVelY);
                
                Player1.Location = new Point(Player1.Location.X + P1Vel, Player1.Location.Y);
                
                Player2.Location = new Point(Player2.Location.X + P2Vel, Player2.Location.Y);
            }
            if(Ball.Location.Y < 0)
            {
                ScoreOne++;
                p1Score.Text = ScoreOne.ToString();
                Ball.Width-=2;
                Ball.Height-=2;
                Ball.Location = new Point(this.Width / 2, this.Height / 2);
            }
            if (Ball.Location.Y > this.Height)
            {
                ScoreTwo++;
                p2score.Text = ScoreTwo.ToString();
                Ball.Width--;
                Ball.Height--;
                Ball.Location = new Point(this.Width / 2, this.Height / 2);
            }

            if (Ball.Location.X > Player1.Location.X && Ball.Location.X + Ball.Width < Player1.Location.X + Player1.Width && Ball.Location.Y + Ball.Height > Player1.Location.Y)
            {
                bVelY *= -1;
            }
            if (Ball.Location.X > Player2.Location.X && Ball.Location.X + Ball.Width < Player2.Location.X + Player2.Width && Ball.Location.Y < Player2.Location.Y + Player2.Height)
            {
                bVelY *= -1;
            }
            if(Ball.Location.X < 0)
            {
                bVelX *= -1;
            }
            if(Ball.Location.X + Ball.Width > this.Width)
            {
                bVelX *= -1;
            }

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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            #region PLAYER MOVEMENT
            if (e.KeyCode == Keys.Right)
            {
                P1Vel = PlayerSpeed;
            }
            else if((e.KeyCode == Keys.Left))
            {
                P1Vel = -PlayerSpeed;
            }
            else if((e.KeyCode == Keys.A))
            {
                P2Vel = -PlayerSpeed;
            }
            else if((e.KeyCode == Keys.D))
            {
                P2Vel = PlayerSpeed;
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
                P1Vel = 0;
            }
            else if ((e.KeyCode == Keys.Left))
            {
                P1Vel = 0;
            }
            else if ((e.KeyCode == Keys.A))
            {
                P2Vel = 0;
            }
            else if ((e.KeyCode == Keys.D))
            {
                P2Vel = 0;
            }
        }
    }
}
