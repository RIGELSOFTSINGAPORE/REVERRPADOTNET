using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_Models;
using Vasthu_DataAccess;

namespace Vastu_Business
{
    public class ContactContentBusinessLayer
    {
        private ContactContentDataAccess _ContactContentDataAccess { get; set; }
        public ContactContentBusinessLayer()
        {
            _ContactContentDataAccess = new ContactContentDataAccess();
        }
        public List<MasterContent> GetHomePageInformation()
        {

            try
            {
                return _ContactContentDataAccess.GetHomePageInformation();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
