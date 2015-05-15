using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PackingClassLibrary.CustomEntity.SMEntitys.RGA;

namespace PackingClassLibrary.Commands.SMcommands.RGA
{
   public class cmdReturn
   {
       #region Get Methods
       
       /// <summary>
       /// Get All Return from GetRMA.ReturnAll();
       /// </summary>
       /// <returns>
       /// Return List of Return Information.
       /// </returns>
       public List<Return> GetallReturn()
       {
           List<Return> _lsreturn = new List<Return>();
           try
           {
               var v = from ls in Service.GetRMA.ReturnAll()
                       select ls;

               foreach (var Ritem in v)
               {
                   _lsreturn.Add(new Return(Ritem));
               }
           }
           catch (Exception)
           {}
           return _lsreturn;
       }


       public List<Return> GetallReturnForGrid()
       {
           List<Return> _lsreturn = new List<Return>();
           try
           {
               var v = from ls in Service.GetRMA.ReturnAll()
                       select ls; 


               foreach (var Ritem in v)
               {
                   _lsreturn.Add(new Return(Ritem));
               }
           }
           catch (Exception)
           { }
           return _lsreturn;
       }

       #region GetCustInformationByRMANumber/SRNumber
       public List<RMAInfo> GetCustInformationByRMANumber(String RMANumber)
       {
           List<RMAInfo> lsCustinfo = new List<RMAInfo>();
           try
           {
               var CustomerInfo = Service.GetRMA.RMAInfoBySRNumber(RMANumber).ToList();
               // var CustomerInfo = Service.GetRMA.GetCustomerByPOnumber(RMANumber).ToList();
               if (CustomerInfo.Count() > 0)
               {
                   foreach (var Customer in CustomerInfo)
                   {
                       lsCustinfo.Add(new RMAInfo(Customer));
                   }
               }
           }
           catch (Exception)
           {
           }
           return lsCustinfo;
       }
       #endregion

       /// <summary>
       /// this method is for Return By ReturnID
       /// </summary>
       /// <param name="ReturnID">
       /// ReturnID pass As Parameter.
       /// </param>
       /// <returns>
       /// Return List of Return Information.
       /// </returns>
       public Return ReturnByReturnID(Guid ReturnID)
       {
           return new Return(Service.GetRMA.ReturnByReturnID(ReturnID));
       }

       /// <summary>
       /// this method is for Return By RMANumber.
       /// </summary>
       /// <param name="RMANumber">
       /// RMANumber pass as parameter. 
       /// </param>
       /// <returns>
       /// Return List of Return Information.
       /// </returns>
       public Return ReturnByRMANumber(string RMANumber)
       {
           return new Return(Service.GetRMA.ReturnByRMANumber(RMANumber));
       }
       /// <summary>
       /// this method is for return by OrderNumber.
       /// </summary>
       /// <param name="OrderNum">
       /// OrderNumber pass as parameter.
       /// </param>
       /// <returns>
       /// Return List of Return Information.
       /// </returns>
       public List<Return> ReturnByOrderNum(string OrderNum)
       {
           List<Return> _lsreturn = new List<Return>();
           try
           {
               var v = from ls in Service.GetRMA.ReturnByOrderNum(OrderNum)
                       select ls;

               foreach (var Ritem in v)
               {
                   _lsreturn.Add(new Return(Ritem));
               }
           }
           catch (Exception)
           { }
           return _lsreturn;
       }
       /// <summary>
       /// this method is for Return information by VenderNumber.
       /// </summary>
       /// <param name="VendorNumber">
       /// VendorNumber pass as parameter.
       /// </param>
       /// <returns>
       /// Return List of Return Information.
       /// </returns>
       public List<Return> ReturnByVendoeNum(string VendorNumber)
       {
           List<Return> _lsreturn = new List<Return>();
           try
           {
               var v = from ls in Service.GetRMA.ReturnByVendoeNum(VendorNumber)
                       select ls;

               foreach (var Ritem in v)
               {
                   _lsreturn.Add(new Return(Ritem));
               }
           }
           catch (Exception)
           { }
           return _lsreturn;
       }

       /// <summary>
       /// this method is for Return information by VenderName.
       /// </summary>
       /// <param name="VendorName">
       /// VendorNumber pass as parameter.
       /// </param>
       /// <returns>
       /// Return List of Return Information.
       /// </returns>
       public List<Return> ReturnByVendorName(string VendorName)
       {
           List<Return> _lsreturn = new List<Return>();
           try
           {
               var v = from ls in Service.GetRMA.ReturnByVendorName(VendorName)
                       select ls;

               foreach (var Ritem in v)
               {
                   _lsreturn.Add(new Return(Ritem));
               }
           }
           catch (Exception)
           { }
           return _lsreturn;
       }

       /// <summary>
       /// This Method is for Return information by ShipmentNumber. 
       /// </summary>
       /// <param name="ShipmentNumber">
       /// ShipmentNumber pass as parameter.
       /// </param>
       /// <returns>
       /// Return List of Return Information.
       /// </returns>
       public List<Return> ReturnByShipmentNumber(string ShipmentNumber)
       {
           List<Return> _lsreturn = new List<Return>();
           try
           {
               var v = from ls in Service.GetRMA.ReturnByShipmentNumber(ShipmentNumber)
                       select ls;

               foreach (var Ritem in v)
               {
                   _lsreturn.Add(new Return(Ritem));
               }
           }
           catch (Exception)
           { }
           return _lsreturn;
       }
       /// <summary>
       /// This Method is for Return information by POnumber. 
       /// </summary>
       /// <param name="PONumber">
       /// pass PONumber as parameter.
       /// </param>
       /// <returns>
       /// Return List of Return Information.
       /// </returns>
       public List<Return> ReturnByPONumber(string PONumber)
       {
           List<Return> _lsreturn = new List<Return>();
           try
           {
               var v = from ls in Service.GetRMA.ReturnByPONumber(PONumber)
                       select ls;

               foreach (var Ritem in v)
               {
                   _lsreturn.Add(new Return(Ritem));
               }
           }
           catch (Exception)
           { }
           return _lsreturn;
       }
       /// <summary>
       /// this Method is for Return information By RGAROWID.
       /// </summary>
       /// <param name="RGAROWID">
       /// pass RGAROWID as parameter.
       /// </param>
       /// <returns>
       /// Return List of Return Information.
       /// </returns>
       public List<Return> ReturnByRGAROWID(string RGAROWID)
       {
           List<Return> _lsreturn = new List<Return>();
           try
           {
               var v = from ls in Service.GetRMA.ReturnByRGAROWID(RGAROWID)
                       select ls;

               foreach (var Ritem in v)
               {
                   _lsreturn.Add(new Return(Ritem));
               }
           }
           catch (Exception)
           { }
           return _lsreturn;
       }
       /// <summary>
       /// this Method is for Return information By RGADROWID.
       /// </summary>
       /// <param name="RGADROWID">
       /// Pass RGADROWID as parameter.
       /// </param>
       /// <returns>
       /// Return List of Return Information.
       /// </returns>
       public List<Return> ReturnByRGADROWID(string RGADROWID)
       {
           List<Return> _lsreturn = new List<Return>();
           try
           {
               var v = from ls in Service.GetRMA.ReturnByRGADROWID(RGADROWID)
                       select ls;

               foreach (var Ritem in v)
               {
                   _lsreturn.Add(new Return(Ritem));
               }
           }
           catch (Exception)
           { }
           return _lsreturn;
       }

       /// <summary>
       /// this method is for Return By ReturnID
       /// </summary>
       /// <param name="ReturnID">
       /// ReturnID pass As Parameter.
       /// </param>
       /// <returns>
       /// Return List of Return Information.
       /// </returns>
       public Return GetReturnTblByReturnID(Guid ReturnID)
       {
           Return _returnObj = new Return();
           try
           {
               _returnObj = new Return(Service.GetRMA.ReturnByReturnID(ReturnID));
           }
           catch (Exception )
           {
           }
           return _returnObj;
       }

       public List<String> GetPONumber(String Chars)
       {
           List<String> lsponumber = new List<String>();
           try
           {
               var ponumbers = Service.GetRMA.GetPOnumber(Chars);
               if (ponumbers.Count() > 0)
               {
                   foreach (var ponum in ponumbers)
                   {
                       lsponumber.Add(ponum);
                   }
               }
           }
           catch (Exception)
           {
           }
           return lsponumber;
       }

       public List<RMAInfo> GetCustInformationByPoNumber(String PONumber)
       {
           List<RMAInfo> lsCustinfo = new List<RMAInfo>();
           try
           {
               var CustomerInfo = Service.GetRMA.NewRMAInfoByOnlyPONumber(PONumber).ToList();
               if (CustomerInfo.Count() > 0)
               {
                   foreach (var Customer in CustomerInfo)
                   {
                       lsCustinfo.Add(new RMAInfo(Customer));
                   }
               }
           }
           catch (Exception)
           {
           }
           return lsCustinfo;
       

       }


       public List<RMAInfo> GetCustInformationBySRNumber(String SRNumber)
       {
           List<RMAInfo> lsCustinfo = new List<RMAInfo>();
           try
           {
               var CustomerInfo = Service.GetRMA.RMAInfoBySRNumber(SRNumber).ToList();
               if (CustomerInfo.Count() > 0)
               {
                   foreach (var Customer in CustomerInfo)
                   {
                       lsCustinfo.Add(new RMAInfo(Customer));
                   }
               }
           }
           catch (Exception)
           {
           }
           return lsCustinfo;


       }

       public List<string> GetVenderName(String Chars)
       {
           List<string> lsVender = new List<string>();
           try
           {
             var  lsVendername = Service.GetRMA.GetVenderName(Chars);
               if(lsVendername.Count()>0)
               {
                   foreach (var item in lsVendername)
                   {
                       lsVender.Add(item);
                   }
               }
           }
           catch (Exception)
           {
           }
           return lsVender;
       }
       public List<string> GetVenderNumber(String Chars)
       {
           List<string> lsVendernum = new List<string>();
           try
           {
               var lsVendernumber = Service.GetRMA.GetGetVenderNumber(Chars);
               if (lsVendernumber.Count() > 0)
               {
                   foreach (var item in lsVendernumber)
                   {
                       lsVendernum.Add(item);
                   }
               }
           }
           catch (Exception)
           {
           }
           return lsVendernum;
       }

       public string GetVenderNamebyVenderNumber(String Vendernumber)
       {
           string vendername = "";
           try
           {
               vendername = Service.GetRMA.GetVenderNameByVenderNumber(Vendernumber);
           }
           catch (Exception)
           {
           }
           return vendername;
       }

       public string GetVenderNumberByVenderName(String VenderName)
       {
           string VenderNumber = "";
           try
           {
               VenderNumber = Service.GetRMA.GetVenderNumberByVenderName(VenderName);
           }
           catch (Exception)
           {
           }
           return VenderNumber;
       }

       #endregion

       #region Set Method

       /// <summary>
       /// Update return Table information.
       /// </summary>
       /// <param name="_lsreturn">
       /// pass return object as parameter.
       /// </param>
       /// <returns>
       /// return Boolean
       /// </returns>
       public Boolean UpdateReturn(Return _lsreturn)
       {
           Boolean _flag = false;
           try
           {
               _flag = Service.SetRMA.Return(_lsreturn.CopyToSaveDTO(_lsreturn));
           }
           catch (Exception)
           {
           }
           return _flag;
       
       }

       /// <summary>
       /// This Method is for GetNewRMANumber.
       /// </summary>
       /// <param name="Chars">
       /// pass string as parameter chars.
       /// </param>
       /// <returns>
       /// Return list of String.
       /// </returns>
       public List<String> GetNewRMANumber(String Chars)
       {
           List<String> lsRMAInfo = new List<String>();
           try
           {
               var NewRMAdetailsInfo = Service.GetRMA.ProductMachingNameCat(Chars);
               if (NewRMAdetailsInfo.Count() > 0)
               {
                   foreach (var RMAitem in NewRMAdetailsInfo)
                   {
                       lsRMAInfo.Add(RMAitem);
                   }
               }
           }
           catch (Exception)
           {
              
           }
           return lsRMAInfo;
       }

       #endregion


       public Boolean UpdateReturnByPOnumber(Return _lsreturn)
       {
           Boolean _flag = false;
           try
           {
               _flag = Service.SetRMA.ReturnByPOnmber(_lsreturn.CopyToSaveDTO(_lsreturn));
           }
           catch (Exception)
           {
           }
           return _flag;

       }

       public Boolean UpsertReturnTblByRGANumber(Return ObjReturnTbl)
       {
           Boolean _returnFlag = false;
           try
           {
               _returnFlag = Service.SetRMA.ReturnByRGANumber(ObjReturnTbl.CopyToSaveDTO(ObjReturnTbl));
           }
           catch (Exception)
           {
              // ex.LogThis("cmdReturn/UpsertReturnTblByPOnumber");
           }
           return _returnFlag;
       }
       public List<ReturnDetails> GetTrackingNumbersInReturnDetails()
       {
           List<ReturnDetails> _lsreturn = new List<ReturnDetails>();
           try
           {
               var v = from ls in Service.GetRMA.GetTrackingNumbersInReturnDetails()
                       select ls;

               foreach (var item in v)
               {
                   ReturnDetails orr = new ReturnDetails();
                   orr.ReturnID = item.ReturnID;
                   orr.TrackingNumber = item.TrackingNumber;
                   _lsreturn.Add(orr);
               }
               //_lsreturn = v.ToList();
           }
           catch (Exception)
           { }
           return _lsreturn;
       }

       #region AllReturnWithString

       public List<ReturnWithString> GetallReturnWithString()
       {
           List<ReturnWithString> _lsreturn = new List<ReturnWithString>();
           try
           {
               var v = from ls in Service.GetRMA.ReturnAllString()
                       select ls;

               foreach (var Ritem in v)
               {
                   _lsreturn.Add(new ReturnWithString(Ritem));
               }
           }
           catch (Exception)
           { }
           return _lsreturn;
       }

       #endregion


   }
}
