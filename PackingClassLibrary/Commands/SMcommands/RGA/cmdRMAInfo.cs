using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PackingClassLibrary.CustomEntity.SMEntitys.RGA;

namespace PackingClassLibrary.Commands.SMcommands.RGA
{
    class cmdRMAInfo
    {
        public List<RMAInfo> ReturnDetailBySRNumber(string SRNumber)
        {
            List<RMAInfo> _lsreturn = new List<RMAInfo>();
            try
            {
                Service.GetRMA.RMAInfoBySRNumber(SRNumber);
                var v = from ls in Service.GetRMA.RMAInfoBySRNumber(SRNumber)
                        select ls;

                foreach (var Ritem in v)
                {
                    _lsreturn.Add(new RMAInfo(Ritem));
                }
                //var v = from ls in Service.GetRMA.ReturnDetailByRGADROWID(RMANumber)
                //        select ls;

                //foreach (var Ritem in v)
                //{
                //    _lsreturn.Add(new ReturnDetail(Ritem));
                //}

            }
            catch (Exception)
            { }
            return _lsreturn;
        }

        public List<RMAInfo> ReturnDetailByPonumber(string POnumber)
        {
            List<RMAInfo> _lsreturn = new List<RMAInfo>();
            try
            {
                var v = from ls in Service.GetRMA.RMAInfoByPONumber(POnumber)
                        select ls;

                foreach (var Ritem in v)
                {
                    _lsreturn.Add(new RMAInfo(Ritem));
                }
            }
            catch (Exception)
            { }
            return _lsreturn;
        }

        #region deepak Barcode slip
        public string GetEANCode(String ItemCode)
        {
            string EANCode = "";
            try
            {
                EANCode = Service.GetRMA.GetEANCode(ItemCode);
            }
            catch (Exception)
            {
            }
            return EANCode;

        }

        #endregion


        public List<ReturnWithString> FortodayData()
        {
            List<ReturnWithString> _lsreturn = new List<ReturnWithString>();
            try
            {
                var v = from ls in Service.GetRMA.ReturnTodaysinstring()
                        select ls;

                foreach (var Ritem in v)
                {
                    _lsreturn.Add(new ReturnWithString(Ritem));
                }
            }
            catch (Exception)
            { }
            return _lsreturn;
        }

        public List<ReturnWithString> forPendingDecision()
        {
            List<ReturnWithString> _lsreturn = new List<ReturnWithString>();
            try
            {
                var v = from ls in Service.GetRMA.ReturnPending()
                        select ls;

                foreach (var Ritem in v)
                {
                    _lsreturn.Add(new ReturnWithString(Ritem));
                }
            }
            catch (Exception)
            { }
            return _lsreturn;
        }
        public List<ReturnWithString> returnByTracking(Guid returnID)
        {
            List<ReturnWithString> _lsreturn = new List<ReturnWithString>();
            try
            {


                var v = Service.GetRMA.GetRetrunDetailByReturnIDforTrackingSearch(returnID);



                foreach (var Ritem in v)
                {
                    _lsreturn.Add(new ReturnWithString(Ritem));

                }
            }
            catch (Exception)
            { }
            return _lsreturn;
        }
        public List<ReturnWithString> returnByTrackingText(string text)
        {
            List<ReturnWithString> _lsreturn = new List<ReturnWithString>();
            try
            {


                var v = Service.GetRMA.GetRetrunDetailByTextforTrackingSearch(text);



                foreach (var Ritem in v)
                {
                    _lsreturn.Add(new ReturnWithString(Ritem));

                }
            }
            catch (Exception)
            { }
            return _lsreturn;
        }

    }
}
