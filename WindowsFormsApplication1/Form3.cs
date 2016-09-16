using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public PictureBox[] SS = new PictureBox[54];

        private void LableLevelTwo_Click(object sender, EventArgs e)
        {
            FormLevelPath for2 = new FormLevelPath();
            this.Hide();
            for2.Show();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    SS[i * 6 + j] = new PictureBox();
                    SS[i * 6 + j].Location = new Point(100 * j, 100 * i);
                }
            }
            for (int i = 0; i < 54; i++)
            {
                SS[i].SendToBack();
                SS[i].Size = new System.Drawing.Size(100, 100);
                this.Controls.Add(SS[i]);
            }
            ch_color();
            word_color();
            turn();

            var n = new int();
            n = 30;
            Point P = new Point(52, 47);
            var paths = new System.Drawing.Drawing2D.GraphicsPath();
            for(int i=0;i<=5;i++)
            {
                paths.AddLine(Convert.ToSingle(P.X + n * Math.Cos(i * 60 * Math.PI / 180)), Convert.ToSingle(P.Y + n * Math.Sin(i * 60 * Math.PI / 180)), Convert.ToSingle(P.X + n * Math.Cos((i+1) * 60 * Math.PI / 180)), Convert.ToSingle(P.Y + n * Math.Sin((i+1) * 60 * Math.PI / 180)));
            }
            paths.CloseAllFigures();
            pictureBox1.Region = new Region(paths);

        }

        private void LableLevelOne_Click(object sender, EventArgs e)
        {
            FormLevelComplete lvOne = new FormLevelComplete();
            this.Hide();
            lvOne.Show();
        }

        private void LableLevelThree_Click(object sender, EventArgs e)
        {
            FormLevelCycle lvThree = new FormLevelCycle();
            this.Hide();
            lvThree.Show();
        }

        private void LableLevelFour_Click(object sender, EventArgs e)
        {
            FormLevelBipartite lvFour = new FormLevelBipartite();
            this.Hide();
            lvFour.Show();
        }

        private void LableLevelSix_Click(object sender, EventArgs e)
        {
            FormLevelHyCu4 lvFive = new FormLevelHyCu4();
            this.Hide();
            lvFive.Show();
        }

        private void LableLevelSeven_Click(object sender, EventArgs e)
        {
            FormLevelHyCu5 lvSeven = new FormLevelHyCu5();
            this.Hide();
            lvSeven.Show();
        }

        private void LableLevelEight_Click(object sender, EventArgs e)
        {
            FormLevelK5B2_3 lvEight = new FormLevelK5B2_3();
            this.Hide();
            lvEight.Show();
        }

        private void LableLevelNine_Click(object sender, EventArgs e)
        {
            FormLevelK4B4_5 lvNine = new FormLevelK4B4_5();
            this.Hide();
            lvNine.Show();
        }

        private void LableLevelTen_Click(object sender, EventArgs e)
        {
            FormLevelK3B7_8 lvTen = new FormLevelK3B7_8();
            this.Hide();
            lvTen.Show();
        }

        private void LableLevelFive_Click(object sender, EventArgs e)
        {
            FormLevelK4P4 lvFive = new FormLevelK4P4();
            this.Hide();
            lvFive.Show();
        }

        private void word_color()
        {
            LableBoxLevelOne.ForeColor = Color.Black;
            LableBoxLevelTwo.ForeColor = Color.Black;
            LableBoxLevelThree.ForeColor = Color.Black;
            LableBoxLevelFour.ForeColor = Color.Black;
            LableBoxLevelFive.ForeColor = Color.Black;
            LableBoxLevelSix.ForeColor = Color.Black;
            LableBoxLevelSeven.ForeColor = Color.Black;
            LableBoxLevelEight.ForeColor = Color.Black;
            LableBoxLevelNine.ForeColor = Color.Black;
            LableBoxLevelTen.ForeColor = Color.Black;
        }

        private void turn()
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, LableBoxLevelOne.Width, LableBoxLevelOne.Height);
            this.LableBoxLevelOne.Region = new Region(path);

            var path1 = new System.Drawing.Drawing2D.GraphicsPath();
            path1.AddEllipse(0, 0, LableBoxLevelTwo.Width, LableBoxLevelTwo.Height);
            this.LableBoxLevelTwo.Region = new Region(path1);

            var path2 = new System.Drawing.Drawing2D.GraphicsPath();
            path2.AddEllipse(0, 0, LableBoxLevelThree.Width, LableBoxLevelThree.Height);
            this.LableBoxLevelThree.Region = new Region(path2);

            var path3 = new System.Drawing.Drawing2D.GraphicsPath();
            path3.AddEllipse(0, 0, LableBoxLevelFour.Width, LableBoxLevelFour.Height);
            this.LableBoxLevelFour.Region = new Region(path3);

            var path4 = new System.Drawing.Drawing2D.GraphicsPath();
            path4.AddEllipse(0, 0, LableBoxLevelFive.Width, LableBoxLevelFive.Height);
            this.LableBoxLevelFive.Region = new Region(path4);

            var path5 = new System.Drawing.Drawing2D.GraphicsPath();
            path5.AddEllipse(0, 0, LableBoxLevelSix.Width, LableBoxLevelSix.Height);
            this.LableBoxLevelSix.Region = new Region(path5);

            var path6 = new System.Drawing.Drawing2D.GraphicsPath();
            path6.AddEllipse(0, 0, LableBoxLevelSeven.Width, LableBoxLevelSeven.Height);
            this.LableBoxLevelSeven.Region = new Region(path6);

            var path7 = new System.Drawing.Drawing2D.GraphicsPath();
            path7.AddEllipse(0, 0, LableBoxLevelEight.Width, LableBoxLevelEight.Height);
            this.LableBoxLevelEight.Region = new Region(path7);

            var path8 = new System.Drawing.Drawing2D.GraphicsPath();
            path8.AddEllipse(0, 0, LableBoxLevelNine.Width, LableBoxLevelNine.Height);
            this.LableBoxLevelNine.Region = new Region(path8);

            var path9 = new System.Drawing.Drawing2D.GraphicsPath();
            path9.AddEllipse(0, 0, LableBoxLevelTen.Width, LableBoxLevelTen.Height);
            this.LableBoxLevelTen.Region = new Region(path9);
        }

        private void ch_color()
        {
            SS[0].BackColor = Color.FromArgb(255, 255, 250, 129);
            SS[1].BackColor = Color.FromArgb(255, 255, 249, 100);
            SS[2].BackColor = Color.FromArgb(255, 255, 247, 0);
            SS[3].BackColor = Color.FromArgb(255, 255, 245, 0);
            SS[4].BackColor = Color.FromArgb(255, 208, 188, 0);
            SS[5].BackColor = Color.FromArgb(255, 171, 155, 6);

            SS[6].BackColor = Color.FromArgb(255, 255, 246, 100);
            SS[7].BackColor = Color.FromArgb(255, 255, 243, 70);
            SS[8].BackColor = Color.FromArgb(255, 255, 232, 0);
            SS[9].BackColor = Color.FromArgb(255, 255, 222, 0);
            SS[10].BackColor = Color.FromArgb(255, 231, 179, 0);
            SS[11].BackColor = Color.FromArgb(255, 168, 147, 8);

            SS[12].BackColor = Color.FromArgb(255, 255, 239, 97);
            SS[13].BackColor = Color.FromArgb(255, 255, 236, 80);
            SS[14].BackColor = Color.FromArgb(255, 255, 231, 71);
            SS[15].BackColor = Color.FromArgb(255, 255, 217, 0);
            SS[16].BackColor = Color.FromArgb(255, 212, 169, 0);
            SS[17].BackColor = Color.FromArgb(255, 177, 140, 4);

            SS[18].BackColor = Color.FromArgb(255, 255, 235, 121);
            SS[19].BackColor = Color.FromArgb(255, 255, 229, 100);
            SS[20].BackColor = Color.FromArgb(255, 255, 214, 70);
            SS[21].BackColor = Color.FromArgb(255, 253, 199, 43);
            SS[22].BackColor = Color.FromArgb(255, 251, 185, 0);
            SS[23].BackColor = Color.FromArgb(255, 190, 144, 10);

            SS[24].BackColor = Color.FromArgb(255, 255, 240, 172);
            SS[25].BackColor = Color.FromArgb(255, 255, 231, 144);
            SS[26].BackColor = Color.FromArgb(255, 254, 208, 98);
            SS[27].BackColor = Color.FromArgb(255, 255, 178, 17);
            SS[28].BackColor = Color.FromArgb(255, 204, 146, 11);
            SS[29].BackColor = Color.FromArgb(255, 164, 128, 27);

            SS[30].BackColor = Color.FromArgb(255, 255, 238, 128);
            SS[31].BackColor = Color.FromArgb(255, 255, 231, 103);
            SS[32].BackColor = Color.FromArgb(255, 255, 221, 96);
            SS[33].BackColor = Color.FromArgb(255, 255, 178, 0);
            SS[34].BackColor = Color.FromArgb(255, 227, 155, 0);
            SS[35].BackColor = Color.FromArgb(255, 161, 117, 15);

            SS[36].BackColor = Color.FromArgb(255, 255, 222, 126);
            SS[37].BackColor = Color.FromArgb(255, 254, 198, 116);
            SS[38].BackColor = Color.FromArgb(255, 251, 172, 77);
            SS[39].BackColor = Color.FromArgb(255, 248, 144, 23);
            SS[40].BackColor = Color.FromArgb(255, 229, 114, 0);
            SS[41].BackColor = Color.FromArgb(255, 146, 87, 18);

            SS[42].BackColor = Color.FromArgb(255, 254, 209, 110);
            SS[43].BackColor = Color.FromArgb(255, 253, 190, 76);
            SS[44].BackColor = Color.FromArgb(255, 250, 174, 51);
            SS[45].BackColor = Color.FromArgb(255, 246, 128, 0);
            SS[46].BackColor = Color.FromArgb(255, 226, 109, 0);
            SS[47].BackColor = Color.FromArgb(255, 154, 84, 17);

            SS[48].BackColor = Color.FromArgb(255, 250, 171, 114);
            SS[49].BackColor = Color.FromArgb(255, 248, 146, 83);
            SS[50].BackColor = Color.FromArgb(255, 246, 130, 59);
            SS[51].BackColor = Color.FromArgb(255, 242, 91, 0);
            SS[52].BackColor = Color.FromArgb(255, 221, 70, 6);
            SS[53].BackColor = Color.FromArgb(255, 138, 50, 16);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 for1 = new Form1();
            this.Hide();
            for1.Show();
        }
    }
}
