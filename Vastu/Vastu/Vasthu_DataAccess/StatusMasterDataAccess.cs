using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_Models;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Vasthu_DataAccess
{
    public class StatusMasterDataAccess : BaseDataAccess
    {
        private string StatusQuery(int statusID)
        {
            string strcmd = "";

            strcmd += "Select M.STATUS_ID,M.STATUS,";
            strcmd += "M.DELETE_FLAG,C.LOGIN_NAME CREATED_USER_NAME,M.CREATED_DATE C_USER_DATE,";
            strcmd += "U.LOGIN_NAME UPDATED_USER_NAME, M.UPDATED_DATE U_USER_DATE";
            strcmd += " From  VS_STATUS_MST M ";
            strcmd += " Left Join VS_USER_MST C on C.USER_ID = M.CREATED_USER ";
            strcmd += " Left Join VS_USER_MST U on U.USER_ID = M.UPDATED_USER ";
            if (statusID != 0)
            {
                strcmd += " Where M.STATUS_ID = @statusID";
            }
            strcmd += " ORDER BY M.STATUS_ID DESC ";

            return strcmd;
        }

       
   
        public List<VS_STATUS_MST> GetAllStatus()
        {
            string strcmd = "";
            List<VS_STATUS_MST> obj = new List<VS_STATUS_MST>();
            try
            {
                
                strcmd = StatusQuery(0);
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                obj = AdoHelper.ExecuteReader<VS_STATUS_MST>(CommandType.Text, strcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;
       
            }
            return obj;

        }
        public VS_STATUS_MST GetStatusByID(int statusID)
        {
            string strcmd = "";
            VS_STATUS_MST obj = new VS_STATUS_MST();
            try
            {
  
                strcmd = StatusQuery(statusID);
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@statusID", statusID);
                sqlParameters.Add(p1);
                obj = AdoHelper.ExecuteReaderSingle<VS_STATUS_MST>(CommandType.Text, strcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;
       
            }
            return obj;

        }

        public List<VS_STATUS_MST> CheckstatusDetail(string statusdetail, int statusID)
        {
            List<VS_STATUS_MST> obj = new List<VS_STATUS_MST>();
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                if (statusID == 0)
                {
                    SqlParameter p1 = new SqlParameter("@statusdetail", statusdetail);
                    sqlParameters.Add(p1);
                    obj = AdoHelper.ExecuteReader<VS_STATUS_MST>(CommandType.Text, "select STATUS_ID,STATUS from VS_STATUS_MST Where STATUS = @statusdetail", sqlParameters);
                }
                else
                {
                    SqlParameter p1 = new SqlParameter("@statusdetail", statusdetail);
                    SqlParameter p2 = new SqlParameter("@statusID", statusID);
                    sqlParameters.Add(p1);
                    sqlParameters.Add(p2);
                    obj = AdoHelper.ExecuteReader<VS_STATUS_MST>(CommandType.Text, "select STATUS_ID,STATUS from VS_STATUS_MST Where STATUS = @statusdetail and STATUS_ID != @statusID", sqlParameters);
                }


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
                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@STATUS", statusmst.STATUS);
                SqlParameter p2 = new SqlParameter("@DELETE_FLAG", statusmst.DELETE_FLAG);
                SqlParameter p3 = new SqlParameter("@CREATED_USER", statusmst.CREATED_USER);
                SqlParameter p4 = new SqlParameter("@CREATED_DATE", c.dt);
   

                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                sqlParameters.Add(p3);
                sqlParameters.Add(p4);
   
           

           

                string sqlcmd = "insert into VS_STATUS_MST(STATUS,";
                sqlcmd += "DELETE_FLAG,CREATED_USER,CREATED_DATE) values(@STATUS,";
                sqlcmd +="@DELETE_FLAG,@CREATED_USER,@CREATED_DATE)";
                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);
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
                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@STATUS", statusmst.STATUS);
                SqlParameter p2 = new SqlParameter("@STATUS_ID", statusmst.STATUS_ID);
                SqlParameter p3 = new SqlParameter("@DELETE_FLAG", statusmst.DELETE_FLAG);
                SqlParameter p4 = new SqlParameter("@UPDATED_USER", statusmst.UPDATED_USER);
                SqlParameter p5 = new SqlParameter("@UPDATED_DATE", c.dt);
   

                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                sqlParameters.Add(p3);
                sqlParameters.Add(p4);
                sqlParameters.Add(p5);
      
       

                string sqlcmd = "Update VS_STATUS_MST set STATUS = @STATUS,";
                sqlcmd += "DELETE_FLAG=@DELETE_FLAG,UPDATED_USER=@UPDATED_USER,UPDATED_DATE=@UPDATED_DATE";
                sqlcmd += " Where STATUS_ID =@STATUS_ID";



                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);
      


            }
            catch (Exception ex)
            {
                throw ex;
         
            }
            return result;
        }
    }
}
