using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_Models;
using Vasthu_DataAccess;
namespace Vastu_Business
{
    public class HomeContentBusinessLayer
    {
        private HomeContentDataAccess _HomeContentDataAccess { get; set; }
        public HomeContentBusinessLayer()
        {
            _HomeContentDataAccess = new HomeContentDataAccess();
        }
        public List<MasterContent> GetHomeContent()
        {
            try
            {
               return _HomeContentDataAccess.GetHomeContent();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<MstrContent> LoadDescription(int ContentID)
        {
            try
            {
                return _HomeContentDataAccess.LoadDescription(ContentID);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public int SaveContentInformation(SaveContent obj)
        {
            int rsult = 0;
            try
            {

                List<MasterContent> mastercontent = new List<MasterContent>();
                //To check the selected id is available or not
                mastercontent= _HomeContentDataAccess.IsDataAvailable(obj);
                if(mastercontent.Count>0)
                {
                    //Update
                    rsult = _HomeContentDataAccess.SaveContentInformation(obj, "Update");
                }
                else
                {
                    //Insert
                    rsult= _HomeContentDataAccess.SaveContentInformation(obj,"Insert");
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
                rsult = _HomeContentDataAccess.DeleteContentById(ContentID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return rsult;
        }

    }
}
