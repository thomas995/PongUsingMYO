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
using System.IO;

namespace PongWithMyo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bgMusic.SoundLocation = "chiptune.wav";
            bgMusic.PlayLooping();

        }

        string Path_PlayerOne = Environment.CurrentDirectory + "/" + "PlayerOneSaves.txt"; // path assigned to saving score
        string Path_PlayerTwo = Environment.CurrentDirectory + "/" + "PlayerTwoSaves.txt"; // path assigned to saving score

        // variable to allow sound effects to be used
        System.Media.SoundPlayer bgMusic = new System.Media.SoundPlayer();


        private void btnStartGame_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ensure MYO is connected to play the game...");
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
            bgMusic.Stop();

        }

        private void btnHighScores_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Path_PlayerOne))
            {
                MessageBox.Show("No Player One Scores Saved. Save before coming here.");
            }
            if (!File.Exists(Path_PlayerTwo))
            {
                MessageBox.Show("No Player Two Scores Saved. Save before coming here.");
            }
            else
            { 
                HighScores hs = new HighScores();
                hs.Show();
                this.Hide();
                bgMusic.Stop();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to exit the game?", "PongWithMyo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close(); // close the program
                bgMusic.Stop();
            }
            else if (dialogResult == DialogResult.No)
            {
                // do nothing
            }
        }

        private void btnMyoTest_Click(object sender, EventArgs e)
        {
            MYO_Test mt = new MYO_Test();
            mt.Show();
            this.Hide();
            bgMusic.Stop();

        }

        private void btnStartGameKB_Click(object sender, EventArgs e)
        {
            FormKB fkb = new FormKB();
            fkb.Show();
            this.Hide();
            bgMusic.Stop();

        }

        // keys to press to pause
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.M)
            {
                bgMusic.Stop();
            }
            // starts the music again
            if (e.KeyCode == Keys.N)
            {
                bgMusic.PlayLooping();
            }
        }
    }
}
