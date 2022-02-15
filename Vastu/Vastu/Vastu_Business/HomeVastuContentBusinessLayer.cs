using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_Models;
using Vasthu_DataAccess;

namespace Vastu_Business
{
    public class HomeVastuContentBusinessLayer
    {
        private HomeVastuContentDataAccess _HomeVastuContentDataAccess { get; set; }

        public HomeVastuContentBusinessLayer()
        {
            _HomeVastuContentDataAccess = new HomeVastuContentDataAccess();
        }

        public List<MasterHomeVastuContent> GetHomeContent()
        {
            try
            {
                return _HomeVastuContentDataAccess.GetHomeContent();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<MstrHomeVastuContent> LoadDescription(int ContentID)
        {
            try
            {
                return _HomeVastuContentDataAccess.LoadDescription(ContentID);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public int SaveContentInformation(SaveHomeVastuContent1 obj)
        {
            int rsult = 0;
            try
            {

                List<MasterHomeVastuContent> mastercontent = new List<MasterHomeVastuContent>();
                //To check the selected id is available or not
                mastercontent = _HomeVastuContentDataAccess.IsDataAvailable(obj);
                if (mastercontent.Count > 0)
                {
                    //Update
                    rsult = _HomeVastuContentDataAccess.SaveContentInformation(obj, "Update");
                }
                else
                {
                    //Insert
                    rsult = _HomeVastuContentDataAccess.SaveContentInformation(obj, "Insert");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return rsult;
        }

        public int DeleteContentById(int ContentID)
        {
            int rsult = 0;
            try
            {
                rsult = _HomeVastuContentDataAccess.DeleteContentById(ContentID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return rsult;
        }
    }
}
