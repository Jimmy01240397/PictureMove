using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PictureMove;

namespace 推箱子
{
    public partial class Form1 : Form
    {
        int x = 0;
        int y = 0;
        int HowNUM = 10;
        Dictionary<string, PictureMove.PictureMove> o;
        bool a = false;
        public Form1()
        {
            InitializeComponent();

            o = new Dictionary<string, PictureMove.PictureMove>();
            start();
        }

        private void start()
        {
            x = 0;
            y = 0;
            for (int i = 0; i < Controls.Count; i++)
            {
                if(!(Controls[i].Name == "pictureMove1" || Controls[i].Name == "label1"))
                {
                    PictureMove.PictureMove pictureMove = (PictureMove.PictureMove)Controls[i];
                    pictureMove.Tick -= pictureMoveX_Tick;
                    pictureMove.Touch -= pictureMoveX_Touch;
                }
            }
            this.pictureMove1.Location = new System.Drawing.Point(1, 1);
            this.Controls.Clear();
            this.Controls.Add(pictureMove1);
            this.Controls.Add(label1);
            o.Clear();
            label1.Text = "分數：" + o.Count.ToString();
            for (int i = 0; i < HowNUM; i++)
            {
                PictureMove.PictureMove pictureMoveX;
                pictureMoveX = new PictureMove.PictureMove();
                ((System.ComponentModel.ISupportInitialize)(pictureMoveX)).BeginInit();
                pictureMoveX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
                pictureMoveX.form = this;
                pictureMoveX.Interval = 10;
                pictureMoveX.List = null;
                Random rnd = new Random(Guid.NewGuid().GetHashCode());
                pictureMoveX.Location = new System.Drawing.Point(rnd.Next(50, 900), rnd.Next(50, 460));
                pictureMoveX.Name = "pictureMoveX" + i.ToString();
                pictureMoveX.Rotate = 0;
                pictureMoveX.Size = new System.Drawing.Size(40, 40);
                pictureMoveX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pictureMoveX.TabIndex = 0;
                pictureMoveX.TabStop = false;
                pictureMoveX.TurnOrNot = false;
                pictureMoveX.Touch += new PictureMove.PictureMove.OnTouch(pictureMoveX_Touch);
                pictureMoveX.Tick += new PictureMove.PictureMove.OnTick(pictureMoveX_Tick);
                while(pictureMoveX.InSideAll())
                {
                    pictureMoveX.Location = new System.Drawing.Point(rnd.Next(50, 900), rnd.Next(50, 460));
                }
                this.Controls.Add(pictureMoveX);
            }
            a = true;
        }

        private void pictureMoveX_Tick(Control me, object sender, EventArgs e)
        {
            PictureMove.PictureMove pictureMove = (PictureMove.PictureMove)me;
            if (a)
            {
                if (pictureMove.OutSide(this, -10, -40))
                {
                    pictureMove.Moving(-7);
                    if (!o.ContainsKey(pictureMove.Name))
                    {
                        o.Add(pictureMove.Name, pictureMove);
                        label1.Text = "分數：" + o.Count.ToString();

                    }
                }
            }
        }

        private void pictureMove1_Tick(Control me, object sender, EventArgs e)
        {
            if (a)
            {
                if (x == 1)
                {
                    if (y == 1)
                    {
                        pictureMove1.Rotate = 45;
                        pictureMove1.Moving(7);
                    }
                    else if (y == -1)
                    {
                        pictureMove1.Rotate = -45;
                        pictureMove1.Moving(7);
                    }
                    else
                    {
                        pictureMove1.Rotate = 0;
                        pictureMove1.Moving(7);
                    }
                }
                else if (x == -1)
                {
                    if (y == 1)
                    {
                        pictureMove1.Rotate = 135;
                        pictureMove1.Moving(7);
                    }
                    else if (y == -1)
                    {
                        pictureMove1.Rotate = -135;
                        pictureMove1.Moving(7);
                    }
                    else
                    {
                        pictureMove1.Rotate = 180;
                        pictureMove1.Moving(7);
                    }
                }
                else
                {
                    if (y == 1)
                    {
                        pictureMove1.Rotate = 90;
                        pictureMove1.Moving(7);
                    }
                    else if (y == -1)
                    {
                        pictureMove1.Rotate = -90;
                        pictureMove1.Moving(7);
                    }
                    else
                    {

                    }
                }
                if (pictureMove1.OutSide(this, -10, -40))
                {
                    pictureMove1.Moving(-7);
                }
            }
            if (o.Count >= HowNUM && a)
            {
                a = false;
                MessageBox.Show("恭喜過關");
                start();
            }
        }

        private void pictureMoveX_Touch(Control me, Control e)
        {
            if(a)
            {
                PictureMove.PictureMove pictureMove = (PictureMove.PictureMove)me;
                if (e != pictureMove1)
                {
                    if(pictureMove.Direction(e) > 315 || pictureMove.Direction(e) < 45)
                    {
                        pictureMove.Rotate = 180;
                    }
                    else if (pictureMove.Direction(e) > 225 && pictureMove.Direction(e) < 315)
                    {
                        pictureMove.Rotate = 90;
                    }
                    else if (pictureMove.Direction(e) > 135 && pictureMove.Direction(e) < 225)
                    {
                        pictureMove.Rotate = 0;
                    }
                    else if (pictureMove.Direction(e) > 45 && pictureMove.Direction(e) < 135)
                    {
                        pictureMove.Rotate = 270;
                    }
                    pictureMove.Moving(7);
                }
                else if (e == pictureMove1)
                {
                    PictureMove.PictureMove b = (PictureMove.PictureMove)e;
                    pictureMove.Rotate = b.Rotate;
                    pictureMove.Moving(7);
                    if (pictureMove.InSideAll())
                    {
                        pictureMove.Moving(-7);
                    }
                }
            }
        }

        private void pictureMove1_Touch(Control me, Control e)
        {
            if (a)
            {
                pictureMove1.Moving(-7);
                PictureMove.PictureMove pictureMove = (PictureMove.PictureMove)e;
                pictureMoveX_Touch(e, me);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (a)
            {
                if (e.KeyCode == Keys.Up)
                {
                    y = 1;
                }
                if (e.KeyCode == Keys.Down)
                {
                    y = -1;
                }
                if (e.KeyCode == Keys.Right)
                {
                    x = 1;
                }
                if (e.KeyCode == Keys.Left)
                {
                    x = -1;
                }
            }
            else
            {
                x = 0;
                y = 0;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                y = 0;
            }
            else if (e.KeyCode == Keys.Down)
            {
                y = 0;
            }
            if (e.KeyCode == Keys.Right)
            {
                x = 0;
            }
            else if (e.KeyCode == Keys.Left)
            {
                x = 0;
            }
        }
    }
}
