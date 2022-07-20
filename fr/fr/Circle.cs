using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace fr
{
    class Circle
    {

        //public int XC, YC, Rad;
        public float XC, YC, Rad, fixedx, fixedy;
      
        public int inC = 45;
        public float StartTh ;
        public float EndTh ;
        public float la1, la2;
        public float x, y,x2, y2;
        public Circle outer;

        public void DrawYourSelf(Graphics g)
        {
            float x, y , xOuter=0 , yOuter=0;
            float thRadian, thRadianOuter;

            Circle obj = new Circle();

          //  float thOuter = outer.StartTh;
            int i=0;

            

       //  for (float th = StartTh; th < EndTh; th += inC, i++)
       //  {
       //      thRadian = (float)(th * Math.PI / 180);
       //      x = (float)(Rad * Math.Cos(thRadian) + XC);
       //      y = (float)(Rad * Math.Sin(thRadian) + YC);
       //      g.FillEllipse(Brushes.Black, x, y, 10, 10);
       //
       //      g.DrawLine(Pens.Green, x, y, xm, ym);
       //
       //  }




            //  if (i > 0)
            //      g.DrawLine(Pens.Green, x - 5, y - 5, xOuter - 5, yOuter - 5);
            //
            //  thRadianOuter = (float)(thOuter * Math.PI / 180);
            //  xOuter = (float)(outer.Rad * Math.Cos(thRadianOuter) + outer.XC);
            //  yOuter = (float)(outer.Rad * Math.Sin(thRadianOuter) + outer.YC);
            //  g.FillEllipse(Brushes.Black, xOuter - 5, yOuter - 5, 10, 10);
            //  thOuter += inC;
            //
            //  g.DrawLine(Pens.Green, x - 5, y - 5, xOuter - 5, yOuter - 5);
            
        }
    }
}
