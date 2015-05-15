using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingClassLibrary.Commands
{
    /// <summary>
    /// Author: Avinash
    /// Version: Alfa.
    /// UPC code Converter From and To sku Name
    /// </summary>
   public static class cmdUPCConverter
    {
       /// <summary>
       /// Convert UPC Code to the SKu name.
       /// </summary>
       /// <param name="UPCCode">11 or 12 Digit UPC Code.</param>
       /// <returns>String of Sku Name in error blank string.</returns>
       public static String UPCCodeToSKU(String UPCCode)
       {
           String _return = "";
           try
           {
               _return = Service.Get.UPCtoSKUName(UPCCode);
                   //0Sage.ITMMASTERs.SingleOrDefault(i => i.EANCOD_0 == UPCCode).ITMDES1_0.ToString();
               
           }
           catch (Exception Ex)
           {
               Error_Loger.elAction.save("UPCCodeTOSKUName.UPCCodeToSKU()", Ex.Message.ToString());
           }
           return _return;
       }

       /// <summary>
       /// SKU Name to its UPC Code.
       /// </summary>
       /// <param name="SKUName">String SKU Name.</param>
       /// <returns>String UPC 13 Digit code in error "000000000000" code</returns>
       public static String SKUNameToSku(String SKUName)
       {

           return Service.Get.SKUNameToUPCCode(SKUName);
       }
    }
}
