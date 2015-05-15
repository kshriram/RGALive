using PackingClassLibrary.Commands.SMcommands.RGA;
using PackingClassLibrary.CustomEntity.SMEntitys.RGA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShippingController_V1._0_.Models
{
    public class modelReaturnUpdate
    {
        cmdReasons cRtnreasons = new cmdReasons();

        cmdReturnedSKUPoints creturnedReason = new cmdReturnedSKUPoints();


        #region  Arun Koli

        public Guid SetReturnTblForRMA(List<RMAInfo> _lsreturn, byte Status, byte Decision, Guid UserID, DateTime ScannedDate, DateTime ExpirarionDate, int InProgress, string calltag, string Wrong_RMA_Flg, string Warranty_STA, int Setting_Wty_Days, int ShipDate_ScanDate_Days_Diff)
        {
            Guid ReturnID = Guid.Empty;
            try
            {
                Return TblRerutn = new Return();

                TblRerutn.ReturnID = Guid.NewGuid();
                TblRerutn.RMANumber = _lsreturn[0].RMANumber;
                TblRerutn.ShipmentNumber = _lsreturn[0].ShipmentNumber;
                TblRerutn.OrderNumber = _lsreturn[0].OrderNumber;
                TblRerutn.PONumber = _lsreturn[0].PONumber;
                TblRerutn.OrderDate = _lsreturn[0].OrderDate;
                TblRerutn.DeliveryDate = _lsreturn[0].DeliveryDate;
                TblRerutn.ReturnDate = _lsreturn[0].ReturnDate;
                TblRerutn.ScannedDate = ScannedDate;
                TblRerutn.ExpirationDate = ExpirarionDate;
                TblRerutn.VendorNumber = _lsreturn[0].VendorNumber;
                TblRerutn.VendoeName = _lsreturn[0].VendorName;
                TblRerutn.CustomerName1 = _lsreturn[0].CustomerName1;
                TblRerutn.CustomerName2 = _lsreturn[0].CustomerName2;
                TblRerutn.Address1 = _lsreturn[0].Address1;
                TblRerutn.Address2 = _lsreturn[0].Address2;
                TblRerutn.Address3 = _lsreturn[0].Address3;
                TblRerutn.ZipCode = _lsreturn[0].ZipCode;
                TblRerutn.City = _lsreturn[0].City;
                TblRerutn.State = _lsreturn[0].State;
                TblRerutn.Country = _lsreturn[0].Country;
                TblRerutn.ReturnReason = "";
                TblRerutn.RMAStatus = Status;
                TblRerutn.Decision = Decision;
                TblRerutn.CreatedBy = UserID;
                TblRerutn.CreatedDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Eastern Standard Time");
                TblRerutn.UpdatedBy = UserID;
                TblRerutn.UpdatedDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Eastern Standard Time");


                TblRerutn.Wrong_RMA_Flg = Wrong_RMA_Flg;//Wrong_RMA_Flg;
                TblRerutn.Warranty_STA = Warranty_STA;
                TblRerutn.Setting_Wty_Days = Setting_Wty_Days;
                TblRerutn.ShipDate_ScanDate_Days_Diff = ShipDate_ScanDate_Days_Diff;

                TblRerutn.CallTag = calltag;

                TblRerutn.ProgressFlag = InProgress;


                if (Obj.Rcall.UpsetReturnTbl(TblRerutn)) ReturnID = TblRerutn.ReturnID;
            }
            catch (Exception)
            {
            }
            return ReturnID;

        }

        public Guid SetReturnTblForNewRMA(List<Return> _lsreturn, byte Status, byte Decision, Guid UserID, DateTime ScannedDate, DateTime ExpirarionDate, int InProgress, string calltag, string Wrong_RMA_Flg, string Warranty_STA, int Setting_Wty_Days, int ShipDate_ScanDate_Days_Diff)
        {
            Guid ReturnID = Guid.Empty;
            try
            {
                Return TblRerutn = new Return();

                TblRerutn.ReturnID = Guid.NewGuid(); 
                TblRerutn.RMANumber = "N/A";
                TblRerutn.ShipmentNumber = _lsreturn[0].ShipmentNumber;
                TblRerutn.OrderNumber = "N/A";
                TblRerutn.PONumber = _lsreturn[0].PONumber;
                TblRerutn.OrderDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Eastern Standard Time");
                TblRerutn.DeliveryDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Eastern Standard Time");
                TblRerutn.ReturnDate = _lsreturn[0].ReturnDate;
                TblRerutn.ScannedDate = ScannedDate;
                TblRerutn.ExpirationDate = ExpirarionDate;
                TblRerutn.VendorNumber = _lsreturn[0].VendorNumber;
                TblRerutn.VendoeName = _lsreturn[0].VendoeName;
                TblRerutn.CustomerName1 = _lsreturn[0].CustomerName1;
                TblRerutn.CustomerName2 = "N/A";
                TblRerutn.Address1 = _lsreturn[0].Address1;
                TblRerutn.Address2 = "N/A";
                TblRerutn.Address3 = "N/A";
                //TblRerutn.ZipCode = _lsreturn[0].ZipCode;
                //TblRerutn.City = _lsreturn[0].City;
                //TblRerutn.State = _lsreturn[0].State;
                //TblRerutn.Country = _lsreturn[0].Country;
                TblRerutn.ZipCode = _lsreturn[0].ZipCode;
                TblRerutn.City = _lsreturn[0].City;
                TblRerutn.State = _lsreturn[0].State;
                TblRerutn.Country = "N/A";
                TblRerutn.ReturnReason = "";
                TblRerutn.RMAStatus = Status;
                TblRerutn.Decision = Decision;
                TblRerutn.CreatedBy = UserID;
                TblRerutn.CreatedDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Eastern Standard Time");
                TblRerutn.UpdatedBy = UserID;
                TblRerutn.UpdatedDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Eastern Standard Time");


                TblRerutn.Wrong_RMA_Flg = Wrong_RMA_Flg;//Wrong_RMA_Flg;
                TblRerutn.Warranty_STA = Warranty_STA;
                TblRerutn.Setting_Wty_Days = Setting_Wty_Days;
                TblRerutn.ShipDate_ScanDate_Days_Diff = ShipDate_ScanDate_Days_Diff;

                TblRerutn.CallTag = calltag;

                TblRerutn.ProgressFlag = InProgress;
               // TblRerutn.RGAROWID = _lsreturn[0].RGAROWID;


                if(Obj.Rcall.UpsetReturnByRGANumber(TblRerutn))ReturnID=TblRerutn.ReturnID;

               // if (Obj.Rcall.UpsetReturnTbl(TblRerutn)) ReturnID = TblRerutn.ReturnID;
            }
            catch (Exception)
            {
            }
            return ReturnID;

        }

        #endregion
        ///Deepak
        ///
        public Guid SetReturnByPonumberTblNew(List<RMAInfo> lstrmainsert, byte Status, byte Decision, Guid UserID, DateTime ScannedDate, DateTime ExpirarionDate, int InProgress, string calltag, string Wrong_RMA_Flg, string Warranty_STA, int Setting_Wty_Days, int ShipDate_ScanDate_Days_Diff)
        {
          //  Return _lsreturn = new Return();

            Guid ReturnID = Guid.Empty;
            try
            {
                Return TblRerutn = new Return();

                TblRerutn.ReturnID = Guid.NewGuid();
                TblRerutn.RMANumber = "N/A";
                TblRerutn.ShipmentNumber = lstrmainsert[0].ShipmentNumber;
                TblRerutn.OrderNumber = lstrmainsert[0].OrderNumber;
                TblRerutn.PONumber = lstrmainsert[0].PONumber;
                TblRerutn.OrderDate = lstrmainsert[0].OrderDate;
                TblRerutn.DeliveryDate = lstrmainsert[0].DeliveryDate;
                TblRerutn.ReturnDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Eastern Standard Time");
                TblRerutn.ScannedDate = ScannedDate;
                TblRerutn.ExpirationDate = ExpirarionDate;
                TblRerutn.VendorNumber = lstrmainsert[0].VendorNumber;
                TblRerutn.VendoeName = lstrmainsert[0].VendorName;
                TblRerutn.CustomerName1 = lstrmainsert[0].CustomerName1;
                TblRerutn.CustomerName2 = lstrmainsert[0].CustomerName2;
                TblRerutn.Address1 = lstrmainsert[0].Address1;
                TblRerutn.Address2 = null;
                TblRerutn.Address3 = null;
                TblRerutn.ZipCode = lstrmainsert[0].ZipCode;
                TblRerutn.City = lstrmainsert[0].City;
                TblRerutn.State = lstrmainsert[0].State;
                TblRerutn.Country = lstrmainsert[0].Country;
                TblRerutn.ReturnReason = null;
                TblRerutn.RMAStatus = Status;
                TblRerutn.Decision = Decision;
                TblRerutn.CreatedBy = UserID;
                TblRerutn.CreatedDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Eastern Standard Time");
                TblRerutn.UpdatedBy = UserID;
                TblRerutn.UpdatedDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Eastern Standard Time");


                TblRerutn.Wrong_RMA_Flg = Wrong_RMA_Flg;//Wrong_RMA_Flg;
                TblRerutn.Warranty_STA = Warranty_STA;
                TblRerutn.Setting_Wty_Days =Setting_Wty_Days;
                TblRerutn.ShipDate_ScanDate_Days_Diff = ShipDate_ScanDate_Days_Diff;

                TblRerutn.CallTag = calltag;

                TblRerutn.ProgressFlag = InProgress;


                if (Obj.Rcall.UpsetReturnByPonumerTbl(TblRerutn)) ReturnID = TblRerutn.ReturnID;
            }
            catch (Exception)
            {
            }
            return ReturnID;

        }
        ///

        public Guid SetReturnDetailNewInsertTblForEditPage(Guid _lsreturndetail, Guid ReturnTblID, String SKUNumber, String ProductName, int ReturnQty, Guid CreatedBy, string SKU_Status, int SKU_Reason_Total_Points, int IsScanned, int Manually, int NewItemQty, int SKU_Qty_Seq, string ProductID, decimal SalesPrice, int LineType, int ShipmentLines, int ReturnLines, DateTime UpdatedDate, string TrackingNumber)
        {
            Return _lsreturn = new Return();
            Guid returndetail = Guid.Empty;
            try
            {
                ReturnDetail TblReturnDetails = new ReturnDetail();

                TblReturnDetails.ReturnDetailID = Guid.NewGuid();
                TblReturnDetails.ReturnID = ReturnTblID;
                TblReturnDetails.SKUNumber = SKUNumber;
                TblReturnDetails.ProductName = ProductName;
                TblReturnDetails.DeliveredQty = 0;
                TblReturnDetails.ExpectedQty = 0;
                TblReturnDetails.TCLCOD_0 = "";
                TblReturnDetails.SKU_Qty_Seq = ReturnQty;
                TblReturnDetails.ProductStatus = 0;
                TblReturnDetails.CreatedBy = CreatedBy;
                TblReturnDetails.CreatedDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Eastern Standard Time");
                TblReturnDetails.UpadatedDate = UpdatedDate;// TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Eastern Standard Time");
                TblReturnDetails.UpdatedBy = CreatedBy;

                TblReturnDetails.SKU_Status = SKU_Status;
                TblReturnDetails.SKU_Reason_Total_Points = SKU_Reason_Total_Points;
                TblReturnDetails.IsSkuScanned = IsScanned;
                TblReturnDetails.IsManuallyAdded = Manually;

                TblReturnDetails.SKU_Sequence = NewItemQty;
                TblReturnDetails.SKU_Qty_Seq = ReturnQty;

                TblReturnDetails.SalesPrice = SalesPrice;
                TblReturnDetails.ProductID = ProductID;

                TblReturnDetails.LineType = LineType;

                TblReturnDetails.ShipmentLines = ShipmentLines;
                TblReturnDetails.ReturnLines = ReturnLines;

                TblReturnDetails.TrackingNumber = TrackingNumber;

                if (Obj.Rcall.UpsetReturnDetails(TblReturnDetails)) returndetail = TblReturnDetails.ReturnDetailID;
            }
            catch (Exception)
            {
            }
            return returndetail;
        }



        //end

        public Guid SetReturnDetailNewInsertTbl(Guid _lsreturndetail, Guid ReturnTblID, String SKUNumber, String ProductName, int ReturnQty, Guid CreatedBy, string SKU_Status, int SKU_Reason_Total_Points, int IsScanned, int Manually, int NewItemQty, int SKU_Qty_Seq, string ProductID, decimal SalesPrice, int LineType, int ShipmentLines, int ReturnLines, string TrackingNumber)
        {
            Return _lsreturn = new Return();
            Guid returndetail = Guid.Empty;
            try
            {
                ReturnDetail TblReturnDetails = new ReturnDetail();

                TblReturnDetails.ReturnDetailID = Guid.NewGuid();
                TblReturnDetails.ReturnID = ReturnTblID;
                TblReturnDetails.SKUNumber = SKUNumber;
                TblReturnDetails.ProductName = ProductName;
                TblReturnDetails.DeliveredQty = 0;
                TblReturnDetails.ExpectedQty = 0;
                TblReturnDetails.TCLCOD_0 = "";
                TblReturnDetails.SKU_Qty_Seq = ReturnQty;
                TblReturnDetails.ProductStatus = 0;
                TblReturnDetails.CreatedBy = CreatedBy;
                TblReturnDetails.CreatedDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Eastern Standard Time");
                TblReturnDetails.UpadatedDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Eastern Standard Time");
                TblReturnDetails.UpdatedBy = CreatedBy;

                TblReturnDetails.SKU_Status = SKU_Status;
                TblReturnDetails.SKU_Reason_Total_Points = SKU_Reason_Total_Points;
                TblReturnDetails.IsSkuScanned = IsScanned;
                TblReturnDetails.IsManuallyAdded = Manually;

                TblReturnDetails.SKU_Sequence = NewItemQty;
                TblReturnDetails.SKU_Qty_Seq = ReturnQty;

                TblReturnDetails.SalesPrice = SalesPrice;
                TblReturnDetails.ProductID = ProductID;

                TblReturnDetails.LineType = LineType;

                TblReturnDetails.ShipmentLines = ShipmentLines;
                TblReturnDetails.ReturnLines = ReturnLines;

                TblReturnDetails.TrackingNumber = TrackingNumber;

                if (Obj.Rcall.UpsetReturnDetails(TblReturnDetails)) returndetail = TblReturnDetails.ReturnDetailID;
            }
            catch (Exception)
            {
            }
            return returndetail;
        }

        ////

        /// <summary>
        /// update all return information.
        /// </summary>
        /// <param name="Status">
        /// pass status as parameter.
        /// </param>
        /// <param name="Decision">
        /// pass decision as parameter.
        /// </param>
        /// <returns></returns>
        public Guid SetReturnTbl(Return _lsreturn, byte Status, byte Decision, Guid UserID, DateTime ScannedDate, DateTime ExpirarionDate, int InProgress, string calltag)
        {
            Guid ReturnID = Guid.NewGuid();
            try
            {
                Return TblRerutn = new Return();

                TblRerutn.ReturnID = _lsreturn.ReturnID;
                TblRerutn.RMANumber = _lsreturn.RMANumber;
                TblRerutn.ShipmentNumber = _lsreturn.ShipmentNumber;
                TblRerutn.OrderNumber = _lsreturn.OrderNumber;
                TblRerutn.PONumber = _lsreturn.PONumber;
                TblRerutn.OrderDate = _lsreturn.OrderDate;
                TblRerutn.DeliveryDate = _lsreturn.DeliveryDate;
                TblRerutn.ReturnDate =  _lsreturn.ReturnDate;
                TblRerutn.ScannedDate = ScannedDate;
                TblRerutn.ExpirationDate = ExpirarionDate;
                TblRerutn.VendorNumber = _lsreturn.VendorNumber;
                TblRerutn.VendoeName = _lsreturn.VendoeName;
                TblRerutn.CustomerName1 = _lsreturn.CustomerName1;
                TblRerutn.CustomerName2 = _lsreturn.CustomerName2;
                TblRerutn.Address1 = _lsreturn.Address1;
                TblRerutn.Address2 = _lsreturn.Address2;
                TblRerutn.Address3 = _lsreturn.Address3;
                TblRerutn.ZipCode = _lsreturn.ZipCode;
                TblRerutn.City = _lsreturn.City;
                TblRerutn.State = _lsreturn.State;
                TblRerutn.Country = _lsreturn.Country;
                TblRerutn.ReturnReason = "";
                TblRerutn.RMAStatus = Status;
                TblRerutn.Decision = Decision;
                TblRerutn.CreatedBy = _lsreturn.CreatedBy;
                TblRerutn.CreatedDate = _lsreturn.CreatedDate;
                TblRerutn.UpdatedBy = UserID;
                TblRerutn.UpdatedDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Eastern Standard Time");


                TblRerutn.Wrong_RMA_Flg = _lsreturn.Wrong_RMA_Flg;//Wrong_RMA_Flg;
                TblRerutn.Warranty_STA = _lsreturn.Warranty_STA;
                TblRerutn.Setting_Wty_Days = _lsreturn.Setting_Wty_Days;
                TblRerutn.ShipDate_ScanDate_Days_Diff = _lsreturn.ShipDate_ScanDate_Days_Diff;

                TblRerutn.CallTag = calltag;

                TblRerutn.ProgressFlag = InProgress;


                if (Obj.Rcall.UpsetReturnTbl(TblRerutn)) ReturnID = TblRerutn.ReturnID;
            }
            catch (Exception)
            {
            }
            return ReturnID;

        }


        public Guid SetReturnByPonumberTbl(Return _lsreturn, byte Status, byte Decision, Guid UserID, DateTime ScannedDate, DateTime ExpirarionDate, int InProgress, string calltag)
        {
            Guid ReturnID = Guid.NewGuid();
            try
            {
                Return TblRerutn = new Return();

                TblRerutn.ReturnID = _lsreturn.ReturnID;
                TblRerutn.RMANumber = _lsreturn.RMANumber;
                TblRerutn.ShipmentNumber = _lsreturn.ShipmentNumber;
                TblRerutn.OrderNumber = _lsreturn.OrderNumber;
                TblRerutn.PONumber = _lsreturn.PONumber;
                TblRerutn.OrderDate = _lsreturn.OrderDate;
                TblRerutn.DeliveryDate = _lsreturn.DeliveryDate;
                TblRerutn.ReturnDate = _lsreturn.ReturnDate;
                TblRerutn.ScannedDate = ScannedDate;
                TblRerutn.ExpirationDate = ExpirarionDate;
                TblRerutn.VendorNumber = _lsreturn.VendorNumber;
                TblRerutn.VendoeName = _lsreturn.VendoeName;
                TblRerutn.CustomerName1 = _lsreturn.CustomerName1;
                TblRerutn.CustomerName2 = _lsreturn.CustomerName2;
                TblRerutn.Address1 = _lsreturn.Address1;
                TblRerutn.Address2 = _lsreturn.Address2;
                TblRerutn.Address3 = _lsreturn.Address3;
                TblRerutn.ZipCode = _lsreturn.ZipCode;
                TblRerutn.City = _lsreturn.City;
                TblRerutn.State = _lsreturn.State;
                TblRerutn.Country = _lsreturn.Country;
                TblRerutn.ReturnReason = "";
                TblRerutn.RMAStatus = Status;
                TblRerutn.Decision = Decision;
                TblRerutn.CreatedBy = _lsreturn.CreatedBy;
                TblRerutn.CreatedDate = _lsreturn.CreatedDate;
                TblRerutn.UpdatedBy = UserID;
                TblRerutn.UpdatedDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Eastern Standard Time");


                TblRerutn.Wrong_RMA_Flg = _lsreturn.Wrong_RMA_Flg;//Wrong_RMA_Flg;
                TblRerutn.Warranty_STA = _lsreturn.Warranty_STA;
                TblRerutn.Setting_Wty_Days = _lsreturn.Setting_Wty_Days;
                TblRerutn.ShipDate_ScanDate_Days_Diff = _lsreturn.ShipDate_ScanDate_Days_Diff;

                TblRerutn.CallTag = calltag;

                TblRerutn.ProgressFlag = InProgress;


                if (Obj.Rcall.UpsetReturnByPonumerTbl(TblRerutn)) ReturnID = TblRerutn.ReturnID;
            }
            catch (Exception)
            {
            }
            return ReturnID;

        }


        public Guid SetReturnByRGANumber(Return _lsreturn, byte Status, byte Decision, Guid UserID, DateTime ScannedDate, DateTime ExpirarionDate, int InProgress, string calltag)
        {
            Guid ReturnID = Guid.NewGuid();
            try
            {
                Return TblRerutn = new Return();

                TblRerutn.ReturnID = _lsreturn.ReturnID;
                TblRerutn.RMANumber = _lsreturn.RMANumber;
                TblRerutn.ShipmentNumber = _lsreturn.ShipmentNumber;
                TblRerutn.OrderNumber = _lsreturn.OrderNumber;
                TblRerutn.PONumber = _lsreturn.PONumber;
                TblRerutn.OrderDate = _lsreturn.OrderDate;
                TblRerutn.DeliveryDate = _lsreturn.DeliveryDate;
                TblRerutn.ReturnDate = _lsreturn.ReturnDate;
                TblRerutn.ScannedDate = ScannedDate;
                TblRerutn.ExpirationDate = ExpirarionDate;
                TblRerutn.VendorNumber = _lsreturn.VendorNumber;
                TblRerutn.VendoeName = _lsreturn.VendoeName;
                TblRerutn.CustomerName1 = _lsreturn.CustomerName1;
                TblRerutn.CustomerName2 = _lsreturn.CustomerName2;
                TblRerutn.Address1 = _lsreturn.Address1;
                TblRerutn.Address2 = _lsreturn.Address2;
                TblRerutn.Address3 = _lsreturn.Address3;
                TblRerutn.ZipCode = _lsreturn.ZipCode;
                TblRerutn.City = _lsreturn.City;
                TblRerutn.State = _lsreturn.State;
                TblRerutn.Country = _lsreturn.Country;
                TblRerutn.ReturnReason = "";
                TblRerutn.RMAStatus = Status;
                TblRerutn.Decision = Decision;
                TblRerutn.CreatedBy = _lsreturn.CreatedBy;
                TblRerutn.CreatedDate = _lsreturn.CreatedDate;
                TblRerutn.UpdatedBy = UserID;
                TblRerutn.UpdatedDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Eastern Standard Time");


                TblRerutn.Wrong_RMA_Flg = _lsreturn.Wrong_RMA_Flg;//Wrong_RMA_Flg;
                TblRerutn.Warranty_STA = _lsreturn.Warranty_STA;
                TblRerutn.Setting_Wty_Days = _lsreturn.Setting_Wty_Days;
                TblRerutn.ShipDate_ScanDate_Days_Diff = _lsreturn.ShipDate_ScanDate_Days_Diff;

                TblRerutn.CallTag = calltag;

                TblRerutn.ProgressFlag = InProgress;
                TblRerutn.RGAROWID = _lsreturn.RGAROWID;


                if (Obj.Rcall.UpsetReturnByRGANumber(TblRerutn)) ReturnID = TblRerutn.ReturnID;
            }
            catch (Exception)
            {
            }
            return ReturnID;

        }

        public Guid SetReturnDetailTblForEditPage(Guid _lsreturndetail, Guid ReturnTblID, String SKUNumber, String ProductName, int ReturnQty, Guid CreatedBy, string SKU_Status, int SKU_Reason_Total_Points, int IsScanned, int Manually, int NewItemQty, int SKU_Qty_Seq, string ProductID, decimal SalesPrice, int LineType, int ShipmentLines, int ReturnLines, DateTime UpdatedDate, DateTime CreatedDate, string TrackingNumber)
        {
            Guid returndetail = Guid.NewGuid();
            try
            {
                ReturnDetail TblReturnDetails = new ReturnDetail();

                TblReturnDetails.ReturnDetailID = _lsreturndetail;
                TblReturnDetails.ReturnID = ReturnTblID;
                TblReturnDetails.SKUNumber = SKUNumber;
                TblReturnDetails.ProductName = ProductName;
                TblReturnDetails.DeliveredQty = 0;
                TblReturnDetails.ExpectedQty = 0;
                TblReturnDetails.TCLCOD_0 = "";
                TblReturnDetails.ReturnQty = ReturnQty;
                TblReturnDetails.ProductStatus = 0;
                TblReturnDetails.CreatedBy = CreatedBy;
                TblReturnDetails.CreatedDate = CreatedDate;// TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Eastern Standard Time");
                TblReturnDetails.UpadatedDate = UpdatedDate;// TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Eastern Standard Time");
                TblReturnDetails.UpdatedBy = CreatedBy;

                TblReturnDetails.SKU_Status = SKU_Status;
                TblReturnDetails.SKU_Reason_Total_Points = SKU_Reason_Total_Points;
                TblReturnDetails.IsSkuScanned = IsScanned;
                TblReturnDetails.IsManuallyAdded = Manually;

                TblReturnDetails.SKU_Sequence = NewItemQty;
                TblReturnDetails.SKU_Qty_Seq = ReturnQty;

                TblReturnDetails.SalesPrice = SalesPrice;
                TblReturnDetails.ProductID = ProductID;

                TblReturnDetails.LineType = LineType;

                TblReturnDetails.ShipmentLines = ShipmentLines;
                TblReturnDetails.ReturnLines = ReturnLines;
                TblReturnDetails.TrackingNumber = TrackingNumber;

                if (Obj.Rcall.UpsetReturnDetails(TblReturnDetails)) returndetail = TblReturnDetails.ReturnDetailID;
            }
            catch (Exception)
            {
            }
            return returndetail;
        }



        /// <summary>
        /// update return detail information.
        /// </summary>
        /// <returns>
        /// retund returndetailID
        /// </returns>
        public Guid SetReturnDetailTbl(Guid _lsreturndetail,Guid ReturnTblID, String SKUNumber, String ProductName, int ReturnQty, Guid CreatedBy, string SKU_Status, int SKU_Reason_Total_Points, int IsScanned, int Manually, int NewItemQty, int SKU_Qty_Seq, string ProductID, decimal SalesPrice, int LineType, int ShipmentLines, int ReturnLines)
        {
            Guid returndetail = Guid.NewGuid();
            try
            {
                ReturnDetail TblReturnDetails = new ReturnDetail();

                TblReturnDetails.ReturnDetailID = _lsreturndetail;
                TblReturnDetails.ReturnID = ReturnTblID;
                TblReturnDetails.SKUNumber = SKUNumber;
                TblReturnDetails.ProductName = ProductName;
                TblReturnDetails.DeliveredQty = 0;
                TblReturnDetails.ExpectedQty = 0;
                TblReturnDetails.TCLCOD_0 = "";
                TblReturnDetails.ReturnQty = ReturnQty;
                TblReturnDetails.ProductStatus = 0;
                TblReturnDetails.CreatedBy = CreatedBy;
                TblReturnDetails.CreatedDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Eastern Standard Time");
                TblReturnDetails.UpadatedDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Eastern Standard Time");
                TblReturnDetails.UpdatedBy = CreatedBy;

                TblReturnDetails.SKU_Status = SKU_Status;
                TblReturnDetails.SKU_Reason_Total_Points = SKU_Reason_Total_Points;
                TblReturnDetails.IsSkuScanned = IsScanned;
                TblReturnDetails.IsManuallyAdded = Manually;

                TblReturnDetails.SKU_Sequence = NewItemQty;
                TblReturnDetails.SKU_Qty_Seq = ReturnQty;

                TblReturnDetails.SalesPrice = SalesPrice;
                TblReturnDetails.ProductID = ProductID;

                TblReturnDetails.LineType = LineType;

                TblReturnDetails.ShipmentLines = ShipmentLines;
                TblReturnDetails.ReturnLines = ReturnLines;

                if (Obj.Rcall.UpsetReturnDetails(TblReturnDetails)) returndetail = TblReturnDetails.ReturnDetailID;
            }
            catch (Exception)
            {
            }
            return returndetail;
        }

        #region deepak Barcode Slip Print info
        List<cSlipInfo> _lsslipinfo = new List<cSlipInfo>();
        public cSlipInfo GetSlipInfo(string SkuNumber, String EANCode, String ReturnReasons, string NewRGANumber, string RMAStatus, string ItemStatus, string nm, string ponum, Guid ReturnDtl)
        {
            //Return lsret = new Return();
            cSlipInfo slip = new cSlipInfo();
            try
            {
                //  Guid usreid = (Guid)lsret.CreatedBy;
                // Guid userId = (Guid)Views.Global.ReteunGlobal.CreatedBy;

                // Obj.Rcall.GetUserInfobyUserID(Views.Global.userId);
                /// string nm = Obj.Rcall.GetUserInfobyUserID(usreid).UserName;


                //////  string dr = Convert.ToString(Obj.Rcall.GetUserInfobyUserID(userId).UserID);


                slip.ProductName = SkuNumber;
                slip.Reason = ReturnReasons;
                slip.ReceivedBY = nm;
                slip.ReceivedDate = DateTime.UtcNow;
                slip.Expiration = DateTime.UtcNow.AddDays(60);
                slip.SRNumber = NewRGANumber;
                slip.EANCode = EANCode;
                slip.ItemStatus = ItemStatus;
                slip.RMAStatus = RMAStatus;
                slip.PoNumber = ponum;
                slip.ReturnDetailID = ReturnDtl;
                //_lsslipinfo.Add(slip);
            }
            catch (Exception)
            {

            }
            return slip;
        }
        #endregion 



        //public Guid SetReturnDetailNewInsertTbl(Guid _lsreturndetail, Guid ReturnTblID, String SKUNumber, String ProductName, int ReturnQty, Guid CreatedBy, string SKU_Status, int SKU_Reason_Total_Points, int IsScanned, int Manually, int NewItemQty, int SKU_Qty_Seq, string ProductID, decimal SalesPrice, int LineType, int ShipmentLines, int ReturnLines)
        //{
        //    Guid returndetail = Guid.NewGuid();
        //    try
        //    {
        //        ReturnDetail TblReturnDetails = new ReturnDetail();

        //        TblReturnDetails.ReturnDetailID = _lsreturndetail;
        //        TblReturnDetails.ReturnID = ReturnTblID;
        //        TblReturnDetails.SKUNumber = SKUNumber;
        //        TblReturnDetails.ProductName = ProductName;
        //        TblReturnDetails.DeliveredQty = 0; ;
        //        TblReturnDetails.ExpectedQty = 0;
        //        TblReturnDetails.TCLCOD_0 = "";
        //        TblReturnDetails.ReturnQty = ReturnQty;
        //        TblReturnDetails.ProductStatus = 0;
        //        TblReturnDetails.CreatedBy = CreatedBy;
        //        TblReturnDetails.CreatedDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Eastern Standard Time");
        //        TblReturnDetails.UpadatedDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Eastern Standard Time");
        //        TblReturnDetails.UpdatedBy = CreatedBy;

        //        TblReturnDetails.SKU_Status = SKU_Status;
        //        TblReturnDetails.SKU_Reason_Total_Points = SKU_Reason_Total_Points;
        //        TblReturnDetails.IsSkuScanned = IsScanned;
        //        TblReturnDetails.IsManuallyAdded = Manually;

        //        TblReturnDetails.SKU_Sequence = NewItemQty;
        //        TblReturnDetails.SKU_Qty_Seq = SKU_Qty_Seq;

        //        TblReturnDetails.SalesPrice = SalesPrice;
        //        TblReturnDetails.ProductID = ProductID;

        //        TblReturnDetails.LineType = LineType;

        //        TblReturnDetails.ShipmentLines = ShipmentLines;
        //        TblReturnDetails.ReturnLines = ReturnLines;

        //        if (Obj.Rcall.UpsetReturnDetails(TblReturnDetails)) returndetail = TblReturnDetails.ReturnDetailID;
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    return returndetail;
        //}

        /// <summary>
        /// this Methods is used for to get ReasonID By ReturnDetails.
        /// </summary>
        /// <param name="ReturnDetailID">
        /// ReturnID pass as parameter.
        /// </param>
        /// <returns>
        /// Return String as ReturnDetailID.
        /// </returns>
        public String ReasonsIdByHasg(Guid ReturnDetailID)
        {
            String _return = "";
            var lsReasonId = Obj.Rcall.ReasonsByReturnDetailID(ReturnDetailID);
            try
            {
                foreach (var Resnitem in lsReasonId)
                {
                    _return += Resnitem.ReasonID + "#";
                }
            }
            catch (Exception)
            {
            }
            return _return;
        }

        /// <summary>
        /// this Method is used to count selected Reasons.
        /// </summary>
        /// <param name="ReturnDetailID">
        /// pass ReturnDetailID as Parameter.
        /// </param>
        /// <returns>
        /// Return Int Value.
        /// </returns>
        public int ReasonCount(Guid ReturnDetailID)
        {
            int _return = 0;
            var lsReasonId = Obj.Rcall.ReasonsByReturnDetailID(ReturnDetailID);
            try
            {
                _return = lsReasonId.Count();
            }
            catch (Exception)
            {
            }
            return _return;
        }

        /// <summary>
        /// This Method is for Delete SKUreasons By ReturnDetailID.
        /// </summary>
        /// <param name="ReturnDetailsID">
        /// Pass ReturnDetailID as parameter.
        /// </param>
        /// <returns>
        /// Return Boolean Value.
        /// </returns>
        public Boolean DeleteSKuReasonsByReturnDetailID(Guid ReturnDetailsID)
        {
            return Obj.Rcall.DeleteSKUReasonsByReturnDetailID(ReturnDetailsID);
        }

        /// <summary>
        /// This Function is for Set SKUReasons table.
        /// </summary>
        /// <param name="ReasonID">
        /// Pass ReasonID as parameter.
        /// </param>
        /// <param name="ReturnDetailID">
        /// pass ReturnDetailID as parameter.
        /// </param>
        /// <returns></returns>
        public Guid SetSkuReasons(Guid ReasonID, Guid ReturnDetailID)
        {
            Guid _transationID = Guid.Empty;
            try
            {
                SKUReason tra = new SKUReason();
                tra.SKUReasonID = Guid.NewGuid();
                tra.ReasonID = ReasonID;
                tra.ReturnDetailID = ReturnDetailID;

                if (cRtnreasons.SetSKuReasons(tra)) _transationID = tra.SKUReasonID;
            }
            catch (Exception)
            {

            }
            return _transationID;
        }

        public Guid SetReturnedSKUPoints(Guid ReturnedSKUID, Guid ReturnDetailsID, Guid ReturnTblID, String SKU, String Reason, string Reason_Value, int Points, int skusequence)
        {
            Guid _ReturnedskuID = Guid.Empty;
            try
            {
                ReturnedSKUPoints TblReturnedSKUPoints = new ReturnedSKUPoints();

                TblReturnedSKUPoints.ID = ReturnedSKUID;
                TblReturnedSKUPoints.ReturnDetailID = ReturnDetailsID;
                TblReturnedSKUPoints.ReturnID = ReturnTblID;
                TblReturnedSKUPoints.SKU = SKU;
                TblReturnedSKUPoints.Reason = Reason;
                TblReturnedSKUPoints.Reason_Value = Reason_Value;
                TblReturnedSKUPoints.Points = Points;
                TblReturnedSKUPoints.SkuSequence = skusequence;


                //On Success of transaction.
                if (creturnedReason.UpsertReturnedSKUPoints(TblReturnedSKUPoints)) _ReturnedskuID = TblReturnedSKUPoints.ID;

            }
            catch (Exception)
            {
              //  ex.LogThis("mReturnedSKUPoints/SetReturnedSKUPoints");
            }
            return _ReturnedskuID;
        }
    }
}