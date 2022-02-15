using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_Models;
using Vasthu_DataAccess;

namespace Vastu_Business
{
    public class ContactBusinessLayer
    {
        private ContactDataAccess _ContactDataAccess { get; set; }

        public ContactBusinessLayer()
        {
            _ContactDataAccess = new ContactDataAccess();
        }

        // write your own business logic
        

        public List<MasterAboutContent> GetHomeContent()
        {
            try
            {
                return _ContactDataAccess.GetHomeContent();
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
                return _ContactDataAccess.LoadDescription(ContentID);
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
                mastercontent = _ContactDataAccess.IsDataAvailable(obj);
                if (mastercontent.Count > 0)
                {
                    //Update
                    rsult = _ContactDataAccess.SaveContentInformation(obj, "Update");
                }
                else
                {
                    //Insert
                    rsult = _ContactDataAccess.SaveContentInformation(obj, "Insert");
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
                rsult = _ContactDataAccess.DeleteContentById(ContentID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return rsult;
        }
    }
}
