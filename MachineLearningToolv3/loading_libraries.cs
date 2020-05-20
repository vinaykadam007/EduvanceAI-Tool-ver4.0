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

namespace MachineLearningToolv3
{
    public partial class loading_libraries : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // width of ellipse
           int nHeightEllipse // height of ellipse
       );

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]

        public static extern bool DeleteObject(IntPtr hObject);
        public Timer timer1 = new Timer();
        public loading_libraries()
        {
            InitializeComponent();
            panel1.Left = 186;
        }
        public int plus = 2;
        public void move(object sender, EventArgs e)
        {
            panel1.Left += plus;
            if (panel1.Left > 545)
            {
                plus = -2;
            }
            if (panel1.Left < 186)
            {
                plus = 2;
            }
        }
        private void loading_libraries_Load(object sender, EventArgs e)
        {
            try
            {
                System.IntPtr ptr = CreateRoundRectRgn(0, 0, this.Width, this.Height, 30, 30);
                this.Region = System.Drawing.Region.FromHrgn(ptr);
                //flowLayoutPanel1.Dispose();
                this.BackColor = Color.FromArgb(80, Color.Black);
                DeleteObject(ptr);
            }
            catch
            {
                Console.WriteLine("parameter is not valid");
            }

            timer1.Tick += new EventHandler(move);
            timer1.Interval = 10;
            timer1.Start();
        }




    }
}
