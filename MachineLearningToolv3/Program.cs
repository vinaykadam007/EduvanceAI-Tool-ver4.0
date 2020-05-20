using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftwareLocker;
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

namespace MachineLearningToolv3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]


        static void Main(string[] args)
        {
           Application.EnableVisualStyles();
           Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                TrialMaker t = new TrialMaker("mltool",
      Application.StartupPath + "\\mltool001.reg",
      Environment.GetFolderPath(Environment.SpecialFolder.System) +
        "\\mltool001.dbf",
      "E-mail: contact@eduvance.in",
      10, 1000000000, "745");

                byte[] MyOwnKey = { 97, 250,  1,  5,  84, 21,   7, 63,
                         4,  54, 87, 56, 123, 10,   3, 62,
                         7,   9, 20, 36,  37, 21, 101, 57};
                t.TripleDESKey = MyOwnKey;
                // if you don't call this part the program will
                //use default key to encryption

                TrialMaker.RunTypes RT = t.ShowDialog();
                bool is_trial;
                if (RT != TrialMaker.RunTypes.Expired)
                {
                    if (RT == TrialMaker.RunTypes.Full)
                        is_trial = false;
                    else
                        is_trial = true;

                    //Application.Run(new Form1());
                    Application.Run(new MLTool());
                }

               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
