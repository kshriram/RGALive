using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackingClassLibrary.CustomEntity.SMEntitys
{
    public class cstShipmentInformationAlls
    {
        public string ShipmentID { get; set; }
        public String PackingStatus { get; set; }
        public string Location { get; set; }
        public String StartTime { get; set; }
        public String TimeSpent { get; set; }
        public String UserName { get; set; }
        public String ManagerOVerride { get; set; }
        public String ShippedStatus { get; set; }
        public String TrackingNumber { get; set; }
        public String PCKRowID { get; set; }
    }
}
