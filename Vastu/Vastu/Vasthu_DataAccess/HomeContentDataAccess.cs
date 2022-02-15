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
    public class HomeContentDataAccess : BaseDataAccess
    {
        public List<MasterContent> GetHomeContent()
        {
            List<MasterContent> obj = new List<MasterContent>();
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                obj = AdoHelper.ExecuteReader<MasterContent>(CommandType.Text, "select CONTENT_ID as ContentID,CONTENT_NAME as ContentName from VS_CONTENT_MST where delete_flag='0' and status_id=4  and CONTENT_ID in(1,2,3) ", sqlParameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return obj;
        }


        public List<MstrContent> LoadDescription(int ContentID)
        {
            List<MstrContent> obj = new List<MstrContent>();
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            try
            {
                SqlParameter P1 = new SqlParameter("@CONTENT_ID", ContentID);
                sqlParameters.Add(P1);


                obj = AdoHelper.ExecuteReader<MstrContent>(CommandType.Text, "select CONTENT_DETAILS as ContentDescription from VS_CONTENT_DETAILS where delete_flag='0' and status_id = 4  and CONTENT_ID = @CONTENT_ID", sqlParameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return obj;


        }

        public List<MasterContent> IsDataAvailable(SaveContent obj)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            List<MasterContent> result = new List<MasterContent>();
            try
            {
                SqlParameter P1 = new SqlParameter("@CONTENT_ID", obj.ContentID);
                sqlParameters.Add(P1);
                result = AdoHelper.ExecuteReader<MasterContent>(CommandType.Text, "select CONTENT_ID as ContentID  from VS_CONTENT_DETAILS where delete_flag='0' and status_id = 4  and CONTENT_ID = @CONTENT_ID", sqlParameters);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }

        public int SaveContentInformation(SaveContent obj,string InsUp)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            int result = 0;
            try
            {

                if(InsUp=="Insert")
                {
                    SqlParameter P1 = new SqlParameter("@CONTENT_ID", obj.ContentID);
                    SqlParameter P2 = new SqlParameter("@CONTENT_DETAILS", obj.ContentDescription);
                    SqlParameter P3 = new SqlParameter("@STATUS_ID", 4);
                    SqlParameter P4 = new SqlParameter("@DELETE_FLAG", false);
                    SqlParameter P5 = new SqlParameter("@CREATED_USER", 1);
                    SqlParameter P6 = new SqlParameter("@CREATED_DATE", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                    sqlParameters.Add(P1);
                    sqlParameters.Add(P2);
                    sqlParameters.Add(P3);
                    sqlParameters.Add(P4);
                    sqlParameters.Add(P5);
                    sqlParameters.Add(P6);

                    result = AdoHelper.ExecuteNonQuery(CommandType.Text, "insert into VS_CONTENT_DETAILS(CONTENT_ID,CONTENT_DETAILS,STATUS_ID,DELETE_FLAG,CREATED_USER,CREATED_DATE)values(@CONTENT_ID,@CONTENT_DETAILS,@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE)", sqlParameters);
                }
                else
                {
                    SqlParameter P1 = new SqlParameter("@CONTENT_ID", obj.ContentID);
                    SqlParameter P2 = new SqlParameter("@CONTENT_DETAILS", obj.ContentDescription);
                    SqlParameter P3 = new SqlParameter("@UPDATED_USER", 1);
                    SqlParameter P4 = new SqlParameter("@UPDATED_DATE", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                    sqlParameters.Add(P1);
                    sqlParameters.Add(P2);
                    sqlParameters.Add(P3);
                    sqlParameters.Add(P4);
                    result = AdoHelper.ExecuteNonQuery(CommandType.Text, "update VS_CONTENT_DETAILS set CONTENT_DETAILS=@CONTENT_DETAILS,UPDATED_USER=@UPDATED_USER,UPDATED_DATE=@UPDATED_DATE where CONTENT_ID=@CONTENT_ID", sqlParameters);
                }
                
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            return result;
        }

        public int DeleteContentById(int ContentID)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            int result = 0;
            try
            {

                SqlParameter P1 = new SqlParameter("@CONTENT_ID", ContentID);
                sqlParameters.Add(P1);
                //result = AdoHelper.ExecuteNonQuery(CommandType.Text, "delete from VS_CONTENT_DETAILS where CONTENT_ID=@CONTENT_ID", sqlParameters);
                result = AdoHelper.ExecuteNonQuery(CommandType.Text, "update VS_CONTENT_DETAILS set content_details = ''  where CONTENT_ID=@CONTENT_ID", sqlParameters);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }

    }
}
