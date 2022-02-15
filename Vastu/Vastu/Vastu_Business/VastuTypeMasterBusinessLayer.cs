using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_DataAccess;
using Vasthu_Models;

namespace Vastu_Business
{
  
    public class VastuTypeMasterBusinessLayer
    {
        private VastuTypeMasterDataAccess _VastuTypeMasterDataAccess { get; set; }
        public VastuTypeMasterBusinessLayer()
        {
            _VastuTypeMasterDataAccess = new VastuTypeMasterDataAccess();
        }

        public List<VS_VASTU_TYPE_MST> GetAllVastuType()
        {
            List<VS_VASTU_TYPE_MST> obj = new List<VS_VASTU_TYPE_MST>();
            try
            {

                obj = _VastuTypeMasterDataAccess.GetAllVastuType();

            }
            catch (Exception ex)
            {
                throw ex;


            }
            return obj;
        }
    
        
        public VS_VASTU_TYPE_MST GetVastuTypeByID(int vastutypeID)
        {
            VS_VASTU_TYPE_MST obj = new VS_VASTU_TYPE_MST();
            try
            {

                obj = _VastuTypeMasterDataAccess.GetVastuTypeByID(vastutypeID);

            }
            catch (Exception ex)
            {
                throw ex;
             
            }
            return obj;


        }

        public int CreateVastuType(VS_VASTU_TYPE_MST vastutypemst)
        {
            int result = 0;
            try
            {
                List<VS_VASTU_TYPE_MST> vtmst = new List<VS_VASTU_TYPE_MST>();

                vtmst = _VastuTypeMasterDataAccess.CheckVastuTypeDetail(vastutypemst.VASTU_TYPE, 0);

                if (vtmst.Count > 0)
                {
                    result = 16;
                    return result;
                }


                result = _VastuTypeMasterDataAccess.CreateVastuType(vastutypemst);
            }
            catch (Exception ex)
            {
                throw ex;
   
            }
            return result;
        }

        public int UpdateVastuType(VS_VASTU_TYPE_MST vastutypemst)
        {
            int result = 0;
            try
            {
                List<VS_VASTU_TYPE_MST> vtmst = new List<VS_VASTU_TYPE_MST>();

                vtmst = _VastuTypeMasterDataAccess.CheckVastuTypeDetail(vastutypemst.VASTU_TYPE, vastutypemst.VASTU_TYPE_ID);

                if (vtmst.Count > 0)
                {
                    result = 16;
                    return result;
                }

                result = _VastuTypeMasterDataAccess.UpdateVastuType(vastutypemst);

            }
            catch (Exception ex)
            {
                throw ex;
   
            }
            return result;
        }
    }
}
