using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace sof9
{
    public class Ball:Figure
    {
        private float x;
        private float y;
        private float r;
        private int id;
        private int color_1;
        private int color_2;
        private int color_3;
        private int color_4;
        private float way;
        private float speed;
        static PointF maxPoint;
        private bool ishide = false;

        public Ball()
        {
            x = 0;
            y = 0;
            r = 0;
            id = 0;
            color_1 = 0;
            color_2 = 0;
            color_3 = 0;
            color_4 = 0;
            way = 0;
            speed = 0;
        
        }

        public PointF MaxPoint
        {
            get
            {
                return maxPoint;
            }
            set
            {
                maxPoint = value;
            }
        }
        public Ball(int id, float x, float y, float r, int color_1,int color_2, int color_3,int color_4, float way, float speed)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            this.r = r;
            this.color_1 = color_1;
            this.color_2 = color_2;
            this.color_3 = color_3;
            this.color_4 = color_4;
            this.way = way;
            this.speed = speed;
          
            
        }

        

        public PointF Locate
        {
            get
            {
                return new PointF(x, y);
            }
            set
            {
                x = value.X;
                y = value.Y;
            }
        }



        private void Crash()
        {
            if (x + r > maxPoint.X)
            {
                x = x - (x + r - maxPoint.X) * 2;
                way = (float)Math.PI - way;
                Ways();
            }
            if (y + r >= maxPoint.Y)
            {
                y = y - (y + r - maxPoint.Y) * 2;
                way = (float)Math.PI * 2 - way;
                Ways();
            }
            if (x < 0)
            {
                x = -x;
                way = (float)Math.PI - way;
                Ways();
            }
            if (y < 0)
            {
                y = -y;
                way = (float)Math.PI * 2 - way;
                Ways();
            }
        }

        private void Ways()
        {
            if (way >= (float)Math.PI * 2) 
                way = way - (float)Math.PI * 2;
            if (way <= 0) 
                way = way + (float)Math.PI * 2;
        }

        public void Move()
        {
            x += (float)Math.Cos(way) * speed;
            y += (float)Math.Sin(way) * speed;
            Crash();
        }

        public PointF Show()
        {
            return new PointF(x, y);
        }

        public void Hide()
        {
            if (ishide)
            {
                ishide = false;
            }
            else ishide = true;
        }

        public bool IsHide
        {
            get { return ishide; }
        }

        public int Id
        {
            get { return id; }
        }
        public Color Col
        {
            //Color c = Color.FromArgb(255, 255, 255, 255);
            get { return Color.FromArgb(color_1, color_2, color_3, color_4); }
        }
        public float rad
        {
            get { return r; }
        }
    }
}
