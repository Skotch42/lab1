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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        const double g = 9.81, c = 0.15, rho = 1.29;

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Height_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
        }

        double height, angle, speed, dt, s, m, t, x, y, cosa, sina, beta, k, vx, vy, ymax = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            double VX = vx, VY = vy, root = Math.Sqrt(vx * vx + vy * vy);

            t += dt;

            vx = VX - k * VX * root * dt;
            vy = VY - (g + k * VY * root) * dt;

            x = x + vx * dt;
            y = y + vy * dt;

            if (y > ymax)
            {
                ymax = y;
            }

            chart1.Series[0].Points.AddXY(x, y);

            if (y < 0)
            {
                root = Math.Round(root, 2);
                label9.Text = root.ToString();

                ymax = Math.Round(ymax, 2);
                label10.Text = ymax.ToString();

                x = Math.Round(x, 2);
                label11.Text = x.ToString();
                timer1.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            height = (double)Height.Value;
            angle = (double)Angle.Value;
            speed = (double)Speed.Value;
            dt = (double)numericUpDown1.Value;
            s = (double)Size.Value;
            m = (double)Mass.Value;

            cosa = Math.Cos(angle * Math.PI / 180);
            sina = Math.Sin(angle * Math.PI / 180);
            beta = 0.5 * c * s * rho;
            k = beta / m;

            t = 0;
            x = 0;
            y = height;
            vx = speed * cosa;
            vy = speed * sina;

            chart1.Series[0].Points.AddXY(x, y);

            timer1.Start();
        }
    }
}
