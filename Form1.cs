using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdverseUtility
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static String GetWindowsServiceStatus(String SERVICENAME)
        {

            ServiceController sc = new ServiceController(SERVICENAME);

            switch (sc.Status)
            {
                case ServiceControllerStatus.Running:
                    return "Running";
                case ServiceControllerStatus.Stopped:
                    return "Stopped";
                case ServiceControllerStatus.Paused:
                    return "Paused";
                case ServiceControllerStatus.StopPending:
                    return "Stopping";
                case ServiceControllerStatus.StartPending:
                    return "Starting";
                default:
                    return "Status Changing";
            }


        }


        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            bunifuProgressBar1.Value = 10;
            Thread.Sleep(30);
            bunifuProgressBar1.Value = 12;
            Thread.Sleep(30);
            bunifuProgressBar1.Value = 13;
            Thread.Sleep(30);
            bunifuProgressBar1.Value = 15;
            Thread.Sleep(30);
            bunifuProgressBar1.Value = 20;
            Thread.Sleep(30);
            bunifuProgressBar1.Value = 30;
            Thread.Sleep(30);
            bunifuProgressBar1.Value = 35;
            Thread.Sleep(30);
            bunifuProgressBar1.Value = 40;
            Thread.Sleep(50);
            bunifuProgressBar1.Value = 45;
            Thread.Sleep(50);
            bunifuProgressBar1.Value = 50;
            Thread.Sleep(50);
            bunifuProgressBar1.Value = 55;
            Thread.Sleep(50);
            bunifuProgressBar1.Value = 60;
            Thread.Sleep(50);
            bunifuProgressBar1.Value = 65;
            Thread.Sleep(50);
            bunifuProgressBar1.Value = 80;
            Thread.Sleep(1000);
            bunifuProgressBar1.Value = 100;
            Thread.Sleep(100);

            dpslbl.Text=GetWindowsServiceStatus("DPS");
            diagtracklbl.Text = GetWindowsServiceStatus("DiagTrack");
            sysmainlbl.Text = GetWindowsServiceStatus("sysmain");

            eventloglbl.Text = GetWindowsServiceStatus("EventLog");
            pcasvclbl.Text = GetWindowsServiceStatus("PcaSvc");

            Process[] processes = Process.GetProcessesByName("javaw");
            if (processes.Length == 0)
            {

                javawlbl.Text = "Stopped";
            }
            else
            {

                javawlbl.Text = "Running";
            }





        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.systemprocessPnl.Show();
            this.journalPnl.Hide();
            this.ModificationsPnl.Hide();
        }

        private void dpslbl_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton3_Click_1(object sender, EventArgs e)
        {
            this.systemprocessPnl.Hide();
            this.journalPnl.Show();
            this.ModificationsPnl.Hide();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            bunifuProgressBar2.Value = 10;
            Thread.Sleep(30);
            bunifuProgressBar2.Value = 12;
            Thread.Sleep(30);
            bunifuProgressBar2.Value = 13;
            Thread.Sleep(30);
            bunifuProgressBar2.Value = 15;
            Thread.Sleep(30);
            bunifuProgressBar2.Value = 20;
            Thread.Sleep(30);
            bunifuProgressBar2.Value = 30;
            Thread.Sleep(30);
            bunifuProgressBar2.Value = 35;
            Thread.Sleep(30);
            bunifuProgressBar2.Value = 40;
            Thread.Sleep(50);
            bunifuProgressBar2.Value = 45;
            Thread.Sleep(50);
            bunifuProgressBar2.Value = 50;
            Thread.Sleep(50);
            bunifuProgressBar2.Value = 55;
            Thread.Sleep(50);
            bunifuProgressBar2.Value = 60;
            Thread.Sleep(50);
            bunifuProgressBar2.Value = 65;
            Thread.Sleep(50);
            bunifuProgressBar2.Value = 67;
            Thread.Sleep(50);
            bunifuProgressBar2.Value = 70;
            Thread.Sleep(50);
            bunifuProgressBar2.Value = 73;
            Thread.Sleep(50);
            bunifuProgressBar2.Value = 76;
            Thread.Sleep(50);
            bunifuProgressBar2.Value = 80;
            Thread.Sleep(50);
            bunifuProgressBar2.Value = 100;

            if (File.Exists(@"c:\users\" + Environment.UserName + @"\desktop\Renamed.txt"))
            {
                File.Delete(@"c:\users\" + Environment.UserName + @"\desktop\Renamed.txt");
            }

            if (File.Exists(@"c:\users\" + Environment.UserName + @"\desktop\Deleted.txt"))
            {
                File.Delete(@"c:\users\" + Environment.UserName + @"\desktop\Deleted.txt");
            }

            Thread.Sleep(1500);

            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine(@"cd c:\users\%username%\desktop\ && fsutil usn readjournal c: csv | findstr /i /c:.exe | findstr /i /c:0x00002000 >> Renamed.txt && notepad Renamed.txt");

            cmd.StandardInput.WriteLine(@"cd c:\users\%username%\desktop\ &&  fsutil usn readjournal c: csv | findstr /i /c:.exe | findstr /i /c:0x80000200 >> Deleted.txt");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();



            





        }





        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            string renamedfiles = "";
            string[] lines = System.IO.File.ReadAllLines(@"c:\users\" + Environment.UserName +@"\desktop\Renamed.txt");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.

                renamedfiles += "\t" + line;
            }
            guna2TextBox1.Text = (renamedfiles);
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            string deletedfiles = "";
            string[] lines = System.IO.File.ReadAllLines(@"c:\users\" + Environment.UserName + @"\desktop\Deleted.txt");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.

                deletedfiles += "\t" + line;
            }
            guna2TextBox2.Text = (deletedfiles);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            this.systemprocessPnl.Hide();
            this.ModificationsPnl.Show();
            this.journalPnl.Hide();
        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            bunifuProgressBar3.Value = 10;
            Thread.Sleep(30);
            bunifuProgressBar3.Value = 12;
            Thread.Sleep(30);
            bunifuProgressBar3.Value = 13;
            Thread.Sleep(30);
            bunifuProgressBar3.Value = 15;
            Thread.Sleep(30);
            bunifuProgressBar3.Value = 20;
            Thread.Sleep(30);
            bunifuProgressBar3.Value = 30;
            Thread.Sleep(30);
            bunifuProgressBar3.Value = 35;
            Thread.Sleep(30);
            bunifuProgressBar3.Value = 40;
            Thread.Sleep(50);
            bunifuProgressBar3.Value = 45;
            Thread.Sleep(50);
            bunifuProgressBar3.Value = 50;
            Thread.Sleep(50);
            bunifuProgressBar3.Value = 55;
            Thread.Sleep(50);
            bunifuProgressBar3.Value = 60;
            Thread.Sleep(50);
            bunifuProgressBar3.Value = 65;
            Thread.Sleep(50);
            bunifuProgressBar3.Value = 67;
            Thread.Sleep(50);
            bunifuProgressBar3.Value = 70;
            Thread.Sleep(50);
            bunifuProgressBar3.Value = 73;
            Thread.Sleep(50);
            bunifuProgressBar3.Value = 76;
            Thread.Sleep(50);
            bunifuProgressBar3.Value = 80;
            Thread.Sleep(50);
            bunifuProgressBar3.Value = 100;


            DateTime lastModifiedRB =       File.GetLastWriteTime(@"C:\$Recycle.bin");
            DateTime lastModifiedPrefetch = File.GetLastWriteTime(@"C:\Windows\Prefetch");
            DateTime lastModifiedMinecraft = File.GetLastWriteTime(@"c:\users\" + Environment.UserName + @"\AppData\Roaming\.minecraft");

            bunifuCustomLabel12.Show();
            bunifuCustomLabel14.Show();

            bunifuCustomLabel16.Show();
            bunifuCustomLabel15.Text = "" + lastModifiedPrefetch;
            bunifuCustomLabel10.Text = "" + lastModifiedRB;
            bunifuCustomLabel17.Text = "" + lastModifiedMinecraft;


        }

        private void bunifuCustomLabel10_Click(object sender, EventArgs e)
        {

        }
    }
}
