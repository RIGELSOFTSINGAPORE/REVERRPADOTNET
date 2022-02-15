
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
    public class VastuReportDataAccess_New : BaseDataAccess
    {

        #region Vastu Report
        public List<AreaReport> Interior()
        {
            List<AreaReport> obj = new List<AreaReport>();
            string sqlcmd;

            try
            {
                //sqlcmd = " select Distinct AM.Area_Id as AreaID,AM.Area,AM.Area_JN ";
                //sqlcmd += " From VS_AREA_MST AM ";
                //sqlcmd += " Join VS_VASTU_MST VM on AM.AREA_ID = VM.AREA_ID ";
                //sqlcmd += " Join VS_DIRECTION_MST DM on DM.DIRECTION_ID = VM.DIRECTION_ID ";
                //sqlcmd += " Join VS_SCORE_MST SM on SM.SCORE_ID = VM.SCORE_ID ";
                //sqlcmd += " Where AM.delete_flag='0' and AM.status_id=4 ";
                //sqlcmd += " AND VM.delete_flag='0' and VM.status_id=4 ";
                //sqlcmd += " AND DM.delete_flag='0' and DM.status_id=4 ";
                //sqlcmd += " AND SM.delete_flag='0' and SM.status_id=4 ";
                //sqlcmd += " order by AreaID ";

                sqlcmd = "select AM.Area_Id as AreaID,AM.Area,AM.Area_JN From VS_AREA_MST AM ";
                sqlcmd += " Where AM.delete_flag='0' and AM.status_id=4 order by AreaID";

                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                obj = AdoHelper.ExecuteReader<AreaReport>(CommandType.Text, sqlcmd, sqlParameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return obj;
        }



        public List<DirectionReport> Direction()
        {
            List<DirectionReport> obj = new List<DirectionReport>();
            string sqlcmd;

            try
            {
                //sqlcmd = " select Distinct AM.Area_Id as AreaID, ";
                //sqlcmd += " DM.direction_id as DirectionID,Direction,Direction_JN ";
                //sqlcmd += " From VS_AREA_MST AM ";
                //sqlcmd += " Join VS_VASTU_MST VM on AM.AREA_ID = VM.AREA_ID ";
                //sqlcmd += " Join VS_DIRECTION_MST DM on DM.DIRECTION_ID = VM.DIRECTION_ID ";
                //sqlcmd += " Join VS_SCORE_MST SM on SM.SCORE_ID = VM.SCORE_ID ";
                //sqlcmd += " Where AM.delete_flag='0' and AM.status_id=4 ";
                //sqlcmd += " AND VM.delete_flag='0' and VM.status_id=4 ";
                //sqlcmd += " AND DM.delete_flag='0' and DM.status_id=4 ";
                //sqlcmd += " AND SM.delete_flag='0' and SM.status_id=4 ";
                //sqlcmd += " Order By AM.Area_Id,DM.direction_id ";

                sqlcmd = " select Distinct AM.Area_Id as AreaID, ";
                sqlcmd += " DM.direction_id as DirectionID,Direction,Direction_JN ";
                sqlcmd += " From VS_AREA_MST AM,VS_DIRECTION_MST DM ";
                sqlcmd += " Where AM.delete_flag='0' and AM.status_id=4 ";
                sqlcmd += " AND DM.delete_flag='0' and DM.status_id=4 ";
                sqlcmd += " Order BY AM.Area_Id,DM.direction_id ";



                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                obj = AdoHelper.ExecuteReader<DirectionReport>(CommandType.Text, sqlcmd, sqlParameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return obj;
        }


        public List<ShowFinalReport> DownLoadReport(InputToReport valueAreaDirection, InputTextToReport textAreaDirection, int VasthuType, string EmailId, string SessionReportId, string IPAddress, string ResearcherName, string language, int UserID)
        {
            List<VastuReportOutput> vastuOutput = new List<VastuReportOutput>();
            List<ShowFinalReport> finalResultReport = new List<ShowFinalReport>();
            GetVastuReportID.VastuReportID = 0;
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter P1 = new SqlParameter("@VASTU_TYPE", VasthuType);
                SqlParameter P2 = new SqlParameter("@EMAIL_ID", EmailId);
                SqlParameter P4 = new SqlParameter("@IP_ADDRESS", IPAddress);
                SqlParameter P5 = new SqlParameter("@SessionID", SessionReportId);

                sqlParameters.Add(P1);
                sqlParameters.Add(P2);
                sqlParameters.Add(P4);
                sqlParameters.Add(P5);
                string sqlquery = string.Empty;
                sqlquery = "select top 1 VASTU_REPORT_ID from VS_VAST_REPORT_TRAN where VASTU_TYPE=@VASTU_TYPE and EMAIL_ID=@EMAIL_ID and  IP_ADDRESS=@IP_ADDRESS and SessionID=@SessionID  and STATUS_ID=4 and DELETE_FLAG=0 ORDER BY VASTU_REPORT_ID desc";
                List<Vastuid1> lstVastuReportId = new List<Vastuid1>();
                lstVastuReportId = AdoHelper.ExecuteReader<Vastuid1>(CommandType.Text, sqlquery, sqlParameters);

                if (lstVastuReportId.Count > 0)
                {
                    var VastuReportId = lstVastuReportId[0].VASTU_REPORT_ID;
                    //check in detail table
                    string qry = string.Empty;
                    qry = "select Area,Direction,RESEARCHER_COMMENTS from VS_VAST_REPORT_TRAN_DETAILS rtd where VASTU_REPORT_ID=@VASTU_REPORT_ID";

                    List<SqlParameter> lstpara = new List<SqlParameter>();
                    SqlParameter parms = new SqlParameter("@VASTU_REPORT_ID", VastuReportId);
                    lstpara.Add(parms);
                    List<AreaDirectionComments> lstAreaDirectionCommentsFromDB = new List<AreaDirectionComments>();

                    lstAreaDirectionCommentsFromDB = AdoHelper.ExecuteReader<AreaDirectionComments>(CommandType.Text, qry, lstpara);

                    bool matching = IsMatch("AreaDirection", textAreaDirection, lstAreaDirectionCommentsFromDB);
                    if (matching == true)
                    {


                        // if the input comment is mismatched with table, we will update comments and date in both table
                        finalResultReport= Update_Tran_Details(VasthuType, EmailId, IPAddress, 1, SessionReportId, lstAreaDirectionCommentsFromDB, textAreaDirection,VastuReportId,language);
                    }
                    else
                    {
                        //if it is area and direction is  mismatched, we will insert as new record in both table
                        finalResultReport= Insert_Tran_Details(VasthuType, EmailId, IPAddress, 1, SessionReportId,  textAreaDirection, ResearcherName, language, UserID);
                    }

                }
                else
                {
                    //insert  in both table
                    finalResultReport= Insert_Tran_Details(VasthuType, EmailId, IPAddress, 1, SessionReportId,  textAreaDirection, ResearcherName, language, UserID);

                }

                return finalResultReport;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }





        public List<ShowFinalReport> Insert_Tran_Details(int VasthuType, string EmailId, string IPAddress, int createduser, string SessionReportId, InputTextToReport textAreaDirection,string ResearcherName, string language, int UserID)
        {
            List<ShowFinalReport> finalResultReport = new List<ShowFinalReport>();

            //inserted records into VS_VAST_REPORT_TRAN table
            try
            {
                int Result;
                string sql_report_tran = string.Empty;
                sql_report_tran = " insert into VS_VAST_REPORT_TRAN ";
                sql_report_tran += "(";
                sql_report_tran += " 	VASTU_TYPE,EMAIL_ID,IP_ADDRESS,CREATED_USER,CREATED_DATE,SessionID,STATUS_ID,DELETE_FLAG,VASTU_DATE,VASTU_TOTAL_SCORE,REPORT_TAKEN_BY,DLANGUAGE ";
                sql_report_tran += ")";
                sql_report_tran += " values"; ;

                sql_report_tran += "(";
                sql_report_tran += " @VASTU_TYPE,@EMAIL_ID,@IP_ADDRESS,@CREATED_USER,@CREATED_DATE,@SessionID,@STATUS_ID,@DELETE_FLAG,@VASTU_DATE,@VASTU_TOTAL_SCORE,@REPORT_TAKEN_BY,@DLANGUAGE";
                sql_report_tran += ")";
                List<SqlParameter> pars = new List<SqlParameter>();
                SqlParameter pa1 = new SqlParameter("@VASTU_TYPE", VasthuType);
                SqlParameter pa2 = new SqlParameter("@EMAIL_ID", EmailId);
                SqlParameter pa3 = new SqlParameter("@IP_ADDRESS", IPAddress);
                SqlParameter pa4 = new SqlParameter("@CREATED_USER", UserID);
                //SqlParameter pa5 = new SqlParameter("@CREATED_DATE", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                Common createddate1 = new Common();
                SqlParameter pa5 = new SqlParameter("@CREATED_DATE", createddate1.dt);
                SqlParameter pa6 = new SqlParameter("@SessionID", SessionReportId);
                SqlParameter pa7 = new SqlParameter("@STATUS_ID", 4);
                SqlParameter pa8 = new SqlParameter("@DELETE_FLAG", false);

                SqlParameter pa9 = new SqlParameter("@VASTU_DATE", createddate1.dt);


                SqlParameter pa10 = new SqlParameter("@VASTU_TOTAL_SCORE", 1.0);// Due to decimal type in the table column, insert dummy value first and update actual score in the table later

                SqlParameter pa11 = new SqlParameter("@REPORT_TAKEN_BY", ResearcherName);
                SqlParameter pa12 = new SqlParameter("@DLANGUAGE", language);
                pars.Add(pa1);
                pars.Add(pa2);
                pars.Add(pa3);
                pars.Add(pa4);
                pars.Add(pa5);
                pars.Add(pa6);
                pars.Add(pa7);
                pars.Add(pa8);
                pars.Add(pa9);
                pars.Add(pa10);
                pars.Add(pa11);
                pars.Add(pa12);

                int success = AdoHelper.ExecuteNonQuery(CommandType.Text, sql_report_tran, pars);
                if (success == 1)
                {
                    //Get VASTU_REPORT_ID id from VS_VAST_REPORT_TRAN
                    string ssql = string.Empty;
                    ssql = "select top 1  VASTU_REPORT_ID from VS_VAST_REPORT_TRAN where EMAIL_ID=@EMAIL_ID and VASTU_TYPE=@VASTU_TYPE and SessionID=@SessionID order by VASTU_REPORT_ID desc ";
                    List<SqlParameter> myptr = new List<SqlParameter>();
                    SqlParameter p11 = new SqlParameter("@EMAIL_ID", EmailId);
                    SqlParameter p12 = new SqlParameter("@VASTU_TYPE", VasthuType);
                    SqlParameter p13 = new SqlParameter("@SessionID", SessionReportId);
                    myptr.Add(p11);
                    myptr.Add(p12);
                    myptr.Add(p13);

                    List<Vastuid2> lstReportid = new List<Vastuid2>();

                    lstReportid = AdoHelper.ExecuteReader<Vastuid2>(CommandType.Text, ssql, myptr);
                    var VstReportID = lstReportid[0].VASTU_REPORT_ID;

                    Common createddate2 = new Common();

                    //textAreaDirection.GetInputsText.ForEach(s => { s.VASTU_REPORT_ID = VstReportID; s.DELETE_FLAG = false; s.CREATED_USER = 1; s.CREATED_DATE = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"); s.Area = s.Area.Replace("\r", "").Replace("\n", ""); s.Direction = s.Direction.Replace("\r", "").Replace("\n", ""); });


                    textAreaDirection.GetInputsText.ForEach(s => { s.VASTU_REPORT_ID = VstReportID; s.DELETE_FLAG = false; s.CREATED_USER = UserID; s.CREATED_DATE = createddate1.dt.ToString(); s.Area = s.Area.Replace("\r", "").Replace("\n", ""); s.Direction = s.Direction.Replace("\r", "").Replace("\n", ""); });

                    string inputXML = Utility.CreateXML(textAreaDirection.GetInputsText);
                    

                    StringBuilder sb = new StringBuilder();
                    sb.Append("Declare @inputXML XML='#xmlvalue'");
                    sb.Replace("#xmlvalue", inputXML);
                    sb.Append(Environment.NewLine);

                    sb.Append("Begin");
                    sb.Append(Environment.NewLine);
                    sb.Append("Declare @VastuReportList as  Table");
                    sb.Append(Environment.NewLine);
                    sb.Append("(");
                    sb.Append(Environment.NewLine);
                    sb.Append("[VASTU_REPORT_ID] bigint, [Area] nvarchar(200),[AreaId] int, [Direction] nvarchar(200),[DirectionId] int,[DELETE_FLAG] bit,[CREATED_USER] bigint,[CREATED_DATE] datetime,[RESEARCHER_COMMENTS] nvarchar(4000)");
                    sb.Append(")");
                    sb.Append(Environment.NewLine);
                    sb.Append("INSERT INTO @VastuReportList SELECT");
                    sb.Append(Environment.NewLine);

                    sb.Append("A.VastuInput.value('(VASTU_REPORT_ID)[1]', 'bigint') AS VASTU_REPORT_ID,");
                    sb.Append(Environment.NewLine);

                    sb.Append(" A.VastuInput.value('(Area)[1]', 'nvarchar(200)') AS Area,");
                    sb.Append(Environment.NewLine);

                    sb.Append(" A.VastuInput.value('(AreaId)[1]', 'int') AS AreaId,");
                    sb.Append(Environment.NewLine);

                    sb.Append(" A.VastuInput.value('(Direction)[1]', 'nvarchar(200)') AS Direction,");
                    sb.Append(Environment.NewLine);

                    sb.Append(" A.VastuInput.value('(DirectionId)[1]', 'int') AS DirectionId,");
                    sb.Append(Environment.NewLine);

                    sb.Append(" A.VastuInput.value('(DELETE_FLAG)[1]', 'bit') AS DELETE_FLAG,");
                    sb.Append(Environment.NewLine);

                    sb.Append(" A.VastuInput.value('(CREATED_USER)[1]', 'bigint') AS CREATED_USER,");
                    sb.Append(Environment.NewLine);

                    sb.Append(" A.VastuInput.value('(CREATED_DATE)[1]', 'datetime') AS CREATED_DATE,");
                    sb.Append(Environment.NewLine);

                    sb.Append("A.VastuInput.value('(RESEARCHER_COMMENTS)[1]', 'nvarchar(4000)') AS RESEARCHER_COMMENTS");
                    sb.Append(Environment.NewLine);



                    sb.Append("FROM @inputXML.nodes('ArrayOfInputText/InputText') AS A (VastuInput)");
                    sb.Append(Environment.NewLine);
                    sb.Append("OPTION (OPTIMIZE FOR (@inputXML = NULL))");
                    sb.Append(Environment.NewLine);

                    sb.Append("Delete from @VastuReportList where DirectionId is null or AreaId is null; ");
                    sb.Append(Environment.NewLine);

                    sb.Append(" INSERT INTO VS_VAST_REPORT_TRAN_DETAILS (VASTU_REPORT_ID, Area,AREA_ID, Direction,DIRECTION_ID,VASTU_SCORE,SCORE_ID,DELETE_FLAG,CREATED_USER,CREATED_DATE,RESEARCHER_COMMENTS) ");
                    sb.Append(Environment.NewLine);

                    //if (language == "ja")
                    //{
                    //    sb.Append(" select TD.VASTU_REPORT_ID,A.AREA_JN,D.DIRECTION_JN,SCORE,TD.DELETE_FLAG,TD.CREATED_USER,TD.CREATED_DATE,TD.RESEARCHER_COMMENTS ");
                    //    sb.Append(Environment.NewLine);
                    //}
                    //else
                    //{
                    //    sb.Append(" select TD.VASTU_REPORT_ID,A.AREA,D.DIRECTION,SCORE,TD.DELETE_FLAG,TD.CREATED_USER,TD.CREATED_DATE,TD.RESEARCHER_COMMENTS ");
                    //    sb.Append(Environment.NewLine);
                    //}

                    //sb.Append(" select TD.VASTU_REPORT_ID,A.AREA,TD.AreaId,D.DIRECTION,TD.DirectionId,SCORE,S.SCORE_ID,TD.DELETE_FLAG,TD.CREATED_USER,TD.CREATED_DATE,TD.RESEARCHER_COMMENTS ");
                    sb.Append(" select TD.VASTU_REPORT_ID,A.AREA,TD.AreaId,D.DIRECTION,TD.DirectionId,isnull(SCORE,0.00) SCORE,isnull(S.SCORE_ID,0) SCORE_ID,TD.DELETE_FLAG,TD.CREATED_USER,TD.CREATED_DATE,TD.RESEARCHER_COMMENTS ");
                    sb.Append(Environment.NewLine);

                    sb.Append(" from @VastuReportList TD ");
                    sb.Append(Environment.NewLine);

                   

                    sb.Append(" left join VS_AREA_MST A ON A.AREA_ID = TD.AreaId ");
                    sb.Append(Environment.NewLine);

                    sb.Append(" left join VS_DIRECTION_MST D ON D.DIRECTION_ID = TD.DirectionId ");
                    sb.Append(Environment.NewLine);

                    sb.Append(" left join VS_VASTU_MST VM ON TD.AreaId = VM.AREA_ID AND TD.DirectionId = VM.DIRECTION_ID ");
                    sb.Append(Environment.NewLine);

                    sb.Append(" left join VS_SCORE_MST S ON S.SCORE_ID = VM.SCORE_ID AND VM.VASTU_TYPE_ID = 2 ");
                    sb.Append(Environment.NewLine);

                    //sb.Append(" Where VM.VASTU_TYPE_ID = 2 ");
                    //sb.Append(Environment.NewLine);
                                        
                    sb.Append("End");

                    List<SqlParameter> sqparmts = new List<SqlParameter>();
                    SqlParameter P1 = new SqlParameter("@VASTU_REPORT_ID", VstReportID);
                    sqparmts.Add(P1);

                    Result = AdoHelper.ExecuteNonQuery(CommandType.Text, sb.ToString(), sqparmts);


                    //Update Grant Total in VS_VAST_REPORT_TRAN_DETAILS
                    if(Result != 0)
                    {
                        //write logic for grant total
                        StringBuilder sbupdatetotal = new StringBuilder();

                        sbupdatetotal.Append("UPDATE  VS_VAST_REPORT_TRAN SET VASTU_TOTAL_SCORE =  ");
                        sbupdatetotal.Append(Environment.NewLine);

                        sbupdatetotal.Append("( SELECT SUM(TD.VASTU_SCORE)  ");
                        sbupdatetotal.Append(Environment.NewLine);

                        sbupdatetotal.Append("FROM VS_VAST_REPORT_TRAN_DETAILS  TD INNER JOIN VS_VAST_REPORT_TRAN T ON T.VASTU_REPORT_ID = TD.VASTU_REPORT_ID ");
                        sbupdatetotal.Append(Environment.NewLine);

                        sbupdatetotal.Append("where T.VASTU_REPORT_ID=@VASTU_REPORT_ID  ");
                        sbupdatetotal.Append(Environment.NewLine);

                        sbupdatetotal.Append(") WHERE VS_VAST_REPORT_TRAN.VASTU_REPORT_ID = @VASTU_REPORT_ID ");
                        sbupdatetotal.Append(Environment.NewLine);


                        List<SqlParameter> upparameters = new List<SqlParameter>();
                        SqlParameter updatetotal = new SqlParameter("@VASTU_REPORT_ID", VstReportID);
                        upparameters.Add(updatetotal);

                       int Result1= AdoHelper.ExecuteNonQuery(CommandType.Text, sbupdatetotal.ToString(), upparameters);

                        if(Result1!=0)
                        {
                            //Report Logic
                            StringBuilder sbrept = new StringBuilder();
                            sbrept=GenerateReport(language);

                            List<SqlParameter> rptparameter = new List<SqlParameter>();
                            SqlParameter preportid = new SqlParameter("@VASTU_REPORT_ID", VstReportID);
                            rptparameter.Add(preportid);
                            GetVastuReportID.VastuReportID = VstReportID;
                            finalResultReport = AdoHelper.ExecuteReader<ShowFinalReport>(CommandType.Text, sbrept.ToString(), rptparameter);
                        }

                    }
                   
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return finalResultReport;
        }



        public List<ShowFinalReport> Update_Tran_Details(int VasthuType, string EmailId, string IPAddress, int createduser, string SessionReportId, List<AreaDirectionComments> adc, InputTextToReport textAreaDirection, long VASTU_REPORT_ID, string language)
        {
            List<ShowFinalReport> finalResultReport = new List<ShowFinalReport>();
            try
            {

                string sqlqy = string.Empty;
                sqlqy = " update  VS_VAST_REPORT_TRAN set ";
                sqlqy += " 	UPDATED_DATE=@UPDATED_DATE where VASTU_REPORT_ID=@VASTU_REPORT_ID ";
                List<SqlParameter> updateparameters = new List<SqlParameter>();

                Common updateddate1 = new Common();
                //SqlParameter up1 = new SqlParameter("@UPDATED_DATE", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                SqlParameter up1 = new SqlParameter("@UPDATED_DATE", updateddate1.dt);
                SqlParameter up2 = new SqlParameter("@VASTU_REPORT_ID", VASTU_REPORT_ID);

                updateparameters.Add(up1);
                updateparameters.Add(up2);

                int success = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlqy, updateparameters);
                if (success == 1)
                {
                    // update  comments
                    List<UpdateComments> lstComments = new List<UpdateComments>();
                    foreach (var item in textAreaDirection.GetInputsText)
                    {



                        //lstComments.Add(new UpdateComments { VASTU_REPORT_ID = VASTU_REPORT_ID, RESEARCHER_COMMENTS = item.RESEARCHER_COMMENTS, UPDATED_DATE = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), Area = item.Area.Replace("\r", "").Replace("\n", ""), Direction = item.Direction.Replace("\r", "").Replace("\n", "") });
                        Common updateddate2 = new Common();
                        lstComments.Add(new UpdateComments { VASTU_REPORT_ID = VASTU_REPORT_ID, RESEARCHER_COMMENTS = item.RESEARCHER_COMMENTS, UPDATED_DATE = updateddate2.dt.ToString("yyyy / MM / dd HH: mm:ss"), Area = item.Area.Replace("\r", "").Replace("\n", ""), Direction = item.Direction.Replace("\r", "").Replace("\n", "") });

                    }
                    string inputXML = Utility.CreateXML(lstComments);

                    StringBuilder sb = new StringBuilder();
                    sb.Append("Declare @inputXML XML='#xmlvalue'");
                    sb.Replace("#xmlvalue", inputXML);
                    sb.Append(Environment.NewLine);

                    sb.Append("Begin");
                    sb.Append(Environment.NewLine);
                    sb.Append("Declare @VastuReportList as  Table");
                    sb.Append(Environment.NewLine);
                    sb.Append("(");
                    sb.Append(Environment.NewLine);
                    sb.Append("[VASTU_REPORT_ID] bigint,[RESEARCHER_COMMENTS] nvarchar(4000),[UPDATED_DATE] datetime,[Area] nvarchar(200),[Direction] nvarchar(200) ");
                    sb.Append(")");
                    sb.Append(Environment.NewLine);
                    sb.Append("INSERT INTO @VastuReportList SELECT");
                    sb.Append(Environment.NewLine);

                    sb.Append("A.VastuInput.value('(VASTU_REPORT_ID)[1]', 'bigint') AS VASTU_REPORT_ID,");
                    sb.Append(Environment.NewLine);
                    sb.Append(" A.VastuInput.value('(RESEARCHER_COMMENTS)[1]', 'nvarchar(4000)') AS RESEARCHER_COMMENTS,");
                    sb.Append(Environment.NewLine);
                    sb.Append(" A.VastuInput.value('(UPDATED_DATE)[1]', 'datetime') AS UPDATED_DATE,");
                    sb.Append(Environment.NewLine);
                    sb.Append(" A.VastuInput.value('(Area)[1]', 'nvarchar(200)') AS Area,");
                    sb.Append(Environment.NewLine);
                    sb.Append(" A.VastuInput.value('(Direction)[1]', 'nvarchar(200)') AS Direction");
                    sb.Append(Environment.NewLine);


                    sb.Append("FROM @inputXML.nodes('ArrayOfUpdateComments/UpdateComments') AS A (VastuInput)");
                    sb.Append(Environment.NewLine);
                    sb.Append("OPTION (OPTIMIZE FOR (@inputXML = NULL))");
                    sb.Append(Environment.NewLine);



                    sb.Append("UPDATE VS_VAST_REPORT_TRAN_DETAILS");
                    sb.Append(Environment.NewLine);

                    sb.Append("SET RESEARCHER_COMMENTS = CASE ");
                    sb.Append(Environment.NewLine);

                    sb.Append("WHEN ISNULL(T.RESEARCHER_COMMENTS,'')='' THEN V.RESEARCHER_COMMENTS ELSE  T.RESEARCHER_COMMENTS END, ");
                    sb.Append(Environment.NewLine);

                    sb.Append("UPDATED_DATE=T.UPDATED_DATE ");
                    sb.Append(Environment.NewLine);

                    sb.Append("FROM @VastuReportList T LEFT JOIN VS_VAST_REPORT_TRAN_DETAILS V ON T.VASTU_REPORT_ID=V.VASTU_REPORT_ID   ");
                    sb.Append(Environment.NewLine);

                    sb.Append("AND LTRIM(RTRIM(T.AREA))=LTRIM(RTRIM(V.AREA)) AND LTRIM(RTRIM(T.DIRECTION))=LTRIM(RTRIM(V.DIRECTION)) ");
                    sb.Append(Environment.NewLine);

                    sb.Append("End");


                    List<SqlParameter> sqparmts = new List<SqlParameter>();
                    int Result = AdoHelper.ExecuteNonQuery(CommandType.Text, sb.ToString(), sqparmts);

                    if (Result != 0)
                    {
                        StringBuilder sbrept = new StringBuilder();
                        sbrept = GenerateReport(language);
                        List<SqlParameter> rptparameter = new List<SqlParameter>();
                        SqlParameter preportid = new SqlParameter("@VASTU_REPORT_ID", VASTU_REPORT_ID);
                        rptparameter.Add(preportid);
                        GetVastuReportID.VastuReportID = VASTU_REPORT_ID;
                        finalResultReport = AdoHelper.ExecuteReader<ShowFinalReport>(CommandType.Text, sbrept.ToString(), rptparameter);
                    }


                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return finalResultReport;
        }


        public StringBuilder GenerateReport(string lan)
        {

            //declare @VASTU_REPORT_ID int
            //set @VASTU_REPORT_ID = 36
            //select* from VS_DIRECTION_MST
            //select* from[dbo].[VS_VAST_REPORT_TRAN_DETAILS] where VASTU_REPORT_ID = 37
            //select test.AreaId as SerialNo, ARE.AREA as Area,tr.DIRECTION as Direction ,
            //test.北,test.北東,test.東,test.南東,test.南, 
            //test.南西,test.西,test.北西,test.センター,
            //cast(tr.VASTU_SCORE  AS decimal(10, 2)) PointsEarned, 
            //ARE.COMMENTS AS MasterComments, 
            //tr.RESEARCHER_COMMENTS as ResearcherComments  from
            //(SELECT AreaId,  [1] as '北', [2] as '北東', [3] as '東',
            //[4] as '南東', [5] as '南', [6] as '南西', [7] as '西',
            //[8] as '北西',[9] as 'センター'
            //FROM
            //(
            //select AREA_ID as AreaId, DIRECTION_ID,
            //FORMAT(CAST(VS_SCORE_MST.SCORE  AS DECIMAL(9, 6)), 'g18')[SCORE]
            //from VS_VASTU_MST LEFT JOIN  VS_SCORE_MST ON VS_VASTU_MST.SCORE_ID = VS_SCORE_MST.SCORE_ID
            //) d
            //pivot
            //(
            // max(SCORE)
            //for DIRECTION_ID in ([1], [2], [3], [4], [5], [6], [7],[8],[9])
            //) piv)test
            //left join VS_AREA_MST ARE ON test.AreaId = ARE.AREA_ID
            //--inner join VS_VAST_REPORT_TRAN_DETAILS tr on tr.AREA = are.AREA
            //--inner join VS_DIRECTION_MST d ON d.DIRECTION = tr.DIRECTION
            //inner join VS_VAST_REPORT_TRAN_DETAILS tr on tr.AREA = are.AREA_JN
            //inner join VS_DIRECTION_MST d ON d.DIRECTION_JN = tr.DIRECTION
            //where tr.VASTU_REPORT_ID = @VASTU_REPORT_ID

            //SELECT AA.SerialNo ,AA.Area,AA.Direction,AA.North,AA.NorthEast,
            //AA.East,AA.SouthEast ,AA.South,AA.SouthWest,AA.West,AA.NorthWest,
            //AA.Center,IM.IMAGE_SYMBOL as Judgement,IM.IMAGE_URL as ImageURL,
            //FORMAT(CAST(AA.PointsEarned AS DECIMAL(9, 6)), 'g18')[PointsEarned],
            //AA.MasterComments,AA.ResearcherComments FROM(
            //select test.AreaId as SerialNo, ARE.AREA as Area,tr.DIRECTION as Direction ,   test.North,test.NorthEast,test.East,test.SouthEast,test.South, 
            //test.SouthWest,test.West,test.NorthWest,test.Center,cast(tr.VASTU_SCORE  AS decimal(10, 2)) PointsEarned, ARE.COMMENTS AS MasterComments, tr.RESEARCHER_COMMENTS as ResearcherComments  from
            //(SELECT AreaId,  [1] as North, [2] as NorthEast, [3] as East, [4] as SouthEast, [5] as South, [6] as SouthWest, [7] as West,[8] as NorthWest,[9] as Center
            //FROM
            //(
            //select AREA_ID as AreaId, DIRECTION_ID, FORMAT(CAST(VS_SCORE_MST.SCORE  AS DECIMAL(9, 6)), 'g18')[SCORE]
            //from VS_VASTU_MST LEFT JOIN  VS_SCORE_MST ON VS_VASTU_MST.SCORE_ID = VS_SCORE_MST.SCORE_ID
            //) d
            //pivot
            //(
            // max(SCORE)
            //for DIRECTION_ID in ([1], [2], [3], [4], [5], [6], [7],[8],[9])
            //) piv)test left join VS_AREA_MST ARE ON test.AreaId = ARE.AREA_ID
            //inner join VS_VAST_REPORT_TRAN_DETAILS tr on tr.AREA = are.AREA
            //inner join VS_DIRECTION_MST d ON d.DIRECTION = tr.DIRECTION
            //inner join VS_VAST_REPORT_TRAN_DETAILS tr on tr.AREA = are.AREA_JN
            //inner join VS_DIRECTION_MST d ON d.DIRECTION_JN = tr.DIRECTION
            //where tr.VASTU_REPORT_ID = @VASTU_REPORT_ID
            //)AS AA LEFT JOIN
            //VS_VAST_REPORT_TRAN_DETAILS TR1 ON TR1.AREA = AA.Area
            //AND TR1.DIRECTION = AA.Direction
            //LEFT JOIN  VS_SCORE_MST SR ON TR1.VASTU_SCORE = SR.SCORE
            //LEFT JOIN VS_IMAGE_MST IM ON IM.IMAGE_ID = SR.IMAGE_ID
            //where TR1.VASTU_REPORT_ID = @VASTU_REPORT_ID Order by AA.SerialNo
            StringBuilder sbreport = new StringBuilder();
            //if (lan == "ja")
            //{
            //    sbreport.Append(" SELECT AA.SerialNo ,AA.Area,AA.Direction,isnull(AA.北,0) 'Center',isnull(AA.北東,0) 'North', ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" isnull(AA.東,0) 'NorthEast',isnull(AA.南東,0) 'East',isnull(AA.南,0) 'SouthEast',isnull(AA.南西,0) 'South', ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" isnull(AA.西,0) 'SouthWest',isnull(AA.北西,0) 'West', ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" isnull(AA.センター,0) 'NorthWest',IM.IMAGE_SYMBOL as Judgement, ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" IM.IMAGE_URL as ImageURL, ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" FORMAT(CAST(AA.PointsEarned AS DECIMAL(9,6)), 'g18') [PointsEarned], ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" AA.MasterComments,AA.ResearcherComments   FROM (  ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" select test.AreaId as SerialNo, ARE.AREA_JN as Area,  ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" tr.DIRECTION as Direction ,  ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" test.北,test.北東,test.東,test.南東,test.南,   ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" test.南西,test.西,test.北西,test.センター,   ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" cast(tr.VASTU_SCORE  AS decimal(10, 2)) PointsEarned, ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" ARE.COMMENTS AS MasterComments, ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" tr.RESEARCHER_COMMENTS as ResearcherComments ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" from ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" (SELECT AreaId,  [1] as '北', [2] as '北東', [3] as '東', ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" [4] as '南東', [5] as '南', [6] as '南西', [7] as '西', ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" [8] as '北西',[9] as 'センター' ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" FROM ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" ( ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" select AREA_ID as AreaId, DIRECTION_ID,FORMAT(CAST(VS_SCORE_MST.SCORE  AS DECIMAL(9,6)), 'g18')[SCORE] ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" from VS_VASTU_MST LEFT JOIN  VS_SCORE_MST ON VS_VASTU_MST.SCORE_ID = VS_SCORE_MST.SCORE_ID ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" ) d pivot ( max(SCORE)  ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" for DIRECTION_ID in ([1], [2], [3], [4], [5], [6], [7],[8],[9]) ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" ) piv)test left join VS_AREA_MST ARE ON test.AreaId =ARE.AREA_ID ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" inner join VS_VAST_REPORT_TRAN_DETAILS tr on tr.AREA = are.AREA_JN ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" inner join VS_DIRECTION_MST d ON d.DIRECTION_JN = tr.DIRECTION ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" where tr.VASTU_REPORT_ID = @VASTU_REPORT_ID ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" ) AS AA LEFT JOIN ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" VS_VAST_REPORT_TRAN_DETAILS TR1 ON TR1.AREA = AA.Area AND TR1.DIRECTION = AA.Direction ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" LEFT JOIN  VS_SCORE_MST SR ON TR1.VASTU_SCORE = SR.SCORE ");
            //    sbreport.Append(Environment.NewLine);

            //    sbreport.Append(" LEFT JOIN VS_IMAGE_MST IM ON IM.IMAGE_ID = SR.IMAGE_ID where TR1.VASTU_REPORT_ID = @VASTU_REPORT_ID Order by AA.SerialNo ");
            //    sbreport.Append(Environment.NewLine);
            //}
            //else
            //{
                //sbreport.Append("SELECT AA.SerialNo ,AA.Area,AA.Direction,isnull(AA.Center,0) Center,isnull(AA.North,0) North,isnull(AA.NorthEast,0) NorthEast,isnull(AA.East,0) East ,isnull(AA.SouthEast,0) SouthEast,isnull(AA.South,0) South,isnull(AA.SouthWest,0) SouthWest,isnull(AA.West,0) West,isnull(AA.NorthWest,0) NorthWest,IM.IMAGE_SYMBOL as Judgement,IM.IMAGE_URL as ImageURL,FORMAT(CAST(AA.PointsEarned AS DECIMAL(9,6)), 'g18') [PointsEarned],AA.MasterComments,AA.ResearcherComments   FROM ( ");
                sbreport.Append("SELECT AA.SerialNo ,AA.Area,AA.Direction,isnull(AA.Center,0) Center,isnull(AA.North,0) North,isnull(AA.NorthEast,0) NorthEast,isnull(AA.East,0) East ,isnull(AA.SouthEast,0) SouthEast,isnull(AA.South,0) South,isnull(AA.SouthWest,0) SouthWest,isnull(AA.West,0) West,isnull(AA.NorthWest,0) NorthWest,IM.IMAGE_SYMBOL as Judgement,IM.IMAGE_URL as ImageURL,FORMAT(CAST(AA.PointsEarned AS DECIMAL(9,6)), 'g18') [PointsEarned],VM.LONG_DESCRIPTION MasterComments,AA.ResearcherComments   FROM ( ");
                sbreport.Append(Environment.NewLine);

                sbreport.Append("select test.AreaId as SerialNo, tr.AREA as Area,tr.DIRECTION  as Direction ,   test.Center,test.North,test.NorthEast,test.East,test.SouthEast, ");
                sbreport.Append(Environment.NewLine);

                sbreport.Append("test.South,test.SouthWest,test.West,test.NorthWest,cast( tr.VASTU_SCORE  AS decimal(10,2)) PointsEarned, ARE.COMMENTS AS MasterComments, tr.RESEARCHER_COMMENTS as ResearcherComments  from ");
                sbreport.Append(Environment.NewLine);

                sbreport.Append("(SELECT AreaId,  [1] as Center, [2] as North, [3] as NorthEast, [4] as East, [5] as SouthEast, [6] as South, [7] as SouthWest,[8] as West,[9] as NorthWest ");
                sbreport.Append(Environment.NewLine);

                sbreport.Append("FROM ");
                sbreport.Append(Environment.NewLine);

                sbreport.Append("(");
                sbreport.Append(Environment.NewLine);

                //sbreport.Append("select AREA_ID as AreaId, DIRECTION_ID,VS_VASTU_MST.SCORE_ID ");
                sbreport.Append("select AREA_ID as AreaId, DIRECTION_ID,FORMAT(CAST(VS_SCORE_MST.SCORE  AS DECIMAL(9,6)), 'g18')[SCORE] ");
                sbreport.Append(Environment.NewLine);

                sbreport.Append("from VS_VASTU_MST LEFT JOIN  VS_SCORE_MST ON VS_VASTU_MST.SCORE_ID = VS_SCORE_MST.SCORE_ID ");
                sbreport.Append(Environment.NewLine);

                sbreport.Append(" UNION ");
                sbreport.Append(Environment.NewLine);

                sbreport.Append(" select AREA_ID as AreaId, DIRECTION_ID,'0' [SCORE] ");
                sbreport.Append(Environment.NewLine);

                sbreport.Append(" From VS_AREA_MST AM,VS_DIRECTION_MST DM ");
                sbreport.Append(Environment.NewLine);

                sbreport.Append(" Where AREA_ID not in (select distinct AREA_ID from VS_VASTU_MST) ");
                sbreport.Append(Environment.NewLine);

                sbreport.Append(") d ");
                sbreport.Append(Environment.NewLine);

                sbreport.Append("pivot");
                sbreport.Append(Environment.NewLine);

                sbreport.Append("(");
                sbreport.Append(Environment.NewLine);

                //sbreport.Append(" max(SCORE_ID) ");
                sbreport.Append(" max(SCORE) ");
                sbreport.Append(Environment.NewLine);

                sbreport.Append("for DIRECTION_ID in ([1], [2], [3], [4], [5], [6], [7],[8],[9]) ");
                sbreport.Append(Environment.NewLine);

                sbreport.Append(") piv)test left join VS_AREA_MST ARE ON test.AreaId =ARE.AREA_ID  ");
                sbreport.Append(Environment.NewLine);

                sbreport.Append("inner join VS_VAST_REPORT_TRAN_DETAILS tr on tr.AREA_ID = are.AREA_ID ");
                //sbreport.Append("inner join VS_VAST_REPORT_TRAN_DETAILS tr on tr.AREA = are.AREA ");
                sbreport.Append(Environment.NewLine);

                sbreport.Append("inner  join VS_DIRECTION_MST d ON d.DIRECTION = tr.DIRECTION ");
                sbreport.Append(Environment.NewLine);

                sbreport.Append("where tr.VASTU_REPORT_ID = @VASTU_REPORT_ID ");
                sbreport.Append(Environment.NewLine);

                sbreport.Append(")AS AA LEFT JOIN  ");
                sbreport.Append(Environment.NewLine);

                sbreport.Append("VS_VAST_REPORT_TRAN_DETAILS TR1 ON TR1.AREA_ID = AA.SerialNo AND TR1.DIRECTION = AA.Direction ");
                //sbreport.Append("VS_VAST_REPORT_TRAN_DETAILS TR1 ON TR1.AREA = AA.Area AND TR1.DIRECTION = AA.Direction ");
                sbreport.Append(Environment.NewLine);

                sbreport.Append("LEFT JOIN  VS_SCORE_MST SR ON TR1.VASTU_SCORE = SR.SCORE ");
                sbreport.Append(Environment.NewLine);

                sbreport.Append("LEFT JOIN VS_IMAGE_MST IM ON IM.IMAGE_ID = SR.IMAGE_ID ");

                sbreport.Append(" LEFT JOIN VS_VASTU_MST VM ON VM.AREA_ID = TR1.AREA_ID ");
                sbreport.Append(" AND VM.DIRECTION_ID = TR1.DIRECTION_ID AND VM.VASTU_TYPE_ID = 2 ");
                sbreport.Append(" where TR1.VASTU_REPORT_ID = @VASTU_REPORT_ID Order by AA.SerialNo");


            sbreport.Append(Environment.NewLine);
            //}
            
            

            

            return sbreport;

        }


       


        //check whether area and direction is changed. if it is changed, insert as new record in both table
        public bool IsMatch(string CompareAD, InputTextToReport lstFromScreen, List<AreaDirectionComments> lsttextareaFromDB)
        {
            bool result = false;

            if (CompareAD == "AreaDirection")
            {
                List<AreaDirectionComments2> lstADC = new List<AreaDirectionComments2>();
                List<AreaDirectionComments> lstfromDB = new List<AreaDirectionComments>();
                foreach (var item in lstFromScreen.GetInputsText)
                {
                    lstADC.Add(new AreaDirectionComments2 { Area = item.Area, Direction = item.Direction });
                }
                foreach (var item in lsttextareaFromDB)
                {
                    lstfromDB.Add(new AreaDirectionComments { Area = item.Area, Direction = item.Direction });
                }


                result = CompareAreaDirection.JsonCompare(lstADC, lstfromDB);
            }
            return result;
        }





        public List<VasthuReportType> VasthuType()
        {
            List<VasthuReportType> obj = new List<VasthuReportType>();
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                obj = AdoHelper.ExecuteReader<VasthuReportType>(CommandType.Text, "select VASTU_TYPE_ID as VasthuTypeId,VASTU_TYPE  as VasthuType from VS_VASTU_TYPE_MST where delete_flag='0' and status_id=4 ", sqlParameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return obj;
        }



        public List<GetVastuEmailInformation> GetEmailInformation(long VastuReportID)
        {
            List<GetVastuEmailInformation> obj = new List<GetVastuEmailInformation>();
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter P1 = new SqlParameter("@VASTU_REPORT_ID", VastuReportID);
                sqlParameters.Add(P1);

                obj = AdoHelper.ExecuteReader<GetVastuEmailInformation>(CommandType.Text, "select Report_taken_by as Name, Email_Id as EmailID,Vastu_Date as VastuDate from vs_vast_report_tran where delete_flag='0' and status_id=4  and vastu_report_id=@VASTU_REPORT_ID", sqlParameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return obj;
        }

        #endregion


        #region Report
        public List<ShowFinalReport> DownLoadReport_His(int id, string lan)
        {
            List<VastuReportOutput> vastuOutput = new List<VastuReportOutput>();
            List<ShowFinalReport> finalResultReport = new List<ShowFinalReport>();
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter P1 = new SqlParameter("@VASTU_REPORT_ID", id);


                sqlParameters.Add(P1);

                StringBuilder sbrept = new StringBuilder();
                sbrept = GenerateReport(lan);

                List<SqlParameter> rptparameter = new List<SqlParameter>();
                SqlParameter preportid = new SqlParameter("@VASTU_REPORT_ID", id);
                rptparameter.Add(preportid);

                finalResultReport = AdoHelper.ExecuteReader<ShowFinalReport>(CommandType.Text, sbrept.ToString(), rptparameter);

                return finalResultReport;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

    }
}
