using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackingClassLibrary.CustomEntity.ReportEntitys;
using System.Data.Objects;
using PackingClassLibrary.Commands.SMcommands;
using PackingClassLibrary.CustomEntity.SMEntitys;
namespace PackingClassLibrary.Commands.ReportCommands
{
    public class cmdStationTotalPacked
    {

        public List<cstStationToatlPacked> GetEachStationPacked()
        {
            List<cstStationToatlPacked> _lsStationPacked = new List<cstStationToatlPacked>();
            try
            {
                var vStationPacked = Service.Get.GetEachStationPacked();


                foreach (var item in vStationPacked)
                {
                    cstStationToatlPacked _spacked = new cstStationToatlPacked();
                    _spacked.StationID = item.StationID;
                    _spacked.StationName = item.StationName;
                    _spacked.TotalPacked = item.TotalPacked;
                    _spacked.PartiallyPacked = item.PartiallyPacked;
                    _lsStationPacked.Add(_spacked);
                }
            }
            catch (Exception)
            { }
            return _lsStationPacked;

        }

        public List<cstStationToatlPacked> GetEachStationPacked(DateTime DateReport)
        {
            List<cstStationToatlPacked> _lsStationPacked = new List<cstStationToatlPacked>();
            try
            {
                var vStationPacked = Service.Get.GetEachStationPacked1(DateReport);


                foreach (var item in vStationPacked)
                {
                    cstStationToatlPacked _spacked = new cstStationToatlPacked();
                    _spacked.StationID = item.StationID;
                    _spacked.StationName = item.StationName;
                    _spacked.TotalPacked = item.TotalPacked;
                    _spacked.PartiallyPacked = item.PartiallyPacked;
                    _lsStationPacked.Add(_spacked);
                }
            }
            catch (Exception)
            { }
            return _lsStationPacked;

        }


        public List<cstDashBoardStion> GetStationByReport(DateTime DateReport)
        {
            List<cstDashBoardStion> _lsStationPacked = new List<cstDashBoardStion>();
            try
            {
                var vStationPacked = Service.Get.GetStationByReport(DateReport);


                foreach (var item in vStationPacked)
                {
                    cstDashBoardStion _spacked = new cstDashBoardStion();
                    _spacked.ErrorCaught = item.ErrorCaught;
                    _spacked.StationName = item.StationName;
                    _spacked.TotalPacked = item.TotalPacked;
                    _spacked.packagePerhr = item.packagePerhr;
                    _spacked.ShipmentNumber = item.ShipmentNumber;
                    _spacked.PackerName = item.PackerName;
                    _lsStationPacked.Add(_spacked);
                }
            }
            catch (Exception)
            { }
            return _lsStationPacked;
        }


        public int PackedTodayByStationID(string StationName)
        {
            return Service.Get.PackedTodayByStationID(StationName);
        }

        public String UnderPackingID(String StationName)
        {
            return Service.Get.UnderPackingID(StationName);

        }

        public List<cstUserEachPacked> GetEachUserPacked(DateTime DateReport)
        {
            List<cstUserEachPacked> _lsStationPacked = new List<cstUserEachPacked>();
            try
            {
                var vStationPacked = Service.Get.GetEachUserPacked(DateReport);


                foreach (var item in vStationPacked)
                {
                    cstUserEachPacked _spacked = new cstUserEachPacked();
                    _spacked.UserID = item.UserID;
                    _spacked.UserName = item.UserName;
                    _spacked.TotalPacked = item.TotalPacked;
                    _spacked.PartiallyPacked = item.PartiallyPacked;
                    _lsStationPacked.Add(_spacked);
                }
            }
            catch (Exception)
            { }
            return _lsStationPacked;

        }

    }
}
