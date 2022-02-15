using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_Models;
using Vasthu_DataAccess;

namespace Vastu_Business
{
    public class AboutContentBusinessLayer
    {
        private AboutContentDataAccess _AboutContentDataAccess { get; set; }

        public AboutContentBusinessLayer()
        {
            _AboutContentDataAccess = new AboutContentDataAccess();
        }

        public List<MasterAboutContent> GetHomeContent()
        {
            try
            {
                return _AboutContentDataAccess.GetHomeContent();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<MstrAboutContent> LoadDescription(int ContentID)
        {
            try
            {
                return _AboutContentDataAccess.LoadDescription(ContentID);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public int SaveContentInformation(SaveAboutContent obj)
        {
            int rsult = 0;
            try
            {

                List<MasterAboutContent> mastercontent = new List<MasterAboutContent>();
                //To check the selected id is available or not
                mastercontent = _AboutContentDataAccess.IsDataAvailable(obj);
                if (mastercontent.Count > 0)
                {
                    //Update
                    rsult = _AboutContentDataAccess.SaveContentInformation(obj, "Update");
                }
                else
                {
                    //Insert
                    rsult = _AboutContentDataAccess.SaveContentInformation(obj, "Insert");
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
                rsult = _AboutContentDataAccess.DeleteContentById(ContentID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return rsult;
        }
    }
}
