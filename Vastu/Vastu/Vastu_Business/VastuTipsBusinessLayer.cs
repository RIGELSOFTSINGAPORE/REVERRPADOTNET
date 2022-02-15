using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_Models;
using Vasthu_DataAccess;

namespace Vastu_Business
{
    public class VastuTipsBusinessLayer
    {
        private VastuTipsDataAccess _VastuTipsDataAccess { get; set; }

        public VastuTipsBusinessLayer()
        {
            _VastuTipsDataAccess = new VastuTipsDataAccess();
        }

        // write your own business logic
        public List<MasterVastuTipsContent> GetVastuTipsInformation()
        {

            try
            {
                return _VastuTipsDataAccess.GetVastuTipsInformation();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
