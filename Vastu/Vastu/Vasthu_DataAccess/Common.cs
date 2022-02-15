using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Vasthu_DataAccess
{
    public class Common
    {
        public DateTime dt = DateTime.Now.AddMinutes(Convert.ToInt16(ConfigurationManager.AppSettings["TimeDiff"].ToString()));

    }
}
