using PackingClassLibrary.CustomEntity;
using PackingClassLibrary.CustomEntity.SMEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingClassLibrary.Commands.SMcommands
{
    public class cmdPackageBoxTracking
    {
        public List<cstPackageBoxTracking> GetPackageBoxTracking(String ShipmentNumber)
        {
            List<cstPackageBoxTracking> _PackageWithBoxReturn = new List<cstPackageBoxTracking>();
            try
            {
                var shippp = Service.Get.GetAllPackageBoxTrackings(ShipmentNumber);
                //var shippp = Service.Get.PackageWithBox();
                foreach (var _shippingInfo in shippp.ToList())
                {
                    cstPackageBoxTracking Ship = new cstPackageBoxTracking();
                    Ship.BOXNUM = _shippingInfo.BOXNUM;
                    Ship.SKUNumber = _shippingInfo.SKUNumber;
                    Ship.SKUQuantity = _shippingInfo.SKUQuantity;
                    Ship.Date = _shippingInfo.Date;
                    Ship.TrackingNumber = _shippingInfo.TrackingNumber;
                    Ship.Status = _shippingInfo.Status;
                    Ship.BoxLocation = _shippingInfo.BoxLocation;
                    Ship.Carrier = _shippingInfo.Carrier;
                    Ship.Heights = _shippingInfo.Heights;
                    Ship.Lengths = _shippingInfo.Lengths;
                    Ship.Widths = _shippingInfo.Widths;
                    Ship.Weights = _shippingInfo.Weights;
                    Ship.FreightCharges = _shippingInfo.FreightCharges;
                    _PackageWithBoxReturn.Add(Ship);
                }
            }
            catch (Exception)
            { }
            return _PackageWithBoxReturn;
        }
    }
}
