using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PictureMove
{
    public class PictureMove : PictureBox
    {
        int Index = -1;
        Image _Image;
        Timer timer;
        bool start = true;
        public ScrollableControl form { get; set; }
        public bool TurnOrNot { get; set; }

        public delegate void OnTouch(Control me, Control e);
        public event OnTouch Touch;
        public delegate void OnTick(Control me, object sender, EventArgs e);
        public event OnTick Tick;
        public ImageList List { get; set; }
        public int Interval
        {
            get { return timer.Interval; }
            set { timer.Stop(); timer.Interval = value; timer.Start(); }
        }
        public int Rotate { get; set; }
        public PictureMove() : base()
        {
            try
            {
                _Image = Image;
                timer = new Timer();
                timer.Tick += new System.EventHandler(this.Timer_Tick);
                Interval = 100;
                timer.Start();
            }
            catch (Exception)
            {

            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            try
            {
                Tick(this, sender, e);
            }
            catch (Exception)
            {

            }
            if (start)
            {
                _Image = Image;
                start = false;
            }
            try
            {
                for (int i = 0; i < form.Controls.Count; i++)
                {
                    if (InSide(form.Controls[i]) && form.Controls[i] != this)
                    {
                        Touch(this, form.Controls[i]);
                    }
                }
            }
            catch (Exception)
            {

            }
            try
            {
                if (TurnOrNot)
                {
                    Rotating(Rotate);
                }
            }
            catch (Exception)
            {

            }
        }

        public void NextPicture()
        {
            if (List.Images.Count != 0)
            {
                if (Image == null || Index == List.Images.Count - 1)
                {
                    Index = 0;
                    Image = List.Images[Index];
                    _Image = Image;
                }
                else
                {
                    Index++;
                    Image = List.Images[Index];
                    _Image = Image;
                }
            }
        }
        public void LastPicture()
        {
            if (List.Images.Count != 0)
            {
                if (Image == null || Index == 0)
                {
                    Index = List.Images.Count - 1;
                    Image = List.Images[Index];
                    _Image = Image;
                }
                else
                {
                    Index--;
                    Image = List.Images[Index];
                    _Image = Image;
                }
            }
        }
        public void NumPicture(int index)
        {
            if (List.Images.Count > Index)
            {
                this.Index = index;
                Image = List.Images[Index];
                _Image = Image;
            }
        }

        private void Rotating(int angle)
        {
            Bitmap b = new Bitmap(_Image);
            angle = angle % 360;

            //弧度转换
            double radian = angle * Math.PI / 180.0;
            double cos = Math.Cos(radian);
            double sin = Math.Sin(radian);

            //原图的宽和高
            int w = b.Width;
            int h = b.Height;
            int W = (int)(Math.Max(Math.Abs(w * cos - h * sin), Math.Abs(w * cos + h * sin)));
            int H = (int)(Math.Max(Math.Abs(w * sin - h * cos), Math.Abs(w * sin + h * cos)));

            //目标位图
            Bitmap dsImage = new Bitmap(W, H);
            Graphics g = Graphics.FromImage(dsImage);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //计算偏移量
            Point Offset = new Point((W - w) / 2, (H - h) / 2);

            //构造图像显示区域：让图像的中心与窗口的中心点一致
            Rectangle rect = new Rectangle(Offset.X, Offset.Y, w, h);
            Point center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
            g.TranslateTransform(center.X, center.Y);
            g.RotateTransform(360 - angle);

            //恢复图像在水平和垂直方向的平移
            g.TranslateTransform(-center.X, -center.Y);
            g.DrawImage(b, rect);

            //重至绘图的所有变换
            g.ResetTransform();

            g.Save();
            g.Dispose();
            Image = dsImage;
        }
        public void Moving(int Long)
        {
            double radian = Rotate * Math.PI / 180.0;
            double x = Math.Cos(radian) * Long;
            double y = -Math.Sin(radian) * Long;
            Location = new System.Drawing.Point(Location.X + (int)x, Location.Y + (int)y);
        }

        public bool OutSide(ScrollableControl scrollable)
        {
            return Location.X <= 0 || Location.Y <= 0 || Location.X + Size.Width >= scrollable.Width || Location.Y + Size.Height >= scrollable.Height;
        }
        public bool OutSide(ScrollableControl scrollable, int x, int y)
        {
            return Location.X <= 0 || Location.Y <= 0 || Location.X + Size.Width >= scrollable.Width + x || Location.Y + Size.Height >= scrollable.Height + y;
        }

        public bool InSide(Control control)
        {
            return Location.X <= control.Location.X + control.Size.Width && Location.Y <= control.Location.Y + control.Size.Height && Location.X + Size.Width >= control.Location.X && Location.Y + Size.Height >= control.Location.Y;
        }
        public int Direction(Control control)
        {
            try
            {
                double radian = Math.Asin(-(double)(control.Location.Y - Location.Y) / Math.Sqrt(Math.Pow(-(double)(control.Location.Y - Location.Y), 2) + Math.Pow((double)(control.Location.X - Location.X), 2)));
                int a = Convert.ToInt32(radian / Math.PI * 180.0);
                if(a < 0)
                {
                    if (control.Location.X - Location.X >= 0)
                    {
                        return 360 + a;
                    }
                    else
                    {
                        return 360 + (-180 - a);
                    }
                }
                else if (a == 360)
                {
                    return 0;
                }
                else
                {
                    if (control.Location.X - Location.X >= 0)
                    {
                        return a;
                    }
                    else
                    {
                        return 180 - a;
                    }

                }
            }
            catch(Exception)
            {
                return 0;
            }
        }
        public bool InSideAll()
        {
            for (int i = 0; i < form.Controls.Count; i++)
            {
                if (InSide(form.Controls[i]) && form.Controls[i] != this)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
