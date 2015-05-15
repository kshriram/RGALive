using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackingClassLibrary.CustomEntity.ReportEntitys;
using PackingClassLibrary.CustomEntity;
using System.Data.Objects;
using System.Data.Objects.SqlClient;
namespace PackingClassLibrary.Commands.ReportCommands
{
   public class GetTotalShipmentPackedToday
    {


       /// <summary>
       /// Current date packing details
       /// </summary>
       /// <returns></returns>
       public List<cstShipmentPackedTodayAndAvgTime> GetTotalShipmentPackedTime()
       {
           List<cstShipmentPackedTodayAndAvgTime> lsShipmentPacked = new List<cstShipmentPackedTodayAndAvgTime>();
           try
           {
               var vs = Service.Get.GetTotalShipmentPackedTime();
               foreach (var item in vs)
               {
                   cstShipmentPackedTodayAndAvgTime _item = new cstShipmentPackedTodayAndAvgTime();
                   _item.Packed = item.Packed;
                   _item.UserID= item.UserID;
                   lsShipmentPacked.Add(_item);
               }

           }
           catch (Exception)
           { }
           return lsShipmentPacked;
       }
    }
}
