using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_DataAccess;
using Vasthu_Models;

namespace Vastu_Business
{
   
    public class DirectionMasterBusinessLayer
    {
        private DirectionMasterDataAccess _DirectionMasterDataAccess { get; set; }
        public DirectionMasterBusinessLayer()
        {
            _DirectionMasterDataAccess = new DirectionMasterDataAccess();
        }

        public List<VS_DIRECTION_MST> GetAllDirection()
        {
            List<VS_DIRECTION_MST> obj = new List<VS_DIRECTION_MST>();
            try
            {

                obj = _DirectionMasterDataAccess.GetAllDirection();

            }
            catch (Exception ex)
            {
                throw ex;


            }
            return obj;
        }
    
        
        public VS_DIRECTION_MST GetDirectionByID(int directionID)
        {
            VS_DIRECTION_MST obj = new VS_DIRECTION_MST();
            try
            {

                obj = _DirectionMasterDataAccess.GetDirectionByID(directionID);

            }
            catch (Exception ex)
            {
                throw ex;
             
            }
            return obj;


        }

        public int CreateDirection(VS_DIRECTION_MST directionmst)
        {
            int result = 0;
            try
            {
                List<VS_DIRECTION_MST> dmst = new List<VS_DIRECTION_MST>();

                dmst = _DirectionMasterDataAccess.CheckDirectionDetail(directionmst.DIRECTION, 0);

                if (dmst.Count > 0)
                {
                    result = 16;
                    return result;
                }


                result = _DirectionMasterDataAccess.CreateDirection(directionmst);
            }
            catch (Exception ex)
            {
                throw ex;
   
            }
            return result;
        }

        public int UpdateDirection(VS_DIRECTION_MST directionmst)
        {
            int result = 0;
            try
            {
                List<VS_DIRECTION_MST> dmst = new List<VS_DIRECTION_MST>();

                dmst = _DirectionMasterDataAccess.CheckDirectionDetail(directionmst.DIRECTION, directionmst.DIRECTION_ID);

                if (dmst.Count > 0)
                {
                    result = 16;
                    return result;
                }

                result = _DirectionMasterDataAccess.UpdateDirection(directionmst);

            }
            catch (Exception ex)
            {
                throw ex;
   
            }
            return result;
        }
    }
}
