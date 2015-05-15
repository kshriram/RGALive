using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingClassLibrary.Commands.SMcommands
{
   public class cmdSkuImages
    {
      // local_x3v6Entities x3v6Entity = new local_x3v6Entities();
       /// <summary>
       /// filters name from table and returns the url for sku image
       /// </summary>
       /// <param name="SkuName">
       /// String SKU name
       /// </param>
       /// <returns>
       /// String URL for Image
       /// </returns>
       public string getUrlByName(String SkuName)
       {
           string _Path = "";
           try
           {
               var tempPath = Service.Get.GetBySKUname(SkuName).SingleOrDefault(); //x3v6Entity.SKUImages.SingleOrDefault(i => i.SKU == SkuName);
               _Path = tempPath.ToString();
           }
           catch (Exception Ex)
           {Error_Loger.elAction.save("GetSkuUrlPath.Execute()", Ex.Message.ToString());}
           return _Path;
       }


       /// <summary>
       /// check that product show barcode or not
       /// </summary>
       /// <param name="SKUName">
       /// String SKU name to be check
       /// </param>
       /// <returns>
       /// Boolean value to show barcode or not
       /// </returns>
       public Boolean getBarcodeShowFlag(string SKUName)
       {
           Boolean _return = true;
           try
           {
               _return = Service.Get.GetByBarcode(SKUName);//x3v6Entity.SKUImages.FirstOrDefault(i => i.SKU == SKUName).BarcodeFlag;
           }
           catch (Exception)
           { }
           return _return;
       }

      
    }
}
