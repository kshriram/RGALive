using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackingClassLibrary.CustomEntity.SMEntitys
{
    public class cstShipmentDetailPageGrid1
    {
        public String ShipmentID { get; set; }
        public DateTime? ShippingCreatedTime { get; set; }
        public String ShippingDate { get; set; }
        public String ShippingTime { get; set; }
        public String OrderID { get; set; }
        public String PONumber { get; set; }
        public String PartnerID { get; set; }
        public String DeliveryMode { get; set; }
        public String Carrier { get; set; }
        public String ExpectedShipDate { get; set; }
        public int shqty { get; set; }
        public int pkqty { get; set; }
        public int TrkCount { get; set; }
        public int BoxCount { get; set; }
        public String ShipmentStatus { get; set; }

    }
}
