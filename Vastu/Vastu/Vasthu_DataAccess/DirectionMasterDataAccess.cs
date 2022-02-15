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
    public class DirectionMasterDataAccess : BaseDataAccess
    {
        private string DirectionQuery(int directionID)
        {
            string strcmd = "";

            strcmd += "Select M.DIRECTION_ID,M.DIRECTION,";
            strcmd += "M.DELETE_FLAG,C.LOGIN_NAME CREATED_USER_NAME,M.CREATED_DATE C_USER_DATE,";
            strcmd += "U.LOGIN_NAME UPDATED_USER_NAME, M.UPDATED_DATE U_USER_DATE";
            strcmd += " From  VS_DIRECTION_MST M ";
            strcmd += " Left Join VS_USER_MST C on C.USER_ID = M.CREATED_USER ";
            strcmd += " Left Join VS_USER_MST U on U.USER_ID = M.UPDATED_USER ";
            if (directionID != 0)
            {
                strcmd += " Where M.DIRECTION_ID = @directionID";
            }
            strcmd += " ORDER BY M.DIRECTION_ID ASC ";

            return strcmd;
        }

       
   
        public List<VS_DIRECTION_MST> GetAllDirection()
        {
            string strcmd = "";
            List<VS_DIRECTION_MST> obj = new List<VS_DIRECTION_MST>();
            try
            {
                
                strcmd = DirectionQuery(0);
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                obj = AdoHelper.ExecuteReader<VS_DIRECTION_MST>(CommandType.Text, strcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;
       
            }
            return obj;

        }
        public VS_DIRECTION_MST GetDirectionByID(int directionID)
        {
            string strcmd = "";
            VS_DIRECTION_MST obj = new VS_DIRECTION_MST();
            try
            {
  
                strcmd = DirectionQuery(directionID);
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@directionID", directionID);
                sqlParameters.Add(p1);
                obj = AdoHelper.ExecuteReaderSingle<VS_DIRECTION_MST>(CommandType.Text, strcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;
       
            }
            return obj;

        }

        public List<VS_DIRECTION_MST> CheckDirectionDetail(string directiondetail, int directionID)
        {
            List<VS_DIRECTION_MST> obj = new List<VS_DIRECTION_MST>();
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                if (directionID == 0)
                {
                    SqlParameter p1 = new SqlParameter("@directiondetail", directiondetail);
                    sqlParameters.Add(p1);
                    obj = AdoHelper.ExecuteReader<VS_DIRECTION_MST>(CommandType.Text, "select DIRECTION_ID,DIRECTION from VS_DIRECTION_MST Where DIRECTION = @directiondetail", sqlParameters);
                }
                else
                {
                    SqlParameter p1 = new SqlParameter("@directiondetail", directiondetail);
                    SqlParameter p2 = new SqlParameter("@directionID", directionID);
                    sqlParameters.Add(p1);
                    sqlParameters.Add(p2);
                    obj = AdoHelper.ExecuteReader<VS_DIRECTION_MST>(CommandType.Text, "select DIRECTION_ID,DIRECTION from VS_DIRECTION_MST Where DIRECTION = @directiondetail and DIRECTION_ID != @directionID", sqlParameters);
                }


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
                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@DIRECTION", directionmst.DIRECTION);
                SqlParameter p2 = new SqlParameter("@STATUS_ID", directionmst.STATUS_ID);
                SqlParameter p3 = new SqlParameter("@DELETE_FLAG", directionmst.DELETE_FLAG);
                SqlParameter p4 = new SqlParameter("@CREATED_USER", directionmst.CREATED_USER);
                SqlParameter p5 = new SqlParameter("@CREATED_DATE", c.dt);
   

                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                sqlParameters.Add(p3);
                sqlParameters.Add(p4);
                sqlParameters.Add(p5);
           

           

                string sqlcmd = "insert into VS_DIRECTION_MST(DIRECTION,STATUS_ID,";
                sqlcmd += "DELETE_FLAG,CREATED_USER,CREATED_DATE) values(@DIRECTION,";
                sqlcmd +="@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE)";
                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);
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
                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@DIRECTION", directionmst.DIRECTION);
                SqlParameter p2 = new SqlParameter("@STATUS_ID", directionmst.STATUS_ID);
                SqlParameter p3 = new SqlParameter("@DELETE_FLAG", directionmst.DELETE_FLAG);
                SqlParameter p4 = new SqlParameter("@UPDATED_USER", directionmst.UPDATED_USER);
                SqlParameter p5 = new SqlParameter("@UPDATED_DATE", c.dt);
                SqlParameter p6 = new SqlParameter("@DIRECTION_ID", directionmst.DIRECTION_ID);

                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                sqlParameters.Add(p3);
                sqlParameters.Add(p4);
                sqlParameters.Add(p5);
                sqlParameters.Add(p6);
       

                string sqlcmd = "Update VS_DIRECTION_MST set DIRECTION = @DIRECTION,";
                sqlcmd += "STATUS_ID=@STATUS_ID,";
                sqlcmd += "DELETE_FLAG=@DELETE_FLAG,UPDATED_USER=@UPDATED_USER,UPDATED_DATE=@UPDATED_DATE";
                sqlcmd += " Where DIRECTION_ID =@DIRECTION_ID";



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
