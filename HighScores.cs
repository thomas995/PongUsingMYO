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
    public partial class HighScores : Form
    {
        public HighScores()
        {
            InitializeComponent();
            // variable to take text file in the programs directory and output it to a textbox
            string text1 = System.IO.File.ReadAllText(Environment.CurrentDirectory + "/" + "PlayerOneSaves.txt");
            txtScoresOne.Text = text1.ToString();

            // variable to take text file in the programs directory and output it to a textbox
            string text2 = System.IO.File.ReadAllText(Environment.CurrentDirectory + "/" + "PlayerTwoSaves.txt");
            txtScoresTwo.Text = text2.ToString();

            // Reads in all the scores from the file and only outputs to the textbox the highest
            var maxP1 = File.ReadAllLines(Environment.CurrentDirectory + "/" + "PlayerOneSCOREONLY.txt").Select(int.Parse).Max(); // gets highest score from text file
            var maxP2 = File.ReadAllLines(Environment.CurrentDirectory + "/" + "PlayerTwoSCOREONLY.txt").Select(int.Parse).Max(); // gets highest score from text file

            // if Player one has higher score, output that score to textbox
            if (maxP1 > maxP2)
            {
                txtHighScore.Text = maxP1.ToString();
            }

            // if Player two has higher score, output that score to textbox
            else if (maxP2 > maxP1)
            {
                txtHighScore.Text = maxP2.ToString();
            }
            //var max = File.ReadAllLines(Environment.CurrentDirectory + "/" + "PlayerOneSCOREONLY.txt").Select(int.Parse).Max();
            //txtHighScore.Text = max.ToString();
        }

        // navigate back to the home page
        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
            
        }
    }
}
