using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class WordList : Form
    {
        public static string path;
        public WordList()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            if (opd.ShowDialog() == DialogResult.OK)
            {
                path = opd.FileName;
                textBox1.Text = path;
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (textBox1 != null)
            {
                if (textBox1.Text != null)
                {
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
