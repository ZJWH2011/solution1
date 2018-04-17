using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FTPNameSpace;
using Examples.System.Net;


namespace EMANFTPFile
{
    public partial class Form1 : Form
    {
        //private UpLoadFiles pUpLoadFiles = new UpLoadFiles();
        private AsynchronousFtpUpLoader pAsynchronousFtpUpLoader = new AsynchronousFtpUpLoader();

        public static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Config pConfig = new Config();

        private readonly string xmlPath = Application.StartupPath + @"\config.xml";

        private bool running = true;

        private System.Threading.Thread thread = null;

        private bool ispaused = true;

        public Form1()
        {
            InitializeComponent();

            this.timer1.Start();

            try
            {
                pAsynchronousFtpUpLoader.FTPProgressEvent += new AsynchronousFtpUpLoader.FTPProgress(this.translate);

                pConfig = (Config)NicolasSHEN.Core.XML.XMLSerializationHelper.Load(typeof(Config), xmlPath);

                this.dirpath.Text = pConfig.DirPath;

                this.filename.Text = pConfig.FileNameStr;

                this.timeSelector1.SelectedTime = new TimeSpan(Int32.Parse(pConfig.SetTimeStr.Substring(0,2)),
                    Int32.Parse(pConfig.SetTimeStr.Substring(3, 2)),0);

                thread = new System.Threading.Thread(this.onstart);
                thread.Start();

                logger.Debug("read success");
            }
            catch(Exception ex)
            {
                logger.Error(ex.ToString());

                pConfig = new Config();
            }
        }

        private void translate(long min,long max)
        {
            this.BeginInvoke(new MethodInvoker(()=>
                {
                    if(max>0)
                    {
                        int step = (int)(min * 100 / max);

                        //Console.WriteLine(step);

                        string str = string.Format("{0}/{1} 字节", min, max);

                        this.ftplabel.Text = str;

                        this.ftpprogressbar.Value = step;      
                    }
                }));
        }

        private void onstart()
        {
            string url= "ftp://47.97.101.47/SHJY2018_000000.ADF";
            string localpath = "";

            while (running)
            {
                if(ispaused)
                {
                    System.Threading.Thread.Sleep(10);
                    continue;
                }
                else
                {
                    try
                    {
                        DateTime curstr = DateTime.Now;

                        DateTime hisstr = curstr.AddDays(-1);

                        localpath = string.Format(@"{0}\{1}{2}{3}.ADF", 
                            pConfig.DirPath,
                            pConfig.FileNameStr,
                            "_",
                            hisstr.ToString("yyyyMMdd"));

                        url = string.Format("{0}{1}{2}{3}.ADF",
                        "ftp://47.97.101.47/",
                        pConfig.FileNameStr,
                        "_",
                        hisstr.ToString("yyyyMMdd"));

                        if (!System.IO.File.Exists(localpath))
                        {
                            throw new Exception(localpath + " is not exist");
                        }


                        pAsynchronousFtpUpLoader.UploadFile(new string[] { url, localpath });

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.ToString());
                    }

                    ispaused = true;

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //bool ret = pUpLoadFiles.UploadFile("E:\\vswork\\Solution1\\EMANFTPFile\\bin\\Debug\\b.txt", "b.txt");

            //pUpLoadFiles.Download("/a.txt");

            //AsynchronousFtpUpLoader.UploadFile(new string[] { "ftp://47.97.101.47/mnb.txt", "E:\\vswork\\Solution1\\EMANFTPFile\\bin\\Debug\\b.txt" });
        }

        /// <summary>
        /// 定时器时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime curTime = DateTime.Now;

            timelabel.Text = curTime.ToString("yyyy-MM-dd HH:mm:ss");

            string timestr = string.Format("{0:D2}:{1:D2}:{2:D2}", curTime.Hour, curTime.Minute,curTime.Second);

            if(timestr==pConfig.SetTimeStr)
            {
                ispaused = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if(!ispaused)
                {
                    throw new Exception("ftp is running");
                }

                if (string.IsNullOrEmpty(this.dirpath.Text))
                {
                    throw new Exception("this.dirpath.Text is null");
                }

                if (string.IsNullOrEmpty(this.filename.Text))
                {
                    throw new Exception("this.filename.Text is null");
                }

                string datestr = this.timeSelector1.SelectedTime.Hours.ToString("D2") + ":" + this.timeSelector1.SelectedTime.Minutes.ToString("D2")+":00";

                pConfig.DirPath = this.dirpath.Text;

                pConfig.FileNameStr = this.filename.Text;

                pConfig.SetTimeStr = datestr;

                NicolasSHEN.Core.XML.XMLSerializationHelper.Save(pConfig, xmlPath);

                MessageBox.Show("保存成功", "提示");
            }
            catch(Exception ex)
            {
                logger.Error(ex.ToString());

                MessageBox.Show("保存失败", "错误");

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WindowState=FormWindowState.Minimized;

            e.Cancel = true;
        }
    }
}
