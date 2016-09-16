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
    public partial class FormLevelHyCu5 : Form       //hyperCube degree 5
    {
        public FormLevelHyCu5()
        {
            InitializeComponent();

        }
        struct vector2D
        {
            int x, y;
        };
        public const int chX = 500;
        public const int chY = 600;
        public const int pointnum = 32;
        public int soldier = 10;
        //public Point[] S = new Point[10];
        public const double offsetX = 250;               //x座標修正
        public const double offsetY = 450;               //y座標修正
        public const double directX = 1;                 //x座標方向修正
        public const double directY = -1;                //y座標方向修正
        public const double winW = 0;                    //預計視窗寬
        public const double winH = 800;                  //預計視窗高
        public const double pSizeW = 40;
        public const double pSizeH = 40;

        public static readonly double[] point1 = new double[2] { -105.0, 105.0 };
        public static readonly double[] point2 = new double[2] { 105.0, 105.0 };
        public static readonly double[] point3 = new double[2] { -35.0, 35.0 };
        public static readonly double[] point4 = new double[2] { 35.0, 35.0 };
        public static readonly double[] point5 = new double[2] { -35.0, -35.0 };
        public static readonly double[] point6 = new double[2] { 35.0, -35.0 };
        public static readonly double[] point7 = new double[2] { -105.0, -105.0 };
        public static readonly double[] point8 = new double[2] { 105.0, -105.0 };

        public const int hubeOffsetX1 = -160, hubeOffsetY1 = 130;
        public const int hubeOffsetX2 = 130, hubeOffsetY2 = 110;
        public const int hubeOffsetX3 = -120, hubeOffsetY3 = -130;
        public const int hubeOffsetX4 = 170, hubeOffsetY4 = -150;

        public double[,] coor =
        {
                { winW +( point1[0] + offsetX + hubeOffsetX1 ) * directX , winH + ( point1[1] + offsetY + hubeOffsetY1  ) * directY},
                { winW +( point2[0] + offsetX + hubeOffsetX1 ) * directX , winH + ( point2[1] + offsetY + hubeOffsetY1  ) * directY },
                { winW +( point3[0] + offsetX + hubeOffsetX1 ) * directX , winH + ( point3[1] + offsetY + hubeOffsetY1  ) * directY },
                { winW +( point4[0] + offsetX + hubeOffsetX1 ) * directX , winH + ( point4[1] + offsetY + hubeOffsetY1  ) * directY },
                { winW +( point5[0] + offsetX + hubeOffsetX1 ) * directX , winH + ( point5[1] + offsetY + hubeOffsetY1  ) * directY },
                { winW +( point6[0] + offsetX + hubeOffsetX1 ) * directX , winH + ( point6[1] + offsetY + hubeOffsetY1  ) * directY },
                { winW +( point7[0] + offsetX + hubeOffsetX1 ) * directX , winH + ( point7[1] + offsetY + hubeOffsetY1  ) * directY },
                { winW +( point8[0] + offsetX + hubeOffsetX1 ) * directX , winH + ( point8[1] + offsetY + hubeOffsetY1  ) * directY },

                { winW +( point1[0] + offsetX + hubeOffsetX2 ) * directX , winH + ( point1[1] + offsetY + hubeOffsetY2  ) * directY },
                { winW +( point2[0] + offsetX + hubeOffsetX2 ) * directX , winH + ( point2[1] + offsetY + hubeOffsetY2  ) * directY  },
                { winW +( point3[0] + offsetX + hubeOffsetX2 ) * directX , winH + ( point3[1] + offsetY + hubeOffsetY2  ) * directY  },
                { winW +( point4[0] + offsetX + hubeOffsetX2 ) * directX , winH + ( point4[1] + offsetY + hubeOffsetY2  ) * directY  },
                { winW +( point5[0] + offsetX + hubeOffsetX2 ) * directX , winH + ( point5[1] + offsetY + hubeOffsetY2  ) * directY  },
                { winW +( point6[0] + offsetX + hubeOffsetX2 ) * directX , winH + ( point6[1] + offsetY + hubeOffsetY2  ) * directY  },
                { winW +( point7[0] + offsetX + hubeOffsetX2 ) * directX , winH + ( point7[1] + offsetY + hubeOffsetY2  ) * directY  },
                { winW +( point8[0] + offsetX + hubeOffsetX2 ) * directX , winH + ( point8[1] + offsetY + hubeOffsetY2  ) * directY  },

                { winW +( point1[0] + offsetX + hubeOffsetX3 ) * directX , winH + ( point1[1] + offsetY + hubeOffsetY3  ) * directY },
                { winW +( point2[0] + offsetX + hubeOffsetX3 ) * directX , winH + ( point2[1] + offsetY + hubeOffsetY3  ) * directY  },
                { winW +( point3[0] + offsetX + hubeOffsetX3 ) * directX , winH + ( point3[1] + offsetY + hubeOffsetY3  ) * directY  },
                { winW +( point4[0] + offsetX + hubeOffsetX3 ) * directX , winH + ( point4[1] + offsetY + hubeOffsetY3  ) * directY  },
                { winW +( point5[0] + offsetX + hubeOffsetX3 ) * directX , winH + ( point5[1] + offsetY + hubeOffsetY3  ) * directY  },
                { winW +( point6[0] + offsetX + hubeOffsetX3 ) * directX , winH + ( point6[1] + offsetY + hubeOffsetY3  ) * directY  },
                { winW +( point7[0] + offsetX + hubeOffsetX3 ) * directX , winH + ( point7[1] + offsetY + hubeOffsetY3  ) * directY  },
                { winW +( point8[0] + offsetX + hubeOffsetX3 ) * directX , winH + ( point8[1] + offsetY + hubeOffsetY3  ) * directY  },

                { winW +( point1[0] + offsetX + hubeOffsetX4 ) * directX , winH + ( point1[1] + offsetY + hubeOffsetY4  ) * directY },
                { winW +( point2[0] + offsetX + hubeOffsetX4 ) * directX , winH + ( point2[1] + offsetY + hubeOffsetY4  ) * directY  },
                { winW +( point3[0] + offsetX + hubeOffsetX4 ) * directX , winH + ( point3[1] + offsetY + hubeOffsetY4  ) * directY  },
                { winW +( point4[0] + offsetX + hubeOffsetX4 ) * directX , winH + ( point4[1] + offsetY + hubeOffsetY4  ) * directY  },
                { winW +( point5[0] + offsetX + hubeOffsetX4 ) * directX , winH + ( point5[1] + offsetY + hubeOffsetY4  ) * directY  },
                { winW +( point6[0] + offsetX + hubeOffsetX4 ) * directX , winH + ( point6[1] + offsetY + hubeOffsetY4  ) * directY  },
                { winW +( point7[0] + offsetX + hubeOffsetX4 ) * directX , winH + ( point7[1] + offsetY + hubeOffsetY4  ) * directY  },
                { winW +( point8[0] + offsetX + hubeOffsetX4 ) * directX , winH + ( point8[1] + offsetY + hubeOffsetY4  ) * directY  }
            };

        /*public double[,] coor =
        {
            { winW +( -235 + offsetX ) * directX , winH + ( 230+ offsetY ) * directY },
            { winW + (  -25 + offsetX ) * directX , winH + ( 230 + offsetY ) * directY },
            { winW + ( -165 + offsetX ) * directX , winH + ( 160 + offsetY ) * directY },
            { winW + (  -95 + offsetX ) * directX ,winH +  ( 160 + offsetY ) * directY },
            { winW + ( -165 + offsetX ) * directX , winH + ( 90 + offsetY ) * directY },
            { winW + ( -95 + offsetX ) * directX , winH + ( 90 + offsetY ) * directY },
            { winW + (  -235 + offsetX ) * directX , winH + ( 20 + offsetY ) * directY },
            { winW + (  -95 + offsetX ) * directX , winH + ( 20 + offsetY ) * directY },

            { winW +( 35 + offsetX ) * directX , winH + ( 140+ offsetY ) * directY },
            { winW + (  245 + offsetX ) * directX , winH + ( 140 + offsetY ) * directY },
            { winW + ( 105 + offsetX ) * directX , winH + ( 70 + offsetY ) * directY },
            { winW + (  175 + offsetX ) * directX ,winH +  ( 70 + offsetY ) * directY },
            { winW + ( 105 + offsetX ) * directX , winH + ( 0 + offsetY ) * directY },
            { winW + ( 175 + offsetX ) * directX , winH + ( 0 + offsetY ) * directY },
            { winW + (  35 + offsetX ) * directX , winH + ( -70 + offsetY ) * directY },
            { winW + (  245 + offsetX ) * directX , winH + ( -70 + offsetY ) * directY },
            ////////////////////////
            { winW +( -225 + offsetX ) * directX , winH + ( -80+ offsetY ) * directY },
            { winW + (  -15 + offsetX ) * directX , winH + ( -80 + offsetY ) * directY },
            { winW + ( -155 + offsetX ) * directX , winH + ( -150 + offsetY ) * directY },
            { winW + (  -85 + offsetX ) * directX ,winH +  ( -150 + offsetY ) * directY },
            { winW + ( -155 + offsetX ) * directX , winH + (  -220+ offsetY ) * directY },
            { winW + ( -85 + offsetX ) * directX , winH + ( -220 + offsetY ) * directY },
            { winW + (  -225 + offsetX ) * directX , winH + ( -290 + offsetY ) * directY },
            { winW + (  -15 + offsetX ) * directX , winH + ( -290 + offsetY ) * directY },

            { winW +( 35 + offsetX ) * directX , winH + ( 10+ offsetY ) * directY },
            { winW + (  245 + offsetX ) * directX , winH + ( 10 + offsetY ) * directY },
            { winW + ( 105 + offsetX ) * directX , winH + ( -60 + offsetY ) * directY },
            { winW + (  175 + offsetX ) * directX ,winH +  ( -60 + offsetY ) * directY },
            { winW + ( 105 + offsetX ) * directX , winH + ( -130 + offsetY ) * directY },
            { winW + ( 175 + offsetX ) * directX , winH + ( -130 + offsetY ) * directY },
            { winW + (  35 + offsetX ) * directX , winH + ( -200 + offsetY ) * directY },
            { winW + (  245 + offsetX ) * directX , winH + ( -200 + offsetY ) * directY }
        };*/
        public int[,] adjMatrix =
        {
                {0,1,1,0,0,0,1,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                {1,0,0,1,0,0,0,1,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                {1,0,0,1,1,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                {0,1,1,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0 },
                {0,0,1,0,0,1,1,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0 },
                {0,0,0,1,1,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0 },
                {1,0,0,0,1,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0 },
                {0,1,0,0,0,1,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0 },

                {1,0,0,0,0,0,0,0,0,1,1,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0},
                {0,1,0,0,0,0,0,0,1,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0},
                {0,0,1,0,0,0,0,0,1,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0},
                {0,0,0,1,0,0,0,0,0,1,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0},
                {0,0,0,0,1,0,0,0,0,0,1,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0},
                {0,0,0,0,0,1,0,0,0,0,0,1,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0},
                {0,0,0,0,0,0,1,0,1,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0},
                {0,0,0,0,0,0,0,1,0,1,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},

                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,  0,1,1,0,0,0,1,0,1,0,0,0,0,0,0,0 },
                {0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,  1,0,0,1,0,0,0,1,0,1,0,0,0,0,0,0 },
                {0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,  1,0,0,1,1,0,0,0,0,0,1,0,0,0,0,0 },
                {0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,  0,1,1,0,0,1,0,0,0,0,0,1,0,0,0,0 },
                {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,  0,0,1,0,0,1,1,0,0,0,0,0,1,0,0,0 },
                {0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,  0,0,0,1,1,0,0,1,0,0,0,0,0,1,0,0 },
                {0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,  1,0,0,0,1,0,0,1,0,0,0,0,0,0,1,0 },
                {0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,  0,1,0,0,0,1,1,0,0,0,0,0,0,0,0,1 },

                {0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,  1,0,0,0,0,0,0,0, 0,1,1,0,0,0,1,0},
                {0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,  0,1,0,0,0,0,0,0,1,0,0,1,0,0,0,1 },
                {0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,  0,0,1,0,0,0,0,0,1,0,0,1,1,0,0,0 },
                {0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,  0,0,0,1,0,0,0,0,0,1,1,0,0,1,0,0 },
                {0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,  0,0,0,0,1,0,0,0,0,0,1,0,0,1,1,0 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,  0,0,0,0,0,1,0,0,0,0,0,1,1,0,0,1 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,  0,0,0,0,0,0,1,0,1,0,0,0,1,0,0,1 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,  0,0,0,0,0,0,0,1,0,1,0,0,0,1,1,0 }
            };
        public PictureBox[] SS = new PictureBox[pointnum];
        public bool UserClosing { get; set; }
        public Label label1 = new Label();
        Bitmap _white = Properties.Resources.white;
        Bitmap _black = Properties.Resources.black;
        Bitmap _red = Properties.Resources.red;
        Bitmap _white_touch = Properties.Resources.white_touch;
        Bitmap _black_touch = Properties.Resources.black_touch;
        Bitmap _red_touch = Properties.Resources.red_touch;

        private void FormLevelHyCu5_Load(object sender, EventArgs e)
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
            //pictureBox1.Image = _white;
            //pictureBox1.Tag = 1;
            Panel PP = new Panel();
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


            /*for (int i = 0; i < pointnum; i++)
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
            }*/

            //for(int i=0;i<5;i++)
            //    this.Controls.Add(SS[i]);
            //SS[2] = new PictureBox();
            //SS[2].Location = new Point(300, 300);

            for (int i = 0; i < pointnum; i++)
            {
                SS[i] = new PictureBox();
                SS[i].BackColor = Color.Transparent;
                SS[i].Location = new Point((int)coor[i, 0], (int)coor[i, 1]);
                SS[i].Size = new System.Drawing.Size((int)pSizeW, (int)pSizeH);
                SS[i].SizeMode = PictureBoxSizeMode.StretchImage;
                SS[i].Image = Properties.Resources.white;//new Bitmap("white.png");
                SS[i].MouseClick += picturebox_click;
                SS[i].MouseEnter += new System.EventHandler(this.picturebox_enter);
                SS[i].MouseLeave += picturebox_leave;
                SS[i].Tag = 1;//1 white; 2 black; 3 red;
                SS[i].Name = i.ToString();//the picturebox number
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
            switch (e.Button)
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

        private void paint(object sender, PaintEventArgs e) //complete graph畫線
        {
            base.OnPaint(e);
            using (Graphics g = e.Graphics)
            {
                var p = new Pen(Color.White, 1);
                /* var point1 = new Point(234, 118);
                 var point2 = new Point(293, 228);
                 g.DrawLine(p, point1, point2);*/
                for (int i = 0; i < pointnum; i++)
                {
                    for (int j = i; j < pointnum; j++)
                    {
                        if (adjMatrix[i, j] == 1)
                            g.DrawLine(p, new Point((int)(coor[i, 0] + pSizeW / 2), (int)(coor[i, 1] + pSizeH / 2)), new Point((int)(coor[j, 0] + pSizeW / 2), (int)(coor[j, 1] + pSizeH / 2)));
                    }
                }
            }
        }

        private void ch_Click(object sender, EventArgs e)
        {
            Process P = new Process();
            P.StartInfo.FileName = "./Project.exe";
            string argvv = "7 7 ";
            //argvv += pointnum.ToString() + " ";
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
            else if (result == 1)
                MessageBox.Show("你有某個城市被攻下了，請在試一次");
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


        private void picturebox_enter(object sender, EventArgs e)
        {
            PictureBox P = (PictureBox)sender;
            int imageindex = (int)P.Tag;
            int name = int.Parse(P.Name);
            for (int i = 0; i < pointnum; i++)
            {
                if (adjMatrix[name, i] == 1)
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

        private void picturebox_leave(object sender, EventArgs e)
        {
            PictureBox P = (PictureBox)sender;
            int name = int.Parse(P.Name);
            int imageindex = (int)P.Tag;
            for (int i = 0; i < pointnum; i++)
            {
                if (adjMatrix[name, i] == 1)
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
    }
}
