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
    public partial class Test : Form
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

        public static List<string> strfeatures = new List<string>();
        
        public Test()
        {
            

            InitializeComponent();



            initials();
            //SetDoubleBuffered(tableLayoutPanel1);
            //SetDoubleBuffered(tableLayoutPanel3);
            //SetDoubleBuffered(tableLayoutPanel5);
            //SetDoubleBuffered(flowLayoutPanel1);
            //SetDoubleBuffered(inputpanels);
            //SetDoubleBuffered(predictionpanels);
            //SetDoubleBuffered(tableLayoutPanel5);
            //SetDoubleBuffered(tableLayoutPanel4);
            //SetDoubleBuffered(Predict);
            // SetStyle(ControlStyles.OptimizedDoubleBuffer, true);


            //var fileStream = new FileStream(Application.StartupPath + @"\stringfeatures.txt", FileMode.Open, FileAccess.Read);
            //using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            //{
            //    string text = streamReader.ReadToEnd();
            //    //Console.WriteLine(text.Substring(0, text.Length - 1));
            //    //strfeatures.Add();
            //    strfeatures = text.Substring(0, text.Length - 1).Split(',').ToList();
            //}
            //fileStream.Close();





        }

        public void initials()
        {
            try
            {
                //flowLayoutPanel1.SuspendLayout();
                createinputcheckboxes();
                //flowLayoutPanel1.ResumeLayout();
                // ProcessCmdKey(null, new KeyEventArgs());
                predictlabel.Text = "";
               
                bunifuThinButton22.Visible = false;
                // System.IO.File.Delete(Application.StartupPath + @"/currentPdfs/currentML_report.pdf");
                // Directory.Delete(Application.StartupPath + @"/currentPdfs");
                // createpredcheckboxes();
            }
            catch(Exception ex)
            {
                this.Close();
                MessageBox.Show("No model has been created to predict");
            }
            Labeloutput.Text = MachineLearningToolv3.MLTool.lab + " : ";
            //try
            //{
            //    System.IO.File.Delete(Application.StartupPath + @"/test_output.txt");
            //    System.IO.File.Delete(Application.StartupPath + @"/currentPdfs/currentML_report.pdf");
            //    Directory.Delete(Application.StartupPath + @"/currentPdfs");
            //}
            //catch
            //{

            //}
        }

        public List<string> featureslabels = new List<string>();
        public static TextBox o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16, o17, o18, o19, o20;

        private void inputpanels_Paint_1(object sender, PaintEventArgs e)
        {
            //inputpanels.BackColor = Color.FromArgb(80, Color.Black);
            System.IntPtr ptr = CreateRoundRectRgn(10, 10, inputpanels.Width, inputpanels.Height, 30, 30); // _BoarderRaduis can be adjusted to your needs, try 15 to start.
            inputpanels.Region = System.Drawing.Region.FromHrgn(ptr);
            DeleteObject(ptr);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            System.IntPtr ptr = CreateRoundRectRgn(0, 0, tableLayoutPanel1.Width, tableLayoutPanel1.Height, 30, 30); // _BoarderRaduis can be adjusted to your needs, try 15 to start.
            tableLayoutPanel1.Region = System.Drawing.Region.FromHrgn(ptr);
            DeleteObject(ptr);
            //tableLayoutPanel1.BackColor = Color.FromArgb(80, Color.Black);
        }

        private void predictionpanels_Paint_1(object sender, PaintEventArgs e)
        {
            //predictionpanels.BackColor = Color.FromArgb(80, Color.Black);
            System.IntPtr ptr = CreateRoundRectRgn(10, 10, predictionpanels.Width, predictionpanels.Height, 30, 30); // _BoarderRaduis can be adjusted to your needs, try 15 to start.
            predictionpanels.Region = System.Drawing.Region.FromHrgn(ptr);
            DeleteObject(ptr);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            flowLayoutPanel1.BackColor = Color.FromArgb(80, Color.Black);
            System.IntPtr ptr = CreateRoundRectRgn(0, 0, flowLayoutPanel1.Width, flowLayoutPanel1.Height, 30, 30); // _BoarderRaduis can be adjusted to your needs, try 15 to start.
            flowLayoutPanel1.Region = System.Drawing.Region.FromHrgn(ptr);
            DeleteObject(ptr);
        }

        private void Predict_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.File.Delete(Application.StartupPath + @"/currentPdfs/currentML_report.pdf");
                Directory.Delete(Application.StartupPath + @"/currentPdfs");
            }
            catch
            {

            }
            for (int j = 0; j < feat.Count; j++)
            {
                if(predictlabel.Text != string.Empty)
                {
                    MessageBox.Show("Do you want to Test again ?");

                    Predict.ActiveFillColor = Color.Green;
                    Predict.ActiveLineColor = Color.White;
                    Predict.IdleForecolor = Color.White;
                    Predict.IdleLineColor = Color.White;
                    Predict.IdleFillColor = Color.Green;

                    predictlabel.Text = "";

                    //for (int i = 0; i < feat.Count; i++)
                    //{
                    //    icheckboxlist[j].TextChanged += new EventHandler(predictgreen);
                    //}
                    



                    //confusionmatbox.Image = null;
                    //traintime.Text = "";

                    return;
                }
                else
                {

                    if (icheckboxlist[j].Text == string.Empty)
                    {
                        predictlabel.Text = "";
                        MessageBox.Show("Invalid input");
                        return;
                    }
                    else
                    {
                        ProcessStartInfo start = new ProcessStartInfo();
                        start.WindowStyle = ProcessWindowStyle.Hidden;
                        start.CreateNoWindow = true;
                        start.UseShellExecute = false;
                        start.FileName = Environment.SystemDirectory + @"\cmd.exe";
                        for (int i = 0; i < feat.Count; i++)
                        {

                            featureslabels.Add(icheckboxlist[i].Text);


                        }

                        string[] fileEntries = Directory.GetFiles(Application.StartupPath + "/", "*.pkl");


                        if (fileEntries[0] == Application.StartupPath + "/LinearRegression.pkl")
                        {
                            test_OLS();

                            start.Arguments = string.Format(@"/C "  + "\"" + MachineLearningToolv3.MLTool.pypath + "\"" + " LinearRegression_Test.py " + "-i " + String.Join(",", featureslabels));
                            Console.WriteLine(start.Arguments);
                            Console.WriteLine(MachineLearningToolv3.MLTool.datafilename);
                        }
                        else if (fileEntries[0] == Application.StartupPath + "/SGD.pkl")
                        {
                            test_SGD();
                            start.Arguments = string.Format(@"/C " + "\"" + MachineLearningToolv3.MLTool.pypath + "\"" + " SGD_Test.py " + "-i " + String.Join(",", featureslabels));
                            Console.WriteLine(start.Arguments);
                        }
                        else if (fileEntries[0] == Application.StartupPath + "/DTR.pkl")
                        {
                            test_DTR();
                            start.Arguments = string.Format(@"/C " + "\"" + MachineLearningToolv3.MLTool.pypath + "\"" + " DTR_Test.py " + "-i " + String.Join(",", featureslabels));
                            Console.WriteLine(start.Arguments);
                        }
                        else if (fileEntries[0] == Application.StartupPath + "/RFR.pkl")
                        {
                            test_RFR();
                            start.Arguments = string.Format(@"/C " + "\"" + MachineLearningToolv3.MLTool.pypath + "\"" + " RFR_Test.py " + "-i " + String.Join(",", featureslabels));
                            Console.WriteLine(start.Arguments);
                        }
                        else if (fileEntries[0] == Application.StartupPath + "/Perceptron.pkl")
                        {
                            test_perceptron();
                            start.Arguments = string.Format(@"/C " + "\"" + MachineLearningToolv3.MLTool.pypath + "\"" + " Perceptron_Test.py " + "-i " + String.Join(",", featureslabels));
                            Console.WriteLine(start.Arguments);
                        }
                        else if (fileEntries[0] == Application.StartupPath + "/DTC.pkl")
                        {
                            test_DTC();
                            start.Arguments = string.Format(@"/C " + "\"" + MachineLearningToolv3.MLTool.pypath + "\"" + " DTC_Test.py " + "-i " + String.Join(",", featureslabels));
                            Console.WriteLine(start.Arguments);
                        }
                        else if (fileEntries[0] == Application.StartupPath + "/RFC.pkl")
                        {
                            test_RFC();
                            start.Arguments = string.Format(@"/C " + "\"" + MachineLearningToolv3.MLTool.pypath + "\"" + " RFC_Test.py " + "-i " + String.Join(",", featureslabels));
                            Console.WriteLine(start.Arguments);
                        }

                        start.RedirectStandardOutput = true;

                        using (Process process = Process.Start(start))
                        {
                            using (StreamReader reader = process.StandardOutput)
                            {
                                string result = reader.ReadToEnd();
                                Console.Write(result);

                                predictlabel.Font = new System.Drawing.Font("Segoe UI", 13.0F, FontStyle.Bold);

                                if(MachineLearningToolv3.MLTool.modelname == "LinearRegression")
                                {
                                    try
                                    {
                                        predictlabel.Text = Convert.ToString(Math.Round(Convert.ToDouble(result), 2, MidpointRounding.ToEven));
                                    }
                                    catch(System.FormatException ex)
                                    {
                                        MessageBox.Show("Invalid input");
                                    }
                                    
                                }   
                                else if (MachineLearningToolv3.MLTool.modelname == "SGD")
                                {
                                    try
                                    {
                                        predictlabel.Text = Convert.ToString(Math.Round(Convert.ToDouble(result), 2, MidpointRounding.ToEven));
                                    }
                                    catch (System.FormatException ex)
                                    {
                                        MessageBox.Show("Invalid input");
                                    }
                                }
                                else if (MachineLearningToolv3.MLTool.modelname == "DTR")
                                {
                                    try
                                    {
                                        predictlabel.Text = Convert.ToString(Math.Round(Convert.ToDouble(result), 2, MidpointRounding.ToEven));
                                    }
                                    catch (System.FormatException ex)
                                    {
                                        MessageBox.Show("Invalid input");
                                    }   
                                }
                                else if (MachineLearningToolv3.MLTool.modelname == "RFR")
                                {
                                    try
                                    {
                                        predictlabel.Text = Convert.ToString(Math.Round(Convert.ToDouble(result), 2, MidpointRounding.ToEven));
                                    }
                                    catch (System.FormatException ex)
                                    {
                                        MessageBox.Show("Invalid input");
                                    }
                                }
                                else if (MachineLearningToolv3.MLTool.modelname == "DTC")
                                {
                                    predictlabel.Text = result;
                                }
                                else if (MachineLearningToolv3.MLTool.modelname == "RFC")
                                {
                                    predictlabel.Text = result;
                                }
                                else if (MachineLearningToolv3.MLTool.modelname == "Perceptron")
                                {
                                    predictlabel.Text = result;
                                }
                                //predictlabel.Text = Convert.ToString(Math.Round(Convert.ToDouble(result), 2, MidpointRounding.ToEven));
                                
                                if(predictlabel.Text == string.Empty)
                                {
                                    if (MachineLearningToolv3.MLTool.modelname == "Perceptron" || MachineLearningToolv3.MLTool.modelname == "RFC" || MachineLearningToolv3.MLTool.modelname == "DTC")
                                    {
                                        MessageBox.Show("Invalid input");
                                       // return;
                                    }
                                        
                                    Predict.ActiveFillColor = SystemColors.ActiveCaption;
                                    Predict.ActiveLineColor = Color.White;
                                    Predict.IdleForecolor = Color.White;
                                    Predict.IdleLineColor = Color.White;
                                    Predict.IdleFillColor = SystemColors.ActiveCaption;
                                
                                } 
                                else if(predictlabel.Text != string.Empty)
                                {
                                    Predict.ActiveFillColor = SystemColors.ActiveCaption;
                                    Predict.ActiveLineColor = Color.White;
                                    Predict.IdleForecolor = Color.White;
                                    Predict.IdleLineColor = Color.White;
                                    Predict.IdleFillColor = SystemColors.ActiveCaption;
                                }
                                else
                                {

                                   
                                    Predict.ActiveFillColor = SystemColors.ActiveCaption;
                                    Predict.ActiveLineColor = Color.White;
                                    Predict.IdleForecolor = Color.White;
                                    Predict.IdleLineColor = Color.White;
                                    Predict.IdleFillColor = SystemColors.ActiveCaption;
                                }
                                
                                


                                using (StreamWriter sw = File.AppendText(Application.StartupPath + @"\test_output.txt"))
                                {
                                    sw.WriteLine("Test " + i);
                                    sw.WriteLine("Inputs: " + String.Join(",", featureslabels));
                                    sw.WriteLine("Prediction: " + predictlabel.Text);

                                    i += 1;
                                }
                            }
                        }
                        Console.WriteLine("********Predicted*******");
                        Console.WriteLine(fileEntries[0]);
                        featureslabels.Clear();
                        try
                        {
                            System.IO.File.Delete(Application.StartupPath + @"/LinearRegression_Test" + ".py");
                            System.IO.File.Delete(Application.StartupPath + @"/SGD_Test" + ".py");
                            System.IO.File.Delete(Application.StartupPath + @"/DTR_Test" + ".py");
                            System.IO.File.Delete(Application.StartupPath + @"/RFR_Test" + ".py");
                            System.IO.File.Delete(Application.StartupPath + @"/Perceptron_Test" + ".py");
                            System.IO.File.Delete(Application.StartupPath + @"/DTC_Test" + ".py");
                            System.IO.File.Delete(Application.StartupPath + @"/RFC_Test" + ".py");
                            //System.IO.File.Delete(Application.StartupPath + @"/RFC_Test" + ".py");
                        }
                        catch
                        {
                            Console.WriteLine("exception while deleting test script");
                        }
                        break;
                    }
                }

            }
                
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            try
            {
                System.IO.File.Delete(Application.StartupPath + @"/currentPdfs/currentML_report.pdf");
                Directory.Delete(Application.StartupPath + @"/currentPdfs");
                System.IO.File.Delete(Application.StartupPath + @"/test_output.txt");
            }
            catch
            {

            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {
           // tableLayoutPanel3.BackColor = Color.FromArgb(80, Color.Black);
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {
           // tableLayoutPanel4.BackColor = Color.FromArgb(80, Color.Black);
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {
           // tableLayoutPanel5.BackColor = Color.FromArgb(80, Color.Black);
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            //create_currentpdfreport();
            //try
            //{
            //    //predictlabel.Text = "";
            //    System.IO.File.Delete(Application.StartupPath + @"/currentPdfs/currentML_report.pdf");
            //    Directory.Delete(Application.StartupPath + @"/currentPdfs");
            //}
            //catch
            //{

            //}
            //for (int j = 0; j < feat.Count; j++)
            //{
            //    if (icheckboxlist[j].Text == string.Empty)
            //    {
            //        predictlabel.Text = "";
            //        MessageBox.Show("Put some input values");
            //    }
            //    else
            //    {

            //        ProcessStartInfo start = new ProcessStartInfo();
            //        start.WindowStyle = ProcessWindowStyle.Hidden;
            //        start.CreateNoWindow = true;
            //        start.UseShellExecute = false;
            //        start.FileName = "cmd.exe";
            //        start.Arguments = string.Format(@"/C " + MachineLearningToolv3.MLTool.pypath + " " + Application.StartupPath + @"/currenttxttopdf.py");
            //        start.RedirectStandardOutput = true;
            //        using (Process process = Process.Start(start))
            //        {
            //            using (StreamReader reader = process.StandardOutput)
            //            {
            //                string pdf = reader.ReadToEnd();
            //                Console.WriteLine(pdf);
            //                MessageBox.Show("Pdf file generated and will be save on your Desktop Folder");
            //            }
            //        }

            //        System.IO.File.Delete(Application.StartupPath + @"/currenttxttopdf.py");
            //        System.IO.File.Delete(Application.StartupPath + @"/currentDocuments/ML.docx");
            //        Directory.Delete(Application.StartupPath + @"/currentDocuments");
            //        System.IO.File.Copy(Application.StartupPath + @"/currentPdfs/currentML_report.pdf", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/currentML_report.pdf", true);
            //    }
            //}
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

        //private void LoadBackgroundImage()
        //{
        //    Image img = Image.FromFile(Application.StartupPath + @"/background.bmp");
        //    this.BackgroundImage = img;
        //}


        private void Test_Load(object sender, EventArgs e)
        {
            //tableLayoutPanel1.BackgroundImage = Image.FromFile(Application.StartupPath + @"/icons/Background.png");
            //tableLayoutPanel1.Update();
            //this.Size = new Size(900, 520);
            try
            {
                System.IntPtr ptr = CreateRoundRectRgn(0, 0, this.Width, this.Height, 30, 30); // _BoarderRaduis can be adjusted to your needs, try 15 to start.
                this.Region = System.Drawing.Region.FromHrgn(ptr);
                DeleteObject(ptr);

                for (int i = 0; i < feat.Count; i++)
                {
                    System.IntPtr ptr1 = CreateRoundRectRgn(0, 0, icheckboxlist[i].Width, icheckboxlist[i].Height, 10, 10); // _BoarderRaduis can be adjusted to your needs, try 15 to start.
                    icheckboxlist[i].Region = System.Drawing.Region.FromHrgn(ptr1);
                    DeleteObject(ptr1);
                }

                SetDoubleBuffered(tableLayoutPanel1);
                SetDoubleBuffered(tableLayoutPanel3);
                SetDoubleBuffered(tableLayoutPanel5);
                SetDoubleBuffered(flowLayoutPanel1);
                SetDoubleBuffered(inputpanels);
                SetDoubleBuffered(inputpanel);
                SetDoubleBuffered(predictionpanels);
                SetDoubleBuffered(tableLayoutPanel5);
                SetDoubleBuffered(tableLayoutPanel4);
                SetDoubleBuffered(Predict);
                SetDoubleBuffered(tableLayoutPanel2);
            }
            catch
            {
                Console.WriteLine("ex");
            }
        }

        private void Test_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                icheckboxlist[0].Click += new EventHandler(click);
            }
            catch
            {
                Console.WriteLine("null exception ");
            }
            
            
            //    click();
            
        }

        private void inputpanels_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void predictionpanels_Paint(object sender, PaintEventArgs e)
        {
            predictionpanels.BackColor = Color.FromArgb(80, Color.Black);
        }

        int i = 0;

        private void Test_FormClosing(object sender, FormClosingEventArgs e)
        {
           // this.Close();
        }

        public void create_currentpdfreport()
        {
            string default_currentpdfreport = @"from docx import Document
from docx.enum.text import WD_UNDERLINE
import time
import os
import sys
import comtypes.client
import glob


wordpath           = r'currentDocuments'
pdfpath            = r'currentPdfs'
outputdata = """"


txtfile = open(r""" + Application.StartupPath + @"/test_output.txt" + @""",'r')
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

temppath = r""./currentDocuments/ML.docx""
document.save(temppath)
time.sleep(2)

wdFormatPDF = 17
try:
    infile = (glob.glob(""%s\\*.docx"" % (wordpath)))
    word = comtypes.client.CreateObject('word.Application')
    for in_file in infile: 
        out_file = os.path.abspath(r""./currentPdfs/currentML_report.pdf"")
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

            string from = Application.StartupPath + @"/currenttxttopdf.py";
            using (StreamWriter file = new StreamWriter(from))
            {

                file.WriteLine(default_currentpdfreport);

            }
        }

        public static TextBox i1, i2, i3, i4, i5, i6, i7, i8, i9, i10, i11, i12, i13, i14, i15, i16, i17, i18, i19, i20, i21, i22, i23, i24, i25, i26, i27, i28, i29, i30;
        public static ComboBox c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30;
        public List<TextBox> icheckboxlist = new List<TextBox> { i1, i2, i3, i4, i5, i6, i7, i8, i9, i10, i11, i12, i13, i14, i15, i16, i17, i18, i19, i20, i21, i22, i23, i24, i25, i26, i27, i28, i29, i30 };
        public List<ComboBox> comboboxlist = new List<ComboBox> { c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30 };
       // public List<TextBox> ocheckboxlist = new List<TextBox> { o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16, o17, o18, o19, o20, o21, o22, o23, o24, o25, o26, o27, o28, o29, o30 };
        public static Label l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13, l14, l15, l16, l17, l18, l19, l20, l21, l22, l23, l24, l25, l26, l27, l28, l29, l30;
        public List<Label> labellist = new List<Label> { l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13, l14, l15, l16, l17, l18, l19, l20, l21, l22, l23, l24, l25, l26, l27, l28, l29, l30 };




        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;
        //        return cp;
        //    }
        //}
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
            for (int i = 0; i <feat.Count; i++)
            {
                icheckboxlist[i].TabStop = true;
                icheckboxlist[i].KeyDown += ProcessCmdKey;
            }
        }

        public void predictgreen(object sender, EventArgs e)
        {
            int cnt = 0;
            for (int i = 0; i < feat.Count; i++)
            { 
                if(icheckboxlist[i].Text != string.Empty)
                {
                    cnt = cnt + 1;
                   
                }
            
            }
            if (cnt == feat.Count)
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
                predictlabel.Text = "";
            }
            //foreach(Control c in inputpanels.Controls)
            //{
            //    TextBox cb = c as TextBox;

            //}
        }


        public List<string> feat = MachineLearningToolv3.MLTool.feat.Distinct().ToList();
        public void createinputcheckboxes()
        {

            //for (int i = 0; i < feat.Count; i++)
            //{
            //    try
            //    {
            //        //if (strfeatures[i] == feat[i])
            //        //{

            //        //    Console.WriteLine(i);

            //        //}
            //        var list3 = strfeatures.Except(feat);
            //        Console.WriteLine(list3);
            //    }
            //    catch
            //    {
            //        Console.WriteLine("not match");
            //    }


            // }





            int ypos = 10;
            // int ypos1 = 40;
            
            inputpanel.HorizontalScroll.Maximum = 0;
            inputpanel.AutoScroll = false;
            inputpanel.VerticalScroll.Visible = false;
            inputpanel.AutoScroll = true;
            for (int i = 0; i < feat.Count; i++)
            {


                for (int j = 0; j < feat.Count; j++)
                {
                    labellist[j] = new Label();
                    labellist[j].Location = new Point(80, ypos);
                    labellist[j].Text = feat[i];
                    labellist[j].Size = new System.Drawing.Size(300, 22);
                    labellist[j].Font = new System.Drawing.Font("Segoe UI", 12.0F, FontStyle.Regular);
                    labellist[j].ForeColor = Color.Black;

                }
                //Console.WriteLine(feat[i]);
                
                //for (int k = 0; k < strfeatures.Count; k++)
                //{
                //    if (strfeatures[k] == feat[i])
                //    {
                //        comboboxlist[i] = new ComboBox();
                //        comboboxlist[i].Location = new Point(340, ypos);
                //        comboboxlist[i].Size = new System.Drawing.Size(60, 10);
                //        //comboboxlist[i].Text += new EventHandler(b1_Click);
                //        comboboxlist[i].Text = "0";
                //        comboboxlist[i].Font = new Font("Century Gothic", 8);
                //        comboboxlist[i].Items.Add(".obj");
                //        comboboxlist[i].Items.Add(".fbx");
                //        comboboxlist[i].Items.Add(".htl");
                //    }
                //    else
                //    {
                //        icheckboxlist[i] = new TextBox();
                //        icheckboxlist[i].Location = new Point(340, ypos);
                //        icheckboxlist[i].BorderStyle = BorderStyle.None;
                //        icheckboxlist[i].Size = new System.Drawing.Size(60, 50);
                //        icheckboxlist[i].Text = String.Empty;
                //        icheckboxlist[i].TabStop = false;
                //        icheckboxlist[i].Font = new System.Drawing.Font("Segoe UI", 12.0F, FontStyle.Regular);
                //        icheckboxlist[i].TextAlign = HorizontalAlignment.Center;
                //    }
                //}


                icheckboxlist[i] = new TextBox();
                icheckboxlist[i].Location = new Point(280, ypos);
                icheckboxlist[i].BorderStyle = BorderStyle.None;
                icheckboxlist[i].Size = new System.Drawing.Size(80, 50);
                icheckboxlist[i].Text = String.Empty;
                icheckboxlist[i].TabStop = false;
                icheckboxlist[i].Font = new System.Drawing.Font("Segoe UI", 12.0F, FontStyle.Regular);
                icheckboxlist[i].TextAlign = HorizontalAlignment.Center;
                



                inputpanel.Controls.Add(icheckboxlist[i]);
                inputpanel.Controls.Add(labellist[i]);

                icheckboxlist[i].TextChanged += new EventHandler(predictgreen);

                ypos += 32;
                //ypos1 += 60;
                //icheckboxlist[i].OnChange += new EventHandler(chkcheckboxes);
            }



        }

        public void test_OLS()
        {
            string default_testols = @"import pickle
import sys
import getopt
import numpy as np
import pandas as pd
pkl_filename = ""LinearRegression.pkl""
with open(pkl_filename, 'rb') as file:
    pickle_model = pickle.load(file)


def main(argv):
    newinputvalues = []
    newvalues = []
    mapping = { }
    mapping1 = { }
    mapping2 = { }
    try:
        opts, args = getopt.getopt(argv, ""i:"",[""ifile=""])
    except getopt.GetoptError:
        print(""Pythonfile.py -i <inputvalues>"")
        sys.exit(2)
    for opt, arg in opts:
        if opt in (""-i"", ""--ifile""):
            inputvalue = arg
        else:
            print(""Pythonfile.py -i <inputvalues>"")
            sys.exit()
        
    try:
        value = float(inputvalue)
    except ValueError as e:
        
         for s in list(inputvalue.split("","")):
             if type(s) != str:
                if s.isdigit() and s.isdecimal():   # only digits
                    for i in inputvalue.split("",""):
                        newinputvalues.append(float(i))
                    Xtest = [newinputvalues]
                    Ypredict = pickle_model.predict(Xtest)
                    print(Ypredict[0][0])
                    break
             else:
                if (""could not convert string to float: "" == str(e)[:35]):
                    df = pd.read_csv(r"""+ MachineLearningToolv3.MLTool.datafilename +@""")
                    df = df.dropna()
                    stringname = str(e)[35:]
                    first = stringname[1:]
                    tt = df.apply(lambda x: x.astype(str).str.startswith(first[:-1]).any()).idxmax()
                    cnt = 0
                    for i in df[tt].unique():
                        mapping[i] = cnt
                        cnt = cnt + 1
                    df[tt] = df[tt].apply(lambda x: mapping[x])
                    try:
                        Xtest = [[mapping[first[:-1]]]]
                        Ypredict = pickle_model.predict(Xtest)
                        print(Ypredict[0][0])
                        break
                    except:
                        try:    #mulitple strings
                            for s in list(inputvalue.split(',')):   
                                df = pd.read_csv(r"""+ MachineLearningToolv3.MLTool.datafilename +@""")
                                df = df.dropna()
                                tt = df.apply(lambda x: x.astype(str).str.startswith(s).any()).idxmax()
                                cnt = 0
                                for i in df[tt].unique():
                                    mapping1[i] = cnt
                                    cnt = cnt + 1
                                df[tt] = df[tt].apply(lambda x: mapping1[x])
                            list1 =[]
                            for k in list(inputvalue.split(',')):
                                list1.append(mapping1[k])
                            Xtest = [list1]
                            Ypredict = pickle_model.predict(Xtest)
                            print(Ypredict[0][0])
                            break
                        except:
                            while True:
                                try:   #mix strings and num
                                    list2 = list(inputvalue.split(','))
                                    for l in list(inputvalue.split(',')):
                                        if type(l) == str:
                                            if not l.isdigit() and not l.isdecimal():
                                                df = pd.read_csv(r"""+ MachineLearningToolv3.MLTool.datafilename +@""")
                                                df = df.dropna()
                                                tt = df.apply(lambda x: x.astype(str).str.startswith(l).any()).idxmax()
                                                cnt = 0
                                                for i in df[tt].unique():
                                                    mapping2[i] = cnt
                                                    cnt = cnt + 1
                                                df[tt] = df[tt].apply(lambda x: mapping2[x])
                                                try:
                                                    list2[(list(inputvalue.split(',')).index(l))] = mapping2[l]
                                                except KeyError:
                                                    pass
                                    for m in list2:
                                        newvalues.append(float(m))
                                    Xtest1 = [newvalues]
                                    Ypredict = pickle_model.predict(Xtest1)
                                    print(Ypredict[0][0])
                                    break
                                except:
                                    list2 = list(inputvalue.split(','))
                                    for l in list(inputvalue.split(',')):
                                        if type(l) == str:
                                            if not l.isdigit() and not l.isdecimal:
                                                df = pd.read_csv(r"""+ MachineLearningToolv3.MLTool.datafilename +@""")
                                                df = df.dropna()
                                                tt = df.apply(lambda x: x.astype(str).str.startswith(l).any()).idxmax()
                                                cnt = 0
                                                for i in df[tt].unique():
                                                    mapping2[i] = cnt
                                                    cnt = cnt + 1
                                                df[tt] = df[tt].apply(lambda x: mapping2[x])
                                                try:
                                                    list2[(list(inputvalue.split(',')).index(l))] = mapping2[l]
                                                except KeyError:
                                                    pass
                                    for m in list2:
                                        newvalues.append(float(m))
                                    Xtest1 = [newvalues]
                                    Ypredict = pickle_model.predict(Xtest1)
                                    print(Ypredict[0][0])
                                    break


                        break
    else:
        Xtest = [[value]]
        Ypredict = pickle_model.predict(Xtest)
        print(Ypredict[0][0])


if __name__ == ""__main__"":
    main(sys.argv[1:])";

            string from = Application.StartupPath + "/LinearRegression_Test.py";
            using (StreamWriter file = new StreamWriter(from))
            {

                file.WriteLine(default_testols);

            }

        }

        public void test_SGD()
        {
            string default_testsgd = @"import pickle
import sys
import getopt
import numpy as np
import pandas as pd
pkl_filename = ""SGD.pkl""
with open(pkl_filename, 'rb') as file:
    pickle_model = pickle.load(file)


def main(argv):
    newinputvalues = []
    newvalues = []
    mapping = { }
    mapping1 = { }
    mapping2 = { }
    try:
        opts, args = getopt.getopt(argv, ""i:"",[""ifile=""])
    except getopt.GetoptError:
        print(""Pythonfile.py -i <inputvalues>"")
        sys.exit(2)
    for opt, arg in opts:
        if opt in (""-i"", ""--ifile""):
            inputvalue = arg
        else:
            print(""Pythonfile.py -i <inputvalues>"")
            sys.exit()
    try:
        value = float(inputvalue)
    except ValueError as e:
        
         for s in list(inputvalue.split("","")):
             if type(s) != str:
                if s.isdigit() and s.isdecimal():   # only digits
                    for i in inputvalue.split("",""):
                        newinputvalues.append(float(i))
                    Xtest = [newinputvalues]
                    Ypredict = pickle_model.predict(Xtest)
                    print(Ypredict[0])
                    break
             else:
                if (""could not convert string to float: "" == str(e)[:35]):
                    df = pd.read_csv(r"""+ MachineLearningToolv3.MLTool.datafilename +@""")
                    df = df.dropna()
                    stringname = str(e)[35:]
                    first = stringname[1:]
                    tt = df.apply(lambda x: x.astype(str).str.startswith(first[:-1]).any()).idxmax()
                    cnt = 0
                    for i in df[tt].unique():
                        mapping[i] = cnt
                        cnt = cnt + 1
                    df[tt] = df[tt].apply(lambda x: mapping[x])
                    try:
                        Xtest = [[mapping[first[:-1]]]]
                        Ypredict = pickle_model.predict(Xtest)
                        print(Ypredict[0])
                        break
                    except:
                        try:    #mulitple strings
                            for s in list(inputvalue.split(',')):   
                                df = pd.read_csv(r"""+ MachineLearningToolv3.MLTool.datafilename +@""")
                                df = df.dropna()
                                tt = df.apply(lambda x: x.astype(str).str.startswith(s).any()).idxmax()
                                cnt = 0
                                for i in df[tt].unique():
                                    mapping1[i] = cnt
                                    cnt = cnt + 1
                                df[tt] = df[tt].apply(lambda x: mapping1[x])
                            list1 =[]
                            for k in list(inputvalue.split(',')):
                                list1.append(mapping1[k])
                            Xtest = [list1]
                            Ypredict = pickle_model.predict(Xtest)
                            print(Ypredict[0])

                            break
                        except:
                            while True:
                                try:   #mix strings and num
                                    list2 = list(inputvalue.split(','))
                                    for l in list(inputvalue.split(',')):
                                        if type(l) == str:
                                            if not l.isdigit() and not l.isdecimal():
                                                df = pd.read_csv(r"""+ MachineLearningToolv3.MLTool.datafilename +@""")
                                                df = df.dropna()
                                                tt = df.apply(lambda x: x.astype(str).str.startswith(l).any()).idxmax()
                                                cnt = 0
                                                for i in df[tt].unique():
                                                    mapping2[i] = cnt
                                                    cnt = cnt + 1
                                                df[tt] = df[tt].apply(lambda x: mapping2[x])
                                                try:
                                                    list2[(list(inputvalue.split(',')).index(l))] = mapping2[l]
                                                except KeyError:
                                                    pass
                                    for m in list2:
                                        newvalues.append(float(m))
                                    Xtest1 = [newvalues]
                                    Ypredict = pickle_model.predict(Xtest1)
                                    print(Ypredict[0])
                                    break
                                except:
                                    list2 = list(inputvalue.split(','))
                                    for l in list(inputvalue.split(',')):
                                        if type(l) == str:
                                            if not l.isdigit() and not l.isdecimal:
                                                df = pd.read_csv(r"""+ MachineLearningToolv3.MLTool.datafilename +@""")
                                                df = df.dropna()
                                                tt = df.apply(lambda x: x.astype(str).str.startswith(l).any()).idxmax()
                                                cnt = 0
                                                for i in df[tt].unique():
                                                    mapping2[i] = cnt
                                                    cnt = cnt + 1
                                                df[tt] = df[tt].apply(lambda x: mapping2[x])
                                                try:
                                                    list2[(list(inputvalue.split(',')).index(l))] = mapping2[l]
                                                except KeyError:
                                                    pass
                                    for m in list2:
                                        newvalues.append(float(m))
                                    Xtest1 = [newvalues]
                                    Ypredict = pickle_model.predict(Xtest1)
                                    print(Ypredict[0])
                                    break
                        break
    else:
        Xtest = [[value]]
        Ypredict = pickle_model.predict(Xtest)
        print(Ypredict[0])

if __name__ == ""__main__"":
    main(sys.argv[1:])";
            string from = Application.StartupPath + "/SGD_Test.py";
            using (StreamWriter file = new StreamWriter(from))
            {

                file.WriteLine(default_testsgd);

            }
        }

        public void test_DTR()
        {
            String default_testDTR = @"import pickle
import sys
import getopt
import numpy as np
import pandas as pd
pkl_filename = ""DTR.pkl""
with open(pkl_filename, 'rb') as file:
    pickle_model = pickle.load(file)


def main(argv):
    newinputvalues = []
    newvalues = []
    mapping = { }
    mapping1 = { }
    mapping2 = { }
    try:
        opts, args = getopt.getopt(argv, ""i:"",[""ifile=""])
    except getopt.GetoptError:
        print(""Pythonfile.py -i <inputvalues>"")
        sys.exit(2)
    for opt, arg in opts:
        if opt in (""-i"", ""--ifile""):
            inputvalue = arg
        else:
            print(""Pythonfile.py -i <inputvalues>"")
            sys.exit()
    try:
        value = float(inputvalue)
    except ValueError as e:
         for s in list(inputvalue.split("","")):
             if type(s) != str:
                if s.isdigit() and s.isdecimal():   # only digits
                    for i in inputvalue.split("",""):
                        newinputvalues.append(float(i))
                    Xtest = [newinputvalues]
                    Ypredict = pickle_model.predict(Xtest)
                    print(Ypredict[0])
                    break
             else:
                if (""could not convert string to float: "" == str(e)[:35]):
                    df = pd.read_csv(r"""+ MachineLearningToolv3.MLTool.datafilename +@""")
                    df = df.dropna()
                    stringname = str(e)[35:]
                    first = stringname[1:]
                    tt = df.apply(lambda x: x.astype(str).str.startswith(first[:-1]).any()).idxmax()
                    cnt = 0
                    for i in df[tt].unique():
                        mapping[i] = cnt
                        cnt = cnt + 1
                    df[tt] = df[tt].apply(lambda x: mapping[x])
                    try:
                        Xtest = [[mapping[first[:-1]]]]
                        Ypredict = pickle_model.predict(Xtest)
                        print(Ypredict[0])
                        break
                    except:
                        try:    #mulitple strings
                            for s in list(inputvalue.split(',')):   
                                df = pd.read_csv(r"""+ MachineLearningToolv3.MLTool.datafilename +@""")
                                df = df.dropna()
                                tt = df.apply(lambda x: x.astype(str).str.startswith(s).any()).idxmax()
                                cnt = 0
                                for i in df[tt].unique():
                                    mapping1[i] = cnt
                                    cnt = cnt + 1
                                df[tt] = df[tt].apply(lambda x: mapping1[x])
                            list1 =[]
                            for k in list(inputvalue.split(',')):
                                list1.append(mapping1[k])
                            Xtest = [list1]
                            Ypredict = pickle_model.predict(Xtest)
                            print(Ypredict[0])

                            break
                        except:
                            while True:
                                try:   #mix strings and num
                                    list2 = list(inputvalue.split(','))
                                    for l in list(inputvalue.split(',')):
                                        if type(l) == str:
                                            if not l.isdigit() and not l.isdecimal():
                                                df = pd.read_csv(r"""+ MachineLearningToolv3.MLTool.datafilename +@""")
                                                df = df.dropna()
                                                tt = df.apply(lambda x: x.astype(str).str.startswith(l).any()).idxmax()
                                                cnt = 0
                                                for i in df[tt].unique():
                                                    mapping2[i] = cnt
                                                    cnt = cnt + 1
                                                df[tt] = df[tt].apply(lambda x: mapping2[x])
                                                try:
                                                    list2[(list(inputvalue.split(',')).index(l))] = mapping2[l]
                                                except KeyError:
                                                    pass
                                    for m in list2:
                                        newvalues.append(float(m))
                                    Xtest1 = [newvalues]
                                    Ypredict = pickle_model.predict(Xtest1)
                                    print(Ypredict[0])
                                    break
                                except:
                                    list2 = list(inputvalue.split(','))
                                    for l in list(inputvalue.split(',')):
                                        if type(l) == str:
                                            if not l.isdigit() and not l.isdecimal:
                                                df = pd.read_csv(r"""+ MachineLearningToolv3.MLTool.datafilename +@""")
                                                df = df.dropna()
                                                tt = df.apply(lambda x: x.astype(str).str.startswith(l).any()).idxmax()
                                                cnt = 0
                                                for i in df[tt].unique():
                                                    mapping2[i] = cnt
                                                    cnt = cnt + 1
                                                df[tt] = df[tt].apply(lambda x: mapping2[x])
                                                try:
                                                    list2[(list(inputvalue.split(',')).index(l))] = mapping2[l]
                                                except KeyError:
                                                    pass
                                    for m in list2:
                                        newvalues.append(float(m))
                                    Xtest1 = [newvalues]
                                    Ypredict = pickle_model.predict(Xtest1)
                                    print(Ypredict[0])
                                    break
                        break
    else:
        Xtest = [[value]]
        Ypredict = pickle_model.predict(Xtest)
        print(Ypredict[0])


if __name__ == ""__main__"":
    main(sys.argv[1:])";

            string from = Application.StartupPath + "/DTR_Test.py";
            using (StreamWriter file = new StreamWriter(from))
            {

                file.WriteLine(default_testDTR);

            }
        }

        public void test_RFR()
        {
            string default_testRFR = @"import pickle
import sys
import getopt
import numpy as np
import pandas as pd
pkl_filename = ""RFR.pkl""
with open(pkl_filename, 'rb') as file:
    pickle_model = pickle.load(file)


def main(argv):
    newinputvalues = []
    newvalues = []
    mapping = { }
    mapping1 = { }
    mapping2 = { }
    try:
        opts, args = getopt.getopt(argv, ""i:"",[""ifile=""])
    except getopt.GetoptError:
        print(""Pythonfile.py -i <inputvalues>"")
        sys.exit(2)
    for opt, arg in opts:
        if opt in (""-i"", ""--ifile""):
            inputvalue = arg
        else:
            print(""Pythonfile.py -i <inputvalues>"")
            sys.exit()
    try:
        value = float(inputvalue)
    except ValueError as e:
         for s in list(inputvalue.split("","")):
             if type(s) != str:
                if s.isdigit() and s.isdecimal():   # only digits
                    for i in inputvalue.split("",""):
                        newinputvalues.append(float(i))
                    Xtest = [newinputvalues]
                    Ypredict = pickle_model.predict(Xtest)
                    print(Ypredict[0])
                    break
             else:
                if (""could not convert string to float: "" == str(e)[:35]):
                    df = pd.read_csv(r"""+ MachineLearningToolv3.MLTool.datafilename +@""")
                    df = df.dropna()
                    stringname = str(e)[35:]
                    first = stringname[1:]
                    tt = df.apply(lambda x: x.astype(str).str.startswith(first[:-1]).any()).idxmax()
                    cnt = 0
                    for i in df[tt].unique():
                        mapping[i] = cnt
                        cnt = cnt + 1
                    df[tt] = df[tt].apply(lambda x: mapping[x])
                    try:
                        Xtest = [[mapping[first[:-1]]]]
                        Ypredict = pickle_model.predict(Xtest)
                        print(Ypredict[0])
                        break
                    except:
                        try:    #mulitple strings
                            for s in list(inputvalue.split(',')):   
                                df = pd.read_csv(r"""+ MachineLearningToolv3.MLTool.datafilename +@""")
                                df = df.dropna()
                                tt = df.apply(lambda x: x.astype(str).str.startswith(s).any()).idxmax()
                                cnt = 0
                                for i in df[tt].unique():
                                    mapping1[i] = cnt
                                    cnt = cnt + 1
                                df[tt] = df[tt].apply(lambda x: mapping1[x])
                            list1 =[]
                            for k in list(inputvalue.split(',')):
                                list1.append(mapping1[k])
                            Xtest = [list1]
                            Ypredict = pickle_model.predict(Xtest)
                            print(Ypredict[0])

                            break
                        except:
                            while True:
                                try:   #mix strings and num
                                    list2 = list(inputvalue.split(','))
                                    for l in list(inputvalue.split(',')):
                                        if type(l) == str:
                                            if not l.isdigit() and not l.isdecimal():
                                                df = pd.read_csv(r"""+ MachineLearningToolv3.MLTool.datafilename +@""")
                                                df = df.dropna()
                                                tt = df.apply(lambda x: x.astype(str).str.startswith(l).any()).idxmax()
                                                cnt = 0
                                                for i in df[tt].unique():
                                                    mapping2[i] = cnt
                                                    cnt = cnt + 1
                                                df[tt] = df[tt].apply(lambda x: mapping2[x])
                                                try:
                                                    list2[(list(inputvalue.split(',')).index(l))] = mapping2[l]
                                                except KeyError:
                                                    pass
                                    for m in list2:
                                        newvalues.append(float(m))
                                    Xtest1 = [newvalues]
                                    Ypredict = pickle_model.predict(Xtest1)
                                    print(Ypredict[0])
                                    break
                                except:
                                    list2 = list(inputvalue.split(','))
                                    for l in list(inputvalue.split(',')):
                                        if type(l) == str:
                                            if not l.isdigit() and not l.isdecimal:
                                                df = pd.read_csv(r"""+ MachineLearningToolv3.MLTool.datafilename +@""")
                                                df = df.dropna()
                                                tt = df.apply(lambda x: x.astype(str).str.startswith(l).any()).idxmax()
                                                cnt = 0
                                                for i in df[tt].unique():
                                                    mapping2[i] = cnt
                                                    cnt = cnt + 1
                                                df[tt] = df[tt].apply(lambda x: mapping2[x])
                                                try:
                                                    list2[(list(inputvalue.split(',')).index(l))] = mapping2[l]
                                                except KeyError:
                                                    pass
                                    for m in list2:
                                        newvalues.append(float(m))
                                    Xtest1 = [newvalues]
                                    Ypredict = pickle_model.predict(Xtest1)
                                    print(Ypredict[0])
                                    break
                        break
    else:
        Xtest = [[value]]
        Ypredict = pickle_model.predict(Xtest)
        print(Ypredict[0])


if __name__ == ""__main__"":
    main(sys.argv[1:])";

            string from = Application.StartupPath + "/RFR_Test.py";
            using (StreamWriter file = new StreamWriter(from))
            {

                file.WriteLine(default_testRFR);

            }

        }

        public void test_perceptron()
        {
            string default_testpercep = @"import pickle
import sys
import getopt
import numpy as np
import pandas as pd
pkl_filename = ""Perceptron.pkl""
with open(pkl_filename, 'rb') as file:
    pickle_model = pickle.load(file)


def main(argv):
    newinputvalues = []
    newvalues = []
    mapping = { }
    mapping1 = { }
    mapping2 = { }
    try:
        opts, args = getopt.getopt(argv, ""i:"",[""ifile=""])
    except getopt.GetoptError:
        print(""Pythonfile.py -i <inputvalues>"")
        sys.exit(2)
    for opt, arg in opts:
        if opt in (""-i"", ""--ifile""):
            inputvalue = arg
        else:
            print(""Pythonfile.py -i <inputvalues>"")
            sys.exit()
    try:
        value = float(inputvalue)
    except ValueError as e:
         for s in list(inputvalue.split("","")):
             if type(s) != str:
                if s.isdigit() and s.isdecimal():   # only digits
                    for i in inputvalue.split("",""):
                        newinputvalues.append(float(i))
                    Xtest = [newinputvalues]
                    Ypredict = pickle_model.predict(Xtest)
                    print(Ypredict[0])
                    break
             else:
                if (""could not convert string to float: "" == str(e)[:35]):
                    df = pd.read_csv(r"""+ MachineLearningToolv3.MLTool.datafilename +@""")
                    df = df.dropna()
                    stringname = str(e)[35:]
                    first = stringname[1:]
                    tt = df.apply(lambda x: x.astype(str).str.startswith(first[:-1]).any()).idxmax()
                    cnt = 0
                    for i in df[tt].unique():
                        mapping[i] = cnt
                        cnt = cnt + 1
                    df[tt] = df[tt].apply(lambda x: mapping[x])
                    try:
                        Xtest = [[mapping[first[:-1]]]]
                        Ypredict = pickle_model.predict(Xtest)
                        print(Ypredict[0])
                        break
                    except:
                        try:    #mulitple strings
                            for s in list(inputvalue.split(',')):   
                                df = pd.read_csv(r"""+ MachineLearningToolv3.MLTool.datafilename +@""")
                                df = df.dropna()
                                tt = df.apply(lambda x: x.astype(str).str.startswith(s).any()).idxmax()
                                cnt = 0
                                for i in df[tt].unique():
                                    mapping1[i] = cnt
                                    cnt = cnt + 1
                                df[tt] = df[tt].apply(lambda x: mapping1[x])
                            list1 =[]
                            for k in list(inputvalue.split(',')):
                                list1.append(mapping1[k])
                            Xtest = [list1]
                            Ypredict = pickle_model.predict(Xtest)
                            print(Ypredict[0])

                            break
                        except:
                            while True:
                                try:   #mix strings and num
                                    list2 = list(inputvalue.split(','))
                                    for l in list(inputvalue.split(',')):
                                        if type(l) == str:
                                            if not l.isdigit() and not l.isdecimal():
                                                df = pd.read_csv(r"""+ MachineLearningToolv3.MLTool.datafilename +@""")
                                                df = df.dropna()
                                                tt = df.apply(lambda x: x.astype(str).str.startswith(l).any()).idxmax()
                                                cnt = 0
                                                for i in df[tt].unique():
                                                    mapping2[i] = cnt
                                                    cnt = cnt + 1
                                                df[tt] = df[tt].apply(lambda x: mapping2[x])
                                                try:
                                                    list2[(list(inputvalue.split(',')).index(l))] = mapping2[l]
                                                except KeyError:
                                                    pass
                                    for m in list2:
                                        newvalues.append(float(m))
                                    Xtest1 = [newvalues]
                                    Ypredict = pickle_model.predict(Xtest1)
                                    print(Ypredict[0])
                                    break
                                except:
                                    list2 = list(inputvalue.split(','))
                                    for l in list(inputvalue.split(',')):
                                        if type(l) == str:
                                            if not l.isdigit() and not l.isdecimal:
                                                df = pd.read_csv(r"""+ MachineLearningToolv3.MLTool.datafilename +@""")
                                                df = df.dropna()
                                                tt = df.apply(lambda x: x.astype(str).str.startswith(l).any()).idxmax()
                                                cnt = 0
                                                for i in df[tt].unique():
                                                    mapping2[i] = cnt
                                                    cnt = cnt + 1
                                                df[tt] = df[tt].apply(lambda x: mapping2[x])
                                                try:
                                                    list2[(list(inputvalue.split(',')).index(l))] = mapping2[l]
                                                except KeyError:
                                                    pass
                                    for m in list2:
                                        newvalues.append(float(m))
                                    Xtest1 = [newvalues]
                                    Ypredict = pickle_model.predict(Xtest1)
                                    print(Ypredict[0])
                                    break
                        break
    else:
        Xtest = [[value]]
        Ypredict = pickle_model.predict(Xtest)
        print(Ypredict[0])


if __name__ == ""__main__"":
    main(sys.argv[1:])";


            string from = Application.StartupPath + "/Perceptron_Test.py";
            using (StreamWriter file = new StreamWriter(from))
            {

                file.WriteLine(default_testpercep);

            }
        }

        public void test_DTC()
        {
            string default_DTC = @"import pickle
import sys
import getopt
import numpy as np
import pandas as pd
pkl_filename = ""DTC.pkl""
with open(pkl_filename, 'rb') as file:
    pickle_model = pickle.load(file)


def main(argv):
    newinputvalues = []
    newvalues = []
    mapping = { }
    mapping1 = { }
    mapping2 = { }
    try:
        opts, args = getopt.getopt(argv, ""i:"",[""ifile=""])
    except getopt.GetoptError:
        print(""Pythonfile.py -i <inputvalues>"")
        sys.exit(2)
    for opt, arg in opts:
        if opt in (""-i"", ""--ifile""):
            inputvalue = arg
        else:
            print(""Pythonfile.py -i <inputvalues>"")
            sys.exit()
    try:
        value = float(inputvalue)
    except ValueError as e:
         for s in list(inputvalue.split("","")):
             if type(s) != str:
                if s.isdigit() and s.isdecimal():   # only digits
                    for i in inputvalue.split("",""):
                        newinputvalues.append(float(i))
                    Xtest = [newinputvalues]
                    Ypredict = pickle_model.predict(Xtest)
                    print(Ypredict[0])
                    break
             else:
                if (""could not convert string to float: "" == str(e)[:35]):
                    df = pd.read_csv(r"""+ MachineLearningToolv3.MLTool.datafilename +@""")
                    df = df.dropna()
                    stringname = str(e)[35:]
                    first = stringname[1:]
                    tt = df.apply(lambda x: x.astype(str).str.startswith(first[:-1]).any()).idxmax()
                    cnt = 0
                    for i in df[tt].unique():
                        mapping[i] = cnt
                        cnt = cnt + 1
                    df[tt] = df[tt].apply(lambda x: mapping[x])
                    try:
                        Xtest = [[mapping[first[:-1]]]]
                        Ypredict = pickle_model.predict(Xtest)
                        print(Ypredict[0])
                        break
                    except:
                        try:    #mulitple strings
                            for s in list(inputvalue.split(',')):   
                                df = pd.read_csv(r"""+ MachineLearningToolv3.MLTool.datafilename +@""")
                                df = df.dropna()
                                tt = df.apply(lambda x: x.astype(str).str.startswith(s).any()).idxmax()
                                cnt = 0
                                for i in df[tt].unique():
                                    mapping1[i] = cnt
                                    cnt = cnt + 1
                                df[tt] = df[tt].apply(lambda x: mapping1[x])
                            list1 =[]
                            for k in list(inputvalue.split(',')):
                                list1.append(mapping1[k])
                            Xtest = [list1]
                            Ypredict = pickle_model.predict(Xtest)
                            print(Ypredict[0])

                            break
                        except:
                            while True:
                                try:   #mix strings and num
                                    list2 = list(inputvalue.split(','))
                                    for l in list(inputvalue.split(',')):
                                        if type(l) == str:
                                            if not l.isdigit() and not l.isdecimal():
                                                df = pd.read_csv(r""" + MachineLearningToolv3.MLTool.datafilename + @""")
                                                df = df.dropna()
                                                tt = df.apply(lambda x: x.astype(str).str.startswith(l).any()).idxmax()
                                                cnt = 0
                                                for i in df[tt].unique():
                                                    mapping2[i] = cnt
                                                    cnt = cnt + 1
                                                df[tt] = df[tt].apply(lambda x: mapping2[x])
                                                try:
                                                    list2[(list(inputvalue.split(',')).index(l))] = mapping2[l]
                                                except KeyError:
                                                    pass
                                    for m in list2:
                                        newvalues.append(float(m))
                                    Xtest1 = [newvalues]
                                    Ypredict = pickle_model.predict(Xtest1)
                                    print(Ypredict[0])
                                    break
                                except:
                                    list2 = list(inputvalue.split(','))
                                    for l in list(inputvalue.split(',')):
                                        if type(l) == str:
                                            if not l.isdigit() and not l.isdecimal:
                                                df = pd.read_csv(r"""+ MachineLearningToolv3.MLTool.datafilename +@""")
                                                df = df.dropna()
                                                tt = df.apply(lambda x: x.astype(str).str.startswith(l).any()).idxmax()
                                                cnt = 0
                                                for i in df[tt].unique():
                                                    mapping2[i] = cnt
                                                    cnt = cnt + 1
                                                df[tt] = df[tt].apply(lambda x: mapping2[x])
                                                try:
                                                    list2[(list(inputvalue.split(',')).index(l))] = mapping2[l]
                                                except KeyError:
                                                    pass
                                    for m in list2:
                                        newvalues.append(float(m))
                                    Xtest1 = [newvalues]
                                    Ypredict = pickle_model.predict(Xtest1)
                                    print(Ypredict[0])
                                    break
                        break
    else:
        Xtest = [[value]]
        Ypredict = pickle_model.predict(Xtest)
        print(Ypredict[0])


if __name__ == ""__main__"":
    main(sys.argv[1:])";

            string from = Application.StartupPath + "/DTC_Test.py";
            using (StreamWriter file = new StreamWriter(from))
            {

                file.WriteLine(default_DTC);

            }
        }

        public void test_RFC()
        {
            string default_RFC = @"import pickle
import sys
import getopt
import numpy as np
import pandas as pd
pkl_filename = ""RFC.pkl""
with open(pkl_filename, 'rb') as file:
    pickle_model = pickle.load(file)


def main(argv):
    newinputvalues = []
    newvalues = []
    mapping = { }
    mapping1 = { }
    mapping2 = { }
    try:
        opts, args = getopt.getopt(argv, ""i:"",[""ifile=""])
    except getopt.GetoptError:
        print(""Pythonfile.py -i <inputvalues>"")
        sys.exit(2)
    for opt, arg in opts:
        if opt in (""-i"", ""--ifile""):
            inputvalue = arg
        else:
            print(""Pythonfile.py -i <inputvalues>"")
            sys.exit()
    try:
        value = float(inputvalue)
    except ValueError as e:
         for s in list(inputvalue.split("","")):
             if type(s) != str:
                if s.isdigit() and s.isdecimal():   # only digits
                    for i in inputvalue.split("",""):
                        newinputvalues.append(float(i))
                    Xtest = [newinputvalues]
                    Ypredict = pickle_model.predict(Xtest)
                    print(Ypredict[0])
                    break
             else:
                if (""could not convert string to float: "" == str(e)[:35]):
                    df = pd.read_csv(r""" + MachineLearningToolv3.MLTool.datafilename + @""")
                    df = df.dropna()
                    stringname = str(e)[35:]
                    first = stringname[1:]
                    tt = df.apply(lambda x: x.astype(str).str.startswith(first[:-1]).any()).idxmax()
                    cnt = 0
                    for i in df[tt].unique():
                        mapping[i] = cnt
                        cnt = cnt + 1
                    df[tt] = df[tt].apply(lambda x: mapping[x])
                    try:
                        Xtest = [[mapping[first[:-1]]]]
                        Ypredict = pickle_model.predict(Xtest)
                        print(Ypredict[0])
                        break
                    except:
                        try:    #mulitple strings
                            for s in list(inputvalue.split(',')):   
                                df = pd.read_csv(r""" + MachineLearningToolv3.MLTool.datafilename + @""")
                                df = df.dropna()
                                tt = df.apply(lambda x: x.astype(str).str.startswith(s).any()).idxmax()
                                cnt = 0
                                for i in df[tt].unique():
                                    mapping1[i] = cnt
                                    cnt = cnt + 1
                                df[tt] = df[tt].apply(lambda x: mapping1[x])
                            list1 =[]
                            for k in list(inputvalue.split(',')):
                                list1.append(mapping1[k])
                            Xtest = [list1]
                            Ypredict = pickle_model.predict(Xtest)
                            print(Ypredict[0])

                            break
                        except:
                            while True:
                                try:   #mix strings and num
                                    list2 = list(inputvalue.split(','))
                                    for l in list(inputvalue.split(',')):
                                        if type(l) == str:
                                            if not l.isdigit() and not l.isdecimal():
                                                df = pd.read_csv(r""" + MachineLearningToolv3.MLTool.datafilename + @""")
                                                df = df.dropna()
                                                tt = df.apply(lambda x: x.astype(str).str.startswith(l).any()).idxmax()
                                                cnt = 0
                                                for i in df[tt].unique():
                                                    mapping2[i] = cnt
                                                    cnt = cnt + 1
                                                df[tt] = df[tt].apply(lambda x: mapping2[x])
                                                try:
                                                    list2[(list(inputvalue.split(',')).index(l))] = mapping2[l]
                                                except KeyError:
                                                    pass
                                    for m in list2:
                                        newvalues.append(float(m))
                                    Xtest1 = [newvalues]
                                    Ypredict = pickle_model.predict(Xtest1)
                                    print(Ypredict[0])
                                    break
                                except:
                                    list2 = list(inputvalue.split(','))
                                    for l in list(inputvalue.split(',')):
                                        if type(l) == str:
                                            if not l.isdigit() and not l.isdecimal:
                                                df = pd.read_csv(r""" + MachineLearningToolv3.MLTool.datafilename + @""")
                                                df = df.dropna()
                                                tt = df.apply(lambda x: x.astype(str).str.startswith(l).any()).idxmax()
                                                cnt = 0
                                                for i in df[tt].unique():
                                                    mapping2[i] = cnt
                                                    cnt = cnt + 1
                                                df[tt] = df[tt].apply(lambda x: mapping2[x])
                                                try:
                                                    list2[(list(inputvalue.split(',')).index(l))] = mapping2[l]
                                                except KeyError:
                                                    pass
                                    for m in list2:
                                        newvalues.append(float(m))
                                    Xtest1 = [newvalues]
                                    Ypredict = pickle_model.predict(Xtest1)
                                    print(Ypredict[0])
                                    break
                        break
    else:
        Xtest = [[value]]
        Ypredict = pickle_model.predict(Xtest)
        print(Ypredict[0])


if __name__ == ""__main__"":
    main(sys.argv[1:])";

            string from = Application.StartupPath + "/RFC_Test.py";
            using (StreamWriter file = new StreamWriter(from))
            {

                file.WriteLine(default_RFC);

            }
        }
    }
}
