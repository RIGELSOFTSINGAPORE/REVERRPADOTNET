using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_DataAccess;
using Vasthu_Models;

namespace Vastu_Business
{
    public class AreaMasterTranDtlBusinessLayer
    {
        private AreaMasterTranDtlDataAccess _AreaMasterTranDtlDataAccess { get; set; }
        public AreaMasterTranDtlBusinessLayer()
        {
            _AreaMasterTranDtlDataAccess = new AreaMasterTranDtlDataAccess();
        }


        public List<VS_AREA_MST_TRAN_DETAILS> GetAllAreaTranDtl()
        {
            List<VS_AREA_MST_TRAN_DETAILS> obj = new List<VS_AREA_MST_TRAN_DETAILS>();
            try
            {



                obj = _AreaMasterTranDtlDataAccess.GetAllAreaTranDtl();


            }
            catch (Exception ex)
            {
                throw ex;


            }
            return obj;
        }

        public VS_AREA_MST_TRAN_DETAILS GetAllAreaTranDtlByID(int amTrnID)
        {
            VS_AREA_MST_TRAN_DETAILS obj = new VS_AREA_MST_TRAN_DETAILS();
            try
            {


                obj = _AreaMasterTranDtlDataAccess.GetAllAreaTranDtlByID(amTrnID);

            }
            catch (Exception ex)
            {
                throw ex;

            }
            return obj;


        }
    }
}
