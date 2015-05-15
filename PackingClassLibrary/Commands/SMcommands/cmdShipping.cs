using PackingClassLibrary.CustomEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingClassLibrary.Commands.SMcommands
{
    public class cmdShipping
    {
        //local_x3v6Entities entx3v6 = new local_x3v6Entities();
        //Sage_x3v6Entities Sage = new Sage_x3v6Entities();

        #region set Methods
        public Boolean SaveShippingTbl(List<cstShippingTbl> lsShipping)
        {
            Boolean _return = false;
            try
            {
                if (lsShipping.Count() > 0)
                {
                    foreach (cstShippingTbl _shippingInfo in lsShipping)
                    {
                        Guid _tShipID = Guid.Empty;
                        try { _tShipID = Service.Get.ShippingAllShipping().SingleOrDefault(re => re.ShippingNum == _shippingInfo.ShippingNum).ShippingID; } //entx3v6.Shippings.SingleOrDefault(i => i.ShippingNum == _shippingInfo.ShippingNum).ShippingID; }
                        catch (Exception) { }

                        //If shipping number is not saved previously then insert new record
                        if (_tShipID == Guid.Empty)
                        {
                            SetService.ShippingDTO Ship = new SetService.ShippingDTO();
                            Ship.ShippingID = Guid.NewGuid();
                            Ship.ShippingNum = _shippingInfo.ShippingNum;
                            Ship.ShippingStartTime = DateTime.UtcNow;
                            Ship.ShippingEndTime = DateTime.UtcNow;
                            Ship.DeliveryProvider = _shippingInfo.DeliveryProvider;
                            Ship.DeliveryMode = _shippingInfo.DeliveryMode;
                            Ship.FromAddressLine1 = _shippingInfo.FromAddressLine1;
                            Ship.FromAddressLine2 = _shippingInfo.FromAddressLine2;
                            Ship.FromAddressLine3 = _shippingInfo.FromAddressLine3;
                            Ship.FromAddressCity = _shippingInfo.FromAddressCity;
                            Ship.FromAddressState = _shippingInfo.FromAddressState;
                            Ship.FromAddressCountry = _shippingInfo.FromAddressCountry;
                            Ship.FromAddressZipCode = _shippingInfo.FromAddressZipCode;
                            Ship.ToAddressLine1 = _shippingInfo.ToAddressLine1;
                            Ship.ToAddressLine2 = _shippingInfo.ToAddressLine2;
                            Ship.ToAddressLine3 = _shippingInfo.ToAddressLine3;
                            Ship.ToAddressCity = _shippingInfo.ToAddressCity;
                            Ship.ToAddressState = _shippingInfo.ToAddressState;
                            Ship.ToAddressCountry = _shippingInfo.ToAddressCountry;
                            Ship.ToAddressZipCode = _shippingInfo.ToAddressZipCode;
                            Ship.ShipmentStatus = _shippingInfo.ShipmentStatus;
                            Ship.OrderID = _shippingInfo.OrderID;
                            Ship.CustomerPO = _shippingInfo.CustomerPO;
                            Ship.ShipToAddress = _shippingInfo.ShipToAddress;
                            Ship.OurSupplierNo = _shippingInfo.OurSupplierNo;
                            Ship.CustomerName1 = _shippingInfo.CustomerName1;
                            Ship.CustomerName2 = _shippingInfo.CustomerName2;
                            Ship.WebAddress = _shippingInfo.WebAddress;
                            Ship.FreightTerms = _shippingInfo.FreightTerms;
                            Ship.Carrier = _shippingInfo.Carrier;
                            Ship.DeliveryContact = _shippingInfo.DeliveryContact;
                            Ship.Indexcode = _shippingInfo.Indexcode;
                            Ship.Contact = _shippingInfo.Contact;
                            Ship.PaymentTerms = _shippingInfo.PaymentTerms;
                            Ship.TotalPackages = _shippingInfo.TotalPackages;
                            Ship.Fax = _shippingInfo.Fax;
                            Ship.VendorName = _shippingInfo.VendorName;
                            Ship.MDL_0 = _shippingInfo.MDL_0;
                            Ship.XB_RESFLG_0 = _shippingInfo.XB_RESFLG_0;
                            Ship.CODCHG_0 = _shippingInfo.CODCHG_0;
                            Ship.INSVAL_0 = _shippingInfo.INSVAL_0;
                            Ship.ADDCODFRT_0 = _shippingInfo.ADDCODFRT_0;
                            Ship.BILLOPT_0 = _shippingInfo.BILLOPT_0;
                            Ship.HDLCHG_0 = _shippingInfo.HDLCHG_0;
                            Ship.DOWNFLG_0 = _shippingInfo.DOWNFLG_0;
                            Ship.BACCT_0 = _shippingInfo.BACCT_0;
                            Ship.TPBILL_0 = _shippingInfo.TPBILL_0;
                            Ship.CUSTBILL_0 = _shippingInfo.CUSTBILL_0;
                            Ship.CNTFULNAM_0 = _shippingInfo.CNTFULNAM_0;
                            Ship.CreatedDateTime = DateTime.UtcNow;
                            Ship.CreatedBy = GlobalClasses.ClGlobal.UserID;

                            List<SetService.ShippingDTO> _lsshipping = new List<SetService.ShippingDTO>();
                            _lsshipping.Add(Ship);
                            var v = _lsshipping.ToArray();
                            bool r = Service.Set.Shipping(v);
                        }
                        else //If shipping number is saved previously then updated old record
                        {
                            SetService.ShippingDTO Ship = new SetService.ShippingDTO();
                            Ship.ShippingID = Guid.NewGuid();
                            Ship.ShippingNum = _shippingInfo.ShippingNum;
                            Ship.ShippingStartTime = DateTime.UtcNow;
                            Ship.ShippingEndTime = DateTime.UtcNow;
                            Ship.DeliveryProvider = _shippingInfo.DeliveryProvider;
                            Ship.DeliveryMode = _shippingInfo.DeliveryMode;
                            Ship.FromAddressLine1 = _shippingInfo.FromAddressLine1;
                            Ship.FromAddressLine2 = _shippingInfo.FromAddressLine2;
                            Ship.FromAddressLine3 = _shippingInfo.FromAddressLine3;
                            Ship.FromAddressCity = _shippingInfo.FromAddressCity;
                            Ship.FromAddressState = _shippingInfo.FromAddressState;
                            Ship.FromAddressCountry = _shippingInfo.FromAddressCountry;
                            Ship.FromAddressZipCode = _shippingInfo.FromAddressZipCode;
                            Ship.ToAddressLine1 = _shippingInfo.ToAddressLine1;
                            Ship.ToAddressLine2 = _shippingInfo.ToAddressLine2;
                            Ship.ToAddressLine3 = _shippingInfo.ToAddressLine3;
                            Ship.ToAddressCity = _shippingInfo.ToAddressCity;
                            Ship.ToAddressState = _shippingInfo.ToAddressState;
                            Ship.ToAddressCountry = _shippingInfo.ToAddressCountry;
                            Ship.ToAddressZipCode = _shippingInfo.ToAddressZipCode;
                            Ship.ShipmentStatus = _shippingInfo.ShipmentStatus;
                            Ship.OrderID = _shippingInfo.OrderID;
                            Ship.CustomerPO = _shippingInfo.CustomerPO;
                            Ship.ShipToAddress = _shippingInfo.ShipToAddress;
                            Ship.OurSupplierNo = _shippingInfo.OurSupplierNo;
                            Ship.CustomerName1 = _shippingInfo.CustomerName1;
                            Ship.CustomerName2 = _shippingInfo.CustomerName2;
                            Ship.WebAddress = _shippingInfo.WebAddress;
                            Ship.FreightTerms = _shippingInfo.FreightTerms;
                            Ship.Carrier = _shippingInfo.Carrier;
                            Ship.DeliveryContact = _shippingInfo.DeliveryContact;
                            Ship.Indexcode = _shippingInfo.Indexcode;
                            Ship.Contact = _shippingInfo.Contact;
                            Ship.PaymentTerms = _shippingInfo.PaymentTerms;
                            Ship.TotalPackages = _shippingInfo.TotalPackages;
                            Ship.Fax = _shippingInfo.Fax;
                            Ship.VendorName = _shippingInfo.VendorName;
                            Ship.MDL_0 = _shippingInfo.MDL_0;
                            Ship.XB_RESFLG_0 = _shippingInfo.XB_RESFLG_0;
                            Ship.CODCHG_0 = _shippingInfo.CODCHG_0;
                            Ship.INSVAL_0 = _shippingInfo.INSVAL_0;
                            Ship.ADDCODFRT_0 = _shippingInfo.ADDCODFRT_0;
                            Ship.BILLOPT_0 = _shippingInfo.BILLOPT_0;
                            Ship.HDLCHG_0 = _shippingInfo.HDLCHG_0;
                            Ship.DOWNFLG_0 = _shippingInfo.DOWNFLG_0;
                            Ship.BACCT_0 = _shippingInfo.BACCT_0;
                            Ship.TPBILL_0 = _shippingInfo.TPBILL_0;
                            Ship.CUSTBILL_0 = _shippingInfo.CUSTBILL_0;
                            Ship.CNTFULNAM_0 = _shippingInfo.CNTFULNAM_0;
                            Ship.CreatedDateTime = DateTime.UtcNow;
                            Ship.CreatedBy = GlobalClasses.ClGlobal.UserID;

                            List<SetService.ShippingDTO> _lsshipping = new List<SetService.ShippingDTO>();
                            _lsshipping.Add(Ship);
                            var v = _lsshipping.ToArray();
                            bool r = Service.Set.Shipping(v);

                            //SetService.ShippingDTO Ship = new SetService.ShippingDTO();
                            //Ship = Service.Get.ShippingByShippingID(_tShipID); 
                            ////entx3v6.Shippings.SingleOrDefault(i => i.ShippingID == _tShipID);
                            //Ship.ShippingNum = _shippingInfo.ShippingNum;
                            //DateTime EndTime = DateTime.UtcNow;
                            //DateTime.TryParse(_shippingInfo.ShippingEndTime.ToString(), out EndTime);
                            //Ship.ShippingEndTime = DateTime.UtcNow;
                            //if (EndTime.Date != Convert.ToDateTime("01/01/0001"))
                            //{ Ship.ShippingEndTime = EndTime; }
                            //Ship.DeliveryProvider = _shippingInfo.DeliveryProvider;
                            //Ship.DeliveryMode = _shippingInfo.DeliveryMode;
                            //Ship.FromAddressLine1 = _shippingInfo.FromAddressLine1;
                            //Ship.FromAddressLine2 = _shippingInfo.FromAddressLine2;
                            //Ship.FromAddressLine3 = _shippingInfo.FromAddressLine3;
                            //Ship.FromAddressCity = _shippingInfo.FromAddressCity;
                            //Ship.FromAddressState = _shippingInfo.FromAddressState;
                            //Ship.FromAddressCountry = _shippingInfo.FromAddressCountry;
                            //Ship.FromAddressZipCode = _shippingInfo.FromAddressZipCode;
                            //Ship.ToAddressLine1 = _shippingInfo.ToAddressLine1;
                            //Ship.ToAddressLine2 = _shippingInfo.ToAddressLine2;
                            //Ship.ToAddressLine3 = _shippingInfo.ToAddressLine3;
                            //Ship.ToAddressCity = _shippingInfo.ToAddressCity;
                            //Ship.ToAddressState = _shippingInfo.ToAddressState;
                            //Ship.ToAddressCountry = _shippingInfo.ToAddressCountry;
                            //Ship.ToAddressZipCode = _shippingInfo.ToAddressZipCode;
                            //Ship.ShipmentStatus = _shippingInfo.ShipmentStatus;
                            //Ship.OrderID = _shippingInfo.OrderID;
                            //Ship.CustomerPO = _shippingInfo.CustomerPO;
                            //Ship.ShipToAddress = _shippingInfo.ShipToAddress;
                            //Ship.OurSupplierNo = _shippingInfo.OurSupplierNo;
                            //Ship.CustomerName1 = _shippingInfo.CustomerName1;
                            //Ship.CustomerName2 = _shippingInfo.CustomerName2;
                            //Ship.WebAddress = _shippingInfo.WebAddress;
                            //Ship.FreightTerms = _shippingInfo.FreightTerms;
                            //Ship.Carrier = _shippingInfo.Carrier;
                            //Ship.DeliveryContact = _shippingInfo.DeliveryContact;
                            //Ship.Indexcode = _shippingInfo.Indexcode;
                            //Ship.Contact = _shippingInfo.Contact;
                            //Ship.PaymentTerms = _shippingInfo.PaymentTerms;
                            //Ship.TotalPackages = _shippingInfo.TotalPackages;
                            //Ship.Fax = _shippingInfo.Fax;
                            //Ship.VendorName = _shippingInfo.VendorName;
                            //Ship.MDL_0 = _shippingInfo.MDL_0;
                            //Ship.XB_RESFLG_0 = _shippingInfo.XB_RESFLG_0;
                            //Ship.CODCHG_0 = _shippingInfo.CODCHG_0;
                            //Ship.INSVAL_0 = _shippingInfo.INSVAL_0;
                            //Ship.ADDCODFRT_0 = _shippingInfo.ADDCODFRT_0;
                            //Ship.BILLOPT_0 = _shippingInfo.BILLOPT_0;
                            //Ship.HDLCHG_0 = _shippingInfo.HDLCHG_0;
                            //Ship.DOWNFLG_0 = _shippingInfo.DOWNFLG_0;
                            //Ship.BACCT_0 = _shippingInfo.BACCT_0;
                            //Ship.TPBILL_0 = _shippingInfo.TPBILL_0;
                            //Ship.CUSTBILL_0 = _shippingInfo.CUSTBILL_0;
                            //Ship.CNTFULNAM_0 = _shippingInfo.CNTFULNAM_0;
                            //Ship.UpdatedDateTime = DateTime.UtcNow;
                            //Ship.Updatedby = GlobalClasses.ClGlobal.UserID;
                        }

                    }
                  //  entx3v6.SaveChanges();
                    _return = true;
                }
            }
            catch (Exception)
            { }

            return _return;
        }
        #endregion

        #region Get Methods
        public List<cstShippingTbl> GetShipping()
        {
            List<cstShippingTbl> lsshippingInfo = new List<cstShippingTbl>();
            try
            {
                var ShippingInfo = Service.Get.ShippingAllShipping();//from ls in entx3v6.Shippings select ls;

                foreach (var _shippingInfo in ShippingInfo.ToList())
                {
                    DateTime Edate = DateTime.UtcNow;
                    DateTime.TryParse(_shippingInfo.ShippingEndTime.ToString(), out Edate);
                    cstShippingTbl Ship = new cstShippingTbl();
                    Ship.ShippingID = _shippingInfo.ShippingID;
                    Ship.ShippingNum = _shippingInfo.ShippingNum;
                    Ship.ShippingStartTime = Convert.ToDateTime(_shippingInfo.ShippingStartTime);
                    Ship.ShippingEndTime = Edate;
                    Ship.DeliveryProvider = _shippingInfo.DeliveryProvider;
                    Ship.DeliveryMode = _shippingInfo.DeliveryMode;
                    Ship.FromAddressLine1 = _shippingInfo.FromAddressLine1;
                    Ship.FromAddressLine2 = _shippingInfo.FromAddressLine2;
                    Ship.FromAddressLine3 = _shippingInfo.FromAddressLine3;
                    Ship.FromAddressCity = _shippingInfo.FromAddressCity;
                    Ship.FromAddressState = _shippingInfo.FromAddressState;
                    Ship.FromAddressCountry = _shippingInfo.FromAddressCountry;
                    Ship.FromAddressZipCode = _shippingInfo.FromAddressZipCode;
                    Ship.ToAddressLine1 = _shippingInfo.ToAddressLine1;
                    Ship.ToAddressLine2 = _shippingInfo.ToAddressLine2;
                    Ship.ToAddressLine3 = _shippingInfo.ToAddressLine3;
                    Ship.ToAddressCity = _shippingInfo.ToAddressCity;
                    Ship.ToAddressState = _shippingInfo.ToAddressState;
                    Ship.ToAddressCountry = _shippingInfo.ToAddressCountry;
                    Ship.ToAddressZipCode = _shippingInfo.ToAddressZipCode;
                    Ship.ShipmentStatus = _shippingInfo.ShipmentStatus;
                    Ship.OrderID = _shippingInfo.OrderID;
                    Ship.CustomerPO = _shippingInfo.CustomerPO;
                    Ship.ShipToAddress = _shippingInfo.ShipToAddress;
                    Ship.OurSupplierNo = _shippingInfo.OurSupplierNo;
                    Ship.CustomerName1 = _shippingInfo.CustomerName1;
                    Ship.CustomerName2 = _shippingInfo.CustomerName2;
                    Ship.WebAddress = _shippingInfo.WebAddress;
                    Ship.FreightTerms = _shippingInfo.FreightTerms;
                    Ship.Carrier = _shippingInfo.Carrier;
                    Ship.DeliveryContact = _shippingInfo.DeliveryContact;
                    Ship.Indexcode = Convert.ToInt16(_shippingInfo.Indexcode);
                    Ship.Contact = _shippingInfo.Contact;
                    Ship.PaymentTerms = _shippingInfo.PaymentTerms;
                    Ship.TotalPackages = Convert.ToInt32(_shippingInfo.TotalPackages);
                    Ship.Fax = _shippingInfo.Fax;
                    Ship.VendorName = _shippingInfo.VendorName;
                    Ship.MDL_0 = _shippingInfo.MDL_0;
                    Ship.XB_RESFLG_0 = Convert.ToByte(_shippingInfo.XB_RESFLG_0);
                    Ship.CODCHG_0 = _shippingInfo.CODCHG_0;
                    Ship.INSVAL_0 = Convert.ToDecimal(_shippingInfo.INSVAL_0);
                    Ship.ADDCODFRT_0 = Convert.ToByte(_shippingInfo.ADDCODFRT_0);
                    Ship.BILLOPT_0 = _shippingInfo.BILLOPT_0;
                    Ship.HDLCHG_0 = _shippingInfo.HDLCHG_0;
                    Ship.DOWNFLG_0 = Convert.ToByte(_shippingInfo.DOWNFLG_0);
                    Ship.BACCT_0 = _shippingInfo.BACCT_0;
                    Ship.TPBILL_0 = Convert.ToByte(_shippingInfo.TPBILL_0);
                    Ship.CUSTBILL_0 = Convert.ToByte(_shippingInfo.CUSTBILL_0);
                    Ship.CNTFULNAM_0 = _shippingInfo.CNTFULNAM_0;
                    Ship.SHIPPINGROWID = _shippingInfo.SHIPPINGROWID;
                    lsshippingInfo.Add(Ship);
                }
            }
            catch (Exception)
            { }
            return lsshippingInfo;

        }


        //public List<cstShippingTbl> GetShippingWithPackage()
        //{
        //    List<cstShippingTbl> _shippingInfoReturn = new List<cstShippingTbl>();
        //    try
        //    {
        //        var shippp = Service.Get.ShippingWithAllPackage();
        //        foreach (var _shippingInfo in shippp.ToList())
        //        {
        //            cstShippingTbl Ship = new cstShippingTbl();
        //            Ship.ShippingNum = _shippingInfo.ShippingNum;
        //            Ship.ShippingStartTime = _shippingInfo.ShippingStartTime;
        //            Ship.DeliveryProvider = _shippingInfo.DeliveryProvider;
        //            Ship.DeliveryMode = _shippingInfo.DeliveryMode;
        //            Ship.OrderID = _shippingInfo.OrderID;
        //            Ship.CustomerPO = _shippingInfo.CustomerPO;
        //            Ship.Carrier = _shippingInfo.Carrier;
        //            Ship.VendorName = _shippingInfo.VendorName;
        //            Ship.StartDate = _shippingInfo.StartDate;
        //            _shippingInfoReturn.Add(Ship);
        //        }
        //    }
        //    catch (Exception)
        //    { }
        //    return _shippingInfoReturn;
        //}


        public cstShippingTbl GetShippingByShippingNumber(String ShippingNum)
        {
            cstShippingTbl Ship = new cstShippingTbl();
            try
            {
                List<GetService.ShippingDTO> _shippingInfo = new List<GetService.ShippingDTO>();
                var shippp = Service.Get.ShippingByShippingNum(ShippingNum);
                foreach (var item in shippp)
                {
                    _shippingInfo.Add(item);
                }
                //List<GetService.ShippingDTO> _shippingInfo = Service.Get.ShippingByShippingNum(ShippingNum); //entx3v6.Shippings.SingleOrDefault(i => i.ShippingNum == ShippingNum);
                
                Ship.ShippingID = _shippingInfo[0].ShippingID;
                Ship.ShippingNum = _shippingInfo[0].ShippingNum;
                Ship.ShippingStartTime = Convert.ToDateTime(_shippingInfo[0].ShippingStartTime);
                Ship.ShippingEndTime = Convert.ToDateTime(_shippingInfo[0].ShippingEndTime); ;
                Ship.DeliveryProvider = _shippingInfo[0].DeliveryProvider;
                Ship.DeliveryMode = _shippingInfo[0].DeliveryMode;
                Ship.FromAddressLine1 = _shippingInfo[0].FromAddressLine1;
                Ship.FromAddressLine2 = _shippingInfo[0].FromAddressLine2;
                Ship.FromAddressLine3 = _shippingInfo[0].FromAddressLine3;
                Ship.FromAddressCity = _shippingInfo[0].FromAddressCity;
                Ship.FromAddressState = _shippingInfo[0].FromAddressState;
                Ship.FromAddressCountry = _shippingInfo[0].FromAddressCountry;
                Ship.FromAddressZipCode = _shippingInfo[0].FromAddressZipCode;
                Ship.ToAddressLine1 = _shippingInfo[0].ToAddressLine1;
                Ship.ToAddressLine2 = _shippingInfo[0].ToAddressLine2;
                Ship.ToAddressLine3 = _shippingInfo[0].ToAddressLine3;
                Ship.ToAddressCity = _shippingInfo[0].ToAddressCity;
                Ship.ToAddressState = _shippingInfo[0].ToAddressState;
                Ship.ToAddressCountry = _shippingInfo[0].ToAddressCountry;
                Ship.ToAddressZipCode = _shippingInfo[0].ToAddressZipCode;
                Ship.ShipmentStatus = _shippingInfo[0].ShipmentStatus;
                Ship.OrderID = _shippingInfo[0].OrderID;
                Ship.CustomerPO = _shippingInfo[0].CustomerPO;
                Ship.ShipToAddress = _shippingInfo[0].ShipToAddress;
                Ship.OurSupplierNo = _shippingInfo[0].OurSupplierNo;
                Ship.CustomerName1 = _shippingInfo[0].CustomerName1;
                Ship.CustomerName2 = _shippingInfo[0].CustomerName2;
                Ship.WebAddress = _shippingInfo[0].WebAddress;
                Ship.FreightTerms = _shippingInfo[0].FreightTerms;
                Ship.Carrier = _shippingInfo[0].Carrier;
                Ship.DeliveryContact = _shippingInfo[0].DeliveryContact;
                Ship.Indexcode = Convert.ToInt16(_shippingInfo[0].Indexcode);
                Ship.Contact = _shippingInfo[0].Contact;
                Ship.PaymentTerms = _shippingInfo[0].PaymentTerms;
                Ship.TotalPackages = Convert.ToInt32(_shippingInfo[0].TotalPackages);
                Ship.Fax = _shippingInfo[0].Fax;
                Ship.VendorName = _shippingInfo[0].VendorName;
                Ship.MDL_0 = _shippingInfo[0].MDL_0;
                Ship.XB_RESFLG_0 = Convert.ToByte(_shippingInfo[0].XB_RESFLG_0);
                Ship.CODCHG_0 = _shippingInfo[0].CODCHG_0;
                Ship.INSVAL_0 = Convert.ToDecimal(_shippingInfo[0].INSVAL_0);
                Ship.ADDCODFRT_0 = Convert.ToByte(_shippingInfo[0].ADDCODFRT_0);
                Ship.BILLOPT_0 = _shippingInfo[0].BILLOPT_0;
                Ship.HDLCHG_0 = _shippingInfo[0].HDLCHG_0;
                Ship.DOWNFLG_0 = Convert.ToByte(_shippingInfo[0].DOWNFLG_0);
                Ship.BACCT_0 = _shippingInfo[0].BACCT_0;
                Ship.TPBILL_0 = Convert.ToByte(_shippingInfo[0].TPBILL_0);
                Ship.CUSTBILL_0 = Convert.ToByte(_shippingInfo[0].CUSTBILL_0);
                Ship.CNTFULNAM_0 = _shippingInfo[0].CNTFULNAM_0;
                Ship.SHIPPINGROWID = _shippingInfo[0].SHIPPINGROWID;

            }
            catch (Exception)
            { }
            return Ship;
        }
        #endregion

        #region set Delete

        #endregion
    }
}
