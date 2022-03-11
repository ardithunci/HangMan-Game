using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class HangManGame : Form
    {
        int i = 0;
        string file;
        string target;
        char guess;
        int tries;
        bool hit = false;
        public HangManGame()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void randomWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WordList w1 = new WordList();
            if (w1.ShowDialog() == DialogResult.OK)
                file = WordList.path;
            // MessageBox.Show(file);
            StreamReader sr = new StreamReader(file);
            while (sr.ReadLine() != null)
                i++;
            sr.Dispose();
            sr = new StreamReader(file);
            Random r = new Random();
            for (int k = 0; k < r.Next(1, i-1); k++)
                target = sr.ReadLine();
            sr.Dispose();
            MessageBox.Show(target);
            Setting();
        }
        private void Setting()
        {
            label1.Text = "";
            for (i = 0; i < target.Length; i++)
                label1.Text = label1.Text.Insert(i, "*");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guess = textBox1.Text[0];

            for (i = 0; i < target.Length; i++) {
             
               if (Char.ToUpper(target[i]) ==Char.ToUpper(guess))
                  {
                        hit = true;
                        label1.Text = label1.Text.Remove(i, 1);
                        label1.Text = label1.Text.Insert(i, guess.ToString());
                   }
                
            }
            if (label1.Text.ToUpper() == target.ToUpper())
                WonGame();

            if (!hit)
            {
                tries++;
                switch (tries)
                {
                    case 1:
                        pictureBox1.Image = WindowsFormsApp1.Properties.Resources._0;
                        break;
                    case 2:
                        pictureBox1.Image = WindowsFormsApp1.Properties.Resources._1;
                        break;
                    case 3:
                        pictureBox1.Image = WindowsFormsApp1.Properties.Resources._2;
                        break;
                    case 4:
                        pictureBox1.Image = WindowsFormsApp1.Properties.Resources._3;
                        break;
                    case 5:
                        pictureBox1.Image = WindowsFormsApp1.Properties.Resources._4;
                        break;
                    case 6:
                        pictureBox1.Image = WindowsFormsApp1.Properties.Resources._5;
                        break;
                    case 7:
                        pictureBox1.Image = WindowsFormsApp1.Properties.Resources._6;
                        break;
                    case 8:
                        pictureBox1.Image = WindowsFormsApp1.Properties.Resources._7;
                        break;
                    case 9:
                        pictureBox1.Image = WindowsFormsApp1.Properties.Resources._8;
                        break;
                    case 10:
                        pictureBox1.Image = WindowsFormsApp1.Properties.Resources._9;
                        LostGame();
                        break;
                }
                
            }
            hit = false;
            textBox1.Focus();
            textBox1.SelectAll();
        }
        private void LostGame()
        {
            MessageBox.Show("You Lost :( secret word was " + target);
            ResetGame();
        }
        private void WonGame()
        {
            MessageBox.Show("You Win :) secret word was " + target);
            ResetGame();
        }
        private void ResetGame()
        {
            textBox1.Text = "";
            label1.Text = "Secret Word";
            target = "";
            tries = 0;
            pictureBox1.Image = null;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void HangManGame_Load(object sender, EventArgs e)
        {

        }
    }
}
