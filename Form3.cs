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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }


        #region VARIABLES
        // GAME VARIABLES
        
        int SpeedOfPlayer = 4; // how fast the player will move

        int PlayerOneMovement; // allows Player One to move
        int PlayerTwoMovement; // allows Player Two to move

        int BallX = 4; // speed of the ball going left to right
        int BallY = 4; // speed of the ball going up and down

        int ScoreOne; // Player One's score
        int ScoreTwo; // Player Two's Score

        string Path_PlayerOne = Environment.CurrentDirectory + "/" + "PlayerOneSaves.txt"; // path assigned to saving score
        string Path_PlayerTwo = Environment.CurrentDirectory + "/" + "PlayerTwoSaves.txt"; // path assigned to saving score


        bool Pause; // True/False variable for Starting/Pausing the game
        #endregion


        private void Form1_Load(object sender, EventArgs e)
        {

            //  InitializeMyo2();

            // When the game starts, have it remain paused until the player is ready
            // and also display a message box telling the plyer how to play the game
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
            else if ((e.KeyCode == Keys.Left))
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
                        SW1 = File.AppendText(Path_PlayerOne);
                        SW1.WriteLine(ScoreOne + " - Player One  " + DateTime.Now);
                        MessageBox.Show("Player One's Score Saved Successfully");
                        SW1.Close();
                    }
                    if (!File.Exists(Path_PlayerOne))
                    {
                        StreamWriter SW1;
                        SW1 = File.CreateText(Path_PlayerOne);
                        SW1.Close();
                        SW1 = File.AppendText(Path_PlayerOne);
                        SW1.WriteLine(ScoreOne + " - Player One  " + DateTime.Now);
                        MessageBox.Show("Player One's Score Saved Successfully");
                        SW1.Close();
                    }


                    if (File.Exists(Path_PlayerTwo))
                    {
                        StreamWriter SW2;
                        SW2 = File.AppendText(Path_PlayerTwo);
                        SW2.WriteLine(ScoreTwo + " - Player Two  " + DateTime.Now);
                        MessageBox.Show("Player Two's Score Saved Successfully");
                        SW2.Close();
                        this.Close();
                    }
                    if (!File.Exists(Path_PlayerTwo))
                    {
                        StreamWriter SW2;
                        SW2 = File.CreateText(Path_PlayerTwo);
                        SW2.Close();
                        SW2 = File.AppendText(Path_PlayerTwo);
                        SW2.WriteLine(ScoreTwo + " - Player Two  " + DateTime.Now);
                        MessageBox.Show("Player Two's Score Saved Successfully");
                        SW2.Close();
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
                    SpeedOfPlayer = 4;
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
            else if ((e.KeyCode == Keys.Escape))
            {
                PlayerTwoMovement = 0;
                Pause = false;
            }

        }

    }
}
