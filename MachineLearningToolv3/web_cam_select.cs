using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing.Imaging;

namespace MachineLearningToolv3
{
    public partial class web_cam_select : Form
    {
        public web_cam_select()
        {
            InitializeComponent();
            capturepic.Visible = false;
           // Ok.Visible = false;
           // capture.Visible = false;
        }

        public static FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        private void web_cam_select_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                camdropdown.Items.Add(filterInfo.Name);
            camdropdown.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice();

        }

       

        private void drivedropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            cnt = 0;
            //if (cam.Image != null)
            //{
            //    if (videoCaptureDevice.IsRunning == true)
            //        videoCaptureDevice.Stop();
            //}
            
        }
        public static string webcam;
        private void Ok_Click(object sender, EventArgs e)
        {
            //camdropdown.Text = cnntest.webby;
            //Console.WriteLine(cnntest.webby);

            

           //this.Hide();
        }

        private void VideoCaptureDevice_NewFrame1(object sender, NewFrameEventArgs eventArgs)
        {
            cam.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            cam.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void web_cam_select_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoCaptureDevice.IsRunning == true)
                videoCaptureDevice.Stop();


            //if (e.CloseReason == CloseReason.UserClosing)
            //{
            //    DialogResult result = MessageBox.Show("Do you really want to exit?", "Dialog Title", MessageBoxButtons.YesNo);
            //    if (result == DialogResult.Yes)
            //    {
            //        //Environment.Exit(0);
            //        this.Close();
            //        if (videoCaptureDevice.IsRunning == true)
            //            videoCaptureDevice.Stop();
            //    }
            //    else
            //    {
            //        e.Cancel = true;
            //        if (videoCaptureDevice.IsRunning == true)
            //            videoCaptureDevice.Stop();
            //    }
            //}
            //else
            //{
            //    e.Cancel = true;
            //    if (videoCaptureDevice.IsRunning == true)
            //        videoCaptureDevice.Stop();
            //}
        }
      
        private void capture_Click(object sender, EventArgs e)
        {
           
           
            //this.Dispose();
            
           
        }
        public int cnt = 0;
        private void Start_Click(object sender, EventArgs e)
        {
            cnt = cnt + 1;
            if(cnt == 1)
            {
                videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[camdropdown.SelectedIndex].MonikerString);
                videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame1;
                videoCaptureDevice.Start();
            }
           
        }

        private void Capture_Click_1(object sender, EventArgs e)
        {
            if (cam.Image == null)
            {
                Console.WriteLine("cam not there");
            }
            else
            {
                capturepic.Image = (Bitmap)cam.Image.Clone();
                capturepic.Image.Save(Application.StartupPath + @"/test.jpg", ImageFormat.Jpeg);
                cnntest.datafilename = Application.StartupPath + @"/test.jpg";
                cnntest.filename = @"test.jpg";
                try
                {
                   cnntest.pictest.Image = capturepic.Image;

                }
                catch
                {
                    Console.WriteLine("null error");
                }

                this.Close();
            }
        }
    }
}
