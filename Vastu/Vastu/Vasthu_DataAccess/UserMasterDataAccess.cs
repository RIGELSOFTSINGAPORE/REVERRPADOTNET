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
    public class UserMasterDataAccess : BaseDataAccess
    {

        private string UserQuery(decimal userid)
        {
            string strcmd = "";

            strcmd += "Select M.USER_ID,M.LOGIN_NAME,M.FIRST_NAME,M.MIDDLE_NAME,M.LAST_NAME,";

            if (userid != 0)
            {
                strcmd += "M.LOGIN_PASSWORD,M.ADDRESS_LINE1,M.ADDRESS_LINE2,M.CITY,M.COUNTRY,M.EMAIL_ID,M.CONTACT_NO,";
                strcmd += "C.LOGIN_NAME CREATED_USER_NAME,M.CREATED_DATE C_USER_DATE,";
                strcmd += "U.LOGIN_NAME UPDATED_USER_NAME, M.UPDATED_DATE U_USER_DATE,";
            }
            strcmd += "M.USER_TYPE,";
            strcmd += "case when M.USER_TYPE = 1 then 'Admin' else 'User' End USER_TYPE_NAME_STR,";
            strcmd += "M.DELETE_FLAG";
            
            strcmd += " From  VS_USER_MST M ";
            
            strcmd += " Left Join VS_USER_MST C on C.USER_ID = M.CREATED_USER ";
            strcmd += " Left Join VS_USER_MST U on U.USER_ID = M.UPDATED_USER ";
            if (userid != 0)
            {
                strcmd += " Where M.USER_ID = @userID";
            }
            strcmd += " ORDER BY M.USER_ID DESC ";

            return strcmd;
        }
        public List<VS_USER_MST> GetAllUser()
        {
            string strcmd = "";
            List<VS_USER_MST> obj = new List<VS_USER_MST>();
            try
            {
                
                strcmd = UserQuery(0);
                List <SqlParameter> sqlParameters = new List<SqlParameter>();

                obj = AdoHelper.ExecuteReader<VS_USER_MST>(CommandType.Text, strcmd, sqlParameters);
               

            }
            catch (Exception ex)
            {
                throw ex;
       
             
            }
            return obj;

        }
    
        public VS_USER_MST GetUserByID(decimal userID)
        {
            string strcmd = "";
            VS_USER_MST obj = new VS_USER_MST();
            try
            {
   
                strcmd = UserQuery(userID);
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@userID", userID);
                sqlParameters.Add(p1);
                obj = AdoHelper.ExecuteReaderSingle<VS_USER_MST>(CommandType.Text, strcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;
              
            }
            return obj;

        }

        public List<VS_USER_MST> CheckUserName(string username, decimal userid)
        {
            List<VS_USER_MST> obj = new List<VS_USER_MST>();
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
          
                if (userid == 0)
                {
                    SqlParameter p1 = new SqlParameter("@username", username);
                    sqlParameters.Add(p1);
                    obj = AdoHelper.ExecuteReader<VS_USER_MST>(CommandType.Text, "select USER_ID,LOGIN_NAME from VS_USER_MST Where LOGIN_NAME = @username", sqlParameters);
                }
                else
                {
                    SqlParameter p1 = new SqlParameter("@username", username);
                    SqlParameter p2 = new SqlParameter("@userid", userid);
                    sqlParameters.Add(p1);
                    sqlParameters.Add(p2);
                    obj = AdoHelper.ExecuteReader<VS_USER_MST>(CommandType.Text, "select USER_ID,LOGIN_NAME from VS_USER_MST Where LOGIN_NAME = @username and USER_ID != @userID", sqlParameters);
                }
                

            }
            catch (Exception ex)
            {
                throw ex;
        
            }
            return obj;
        }

        public int CreateUser(VS_USER_MST usermst)
        {
            int result = 0;
    
            try
            {
                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@LOGIN_NAME", usermst.LOGIN_NAME);
                SqlParameter p2 = new SqlParameter("@LOGIN_PASSWORD", usermst.LOGIN_PASSWORD);

                SqlParameter p3 = new SqlParameter("@FIRST_NAME", usermst.FIRST_NAME);
                SqlParameter p4 = new SqlParameter("@MIDDLE_NAME", (object)usermst.MIDDLE_NAME ?? DBNull.Value);

                SqlParameter p5 = new SqlParameter("@LAST_NAME", (object)usermst.LAST_NAME ?? DBNull.Value);

                SqlParameter p6 = new SqlParameter("@ADDRESS_LINE1", (object)usermst.ADDRESS_LINE1 ?? DBNull.Value);
                SqlParameter p7 = new SqlParameter("@ADDRESS_LINE2", (object)usermst.ADDRESS_LINE2 ?? DBNull.Value);
                SqlParameter p8 = new SqlParameter("@CITY", (object)usermst.CITY ?? DBNull.Value);
                SqlParameter p9 = new SqlParameter("@COUNTRY", (object)usermst.COUNTRY ?? DBNull.Value);

                SqlParameter p10 = new SqlParameter("@EMAIL_ID", usermst.EMAIL_ID);
                SqlParameter p11 = new SqlParameter("@CONTACT_NO", (object)usermst.CONTACT_NO ?? DBNull.Value);

                SqlParameter p12 = new SqlParameter("@USER_TYPE", usermst.USER_TYPE);
                SqlParameter p13 = new SqlParameter("@STATUS_ID", usermst.STATUS_ID);

                SqlParameter p14 = new SqlParameter("@DELETE_FLAG", usermst.DELETE_FLAG);

                SqlParameter p15 = new SqlParameter("@CREATED_USER", usermst.CREATED_USER);
                SqlParameter p16 = new SqlParameter("@CREATED_DATE", c.dt);


                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                sqlParameters.Add(p3);
                sqlParameters.Add(p4);
                sqlParameters.Add(p5);
                sqlParameters.Add(p6);

                sqlParameters.Add(p7);
                sqlParameters.Add(p8);
                sqlParameters.Add(p9);
                sqlParameters.Add(p10);
                sqlParameters.Add(p11);
                sqlParameters.Add(p12);
                sqlParameters.Add(p13);
                sqlParameters.Add(p14);
                sqlParameters.Add(p15);
                sqlParameters.Add(p16);

                string sqlcmd = "insert into VS_USER_MST(LOGIN_NAME,LOGIN_PASSWORD,FIRST_NAME,MIDDLE_NAME,";
                sqlcmd += "LAST_NAME,ADDRESS_LINE1,ADDRESS_LINE2,CITY,COUNTRY,EMAIL_ID,CONTACT_NO,USER_TYPE,STATUS_ID,";
                sqlcmd += "DELETE_FLAG,CREATED_USER,CREATED_DATE) values(@LOGIN_NAME,@LOGIN_PASSWORD,@FIRST_NAME,";
                sqlcmd += "@MIDDLE_NAME,@LAST_NAME,@ADDRESS_LINE1,@ADDRESS_LINE2,@CITY,@COUNTRY,@EMAIL_ID,";
                sqlcmd += "@CONTACT_NO,@USER_TYPE,@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE)";
                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;
          
            }
            return result;
       
        }

        public int UpdateUser(VS_USER_MST usermst)
        {
            int result = 0;
    
            try
            {
                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@LOGIN_NAME", usermst.LOGIN_NAME);
                SqlParameter p2 = new SqlParameter("@LOGIN_PASSWORD", usermst.LOGIN_PASSWORD);

                SqlParameter p3 = new SqlParameter("@FIRST_NAME", usermst.FIRST_NAME);

 
                SqlParameter p4 = new SqlParameter("@MIDDLE_NAME", (object)usermst.MIDDLE_NAME ?? DBNull.Value);

                SqlParameter p5 = new SqlParameter("@LAST_NAME", (object)usermst.LAST_NAME ?? DBNull.Value);

                SqlParameter p6 = new SqlParameter("@ADDRESS_LINE1", (object)usermst.ADDRESS_LINE1 ?? DBNull.Value);
                SqlParameter p7 = new SqlParameter("@ADDRESS_LINE2", (object)usermst.ADDRESS_LINE2 ?? DBNull.Value);
                SqlParameter p8 = new SqlParameter("@CITY", (object)usermst.CITY ?? DBNull.Value);
                SqlParameter p9 = new SqlParameter("@COUNTRY", (object)usermst.COUNTRY ?? DBNull.Value);

                SqlParameter p10 = new SqlParameter("@EMAIL_ID", usermst.EMAIL_ID);
                SqlParameter p11 = new SqlParameter("@CONTACT_NO", (object)usermst.CONTACT_NO ?? DBNull.Value);

                SqlParameter p12 = new SqlParameter("@USER_TYPE", usermst.USER_TYPE);
                SqlParameter p13 = new SqlParameter("@STATUS_ID", usermst.STATUS_ID);

                SqlParameter p14 = new SqlParameter("@DELETE_FLAG", usermst.DELETE_FLAG);

                SqlParameter p15 = new SqlParameter("@UPDATED_USER", usermst.UPDATED_USER);
                SqlParameter p16 = new SqlParameter("@UPDATED_DATE", c.dt);
                SqlParameter p17 = new SqlParameter("@USER_ID", usermst.USER_ID);

                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                sqlParameters.Add(p3);
                sqlParameters.Add(p4);
                sqlParameters.Add(p5);
                sqlParameters.Add(p6);

                sqlParameters.Add(p7);
                sqlParameters.Add(p8);
                sqlParameters.Add(p9);
                sqlParameters.Add(p10);
                sqlParameters.Add(p11);
                sqlParameters.Add(p12);
                sqlParameters.Add(p13);
                sqlParameters.Add(p14);
                sqlParameters.Add(p15);
                sqlParameters.Add(p16);
                sqlParameters.Add(p17);

          

                string sqlcmd = "Update VS_USER_MST set LOGIN_NAME = @LOGIN_NAME,LOGIN_PASSWORD=@LOGIN_PASSWORD,";
                sqlcmd += "FIRST_NAME=@FIRST_NAME,MIDDLE_NAME=@MIDDLE_NAME,LAST_NAME=@LAST_NAME,";
                sqlcmd += "ADDRESS_LINE1=@ADDRESS_LINE1,ADDRESS_LINE2=@ADDRESS_LINE2,CITY=@CITY,COUNTRY=@COUNTRY,";
                sqlcmd += "EMAIL_ID=@EMAIL_ID,CONTACT_NO=@CONTACT_NO,USER_TYPE=@USER_TYPE,STATUS_ID=@STATUS_ID,";
                sqlcmd += "DELETE_FLAG=@DELETE_FLAG,UPDATED_USER=@UPDATED_USER,UPDATED_DATE=@UPDATED_DATE";
                sqlcmd += " Where USER_ID =@USER_ID";



                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);
                //result = AdoHelper.ExecuteNonQuery(CommandType.Text, "Update VS_USER_MST set LOGIN_NAME=@LOGIN_NAME, EMAIL_ID=@EMAIL_ID, DELETE_FLAG=@DELETE_FLAG, UPDATED_DATE=@UPDATE_DATE  Where USER_ID=@USER_ID", sqlParameters);
                

            }
            catch (Exception ex)
            {
                throw ex;
     
            }
            return result;
        }
    }
}
