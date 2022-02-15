﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_Models;
using System.Data;
using System.Data.SqlClient;

namespace Vasthu_DataAccess
{
    public class AreaMasterTranDtlDataAccess : BaseDataAccess
    {
        private string AMTranDtlQuery(int amTrnID)
        {
            string strcmd = "";
            strcmd += "Select * from ";
            strcmd += " ( ";
            strcmd += "select AREA_MST_TRAN_ID,NEW_DESCRIPTION_VALUE AREA,COLUMN_NAME,";
            strcmd += "case OLD_DESCRIPTION_VALUE when 'add' then '-' when 'del' then '-' else OLD_DESCRIPTION_VALUE end OLD_VALUE,";
            strcmd += "case OLD_DESCRIPTION_VALUE when 'add' then N'新しく作成されました -  ' + NEW_DESCRIPTION_VALUE when 'del' then  N'削除されました - ' + NEW_DESCRIPTION_VALUE else NEW_DESCRIPTION_VALUE end NEW_VALUE,LOGIN_NAME C_USER,";
            strcmd += "TVM.CREATED_DATE C_DATE  ";
            strcmd += "from [dbo].[VS_AREA_MST_TRAN_DETAILS] TVM";
            strcmd += " left Join VS_AREA_MST AM on TVM.AREA_ID = AM.AREA_ID";
            strcmd += " left Join VS_USER_MST UM on TVM.CREATED_USER = UM.USER_ID";
            strcmd += " where COLUMN_NAME in (N'エリア')";
            strcmd += " UNION ";
            strcmd += " select AREA_MST_TRAN_ID,AM.AREA,COLUMN_NAME, ";
            strcmd += " '-'  OLD_VALUE,N'修正されました' NEW_VALUE, ";
            strcmd += " LOGIN_NAME C_USER,TVM.CREATED_DATE C_DATE ";
            strcmd += " from [dbo].[VS_AREA_MST_TRAN_DETAILS] TVM ";
            strcmd += " left Join VS_AREA_MST AM on TVM.AREA_ID = AM.AREA_ID";
            strcmd += " left Join VS_USER_MST UM on TVM.CREATED_USER = UM.USER_ID ";
            strcmd += " where COLUMN_NAME in (N'コメント') ";
            strcmd += " UNION ";
            strcmd += " select AREA_MST_TRAN_ID,AM.AREA,COLUMN_NAME, ";
            strcmd += " case when OLD_DESCRIPTION_VALUE = '1' then N'非アクティブ' else N'アクティブ' end OLD_VALUE, ";
            strcmd += " case when NEW_DESCRIPTION_VALUE = '1' then N'非アクティブ' else N'アクティブ' end NEW_VALUE, ";
            strcmd += " LOGIN_NAME C_USER,TVM.CREATED_DATE C_DATE ";
            strcmd += " from [dbo].[VS_AREA_MST_TRAN_DETAILS] TVM ";
            strcmd += " left Join VS_AREA_MST AM on TVM.AREA_ID = AM.AREA_ID";
            strcmd += " left Join VS_USER_MST UM on TVM.CREATED_USER = UM.USER_ID ";
            strcmd += " where COLUMN_NAME in (N'アクティブ・非アクティブ') ";
            strcmd += " ) A ";
            if (amTrnID != 0)
            {
                strcmd += " Where A.AREA_MST_TRAN_ID = @amTrnID";
            }

            strcmd += " ORDER BY AREA_MST_TRAN_ID DESC";

            return strcmd;
        }
        public List<VS_AREA_MST_TRAN_DETAILS> GetAllAreaTranDtl()
        {
            string strcmd = "";
            List<VS_AREA_MST_TRAN_DETAILS> obj = new List<VS_AREA_MST_TRAN_DETAILS>();
            try
            {

                strcmd = AMTranDtlQuery(0);
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                obj = AdoHelper.ExecuteReader<VS_AREA_MST_TRAN_DETAILS>(CommandType.Text, strcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;

        }

        public VS_AREA_MST_TRAN_DETAILS GetAllAreaTranDtlByID(int amTrnID)
        {
            string strcmd = "";
            VS_AREA_MST_TRAN_DETAILS obj = new VS_AREA_MST_TRAN_DETAILS();
            try
            {

                strcmd = AMTranDtlQuery(amTrnID);
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@amTrnID", amTrnID);
                sqlParameters.Add(p1);
                obj = AdoHelper.ExecuteReaderSingle<VS_AREA_MST_TRAN_DETAILS>(CommandType.Text, strcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;

        }
    }
}
