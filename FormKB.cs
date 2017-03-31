using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PongWithMyo
{
    public partial class FormKB : Form
    {
        #region VARIABLES
        // GAME VARIABLES
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



        bool Pause; // True/False variable for Starting/Pausing the game

        //System.Media.SoundPlayer bgMusic = new System.Media.SoundPlayer();
        System.Media.SoundPlayer collisionSound = new System.Media.SoundPlayer();


        #endregion


        public FormKB()
        {
            InitializeComponent();
        }

        private void FormKB_Load(object sender, EventArgs e)
        {
            Pause = true;
            MessageBox.Show("TRY TO GET THE BALL PAST THE ENEMY'S PADDLE." +
                "PREVENT THE ENEMY FROM GETTING THE BALL PAST YOUR PADDLE. " +
                "PRESS SPACE TO BEGIN GAME(AND PAUSE THE GAME AT ANY POINT).");

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
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            // if the game isn't paused
            if (!Pause)
            {
                // set the location for all the objects in the game
                Ball.Location = new Point(Ball.Location.X + BallX, Ball.Location.Y + BallY);

                Player1.Location = new Point(Player1.Location.X + PlayerOneMovement, Player1.Location.Y);

                Player2.Location = new Point(Player2.Location.X + PlayerTwoMovement, Player2.Location.Y);
            }
            // if the ball goes below the canvas - player one wins a point
            if (Ball.Location.Y < 0)
            {
                ScoreOne++; // score for player one goes up by one
                p1Score.Text = ScoreOne.ToString();

                // resets the ball back to the center
                Ball.Location = new Point(this.Width / 2, this.Height / 2);
            }
            // if the ball goes above the canvas - player two wins a point
            if (Ball.Location.Y > this.Height)
            {
                ScoreTwo++; // score for player two goes up by one
                p2score.Text = ScoreTwo.ToString();

                // resets the ball back to the center
                Ball.Location = new Point(this.Width / 2, this.Height / 2);
            }
            // if the ball hits player one's paddle
            if (Ball.Location.X > Player1.Location.X && Ball.Location.X + Ball.Width < Player1.Location.X + Player1.Width && Ball.Location.Y + Ball.Height > Player1.Location.Y)
            {
                BallY *= -1;
                collisionSound.SoundLocation = "pongSE.wav";
                collisionSound.Play();
            }
            // if the ball hits player two's paddle
            if (Ball.Location.X > Player2.Location.X && Ball.Location.X + Ball.Width < Player2.Location.X + Player2.Width && Ball.Location.Y < Player2.Location.Y + Player2.Height)
            {
                BallY *= -1;
                collisionSound.SoundLocation = "pongSE.wav";
                collisionSound.Play();
            }
            // if the ball hits the left wall
            if (Ball.Location.X < 0)
            {
                BallX *= -1;
                //collisionSound.SoundLocation = "pongSE.wav";
                //collisionSound.Play();
            }
            // if the ball hits the right wall
            if (Ball.Location.X + Ball.Width > this.Width)
            {
                BallX *= -1;
                //collisionSound.SoundLocation = "pongSE.wav";
               // collisionSound.Play();
            }
        }
        #endregion

        private void FormKB_KeyDown(object sender, KeyEventArgs e)
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
                    SpeedOfPlayer = 7;
                    PlayerOneMovement = SpeedOfPlayer;
                }
            }
            else if ((e.KeyCode == Keys.Left))
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
                        SW1.WriteLine(ScoreOne + " - Player One  " + DateTime.Now);
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
                        SW1.WriteLine(ScoreOne + " - Player One(KB)  " + DateTime.Now);
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
                        SW2.WriteLine(ScoreTwo + " - Player Two(KB)  " + DateTime.Now);
                        SW2_SO.WriteLine(ScoreTwo);
                        MessageBox.Show("Player Two's Score Saved Successfully");
                        SW2.Close();
                        SW2_SO.Close();

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
                        SW2.WriteLine(ScoreTwo + " - Player Two  " + DateTime.Now);
                        SW2_SO.WriteLine(ScoreTwo);
                        MessageBox.Show("Player Two's Score Saved Successfully");
                        SW2.Close();
                        SW2_SO.Close();


                        Form1 f1 = new Form1();
                        f1.Show();
                        this.Hide();
                    }
                } // YES

                if (dialogResult == DialogResult.No)
                {
                    Form1 f1 = new Form1();
                    f1.Show();
                    this.Hide();
                }
                else if (dialogResult == DialogResult.Cancel)
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
                    SpeedOfPlayer = 6;
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
                    SpeedOfPlayer = 6;
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

        private void FormKB_KeyUp(object sender, KeyEventArgs e)
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
