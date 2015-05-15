using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackingClassLibrary.CustomEntity;
using System.IO;

namespace PackingClassLibrary.Commands
{
   public class cmdErrorLog
    {
     //  local_x3v6Entities entX3v6 = new local_x3v6Entities();

       #region Set Fucntions
       /// <summary>
       /// Save Error log
       /// </summary>
       /// <param name="lsErrorlog">detail error log info</param>
       /// <returns>Boolean Value</returns>
       public Boolean SaveLog(List<cstErrorLog> lsErrorlog)
       {
           Boolean _return = false;
           try
           {
               if (lsErrorlog.Count > 0)
               {
                   foreach (var _Erroritem in lsErrorlog)
                   {
                       SetService.ErrorLogDTO _errorCustom = new SetService.ErrorLogDTO();
                       _errorCustom.ErrorlogID = Guid.NewGuid();
                       _errorCustom.ErrorLocation = _Erroritem.ErrorLocation;
                       _errorCustom.ErrorDesc = _Erroritem.ErrorDesc;
                       _errorCustom.ErrorTime = Convert.ToDateTime(_Erroritem.ErrorTime);
                       _errorCustom.UserID = _Erroritem.UserID;

                       List<SetService.ErrorLogDTO> lserror = new List<SetService.ErrorLogDTO>();
                       lserror.Add(_errorCustom);
                       var v = lserror.ToArray();
                       bool r = Service.Set.ErrorLog(v);
                       _return = true;
                   }
               }
           }
           catch (Exception)
           {
               ///Save the Exeption to the File Name Bellow
               String[] Lines = { "", "" }; ;
               Lines[0] = Environment.NewLine + "------------------------------------------------" + DateTime.UtcNow + "------------------------------------------------";
               Lines[1] = "Internet Connection Fail == " + lsErrorlog[0].ErrorLocation.ToString() + " == " + DateTime.UtcNow;
               File.AppendAllLines("C:\\ShipmentManagerErrorLog.sys", Lines);
           }
           return _return;
       }
       #endregion

       #region Get Functions.
       /// <summary>
       /// Get All error Log Table information.
       /// </summary>
       /// <returns>list og cstErrorLog Table.</returns>
       public List<cstErrorLog> GetErrorLogAll()
       {
           List<cstErrorLog> lsError = new List<cstErrorLog>();
           try
           {
               var v = from _error in Service.Get.ErrorLogAll() select _error;
               foreach (var Vitem in v)
               {
                   cstErrorLog _error = new cstErrorLog();
                   _error.ErrorLogID = Vitem.ErrorlogID;
                   _error.ErrorDesc = Vitem.ErrorDesc;
                   _error.ErrorLocation = Vitem.ErrorLocation;
                   _error.ErrorTime = Convert.ToDateTime(Vitem.ErrorTime);
                   Guid Userid = (Guid)Vitem.UserID;
                   _error.UserID = Userid;
                   lsError.Add(_error);
               }
           }
           catch (Exception)
           { }
           return lsError;
       }
       #endregion
    }
}
