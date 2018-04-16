using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace M160CommandApp
{
    public partial class Form1 : Form
    {
        private byte[] recvBufferIn = new byte[512];


        private byte[] recvBuffer = new byte[256];

        //接收实时长度
        private int recvRealLen = 0;

        public Form1()
        {
            InitializeComponent();

            this.serialPort1.Open();
        }

        private static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "FA 1B 60 18 01 45 38 45 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FC";
            //byte[] byteArray = System.Text.Encoding.Default.GetBytes(str);

            byte[] byteArray = strToToHexByte(str);

            this.serialPort1.Write(byteArray, 0, byteArray.Length);
        }

        private void translateBuffer()
        {
            bool bstarts = false;

            int realLens = 0;

            for (int i = 0; i < this.recvRealLen; i++)
            {
                if (0xFC == this.recvBufferIn[i])
                {
                    recvBuffer[realLens] = this.recvBufferIn[i];
                    realLens++;
                    bstarts = true;
                    continue;
                }

                if (!bstarts)
                    continue;

                if (0xFB == this.recvBufferIn[i])
                {
                    if (0xA0 == this.recvBufferIn[i + 1])
                    {
                        recvBuffer[realLens] = 0xFA;
                        realLens++;
                        i++;
                    }
                    else if (0xA1 == this.recvBufferIn[i + 1])
                    {
                        recvBuffer[realLens] = 0xFC;
                        realLens++;
                        i++;
                    }
                    else if (0xA2 == this.recvBufferIn[i + 1])
                    {
                        recvBuffer[realLens] = 0xFB;
                        realLens++;
                        i++;
                    }
                    else
                    {
                        recvBuffer[realLens] = this.recvBufferIn[i];
                        realLens++;
                    }
                }
                else if (0xFA == this.recvBufferIn[i])
                {
                    recvBuffer[realLens] = this.recvBufferIn[i];
                    bstarts = false;
                    realLens++;
                    this.HandleEveryCommand(realLens);
                    realLens = 0;
                }
                else
                {
                    recvBuffer[realLens] = this.recvBufferIn[i];
                    realLens++;
                }
            }

            //recvBuffer[realLens++] = 0xFC;


            this.recvRealLen = 0;
        }

        private void HandleEveryCommand(int realLens)
        {
            StringBuilder anwserBuilder = new StringBuilder("返回帧: ", 512);
            for (int i = 0; i < realLens; i++)
            {
                anwserBuilder.Append(string.Format("{0} ", recvBuffer[i].ToString("X2")));
            }

            this.BeginInvoke(new MethodInvoker(() =>
            {
                this.textBox1.AppendText(anwserBuilder.ToString()+"\n");

            }));

        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                int bytes = this.serialPort1.BytesToRead;

                if (this.recvRealLen >= 256)
                {
                    this.recvRealLen = 0;
                }

                if (bytes > 0)
                {
                    this.serialPort1.Read(this.recvBufferIn, this.recvRealLen, bytes);

                    this.recvRealLen += bytes;

                    if (this.recvBufferIn[this.recvRealLen - 1] == 0xFA)
                    {
                        this.translateBuffer();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                this.recvRealLen = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = "FA 08 70 10 01 00 00 FC";
            //byte[] byteArray = System.Text.Encoding.Default.GetBytes(str);

            byte[] byteArray = strToToHexByte(str);

            this.serialPort1.Write(byteArray, 0, byteArray.Length);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = "FA 08 70 10 00 00 00 FC";
            //byte[] byteArray = System.Text.Encoding.Default.GetBytes(str);

            byte[] byteArray = strToToHexByte(str);

            this.serialPort1.Write(byteArray, 0, byteArray.Length);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str = "FA 1B 40 19 01 45 38 45 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FC";
            //byte[] byteArray = System.Text.Encoding.Default.GetBytes(str);

            byte[] byteArray = strToToHexByte(str);

            this.serialPort1.Write(byteArray, 0, byteArray.Length);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string str = "FA 1B 70 16 00 00 00 00 00 00 FC";
            //byte[] byteArray = System.Text.Encoding.Default.GetBytes(str);

            byte[] byteArray = strToToHexByte(str);

            this.serialPort1.Write(byteArray, 0, byteArray.Length);
        }

        private void version_Click(object sender, EventArgs e)
        {
            int asd = 10;
            ffffffffffffffffffffffff


            VersionCatWindow window = new VersionCatWindow();
            window.Show();
        }
    }
}
