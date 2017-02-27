using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.IO;

namespace ec447AndrewIvanovLab8
{
    public partial class ShowDialog : Form
    {
        private int ticks;
        private Font font;

        private Bitmap bm; 

        public ShowDialog()
        {
            InitializeComponent();
            ticks = 0;
            //timer1.Interval = 1000; 
            timer1.Interval = Form1.t1 * 1000;
            timer1.Enabled = true;
            font = new Font("Arial", 48);
        }

        public bool ImageTest(string filename)
        {
            try
            {
                using (var bmp = new Bitmap(filename))
                {
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //if (Form1.L1.Items[ticks].ToString().Substring(Form1.L1.Items[ticks].ToString().Length - 4, 4) == ".BMP" ||
            //    Form1.L1.Items[ticks].ToString().Substring(Form1.L1.Items[ticks].ToString().Length - 4, 4) == ".JPG" ||
            //    Form1.L1.Items[ticks].ToString().Substring(Form1.L1.Items[ticks].ToString().Length - 4, 4) == ".GIF" ||
            //    Form1.L1.Items[ticks].ToString().Substring(Form1.L1.Items[ticks].ToString().Length - 4, 4) == ".PNG" ||
            //    Form1.L1.Items[ticks].ToString().Substring(Form1.L1.Items[ticks].ToString().Length - 4, 4) == ".bmp" ||
            //    Form1.L1.Items[ticks].ToString().Substring(Form1.L1.Items[ticks].ToString().Length - 4, 4) == ".jpg" ||
            //    Form1.L1.Items[ticks].ToString().Substring(Form1.L1.Items[ticks].ToString().Length - 4, 4) == ".gif" ||
            //    Form1.L1.Items[ticks].ToString().Substring(Form1.L1.Items[ticks].ToString().Length - 4, 4) == ".png")

            //using (Image img = Image.FromFile(@Form1.L1.Items[ticks].ToString())) 
            //{
            //    if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp) ||
            //        img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg) ||
            //        img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Gif) ||
            //        img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))

            if (ImageTest(Form1.L1.Items[ticks].ToString()))
                {
                    bm = new Bitmap(@Form1.L1.Items[ticks].ToString());
                    SizeF cs = this.ClientSize;
                    float ratio = Math.Min(cs.Height / bm.Height, cs.Width / bm.Width);
                    //g.DrawImage(bm, 0, 0, bm.Width * ratio, bm.Height * ratio);
                    g.DrawImage(bm, (cs.Width - bm.Width * ratio) / 2, (cs.Height - bm.Height * ratio) / 2, bm.Width * ratio, bm.Height * ratio);
                }
                else
                {
                    g.DrawString("Not an image file.", font, Brushes.Black, 200, 200);
                }
            //}
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            ticks++;
            if (ticks == Form1.L1.Items.Count) // 3 for test
            {
                timer1.Enabled = false;
                DialogResult = DialogResult.OK;
            }
            else
                Invalidate();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
