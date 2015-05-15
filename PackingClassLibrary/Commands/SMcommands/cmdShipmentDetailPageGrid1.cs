using PackingClassLibrary.CustomEntity;
using PackingClassLibrary.CustomEntity.SMEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingClassLibrary.Commands.SMcommands
{
    public class cmdShipmentDetailPageGrid1
    {
        public List<cstShipmentDetailPageGrid1> GetShipmentDetailPageGrid1(String Date)
        {
            List<cstShipmentDetailPageGrid1> _ShipmentDetailPageGrid1 = new List<cstShipmentDetailPageGrid1>();
            try
            {
                var shippp = Service.Get.GetAllShipmentDetailPageGrid1s(Date);
                //var shippp = Service.Get.PackageWithBox();
                foreach (var _shippingInfo in shippp.ToList())
                {
                    cstShipmentDetailPageGrid1 Ship = new cstShipmentDetailPageGrid1();
                    Ship.ShipmentID = _shippingInfo.ShipmentID;
                    Ship.ShippingCreatedTime = _shippingInfo.ShippingCreatedTime;
                    Ship.ShippingDate = (_shippingInfo.ShippingDate);
                    Ship.ShippingTime = _shippingInfo.ShippingTime;
                    Ship.OrderID = _shippingInfo.OrderID;
                    Ship.PONumber = _shippingInfo.PONumber;
                    Ship.PartnerID = _shippingInfo.PartnerID;
                    Ship.DeliveryMode = _shippingInfo.DeliveryMode;
                    Ship.Carrier = _shippingInfo.Carrier;
                    Ship.ExpectedShipDate = (_shippingInfo.ExpectedShipDate);
                    Ship.shqty = _shippingInfo.shqty;
                    Ship.pkqty = _shippingInfo.pkqty;
                    Ship.TrkCount = _shippingInfo.TrkCount;
                    Ship.BoxCount = _shippingInfo.BoxCount;
                    Ship.ShipmentStatus = _shippingInfo.ShipmentStatus;

                    _ShipmentDetailPageGrid1.Add(Ship);
                }
            }
            catch (Exception)
            { }
            return _ShipmentDetailPageGrid1;
        }


        public List<cstShipmentDetailPageGrid1> GetShipmentDetailPageGrid1Total(String Date)
        {
            List<cstShipmentDetailPageGrid1> _ShipmentDetailPageGrid1 = new List<cstShipmentDetailPageGrid1>();
            try
            {
                var shippp = Service.Get.GetAllShipmentDetailPageGrid1Totals(Date);
                //var shippp = Service.Get.PackageWithBox();
                foreach (var _shippingInfo in shippp.ToList())
                {
                    cstShipmentDetailPageGrid1 Ship = new cstShipmentDetailPageGrid1();
                    Ship.ShipmentID = _shippingInfo.ShipmentID;
                    Ship.ShippingCreatedTime = _shippingInfo.ShippingCreatedTime;
                    Ship.ShippingDate = (_shippingInfo.ShippingDate);
                    Ship.ShippingTime = _shippingInfo.ShippingTime;
                    Ship.OrderID = _shippingInfo.OrderID;
                    Ship.PONumber = _shippingInfo.PONumber;
                    Ship.PartnerID = _shippingInfo.PartnerID;
                    Ship.DeliveryMode = _shippingInfo.DeliveryMode;
                    Ship.Carrier = _shippingInfo.Carrier;
                    Ship.ExpectedShipDate = (_shippingInfo.ExpectedShipDate);
                    Ship.shqty = _shippingInfo.shqty;
                    Ship.pkqty = _shippingInfo.pkqty;
                    Ship.TrkCount = _shippingInfo.TrkCount;
                    Ship.BoxCount = _shippingInfo.BoxCount;
                    Ship.ShipmentStatus = _shippingInfo.ShipmentStatus;

                    _ShipmentDetailPageGrid1.Add(Ship);
                }
            }
            catch (Exception)
            { }
            return _ShipmentDetailPageGrid1;
        }



        public List<cstShipmentDetailPageGrid1> GetShipmentDetailPageGrid1SearchByDates(String Date1, String Date2)
        {
            List<cstShipmentDetailPageGrid1> _ShipmentDetailPageGrid1 = new List<cstShipmentDetailPageGrid1>();
            try
            {
                var shippp = Service.Get.GetAllShipmentDetailPageGrid1ByDateSearchs(Date1, Date2);
                //var shippp = Service.Get.PackageWithBox();
                foreach (var _shippingInfo in shippp.ToList())
                {
                    cstShipmentDetailPageGrid1 Ship = new cstShipmentDetailPageGrid1();
                    Ship.ShipmentID = _shippingInfo.ShipmentID;
                    Ship.ShippingCreatedTime = _shippingInfo.ShippingCreatedTime;
                    Ship.ShippingDate = (_shippingInfo.ShippingDate);
                    Ship.ShippingTime = _shippingInfo.ShippingTime;
                    Ship.OrderID = _shippingInfo.OrderID;
                    Ship.PONumber = _shippingInfo.PONumber;
                    Ship.PartnerID = _shippingInfo.PartnerID;
                    Ship.DeliveryMode = _shippingInfo.DeliveryMode;
                    Ship.Carrier = _shippingInfo.Carrier;
                    Ship.ExpectedShipDate = (_shippingInfo.ExpectedShipDate);
                    Ship.shqty = _shippingInfo.shqty;
                    Ship.pkqty = _shippingInfo.pkqty;
                    Ship.TrkCount = _shippingInfo.TrkCount;
                    Ship.BoxCount = _shippingInfo.BoxCount;
                    Ship.ShipmentStatus = _shippingInfo.ShipmentStatus;

                    _ShipmentDetailPageGrid1.Add(Ship);
                }
            }
            catch (Exception)
            { }
            return _ShipmentDetailPageGrid1;
        }



        public List<cstShipmentDetailPageGrid1> GetShipmentDetailPageGrid1ByDateSearchExpected(String Date1, String Date2)
        {
            List<cstShipmentDetailPageGrid1> _ShipmentDetailPageGrid1 = new List<cstShipmentDetailPageGrid1>();
            try
            {
                var shippp = Service.Get.GetAllShipmentDetailPageGrid1ByDateSearchExpecteds(Date1, Date2);
                //var shippp = Service.Get.PackageWithBox();
                foreach (var _shippingInfo in shippp.ToList())
                {
                    cstShipmentDetailPageGrid1 Ship = new cstShipmentDetailPageGrid1();
                    Ship.ShipmentID = _shippingInfo.ShipmentID;
                    Ship.ShippingCreatedTime = _shippingInfo.ShippingCreatedTime;
                    Ship.ShippingDate = (_shippingInfo.ShippingDate);
                    Ship.ShippingTime = _shippingInfo.ShippingTime;
                    Ship.OrderID = _shippingInfo.OrderID;
                    Ship.PONumber = _shippingInfo.PONumber;
                    Ship.PartnerID = _shippingInfo.PartnerID;
                    Ship.DeliveryMode = _shippingInfo.DeliveryMode;
                    Ship.Carrier = _shippingInfo.Carrier;
                    Ship.ExpectedShipDate = (_shippingInfo.ExpectedShipDate);
                    Ship.shqty = _shippingInfo.shqty;
                    Ship.pkqty = _shippingInfo.pkqty;
                    Ship.TrkCount = _shippingInfo.TrkCount;
                    Ship.BoxCount = _shippingInfo.BoxCount;
                    Ship.ShipmentStatus = _shippingInfo.ShipmentStatus;

                    _ShipmentDetailPageGrid1.Add(Ship);
                }
            }
            catch (Exception)
            { }
            return _ShipmentDetailPageGrid1;
        }

    }
}
