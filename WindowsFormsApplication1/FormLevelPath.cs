using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class FormLevelPath : Form
    {
        public FormLevelPath()
        {
            InitializeComponent();
            G = this.CreateGraphics();
        }
        Graphics G;
        public int pointnum = 5;
        public int soldier = 3;
        public Point[] S = new Point[5];
        public PictureBox[] SS = new PictureBox[5];
        public bool UserClosing { get; set; }
        public Label label1 = new Label();
        public Panel PP = new Panel();
        Bitmap _white = Properties.Resources.white;
        Bitmap _black = Properties.Resources.black;
        Bitmap _red = Properties.Resources.red;
        Bitmap _white_touch = Properties.Resources.white_touch;
        Bitmap _black_touch = Properties.Resources.black_touch;
        Bitmap _red_touch = Properties.Resources.red_touch;

        private void Form2_Load(object sender, EventArgs e)
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
            //pictureBox1.Image = _white;
            //pictureBox1.Tag = 1;
            //Panel PP = new Panel();
            PP.Enabled = true;
            PP.BackColor = Color.Transparent;
            PP.Location = new Point(0, 0);
            PP.Size = new System.Drawing.Size(570, 865);    
            this.Controls.Add(PP);
            PP.Paint += paint;

            //button
            Button ch = new Button();
            ch.Text = "check!";
            ch.Location = new Point(500, 800);
            PP.Controls.Add(ch);
            ch.Click += ch_Click;

            for (int i = 0; i < 5; i++)
            {
                if (i % 2 == 0)
                    S[i].X = 70;
                else
                    S[i].X = 585 - 70 - 80;
            }
            if (pointnum % 2 == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    S[i].Y = ((this.Height - (pointnum - 1) * 50) / 2 - 100) + 100 * i;
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    S[i].Y = (904 / 2 - (pointnum) / 2 * 100) + i * 100;
                }
            }

            //for(int i=0;i<5;i++)
            //    this.Controls.Add(SS[i]);
            //SS[2] = new PictureBox();
            //SS[2].Location = new Point(300, 300);

            for (int i = 0; i < 5; i++)
            {
                SS[i] = new PictureBox();
                SS[i].BackColor = Color./*White;*/Transparent;
                SS[i].Location = new Point(S[i].X, S[i].Y);
                SS[i].Size = new System.Drawing.Size(80, 80);
                SS[i].SizeMode = PictureBoxSizeMode.StretchImage;
                SS[i].Image = /*null;*/Properties.Resources.white;//new Bitmap("white.png");
                SS[i].MouseClick += picturebox_click;
                SS[i].MouseEnter += new System.EventHandler(this.picturebox_enter);
                SS[i].MouseLeave += picturebox_leave;
                SS[i].Tag = 1;//1 white; 2 black; 3 red;
                //4 white_touch; 5 black_touch; 6 red_touch;
                SS[i].Name = i.ToString();
                //new add
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddEllipse(0, 0, SS[i].Width, SS[i].Height);
                this.SS[i].Region = new Region(path);
                //new add end
                //this.Controls.Add(SS[i]);
                PP.Controls.Add(SS[i]);
            }

            
            label1.Location = new Point(166, 27);
            label1.Text = "剩餘士兵數量:" + soldier.ToString();
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
            label1.Font = new Font(label1.Font.Name, 20, label1.Font.Style, label1.Font.Unit);
            label1.Size = new System.Drawing.Size(300, 100);
            PP.Controls.Add(label1);
        }

        private void picturebox_click(object sender, MouseEventArgs e)
        {
            PictureBox P = (PictureBox)sender;
            int imageindex = (int)P.Tag;
            switch(e.Button)
            {
                case MouseButtons.Left:
                    if (imageindex == 1)
                    {
                        P.Tag = 2;
                        P.Image = _black;
                        soldier--;
                    }
                    else if (imageindex == 2)
                    {
                        P.Tag = 3;
                        P.Image = _red;
                        soldier--;
                    }
                    else
                    {
                    }
                    break;
                case MouseButtons.Right:
                    if (imageindex == 1)
                    {
                    }
                    else if (imageindex == 2)
                    {
                        P.Tag = 1;
                        P.Image = _white;
                        soldier++;
                    }
                    else
                    {
                        P.Tag = 2;
                        P.Image = _black;
                        soldier++;
                    }
                    break;
            }
            label1.Text = "剩餘士兵數量:" + soldier.ToString();
        }

        private void picturebox_enter(object sender, System.EventArgs e)
        {
            PictureBox P = (PictureBox)sender;
            int imageindex = (int)P.Tag;
            int name = int.Parse(P.Name);
            for (int i = 0; i < pointnum; i++)
            {
                if (i == name - 1 || i == name + 1)
                {
                    if ((int)SS[i].Tag <= 3)
                    {
                        SS[i].Tag = (int)SS[i].Tag + 3;
                        if ((int)SS[i].Tag == 4)
                            SS[i].Image = _white_touch;
                        else if ((int)SS[i].Tag == 5)
                            SS[i].Image = _black_touch;
                        else
                            SS[i].Image = _red_touch;
                    }
                }
            }
        }

        private void picturebox_leave(object sender, System.EventArgs e)
        {
            PictureBox P = (PictureBox)sender;
            int name = int.Parse(P.Name);
            int imageindex = (int)P.Tag;
            for (int i = 0; i < pointnum; i++)
            {
                if (i == name - 1 || i == name + 1)
                {
                    if ((int)SS[i].Tag >= 4)
                    {
                        SS[i].Tag = (int)SS[i].Tag - 3;
                        if ((int)SS[i].Tag == 1)
                            SS[i].Image = _white;
                        else if ((int)SS[i].Tag == 2)
                            SS[i].Image = _black;
                        else
                            SS[i].Image = _red;
                    }
                }
            }
        }

        private void paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Graphics g = e.Graphics)
            {
                var p = new Pen(Color.White, 1);
               /* var point1 = new Point(234, 118);
                var point2 = new Point(293, 228);
                g.DrawLine(p, point1, point2);*/
                for(int i=0;i<5-1;i++)
                {
                    g.DrawLine(p, new Point(S[i].X + 40, S[i].Y + 40), new Point(S[i + 1].X + 40, S[i + 1].Y + 40));
                }
            }
        }

        /*private void animation(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Graphics g = e.Graphics)
            {
                var p = new Pen(Color.Black, 1);
                g.DrawLine(p, new Point(S[0].X + 40, S[0].Y + 40), new Point(S[0 + 1].X + 40, S[0 + 1].Y + 40));
            }
        }*/

        private void ch_Click(object sender, EventArgs e)
        {
            //PP.Paint += animation;
            /*G = Graphics.
            var p = new Pen(Color.Black, 1);
            G.DrawLine(p, new Point(S[0].X + 40, S[0].Y + 40), new Point(S[0 + 1].X + 40, S[0 + 1].Y + 40));
            */Process P = new Process();
            P.StartInfo.FileName = "./Project.exe";
            //設定傳入值
            string argvv = "1 ";
            argvv += pointnum.ToString() + " ";
            for (int i = 0; i < pointnum; i++)
            {
                int imageindex = (int)SS[i].Tag;
                if (imageindex != 1)
                {
                    argvv += i.ToString();
                    argvv += " ";
                    argvv += (imageindex - 1).ToString();
                    argvv += " ";
                    //MessageBox.Show(argvv);
                }
            }
            //設定傳入值結束
            P.StartInfo.Arguments = argvv;
            P.StartInfo.UseShellExecute = false;
            P.StartInfo.RedirectStandardInput = true;
            P.StartInfo.RedirectStandardOutput = true;
            P.StartInfo.RedirectStandardError = true;
            P.StartInfo.CreateNoWindow = true;
            P.Start();
            

            P.WaitForExit();
            int result = P.ExitCode;
            if (result == 0)
            {
                MessageBox.Show("恭喜你通過了!!!");
                Form3 for3 = new Form3();
                this.Hide();
                for3.Show();
            }
            else if(result == 1)
                MessageBox.Show("你有某個城市被攻下了，請再試一次");//改!!!!!!!!!!!!!!!!!!!!!
            else
                MessageBox.Show("發生未知的錯誤，請回報開發者");
            P.Close();
            //P.Kill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 for3 = new Form3();
            this.Hide();
            for3.Show();
        }
    }
}
