using PackingClassLibrary.CustomEntity;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingClassLibrary.Commands.SMcommands
{
    public class cmdPackage
    {
        //local_x3v6Entities entx3v6 = new local_x3v6Entities();
        //Sage_x3v6Entities Sage = new Sage_x3v6Entities();

        #region Get Package
        /// <summary>
        /// get information from packag table
        /// </summary>
        /// <param name="PackingID">Guid PackingID</param>
        /// <returns>String ShippingNum</returns>
        public static String GetShippingNum(Guid PackingID)
        {
          //  local_x3v6Entities ent = new local_x3v6Entities();
            string lsShippingNumbers = "0";
            try
            {
                lsShippingNumbers = Service.Get.PackageByPackageID(PackingID)[0].ShippingNum;
            }
            catch (Exception)
            { }
            return lsShippingNumbers;
        }

        /// <summary>
        /// get information from packag table
        /// </summary>
        /// <param name="ShippingNumber">String Shippingn Number</param>
        /// <returns>List of Guid That indicates the PackingID</returns>
        public static List<Guid> GetPackingNum(String ShippingNumber)
        {
            List<Guid> _PackingID = new List<Guid>();
            try
            {
                var PackingNum = Service.Get.PackageByShippingNum(ShippingNumber);
                foreach (var PakingNumItem in PackingNum)
                {
                    Guid _PackingNum = new Guid();
                    _PackingNum = PakingNumItem.PackingId;
                    _PackingID.Add(_PackingNum);
                }
            }
            catch (Exception)
            { }
            return _PackingID;
        }

        /// <summary>
        /// Get Infromation from Package table 
        /// </summary>
        /// <param name="ShippingNumber">String Shipment Number</param>
        /// <param name="OverrideMode">int manager Override</param>
        /// <param name="Location">String Location</param>
        /// <returns>Guid as a packing</returns>
        public static Guid GetPackageDI(String ShippingNumber, int OverrideMode, String Location)
        {
            Guid _PackingID = Guid.Empty;
            try
            {
                _PackingID = Service.Get.PackageAllPackge().SingleOrDefault(i => i.ShippingNum == ShippingNumber && i.MangerOverride == OverrideMode && i.ShipmentLocation == Location).PackingId;
            }
            catch (Exception)
            { }
            return _PackingID;
        }

        /// <summary>
        /// All packing table 
        /// </summary>
        /// <returns>list < cstPackingtbl></returns>
        public List<cstPackageTbl> Execute()
        {
            List<cstPackageTbl> _lsreturn = new List<cstPackageTbl>();
            try
            {
                var listPacking = Service.Get.PackageAllPackge(); //from packingtbl in entx3v6.Packages select packingtbl;
                foreach (var listitem in listPacking)
                {
                    cstPackageTbl _pack = new cstPackageTbl();
                    _pack.PackingId = listitem.PackingId;
                    _pack.ShippingID = (Guid)listitem.ShippingID;
                    _pack.ShippingNum = listitem.ShippingNum;
                    _pack.PackingStatus = Convert.ToInt32(listitem.PackingStatus);
                    _pack.UserID = listitem.UserID;
                    _pack.ShipmentLocation = listitem.ShipmentLocation;
                    _pack.StartTime = Convert.ToDateTime(listitem.StartTime);
                    _pack.EndTime = Convert.ToDateTime(listitem.EndTime);
                    _pack.StationID = (Guid)listitem.StationID;
                    _pack.MangerOverride = Convert.ToInt32(listitem.MangerOverride);
                    _pack.PCKROWID = listitem.PCKROWID;
                    _lsreturn.Add(_pack);
                }
            }
            catch (Exception Ex)
            {
                Error_Loger.elAction.save("GetPackingListSelcted.Execute(1)", Ex.Message.ToString());
            }
            return _lsreturn;
        }
        /// <summary>
        /// All packing table 
        /// </summary>
        /// <param name="UserID">long UserID</param>
        /// <returns>list < cstPackingtbl></returns>
        public List<cstPackageTbl> Execute(Guid UserID)
        {
            List<cstPackageTbl> _lsreturn = new List<cstPackageTbl>();
            try
            {

                var listPacking = Service.Get.PackageByUserID(UserID);
                    
                    //from packingtbl in entx3v6.Packages
                    //              where packingtbl.UserId == UserID
                    //              select packingtbl;
                foreach (var listitem in listPacking)
                {
                    cstPackageTbl _pack = new cstPackageTbl();
                    _pack.PackingId = listitem.PackingId;
                    _pack.ShippingID = (Guid)listitem.ShippingID;
                    _pack.ShippingNum = listitem.ShippingNum;
                    _pack.PackingStatus = Convert.ToInt32(listitem.PackingStatus);
                    _pack.UserID = listitem.UserID;
                    _pack.ShipmentLocation = listitem.ShipmentLocation;
                    _pack.StartTime = Convert.ToDateTime(listitem.StartTime);
                    _pack.EndTime = Convert.ToDateTime(listitem.EndTime);
                    _pack.StationID = (Guid)listitem.StationID;
                    _pack.MangerOverride = Convert.ToInt32(listitem.MangerOverride);
                    _pack.PCKROWID = listitem.PCKROWID;
                    _lsreturn.Add(_pack);
                }
            }
            catch (Exception Ex)
            {
                Error_Loger.elAction.save("GetPackingListSelcted.Execute(2)", Ex.Message.ToString());
            }
            return _lsreturn;
        }

        /// <summary>
        /// All packing table 
        /// </summary>
        /// <param name="UserID">long UserID</param>
        /// <param name="Date">DateTime Date</param>
        /// <returns>list < cstPackingtbl></returns>
        public List<cstPackageTbl> Execute(Guid UserID, DateTime Date)
        {
            List<cstPackageTbl> _lsreturn = new List<cstPackageTbl>();
            try
            {
                var listPacking = Service.Get.PackageByUserIDAndDate(UserID, Date);
                    //from packingtbl in entx3v6.Packages
                    //              where packingtbl.UserId == UserID &&
                    //             EntityFunctions.TruncateTime(packingtbl.EndTime.Value) == EntityFunctions.TruncateTime(Date.Date)
                    //              select packingtbl;

                foreach (var listitem in listPacking)
                {
                    cstPackageTbl _pack = new cstPackageTbl();
                    _pack.PackingId = listitem.PackingId;
                    _pack.ShippingID = (Guid)listitem.ShippingID;
                    _pack.ShippingNum = _pack.ShippingNum;
                    _pack.PackingStatus = Convert.ToInt32(listitem.PackingStatus);
                    _pack.UserID = listitem.UserID;
                    _pack.ShipmentLocation = listitem.ShipmentLocation;
                    _pack.StartTime = Convert.ToDateTime(listitem.StartTime);
                    _pack.EndTime = Convert.ToDateTime(listitem.EndTime);
                    _pack.StationID = (Guid)listitem.StationID;
                    _pack.MangerOverride = Convert.ToInt32(listitem.MangerOverride);
                    _pack.PCKROWID = listitem.PCKROWID;
                    _lsreturn.Add(_pack);
                }
            }
            catch (Exception Ex)
            {
                Error_Loger.elAction.save("GetPackingListSelcted.Execute(3)", Ex.Message.ToString());
            }
            return _lsreturn;
        }

        /// <summary>
        /// Packing Tbl Packing Id wiht manger Override =0
        /// </summary>
        /// <param name="ShippingNum"></param>
        /// <param name="Location"></param>
        /// <returns></returns>
        public List<cstPackageTbl> Execute(String ShippingNum, String Location)
        {
            List<cstPackageTbl> _lsPacking = new List<cstPackageTbl>();
            try
            {
              //Service.Get.PackageAllPackge().SingleOrDefault(v => v.ShippingNum == ShippingNum && v.ShipmentLocation == Location);
                var _Packing1 = Service.Get.PackageByShippingNumAndLocation(ShippingNum, Location);
                    
                    //from v in entx3v6.Packages
                    //            where v.ShippingNum == ShippingNum && v.ShipmentLocation == Location
                    //            select v; 
                    
                foreach (var _Packing in _Packing1)
                {
                    cstPackageTbl _PC = new cstPackageTbl();
                    _PC.PackingId = _Packing.PackingId;
                    _PC.ShippingID = (Guid)_Packing.ShippingID;
                    _PC.ShippingNum = _Packing.ShippingNum;
                    _PC.UserID = _Packing.UserID;
                    _PC.StartTime = Convert.ToDateTime(_Packing.StartTime);
                    _PC.EndTime = Convert.ToDateTime(_Packing.EndTime);
                    _PC.StationID = (Guid)_Packing.StationID;
                    _PC.PackingStatus = Convert.ToInt32(_Packing.PackingStatus);
                    _PC.ShipmentLocation = _Packing.ShipmentLocation;
                    _PC.MangerOverride = Convert.ToInt32(_Packing.MangerOverride);
                    _PC.PCKROWID = _Packing.PCKROWID;
                    _lsPacking.Add(_PC);
                }

            }
            catch (Exception Ex)
            {
                Error_Loger.elAction.save("GetPackingListSelcted.Execute()", Ex.Message.ToString());
            }
            return _lsPacking;
        }

        public List<cstPackageTbl> Execute(String ShippingNum, String Location, int managerOvrride)
        {
            List<cstPackageTbl> _lsPacking = new List<cstPackageTbl>();
            try
            {
               // local_x3v6Entities _Localx3v6 = new local_x3v6Entities();
                var _Packing = Service.Get.PackageByShippingNumAndLocation(ShippingNum, Location).SingleOrDefault(r => r.MangerOverride == managerOvrride);// _Localx3v6.Packages.SingleOrDefault(i => i.ShippingNum == ShippingNum && i.ShipmentLocation == Location && i.ManagerOverride == managerOvrride);
                cstPackageTbl _PC = new cstPackageTbl();
                _PC.PackingId = _Packing.PackingId;
                _PC.ShippingID = (Guid)_Packing.ShippingID;
                _PC.ShippingNum = _Packing.ShippingNum;
                _PC.UserID = _Packing.UserID;
                _PC.StartTime = Convert.ToDateTime(_Packing.StartTime);
                _PC.EndTime = Convert.ToDateTime(_Packing.EndTime);
                _PC.StationID = (Guid)_Packing.StationID;
                _PC.PackingStatus = Convert.ToInt32(_Packing.PackingStatus);
                _PC.ShipmentLocation = _Packing.ShipmentLocation;
                _PC.MangerOverride = Convert.ToInt32(_Packing.MangerOverride);
                _PC.PCKROWID = _Packing.PCKROWID;
                _lsPacking.Add(_PC);
            }
            catch (Exception Ex)
            {
                Error_Loger.elAction.save("GetPackingListSelcted.Execute()", Ex.Message.ToString());
            }
            return _lsPacking;
        }

        /// <summary>
        /// get the packing id from PCKROWID
        /// </summary>
        /// <param name="PCKROWID">
        /// String PCKROWID
        /// </param>
        /// <returns>
        /// Guid PackingID
        /// </returns>
        public Guid GetPackingID(string PCKROWID)
        {
            Guid _return = Guid.Empty;
            try
            {
                _return = Service.Get.PackingID(PCKROWID);
            }
            catch (Exception)
            {}

            return _return;
        }

        public cstPackageTbl ExecutePacking(Guid PackingID)
        {
            cstPackageTbl _PC = new cstPackageTbl();
            try
            {
               // local_x3v6Entities _Localx3v6 = new local_x3v6Entities();
                var _Packing = Service.Get.PackageByPackageID(PackingID); //_Localx3v6.Packages.SingleOrDefault(i => i.PackingId == PackingID);

                foreach (var item in _Packing)
                {
                 _PC = new cstPackageTbl();
                 _PC.PackingId = item.PackingId;
                 _PC.ShippingID = (Guid)item.ShippingID;
                 _PC.ShippingNum = item.ShippingNum;
                 _PC.UserID = item.UserID;
                 _PC.StartTime = Convert.ToDateTime(item.StartTime);
                 _PC.EndTime = Convert.ToDateTime(item.EndTime);
                 _PC.StationID = (Guid)item.StationID;
                 _PC.PackingStatus = Convert.ToInt32(item.PackingStatus);
                 _PC.ShipmentLocation = item.ShipmentLocation;
                 _PC.MangerOverride = Convert.ToInt32(item.MangerOverride);
                 _PC.PCKROWID = item.PCKROWID;

                }
 
               
            }
            catch (Exception Ex)
            {
                Error_Loger.elAction.save("GetPackingListSelcted.Execute()", Ex.Message.ToString());
            }
            return _PC;
        }

        public List<cstPackageTbl> ExecuteNoLocation(String ShippingNum)
        {
            List<cstPackageTbl> _lsPacking = new List<cstPackageTbl>();
            try
            {
               // local_x3v6Entities _Localx3v6 = new local_x3v6Entities();
               // Package _Packing = _Localx3v6.Packages.SingleOrDefault(i => i.ShippingNum == ShippingNum);
                var _packinglist = Service.Get.PackageByShippingNum(ShippingNum); 
                    //from _Pack in _Localx3v6.Packages
                      //             where _Pack.ShippingNum == ShippingNum
                        //           select _Pack;
                foreach (var _Packing in _packinglist)
                {
                    cstPackageTbl _PC = new cstPackageTbl();
                    _PC.PackingId = _Packing.PackingId;
                    _PC.ShippingID = (Guid)_Packing.ShippingID;
                    _PC.ShippingNum = _Packing.ShippingNum;
                    _PC.UserID = _Packing.UserID;
                    _PC.StartTime = Convert.ToDateTime(_Packing.StartTime);
                    _PC.EndTime = Convert.ToDateTime(_Packing.EndTime);
                    _PC.StationID = (Guid)_Packing.StationID;
                    _PC.PackingStatus = Convert.ToInt32(_Packing.PackingStatus);
                    _PC.ShipmentLocation = _Packing.ShipmentLocation;
                    _PC.MangerOverride = Convert.ToInt32(_Packing.MangerOverride);
                    _PC.PCKROWID = _Packing.PCKROWID;
                    _lsPacking.Add(_PC);   
                }

                
            }
            catch (Exception Ex)
            {
                Error_Loger.elAction.save("GetPackingListSelcted.ExecuteNoLocation()", Ex.Message.ToString());
            }
            return _lsPacking;
        }

        public string getMaxPackageID()
        {
            string MaxID = "";
            try
            {
               // Guid MaxGUiID = entx3v6.Packages.Max(i => i.PackingId);
                MaxID = Service.Get.MaxPackingID(); //entx3v6.Packages.SingleOrDefault(i => i.PackingId == MaxGUiID).ShippingNum;

            }
            catch (Exception Ex)
            {
                Error_Loger.elAction.save("GetMaxShipmentIDCommmand.Execute()", Ex.Message.ToString());
            }
            return MaxID;
        }
        #endregion


        #region set Packing
        /// <summary>
        /// Save data to the paking table.
        /// </summary>
        /// <param name="lsPackingObj">list of values for the packing table.</param>
        /// <returns>New Guid</returns>
        public Guid setPacking(List<cstPackageTbl> lsPackingObj)
        {
            Guid Retuen = Guid.Empty;
            try
            {
                foreach (var Pckitems in lsPackingObj)
                {
                    SetService.PackageDTO _packing = new SetService.PackageDTO();
                    _packing.PackingId = Guid.NewGuid();
                    _packing.ShippingID = Service.Get.PackageAllPackge().SingleOrDefault(i => i.ShippingNum == Pckitems.ShippingNum).ShippingID;
                    _packing.UserID = Pckitems.UserID;
                    _packing.ShippingNum = Pckitems.ShippingNum;
                    _packing.StartTime = Pckitems.StartTime;
                    _packing.EndTime = Pckitems.EndTime;
                    _packing.StationID = Pckitems.StationID;
                    _packing.PackingStatus = Pckitems.PackingStatus;
                    _packing.ShipmentLocation = Pckitems.ShipmentLocation;
                    _packing.CreatedBy = GlobalClasses.ClGlobal.UserID;
                    _packing.CreatedDateTime = DateTime.UtcNow;
                    _packing.MangerOverride = Pckitems.MangerOverride;

                    List<SetService.PackageDTO> lspackage = new List<SetService.PackageDTO>();
                    lspackage.Add(_packing);
                    var v = lspackage.ToArray();
                    bool r = Service.Set.Package(v);

                    //entx3v6.AddToPackages(_packing);
                    Retuen = _packing.PackingId;
                }
                //entx3v6.SaveChanges();

            }
            catch (Exception Ex)
            {
                Error_Loger.elAction.save("UpdatePackingCommand.Execute()", Ex.Message.ToString());
            }
            return Retuen;
        }
        /// <summary>
        /// Save data to the paking table.
        /// </summary>
        /// <param name="lsPackingObj">list of values for the packing table.</param>
        /// <returns>fail if trasaction fail else Success.</returns>
        public string setPacking(List<cstPackageTbl> lsPackingObj, Guid PackingID)
        {
            string Retuen = "Fail";
            try
            {
                SetService.PackageDTO[] Lspackage = { new SetService.PackageDTO() };
                //List<GetService.PackageDTO> _lspackage = new List<GetService.PackageDTO>();
                foreach (var Pckitems in lsPackingObj)
                {
                    GetService.PackageDTO[] _packing = Service.Get.PackageByPackageID(PackingID); //entx3v6.Packages.SingleOrDefault(i => i.PackingId == PackingID);
                    _packing[0].UserID = Pckitems.UserID;
                    _packing[0].ShippingID = Pckitems.ShippingID;
                    _packing[0].ShippingNum = Pckitems.ShippingNum;
                    _packing[0].StartTime = Pckitems.StartTime;
                    _packing[0].EndTime = Pckitems.EndTime;
                    _packing[0].StationID = Pckitems.StationID;
                    _packing[0].PackingStatus = Pckitems.PackingStatus;
                    _packing[0].ShipmentLocation = Pckitems.ShipmentLocation;
                    _packing[0].Updatedby = GlobalClasses.ClGlobal.UserID;
                    _packing[0].UpdatedDateTime = DateTime.UtcNow;
                    _packing[0].MangerOverride = Pckitems.MangerOverride;


                    Lspackage[0].UserID = _packing[0].UserID;
                    Lspackage[0].ShippingID = _packing[0].ShippingID;
                    Lspackage[0].ShippingNum = _packing[0].ShippingNum;
                    Lspackage[0].StartTime = _packing[0].StartTime;
                    Lspackage[0].EndTime = _packing[0].EndTime;
                    Lspackage[0].StationID = _packing[0].StationID;
                    Lspackage[0].PackingStatus = _packing[0].PackingStatus;
                    Lspackage[0].ShipmentLocation = _packing[0].ShipmentLocation;
                    Lspackage[0].Updatedby = GlobalClasses.ClGlobal.UserID;
                    Lspackage[0].UpdatedDateTime = DateTime.UtcNow;
                    Lspackage[0].MangerOverride = _packing[0].MangerOverride;

                    //var r = _lspackage.ToArray();
                    // Service.Set.Package(r);
                    
                }
                Service.Set.Package(Lspackage);
               
                //entx3v6.SaveChanges();
                Retuen = "Success";
            }
            catch (Exception Ex)
            {
                Error_Loger.elAction.save("UpdatePackingCommand.UpdatePacking()", Ex.Message.ToString());
            }
            return Retuen;
        }
        #endregion


        #region Delete Packing
        /// <summary>
        /// Roll Back Transaction Operations that delete the entry from the table Paking.
        /// For shipment ID
        /// </summary>
        /// <param name="ShipmentID">Roll back entry from Shipment</param>
        /// <returns>Boolean if Transacetion Seccess else False</returns>
        public Boolean RollBack(String ShipmentID)
        {
            Boolean _return = false;
            try
            {
                Service.delete.PackageByShipmentNum(ShipmentID);

                //Package _Packing = entx3v6.Packages.SingleOrDefault(i => i.ShippingNum == ShipmentID);
                //entx3v6.DeleteObject(_Packing);
                //entx3v6.SaveChanges();
                _return = true;
            }
            catch (Exception Ex)
            {
                Error_Loger.elAction.save("RollBackPakingMaster.Execute()", Ex.Message.ToString());
            }
            return _return;
        }
        #endregion
    }
}
