using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VersionFace
{
    class FirstPush: EmanVersion
    {


        public string getAuthor()
        {
            return "lujy";
        }

        public string getDate()
        {
            return "2018/04/16";
        }

        public string getVersion()
        {
            return "V1.0";
        }

        public List<string> getDesp()
        {
            return new List<string>()
            {
                "添加基本按钮",
                "发布到GitHub",
                "添加图标",
                "添加帮助菜单栏"
            };
        }
    }
}
