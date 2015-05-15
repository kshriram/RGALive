using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PackingClassLibrary.CustomEntity.SMEntitys.RGA;

namespace PackingClassLibrary.Commands.SMcommands.RGA
{
   public class cmdReturnImages
    {

       public List<string> ReturnImagesByReturnDetailsID(Guid ReturnDetailsID)
        {

            return Service.GetRMA.ImagePathStringList(ReturnDetailsID).ToList();
        }

       public Boolean deleteImageFromDatabase(Guid ReturnDetailsID, string ImgSkuPath)
       {
          
           return Service.GetRMA.Authenticate(ReturnDetailsID, ImgSkuPath);
       }
       public Boolean UpsertReturnImage(ReturnImage ReturnImageObj)
       {
           Boolean _returnFlag = false;
           try
           {
               _returnFlag = Service.SetRMA.ReturnImages(ReturnImageObj.CopyToSaveDTO(ReturnImageObj));
           }
           catch (Exception)
           {
               
           }
           return _returnFlag;
       }
    }
}
