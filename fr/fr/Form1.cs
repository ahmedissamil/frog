using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fr
{
    public partial class Form1 : Form
    {
        Circle O = new Circle();
        float R;
        Bitmap off;
        Bitmap f;
        float xl, yl;
        int r = 0;
        float x, y;
        int s2 = 0;
        int c = 0;
        Bitmap p;
        int s1 = 0;
        Timer ttiimmee = new Timer();
        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;
            this.MouseDown += Form1_MouseDown;
            ttiimmee.Tick += ttiimmee_Tick;
            ttiimmee.Start();
        }
        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }
        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            xl = e.X;
            yl = e.Y;
            float dx = Math.Abs(e.X - O.fixedx);
            float dy = Math.Abs(e.Y - O.fixedy);
            O.fixedx = 400;
            O.fixedy = 400;
            float xx1 = Math.Abs(e.X - O.fixedx);
            float yy1 = Math.Abs(e.Y - O.fixedy);
            float xy = Math.Abs((float)Math.Sqrt((xx1 * xx1) + (yy1 * yy1)));
            xy = xy / 2;
            float diff = Math.Abs(e.X - O.fixedx);
            diff = diff / 2;
            float diff2 = Math.Abs(e.Y - O.fixedy);
            diff2 = diff2 / 2;
            O.Rad = xy;
            if (e.Y < O.fixedy)
            {
                O.YC = O.fixedy - diff2;
            }
            if (e.Y > O.fixedy)
            {
                O.YC = O.fixedy + diff2;
            }


            if (e.X > O.fixedx)
            {
                O.XC = O.fixedx + diff;
            }
            if (e.X < O.fixedx)
            {
                O.XC = O.fixedx - diff;
            }

            O.StartTh = 0;
            O.EndTh = 360;
            c = 1;
            DrawDubb(this.CreateGraphics());
        }
        void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space)
            {
                r = 1;
            }

            DrawDubb(this.CreateGraphics());
        }
        void ttiimmee_Tick(object sender, EventArgs e)
        {


            if (r == 1)
            {
                float ths = (float)Math.Atan2(yl - O.YC, xl - O.XC);

                float the = (float)Math.Atan2(400 - O.YC, 400 - O.XC);

                if (ths < 0)
                {
                    for (float th = ths; th < the; th += 0.1f)
                    {
                        //  Radian = (float)(th * Math.PI / 180);
                        xl = (float)(O.Rad * Math.Cos(th) + O.XC);
                        yl = (float)(O.Rad * Math.Sin(th) + O.YC);

                        DrawDubb(this.CreateGraphics());
                    }
                    r= 0;
                    p= new Bitmap("frog1.bmp");
                    p.MakeTransparent(p.GetPixel(0, 0));

                    s1 = 1;
                    s2 = 1;

                }
                else
                {
                    if (ths > 0)
                    {
                        for (float th = ths; th > the; th -= 0.1f)
                        {
                            xl = (float)(O.Rad * Math.Cos(th) + O.XC);
                            yl = (float)(O.Rad * Math.Sin(th) + O.YC);

                            DrawDubb(this.CreateGraphics());
                        }
                        r= 0;
                        p = new Bitmap("frog1.bmp");
                        p.MakeTransparent(p.GetPixel(0, 0));
                        s1 = 1;
                        s2 = 1;

                    }
                }
            }
            DrawDubb(this.CreateGraphics());
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        void Form1_Load(object sender, EventArgs e)
        {
            p= new Bitmap("frog0.bmp");
            p.MakeTransparent(p.GetPixel(0, 0));

            f = new Bitmap("ball.bmp");
            f.MakeTransparent(f.GetPixel(0, 0));

            off = new Bitmap(ClientSize.Width, ClientSize.Height);
        }
        void DrawScene(Graphics g)
        {
            g.Clear(Color.White);

            if (c == 0)
            {
                g.DrawImage(p, 400 - p.Width, 400);

            }
            if (c == 1)
            {
                for (float th = O.StartTh; th < O.EndTh; th += 0.1f)
                {
                    R = (float)(th * Math.PI / 180);
                    x = (float)(O.Rad * Math.Cos(th) + O.XC);
                    y = (float)(O.Rad * Math.Sin(th) + O.YC);
                    g.FillEllipse(Brushes.BlueViolet, x, y, 1, 1);

                }
                g.FillEllipse(Brushes.Red, O.XC, O.YC, 10, 10);
                g.DrawImage(p, 400 - p.Width, 400);
                if (s2 == 0)
                {
                    g.DrawLine(Pens.Red, O.fixedx, O.fixedy, xl, yl);
                    g.DrawImage(f, xl, yl);
                    g.DrawImage(p, 400 - p.Width, 400);
                }
            }
        }

        
    }
}
