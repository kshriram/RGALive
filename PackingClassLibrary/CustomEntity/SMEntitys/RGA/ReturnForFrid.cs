using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackingClassLibrary.CustomEntity.SMEntitys.RGA
{
    public class ReturnForFrid
    {
         public Guid ReturnID { get; set; }
        public string RMANumber { get; set; }
        public string ShipmentNumber { get; set; }
        public string OrderNumber { get; set; }
        public string PONumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ScannedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string VendorNumber { get; set; }
        public string VendoeName { get; set; }
        public string CustomerName1 { get; set; }
        public string CustomerName2 { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ReturnReason { get; set; }
        public string RMAStatus { get; set; }
        public string Decision { get; set; }
        public Guid? CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public string Wrong_RMA_Flg { get; set; }
        public string Warranty_STA { get; set; }
        public int Setting_Wty_Days { get; set; }
        public int ShipDate_ScanDate_Days_Diff { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public String RGAROWID { get; set; }

        public string ProductID { get; set; }
        public decimal? SalesPrice { get; set; }

        public string CallTag { get; set; }
        public int Ready_To_Export { get; set; }
        public int Exported_in_ERP { get; set; }

        public string ProgressFlag { get; set; }


        public ReturnForFrid()
        { }

       

    }
}
