using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Vasthu_Models
{
    public static class CompareAreaDirection
    {
        public static bool JsonCompare(this object obj, object another)
        {
            //if (ReferenceEquals(obj, another)) return true;
            //if ((obj == null) || (another == null)) return false;
            //if (obj.GetType() != another.GetType()) return false;

            var objJson = JsonConvert.SerializeObject(obj);
            var anotherJson = JsonConvert.SerializeObject(another);

            return objJson == anotherJson;
        }
    }

}


    