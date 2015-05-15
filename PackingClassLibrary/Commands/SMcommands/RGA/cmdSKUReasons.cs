using PackingClassLibrary.CustomEntity.SMEntitys.RGA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackingClassLibrary.Commands.SMcommands.RGA
{

   public class cmdSKUReasons
    {

       public List<SKUReason> _lsReasons { get; protected set; }

     //   _lsReasons = new List<SKUReason>();

       public Boolean DeleteByReturnDetailsID(Guid ReturnDetailsID)
       {
           return Service.DeleteRMA.SKUReasonsByReturnDetailsID(ReturnDetailsID);
       }
       public List<SKUReason> GetReasons(List<ReturnDetail> LsRetnDetails)
       {
           _lsReasons = new List<SKUReason>();
           try
           {
               foreach (var lsitem in LsRetnDetails)
               {

                   foreach (var item in GetSKuReasonsByReturnDetailsID(lsitem.ReturnDetailID))
                   {
                       _lsReasons.Add(item);
                   }
               }

           }
           catch (Exception)
           { }
           return _lsReasons;
       }

       public List<SKUReason> GetSKuReasonsByReturnDetailsID(Guid ReturnDetailID)
       {
           List<SKUReason> _lsReturn = new List<SKUReason>();
           try
           {
               var LsReasosn = Service.GetRMA.GetSKUImagesByReturnDetailID(ReturnDetailID);
               foreach (var lsitem in LsReasosn)
               {
                   _lsReturn.Add(new SKUReason(lsitem));
               }
           }
           catch (Exception)
           { }
           return _lsReturn;

       }

    }
}
