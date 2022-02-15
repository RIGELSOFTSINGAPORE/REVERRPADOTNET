using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_DataAccess;
using Vasthu_Models;

namespace Vastu_Business
{
    
    public class ContentMasterBusinessLayer
    {
        private ContentMasterDataAccess _ContentMasterDataAccess { get; set; }
        public ContentMasterBusinessLayer()
        {
            _ContentMasterDataAccess = new ContentMasterDataAccess();
        }

        public List<VS_CONTENT_MST> GetAllContent()
        {
            List<VS_CONTENT_MST> obj = new List<VS_CONTENT_MST>();
            try
            {

                obj = _ContentMasterDataAccess.GetAllContent();

            }
            catch (Exception ex)
            {
                throw ex;


            }
            return obj;
        }
    
        
        public VS_CONTENT_MST GetContentByID(int contentID)
        {
            VS_CONTENT_MST obj = new VS_CONTENT_MST();
            try
            {

                obj = _ContentMasterDataAccess.GetContentByID(contentID);

            }
            catch (Exception ex)
            {
                throw ex;
             
            }
            return obj;


        }

        public int CreateContent(VS_CONTENT_MST contentmst)
        {
            int result = 0;
            try
            {
                List<VS_CONTENT_MST> cmst = new List<VS_CONTENT_MST>();

                cmst = _ContentMasterDataAccess.CheckContentDetail(contentmst.CONTENT_NAME, 0);

                if (cmst.Count > 0)
                {
                    result = 16;
                    return result;
                }


                result = _ContentMasterDataAccess.CreateContent(contentmst);
            }
            catch (Exception ex)
            {
                throw ex;
   
            }
            return result;
        }

        public int UpdateContent(VS_CONTENT_MST contentmst)
        {
            int result = 0;
            try
            {
                List<VS_CONTENT_MST> cmst = new List<VS_CONTENT_MST>();

                cmst = _ContentMasterDataAccess.CheckContentDetail(contentmst.CONTENT_NAME, contentmst.CONTENT_ID);

                if (cmst.Count > 0)
                {
                    result = 16;
                    return result;
                }

                result = _ContentMasterDataAccess.UpdateContent(contentmst);

            }
            catch (Exception ex)
            {
                throw ex;
   
            }
            return result;
        }
    }
}
