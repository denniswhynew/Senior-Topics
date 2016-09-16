using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using System.Drawing.Drawing2D;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Form1 F1 = new Form1();
            //F1.BackColor = Color.Black;
            see();
        }
        public void see()
        {
            //axShockwaveFlash1.Movie = @"C:\Users\dennis\Desktop\WindowsFormsApplication1\background\test.swf";
            axShockwaveFlash1.Movie = Application.StartupPath + @"\test.swf";
            //axShockwaveFlash1.Loop = false;
            axShockwaveFlash1.Play();
            //axShockwaveFlash1.BackgroundColor = Color.Black.ToArgb();
        }

        public class myAxShockwaveFlash : AxShockwaveFlashObjects.AxShockwaveFlash
        {
            private const int WM_LBUTTONDOWN = 0x0201;

            protected override void WndProc(ref Message m)
            {
                switch (m.Msg)
                {
                    case WM_LBUTTONDOWN:
                    {
                        MessageBox.Show("click!");
                    }
                        break;
                }
                base.WndProc(ref m);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            timer1.Start();
            timer1.Interval = 700;
            timer1.Enabled = true;
            /*Button invisable = new Button();
            invisable.Width = 300;
            invisable.Height = 600;
            Controls.Add(invisable);
            invisable.Click += delegate { MessageBox.Show("HI!"); };
            invisable.FlatStyle = FlatStyle.Flat;
            invisable.FlatAppearance.BorderColor = BackColor;
            invisable.FlatAppearance.MouseOverBackColor = BackColor;
            invisable.FlatAppearance.MouseDownBackColor = BackColor;*/
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            press_to_continue.Visible = !press_to_continue.Visible;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            FormLevelPath for2 = new FormLevelPath();
            for2.Show();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormLevelPath for2 = new FormLevelPath();
            for2.Show();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            /*Form2 for2 = new Form2();
            this.Hide();
            for2.Show();*/

            Form3 for3 = new Form3();
            this.Hide();
            for3.Show();

            Form1 for1 = new Form1();
            for1.Close();
            //this.Close();
        }
    }
}
