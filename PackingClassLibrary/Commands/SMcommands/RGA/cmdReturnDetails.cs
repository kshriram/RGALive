using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PackingClassLibrary.CustomEntity.SMEntitys.RGA;

namespace PackingClassLibrary.Commands.SMcommands.RGA
{
   public class cmdReturnDetails
    {

       private Return _Return = new Return();
       /// <summary>
       /// This Method
       /// </summary>
       /// <returns></returns>
       /// 

       #region
       public Boolean DeleteAllTabledRecordsByReturnDetailID(Guid ReturnDetailID)
       {
           Boolean _return = false;
           try
           {
               _return = Service.DeleteRMA.ReturnDetailsallForeignKeyTables(ReturnDetailID);
               //_return = Service.DeleteRMA.ReasonsByReasonID(ReturnDetailID);
           }
           catch (Exception)
           { }
           return _return;
       }
       #endregion




       public List<ReturnDetail> ReturnDetailAll()
       {
           List<ReturnDetail> _lsreturn = new List<ReturnDetail>();
           try
           {
               var v = from ls in Service.GetRMA.ReturnDetailAll()
                       select ls;

               foreach (var Ritem in v)
               {
                   _lsreturn.Add(new ReturnDetail(Ritem));
               }
           }
           catch (Exception)
           { }
           return _lsreturn;
       }
        public List<ReturnDetail> ReturnDetailByretrnID(Guid RetunID)
        {
            List<ReturnDetail> _lsreturn = new List<ReturnDetail>();
            try
            {
                var v = from ls in Service.GetRMA.ReturnDetailByretrnID(RetunID)
                        select ls;

                foreach (var Ritem in v)
                {
                    _lsreturn.Add(new ReturnDetail(Ritem));
                }
            }
            catch (Exception)
            { }
            return _lsreturn;
        }

        public List<ReturnDetail> ReturnDetailByRetundetailID(Guid RetundetailID)
        {
            List<ReturnDetail> _lsreturn = new List<ReturnDetail>();
            try
            {
                var v = from ls in Service.GetRMA.ReturnDetailByRetundetailID(RetundetailID)
                        select ls;

                foreach (var Ritem in v)
                {
                    _lsreturn.Add(new ReturnDetail(Ritem));
                }
            }
            catch (Exception)
            { }
            return _lsreturn;
        }

        public List<ReturnDetail> ReturnDetailByRGADROWID(string RGADROWID)
        {
            List<ReturnDetail> _lsreturn = new List<ReturnDetail>();
            try
            {
                var v = from ls in Service.GetRMA.ReturnDetailByRGADROWID(RGADROWID)
                        select ls;

                foreach (var Ritem in v)
                {
                    _lsreturn.Add(new ReturnDetail(Ritem));
                }
            }
            catch (Exception)
            { }
            return _lsreturn;
        }

        public List<ReturnDetail> ReturnDetailByRGAROWID(string RGAROWID)
        {
            List<ReturnDetail> _lsreturn = new List<ReturnDetail>();
            try
            {
                var v = from ls in Service.GetRMA.ReturnDetailByRGAROWID(RGAROWID)
                        select ls;

                foreach (var Ritem in v)
                {
                    _lsreturn.Add(new ReturnDetail(Ritem));
                }
            }
            catch (Exception)
            { }
            return _lsreturn;
        }

        #region Set Method

        /// <summary>
        /// Update returndetail Table information.
        /// </summary>
        /// <param name="_lsreturn">
        /// pass return object as parameter.
        /// </param>
        /// <returns>
        /// return Bolean
        /// </returns>
        public Boolean UpdateReturnDetail(ReturnDetail _lsreturndetail)
        {
            Boolean _flag = false;
            try
            {
                _flag = Service.SetRMA.ReturnDetails(_lsreturndetail.ConvertToSaveDTO(_lsreturndetail));
            }
            catch (Exception)
            {
            }
            return _flag;

        }

        #endregion


        /// <summary>
        /// Check that SRnumber is already saved in databse or not.
        /// </summary>
        /// <param name="SRnumber">
        /// String SR Number
        /// </param>
        /// <returns>
        /// Boolean Value True is present else false.
        /// </returns>
        public Boolean IsPONumberAlreadyPresent(String PONumber)
        {
            Boolean _return = false;
            //RMA databse Object.
            try
            {
                List<Return> _lsReturn = new List<Return>();

                var lsponumber = Service.GetRMA.ReturnByPONumber(PONumber);

                foreach (var lsitem in lsponumber)
                {
                    _lsReturn.Add(new Return(lsitem));

                }
                if (_lsReturn.Count > 0)
                {
                    //String Anyvalue = _lsReturn[0].PONumber;
                    //if (Anyvalue == PONumber) _return = true;
                    _return = true;
                }
                //Check Decision is Always new.
                //  IsValidNumber = CanUserOpenThis();
                //Service.GetRMA.ReturnByPONumber;
            }
            catch (Exception ex)
            {
                // ex.LogThis("mReturnDetails/IsNumberAlreadyPresent");
            }
            return _return;

        }


        /// <summary>
        /// Check that SRnumber is already saved in databse or not.
        /// </summary>
        /// <param name="SRnumber">
        /// String SR Number
        /// </param>
        /// <returns>
        /// Boolean Value True is present else false.
        /// </returns>
        public Boolean IsSRNumberAlreadyPresent(String SRnumber)
        {
            Boolean _return = false;
            //RMA databse Object.
            try
            {
                _Return = new Return(Service.GetRMA.ReturnByRMANumber(SRnumber));
                String Anyvalue = _Return.RMANumber;
                if (Anyvalue == SRnumber) _return = true;

                //Check Decision is Always new.
                //  IsValidNumber = CanUserOpenThis();
            }
            catch (Exception ex)
            {
                // ex.LogThis("mReturnDetails/IsNumberAlreadyPresent");
            }
            return _return;

        }




    }
}
