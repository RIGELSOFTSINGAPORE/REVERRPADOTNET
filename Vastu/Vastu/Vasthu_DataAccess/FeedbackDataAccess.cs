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
    public class FeedbackDataAccess : BaseDataAccess
    {
      
        public List<Feedback> Feedback()
        {
            List<Feedback> obj = new List<Feedback>();
            try
            {
                
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
               
                obj = AdoHelper.ExecuteReader<Feedback>(CommandType.Text, "select FEEDBACK_ID,COMMENTS_1,SUBSTRING(Name, 1, 15) AS DISPLAYNAME,NAME,IMAGE_URL_1,DELETE_FLAG,STATUS_ID from VS_FEEDBACK_MST where  status_id=4 and delete_flag=0 order by created_date desc", sqlParameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return obj;
        }
        public List<Feedback> Feedbackend()
        {
            List<Feedback> obj = new List<Feedback>();
            try
            {
                Common c = new Common();
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@CREATED_DATE", c.dt);
                sqlParameters.Add(p1);

                obj = AdoHelper.ExecuteReader<Feedback>(CommandType.Text, "select FEEDBACK_ID,COMMENTS_1,NAME,IMAGE_URL_1,DELETE_FLAG,STATUS_ID,ADDRESS_LINE,CITY,STATE,COUNTRY,LNAME  from VS_FEEDBACK_MST where  delete_flag=0 and CONVERT(DATE, CREATED_DATE) =  CONVERT(char(10), GetDate(),126) order by created_date desc", sqlParameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return obj;
        }
        public int SaveFeedback(string name,string lname, string address, string comment, string city,string state,string country,string filename,int UserID)
        {
            //Feedback obj = new Feedback();
            int obj;
            try
            {
                Common c = new Common();

                List<SqlParameter>  sqlParameters = new List<SqlParameter>();

                string qry = "insert into VS_FEEDBACK_MST(NAME,ADDRESS_LINE,comments_1,CITY,state,country,image_url_1,STATUS_ID,CREATED_USER,lname,CREATED_DATE)values(@name,@address,@comment,@city,@state,@country,@filename,'1',@CREATED_USER,@lname,@CREATED_DATE)";
                SqlParameter p1 = new SqlParameter("@name", name);
                SqlParameter p2 = new SqlParameter("@address", address);
                SqlParameter p3 = new SqlParameter("@comment", comment);
                SqlParameter p4 = new SqlParameter("@city", city);
                SqlParameter p5 = new SqlParameter("@state", state);
                SqlParameter p6 = new SqlParameter("@country", country);
                SqlParameter p7 = new SqlParameter("@filename", filename);
                SqlParameter p8 = new SqlParameter("@lname", lname);
                SqlParameter p9 = new SqlParameter("@CREATED_DATE", c.dt);
                SqlParameter p10 = new SqlParameter("@CREATED_USER", UserID);

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

                obj = AdoHelper.ExecuteNonQuery(CommandType.Text, qry, sqlParameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }

        public List<Feedback> FeedbackAdmin(int id,int del)
        {
            List<Feedback> obj = new List<Feedback>();
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@id", id);
                SqlParameter p2 = new SqlParameter("@del", del);
                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                obj = AdoHelper.ExecuteReader<Feedback>(CommandType.Text, "update VS_FEEDBACK_MST set STATUS_ID=@del  where feedback_id=@id ", sqlParameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return obj;
        }
        public List<Feedback> SearchFeedbackAdmin(DateTime frmdate,DateTime todate)
        {
            List<Feedback> obj = new List<Feedback>();
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@frmdate", frmdate);
                SqlParameter p2 = new SqlParameter("@todate", todate);
                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                obj = AdoHelper.ExecuteReader<Feedback>(CommandType.Text, "select FEEDBACK_ID,COMMENTS_1,NAME,IMAGE_URL_1,DELETE_FLAG,STATUS_ID,ADDRESS_LINE,CITY,STATE,COUNTRY,LNAME from VS_FEEDBACK_MST where  delete_flag=0 and CONVERT(DATE, CREATED_DATE) between @frmdate and @todate order by created_date desc", sqlParameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return obj;
        }

        public int DeleteFeedback(int id)
        {
            //Feedback obj = new Feedback();
            int obj;
            try
            {

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                string qry = "update VS_FEEDBACK_MST set delete_flag='1' where feedback_id=@id";
                SqlParameter p1 = new SqlParameter("@id", id);
               

                sqlParameters.Add(p1);
                

                obj = AdoHelper.ExecuteNonQuery(CommandType.Text, qry, sqlParameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }
    }
}
