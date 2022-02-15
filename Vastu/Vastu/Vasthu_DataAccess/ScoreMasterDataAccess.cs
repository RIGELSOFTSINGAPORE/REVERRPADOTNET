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
    public class ScoreMasterDataAccess : BaseDataAccess
    {
        private string ScoreQuery(int scoreID)
        {
            string strcmd = "";

            strcmd += "Select M.SCORE_ID,M.SCORE_TEXT,M.SCORE,I.IMAGE_DETAILS,I.IMAGE_URL,I.IMAGE_ID,I.IMAGE_SYMBOL,";
            strcmd += "M.DELETE_FLAG,C.LOGIN_NAME CREATED_USER_NAME,M.CREATED_DATE C_USER_DATE,";
            strcmd += "U.LOGIN_NAME UPDATED_USER_NAME, M.UPDATED_DATE U_USER_DATE,I.DELETE_FLAG IMG_DELETE_FLAG";
            strcmd += " From  VS_SCORE_MST M ";
            strcmd += " Left Join VS_IMAGE_MST I on I.IMAGE_ID = M.IMAGE_ID ";
            strcmd += " Left Join VS_USER_MST C on C.USER_ID = M.CREATED_USER ";
            strcmd += " Left Join VS_USER_MST U on U.USER_ID = M.UPDATED_USER ";
            if (scoreID != 0)
            {
                strcmd += " Where M.SCORE_ID = @scoreID";
            }
            strcmd += " ORDER BY M.SCORE_ID DESC ";

            return strcmd;
        }

        public List<VS_SCORE_MST> GetAllScore()
        {
            string strcmd = "";
            List<VS_SCORE_MST> obj = new List<VS_SCORE_MST>();
            try
            {
                
                strcmd = ScoreQuery(0);
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                obj = AdoHelper.ExecuteReader<VS_SCORE_MST>(CommandType.Text, strcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;
           
            }
            return obj;

        }
        public VS_SCORE_MST GetScoreByID(int scoreID)
        {
            string strcmd = "";
            VS_SCORE_MST obj = new VS_SCORE_MST();
            try
            {
  
                strcmd = ScoreQuery(scoreID);
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@scoreID", scoreID);
                sqlParameters.Add(p1);
                obj = AdoHelper.ExecuteReaderSingle<VS_SCORE_MST>(CommandType.Text, strcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;
             
            }
            return obj;

        }

        public List<VS_SCORE_MST> CheckScoreDetail(decimal scoredetail, int scoreid)
        {
            List<VS_SCORE_MST> obj = new List<VS_SCORE_MST>();
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                if (scoreid == 0)
                {
                    SqlParameter p1 = new SqlParameter("@scoredetail", scoredetail);
                    sqlParameters.Add(p1);
                    obj = AdoHelper.ExecuteReader<VS_SCORE_MST>(CommandType.Text, "select SCORE_ID,SCORE from VS_SCORE_MST Where SCORE = @scoredetail", sqlParameters);
                }
                else
                {
                    SqlParameter p1 = new SqlParameter("@scoredetail", scoredetail);
                    SqlParameter p2 = new SqlParameter("@scoreid", scoreid);
                    sqlParameters.Add(p1);
                    sqlParameters.Add(p2);
                    obj = AdoHelper.ExecuteReader<VS_SCORE_MST>(CommandType.Text, "select SCORE_ID,SCORE from VS_SCORE_MST Where SCORE = @scoredetail and SCORE_ID != @scoreid", sqlParameters);
                }


            }
            catch (Exception ex)
            {
                throw ex;
           
            }
            return obj;
        }

        public int CreateScore(VS_SCORE_MST scoremst)
        {
            int result = 0;
         
            try
            {
                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@SCORE_TEXT", scoremst.SCORE_TEXT);
                SqlParameter p2 = new SqlParameter("@SCORE", scoremst.SCORE);

        
                SqlParameter p3 = new SqlParameter("@STATUS_ID", scoremst.STATUS_ID);

                SqlParameter p4 = new SqlParameter("@DELETE_FLAG", scoremst.DELETE_FLAG);

                SqlParameter p5 = new SqlParameter("@CREATED_USER", scoremst.CREATED_USER);
                SqlParameter p6 = new SqlParameter("@CREATED_DATE", c.dt);
                SqlParameter p7 = new SqlParameter("@IMAGE_ID", scoremst.IMAGE_ID);

                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                sqlParameters.Add(p3);
                sqlParameters.Add(p4);
                sqlParameters.Add(p5);
                sqlParameters.Add(p6);
                sqlParameters.Add(p7);


                string sqlcmd = "insert into VS_SCORE_MST(SCORE_TEXT,SCORE,STATUS_ID,";
                sqlcmd += "DELETE_FLAG,CREATED_USER,CREATED_DATE,IMAGE_ID) values(@SCORE_TEXT,@SCORE,";
                sqlcmd += "@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE,@IMAGE_ID)";
                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;
              
            }
            return result;
          
        }

        public int UpdateScore(VS_SCORE_MST scoremst)
        {
            int result = 0;
        
            try
            {
                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@SCORE_TEXT", scoremst.SCORE_TEXT);
                SqlParameter p2 = new SqlParameter("@SCORE", scoremst.SCORE);


                SqlParameter p3 = new SqlParameter("@STATUS_ID", scoremst.STATUS_ID);

                SqlParameter p4 = new SqlParameter("@DELETE_FLAG", scoremst.DELETE_FLAG);

                SqlParameter p5 = new SqlParameter("@UPDATED_USER", scoremst.UPDATED_USER);
                SqlParameter p6 = new SqlParameter("@UPDATED_DATE", c.dt);
                SqlParameter p7 = new SqlParameter("@IMAGE_ID", scoremst.IMAGE_ID);
                SqlParameter p8 = new SqlParameter("@SCORE_ID", scoremst.SCORE_ID);

                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                sqlParameters.Add(p3);
                sqlParameters.Add(p4);
                sqlParameters.Add(p5);
                sqlParameters.Add(p6);
                sqlParameters.Add(p7);
                sqlParameters.Add(p8);
              

                string sqlcmd = "Update VS_SCORE_MST set SCORE_TEXT = @SCORE_TEXT,SCORE=@SCORE,";
                sqlcmd += "STATUS_ID=@STATUS_ID,";
                sqlcmd += "DELETE_FLAG=@DELETE_FLAG,UPDATED_USER=@UPDATED_USER,UPDATED_DATE=@UPDATED_DATE,IMAGE_ID=@IMAGE_ID";
                sqlcmd += " Where SCORE_ID =@SCORE_ID";



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
