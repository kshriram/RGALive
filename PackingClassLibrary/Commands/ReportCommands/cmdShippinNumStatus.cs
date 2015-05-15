using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackingClassLibrary.Commands;
using PackingClassLibrary.CustomEntity;
using PackingClassLibrary.CustomEntity.ReportEntitys;
using PackingClassLibrary.Commands.SMcommands;
using PackingClassLibrary.CustomEntity.SMEntitys;


namespace PackingClassLibrary.Commands.ReportCommands
{
    public class cmdShippinNumStatus
    {
        /// <summary>
        /// Shipment number serch for information of packing status
        /// </summary>
        /// <param name="ShippingNumber">String Shipping Number</param>
        /// <returns>List<cstShipmentNumStatus> depending on location retuersn shipping number information</returns>
        public List<cstShipmentNumStatus> GetStaus(String ShippingNumber)
        {
            List<cstShipmentNumStatus> _lsStatus = new List<cstShipmentNumStatus>();

            try
            {
                var serviceReturn = Service.Get.GetStaus(ShippingNumber);
                foreach (var item in serviceReturn)
                {
                    cstShipmentNumStatus _item = new cstShipmentNumStatus();
                    _item.Location = item.Location;
                    _item.PackageID = item.PackageID;
                    _item.ShippingCompletedInt = item.ShippingCompletedInt;
                    _item.ShippingNum = item.ShippingNum;
                    _item.ShippinStatus = item.ShippinStatus;
                    _lsStatus.Add(_item);
                }

            }
            catch (Exception)
            { }
            return _lsStatus;
        }
    }
}
