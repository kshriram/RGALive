using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PackingClassLibrary;
using PackingClassLibrary.CustomEntity.SMEntitys.RGA;

namespace ShippingController_V1._0_.Models
{
    public class Obj
    {
        public static List<RMAInfo> _lsReturnDetailsWithPO = new List<RMAInfo>();

        public static smController call = new smController();
        public static ReportController Rcall = new ReportController();

        public static List<RMAInfo> _lsReturnDetailsWithSR = new List<RMAInfo>();
      public static List<Return> _lsreturn = new List<Return>();
      public static List<ReturnDetail> _lsReturnDetails = new List<ReturnDetail>();

      public static Views.PopupValue _popupValue = new Views.PopupValue();

      public static List<Views.ReasonList> _ReasonList = new List<Views.ReasonList>();
      public static int RowID = 0;

      public static Views.ReasonSelectionsPopup ReasonsIDs = new Views.ReasonSelectionsPopup();

    }
}