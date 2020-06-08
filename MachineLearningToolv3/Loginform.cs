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
//using SoftwareLocker;
using System.Security.Authentication.ExtendedProtection;
using System.IO.Compression;
using Newtonsoft.Json.Linq;

namespace MachineLearningToolv3
{
    public partial class Loginform : Form
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

        public Loginform()
        {
            InitializeComponent();
            loginerror.Text = "";
            
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


        public string json;
        public string pathlog = Environment.GetEnvironmentVariable("windir") + @"\locred.dat";
       // public bool yes;
        public void logincredentials()
        {

            Console.WriteLine(pathlog);

            if(CheckForInternetConnection() == true)
            {
                try
                {
                    try
                    {
                        ManagementObjectSearcher searcher =
                            new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");

                        foreach (ManagementObject queryObj in searcher.Get())
                        {
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Win32_Processor instance");
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Architecture: {0}", queryObj["Architecture"]);
                            Console.WriteLine("Caption: {0}", queryObj["Caption"]);
                            Console.WriteLine("Family: {0}", queryObj["Family"]);
                            Console.WriteLine("ProcessorId: {0}", queryObj["ProcessorId"]);

                            json = @"{""username"":" + "\"" + usernameans.Text + "\"" + "," + @"""password"":" + "\"" + passwordans.Text + "\"" + "," + @"""hw_id"":" + "\"" + Convert.ToString(queryObj["ProcessorId"]) + Convert.ToString(queryObj["Family"]) + Convert.ToString(queryObj["Architecture"]) + "\"" + "}";
                        }


                        // json = @"{ ""username"":""vinay"",""password"":""test@123"",""hw_id"":""BFEBFBFF000906EA2059""}";
                        //""vinay"",""password"": ""test@123"",""hw_id"": ""2""}
                        Console.WriteLine(json);
                        MyWebRequest myRequest = new MyWebRequest("http://173.82.227.236:8014/sign-in/", "POST", json);
                    
                        loginerror.Text = "";
                        

                        
                        //if(Convert.ToString(myRequest.GetResponse()) == "OK")
                        //{
                            loginbutton.ActiveFillColor = Color.Green;
                            loginbutton.ActiveLineColor = Color.White;
                            loginbutton.IdleForecolor = Color.White;
                            loginbutton.IdleLineColor = Color.White;
                            loginbutton.IdleFillColor = Color.Green;
                        //}

                        Console.WriteLine(myRequest.GetResponse());

                        Console.WriteLine(myRequest.GetResponse().GetType());

                        




                        //Console.WriteLine();



                        //var stream = myRequest.GetResponse();
                        //using (StreamWriter file = new StreamWriter(pathlog))
                        //{

                        //    file.WriteLine(myRequest.GetResponse());
                        //    file.Dispose();
                        //}
                        //string content = string.Empty;

                        //using (var reader = new StreamReader(stream ?? new MemoryStream(), Convert.ToBoolean(Encoding.UTF8)))
                        //    content = reader.ReadToEnd();

                        //// write to file on desktop
                        // File.WriteAllText(
                        //    pathlog,
                        //    content,
                        //    Encoding.UTF8);

                        //Console.WriteLine("done");



                        //var current = Process.GetCurrentProcess();
                        //    Process.GetProcessesByName(current.ProcessName)
                        //        .Where(t => t.Id != current.Id)
                        //        .ToList()
                        //        .ForEach(t => t.Kill());

                        //    current.Kill();

                        //    Application.Exit();
                        FileReadWrite.WriteFile(Environment.GetEnvironmentVariable("windir") + @"/locredo.dat", json);
                        this.DialogResult = DialogResult.OK;
                        this.Close();


                    }
                    catch (ManagementException e)
                    {
                        MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
                    }


                }
                catch (Exception e)
                {
                    
                    Console.WriteLine("**********");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("**********");
                    if (e.Message == "Stream was not readable.")
                    {
                        //yes = true;
                        loginbutton.ActiveFillColor = Color.Green;
                        loginbutton.ActiveLineColor = Color.White;
                        loginbutton.IdleForecolor = Color.White;
                        loginbutton.IdleLineColor = Color.White;
                        loginbutton.IdleFillColor = Color.Green;
                        Console.WriteLine("chutiya exception");
                        //var current = Process.GetCurrentProcess();
                        //Process.GetProcessesByName(current.ProcessName)
                        //    .Where(t => t.Id != current.Id)
                        //    .ToList()
                        //    .ForEach(t => t.Kill());

                        //current.Kill();
                        FileReadWrite.WriteFile(Environment.GetEnvironmentVariable("windir") + @"/locredo.dat", json);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        //Application.Exit();
                    }
                    else
                    {
                        loginbutton.ActiveFillColor = Color.FromArgb(2, 70, 107);
                        loginbutton.ActiveLineColor = Color.White;
                        loginbutton.IdleForecolor = Color.White;
                        loginbutton.IdleLineColor = Color.White;
                        loginbutton.IdleFillColor = Color.FromArgb(2, 70, 107);
                        //Color.FromArgb(2, 70, 107);
                        loginerror.Text = "*Invalid Username and Password";
                    }

                }
            }
            else
            {
                MessageBox.Show("Make sure you are connected to the Internet");
            }

            
        }
        private void ProcessCmdKey(object sender, KeyEventArgs e)
        {

            //for (int i = 0; i < MachineLearningToolv3.MLTool.feat.Count; i++)
            // {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                // e.SuppressKeyPress = true;
                //SelectNextControl(icheckboxlist[i], true, true, true, true);
            }
            //}
        }
        public void click(object sender, EventArgs e)
        {
            //for (int i = 0; i < feat.Count; i++)
            //{
                usernameans.TabStop = true;
                passwordans.TabStop = true;
                usernameans.KeyDown += ProcessCmdKey;
                passwordans.KeyUp += ProcessCmdKey;
            //}
        }
        private void Loginform_Load(object sender, EventArgs e)
        {
            try
            {
                System.IntPtr ptr = CreateRoundRectRgn(0, 0, this.Width, this.Height, 30, 30);
                this.Region = System.Drawing.Region.FromHrgn(ptr);
                //flowLayoutPanel1.Dispose();
               // this.BackColor = Color.FromArgb(80, Color.Black);
                DeleteObject(ptr);
            }
            catch
            {
                Console.WriteLine("parameter is not valid");
            }
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            logincredentials();
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            var current = Process.GetCurrentProcess();
            Process.GetProcessesByName(current.ProcessName)
                .Where(t => t.Id != current.Id)
                .ToList()
                .ForEach(t => t.Kill());

            current.Kill();

            Application.Exit();
        }

        private void Loginform_VisibleChanged(object sender, EventArgs e)
        {
            usernameans.Click += new EventHandler(click);
            passwordans.Click += new EventHandler(click);
        }

        private void passwordans_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                logincredentials();

           
                //await Task.Delay(500);
                
            }
        }

        private void usernameans_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                logincredentials();


                //await Task.Delay(500);

            }
        }
    }
}
