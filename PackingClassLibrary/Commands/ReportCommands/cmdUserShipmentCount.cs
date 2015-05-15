using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackingClassLibrary;
using PackingClassLibrary.CustomEntity.ReportEntitys;
using PackingClassLibrary.CustomEntity.SMEntitys;
using PackingClassLibrary.Commands.SMcommands;
using System.Data.Objects;

namespace PackingClassLibrary.Commands.ReportCommands
{
   public  class cmdUserShipmentCount
    {
       /// <summary>
       /// for each user its total packed shipments and its dates
       /// </summary>
       /// <returns>List of cstUserShipmentCount</returns>
       public List<cstUserShipmentCount> GetAllShipmentCountByUser()
       {
           List<cstUserShipmentCount> _lsUserShipmentCount = new List<cstUserShipmentCount>();
           try
           {
               var Shipments =Service.Get.GetAllShipmentCountByUser();
               foreach (var item in Shipments)
               {
                   cstUserShipmentCount Uship = new cstUserShipmentCount();
                   Uship.UserID = item.UserID;
                   Uship.UserName = item.UserName;
                   Uship.ShipmentCount =Convert.ToInt32( item.ShipmentCount);
                   Uship.Datepacked = Convert.ToDateTime(item.Datepacked);
                   _lsUserShipmentCount.Add(Uship);
               }

           }
           catch (Exception)
           {}
           return _lsUserShipmentCount;
       }
    }
}
