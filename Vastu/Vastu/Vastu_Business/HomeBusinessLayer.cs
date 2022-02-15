using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_Models;
using Vasthu_DataAccess;

namespace Vastu_Business
{
    public class HomeBusinessLayer
    {
        private HomeDataAccess _HomeDataAccess { get; set; }

        public HomeBusinessLayer()
        {
            _HomeDataAccess = new HomeDataAccess();
        }

        // write your own business logic
        public List<MasterContent> GetHomePageInformation()
        {

            try
            {
              return  _HomeDataAccess.GetHomePageInformation();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
            
        }
    }
}
