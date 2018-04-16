using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using VersionFace;

namespace M160CommandApp
{
    public partial class VersionCatWindow : Form
    {
        private readonly  List<EmanVersion> verList = new List<EmanVersion>();

        public VersionCatWindow()
        {
            InitializeComponent();

            verList.Add(new FirstPush());

            Assembly asm = Assembly.GetExecutingAssembly();//如果是当前程序集
            //如果是其他文件
            //string filename = Application.StartupPath + "\\xxx.exe";
            //Assembly asm = Assembly.LoadFile(filename);
            AssemblyDescriptionAttribute asmdis = (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(asm, typeof(AssemblyDescriptionAttribute));
            AssemblyCopyrightAttribute asmcpr = (AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(asm, typeof(AssemblyCopyrightAttribute));
            AssemblyCompanyAttribute asmcpn = (AssemblyCompanyAttribute)Attribute.GetCustomAttribute(asm, typeof(AssemblyCompanyAttribute));

            this.listBox1.Items.Add("文件描述:" + asmdis.Description);
            this.listBox1.Items.Add("版权所有:" + asmcpr.Copyright);
            this.listBox1.Items.Add("所属公司:" + asmcpn.Company);
            this.listBox1.Items.Add("版本追溯");
            this.listBox1.Items.Add("");

            foreach (var item in verList)
            {
                this.listBox1.Items.Add("版本名称:" + item.getVersion());
                this.listBox1.Items.Add("版本作者:" + item.getAuthor());
                this.listBox1.Items.Add("版本日期:" + item.getDate());

                this.listBox1.Items.Add("版本描述");
                foreach (var desp in item.getDesp())
                {
                    this.listBox1.Items.Add("\t" + desp);
                }

                this.listBox1.Items.Add("");
            }
        }
    }
}
