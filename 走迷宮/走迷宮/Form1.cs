using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 走迷宮
{
    public partial class Form1 : Form
    {
        int x = 0;
        int y = 0;
        bool a = true;
        Label[,][] labels;
        List<Pos> pos;
        List<KeyValuePair<Pos, int>> len;
        public Form1()
        {
            InitializeComponent();

            NewGame();
        }

        void MakeMap(int x, int y, int cont)
        {
            cont++;
            pos.Add(new Pos(x, y));
            List<Pos> use = new List<Pos>();
            bool HasR = false;
            for (int q = 0; q < 9; q++)
            {
                int i = new Random(Guid.NewGuid().GetHashCode()).Next(-1, 2);
                int ii = new Random(Guid.NewGuid().GetHashCode()).Next(-1, 2);
                Pos xx = new Pos(i, ii);
                while (use.Contains(xx))
                {
                    i = new Random(Guid.NewGuid().GetHashCode()).Next(-1, 2);
                    ii = new Random(Guid.NewGuid().GetHashCode()).Next(-1, 2);
                    xx = new Pos(i, ii);
                }
                use.Add(new Pos(i, ii));
                if ((i != 0 && ii != 0) || (i == 0 && ii == 0))
                {
                    continue;
                }
                if (x + i < 0 || y + ii < 0 || x + i >= this.Size.Width / 45 || y + ii >= this.Size.Height / 45)
                {
                    continue;
                }
                Pos po = new Pos(x + i, y + ii);
                if (pos.Contains(po))
                {
                    continue;
                }
                if (i < 0 || ii < 0)
                {
                    Controls.Remove(labels[x + i, y + ii][i == 0 ? 0 : 1]);
                }
                else
                {
                    Controls.Remove(labels[x, y][i == 0 ? 0 : 1]);
                }
                HasR = true;
                MakeMap(x + i, y + ii, cont);
            }
            if(!HasR)
            {
                len.Add(new KeyValuePair<Pos, int>(new Pos(x, y), cont));
            }
        }

        struct Pos
        {
            public int x;
            public int y;
            public Pos(int x,int y)
            {
                this.x = x;
                this.y = y;
            }
            public bool Equals(Pos obj)
            {
                return x == obj.x && y == obj.y;
            }
        }

        private void pictureMove1_Tick(Control me, object sender, EventArgs e)
        {
            if (x != 0)
            {
                pictureMove1.Rotate = x == 1 ? 0 : 180;
                for (int i = 0; i < 9; i++)
                {
                    pictureMove1.Moving(1);
                    if (pictureMove1.OutSide(this, -10, -40) || pictureMove1.InSideAll())
                    {
                        if (pictureMove1.InSide(label9) && a)
                        {
                            x = 0;
                            y = 0;
                            a = false;
                            MessageBox.Show("恭喜過關");
                            NewGame();
                            a = true;
                        }
                        pictureMove1.Moving(-1);
                        break;
                    }
                }
            }
            if (y != 0)
            {
                pictureMove1.Rotate = y == 1 ? 90 : -90;
                for (int i = 0; i < 9; i++)
                {
                    pictureMove1.Moving(1);
                    if (pictureMove1.OutSide(this, -10, -40) || pictureMove1.InSideAll())
                    {
                        if (pictureMove1.InSide(label9) && a)
                        {
                            x = 0;
                            y = 0;
                            a = false;
                            MessageBox.Show("恭喜過關");
                            NewGame();
                            a = true;
                        }
                        pictureMove1.Moving(-1);
                        break;
                    }
                }
            }
        }

        void NewGame()
        {
            pos = new List<Pos>();
            len = new List<KeyValuePair<Pos, int>>();
            pictureMove1.Location = new System.Drawing.Point(1, 1);
            int x = this.Size.Width / 45;
            int y = this.Size.Height / 45;
            if (labels != null)
            {
                for (int i = 0; i < x; i++)
                {
                    for (int ii = 0; ii < y; ii++)
                    {
                        for (int iii = 0; iii < 3; iii++)
                        {
                            if (Controls.Contains(labels[i, ii][iii]))
                            {
                                Controls.Remove(labels[i, ii][iii]);
                            }
                        }
                    }
                }
            }
            labels = null;
            labels = new Label[x, y][];
            for (int i = 0; i < x; i++)
            {
                for (int ii = 0; ii < y; ii++)
                {
                    labels[i, ii] = new Label[3];
                    labels[i, ii][0] = new Label();
                    labels[i, ii][0].BackColor = System.Drawing.SystemColors.ActiveCaption;
                    labels[i, ii][0].Location = new System.Drawing.Point(45 * i, 45 * ii + 30);
                    labels[i, ii][0].Name = "label" + i + "," + ii + ",0";
                    labels[i, ii][0].Size = new System.Drawing.Size(30, 15);
                    labels[i, ii][0].TabIndex = 1;
                    this.Controls.Add(labels[i, ii][0]);
                    labels[i, ii][1] = new Label();
                    labels[i, ii][1].BackColor = System.Drawing.SystemColors.ActiveCaption;
                    labels[i, ii][1].Location = new System.Drawing.Point(45 * i + 30, 45 * ii);
                    labels[i, ii][1].Name = "label" + i + "," + ii + ",1";
                    labels[i, ii][1].Size = new System.Drawing.Size(15, 30);
                    labels[i, ii][1].TabIndex = 1;
                    this.Controls.Add(labels[i, ii][1]);
                    labels[i, ii][2] = new Label();
                    labels[i, ii][2].BackColor = System.Drawing.SystemColors.ActiveCaption;
                    labels[i, ii][2].Location = new System.Drawing.Point(45 * i + 30, 45 * ii + 30);
                    labels[i, ii][2].Name = "label" + i + "," + ii + ",2";
                    labels[i, ii][2].Size = new System.Drawing.Size(15, 15);
                    labels[i, ii][2].TabIndex = 1;
                    this.Controls.Add(labels[i, ii][2]);
                }
            }
            MakeMap(0, 0, 0);
            len.Sort((a, b) =>
            {
                return b.Value.CompareTo(a.Value);
            });
            label9.Location = new Point(len[0].Key.x * 45 + 15 - label9.Size.Width / 2, len[0].Key.y * 45 + 15 - label9.Size.Height / 2);
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

        private void pictureMove1_Touch(Control me, Control e)
        {
            /*while (pictureMove1.InSide(e))
            {
                pictureMove1.Moving(-10);
            }*/
        }
    }
}
