using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_Models;
using System.Data;
using System.Data.SqlClient;

namespace Vasthu_DataAccess
{
    public class VastuMasterDataAccess : BaseDataAccess
    {
        private string VastuQuery(int vastuID)
        {
            string strcmd = "";

            strcmd += "Select M.VASTU_ID,M.AREA_ID,M.DIRECTION_ID,M.VASTU_TYPE_ID,M.SCORE_ID,";
            strcmd += "M.EXTRA_SCORE,M.EXTRA_SCORE OLD_EXTRA_SCORE,";
            if (vastuID != 0)
            {
                strcmd += "M.SHORT_DESCRIPTION,M.SHORT_DESCRIPTION OLD_SHORT_DESCRIPTION,";
                strcmd += "M.LONG_DESCRIPTION,M.LONG_DESCRIPTION OLD_SHORT_DESCRIPTION,M.DELETE_FLAG OLD_DELETE_FLAG, ";
            }
            strcmd += "M.DELETE_FLAG,C.LOGIN_NAME CREATED_USER_NAME,M.CREATED_DATE C_USER_DATE,";
            strcmd += "U.LOGIN_NAME UPDATED_USER_NAME, M.UPDATED_DATE U_USER_DATE,";
            strcmd += "VT.VASTU_TYPE,A.AREA,D.DIRECTION,S.SCORE,null OLD_SCORE";
            strcmd += " From  VS_VASTU_MST M ";
            strcmd += " Left Join VS_VASTU_TYPE_MST VT on VT.VASTU_TYPE_ID = M.VASTU_TYPE_ID ";
            strcmd += " Left Join VS_AREA_MST A on A.AREA_ID = M.AREA_ID ";
            strcmd += " Left Join VS_DIRECTION_MST D on D.DIRECTION_ID = M.DIRECTION_ID ";
            strcmd += " Left Join VS_SCORE_MST S on S.SCORE_ID = M.SCORE_ID ";
            strcmd += " Left Join VS_USER_MST C on C.USER_ID = M.CREATED_USER ";
            strcmd += " Left Join VS_USER_MST U on U.USER_ID = M.UPDATED_USER ";
            if (vastuID != 0)
            {
                strcmd += " Where M.VASTU_ID = @vastuID";
            }
           
            strcmd += " ORDER BY VT.VASTU_TYPE,A.AREA,D.DIRECTION DESC ";

            return strcmd;
        }
        private string VastuEditQuery(int vastuID)
        {
            string strcmd = "";

            strcmd += "Select M.VASTU_ID,M.AREA_ID,M.DIRECTION_ID,M.VASTU_TYPE_ID,M.SCORE_ID,";
            strcmd += "M.EXTRA_SCORE,M.EXTRA_SCORE OLD_EXTRA_SCORE,";
            strcmd += "M.SHORT_DESCRIPTION,M.SHORT_DESCRIPTION OLD_SHORT_DESCRIPTION,";
            strcmd += "M.LONG_DESCRIPTION,M.LONG_DESCRIPTION OLD_LONG_DESCRIPTION,M.DELETE_FLAG OLD_DELETE_FLAG, ";
            strcmd += "M.DELETE_FLAG,C.LOGIN_NAME CREATED_USER_NAME,M.CREATED_DATE C_USER_DATE,";//
            strcmd += "U.LOGIN_NAME UPDATED_USER_NAME, M.UPDATED_DATE U_USER_DATE,";
            strcmd += "VT.VASTU_TYPE,A.AREA,D.DIRECTION,S.SCORE,S.SCORE OLD_SCORE,M.SCORE_ID OLD_SCORE_ID  ";
            strcmd += " From  VS_VASTU_MST M ";
            strcmd += " Left Join VS_VASTU_TYPE_MST VT on VT.VASTU_TYPE_ID = M.VASTU_TYPE_ID ";
            strcmd += " Left Join VS_AREA_MST A on A.AREA_ID = M.AREA_ID ";
            strcmd += " Left Join VS_DIRECTION_MST D on D.DIRECTION_ID = M.DIRECTION_ID ";
            strcmd += " Left Join VS_SCORE_MST S on S.SCORE_ID = M.SCORE_ID ";
            strcmd += " Left Join VS_USER_MST C on C.USER_ID = M.CREATED_USER ";
            strcmd += " Left Join VS_USER_MST U on U.USER_ID = M.UPDATED_USER ";
            if (vastuID != 0)
            {
                strcmd += " Where M.VASTU_ID = @vastuID";
            }

            strcmd += " ORDER BY VT.VASTU_TYPE,A.AREA,D.DIRECTION DESC ";

            return strcmd;
        }
        private string VastuTypeList()
        {
            string strcmd = "";

            strcmd += "Select M.VASTU_TYPE_ID,M.VASTU_TYPE";
            strcmd += " From  VS_VASTU_TYPE_MST M ";
            strcmd += " Where STATUS_ID = 4 and DELETE_FLAG = 0";
            strcmd += " ORDER BY M.VASTU_TYPE";

            return strcmd;
        }

        private string AreaList()
        {
            string strcmd = "";

            strcmd += "Select M.AREA_ID,M.AREA";
            strcmd += " From  VS_AREA_MST M ";
            strcmd += " Where STATUS_ID = 4 and DELETE_FLAG = 0";
            strcmd += " ORDER BY M.AREA_ID";

            return strcmd;
        }

        private string ScoreList()
        {
            string strcmd = "";

            strcmd += "Select M.SCORE_ID,M.SCORE";
            strcmd += " From  VS_SCORE_MST M ";
            strcmd += " Where STATUS_ID = 4 and DELETE_FLAG = 0";
            strcmd += " ORDER BY M.SCORE";

            return strcmd;
        }

        private string DirectionList()
        {
            string strcmd = "";

            strcmd += "Select M.DIRECTION_ID,M.DIRECTION";
            strcmd += " From  VS_DIRECTION_MST M ";
            strcmd += " Where STATUS_ID = 4 and DELETE_FLAG = 0";
            strcmd += " ORDER BY M.DIRECTION";

            return strcmd;
        }

        private string AreasearchList(int area)
        {
            string strcmd = "";

            strcmd += "Select M.VASTU_ID,M.AREA_ID,M.DIRECTION_ID,M.VASTU_TYPE_ID,M.SCORE_ID,";
            strcmd += "M.EXTRA_SCORE,M.EXTRA_SCORE OLD_EXTRA_SCORE,";
            strcmd += "M.DELETE_FLAG,C.LOGIN_NAME CREATED_USER_NAME,M.CREATED_DATE C_USER_DATE,";
            strcmd += "U.LOGIN_NAME UPDATED_USER_NAME, M.UPDATED_DATE U_USER_DATE,";
            strcmd += "VT.VASTU_TYPE,A.AREA,D.DIRECTION,S.SCORE,null OLD_SCORE";
            strcmd += " From  VS_VASTU_MST M ";
            strcmd += " Left Join VS_VASTU_TYPE_MST VT on VT.VASTU_TYPE_ID = M.VASTU_TYPE_ID ";
            strcmd += " Left Join VS_AREA_MST A on A.AREA_ID = M.AREA_ID ";
            strcmd += " Left Join VS_DIRECTION_MST D on D.DIRECTION_ID = M.DIRECTION_ID ";
            strcmd += " Left Join VS_SCORE_MST S on S.SCORE_ID = M.SCORE_ID ";
            strcmd += " Left Join VS_USER_MST C on C.USER_ID = M.CREATED_USER ";
            strcmd += " Left Join VS_USER_MST U on U.USER_ID = M.UPDATED_USER ";
            strcmd += " Where A.AREA_ID = @area";

            return strcmd;
        }

        public List<VS_VASTU_TYPE_MST> GetAllVastuTypeList()
        {
            string strcmd = "";
            List<VS_VASTU_TYPE_MST> obj = new List<VS_VASTU_TYPE_MST>();
            try
            {

                strcmd = VastuTypeList();
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                obj = AdoHelper.ExecuteReader<VS_VASTU_TYPE_MST>(CommandType.Text, strcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;

        }

        public List<VS_AREA_MST> GetAllAreaList()
        {
            string strcmd = "";
            List<VS_AREA_MST> obj = new List<VS_AREA_MST>();
            try
            {

                strcmd = AreaList();
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                obj = AdoHelper.ExecuteReader<VS_AREA_MST>(CommandType.Text, strcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;

        }

        public List<VS_DIRECTION_MST> GetAllDirectionList()
        {
            string strcmd = "";
            List<VS_DIRECTION_MST> obj = new List<VS_DIRECTION_MST>();
            try
            {

                strcmd = DirectionList();
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                obj = AdoHelper.ExecuteReader<VS_DIRECTION_MST>(CommandType.Text, strcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;

        }

        public List<VS_SCORE_MST> GetAllScoreList()
        {
            string strcmd = "";
            List<VS_SCORE_MST> obj = new List<VS_SCORE_MST>();
            try
            {

                strcmd = ScoreList();
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                obj = AdoHelper.ExecuteReader<VS_SCORE_MST>(CommandType.Text, strcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;

        }

        public List<VS_VASTU_MST> GetAllVastu()
        {
            string strcmd = "";
            List<VS_VASTU_MST> obj = new List<VS_VASTU_MST>();
            try
            {
     
                strcmd = VastuQuery(0);
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                obj = AdoHelper.ExecuteReader<VS_VASTU_MST>(CommandType.Text, strcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;

        }

        public VS_VASTU_MST GetVastuByID(int vastuID)
        {
            string strcmd = "";
            VS_VASTU_MST obj = new VS_VASTU_MST();
            try
            {

                strcmd = VastuEditQuery(vastuID);
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@vastuID", vastuID);
                sqlParameters.Add(p1);
                obj = AdoHelper.ExecuteReaderSingle<VS_VASTU_MST>(CommandType.Text, strcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;

        }


        public List<VS_VASTU_MST> CheckVastuDetail(int vastutype, int area, int direction, int vastuid)
        {
            List<VS_VASTU_MST> obj = new List<VS_VASTU_MST>();
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                string strcmd = "";

                strcmd += "Select AREA_ID,DIRECTION_ID,VASTU_TYPE_ID ";
                strcmd += " From  VS_VASTU_MST M ";
                strcmd += " Where AREA_ID = @area And DIRECTION_ID = @direction And VASTU_TYPE_ID=@vastutype";
                SqlParameter p1 = new SqlParameter("@vastutype", vastutype);
                SqlParameter p2 = new SqlParameter("@area", area);
                SqlParameter p3 = new SqlParameter("@direction", direction);
                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                sqlParameters.Add(p3);

                if (vastuid == 0)
                {
                  
                    obj = AdoHelper.ExecuteReader<VS_VASTU_MST>(CommandType.Text, strcmd , sqlParameters);
                }
                else
                {
                    strcmd += " And VASTU_ID != @vastuid";

                    SqlParameter p4 = new SqlParameter("@vastuid", vastuid);
                    sqlParameters.Add(p4);
   
                    obj = AdoHelper.ExecuteReader<VS_VASTU_MST>(CommandType.Text, strcmd , sqlParameters);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }

        public int CreateVastu(VS_VASTU_MST vastumst)
        {
            int result = 0;
            try
            {
                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@AREA_ID", vastumst.AREA_ID);
                SqlParameter p2 = new SqlParameter("@DIRECTION_ID", vastumst.DIRECTION_ID);
                SqlParameter p3 = new SqlParameter("@VASTU_TYPE_ID", vastumst.VASTU_TYPE_ID);
                SqlParameter p4 = new SqlParameter("@SCORE_ID", vastumst.SCORE_ID);
                SqlParameter p5 = new SqlParameter("@EXTRA_SCORE", (object)vastumst.EXTRA_SCORE ?? DBNull.Value);
                SqlParameter p6 = new SqlParameter("@SHORT_DESCRIPTION", (object)vastumst.SHORT_DESCRIPTION ?? DBNull.Value);
                SqlParameter p7 = new SqlParameter("@LONG_DESCRIPTION", (object)vastumst.LONG_DESCRIPTION ?? DBNull.Value);
                SqlParameter p8 = new SqlParameter("@STATUS_ID", vastumst.STATUS_ID);
                SqlParameter p9 = new SqlParameter("@DELETE_FLAG", vastumst.DELETE_FLAG);
                SqlParameter p10 = new SqlParameter("@CREATED_USER", vastumst.CREATED_USER);
                SqlParameter p11 = new SqlParameter("@CREATED_DATE", c.dt);

         
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



                string sqlcmd = "insert into VS_VASTU_MST(AREA_ID,DIRECTION_ID,VASTU_TYPE_ID,SCORE_ID,EXTRA_SCORE,";
                sqlcmd += "SHORT_DESCRIPTION,LONG_DESCRIPTION,STATUS_ID,DELETE_FLAG,CREATED_USER,CREATED_DATE) values ";
                sqlcmd += "(@AREA_ID,@DIRECTION_ID,@VASTU_TYPE_ID,@SCORE_ID,@EXTRA_SCORE,@SHORT_DESCRIPTION,@LONG_DESCRIPTION,";
                sqlcmd += "@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE)";
                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);

                sqlParameters.Remove(p1);
                sqlParameters.Remove(p2);
                sqlParameters.Remove(p3);
                sqlParameters.Remove(p4);
                sqlParameters.Remove(p5);
                sqlParameters.Remove(p6);
                sqlParameters.Remove(p7);
                sqlParameters.Remove(p8);
                sqlParameters.Remove(p9);
                sqlParameters.Remove(p10);
                sqlParameters.Remove(p11);

                sqlcmd = "select top 1 VST.VASTU_ID,VST.AREA_ID,AREA.AREA ,VST.DIRECTION_ID,DST.DIRECTION,VST.VASTU_TYPE_ID,VAS.VASTU_TYPE,VST.SCORE_ID,SCR.SCORE,VST.EXTRA_SCORE,VST.SHORT_DESCRIPTION,VST.LONG_DESCRIPTION,VST.STATUS_ID,VST.DELETE_FLAG,VST.CREATED_USER,VST.CREATED_DATE from VS_VASTU_MST[VST] JOIN VS_AREA_MST[AREA] ON VST.AREA_ID = AREA.AREA_ID JOIN VS_DIRECTION_MST DST ON VST.DIRECTION_ID = DST.DIRECTION_ID JOIN VS_VASTU_TYPE_MST VAS ON VST.VASTU_TYPE_ID=VAS.VASTU_TYPE_ID JOIN VS_SCORE_MST SCR ON VST.SCORE_ID = SCR.SCORE_ID ORDER BY VASTU_ID desc";

                List<VS_VASTU_MST> obj = new List<VS_VASTU_MST>();
                obj = AdoHelper.ExecuteReader<VS_VASTU_MST>(CommandType.Text, sqlcmd, sqlParameters);

                result = InsertCreateLongDescLog(obj);
                result = InsertCreateShortDescLog(obj);
                result = InsertCreateExtraScoreLog(obj);
                result = InsertCreateScoreLog(obj);
               // result = InsertCreateStatusLog(obj);

            }
            catch (Exception ex)
            {
                throw ex;
    
            }
            return result;
        }

        public int InsertCreateLongDescLog(List<VS_VASTU_MST> vastumst)
        {
            int result = 0;
            try
            {

                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@VASTU_ID", vastumst[0].VASTU_ID);
                SqlParameter p2 = new SqlParameter("@AREA_ID", vastumst[0].AREA_ID);
                SqlParameter p3 = new SqlParameter("@AREA", vastumst[0].AREA);
                SqlParameter p4 = new SqlParameter("@DIRECTION_ID", vastumst[0].DIRECTION_ID);
                SqlParameter p5 = new SqlParameter("@DIRECTION", vastumst[0].DIRECTION);
                SqlParameter p6 = new SqlParameter("@VASTU_TYPE_ID", vastumst[0].VASTU_TYPE_ID);
                SqlParameter p7 = new SqlParameter("@VASTU_TYPE", vastumst[0].VASTU_TYPE);
                SqlParameter p8 = new SqlParameter("@STATUS_ID", vastumst[0].STATUS_ID);
                SqlParameter p9 = new SqlParameter("@DELETE_FLAG", false);
                SqlParameter p10 = new SqlParameter("@CREATED_USER", vastumst[0].CREATED_USER);
                SqlParameter p11 = new SqlParameter("@CREATED_DATE", c.dt);
                SqlParameter p12 = new SqlParameter("@COLUMN_NAME", "長い説明");
                SqlParameter p13 = new SqlParameter("@OLD_LONG_DESCRIPTION", "新しく作成された");
                SqlParameter p14 = new SqlParameter("@LONG_DESCRIPTION", (object)vastumst[0].LONG_DESCRIPTION ?? DBNull.Value);

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


                string sqlcmd = "insert into VS_VASTU_MST_TRAN_DETAILS(VASTU_ID,AREA_ID,AREA,DIRECTION_ID,DIRECTION,";
                sqlcmd += "VASTU_TYPE_ID,VASTU_TYPE,STATUS_ID,DELETE_FLAG,CREATED_USER,CREATED_DATE,COLUMN_NAME,";
                sqlcmd += "OLD_DESCRIPTION_VALUE,NEW_DESCRIPTION_VALUE) values ";
                sqlcmd += "(@VASTU_ID,@AREA_ID,@AREA,@DIRECTION_ID,@DIRECTION,@VASTU_TYPE_ID,@VASTU_TYPE,";
                sqlcmd += "@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE,@COLUMN_NAME,";
                sqlcmd += "@OLD_LONG_DESCRIPTION,@LONG_DESCRIPTION)";


                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return result;

        }

        public int DeleteCreateLongDescLog(List<VS_VASTU_MST> vastumst)
        {
            int result = 0;
            try
            {

                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@VASTU_ID", vastumst[0].VASTU_ID);
                SqlParameter p2 = new SqlParameter("@AREA_ID", vastumst[0].AREA_ID);
                SqlParameter p3 = new SqlParameter("@AREA", vastumst[0].AREA);
                SqlParameter p4 = new SqlParameter("@DIRECTION_ID", vastumst[0].DIRECTION_ID);
                SqlParameter p5 = new SqlParameter("@DIRECTION", vastumst[0].DIRECTION);
                SqlParameter p6 = new SqlParameter("@VASTU_TYPE_ID", vastumst[0].VASTU_TYPE_ID);
                SqlParameter p7 = new SqlParameter("@VASTU_TYPE", vastumst[0].VASTU_TYPE);
                SqlParameter p8 = new SqlParameter("@STATUS_ID", vastumst[0].STATUS_ID);
                SqlParameter p9 = new SqlParameter("@DELETE_FLAG", false);
                SqlParameter p10 = new SqlParameter("@CREATED_USER", vastumst[0].CREATED_USER);
                SqlParameter p11 = new SqlParameter("@CREATED_DATE", c.dt);
                SqlParameter p12 = new SqlParameter("@COLUMN_NAME", "長い説明");
                SqlParameter p13 = new SqlParameter("@OLD_LONG_DESCRIPTION", "削除された");
                SqlParameter p14 = new SqlParameter("@LONG_DESCRIPTION", (object)vastumst[0].LONG_DESCRIPTION ?? DBNull.Value);

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


                string sqlcmd = "insert into VS_VASTU_MST_TRAN_DETAILS(VASTU_ID,AREA_ID,AREA,DIRECTION_ID,DIRECTION,";
                sqlcmd += "VASTU_TYPE_ID,VASTU_TYPE,STATUS_ID,DELETE_FLAG,CREATED_USER,CREATED_DATE,COLUMN_NAME,";
                sqlcmd += "OLD_DESCRIPTION_VALUE,NEW_DESCRIPTION_VALUE) values ";
                sqlcmd += "(@VASTU_ID,@AREA_ID,@AREA,@DIRECTION_ID,@DIRECTION,@VASTU_TYPE_ID,@VASTU_TYPE,";
                sqlcmd += "@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE,@COLUMN_NAME,";
                sqlcmd += "@OLD_LONG_DESCRIPTION,@LONG_DESCRIPTION)";


                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return result;

        }


        public int InsertLongDescLog(VS_VASTU_MST vastumst)
        {
            int result = 0;
            try
            {

                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@VASTU_ID", vastumst.VASTU_ID);
                SqlParameter p2 = new SqlParameter("@AREA_ID", vastumst.AREA_ID);
                SqlParameter p3 = new SqlParameter("@AREA", vastumst.AREA);
                SqlParameter p4 = new SqlParameter("@DIRECTION_ID", vastumst.DIRECTION_ID);
                SqlParameter p5 = new SqlParameter("@DIRECTION", vastumst.DIRECTION);
                SqlParameter p6 = new SqlParameter("@VASTU_TYPE_ID", vastumst.VASTU_TYPE_ID);
                SqlParameter p7 = new SqlParameter("@VASTU_TYPE", vastumst.VASTU_TYPE);
                SqlParameter p8 = new SqlParameter("@STATUS_ID", vastumst.STATUS_ID);
                SqlParameter p9 = new SqlParameter("@DELETE_FLAG", false);
                SqlParameter p10 = new SqlParameter("@CREATED_USER", vastumst.UPDATED_USER);
                SqlParameter p11 = new SqlParameter("@CREATED_DATE", c.dt);
                SqlParameter p12 = new SqlParameter("@COLUMN_NAME", "長い説明");
                SqlParameter p13 = new SqlParameter("@OLD_LONG_DESCRIPTION", (object)vastumst.OLD_LONG_DESCRIPTION ?? DBNull.Value);
                SqlParameter p14 = new SqlParameter("@LONG_DESCRIPTION", (object)vastumst.LONG_DESCRIPTION ?? DBNull.Value);

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


                string sqlcmd = "insert into VS_VASTU_MST_TRAN_DETAILS(VASTU_ID,AREA_ID,AREA,DIRECTION_ID,DIRECTION,";
                sqlcmd += "VASTU_TYPE_ID,VASTU_TYPE,STATUS_ID,DELETE_FLAG,CREATED_USER,CREATED_DATE,COLUMN_NAME,";
                sqlcmd += "OLD_DESCRIPTION_VALUE,NEW_DESCRIPTION_VALUE) values ";
                sqlcmd += "(@VASTU_ID,@AREA_ID,@AREA,@DIRECTION_ID,@DIRECTION,@VASTU_TYPE_ID,@VASTU_TYPE,";
                sqlcmd += "@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE,@COLUMN_NAME,";
                sqlcmd += "@OLD_LONG_DESCRIPTION,@LONG_DESCRIPTION)";


                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return result;

        }
        public int InsertCreateShortDescLog(List<VS_VASTU_MST> vastumst)
        {
            int result = 0;
            try
            {

                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@VASTU_ID", vastumst[0].VASTU_ID);
                SqlParameter p2 = new SqlParameter("@AREA_ID", vastumst[0].AREA_ID);
                SqlParameter p3 = new SqlParameter("@AREA", vastumst[0].AREA);
                SqlParameter p4 = new SqlParameter("@DIRECTION_ID", vastumst[0].DIRECTION_ID);
                SqlParameter p5 = new SqlParameter("@DIRECTION", vastumst[0].DIRECTION);
                SqlParameter p6 = new SqlParameter("@VASTU_TYPE_ID", vastumst[0].VASTU_TYPE_ID);
                SqlParameter p7 = new SqlParameter("@VASTU_TYPE", vastumst[0].VASTU_TYPE);
                SqlParameter p8 = new SqlParameter("@STATUS_ID", vastumst[0].STATUS_ID);
                SqlParameter p9 = new SqlParameter("@DELETE_FLAG", false);
                SqlParameter p10 = new SqlParameter("@CREATED_USER", vastumst[0].CREATED_USER);
                SqlParameter p11 = new SqlParameter("@CREATED_DATE", c.dt);
                SqlParameter p12 = new SqlParameter("@COLUMN_NAME", "簡単な説明");
                SqlParameter p13 = new SqlParameter("@OLD_SHORT_DESCRIPTION", "新しく作成された");
                SqlParameter p14 = new SqlParameter("@SHORT_DESCRIPTION", (object)vastumst[0].SHORT_DESCRIPTION ?? DBNull.Value);

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


                string sqlcmd = "insert into VS_VASTU_MST_TRAN_DETAILS(VASTU_ID,AREA_ID,AREA,DIRECTION_ID,DIRECTION,";
                sqlcmd += "VASTU_TYPE_ID,VASTU_TYPE,STATUS_ID,DELETE_FLAG,CREATED_USER,CREATED_DATE,COLUMN_NAME,";
                sqlcmd += "OLD_DESCRIPTION_VALUE,NEW_DESCRIPTION_VALUE) values ";
                sqlcmd += "(@VASTU_ID,@AREA_ID,@AREA,@DIRECTION_ID,@DIRECTION,@VASTU_TYPE_ID,@VASTU_TYPE,";
                sqlcmd += "@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE,@COLUMN_NAME,";
                sqlcmd += "@OLD_SHORT_DESCRIPTION,@SHORT_DESCRIPTION)";


                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return result;

        }
        public int DeleteCreateShortDescLog(List<VS_VASTU_MST> vastumst)
        {
            int result = 0;
            try
            {

                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@VASTU_ID", vastumst[0].VASTU_ID);
                SqlParameter p2 = new SqlParameter("@AREA_ID", vastumst[0].AREA_ID);
                SqlParameter p3 = new SqlParameter("@AREA", vastumst[0].AREA);
                SqlParameter p4 = new SqlParameter("@DIRECTION_ID", vastumst[0].DIRECTION_ID);
                SqlParameter p5 = new SqlParameter("@DIRECTION", vastumst[0].DIRECTION);
                SqlParameter p6 = new SqlParameter("@VASTU_TYPE_ID", vastumst[0].VASTU_TYPE_ID);
                SqlParameter p7 = new SqlParameter("@VASTU_TYPE", vastumst[0].VASTU_TYPE);
                SqlParameter p8 = new SqlParameter("@STATUS_ID", vastumst[0].STATUS_ID);
                SqlParameter p9 = new SqlParameter("@DELETE_FLAG", false);
                SqlParameter p10 = new SqlParameter("@CREATED_USER", vastumst[0].CREATED_USER);
                SqlParameter p11 = new SqlParameter("@CREATED_DATE", c.dt);
                SqlParameter p12 = new SqlParameter("@COLUMN_NAME", "簡単な説明");
                SqlParameter p13 = new SqlParameter("@OLD_SHORT_DESCRIPTION", "削除された" );
                SqlParameter p14 = new SqlParameter("@SHORT_DESCRIPTION", (object)vastumst[0].SHORT_DESCRIPTION ?? DBNull.Value);

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


                string sqlcmd = "insert into VS_VASTU_MST_TRAN_DETAILS(VASTU_ID,AREA_ID,AREA,DIRECTION_ID,DIRECTION,";
                sqlcmd += "VASTU_TYPE_ID,VASTU_TYPE,STATUS_ID,DELETE_FLAG,CREATED_USER,CREATED_DATE,COLUMN_NAME,";
                sqlcmd += "OLD_DESCRIPTION_VALUE,NEW_DESCRIPTION_VALUE) values ";
                sqlcmd += "(@VASTU_ID,@AREA_ID,@AREA,@DIRECTION_ID,@DIRECTION,@VASTU_TYPE_ID,@VASTU_TYPE,";
                sqlcmd += "@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE,@COLUMN_NAME,";
                sqlcmd += "@OLD_SHORT_DESCRIPTION,@SHORT_DESCRIPTION)";


                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return result;

        }
        public int InsertShortDescLog(VS_VASTU_MST vastumst)
        {
            int result = 0;
            try
            {

                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@VASTU_ID", vastumst.VASTU_ID);
                SqlParameter p2 = new SqlParameter("@AREA_ID", vastumst.AREA_ID);
                SqlParameter p3 = new SqlParameter("@AREA", vastumst.AREA);
                SqlParameter p4 = new SqlParameter("@DIRECTION_ID", vastumst.DIRECTION_ID);
                SqlParameter p5 = new SqlParameter("@DIRECTION", vastumst.DIRECTION);
                SqlParameter p6 = new SqlParameter("@VASTU_TYPE_ID", vastumst.VASTU_TYPE_ID);
                SqlParameter p7 = new SqlParameter("@VASTU_TYPE", vastumst.VASTU_TYPE);
                SqlParameter p8 = new SqlParameter("@STATUS_ID", vastumst.STATUS_ID);
                SqlParameter p9 = new SqlParameter("@DELETE_FLAG", false);
                SqlParameter p10 = new SqlParameter("@CREATED_USER", vastumst.UPDATED_USER);
                SqlParameter p11 = new SqlParameter("@CREATED_DATE", c.dt);
                SqlParameter p12 = new SqlParameter("@COLUMN_NAME", "簡単な説明");
                SqlParameter p13 = new SqlParameter("@OLD_SHORT_DESCRIPTION", (object)vastumst.OLD_SHORT_DESCRIPTION ?? DBNull.Value);
                SqlParameter p14 = new SqlParameter("@SHORT_DESCRIPTION", (object)vastumst.SHORT_DESCRIPTION ?? DBNull.Value);

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


                string sqlcmd = "insert into VS_VASTU_MST_TRAN_DETAILS(VASTU_ID,AREA_ID,AREA,DIRECTION_ID,DIRECTION,";
                sqlcmd += "VASTU_TYPE_ID,VASTU_TYPE,STATUS_ID,DELETE_FLAG,CREATED_USER,CREATED_DATE,COLUMN_NAME,";
                sqlcmd += "OLD_DESCRIPTION_VALUE,NEW_DESCRIPTION_VALUE) values ";
                sqlcmd += "(@VASTU_ID,@AREA_ID,@AREA,@DIRECTION_ID,@DIRECTION,@VASTU_TYPE_ID,@VASTU_TYPE,";
                sqlcmd += "@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE,@COLUMN_NAME,";
                sqlcmd += "@OLD_SHORT_DESCRIPTION,@SHORT_DESCRIPTION)";


                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return result;

        }
        public int InsertCreateExtraScoreLog(List<VS_VASTU_MST> vastumst)
        {
            int result = 0;
            try
            {

                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@VASTU_ID", vastumst[0].VASTU_ID);
                SqlParameter p2 = new SqlParameter("@AREA_ID", vastumst[0].AREA_ID);
                SqlParameter p3 = new SqlParameter("@AREA", vastumst[0].AREA);
                SqlParameter p4 = new SqlParameter("@DIRECTION_ID", vastumst[0].DIRECTION_ID);
                SqlParameter p5 = new SqlParameter("@DIRECTION", vastumst[0].DIRECTION);
                SqlParameter p6 = new SqlParameter("@VASTU_TYPE_ID", vastumst[0].VASTU_TYPE_ID);
                SqlParameter p7 = new SqlParameter("@VASTU_TYPE", vastumst[0].VASTU_TYPE);
                SqlParameter p8 = new SqlParameter("@STATUS_ID", vastumst[0].STATUS_ID);
                SqlParameter p9 = new SqlParameter("@DELETE_FLAG", false);
                SqlParameter p10 = new SqlParameter("@CREATED_USER", vastumst[0].CREATED_USER);
                SqlParameter p11 = new SqlParameter("@CREATED_DATE", c.dt);
                SqlParameter p12 = new SqlParameter("@COLUMN_NAME", "追加点");
                SqlParameter p13 = new SqlParameter("@OLD_SCORE_VALUE", "0");
                SqlParameter p14 = new SqlParameter("@NEW_SCORE_VALUE", (object)vastumst[0].EXTRA_SCORE ?? DBNull.Value);

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

                if (vastumst[0].EXTRA_SCORE != null)
                {

                    string sqlcmd = "insert into VS_VASTU_MST_TRAN_DETAILS(VASTU_ID,AREA_ID,AREA,DIRECTION_ID,DIRECTION,";
                    sqlcmd += "VASTU_TYPE_ID,VASTU_TYPE,STATUS_ID,DELETE_FLAG,CREATED_USER,CREATED_DATE,COLUMN_NAME,";
                    sqlcmd += "OLD_SCORE_VALUE,NEW_SCORE_VALUE) values ";
                    sqlcmd += "(@VASTU_ID,@AREA_ID,@AREA,@DIRECTION_ID,@DIRECTION,@VASTU_TYPE_ID,@VASTU_TYPE,";
                    sqlcmd += "@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE,@COLUMN_NAME,";
                    sqlcmd += "@OLD_SCORE_VALUE,@NEW_SCORE_VALUE)";


                    result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return result;

        }

        public int DeleteCreateExtraScoreLog(List<VS_VASTU_MST> vastumst)
        {
            int result = 0;
            try
            {

                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@VASTU_ID", vastumst[0].VASTU_ID);
                SqlParameter p2 = new SqlParameter("@AREA_ID", vastumst[0].AREA_ID);
                SqlParameter p3 = new SqlParameter("@AREA", vastumst[0].AREA);
                SqlParameter p4 = new SqlParameter("@DIRECTION_ID", vastumst[0].DIRECTION_ID);
                SqlParameter p5 = new SqlParameter("@DIRECTION", vastumst[0].DIRECTION);
                SqlParameter p6 = new SqlParameter("@VASTU_TYPE_ID", vastumst[0].VASTU_TYPE_ID);
                SqlParameter p7 = new SqlParameter("@VASTU_TYPE", vastumst[0].VASTU_TYPE);
                SqlParameter p8 = new SqlParameter("@STATUS_ID", vastumst[0].STATUS_ID);
                SqlParameter p9 = new SqlParameter("@DELETE_FLAG", false);
                SqlParameter p10 = new SqlParameter("@CREATED_USER", vastumst[0].CREATED_USER);
                SqlParameter p11 = new SqlParameter("@CREATED_DATE", c.dt);
                SqlParameter p12 = new SqlParameter("@COLUMN_NAME", "追加点");
                SqlParameter p13 = new SqlParameter("@OLD_SCORE_VALUE", (object)vastumst[0].EXTRA_SCORE ?? DBNull.Value);
                SqlParameter p14 = new SqlParameter("@NEW_SCORE_VALUE", "0");

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

                if (vastumst[0].EXTRA_SCORE != null)
                {

                    string sqlcmd = "insert into VS_VASTU_MST_TRAN_DETAILS(VASTU_ID,AREA_ID,AREA,DIRECTION_ID,DIRECTION,";
                    sqlcmd += "VASTU_TYPE_ID,VASTU_TYPE,STATUS_ID,DELETE_FLAG,CREATED_USER,CREATED_DATE,COLUMN_NAME,";
                    sqlcmd += "OLD_SCORE_VALUE,NEW_SCORE_VALUE) values ";
                    sqlcmd += "(@VASTU_ID,@AREA_ID,@AREA,@DIRECTION_ID,@DIRECTION,@VASTU_TYPE_ID,@VASTU_TYPE,";
                    sqlcmd += "@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE,@COLUMN_NAME,";
                    sqlcmd += "@OLD_SCORE_VALUE,@NEW_SCORE_VALUE)";


                    result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return result;

        }
        public int InsertExtraScoreLog(VS_VASTU_MST vastumst)
        {
            int result = 0;
            try
            {

                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                if (vastumst.OLD_EXTRA_SCORE == null)
                {
                    vastumst.OLD_EXTRA_SCORE = "0";
                }

                SqlParameter p1 = new SqlParameter("@VASTU_ID", vastumst.VASTU_ID);
                SqlParameter p2 = new SqlParameter("@AREA_ID", vastumst.AREA_ID);
                SqlParameter p3 = new SqlParameter("@AREA", vastumst.AREA);
                SqlParameter p4 = new SqlParameter("@DIRECTION_ID", vastumst.DIRECTION_ID);
                SqlParameter p5 = new SqlParameter("@DIRECTION", vastumst.DIRECTION);
                SqlParameter p6 = new SqlParameter("@VASTU_TYPE_ID", vastumst.VASTU_TYPE_ID);
                SqlParameter p7 = new SqlParameter("@VASTU_TYPE", vastumst.VASTU_TYPE);
                SqlParameter p8 = new SqlParameter("@STATUS_ID", vastumst.STATUS_ID);
                SqlParameter p9 = new SqlParameter("@DELETE_FLAG", false);
                SqlParameter p10 = new SqlParameter("@CREATED_USER", vastumst.UPDATED_USER);
                SqlParameter p11 = new SqlParameter("@CREATED_DATE", c.dt);
                SqlParameter p12 = new SqlParameter("@COLUMN_NAME", "追加点");
                SqlParameter p13 = new SqlParameter("@OLD_SCORE_VALUE", (object)vastumst.OLD_EXTRA_SCORE ?? DBNull.Value);
                SqlParameter p14 = new SqlParameter("@NEW_SCORE_VALUE", (object)vastumst.EXTRA_SCORE ?? DBNull.Value);

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
 

                string sqlcmd = "insert into VS_VASTU_MST_TRAN_DETAILS(VASTU_ID,AREA_ID,AREA,DIRECTION_ID,DIRECTION,";
                sqlcmd += "VASTU_TYPE_ID,VASTU_TYPE,STATUS_ID,DELETE_FLAG,CREATED_USER,CREATED_DATE,COLUMN_NAME,";
                sqlcmd += "OLD_SCORE_VALUE,NEW_SCORE_VALUE) values ";
                sqlcmd += "(@VASTU_ID,@AREA_ID,@AREA,@DIRECTION_ID,@DIRECTION,@VASTU_TYPE_ID,@VASTU_TYPE,";
                sqlcmd += "@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE,@COLUMN_NAME,";
                sqlcmd += "@OLD_SCORE_VALUE,@NEW_SCORE_VALUE)";


                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return result;

        }
        public int InsertCreateScoreLog(List<VS_VASTU_MST> vastumst)
        {
            int result = 0;
            try
            {

                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@VASTU_ID", vastumst[0].VASTU_ID);
                SqlParameter p2 = new SqlParameter("@AREA_ID", vastumst[0].AREA_ID);
                SqlParameter p3 = new SqlParameter("@AREA", vastumst[0].AREA);
                SqlParameter p4 = new SqlParameter("@DIRECTION_ID", vastumst[0].DIRECTION_ID);
                SqlParameter p5 = new SqlParameter("@DIRECTION", vastumst[0].DIRECTION);
                SqlParameter p6 = new SqlParameter("@VASTU_TYPE_ID", vastumst[0].VASTU_TYPE_ID);
                SqlParameter p7 = new SqlParameter("@VASTU_TYPE", vastumst[0].VASTU_TYPE);
                SqlParameter p8 = new SqlParameter("@STATUS_ID", vastumst[0].STATUS_ID);
                SqlParameter p9 = new SqlParameter("@DELETE_FLAG", false);
                SqlParameter p10 = new SqlParameter("@CREATED_USER", vastumst[0].CREATED_USER);
                SqlParameter p11 = new SqlParameter("@CREATED_DATE", c.dt);
                SqlParameter p12 = new SqlParameter("@COLUMN_NAME", "点数");
                SqlParameter p13 = new SqlParameter("@OLD_COLUMN_ID", "0");
                SqlParameter p14 = new SqlParameter("@NEW_COLUMN_ID", vastumst[0].SCORE_ID);
                SqlParameter p15 = new SqlParameter("@OLD_SCORE_VALUE", "0");
                SqlParameter p16 = new SqlParameter("@NEW_SCORE_VALUE", vastumst[0].SCORE);

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

                string sqlcmd = "insert into VS_VASTU_MST_TRAN_DETAILS(VASTU_ID,AREA_ID,AREA,DIRECTION_ID,DIRECTION,";
                sqlcmd += "VASTU_TYPE_ID,VASTU_TYPE,STATUS_ID,DELETE_FLAG,CREATED_USER,CREATED_DATE,COLUMN_NAME,";
                sqlcmd += "OLD_COLUMN_ID,NEW_COLUMN_ID,OLD_SCORE_VALUE,NEW_SCORE_VALUE) values ";
                sqlcmd += "(@VASTU_ID,@AREA_ID,@AREA,@DIRECTION_ID,@DIRECTION,@VASTU_TYPE_ID,@VASTU_TYPE,";
                sqlcmd += "@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE,@COLUMN_NAME,@OLD_COLUMN_ID,";
                sqlcmd += "@NEW_COLUMN_ID,@OLD_SCORE_VALUE,@NEW_SCORE_VALUE)";


                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return result;

        }
        public int DeleteCreateScoreLog(List<VS_VASTU_MST> vastumst)
        {
            int result = 0;
            try
            {

                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@VASTU_ID", vastumst[0].VASTU_ID);
                SqlParameter p2 = new SqlParameter("@AREA_ID", vastumst[0].AREA_ID);
                SqlParameter p3 = new SqlParameter("@AREA", vastumst[0].AREA);
                SqlParameter p4 = new SqlParameter("@DIRECTION_ID", vastumst[0].DIRECTION_ID);
                SqlParameter p5 = new SqlParameter("@DIRECTION", vastumst[0].DIRECTION);
                SqlParameter p6 = new SqlParameter("@VASTU_TYPE_ID", vastumst[0].VASTU_TYPE_ID);
                SqlParameter p7 = new SqlParameter("@VASTU_TYPE", vastumst[0].VASTU_TYPE);
                SqlParameter p8 = new SqlParameter("@STATUS_ID", vastumst[0].STATUS_ID);
                SqlParameter p9 = new SqlParameter("@DELETE_FLAG", false);
                SqlParameter p10 = new SqlParameter("@CREATED_USER", vastumst[0].CREATED_USER);
                SqlParameter p11 = new SqlParameter("@CREATED_DATE", c.dt);
                SqlParameter p12 = new SqlParameter("@COLUMN_NAME", "点数");
                SqlParameter p13 = new SqlParameter("@OLD_COLUMN_ID", vastumst[0].SCORE_ID);
                SqlParameter p14 = new SqlParameter("@NEW_COLUMN_ID", "0");
                SqlParameter p15 = new SqlParameter("@OLD_SCORE_VALUE", vastumst[0].SCORE);
                SqlParameter p16 = new SqlParameter("@NEW_SCORE_VALUE", "0");

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

                string sqlcmd = "insert into VS_VASTU_MST_TRAN_DETAILS(VASTU_ID,AREA_ID,AREA,DIRECTION_ID,DIRECTION,";
                sqlcmd += "VASTU_TYPE_ID,VASTU_TYPE,STATUS_ID,DELETE_FLAG,CREATED_USER,CREATED_DATE,COLUMN_NAME,";
                sqlcmd += "OLD_COLUMN_ID,NEW_COLUMN_ID,OLD_SCORE_VALUE,NEW_SCORE_VALUE) values ";
                sqlcmd += "(@VASTU_ID,@AREA_ID,@AREA,@DIRECTION_ID,@DIRECTION,@VASTU_TYPE_ID,@VASTU_TYPE,";
                sqlcmd += "@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE,@COLUMN_NAME,@OLD_COLUMN_ID,";
                sqlcmd += "@NEW_COLUMN_ID,@OLD_SCORE_VALUE,@NEW_SCORE_VALUE)";


                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return result;

        }
        public int InsertScoreLog(VS_VASTU_MST vastumst)
        {
            int result = 0;
            try
            {
           
                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@VASTU_ID", vastumst.VASTU_ID);
                SqlParameter p2 = new SqlParameter("@AREA_ID", vastumst.AREA_ID);
                SqlParameter p3 = new SqlParameter("@AREA", vastumst.AREA);
                SqlParameter p4 = new SqlParameter("@DIRECTION_ID", vastumst.DIRECTION_ID);
                SqlParameter p5 = new SqlParameter("@DIRECTION", vastumst.DIRECTION);
                SqlParameter p6 = new SqlParameter("@VASTU_TYPE_ID", vastumst.VASTU_TYPE_ID);
                SqlParameter p7 = new SqlParameter("@VASTU_TYPE", vastumst.VASTU_TYPE);
                SqlParameter p8 = new SqlParameter("@STATUS_ID", vastumst.STATUS_ID);
                SqlParameter p9 = new SqlParameter("@DELETE_FLAG", false);
                SqlParameter p10 = new SqlParameter("@CREATED_USER", vastumst.UPDATED_USER);
                SqlParameter p11 = new SqlParameter("@CREATED_DATE", c.dt);
                SqlParameter p12 = new SqlParameter("@COLUMN_NAME", "点数");
                SqlParameter p13 = new SqlParameter("@OLD_COLUMN_ID", vastumst.OLD_SCORE_ID);
                SqlParameter p14 = new SqlParameter("@NEW_COLUMN_ID", vastumst.SCORE_ID);
                SqlParameter p15 = new SqlParameter("@OLD_SCORE_VALUE", vastumst.OLD_SCORE);
                SqlParameter p16 = new SqlParameter("@NEW_SCORE_VALUE", vastumst.SCORE);

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

                string sqlcmd = "insert into VS_VASTU_MST_TRAN_DETAILS(VASTU_ID,AREA_ID,AREA,DIRECTION_ID,DIRECTION,";
                sqlcmd += "VASTU_TYPE_ID,VASTU_TYPE,STATUS_ID,DELETE_FLAG,CREATED_USER,CREATED_DATE,COLUMN_NAME,";
                sqlcmd += "OLD_COLUMN_ID,NEW_COLUMN_ID,OLD_SCORE_VALUE,NEW_SCORE_VALUE) values ";
                sqlcmd += "(@VASTU_ID,@AREA_ID,@AREA,@DIRECTION_ID,@DIRECTION,@VASTU_TYPE_ID,@VASTU_TYPE,";
                sqlcmd += "@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE,@COLUMN_NAME,@OLD_COLUMN_ID,";
                sqlcmd += "@NEW_COLUMN_ID,@OLD_SCORE_VALUE,@NEW_SCORE_VALUE)";


                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return result;

        }
        public int InsertCreateStatusLog(List<VS_VASTU_MST> vastumst)
        {
            int result = 0;
            try
            {
                if (vastumst[0].OLD_DELETE_FLAG == true)
                {
                    // vastumst.OLD_SCORE = "偽";
                    vastumst[0].OLD_SCORE = "1";
                }
                else
                {
                    //vastumst.OLD_SCORE = "本当";
                    vastumst[0].OLD_SCORE = "0";
                }
                if (vastumst[0].DELETE_FLAG == true)
                {
                    vastumst[0].SCORE = "1";
                    //vastumst.SCORE = "本当";
                }
                else
                {
                    vastumst[0].SCORE = "0";
                    //vastumst.SCORE = "誤り";
                }
                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@VASTU_ID", vastumst[0].VASTU_ID);
                SqlParameter p2 = new SqlParameter("@AREA_ID", vastumst[0].AREA_ID);
                SqlParameter p3 = new SqlParameter("@AREA", vastumst[0].AREA);
                SqlParameter p4 = new SqlParameter("@DIRECTION_ID", vastumst[0].DIRECTION_ID);
                SqlParameter p5 = new SqlParameter("@DIRECTION", vastumst[0].DIRECTION);
                SqlParameter p6 = new SqlParameter("@VASTU_TYPE_ID", vastumst[0].VASTU_TYPE_ID);
                SqlParameter p7 = new SqlParameter("@VASTU_TYPE", vastumst[0].VASTU_TYPE);
                SqlParameter p8 = new SqlParameter("@STATUS_ID", vastumst[0].STATUS_ID);
                SqlParameter p9 = new SqlParameter("@DELETE_FLAG", false);
                SqlParameter p10 = new SqlParameter("@CREATED_USER", vastumst[0].UPDATED_USER);
                SqlParameter p11 = new SqlParameter("@CREATED_DATE", c.dt);
                SqlParameter p12 = new SqlParameter("@COLUMN_NAME", "アクティブ・非アクティブ");
                SqlParameter p13 = new SqlParameter("@OLD_SCORE_VALUE", "0");
                SqlParameter p14 = new SqlParameter("@NEW_SCORE_VALUE", vastumst[0].SCORE);

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


                string sqlcmd = "insert into VS_VASTU_MST_TRAN_DETAILS(VASTU_ID,AREA_ID,AREA,DIRECTION_ID,DIRECTION,";
                sqlcmd += "VASTU_TYPE_ID,VASTU_TYPE,STATUS_ID,DELETE_FLAG,CREATED_USER,CREATED_DATE,COLUMN_NAME,";
                sqlcmd += "OLD_SCORE_VALUE,NEW_SCORE_VALUE) values ";
                sqlcmd += "(@VASTU_ID,@AREA_ID,@AREA,@DIRECTION_ID,@DIRECTION,@VASTU_TYPE_ID,@VASTU_TYPE,";
                sqlcmd += "@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE,@COLUMN_NAME,";
                sqlcmd += "@OLD_SCORE_VALUE,@NEW_SCORE_VALUE)";


                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return result;

        }
        public int DeleteCreateVasStatusLog(List<VS_VASTU_MST> vastumst)
        {
            int result = 0;
            try
            {
                if (vastumst[0].OLD_DELETE_FLAG == true)
                {
                    // vastumst.OLD_SCORE = "偽";
                    vastumst[0].OLD_SCORE = "1";
                }
                else
                {
                    //vastumst.OLD_SCORE = "本当";
                    vastumst[0].OLD_SCORE = "0";
                }
                if (vastumst[0].DELETE_FLAG == true)
                {
                    vastumst[0].SCORE = "1";
                    //vastumst.SCORE = "本当";
                }
                else
                {
                    vastumst[0].SCORE = "0";
                    //vastumst.SCORE = "誤り";
                }
                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@VASTU_ID", vastumst[0].VASTU_ID);
                SqlParameter p2 = new SqlParameter("@AREA_ID", vastumst[0].AREA_ID);
                SqlParameter p3 = new SqlParameter("@AREA", vastumst[0].AREA);
                SqlParameter p4 = new SqlParameter("@DIRECTION_ID", vastumst[0].DIRECTION_ID);
                SqlParameter p5 = new SqlParameter("@DIRECTION", vastumst[0].DIRECTION);
                SqlParameter p6 = new SqlParameter("@VASTU_TYPE_ID", vastumst[0].VASTU_TYPE_ID);
                SqlParameter p7 = new SqlParameter("@VASTU_TYPE", vastumst[0].VASTU_TYPE);
                SqlParameter p8 = new SqlParameter("@STATUS_ID", vastumst[0].STATUS_ID);
                SqlParameter p9 = new SqlParameter("@DELETE_FLAG", false);
                SqlParameter p10 = new SqlParameter("@CREATED_USER", vastumst[0].UPDATED_USER);
                SqlParameter p11 = new SqlParameter("@CREATED_DATE", c.dt);
                SqlParameter p12 = new SqlParameter("@COLUMN_NAME", "アクティブ・非アクティブ");
                SqlParameter p13 = new SqlParameter("@OLD_SCORE_VALUE", vastumst[0].SCORE);
                SqlParameter p14 = new SqlParameter("@NEW_SCORE_VALUE", "0");

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

                if (vastumst[0].OLD_SCORE != "0")
                { 
                    string sqlcmd = "insert into VS_VASTU_MST_TRAN_DETAILS(VASTU_ID,AREA_ID,AREA,DIRECTION_ID,DIRECTION,";
                sqlcmd += "VASTU_TYPE_ID,VASTU_TYPE,STATUS_ID,DELETE_FLAG,CREATED_USER,CREATED_DATE,COLUMN_NAME,";
                sqlcmd += "OLD_SCORE_VALUE,NEW_SCORE_VALUE) values ";
                sqlcmd += "(@VASTU_ID,@AREA_ID,@AREA,@DIRECTION_ID,@DIRECTION,@VASTU_TYPE_ID,@VASTU_TYPE,";
                sqlcmd += "@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE,@COLUMN_NAME,";
                sqlcmd += "@OLD_SCORE_VALUE,@NEW_SCORE_VALUE)";


                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return result;

        }
        public int InsertStatusLog(VS_VASTU_MST vastumst)
        {
            int result = 0;
            try
            {
                if(vastumst.OLD_DELETE_FLAG == true)
                {
                    // vastumst.OLD_SCORE = "偽";
                    vastumst.OLD_SCORE = "1";
                }
                else
                {
                    //vastumst.OLD_SCORE = "本当";
                    vastumst.OLD_SCORE = "0";
                }
                if (vastumst.DELETE_FLAG == true)
                {
                    vastumst.SCORE = "1";
                    //vastumst.SCORE = "本当";
                }
                else
                {
                    vastumst.SCORE = "0";
                    //vastumst.SCORE = "誤り";
                }
                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@VASTU_ID", vastumst.VASTU_ID);
                SqlParameter p2 = new SqlParameter("@AREA_ID", vastumst.AREA_ID);
                SqlParameter p3 = new SqlParameter("@AREA", vastumst.AREA);
                SqlParameter p4 = new SqlParameter("@DIRECTION_ID", vastumst.DIRECTION_ID);
                SqlParameter p5 = new SqlParameter("@DIRECTION", vastumst.DIRECTION);
                SqlParameter p6 = new SqlParameter("@VASTU_TYPE_ID", vastumst.VASTU_TYPE_ID);
                SqlParameter p7 = new SqlParameter("@VASTU_TYPE", vastumst.VASTU_TYPE);
                SqlParameter p8 = new SqlParameter("@STATUS_ID", vastumst.STATUS_ID);
                SqlParameter p9 = new SqlParameter("@DELETE_FLAG", false);
                SqlParameter p10 = new SqlParameter("@CREATED_USER", vastumst.UPDATED_USER);
                SqlParameter p11 = new SqlParameter("@CREATED_DATE", c.dt);
                SqlParameter p12 = new SqlParameter("@COLUMN_NAME", "アクティブ・非アクティブ");
                SqlParameter p13 = new SqlParameter("@OLD_SCORE_VALUE", vastumst.OLD_SCORE);
                SqlParameter p14 = new SqlParameter("@NEW_SCORE_VALUE", vastumst.SCORE);

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
  

                string sqlcmd = "insert into VS_VASTU_MST_TRAN_DETAILS(VASTU_ID,AREA_ID,AREA,DIRECTION_ID,DIRECTION,";
                sqlcmd += "VASTU_TYPE_ID,VASTU_TYPE,STATUS_ID,DELETE_FLAG,CREATED_USER,CREATED_DATE,COLUMN_NAME,";
                sqlcmd += "OLD_SCORE_VALUE,NEW_SCORE_VALUE) values ";
                sqlcmd += "(@VASTU_ID,@AREA_ID,@AREA,@DIRECTION_ID,@DIRECTION,@VASTU_TYPE_ID,@VASTU_TYPE,";
                sqlcmd += "@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE,@COLUMN_NAME,";
                sqlcmd += "@OLD_SCORE_VALUE,@NEW_SCORE_VALUE)";


                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return result;

        }
        public int UpdateVastu(VS_VASTU_MST vastumst)
        {
            int result = 0;
 
            try
            {
                //List<VS_SCORE_MST> scrdrl = new List<VS_SCORE_MST>();
                var scrdrl = GetAllScoreList().Where(item => item.SCORE_ID == vastumst.SCORE_ID).FirstOrDefault();
                
                if (scrdrl.SCORE !=  Convert.ToDecimal(vastumst.OLD_SCORE))
                {
                    vastumst.SCORE = scrdrl.SCORE.ToString();

                    result = InsertScoreLog(vastumst);
                }

                if(vastumst.OLD_DELETE_FLAG != vastumst.DELETE_FLAG)
                {
                    result = InsertStatusLog(vastumst);
                }
                if(vastumst.EXTRA_SCORE != null)
                {
                    vastumst.EXTRA_SCORE = vastumst.EXTRA_SCORE.Trim();
                }
                if (vastumst.OLD_EXTRA_SCORE != null)
                {
                    vastumst.OLD_EXTRA_SCORE = vastumst.OLD_EXTRA_SCORE.Trim();
                }
                if (vastumst.SHORT_DESCRIPTION != null)
                {
                    vastumst.SHORT_DESCRIPTION = vastumst.SHORT_DESCRIPTION.Trim();
                }
                if (vastumst.OLD_SHORT_DESCRIPTION != null)
                {
                    vastumst.OLD_SHORT_DESCRIPTION = vastumst.OLD_SHORT_DESCRIPTION.Trim();
                }
                if (vastumst.LONG_DESCRIPTION != null)
                {
                    vastumst.LONG_DESCRIPTION = vastumst.LONG_DESCRIPTION.Trim();
                }
                if (vastumst.OLD_LONG_DESCRIPTION != null)
                {
                    vastumst.OLD_LONG_DESCRIPTION = vastumst.OLD_LONG_DESCRIPTION.Trim();
                }



                if (vastumst.EXTRA_SCORE != vastumst.OLD_EXTRA_SCORE)
                {
                    result = InsertExtraScoreLog(vastumst);
                }

                if (vastumst.SHORT_DESCRIPTION != vastumst.OLD_SHORT_DESCRIPTION)
                {
                    result = InsertShortDescLog(vastumst);
                }
                if (vastumst.LONG_DESCRIPTION != vastumst.OLD_LONG_DESCRIPTION)
                {
                    result = InsertLongDescLog(vastumst);
                }
                
                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@AREA_ID", vastumst.AREA_ID);
                SqlParameter p2 = new SqlParameter("@DIRECTION_ID", vastumst.DIRECTION_ID);
                SqlParameter p3 = new SqlParameter("@VASTU_TYPE_ID", vastumst.VASTU_TYPE_ID);
                SqlParameter p4 = new SqlParameter("@SCORE_ID", vastumst.SCORE_ID);
                SqlParameter p5 = new SqlParameter("@EXTRA_SCORE", (object)vastumst.EXTRA_SCORE ?? DBNull.Value);
                SqlParameter p6 = new SqlParameter("@SHORT_DESCRIPTION", (object)vastumst.SHORT_DESCRIPTION ?? DBNull.Value);
                SqlParameter p7 = new SqlParameter("@LONG_DESCRIPTION", (object)vastumst.LONG_DESCRIPTION ?? DBNull.Value);
                SqlParameter p8 = new SqlParameter("@STATUS_ID", vastumst.STATUS_ID);
                SqlParameter p9 = new SqlParameter("@DELETE_FLAG", vastumst.DELETE_FLAG);

                SqlParameter p10 = new SqlParameter("@UPDATED_USER", vastumst.UPDATED_USER);
                SqlParameter p11 = new SqlParameter("@UPDATED_DATE", c.dt);
                SqlParameter p12 = new SqlParameter("@VASTU_ID", vastumst.VASTU_ID);

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
  
                string sqlcmd = "Update VS_VASTU_MST set AREA_ID = @AREA_ID,DIRECTION_ID=@DIRECTION_ID,VASTU_TYPE_ID=@VASTU_TYPE_ID,";
                sqlcmd += "SCORE_ID=@SCORE_ID,EXTRA_SCORE=@EXTRA_SCORE,SHORT_DESCRIPTION=@SHORT_DESCRIPTION,LONG_DESCRIPTION=@LONG_DESCRIPTION,";
                sqlcmd += "STATUS_ID=@STATUS_ID,DELETE_FLAG=@DELETE_FLAG,UPDATED_USER=@UPDATED_USER,UPDATED_DATE=@UPDATED_DATE";
                sqlcmd += " Where VASTU_ID =@VASTU_ID";



                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);
                


            }
            catch (Exception ex)
            {
                throw ex;
             
            }
            return result;
        }

        public int DeleteVastuMaster(int VastuID)
        {
            int result = 0;
            try
            {

                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@DELETE_FLAG", VastuID);
                SqlParameter p2 = new SqlParameter("@DELETE_FLAG", VastuID);

                sqlParameters.Add(p1);

                string sqlcmd1 = "select  VST.VASTU_ID,VST.AREA_ID,AREA.AREA ,VST.DIRECTION_ID,DST.DIRECTION,VST.VASTU_TYPE_ID,VAS.VASTU_TYPE,VST.SCORE_ID,SCR.SCORE,VST.EXTRA_SCORE,VST.SHORT_DESCRIPTION,VST.LONG_DESCRIPTION,VST.STATUS_ID,VST.DELETE_FLAG,VST.CREATED_USER,VST.CREATED_DATE from VS_VASTU_MST[VST] JOIN VS_AREA_MST[AREA] ON VST.AREA_ID = AREA.AREA_ID JOIN VS_DIRECTION_MST DST ON VST.DIRECTION_ID = DST.DIRECTION_ID JOIN VS_VASTU_TYPE_MST VAS ON VST.VASTU_TYPE_ID=VAS.VASTU_TYPE_ID JOIN VS_SCORE_MST SCR ON VST.SCORE_ID = SCR.SCORE_ID where VST.vastu_id = @DELETE_FLAG";

                List<VS_VASTU_MST> obj = new List<VS_VASTU_MST>();
                obj = AdoHelper.ExecuteReader<VS_VASTU_MST>(CommandType.Text, sqlcmd1, sqlParameters);

                result = DeleteCreateLongDescLog(obj);
                result = DeleteCreateShortDescLog(obj);
                result = DeleteCreateExtraScoreLog(obj);
                result = DeleteCreateScoreLog(obj);
                //result = DeleteCreateVasStatusLog(obj);

                sqlParameters.Remove(p1);
                sqlParameters.Add(p2);

                string sqlcmd = "Delete from VS_VASTU_MST where vastu_id = @DELETE_FLAG";

                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);

            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public int DeleteAreaMaster(int VastuID)
        {
            int result = 0;

            try
            {

                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@DELETE_FLAG", VastuID);
                SqlParameter p2 = new SqlParameter("@DELETE_FLAG", VastuID);
                SqlParameter p3 = new SqlParameter("@DELETE_FLAG", VastuID);

                sqlParameters.Remove(p1);
                sqlParameters.Remove(p2);

                sqlParameters.Add(p3);

                string sqlcmd2 = "select AREA_ID,AREA,COMMENTS,DELETE_FLAG,CREATED_USER,CREATED_DATE from VS_AREA_MST  where area_id = @DELETE_FLAG";

                List<VS_AREA_MST> obj = new List<VS_AREA_MST>();
                obj = AdoHelper.ExecuteReader<VS_AREA_MST>(CommandType.Text, sqlcmd2, sqlParameters);

                result = DeleteCreateAreaLog(obj);
                //result = DeleteCreateAreaCommentsLog(obj);
                //result = DeleteCreateStatusLog(obj);

                sqlParameters.Remove(p3);
                sqlParameters.Add(p1);

                string sqlcmd = "Delete from VS_VASTU_MST where area_id = @DELETE_FLAG";

                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);

                sqlParameters.Remove(p1);
                sqlParameters.Remove(p3);
                sqlParameters.Add(p2);

                string sqlcmd1 = "Delete from VS_AREA_MST where area_id = @DELETE_FLAG";

                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd1, sqlParameters);

            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public int DeleteCreateStatusLog(List<VS_AREA_MST> areamst)
        {
            int result = 0;
            string OldDelFG = "";
            string NewDelFG = "";
            try
            {

                if (areamst[0].OLD_DELETE_FLAG == true)
                {
                    // vastumst.OLD_SCORE = "偽";
                    OldDelFG = "1";
                }
                else
                {
                    //vastumst.OLD_SCORE = "本当";
                    OldDelFG = "0";
                }
                if (areamst[0].DELETE_FLAG == true)
                {
                    NewDelFG = "1";
                    //vastumst.SCORE = "本当";
                }
                else
                {
                    NewDelFG = "0";
                    //vastumst.SCORE = "誤り";
                }

                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@AREA_ID", areamst[0].AREA_ID);
                SqlParameter p2 = new SqlParameter("@STATUS_ID", areamst[0].STATUS_ID);
                SqlParameter p3 = new SqlParameter("@DELETE_FLAG", areamst[0].DELETE_FLAG);
                SqlParameter p4 = new SqlParameter("@CREATED_USER", areamst[0].CREATED_USER);
                SqlParameter p5 = new SqlParameter("@CREATED_DATE", areamst[0].CREATED_DATE);
                SqlParameter p6 = new SqlParameter("@COLUMN_NAME", "アクティブ・非アクティブ");
                SqlParameter p7 = new SqlParameter("@OLD_DESCRIPTION_VALUE", NewDelFG);
                SqlParameter p8 = new SqlParameter("@NEW_DESCRIPTION_VALUE", "削除された");


                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                sqlParameters.Add(p3);
                sqlParameters.Add(p4);
                sqlParameters.Add(p5);
                sqlParameters.Add(p6);
                sqlParameters.Add(p7);
                sqlParameters.Add(p8);


                string sqlcmd = "insert into VS_AREA_MST_TRAN_DETAILS(AREA_ID,STATUS_ID,";
                sqlcmd += "DELETE_FLAG,CREATED_USER,CREATED_DATE,COLUMN_NAME,OLD_DESCRIPTION_VALUE,NEW_DESCRIPTION_VALUE) values(@AREA_ID,";
                sqlcmd += "@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE,@COLUMN_NAME,@OLD_DESCRIPTION_VALUE,@NEW_DESCRIPTION_VALUE)";
                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);



                // result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;

            }
            return result;

        }
        public int DeleteCreateAreaLog(List<VS_AREA_MST> areamst)
        {
            int result = 0;
            try
            {

                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@AREA_ID", areamst[0].AREA_ID);
                SqlParameter p2 = new SqlParameter("@STATUS_ID", areamst[0].STATUS_ID);
                SqlParameter p3 = new SqlParameter("@DELETE_FLAG", areamst[0].DELETE_FLAG);
                SqlParameter p4 = new SqlParameter("@CREATED_USER", areamst[0].CREATED_USER);
                SqlParameter p5 = new SqlParameter("@CREATED_DATE", areamst[0].CREATED_DATE);
                SqlParameter p6 = new SqlParameter("@COLUMN_NAME", "エリア");
                SqlParameter p7 = new SqlParameter("@OLD_DESCRIPTION_VALUE", "del");
                SqlParameter p8 = new SqlParameter("@NEW_DESCRIPTION_VALUE", (object)areamst[0].AREA ?? DBNull.Value);

                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                sqlParameters.Add(p3);
                sqlParameters.Add(p4);
                sqlParameters.Add(p5);
                sqlParameters.Add(p6);
                sqlParameters.Add(p7);
                sqlParameters.Add(p8);
            


                string sqlcmd = "insert into VS_AREA_MST_TRAN_DETAILS(AREA_ID,STATUS_ID,";
                sqlcmd += "DELETE_FLAG,CREATED_USER,CREATED_DATE,COLUMN_NAME,OLD_DESCRIPTION_VALUE,NEW_DESCRIPTION_VALUE) values(@AREA_ID,";
                sqlcmd += "@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE,@COLUMN_NAME,@OLD_DESCRIPTION_VALUE,@NEW_DESCRIPTION_VALUE)";
                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);



                //result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;

            }
            return result;

        }

        public int DeleteCreateAreaCommentsLog(List<VS_AREA_MST> areamst)
        {
            int result = 0;
            try
            {

                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@AREA_ID", areamst[0].AREA_ID);
                SqlParameter p2 = new SqlParameter("@STATUS_ID", areamst[0].STATUS_ID);
                SqlParameter p3 = new SqlParameter("@DELETE_FLAG", areamst[0].DELETE_FLAG);
                SqlParameter p4 = new SqlParameter("@CREATED_USER", areamst[0].CREATED_USER);
                SqlParameter p5 = new SqlParameter("@CREATED_DATE", areamst[0].CREATED_DATE);
                SqlParameter p6 = new SqlParameter("@COLUMN_NAME", "コメント");
                SqlParameter p7 = new SqlParameter("@OLD_DESCRIPTION_VALUE", (object)areamst[0].AREA ?? DBNull.Value);
                SqlParameter p8 = new SqlParameter("@NEW_DESCRIPTION_VALUE", "削除された") ;


                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                sqlParameters.Add(p3);
                sqlParameters.Add(p4);
                sqlParameters.Add(p5);
                sqlParameters.Add(p6);
                sqlParameters.Add(p7);
                sqlParameters.Add(p8);


                string sqlcmd = "insert into VS_AREA_MST_TRAN_DETAILS(AREA_ID,STATUS_ID,";
                sqlcmd += "DELETE_FLAG,CREATED_USER,CREATED_DATE,COLUMN_NAME,OLD_DESCRIPTION_VALUE,NEW_DESCRIPTION_VALUE) values(@AREA_ID,";
                sqlcmd += "@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE,@COLUMN_NAME,@OLD_DESCRIPTION_VALUE,@NEW_DESCRIPTION_VALUE)";
                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);



                //result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;

            }
            return result;

        }
      
        public int DeleteVastuType(int VastuID)
        {
            int result = 0;

            try
            {

                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@DELETE_FLAG", VastuID);
                //SqlParameter p2 = new SqlParameter("@DELETE_FLAG", VastuID);
                sqlParameters.Add(p1);

                string sqlcmd = "Delete from VS_VASTU_TYPE_MST where VASTU_TYPE_id = @DELETE_FLAG";

                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);

                //sqlParameters.Remove(p1);
                //sqlParameters.Add(p2);

                //string sqlcmd1 = "Delete from VS_AREA_MST where area_id = @DELETE_FLAG";

                //result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd1, sqlParameters);

            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public int DeleteScoreMaster(int VastuID)
        {
            int result = 0;

            try
            {

                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@DELETE_FLAG", VastuID);
                //SqlParameter p2 = new SqlParameter("@DELETE_FLAG", VastuID);
                sqlParameters.Add(p1);

                string sqlcmd = "Delete from VS_SCORE_MST where SCoRE_id = @DELETE_FLAG";

                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);



            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public int DeleteImageMaster(int VastuID)
        {
            int result = 0;

            try
            {

                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@DELETE_FLAG", VastuID);
                SqlParameter p2 = new SqlParameter("@DELETE_FLAG", VastuID);
                sqlParameters.Add(p1);

                string sqlcmd = "Delete from VS_SCORE_MST where image_id = @DELETE_FLAG";

                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);

                sqlParameters.Remove(p1);
                sqlParameters.Add(p2);

                string sqlcmd1 = "Delete from VS_IMAGE_MST where image_id = @DELETE_FLAG";

                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd1, sqlParameters);



            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public int DeleteDirectionMaster(int VastuID)
        {
            int result = 0;

            try
            {

                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@DELETE_FLAG", VastuID);
                //SqlParameter p2 = new SqlParameter("@DELETE_FLAG", VastuID);
                sqlParameters.Add(p1);

                string sqlcmd = "Delete from VS_direction_MST where direction_id = @DELETE_FLAG";

                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);



            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public int DeleteUserMaster(int VastuID)
        {
            int result = 0;

            try
            {

                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@DELETE_FLAG", VastuID);
                //SqlParameter p2 = new SqlParameter("@DELETE_FLAG", VastuID);
                sqlParameters.Add(p1);

                string sqlcmd = "Delete from VS_user_MST where user_id = @DELETE_FLAG";

                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);



            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public List<AreaVasthu> Area()
        {
            List<AreaVasthu> obj = new List<AreaVasthu>();
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();


                obj = AdoHelper.ExecuteReader<AreaVasthu>(CommandType.Text, "select AREA,AREA_ID from VS_AREA_MST where delete_flag='0' and status_id=4 order by AREA_ID asc", sqlParameters);



                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VS_VASTU_MST> GetAllVastu(int area)
        {
            string strcmd = "";
            List<VS_VASTU_MST> obj = new List<VS_VASTU_MST>();
            try
            {

                strcmd = AreasearchList(area);
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@area", area);
                sqlParameters.Add(p1);

                obj = AdoHelper.ExecuteReader<VS_VASTU_MST>(CommandType.Text, strcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;

        }
    }
}
