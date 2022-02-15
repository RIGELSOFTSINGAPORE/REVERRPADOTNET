using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_DataAccess;
using Vasthu_Models;

namespace Vastu_Business
{
  
    public class StatusMasterBusinessLayer
    {
        private StatusMasterDataAccess _StatusMasterDataAccess { get; set; }
        public StatusMasterBusinessLayer()
        {
            _StatusMasterDataAccess = new StatusMasterDataAccess();
        }

        public List<VS_STATUS_MST> GetAllStatus()
        {
            List<VS_STATUS_MST> obj = new List<VS_STATUS_MST>();
            try
            {

                obj = _StatusMasterDataAccess.GetAllStatus();

            }
            catch (Exception ex)
            {
                throw ex;


            }
            return obj;
        }
    
        
        public VS_STATUS_MST GetStatusByID(int statusID)
        {
            VS_STATUS_MST obj = new VS_STATUS_MST();
            try
            {

                obj = _StatusMasterDataAccess.GetStatusByID(statusID);

            }
            catch (Exception ex)
            {
                throw ex;
             
            }
            return obj;


        }

        public int CreateStatus(VS_STATUS_MST statusmst)
        {
            int result = 0;
            try
            {
                List<VS_STATUS_MST> smst = new List<VS_STATUS_MST>();

                smst = _StatusMasterDataAccess.CheckstatusDetail(statusmst.STATUS, 0);

                if (smst.Count > 0)
                {
                    result = 16;
                    return result;
                }


                result = _StatusMasterDataAccess.CreateStatus(statusmst);
            }
            catch (Exception ex)
            {
                throw ex;
   
            }
            return result;
        }

        public int UpdateStatus(VS_STATUS_MST statusmst)
        {
            int result = 0;
            try
            {
                List<VS_STATUS_MST> smst = new List<VS_STATUS_MST>();

                smst = _StatusMasterDataAccess.CheckstatusDetail(statusmst.STATUS, statusmst.STATUS_ID);

                if (smst.Count > 0)
                {
                    result = 16;
                    return result;
                }

                result = _StatusMasterDataAccess.UpdateStatus(statusmst);

            }
            catch (Exception ex)
            {
                throw ex;
   
            }
            return result;
        }
    }
}
