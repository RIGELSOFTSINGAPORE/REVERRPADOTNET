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
    public class ContentMasterDataAccess : BaseDataAccess
    {
        private string ContentQuery(int contentID)
        {
            string strcmd = "";

            strcmd += "Select M.CONTENT_ID,M.CONTENT_NAME,";
            strcmd += "M.DELETE_FLAG,C.LOGIN_NAME CREATED_USER_NAME,M.CREATED_DATE C_USER_DATE,";
            strcmd += "U.LOGIN_NAME UPDATED_USER_NAME, M.UPDATED_DATE U_USER_DATE";
            strcmd += " From  VS_CONTENT_MST M ";
            strcmd += " Left Join VS_USER_MST C on C.USER_ID = M.CREATED_USER ";
            strcmd += " Left Join VS_USER_MST U on U.USER_ID = M.UPDATED_USER ";
            if (contentID != 0)
            {
                strcmd += " Where M.CONTENT_ID = @contentID";
            }
            strcmd += " ORDER BY M.CONTENT_ID DESC ";

            return strcmd;
        }

       
   
        public List<VS_CONTENT_MST> GetAllContent()
        {
            string strcmd = "";
            List<VS_CONTENT_MST> obj = new List<VS_CONTENT_MST>();
            try
            {
                
                strcmd = ContentQuery(0);
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                obj = AdoHelper.ExecuteReader<VS_CONTENT_MST>(CommandType.Text, strcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;
       
            }
            return obj;

        }
        public VS_CONTENT_MST GetContentByID(int contentID)
        {
            string strcmd = "";
            VS_CONTENT_MST obj = new VS_CONTENT_MST();
            try
            {
  
                strcmd = ContentQuery(contentID);
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@contentID", contentID);
                sqlParameters.Add(p1);
                obj = AdoHelper.ExecuteReaderSingle<VS_CONTENT_MST>(CommandType.Text, strcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;
       
            }
            return obj;

        }

        public List<VS_CONTENT_MST> CheckContentDetail(string contentdetail, int contentID)
        {
            List<VS_CONTENT_MST> obj = new List<VS_CONTENT_MST>();
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                if (contentID == 0)
                {
                    SqlParameter p1 = new SqlParameter("@contentdetail", contentdetail);
                    sqlParameters.Add(p1);
                    obj = AdoHelper.ExecuteReader<VS_CONTENT_MST>(CommandType.Text, "select CONTENT_ID,CONTENT_NAME from VS_CONTENT_MST Where CONTENT_NAME = @contentdetail", sqlParameters);
                }
                else
                {
                    SqlParameter p1 = new SqlParameter("@contentdetail", contentdetail);
                    SqlParameter p2 = new SqlParameter("@contentID", contentID);
                    sqlParameters.Add(p1);
                    sqlParameters.Add(p2);
                    obj = AdoHelper.ExecuteReader<VS_CONTENT_MST>(CommandType.Text, "select CONTENT_ID,CONTENT_NAME from VS_CONTENT_MST Where CONTENT_NAME = @contentdetail and CONTENT_ID != @contentID", sqlParameters);
                }


            }
            catch (Exception ex)
            {
                throw ex;
 
            }
            return obj;
        }

        public int CreateContent(VS_CONTENT_MST contentmst)
        {
            int result = 0;
   
            try
            {
                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@CONTENT_NAME", contentmst.CONTENT_NAME);
                SqlParameter p2 = new SqlParameter("@STATUS_ID", contentmst.STATUS_ID);
                SqlParameter p3 = new SqlParameter("@DELETE_FLAG", contentmst.DELETE_FLAG);
                SqlParameter p4 = new SqlParameter("@CREATED_USER", contentmst.CREATED_USER);
                SqlParameter p5 = new SqlParameter("@CREATED_DATE", c.dt);
   

                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                sqlParameters.Add(p3);
                sqlParameters.Add(p4);
                sqlParameters.Add(p5);
           

           

                string sqlcmd = "insert into VS_CONTENT_MST(CONTENT_NAME,STATUS_ID,";
                sqlcmd += "DELETE_FLAG,CREATED_USER,CREATED_DATE) values(@CONTENT_NAME,";
                sqlcmd +="@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE)";
                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;
   
            }
            return result;
       
        }

        public int UpdateContent(VS_CONTENT_MST contentmst)
        {
            int result = 0;
    
            try
            {
                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@CONTENT_NAME", contentmst.CONTENT_NAME);
                SqlParameter p2 = new SqlParameter("@STATUS_ID", contentmst.STATUS_ID);
                SqlParameter p3 = new SqlParameter("@DELETE_FLAG", contentmst.DELETE_FLAG);
                SqlParameter p4 = new SqlParameter("@UPDATED_USER", contentmst.UPDATED_USER);
                SqlParameter p5 = new SqlParameter("@UPDATED_DATE", c.dt);
                SqlParameter p6 = new SqlParameter("@CONTENT_ID", contentmst.CONTENT_ID);

                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                sqlParameters.Add(p3);
                sqlParameters.Add(p4);
                sqlParameters.Add(p5);
                sqlParameters.Add(p6);
       

                string sqlcmd = "Update VS_CONTENT_MST set CONTENT_NAME = @CONTENT_NAME,";
                sqlcmd += "STATUS_ID=@STATUS_ID,";
                sqlcmd += "DELETE_FLAG=@DELETE_FLAG,UPDATED_USER=@UPDATED_USER,UPDATED_DATE=@UPDATED_DATE";
                sqlcmd += " Where CONTENT_ID =@CONTENT_ID";



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
