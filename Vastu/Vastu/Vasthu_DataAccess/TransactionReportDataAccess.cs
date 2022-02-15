using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace Vasthu_DataAccess
{
    public class TransactionReportDataAccess : BaseDataAccess
    {
        public List<TransReport> SearchTrans()
        {
            List<TransReport> obj = new List<TransReport>();
            try
            {
                Common c = new Common();
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@CREATED_DATE", c.dt);
                sqlParameters.Add(p1);

                obj = AdoHelper.ExecuteReader<TransReport>(CommandType.Text, "select VASTU_REPORT_ID,VASTU_TYPE,REPORT_TAKEN_BY,EMAIL_ID,VASTU_DATE from VS_VAST_REPORT_TRAN  order by  created_date desc", sqlParameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return obj;
        }
        public List<TransReport> SearchFeedbackAdmin(DateTime frmdate, DateTime todate)
        {
            List<TransReport> obj = new List<TransReport>();
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@frmdate", frmdate);
                SqlParameter p2 = new SqlParameter("@todate", todate);
                sqlParameters.Add(p1);
                sqlParameters.Add(p2);

                obj = AdoHelper.ExecuteReader<TransReport>(CommandType.Text, "select VASTU_REPORT_ID,VASTU_TYPE,REPORT_TAKEN_BY,EMAIL_ID,VASTU_DATE from VS_VAST_REPORT_TRAN where CONVERT(DATE, VASTU_DATE) between @frmdate and @todate order by created_date desc", sqlParameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return obj;
        }
    }
}
