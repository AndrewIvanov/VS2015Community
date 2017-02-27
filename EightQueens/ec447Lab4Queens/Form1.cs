using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Collections;

namespace ec447Lab4Queens
{
    public partial class Form1 : Form
    {
        private ArrayList coordinates = new ArrayList();
        //private ArrayList coordinates_x = new ArrayList();
        //private ArrayList coordinates_y = new ArrayList();
        private ArrayList red = new ArrayList();
        private ArrayList detecter = new ArrayList();

        private int[] board = new int[64];

        public Form1()
        {
            InitializeComponent();
            this.Text = "Eight Queens by Andrew Ivanov";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(600,600);
            ResizeRedraw = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.TranslateTransform(100, 100);
            Pen pen = new Pen(Brushes.Black, 2f);
            g.PageUnit = GraphicsUnit.Pixel;

            Font font1 = new Font("Arial", 30, FontStyle.Bold);

            int count1 = 0;
            for (int o = 0; o < 8; o++)
            {
                for (int i = 0; i < 8; i++)
                {

                    int sum = i + o;
                    g.DrawRectangle(pen, 0+50*i, 0+50*o, 50 , 50);
                    if (sum % 2 == 1) // odd squares [0-63]
                    {
                        g.FillRectangle(Brushes.Black, 0+50*i, 0+50*o, 50 , 50);
                    }
                    if (sum % 2 == 0) // even squares [0-63]
                    {
                        g.FillRectangle(Brushes.White, 0 + 50 * i, 0 + 50 * o, 50, 50);
                    }

                    if (red.Contains(count1))
                    {
                        g.FillRectangle(Brushes.Red, 0 + 50 * i, 0 + 50 * o, 50, 50);
                    }

                    count1++;
                }
            }

            ///////////////////////////////////////////////////////// DETECTER for safety

            detecter.Clear();
            foreach (Point p in this.coordinates)
            {
                int count = 0;
                for (int o = 0; o < 8; o++)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        if (p.X + p.Y * 8 == count)
                        {
                            detecter.Add(count);
                            for (int q = 1; q < 8; q++)  //vertical detection
                            {
                                detecter.Add(count + 8 * q);
                            }
                            for (int q = 1; q < 8; q++)
                            {
                                detecter.Add(count - 8 * q);
                            }

                            for (int q = 1; q < 8; q++)  //horizontal detection
                            {
                                detecter.Add(p.Y * 8 + ((count + q) % 8));
                            }

                            for (int q = count % 8; q < 8; q++)  // down & right diagonal detection
                            {
                                detecter.Add(count + 9 * (q - count % 8));
                            }

                            for (int q = count % 8; q >= 0; q--)  // up & left diagonal detection
                            {
                                detecter.Add(count + 9 * (q - count % 8));
                            }

                            for (int q = count % 8; q >= 0; q--)  //  down & left diagonal detection
                            {
                                detecter.Add(count + 7 * (count % 8 - q));
                            }

                            for (int q = count % 8; q < 8; q++)  // up & right diagonal detection
                            {
                                detecter.Add(count - 7 * (q - count % 8));
                            }
                        }

                        count++;
                    }
                }
            }

            //////////////////////////////////////////////////// Q generator & counter

            int count2 = 0;
            foreach (Point p in this.coordinates)
            {
                //if (p.X <= 400 && p.Y <= 400 && p.X >= 0 && p.Y >=  0)
                if (p.X < 8 && p.Y < 8 && p.X >= 0 && p.Y >=  0)
                {
                    count2++;
                    int D; // # cells down
                    int R; // # cells right
                    int sum;
                    D = p.X;
                    R = p.Y;
                    sum = D + R;
                    if (sum % 2 == 1)
                    {
                        if (red.Contains(p.X + 8 * p.Y))
                        {
                            g.DrawString("Q", font1, Brushes.Black, 50 * D, 50 * R);
                        }
                        else
                        {
                            g.DrawString("Q", font1, Brushes.White, 50 * D, 50 * R);
                        }
                    }
                    if (sum % 2 == 0)
                    {
                        g.DrawString("Q", font1, Brushes.Black, 50 * D, 50 * R);
                    }
                }
            }

            g.DrawString("You have " + count2 + " Queens on the board",Font, Brushes.Black, 100, -45);

            //if (count2 == 8)
            //{
            //    MessageBox.Show("You did it!");
            //}

        }


        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = (e.X - 100) / 50;
                int y = (e.Y - 100) / 50;

                Point p = new Point(x, y);
                //Point px = new Point(x, 0);
                //Point py = new Point(0, y);

                //if (coordinates.Contains(p) || coordinates_x.Contains(px) || coordinates_y.Contains(py))
                //{
                //    System.Media.SystemSounds.Beep.Play();
                //}
                if (detecter.Contains(p.X + 8 * p.Y))
                {
                    System.Media.SystemSounds.Beep.Play();
                }

                else if (p.X < 8 && p.Y < 8 && p.X >= 0 && p.Y >= 0 && e.X - 100 > 0 && e.Y - 100 > 0)
                {
                    this.coordinates.Add(p);
                    //this.coordinates_x.Add(px);
                    //this.coordinates_y.Add(py);
                }
                else
                {

                }

                checkBox1_CheckedChanged(sender,e);
                this.Invalidate();
                if (this.coordinates.Count == 8)
                {
                    MessageBox.Show("You did it!");
                }
               
            }
            if (e.Button == MouseButtons.Right)
            {
                Point p = new Point((e.X - 100) / 50, (e.Y - 100) / 50);
                //Point px = new Point((e.X - 100) / 50, 0);
                //Point py = new Point(0, (e.Y - 100) / 50);
                if (coordinates.Contains(p))
                {
                    this.coordinates.Remove(p);
                    //this.coordinates_x.Remove(px);
                    //this.coordinates_y.Remove(py);
                }
                checkBox1_CheckedChanged(sender, e);
                this.Invalidate();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.coordinates.Clear();
            //this.coordinates_x.Clear();
            //this.coordinates_y.Clear();
            this.red.Clear();
            this.detecter.Clear();
            this.Invalidate();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                red.Clear(); //////////////////////////////////////////////////// detector for red hint field 
                //System.Media.SystemSounds.Beep.Play();
                foreach (Point p in this.coordinates)
                {
                    int count = 0;
                    for (int o = 0; o < 8; o++)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            if (p.X + p.Y*8 == count)
                            {
                                red.Add(count);
                                for (int q = 1; q < 8; q++)  //vertical detection
                                {
                                    red.Add(count + 8 * q);
                                }
                                for (int q = 1; q < 8; q++)
                                {
                                    red.Add(count - 8 * q);
                                }

                                for (int q = 1; q < 8; q++)  //horizontal detection
                                {
                                    red.Add(p.Y * 8 + ((count + q) % 8));
                                }

                                for (int q = count%8; q < 8; q++)  // down & right diagonal detection
                                {
                                    red.Add(count + 9*(q-count%8));
                                }

                                for (int q = count % 8; q >= 0; q--)  // up & left diagonal detection
                                {
                                    red.Add(count + 9 * (q - count % 8));
                                }

                                for (int q = count % 8; q >= 0; q--)  //  down & left diagonal detection
                                {
                                    red.Add(count + 7 * (count % 8 - q));
                                }

                                for (int q = count % 8; q < 8; q++)  // up & right diagonal detection
                                {
                                    red.Add(count - 7 * (q - count % 8));
                                }
                            }
                            
                            count++;
                        }
                    }
                }
                this.Invalidate();
            }
            if (!checkBox1.Checked)
            {
                red.Clear();
                this.Invalidate();
            }
        }
        

    }
}
