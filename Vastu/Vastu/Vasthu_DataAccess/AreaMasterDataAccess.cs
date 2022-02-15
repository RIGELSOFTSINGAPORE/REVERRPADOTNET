﻿using System;
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
    public class AreaMasterDataAccess : BaseDataAccess
    {
        private string AreaQuery(int areaID)
        {
            string strcmd = "";

            strcmd += "Select M.AREA_ID,M.AREA,";
            if (areaID != 0)
            {
                strcmd += "M.COMMENTS,M.DELETE_FLAG OLD_DELETE_FLAG,M.AREA OLD_AREA,M.COMMENTS OLD_COMMENTS,";
            }
            strcmd += "M.DELETE_FLAG,C.LOGIN_NAME CREATED_USER_NAME,M.CREATED_DATE C_USER_DATE,";
            strcmd += "U.LOGIN_NAME UPDATED_USER_NAME, M.UPDATED_DATE U_USER_DATE";
            strcmd += " From  VS_AREA_MST M ";
            strcmd += " Left Join VS_USER_MST C on C.USER_ID = M.CREATED_USER ";
            strcmd += " Left Join VS_USER_MST U on U.USER_ID = M.UPDATED_USER ";
            if (areaID != 0)
            {
                strcmd += " Where M.AREA_ID = @areaID";
            }
            strcmd += " ORDER BY M.AREA_ID DESC ";

            return strcmd;
        }



        public List<VS_AREA_MST> GetAllArea()
        {
            string strcmd = "";
            List<VS_AREA_MST> obj = new List<VS_AREA_MST>();
            try
            {

                strcmd = AreaQuery(0);
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                obj = AdoHelper.ExecuteReader<VS_AREA_MST>(CommandType.Text, strcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;

            }
            return obj;

        }
        public VS_AREA_MST GetAreaByID(int areaID)
        {
            string strcmd = "";
            VS_AREA_MST obj = new VS_AREA_MST();
            try
            {

                strcmd = AreaQuery(areaID);
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@areaID", areaID);
                sqlParameters.Add(p1);
                obj = AdoHelper.ExecuteReaderSingle<VS_AREA_MST>(CommandType.Text, strcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;

            }
            return obj;

        }

        public List<VS_AREA_MST> CheckAreaDetail(string areadetail, int areaID)
        {
            List<VS_AREA_MST> obj = new List<VS_AREA_MST>();
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                if (areaID == 0)
                {
                    SqlParameter p1 = new SqlParameter("@areadetail", areadetail);
                    sqlParameters.Add(p1);
                    obj = AdoHelper.ExecuteReader<VS_AREA_MST>(CommandType.Text, "select AREA_ID,AREA from VS_AREA_MST Where AREA = @areadetail", sqlParameters);
                }
                else
                {
                    SqlParameter p1 = new SqlParameter("@areadetail", areadetail);
                    SqlParameter p2 = new SqlParameter("@areaID", areaID);
                    sqlParameters.Add(p1);
                    sqlParameters.Add(p2);
                    obj = AdoHelper.ExecuteReader<VS_AREA_MST>(CommandType.Text, "select AREA_ID,AREA from VS_AREA_MST Where AREA = @areadetail and AREA_ID != @areaID", sqlParameters);
                }


            }
            catch (Exception ex)
            {
                throw ex;

            }
            return obj;
        }

        public int CreateArea(VS_AREA_MST areamst)
        {
            int result = 0;

            try
            {
                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@AREA", areamst.AREA);
                SqlParameter p2 = new SqlParameter("@STATUS_ID", areamst.STATUS_ID);
                SqlParameter p3 = new SqlParameter("@DELETE_FLAG", areamst.DELETE_FLAG);
                SqlParameter p4 = new SqlParameter("@CREATED_USER", areamst.CREATED_USER);
                SqlParameter p5 = new SqlParameter("@CREATED_DATE", c.dt);
                SqlParameter p6 = new SqlParameter("@COMMENTS", areamst.COMMENTS);

                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                sqlParameters.Add(p3);
                sqlParameters.Add(p4);
                sqlParameters.Add(p5);
                sqlParameters.Add(p6);



                string sqlcmd = "insert into VS_AREA_MST(AREA,STATUS_ID,";
                sqlcmd += "DELETE_FLAG,CREATED_USER,CREATED_DATE,COMMENTS) values(@AREA,";
                sqlcmd += "@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE,@COMMENTS)";
                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);

                sqlParameters.Remove(p1);
                sqlParameters.Remove(p2);
                sqlParameters.Remove(p3);
                sqlParameters.Remove(p4);
                sqlParameters.Remove(p5);
                sqlParameters.Remove(p6);

                sqlcmd = "select top 1 AREA_ID,AREA,COMMENTS,DELETE_FLAG,CREATED_USER,CREATED_DATE from VS_AREA_MST  ORDER BY AREA_ID desc";

                List<VS_AREA_MST> obj = new List<VS_AREA_MST>();
                obj = AdoHelper.ExecuteReader<VS_AREA_MST>(CommandType.Text, sqlcmd, sqlParameters);

                result = InsertCreateAreaLog(obj);
                //result = InsertCreateAreaCommentsLog(obj);
                //result = InsertCreateStatusLog(obj);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return result;

        }
        public int InsertCreateStatusLog(List<VS_AREA_MST> areamst)
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
                SqlParameter p7 = new SqlParameter("@OLD_DESCRIPTION_VALUE", "新しく作成された");
                SqlParameter p8 = new SqlParameter("@NEW_DESCRIPTION_VALUE", NewDelFG);


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
        public int InsertStatusLog(VS_AREA_MST areamst)
        {
            int result = 0;
            string OldDelFG = "";
            string NewDelFG = "";
            try
            {

                if (areamst.OLD_DELETE_FLAG == true)
                {
                    // vastumst.OLD_SCORE = "偽";
                    OldDelFG = "1";
                }
                else
                {
                    //vastumst.OLD_SCORE = "本当";
                    OldDelFG = "0";
                }
                if (areamst.DELETE_FLAG == true)
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

                SqlParameter p1 = new SqlParameter("@AREA_ID", areamst.AREA_ID);
                SqlParameter p2 = new SqlParameter("@STATUS_ID", areamst.STATUS_ID);
                SqlParameter p3 = new SqlParameter("@DELETE_FLAG", areamst.DELETE_FLAG);
                SqlParameter p4 = new SqlParameter("@CREATED_USER", areamst.UPDATED_USER);
                SqlParameter p5 = new SqlParameter("@CREATED_DATE", c.dt);
                SqlParameter p6 = new SqlParameter("@COLUMN_NAME", "アクティブ・非アクティブ");
                SqlParameter p7 = new SqlParameter("@OLD_DESCRIPTION_VALUE", OldDelFG);
                SqlParameter p8 = new SqlParameter("@NEW_DESCRIPTION_VALUE", NewDelFG);


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
        public int InsertCreateAreaLog(List<VS_AREA_MST> areamst)
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
                SqlParameter p5 = new SqlParameter("@CREATED_DATE", c.dt);
                SqlParameter p6 = new SqlParameter("@COLUMN_NAME", "エリア");
                SqlParameter p7 = new SqlParameter("@OLD_DESCRIPTION_VALUE", "add");
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
        public int InsertAreaLog(VS_AREA_MST areamst)
        {
            int result = 0;
            try
            {

                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@AREA_ID", areamst.AREA_ID);
                SqlParameter p2 = new SqlParameter("@STATUS_ID", areamst.STATUS_ID);
                SqlParameter p3 = new SqlParameter("@DELETE_FLAG", areamst.DELETE_FLAG);
                SqlParameter p4 = new SqlParameter("@CREATED_USER", areamst.UPDATED_USER);
                SqlParameter p5 = new SqlParameter("@CREATED_DATE", c.dt);
                SqlParameter p6 = new SqlParameter("@COLUMN_NAME", "エリア");
                SqlParameter p7 = new SqlParameter("@OLD_DESCRIPTION_VALUE", (object)areamst.OLD_AREA ?? DBNull.Value);
                SqlParameter p8 = new SqlParameter("@NEW_DESCRIPTION_VALUE", (object)areamst.AREA ?? DBNull.Value);


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
        public int InsertCreateAreaCommentsLog(List<VS_AREA_MST> areamst)
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
                SqlParameter p5 = new SqlParameter("@CREATED_DATE", c.dt);
                SqlParameter p6 = new SqlParameter("@COLUMN_NAME", "コメント");
                SqlParameter p7 = new SqlParameter("@OLD_DESCRIPTION_VALUE", "新しく作成された");
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

        public int InsertAreaCommentsLog(VS_AREA_MST areamst)
        {
            int result = 0;
            try
            {

                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@AREA_ID", areamst.AREA_ID);
                SqlParameter p2 = new SqlParameter("@STATUS_ID", areamst.STATUS_ID);
                SqlParameter p3 = new SqlParameter("@DELETE_FLAG", areamst.DELETE_FLAG);
                SqlParameter p4 = new SqlParameter("@CREATED_USER", areamst.UPDATED_USER);
                SqlParameter p5 = new SqlParameter("@CREATED_DATE", c.dt);
                SqlParameter p6 = new SqlParameter("@COLUMN_NAME", "コメント");
                SqlParameter p7 = new SqlParameter("@OLD_DESCRIPTION_VALUE", (object)areamst.OLD_COMMENTS ?? DBNull.Value);
                SqlParameter p8 = new SqlParameter("@NEW_DESCRIPTION_VALUE", (object)areamst.COMMENTS ?? DBNull.Value);


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
        public int UpdateArea(VS_AREA_MST areamst)
        {
            int result = 0;

            try
            {
                Common c = new Common();

                if (areamst.OLD_AREA.Trim() != areamst.AREA.Trim())
                {
                    result = InsertAreaLog(areamst);
                }
                if (areamst.OLD_COMMENTS != null)
                {
                    areamst.OLD_COMMENTS = areamst.OLD_COMMENTS.Trim();
                }
                if (areamst.COMMENTS != null)
                {
                    areamst.COMMENTS = areamst.COMMENTS.Trim();
                }
                if (areamst.OLD_COMMENTS != areamst.COMMENTS)
                {
                    result = InsertAreaCommentsLog(areamst);
                }

                if (areamst.OLD_DELETE_FLAG != areamst.DELETE_FLAG)
                {
                    result = InsertStatusLog(areamst);
                }
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@AREA", areamst.AREA);
                SqlParameter p2 = new SqlParameter("@STATUS_ID", areamst.STATUS_ID);
                SqlParameter p3 = new SqlParameter("@DELETE_FLAG", areamst.DELETE_FLAG);
                SqlParameter p4 = new SqlParameter("@UPDATED_USER", areamst.UPDATED_USER);
                SqlParameter p5 = new SqlParameter("@UPDATED_DATE", c.dt);
                SqlParameter p6 = new SqlParameter("@AREA_ID", areamst.AREA_ID);
                SqlParameter p7 = new SqlParameter("@COMMENTS", areamst.COMMENTS);

                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                sqlParameters.Add(p3);
                sqlParameters.Add(p4);
                sqlParameters.Add(p5);
                sqlParameters.Add(p6);
                sqlParameters.Add(p7);

                string sqlcmd = "Update VS_AREA_MST set AREA = @AREA,";
                sqlcmd += "STATUS_ID=@STATUS_ID,";
                sqlcmd += "DELETE_FLAG=@DELETE_FLAG,UPDATED_USER=@UPDATED_USER,UPDATED_DATE=@UPDATED_DATE,COMMENTS=@COMMENTS";
                sqlcmd += " Where AREA_ID =@AREA_ID";



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
