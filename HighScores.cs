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
    public partial class HighScores : Form
    {
        public HighScores()
        {
            InitializeComponent();
            string text1 = System.IO.File.ReadAllText(Environment.CurrentDirectory + "/" + "PlayerOneSaves.txt");
            txtScoresOne.Text = text1.ToString();

            string text2 = System.IO.File.ReadAllText(Environment.CurrentDirectory + "/" + "PlayerTwoSaves.txt");
            txtScoresTwo.Text = text2.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
            
        }
    }
}
