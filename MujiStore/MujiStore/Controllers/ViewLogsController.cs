using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MujiStore.Models;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using MujiStore.BLL;
using PagedList;

namespace MujiStore.Controllers
{

    [SessionExpire]
    [Authorize]
    [MUJICustomAuthorize(Roles = "16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31")]
    public class ViewLogsController : BaseController
    {
        private mujiEntities1 db = new mujiEntities1();
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;

        // GET: ViewLogs
        public ActionResult Index(int? page)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int pageSize;
            try
            {

                List<ViewLogDetails> mvList = new List<ViewLogDetails>();

                string query = "";
                using (SqlConnection con = new SqlConnection(CS))
                {

                    query = "SELECT 1 as ID,  N'" + MujiStore.Resources.Resource.VietblMediaIndexH2 + " 'as  TableName, 'VideoMgmtViewLog' as MethodName, COUNT(*) as Number_of_count  FROM tblMedia";
                    query += " UNION ALL";
                    query += " SELECT 2 as ID, N'" + MujiStore.Resources.Resource.VieStoreMstIndexH2 + " ' as  TableName,'StoreMgmtViewLog' as MethodName,  COUNT(*) as Number_of_count FROM  tblStore";
                    query += " UNION ALL";
                    query += " SELECT 3 as ID, N'" + MujiStore.Resources.Resource.VieFoldersIndexH2Title + " ' as  TableName, 'FolderMgmtViewLog' as MethodName, COUNT(*) as Number_of_count FROM  tblFolder";
                    query += " UNION ALL";
                    query += " SELECT 4 as ID,  N'" + MujiStore.Resources.Resource.VieFeedbacksEditH2Title + " ' as  TableName, 'FeedbackMgmtViewLog' as MethodName, COUNT(*) as Number_of_count FROM  tblFeedback ";
                    query += " UNION ALL";
                    query += " SELECT 5 as ID,N'" + MujiStore.Resources.Resource.VieUserIndexH2 + " ' as  TableName, 'UserMgmtViewLog'as MethodName, COUNT(*) as Number_of_count  FROM   tblUser";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        
                        ViewLogDetails viewLog = new ViewLogDetails();
                        viewLog.TableID = Convert.ToInt32(rdr["ID"]);
                        viewLog.TableDescription = rdr["TableName"].ToString();
                        viewLog.TableCount = Convert.ToInt32(rdr["Number_of_count"]);
                        viewLog.MethodName = rdr["MethodName"].ToString();
                        mvList.Add(viewLog);

                    }

                    if (System.Configuration.ConfigurationManager.AppSettings["PageSize"] == null)
                    {
                        pageSize = 10;
                    }
                    else
                    {
                        pageSize = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["PageSize"].ToString());
                    }

                    int pageNumber = (page ?? 1);
                    return View(mvList.ToPagedList(pageNumber,pageSize));
                }

            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            
        }
        //tblMedia View log

    
        [MUJICustomAuthorize(Roles = "16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31")]
        public ActionResult VideoMgmtViewLog(int? page)
        {
            try
            {
                List<tblMedia> mvList = new List<tblMedia>();
                int pageSize;
                string query = "";
                SqlCommand cmd;
                if (System.Configuration.ConfigurationManager.AppSettings["PageSize"] == null)
                {
                    pageSize = 10;
                }
                else
                {
                    pageSize = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["PageSize"].ToString());
                }

                int pageNumber = (page ?? 1);
                using (SqlConnection con = new SqlConnection(CS))
                {
                    query = "select MediaID,Title,IpAddress,CRTDT,CRTCD,UPDDT,UPDCD from tblMedia ";
                    query += "order by MediaID desc";

                    cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        tblMedia Media = new tblMedia();
                        

                        Media.MediaID = Convert.ToInt32(rdr["MediaID"]);
                        Media.Title = rdr["Title"].ToString();
                        Media.IpAddress = rdr["IpAddress"].ToString();
                        Media.CRTDT = Convert.ToDateTime(rdr["CRTDT"]);
                        Media.CRTCD = rdr["CRTCD"].ToString();
                        Media.STRCRTDT = Convert.ToDateTime(rdr["CRTDT"]).ToString("yyyy/MM/dd");// .ToString("yyyy/MM/dd HH:mm:ss tt");
                        Media.STRCRTDTTIME = Convert.ToDateTime(rdr["CRTDT"]).ToString("HH:mm:ss");
                        if (rdr["UPDDT"].ToString() != "")
                        {
                            Media.UPDDT = Convert.ToDateTime(rdr["UPDDT"]);
                            Media.STRUPDDT = Convert.ToDateTime(rdr["UPDDT"]).ToString("yyyy/MM/dd");// .ToString("yyyy/MM/dd HH:mm:ss tt");
                            Media.STRUPDDTTIME = Convert.ToDateTime(rdr["UPDDT"]).ToString("HH:mm:ss");// .ToString("yyyy/MM/dd HH:mm:ss tt");
                        }
                        Media.UPDCD = rdr["UPDCD"].ToString();
                
                        mvList.Add(Media);
                    }
                    return View(mvList.ToPagedList(pageNumber,pageSize));

                }
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

        }

        //Create tblStore View Logs
      
        [MUJICustomAuthorize(Roles = "16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31")]
        public ActionResult StoreMgmtViewLog(int? page)
        {
            try
            {
                List<tblStore> smvList = new List<tblStore>();
                int pageSize;
                if (System.Configuration.ConfigurationManager.AppSettings["PageSize"] == null)
                {
                    pageSize = 10;
                }
                else
                {
                    pageSize = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["PageSize"].ToString());
                }

                int pageNumber = (page ?? 1);

                string query = "";
                SqlCommand cmd;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    query = "select StoreID,convert(varchar,StoreID) StoreNumber,StoreName StoreName,CRTDT,CRTCD,UPDDT,UPDCD,IPAddress,StoreIPAddress from tblStore ";
                    query += "order by StoreID desc";

                    cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        tblStore Store = new tblStore();

                        Store.StoreNumber = Convert.ToInt32(rdr["StoreNumber"]);
                        Store.StoreName = rdr["StoreName"].ToString();
                        Store.CRTDT = Convert.ToDateTime(rdr["CRTDT"]);
                        Store.STRCRTDT = Convert.ToDateTime(rdr["CRTDT"]).ToString("yyyy/MM/dd");// .ToString("yyyy/MM/dd HH:mm:ss tt");
                        Store.STRCRTDTTIME = Convert.ToDateTime(rdr["CRTDT"]).ToString("HH:mm:ss");
                        Store.CRTCD = rdr["CRTCD"].ToString();
                        Store.UPDCD = rdr["UPDCD"].ToString();
                        if (rdr["UPDDT"].ToString() != "")
                        {
                            Store.UPDDT = Convert.ToDateTime(rdr["UPDDT"]);
                            Store.STRUPDDT = Convert.ToDateTime(rdr["UPDDT"]).ToString("yyyy/MM/dd");// .ToString("yyyy/MM/dd HH:mm:ss tt");
                            Store.STRUPDDTTIME = Convert.ToDateTime(rdr["UPDDT"]).ToString("HH:mm:ss");
                        }
                        Store.IPAddress = rdr["IPAddress"].ToString();                                              
                        Store.StoreIPAddress = rdr["StoreIPAddress"].ToString();
                        smvList.Add(Store);                        

                    }
                    return View(smvList.ToPagedList(pageNumber,pageSize));
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }

        //Create tblFeedback View Log
      
        [MUJICustomAuthorize(Roles = "16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31")]
        public ActionResult FeedbackMgmtViewLog(int? page)
        {
            try
            {

                string query = "";
                SqlCommand cmd;
                int pageSize;
                List<tblFeedback> fbmvList = new List<tblFeedback>();
                if (System.Configuration.ConfigurationManager.AppSettings["PageSize"] == null)
                {
                    pageSize = 10;
                }
                else
                {
                    pageSize = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["PageSize"].ToString());
                }

                int pageNumber = (page ?? 1);

                using (SqlConnection con = new SqlConnection(CS))
                {
                    query = "select FeedbackID,Comments,WriterName,IPAddress,WriterDatetime, CRTDT,CRTCD,UPDDT,UPDCD from tblFeedback ";
                    query += "order by FeedbackID desc";

                    cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        tblFeedback feedback = new tblFeedback();

                        feedback.FeedbackID = Convert.ToInt32(rdr["FeedbackID"]);
                        feedback.Comments = rdr["Comments"].ToString();
                        feedback.WriterName = rdr["WriterName"].ToString();
                        feedback.IPAddress = rdr["IPAddress"].ToString();
                        feedback.WriterDatetime = Convert.ToDateTime(rdr["WriterDatetime"]);
                        feedback.CRTDT = Convert.ToDateTime(rdr["CRTDT"]);
                        feedback.CRTCD = rdr["CRTCD"].ToString();
                        feedback.STRCRTDT = Convert.ToDateTime(rdr["CRTDT"]).ToString("yyyy/MM/dd");// .ToString("yyyy/MM/dd HH:mm:ss tt");
                        feedback.STRCRTDTTIME = Convert.ToDateTime(rdr["CRTDT"]).ToString("HH:mm:ss");
                        if (rdr["UPDDT"].ToString() != "")
                        {
                            feedback.UPDDT = Convert.ToDateTime(rdr["UPDDT"]);
                            feedback.STRUPDDT = Convert.ToDateTime(rdr["UPDDT"]).ToString("yyyy/MM/dd");// .ToString("yyyy/MM/dd HH:mm:ss tt");
                            feedback.STRUPDDTTIME = Convert.ToDateTime(rdr["UPDDT"]).ToString("HH:mm:ss");
                        }

                        feedback.UPDCD = rdr["UPDCD"].ToString();
                        fbmvList.Add(feedback);


                    }

                }
                return View(fbmvList.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }


        }

        //Create tblFolder View Log
     
        [MUJICustomAuthorize(Roles = "16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31")]
        public ActionResult FolderMgmtViewLog(int? page)
        {
            try
            {
            string query = "";
            SqlCommand cmd;

            int pageSize;
            List<tblFolder> folmvList = new List<tblFolder>();
            if (System.Configuration.ConfigurationManager.AppSettings["PageSize"] == null)
            {
                pageSize = 10;
            }
            else
            {
                pageSize = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["PageSize"].ToString());
            }

            int pageNumber = (page ?? 1);

            using (SqlConnection con = new SqlConnection(CS))
            {
                query = "select M.Name,P.Name ParentName,M.CRTDT,M.CRTCD,M.UPDDT,M.UPDCD,M.IPAddress  ";
                query += "from tblFolder M ";
                query += "left join tblFolder P on M.ParentID = P.FolderID ";
                query += "order by M.FolderID desc";

                cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    tblFolder folder = new tblFolder();

                    folder.Name = rdr["Name"].ToString();
                    folder.ParentFolderName = rdr["ParentName"].ToString();
                        folder.CRTDT = Convert.ToDateTime(rdr["CRTDT"]);

                        folder.CRTCD = rdr["CRTCD"].ToString();
                        folder.STRCRTDT = Convert.ToDateTime(rdr["CRTDT"]).ToString("yyyy/MM/dd");// .ToString("yyyy/MM/dd HH:mm:ss tt");
                        folder.STRCRTDTTIME = Convert.ToDateTime(rdr["CRTDT"]).ToString("HH:mm:ss");
                        if (rdr["UPDDT"].ToString() != "")
                    {
                        folder.STRUPDDT = Convert.ToDateTime(rdr["UPDDT"]).ToString("yyyy/MM/dd");
                          folder.STRUPDDTTIME = Convert.ToDateTime(rdr["UPDDT"]).ToString("HH:mm:ss");
                        }
                    folder.UPDCD = rdr["UPDCD"].ToString();
                    folder.IPAddress = rdr["IPAddress"].ToString();

                    folmvList.Add(folder);

                }
               
            }
                return View(folmvList.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }

        //tblUser log Report
      
        [MUJICustomAuthorize(Roles = "16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31")]
        public ActionResult UserMgmtViewLog(int? page)
        {
            try
            {           
            string query = "";
            SqlCommand cmd;
            List<tblUser> userList = new List<tblUser>();
            int pageSize;
            if (System.Configuration.ConfigurationManager.AppSettings["PageSize"] == null)
            {
                pageSize = 10;
            }
            else
            {
                pageSize = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["PageSize"].ToString());
            }

            int pageNumber = (page ?? 1);

            using (SqlConnection con = new SqlConnection(CS))
                {
                    query = "select UserID,UserName,CRTDT,CRTCD,UPDDT,UPDCD,IPAddress from tblUser";                    
                    query += " order by UserID desc";

                    cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        tblUser tblUser = new tblUser();
                         tblUser.UserID = Convert.ToInt32(rdr["UserID"]);
                        tblUser.UserName = rdr["UserName"].ToString();
                        tblUser.CRTDT = Convert.ToDateTime(rdr["CRTDT"]);
                        tblUser.CRTCD = rdr["CRTCD"].ToString();
                        tblUser.STRCRTDT = Convert.ToDateTime(rdr["CRTDT"]).ToString("yyyy/MM/dd");// .ToString("yyyy/MM/dd HH:mm:ss tt");
                        tblUser.STRCRTDTTIME = Convert.ToDateTime(rdr["CRTDT"]).ToString("HH:mm:ss");
                        if (rdr["UPDDT"].ToString() != "")
                        {
                        tblUser.UPDDT = Convert.ToDateTime(rdr["UPDDT"]);
                        tblUser.STRUPDDT = Convert.ToDateTime(rdr["UPDDT"]).ToString("yyyy/MM/dd");// .ToString("yyyy/MM/dd HH:mm:ss tt");
                            tblUser.STRUPDDTTIME = Convert.ToDateTime(rdr["UPDDT"]).ToString("HH:mm:ss");
                        }

                        tblUser.UPDCD = rdr["UPDCD"].ToString();
                        tblUser.IPAddress = rdr["IPAddress"].ToString();

                        userList.Add(tblUser);

                     
                    }                     
                    
                }
                    return View(userList.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }
    }

}