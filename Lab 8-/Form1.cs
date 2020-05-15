using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace sof9
{
    public partial class Form1 : Form
    {
        public int qqq = 5;
        public int k = 0;
        Ball[] balls = new Ball[5];
        bool isPaint = false;
        bool isMouse = false;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            balls = new Ball[qqq];
            Random rnd = new Random();
            for (int i=0; i < qqq; i++)
            {
               balls[i] = new Ball(i, rnd.Next(1, panel1.ClientSize.Width), rnd.Next(1, panel1.ClientSize.Height), 
            rnd.Next(1, 50), rnd.Next(100, 255), rnd.Next(100, 255), rnd.Next(100, 255), rnd.Next(100, 255), rnd.Next(1, 50), rnd.Next(1, 60));
            }
           
            balls[0].MaxPoint = new PointF(panel1.ClientSize.Width, panel1.ClientSize.Height);
            timer1.Enabled = true;
            isPaint = true;
        }
        


        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Ball ball in balls)
            {
                 ball.Move();
                //Thread thread = new Thread(ball.Move);
                //  thread.Start();
            }
            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        { 
           
            if (!isPaint) return;
            
            foreach (Ball ball in balls)
            { 
                if (!ball.IsHide)
                   
                e.Graphics.FillEllipse(new SolidBrush(ball.Col), ball.Show().X, ball.Show().Y , ball.rad, ball.rad );
                
            }

        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled) timer1.Enabled = false;
            else if (isPaint) timer1.Enabled = true;
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            if (isPaint)
                balls[0].MaxPoint = new PointF(panel1.ClientSize.Width, panel1.ClientSize.Height);
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            qqq = Convert.ToInt32(textBox1.Text);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            groupBox1.Left = ClientSize.Width - groupBox1.Width - 10;
            label1.Left = ClientSize.Width - label1.Width - 30;
            textBox1.Left = ClientSize.Width - textBox1.Width - 35;
            button4.Left = ClientSize.Width - button4.Width - 60;
            label2.Left = ClientSize.Width - label1.Width - 30;
            textBox2.Left = ClientSize.Width - textBox1.Width - 35;
            button5.Left = ClientSize.Width - button4.Width - 60;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Width = Convert.ToInt32(textBox2.Text);
            panel1.Height = Convert.ToInt32(textBox2.Text);
        }
    }

}