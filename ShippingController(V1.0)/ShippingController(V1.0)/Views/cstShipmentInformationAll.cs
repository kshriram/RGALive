using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShippingController_V1._0_.Views
{
    public class cstShipmentInformationAll
    {
        public string ShipmentID { get; set; }
        public String PackingStatus { get; set; }
        public string Location { get; set; }
        public String StartTime { get; set; }
        public String TimeSpent { get; set; }
        public String UserName{ get; set; }
        public String ManagerOVerride { get; set; }
        public String ShippedStatus { get; set; }
        public String TrackingNumber { get; set; }
        public String PCKRowID { get; set; }
    }
}