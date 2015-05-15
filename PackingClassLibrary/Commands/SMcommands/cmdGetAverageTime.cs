using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects;
using System.Data.Linq.SqlClient;
using System.Data.Objects.SqlClient;
namespace PackingClassLibrary.Commands
{
    public class cmdGetAverageTime 
    {
        Guid _userId;
        public cmdGetAverageTime(Guid userId)
        {
            _userId = userId;
        }

        public  List<KeyValuePair<string, float>> Execute()
        {
            return Service.Get.Execute(_userId).ToList();
        }
    }    
}
