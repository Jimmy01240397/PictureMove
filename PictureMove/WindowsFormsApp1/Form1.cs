using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                pictureMove1.Rotate = Convert.ToInt32(textBox1.Text);
            }
            catch(Exception)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void pictureMove1_Tick(Control me, object sender, EventArgs e)
        {
            pictureMove1.NextPicture();
            pictureMove1.Moving(10);
            if(pictureMove1.OutSide(this, 0, -40))
            {
                pictureMove1.Moving(-10);
                pictureMove1.Rotate += 90;
            }
        }

        private void pictureMove1_Touch(Control me, Control e)
        {
            pictureMove1.Moving(-10);
            pictureMove1.Rotate += 90;
            label1.Text = e.Name;
        }
    }
}
