﻿using System;
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
    public class LoginDataAccess : BaseDataAccess
    {
        public List<Login> Login(string LOGIN_NAME, string LOGIN_PASSWORD)
        {
            List<Login> Login = new List<Login>();
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@LOGIN_PASSWORD", LOGIN_PASSWORD);
                SqlParameter p2 = new SqlParameter("@LOGIN_NAME", LOGIN_NAME);

                sqlParameters.Add(p1);
                sqlParameters.Add(p2);

                Login = AdoHelper.ExecuteReader<Login>(CommandType.Text, "select * from VS_USER_MST where LOGIN_PASSWORD=@LOGIN_PASSWORD and LOGIN_NAME=@LOGIN_NAME and DELETE_FLAG=0 and STATUS_ID = 4", sqlParameters);


                return Login;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public List<Login> Forgotten(Login Login)
        {
            List<Login> Forgotten = new List<Login>();
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@LOGIN_PASSWORD", Login.ConfrimPassword);
                SqlParameter p2 = new SqlParameter("@LOGIN_NAME", Login.LOGIN_NAME);
                SqlParameter p3 = new SqlParameter("@EMAIL_ID", Login.EMAIL_ID);

                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                sqlParameters.Add(p3);


                Forgotten = AdoHelper.ExecuteReader<Login>(CommandType.Text, "Update VS_USER_MST set LOGIN_PASSWORD=@LOGIN_PASSWORD where LOGIN_NAME=@LOGIN_NAME and EMAIL_ID=@EMAIL_ID ", sqlParameters);


                return Forgotten;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
