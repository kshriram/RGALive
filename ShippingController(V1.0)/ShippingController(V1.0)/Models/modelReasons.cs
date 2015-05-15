using PackingClassLibrary.Commands.SMcommands.RGA;
using PackingClassLibrary.CustomEntity.SMEntitys.RGA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShippingController_V1._0_.Models
{
    public class modelReasons
    {
        cmdReasons cRtnreasons = new cmdReasons();

        cmdReasonCategory cCategoryReasons = new cmdReasonCategory();

        public List<Reason> GetAllReasons()
        {
            List<Reason> _lsReturn = new List<Reason>();
            _lsReturn = cRtnreasons.ReasonsAll();
            return _lsReturn;
        }


    }
}