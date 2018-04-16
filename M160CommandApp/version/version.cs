using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VersionFace
{
    interface EmanVersion
    {
        //版本作者
        string getAuthor();

        //版本日期
        string getDate();

        //版本名称
        string getVersion();

        //版本描述
        List<string> getDesp();
    }
}
