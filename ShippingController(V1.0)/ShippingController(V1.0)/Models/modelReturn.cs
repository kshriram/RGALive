using PackingClassLibrary.CustomEntity.SMEntitys.RGA;
using PackingClassLibrary.GetService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using PackingClassLibrary.Commands.SMcommands.RGA;


namespace ShippingController_V1._0_.Models
{

    public class modelReturn
    {
        #region Declaration

        //Create Object of CmdReturn. 
        cmdReturn cReturnTbl = new cmdReturn();

        //Create Update of cmdReasons.
        cmdReasons cRtnreasons = new cmdReasons();

        //Create Object of cmdReturnImages.
        cmdReturnImages cRtnImages = new cmdReturnImages();

        //Create Object of cmdReasonCategory.
        cmdReasonCategory cCategoryReasons = new cmdReasonCategory();

        //Create Object of cmdReturnDetails.
        cmdReturnDetails cRetutnDetailsTbl = new cmdReturnDetails();

        #endregion

        /// <summary>
        /// List Of ReturnDetails.
        /// </summary>
        /// <param name="lsReturn">
        /// list of Return information. 
        /// </param>
        /// <returns>
        /// Retrurn List Of ReturnDetails.
        /// </returns>

        public List<ReturnDetail> ReturnAllRowsfromReturnTbl(List<Return> lsReturn)
        {
            List<ReturnDetail> lsReD = new List<ReturnDetail>();
            try
            {
                var ReturnDetais = from rm in lsReturn
                                   join Rd in Obj.Rcall.ReturnDetailAll()
                                   on rm.ReturnID equals Rd.ReturnID
                                   select new
                                   {
                                       Rd.ReturnDetailID,
                                       Rd.ReturnID,
                                       Rd.SKUNumber,
                                       Rd.ProductName,
                                       Rd.TCLCOD_0,
                                       Rd.DeliveredQty,
                                       Rd.ExpectedQty,
                                       Rd.ReturnQty,
                                       Rd.ProductStatus,
                                       Rd.CreatedBy,
                                       Rd.UpdatedBy,
                                       Rd.CreatedDate,
                                       Rd.UpadatedDate,
                                       Rd.RGADROWID,
                                       Rd.TrackingNumber
                                       
                                       
                                   };


                foreach (var ReturnDetails in ReturnDetais)
                {
                    ReturnDetail Rd1 = new ReturnDetail();
                    Rd1.ReturnDetailID = ReturnDetails.ReturnDetailID;
                    Rd1.ReturnID = ReturnDetails.ReturnID;
                    Rd1.SKUNumber = ReturnDetails.SKUNumber;
                    Rd1.ProductName = ReturnDetails.ProductName;
                    Rd1.TCLCOD_0 = ReturnDetails.TCLCOD_0;
                    Rd1.DeliveredQty = (int)ReturnDetails.DeliveredQty;
                    Rd1.ExpectedQty = (int)ReturnDetails.ExpectedQty;
                    Rd1.ReturnQty = (int)ReturnDetails.ReturnQty;
                    Rd1.ProductStatus = (int)ReturnDetails.ProductStatus;
                    Rd1.CreatedBy = (Guid)ReturnDetails.CreatedBy;
                    Rd1.UpdatedBy = (Guid)ReturnDetails.UpdatedBy;
                    Rd1.CreatedDate = (DateTime)ReturnDetails.CreatedDate;
                    Rd1.UpadatedDate = (DateTime)ReturnDetails.UpadatedDate;
                    Rd1.RGADROWID = ReturnDetails.RGADROWID;
                    Rd1.TrackingNumber = ReturnDetails.TrackingNumber;

                    lsReD.Add(Rd1);
                }

            }
            catch (Exception)
            { }

            return lsReD;

        }

        #region RMAInfo by RMANumber/SRNumber

        public List<RMAInfo> GetCustomerByRMANumber(string RMANumber)
        {
            List<RMAInfo> lsCustomer = new List<RMAInfo>();
            try
            {
                lsCustomer = cReturnTbl.GetCustInformationByRMANumber(RMANumber);
            }
            catch (Exception)
            {
            }
            return lsCustomer;

        }

        #endregion

        /// <summary>
        /// Text Of link Button
        /// </summary>
        /// <param name="LinkButtonID">
        /// String Link Button ID
        /// </param>
        /// <param name="GridViewName">
        /// Gridview Object link button belongs to
        /// </param>
        /// <returns>
        /// String Text Of Link Button 
        /// </returns>
        public String linkButtonText(String LinkButtonID, GridView GridViewName)
        {
            String _return = "";
            try
            {
                LinkButton lnk = (LinkButton)GridViewName.SelectedRow.FindControl(LinkButtonID);
                _return = lnk.Text;
            }
            catch (Exception)
            { }
            return _return;
        }


        /// <summary>
        /// this Method is to return the string decision. 
        /// </summary>
        /// <param name="Value">
        /// Value parameter to Return Decision.
        /// </param>
        /// <returns></returns>
        public String ConvertToDecision(int Value)
        {
            switch (Value)
            {
                case 0:
                    return "Pending";

                case 1:
                    return "Deny";


                case 2:
                    return "Full Refund";


                case 3:
                    return "Partial-Refund";

                default:
                    return "";
            }
        }

        public String ConvertToStatus(int Value)
        {
            switch (Value)
            {
                case 0:
                    return "Incomplete";

                case 1:
                    return "Complete";


                case 2:
                    return "Wrong RMA";


                case 3:
                    return "To Process";

                default:
                    return "";
            }
        }

        public String ConvertToFlag(int Value)
        {
            switch (Value)
            {
                case 0:
                    return "";

                case 1:
                    return "Flag";

                               

                default:
                    return "";
            }
        }

        public String UserName(Guid UserID)
        {
            string Name = "";

            try
            {
                Name = Obj.Rcall.GetUserInfobyUserID(UserID).UserFullName;
            }
            catch (Exception)
            {
            }

            return Name;
        }






        /// <summary>
        /// Return List Of Return Information.String SortExpression check in Switch case.
        /// </summary>
        /// <param name="sortExperssion">
        /// SortExpression string pass as parameter.
        /// </param>
        /// <returns>
        /// Return List of Return info.
        /// </returns>
        public List<Return> SortedListOFReturn(String sortExperssion)
        {
            List<Return> lsShippingSorted = new List<Return>();
            try
            {

                switch (sortExperssion)
                {
                    case "RGAROWID":
                        lsShippingSorted = (Obj._lsreturn.OrderBy(i => i.RGAROWID).ToList());
                        break;
                    case "RMANumber":
                        lsShippingSorted = (Obj._lsreturn.OrderBy(i => i.RMANumber).ToList());
                        break;
                    case "RMAStatus":
                        lsShippingSorted = (Obj._lsreturn.OrderBy(i => i.RMAStatus).ToList());
                        break;
                    case "Decision":
                        lsShippingSorted = (Obj._lsreturn.OrderBy(i => i.Decision).ToList());
                        break;
                    case "CustomerName":
                        lsShippingSorted = (Obj._lsreturn.OrderBy(i => i.CustomerName1).ToList());
                        break;
                    case "ShipmentNumber":
                        lsShippingSorted = (Obj._lsreturn.OrderBy(i => i.ShipmentNumber).ToList());
                        break;
                    case "VendorNumber":
                        lsShippingSorted = (Obj._lsreturn.OrderBy(i => i.VendorNumber).ToList());
                        break;
                    case "VendoeName":
                        lsShippingSorted = (Obj._lsreturn.OrderBy(i => i.VendoeName).ToList());
                        break;
                    case "ReturnDate":
                        lsShippingSorted = (Obj._lsreturn.OrderBy(i => i.ReturnDate).ToList());
                        break;
                    case "PONumber":
                        lsShippingSorted = (Obj._lsreturn.OrderBy(i => i.PONumber).ToList());
                        break;
                    case "OrderNumber":
                        lsShippingSorted = (Obj._lsreturn.OrderBy(i => i.OrderNumber).ToList());
                        break;

                    default:
                        lsShippingSorted = (Obj._lsreturn.OrderBy(i => i.RGAROWID).ToList());
                        break;
                }
            }
            catch (Exception)
            {
            }
            return lsShippingSorted;
        }

        /// <summary>
        /// this method Return ReturnDetails.
        /// </summary>
        /// <param name="SortExpression">
        /// SortExpression pass as parameter.
        /// </param>
        /// <returns>
        /// Return list of ReturnDetails.
        /// </returns>
        public List<ReturnDetail> SortedListOfReturnDetails(string SortExpression)
        {
            List<ReturnDetail> lsShippingSorted = new List<ReturnDetail>();
            try
            {
                switch (SortExpression)
            {
                case "RGADROWID":
                    lsShippingSorted = (Obj._lsReturnDetails.OrderBy(i => i.RGADROWID).ToList());
                    break;
                case "SKUNumber":
                    lsShippingSorted = (Obj._lsReturnDetails.OrderBy(i => i.SKUNumber).ToList());
                    break;
                case "ProductName":
                    lsShippingSorted = (Obj._lsReturnDetails.OrderBy(i => i.ProductName).ToList());
                    break;
                case "DeliveredQty":
                    lsShippingSorted = (Obj._lsReturnDetails.OrderBy(i => i.DeliveredQty).ToList());
                    break;
                case "ReturnQty":
                    lsShippingSorted = (Obj._lsReturnDetails.OrderBy(i => i.ReturnQty).ToList());
                    break;
                default:
                    lsShippingSorted = (Obj._lsReturnDetails.OrderBy(i => i.RGADROWID).ToList());
                    break;
            }
            }
            catch (Exception)
            {}
            return lsShippingSorted;

        }

        /// <summary>
        /// this method Set ReturnTable Information.
        /// </summary>
        /// <param name="lsNewRMA">
        /// List of Return info.
        /// </param>
        /// <param name="ReturnReason">
        /// string of ReturnReason.
        /// </param>
        /// <param name="RMAStatus">
        /// Byte of RMA Status.
        /// </param>
        /// <param name="Decision">
        /// Byte Of Decision.
        /// </param>
        /// <param name="CreatedBy">
        /// Guid CreatedBy pass user Guid. 
        /// </param>
        /// <returns>
        /// Return Guid ReturnID.
        /// </returns>
        public Guid SetReturnTbl(List<Return> lsNewRMA, String ReturnReason, Byte RMAStatus, Byte Decision, Guid CreatedBy)
        {
            Guid _returnID = Guid.Empty;
            try
            {
                //Return table new object.
                Return TblRerutn = new Return();

                TblRerutn.ReturnID = Guid.NewGuid();
                TblRerutn.RMANumber = null;//lsNewRMA[0].RMANumber;
                TblRerutn.ShipmentNumber = lsNewRMA[0].ShipmentNumber;
                TblRerutn.OrderNumber = "N/A";
                TblRerutn.PONumber = lsNewRMA[0].PONumber;
                TblRerutn.OrderDate = DateTime.UtcNow;
                TblRerutn.DeliveryDate = DateTime.UtcNow;
                TblRerutn.ReturnDate = lsNewRMA[0].ReturnDate;
                TblRerutn.VendorNumber = lsNewRMA[0].VendorNumber;
                TblRerutn.VendoeName = lsNewRMA[0].VendoeName;
                TblRerutn.CustomerName1 = lsNewRMA[0].CustomerName1;
                TblRerutn.ScannedDate = lsNewRMA[0].ScannedDate;
                TblRerutn.ExpirationDate = lsNewRMA[0].ExpirationDate;
                TblRerutn.CustomerName2 = "N/A";
                TblRerutn.Address1 = lsNewRMA[0].Address1;
                TblRerutn.Address2 = "N/A";
                TblRerutn.Address3 = "N/A";
                TblRerutn.ZipCode = lsNewRMA[0].ZipCode;
                TblRerutn.City = lsNewRMA[0].City;
                TblRerutn.State = lsNewRMA[0].State;
                TblRerutn.Country = lsNewRMA[0].Country;
                TblRerutn.ReturnReason = ReturnReason;
                TblRerutn.RMAStatus = RMAStatus;
                TblRerutn.Decision = Decision;
                TblRerutn.CreatedBy = CreatedBy;
                TblRerutn.CreatedDate = DateTime.UtcNow;
                TblRerutn.UpdatedBy = null;
                TblRerutn.UpdatedDate = DateTime.Now;

                //On success of transaction it returns id.
                if (cReturnTbl.UpdateReturn(TblRerutn)) _returnID = TblRerutn.ReturnID;

            }
            catch (Exception)
            {
            }
            return _returnID;
        }

        /// <summary>
        /// this method is for Get All Reasons.
        /// </summary>
        /// <returns>
        /// Return list of Reasons.
        /// </returns>
        public List<Reason> GetReasons()
        {
            List<Reason> reasonList = new List<Reason>();

            try
            {
                reasonList = cRtnreasons.ReasonsAll();
            }
            catch (Exception )
            {
              
            }
            return reasonList;
        }

        /// <summary>
        /// Set All information of ReturnDetails in Return Detail Table.
        /// </summary>
        /// <param name="ReturnTblID">
        /// pass ReturnID as parameter. 
        /// </param>
        /// <param name="SKUNumber">
        /// SKUNumber Pass String as Parameter.
        /// </param>
        /// <param name="ProductName">
        /// String Productname as Parameter.
        /// </param>
        /// <param name="DeliveredQty">
        /// int DeliveredQTY as parameter.
        /// </param>
        /// <param name="ExpectedQty">
        /// int Expected Qty as Parameter.
        /// </param>
        /// <param name="ReturnQty">
        /// int ReturnQty as Parameter.
        /// </param>
        /// <param name="TK"></param>
        /// <param name="CreatedBy">
        /// User Guid pass as paeameter.means Createdby.
        /// </param>
        /// <returns>
        /// Return Guid ReturnDetails.
        /// </returns>
        public Guid SetReturnDetailTbl(Guid ReturnTblID, String SKUNumber, String ProductName, int DeliveredQty, int ExpectedQty, int ReturnQty, string TK, Guid CreatedBy)
        {
            Guid _ReturnID = Guid.Empty;
            try
            {
                ReturnDetail TblReturnDetails = new ReturnDetail();

                TblReturnDetails.ReturnDetailID = Guid.NewGuid();
                TblReturnDetails.ReturnID = ReturnTblID;
                TblReturnDetails.SKUNumber = SKUNumber;
                TblReturnDetails.ProductName = ProductName;
                TblReturnDetails.DeliveredQty = DeliveredQty;
                TblReturnDetails.ExpectedQty = ExpectedQty;
                TblReturnDetails.TCLCOD_0 = TK;
                TblReturnDetails.ReturnQty = ReturnQty;
                TblReturnDetails.ProductStatus = 0;
                TblReturnDetails.CreatedBy = CreatedBy;
                TblReturnDetails.CreatedDate = DateTime.UtcNow;
                TblReturnDetails.UpadatedDate = DateTime.UtcNow;
                TblReturnDetails.UpdatedBy = CreatedBy;

                //On Success of transaction.
                if (cRetutnDetailsTbl.UpdateReturnDetail(TblReturnDetails)) _ReturnID = TblReturnDetails.ReturnDetailID;

            }
            catch (Exception )
            {
            }
            return _ReturnID;
        }

        /// <summary>
        /// this method is for Get List of Reasons By Category.
        /// </summary>
        /// <param name="Category">
        /// Category Name pass as parameter.
        /// </param>
        /// <returns>
        /// Return list Of Reasons.
        /// </returns>
        public List<Reason> GetReasons(String Category)
        {
            List<Reason> _lsReasons = new List<Reason>();
            try
            {
                _lsReasons = cRtnreasons.ReasonByCategoryName(Category);
            }
            catch (Exception)
            {
              
            }
            return _lsReasons;
        }

        /// <summary>
        /// Set SKUreasons in SKUreason Table.
        /// </summary>
        /// <param name="ReasonID">
        /// pass ReasonID as parameter.
        /// </param>
        /// <param name="ReturnDetailID">
        /// pass ReturnDetailID as Parameter.
        /// </param>
        /// <returns>
        /// Return Guid TransactionID.
        /// </returns>
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
            catch (Exception )
            {
                
            }
            return _transationID;
        }

        /// <summary>
        /// Set ReturnIamges In ReturnImages Table. 
        /// </summary>
        /// <param name="ImageID">
        /// pass Image Guid As parameter.
        /// </param>
        /// <param name="ReturnDetailID">
        /// pass ReturnDetailID as Parameter.
        /// </param>
        /// <param name="ImagePath">
        /// pass ImagePath As parameter.
        /// </param>
        /// <param name="CreatedBy">
        /// Pass UserID As Parameter that is CreatedBy.
        /// </param>
        /// <returns>
        /// Return ReturnImageID Guid.
        /// </returns>
        public Guid SetReturnedImages(Guid ImageID, Guid ReturnDetailID, String ImagePath, Guid CreatedBy)
        {
            Guid _ReturnID = Guid.Empty;
            try
            {
                ReturnImage RtnImages = new ReturnImage();

                RtnImages.ReturnImageID = ImageID;
                RtnImages.ReturnDetailID = ReturnDetailID;
                RtnImages.SKUImagePath = ImagePath;
                RtnImages.CreatedBy = CreatedBy;
                RtnImages.CreatedDate = DateTime.UtcNow;
                RtnImages.UpadatedBy = CreatedBy;
                RtnImages.UpadatedDate = DateTime.UtcNow;
                if (cRtnImages.UpsertReturnImage(RtnImages)) _ReturnID = RtnImages.ReturnImageID;

            }
            catch (Exception)
            {
               
            }
            return _ReturnID;
        }

        /// <summary>
        /// This Method Is for GetRowID by using the RMAID.
        /// </summary>
        /// <param name="RMAID">
        /// pass RMAID as parameter.
        /// </param>
        /// <returns>
        /// Return String NewRowID
        /// </returns>
        public String GetNewROWID(Guid RMAID)
        {
            String _retunn = "";
            try
            {
                _retunn = cReturnTbl.GetReturnTblByReturnID(RMAID).RGAROWID;
            }
            catch (Exception)
            { }
            return _retunn;
        }

        public List<RMAInfo> GetCustomer(string PONumber)
        {
            List<RMAInfo> lsCustomer = new List<RMAInfo>();
            try
            {
                lsCustomer = cReturnTbl.GetCustInformationByPoNumber(PONumber);
            }
            catch (Exception)
            {
            }
            return lsCustomer;

        }

        //public List<RMAInfo> GetCustomer1(string SRNumber)
        //{
        //    List<RMAInfo> lsCustomer = new List<RMAInfo>();
        //    try
        //    {
        //        lsCustomer = cReturnTbl.GetCustomerByRMANumber(string RMANumber);
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    return lsCustomer;

        //}

        public List<string> GetVenderName(String Chars)
        {
            List<string> lsvendername = new List<string>();
            try
            {
                lsvendername = cReturnTbl.GetVenderName(Chars);
            }
            catch (Exception)
            {
            }
            return lsvendername;
        }
        public List<string> GetVenderNumber(String Chars)
        {
            List<string> lsvendernumber = new List<string>();
            try
            {
                lsvendernumber = cReturnTbl.GetVenderNumber(Chars);
            }
            catch (Exception)
            {
            }
            return lsvendernumber;
        }
        public string GetVenderNumberByVenderName(String VenderName)
        {
            return cReturnTbl.GetVenderNumberByVenderName(VenderName);
        }
        public string GetVenderNameByVenderNumber(String VenderNumber)
        {
            return cReturnTbl.GetVenderNamebyVenderNumber(VenderNumber);
        }



       




    }
}