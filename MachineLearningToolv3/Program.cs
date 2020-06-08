using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//using SoftwareLocker;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
using System.Security.Authentication.ExtendedProtection;
using System.IO.Compression;
using Ionic.Zip;
using ZipFile = Ionic.Zip.ZipFile;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace MachineLearningToolv3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        // public 
        // public static bool OpenDetailFormOnClose { get; set; }

        public static string hwid;
        public static string todaydate = Convert.ToString(DateTime.Now.Date);
        
       
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
        [STAThread]
        static void Main(string[] args)
        {

        
           Application.EnableVisualStyles();
           Application.SetCompatibleTextRenderingDefault(false);

            Console.WriteLine(Environment.GetEnvironmentVariable("windir") + @"/locred.dat");
            //OpenDetailFormOnClose = false;
            
            if (!File.Exists(Environment.GetEnvironmentVariable("windir") + @"/locred.dat"))
            {
                Loginform fLogin = new Loginform();

                if (fLogin.ShowDialog() == DialogResult.OK)
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

                            hwid = Convert.ToString(queryObj["ProcessorId"]) + Convert.ToString(queryObj["Family"]) + Convert.ToString(queryObj["Architecture"]);
                            //json = @"{""username"":" + "\"" + usernameans.Text + "\"" + "," + @"""password"":" + "\"" + passwordans.Text + "\"" + "," + @"""hw_id"":" + "\"" + Convert.ToString(queryObj["ProcessorId"]) + Convert.ToString(queryObj["Family"]) + Convert.ToString(queryObj["Architecture"]) + "\"" + "}";
                        }

                        string jsoninfo = FileReadWrite.ReadFile(Environment.GetEnvironmentVariable("windir") + @"/locredo.dat");
                        Console.WriteLine(jsoninfo);
                        string jsoninfo1 = FileReadWrite.ReadFile(Environment.GetEnvironmentVariable("windir") + @"/locred.dat");
                        dynamic json2 = JsonConvert.DeserializeObject(jsoninfo1);

                        dynamic json = JsonConvert.DeserializeObject(jsoninfo);
                        //Console.WriteLine(json["token"]);
                        //Console.WriteLine(hwid);
                        string json1 = @"{""username"":" + "\"" + Convert.ToString(json["username"]) + "\"" + "," + @"""password"":" + "\"" + Convert.ToString(json["password"]) + "\"" + "," + @"""hw_id"":" + "\"" + hwid + "\"" + "}";
                        Console.WriteLine(json1);

                        if (CheckForInternetConnection() == true)
                        {
                            try
                            {
                                MyWebRequest myRequest = new MyWebRequest("http://173.82.227.236:8014/sign-in/", "POST", json1);

                                Console.WriteLine(myRequest.GetResponse());
                                Console.WriteLine("everything is ok");
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine("+++++++++++");
                                Console.WriteLine(e.Message);
                                Console.WriteLine("+++++++++++");
                                System.IO.File.Delete(Environment.GetEnvironmentVariable("windir") + @"/locred.dat");
                                System.IO.File.Delete(Environment.GetEnvironmentVariable("windir") + @"/locredo.dat");
                                MessageBox.Show("License Expired");
                                var current = Process.GetCurrentProcess();
                                Process.GetProcessesByName(current.ProcessName)
                                    .Where(t => t.Id != current.Id)
                                    .ToList()
                                    .ForEach(t => t.Kill());

                                current.Kill();
                                Application.Exit();
                            }
                            
                            //}
                            //else
                            //{
                              //  System.IO.File.Delete(Environment.GetEnvironmentVariable("windir") + @"/locred.dat");

                                //Program.OpenDetailFormOnClose = true;
                                //this.Close();
                                //this.Dispose();
                                //if (!File.Exists(Environment.GetEnvironmentVariable("windir") + @"/locred.dat"))
                                //{
                                //    //this.Hide();
                                //    Loginform fLogin1 = new Loginform();

                                //    if (fLogin1.ShowDialog() == DialogResult.OK)
                                //    {
                                //        //Thread newsplash = new Thread(new ThreadStart(newscreen));
                                //        //newsplash.SetApartmentState(ApartmentState.STA);
                                //        //newsplash.Start();
                                //        Application.Run(new MLTool());
                                //        fLogin1.Dispose();
                                //    }
                                //    else
                                //    {
                                //        Application.Exit();
                                //    }
                                //}
                                //else
                                //{
                                //    Application.Exit();

                                //}
                            //}
                        }
                        else
                        {
                            DateTime expiry = json2["expiry_date"];
                            Console.WriteLine(expiry.Year.ToString());
                            Console.WriteLine(expiry.Month.ToString());
                            Console.WriteLine(expiry.Day.ToString());
                            Console.WriteLine(json2["expiry_date"]);
                            Console.WriteLine("''''''''''''''''''''''''''");

                            string todaydates = Convert.ToString(todaydate).Substring(0, 10);
                            DateTime temp = DateTime.ParseExact(todaydates, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                            Console.WriteLine(temp.Year.ToString());
                            Console.WriteLine(temp.Month.ToString());
                            Console.WriteLine(temp.Day.ToString());

                            string str = temp.ToString("yyyy-MM-dd");
                            Console.WriteLine(str);

                            if (Convert.ToInt32(expiry.Year.ToString()) > Convert.ToInt32(temp.Year.ToString()))
                            {
                                if (Convert.ToInt32(expiry.Month.ToString()) > Convert.ToInt32(temp.Month.ToString()))
                                {
                                    if (Convert.ToInt32(expiry.Day.ToString()) > Convert.ToInt32(temp.Day.ToString()))
                                    {
                                        System.IO.File.Delete(Environment.GetEnvironmentVariable("windir") + @"/locred.dat");
                                        MessageBox.Show("License Expired");
                                        var current = Process.GetCurrentProcess();
                                        Process.GetProcessesByName(current.ProcessName)
                                            .Where(t => t.Id != current.Id)
                                            .ToList()
                                            .ForEach(t => t.Kill());

                                        current.Kill();
                                        Application.Exit();
                                    }
                                }

                            }
                        }


                    }
                    catch
                    {
                        Console.WriteLine("correct hai sab");
                    }




                    Application.Run(new MLTool());
                    fLogin.Dispose();
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {
                try
                {
                    ManagementObjectSearcher searcher =
                              new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");

                    foreach (ManagementObject queryObj in searcher.Get())
                    {

                        hwid = Convert.ToString(queryObj["ProcessorId"]) + Convert.ToString(queryObj["Family"]) + Convert.ToString(queryObj["Architecture"]);
                        //json = @"{""username"":" + "\"" + usernameans.Text + "\"" + "," + @"""password"":" + "\"" + passwordans.Text + "\"" + "," + @"""hw_id"":" + "\"" + Convert.ToString(queryObj["ProcessorId"]) + Convert.ToString(queryObj["Family"]) + Convert.ToString(queryObj["Architecture"]) + "\"" + "}";
                    }

                    string jsoninfo = FileReadWrite.ReadFile(Environment.GetEnvironmentVariable("windir") + @"/locredo.dat");
                    Console.WriteLine(jsoninfo);
                    string jsoninfo1 = FileReadWrite.ReadFile(Environment.GetEnvironmentVariable("windir") + @"/locred.dat");
                    dynamic json2 = JsonConvert.DeserializeObject(jsoninfo1);

                    dynamic json = JsonConvert.DeserializeObject(jsoninfo);
                    //Console.WriteLine(json["token"]);
                    //Console.WriteLine(hwid);
                    // "," + @"""hw_id"":" + "\"" + Convert.ToString(queryObj["ProcessorId"]) + Convert.ToString(queryObj["Family"]) + Convert.ToString(queryObj["Architecture"]) + "\"" + "}";
                    string json1 = @"{""username"":" + "\"" + Convert.ToString(json["username"]) + "\"" + "," + @"""password"":" + "\"" + Convert.ToString(json["password"]) + "\"" + "," + @"""hw_id"":" + "\"" + hwid + "\"" + "}";
                    Console.WriteLine(json1);
                    if (CheckForInternetConnection() == true)
                    {

                        try
                        {
                            MyWebRequest myRequest = new MyWebRequest("http://173.82.227.236:8014/sign-in/", "POST", json1);

                            Console.WriteLine(myRequest.GetResponse());
                            Console.WriteLine("everything is ok");
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("+++++++++++");
                            Console.WriteLine(e.Message);
                            Console.WriteLine("+++++++++++");
                            System.IO.File.Delete(Environment.GetEnvironmentVariable("windir") + @"/locred.dat");
                            System.IO.File.Delete(Environment.GetEnvironmentVariable("windir") + @"/locredo.dat");
                            MessageBox.Show("License Expired");
                            var current = Process.GetCurrentProcess();
                            Process.GetProcessesByName(current.ProcessName)
                                .Where(t => t.Id != current.Id)
                                .ToList()
                                .ForEach(t => t.Kill());

                            current.Kill();
                            Application.Exit();
                        }
                        //}
                        //else
                        //{
                        //   System.IO.File.Delete(Environment.GetEnvironmentVariable("windir") + @"/locred.dat");

                        //Program.OpenDetailFormOnClose = true;
                        //this.Close();
                        //this.Dispose();
                        //if (!File.Exists(Environment.GetEnvironmentVariable("windir") + @"/locred.dat"))
                        //{
                        //    //this.Hide();
                        //    Loginform fLogin1 = new Loginform();

                        //    if (fLogin1.ShowDialog() == DialogResult.OK)
                        //    {
                        //        //Thread newsplash = new Thread(new ThreadStart(newscreen));
                        //        //newsplash.SetApartmentState(ApartmentState.STA);
                        //        //newsplash.Start();
                        //        Application.Run(new MLTool());
                        //        fLogin1.Dispose();
                        //    }
                        //    else
                        //    {
                        //        Application.Exit();
                        //    }
                        //}
                        //else
                        //{
                        //  Application.Exit();

                        //}
                        //}
                    }
                    else
                    {
                        
                        DateTime expiry = json2["expiry_date"];
                        Console.WriteLine(expiry.Year.ToString());
                        Console.WriteLine(expiry.Month.ToString());
                        Console.WriteLine(expiry.Day.ToString());
                        Console.WriteLine(json2["expiry_date"]);
                        Console.WriteLine("''''''''''''''''''''''''''");

                        string todaydates = Convert.ToString(todaydate).Substring(0, 10);
                        DateTime temp = DateTime.ParseExact(todaydates, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        Console.WriteLine(temp.Year.ToString());
                        Console.WriteLine(temp.Month.ToString());
                        Console.WriteLine(temp.Day.ToString());

                        string str = temp.ToString("yyyy-MM-dd");
                        Console.WriteLine(str);

                        if (Convert.ToInt32(expiry.Year.ToString()) > Convert.ToInt32(temp.Year.ToString()))
                        {
                            if(Convert.ToInt32(expiry.Month.ToString()) > Convert.ToInt32(temp.Month.ToString()))
                            {
                                if(Convert.ToInt32(expiry.Day.ToString()) > Convert.ToInt32(temp.Day.ToString()))
                                {
                                    System.IO.File.Delete(Environment.GetEnvironmentVariable("windir") + @"/locred.dat");
                                    MessageBox.Show("License Expired");
                                    var current = Process.GetCurrentProcess();
                                    Process.GetProcessesByName(current.ProcessName)
                                        .Where(t => t.Id != current.Id)
                                        .ToList()
                                        .ForEach(t => t.Kill());

                                    current.Kill();
                                    Application.Exit();
                                }
                            }
                            
                        }
                       

                    }


                }
                catch
                {
                    Console.WriteLine("correct hai sab");

                    
                }
               
                   
                Application.Run(new MLTool());
               
                
            }


            //if (OpenDetailFormOnClose)
            //{
            //    if (!File.Exists(Application.StartupPath + @"/locred.dat"))
            //    {
            //        Loginform fLogin = new Loginform();

            //        if (fLogin.ShowDialog() == DialogResult.OK)
            //        {
            //            Application.Run(new MLTool());
            //            fLogin.Dispose();
            //        }
            //        else
            //        {
            //            Application.Exit();
            //        }
            //    }
            //    else
            //    {

            //        Application.Run(new MLTool());
            //    }
                //Application.Run(new MLTool());
           // }
            


            //try
            // {
            //          TrialMaker t = new TrialMaker("mltool",
            //Application.StartupPath + "\\mltool001.reg",
            //Environment.GetFolderPath(Environment.SpecialFolder.System) +
            //  "\\mltool001.dbf",
            //"E-mail: contact@eduvance.in",
            //10, 1000000000, "745");

            //          byte[] MyOwnKey = { 97, 250,  1,  5,  84, 21,   7, 63,
            //                   4,  54, 87, 56, 123, 10,   3, 62,
            //                   7,   9, 20, 36,  37, 21, 101, 57};
            //          t.TripleDESKey = MyOwnKey;
            //          // if you don't call this part the program will
            //          //use default key to encryption

            //          TrialMaker.RunTypes RT = t.ShowDialog();
            //          bool is_trial;
            //          if (RT != TrialMaker.RunTypes.Expired)
            //          {
            //              if (RT == TrialMaker.RunTypes.Full)
            //                  is_trial = false;
            //              else
            //                  is_trial = true;

            //Application.Run(new Form1());
            
                //}

               
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
        }
    }
}
