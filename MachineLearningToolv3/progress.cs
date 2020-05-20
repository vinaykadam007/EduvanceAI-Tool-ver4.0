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

namespace MachineLearningToolv3
{
    public partial class progress : Form
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

        public progress()
        {
            InitializeComponent();
            Init0.ProgressColor = Color.Silver;
            Init.ProgressColor = Color.Silver;
            dataread.ProgressColor = Color.Silver;
            modelbuild.ProgressColor = Color.Silver;
            finishing.ProgressColor = Color.Silver;

            label1.Visible = false;
            label2.Visible = false;
            label4.Visible = false;
            label5.Visible = false;

            // Initiate.Visible = false;
            // datareading.Visible = false;
            // modelbuilding.Visible = false;
            // finished.Visible = false;

            Init0.Value = 100;
            Init.Value = 100;
            dataread.Value = 100;
            modelbuild.Value = 100;
            finishing.Value = 100;
            Init0.Visible = true;

            init0tick.Visible = false;
            inittick.Visible = false;
            datareadtick.Visible = false;
            modelbuildtick.Visible = false;
            finishtick.Visible = false;
            Init.animated = false;
            //init, dataread, modelbuild, finishing
        }
        public System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer timer3 = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer timer4 = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer timer5 = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer timer6 = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer endtimer = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer timer0 = new System.Windows.Forms.Timer();
        public int step1 = 0;
        public int step2 = 0;
        public int step3 = 0;
        public int step4 = 0;
        public int step5 = 0;
        public void init_timer(object sender, EventArgs e)
        {





        }
        public int init0 = 0;

        public async void init0_timer(object sender, EventArgs e)
        {
           
            init0 = init0 + 1;


            if (init0 == 1)
            {
                init0tick.Visible = true;
                label3.Visible = false;
                label6.Left = 30;
                label6.Text = "Initialization \r\nCompleted";
                label6.ForeColor = Color.Green;
                Init0.animated = false;
                label4.Visible = true;
                label7.Text = "Click on Step 2 to continue";

                await Task.Delay(150);

                for (int i = 0; i < 100; i++)
                {
                    bunifuProgressBar4.Value = i;
                    bunifuProgressBar4.Update();
                    System.Threading.Thread.Sleep(1);
                }
            }
            else
            {
                Console.WriteLine("multiple times init0");
            }
        }
        public int datareadtimer = 0;
        public async void dataread_timer(object sender, EventArgs e)
        {

            
            datareadtimer = datareadtimer + 1;


            if (datareadtimer == 1)
            {
                inittick.Visible = true;
                label4.Visible = false;
                Initiate.Left = 226;
                Initiate.Text = "Data Analysis \r\n  Completed";
                Initiate.ForeColor = Color.Green;
                Init.animated = false;
                // System.Threading.Thread.Sleep(2);

                label5.Visible = true;
                label7.Text = "Click on Step 3 to continue";

                await Task.Delay(150);

                for (int i = 0; i < 100; i++)
                {
                    bunifuProgressBar1.Value = i;
                    bunifuProgressBar1.Update();
                    System.Threading.Thread.Sleep(1);
                }
            }
            else
            {
                Console.WriteLine("multiple times datareadtimer");
            }
            // for (int i = 0; i < 10000; i++)
            //{
            //System.Threading.Thread.Sleep(2);
            // }

        }
        public int modelbuildtimer = 0;
        public async void modelbuild_timer(object sender, EventArgs e)
        {
            
            modelbuildtimer = modelbuildtimer + 1;


            if (modelbuildtimer == 1)
            {
                datareadtick.Visible = true;
                label5.Visible = false;
                // bunifuProgressBar2.Value = 100;
                datareading.Left = 415;
                datareading.Text = "Machine Training \r\n    Completed";
                datareading.ForeColor = Color.Green;
                dataread.animated = false;
                label1.Visible = true;
                label7.Text = "Click on Step 4 to continue";


                await Task.Delay(150);

                for (int i = 0; i < 100; i++)
                {
                    bunifuProgressBar2.Value = i;
                    bunifuProgressBar2.Update();
                    System.Threading.Thread.Sleep(1);
                }
            }
            else
            {
                Console.WriteLine("multiple times modelbuildtimer");
            }

        }
        public int finishingtimer = 0;
        public async void finishing_timer(object sender, EventArgs e)
        {
            
            finishingtimer = finishingtimer + 1;


            if (finishingtimer == 1)
            {
                modelbuildtick.Visible = true;
                label1.Visible = false;
                // bunifuProgressBar3.Value = 100;
                modelbuilding.Left = 641;
                modelbuilding.Text = " Validation\r\nCompleted";
                modelbuilding.ForeColor = Color.Green;
                modelbuild.animated = false;
                label2.Visible = true;
                label7.Text = "Click on Step 5 to continue";


                await Task.Delay(150);

                for (int i = 0; i < 100; i++)
                {
                    bunifuProgressBar3.Value = i;
                    bunifuProgressBar3.Update();
                    System.Threading.Thread.Sleep(1);
                }
            }
            else
            {
                Console.WriteLine("multiple times finishingtimer");
            }
            //timer6.Tick += new EventHandler(end_timer);
            //timer6.Interval = MachineLearningTool.Form1.elapsedms1;
            //timer6.Start();
        }
        public static bool trdstop = false;


        private void progress_Load(object sender, EventArgs e)
        {

            System.IntPtr ptr = CreateRoundRectRgn(0, 0, this.Width, this.Height, 40, 40);
            this.Region = System.Drawing.Region.FromHrgn(ptr);
            DeleteObject(ptr);

            if (MachineLearningToolv3.MLTool.khatam == true)
            {
                if (finishing.animated == true)
                {
                    label1.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    if (MachineLearningToolv3.MLTool.modelname == "IC")
                    {
                        if (!File.Exists(Application.StartupPath + @"\cnn.h5"))
                        {

                            Console.WriteLine("cnn file nai bana123");
                        }
                        else
                        {
                            finishtick.Visible = true;
                            label2.Visible = false;
                            finished.Left = 820;
                            finished.Text = "Result Generated";
                            finished.ForeColor = Color.Green;

                            // System.Threading.Thread.Sleep(2000);
                            endtimer.Tick += new EventHandler(end_it);
                            endtimer.Interval = 2000;
                            endtimer.Start();

                            //this.Close();
                        }
                    }
                }

            }

        }
        public void end_it(object sender, EventArgs e)
        {
            label1.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;

            finishtick.Visible = true;
            label2.Visible = false;
            finished.Left = 820;
            finished.Text = "Result Generated";
            finished.ForeColor = Color.Green;

            endtimer.Stop();
            endtimer.Dispose();

            if (endtimer.Enabled == false)
            {
                this.Close();
            }

        }
        private void progress_VisibleChanged(object sender, EventArgs e)
        {
            if (MachineLearningToolv3.MLTool.khatam == true)
            {
                if (finishing.animated == true)
                {
                    label1.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    if (MachineLearningToolv3.MLTool.modelname == "IC")
                    {
                        if (!File.Exists(Application.StartupPath + @"\cnn.h5"))
                        {

                            Console.WriteLine("cnn file nai bana123");
                        }
                        else
                        {
                            finishtick.Visible = true;
                            label2.Visible = false;
                            finished.Left = 820;
                            finished.Text = "Result Generated";
                            finished.ForeColor = Color.Green;

                            // System.Threading.Thread.Sleep(2000);
                            endtimer.Tick += new EventHandler(end_it);
                            endtimer.Interval = 2000;
                            endtimer.Start();


                            //this.Close();
                        }
                    }
                }

            }

            //timer2.Tick += new EventHandler(init_timer);
            //timer2.Interval = 4000;
            // timer2.Start();

            timer0.Tick += new EventHandler(init_timer);
            timer0.Interval = 4000;
            timer0.Start();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            System.IntPtr ptr = CreateRoundRectRgn(0, 0, this.Width, this.Height, 40, 40);
            this.Region = System.Drawing.Region.FromHrgn(ptr);
            //panel1.BackColor = Color.FromArgb(80, Color.Black);
            DeleteObject(ptr);

            if (MachineLearningToolv3.MLTool.khatam == true)
            {
                if (finishing.animated == true)
                {
                    if (MachineLearningToolv3.MLTool.modelname == "IC")
                    {
                        if (!File.Exists(Application.StartupPath + @"\cnn.h5"))
                        {

                            Console.WriteLine("cnn file nai bana123");
                        }
                        else
                        {
                            finishtick.Visible = true;
                            label2.Visible = false;
                            finished.Left = 820;
                            finished.Text = "Result Generated";
                            finished.ForeColor = Color.Green;

                            // System.Threading.Thread.Sleep(2000);

                            endtimer.Tick += new EventHandler(end_it);
                            endtimer.Interval = 2000;
                            endtimer.Start();

                            // this.Close();
                        }
                    }
                }

            }
        }



        private void label4_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Init_timer");
            step2 = step2 + 1;
            if (step2 == 1)
            {


                Init.Value = 60;
                Init.ProgressColor = Color.SteelBlue;
                Init.animated = true;
                dataread.animated = false;
                modelbuild.animated = false;
                finishing.animated = false;


                inittick.Visible = false;
                dataread.Enabled = false;
                modelbuild.Enabled = false;
                finishing.Enabled = false;
                datareadtick.Enabled = false;
                modelbuildtick.Enabled = false;
                finishtick.Enabled = false;
                bunifuProgressBar1.Enabled = false;
                bunifuProgressBar2.Enabled = false;
                bunifuProgressBar3.Enabled = false;
                timer2.Stop();
                // timer2 = null;
                timer2.Dispose();




                timer3.Tick += new EventHandler(dataread_timer);
                timer3.Interval = 4000;
                timer3.Start();
            }
            else
            {
                Console.WriteLine("step2 is pressing multiple times");
            }




        }

        private void label5_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("dataread_timer");
            step3 = step3 + 1;
            if (step3 == 1)
            {


                dataread.Value = 60;
                //dataread.Visible = true;
                dataread.ProgressColor = Color.SteelBlue;
                dataread.animated = true;
                if (MachineLearningToolv3.MLTool.modelname == "IC")
                {
                    if (!Directory.Exists(Application.StartupPath + @"\root"))
                    {
                        Console.WriteLine("root folder nai aya");
                        //this.Close();
                    }
                    else
                    {
                        timer3.Stop();
                        // timer3 = null;
                        timer3.Dispose();
                        //MessageBox.Show("Data reading error !!!");
                        //this.Close();
                    }
                }
                else
                {
                    timer3.Stop();
                    // timer3 = null;
                    timer3.Dispose();
                    //MessageBox.Show("Data reading error !!!");
                    //this.Close();
                }
                //datareadtick.Visible = true;
                //label5.Visible = false;
                //bunifuProgressBar2.Value = 100;
                //datareading.ForeColor = Color.Green;
                timer4.Tick += new EventHandler(modelbuild_timer);
                timer4.Interval = MachineLearningToolv3.MLTool.elapsedms1 + 10000;
                timer4.Start();
            }
            else
            {
                Console.WriteLine("step3 is pressing multiple times");
            }

        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("modelbuild_timer");
            step4 = step4 + 1;
            if (step4 == 1)
            {

                // ProcessThread.Sleep(100);
                System.Threading.Thread.Sleep(100);
                //GC.Collect();
                //GC.WaitForPendingFinalizers();
                //GC.Collect();





                modelbuild.Value = 60;
                //dataread.Visible = true;
                modelbuild.ProgressColor = Color.SteelBlue;
                modelbuild.animated = true;



                // timer4.Stop();
                if (MachineLearningToolv3.MLTool.modelname == "IC")
                {
                    if (!File.Exists(Application.StartupPath + @"\cnn.h5"))
                    {

                        Console.WriteLine("cnn file nai bana1");
                    }
                    else
                    {
                        timer4.Stop();
                        //exitflag = true;
                        // timer4 = null;
                        timer4.Dispose();
                    }
                }

                else if (MachineLearningToolv3.MLTool.modelname == "SGD")
                {
                    if (!File.Exists(Application.StartupPath + @"\SGD.pkl"))
                    {

                        Console.WriteLine("SGD");
                    }
                    else
                    {
                        timer4.Stop();
                        // timer4 = null;
                        timer4.Dispose();
                    }
                }
                else if (MachineLearningToolv3.MLTool.modelname == "LinearRegression")
                {
                    if (!File.Exists(Application.StartupPath + @"\LinearRegression.pkl"))
                    {
                        Console.WriteLine("LR");

                    }
                    else
                    {
                        timer4.Stop();
                        // timer4 = null;
                        timer4.Dispose();
                    }
                }
                else if (MachineLearningToolv3.MLTool.modelname == "DTR")
                {
                    if (!File.Exists(Application.StartupPath + @"\DTR.pkl"))
                    {
                        Console.WriteLine("DTR");
                    }
                    else
                    {
                        timer4.Stop();
                        // timer4 = null;
                        timer4.Dispose();
                    }
                }

                else if (MachineLearningToolv3.MLTool.modelname == "RFR")
                {
                    if (!File.Exists(Application.StartupPath + @"\RFR.pkl"))
                    {
                        Console.WriteLine("RFR");
                    }
                    else
                    {
                        timer4.Stop();
                        // timer4 = null;
                        timer4.Dispose();
                    }
                }
                else if (MachineLearningToolv3.MLTool.modelname == "Perceptron")
                {
                    if (!File.Exists(Application.StartupPath + @"\Perceptron.pkl"))
                    {
                        Console.WriteLine("Perceptron");
                    }
                    else
                    {
                        timer4.Stop();
                        // timer4 = null;
                        timer4.Dispose();
                    }
                }
                else if (MachineLearningToolv3.MLTool.modelname == "DTC")
                {
                    if (!File.Exists(Application.StartupPath + @"\DTC.pkl"))
                    {
                        Console.WriteLine("DTC");
                    }
                    else
                    {
                        timer4.Stop();
                        //  timer4 = null;
                        timer4.Dispose();
                    }
                }
                else if (MachineLearningToolv3.MLTool.modelname == "RFC")
                {
                    if (!File.Exists(Application.StartupPath + @"\RFC.pkl"))
                    {
                        Console.WriteLine("DTR");
                    }
                    else
                    {
                        timer4.Stop();
                        // timer4 = null;
                        timer4.Dispose();
                    }
                }
                else
                {

                    timer4.Stop();
                    //timer4 = null;
                    timer4.Dispose();
                    //MessageBox.Show("Model building error !!!");
                    // goto skip1;

                }



                timer5.Tick += new EventHandler(finishing_timer);
                timer5.Interval = MachineLearningToolv3.MLTool.elapsedms1 + 4000;
                timer5.Start();
            }
            else
            {
                Console.WriteLine("step4 is pressed multiple times");
            }


            // return;
            // skip1:
            // Console.WriteLine("oooo");

        }

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("finishing_timer");
            step5 = step5 + 1;
            if (step5 == 1)
            {

                System.Threading.Thread.Sleep(100);

                finishing.Value = 60;
                finishing.ProgressColor = Color.SteelBlue;
                // while (true)
                //   {
                finishing.animated = true;
                if (MachineLearningToolv3.MLTool.modelname == "IC")
                {
                    if (!File.Exists(Application.StartupPath + @"\cnn.h5"))
                    {

                        Console.WriteLine("cnn file nai bana2");

                    }

                    else
                    {
                        timer5.Stop();
                        timer5.Dispose();

                    }
                }
                else if (MachineLearningToolv3.MLTool.modelname == "LinearRegression")
                {
                    if (!File.Exists(Application.StartupPath + @"\LinearRegression.pkl"))
                    {
                        Console.WriteLine("LR");
                        // finishing.animated = true;

                    }
                    else
                    {
                        timer5.Stop();
                        // timer5 = null;
                        timer5.Dispose();
                        //finishing.animated = true;
                    }
                }
                else if (MachineLearningToolv3.MLTool.modelname == "SGD")
                {
                    if (!File.Exists(Application.StartupPath + @"\SGD.pkl"))
                    {

                        Console.WriteLine("SGD");
                        //finishing.animated = true;
                    }
                    else
                    {
                        timer5.Stop();
                        // timer5 = null;
                        timer5.Dispose();
                        // finishing.animated = true;
                    }
                }
                else if (MachineLearningToolv3.MLTool.modelname == "DTR")
                {
                    if (!File.Exists(Application.StartupPath + @"\DTR.pkl"))
                    {
                        Console.WriteLine("DTR");
                        // finishing.animated = true;
                    }
                    else
                    {
                        timer5.Stop();
                        // timer5 = null;
                        timer5.Dispose();
                        // finishing.animated = true;
                    }
                }

                else if (MachineLearningToolv3.MLTool.modelname == "RFR")
                {
                    if (!File.Exists(Application.StartupPath + @"\RFR.pkl"))
                    {
                        Console.WriteLine("RFR");
                        // finishing.animated = true;
                    }
                    else
                    {
                        timer5.Stop();
                        // timer5 = null;
                        timer5.Dispose();
                        //  finishing.animated = true;
                    }
                }
                else if (MachineLearningToolv3.MLTool.modelname == "Perceptron")
                {
                    if (!File.Exists(Application.StartupPath + @"\Perceptron.pkl"))
                    {
                        Console.WriteLine("Perceptron");
                        // finishing.animated = true;
                    }
                    else
                    {
                        timer5.Stop();
                        // timer5 = null;
                        timer5.Dispose();
                        // finishing.animated = true;
                    }
                }
                else if (MachineLearningToolv3.MLTool.modelname == "DTC")
                {
                    if (!File.Exists(Application.StartupPath + @"\DTC.pkl"))
                    {
                        Console.WriteLine("DTC");
                        //  finishing.animated = true;
                    }
                    else
                    {

                        timer5.Stop();
                        // timer5 = null;
                        timer5.Dispose();
                        // finishing.animated = true;
                    }
                }
                else if (MachineLearningToolv3.MLTool.modelname == "RFC")
                {
                    if (!File.Exists(Application.StartupPath + @"\RFC.pkl"))
                    {
                        Console.WriteLine("DTR");
                        //  finishing.animated = true;
                    }
                    else
                    {
                        timer5.Stop();
                        // timer5 = null;
                        timer5.Dispose();
                        // finishing.animated = true;
                    }
                }
                else
                {
                    timer5.Stop();
                    // timer5 = null;
                    timer5.Dispose();
                    Console.WriteLine("Timer5 closed");
                    // finishing.animated = true;
                    //MessageBox.Show("Model building error !!!");

                }
                Console.WriteLine("closed1");

                if (timer5.Enabled == false)
                {

                    label1.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    //if(MachineLearningToolv3.MLTool.khatam == true)
                    // {
                    finishtick.Visible = true;
                    label2.Visible = false;
                    finished.Left = 820;
                    finished.Text = "Result Generated";
                    finished.ForeColor = Color.Green;
                    // finishing.animated = false;
                    Console.WriteLine("Timer5 closed1");

                    timer6.Tick += new EventHandler(end_timer);
                    timer6.Interval = 2000;
                    timer6.Start();

                    // }



                    // label2.Update();

                }
                if (MachineLearningToolv3.MLTool.khatam == true)
                {
                    if (finishing.animated == true)
                    {
                        label1.Visible = false;
                        label3.Visible = false;
                        label4.Visible = false;
                        label5.Visible = false;
                        if (MachineLearningToolv3.MLTool.modelname == "IC")
                        {

                            if (!File.Exists(Application.StartupPath + @"\cnn.h5"))
                            {

                                Console.WriteLine("cnn file nai bana123");
                            }
                            else
                            {
                                finishtick.Visible = true;
                                label2.Visible = false;
                                finished.Left = 820;
                                finished.Text = "Result Generated";
                                finished.ForeColor = Color.Green;

                                //System.Threading.Thread.Sleep(2000);
                                endtimer.Tick += new EventHandler(end_it);
                                endtimer.Interval = 2000;
                                endtimer.Start();
                                //this.Close();

                            }
                        }
                    }

                }
            }
            else
            {

            }


            //}
            // return;
        }


        private void end_timer(object sender, EventArgs e)
        {
            Console.WriteLine("end_timer");


            finishing.animated = true;

            timer6.Stop();
            timer6.Dispose();
            Console.WriteLine("Timer6 closed");



            if (timer6.Enabled == false)
            {

                Console.WriteLine("Timer6 closed1");
                trdstop = true;
                Console.WriteLine("khatam");

                this.Close();
            }



        }

        private void progress_Activated(object sender, EventArgs e)
        {
            if (MachineLearningToolv3.MLTool.khatam == true)
            {
                if (finishing.animated == true)
                {
                    label1.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    if (MachineLearningToolv3.MLTool.modelname == "IC")
                    {
                        if (!File.Exists(Application.StartupPath + @"\cnn.h5"))
                        {

                            Console.WriteLine("cnn file nai bana123");
                        }
                        else
                        {
                            finishtick.Visible = true;
                            label2.Visible = false;
                            finished.Left = 820;
                            finished.Text = "Result Generated";
                            finished.ForeColor = Color.Green;

                            // System.Threading.Thread.Sleep(2000);
                            endtimer.Tick += new EventHandler(end_it);
                            endtimer.Interval = 2000;
                            endtimer.Start();
                            // this.Close();
                        }
                    }
                }

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_MouseClick(object sender, MouseEventArgs e)
        {
            step1 = step1 + 1;
            if (step1 == 1)
            {
                //label7.Visible = false;
                Console.WriteLine("Init_timer0");
                Init0.Value = 60;
                Init0.ProgressColor = Color.SteelBlue;
                Init0.animated = true;
                Init.animated = false;
                dataread.animated = false;
                modelbuild.animated = false;
                finishing.animated = false;

                init0tick.Visible = false;
                inittick.Visible = false;
                dataread.Enabled = false;
                modelbuild.Enabled = false;
                finishing.Enabled = false;
                datareadtick.Enabled = false;
                modelbuildtick.Enabled = false;
                finishtick.Enabled = false;
                bunifuProgressBar4.Enabled = false;
                bunifuProgressBar1.Enabled = false;
                bunifuProgressBar2.Enabled = false;
                bunifuProgressBar3.Enabled = false;
                timer0.Stop();
                // timer2 = null;
                timer0.Dispose();




                timer2.Tick += new EventHandler(init0_timer);
                timer2.Interval = 4000;
                timer2.Start();
            }
            else
            {
                Console.WriteLine("step1 pressing multiple times");
            }

        }

        private void progress_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (e.CloseReason == CloseReason.UserClosing)
            //{
            //    Environment.Exit(Environment.ExitCode);
            //}

        //    if (string.Equals((sender as Button).Name, @"CloseButton"))
        //    {
        //        Environment.Exit(Environment.ExitCode);
        //    }
        //// Do something proper to CloseButton.
        //    else
        //    {

        //    }
        }
    }
}
