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


namespace project
{
    public partial class Form1 : Form
    {
        Timer t = new Timer();
        List<string> SelImg;
        List<string> AllImg;
        

        public Form1()
        {
            InitializeComponent();
            SelImg = new List<string>();
            AllImg = new List<string>();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            listBox1.SelectionMode = SelectionMode.MultiSimple;
          
            t.Stop();

        }
       
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
          
            
            
      }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "image(*.BMP;*.JPG;.GIF;*.PNG;*.TIFF)|*.BMP;*.JPG;.GIF;*.PNG;*.TIFF";
            op.Multiselect = true;
            DialogResult o = op.ShowDialog();
            if (o == DialogResult.OK)
            {
                for (int i = 0; i < op.FileNames.Length; i++)
                {
                    AllImg.Add(op.FileNames[i]);
                   
                    listBox1.Items.Add(Path.GetFileNameWithoutExtension(AllImg[i]));
                }
               
            }
        }

        private void singlePictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip1.Hide();
           
            pictureBox1.Show();
            t.Stop();
            SelImg.Clear();
            listBox1.SelectionMode = SelectionMode.One;
            SelImg.Add(AllImg[listBox1.SelectedIndex]);
           

            pictureBox1.ImageLocation = SelImg[0];
            

        }

         void slideShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            pictureBox1.Show();
            

            SelImg.Clear();
            statusStrip1.Show();

            listBox1.SelectionMode = SelectionMode.MultiSimple;
            foreach (int i in listBox1.SelectedIndices)
            {

                SelImg.Add(AllImg[i]);

            }
            
            t.Tick += T_Tick;
            t.Interval = 1500;
            t.Enabled = true;
            t.Start();

        }
        int c = 0;

          private void T_Tick(object sender, System.EventArgs e)
        {
            
            pictureBox1.ImageLocation = SelImg[c];
            toolStripStatusLabel1.Text = Path.GetFileNameWithoutExtension(SelImg[c]);
            c++;
            c = c % SelImg.Count;
        }

        private void multipictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip1.Hide();
            pictureBox1.Hide();
            panel1.Show();
            SelImg.Clear();
            
            listBox1.SelectionMode = SelectionMode.MultiSimple;
           
            foreach (int i in listBox1.SelectedIndices)
            {

                SelImg.Add(AllImg[i]);

            }
           
            int x = 0, y = 0;
            for (int i = 0; i < SelImg.Count; i++)
            {
                PictureBox p = new PictureBox()
                { SizeMode = PictureBoxSizeMode.Zoom };
                p.Location = new Point(x, y);
                p.Width = panel1.Width / 5;
                p.Height = panel1.Height / 5;
               
                    p.Image = new Bitmap(SelImg[i]);
                    panel1.Controls.Add(p);

                    if ((x + p.Width + 5) >= panel1.Width)
                    {
                        x = 0;
                        y += p.Height + 1;
                    }
                    else
                    {
                        x += p.Width;
                    }

                }
                }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
