using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackingClassLibrary.CustomEntity;
using PackingClassLibrary.Commands;
using PackingClassLibrary.Commands.ReportCommands;
using PackingClassLibrary.CustomEntity.ReportEntitys;
using PackingClassLibrary.CustomEntity.SMEntitys.RGA;
using PackingClassLibrary.Commands.SMcommands.RGA;
using System.Collections;
using PackingClassLibrary.CustomEntity.SMEntitys;


namespace PackingClassLibrary
{
   public class ReportController
   {

     


       #region Declaration
      
       cmdReturn _cReturn = new cmdReturn();
       cmdReturnDetails _cReturnDetail = new cmdReturnDetails();
       cmdReasons _cReasons = new cmdReasons();
       cmdReasonCategory _cReasonCategoty = new cmdReasonCategory();
       cmdSKUReasons _cSKUReasons = new cmdSKUReasons();

       cmdUserforRGA _cuser = new cmdUserforRGA();

       cmdRMAComment _cRMAComment = new cmdRMAComment();

       cmdReturnedSKUPoints _cReturnedSKUPoint = new cmdReturnedSKUPoints();
       cmdRMAInfo _lsreturn = new cmdRMAInfo();
       #endregion


       #region Shipping table Processing
       /// <summary>
       /// Get all Shipping ids information with Delivery provider name
       /// </summary>
        /// <returns>List<cstShippingInfoBPName></returns>
       public List<cstShippingInfoBPName> GetBpinfoOFShippingNum()
       {
           cmdBPNameShippingNum command = new cmdBPNameShippingNum();
           return command.GetBpinfoOFShippingNum();
       }

       /// <summary>
       /// get Delivery provider Name from the number
       /// </summary>
       /// <param name="BPCNUM">Strign Delivery provider Number</param>
       /// <returns>String Delivery provider Name</returns>
       public String GetDeliveryProviderNameFromBPCNUM(String BPCNUM)
       {
           cmdBPNameShippingNum command = new cmdBPNameShippingNum();
           return command.getBPNameFromBPNUM(BPCNUM);
       }
       #endregion
       
       #region Total Shipment Packed By user Per date
       /// <summary>
       /// User packed total shipment count per day per user
       /// </summary>
       /// <returns>List of cstUserShipmentCount</returns>
       public List<cstUserShipmentCount> GetUserTotalPakedPerDay()
       {
           cmdUserShipmentCount command = new cmdUserShipmentCount();
           return command.GetAllShipmentCountByUser();
       }
        
       #endregion
       
       /// <summary>
       /// Shipment number serch for information of packing status
       /// </summary>
       /// <param name="ShippingNumber">String Shipping Number</param>
       /// <returns>List<cstShipmentNumStatus> depending on location retuersn shipping number information</returns>
       #region Shipping Number with status and location

       public List<cstShipmentNumStatus> GetShippingStatus(String ShippingNumber)
       {
           cmdShippinNumStatus command = new cmdShippinNumStatus();
          return command.GetStaus(ShippingNumber);
       }

       #endregion
       
       #region Station Total Packed and Unpacked.
       /// <summary>
       /// Total Shipment packed per station and under packing Shipments per station
       /// </summary>
       /// <returns>List<cstStationToatlPacked>  information</returns>
       public List<cstStationToatlPacked> GetStationTotalPaked()
       {
           cmdStationTotalPacked command = new cmdStationTotalPacked();
           return command.GetEachStationPacked();
       }

       /// <summary>
       /// For Station Dashboard screen
       /// </summary>
       /// <param name="DatetimeNow"></param>
       /// <returns></returns>
       public List<cstDashBoardStion> GetStationDashboard(DateTime DatetimeNow)
       {
           cmdStationTotalPacked command = new cmdStationTotalPacked();
           return command.GetStationByReport(DatetimeNow);
       }

       /// <summary>
       /// Total Shipment packed per station and under packing Shipments per station on the given date
       /// </summary>
       /// <param name="ReportDate">Date Time Report Date</param>
       /// <returns>List<cstStationToatlPacked></returns>
       public List<cstStationToatlPacked> GetStationTotalPaked(DateTime ReportDate)
       {
           cmdStationTotalPacked command = new cmdStationTotalPacked();
           return command.GetEachStationPacked(ReportDate);
       }

       /// <summary>
       /// Station Total Packed Shipment Today by staion Name
       /// </summary>
       /// <param name="StationName">
       /// String Staion name.
       /// </param>
       /// <returns>
       /// inter total packed Shipment Count. else 0.
       /// </returns>
       public int TotalPackedTodayByStationID(String  StationName)
       {
           cmdStationTotalPacked cmd = new cmdStationTotalPacked();
           return cmd.PackedTodayByStationID(StationName);
       }


       public String GetShippingNumByStation(String StationName)
       {
           cmdStationTotalPacked cmd = new cmdStationTotalPacked();
           return cmd.UnderPackingID(StationName);
       }
       #endregion

       #region ReturnedSkuPoints

       public List<ReturnedSKUPoints> ReturnedSKUansPoints(Guid ReturnID)
       {
           return _cReturnedSKUPoint.GetReturnedSKUPointsByReturnID(ReturnID);
       
       }

       #endregion

       #region RGA

       #region Return

       /// <summary>
       /// Deeepak 
       /// </summary>
       /// <returns></returns>

       public List<RMAInfo> ReturnDetailByPoNumber(string PoNumber)
       {
           return _lsreturn.ReturnDetailByPonumber(PoNumber);
       }

       
       
       /// end

       public List<ReturnWithString> Todaysall()
       {
           return _lsreturn.FortodayData();
       }

       public List<ReturnWithString> PendingDecision()
       {

           return _lsreturn.forPendingDecision();
       }
       public List<ReturnWithString> returnByTracking(Guid returnId)
       {

           return _lsreturn.returnByTracking(returnId);
       }


       public List<Return> ReturnAll()
       {
           return _cReturn.GetallReturn();
       }

       public List<ReturnWithString> ReturnAllString()
       {
           return _cReturn.GetallReturnWithString();
       }

       public Return ReturnByReturnID(Guid ReturnID)
       {
           return _cReturn.ReturnByReturnID(ReturnID);
       }
       public Return ReturnByRMANumber(string RMANumber)
       {
           return _cReturn.ReturnByRMANumber(RMANumber);
       }

       public List<Return> ReturnByOrderNum(string OrderNum)
       {
           return _cReturn.ReturnByOrderNum(OrderNum);
       }

       public List<Return> ReturnByVendoeNum(string VendorNumber)
       {
           return _cReturn.ReturnByVendoeNum(VendorNumber);
       }

       public List<Return> ReturnByVendorName(string VendorName)
       {
           return _cReturn.ReturnByVendorName(VendorName);
       }

       public List<Return> ReturnByShipmentNumber(string ShipmentNumber)
       {
           return _cReturn.ReturnByShipmentNumber(ShipmentNumber);
       }

       public List<Return> ReturnByPONumber(string PONumber)
       {
           return _cReturn.ReturnByPONumber(PONumber);
       }

       public List<Return> ReturnByRGAROWID(string RGAROWID)
       {
           return _cReturn.ReturnByRGAROWID(RGAROWID);
       }

       public List<Return> ReturnByRGADROWID(string RGADROWID)
       {
           return _cReturn.ReturnByRGADROWID(RGADROWID);
       }

       public Boolean UpsetReturnTbl(Return Rtn)
       {
           return _cReturn.UpdateReturn(Rtn);
       }

        public Boolean UpsetReturnByPonumerTbl(Return Rtn)
       {
           return _cReturn.UpdateReturnByPOnumber(Rtn);
       }

        public Boolean UpsetReturnByRGANumber(Return Rtn)
        {
            return _cReturn.UpsertReturnTblByRGANumber(Rtn);
        }

       public List<String> GetCustByPOnumber(string chars)
       {
           return _cReturn.GetPONumber(chars);
       }
       public List<string> VenderName(string chars)
       {
           return _cReturn.GetVenderName(chars);
       }
       public List<string> VenderNumber(string chars)
       {
           return _cReturn.GetVenderNumber(chars);
       }
       public string VenderNameByVenderNumber(string VenderNum)
       {
           return _cReturn.GetVenderNamebyVenderNumber(VenderNum);
       }
       public string VenderNumberByVenderName(string VenderName)
       {
           return _cReturn.GetVenderNumberByVenderName(VenderName);
       }
       public List<ReturnDetails> GetTrackingNumbersInReturnDetails()
       {
           return _cReturn.GetTrackingNumbersInReturnDetails();
       }
       #endregion

       #region Return Detail

       public List<ReturnDetail> ReturnDetailAll()
       {
           return _cReturnDetail.ReturnDetailAll();
       }

       public List<ReturnDetail> ReturnDetailByretrnID(Guid RetunID)
       {
           return _cReturnDetail.ReturnDetailByretrnID(RetunID);
       }

       public List<ReturnDetail> ReturnDetailByRetundetailID(Guid RetundetailID)
       {
           return _cReturnDetail.ReturnDetailByRetundetailID(RetundetailID);
       }

       public List<ReturnDetail> ReturnDetailByRGADROWID(string RGADROWID)
       {
           return _cReturnDetail.ReturnDetailByRGADROWID(RGADROWID);
       }

       public List<ReturnDetail> ReturnDetailByRGAROWID(string RGAROWID)
       {
           return _cReturnDetail.ReturnDetailByRGAROWID(RGAROWID);
       }

       public Boolean UpsetReturnDetails(ReturnDetail ReturnDtls)
       {
           return _cReturnDetail.UpdateReturnDetail(ReturnDtls);
       }

       public Boolean DeleteAllTablesByReturnDetailID(Guid ReturnDetailID)
       {
           return _cReturnDetail.DeleteAllTabledRecordsByReturnDetailID(ReturnDetailID);
       }

       #endregion

       #region Resons

       public List<Reason> ReasonsAll()
       {
           return _cReasons.ReasonsAll();
       }

       public List<Reason> ReasonByCategoryName(string CategoryName)
       {
           return _cReasons.ReasonByCategoryName(CategoryName);
       }

       public string ReasonsListByReturnDetails(Guid ReturnDetailID)
       {
           return _cReasons.ListOfReasons(ReturnDetailID);
       }
       public Guid UpsertReasons(string _Reason)
       {
           //return _cReasons.UpsertReason(_Reason);

           Guid _reasonID = Guid.Empty;

           try
           {
               Reason ReasonTable = new Reason();

               ReasonTable.ReasonID = Guid.NewGuid();
               ReasonTable.Reason1 = _Reason;
               ReasonTable.ReasonFlag = 0;

               if (_cReasons.UpsertReason(ReasonTable)) _reasonID = ReasonTable.ReasonID;
           }
           catch (Exception)
           {
           }
           return _reasonID;
       }

       public Guid SetTransaction(Guid SKUReasonID, Guid ReasonID, Guid ReturnDetailID)
       {
           Guid _transationID = Guid.Empty;
           try
           {
               SKUReason tra = new SKUReason();
               tra.SKUReasonID = SKUReasonID;
               tra.ReasonID = ReasonID;
               tra.ReturnDetailID = ReturnDetailID;

               if (_cReasons.SetSKuReasons(tra)) _transationID = tra.SKUReasonID;
           }
           catch (Exception)
           {
              
           }
           return _transationID;
       }


       public Guid SetTransaction1(Guid SKUReasonID, Guid ReasonID, Guid ReturnDetailID)
       {
           Guid _transationID = Guid.Empty;
           try
           {
               SKUReason tra = new SKUReason();
               tra.SKUReasonID = SKUReasonID;
               tra.ReasonID = ReasonID;
               tra.ReturnDetailID = ReturnDetailID;

               if (_cReasons.SetSKuReasons1(tra)) _transationID = tra.SKUReasonID;
           }
           catch (Exception)
           {

           }
           return _transationID;
       }



       public List<Reason> ReasonsByReturnDetailID(Guid ReturnDetailID)
       {
           return _cReasons.GetReasonsByReturnDetailID(ReturnDetailID);
       }

       public string GetReasonsInStringByReturnDetailIDF(Guid ReturnDetailID)
       {
           return _cReasons.GetReasonsInStringByReturnDetailID(ReturnDetailID);
       }

       public Boolean DeleteReasonByReasonID(Guid ReasonID)
       {
           return _cReasons.DeleteByReasonID(ReasonID);
       }

       #endregion

       #region SKUReasons

       public Boolean DeleteSKUReasonsByReturnDetailID(Guid ReturnDetailID)
       {
           return _cSKUReasons.DeleteByReturnDetailsID(ReturnDetailID);
       }

       public List<SKUReason> SKUReasonsByReturnDetails(List<ReturnDetail> LsRetnDetails)
       {
           return _cSKUReasons.GetReasons(LsRetnDetails);
       }

       public string GetReasonstringbyReturnID(Guid ReturnDetialID)
       {
           return _cReasons.GetReasonstringByReturnDetailID(ReturnDetialID);
       }



       #endregion

       #region Return Images

       public List<String> ReturnImagesByReturnDetailsID(Guid ReturnDetailsID)
       {
           cmdReturnImages _images = new cmdReturnImages();
           return _images.ReturnImagesByReturnDetailsID(ReturnDetailsID);
       }
       public Boolean deleteImageFromDatabase(Guid ReturnDetailsID, string ImgS)
       {
           cmdReturnImages _images = new cmdReturnImages();
           return _images.deleteImageFromDatabase(ReturnDetailsID, ImgS);
       }
       #endregion

       #region CategotyReson table

       public List<ReasonCategoty> GetReasonCategotyAll()
       {
           return _cReasonCategoty.All();
       }

       public List<ReasonCategoty> GetReasonCategoryByReasonID(Guid ReasonID)
       {
           return _cReasonCategoty.CategotyReasonNameByReasonID(ReasonID);
       }

       public Boolean UpsertReasonCategory(ReasonCategoty ReasonCat)
       {
           return _cReasonCategoty.UpsertReasonCategory(ReasonCat);
       }

    
       #endregion
       
       
       #endregion


       #region User
       public UserMaster GetUserInfobyUserID(Guid UserID)
       {
           return _cuser.UserInfoByUserID(UserID);
       }
       #endregion

       #region RMAComment
       public List<RMAComment> GetRMACommentByReturnID(Guid ReturnID)
       {
           return _cRMAComment.GetCommentByReturnID(ReturnID);
       }

       public Boolean InsertRMACommnt(RMAComment Comment)
       {
           return _cRMAComment.InsertComment(Comment);
       }


       #endregion

       #region RMAInfo
       public List<RMAInfo> ReturnDetailBySRNumber(string srnumber)
       {
           return _lsreturn.ReturnDetailBySRNumber(srnumber);
       }

       #endregion





       public List<ReturnWithString> returnByTrackingText(string text)
      {

          return _lsreturn.returnByTrackingText(text);
      }


       public List<ReturnForFrid> lsReturnForGrid()
       {
           //ReturnAll();
           List<ReturnForFrid> lsreturb = new List<ReturnForFrid>();

           // lsreturb=ReturnAll();
           string ProgressFlag, RMAStatus, Decision, lastUpdatedBy;

           var sort = from r in ReturnAll()
                      select new
                      {
                          ProgressFlag = r.ProgressFlag == 1 ? "Flag" : "",
                          RMAStatus = r.RMAStatus == 0 ? "Incomplete" :
                          r.RMAStatus == 1 ? "Complete" :
                          r.RMAStatus == 2 ? "Wrong RMA" :
                          r.RMAStatus == 3 ? "To Process" : "",

                          Decision = r.Decision == 0 ? "Pending" :
                          r.Decision == 1 ? "Deny" :
                          r.Decision == 2 ? "Full Refund" :
                          r.Decision == 3 ? "Partial-Refund" : "",

                          lastUpdatedBy = r.UpdatedBy == null ? "" : GetUserInfobyUserID((Guid)r.UpdatedBy).UserFullName,

                          r.RGAROWID,
                          r.RMANumber,
                          r.PONumber,
                          r.OrderNumber,
                          r.ShipmentNumber,
                          r.ReturnDate,
                          r.CustomerName1,
                          r.VendoeName,
                      };

           foreach (var item in sort)
           {
               ReturnForFrid templs = new ReturnForFrid();
               templs.ProgressFlag = item.ProgressFlag;
               templs.RMAStatus = item.RMAStatus;
               templs.Decision = item.Decision;
               templs.RGAROWID = item.RGAROWID;
               templs.RMANumber = item.RGAROWID;
               templs.PONumber = item.PONumber;
               templs.VendoeName = item.VendoeName;
               templs.CustomerName1 = item.CustomerName1;
               templs.ReturnDate = item.ReturnDate;
               templs.UpdatedBy = item.lastUpdatedBy;
               templs.OrderNumber = item.OrderNumber;
               templs.ShipmentNumber = item.ShipmentNumber;

               lsreturb.Add(templs);
           }

           return lsreturb;


           // int i = 0;
           //foreach (Return row in ReturnAll())
           //{
           //    ReturnForFrid lsReturn = new ReturnForFrid();

           //    int Value = Convert.ToInt32(row.ProgressFlag.ToString());

           //    switch (Value)
           //    {
           //        case 0:
           //            lsReturn.ProgressFlag = "Flag";
           //            break;
           //        case 1:
           //            lsReturn.ProgressFlag = "";
           //            break;

           //        default:
           //            break;
           //    }

           //    lsReturn.RGAROWID = row.RGAROWID;
           //    lsReturn.RMANumber = row.RMANumber;
           //    lsReturn.PONumber = row.PONumber;

           //    int forStatus = Convert.ToInt32(row.RMAStatus.ToString());

           //    switch (forStatus)
           //    {
           //        case 0:
           //            lsReturn.RMAStatus = "Incomplete";
           //            break;
           //        case 1:
           //            lsReturn.RMAStatus = "Complete";
           //            break;

           //        case 2:
           //            lsReturn.RMAStatus = "Wrong RMA";
           //            break;

           //        case 3:
           //            lsReturn.RMAStatus = "To Process";
           //            break;
           //        default:
           //            lsReturn.RMAStatus = "";
           //            break;
           //    }

           //    int forDecision = Convert.ToInt32(row.Decision.ToString());

           //    switch (forDecision)
           //    {
           //        case 0:
           //            lsReturn.Decision = "Pending";
           //            break;

           //        case 1:
           //            lsReturn.Decision = "Deny";
           //            break;

           //        case 2:
           //            lsReturn.Decision = "Full Refund";
           //            break;

           //        case 3:
           //            lsReturn.Decision = "Partial-Refund";
           //            break;

           //        default:
           //            lsReturn.Decision = "";
           //            break;
           //    }

           //    lsReturn.VendoeName = row.VendoeName;
           //    lsReturn.CustomerName1 = row.CustomerName1;
           //    lsReturn.ShipmentNumber = row.ShipmentNumber;

           //    lsReturn.OrderNumber = row.OrderNumber;
           //    lsReturn.ReturnDate = row.ReturnDate;

           //    string lastUpdatedBy = row.UpdatedBy.ToString();

           //    if (lastUpdatedBy == "")
           //    {
           //        lsReturn.UpdatedBy = "";
           //        //row.Cells[14].Text = "";
           //    }
           //    else
           //    {
           //        Guid UserID = Guid.Parse(lastUpdatedBy);
           //        lsReturn.UpdatedBy = GetUserInfobyUserID(UserID).UserFullName;
           //    }

           //    lsreturb.Add(lsReturn);

           //}
           //return lsreturb;


       }

       public List<cstUserEachPacked> GetEachUserPacked(DateTime ReportDate)
       {
           cmdStationTotalPacked command = new cmdStationTotalPacked();
           return command.GetEachUserPacked(ReportDate);
       }


       public Boolean DeleteReasonByReturnDetailID(Guid ReturnDetailID)
       {
           return _cReasons.DeleteByReturnDetailID(ReturnDetailID);
       }


       public Boolean DeleteRecordByReturnDetailID(Guid ReturnDetailID)
       {
           return _cReasons.DeleteRecordByReturnDetailID(ReturnDetailID);
       }



       public List<Return> DataforToday(List<Return> listreturn)
       {
           List<Return> lsreturn = new List<Return>();

           DateTime dt = DateTime.UtcNow.Date;

           var RMA = from returnALL in listreturn
                     where returnALL.UpdatedDate.ToShortDateString() == dt.ToShortDateString()
                     select returnALL;

           lsreturn = RMA.ToList();

           return lsreturn;
       }

       public List<ReturnWithString> DataforBetweenDates(List<ReturnWithString> listreturn, DateTime From, DateTime To)
       {
           List<ReturnWithString> lsreturn = new List<ReturnWithString>();

           DateTime dt = DateTime.UtcNow.Date;
        //   DateTime 

           var RMA = from returnALL in listreturn
                     where (returnALL.UpdatedDate.Date >= From.Date && returnALL.UpdatedDate.Date <= To.Date)
                     select returnALL;

           lsreturn = RMA.ToList();

           return lsreturn;
       }


       public List<Return> DataForPendingDecision(List<Return> listreturn)
       {
           List<Return> lsreturn = new List<Return>();

           DateTime dt = DateTime.UtcNow.Date;
           //   DateTime 

           var RMA = from returnALL in listreturn
                     where returnALL.Decision == 0
                     select returnALL;

           lsreturn = RMA.ToList();

           return lsreturn;
       }


       public List<Return> DataforSearchforPOnumber(List<Return> listreturn, string POnumber)
       {
           List<Return> lsreturn = new List<Return>();

           var RMA = from returnALL in listreturn
                     where returnALL.PONumber == POnumber
                     select returnALL;

           lsreturn = RMA.ToList();

           return lsreturn;
       }

       public List<Return> DataforSearchforShipmentNUmber(List<Return> listreturn, string ShipmentNUmber)
       {
           List<Return> lsreturn = new List<Return>();

           var RMA = from returnALL in listreturn
                     where returnALL.ShipmentNumber == ShipmentNUmber
                     select returnALL;

           lsreturn = RMA.ToList();

           return lsreturn;
       }

       public List<Return> DataforSearchforOrderNumber(List<Return> listreturn, string OrderNumber)
       {
           List<Return> lsreturn = new List<Return>();

           var RMA = from returnALL in listreturn
                     where returnALL.OrderNumber == OrderNumber
                     select returnALL;

           lsreturn = RMA.ToList();

           return lsreturn;
       }


       //public void Response()
       //{
       //    string script = " <script type=\"text/javascript\">  window.open('frmRMAFormPrint2.aspx');   </script> ";
       //    //  this.Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", script);
       //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
       
       //}
       public string EncodeCode(string code)
       {
           return _lsreturn.GetEANCode(code);
       }

   }
}
