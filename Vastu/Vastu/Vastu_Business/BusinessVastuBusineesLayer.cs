using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_Models;
using Vasthu_DataAccess;

namespace Vastu_Business
{
    public class BusinessVastuBusineesLayer
    {
        private BusinessVastuDataAccess _BusinessVastuDataAccess { get; set; }

        public BusinessVastuBusineesLayer()
        {
            _BusinessVastuDataAccess = new BusinessVastuDataAccess();
        }

        // write your own business logic
        public void Test()
        {

            try
            {
                _BusinessVastuDataAccess.Test();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
