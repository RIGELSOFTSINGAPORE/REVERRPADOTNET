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
   public class UserVastuDataAccess : BaseDataAccess
    {
        public List<USER_MST> GetUser()
        {
            List<USER_MST> obj = new List<USER_MST>();
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                obj = AdoHelper.ExecuteReader<USER_MST>(CommandType.Text, "select * from VS_USER_MST", sqlParameters);
                return obj;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public List<USER_MST> CreateUser(USER_MST usermst)
        {
            List<USER_MST> obj = new List<USER_MST>();
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@LOGIN_NAME", usermst.LOGIN_NAME);
                SqlParameter p2 = new SqlParameter("@LOGIN_PASSWORD", usermst.NewPassword);

                SqlParameter p3 = new SqlParameter("@FIRST_NAME", usermst.FIRST_NAME);
                SqlParameter p4 = new SqlParameter("@EMAIL_ID", usermst.EMAIL_ID);
                SqlParameter p5 = new SqlParameter("@USER_TYPE", usermst.USER_TYPE);
                SqlParameter p6 = new SqlParameter("@STATUS_ID", usermst.STATUS_ID);

                SqlParameter p7 = new SqlParameter("@DELETE_FLAG", usermst.DELETE_FLAG);
                
                SqlParameter p8 = new SqlParameter("@CREATED_USER", usermst.CREATED_USER);
                SqlParameter p9 = new SqlParameter("@CREATED_DATE", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));


                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                sqlParameters.Add(p3);
                sqlParameters.Add(p4);
                sqlParameters.Add(p5);
                sqlParameters.Add(p6);

                sqlParameters.Add(p7);
                sqlParameters.Add(p8);
                sqlParameters.Add(p9);


                obj = AdoHelper.ExecuteReader<USER_MST>(CommandType.Text, "insert into VS_USER_MST(LOGIN_NAME,LOGIN_PASSWORD,FIRST_NAME,EMAIL_ID,USER_TYPE,STATUS_ID, DELETE_FLAG,CREATED_USER,CREATED_DATE) values(@LOGIN_NAME,@LOGIN_PASSWORD,@FIRST_NAME,@EMAIL_ID,@USER_TYPE,@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE)", sqlParameters);
                return obj;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<USER_MST> Update(int ID)
        {
            List<USER_MST> obj = new List<USER_MST>();
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@USER_ID", ID);

                sqlParameters.Add(p1);
                obj = AdoHelper.ExecuteReader<USER_MST>(CommandType.Text, "select * from VS_USER_MST Where USER_ID=@USER_ID", sqlParameters);
                return obj;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<USER_MST> UpdateDetails(USER_MST Update)
        {
            List<USER_MST> obj = new List<USER_MST>();
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@LOGIN_NAME", Update.LOGIN_NAME);
                SqlParameter p2 = new SqlParameter("@EMAIL_ID", Update.EMAIL_ID);
                SqlParameter p3 = new SqlParameter("@LOGIN_PASSWORD", Update.ConfrimPassword);
                SqlParameter p4 = new SqlParameter("@DELETE_FLAG", Update.DELETE_FLAG);
                SqlParameter p5 = new SqlParameter("@USER_ID", Update.USER_ID);
                SqlParameter p9 = new SqlParameter("@UPDATE_DATE", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                sqlParameters.Add(p3);
                sqlParameters.Add(p4);
                sqlParameters.Add(p5);
                sqlParameters.Add(p9);

                obj = AdoHelper.ExecuteReader<USER_MST>(CommandType.Text, "Update VS_USER_MST set LOGIN_NAME=@LOGIN_NAME, EMAIL_ID=@EMAIL_ID, DELETE_FLAG=@DELETE_FLAG, UPDATED_DATE=@UPDATE_DATE  Where USER_ID=@USER_ID", sqlParameters);
                return obj;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
