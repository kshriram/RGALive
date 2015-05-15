using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShippingController_V1._0_.Views
{
    public class cstDspErrorLog
    {
        public Guid ErrorID { get; set; }
        public string ErrorDescription { get; set; }
        public string ErrorLocation { get; set; }
        public string UserName { get; set; }
        public DateTime ErrorDate { get; set; }
    }
}