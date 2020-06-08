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
using System.Drawing.Imaging;
using System.Timers;
using System.Management;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Windows.Threading;
using System.Threading;
using System.Net.NetworkInformation;

namespace MachineLearningToolv3
{
    public partial class cnntest : Form
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
        public static string datafilename;
        public static string filename;
        public static PictureBox pictest = new PictureBox();
        //public static PictureBox temppictest = new PictureBox();

        public cnntest()
        {
            InitializeComponent();
            Console.WriteLine(Application.StartupPath + @"\icons\test.jpg");

            //m_oWorker2 = new BackgroundWorker();
            //m_oWorker2.DoWork += new DoWorkEventHandler(run_webcam);
            // SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            predictlabel.Text = "";
            noofdrives.Visible = false;
            drivedropdown.Visible = false;
            export.Visible = false;
            Exportmodel.Visible = false;


            //pictest.Dispose();

            
            //var picture = new PictureBox
            //{
            //    Name = "pictureBox",
            //    Size = new Size(16, 16),
            //    Location = new System.Drawing.Point(100, 100),
            //    Image = Image.FromFile("hello.jpg"),

            //};
            //this.Controls.Add(picture)

        }




        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle = cp.ExStyle | 0x2000000;
        //        return cp;
        //    }
        //}

        //const int WM_DEVICECHANGE = 0x0219; //see msdn site
        //const int DBT_DEVICEARRIVAL = 0x8000;
        //const int DBT_DEVICEREMOVALCOMPLETE = 0x8004;
        //const int DBT_DEVTYPVOLUME = 0x00000002;
        //protected override void WndProc(ref Message m)
        //{
        //    try
        //    {

        //        if (m.Msg == WM_DEVICECHANGE)
        //        {
        //            DEV_BROADCAST_VOLUME vol = (DEV_BROADCAST_VOLUME)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_VOLUME));
        //            if ((m.WParam.ToInt32() == DBT_DEVICEARRIVAL) && (vol.dbcv_devicetype == DBT_DEVTYPVOLUME))
        //            {
        //                // MessageBox.Show(DriveMaskToLetter(vol.dbcv_unitmask).ToString());
        //                drivedropdown.Items.Add(DriveMaskToLetter(vol.dbcv_unitmask).ToString() + @":\");
        //                Console.WriteLine("drive");
        //            }
        //            if ((m.WParam.ToInt32() == DBT_DEVICEREMOVALCOMPLETE) && (vol.dbcv_devicetype == DBT_DEVTYPVOLUME))
        //            {
        //                Console.WriteLine("drive remove");
        //                //MessageBox.Show("usb out");
        //            }
        //        }
        //        base.WndProc(ref m);

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //    }

        //}

        //[StructLayout(LayoutKind.Sequential)] //Same layout in mem
        //public struct DEV_BROADCAST_VOLUME
        //{
        //    public int dbcv_size;
        //    public int dbcv_devicetype;
        //    public int dbcv_reserved;
        //    public int dbcv_unitmask;
        //}

        //private static char DriveMaskToLetter(int mask)
        //{
        //    char letter;
        //    string drives = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; //1 = A, 2 = B, 3 = C
        //    int cnt = 0;
        //    int pom = mask / 2;
        //    while (pom != 0)    // while there is any bit set in the mask shift it right        
        //    {
        //        pom = pom / 2;
        //        cnt++;
        //    }
        //    if (cnt < drives.Length)
        //        letter = drives[cnt];
        //    else
        //        letter = '?';
        //    return letter;
        //}

        

        private void inputpanels_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                System.IntPtr ptr = CreateRoundRectRgn(30, 30, inputpanels.Width, inputpanels.Height, 30, 30); // _BoarderRaduis can be adjusted to your needs, try 15 to start.
                inputpanels.Region = System.Drawing.Region.FromHrgn(ptr);
                DeleteObject(ptr);
            }
            catch
            {
                Console.WriteLine("Parameter is not valid");
            }
            
        }

        private void predictionpanels_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                System.IntPtr ptr = CreateRoundRectRgn(20, 20, predictionpanels.Width, predictionpanels.Height, 30, 30); // _BoarderRaduis can be adjusted to your needs, try 15 to start.
                predictionpanels.Region = System.Drawing.Region.FromHrgn(ptr);
                DeleteObject(ptr);
            }
            catch
            {
                Console.WriteLine("Parameter is not valid");
            }

            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                flowLayoutPanel1.BackColor = Color.FromArgb(80, Color.Black);
                System.IntPtr ptr = CreateRoundRectRgn(0, 0, flowLayoutPanel1.Width, flowLayoutPanel1.Height, 30, 30); // _BoarderRaduis can be adjusted to your needs, try 15 to start.
                flowLayoutPanel1.Region = System.Drawing.Region.FromHrgn(ptr);
                DeleteObject(ptr);
            }
            catch
            {
                Console.WriteLine("Parameter is not valid");
            }

            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                System.IntPtr ptr = CreateRoundRectRgn(0, 0, tableLayoutPanel1.Width, tableLayoutPanel1.Height, 30, 30); // _BoarderRaduis can be adjusted to your needs, try 15 to start.
                tableLayoutPanel1.Region = System.Drawing.Region.FromHrgn(ptr);
                DeleteObject(ptr);
            }
            catch
            {
                Console.WriteLine("Parameter is not valid");
            }
            
        }
        #region .. Double Buffered function ..
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered",
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }

        #endregion
        //FilterInfoCollection filterInfoCollection;
        
        private void cnntest_Load(object sender, EventArgs e)
        {
            //s_oInstance = this;
            try
            {
                pictest = new PictureBox();
                pictest.Image = null;
                pictest.SizeMode = PictureBoxSizeMode.Zoom;
                pictest.Location = new System.Drawing.Point(180, 26);
                pictest.Size = new Size(200, 200);
                inputpanels.Controls.Add(pictest);
                try
                {
                    pictest.Paint += new PaintEventHandler(pictest_Paint);
                }
                catch
                {
                    Console.WriteLine("Parameter is not valid");
                }


                try
                {
                    System.IntPtr ptr = CreateRoundRectRgn(0, 0, this.Width, this.Height, 30, 30); // _BoarderRaduis can be adjusted to your needs, try 15 to start.
                    this.Region = System.Drawing.Region.FromHrgn(ptr);
                    DeleteObject(ptr);
                    SetDoubleBuffered(tableLayoutPanel1);
                    SetDoubleBuffered(tableLayoutPanel5);
                    SetDoubleBuffered(flowLayoutPanel1);
                    SetDoubleBuffered(inputpanels);
                    SetDoubleBuffered(predictionpanels);
                    SetDoubleBuffered(tableLayoutPanel4);
                    SetDoubleBuffered(tableLayoutPanel2);
                    SetDoubleBuffered(Predict);
                    SetDoubleBuffered(tableLayoutPanel6);
                    SetDoubleBuffered(tableLayoutPanel7);
                    SetDoubleBuffered(tableLayoutPanel8);
                    SetDoubleBuffered(tableLayoutPanel10);
                    SetDoubleBuffered(tableLayoutPanel9);

                }
                catch
                {
                    Console.WriteLine("ex");
                }
            }
            catch
            {
                Console.WriteLine("parameter is not valid");
            }
            
            
        }

        


        private void Browsebutton_Click(object sender, EventArgs e)
        {
            // if()
            try
            {
                try
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    // File.Delete(filepath);
                    string[] pathproject3 = Directory.GetFiles(Application.StartupPath, "*.jpg");
                    foreach (string filename1 in pathproject3)
                    {
                        System.IO.File.Delete(filename1);

                    }
                    string[] pathproject2 = Directory.GetFiles(Application.StartupPath, "*.png");
                    foreach (string filename2 in pathproject2)
                    {
                        System.IO.File.Delete(filename2);

                    }
                }
                catch
                {
                    Console.WriteLine("file not deleted1");
                }
                try
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    System.IO.File.Delete(Application.StartupPath + @"\" + filename);
                    Console.WriteLine(Application.StartupPath + @"\" + filename);
                }
                catch
                {
                    Console.WriteLine("file not deleted2");
                }

                predictlabel.Text = "";
                pictest.Image = null;
                Image img;
                //datafilename = "";



                System.Windows.Forms.OpenFileDialog openfiledialog = new System.Windows.Forms.OpenFileDialog();
                openfiledialog.Filter = "Image Files (*.jpg, *.jpeg, *.png) |*.jpg; *.jpeg; *.png";

                //Console.WriteLine(filename);


                if (openfiledialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (pictest.Image != null)
                    {
                        pictest.Image.Dispose();
                    }

                    predictlabel.Text = "";
                    pictest.Image = null;

                    datafilename = openfiledialog.FileName;
                    filename = openfiledialog.SafeFileName;
                    Console.WriteLine(datafilename);
                    Console.WriteLine(Application.StartupPath + @"\" + filename);
                    var i = Image.FromFile(datafilename);
                    Console.WriteLine(i);

                    // using (var bmpTemp = new Bitmap(i))
                    //{
                    img = new Bitmap(i);
                    //}
                    i.Dispose();
                    i = null;
                    try
                    {
                        img.Save(Application.StartupPath + @"\" + filename);

                    }
                    catch
                    {

                    }

                    // pictest.Image.Save(Application.StartupPath + @"\" + filename, ImageFormat.Jpeg);

                    //System.IO.File.Copy(datafilename, Application.StartupPath + @"\" + filename, true);
                    //pictest.ImageLocation = Application.StartupPath + @"\" + filename;
                    pictest.Image = img;//Image.FromFile(Application.StartupPath + @"\" + filename);
                                        //img.Dispose();
                                        //Image previousImage = pictest.Image;
                                        ////pictest.Image = null;
                                        //if (previousImage != null)
                                        //{
                                        //    previousImage.Dispose();
                                        //}

                    Predict.ActiveFillColor = Color.Green;
                    Predict.ActiveLineColor = Color.White;
                    Predict.IdleForecolor = Color.White;
                    Predict.IdleLineColor = Color.White;
                    Predict.IdleFillColor = Color.Green;

                    img.Dispose();
                    img = null;
                    openfiledialog.Dispose();
                }
                else
                {

                    Predict.ActiveFillColor = SystemColors.ActiveCaption;
                    Predict.ActiveLineColor = Color.White;
                    Predict.IdleForecolor = Color.White;
                    Predict.IdleLineColor = Color.White;
                    Predict.IdleFillColor = SystemColors.ActiveCaption;

                    predictlabel.Text = "";
                    pictest.Image = null;

                }
            }
            catch
            {
                Console.WriteLine("Parameter is not valid");
            }

            


           
           // openfiledialog.Reset();
            
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

            //if (pictest != null && pictest.Image != null)
            //{
            //    if (pictest.Image.GetHashCode() != pictest.InitialImage.GetHashCode())
            //    {
            //        pictest.Image.Dispose();
            //    }
            //}
            //Image previousImage = pictest.Image;
            ////pictest.Image = null;
            //if (previousImage != null)
            //{
            //    previousImage.Dispose();
            //}
            try
            {
                string[] pathproject3 = Directory.GetFiles(Application.StartupPath, "*.jpg");
                foreach (string filename1 in pathproject3)
                {
                    System.IO.File.Delete(filename1);

                }
                string[] pathproject2 = Directory.GetFiles(Application.StartupPath, "*.png");
                foreach (string filename2 in pathproject2)
                {
                    System.IO.File.Delete(filename2);

                }
                datafilename = "";
                System.IO.File.Delete(Application.StartupPath + @"/test.jpg");
                System.IO.File.Delete(Application.StartupPath + @"\" + filename);
                try
                {
                    if (pictest.Image != null)
                    {
                        pictest.Image.Dispose();
                    }

                    predictlabel.Text = "";
                    pictest.Image = null;

                    inputpanels.Controls.Remove(pictest);
                }
                catch
                {
                    Console.WriteLine("parameter is not valid");
                }
            }
            catch
            {
                Console.WriteLine("no image found");
            }
           
            this.Close();
           // this.Dispose();
        }

        private void Predict_Click(object sender, EventArgs e)
        {

            try
            {
                if (pictest.Image == null)
                {
                    predictlabel.Text = "";
                    //System.IO.File.Delete(Application.StartupPath + @"\" + filename);
                }
                else
                {
                    if (predictlabel.Text != string.Empty)
                    {
                        // MessageBox.Show("Do you want to Test again ?");

                        DialogResult dialogResult = MessageBox.Show("Do you want to Test again ?", "Message", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Predict.ActiveFillColor = SystemColors.ActiveCaption;
                            Predict.ActiveLineColor = Color.White;
                            Predict.IdleForecolor = Color.White;
                            Predict.IdleLineColor = Color.White;
                            Predict.IdleFillColor = SystemColors.ActiveCaption;

                            predictlabel.Text = "";
                            pictest.Image = null;
                            //confusionmatbox.Image = null;
                            //traintime.Text = "";
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            Console.WriteLine("hehe....No means no");
                        }




                        return;
                    }
                    else
                    {
                        if (datafilename == string.Empty)
                        {
                            MessageBox.Show("Select Input image again");
                            predictlabel.Text = "";
                            datafilename = "";
                            pictest.Image = null;
                        }
                        else
                        {

                            predictlabel.Text = "";
                            //System.IO.File.Copy(datafilename, Application.StartupPath + @"\test\" + filename, true);
                            ProcessStartInfo start = new ProcessStartInfo();
                            start.WindowStyle = ProcessWindowStyle.Hidden;
                            start.CreateNoWindow = true;
                            start.UseShellExecute = false;
                            start.FileName = Environment.SystemDirectory + @"\cmd.exe";
                            string[] fileEntries = Directory.GetFiles(Application.StartupPath + "/", "*.h5");
                            Console.WriteLine("%%%%%%%");
                            Console.WriteLine(fileEntries[0]);
                            if (fileEntries[0] == Application.StartupPath + "/cnn.h5")
                            {
                                test_cnn();
                                Console.WriteLine(fileEntries[0]);
                                start.Arguments = string.Format(@"/C " + "\"" + MachineLearningToolv3.MLTool.pypath + "\"" + " " + Application.StartupPath +@"/IC_Test.py");
                                //start.Arguments = string.Format(@"/C " + MachineLearningToolv3.MLTool.pypath + " IC_Test.py");
                            }

                            start.RedirectStandardOutput = true;

                            using (Process process = Process.Start(start))
                            {
                                using (StreamReader reader = process.StandardOutput)
                                {
                                    string result = reader.ReadToEnd();
                                    Console.Write(result);
                                    predictlabel.Text = result;
                                    predictlabel.Font = new System.Drawing.Font("Segoe UI", 15.0F, FontStyle.Bold);
                                    Predict.ActiveFillColor = SystemColors.ActiveCaption;
                                    Predict.ActiveLineColor = Color.White;
                                    Predict.IdleForecolor = Color.White;
                                    Predict.IdleLineColor = Color.White;
                                    Predict.IdleFillColor = SystemColors.ActiveCaption;

                                }
                            }
                            Console.WriteLine("********Predicted*******");
                            Console.WriteLine(fileEntries[0]);
                            try
                            {
                                System.IO.File.Delete(Application.StartupPath + @"/IC_Test" + ".py");
                                string[] pathproject3 = Directory.GetFiles(Application.StartupPath, "*.jpg");
                                foreach (string filename1 in pathproject3)
                                {
                                    System.IO.File.Delete(filename1);

                                }
                                string[] pathproject2 = Directory.GetFiles(Application.StartupPath, "*.png");
                                foreach (string filename2 in pathproject2)
                                {
                                    System.IO.File.Delete(filename2);

                                }
                                // datafilename = "";
                                System.IO.File.Delete(Application.StartupPath + @"/test.jpg");
                                //System.IO.File.Delete(Application.StartupPath + @"\" + filename);
                            }
                            catch
                            {
                                Console.WriteLine("exception while deleting test script");
                            }

                        }

                    }
                }
            }
            catch
            {
                Console.WriteLine("parameter is not valid");
            }

            
            
            

        }

        public void web_cnn()
        {
            string default_web_cnn = @"import pickle
from keras.models import load_model
from keras.preprocessing import image
import numpy as np
from keras.models import model_from_json
import os
import matplotlib.pyplot as plt
from PIL import Image
import cv2


with open('cnn.json', 'r') as f:
    model = model_from_json(f.read())

model.load_weights('cnn.h5')

cap = cv2.VideoCapture(0)
IMAGE_WIDTH, IMAGE_HEIGHT = 30, 30
dim = (IMAGE_WIDTH, IMAGE_HEIGHT)
list1=[]
for root, dirs, files in os.walk(r""" + Application.StartupPath + @"/root"", topdown=False):
    for name in dirs:
        list1.append(os.path.basename(os.path.join(root, name)))

if 'mix' in list1:
            list1.remove('mix')


while (True):
    ret, frame = cap.read()
    data = []
    resized = cv2.resize(frame, dim)

    data.append(resized)
    inputs = np.asarray(data)
    inputs = inputs.reshape(inputs.shape[0], IMAGE_WIDTH, IMAGE_HEIGHT, 3)
    print(list1[np.argmax(model.predict([inputs]))])


    cv2.imshow('Test Window', frame)

    if cv2.waitKey(1) & 0xFF == ord('q'):
        break

cap.release()
cv2.destroyAllWindows()";

            string from = Application.StartupPath + "/web_Test.py";
            using (StreamWriter file = new StreamWriter(from))
            {

                file.WriteLine(default_web_cnn);

            }
        }
        public void test_cnn()
        {
            string default_testcnn = @"import pickle
from keras.models import load_model
from keras.preprocessing import image
import numpy as np
from keras.models import model_from_json
import os
import matplotlib.pyplot as plt
from PIL import Image
import cv2

with open('cnn.json', 'r') as f:
    model = model_from_json(f.read())

model.load_weights('cnn.h5')

IMAGE_WIDTH, IMAGE_HEIGHT = 30, 30

data = []
img = cv2.resize(cv2.imread(r'" + Application.StartupPath + @"\" + filename + @"'),(IMAGE_WIDTH, IMAGE_HEIGHT))
data.append(img)
inputs = np.asarray(data)
inputs = inputs.reshape(inputs.shape[0], IMAGE_WIDTH, IMAGE_HEIGHT, 3)
list1=[]
for root, dirs, files in os.walk(r""" + Application.StartupPath + @"/root"", topdown=False):
    for name in dirs:
        list1.append(os.path.basename(os.path.join(root, name)))

if 'mix' in list1:
            list1.remove('mix')

print(list1[np.argmax(model.predict([inputs]))])";

            string from = Application.StartupPath + "/IC_Test.py";
            using (StreamWriter file = new StreamWriter(from))
            {

                file.WriteLine(default_testcnn);

            }
        }

       

        private void Exportmodel_Click(object sender, EventArgs e)
        {
            noofdrives.Visible = true;
            drivedropdown.Visible = true;
        }

        private void drivedropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            export.Visible = true;
        }

        private void export_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.StartupPath + @"\filedetails.json"))
            {
                string json = "{"+""+"Scriptname:"+""+""+"followme.py"+""+"}";
                file.WriteLine(json);
                //System.IO.File.Delete(Application.StartupPath + @"/Libinstall.py");
                file.Close();
            }



            try
            {
                System.IO.File.Delete(drivedropdown.Text + @"cnn.h5");
                System.IO.File.Delete(drivedropdown.Text + @"cnn.json");
                System.IO.File.Delete(drivedropdown.Text + @"filedetails.json");
                Console.WriteLine("pd files deleted");
            }
            catch
            {
                Console.WriteLine("pd files not deleted");
            }

            try
            {
                System.IO.File.Copy(Application.StartupPath + @"/filedetails.json", drivedropdown.Text + @"filedetails.json");
                System.IO.File.Copy(Application.StartupPath + @"/cnn.h5", drivedropdown.Text + @"cnn.h5");
                System.IO.File.Copy(Application.StartupPath + @"/cnn.json", drivedropdown.Text + @"cnn.json");
                Console.WriteLine("files copied in pd");
                MessageBox.Show("Successful");
            }
            catch
            {
                Console.WriteLine("files did'nt copy in pd");
            }
        }

        
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
   
        private void webcam_Click(object sender, EventArgs e)
        {

            //selectcamlabel.Visible = true;
            //camdropdown.Visible = true;

            //if(camdropdown.Visible == true)
            //{

            //        filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //        foreach (FilterInfo filterInfo in filterInfoCollection)
            //            camdropdown.Items.Add(filterInfo.Name);
            //        camdropdown.SelectedIndex = 0;
            //        videoCaptureDevice = new VideoCaptureDevice();


            //}
          
            //temppictest.Image = null;

            //temppictest.SizeMode = PictureBoxSizeMode.Zoom;
            //temppictest.Location = new System.Drawing.Point(180, 26);
            //temppictest.Size = new Size(200, 200);
            //inputpanels.Controls.Add(temppictest);



            Predict.ActiveFillColor = SystemColors.ActiveCaption;
            Predict.ActiveLineColor = Color.White;
            Predict.IdleForecolor = Color.White;
            Predict.IdleLineColor = Color.White;
            Predict.IdleFillColor = SystemColors.ActiveCaption;

            predictlabel.Text = "";

            pictest.Image = null;

            var web_cam = new web_cam_select();
            web_cam.ShowDialog();






            
            //web_cam = null;
            //this.Show();
            //videocapturedevice = new VideoCaptureDevice();

            //web_cam = null;
            //timer_end.Tick += new EventHandler(end_it);
            //timer_end.Interval = 200000;
            //timer_end.Start();

            //tmCountDown.Enabled = true;
            //tmCountDown.Interval = 200000;
            //tmCountDown.Start();
            // timer_end.Start();
            //while(cnntestpic == null)
            //{
            //    if (File.Exists(Application.StartupPath + @"/icons/test.jpg"))
            //    {
            //        cnntestpic.ImageLocation = Application.StartupPath + @"/icons/test.jpg";
            //        //tmCountDown.Stop();
            //        break;
            //    }
            //}
            //runtrd = new Thread(() =>
            //{

            //    m_oWorker2.RunWorkerAsync();
            //});

            //runtrd.Start();
            //Console.WriteLine("webcam: ");
            //Console.WriteLine(web_cam_select.webcam);
            //this.Show();
            //predictlabel.Text = "";
            ////System.IO.File.Copy(datafilename, Application.StartupPath + @"\test\" + filename, true);
            //ProcessStartInfo start = new ProcessStartInfo();
            //start.WindowStyle = ProcessWindowStyle.Hidden;
            //start.CreateNoWindow = true;
            //start.UseShellExecute = false;
            //start.FileName = "cmd.exe";
            //string[] fileEntries = Directory.GetFiles(Application.StartupPath + "/", "*.h5");
            //Console.WriteLine("%%%%%%%");
            //Console.WriteLine(fileEntries[0]);
            //if (fileEntries[0] == Application.StartupPath + "/cnn.h5")
            //{
            //    web_cnn();
            //    Console.WriteLine(fileEntries[0]);
            //    start.Arguments = string.Format(@"/C " + MachineLearningToolv3.MLTool.pypath + " web_Test.py");
            //}

            //start.RedirectStandardOutput = true;

            //using (Process process = Process.Start(start))
            //{

            //   // process.OutputDataReceived += (s, k) => { Console.WriteLine(k.Data); };
            //    //process.BeginOutputReadLine();
            //    using (StreamReader reader = process.StandardOutput)
            //    {

            //        string result = reader.ReadToEnd();
            //        //Console.Write(result);
            //        //predictlabel.Text = result;
            //        //predictlabel.Font = new System.Drawing.Font("Segoe UI", 15.0F, FontStyle.Bold);

            //    }
            //}
            //Console.WriteLine("********Predicted*******");
            //Console.WriteLine(fileEntries[0]);
        }


        public void pictest_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (pictest.Image != null)
                {
                    Predict.ActiveFillColor = Color.Green;
                    Predict.ActiveLineColor = Color.White;
                    Predict.IdleForecolor = Color.White;
                    Predict.IdleLineColor = Color.White;
                    Predict.IdleFillColor = Color.Green;
                }
                else
                {
                    Predict.ActiveFillColor = SystemColors.ActiveCaption;
                    Predict.ActiveLineColor = Color.White;
                    Predict.IdleForecolor = Color.White;
                    Predict.IdleLineColor = Color.White;
                    Predict.IdleFillColor = SystemColors.ActiveCaption;
                }
            }
            catch
            {
                Console.WriteLine("Parameter is not valid");
            }
           
        }


        private void cnntest_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void cnntest_Activated(object sender, EventArgs e)
        {
            
        }

   

       

        private void cnntest_FormClosing(object sender, FormClosingEventArgs e)
        {
          

        }



        
      

       
    }
}
