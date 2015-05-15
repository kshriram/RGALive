using PackingClassLibrary.Commands.SMcommands.RGA;
using PackingClassLibrary.CustomEntity;
using PackingClassLibrary.CustomEntity.SMEntitys;
using PackingClassLibrary.CustomEntity.SMEntitys.RGA;
using ShippingController_V1._0_.Models;
using ShippingController_V1._0_.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShippingController_V1._0_.Forms.Web_Forms
{
    public partial class AutoCompleteService : System.Web.UI.Page
    {

       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Web Service for autocomplete in shipping number textBox.
        /// </summary>
        /// <param name="prefixText"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod()]
        public static List<string> SearchpackingID(string prefixText, int count)
        {
            List<string> lsreturn = new List<string>();
            if (prefixText == "")
            {
                prefixText = "SH";
            }
            List<cstPackageTbl> lspcking = Obj.call.GetPackingTbl();
            foreach (var packing in lspcking)
            {

                if (packing.ShippingNum.Contains(prefixText))
                {
                    lsreturn.Add(packing.ShippingNum.ToString().ToUpper());
                }
            }
            return lsreturn;
        }


        /// <summary>
        /// Web Service for Error log serach
        /// </summary>
        /// <param name="prefixText"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchLog(string prefixText, int count)
        {
            List<string> lsreturn = new List<string>();
            int i = 0;
            if (prefixText == "")
            {
                prefixText = "SH";
            }
            List<cstErrorLog> lsErrorLog = Obj.call.GetErrorLog();
            foreach (var packing in lsErrorLog)
            {
                if (i < 10)
                {
                    string ctext = packing.ErrorLogID + " | " +  packing.ErrorDesc + " | " + packing.ErrorTime;

                    if (ctext.Contains(prefixText))
                    {
                        lsreturn.Add(ctext);
                    }
                    i++;
                }
                else
                {
                    break;
                }
            }
            return lsreturn;
        }

        /// <summary>
        /// Web method for serach Box number 
        /// </summary>
        /// <param name="prefixText"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> serachBoxNumber(string prefixText, int count)
        {
            List<string> _lsRetutn = new List<string>();
            int i = 0;
            List<cstBoxPackage> lsBoxPackage = Obj.call.GetBoxPackageAll();
            foreach (cstBoxPackage _box in lsBoxPackage)
            {
                if (i<30)
                {
                    if (_box.BOXNUM.Contains(prefixText))
                    {
                        _lsRetutn.Add(_box.BOXNUM);
                    }
                    i++;
                }
                else
                {
                    break;
                }
            }
            return _lsRetutn;
        }

        /// <summary>
        /// Web script method to Auto-Search tracking Number in Tacking Number textbox .
        /// </summary>
        /// <param name="prefixText">
        /// string Prefix  autosend by Ajax autocomplete extender
        /// </param>
        /// <param name="count">
        /// int Count is Auto send to this function by ajax autocomplete extender.
        /// </param>
        /// <returns>
        /// list of string that contains maching tracking Numbers.
        /// </returns>
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<String> SearchTrackingNumber(String prefixText, int count)
        {
            List<String> _lsRetutn = new List<string>();
            int i = 0;
            List<cstTrackingTbl> lsTrackingTbl = Obj.call.GetTrackingTbl();
            foreach (cstTrackingTbl TrackItm in lsTrackingTbl)
            {
                if (i < 25)
                {
                    if (TrackItm.TrackingNum.Contains(prefixText))
                    {
                        _lsRetutn.Add(TrackItm.TrackingNum);
                    }
                    i++;
                }
                else
                {
                    break;
                }
            }

            return _lsRetutn;
        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<String> SearchRMANumber(String prefixText, int count)
        {
            List<String> _lsRetutn = new List<string>();
            int i = 0;
           var lsTrackingTbl = Obj.Rcall.ReturnAll();
           foreach (var TrackItm in lsTrackingTbl)
           {
               if (TrackItm.RMANumber != null)
               {
                   if (TrackItm.RMANumber.Contains(prefixText))
                   {
                       _lsRetutn.Add(TrackItm.RMANumber);
                       i++;
                   }
                   if (i > 10)
                       break;
                  
               }
           }

            return _lsRetutn;
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<String> SearchShipmentID(String prefixText, int count)
        {
            List<String> _lsRetutn = new List<string>();
            int i = 0;
            List<Return> lsTrackingTbl = Obj.Rcall.ReturnAll();
            foreach (Return TrackItm in lsTrackingTbl)
            {
                if (i < 25)
                {
                    if (TrackItm.ShipmentNumber == null)
                    {
                    }
                    else
                    {
                        if (TrackItm.ShipmentNumber.Contains(prefixText))
                        {
                            _lsRetutn.Add(TrackItm.ShipmentNumber);
                        }
                        i++;
                    }
                }
                else
                {
                    break;
                }
            }

            return _lsRetutn;
        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<String> SearchOrderID(String prefixText, int count)
        {
            List<String> _lsRetutn = new List<string>();
            int i = 0;
            List<Return> lsTrackingTbl = Obj.Rcall.ReturnAll();
            foreach (Return TrackItm in lsTrackingTbl)
            {
                if (i < 25)
                {
                    if (TrackItm.OrderNumber.Contains(prefixText))
                    {
                        _lsRetutn.Add(TrackItm.OrderNumber);
                    }
                    i++;
                }
                else
                {
                    break;
                }
            }

            return _lsRetutn;
        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<String> SearchOPnumber(String prefixText, int count)
        {
            List<String> _lsRetutn = new List<string>();
            int i = 0;
            List<Return> lsTrackingTbl = Obj.Rcall.ReturnAll();
            foreach (Return TrackItm in lsTrackingTbl)
            {
                if (i < 25)
                {
                    if (TrackItm.PONumber.Contains(prefixText))
                    {
                        _lsRetutn.Add(TrackItm.PONumber);
                    }
                    i++;
                }
                else
                {
                    break;
                }
            }

            return _lsRetutn;
        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<String> SearchSKUNumber(String prefixText, int count)
        {
            List<String> _lsRetutn = new List<string>();
          
           int i = 0;

           List<string> lsTrackingTbl = Obj.call._skulist(prefixText.ToUpper());
           foreach (var TrackItm in lsTrackingTbl)
           {


               string str = TrackItm.ToString().Split(new char[] { '#' })[0];
               if (i == 10)
                   break;
               else
                 _lsRetutn.Add(str);
               i++;
           }

            return _lsRetutn;
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<String> SerachReason(string prefixText, int count)
        {

            cmdReasons _cresons = new cmdReasons();
            List<String> _lsRetutn = new List<string>();
            int i = 0;
           var lsTrackingTbl = _cresons.ReasonsAll();
            foreach (var TrackItm in lsTrackingTbl)
            {
                if (i < 25)
                {
                    if (TrackItm.Reason1.Contains(prefixText))
                    {
                        _lsRetutn.Add(TrackItm.Reason1);
                    }
                    i++;
                }
                else
                {
                    break;
                }
            }
            return _lsRetutn;
        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<String> SearchPONumber(String prefixText, int count)
        {
            List<String> _lsRetutn = new List<string>();

            int i = 0;

            List<string> lsTrackingTbl = Obj.Rcall.GetCustByPOnumber(prefixText);
            foreach (var TrackItm in lsTrackingTbl)
            {

                if (i == 10)
                    break;
                else
                    _lsRetutn.Add(TrackItm);
                i++;
            }

            return _lsRetutn;
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<String> SearchPONumber1(String prefixText, int count)
        {
            List<String> _lsRetutn = new List<string>();

            int i = 0;

            List<string> lsTrackingTbl = Obj.Rcall.VenderName(prefixText);
            foreach (var TrackItm in lsTrackingTbl)
            {

                if (i == 10)
                    break;
                else
                    _lsRetutn.Add(TrackItm);
                i++;
            }

            return _lsRetutn;
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<String> SearchVen(String prefixText, int count)
        {
            List<string> _lsvendername = new List<string>();
            int i = 0;
            List<string> lsvender = Obj.Rcall.VenderName(prefixText.ToUpper());
            foreach (var item in lsvender)
            {
                if (i == 10)
                    break;
                else
                    _lsvendername.Add(item);
                i++;

            }
            return _lsvendername;
        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<String> SearchVenderNumber(String prefixText, int count)
        {
            List<string> _lsvendernumber = new List<string>();
            int i = 0;
            List<string> lsvender = Obj.Rcall.VenderNumber(prefixText.ToUpper());
            foreach (var item in lsvender)
            {
                if (i == 10)
                    break;
                else
                    _lsvendernumber.Add(item);
                i++;

            }
            return _lsvendernumber;
        }

    }
}