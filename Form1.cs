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
        }

        string Path_PlayerOne = Environment.CurrentDirectory + "/" + "PlayerOneSaves.txt"; // path assigned to saving score
        string Path_PlayerTwo = Environment.CurrentDirectory + "/" + "PlayerTwoSaves.txt"; // path assigned to saving score

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
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
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to exit the game?", "PongWithMyo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close(); // close the program
            }
            else if (dialogResult == DialogResult.No)
            {
                // do nothing
            }
        }
    }
}
