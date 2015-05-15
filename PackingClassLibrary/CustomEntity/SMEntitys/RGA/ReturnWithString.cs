using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackingClassLibrary.CustomEntity.SMEntitys.RGA
{
    public class ReturnWithString
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
        public byte? RMAStatus { get; set; }
        public byte? Decision { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

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

        public int ProgressFlag { get; set; }

        public String UpdatedByStr { get; set; }
        public String DecisionStr { get; set; }
        public String RMAStatusStr { get; set; }
        public String UpdatedDates { get; set; }
        public String ReturnDates { get; set; }

        public ReturnWithString()
        { }

        public ReturnWithString(GetRGAService.ReturnWithStringDTO _ReturnDTO)
        {
            if (_ReturnDTO.ReturnID != Guid.Empty) this.ReturnID = (Guid)_ReturnDTO.ReturnID;
            if (_ReturnDTO.RMANumber != null) this.RMANumber = _ReturnDTO.RMANumber;
            if (_ReturnDTO.ShipmentNumber != null) this.ShipmentNumber = _ReturnDTO.ShipmentNumber;
            if (_ReturnDTO.OrderNumber != null) this.OrderNumber = _ReturnDTO.OrderNumber;
            if (_ReturnDTO.PONumber != null) this.PONumber = _ReturnDTO.PONumber;
            if (_ReturnDTO.OrderDate != null) this.OrderDate = (DateTime)_ReturnDTO.OrderDate;
            if (_ReturnDTO.DeliveryDat != null) this.DeliveryDate = (DateTime)_ReturnDTO.DeliveryDat;
            if (_ReturnDTO.ReturnDate != null) this.ReturnDate = (DateTime)_ReturnDTO.ReturnDate;
            if (_ReturnDTO.ScannedDate != null) this.ScannedDate = (DateTime)_ReturnDTO.ScannedDate;
            if (_ReturnDTO.ExpirationDate != null) this.ExpirationDate = (DateTime)_ReturnDTO.ExpirationDate;
            if (_ReturnDTO.VendorNumber != null) this.VendorNumber = _ReturnDTO.VendorNumber;
            if (_ReturnDTO.VendoeName != null) this.VendoeName = _ReturnDTO.VendoeName;
            if (_ReturnDTO.CustomerName1 != null) this.CustomerName1 = _ReturnDTO.CustomerName1;
            if (_ReturnDTO.CustomerName2 != null) this.CustomerName2 = _ReturnDTO.CustomerName2;
            if (_ReturnDTO.Address1 != null) this.Address1 = _ReturnDTO.Address1;
            if (_ReturnDTO.Address2 != null) this.Address2 = _ReturnDTO.Address2;
            if (_ReturnDTO.Address3 != null) this.Address3 = _ReturnDTO.Address3;
            if (_ReturnDTO.ZipCode != null) this.ZipCode = _ReturnDTO.ZipCode;
            if (_ReturnDTO.City != null) this.City = _ReturnDTO.City;
            if (_ReturnDTO.State != null) this.State = _ReturnDTO.State;
            if (_ReturnDTO.Country != null) this.Country = _ReturnDTO.Country;
            if (_ReturnDTO.ReturnReason != null) this.ReturnReason = _ReturnDTO.ReturnReason;
            if (_ReturnDTO.RMAStatus != null) this.RMAStatus = _ReturnDTO.RMAStatus;
            if (_ReturnDTO.Decision != null) this.Decision = _ReturnDTO.Decision;
            if (_ReturnDTO.CreatedBy != null) this.CreatedBy = _ReturnDTO.CreatedBy;
            if (_ReturnDTO.UpdatedBy != null) this.UpdatedBy = _ReturnDTO.UpdatedBy;

            if (_ReturnDTO.Wrong_RMA_Flg != null) this.Wrong_RMA_Flg = _ReturnDTO.Wrong_RMA_Flg;
            if (_ReturnDTO.Warranty_STA != null) this.Warranty_STA = _ReturnDTO.Warranty_STA;
            if (_ReturnDTO.Setting_Wty_Days != null) this.Setting_Wty_Days = _ReturnDTO.Setting_Wty_Days;
            if (_ReturnDTO.ShipDate_ScanDate_Days_Diff != null) this.ShipDate_ScanDate_Days_Diff = _ReturnDTO.ShipDate_ScanDate_Days_Diff;

            if (_ReturnDTO.CreatesDate != null) this.CreatedDate = (DateTime)_ReturnDTO.CreatesDate;
            if (_ReturnDTO.UpdatedDate != null) this.UpdatedDate = (DateTime)_ReturnDTO.UpdatedDate;

            if (_ReturnDTO.CallTag != null) this.CallTag = _ReturnDTO.CallTag;
            if (_ReturnDTO.Ready_To_Export != null) this.Ready_To_Export = (int)_ReturnDTO.Ready_To_Export;
            if (_ReturnDTO.Exported_in_ERP != null) this.Exported_in_ERP = (int)_ReturnDTO.Exported_in_ERP;

            if (_ReturnDTO.ProgressFlag != null) this.ProgressFlag = (int)_ReturnDTO.ProgressFlag;

            if (_ReturnDTO.UpdatedByStr != null) this.UpdatedByStr = _ReturnDTO.UpdatedByStr;
            if (_ReturnDTO.DecisionStr != null) this.DecisionStr = _ReturnDTO.DecisionStr;
            if (_ReturnDTO.RMAStatusStr != null) this.RMAStatusStr = _ReturnDTO.RMAStatusStr;
            if (_ReturnDTO.UpdatedDates != null) this.UpdatedDates = _ReturnDTO.UpdatedDates;
            if (_ReturnDTO.ReturnDates != null) this.ReturnDates = _ReturnDTO.ReturnDates;

            this.RGAROWID = _ReturnDTO.RGAROWID;
        }



    }
}
