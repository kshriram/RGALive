using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackingClassLibrary.CustomEntity;
using PackingClassLibrary.CustomEntity.ReportEntitys;

namespace PackingClassLibrary.Commands.ReportCommands
{
  
   public class cmdBPNameShippingNum
    {
       /// <summary>
       /// Add Delivery provide name to the from sage and add it to the list of information of shipment.
       /// </summary>
       /// <returns>List<cstShippingInfoBPName> information</returns>
       public List<cstShippingInfoBPName> GetBpinfoOFShippingNum()
       {
           //list with Delivery provider name. to be returened.
           List<cstShippingInfoBPName> _lsretuen = new List<cstShippingInfoBPName>();
           try
           {
               var ship = Service.Get.GetBpinfoOFShippingNum(); //Service.Get.ShippingAllShipping();
               foreach (var item in ship)
               {
                   cstShippingInfoBPName Bpnamecall = new cstShippingInfoBPName();
                   Bpnamecall.BPName = item.BPName;
                   Bpnamecall.ShippingID = item.ShippingID;
                   Bpnamecall.ShippingNumner = item.ShippingNumner;
                   Bpnamecall.BusinessPartNo = item.BusinessPartNo;
                   Bpnamecall.ShippingStatus = item.ShippingStatus;
                   _lsretuen.Add(Bpnamecall);
               }
           }
           catch (Exception)
           {}
           return _lsretuen;
       }


       /// <summary>
       /// get the Name from number
       /// </summary>
       /// <param name="BPNUM_0">string Delivery provider number</param>
       /// <returns>Srtring Delivery Provider name</returns>
       public string getBPNameFromBPNUM(string BPNUM_0)
       {
           return Service.Get.getBPNameFromBPNUM(BPNUM_0);
       }
    }
}
