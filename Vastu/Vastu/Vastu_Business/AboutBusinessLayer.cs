using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_Models;
using Vasthu_DataAccess;

namespace Vastu_Business
{
    public class AboutBusinessLayer
    {
        private AboutDataAccess _AboutDataAccess { get; set; }

        public AboutBusinessLayer()
        {
            _AboutDataAccess = new AboutDataAccess();
        }

        // write your own business logic
        public List<MasterAboutContent> GetAboutPageInformation()
        {

            try
            {
                return _AboutDataAccess.GetAboutPageInformation();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
