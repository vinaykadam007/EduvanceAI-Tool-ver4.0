using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using System.Web;
using Microsoft.Win32;
using Microsoft.VisualBasic;

namespace MachineLearningToolv3
{
    public partial class splashscreen : Form
    {

       // [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

       // private static extern IntPtr CreateRoundRectRgn
       //(
       //    int nLeftRect,     // x-coordinate of upper-left corner
       //    int nTopRect,      // y-coordinate of upper-left corner
       //    int nRightRect,    // x-coordinate of lower-right corner
       //    int nBottomRect,   // y-coordinate of lower-right corner
       //    int nWidthEllipse, // width of ellipse
       //    int nHeightEllipse // height of ellipse
       //);

       // [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]

       // public static extern bool DeleteObject(IntPtr hObject);
        public splashscreen()
        {
            InitializeComponent();
        }

        private void splashscreen_Load(object sender, EventArgs e)
        {
            this.TransparencyKey = BackColor;
            //System.IntPtr ptr = CreateRoundRectRgn(0, 0, this.Width, this.Height, 30, 30); // _BoarderRaduis can be adjusted to your needs, try 15 to start.
            //this.Region = System.Drawing.Region.FromHrgn(ptr);
            //DeleteObject(ptr);
        }

        private void OUTfade_Tick(object sender, EventArgs e)
        {
            if(this.Opacity == 1)
            {
                OUTfade.Enabled = false;
                timer3.Enabled = true;
                return;
            }
            this.Opacity += 0.01;
        }
        int count = 20;
        private void timer3_Tick(object sender, EventArgs e)
        {
            if(count == 0)
            {
                timer3.Enabled = false;
                INfade.Enabled = true;
                return;
            }
            count -= 1;
        }

        private void INfade_Tick(object sender, EventArgs e)
        {
            if(this.Opacity == 0)
            {
                INfade.Enabled = false;
                //MLTool m1 = new MLTool();
                //this.Close();
                return;
            }
            this.Opacity -= 0.01;
        }
    }
}
