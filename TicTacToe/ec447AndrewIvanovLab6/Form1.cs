using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ec447AndrewIvanovLab6
{
    public partial class Form1 : Form
    {
        // dimensions
        private const float clientsize = 100;
        private const float linelength = 80;
        public const float block = linelength / 3;
        private const float offset = 10;
        private const float delta = 5;
        public enum CellSelection { N, O, X };
        public CellSelection[,] grid = new CellSelection[3, 3];
        public float scale;

        public int gametype = new int();
        
        

        public Form1()
        {
            InitializeComponent();
            ResizeRedraw = true;
            this.Text = "Lab 6 by Andrew Ivanov";
            this.StartPosition = FormStartPosition.CenterScreen;
            //GameEngine GE = new GameEngine();
            //GE.grid = GE.algorithm(grid);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            ApplyTransform(g);

            g.DrawLine(Pens.Black, block, 0, block, linelength);
            g.DrawLine(Pens.Black, 2 * block, 0, 2 * block, linelength);
            g.DrawLine(Pens.Black, 0, block, linelength, block);
            g.DrawLine(Pens.Black, 0, 2 * block, linelength, 2 * block);

            GameEngine GE = new GameEngine();
            GE.WinDetector(grid);
            if (GE.status == 1)
            {
                for (int i = 0; i < 3; ++i)
                {
                    for (int j = 0; j < 3; ++j)
                    {
                        if (grid[i, j] == CellSelection.O)
                            DrawO(i, j, g);
                        if (grid[i, j] == CellSelection.X)
                            DrawX(i, j, g);
                    }
                }
                return;
            }
            grid = GE.algorithm(grid,gametype);
            //grid = GE.FirstTime(grid);
            GE.WinDetector(grid);

            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    if (grid[i, j] == CellSelection.O)
                        DrawO(i, j, g);
                    if (grid[i, j] == CellSelection.X)
                        DrawX(i, j, g);
                }
            }
            
        }

        private void ApplyTransform(Graphics g)
        {
            scale = Math.Min(ClientRectangle.Width / clientsize, ClientRectangle.Height / clientsize);
            if (scale == 0f) return;
            g.ScaleTransform(scale, scale);
            g.TranslateTransform(offset, offset);
        }

        private void DrawX(int i, int j, Graphics g)
        {
            g.DrawLine(Pens.Black, i * block + delta, j * block + delta, (i * block) + block - delta, (j * block) + block - delta);
            g.DrawLine(Pens.Black, (i * block) + block - delta, j * block + delta, (i * block) + delta, (j * block) + block - delta);
        }

        private void DrawO(int i, int j, Graphics g)
        {
            g.DrawEllipse(Pens.Black, i*block+delta, j*block+delta, block-2*delta, block-2*delta);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics g = CreateGraphics();
            ApplyTransform(g);
            PointF[] p = { new Point(e.X, e.Y) };
            g.TransformPoints(System.Drawing.Drawing2D.CoordinateSpace.World, System.Drawing.Drawing2D.CoordinateSpace.Device, p);

            GameEngine GE = new GameEngine();
            GE.WinDetector(grid);
            if (GE.status == 1) return;

            if (p[0].X < 0 || p[0].Y < 0) return;
            int i = (int)(p[0].X / block);
            int j = (int)(p[0].Y / block);
            if (i > 2 || j > 2) return;
            if (e.Button == MouseButtons.Middle)
            {
                //grid[i, j] = CellSelection.N;
            }
            if (grid[i, j] == CellSelection.O || grid[i, j] == CellSelection.X)
            {
                MessageBox.Show("Invalid move, try again!");
            }
            if (grid[i, j] == CellSelection.N)
            {
                //if (e.Button == MouseButtons.Right)
                //    grid[i, j] = CellSelection.O;
                if (e.Button == MouseButtons.Left)
                    grid[i, j] = CellSelection.X;
            }
            
            Invalidate();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    grid[i, j] = CellSelection.N;
                }
            }
            gametype = 0;
            this.Invalidate();
            
        }

        private void computerStartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    grid[i, j] = CellSelection.N;
                }
            }
            gametype = 1;
            this.Invalidate();
        }



        
    }
}
