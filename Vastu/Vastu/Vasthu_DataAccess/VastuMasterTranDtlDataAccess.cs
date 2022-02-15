using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_Models;
using System.Data;
using System.Data.SqlClient;
using Vasthu_DataAccess;

namespace Vasthu_DataAccess
{
    public class VastuMasterTranDtlDataAccess : BaseDataAccess
    {
        private string VMTranDtlQuery(int vmTrnID)
        {
            string strcmd = "";
            strcmd += "Select * from ";
            strcmd += " ( ";
            strcmd += "select VASTU_MST_TRAN_ID,VASTU_TYPE,AREA,DIRECTION,COLUMN_NAME,";
            strcmd += "convert(varchar,OLD_SCORE_VALUE) OLD_VALUE,";
            strcmd += "convert(varchar,NEW_SCORE_VALUE) NEW_VALUE,LOGIN_NAME C_USER,";
            strcmd += "TVM.CREATED_DATE C_DATE  ";
            strcmd += "from [dbo].[VS_VASTU_MST_TRAN_DETAILS] TVM";
            strcmd += " left Join VS_USER_MST UM on TVM.CREATED_USER = UM.USER_ID";
            strcmd += " where COLUMN_NAME in (N'点数',N'追加点')";
            strcmd += " UNION ";
            strcmd += " select VASTU_MST_TRAN_ID,VASTU_TYPE,AREA,DIRECTION,COLUMN_NAME, ";
            strcmd += " '-'  OLD_VALUE,case OLD_DESCRIPTION_VALUE  when N'新しく作成された' then N'新しく作成されました' when N'削除された' then  N'削除されました' else N'修正されました' end NEW_VALUE, ";
            strcmd += " LOGIN_NAME C_USER,TVM.CREATED_DATE C_DATE ";
            strcmd += " from [dbo].[VS_VASTU_MST_TRAN_DETAILS] TVM ";
            strcmd += " left Join VS_USER_MST UM on TVM.CREATED_USER = UM.USER_ID ";
            strcmd += " where COLUMN_NAME in (N'簡単な説明',N'長い説明') ";
            strcmd += " UNION ";
            strcmd += " select VASTU_MST_TRAN_ID,VASTU_TYPE,AREA,DIRECTION,COLUMN_NAME, ";
            strcmd += " case when OLD_SCORE_VALUE = 1 then N'非アクティブ' else N'アクティブ' end OLD_VALUE, ";
            strcmd += " case when NEW_SCORE_VALUE = 1 then N'非アクティブ' else N'アクティブ' end NEW_VALUE, ";
            strcmd += " LOGIN_NAME C_USER,TVM.CREATED_DATE C_DATE ";
            strcmd += " from [dbo].[VS_VASTU_MST_TRAN_DETAILS] TVM ";
            strcmd += " left Join VS_USER_MST UM on TVM.CREATED_USER = UM.USER_ID ";
            strcmd += " where COLUMN_NAME in (N'アクティブ・非アクティブ') ";
            strcmd += " ) A ";
            if (vmTrnID != 0)
            {
                strcmd += " Where A.VASTU_MST_TRAN_ID = @vmTrnID";
            }

            strcmd += " ORDER BY VASTU_MST_TRAN_ID DESC";

            return strcmd;
        }
        public List<VS_VASTU_MST_TRAN_DETAILS> GetAllVastuTranDtl()
        {
            string strcmd = "";
            List<VS_VASTU_MST_TRAN_DETAILS> obj = new List<VS_VASTU_MST_TRAN_DETAILS>();
            try
            {

                strcmd = VMTranDtlQuery(0);
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                obj = AdoHelper.ExecuteReader<VS_VASTU_MST_TRAN_DETAILS>(CommandType.Text, strcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;

        }

        public VS_VASTU_MST_TRAN_DETAILS GetAllVastuTranDtlByID(int vmTrnID)
        {
            string strcmd = "";
            VS_VASTU_MST_TRAN_DETAILS obj = new VS_VASTU_MST_TRAN_DETAILS();
            try
            {

                strcmd = VMTranDtlQuery(vmTrnID);
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@vmTrnID", vmTrnID);
                sqlParameters.Add(p1);
                obj = AdoHelper.ExecuteReaderSingle<VS_VASTU_MST_TRAN_DETAILS>(CommandType.Text, strcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;

        }
    }
}
