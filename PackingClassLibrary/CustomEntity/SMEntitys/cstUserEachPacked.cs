using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackingClassLibrary.CustomEntity.SMEntitys
{
    public class cstUserEachPacked
    {
        public Guid UserID { get; set; }
        public String UserName { get; set; }
        public int TotalPacked { get; set; }
        public int PartiallyPacked { get; set; }
    }
}
