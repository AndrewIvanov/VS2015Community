using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; 

namespace ec447AndrewIvanovLab8
{
    public partial class Form1 : Form
    {

        //private ShowDialog dlg = new ShowDialog();
        public static int t1 = 1;
        public static ListBox L1;

        public Form1()
        {
            InitializeComponent(); 
            ResizeRedraw = true;
            this.Text = "Lab 8 by Andrew Ivanov";
            this.StartPosition = FormStartPosition.CenterScreen;
            listBox1.SelectionMode = SelectionMode.MultiExtended;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawString("Interval", Font, Brushes.Black, 400, 235);

            //listBox1.SelectionMode = SelectionMode.MultiExtended;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void button1_Add_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|" + "All files (*.*)|*.*";
            this.openFileDialog1.Title = "Select image slides";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                foreach (string File in openFileDialog1.FileNames)
                {
                    listBox1.Items.Add(File);
                }
            }
        }

        private void button2_Delete_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.SelectedIndices.Count - 1; i >= 0; i--)
            {
                int idx = listBox1.SelectedIndices[i];
                listBox1.Items.RemoveAt(idx);
            }
        }


        private void button3_Show_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.Items.Count == 0)
                    MessageBox.Show("No images to show.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (listBox1.Items.Count > 0)
                {
                    L1 = listBox1;
                    t1 = Convert.ToInt32(textBox1.Text);
                    ShowDialog dlg = new ShowDialog();
                    //t1 = Convert.ToInt32(textBox1.Text);
                    dlg.ShowDialog();
                }
            }
            catch 
            {
                MessageBox.Show("Please enter an interger interval > 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Filter = "Data Files (*.pix*)|*.pix*"; 
            this.openFileDialog1.Title = "Load collections";

            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                listBox1.Items.Clear();

                List<string> lines = new List<string>();
                using (StreamReader r = new StreamReader(openFileDialog1.OpenFile()))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        listBox1.Items.Add(line);

                    }
                }
            }
        }

        private void saveCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SaveFileDialog save = new SaveFileDialog();
            this.saveFileDialog1.Filter = "Data Files (*.pix*)|*.pix*"; 
            this.saveFileDialog1.DefaultExt = "pix";
            this.saveFileDialog1.AddExtension = true;
            this.saveFileDialog1.Title = "Save collections";

            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveFileDialog1.OpenFile()); 
                for (int i = 0; i < listBox1.Items.Count; i++) {
                    writer.WriteLine(listBox1.Items[i].ToString());
                }
                writer.Dispose();
                writer.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        //if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
        //    {
        //        textBox1.Text = openFileDialog1.FileName;
        //    }


    }
}
