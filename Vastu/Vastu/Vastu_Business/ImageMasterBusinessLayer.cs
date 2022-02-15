using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_DataAccess;
using Vasthu_Models;

namespace Vastu_Business
{
    public class ImageMasterBusinessLayer
    {
        private ImageMasterDataAccess _ImageMasterDataAccess { get; set; }
        public ImageMasterBusinessLayer()
        {
            _ImageMasterDataAccess = new ImageMasterDataAccess();
        }

        public List<VS_IMAGE_MST> GetAllImage()
        {
            List<VS_IMAGE_MST> obj = new List<VS_IMAGE_MST>();
            try
            {



                obj = _ImageMasterDataAccess.GetAllImage();


            }
            catch (Exception ex)
            {
                throw ex;
                

            }
            return obj;
        }
        public List<VS_IMAGE_MST> GetAllImageList()
        {
            List<VS_IMAGE_MST> obj = new List<VS_IMAGE_MST>();
            try
            {



                obj = _ImageMasterDataAccess.GetAllImageList();


            }
            catch (Exception ex)
            {
                throw ex;
                

            }
            return obj;
        }
        
        public VS_IMAGE_MST GetImageByID(int imageID)
        {
            VS_IMAGE_MST obj = new VS_IMAGE_MST();
            try
            {


                obj = _ImageMasterDataAccess.GetImageByID(imageID);

            }
            catch (Exception ex)
            {
                throw ex;
                
            }
            return obj;


        }

        public int CreateImage(VS_IMAGE_MST imagermst)
        {
            int result = 0;
            try
            {
                List<VS_IMAGE_MST> imgmst = new List<VS_IMAGE_MST>();

                imgmst = _ImageMasterDataAccess.CheckImageDetail(imagermst.IMAGE_DETAILS, 0);

                if (imgmst.Count > 0)
                {
                    result = 16;
                    return result;
                }


                result = _ImageMasterDataAccess.CreateImage(imagermst);
            }
            catch (Exception ex)
            {
                throw ex;
             
            }
            return result;
        }

        public int UpdateImage(VS_IMAGE_MST imagermst)
        {
            int result = 0;
            try
            {
                List<VS_IMAGE_MST> imgmst = new List<VS_IMAGE_MST>();

                imgmst = _ImageMasterDataAccess.CheckImageDetail(imagermst.IMAGE_DETAILS, imagermst.IMAGE_ID);

                if (imgmst.Count > 0)
                {
                    result = 16;
                    return result;
                }

                result = _ImageMasterDataAccess.UpdateImage(imagermst);

            }
            catch (Exception ex)
            {
                throw ex;
              
            }
            return result;
        }
    }
}
