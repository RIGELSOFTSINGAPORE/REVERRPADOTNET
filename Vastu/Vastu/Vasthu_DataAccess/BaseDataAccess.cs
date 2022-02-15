using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vasthu_DataAccess
{
   public abstract class BaseDataAccess
    {
        private AdoHelper _AdoHelper { get; set; }
        public AdoHelper AdoHelper {
            get {
                return _AdoHelper; 
            }
           
        }
        public BaseDataAccess()
        {
            _AdoHelper = new AdoHelper(ConfigurationManager.ConnectionStrings["Vastu"].ConnectionString);
            
        }
    }
}
