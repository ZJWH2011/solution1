using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EMANFTPFile
{
    public class Config
    {
        public Config()
        {
            DirPath = @"D:\kdbackup";
            FileNameStr = "SHJY2018";
            SetTimeStr = "00:00";
        }

        [XmlElement]
        public string DirPath { get; set; }

        [XmlElement]
        public string FileNameStr { get; set; }

        [XmlElement]
        public string SetTimeStr { get; set; }

    }
}
