using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackingClassLibrary;
using PackingClassLibrary.CustomEntity;
using PackingClassLibrary.CustomEntity.ReportEntitys;
using System.Data.Objects.SqlClient;
using System.Data.Objects;
using PackingClassLibrary.Commands.SMcommands;

namespace PackingClassLibrary.Commands.ReportCommands
{
    public class cmdPackingTimeAndQuantity
    {
        
        /// <summary>
        /// Calculate all shipments toatal Quantity and Time Required to pack the saprate shipment
        /// </summary>
        /// <returns>List<cstPackingTime></returns>
        public List<cstPackingTime> GetPackingTimeAndQantity()
        {
            List<cstPackingTime> _lsreturnPacingTime = new List<cstPackingTime>();
            try
            {
                var packingG = Service.Get.GetPackingTimeAndQantity1();

                foreach (var listItem in packingG)
                {
                    cstPackingTime _Packing = new cstPackingTime();
                    _Packing.PackingID = listItem.PackingID;
                    _Packing.ShippingNumber = listItem.ShippingNumber;
                    _Packing.TimeSpend = listItem.TimeSpend;
                    _Packing.Quantity = listItem.Quantity;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            catch (Exception)
            { }
            return _lsreturnPacingTime;
        }
        /// <summary>
        /// Shipment With its Time And SKu Quantity up to current Date
        /// </summary>
        /// <param name="UserID">Long UserID</param>
        /// <returns>List<cstPackingTime></returns>
        public List<cstPackingTime> GetPackingTimeAndQantity(Guid UserID)
        {
            List<cstPackingTime> _lsreturnPacingTime = new List<cstPackingTime>();
            try
            {
                var packingG = Service.Get.GetPackingTimeAndQantity2(UserID);

                foreach (var listItem in packingG)
                {
                    cstPackingTime _Packing = new cstPackingTime();
                    _Packing.PackingID = listItem.PackingID;
                    _Packing.ShippingNumber = listItem.ShippingNumber;
                    _Packing.TimeSpend = listItem.TimeSpend;
                    _Packing.Quantity = listItem.Quantity;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            catch (Exception)
            { }
            return _lsreturnPacingTime;
        }

        /// <summary>
        /// Shipment With its Time And SKu Quantity on specified date
        /// </summary>
        /// <param name="UserID">Long UserID</param>
        /// <param name="date"> DateTime For Filter</param>
        /// <returns>List<cstPackingTime></returns>
        public List<cstPackingTime> GetPackingTimeAndQantity(DateTime Fromdate, DateTime Todate)
        {

            List<cstPackingTime> _lsreturnPacingTime = new List<cstPackingTime>();
            try
            {
                var packingG = Service.Get.GetPackingTimeAndQantity3(Fromdate, Todate);

                foreach (var listItem in packingG)
                {
                    cstPackingTime _Packing = new cstPackingTime();
                    _Packing.PackingID = listItem.PackingID;
                    _Packing.ShippingNumber = listItem.ShippingNumber;
                    _Packing.TimeSpend = listItem.TimeSpend;
                    _Packing.Quantity = listItem.Quantity;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            catch (Exception)
            { }
            return _lsreturnPacingTime;
        }

        /// <summary>
        /// Shipment With its Time And SKu Quantity on specified date
        /// </summary>
        /// <param name="UserID">Long UserID</param>
        /// <returns>List<cstPackingTime></returns>
        public List<cstPackingTime> GetPackingTimeAndQantity(Guid UserID, DateTime Fromdate, DateTime Todate)
        {

            List<cstPackingTime> _lsreturnPacingTime = new List<cstPackingTime>();
            try
            {
                var packingG = Service.Get.GetPackingTimeAndQantity4(UserID, Fromdate, Todate);

                foreach (var listItem in packingG)
                {
                    cstPackingTime _Packing = new cstPackingTime();
                    _Packing.PackingID = listItem.PackingID;
                    _Packing.ShippingNumber = listItem.ShippingNumber;
                    _Packing.TimeSpend = listItem.TimeSpend;
                    _Packing.Quantity = listItem.Quantity;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            catch (Exception)
            { }
            return _lsreturnPacingTime;
        }


        public List<cstPackingTime> GetPackingTimeAndQantity(int PackingStatus, Boolean PackingStaus)
        {
            List<cstPackingTime> _lsreturnPacingTime = new List<cstPackingTime>();
            try
            {
                var packingG = Service.Get.GetPackingTimeAndQantity5(PackingStatus, PackingStaus);

                foreach (var listItem in packingG)
                {
                    cstPackingTime _Packing = new cstPackingTime();
                    _Packing.PackingID = listItem.PackingID;
                    _Packing.ShippingNumber = listItem.ShippingNumber;
                    _Packing.TimeSpend = listItem.TimeSpend;
                    _Packing.Quantity = listItem.Quantity;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            catch (Exception)
            { }
            return _lsreturnPacingTime;
        }
        /// <summary>
        /// Shipment With its Time And SKu Quantity up to current Date
        /// </summary>
        /// <param name="UserID">Long UserID</param>
        /// <returns>List<cstPackingTime></returns>
        public List<cstPackingTime> GetPackingTimeAndQantity(Guid UserID, int PackingStatus)
        {
            List<cstPackingTime> _lsreturnPacingTime = new List<cstPackingTime>();
            try
            {
                var packingG = Service.Get.GetPackingTimeAndQantity6(UserID, PackingStatus);

                foreach (var listItem in packingG)
                {
                    cstPackingTime _Packing = new cstPackingTime();
                    _Packing.PackingID = listItem.PackingID;
                    _Packing.ShippingNumber = listItem.ShippingNumber;
                    _Packing.TimeSpend = listItem.TimeSpend;
                    _Packing.Quantity = listItem.Quantity;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            catch (Exception)
            { }
            return _lsreturnPacingTime;
        }

        /// <summary>
        /// Shipment With its Time And SKu Quantity on specified date
        /// </summary>
        /// <param name="UserID">Long UserID</param>
        /// <param name="date"> DateTime For Filter</param>
        /// <returns>List<cstPackingTime></returns>
        public List<cstPackingTime> GetPackingTimeAndQantity(DateTime Fromdate, DateTime Todate, int PackingStatus)
        {
            List<cstPackingTime> _lsreturnPacingTime = new List<cstPackingTime>();
            try
            {
                var packingG = Service.Get.GetPackingTimeAndQantity7(Fromdate, Todate, PackingStatus);

                foreach (var listItem in packingG)
                {
                    cstPackingTime _Packing = new cstPackingTime();
                    _Packing.PackingID = listItem.PackingID;
                    _Packing.ShippingNumber = listItem.ShippingNumber;
                    _Packing.TimeSpend = listItem.TimeSpend;
                    _Packing.Quantity = listItem.Quantity;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            catch (Exception)
            { }
            return _lsreturnPacingTime;
        }

        /// <summary>
        /// Shipment With its Time And SKu Quantity on specified date
        /// </summary>
        /// <param name="UserID">Long UserID</param>
        /// <returns>List<cstPackingTime></returns>
        public List<cstPackingTime> GetPackingTimeAndQantity(Guid UserID, DateTime Fromdate, DateTime Todate, int PackingStatus)
        {
            List<cstPackingTime> _lsreturnPacingTime = new List<cstPackingTime>();
            try
            {
                var packingG = Service.Get.GetPackingTimeAndQantity8(UserID, Fromdate, Todate, PackingStatus);

                foreach (var listItem in packingG)
                {
                    cstPackingTime _Packing = new cstPackingTime();
                    _Packing.PackingID = listItem.PackingID;
                    _Packing.ShippingNumber = listItem.ShippingNumber;
                    _Packing.TimeSpend = listItem.TimeSpend;
                    _Packing.Quantity = listItem.Quantity;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            catch (Exception)
            { }
            return _lsreturnPacingTime;
        }



        #region Station Wise new added

        /// <summary>
        /// Calculate all shipments toatal Quantity and Time Required to pack the saprate shipment
        /// </summary>
        /// <returns>List<cstPackingTime></returns>
        public List<cstPackingTime> GetPackingTimeAndQantityByStation(Guid StationID)
        {
            List<cstPackingTime> _lsreturnPacingTime = new List<cstPackingTime>();
            try
            {
                DateTime dt = DateTime.UtcNow;

                var packingG = Service.Get.GetPackingTimeAndQantityByStation21(StationID);


                foreach (var listItem in packingG)
                {
                    cstPackingTime _Packing = new cstPackingTime();
                    _Packing.PackingID = listItem.PackingID;
                    _Packing.ShippingNumber = cmdPackage.GetShippingNum(listItem.PackingID);
                    _Packing.Quantity = Convert.ToInt32(listItem.Quantity);
                    TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.TimeSpend.ToString()));
                    string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                    _Packing.TimeSpend = answer;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            catch (Exception)
            { }
            return _lsreturnPacingTime;
        }
        /// <summary>
        /// Shipment With its Time And SKu Quantity up to current Date
        /// </summary>
        /// <param name="UserID">Long UserID</param>
        /// <returns>List<cstPackingTime></returns>
        public List<cstPackingTime> GetPackingTimeAndQantityByStation(Guid UserID, Guid StationID)
        {
            List<cstPackingTime> _lsreturnPacingTime = new List<cstPackingTime>();
            try
            {
                DateTime dt = DateTime.UtcNow;

                var packingG = Service.Get.GetPackingTimeAndQantityByStation22(UserID, StationID);

                foreach (var listItem in packingG)
                {
                    cstPackingTime _Packing = new cstPackingTime();
                    _Packing.PackingID = listItem.PackingID;
                    _Packing.ShippingNumber = cmdPackage.GetShippingNum(listItem.PackingID);
                    _Packing.Quantity = Convert.ToInt32(listItem.Quantity);
                    TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.TimeSpend.ToString()));
                    string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                    _Packing.TimeSpend = answer;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            catch (Exception)
            { }
            return _lsreturnPacingTime;
        }

        /// <summary>
        /// Shipment With its Time And SKu Quantity on specified date
        /// </summary>
        /// <param name="UserID">Long UserID</param>
        /// <param name="date"> DateTime For Filter</param>
        /// <returns>List<cstPackingTime></returns>
        public List<cstPackingTime> GetPackingTimeAndQantityByStation(DateTime Fromdate, DateTime Todate, Guid StationID)
        {


            List<cstPackingTime> _lsreturnPacingTime = new List<cstPackingTime>();
            try
            {
                DateTime dt = DateTime.UtcNow;

                var packingG = Service.Get.GetPackingTimeAndQantityByStation23(Fromdate, Todate, StationID);

                foreach (var listItem in packingG)
                {
                    cstPackingTime _Packing = new cstPackingTime();
                    _Packing.PackingID = listItem.PackingID;
                    _Packing.ShippingNumber = cmdPackage.GetShippingNum(listItem.PackingID);
                    _Packing.Quantity = Convert.ToInt32(listItem.Quantity);
                    TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.TimeSpend.ToString()));
                    string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                    _Packing.TimeSpend = answer;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            catch (Exception)
            { }
            return _lsreturnPacingTime;
        }

        /// <summary>
        /// Shipment With its Time And SKu Quantity on specified date
        /// </summary>
        /// <param name="UserID">Long UserID</param>
        /// <returns>List<cstPackingTime></returns>
        public List<cstPackingTime> GetPackingTimeAndQantityByStation(Guid UserID, DateTime Fromdate, DateTime Todate, Guid StationID)
        {

            List<cstPackingTime> _lsreturnPacingTime = new List<cstPackingTime>();
            try
            {
                DateTime dt = DateTime.UtcNow;

                var packingG = Service.Get.GetPackingTimeAndQantityByStation24(UserID, Fromdate, Todate, StationID);


                foreach (var listItem in packingG)
                {
                    cstPackingTime _Packing = new cstPackingTime();
                    _Packing.PackingID = listItem.PackingID;
                    _Packing.ShippingNumber = cmdPackage.GetShippingNum(listItem.PackingID);
                    _Packing.Quantity = Convert.ToInt32(listItem.Quantity);
                    TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.TimeSpend.ToString()));
                    string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                    _Packing.TimeSpend = answer;
                    _lsreturnPacingTime.Add(_Packing);
                }
            }
            catch (Exception)
            { }
            return _lsreturnPacingTime;
        }


        public List<cstPackingTime> GetPackingTimeAndQantityByStation(int PackingStatus, Boolean PackingStaus, Guid StationID)
        {
              List<cstPackingTime> _lsreturnPacingTime = new List<cstPackingTime>();
              try
              {
                  DateTime dt = DateTime.UtcNow;

                  var packingG = Service.Get.GetPackingTimeAndQantityByStation25(PackingStatus, PackingStaus, StationID);


                  foreach (var listItem in packingG)
                  {
                      cstPackingTime _Packing = new cstPackingTime();
                      _Packing.PackingID = listItem.PackingID;
                      _Packing.ShippingNumber = cmdPackage.GetShippingNum(listItem.PackingID);
                      _Packing.Quantity = Convert.ToInt32(listItem.Quantity);
                      TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.TimeSpend.ToString()));
                      string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                      _Packing.TimeSpend = answer;
                      _lsreturnPacingTime.Add(_Packing);
                  }
              }
              catch (Exception)
              { }
            return _lsreturnPacingTime;
        }
        /// <summary>
        /// Shipment With its Time And SKu Quantity up to current Date
        /// </summary>
        /// <param name="UserID">Long UserID</param>
        /// <returns>List<cstPackingTime></returns>
        public List<cstPackingTime> GetPackingTimeAndQantityByStation(Guid UserID, int PackingStatus, Guid StationID)
        {
            List<cstPackingTime> _lsreturnPacingTime = new List<cstPackingTime>();
            if (PackingStatus == 0)
            {
                try
                {
                    DateTime dt = DateTime.UtcNow;

                    var packingG = Service.Get.GetPackingTimeAndQantityByStation26(UserID, PackingStatus, StationID);

                    foreach (var listItem in packingG)
                    {
                        cstPackingTime _Packing = new cstPackingTime();
                        _Packing.PackingID = listItem.PackingID;
                        _Packing.ShippingNumber = cmdPackage.GetShippingNum(listItem.PackingID);
                        _Packing.Quantity = Convert.ToInt32(listItem.Quantity);
                        TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.TimeSpend.ToString()));
                        string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                        _Packing.TimeSpend = answer;
                        _lsreturnPacingTime.Add(_Packing);
                    }
                }

                catch (Exception)
                { }
            }
                return _lsreturnPacingTime;
            
        }

        /// <summary>
        /// Shipment With its Time And SKu Quantity on specified date
        /// </summary>
        /// <param name="UserID">Long UserID</param>
        /// <param name="date"> DateTime For Filter</param>
        /// <returns>List<cstPackingTime></returns>
        public List<cstPackingTime> GetPackingTimeAndQantityByStation(DateTime Fromdate, DateTime Todate, int PackingStatus, Guid StationID)
        {
            List<cstPackingTime> _lsreturnPacingTime = new List<cstPackingTime>();
            if (PackingStatus == 0)
            {
                try
                {
                    DateTime dt = DateTime.UtcNow;

                    var packingG = Service.Get.GetPackingTimeAndQantityByStation27(Fromdate, Todate, PackingStatus, StationID);

                    foreach (var listItem in packingG)
                    {
                        cstPackingTime _Packing = new cstPackingTime();
                        _Packing.PackingID = listItem.PackingID;
                        _Packing.ShippingNumber = cmdPackage.GetShippingNum(listItem.PackingID);
                        _Packing.Quantity = Convert.ToInt32(listItem.Quantity);
                        TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.TimeSpend.ToString()));
                        string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                        _Packing.TimeSpend = answer;
                        _lsreturnPacingTime.Add(_Packing);
                    }
                }
                catch (Exception)
                { }
            }
            return _lsreturnPacingTime;
        }

        /// <summary>
        /// Shipment With its Time And SKu Quantity on specified date
        /// </summary>
        /// <param name="UserID">Long UserID</param>
        /// <returns>List<cstPackingTime></returns>
        public List<cstPackingTime> GetPackingTimeAndQantityByStation(Guid UserID, DateTime Fromdate, DateTime Todate, int PackingStatus, Guid StationID)
        {
            List<cstPackingTime> _lsreturnPacingTime = new List<cstPackingTime>();
            if (PackingStatus == 0)
            {
                try
                {
                    DateTime dt = DateTime.UtcNow;

                    var packingG = Service.Get.GetPackingTimeAndQantityByStation28(UserID, Fromdate, Todate, PackingStatus, StationID);

                    foreach (var listItem in packingG)
                    {
                        cstPackingTime _Packing = new cstPackingTime();
                        _Packing.PackingID = listItem.PackingID;
                        _Packing.ShippingNumber = cmdPackage.GetShippingNum(listItem.PackingID);
                        _Packing.Quantity = Convert.ToInt32(listItem.Quantity);
                        TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(listItem.TimeSpend.ToString()));
                        string answer = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", t.Hours, t.Minutes, t.Seconds);
                        _Packing.TimeSpend = answer;
                        _lsreturnPacingTime.Add(_Packing);
                    }
                }
                catch (Exception)
                { }
            }
            return _lsreturnPacingTime;
        }
        #endregion





    }
}
