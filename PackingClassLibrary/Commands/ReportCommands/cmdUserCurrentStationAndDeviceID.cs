using PackingClassLibrary.CustomEntity;
using PackingClassLibrary.CustomEntity.ReportEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingClassLibrary.Commands.ReportCommands
{
   public class cmdUserCurrentStationAndDeviceID
    {

        /// <summary>
        /// All Users last Login Station
        /// </summary>
        /// <returns></returns>
        public List<cstUserCurrentStationAndDeviceID> LastLoginStationAllUsers()
        {
            List<cstUserCurrentStationAndDeviceID> lsUstation = new List<cstUserCurrentStationAndDeviceID>();
            try
            {
                var StaionName = Service.Get.LastLoginStationAllUsers();

                foreach (var Useritem in StaionName)
                {
                    cstUserCurrentStationAndDeviceID UserStation = new cstUserCurrentStationAndDeviceID();
                    UserStation.UserID = Useritem.UserID;
                    UserStation.UserName = Useritem.UserName;
                    UserStation.StationName = Useritem.StationName;
                    UserStation.Datetime = Useritem.Datetime;
                    UserStation.DeviceID = Useritem.DeviceID;
                    lsUstation.Add(UserStation);
                }
            }
            catch (Exception)
            { }
            return lsUstation;
        }
    }
}
