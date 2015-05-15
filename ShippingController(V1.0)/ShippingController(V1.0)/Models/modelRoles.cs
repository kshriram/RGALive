using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShippingController_V1._0_.Models
{
    public class modelRoles
    {
        /// <summary>
        /// String split by charactor in permission set on the action Veriable
        /// </summary>
        /// <param name="Action">
        /// string Permission set
        /// </param>
        /// <returns>
        /// String permission set
        /// </returns>
        public String ActionString(String Action)
        {
            string _return="";
            try
            {
                String[] Permission = Action.Split('-', '&');
                //User Permission
                _return = _return + "Super User=";
                if (!Convert.ToBoolean(Permission[0].ToString()) || !Convert.ToBoolean(Permission[1].ToString()) || !Convert.ToBoolean(Permission[2].ToString()) || !Convert.ToBoolean(Permission[3].ToString()))
                    _return = _return + " No";
               else if (Convert.ToBoolean(Permission[0].ToString()) && Convert.ToBoolean(Permission[1].ToString()) && Convert.ToBoolean(Permission[2].ToString()) && Convert.ToBoolean(Permission[3].ToString()))
                    _return = _return + " Yes";

                //Shipment permission
                _return = _return + " | Shipment Permission=";
                if (Convert.ToBoolean(Permission[4].ToString()))
                    _return = _return + " View";
                if (Convert.ToBoolean(Permission[5].ToString()))
                    _return = _return + ", Scan";
                if (Convert.ToBoolean(Permission[6].ToString()))
                    _return = _return + ", ReScan";
                if (Convert.ToBoolean(Permission[7].ToString()))
                    _return = _return + ", Override";
            }
            catch (Exception)
            {}
            return _return;
        }


        /// <summary>
        /// Chech that the role is of super user or not.
        /// </summary>
        /// <param name="RoleID">
        /// note that String RoleID not GUID.
        /// </param>
        /// <returns>
        /// Boolean True Or False.
        /// </returns>
        public Boolean IsSuperUser(String RoleID)
        {
            Boolean _return = true;
            try
            {
                Guid Rl = Guid.Parse(RoleID);
                String Action = Obj.call.GetRole().FirstOrDefault(i => i.RoleId == Rl).Action;

                String[] IsSuper = Action.Split('&')[0].Split('-');

                foreach (String s in IsSuper)
                {
                    if (s.ToUpper()=="FALSE")
                    {
                        _return = false;
                        break;
                    }
                }

            }
            catch (Exception)
            {}
            return _return;
        }

        /// <summary>
        /// Chech that this permission is avilable or not ;
        /// </summary>
        /// <param name="PermissionType">
        /// String view/Scan/ReScan/Override on of these
        /// </param>
        /// <param name="RoleID">
        /// String RoleID Note that ROle id is String not Guid
        /// </param>
        /// <returns>
        /// Boolean True Or flase.
        /// </returns>
        public Boolean IsPermisson(String PermissionType, String RoleID)
        {
            Boolean _return = true;
            try
            {
                Guid Rl = Guid.Parse(RoleID);
                String Action = Obj.call.GetRole().FirstOrDefault(i => i.RoleId == Rl).Action;

                String[] IsSuper = Action.Split('&')[1].Split('-');

                switch (PermissionType.ToUpper())
                {
                    case "VIEW":
                        if (IsSuper[0].ToUpper() == "FALSE")
                            _return = false;
                        break;
                    case "SCAN":
                         if (IsSuper[1].ToUpper() == "FALSE")
                            _return = false;
                        break;
                    case "RESCAN":
                        if (IsSuper[2].ToUpper() == "FALSE")
                            _return = false;
                        break;
                    case "OVERRIDE":
                        if (IsSuper[3].ToUpper() == "FALSE")
                            _return = false;
                        break;
                    default :
                        break;
                }

                
            }
            catch (Exception)
            { }
            return _return;
        }


        

        
    }

    
}