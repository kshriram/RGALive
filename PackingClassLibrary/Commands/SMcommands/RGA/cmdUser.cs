using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PackingClassLibrary.CustomEntity.SMEntitys.RGA;

namespace PackingClassLibrary.Commands.SMcommands.RGA
{
    public class cmdUserforRGA
    {
        public UserMaster UserInfoByUserID(Guid UserID)
        {
            //return new UserMaster(Service.GetRMA.UserByUserID(UserID));
            UserMaster _lsUserReturn = new UserMaster();
            try
            {
                _lsUserReturn = new UserMaster(Service.GetRMA.UserAll().FirstOrDefault(i => i.UserID == UserID));
            }
            catch (Exception)
            {
               // ex.LogThis("cmdUser/GetUserTbl(Guid Userid)");
            }
            return _lsUserReturn;
        }
    }
}
