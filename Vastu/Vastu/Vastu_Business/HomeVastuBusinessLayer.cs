using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_Models;
using Vasthu_DataAccess;

namespace Vastu_Business
{
    public class HomeVastuBusinessLayer
    {
        private HomeVastuDataAccess _HomeVastuDataAccess { get; set; }

        public HomeVastuBusinessLayer()
        {
            _HomeVastuDataAccess = new HomeVastuDataAccess();
        }

        // write your own business logic
        public List<MasterHomeVastuContent> GetHomeVastuInformation()
        {
            try
            {
               return _HomeVastuDataAccess.GetHomeVastuInformation();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
