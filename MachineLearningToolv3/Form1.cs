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
using System.Windows.Forms.Design;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Diagnostics;
using System.Web;
using Microsoft.Win32;
using Microsoft.VisualBasic;
using System.Drawing.Imaging;
using System.Net;
using System.Xml;
using System.Management;
using System.Net.Http;
using System.Xml.Linq;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Net.Cache;
using System.Globalization;
using LumenWorks.Framework.IO.Csv;
using SoftwareLocker;
using System.Security.Authentication.ExtendedProtection;
using System.IO.Compression;

namespace MachineLearningToolv3
{
    
    public partial class MLTool : Form
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

        [DllImport("Kernel32.dll")]
        static extern long GetTickCount64();
        public string osstarttime;
        public string text;
        public string data;
        public static int elapsedms1 = 0;
        BackgroundWorker m_oWorker;
       // BackgroundWorker test_window;
        public string ext;
        public bool installed;
        public static string datafilename;
        public string pythonpath;
        public string result;
        public static string modelname;
        public static string[] mystring;
        public static List<string> columns;
        public Thread test_trd;
        public Thread cnntest_trd;
        public Thread trd;
        public Thread cmdtrd;
        Process process = new Process();
        public static string pypath;
        public static List<string> features = new List<string>();
        public static List<string> testfeatures = new List<string>();
        public static List<string> labels = new List<string>();
        //public static List<string> algolabels = new List<string>();
        public static List<string> outputcolumns = new List<string>();
        public static List<string> choosealgo = new List<string>();
        public static List<string> feat = new List<string>();
        public static Bunifu.Framework.UI.BunifuCheckbox o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16, o17, o18, o19, o20, o21, o22, o23, o24, o25, o26, o27, o28, o29, o30;
        public static Bunifu.Framework.UI.BunifuCheckbox i1, i2, i3, i4, i5, i6, i7, i8, i9, i10, i11, i12, i13, i14, i15, i16, i17, i18, i19, i20, i21, i22, i23, i24, i25, i26, i27, i28, i29, i30;
        public List<Bunifu.Framework.UI.BunifuCheckbox> icheckboxlist = new List<Bunifu.Framework.UI.BunifuCheckbox> { i1, i2, i3, i4, i5, i6, i7, i8, i9, i10, i11, i12, i13, i14, i15, i16, i17, i18, i19, i20, i21, i22, i23, i24, i25, i26, i27, i28, i29, i30 };
        public List<Bunifu.Framework.UI.BunifuCheckbox> ocheckboxlist = new List<Bunifu.Framework.UI.BunifuCheckbox> { o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16, o17, o18, o19, o20, o21, o22, o23, o24, o25, o26, o27, o28, o29, o30 };
        public static Label l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13, l14, l15, l16, l17, l18, l19, l20, l21, l22, l23, l24, l25, l26, l27, l28, l29, l30;
        public List<Label> labellist = new List<Label> { l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13, l14, l15, l16, l17, l18, l19, l20, l21, l22, l23, l24, l25, l26, l27, l28, l29, l30 };
        public string licfile = Application.StartupPath + "\\mltool001.reg";
        public int count;
        public string pathlog = Application.StartupPath + "//log.txt";
        public string hideinfo;
        public int runed;
        public string info;
        public string todaydate;
        public string log;
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        public string internettodaydate;
        public static string pippath;
        //public static string fullpath;
        public static string lab;

        private void formrun()
        {
            Application.Run(new splashscreen());
        }


      

        private void formRun1()
        {
            Application.Run(new loading_libraries());
        }
        public MLTool()
        {


            //cnntest cnntest = new cnntest();
            //this.Hide();
            //cnntest.ShowDialog();
            //cnntest = null;
            //this.Show();

            Thread splash = new Thread(new ThreadStart(formrun));
            splash.Start();
            Thread.Sleep(5000);
            CheckForInternetConnection();
            InitializeComponent();
            splash.Abort();


           
            //Console.WriteLine(pypath.Substring(0, 54) + @"Scripts\pip3.6.exe");

            this.WindowState = FormWindowState.Maximized;
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            Resolution objFormResizer = new Resolution();
            objFormResizer.ResizeForm(this, screenHeight, screenWidth);

           datenowtime();
           writelogfile();
           validation();

            DateTime osStartTime = DateTime.Now - new TimeSpan(10000 * GetTickCount64());
            osstarttime = Convert.ToString(osStartTime);


            

            try
            {
                string registry_key = @"Software\Python\PythonCore\3.6";
                using (Microsoft.Win32.RegistryKey key = Registry.CurrentUser.OpenSubKey(registry_key, RegistryKeyPermissionCheck.ReadSubTree))
                {

                    foreach (string subkey_name in key.GetSubKeyNames())
                    {

                        using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                        {

                            object o = subkey.GetValue("ExecutablePath");
                            if (o != null)
                            {

                                Console.WriteLine(o);
                                //keys.Add(o.ToString());
                                pypath = o.ToString();
                            }
                        }
                    }
                    key.Close();
                }
                installed = false;
                
            }
            catch
            {
                installed = true;
                MessageBox.Show("Dependencies not installed");

                this.Close();
            }
            //Set();

            //  Console.WriteLine(pypath.Substring(0,54) + @"Scripts\pip.exe");

            if (installed == false)
            {
                if (File.Exists(Application.StartupPath + @"\installed.reg"))
                {
                    Console.WriteLine("All libraries are installed");
                    goto SkipToEnd;
                }
                else
                {

                    //MessageBox.Show("Wait for libraries to be installed and click ok");
                    Set();
                    if (CheckForInternetConnection() == true)
                    {
                      

                        string registry_key1 = @"Software\Python\PythonCore\3.6";
                        using (Microsoft.Win32.RegistryKey key1 = Registry.CurrentUser.OpenSubKey(registry_key1, RegistryKeyPermissionCheck.ReadSubTree))
                        {


                            using (RegistryKey subkey = key1.OpenSubKey("InstallPath"))
                            {

                                object P = subkey.GetValue(null);
                                if (P != null)
                                {

                                    Console.WriteLine(P);
                                    //keys.Add(o.ToString());
                                    pippath = P.ToString();
                                    pippath = pippath.Replace(@"\", "/");
                                }
                            }

                            key1.Close();
                        }
                        Console.WriteLine(pippath);





                        libraries();


                    }
                    //m_oWorker1.RunWorkerAsync();
                    else
                    {
                        MessageBox.Show("Make sure you have valid Internet Connection");
                        var current = Process.GetCurrentProcess();
                        Process.GetProcessesByName(current.ProcessName)
                            .Where(t => t.Id != current.Id)
                            .ToList()
                            .ForEach(t => t.Kill());

                        current.Kill();

                        Application.Exit();
                    }
                    // this.Show();
                    // this.Hide();

                }

                SkipToEnd:
                Console.WriteLine("All libraries are installed 2");


            }
            else
            {
                Console.WriteLine("Libraries not installed");
            }
            //string test1 = pypath;

            //string result2 = test1.Substring(test1.LastIndexOf('(') + 1, (test1.Length - test1.LastIndexOf('\\')) - 2);
            //Console.WriteLine(pypath);
            //Console.WriteLine(result2);

           

            m_oWorker = new BackgroundWorker();
            m_oWorker.DoWork += new DoWorkEventHandler(run_cmd);
            //test_window = new BackgroundWorker();
            //test_window.DoWork += new DoWorkEventHandler(test_model);

            bunifuThinButton22.Visible = false;

            //test.Text = bunifuSlider1.Value.ToString();

            Test_Button.ActiveFillColor = SystemColors.ActiveCaption;
            Test_Button.ActiveLineColor = Color.White;
            Test_Button.IdleForecolor = Color.White;
            Test_Button.IdleLineColor = Color.White;
            Test_Button.IdleFillColor = SystemColors.ActiveCaption;

            output.Text = "";
            traintime.Text = "";
            filename.Text = "";
            bunifuSlider2.Visible = false;
            label22.Visible = false;
            cycle_textbox();
            cycles.Visible = false;
            //cycles = new TextBox();
            
            //cycles.TextAlign = HorizontalAlignment.Center;


            //bunifuThinButton22.Enabled = false;
            (new Bunifu.Utils.DropShaddow()).ApplyShadows(this);
            try
            {
                System.IO.File.Delete(Application.StartupPath + @"/filedetails.json");
                System.IO.File.Delete(Application.StartupPath + @"/test.jpg");
                System.IO.File.Delete(Application.StartupPath + @"/SGD.pkl");
                System.IO.File.Delete(Application.StartupPath + @"/LinearRegression.pkl");
                System.IO.File.Delete(Application.StartupPath + @"/DTR.pkl");
                System.IO.File.Delete(Application.StartupPath + @"/RFR.pkl");
                System.IO.File.Delete(Application.StartupPath + @"/Perceptron.pkl");
                System.IO.File.Delete(Application.StartupPath + @"/DTC.pkl");
                System.IO.File.Delete(Application.StartupPath + @"/RFC.pkl");
                System.IO.File.Delete(Application.StartupPath + @"/cnn.h5");
                System.IO.File.Delete(Application.StartupPath + @"/cnn.json");
                System.IO.File.Delete(Application.StartupPath + @"/DTC_confusion.png");
                System.IO.File.Delete(Application.StartupPath + @"/Perceptron_confusion.png");
                System.IO.File.Delete(Application.StartupPath + @"/RFC_confusion.png");
                System.IO.File.Delete(Application.StartupPath + @"/IC.py");
                System.IO.File.Delete(Application.StartupPath + @"/SGD.py");
                System.IO.File.Delete(Application.StartupPath + @"/DTR.py");
                System.IO.File.Delete(Application.StartupPath + @"/LinearRegression.py");
                System.IO.File.Delete(Application.StartupPath + @"/RFR.py");
                System.IO.File.Delete(Application.StartupPath + @"/Perceptron.py");
                System.IO.File.Delete(Application.StartupPath + @"/DTC.py");
                System.IO.File.Delete(Application.StartupPath + @"/RFC.py");
                System.IO.File.Delete(Application.StartupPath + @"/Outputhistory.txt");
                string[] pathproject = Directory.GetFiles(Application.StartupPath, "*.zip");
                foreach (string filename in pathproject)
                {
                    System.IO.File.Delete(filename);

                }

                string[] pathproject1 = Directory.GetFiles(Application.StartupPath, "*.csv");
                foreach (string filename in pathproject1)
                {
                    System.IO.File.Delete(filename);

                }
                System.IO.File.Delete(Application.StartupPath + @"/" + modelname + ".py");
                System.IO.File.Delete(Application.StartupPath + @"/Pdfs/ML_report.pdf");
                Directory.Delete(Application.StartupPath + @"/Pdfs");
                // System.IO.File.Delete(Application.StartupPath + @"/test_output.txt");


            }
            catch
            {
                Console.WriteLine("no model file found");
            }
            try
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(Application.StartupPath + @"\root");

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
                Directory.Delete(Application.StartupPath + @"\root");
            }
            catch
            {
                Console.WriteLine("sab delete hua haha");
            }
            

            input_panel1.Enabled = false;
            input_panel1.Controls.Clear();
            //panel4.Enabled = false;
            //label2.Enabled = false;
            //panel5.Enabled = false;
            output_panel1.Enabled = false;
            output_panel1.Controls.Clear();

            label6.ForeColor = Color.DarkGray;
            label9.ForeColor = Color.DarkGray;
            label13.ForeColor = Color.DarkGray;

            IC.Image = SetAlpha((Bitmap)IC.Image, 60);
            label7.ForeColor = Color.DarkGray;


            Perceptron.Image = SetAlpha((Bitmap)Perceptron.Image, 60);
            label10.ForeColor = Color.DarkGray;

            DTC.Image = SetAlpha((Bitmap)DTC.Image, 60);
            label11.ForeColor = Color.DarkGray;

            RFC.Image = SetAlpha((Bitmap)RFC.Image, 60);
            label12.ForeColor = Color.DarkGray;

            LinearRegression.Image = SetAlpha((Bitmap)LinearRegression.Image, 60);
            label15.ForeColor = Color.DarkGray;

            SGD.Image = SetAlpha((Bitmap)SGD.Image, 60);
            label14.ForeColor = Color.DarkGray;

            DTR.Image = SetAlpha((Bitmap)DTR.Image, 60);
            label18.ForeColor = Color.DarkGray;

            RFR.Image = SetAlpha((Bitmap)RFR.Image, 60);
            label17.ForeColor = Color.DarkGray;

        }


        public class Resolution
        {
            float heightRatio = new float();
            float widthRatio = new float();
            int standardHeight, standardWidth;
            public void ResizeForm(Form objForm, int DesignerHeight, int DesignerWidth)
            {
                standardHeight = DesignerHeight;
                standardWidth = DesignerWidth;
                int presentHeight = Screen.PrimaryScreen.WorkingArea.Height;//.Bounds.Height;
                int presentWidth = Screen.PrimaryScreen.Bounds.Width;
                heightRatio = (float)((float)presentHeight / (float)standardHeight);
                widthRatio = (float)((float)presentWidth / (float)standardWidth);
                objForm.AutoScaleMode = AutoScaleMode.None;
                objForm.Scale(new SizeF(widthRatio, heightRatio));
                foreach (Control c in objForm.Controls)
                {
                    if (c.HasChildren)
                    {
                        ResizeControlStore(c);
                    }
                    else
                    {
                        c.Font = new Font(c.Font.FontFamily, c.Font.Size * heightRatio, c.Font.Style, c.Font.Unit, ((byte)(0)));
                    }
                }
                objForm.Font = new Font(objForm.Font.FontFamily, objForm.Font.Size * heightRatio, objForm.Font.Style, objForm.Font.Unit, ((byte)(0)));
            }

            private void ResizeControlStore(Control objCtl)
            {
                if (objCtl.HasChildren)
                {
                    foreach (Control cChildren in objCtl.Controls)
                    {
                        if (cChildren.HasChildren)
                        {
                            ResizeControlStore(cChildren);

                        }
                        else
                        {
                            cChildren.Font = new Font(cChildren.Font.FontFamily, cChildren.Font.Size * heightRatio, cChildren.Font.Style, cChildren.Font.Unit, ((byte)(0)));
                        }
                    }
                    objCtl.Font = new Font(objCtl.Font.FontFamily, objCtl.Font.Size * heightRatio, objCtl.Font.Style, objCtl.Font.Unit, ((byte)(0)));
                }
                else
                {
                    objCtl.Font = new Font(objCtl.Font.FontFamily, objCtl.Font.Size * heightRatio, objCtl.Font.Style, objCtl.Font.Unit, ((byte)(0)));
                }
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


        #region .. code for Flucuring ..

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        #endregion

        
        public static class Utility
        {


            public static void fitFormToScreen(Form form, int h, int w)
            {

                //scale the form to the current screen resolution
                form.Height = (int)((float)form.Height * ((float)Screen.PrimaryScreen.Bounds.Size.Height / (float)h));
                form.Width = (int)((float)form.Width * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w));

                //here font is scaled like width
                //form.Font = new System.Drawing.Font(form.Font.FontFamily, form.Font.Size * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w));

                foreach (Control item in form.Controls)
                {
                    fitControlsToScreen(item, h, w);
                }

            }

            static void fitControlsToScreen(Control cntrl, int h, int w)
            {
                if (Screen.PrimaryScreen.Bounds.Size.Height != h)
                {

                    cntrl.Height = (int)((float)cntrl.Height * ((float)Screen.PrimaryScreen.Bounds.Size.Height / (float)h));
                    cntrl.Top = (int)((float)cntrl.Top * ((float)Screen.PrimaryScreen.Bounds.Size.Height / (float)h));

                }
                if (Screen.PrimaryScreen.Bounds.Size.Width != w)
                {

                    cntrl.Width = (int)((float)cntrl.Width * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w));
                    cntrl.Left = (int)((float)cntrl.Left * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w));

                    // cntrl.Font = new System.Drawing.Font(cntrl.Font.FontFamily, cntrl.Font.Size * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w));

                }

                foreach (Control item in cntrl.Controls)
                {
                    fitControlsToScreen(item, h, w);
                }
            }
        }
        public void readlogfile()
        {
            hideinfo = FileReadWrite.ReadFile(pathlog);
            return;
        }

        public void writelogfile()
        {
            if (!File.Exists(pathlog))
            {
                string checklisttxt = Convert.ToString(count);
                // Console.WriteLine(checklisttxt);
                FileReadWrite.WriteFile(pathlog, checklisttxt);
            }

            else
            {

                string run = FileReadWrite.ReadFile(pathlog);

                readlogfile();
                runed = Convert.ToInt32(run) + 1;
                todaydate = Convert.ToString(DateTime.Now.Date);
                Console.WriteLine("$$$$$$$$$$$$");
                Console.WriteLine(todaydate);
                if (osstarttime != string.Empty)
                {
                    info = runed + ";" + osstarttime;
                    FileReadWrite.WriteFile(pathlog, Convert.ToString(runed));
                    Console.WriteLine(info);
                }
                else
                {
                    info = runed + ";" + todaydate;
                    FileReadWrite.WriteFile(pathlog, Convert.ToString(runed));
                    Console.WriteLine(info);
                }


            }

        }


        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }


        public void datenowtime()
        {
            DateTime result;
            try
            {
                //var client = new TcpClient("time.nist.gov", 13);
                //using (var streamReader = new StreamReader(client.GetStream()))
                //{
                //    var response = streamReader.ReadToEnd();
                //    var utcDateTimeString = response.Substring(7, 17);
                //    //Console.WriteLine(response);
                //    //Console.WriteLine(utcDateTimeString);
                //    DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(Convert.ToDateTime(utcDateTimeString), INDIAN_ZONE);
                //    internettodaydate = Convert.ToString(indianTime);
                //    Console.WriteLine("#######");
                //    Console.WriteLine(internettodaydate);
                //    //Console.WriteLine(indianTime);
                //}

                using (var response =
                    WebRequest.Create("http://www.google.com").GetResponse())
                    //string todaysDates =  response.Headers["date"];
                    result = DateTime.ParseExact(response.Headers["date"],
                        "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                        CultureInfo.InvariantCulture.DateTimeFormat,
                        DateTimeStyles.AssumeUniversal);

                internettodaydate = Convert.ToString(result);
                Console.WriteLine("#######");
                Console.WriteLine(internettodaydate);


            }
            catch (Exception)
            {
                Console.WriteLine("No internet");
            }

        }


        public void validation()
        {

            if (File.Exists(licfile))
            {
                try
                {
                    DateTime creation = File.GetCreationTime(licfile);
                    Console.WriteLine("+++++");
                    //Console.WriteLine(creation);
                    DateTime enddate = creation.AddDays(180);//add days 
                                                            // Console.WriteLine(enddate);
                    string one = internettodaydate.Substring(0, 2);
                    string two = internettodaydate.Substring(2, 6);
                    string three = internettodaydate.Substring(8, 10);
                    string[] four = three.Split(' ');
                    Console.WriteLine("One: "+one);
                    Console.WriteLine("Two: " + two);
                    Console.WriteLine("Three: " + three);

                    foreach (string lined in four)
                    {
                        log = string.Concat(log, lined);
                        Console.WriteLine("Four: "+log);
                        break;
                    }
                    string endates = Convert.ToString(enddate).Substring(0, 10);
                    Console.WriteLine("Four: " + log);
                    Console.WriteLine("Endate: " + endates);
                   
                   // Console.WriteLine("second: " + todaydate);
                    string todaydates = Convert.ToString(todaydate).Substring(0, 10);
                   // Console.WriteLine("third: "+ todaydates);
                    Console.WriteLine(one + two + log);
                    if (endates == one + two + log)
                    {
                        System.IO.File.Delete(licfile);
                        Console.WriteLine("First delete");
                        MessageBox.Show("License Expired(1)");
                    }
                    if (endates == todaydates)
                    {
                        System.IO.File.Delete(licfile);
                        Console.WriteLine("Second delete");
                        MessageBox.Show("License Expired(2)");
                    }
                    else if (Convert.ToDateTime(endates) < Convert.ToDateTime(one + two + log))
                    {
                        System.IO.File.Delete(licfile);
                        Console.WriteLine("Third delete");
                        MessageBox.Show("License Expired(3)");
                    }
                    else if (enddate < DateTime.Now)
                    {
                        System.IO.File.Delete(licfile);
                        Console.WriteLine("Fourth delete");
                        MessageBox.Show("License Expired(4)");
                    }
                    else if (enddate < Convert.ToDateTime(osstarttime))
                    {
                        System.IO.File.Delete(licfile);
                        Console.WriteLine("Fifth delete");
                        MessageBox.Show("License Expired(5)");
                    }
                }
                catch
                {
                    Console.WriteLine("internettodaydate not found");
                }


            }
            else
            {
                // goto 
                Console.WriteLine("License hai");
                //this.Close();
            }
            //       Trialmaker t = new Trialmaker("enblarpre",
            //Application.StartupPath + "\\enb0112p.reg",
            //Environment.GetFolderPath(Environment.SpecialFolder.System) +
            //  "\\enb0112p.dbf",
            //"E-mail: contact@eduvance.in",
            //365, 100, "112");

            //      byte[] MyOwnKey = { 97, 250,  1,  5,  84, 21,   7, 63,
            //                   4,  54, 87, 56, 123, 10,   3, 62,
            //                   7,   9, 20, 36,  37, 21, 101, 57};
            //      t.TripleDESKey = MyOwnKey;
            //      // if you don't call this part the program will
            //      //use default key to encryption

            //      Trialmaker.RunTypes RT = t.ShowDialog();
            //      bool is_trial;
            //      if (RT != Trialmaker.RunTypes.Expired)
            //      {
            //          if (RT == Trialmaker.RunTypes.Full)
            //              is_trial = false;
            //          else
            //              is_trial = true;

            //          Application.Exit();
            //          Application.Restart();
            //      }
        }

        public void libraries() //object sender, DoWorkEventArgs e
        {
            Thread loadinglibraries = new Thread(new ThreadStart(formRun1));
            loadinglibraries.Start();
            //Thread.Sleep(10000);
            
            //create_libinstall();
            this.Hide();
            // this.Invoke((MethodInvoker)delegate () { 
            ProcessStartInfo start = new ProcessStartInfo();
            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.CreateNoWindow = true;
            start.UseShellExecute = false;
            start.Verb = "runas";
            start.FileName = Environment.SystemDirectory + @"\cmd.exe";
            // start.Arguments = string.Format(@"/C " + pypath + " " + Application.StartupPath + @"/Libinstall.py");
            start.Arguments = string.Format(@"/C " + "\"" + @pippath + @"Scripts/pip3.6.exe" + "\"" + @" install python-docx==0.8.10 comtypes numpy matplotlib pandas sklearn seaborn tensorflow==2.0 keras pillow==7.1.0 opencv-python==4.2.0.34");
            start.RedirectStandardOutput = true;


            libinstall:
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string pdf = reader.ReadToEnd();
                    Console.WriteLine(pdf);
                    // MessageBox.Show("Pdf file generated and will be save on your Desktop Folder");
                    // using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.StartupPath + @"\installed.reg"))
                    // {
                    // if(process.HasExited && process.ExitCode == 0)
                    // {

                    //  }


                    //}
                }

                process.Close();
                
            }

            if (Directory.Exists(pippath + @"\Lib\site-packages\python_docx-0.8.10-py3.6.egg-info") &&
                Directory.Exists(pippath + @"\Lib\site-packages\matplotlib") &&
                Directory.Exists(pippath + @"\Lib\site-packages\sklearn") &&
                Directory.Exists(pippath + @"\Lib\site-packages\comtypes") &&
                Directory.Exists(pippath + @"\Lib\site-packages\tensorflow") &&
                Directory.Exists(pippath + @"\Lib\site-packages\keras") &&
                Directory.Exists(pippath + @"\Lib\site-packages\seaborn") &&
                Directory.Exists(pippath + @"\Lib\site-packages\Pillow-7.1.0.dist-info") &&
                Directory.Exists(pippath + @"\Lib\site-packages\opencv_python-4.2.0.34.dist-info")
                )



            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.StartupPath + @"\installed.reg"))
                {

                    file.WriteLine("Ye File kholna nai ta yede");
                    System.IO.File.Delete(Application.StartupPath + @"/Libinstall.py");
                    file.Close();
                }
                //this.Close();
            }
            else
            {
                Console.WriteLine("lib not installed properly");
                process.Close();
                goto libinstall;
            }
            
            //});
           




            if (File.Exists(Application.StartupPath + @"\installed.reg"))
            {
                loadinglibraries.Abort();
                this.Show();
                
            }
            else
            {
                var current = Process.GetCurrentProcess();
                Process.GetProcessesByName(current.ProcessName)
                    .Where(t => t.Id != current.Id)
                    .ToList()
                    .ForEach(t => t.Kill());

                current.Kill();

                Application.Exit();
            }

        }

        public void Set()
        {
            const string name = "PATH";
            string pathvar = System.Environment.GetEnvironmentVariable(name);
            var value = pathvar + @";" + pythonpath + ";";
            var target = EnvironmentVariableTarget.Machine;
            System.Environment.SetEnvironmentVariable(name, value, target);
            Console.WriteLine(target);
        }

        public void readcsvfile()
        {

            using (StreamReader SR = new StreamReader(datafilename))
            {
                string readingline = SR.ReadLine();
                //Console.WriteLine(readingline);
                mystring = readingline.Split(',');
            }

            for (int i = 0; i < mystring.Length; i++)
            {
                 columns = mystring.ToList<string>();
                //var col = new List<string>();
                //var columns = new List<string>();
                //columns.Add(mystring[i]);
                //List<string> columns = mystring.ToList();
                //Console.WriteLine(columns);
                //Console.WriteLine(mystring);
            }



        }

        public string algo;
        public bool browsealgocsvc = false;
        public bool browsealgocsvr = false;
        public bool browsealgozip = false;
        public void onhovercheck(object sender, EventArgs e)
        {

            



            try
            {
                choosealgo.Clear();
                //algo = "";
                foreach (Control c in output_panel1.Controls)
                {
                    if ((c is Bunifu.Framework.UI.BunifuCheckbox) && ((Bunifu.Framework.UI.BunifuCheckbox)c).Checked)
                    {
                        try
                        {
                            //algolabels.Add(columns[Convert.ToInt32(c.Name)]);
                            algo = columns[Convert.ToInt32(c.Name)];
                        }
                        catch
                        {
                            Console.WriteLine("null");

                        }
                    }

                }



                using (CsvReader csv =
            new CsvReader(new StreamReader(datafilename), true))
                {
                    int fieldCount = csv.FieldCount;
                    //Console.WriteLine(fieldCount);
                    // string[] headers = csv.GetFieldHeaders();

                    while (csv.ReadNextRecord())
                    {
                        for (int i = 0; i < fieldCount; i++)
                        {
                            //Console.WriteLine(csv[algo]);
                            choosealgo.Add(csv[algo]);
                            // Console.Write(string.Format("{0} = {1};",
                            //          headers[i], csv[i]));
                            // Console.WriteLine();
                        }


                    }

                    csv.Dispose();
                }

                choosealgo = choosealgo.Distinct().ToList();
                if (choosealgo.Count < 10)
                {
                    browsealgocsvc = true;

                    label6.ForeColor = Color.DarkGray;
                    label9.ForeColor = Color.White;
                    label13.ForeColor = Color.DarkGray;

                    

                    tableLayoutPanel10.Height = t10height;
                    IC.Height = p1height;
                   

                    tableLayoutPanel22.Height = t22height;
                    RFR.Height = p7height;
                    DTR.Height = p8height;

                    tableLayoutPanel20.Height = t20height;
                    LinearRegression.Height = p6height;
                    SGD.Height = p5height;

                   

                    tableLayoutPanel15.Height = t15height;
                    //tableLayoutPanel15.Update();
                    Perceptron.Height = p2height;
                    // pictureBox2.Update();

                    tableLayoutPanel17.Height = t17height;
                    //tableLayoutPanel17.Update();
                    RFC.Height = p3height;
                    //pictureBox3.Update();
                    DTC.Height = p4height;

                    



                    choosealgo.Clear();
                    Console.WriteLine("choosealgoclear");


                    Perceptron.Image = Image.FromFile(Application.StartupPath + @"/icons/perceptron.png"); 
                    label10.ForeColor = Color.White;

                    DTC.Image = Image.FromFile(Application.StartupPath + @"/icons/dtc.png");
                    label11.ForeColor = Color.White;

                    RFC.Image = Image.FromFile(Application.StartupPath + @"/icons/rfc.png");
                    label12.ForeColor = Color.White;

                    IC.Image = Image.FromFile(Application.StartupPath + @"/icons/visual.png");
                    IC.Image = SetAlpha((Bitmap)IC.Image, 60);
                    label7.ForeColor = Color.DarkGray;
                   
                    LinearRegression.Image = Image.FromFile(Application.StartupPath + @"/icons/sgd.png");
                    LinearRegression.Image = SetAlpha((Bitmap)LinearRegression.Image, 60);
                    label15.ForeColor = Color.DarkGray;

                    SGD.Image = Image.FromFile(Application.StartupPath + @"/icons/sgd.png");
                    SGD.Image = SetAlpha((Bitmap)SGD.Image, 60);
                    label14.ForeColor = Color.DarkGray;

                    DTR.Image = Image.FromFile(Application.StartupPath + @"/icons/dtr.png");
                    DTR.Image = SetAlpha((Bitmap)DTR.Image, 60);
                    label18.ForeColor = Color.DarkGray;

                    RFR.Image = Image.FromFile(Application.StartupPath + @"/icons/rfr.png");
                    RFR.Image = SetAlpha((Bitmap)RFR.Image, 60);
                    label17.ForeColor = Color.DarkGray;

                    IC.Enabled = false;
                    LinearRegression.Enabled = false;
                    SGD.Enabled = false;
                    DTR.Enabled = false;
                    RFR.Enabled = false;

                    Perceptron.Enabled = true;
                    DTC.Enabled = true;
                    RFC.Enabled = true;



                    linearregression_click = false;
                    sgd_click = false;
                    dtr_click = false;
                    rfr_click = false;
                    dtc_click = false;
                    rfc_click = false;
                    perceptron_click = false;



                    if (run.IdleFillColor == Color.Green)
                    {
                        Test_Button.ActiveFillColor = SystemColors.ActiveCaption;
                        Test_Button.ActiveLineColor = Color.White;
                        Test_Button.IdleForecolor = Color.White;
                        Test_Button.IdleLineColor = Color.White;
                        Test_Button.IdleFillColor = SystemColors.ActiveCaption;

                        output.Text = "";
                        confusionmatbox.Image = null;
                        traintime.Text = "";

                        run.ActiveFillColor = SystemColors.ActiveCaption;
                        run.ActiveLineColor = Color.White;
                        run.IdleForecolor = Color.White;
                        run.IdleLineColor = Color.White;
                        run.IdleFillColor = SystemColors.ActiveCaption;

                       
                    }
                    else
                    {

                    }


                    Console.WriteLine("classification ahe re");
                }
                else
                {
                    browsealgocsvr = true;

                    label6.ForeColor = Color.DarkGray;
                    label9.ForeColor = Color.DarkGray;
                    label13.ForeColor = Color.White;

                    

                    tableLayoutPanel10.Height = t10height;
                    IC.Height = p1height;
                    

                    tableLayoutPanel22.Height = t22height;
                    RFR.Height = p7height;
                    DTR.Height = p8height;

                    tableLayoutPanel20.Height = t20height;
                    LinearRegression.Height = p6height;
                    SGD.Height = p5height;

                    tableLayoutPanel15.Height = t15height;
                    //tableLayoutPanel15.Update();
                    Perceptron.Height = p2height;
                    // pictureBox2.Update();

                    tableLayoutPanel17.Height = t17height;
                    //tableLayoutPanel17.Update();
                    RFC.Height = p3height;
                    //pictureBox3.Update();
                    DTC.Height = p4height;

                    

                    choosealgo.Clear();
                    Console.WriteLine("choosealgoclear");

                    LinearRegression.Image = Image.FromFile(Application.StartupPath + @"/icons/sgd.png");
                    label15.ForeColor = Color.White;

                    SGD.Image = Image.FromFile(Application.StartupPath + @"/icons/sgd.png");
                    label14.ForeColor = Color.White;

                    DTR.Image = Image.FromFile(Application.StartupPath + @"/icons/dtr.png");
                    label18.ForeColor = Color.White;

                    RFR.Image = Image.FromFile(Application.StartupPath + @"/icons/rfr.png");
                    label17.ForeColor = Color.White;

                    //IC.Image = SetAlpha((Bitmap)IC.Image, 60);
                    //label7.ForeColor = Color.DarkGray;

                    Perceptron.Image = Image.FromFile(Application.StartupPath + @"/icons/perceptron.png");
                    Perceptron.Image = SetAlpha((Bitmap)Perceptron.Image, 60);
                    label10.ForeColor = Color.DarkGray;

                    DTC.Image = Image.FromFile(Application.StartupPath + @"/icons/dtc.png");
                    DTC.Image = SetAlpha((Bitmap)DTC.Image, 60);
                    label11.ForeColor = Color.DarkGray;

                    RFC.Image = Image.FromFile(Application.StartupPath + @"/icons/rfc.png");
                    RFC.Image = SetAlpha((Bitmap)RFC.Image, 60);
                    label12.ForeColor = Color.DarkGray;

                    Perceptron.Enabled = false;
                    DTC.Enabled = false;
                    RFC.Enabled = false;


                    LinearRegression.Enabled = true;
                    SGD.Enabled = true;
                    DTR.Enabled = true;
                    RFR.Enabled = true;


                    IC.Enabled = false;
                    linearregression_click = false;
                    sgd_click = false;
                    dtr_click = false;
                    rfr_click = false;
                    dtc_click = false;
                    rfc_click = false;
                    perceptron_click = false;

                   

                    if (run.IdleFillColor == Color.Green)
                    {
                        Test_Button.ActiveFillColor = SystemColors.ActiveCaption;
                        Test_Button.ActiveLineColor = Color.White;
                        Test_Button.IdleForecolor = Color.White;
                        Test_Button.IdleLineColor = Color.White;
                        Test_Button.IdleFillColor = SystemColors.ActiveCaption;

                        output.Text = "";
                        confusionmatbox.Image = null;
                        traintime.Text = "";

                        run.ActiveFillColor = SystemColors.ActiveCaption;
                        run.ActiveLineColor = Color.White;
                        run.IdleForecolor = Color.White;
                        run.IdleLineColor = Color.White;
                        run.IdleFillColor = SystemColors.ActiveCaption;

                      
                    }
                    else
                    {

                    }

                    Console.WriteLine("regression ahe re");
                }
            }
            catch(System.ArgumentNullException ex)
            {
                MessageBox.Show("This is already been select as input");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            //algolabels.Clear();

            //using (StreamReader SR = new StreamReader(datafilename))
            // {
            //string readingline = SR.ReadLine();
            //  string readinglines = SR.ReadToEnd();
            //  var ocmystring = readinglines.Split(',');
            //Console.WriteLine(readinglines);
            // outputcolumns.Add(ocmystring[algolabels.Count]);
            //  foreach (var item in outputcolumns)
            // {
            //  Console.WriteLine(item);
            // }
            // SR.Close();
            //  }
            //choosealgo.Clear();
            return;






        }

        public void check()
        {
            foreach (Control c in input_panel1.Controls)
            {
                if ((c is Bunifu.Framework.UI.BunifuCheckbox) && ((Bunifu.Framework.UI.BunifuCheckbox)c).Checked)
                {
                    try
                    {
                        features.Add(columns[Convert.ToInt32(c.Name)]);
                        feat.Add(columns[Convert.ToInt32(c.Name)]);
                    }
                    catch
                    {
                        Console.WriteLine("null");

                    }
                }
               
            }



            foreach (Control c in output_panel1.Controls)
            {
                if ((c is Bunifu.Framework.UI.BunifuCheckbox) && ((Bunifu.Framework.UI.BunifuCheckbox)c).Checked)
                {
                    try
                    {
                        labels.Add(columns[Convert.ToInt32(c.Name)]);
                    }
                    catch
                    {
                        Console.WriteLine("null");

                    }
                }
            }

            return;
        }

        public static string getBetween(string strSource, string strStart)
        {
            int Start;
            if (strSource.Contains(strStart))
            {
                Start = strSource.IndexOf(strStart, 0);
                return strSource.Substring(Start);

            }
            else
            {
                return "";
            }
        }
        int i = 1;

        public void cnntestscreen()
        {
           // await Task.Delay(300);
            var cnntes = (cnntest)Application.OpenForms["cnntest"];
            
            //this.Visible = false;
            cnntes = new cnntest();
           // await Task.Delay(300);

            cnntes.ShowDialog();

            this.Invoke((MethodInvoker)delegate ()
            {
                this.Visible = true;
                cnntes.Close();
                cnntes.Dispose();
                cnntest_trd.Abort();
            });
            //this.Visible = true;
        }




        public void testscreen()
        {
            //
            var tes = (Test)Application.OpenForms["Test"];
            //await Task.Delay(500);
            //this.Visible = false;
            tes = new Test();
           // await Task.Delay(300);
            tes.ShowDialog();
           
            this.Invoke((MethodInvoker)delegate ()
            {
                this.Visible = true;
                tes.Close();
                tes.Dispose();
                test_trd.Abort();
            });
                //this.Visible = true;
        }

        public void loadingscreen()
        {
            var ac = (progress)Application.OpenForms["progress"];

            ac = new progress();
         

            ac.ShowDialog();
            this.Invoke((MethodInvoker)delegate () 
            {

                // Application.Run(new progress());
                //ac = null;
                var fileStream = new FileStream(Application.StartupPath + @"\output.txt", FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    text = streamReader.ReadToEnd();
                    Console.WriteLine("************");
                    if (modelname == "IC")
                    {
                        confusionmatbox.Image = null;
                        // Console.WriteLine(text.Length);
                        //confusionmatbox.ImageLocation = "";
                        consolepanel.AutoScroll = true;
                        data = getBetween(text, "Cycle:");
                        //string strStart = "model_accuracy";
                        //int Start = data.IndexOf(strStart, 0) + strStart.Length;
                        ////strStart.Remove();
                        //Console.WriteLine(Start);
                        Console.WriteLine(data);
                        output.Text = data;
                        traintime.Text = "Total Training time: " + Convert.ToInt32(elapsedms1) + " ms";
                        output.Font = new System.Drawing.Font("Segoe UI", 13.0F, FontStyle.Regular);
                        traintime.Font = new System.Drawing.Font("Segoe UI", 13.0F, FontStyle.Regular);
                        output.ForeColor = Color.Black;
                        traintime.ForeColor = Color.Black;
                        run.ActiveFillColor = SystemColors.ActiveCaption;
                        run.ActiveLineColor = Color.White;
                        run.IdleForecolor = Color.White;
                        run.IdleLineColor = Color.White;
                        run.IdleFillColor = SystemColors.ActiveCaption;

                        if(output.Text != string.Empty)
                        {
                            Test_Button.ActiveFillColor = Color.Green;
                            Test_Button.ActiveLineColor = Color.White;
                            Test_Button.IdleForecolor = Color.White;
                            Test_Button.IdleLineColor = Color.White;
                            Test_Button.IdleFillColor = Color.Green;
                        }
                        else
                        {
                            Test_Button.ActiveFillColor = SystemColors.ActiveCaption;
                            Test_Button.ActiveLineColor = Color.White;
                            Test_Button.IdleForecolor = Color.White;
                            Test_Button.IdleLineColor = Color.White;
                            Test_Button.IdleFillColor = SystemColors.ActiveCaption;
                        }



                    }
                    else
                    {

                        output.Text = text;
                        traintime.Text = "Total Training time: " + Convert.ToInt32(elapsedms1) + " ms";
                        output.Font = new System.Drawing.Font("Segoe UI", 13.0F, FontStyle.Regular);
                        traintime.Font = new System.Drawing.Font("Segoe UI", 13.0F, FontStyle.Regular);
                        output.ForeColor = Color.Black;
                        traintime.ForeColor = Color.Black;
                        run.ActiveFillColor = SystemColors.ActiveCaption;
                        run.ActiveLineColor = Color.White;
                        run.IdleForecolor = Color.White;
                        run.IdleLineColor = Color.White;
                        run.IdleFillColor = SystemColors.ActiveCaption;

                        if (output.Text != string.Empty)
                        {
                            Test_Button.ActiveFillColor = Color.Green;
                            Test_Button.ActiveLineColor = Color.White;
                            Test_Button.IdleForecolor = Color.White;
                            Test_Button.IdleLineColor = Color.White;
                            Test_Button.IdleFillColor = Color.Green;
                        }
                        else
                        {
                            Test_Button.ActiveFillColor = SystemColors.ActiveCaption;
                            Test_Button.ActiveLineColor = Color.White;
                            Test_Button.IdleForecolor = Color.White;
                            Test_Button.IdleLineColor = Color.White;
                            Test_Button.IdleFillColor = SystemColors.ActiveCaption;
                        }

                    }
                }

                fileStream.Close();
                this.Visible = true; 
                //trd.Abort();
                //trd1.Abort();
                ac.Close();
                using (StreamWriter sw = File.AppendText(Application.StartupPath + @"\Outputhistory.txt"))
                {

                    sw.WriteLine("Run " + i);

                    //sw.WriteLine();
                    if (modelname == "LinearRegression")
                    {
                        sw.WriteLine("Inputs: " + String.Join(",", feat));
                        sw.WriteLine("Outputs: " + String.Join(",", labels));
                        sw.WriteLine("Model: Linear Regression OLS");
                        sw.WriteLine(traintime.Text);
                        sw.WriteLine(result);
                        sw.WriteLine();
                        i = i + 1;
                    }
                    else if (modelname == "SGD")
                    {
                        sw.WriteLine("Inputs: " + String.Join(",", feat));
                        sw.WriteLine("Outputs: " + String.Join(",", labels));
                        sw.WriteLine("Model: Linear Regression SGD");
                        sw.WriteLine(traintime.Text);
                        sw.WriteLine(result);
                        sw.WriteLine();
                        i = i + 1;
                    }
                    else if (modelname == "DTR")
                    {
                        sw.WriteLine("Inputs: " + String.Join(",", feat));
                        sw.WriteLine("Outputs: " + String.Join(",", labels));
                        sw.WriteLine("Model: Decision Tree Regressor");
                        sw.WriteLine(traintime.Text);
                        sw.WriteLine(result);
                        sw.WriteLine();
                        i = i + 1;
                    }
                    else if (modelname == "RFR")
                    {
                        sw.WriteLine("Inputs: " + String.Join(",", feat));
                        sw.WriteLine("Outputs: " + String.Join(",", labels));
                        sw.WriteLine("Model: Random Forest Regressor");
                        sw.WriteLine(traintime.Text);
                        sw.WriteLine(result);
                        sw.WriteLine();
                        i = i + 1;
                    }
                    else if (modelname == "Perceptron")
                    {
                        sw.WriteLine("Inputs: " + String.Join(",", feat));
                        sw.WriteLine("Outputs: " + String.Join(",", labels));
                        sw.WriteLine("Model: Perceptron");
                        sw.WriteLine(traintime.Text);
                        sw.WriteLine(result);
                        sw.WriteLine();
                        i = i + 1;
                    }
                    else if (modelname == "DTC")
                    {
                        sw.WriteLine("Inputs: " + String.Join(",", feat));
                        sw.WriteLine("Outputs: " + String.Join(",", labels));
                        sw.WriteLine("Model: Decision Tree Classifer");
                        sw.WriteLine(traintime.Text);
                        sw.WriteLine(result);
                        sw.WriteLine();
                        i = i + 1;
                    }
                    else if (modelname == "RFC")
                    {
                        sw.WriteLine("Inputs: " + String.Join(",", feat));
                        sw.WriteLine("Outputs: " + String.Join(",", labels));
                        sw.WriteLine("Model: Random Forest Classifer");
                        sw.WriteLine(traintime.Text);
                        sw.WriteLine(result);
                        sw.WriteLine();
                        i = i + 1;
                    }
                    else if (modelname == "IC")
                    {
                        sw.WriteLine("Model: Image Classifer");
                        sw.WriteLine(traintime.Text);
                        sw.WriteLine(data);
                        sw.WriteLine();
                        i = i + 1;
                    }
                    //sw.WriteLine(traintime.Text);
                    //sw.WriteLine(result);
                    //sw.WriteLine();
                    //sw.WriteLine("Text");
                    
                }

                
                feat = feat.Distinct().ToList();
                //testfeatures = features;
                features.Clear();
                try
                {
                    if(modelname != "IC")
                    {
                        lab = labels[0];
                    }
                }
                catch
                {
                }
                

                labels.Clear();
                System.IO.File.Delete(Application.StartupPath + @"/" + modelname + ".py");

            });
           ac.Close();
        }

       


        public void run_cmd(object sender, DoWorkEventArgs e)
        {
            check();
            khatam = false;
            //this.Invoke((MethodInvoker)delegate () 
            //{
            feat = feat.Distinct().ToList();
            features = features.Distinct().ToList();
            feat = features;
            labels = labels.Distinct().ToList();
            Console.WriteLine(labels.Count);
            Console.WriteLine(feat.Count);
            Console.WriteLine(features.Count);


            //check();

            //foreach (Control c in flowLayoutPanel2.Controls)
            //{
            //    if ((c is System.Windows.Forms.PictureBox) )
            //    {
            //        modelname = c.Name;

            //    }
            //}

            if (ic_click == true)
            {
                modelname = "IC";
                Console.WriteLine("IC");
            }
            else if(perceptron_click == true) 
            {
                modelname = "Perceptron";
                Console.WriteLine("Perceptron");
            }
            else if (rfc_click == true)
            {
                modelname = "RFC";
                Console.WriteLine("RFC");
            }
            else if (dtc_click == true)
            {
                modelname = "DTC";
                Console.WriteLine("DTC");
            }
            else if (linearregression_click == true)
            {
                modelname = "LinearRegression";
                Console.WriteLine("LinearRegression");
            }
            else if (sgd_click == true)
            {
                modelname = "SGD";
                Console.WriteLine("SGD");

            }
            else if (dtr_click == true)
            {
                modelname = "DTR";
                Console.WriteLine("DTR");
            }
            else if (rfr_click == true)
            {
                modelname = "RFR";
                Console.WriteLine("RFR");
            }
            else
            {
                MessageBox.Show("Select the Algorithm");
                return;
            }



            if (modelname == "LinearRegression")
            {
                create_OLS();
                System.IO.File.Delete(Application.StartupPath + @"/cnn.h5");
                System.IO.File.Delete(Application.StartupPath + @"/cnn.json");
                System.IO.File.Delete(Application.StartupPath + @"/DTC_confusion.png");
                System.IO.File.Delete(Application.StartupPath + @"/Perceptron_confusion.png");
                System.IO.File.Delete(Application.StartupPath + @"/RFC_confusion.png");

                string[] pathproject = Directory.GetFiles(Application.StartupPath, "*.zip");
                confusionmatbox.Image = null;
                foreach (string filename in pathproject)
                {
                    System.IO.File.Delete(filename);

                }
            }
            else if (modelname == "SGD")
            {
                create_SGD();
                System.IO.File.Delete(Application.StartupPath + @"/cnn.h5");
                System.IO.File.Delete(Application.StartupPath + @"/cnn.json");
                System.IO.File.Delete(Application.StartupPath + @"/DTC_confusion.png");
                System.IO.File.Delete(Application.StartupPath + @"/Perceptron_confusion.png");
                System.IO.File.Delete(Application.StartupPath + @"/RFC_confusion.png");
                string[] pathproject = Directory.GetFiles(Application.StartupPath, "*.zip");
                confusionmatbox.Image = null;
                foreach (string filename in pathproject)
                {
                    System.IO.File.Delete(filename);

                }
            }
            else if (modelname == "DTR")
            {
                create_DTR();
                System.IO.File.Delete(Application.StartupPath + @"/cnn.h5");
                System.IO.File.Delete(Application.StartupPath + @"/cnn.json");
                System.IO.File.Delete(Application.StartupPath + @"/DTC_confusion.png");
                System.IO.File.Delete(Application.StartupPath + @"/Perceptron_confusion.png");
                System.IO.File.Delete(Application.StartupPath + @"/RFC_confusion.png");
                string[] pathproject = Directory.GetFiles(Application.StartupPath, "*.zip");
                confusionmatbox.Image = null;
                foreach (string filename in pathproject)
                {
                    System.IO.File.Delete(filename);

                }
            }
            else if (modelname == "RFR")
            {
                create_RFR();
                System.IO.File.Delete(Application.StartupPath + @"/cnn.h5");
                System.IO.File.Delete(Application.StartupPath + @"/cnn.json");
                System.IO.File.Delete(Application.StartupPath + @"/DTC_confusion.png");
                System.IO.File.Delete(Application.StartupPath + @"/Perceptron_confusion.png");
                System.IO.File.Delete(Application.StartupPath + @"/RFC_confusion.png");
                string[] pathproject = Directory.GetFiles(Application.StartupPath, "*.zip");
                confusionmatbox.Image = null;
                foreach (string filename in pathproject)
                {
                    System.IO.File.Delete(filename);

                }
            }
            else if (modelname == "Perceptron")
            {
                create_Perceptron();
                System.IO.File.Delete(Application.StartupPath + @"/cnn.h5");
                System.IO.File.Delete(Application.StartupPath + @"/cnn.json");
                System.IO.File.Delete(Application.StartupPath + @"/DTC_confusion.png");
                //System.IO.File.Delete(Application.StartupPath + @"/Perecptron_confusion.png");
                System.IO.File.Delete(Application.StartupPath + @"/RFC_confusion.png");
                string[] pathproject = Directory.GetFiles(Application.StartupPath, "*.zip");
                confusionmatbox.Image = null;
                foreach (string filename in pathproject)
                {
                    System.IO.File.Delete(filename);

                }
            }
            else if (modelname == "DTC")
            {
                create_DTC();
                System.IO.File.Delete(Application.StartupPath + @"/cnn.h5");
                System.IO.File.Delete(Application.StartupPath + @"/cnn.json");
                // System.IO.File.Delete(Application.StartupPath + @"/DTC_confusion.png");
                System.IO.File.Delete(Application.StartupPath + @"/Perceptron_confusion.png");
                System.IO.File.Delete(Application.StartupPath + @"/RFC_confusion.png");
                string[] pathproject = Directory.GetFiles(Application.StartupPath, "*.zip");
                confusionmatbox.Image = null;
                foreach (string filename in pathproject)
                {
                    System.IO.File.Delete(filename);

                }
            }
            else if (modelname == "RFC")
            {
                create_RFC();
                System.IO.File.Delete(Application.StartupPath + @"/cnn.h5");
                System.IO.File.Delete(Application.StartupPath + @"/cnn.json");
                string[] pathproject = Directory.GetFiles(Application.StartupPath, "*.zip");
                System.IO.File.Delete(Application.StartupPath + @"/DTC_confusion.png");
                System.IO.File.Delete(Application.StartupPath + @"/Perceptron_confusion.png");
                //System.IO.File.Delete(Application.StartupPath + @"/RFC_confusion.png");
                confusionmatbox.Image = null;
                foreach (string filename in pathproject)
                {
                    System.IO.File.Delete(filename);

                }
            }
            else if (modelname == "IC")
            {

                System.IO.File.Delete(Application.StartupPath + @"/cnn.h5");
                System.IO.File.Delete(Application.StartupPath + @"/cnn.json");
                System.IO.File.Delete(Application.StartupPath + @"/SGD.pkl");
                System.IO.File.Delete(Application.StartupPath + @"/LinearRegression.pkl");
                System.IO.File.Delete(Application.StartupPath + @"/DTR.pkl");
                System.IO.File.Delete(Application.StartupPath + @"/RFR.pkl");
                System.IO.File.Delete(Application.StartupPath + @"/Perceptron.pkl");
                System.IO.File.Delete(Application.StartupPath + @"/DTC.pkl");
                System.IO.File.Delete(Application.StartupPath + @"/RFC.pkl");
                System.IO.File.Delete(Application.StartupPath + @"/DTC_confusion.png");
                System.IO.File.Delete(Application.StartupPath + @"/Perceptron_confusion.png");
                System.IO.File.Delete(Application.StartupPath + @"/RFC_confusion.png");
                confusionmatbox.Image = null;
                create_IC();

                string[] pathproject = Directory.GetFiles(Application.StartupPath, "*.csv");
                foreach (string filename in pathproject)
                {
                    System.IO.File.Delete(filename);

                }
                try
                {
                    System.IO.DirectoryInfo di = new DirectoryInfo(Application.StartupPath + @"\root");

                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }
                    Directory.Delete(Application.StartupPath + @"\root");
                }
                catch
                {
                    Console.WriteLine("sab delete hua haha");
                }
                //try
                //{
                //    System.IO.DirectoryInfo di = new DirectoryInfo(Application.StartupPath + @"\root");

                //    foreach (FileInfo file in di.GetFiles())
                //    {
                //        file.Delete();
                //    }
                //    foreach (DirectoryInfo dir in di.GetDirectories())
                //    {
                //        dir.Delete(true);
                //    }
                //    Directory.Delete(Application.StartupPath + @"\root");
                //}
                //catch
                //{
                //    Console.WriteLine("sab delete hua haha");
                //}
            }
            //Thread.Yield();
            float split = Convert.ToInt32(test.Text);

            //GC.Collect();
            //GC.WaitForPendingFinalizers();
            //GC.Collect();
            runner = true;
            
            ProcessStartInfo start = new ProcessStartInfo();
            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.CreateNoWindow = true;
            start.UseShellExecute = false;
            start.FileName = Environment.SystemDirectory + @"\cmd.exe";
            //Console.WriteLine(keys[0]);
            //if (modelname == "IC")
            //{
            //    start.Arguments = string.Format(@"/C " + pypath + " " + Application.StartupPath + @"/" + modelname + ".py ");
            //}
            //else
            //{
            //    start.Arguments = string.Format(@"/C " + pypath + " " + Application.StartupPath + @"/" + modelname + ".py " + "-d " + "r\"" + datafilename + "\"" + " -i " + "\"" +String.Join(",", features) + "\"" + " -o " + "\"" + String.Join(",", labels) + "\"" + " -s " + split / 100);
            //}

            //Console.WriteLine(start.Arguments);
            string pythonpath1 = pypath;
            string scriptpath = Application.StartupPath + @"\" + modelname + ".py";

            if (modelname == "IC")
            {
                start.Arguments = string.Format(@"/C " + "\"" + @pythonpath1 + "\"" + " " + Application.StartupPath + @"/" + modelname + ".py");
            }
            else
            {
                start.Arguments = string.Format(@"/C " + "\"" + @pythonpath1 + "\"" + " " + @scriptpath); //" -d " + "r\"" + datafilename + "\"" + " -i " + "\"" +String.Join(",", features.ToArray()) + "\"" + " -o " + "\"" + String.Join(",", labels.ToArray()) + "\"" + " -s " + split / 100);
            }

            Console.WriteLine(start.Arguments);
            start.RedirectStandardOutput = true;
            var watch1 = System.Diagnostics.Stopwatch.StartNew();
            process.Exited += new EventHandler(cmd_Exited);
            using (process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    result = reader.ReadToEnd();
                    Console.Write(result);
                    //if(result.Contains)
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.StartupPath + @"\output.txt"))
                    {

                        file.WriteLine(result);


                    }



                }
                // string[] lines = System.IO.File.ReadAllLines(Application.StartupPath + @"\output.txt");


                var fileStream = new FileStream(Application.StartupPath + @"\output.txt", FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    text = streamReader.ReadToEnd();
                    Console.WriteLine("************");

                    //text.Substring(5100)
                    if (modelname == "IC")
                    {

                        watch1.Stop();
                        elapsedms1 = Convert.ToInt32(watch1.ElapsedMilliseconds);

                    }
                    else
                    {
                        watch1.Stop();
                        elapsedms1 = Convert.ToInt32(watch1.ElapsedMilliseconds);



                        if (modelname == "DTC")
                        {

                            confusionmatbox.ImageLocation = Application.StartupPath + @"\DTC_confusion.png";
                        }
                        else if (modelname == "RFC")
                        {
                            confusionmatbox.ImageLocation = Application.StartupPath + @"\RFC_confusion.png";
                        }
                        else if (modelname == "Perceptron")
                        {
                            confusionmatbox.ImageLocation = Application.StartupPath + @"\Perceptron_confusion.png";
                        }
                    }


                    //process.WaitForExit();

                    if (process.HasExited && process.ExitCode == 0)
                    {
                        //process.Close();
                        Console.WriteLine("process khatam");
                        khatam = true;
                        //if (linearregression_click == true)
                        //{
                        //    linearregression_click = true;
                        //    sgd_click = false;
                        //    dtr_click = false;
                        //    rfr_click = false;
                        //    dtc_click = false;
                        //    rfc_click = false;
                        //    perceptron_click = false;
                        //}
                        //else if (sgd_click == true)
                        //{
                        //    linearregression_click = false;
                        //    sgd_click = true;
                        //    dtr_click = false;
                        //    rfr_click = false;
                        //    dtc_click = false;
                        //    rfc_click = false;
                        //    perceptron_click = false;
                        //}
                        

                    }
                }

                    

            }



        }
        public static bool khatam = false;
        void cmd_Exited(object sender, EventArgs e)
        {
            //MessageBox.Show(output.ToString());
            process.Dispose();
        }

        public void chkcheckboxes(object sender, EventArgs e)
        {
            for (int i = 0; i < mystring.Length; i++)
            {
                if (icheckboxlist[i].Checked)
                {
                    ocheckboxlist[i].Checked = false;
                }
                else if (ocheckboxlist[i].Checked)
                {
                    icheckboxlist[i].Checked = false;

                    //ocheckboxlist[i].Checked = false;
                }
                //else 
                //{
                //    ocheckboxlist[i].Checked = false;

                //}



            }
        }

        public void outputone(object sender, EventArgs e)
        {


            List<int> track = new List<int>();

            for (int i = 0; i < mystring.Length; i++)
            {
                if (icheckboxlist[i].Checked)
                {
                    track.Add(i);

                    //ocheckboxlist[i].Checked = false;
                    //MessageBox.Show("selected as input");
                    //return;
                }

            }
            for (int i = 0; i < track.Count; i++)
            {
                ocheckboxlist[i].Checked = false;
                MessageBox.Show("selected as input");
                return;

            }

            //int j;
            //for (int i = 0; i < mystring.Length; i++)
            //{
            //    if (ocheckboxlist[i].Checked)
            //    {
            //        Console.WriteLine("one");
            //        Console.WriteLine(ocheckboxlist[i].Name);

            //        j = i;

            //        for (int k = 0; k < mystring.Length; k++)
            //        {
            //            if (ocheckboxlist[k] != ocheckboxlist[j])
            //            {

            //                ocheckboxlist[j].Checked = true;
            //                ocheckboxlist[k].Checked = false;
            //                Console.WriteLine("two");
            //                Console.WriteLine(ocheckboxlist[k].Name);
            //            }

            //        }


            //    }
            //    else
            //    {
            //        ocheckboxlist[i].Checked = false;
            //    }

            //}

            //for (int i = mystring.Length; i < 0; i--)
            //{
            //    if (ocheckboxlist[i].Checked)
            //    {
            //        Console.WriteLine("one");
            //        Console.WriteLine(ocheckboxlist[i].Name);

            //        j = i;

            //        for (int k = mystring.Length; k < 0; k--)
            //        {
            //            if (ocheckboxlist[k] != ocheckboxlist[j])
            //            {

            //                ocheckboxlist[j].Checked = true;
            //                ocheckboxlist[k].Checked = false;
            //                Console.WriteLine("two");
            //                Console.WriteLine(ocheckboxlist[k].Name);
            //            }

            //        }


            //    }
            //    else
            //    {
            //        ocheckboxlist[i].Checked = false;
            //    }

            //}


            //foreach (Control c in output_panel1.Controls)
            //{
            //    Bunifu.Framework.UI.BunifuCheckbox cb = c as Bunifu.Framework.UI.BunifuCheckbox;

            //    if (cb != null)
            //    {
            //        if (cb.Checked)
            //        {

            //            Console.WriteLine(cb.Name);
            //            foreach (Control n in output_panel1.Controls)
            //            {
            //                Bunifu.Framework.UI.BunifuCheckbox u = n as Bunifu.Framework.UI.BunifuCheckbox;
            //                if(u != null)
            //                {
            //                    if (u.Name != cb.Name)
            //                    {
            //                        u.Checked = false;
            //                    }
            //                }

            //            }

            //        }
            //        else
            //        {
            //            cb.Checked = false;
            //        }

            //    }
            //}










        }

        public void onhoverincheck(object sender, EventArgs e)
        {
            //label6.ForeColor = Color.DarkGray;
            //label9.ForeColor = Color.White;
            //label13.ForeColor = Color.DarkGray;



            tableLayoutPanel10.Height = t10height;
            IC.Height = p1height;

            tableLayoutPanel22.Height = t22height;
            RFR.Height = p7height;
            DTR.Height = p8height;

            tableLayoutPanel20.Height = t20height;
            LinearRegression.Height = p6height;
            SGD.Height = p5height;

            tableLayoutPanel15.Height = t15height;
            //tableLayoutPanel15.Update();
            Perceptron.Height = p2height;
            // pictureBox2.Update();

            tableLayoutPanel17.Height = t17height;
            //tableLayoutPanel17.Update();
            RFC.Height = p3height;
            //pictureBox3.Update();
            DTC.Height = p4height;

            choosealgo.Clear();
            Console.WriteLine("choosealgoclear");


           


            linearregression_click = false;
            sgd_click = false;
            dtr_click = false;
            rfr_click = false;
            dtc_click = false;
            rfc_click = false;
            perceptron_click = false;



            if (run.IdleFillColor == Color.Green)
            {
                Test_Button.ActiveFillColor = SystemColors.ActiveCaption;
                Test_Button.ActiveLineColor = Color.White;
                Test_Button.IdleForecolor = Color.White;
                Test_Button.IdleLineColor = Color.White;
                Test_Button.IdleFillColor = SystemColors.ActiveCaption;

                output.Text = "";
                confusionmatbox.Image = null;
                traintime.Text = "";

                run.ActiveFillColor = SystemColors.ActiveCaption;
                run.ActiveLineColor = Color.White;
                run.IdleForecolor = Color.White;
                run.IdleLineColor = Color.White;
                run.IdleFillColor = SystemColors.ActiveCaption;


            }
            else
            {

            }
        }
        public void createcheckboxes1()
        {
            int ypos = 10;
            output_panel1.HorizontalScroll.Maximum = 0;
            output_panel1.AutoScroll = false;
            output_panel1.VerticalScroll.Visible = false;
            output_panel1.AutoScroll = true;
            //List<string> lstArray = mystring.ToList();
            for (int i = 0; i < mystring.Length; i++)
            {
                ocheckboxlist[i] = new Bunifu.Framework.UI.BunifuCheckbox();
                ocheckboxlist[i].Location = new Point(20, ypos);
                ocheckboxlist[i].Checked = false;
                ocheckboxlist[i].BackColor = Color.White;
                ocheckboxlist[i].ForeColor = Color.White;
                ocheckboxlist[i].ChechedOffColor = Color.White;
                ocheckboxlist[i].CheckedOnColor = Color.FromArgb(2, 70, 107); 
                ocheckboxlist[i].Name = Convert.ToString(i);
                //checkboxlist[i].


                for (int j = 0; j < mystring.Length; j++)
                {
                    labellist[j] = new Label();
                    labellist[j].Location = new Point(50, ypos);
                    labellist[j].Text = columns[i];
                    labellist[j].Size = new System.Drawing.Size(300, 22);
                    labellist[j].Font = new System.Drawing.Font("Segoe UI", 12.0F, FontStyle.Regular);
                    labellist[j].ForeColor = Color.Black;
                    //Console.WriteLine(columns[i]);
                }




                output_panel1.Controls.Add(ocheckboxlist[i]);
                output_panel1.Controls.Add(labellist[i]);
                //outputpanel1.Controls.Add(checkboxlist[i]);
                //outputpanel1.Controls.Add(checkboxlist[i]);

                ypos += 32;
                ocheckboxlist[i].OnChange += new EventHandler(chkcheckboxes);
               // ocheckboxlist[i].OnChange += new EventHandler(outputone);
                ocheckboxlist[i].OnChange += new EventHandler(onhovercheck);
                
                
               
            }


        }

        public void createcheckboxes()
        {
            int ypos = 10;
            input_panel1.HorizontalScroll.Maximum = 0;
            input_panel1.AutoScroll = false;
            input_panel1.VerticalScroll.Visible = false;
            input_panel1.AutoScroll = true;
            //List<string> lstArray = mystring.ToList();
            for (int i = 0; i < mystring.Length; i++)
            {
                icheckboxlist[i] = new Bunifu.Framework.UI.BunifuCheckbox();
                icheckboxlist[i].Location = new Point(20, ypos);
                icheckboxlist[i].Checked = false;
                icheckboxlist[i].BackColor = Color.White;
                icheckboxlist[i].ForeColor = Color.White;
                icheckboxlist[i].ChechedOffColor = Color.White;
                icheckboxlist[i].CheckedOnColor = Color.FromArgb(2, 70, 107); 
                icheckboxlist[i].Name = Convert.ToString(i);


                for (int j = 0; j < mystring.Length; j++)
                {
                    labellist[j] = new Label();
                    labellist[j].Location = new Point(50, ypos);
                    labellist[j].Text = columns[i];
                    labellist[j].Size = new System.Drawing.Size(300, 22);
                    labellist[j].Font = new System.Drawing.Font("Segoe UI", 12.0F, FontStyle.Regular);
                    labellist[j].ForeColor = Color.Black;
                    //Console.WriteLine(columns[i]);
                }




                input_panel1.Controls.Add(icheckboxlist[i]);
                input_panel1.Controls.Add(labellist[i]);

                ypos += 32;
                icheckboxlist[i].OnChange += new EventHandler(chkcheckboxes);
                icheckboxlist[i].OnChange += new EventHandler(onhoverincheck);
            }



        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
           
        }



       
        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            //panel8.BackColor = Color.FromArgb(80, Color.Black);
        }

        private void label5_Paint(object sender, PaintEventArgs e)
        {
            //label5.BackColor = Color.FromArgb(80, Color.Black);

        }

       

       

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint_1(object sender, PaintEventArgs e)
        {
            try
            {
                System.IntPtr ptr = CreateRoundRectRgn(0, 0, flowLayoutPanel2.Width, flowLayoutPanel2.Height, 30, 30);
                flowLayoutPanel2.Region = System.Drawing.Region.FromHrgn(ptr);
                //flowLayoutPanel1.Dispose();
                flowLayoutPanel2.BackColor = Color.FromArgb(80, Color.Black);
                DeleteObject(ptr);
            }
            catch
            {
                Console.WriteLine("parameter is not valid");
            }
        }

        private void bunifuSlider2_ValueChanged(object sender, EventArgs e)
        {
            cycles.Text = bunifuSlider2.Value.ToString();
            //cycles.Text = 
        }

        private void bunifuSlider2_ValueChangeComplete(object sender, EventArgs e)
        {
            if (bunifuSlider2.Value > 20)
            {
                MessageBox.Show("Increase in number of cycles, will increase your machine training time");

            }
            else
            {
                Console.WriteLine("Value is under 20 :)");
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

        }

        private void bunifuSlider1_ValueChanged(object sender, EventArgs e)
        {
            test.Text = bunifuSlider1.Value.ToString();
            train.Text = (100 - bunifuSlider1.Value).ToString();
        }
        public int  one = 0;
        public bool runner = false;
        private async void run_Click(object sender, EventArgs e)
        {
           // if(one == 0)
            //{
                if (ext == ".zip")
                {
                    if (ic_click == true)
                    {
                        if (filename.Text != string.Empty)
                        {
                            if (output.Text != string.Empty)
                            {

                                DialogResult dialogResult = MessageBox.Show("Do you want to run again ?", "Message", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {

                                    await Task.Delay(500);
                                    this.Visible = false;
                                    //Application.Run(new progress());

                                    trd = new Thread(() =>
                                    {
                                        loadingscreen();

                                    });

                                    cmdtrd = new Thread(() =>
                                    {

                                        m_oWorker.RunWorkerAsync();
                                    });


                                    Parallel.Invoke(() =>
                                    {
                                        trd.Start();
                                        //loadingscreen();
                                    },
                                    () => {
                                        cmdtrd.Start();
                                    });
                                    //run.ActiveFillColor = SystemColors.ActiveCaption; //Color.FromArgb(2, 70, 107); SystemColors.ActiveCaption
                                    //run.ActiveLineColor = Color.White;
                                    //run.IdleForecolor = Color.White;
                                    //run.IdleLineColor = Color.White;
                                    //run.IdleFillColor = SystemColors.ActiveCaption;

                                    //Test_Button.ActiveFillColor = SystemColors.ActiveCaption;
                                    //Test_Button.ActiveLineColor = Color.White;
                                    //Test_Button.IdleForecolor = Color.White;
                                    //Test_Button.IdleLineColor = Color.White;
                                    //Test_Button.IdleFillColor = SystemColors.ActiveCaption;

                                    //output.Text = "";
                                    //confusionmatbox.Image = null;
                                    //traintime.Text = "";
                                    //tableLayoutPanel10.Height = t10height;
                                    //IC.Height = p1height;

                                    //tableLayoutPanel22.Height = t22height;
                                    //RFR.Height = p7height;
                                    //DTR.Height = p8height;

                                    //tableLayoutPanel20.Height = t20height;
                                    //LinearRegression.Height = p6height;
                                    //SGD.Height = p5height;

                                    //tableLayoutPanel15.Height = t15height;
                                    ////tableLayoutPanel15.Update();
                                    //Perceptron.Height = p2height;
                                    //// pictureBox2.Update();

                                    //tableLayoutPanel17.Height = t17height;
                                    ////tableLayoutPanel17.Update();
                                    //RFC.Height = p3height;
                                    ////pictureBox3.Update();
                                    //DTC.Height = p4height;

                                    //choosealgo.Clear();
                                    //Console.WriteLine("choosealgoclear");

                                    //modelname = "";
                                    //ic_click = false;
                                }
                                else if (dialogResult == DialogResult.No)
                                {
                                    Console.WriteLine("hehe....No means no");
                                }



                                return;


                            }

                            Test_Button.ActiveFillColor = SystemColors.ActiveCaption;
                            Test_Button.ActiveLineColor = Color.White;
                            Test_Button.IdleForecolor = Color.White;
                            Test_Button.IdleLineColor = Color.White;
                            Test_Button.IdleFillColor = SystemColors.ActiveCaption;

                            output.Text = "";
                            confusionmatbox.Image = null;
                            traintime.Text = "";



                            try
                            {
                                System.IO.File.Delete(Application.StartupPath + @"/Pdfs/ML_report.pdf");
                                Directory.Delete(Application.StartupPath + @"/Pdfs");
                            }
                            catch
                            {

                            }

                            //if (bunifuSlider1.Value > 40)
                            //{
                            if (run.ActiveLineColor == SystemColors.ActiveCaption)
                            {
                                MessageBox.Show("Select Algorithm again to Run");
                                return;
                            }
                            //run.ActiveFillColor = Color.DodgerBlue;
                            //run.ActiveLineColor = Color.DodgerBlue;
                            //run.IdleForecolor = Color.DodgerBlue;
                            //run.IdleLineColor = Color.DodgerBlue;
                            else
                            {



                                //var pro = new progress();

                                //trd.IsBackground = true;

                                //this.Hide();
                                this.Visible = false;
                                //Application.Run(new progress());

                                trd = new Thread(() =>
                                {
                                    loadingscreen();

                                });

                                cmdtrd = new Thread(() =>
                                {

                                    m_oWorker.RunWorkerAsync();
                                });


                                Parallel.Invoke(() =>
                                {
                                    trd.Start();
                                    //loadingscreen();
                                },
                                () => {
                                    cmdtrd.Start();
                                });



                            }
                        }
                        else
                        {
                            MessageBox.Show("Select the data file");
                        }
                        

                    }
                    else
                    {
                        MessageBox.Show("Select the model");
                    }
                }


                else
                {
                    if (filename.Text == string.Empty)
                    {
                        MessageBox.Show("Select data file");
                        return;
                    }
                    else
                    {
                        check();
                        if (features.Count == 0)
                        {
                            MessageBox.Show("Select the inputs for your model");
                            return;
                        }
                        else if (labels.Count == 0)
                        {
                            MessageBox.Show("Select the output for your model");
                            return;
                        }

                        else
                        {
                            if (runner == true)
                            {
                                if (linearregression_click == true || ic_click == true || sgd_click == true || perceptron_click == true || dtc_click == true || rfc_click == true || dtr_click == true || rfr_click == true)
                                {
                                    DialogResult dialogResult = MessageBox.Show("Do you want to run again ?", "Message", MessageBoxButtons.YesNo);
                                
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        await Task.Delay(500);
                                        this.Visible = false;
                                        //Application.Run(new progress());

                                        trd = new Thread(() =>
                                        {
                                            loadingscreen();

                                        });

                                        cmdtrd = new Thread(() =>
                                        {

                                            m_oWorker.RunWorkerAsync();
                                        });


                                        Parallel.Invoke(() =>
                                        {
                                            trd.Start();
                                            //loadingscreen();
                                        },
                                        () => {
                                            cmdtrd.Start();
                                        });


                                        //runner = false;
                                        //run.ActiveFillColor = SystemColors.ActiveCaption;
                                        //run.ActiveLineColor = Color.White;
                                        //run.IdleForecolor = Color.White;
                                        //run.IdleLineColor = Color.White;
                                        //run.IdleFillColor = SystemColors.ActiveCaption;

                                        //Test_Button.ActiveFillColor = SystemColors.ActiveCaption;
                                        //Test_Button.ActiveLineColor = Color.White;
                                        //Test_Button.IdleForecolor = Color.White;
                                        //Test_Button.IdleLineColor = Color.White;
                                        //Test_Button.IdleFillColor = SystemColors.ActiveCaption;

                                        //output.Text = "";
                                        //confusionmatbox.Image = null;
                                        //traintime.Text = "";
                                        //tableLayoutPanel10.Height = t10height;
                                        //IC.Height = p1height;

                                        //tableLayoutPanel22.Height = t22height;
                                        //RFR.Height = p7height;
                                        //DTR.Height = p8height;

                                        //tableLayoutPanel20.Height = t20height;
                                        //LinearRegression.Height = p6height;
                                        //SGD.Height = p5height;

                                        //tableLayoutPanel15.Height = t15height;
                                        //Perceptron.Height = p2height;

                                        //tableLayoutPanel17.Height = t17height;
                                        //RFC.Height = p3height;
                                        //DTC.Height = p4height;

                                        //choosealgo.Clear();
                                        //Console.WriteLine("choosealgoclear");
                                        //foreach (Control c in output_panel1.Controls)
                                        //{
                                        //    Bunifu.Framework.UI.BunifuCheckbox cb = c as Bunifu.Framework.UI.BunifuCheckbox;

                                        //    if (cb != null)
                                        //    {
                                        //        if (cb.Checked)
                                        //        {
                                        //            cb.Checked = false;


                                        //        }


                                        //    }
                                        //}
                                        //labels.Clear();

                                        //linearregression_click = false;
                                        //sgd_click = false;
                                        //dtr_click = false;
                                        //rfr_click = false;
                                        //dtc_click = false;
                                        //rfc_click = false;
                                        //perceptron_click = false;
                                        //return;
                                    }
                                    else if (dialogResult == DialogResult.No)
                                    {
                                
                                    Console.WriteLine("noooooooooooo");

                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Select the model");
                                    tableLayoutPanel10.Height = t10height;
                                    IC.Height = p1height;

                                    tableLayoutPanel22.Height = t22height;
                                    RFR.Height = p7height;
                                    DTR.Height = p8height;

                                    tableLayoutPanel20.Height = t20height;
                                    LinearRegression.Height = p6height;
                                    SGD.Height = p5height;

                                    tableLayoutPanel15.Height = t15height;
                                    //tableLayoutPanel15.Update();
                                    Perceptron.Height = p2height;
                                    // pictureBox2.Update();

                                    tableLayoutPanel17.Height = t17height;
                                    //tableLayoutPanel17.Update();
                                    RFC.Height = p3height;
                                    //pictureBox3.Update();
                                    DTC.Height = p4height;

                                    choosealgo.Clear();
                                    Console.WriteLine("choosealgoclear");



                                    labels.Clear();

                                    return;


                            }
                           
                            }
                            else
                            {
                                if (labels.Count > 1)
                                {
                                    int i = 0;

                                    foreach (Control c in output_panel1.Controls)
                                    {
                                        Bunifu.Framework.UI.BunifuCheckbox cb = c as Bunifu.Framework.UI.BunifuCheckbox;

                                        if (cb != null)
                                        {
                                            if (cb.Checked)
                                            {
                                                i = i + 1;

                                            }
                                        

                                        }

                                    }
                                    Console.WriteLine("Count_Labels: "+i);
                                    if(i > 1)
                                    {
                                        MessageBox.Show("Select only one output for your model");
                                    }
                                    else if (i == 1)
                                    {
                                        this.Visible = false;
                                            

                                            trd = new Thread(() =>
                                            {
                                                loadingscreen();

                                            });

                                            cmdtrd = new Thread(() =>
                                            {

                                                m_oWorker.RunWorkerAsync();
                                            });


                                            Parallel.Invoke(() =>
                                            {
                                                trd.Start();
                                                //loadingscreen();
                                            },
                                            () => {
                                                cmdtrd.Start();
                                            });
                                    }
                                

                                    //Console.WriteLine("ekich hai");

                                    labels.Clear();

                                        

                                    //linearregression_click = false;
                                    //sgd_click = false;
                                    //dtr_click = false;
                                    //rfr_click = false;
                                    //dtc_click = false;
                                    //rfc_click = false;
                                    //perceptron_click = false;
                                    return;
                                }
                                else
                                {
                                    if (linearregression_click == true || ic_click == true || sgd_click == true || perceptron_click == true || dtc_click == true || rfc_click == true || dtr_click == true || rfr_click == true)
                                    {
                                        if (output.Text != string.Empty)
                                        {

                                            DialogResult dialogResult = MessageBox.Show("Do you want to run again ?", "Message", MessageBoxButtons.YesNo);
                                            //runone:
                                            if (dialogResult == DialogResult.Yes)
                                            {
                                                run.ActiveFillColor = SystemColors.ActiveCaption;
                                                run.ActiveLineColor = Color.White;
                                                run.IdleForecolor = Color.White;
                                                run.IdleLineColor = Color.White;
                                                run.IdleFillColor = SystemColors.ActiveCaption;

                                                Test_Button.ActiveFillColor = SystemColors.ActiveCaption;
                                                Test_Button.ActiveLineColor = Color.White;
                                                Test_Button.IdleForecolor = Color.White;
                                                Test_Button.IdleLineColor = Color.White;
                                                Test_Button.IdleFillColor = SystemColors.ActiveCaption;

                                                output.Text = "";
                                                confusionmatbox.Image = null;
                                                traintime.Text = "";
                                                tableLayoutPanel10.Height = t10height;
                                                IC.Height = p1height;

                                                tableLayoutPanel22.Height = t22height;
                                                RFR.Height = p7height;
                                                DTR.Height = p8height;

                                                tableLayoutPanel20.Height = t20height;
                                                LinearRegression.Height = p6height;
                                                SGD.Height = p5height;

                                                tableLayoutPanel15.Height = t15height;
                                                //tableLayoutPanel15.Update();
                                                Perceptron.Height = p2height;
                                                // pictureBox2.Update();

                                                tableLayoutPanel17.Height = t17height;
                                                //tableLayoutPanel17.Update();
                                                RFC.Height = p3height;
                                                //pictureBox3.Update();
                                                DTC.Height = p4height;

                                                choosealgo.Clear();
                                                Console.WriteLine("choosealgoclear");
                                                foreach (Control c in output_panel1.Controls)
                                                {
                                                    Bunifu.Framework.UI.BunifuCheckbox cb = c as Bunifu.Framework.UI.BunifuCheckbox;

                                                    if (cb != null)
                                                    {
                                                        if (cb.Checked)
                                                        {
                                                            cb.Checked = false;
                                                            //            Console.WriteLine(cb.Name);
                                                            //            foreach (Control n in output_panel1.Controls)
                                                            //            {
                                                            //                Bunifu.Framework.UI.BunifuCheckbox u = n as Bunifu.Framework.UI.BunifuCheckbox;
                                                            //                if(u != null)
                                                            //                {
                                                            //                    if (u.Name != cb.Name)
                                                            //                    {
                                                            //                        u.Checked = false;
                                                            //                    }
                                                            //                }

                                                            //            }

                                                        }
                                                        //        else
                                                        //        {
                                                        //            cb.Checked = false;
                                                        //        }

                                                    }
                                                }
                                                labels.Clear();
                                                linearregression_click = false;
                                                sgd_click = false;
                                                dtr_click = false;
                                                rfr_click = false;
                                                dtc_click = false;
                                                rfc_click = false;
                                                perceptron_click = false;
                                                return;
                                            }
                                            else //if (dialogResult == DialogResult.No)
                                            {
                                               // Console.WriteLine("hehe....No means no");
                                                //one = true;
                                                //goto runone;
                                               // return;

                                            }



                                            // return;
                                        }

                                        Test_Button.ActiveFillColor = SystemColors.ActiveCaption;
                                        Test_Button.ActiveLineColor = Color.White;
                                        Test_Button.IdleForecolor = Color.White;
                                        Test_Button.IdleLineColor = Color.White;
                                        Test_Button.IdleFillColor = SystemColors.ActiveCaption;

                                        output.Text = "";
                                        confusionmatbox.Image = null;
                                        traintime.Text = "";



                                        try
                                        {
                                            System.IO.File.Delete(Application.StartupPath + @"/Pdfs/ML_report.pdf");
                                            Directory.Delete(Application.StartupPath + @"/Pdfs");
                                        }
                                        catch
                                        {

                                        }

                                        //if (bunifuSlider1.Value > 40)
                                        //{
                                        if (run.ActiveLineColor == SystemColors.ActiveCaption)
                                        {
                                            MessageBox.Show("Select Algorithm again to Run");
                                            return;
                                        }
                                        //run.ActiveFillColor = Color.DodgerBlue;
                                        //run.ActiveLineColor = Color.DodgerBlue;
                                        //run.IdleForecolor = Color.DodgerBlue;
                                        //run.IdleLineColor = Color.DodgerBlue;
                                        else
                                        {

                                            //gohere:

                                            //var pro = new progress();

                                            //trd.IsBackground = true;

                                            //this.Hide();
                                            this.Visible = false;
                                            //Application.Run(new progress());

                                            trd = new Thread(() =>
                                            {
                                                loadingscreen();

                                            });

                                            cmdtrd = new Thread(() =>
                                            {

                                                m_oWorker.RunWorkerAsync();
                                            });


                                            Parallel.Invoke(() =>
                                            {
                                                trd.Start();
                                                //loadingscreen();
                                            },
                                            () => {
                                                cmdtrd.Start();
                                            });



                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Select the model");
                                        tableLayoutPanel10.Height = t10height;
                                        IC.Height = p1height;

                                        tableLayoutPanel22.Height = t22height;
                                        RFR.Height = p7height;
                                        DTR.Height = p8height;

                                        tableLayoutPanel20.Height = t20height;
                                        LinearRegression.Height = p6height;
                                        SGD.Height = p5height;

                                        tableLayoutPanel15.Height = t15height;
                                        //tableLayoutPanel15.Update();
                                        Perceptron.Height = p2height;
                                        // pictureBox2.Update();

                                        tableLayoutPanel17.Height = t17height;
                                        //tableLayoutPanel17.Update();
                                        RFC.Height = p3height;
                                        //pictureBox3.Update();
                                        DTC.Height = p4height;

                                        choosealgo.Clear();
                                        Console.WriteLine("choosealgoclear");   



                                        labels.Clear();

                                        return;


                                    }
                                }
                            }
                            

                        }

                    }
                }

            //    one = one + 1;
            //}
            //else if(one > 0)
            //{
            //    MessageBox.Show()
            //}
            
            
            
            
        }
        public bool ic_click = false;
        private void IC_Click(object sender, EventArgs e)
        {
            label6.Focus();
            if (browsealgozip == true)
            {
                runner = false;
                ic_click = true;
                perceptron_click = false;
                rfc_click = false;
                dtc_click = false;
                linearregression_click = false;
                sgd_click = false;
                dtr_click = false;
                rfr_click = false;

               

                tableLayoutPanel10.Height = 66;
                IC.Size = new Size(71, 60);

                run.ActiveFillColor = Color.Green;
                run.ActiveLineColor = Color.White;
                run.IdleForecolor = Color.White;
                run.IdleLineColor = Color.White;
                run.IdleFillColor = Color.Green;

                Test_Button.ActiveFillColor = SystemColors.ActiveCaption;
                Test_Button.ActiveLineColor = Color.White;
                Test_Button.IdleForecolor = Color.White;
                Test_Button.IdleLineColor = Color.White;
                Test_Button.IdleFillColor = SystemColors.ActiveCaption;

                output.Text = "";
                confusionmatbox.Image = null;
                traintime.Text = "";

            }
            else
            {
                tableLayoutPanel22.Height = t22height;
                RFR.Height = p7height;
                DTR.Height = p8height;

                tableLayoutPanel20.Height = t20height;
                LinearRegression.Height = p6height;
                SGD.Height = p5height;

                tableLayoutPanel15.Height = t15height;
                //tableLayoutPanel15.Update();
                Perceptron.Height = p2height;
                // pictureBox2.Update();

                tableLayoutPanel17.Height = t17height;
                //tableLayoutPanel17.Update();
                RFC.Height = p3height;
                //pictureBox3.Update();
                DTC.Height = p4height;
            }

        }

        private void output_panel1_Paint(object sender, PaintEventArgs e)
        {
            //CheckBox activeCheckBox = sender as CheckBox;
            //foreach (Control c in Controls)
            //{
            //    CheckBox checkBox = c as CheckBox;
            //    if (checkBox != null)
            //    {
            //        if (!checkBox.Equals(activeCheckBox))
            //        { checkBox.Checked = !activeCheckBox.Checked; }
            //        else
            //        { checkBox.Checked = true; }
            //    }
            //}
        }

        private void output_panel1_VisibleChanged(object sender, EventArgs e)
        {
            //CheckBox lastChecked;

            

            

            //CheckBox activeCheckBox = sender as CheckBox;
            //foreach (Control c in Controls)
            //{
            //    CheckBox checkBox = c as CheckBox;
            //    if (checkBox != null)
            //    {
            //        if (!checkBox.Equals(activeCheckBox))
            //        { checkBox.Checked = !activeCheckBox.Checked; }
            //        else
            //        { checkBox.Checked = true; }
            //    }
            //}
        }

       
       

      
        private string getfilename(string pathy)
        {
            return Path.GetFileNameWithoutExtension(pathy);
        }
        
        public bool perceptron_click = false;
        private void Perceptron_Click(object sender, EventArgs e)
        {
            if(browsealgocsvc == true)
            {
                //  check();
                runner = false;
                perceptron_click = true;
                ic_click = false;
                rfc_click = false;
                dtc_click = false;
                linearregression_click = false;
                sgd_click = false;
                dtr_click = false;
                rfr_click = false;

                tableLayoutPanel15.Height = 66;
                Perceptron.Size = new Size(71, 60);

                tableLayoutPanel17.Height = t17height;
                RFC.Height = p3height;
                // pictureBox3.Update();
                DTC.Height = p4height;

                run.ActiveFillColor = Color.Green;
                run.ActiveLineColor = Color.White;
                run.IdleForecolor = Color.White;
                run.IdleLineColor = Color.White;
                run.IdleFillColor = Color.Green;

                Test_Button.ActiveFillColor = SystemColors.ActiveCaption;
                Test_Button.ActiveLineColor = Color.White;
                Test_Button.IdleForecolor = Color.White;
                Test_Button.IdleLineColor = Color.White;
                Test_Button.IdleFillColor = SystemColors.ActiveCaption;

                output.Text = "";
                confusionmatbox.Image = null;
                traintime.Text = "";
            }

            else
            {
                tableLayoutPanel22.Height = t22height;
                RFR.Height = p7height;
                DTR.Height = p8height;

                tableLayoutPanel20.Height = t20height;
                LinearRegression.Height = p6height;
                SGD.Height = p5height;

                tableLayoutPanel10.Height = t10height;
                IC.Height = p1height;
                //tableLayoutPanel10.Update();
                // pictureBox1.Update();


                tableLayoutPanel17.Height = t17height;
                RFC.Height = p3height;
                // pictureBox3.Update();
                DTC.Height = p4height;


    
            }

        }

        public bool rfc_click = false;
        private void RFC_Click(object sender, EventArgs e)
        {
            if(browsealgocsvc == true)
            {
                runner = false;
                rfc_click = true;
                perceptron_click = false;
                ic_click = false;
                dtc_click = false;
                linearregression_click = false;
                sgd_click = false;
                dtr_click = false;
                rfr_click = false;

                tableLayoutPanel17.Height = 66;
                RFC.Size = new Size(71, 60);

                tableLayoutPanel15.Height = t15height;
                Perceptron.Height = p2height;

                DTC.Height = p4height;

                run.ActiveFillColor = Color.Green;
                run.ActiveLineColor = Color.White;
                run.IdleForecolor = Color.White;
                run.IdleLineColor = Color.White;
                run.IdleFillColor = Color.Green;

                Test_Button.ActiveFillColor = SystemColors.ActiveCaption;
                Test_Button.ActiveLineColor = Color.White;
                Test_Button.IdleForecolor = Color.White;
                Test_Button.IdleLineColor = Color.White;
                Test_Button.IdleFillColor = SystemColors.ActiveCaption;

                output.Text = "";
                confusionmatbox.Image = null;
                traintime.Text = "";
            }
            else
            {
                tableLayoutPanel22.Height = t22height;
                RFR.Height = p7height;
                DTR.Height = p8height;

                tableLayoutPanel20.Height = t20height;
                LinearRegression.Height = p6height;
                SGD.Height = p5height;

                tableLayoutPanel10.Height = t10height;
                IC.Height = p1height;
                // tableLayoutPanel10.Update();
                // pictureBox1.Update();

                tableLayoutPanel15.Height = t15height;
                Perceptron.Height = p2height;
                // pictureBox2.Update();
                // tableLayoutPanel15.Update();

                //tableLayoutPanel17.Height = t17height;
                DTC.Height = p4height;
             
            }


        }


        public bool dtc_click = false;
        private void DTC_Click(object sender, EventArgs e)
        {
            if(browsealgocsvc == true)
            {
                runner = false;
                dtc_click = true;
                rfc_click = false;
                perceptron_click = false;
                ic_click = false;
                linearregression_click = false;
                sgd_click = false;
                dtr_click = false;
                rfr_click = false;

                tableLayoutPanel17.Height = 66;
                DTC.Size = new Size(71, 60);

                tableLayoutPanel15.Height = t15height;
                Perceptron.Height = p2height;

                RFC.Height = p3height;

                run.ActiveFillColor = Color.Green;
                run.ActiveLineColor = Color.White;
                run.IdleForecolor = Color.White;
                run.IdleLineColor = Color.White;
                run.IdleFillColor = Color.Green;

                Test_Button.ActiveFillColor = SystemColors.ActiveCaption;
                Test_Button.ActiveLineColor = Color.White;
                Test_Button.IdleForecolor = Color.White;
                Test_Button.IdleLineColor = Color.White;
                Test_Button.IdleFillColor = SystemColors.ActiveCaption;

                output.Text = "";
                confusionmatbox.Image = null;
                traintime.Text = "";
            }

            else
            {
                tableLayoutPanel22.Height = t22height;
                RFR.Height = p7height;
                DTR.Height = p8height;

                tableLayoutPanel20.Height = t20height;
                LinearRegression.Height = p6height;
                SGD.Height = p5height;

                tableLayoutPanel10.Height = t10height;
                IC.Height = p1height;
                // tableLayoutPanel10.Update();
                // pictureBox1.Update();

                tableLayoutPanel15.Height = t15height;
                Perceptron.Height = p2height;
                //  pictureBox2.Update();
                // tableLayoutPanel15.Update();

                //tableLayoutPanel17.Height = t17height;
                RFC.Height = p3height;
                // pictureBox3.Update();
            }

        }

        public bool linearregression_click = false;
        private void LinearRegression_Click(object sender, EventArgs e)
        {
            if(browsealgocsvr == true)
            {
                runner = false;
                linearregression_click = true;
                rfc_click = false;
                perceptron_click = false;
                ic_click = false;
                dtc_click = false;
                sgd_click = false;
                dtr_click = false;
                rfr_click = false;
                Console.WriteLine("Linear Regression");

                tableLayoutPanel20.Height = 66;
                LinearRegression.Size = new Size(71, 60);

                tableLayoutPanel22.Height = t22height;
                RFR.Height = p7height;
                DTR.Height = p8height;

                SGD.Height = p5height;

                run.ActiveFillColor = Color.Green;
                run.ActiveLineColor = Color.White;
                run.IdleForecolor = Color.White;
                run.IdleLineColor = Color.White;
                run.IdleFillColor = Color.Green;

                Test_Button.ActiveFillColor = SystemColors.ActiveCaption;
                Test_Button.ActiveLineColor = Color.White;
                Test_Button.IdleForecolor = Color.White;
                Test_Button.IdleLineColor = Color.White;
                Test_Button.IdleFillColor = SystemColors.ActiveCaption;

                output.Text = "";
                confusionmatbox.Image = null;
                traintime.Text = "";

            }

            else
            {
                tableLayoutPanel22.Height = t22height;
                RFR.Height = p7height;
                DTR.Height = p8height;

                tableLayoutPanel10.Height = t10height;
                IC.Height = p1height;
                // tableLayoutPanel10.Update();
                // pictureBox1.Update();

                tableLayoutPanel15.Height = t15height;
                Perceptron.Height = p2height;
                //  pictureBox2.Update();
                // tableLayoutPanel15.Update();

                tableLayoutPanel17.Height = t17height;
                RFC.Height = p3height;
                DTC.Height = p4height;
                // pictureBox3.Update();

                SGD.Height = p5height;

            }

        }

        public bool sgd_click = false;
        private void SGD_Click(object sender, EventArgs e)
        {
            if(browsealgocsvr == true)
            {
                runner = false;
                sgd_click = true;
                rfc_click = false;
                perceptron_click = false;
                ic_click = false;
                dtc_click = false;
                linearregression_click = false;
                dtr_click = false;
                rfr_click = false;
                Console.WriteLine("SGD");
                tableLayoutPanel20.Height = 66;
                SGD.Size = new Size(71, 60);

                LinearRegression.Height = p6height;

                tableLayoutPanel22.Height = t22height;
                RFR.Height = p7height;
                DTR.Height = p8height;

                run.ActiveFillColor = Color.Green;
                run.ActiveLineColor = Color.White;
                run.IdleForecolor = Color.White;
                run.IdleLineColor = Color.White;
                run.IdleFillColor = Color.Green;

                Test_Button.ActiveFillColor = SystemColors.ActiveCaption;
                Test_Button.ActiveLineColor = Color.White;
                Test_Button.IdleForecolor = Color.White;
                Test_Button.IdleLineColor = Color.White;
                Test_Button.IdleFillColor = SystemColors.ActiveCaption;

                output.Text = "";
                confusionmatbox.Image = null;
                traintime.Text = "";
            }
            else
            {
                tableLayoutPanel22.Height = t22height;
                RFR.Height = p7height;
                DTR.Height = p8height;

                tableLayoutPanel10.Height = t10height;
                IC.Height = p1height;
                // tableLayoutPanel10.Update();
                // pictureBox1.Update();

                tableLayoutPanel15.Height = t15height;
                Perceptron.Height = p2height;
                //  pictureBox2.Update();
                // tableLayoutPanel15.Update();

                tableLayoutPanel17.Height = t17height;
                RFC.Height = p3height;
                DTC.Height = p4height;
                LinearRegression.Height = p6height;

            }



        }

        public bool dtr_click = false;
        private void DTR_Click(object sender, EventArgs e)
        {
            if(browsealgocsvr == true)
            {
                runner = false;
                dtr_click = true;
                rfc_click = false;
                perceptron_click = false;
                ic_click = false;
                dtc_click = false;
                linearregression_click = false;
                sgd_click = false;
                rfr_click = false;
                Console.WriteLine("DTR");

                tableLayoutPanel22.Height = 66;
                DTR.Size = new Size(71, 60);

                tableLayoutPanel20.Height = t20height;
                LinearRegression.Height = p6height;
                SGD.Height = p5height;

                RFR.Height = p7height;

                run.ActiveFillColor = Color.Green;
                run.ActiveLineColor = Color.White;
                run.IdleForecolor = Color.White;
                run.IdleLineColor = Color.White;
                run.IdleFillColor =  Color.Green;

                Test_Button.ActiveFillColor = SystemColors.ActiveCaption;
                Test_Button.ActiveLineColor = Color.White;
                Test_Button.IdleForecolor = Color.White;
                Test_Button.IdleLineColor = Color.White;
                Test_Button.IdleFillColor = SystemColors.ActiveCaption;

                output.Text = "";
                confusionmatbox.Image = null;
                traintime.Text = "";
            }

            else
            {
                //tableLayoutPanel22.Height = t22height;
                RFR.Height = p7height;
                // pictureBox8.Height = p8height;

                tableLayoutPanel10.Height = t10height;
                IC.Height = p1height;
                // tableLayoutPanel10.Update();
                // pictureBox1.Update();

                tableLayoutPanel15.Height = t15height;
                Perceptron.Height = p2height;
                //  pictureBox2.Update();
                // tableLayoutPanel15.Update();

                tableLayoutPanel17.Height = t17height;
                RFC.Height = p3height;
                DTC.Height = p4height;

                tableLayoutPanel20.Height = t20height;
                LinearRegression.Height = p6height;
                SGD.Height = p5height;
            }
            

            
        }

        public bool rfr_click = false;
        private void RFR_Click(object sender, EventArgs e)
        {
            if(browsealgocsvr == true)
            {
                runner = false;
                dtr_click = false;
                rfc_click = false;
                perceptron_click = false;
                ic_click = false;
                dtc_click = false;
                linearregression_click = false;
                sgd_click = false;
                rfr_click = true;
                Console.WriteLine("RFR");

                tableLayoutPanel22.Height = 66;
                RFR.Size = new Size(71, 60);

                DTR.Height = p8height;

                tableLayoutPanel20.Height = t20height;
                LinearRegression.Height = p6height;
                SGD.Height = p5height;

                run.ActiveFillColor = Color.Green;
                run.ActiveLineColor = Color.White;
                run.IdleForecolor = Color.White;
                run.IdleLineColor = Color.White;
                run.IdleFillColor = Color.Green;

                Test_Button.ActiveFillColor = SystemColors.ActiveCaption;
                Test_Button.ActiveLineColor = Color.White;
                Test_Button.IdleForecolor = Color.White;
                Test_Button.IdleLineColor = Color.White;
                Test_Button.IdleFillColor = SystemColors.ActiveCaption;

                output.Text = "";
                confusionmatbox.Image = null;
                traintime.Text = "";

            }
            else
            {
                //tableLayoutPanel22.Height = t22height;
                DTR.Height = p8height;
                // pictureBox8.Height = p8height;

                tableLayoutPanel10.Height = t10height;
                IC.Height = p1height;
                // tableLayoutPanel10.Update();
                // pictureBox1.Update();

                tableLayoutPanel15.Height = t15height;
                Perceptron.Height = p2height;
                //  pictureBox2.Update();
                // tableLayoutPanel15.Update();

                tableLayoutPanel17.Height = t17height;
                RFC.Height = p3height;
                DTC.Height = p4height;

                tableLayoutPanel20.Height = t20height;
                LinearRegression.Height = p6height;
                SGD.Height = p5height;
            }
            

            
        }

        private void Generate_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                System.IntPtr ptr = CreateRoundRectRgn(0, 0, flowLayoutPanel1.Width, flowLayoutPanel1.Height, 30, 30);
                flowLayoutPanel1.Region = System.Drawing.Region.FromHrgn(ptr);
                //flowLayoutPanel1.Dispose();
                flowLayoutPanel1.BackColor = Color.FromArgb(80, Color.Black);
                DeleteObject(ptr);
            }
            catch
            {
                Console.WriteLine("parameter is not valid");
            }
        }
        public void test_model(object sender, DoWorkEventArgs e)
        {
            //var test = new Test();
            //this.Hide();
            //test.ShowDialog();
            //test = null;
            //this.Show();
            //var ac = (Test)Application.OpenForms["Test"];

            //ac = new Test();


            //ac.ShowDialog();

            //this.Invoke((MethodInvoker)delegate () { 
            //    if(ac == null)
            //    {
            //        ac.Close();
            //    }
            
            //});

        }

        private void Test_Button_Click(object sender, EventArgs e)
        {
           // Thread splash = new Thread(new ThreadStart(formrun));
           // splash.Start();

            if (output.Text != string.Empty)
            {

                try
                {
                    if (modelname == "IC")
                    {

                        bool formOpen = false;

                        foreach (Form form in Application.OpenForms)
                        {
                            if (form.Name == "cnntest")
                            {
                                formOpen = true;
                                break;
                            }
                        }
                        if (formOpen)
                        {
                            MessageBox.Show("Test Form is already open");
                        }
                        else
                        {
                            

                            this.Visible = false;
                           // await Task.Delay(1200);
                            cnntest_trd = new Thread(() =>
                            {
                                cnntestscreen();

                            });
                            cnntest_trd.SetApartmentState(ApartmentState.STA);
                            cnntest_trd.Start();


                            //cnntest cnntest = new cnntest();
                            //this.Hide();
                            //// splash.Abort();
                            //cnntest.ShowDialog();
                            //cnntest = null;
                            //this.Show();


                        }

                    }
                    else
                    {

                        bool formOpen = false;

                        foreach (Form form in Application.OpenForms)
                        {
                            if (form.Name == "Test")
                            {
                                formOpen = true;
                                break;
                            }
                        }
                        if (formOpen)
                        {
                            MessageBox.Show("Test Form is already open");
                        }
                        else
                        {

                            this.Visible = false;
                            //await Task.Delay(800);
                            test_trd = new Thread(() =>
                            {
                                testscreen();

                            });

                            test_trd.Start();
                            //Test test = new Test();
                            //this.Hide();
                            ////splash.Abort();
                            //test.ShowDialog();
                            //test = null;
                            //this.Show();
                            //MessageBox.Show("Form is not open");
                        }


                        string[] fileEntries = Directory.GetFiles(Application.StartupPath + "/", "*.pkl");
                        for (int i = 0; i < fileEntries.Length; i++)
                        {
                            if (Path.GetFileName(fileEntries[i]) != modelname + ".pkl")
                            {
                                Console.WriteLine(Path.GetFileName(fileEntries[i]));
                                System.IO.File.Delete(fileEntries[i]);

                            }

                        }


                    }

                }
                catch
                {
                    this.Show();
                    Console.WriteLine("fuck");
                }
                
            }
            else
            {
                MessageBox.Show("Test Window cannot be viewed now, unless you create the model");
                return;


            }

            
        }

        private void bunifuThinButton22_Click_1(object sender, EventArgs e)
        {
            create_pdfreport();
            try
            {
                System.IO.File.Delete(Application.StartupPath + @"/Pdfs/ML_report.pdf");
                Directory.Delete(Application.StartupPath + @"/Pdfs");
            }
            catch
            {

            }

            ProcessStartInfo start = new ProcessStartInfo();
            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.CreateNoWindow = true;
            start.UseShellExecute = false;
            start.FileName = Environment.SystemDirectory + @"\cmd.exe";
            start.Arguments = string.Format(@"/C " + pypath +" " + Application.StartupPath + @"/txttopdf.py");
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string pdf = reader.ReadToEnd();
                    Console.WriteLine(pdf);
                    MessageBox.Show("Pdf file generated and will be save on your Desktop Folder");
                }
            }



            System.IO.File.Delete(Application.StartupPath + @"/txttopdf.py");
            System.IO.File.Delete(Application.StartupPath + @"/Documents/ML.docx");
            Directory.Delete(Application.StartupPath + @"/Documents");

            //System.Windows.Forms.FolderBrowserDialog folderdialog = new System.Windows.Forms.FolderBrowserDialog();
            //if (folderdialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    string folderpath = folderdialog.SelectedPath;
            //    Console.WriteLine(folderpath);
            //    System.IO.File.Copy(Application.StartupPath + @"/Pdfs/ML_report.pdf", folderpath+@"/ML_report.pdf");
            //}
            try
            {
                System.IO.File.Copy(Application.StartupPath + @"/Pdfs/ML_report.pdf", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/ML_report.pdf", true);
            }
            catch
            {
                Console.WriteLine("pdf exists");
            }
        }

        private void bunifuSlider1_ValueChangeComplete(object sender, EventArgs e)
        {
            if (bunifuSlider1.Value > 30)
            {
                MessageBox.Show("Test value is exceeding 30. " +
                    "Your model accuracy might be reduced.");

            }
            else
            {
                Console.WriteLine("Value is under 30 :)");
            }
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            //panel1.BackColor = Color.FromArgb(80, Color.Black);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                System.IntPtr ptr = CreateRoundRectRgn(0, 0, tableLayoutPanel4.Width, tableLayoutPanel4.Height, 30, 30);
                tableLayoutPanel4.Region = System.Drawing.Region.FromHrgn(ptr);
                DeleteObject(ptr);
            }
            catch
            {
                Console.WriteLine("Parameter is not valid");
            }
        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                System.IntPtr ptr = CreateRoundRectRgn(0, 0, tableLayoutPanel6.Width, tableLayoutPanel6.Height, 30, 30);
                tableLayoutPanel6.Region = System.Drawing.Region.FromHrgn(ptr);
                DeleteObject(ptr);
                //tableLayoutPanel6.Dispose();

            }
            catch
            {
                Console.WriteLine("Parameter is not valid");
            }
           
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                System.IntPtr ptr = CreateRoundRectRgn(0, 0, flowLayoutPanel2.Width, flowLayoutPanel2.Height, 30, 30);
                flowLayoutPanel2.Region = System.Drawing.Region.FromHrgn(ptr);
                //flowLayoutPanel1.Dispose();
                flowLayoutPanel2.BackColor = Color.FromArgb(80, Color.Black);
                DeleteObject(ptr);
            }
            catch
            {
                Console.WriteLine("parameter is not valid");
            }
        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                System.IntPtr ptr = CreateRoundRectRgn(0, 0, flowLayoutPanel3.Width, flowLayoutPanel3.Height, 30, 30);
                flowLayoutPanel3.Region = System.Drawing.Region.FromHrgn(ptr);
                //flowLayoutPanel1.Dispose();
                flowLayoutPanel3.BackColor = Color.FromArgb(80, Color.Black);
                DeleteObject(ptr);
            }
            catch
            {
                Console.WriteLine("parameter is not valid");
            }
        }

        private void tableLayoutPanel24_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                System.IntPtr ptr = CreateRoundRectRgn(0, 0, tableLayoutPanel24.Width, tableLayoutPanel24.Height, 30, 30);
                tableLayoutPanel24.Region = System.Drawing.Region.FromHrgn(ptr);
                //flowLayoutPanel1.Dispose();
                //tableLayoutPanel24.BackColor = Color.FromArgb(80, Color.Black);
                DeleteObject(ptr);
            }
            catch
            {
                Console.WriteLine("parameter is not valid");
            }
        }
        public int t15height;
        public int p2height;
        
        public int t10height;
        public int p1height;


        public int t17height;
        public int p3height;
        public int p4height;

        public int t20height;
        public int p5height;
        public int p6height;

        public int t22height;
        public int p8height;
        public int p7height;
        private void MLTool_Load(object sender, EventArgs e)
        {

            bunifuSlider1.Value = Convert.ToInt32(test.Text);
           // bunifuSlider2.Value = Convert.ToInt32(cycles.Text);
            // Utility.fitFormToScreen(this,  974, 1847); //1722, 982 1837, 1046
            // this.CenterToScreen();
            t15height = tableLayoutPanel15.Size.Height;
            t10height = tableLayoutPanel10.Size.Height;
            t17height = tableLayoutPanel17.Size.Height;
            t20height = tableLayoutPanel20.Size.Height;
            t22height = tableLayoutPanel22.Size.Height;

            p1height = IC.Size.Height;
            p2height = Perceptron.Size.Height;
            p3height = RFC.Size.Height;
            p4height = DTC.Size.Height;
            p5height = SGD.Size.Height;
            p6height = LinearRegression.Size.Height;
            p7height = RFR.Size.Height;
            p8height = DTR.Size.Height;

            try
            {
                SetDoubleBuffered(maintablelayout);
                SetDoubleBuffered(flowLayoutPanel1);
                SetDoubleBuffered(tableLayoutPanel1);
                SetDoubleBuffered(tableLayoutPanel3);
                SetDoubleBuffered(tableLayoutPanel4);
                SetDoubleBuffered(tableLayoutPanel6);
                SetDoubleBuffered(tableLayoutPanel11);
                SetDoubleBuffered(tableLayoutPanel28);
                SetDoubleBuffered(tableLayoutPanel12);
                SetDoubleBuffered(bunifuSlider1);
                SetDoubleBuffered(bunifuSlider2);
                SetDoubleBuffered(tableLayoutPanel7);
                SetDoubleBuffered(tableLayoutPanel8);
                SetDoubleBuffered(tableLayoutPanel2);
                SetDoubleBuffered(tableLayoutPanel27);
                SetDoubleBuffered(flowLayoutPanel2);
                SetDoubleBuffered(tableLayoutPanel5);
                SetDoubleBuffered(flowLayoutPanel3);
                SetDoubleBuffered(tableLayoutPanel9);
                SetDoubleBuffered(tableLayoutPanel10);
                SetDoubleBuffered(tableLayoutPanel13);
                SetDoubleBuffered(tableLayoutPanel14);
                SetDoubleBuffered(tableLayoutPanel15);
                SetDoubleBuffered(tableLayoutPanel16);
                SetDoubleBuffered(tableLayoutPanel17);
                SetDoubleBuffered(tableLayoutPanel18);
                SetDoubleBuffered(tableLayoutPanel19);
                SetDoubleBuffered(tableLayoutPanel20);
                SetDoubleBuffered(tableLayoutPanel21);
                SetDoubleBuffered(tableLayoutPanel22);
                SetDoubleBuffered(tableLayoutPanel23);
                SetDoubleBuffered(tableLayoutPanel27);
                SetDoubleBuffered(tableLayoutPanel24);
                SetDoubleBuffered(tableLayoutPanel25);
                SetDoubleBuffered(tableLayoutPanel26);

                SetDoubleBuffered(tableLayoutPanel29);

                SetDoubleBuffered(panel1);
                SetDoubleBuffered(panel2);
                SetDoubleBuffered(logo_panel);

            }
            catch
            {
                Console.WriteLine("ex");
            }
            // TransparetBackground(label16);
            //  panel1.BackColor = Color.FromArgb(80, Color.Black);
            //   label16.BackColor = panel1.BackColor;
            // TransparencyKey = label16.BackColor;
            //  label5.BackColor = Color.FromArgb(60, Color.Black);
            // label6.BackColor = Color.FromArgb(60, Color.Black);
            try
            {
                System.IntPtr ptr1 = CreateRoundRectRgn(0, 0, cycles.Width, cycles.Height, 10, 10); // _BoarderRaduis can be adjusted to your needs, try 15 to start.
                cycles.Region = System.Drawing.Region.FromHrgn(ptr1);
                DeleteObject(ptr1);
            }
            catch
            {
                Console.WriteLine("Parameter is not valid");
            }
        }

        public void cycle_texttoslider(object sender, EventArgs e)
        {
            
                if(String.IsNullOrEmpty(cycles.Text) || String.IsNullOrWhiteSpace(cycles.Text))
                {
                cycles.Text = "1";
                }
                else
                {
                    try
                    {
                        bunifuSlider2.Value = Convert.ToInt32(cycles.Text);
                    }
                    catch
                    {
                        Console.WriteLine("main format exception");
                    }
                }
            
        }
        public void exceed_cycles(object sender, EventArgs e)
        {
            //if(Convert.ToInt32(cycles.Text) > 20)
            //{
            //    MessageBox.Show("Increase in number of cycles, will increase your machine training time");
            //}
            //if (Convert.ToInt32(cycles.Text) > 50)
            //{
            //    cycles.Text = "50";
            //}
            //else
            //{
            //    Console.WriteLine("under 20");
            //}
        }
        

        public TextBox cycles = new TextBox();
        public void cycle_textbox()
        {

            try
            {
                cycles.Location = new Point(160, 0);
                cycles.BorderStyle = BorderStyle.None;

                cycles.Size = new System.Drawing.Size(40, 30);
                cycles.Text = "10";
                cycles.TabStop = false;
                cycles.Font = new System.Drawing.Font("Segoe UI", 10.0F, FontStyle.Regular);
                cycles.TextAlign = HorizontalAlignment.Center;
                panel2.Controls.Add(cycles);

                //if (cycles.Text == string.Empty)
                //{

                //}
                //else
                //{
                    cycles.TextChanged += new EventHandler(cycle_texttoslider);
                //}
                

                //cycles.TextChanged += new EventHandler(exceed_cycles);
                //cycles.TextChanged += new EventHandler(textbox_cursorhandle);
                
            }
            catch
            {
                Console.WriteLine("format exception");
            }
            
        }



        private void Browsebutton_Click_1(object sender, EventArgs e)
        {
            Test_Button.ActiveFillColor = SystemColors.ActiveCaption;
            Test_Button.ActiveLineColor = Color.White;
            Test_Button.IdleForecolor = Color.White;
            Test_Button.IdleLineColor = Color.White;
            Test_Button.IdleFillColor = SystemColors.ActiveCaption;

            output.Text = "";
            confusionmatbox.Image = null;
            traintime.Text = "";

            run.ActiveFillColor = SystemColors.ActiveCaption;
            run.ActiveLineColor = Color.White;
            run.IdleForecolor = Color.White;
            run.IdleLineColor = Color.White;
            run.IdleFillColor = SystemColors.ActiveCaption;


            tableLayoutPanel10.Height = t10height;
            IC.Height = p1height;

            tableLayoutPanel22.Height = t22height;
            RFR.Height = p7height;
            DTR.Height = p8height;

            tableLayoutPanel20.Height = t20height;
            LinearRegression.Height = p6height;
            SGD.Height = p5height;

            tableLayoutPanel15.Height = t15height;
            //tableLayoutPanel15.Update();
            Perceptron.Height = p2height;
            // pictureBox2.Update();

            tableLayoutPanel17.Height = t17height;
            //tableLayoutPanel17.Update();
            RFC.Height = p3height;
            //pictureBox3.Update();
            DTC.Height = p4height;

            choosealgo.Clear();
            Console.WriteLine("choosealgoclear1");
            //run.ActiveFillColor = Color.DodgerBlue;
            //run.ActiveLineColor = Color.DodgerBlue;
            //run.IdleForecolor = Color.DodgerBlue;
            //run.IdleLineColor = Color.DodgerBlue;

            ic_click = false;
            perceptron_click = false;
            rfc_click = false;
            dtc_click = false;
            linearregression_click = false;
            sgd_click = false;
            dtr_click = false;
            rfr_click = false;
            Console.WriteLine("minus 0");

            System.Windows.Forms.OpenFileDialog openfiledialog = new System.Windows.Forms.OpenFileDialog();
            openfiledialog.Filter = "Data files (*.csv, *.zip) |*.csv; *.zip";

            if (openfiledialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Console.WriteLine("minus 1");
                string[] pathproject = Directory.GetFiles(Application.StartupPath, "*.zip");
                foreach (string filename in pathproject)
                {
                    System.IO.File.Delete(filename);

                }

                string[] pathproject1 = Directory.GetFiles(Application.StartupPath, "*.csv");
                foreach (string filename in pathproject1)
                {
                    System.IO.File.Delete(filename);

                }
                features.Clear();
                labels.Clear();
                feat.Clear();


                input_panel1.Controls.Clear();
                output_panel1.Controls.Clear();

                datafilename = openfiledialog.FileName;
                Console.WriteLine("minus 2");
                ext = Path.GetExtension(openfiledialog.FileName);
                Console.WriteLine(openfiledialog.SafeFileName);
                var fileInfo = new FileInfo(datafilename);
                var size = (int)(Convert.ToDecimal(fileInfo.Length) / 1024) + 1;
                if(size > 500000)
                {
                    filename.Text = "";
                    MessageBox.Show("Max value of file is exceeding beyond 500 MB");
                    //string[] pathproject = Directory.GetFiles(Application.StartupPath, "*.zip");
                    foreach (string filename in pathproject)
                    {
                        System.IO.File.Delete(filename);

                    }

                    //string[] pathproject1 = Directory.GetFiles(Application.StartupPath, "*.csv");
                    foreach (string filename in pathproject1)
                    {
                        System.IO.File.Delete(filename);

                    }
                    features.Clear();
                    labels.Clear();
                    feat.Clear();


                    input_panel1.Controls.Clear();
                    output_panel1.Controls.Clear();
                   
                }
                else
                {
                   
                    if (ext == ".zip")
                    {
                        //using (ZipArchive zip = ZipFile.Open(datafilename, ZipArchiveMode.Read))
                        //{
                            
                        //    var listOfZipFolders = zip.Entries.Where(x => x.FullName.EndsWith("/")).ToList();
                        //    for (int i = 0; i < listOfZipFolders.Count; i++)
                        //    {
                        //        Console.WriteLine(listOfZipFolders[i]);
                        //        string folders = Convert.ToString(listOfZipFolders[i]);
                        //        var count = folders.Count(x => x == '/');
                        //        if (count > 1)
                        //        {
                        //            MessageBox.Show("zip file invalid");
                        //            break;
                        //        }
                        //        else
                        //        {
                        //            filename.Text = "Filename: " + openfiledialog.SafeFileName + " (" + size + " kb)";
                        //            System.IO.File.Copy(datafilename, Application.StartupPath + @"\" + openfiledialog.SafeFileName, true);
                        //            browsealgozip = true;
                        //            input_panel1.Enabled = false;
                        //            input_panel1.Controls.Clear();
                        //            //panel4.Enabled = false;
                        //            //label2.Enabled = false;
                        //            //panel5.Enabled = false;
                        //            output_panel1.Enabled = false;
                        //            output_panel1.Controls.Clear();
                        //            // label3.Enabled = false;
                        //            bunifuSlider2.Visible = true;
                        //            label22.Visible = true;
                        //            cycles.Visible = true;

                        //            bunifuSlider2.Value = Convert.ToInt32(cycles.Text);


                        //            label4.Enabled = true;
                        //            //bunifuCustomLabel1.Enabled = true;
                        //            // bunifuCustomLabel2.Enabled = true;
                        //            label5.Enabled = true;
                        //            label19.Enabled = true;

                        //            label6.ForeColor = Color.White;

                        //            label9.ForeColor = Color.DarkGray;
                        //            label13.ForeColor = Color.DarkGray;

                        //            IC.Image = Image.FromFile(Application.StartupPath + @"/icons/visual.png");
                        //            label7.ForeColor = Color.White;


                        //            LinearRegression.Image = Image.FromFile(Application.StartupPath + @"/icons/sgd.png");
                        //            LinearRegression.Image = SetAlpha((Bitmap)LinearRegression.Image, 60);
                        //            label15.ForeColor = Color.DarkGray;

                        //            SGD.Image = Image.FromFile(Application.StartupPath + @"/icons/sgd.png");
                        //            SGD.Image = SetAlpha((Bitmap)SGD.Image, 60);
                        //            label14.ForeColor = Color.DarkGray;

                        //            DTR.Image = Image.FromFile(Application.StartupPath + @"/icons/dtr.png");
                        //            DTR.Image = SetAlpha((Bitmap)DTR.Image, 60);
                        //            label18.ForeColor = Color.DarkGray;

                        //            RFR.Image = Image.FromFile(Application.StartupPath + @"/icons/rfr.png");
                        //            RFR.Image = SetAlpha((Bitmap)RFR.Image, 60);
                        //            label17.ForeColor = Color.DarkGray;

                        //            Perceptron.Image = Image.FromFile(Application.StartupPath + @"/icons/perceptron.png");
                        //            Perceptron.Image = SetAlpha((Bitmap)Perceptron.Image, 60);
                        //            label10.ForeColor = Color.DarkGray;

                        //            DTC.Image = Image.FromFile(Application.StartupPath + @"/icons/dtc.png");
                        //            DTC.Image = SetAlpha((Bitmap)DTC.Image, 60);
                        //            label11.ForeColor = Color.DarkGray;

                        //            RFC.Image = Image.FromFile(Application.StartupPath + @"/icons/rfc.png");
                        //            RFC.Image = SetAlpha((Bitmap)RFC.Image, 60);
                        //            label12.ForeColor = Color.DarkGray;



                        //            IC.Enabled = true;
                        //            Perceptron.Enabled = false;
                        //            DTC.Enabled = false;
                        //            RFC.Enabled = false;


                        //            LinearRegression.Enabled = false;
                        //            SGD.Enabled = false;
                        //            DTR.Enabled = false;
                        //            RFR.Enabled = false;
                        //            break;
                        //        }
                        //    }
                            
                        //}




                        filename.Text = "Filename: " + openfiledialog.SafeFileName + " (" + size + " kb)";
                        System.IO.File.Copy(datafilename, Application.StartupPath + @"\" + openfiledialog.SafeFileName, true);
                        browsealgozip = true;
                        input_panel1.Enabled = false;
                        input_panel1.Controls.Clear();
                        output_panel1.Enabled = false;
                        output_panel1.Controls.Clear();
                        bunifuSlider2.Visible = true;
                        label22.Visible = true;
                        cycles.Visible = true;

                        bunifuSlider2.Value = Convert.ToInt32(cycles.Text);


                        label4.Enabled = true;
                        label5.Enabled = true;
                        label19.Enabled = true;

                        label6.ForeColor = Color.White;

                        label9.ForeColor = Color.DarkGray;
                        label13.ForeColor = Color.DarkGray;

                        IC.Image = Image.FromFile(Application.StartupPath + @"/icons/visual.png");
                        label7.ForeColor = Color.White;


                        LinearRegression.Image = Image.FromFile(Application.StartupPath + @"/icons/sgd.png");
                        LinearRegression.Image = SetAlpha((Bitmap)LinearRegression.Image, 60);
                        label15.ForeColor = Color.DarkGray;

                        SGD.Image = Image.FromFile(Application.StartupPath + @"/icons/sgd.png");
                        SGD.Image = SetAlpha((Bitmap)SGD.Image, 60);
                        label14.ForeColor = Color.DarkGray;

                        DTR.Image = Image.FromFile(Application.StartupPath + @"/icons/dtr.png");
                        DTR.Image = SetAlpha((Bitmap)DTR.Image, 60);
                        label18.ForeColor = Color.DarkGray;

                        RFR.Image = Image.FromFile(Application.StartupPath + @"/icons/rfr.png");
                        RFR.Image = SetAlpha((Bitmap)RFR.Image, 60);
                        label17.ForeColor = Color.DarkGray;

                        Perceptron.Image = Image.FromFile(Application.StartupPath + @"/icons/perceptron.png");
                        Perceptron.Image = SetAlpha((Bitmap)Perceptron.Image, 60);
                        label10.ForeColor = Color.DarkGray;

                        DTC.Image = Image.FromFile(Application.StartupPath + @"/icons/dtc.png");
                        DTC.Image = SetAlpha((Bitmap)DTC.Image, 60);
                        label11.ForeColor = Color.DarkGray;

                        RFC.Image = Image.FromFile(Application.StartupPath + @"/icons/rfc.png");
                        RFC.Image = SetAlpha((Bitmap)RFC.Image, 60);
                        label12.ForeColor = Color.DarkGray;



                        IC.Enabled = true;
                        Perceptron.Enabled = false;
                        DTC.Enabled = false;
                        RFC.Enabled = false;


                        LinearRegression.Enabled = false;
                        SGD.Enabled = false;
                        DTR.Enabled = false;
                        RFR.Enabled = false;







                    }
                    else if (ext == ".csv")
                    {
                        //Console.WriteLine("first");
                        //bool go = true; 
                        //using (CsvReader csv = new CsvReader(new StreamReader(datafilename), true))
                        //{
                        //    int fieldCount = csv.FieldCount;
                        //    //Console.WriteLine(fieldCount);
                        //     string[] headers = csv.GetFieldHeaders();

                        //    while (csv.ReadNextRecord())
                        //    {
                        //        for (int i = 0; i < fieldCount; i++)
                        //        {
                                    
                        //            //Console.WriteLine(csv[algo]);
                        //            //choosealgo.Add(csv[algo]);
                        //            // Console.Write(string.Format("{0} = {1};", headers[i], csv[i]));
                        //            if(headers[i] == csv[i])
                        //            {
                        //                MessageBox.Show("File format not supported");
                        //                filename.Text = "";
                        //                openfiledialog.Dispose();
                        //                go = false;
                        //                break;
                        //            }
                                    
                        //            if (headers[i].All(char.IsLetter) || headers[i].All(char.IsLetterOrDigit))
                        //            {

                        //                if (headers[i].All(char.IsNumber))
                        //                {
                        //                    MessageBox.Show("File format not supported");
                        //                    filename.Text = "";
                        //                    openfiledialog.Dispose();
                        //                    go = false;
                        //                    break;
                        //                }
                        //                else
                        //                {
                        //                    Console.WriteLine(headers[i] + "    valid");
                        //                    go = true;
                        //                    Console.WriteLine("second");
                        //                }
                        //            }
                        //                //else
                        //                //    go = false;
                        //                //   break;
                        //                //if (headers[i].All(char.IsLetterOrDigit))
                        //                //{
                        //                //    //Console.WriteLine();
                        //                //    Console.WriteLine(headers[i] + "    alphanumeric");
                        //                //}
                                        
                                    
                                    
                        //        }
                        //        break;

                        //    }

                        //    csv.Dispose();


                        //}

                        







                       


                        //Perceptron.Image = SetAlpha((Bitmap)Perceptron.Image, 60);
                        //label10.ForeColor = Color.DarkGray;

                        //DTC.Image = SetAlpha((Bitmap)DTC.Image, 60);
                        //label11.ForeColor = Color.DarkGray;

                        //RFC.Image = SetAlpha((Bitmap)RFC.Image, 60);
                        //label12.ForeColor = Color.DarkGray;

                        //LinearRegression.Image = SetAlpha((Bitmap)LinearRegression.Image, 60);
                        //label15.ForeColor = Color.DarkGray;

                        //SGD.Image = SetAlpha((Bitmap)SGD.Image, 60);
                        //label14.ForeColor = Color.DarkGray;

                        //DTR.Image = SetAlpha((Bitmap)DTR.Image, 60);
                        //label18.ForeColor = Color.DarkGray;

                        //RFR.Image = SetAlpha((Bitmap)RFR.Image, 60);
                        //label17.ForeColor = Color.DarkGray;

                       // if(go == true)
                        ///{
                            Console.WriteLine("third");
                            System.IO.File.Copy(datafilename, Application.StartupPath + @"\" + openfiledialog.SafeFileName, true);
                            //browsealgocsv = true;
                            input_panel1.Enabled = true;
                            //panel4.Enabled = true;
                            //label2.Enabled = true;
                            //panel5.Enabled = true;
                            output_panel1.Enabled = true;


                            bunifuSlider1.Enabled = true;
                            label4.Enabled = true;
                            bunifuSlider2.Visible = false;
                            label22.Visible = false;
                            cycles.Visible = false;

                            //bunifuCustomLabel1.Enabled = true;
                            //bunifuCustomLabel2.Enabled = true;
                            label5.Enabled = true;
                            label19.Enabled = true;

                            label6.ForeColor = Color.DarkGray;
                            IC.Image = Image.FromFile(Application.StartupPath + @"/icons/visual.png");
                            IC.Image = SetAlpha((Bitmap)IC.Image, 60);
                            label7.ForeColor = Color.DarkGray;
                            try
                            {
                                Console.WriteLine("fourth");
                                filename.Text = "Filename: " + openfiledialog.SafeFileName + " (" + size + " kb)";
                                readcsvfile();
                                createcheckboxes();
                                createcheckboxes1();
                                Console.WriteLine("checkboxes2");

                                IC.Enabled = false;
                                Perceptron.Enabled = false;
                                DTC.Enabled = false;
                                RFC.Enabled = false;


                                LinearRegression.Enabled = false;
                                SGD.Enabled = false;
                                DTR.Enabled = false;
                                RFR.Enabled = false;
                                //go = true;
                            }
                            catch (System.IO.IOException ex)
                            {
                                filename.Text = "";
                                MessageBox.Show("The file is being used in another process");
                                Test_Button.ActiveFillColor = SystemColors.ActiveCaption;
                                Test_Button.ActiveLineColor = Color.White;
                                Test_Button.IdleForecolor = Color.White;
                                Test_Button.IdleLineColor = Color.White;
                                Test_Button.IdleFillColor = SystemColors.ActiveCaption;

                                output.Text = "";
                                confusionmatbox.Image = null;
                                traintime.Text = "";

                                run.ActiveFillColor = SystemColors.ActiveCaption;
                                run.ActiveLineColor = Color.White;
                                run.IdleForecolor = Color.White;
                                run.IdleLineColor = Color.White;
                                run.IdleFillColor = SystemColors.ActiveCaption;


                                tableLayoutPanel10.Height = t10height;
                                IC.Height = p1height;

                                tableLayoutPanel22.Height = t22height;
                                RFR.Height = p7height;
                                DTR.Height = p8height;

                                tableLayoutPanel20.Height = t20height;
                                LinearRegression.Height = p6height;
                                SGD.Height = p5height;

                                tableLayoutPanel15.Height = t15height;
                                //tableLayoutPanel15.Update();
                                Perceptron.Height = p2height;
                                // pictureBox2.Update();

                                tableLayoutPanel17.Height = t17height;
                                //tableLayoutPanel17.Update();
                                RFC.Height = p3height;
                                //pictureBox3.Update();
                                DTC.Height = p4height;

                                choosealgo.Clear();
                                Console.WriteLine("choosealgoclear2");

                                //go = true;

                            }
                            catch
                            {
                                Console.WriteLine("no data file selected");
                                //go = true;
                            }
                        //}
                        //else
                        //{
                        //    Console.WriteLine("not good");
                        //    openfiledialog.Dispose();
                        //}
                        //go = true;
                        //openfiledialog.Dispose();
                    }
                }
                
            }
            else
            {
                //MessageBox.Show("Select data file again");

               // bunifuSlider2.Visible = false;
               // label22.Visible = false;
               // cycles.Visible = false;
                //filename.Text = "";

               // label6.ForeColor = Color.DarkGray;

                

                if (ext == ".csv")
                {
                    label6.ForeColor = Color.DarkGray;
                    IC.Image = Image.FromFile(Application.StartupPath + @"/icons/visual.png");
                    IC.Image = SetAlpha((Bitmap)IC.Image, 60);
                    label7.ForeColor = Color.DarkGray;
                }
                else
                {
                    label9.ForeColor = Color.DarkGray;
                    label13.ForeColor = Color.DarkGray;
                    LinearRegression.Image = Image.FromFile(Application.StartupPath + @"/icons/sgd.png");
                    LinearRegression.Image = SetAlpha((Bitmap)LinearRegression.Image, 60);
                    label15.ForeColor = Color.DarkGray;

                    SGD.Image = Image.FromFile(Application.StartupPath + @"/icons/sgd.png");
                    SGD.Image = SetAlpha((Bitmap)SGD.Image, 60);
                    label14.ForeColor = Color.DarkGray;

                    DTR.Image = Image.FromFile(Application.StartupPath + @"/icons/dtr.png");
                    DTR.Image = SetAlpha((Bitmap)DTR.Image, 60);
                    label18.ForeColor = Color.DarkGray;

                    RFR.Image = Image.FromFile(Application.StartupPath + @"/icons/rfr.png");
                    RFR.Image = SetAlpha((Bitmap)RFR.Image, 60);
                    label17.ForeColor = Color.DarkGray;

                    Perceptron.Image = Image.FromFile(Application.StartupPath + @"/icons/perceptron.png");
                    Perceptron.Image = SetAlpha((Bitmap)Perceptron.Image, 60);
                    label10.ForeColor = Color.DarkGray;

                    DTC.Image = Image.FromFile(Application.StartupPath + @"/icons/dtc.png");
                    DTC.Image = SetAlpha((Bitmap)DTC.Image, 60);
                    label11.ForeColor = Color.DarkGray;

                    RFC.Image = Image.FromFile(Application.StartupPath + @"/icons/rfc.png");
                    RFC.Image = SetAlpha((Bitmap)RFC.Image, 60);
                    label12.ForeColor = Color.DarkGray;
                }


                Test_Button.ActiveFillColor = SystemColors.ActiveCaption;
                Test_Button.ActiveLineColor = Color.White;
                Test_Button.IdleForecolor = Color.White;
                Test_Button.IdleLineColor = Color.White;
                Test_Button.IdleFillColor = SystemColors.ActiveCaption;

                output.Text = "";
                confusionmatbox.Image = null;
                traintime.Text = "";

                run.ActiveFillColor = SystemColors.ActiveCaption;
                run.ActiveLineColor = Color.White;
                run.IdleForecolor = Color.White;
                run.IdleLineColor = Color.White;
                run.IdleFillColor = SystemColors.ActiveCaption;

                tableLayoutPanel22.Height = t22height;
                RFR.Height = p7height;
                DTR.Height = p8height;

                tableLayoutPanel20.Height = t20height;
                LinearRegression.Height = p6height;
                SGD.Height = p5height;

                tableLayoutPanel15.Height = t15height;
                //tableLayoutPanel15.Update();
                Perceptron.Height = p2height;
                // pictureBox2.Update();

                tableLayoutPanel17.Height = t17height;
                //tableLayoutPanel17.Update();
                RFC.Height = p3height;
                //pictureBox3.Update();
                DTC.Height = p4height;
            }
            openfiledialog.Dispose();
        }

        private void IC_Click1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        static Bitmap SetAlpha(Bitmap bmpIn, int alpha)
        {
            Bitmap bmpOut = new Bitmap(bmpIn.Width, bmpIn.Height);
            float a = alpha / 255f;
            Rectangle r = new Rectangle(0, 0, bmpIn.Width, bmpIn.Height);

            float[][] matrixItems = {
        new float[] {1, 0, 0, 0, 0},
        new float[] {0, 1, 0, 0, 0},
        new float[] {0, 0, 1, 0, 0},
        new float[] {0, 0, 0, a, 0},
        new float[] {0, 0, 0, 0, 1}};

            ColorMatrix colorMatrix = new ColorMatrix(matrixItems);

            ImageAttributes imageAtt = new ImageAttributes();
            imageAtt.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            using (Graphics g = Graphics.FromImage(bmpOut))
                g.DrawImage(bmpIn, r, r.X, r.Y, r.Width, r.Height, GraphicsUnit.Pixel, imageAtt);

            return bmpOut;
        }

        // public class TableLayoutCellPaintEventArgs : System.Windows.Forms.PaintEventArgs;
        public void create_OLS()
        {
            float split = Convert.ToInt32(test.Text);
            // "\"" + String.Join(",", features.ToArray()) + "\""
            string default_OLS = @"import pickle
import sys
import getopt
import numpy as np
import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LinearRegression
from sklearn.metrics import mean_squared_error

def main(argv):
    datafile = r" + "\"" + datafilename + "\"" + @"
    inputs = []
    outputs = []
    mapping = {}
   
    inputs.append(" + "\"" + String.Join(",", features.ToArray()) + "\"" + @")
    outputs.append(" + "\"" + String.Join(",", labels.ToArray()) + "\"" + @")
    test_size = " + split / 100 + @"
    
    df = pd.read_csv(datafile)
    df = df.dropna()
    do = df[outputs]
    connected = True
    
    while connected:
        try:
            X_train, X_test, y_train, y_test = train_test_split(df[inputs[0].split(',')], do, test_size = float(test_size))
            lr = LinearRegression()
            lr_model = lr.fit(X_train, y_train)
            break
        except ValueError as e:
            if(""could not convert string to float: ""== str(e)[:35]):
                stringname = str(e)[35:]
                first = stringname[1:]
                df1 = df[inputs[0].split(',')]
                tt = df1.apply(lambda x: x.astype(str).str.startswith(first[:-1]).any()).idxmax()
                cnt = 0
                for i in df[tt].unique():
                    mapping[i] = cnt
                    cnt = cnt + 1
                df[tt] = df[tt].apply(lambda x: mapping[x])
                #f = open(r""stringfeatures.txt"",""a"")
                #f.write(tt)
                #f.write("","")
                df = df[inputs[0].split(',')]
    #f.close()
    print(""Accuracy: "", round(lr.score(X_test, y_test) * 100, 2))

    pkl_filename =""LinearRegression.pkl""
    with open(pkl_filename,'wb') as file:
        pickle.dump(lr_model, file)

if __name__ == ""__main__"":
    main(sys.argv[1:])";

            string from = Application.StartupPath + "/LinearRegression.py";
            using (StreamWriter file = new StreamWriter(from))
            {

                file.WriteLine(default_OLS);
                file.Dispose();
            }

        }


        public void create_SGD()
        {
            float split = Convert.ToInt32(test.Text);

            string default_sgd = @"import pickle
import sys
import getopt
import numpy as np
import pandas as pd
from sklearn import linear_model
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LinearRegression
from sklearn.metrics import mean_squared_error

def main(argv):
    datafile = r" + "\"" + datafilename + "\"" + @"
    inputs = []
    outputs = []
    mapping = {}

    inputs.append("+ "\"" + String.Join(",", features.ToArray()) + "\"" + @")
    outputs.append("+ "\"" + String.Join(",", labels.ToArray()) + "\"" + @")
    test_size = " + split/100 +@"
        
    df = pd.read_csv(datafile)
    df = df.dropna()
    do = df[outputs]
    connected = True
    
    while connected:
        try:
            X_train, X_test, y_train, y_test = train_test_split(df[inputs[0].split(',')], do, test_size = float(test_size))
            sgd = linear_model.SGDRegressor(max_iter = 1000, tol = 1e-3)
            sgd_model = sgd.fit(X_train, np.ravel(y_train))
            break
        except ValueError as e:
            if(""could not convert string to float: ""== str(e)[:35]):
                stringname = str(e)[35:]
                first = stringname[1:]
                df1 = df[inputs[0].split(',')]
                tt = df1.apply(lambda x: x.astype(str).str.startswith(first[:-1]).any()).idxmax()
                cnt = 0
                for i in df[tt].unique():
                    mapping[i] = cnt
                    cnt = cnt + 1
                df[tt] = df[tt].apply(lambda x: mapping[x])
                df = df[inputs[0].split(',')]
    print(""Accuracy: "", round(sgd.score(X_test, y_test) * 100, 2))

    pkl_filename = ""SGD.pkl""
    with open(pkl_filename,'wb') as file:
        pickle.dump(sgd_model, file)

if __name__ == ""__main__"":
    main(sys.argv[1:])";



            string from = Application.StartupPath + "/SGD.py";
            using (StreamWriter file = new StreamWriter(from))
            {

                file.WriteLine(default_sgd);
                file.Dispose();
            }
        }

        public void create_DTR()
        {
            float split = Convert.ToInt32(test.Text);
            string default_dtr = @"import pickle
import sys
import getopt
import numpy as np
import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.tree import DecisionTreeRegressor
from sklearn.metrics import mean_squared_error

def main(argv):
    datafile = r" + "\"" + datafilename + "\"" + @"
    inputs = []
    outputs = []
    mapping={}

    inputs.append("+ "\"" + String.Join(",", features.ToArray()) + "\"" + @")
    outputs.append("+ "\"" + String.Join(",", labels.ToArray()) + "\"" + @")
    test_size = "+ split/100 +@"

    df = pd.read_csv(datafile)
    df = df.dropna()
    

    do = df[outputs]
    connected = True
    
    while connected:
        try:
            X_train, X_test, y_train, y_test = train_test_split(df[inputs[0].split(',')], do, test_size = float(test_size))
            dr = DecisionTreeRegressor()
            dr_model = dr.fit(X_train, y_train)
            break
        except ValueError as e:
            if(""could not convert string to float: ""== str(e)[:35]):
                stringname = str(e)[35:]
                first = stringname[1:]
                df1 = df[inputs[0].split(',')]
                tt = df1.apply(lambda x: x.astype(str).str.startswith(first[:-1]).any()).idxmax()
                cnt = 0
                for i in df[tt].unique():
                    mapping[i] = cnt
                    cnt = cnt + 1
                df[tt] = df[tt].apply(lambda x: mapping[x])
                df = df[inputs[0].split(',')]
    print(""Accuracy: "", round(dr.score(X_test, y_test) * 100, 2))

    pkl_filename = ""DTR.pkl""
    with open(pkl_filename,'wb') as file:
        pickle.dump(dr_model, file)

if __name__ == ""__main__"":
    main(sys.argv[1:])";

            string from = Application.StartupPath + "/DTR.py";
            using (StreamWriter file = new StreamWriter(from))
            {

                file.WriteLine(default_dtr);
                //file.Close();
                file.Dispose();
            }
        }


        public void create_RFR()
        {
            float split = Convert.ToInt32(test.Text);
            String default_rfr = @"import pickle
import sys
import getopt
import numpy as np
import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.ensemble import RandomForestRegressor
from sklearn.metrics import mean_squared_error

def main(argv):
    datafile = r" + "\"" + datafilename + "\"" + @"
    inputs = []
    outputs = []
    mapping = {}
   
    inputs.append(" + "\"" + String.Join(",", features.ToArray()) + "\"" + @")
    outputs.append(" + "\"" + String.Join(",", labels.ToArray()) + "\"" + @")
    test_size = "+ split/100 +@"
       

    df = pd.read_csv(datafile)
    df = df.dropna()
    
    do = df[outputs]
    connected = True
    
    while connected:
        try:
            X_train, X_test, y_train, y_test = train_test_split(df[inputs[0].split(',')], do, test_size = float(test_size))
            rf = RandomForestRegressor(n_estimators = 100)
            rf_model = rf.fit(X_train, np.array(y_train).ravel())
            break
        except ValueError as e:
            if(""could not convert string to float: ""== str(e)[:35]):
                stringname = str(e)[35:]
                first = stringname[1:]
                df1 = df[inputs[0].split(',')]
                tt = df1.apply(lambda x: x.astype(str).str.startswith(first[:-1]).any()).idxmax()
                cnt = 0
                for i in df[tt].unique():
                    mapping[i] = cnt
                    cnt = cnt + 1
                df[tt] = df[tt].apply(lambda x: mapping[x])
                df = df[inputs[0].split(',')]

    print(""Accuracy: "", round(rf.score(X_test, y_test) * 100, 2))

    pkl_filename = ""RFR.pkl""
    with open(pkl_filename,'wb') as file:
        pickle.dump(rf_model, file)

if __name__ == ""__main__"":
    main(sys.argv[1:])";


            string from = Application.StartupPath + "/RFR.py";
            using (StreamWriter file = new StreamWriter(from))
            {

                file.WriteLine(default_rfr);
                file.Dispose();
            }
        }

        public void create_Perceptron()
        {
            float split = Convert.ToInt32(test.Text);
            string default_per = @"import pickle
import sys
import getopt
import numpy as np
import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.linear_model import Perceptron
from sklearn.metrics import confusion_matrix
import matplotlib.pyplot as plt
import seaborn as sb

def main(argv):
    datafile = r" + "\"" + datafilename + "\"" + @"
    inputs = []
    outputs = []
    mapping = {}
    
    inputs.append("+ "\"" + String.Join(",", features.ToArray()) + "\"" + @")
    outputs.append("+ "\"" + String.Join(",", labels.ToArray()) + "\"" + @")
    test_size = "+ split/100 +@"
        

    df = pd.read_csv(datafile)
    df = df.dropna()
    do = df[outputs]
    connected = True
    
    while connected:
        try:
            X_train, X_test, y_train, y_test = train_test_split(df[inputs[0].split(',')], do, test_size = float(test_size))
            per = Perceptron(max_iter = 500, tol = 1e-3)
            per_model = per.fit(X_train, np.array(y_train).ravel())
            break
        except ValueError as e:
            if(""could not convert string to float: ""== str(e)[:35]):
                stringname = str(e)[35:]
                first = stringname[1:]
                df1 = df[inputs[0].split(',')]
                tt = df1.apply(lambda x: x.astype(str).str.startswith(first[:-1]).any()).idxmax()
                cnt = 0
                for i in df[tt].unique():
                    mapping[i] = cnt
                    cnt = cnt + 1
                df[tt] = df[tt].apply(lambda x: mapping[x])
                df = df[inputs[0].split(',')]

    print(""Accuracy: "", round(per.score(X_test, y_test) * 100, 2))
    fig, ax = plt.subplots()
    sb.set(font_scale = 1.4)
    matimage = sb.heatmap(confusion_matrix(y_test, per_model.predict(X_test)), annot = True, cmap = ""Blues"", ax=ax)
    label_font = {'size':'15'}
    ax.set_yticklabels(np.unique(y_test), va = 'center', fontdict = label_font, rotation = 45)
    ax.set_xticklabels(np.unique(y_test), ha = 'center', fontdict = label_font, rotation = 45)
    fig = matimage.get_figure()
    fig.savefig('Perceptron_confusion.png',bbox_inches = 'tight', dpi = 400)
    pkl_filename = ""Perceptron.pkl""
    with open(pkl_filename,'wb') as file:
        pickle.dump(per_model, file)

if __name__ == ""__main__"":
    main(sys.argv[1:])";

            string from = Application.StartupPath + "/Perceptron.py";
            using (StreamWriter file = new StreamWriter(from))
            {

                file.WriteLine(default_per);
                file.Dispose();
            }
        }


        public void create_DTC()
        {

            float split = Convert.ToInt32(test.Text);
            // "\"" + String.Join(",", features.ToArray()) + "\""
            // "\""  + datafilename + "\"" 
            string default_dtc = @"import pickle
import sys
import getopt
import numpy as np
import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.tree import DecisionTreeClassifier
from sklearn.metrics import confusion_matrix
import seaborn as sb
import matplotlib.pyplot as plt


def main(argv):
    datafile = r" + "\"" + datafilename + "\"" + @"
    inputs = []
    outputs = []
    mapping = {}


    inputs.append(" + "\"" + String.Join(",", features.ToArray()) + "\"" + @")
    outputs.append(" + "\"" + String.Join(",", labels.ToArray()) + "\"" + @")
    test_size = " + split / 100 + @"

    df = pd.read_csv(datafile)
    df = df.dropna()
    do = df[outputs]
    connected = True
    
    while connected:
        try:
            X_train, X_test, y_train, y_test = train_test_split(df[inputs[0].split(',')], do, test_size = float(test_size))
            dc = DecisionTreeClassifier()
            dc_model = dc.fit(X_train, np.array(y_train).ravel())
            break
        except ValueError as e:
            if(""could not convert string to float: ""== str(e)[:35]):
                stringname = str(e)[35:]
                first = stringname[1:]
                df1 = df[inputs[0].split(',')]
                tt = df1.apply(lambda x: x.astype(str).str.startswith(first[:-1]).any()).idxmax()
                cnt = 0
                for i in df[tt].unique():
                    mapping[i] = cnt
                    cnt = cnt + 1
                df[tt] = df[tt].apply(lambda x: mapping[x])
                df = df[inputs[0].split(',')]

    print(""Accuracy: "", round(dc.score(X_test, y_test) * 100, 2))

    fig, ax = plt.subplots()
    sb.set(font_scale = 1.4)
    matimage = sb.heatmap(confusion_matrix(y_test, dc_model.predict(X_test)), annot = True, cmap = ""Blues"", ax=ax)
    label_font = {'size':'15'}
    ax.set_yticklabels(np.unique(y_test), va = 'center', fontdict = label_font, rotation = 45)
    ax.set_xticklabels(np.unique(y_test), ha = 'center', fontdict = label_font, rotation = 45)
    fig = matimage.get_figure()
    fig.savefig('DTC_confusion.png',bbox_inches = 'tight', dpi = 400)

    pkl_filename = ""DTC.pkl""
    with open(pkl_filename,'wb') as file:
        pickle.dump(dc_model, file)

if __name__ == ""__main__"":
    main(sys.argv[1:])";

            string from = Application.StartupPath + "/DTC.py";
            using (StreamWriter file = new StreamWriter(from))
            {

                file.WriteLine(default_dtc);
                file.Dispose();
            }
        }

        public void create_RFC()
        {
            float split = Convert.ToInt32(test.Text);
            string default_RFC = @"import pickle
import sys
import getopt
import numpy as np
import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.ensemble import RandomForestClassifier
from sklearn.metrics import confusion_matrix
import matplotlib.pyplot as plt
import seaborn as sb

def main(argv):
    datafile = r" + "\"" + datafilename + "\"" + @"
    inputs = []
    outputs = []
    mapping = {}

    inputs.append("+ "\"" + String.Join(",", features.ToArray()) + "\"" + @")
    outputs.append(" + "\"" + String.Join(",", labels.ToArray()) + "\"" + @")
    test_size =" + split/100 + @" 

    df = pd.read_csv(datafile)
    df = df.dropna()
    do = df[outputs]
    connected = True
    
    while connected:
        try:
            X_train, X_test, y_train, y_test = train_test_split(df[inputs[0].split(',')], do, test_size = float(test_size))
            rfc = RandomForestClassifier(n_estimators = 1000)
            rfc_model = rfc.fit(X_train, np.array(y_train).ravel())
            break
        except ValueError as e:
            if(""could not convert string to float: ""== str(e)[:35]):
                stringname = str(e)[35:]
                first = stringname[1:]
                df1 = df[inputs[0].split(',')]
                tt = df1.apply(lambda x: x.astype(str).str.startswith(first[:-1]).any()).idxmax()
                cnt = 0
                for i in df[tt].unique():
                    mapping[i] = cnt
                    cnt = cnt + 1
                df[tt] = df[tt].apply(lambda x: mapping[x])
                df = df[inputs[0].split(',')]
    print(""Accuracy: "", round(rfc.score(X_test, y_test) * 100, 2))
    fig, ax = plt.subplots()
    sb.set(font_scale = 1.4)
    matimage = sb.heatmap(confusion_matrix(y_test, rfc_model.predict(X_test)), annot = True, cmap = ""Blues"", ax=ax)
    label_font = {'size':'15'}
    ax.set_yticklabels(np.unique(y_test), va = 'center', fontdict = label_font, rotation = 45)
    ax.set_xticklabels(np.unique(y_test), ha = 'center', fontdict = label_font, rotation = 45)
    fig = matimage.get_figure()
    fig.savefig('RFC_confusion.png',bbox_inches = 'tight', dpi = 400)
    pkl_filename = ""RFC.pkl""
    with open(pkl_filename,'wb') as file:
        pickle.dump(rfc_model, file)

if __name__ == ""__main__"":
    main(sys.argv[1:])";

            string from = Application.StartupPath + "/RFC.py";
            using (StreamWriter file = new StreamWriter(from))
            {

                file.WriteLine(default_RFC);
                file.Dispose();
            }
        }

        public void create_IC()
        {
            float split = Convert.ToInt32(test.Text);
            int cycles1 = Convert.ToInt32(cycles.Text);
            
            
            string default_IC = @"import zipfile 
import os
from distutils.dir_util import copy_tree
import numpy as np
import pandas as pd 
from keras.preprocessing.image import ImageDataGenerator, load_img
from keras.utils import to_categorical
from sklearn.model_selection import train_test_split
import matplotlib.pyplot as plt
import random
from keras.models import Sequential
from keras.layers import Conv2D, MaxPooling2D, Dropout, Flatten, Dense, Activation, BatchNormalization
from keras.callbacks import EarlyStopping, ReduceLROnPlateau
from keras.models import load_model
from keras.preprocessing import image
import shutil
import tensorflow as tf
from PIL import Image
from sklearn.utils import shuffle
from keras.utils import np_utils
import cv2
from keras.backend import manual_variable_initialization 


list1=[]
destpath = """"
copypath = """"
os.mkdir(r""" + Application.StartupPath + @"\root"")
os.mkdir(r""" + Application.StartupPath + @"\root\mix"")
path = r""" + Application.StartupPath + @"\root\mix""
categories = []
IMAGE_WIDTH = 30
IMAGE_HEIGHT = 30
num_pixels = IMAGE_WIDTH * IMAGE_HEIGHT

for root_fol, directory_fol, files in os.walk(r'"+Application.StartupPath + @"') : 
        for file in files : 
            if file.endswith('.zip'):
                zzip = zipfile.ZipFile(r'"+ Application.StartupPath + @"' + '\\' + file)
                zzip.extractall(r'" + Application.StartupPath + @"\root')
                zzip.close()


for root, dirs, files in os.walk(r""" + Application.StartupPath + @"\root"", topdown = False):
    for name in dirs:
        list1.append(os.path.basename(os.path.join(root, name)))

cnt = 0
for root, dirs, files in os.walk(r""" + Application.StartupPath + @"\root""):
    for name in dirs:
        destpath = os.path.basename(os.path.join(root, name))
        if name != 'mix':
            for images in os.listdir(os.path.join(root, name)):
                cnt = cnt + 1
                copypath = ""./root/mix/"" + destpath + ""."" + str(cnt) + "".jpg""
                os.rename(os.path.join(root, name) + ""\\"" + images, copypath)



try:
    manual_variable_initialization(True)
    input_data = []
    output_data = []
    for root, dirs, files in os.walk(path, topdown = False):
        for name in files:
            img = cv2.resize(cv2.imread(path + ""/"" + name), (IMAGE_WIDTH, IMAGE_HEIGHT))
            if len(img.shape) == 3:
                IMAGE_CHANNELS = len(img.shape)
            input_data.append(img)
            category = name.split('.')[0]
            if category in list1:
                output_data.append(list1.index(category))

    inputs = np.asarray(input_data)
    outputs = np.asarray(output_data)

    X_train, X_test, Y_train, Y_test = train_test_split(inputs, outputs, test_size = " + split/100 + @")
    X_train = X_train.reshape(X_train.shape[0], IMAGE_WIDTH, IMAGE_HEIGHT, IMAGE_CHANNELS)
    X_test = X_test.reshape(X_test.shape[0], IMAGE_WIDTH, IMAGE_HEIGHT, IMAGE_CHANNELS)

    Y_train = np_utils.to_categorical(Y_train)
    Y_test = np_utils.to_categorical(Y_test)

    X_train = X_train.astype('float64')
    X_test = X_test.astype('float64')
    X_train = X_train / 255
    X_test = X_test / 255

    model = Sequential()
    model.add(Conv2D(28, kernel_size = (3, 3), input_shape = (IMAGE_WIDTH, IMAGE_HEIGHT, IMAGE_CHANNELS)))
    model.add(MaxPooling2D(pool_size = (2, 2)))
    model.add(Flatten()) # Flattening the 2D arrays for fully connected layers
    model.add(Dense(128, activation = 'relu'))
    model.add(Dropout(0.2))
    model.add(Dense(len(list1[:-1]), activation = 'softmax'))
    model.compile(optimizer = 'adam',
                loss = 'categorical_crossentropy',
                metrics =['accuracy'])

    model.summary()

    history = model.fit(x = X_train, y = Y_train, epochs = " + cycles1 + @")

except ValueError:
    manual_variable_initialization(True)
    input_data = []
    output_data = []
    for root, dirs, files in os.walk(path, topdown = False):
        for name in files:
            img = cv2.resize(cv2.imread(path + ""/"" + name), (IMAGE_WIDTH, IMAGE_HEIGHT))
            if len(img.shape) == 3:
                IMAGE_CHANNELS = len(img.shape)
            input_data.append(img)
            category = name.split('.')[0]
            if category in list1:
                output_data.append(list1.index(category))

    inputs = np.asarray(input_data)
    outputs = np.asarray(output_data)

    X_train, X_test, Y_train, Y_test = train_test_split(inputs, outputs, test_size = " + split / 100 + @")
    X_train = X_train.reshape(X_train.shape[0], IMAGE_WIDTH, IMAGE_HEIGHT, IMAGE_CHANNELS)
    X_test = X_test.reshape(X_test.shape[0], IMAGE_WIDTH, IMAGE_HEIGHT, IMAGE_CHANNELS)

    Y_train = np_utils.to_categorical(Y_train - 1)
    Y_test = np_utils.to_categorical(Y_test - 1)

    X_train = X_train.astype('float32')
    X_test = X_test.astype('float32')
    X_train = X_train / 255
    X_test = X_test / 255

    model = Sequential()
    model.add(Conv2D(28, kernel_size = (3, 3), input_shape = (IMAGE_WIDTH, IMAGE_HEIGHT, IMAGE_CHANNELS)))
    model.add(MaxPooling2D(pool_size = (2, 2)))
    model.add(Flatten()) # Flattening the 2D arrays for fully connected layers
    model.add(Dense(128, activation = 'relu'))
    model.add(Dropout(0.2))
    model.add(Dense(len(list1[:-1]), activation = 'softmax'))
    model.compile(optimizer = 'adam',
                loss = 'categorical_crossentropy',
                metrics =['accuracy'])

    model.summary()

    history = model.fit(x = X_train, y = Y_train, epochs =" + cycles1 + @")

count = 1
print(""model_accuracy"")
for i in history.history['accuracy']:
    if(count==" + cycles1 + @"):
        print(""Cycle: "" + str(count), ""  "", ""Accuracy: "", round(i * 100, 0))
        break
    print(""Cycle: "" + str(count), ""   "", ""Accuracy: "", round(i * 100, 0))
    count = count + 1

model.save_weights(""cnn.h5"")

with open('cnn.json', 'w') as f:
    f.write(model.to_json())
    f.close()";

            string from = Application.StartupPath + "/IC.py";
            using (StreamWriter file = new StreamWriter(from))
            {

                file.WriteLine(default_IC);
                file.Dispose();
            }
        }


        public void create_pdfreport()
        {
            string default_pdf = @"from docx import Document
from docx.enum.text import WD_UNDERLINE
import time
import os
import sys
import comtypes.client
import glob


wordpath           = r'Documents'
pdfpath            = r'Pdfs'
outputdata = """"


txtfile = open(r""" + Application.StartupPath + @"/Outputhistory.txt" + @""",'r')
outputdata = txtfile.read()
txtfile.close()


def ReplacePrefix(document, prefixdata, toreplace):
    for paragraph in document.paragraphs:
        if toreplace in paragraph.text:
            inline = paragraph.runs
            for i in range(len(inline)):
                if toreplace in inline[i].text:
                    text = inline[i].text.replace(toreplace, ""{0}"".format(prefixdata))
                    inline[i].text = text

os.mkdir(os.path.abspath(wordpath))
os.mkdir(os.path.abspath(pdfpath))

document = Document(r""" + Application.StartupPath + @"/Eduvance_ML_report.docx" + @""")

ReplacePrefix(document, outputdata, ""!!"")

temppath = r""./Documents/ML.docx""
document.save(temppath)
time.sleep(2)

wdFormatPDF = 17
try:
    infile = (glob.glob(""%s\\*.docx"" % (wordpath)))
    word = comtypes.client.CreateObject('word.Application')
    for in_file in infile: 
        out_file = os.path.abspath(r""./Pdfs/ML_report.pdf"")
        doc = word.Documents.Open(os.path.abspath(in_file))
        doc.SaveAs(out_file, FileFormat = wdFormatPDF)
        doc.Close()
        print(""{0} file done"".format(in_file))
    word.Quit()
    time.sleep(2)
except Exception as e:
    print(e)
    doc.Close()
    word.Quit()";

            string from = Application.StartupPath + "/txttopdf.py";
            using (StreamWriter file = new StreamWriter(from))
            {

                file.WriteLine(default_pdf);
                file.Dispose();
            }
        }
        public void create_libinstall()
        { //pypath.Substring(0, 54) + @"Scripts\pip3.6.exe" +

            Console.WriteLine(pippath);
            string default_install = @"import os 
os.system(r" +"\""+ @pippath + @"Scripts/pip3.6.exe" + @" install python-docx==0.8.10 comtypes numpy matplotlib pandas sklearn seaborn tensorflow==2.0 keras pillow==7.1.0 opencv-python==4.2.0.34" + "\""+")";
            Console.WriteLine(default_install);
            string from = Application.StartupPath + "/Libinstall.py";
            using (StreamWriter file = new StreamWriter(from))
            {

                file.WriteLine(default_install);
                file.Dispose();
            }
        }
    }
}

   