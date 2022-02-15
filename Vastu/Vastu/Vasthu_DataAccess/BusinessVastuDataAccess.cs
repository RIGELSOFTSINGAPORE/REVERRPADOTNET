using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Vasthu_Models;

namespace Vasthu_DataAccess
{
    public class BusinessVastuDataAccess : BaseDataAccess
    {
        #region Business Vastu
        public void Test()
        {
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                //string qry = "insert into dep(depid,depname,location)values(@depid,@depname,@location)";
                //SqlParameter p1 = new SqlParameter("@depid", 7);
                //SqlParameter p2 = new SqlParameter();
                //p2.ParameterName = "@result";
                //p2.Direction = ParameterDirection.Output;
                //p2.SqlDbType = System.Data.SqlDbType.Int;
                //sqlParameters.Add(p1);
                //sqlParameters.Add(p2);
                //int outputValue = Convert.ToInt32(p2.Value);

                //execute reader

                List<AreaReport> obj = new List<AreaReport>();
                obj = AdoHelper.ExecuteReader<AreaReport>(CommandType.Text, "query", sqlParameters);
                obj = AdoHelper.ExecuteReader<AreaReport>(CommandType.StoredProcedure, "spname", sqlParameters);


                //executenonquery
                int result2 = AdoHelper.ExecuteNonQuery(CommandType.Text, "dmlquery", sqlParameters);
                int result1 = AdoHelper.ExecuteNonQuery(CommandType.StoredProcedure, "spname", sqlParameters);



                //executescalar
                int test1 = AdoHelper.ExecuteScalar<int>(CommandType.Text, "query", sqlParameters);
                int test2 = AdoHelper.ExecuteScalar<int>(CommandType.StoredProcedure, "spname", sqlParameters);

                //dataset
                DataSet ds1 = AdoHelper.ExecDataSet(CommandType.Text, "query", sqlParameters);
                DataSet ds2 = AdoHelper.ExecDataSet(CommandType.StoredProcedure, "spname", sqlParameters);


            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        #endregion
    }
}
