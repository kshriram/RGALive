using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PackingClassLibrary.CustomEntity.SMEntitys.RGA;

namespace PackingClassLibrary.Commands.SMcommands.RGA
{
    public class cmdReasons
    {

       /// <summary>
       /// This Method is for Return List of Reasons.
       /// </summary>
       /// <returns>
       /// Return List of AllReasons.
       /// </returns>
       public List<Reason> ReasonsAll()
       {
           List<Reason> _lsResons = new List<Reason>();
           try
           {
               var resn = from ls in Service.GetRMA.ReasonsAll()
                          select ls;
               foreach (var Ritem in resn)
               {
                   _lsResons.Add(new Reason(Ritem));
               }
           }
           catch (Exception)
           { }
           return _lsResons;

       }

       /// <summary>
       /// This Methods For Get Reasons By CategoryName.
       /// </summary>
       /// <param name="CategoryName">
       /// CategoryName pass as parameter.
       /// </param>
       /// <returns>
       /// Return List of Reasons.
       /// </returns>

       

        public List<Reason> ReasonByCategoryName(string CategoryName)
        {
            List<Reason> _lsResons = new List<Reason>();
            try
            {
                var resn = from ls in Service.GetRMA.ReasonByCategoryName(CategoryName)
                           select ls;
                foreach (var Ritem in resn)
                {
                    _lsResons.Add(new Reason(Ritem));
                }
            }
            catch (Exception)
            { }
            return _lsResons;
        }

       /// <summary>
       /// This Method is for List of Reasons by ReturnDetailID.
       /// </summary>
       /// <param name="ReturnDetailID">
        /// ReturnDetailID pass as parameter.
       /// </param>
       /// <returns>
       /// Return List Of Reasons.
       /// </returns>
        public string ListOfReasons(Guid ReturnDetailID)
        {
            return Service.GetRMA.ListOfReasons(ReturnDetailID);
        }

       /// <summary>
       /// set SKUReasons In this method.
       /// </summary>
       /// <param name="Trans"></param>
       /// <returns></returns>
        public Boolean SetSKuReasons(SKUReason Trans)
        {
            Boolean _status = false;
            try
            {
                _status = Service.SetRMA.SKUReasons(Trans.CopyToSaveDTO(Trans));
            }
            catch (Exception)
            {

            }
            return _status;

        }


        public Boolean SetSKuReasons1(SKUReason Trans)
        {
            Boolean _status = false;
            try
            {
                _status = Service.SetRMA.SKUReasons1(Trans.CopyToSaveDTO(Trans));
            }
            catch (Exception)
            {

            }
            return _status;

        }

        public Boolean DeleteByReturnDetailID(Guid ReturnDetailID)
        {
            Boolean _return = false;
            try
            {
                _return = Service.DeleteRMA.DeleteBothReasonsByReturnDetails(ReturnDetailID);
            }
            catch (Exception)
            { }
            return _return;
        }


        public Boolean DeleteRecordByReturnDetailID(Guid ReturnDetailID)
        {
            Boolean _return = false;
            try
            {
                _return = Service.DeleteRMA.DeleteRecordByReturnDetails(ReturnDetailID);
            }
            catch (Exception)
            { }
            return _return;
        }


       /// <summary>
       /// upsert operation on Reason table.
       /// </summary>
       /// <param name="Resn">
       /// pass Reason to the function.
       /// </param>
       /// <returns>
       /// Return Boolean value.
       /// </returns>
        public Boolean UpsertReason(Reason Resn)
        {
            Boolean _status = false;
            try
            {
                _status = Service.SetRMA.Reasons(Resn.CopyToSaveDTO(Resn));
            }
            catch (Exception)
            {

            }
            return _status;

        }

       /// <summary>
       /// This Method is for GetReasons By ReturnDetialID
       /// </summary>
       /// <param name="ReturnDetailsID">
        /// pass ReturnDetailsID as paramater.
       /// </param>
       /// <returns>
       /// Return List of Reasons.
       /// </returns>
        public List<Reason> GetReasonsByReturnDetailID(Guid ReturnDetailsID)
        {
            List<Reason> lsReasons = new List<Reason>();
            try
            {
                var Resns = Service.GetRMA.ReasonsByReturnDetailID(ReturnDetailsID);
                foreach (var Ritem in Resns)
                {
                    lsReasons.Add(new Reason(Ritem));
                }
            }
            catch (Exception)
            { }
            return lsReasons;
        }

        public Boolean DeleteByReasonID(Guid ReasonID)
        {
            Boolean _return = false;
            try
            {
                _return = Service.DeleteRMA.ReasonsByReasonID(ReasonID);
            }
            catch (Exception)
            { }
            return _return;
        }


        public string GetReasonsInStringByReturnDetailID(Guid ReturnDetailID)
        {
            return Service.GetRMA.ListOfReasons(ReturnDetailID);
        }

        public string GetReasonstringByReturnDetailID(Guid ReturnDetailID)
        {
            return Service.GetRMA.ListOfReasons(ReturnDetailID);
        }

      
    }
}
