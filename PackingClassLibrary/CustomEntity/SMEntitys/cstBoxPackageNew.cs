using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackingClassLibrary.CustomEntity.SMEntitys
{
    public class cstBoxPackageNew
    {
        public string BOXNUM { get; set; }
        public string BoxWeight { get; set; }
        public string BoxLength { get; set; }
        public string BoxHeight { get; set; }
        public string BoxWidth { get; set; }
        public DateTime BoxCreatedTime { get; set; }
        public string TrackingNumber { get; set; }
        public string Date { get; set; }
    }
}
