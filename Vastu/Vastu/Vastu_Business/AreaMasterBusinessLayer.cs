using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_DataAccess;
using Vasthu_Models;

namespace Vastu_Business
{
    
    public class AreaMasterBusinessLayer
    {
        private AreaMasterDataAccess _AreaMasterDataAccess { get; set; }
        public AreaMasterBusinessLayer()
        {
            _AreaMasterDataAccess = new AreaMasterDataAccess();
        }

        public List<VS_AREA_MST> GetAllArea()
        {
            List<VS_AREA_MST> obj = new List<VS_AREA_MST>();
            try
            {

                obj = _AreaMasterDataAccess.GetAllArea();

            }
            catch (Exception ex)
            {
                throw ex;


            }
            return obj;
        }
    
        
        public VS_AREA_MST GetAreaByID(int areaID)
        {
            VS_AREA_MST obj = new VS_AREA_MST();
            try
            {

                obj = _AreaMasterDataAccess.GetAreaByID(areaID);

            }
            catch (Exception ex)
            {
                throw ex;
             
            }
            return obj;


        }

        public int CreateArea(VS_AREA_MST areamst)
        {
            int result = 0;
            try
            {
                List<VS_AREA_MST> amst = new List<VS_AREA_MST>();

                amst = _AreaMasterDataAccess.CheckAreaDetail(areamst.AREA, 0);

                if (amst.Count > 0)
                {
                    result = 16;
                    return result;
                }


                result = _AreaMasterDataAccess.CreateArea(areamst);
            }
            catch (Exception ex)
            {
                throw ex;
   
            }
            return result;
        }

        public int UpdateArea(VS_AREA_MST areamst)
        {
            int result = 0;
            try
            {
                List<VS_AREA_MST> amst = new List<VS_AREA_MST>();

                amst = _AreaMasterDataAccess.CheckAreaDetail(areamst.AREA, areamst.AREA_ID);

                if (amst.Count > 0)
                {
                    result = 16;
                    return result;
                }

                result = _AreaMasterDataAccess.UpdateArea(areamst);

            }
            catch (Exception ex)
            {
                throw ex;
   
            }
            return result;
        }
    }
}
