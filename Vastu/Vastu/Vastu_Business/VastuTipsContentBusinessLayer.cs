using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_Models;
using Vasthu_DataAccess;
namespace Vastu_Business
{
    public class VastuTipsContentBusinessLayer
    {
        private VastuTipsContentDataAccess _VastuTipsContentDataAccess { get; set; }

        public VastuTipsContentBusinessLayer()
        {
            _VastuTipsContentDataAccess = new VastuTipsContentDataAccess();
        }

        public List<MasterVastuTipsContent> GetHomeContent()
        {
            try
            {
                return _VastuTipsContentDataAccess.GetHomeContent();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<MstrVastuTipsContent> LoadDescription(int ContentID)
        {
            try
            {
                return _VastuTipsContentDataAccess.LoadDescription(ContentID);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public int SaveContentInformation(SaveVastuTipsContent obj)
        {
            int rsult = 0;
            try
            {

                List<MasterVastuTipsContent> MasterVastuTipsContent = new List<MasterVastuTipsContent>();
                //To check the selected id is available or not
                MasterVastuTipsContent = _VastuTipsContentDataAccess.IsDataAvailable(obj);
                if (MasterVastuTipsContent.Count > 0)
                {
                    //Update
                    rsult = _VastuTipsContentDataAccess.SaveContentInformation(obj, "Update");
                }
                else
                {
                    //Insert
                    rsult = _VastuTipsContentDataAccess.SaveContentInformation(obj, "Insert");
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
                rsult = _VastuTipsContentDataAccess.DeleteContentById(ContentID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return rsult;
        }
    }
}
