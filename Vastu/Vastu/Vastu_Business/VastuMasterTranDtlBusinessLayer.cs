using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_DataAccess;
using Vasthu_Models;

namespace Vastu_Business
{
    public class VastuMasterTranDtlBusinessLayer
    {
        private VastuMasterTranDtlDataAccess _VastuMasterTranDtlDataAccess { get; set; }
        public VastuMasterTranDtlBusinessLayer()
        {
            _VastuMasterTranDtlDataAccess = new VastuMasterTranDtlDataAccess();
        }


        public List<VS_VASTU_MST_TRAN_DETAILS> GetAllVastuTranDtl()
        {
            List<VS_VASTU_MST_TRAN_DETAILS> obj = new List<VS_VASTU_MST_TRAN_DETAILS>();
            try
            {



                obj = _VastuMasterTranDtlDataAccess.GetAllVastuTranDtl();


            }
            catch (Exception ex)
            {
                throw ex;


            }
            return obj;
        }

        public VS_VASTU_MST_TRAN_DETAILS GetAllVastuTranDtlByID(int vmTrnID)
        {
            VS_VASTU_MST_TRAN_DETAILS obj = new VS_VASTU_MST_TRAN_DETAILS();
            try
            {


                obj = _VastuMasterTranDtlDataAccess.GetAllVastuTranDtlByID(vmTrnID);

            }
            catch (Exception ex)
            {
                throw ex;

            }
            return obj;


        }
    }
}
