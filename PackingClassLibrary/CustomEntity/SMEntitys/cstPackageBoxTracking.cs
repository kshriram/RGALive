using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackingClassLibrary.CustomEntity.SMEntitys
{
    public class cstPackageBoxTracking
    {
        public String BOXNUM { get; set; }
        public String SKUNumber { get; set; }
        public int SKUQuantity { get; set; }
        public String Date { get; set; }
        public String TrackingNumber { get; set; }
        public String Status { get; set; }
        public String BoxLocation { get; set; }
        public String Carrier { get; set; }
        public String Heights { get; set; }
        public String Lengths { get; set; }
        public String Widths { get; set; }
        public String Weights { get; set; }
        public String FreightCharges { get; set; }

    }
}
