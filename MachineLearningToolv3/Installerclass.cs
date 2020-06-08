using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace MachineLearningToolv3
{
    [RunInstaller(true)]
    public partial class Installerclass : System.Configuration.Install.Installer
    {
        public Installerclass()
        {
            InitializeComponent();
        }

        public string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);

            // Delete folder here.
            //System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            //System.IO.File.Delete();
            try
            {

                try
                {
                    System.IO.File.Delete(path + @"/predictions.reg");
                    System.IO.File.Delete(path + @"/filedetails.json");
                    System.IO.File.Delete(path + @"/SGD.pkl");
                    System.IO.File.Delete(path + @"/LinearRegression.pkl");
                    System.IO.File.Delete(path + @"/DTR.pkl");
                    System.IO.File.Delete(path + @"/RFR.pkl");
                    System.IO.File.Delete(path + @"/Perceptron.pkl");
                    System.IO.File.Delete(path + @"/DTC.pkl");
                    System.IO.File.Delete(path + @"/RFC.pkl");
                    System.IO.File.Delete(path + @"/cnn.h5");
                    System.IO.File.Delete(path + @"/cnn.json");
                    System.IO.File.Delete(path + @"/DTC_confusion.png");
                    System.IO.File.Delete(path + @"/Perceptron_confusion.png");
                    System.IO.File.Delete(path + @"/RFC_confusion.png");
                    System.IO.File.Delete(path + @"/IC.py");
                    System.IO.File.Delete(path + @"/SGD.py");
                    System.IO.File.Delete(path + @"/DTR.py");
                    System.IO.File.Delete(path + @"/LinearRegression.py");
                    System.IO.File.Delete(path + @"/RFR.py");
                    System.IO.File.Delete(path + @"/Perceptron.py");
                    System.IO.File.Delete(path + @"/DTC.py");
                    System.IO.File.Delete(path + @"/RFC.py");
                    System.IO.File.Delete(path + @"/Outputhistory.txt");
                    System.IO.File.Delete(path + @"/Eduvance_ML_report.docx");
                    System.IO.File.Delete(path + @"/output.txt");
                    System.IO.File.Delete(path + @"/test_output.txt");
                    System.IO.File.Delete(path + @"/log.txt");
                    System.IO.File.Delete(path + @"/installed.reg");
                    System.IO.File.Delete(path + @"/mltool001.reg");
                    string[] pathproject = Directory.GetFiles(path, "*.zip");
                    foreach (string filename in pathproject)
                    {
                        System.IO.File.Delete(filename);

                    }

                    string[] pathproject1 = Directory.GetFiles(path, "*.csv");
                    foreach (string filename in pathproject1)
                    {
                        System.IO.File.Delete(filename);

                    }


                    System.IO.File.Delete(path + @"/LinearRegression.py");
                    System.IO.File.Delete(path + @"/SGD.py");
                    System.IO.File.Delete(path + @"/DTR.py");
                    System.IO.File.Delete(path + @"/RFR.py");
                    System.IO.File.Delete(path + @"/Perceptron.py");
                    System.IO.File.Delete(path + @"/DTC.py");
                    System.IO.File.Delete(path + @"/RFC.py");
                    System.IO.File.Delete(path + @"/IC.py");
                    System.IO.File.Delete(path + @"/txttopdf.py");
                    System.IO.File.Delete(path + @"/Libinstall.py");

                    System.IO.File.Delete(path + @"/Pdfs/ML_report.pdf");
                    Directory.Delete(path + @"/Pdfs");
                    // System.IO.File.Delete(Application.StartupPath + @"/test_output.txt");
                    System.IO.File.Delete(Environment.GetEnvironmentVariable("windir") + @"/locred.dat");
                    System.IO.File.Delete(Environment.GetEnvironmentVariable("windir") + @"/locredo.dat");
                    System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\mltool001.dbf");

                }
                catch
                {
                    Console.WriteLine("no model file found");
                }
                try
                {
                    System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\mltool001.dbf");
                    System.IO.File.Delete(Environment.GetEnvironmentVariable("windir") + @"/locred.dat");
                    System.IO.File.Delete(Environment.GetEnvironmentVariable("windir") + @"/locredo.dat");

                    System.IO.DirectoryInfo di = new DirectoryInfo(path + @"\root");

                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }
                    Directory.Delete(path + @"\root");
                }
                catch
                {
                    Console.WriteLine("sab delete hua haha");
                }
                //System.IO.File.Delete(path + "\\log.txt");
                //System.IO.File.Delete(path + "\\temp.txt");
                //System.IO.File.Delete(path + "\\configure.xml");
                //Directory.Delete(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\EnablAR");
                //Directory.Delete(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));

            }
            catch (Exception)
            {
                Console.WriteLine("exception");
            }

        }
    }


}

