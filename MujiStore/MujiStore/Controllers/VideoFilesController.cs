using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MujiStore.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using MujiStore.BLL;
using PagedList;
using System.Threading;
using System.Globalization;

namespace MujiStore.Controllers
{
  
    [AuthorizeIPAddress]
 
     
    public class VideoFilesController : BaseController
    {
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        private mujiEntities1 db = new mujiEntities1();
        // GET: VideoFiles
        [NonAction]
        public ActionResult Index()
        {
            CommonLogic.SetCultureInfo();
            return View();
        }
        [NonAction]
        public ActionResult Create()
        {
            CommonLogic.SetCultureInfo();
            return View();
        }


        public string GetSessionUserorStoreName(string ipAddress)
        {
            string UserorStoreName;
            string query = "";
            if (Session["UserName"] == null || Session["UserName"].ToString() == "")
            {
                ipAddress = Session["IPAddress"].ToString();
 
                UserorStoreName = ipAddress;

                if(Session["StoreName"].ToString() !=  "Unknown")
                {
                    UserorStoreName = Session["StoreName"].ToString();
                }
 
            }
            else
            {
                UserorStoreName = Session["LoginUserName"].ToString();
 
            }

            return UserorStoreName;
        }
        [HttpPost]
        public ActionResult SaveThumbnailImage(tblFeedback model)
        {
            string query = "";
            IPAddressDtl ipdtl = new IPAddressDtl();
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            CommonLogic.SetCultureInfo();
            try
            {
                var fileName = "";
                var path = Server.MapPath("~/FeedBack");

                if (model.PostedFile != null)
                {
  
                    fileName = CommonLogic.ModifiedFileName(model.PostedFile.FileName);
                    //get full file path
                    var fileNameWitPath = Path.Combine(path, fileName);
                    model.PostedFile.SaveAs(fileNameWitPath);
                }

                model.WriterName = GetSessionUserorStoreName(Session["IPAddress"].ToString());


                if (model.WriterName.Trim().Length == 0)
                {
                    model.WriterName = Session["IPAddress"].ToString();
                }
                LogInfo.Comments = "Feedback Created - " + model.Comments;
                using (SqlConnection con = new SqlConnection(CS))
                    {
                        query = "Insert into tblFeedback(MovieID,WriterName,Comments,FileName,IPAddress,CRTCD,CRTDT,DELFG) Values ";
                        query += "(@MovieID,@WriterName,@Comments,@FileName,@IPAddress,@CRTCD,@CRTDT,@DELFG);";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@MovieID", model.MovieID);
                        cmd.Parameters.AddWithValue("@WriterName", model.WriterName);
                        cmd.Parameters.AddWithValue("@Comments", model.Comments);
                        cmd.Parameters.AddWithValue("@FileName", fileName);
                        cmd.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());
                        cmd.Parameters.AddWithValue("@CRTCD", model.WriterName);
                        cmd.Parameters.AddWithValue("@CRTDT", DateTime.Now);
                        cmd.Parameters.AddWithValue("@DELFG", false);
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        int result = cmd.ExecuteNonQuery();
                        CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.CntFeedbackCreateSuccMsg;
                }
          
                return RedirectToAction("ViewUploadDetailsByID", "VideoFiles", new { id = model.MovieID, folderID = model.FolderID, formatid = Convert.ToInt32(Session["DefaultFormatID"].ToString()) });
              }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }
        public ActionResult ViewUploadDetails()
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            CommonLogic.SetCultureInfo();
            CommonLogic.GetSessionDetails();
            ViewData["PlayVideo"] = "0";
            ViewData["PlayVideoFileName"] = "";
            ViewData["VideoRecommened"] = "1";
            try
            {

                int FolderID = -1;

               

                var headFolderStructue = getFolderStructure(FolderID);
                ViewData["headFolderStructue"] = headFolderStructue;

                var childFolderDtl = getChildFolder(FolderID);
                ViewData["ChildFolderDtl"] = childFolderDtl;

                var mediaFileDtl = getMedialFileDetails(FolderID);
                ViewData["VideoFileDetails"] = mediaFileDtl;

                if (FolderID == 0)
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.FolderNotMapped;
                }

                return View("ViewUploadDetailsNew");
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

        }

        public List<tblFeedback> getFeedBackDetails(int MediaID)
        {
            List<tblFeedback> fblist = new List<tblFeedback>();
            string query = "";
            using (SqlConnection con = new SqlConnection(CS))
            {
                query = "select FeedbackID,WriterName,Comments,FileName,WriterDatetime from tblFeedback where MovieID = @MovieID and DELFG=0 Order By FeedbackID Desc";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MovieID", MediaID);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    tblFeedback fback = new tblFeedback();
                    fback.FeedbackID = Convert.ToInt32(rdr["FeedbackID"]);
                    fback.WriterName = rdr["WriterName"].ToString();
                    fback.Comments = rdr["Comments"].ToString();
                    fback.FileName = rdr["FileName"].ToString();
                    fback.WriterDatetime = Convert.ToDateTime(rdr["WriterDatetime"]);
                    fback.STRCRTDT = Convert.ToDateTime(rdr["WriterDatetime"]).ToString("yyyy/MM/dd HH:mm:ss");// .ToString("yyyy/MM/dd HH:mm:ss tt");
                    fback.STRCRTDTTIME = Convert.ToDateTime(rdr["WriterDatetime"]).ToString("HH:mm:ss");
                    fblist.Add(fback);
                }
            }

            return fblist;
        }

        public tblDeployStatu GetDeployStatus(int mediaID)
        {
            List<tblDeployStatu> dpsdtllist = new List<tblDeployStatu>();
            tblDeployStatu dpstdtl = new tblDeployStatu();
            bool depserIsExists = false;
            if (Session["SubnetID"].ToString() != "-1")
            {
                dpsdtllist = BLL.CommonLogic.GetDSWithSS(mediaID, Convert.ToInt32(Session["SubnetID"]));
                if (dpsdtllist == null || dpsdtllist.Count == 0)
                {
                    dpsdtllist = BLL.CommonLogic.GetDSWithSNSS(mediaID, Convert.ToInt32(Session["SubnetID"]));
                }
                if (dpsdtllist != null && dpsdtllist.Count > 0)
                {
                    depserIsExists = true;
                    dpstdtl.DSServer = dpsdtllist[0].DSServer;
                    dpstdtl.IPAddress = dpsdtllist[0].IPAddress;
                    dpstdtl.FormatName = dpsdtllist[0].FormatName;
                    dpstdtl.Recommend = dpsdtllist[0].Recommend;
  
                }
            }

            return (tblDeployStatu)dpstdtl;
 
        }
        public tblMedia getMediaDetails(int MediaID)
        {
            tblMedia mediaDtl = new tblMedia();
            string query = "";
            using (SqlConnection con = new SqlConnection(CS))
            {
                query = "Select MediaID,Title,Description,Video,Thumbnail,FolderID,ViewCount from [tblmedia] where MediaID =@MediaID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MediaID", MediaID);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    
                    mediaDtl.MediaID = Convert.ToInt32(rdr["MediaID"]);
                    mediaDtl.Title = rdr["Title"].ToString();
                    mediaDtl.Description = rdr["Description"].ToString();
                    mediaDtl.Video = rdr["Video"].ToString();
                    mediaDtl.Thumbnail = rdr["Thumbnail"].ToString();
                    mediaDtl.FolderID = Convert.ToInt32(rdr["FolderID"]);
                    mediaDtl.ViewCount = Convert.ToInt32(rdr["ViewCount"]);
 
                }
            }

            return mediaDtl;
        }

      


        public List<tblMedia> getMedialFileDetails(int folderID)
        {
            List<tblMedia> videolist = new List<tblMedia>();
            string query = "";
            using (SqlConnection con = new SqlConnection(CS))
            {
                query = "Select MediaID,Title,Description,Video,Thumbnail,FolderID,Duration,ViewCount from [tblmedia] ";
                query += " LEFT JOIN [tblUser] AS U1 ON tblmedia.Registerer = U1.ID ";
                query += " LEFT JOIN [tblUser] AS U2 ON tblmedia.Accepter = U2.ID ";
                query += " where FolderID =@FolderID and U1.DELFG = 0 and U2.DELFG = 0 and tblmedia.DELFG = 0 and ConvertStatus >= 3 ";
                query += " and ApprovalStatus >= 3 ";
                query += " and convert(datetime,format(getdate(), 'yyyy-MM-dd HH:mm')) ";
                query += " between VideoPlayStartDate and isnull(VideoPlayEndDate,DATEADD(DD,30,getdate())) ";
                query += " ORDER BY Title ASC "; //Changed VJ 2021/08/10
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FolderID", folderID);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    tblMedia video = new tblMedia();
                    video.MediaID = Convert.ToInt32(rdr["MediaID"]);
                    video.Title = rdr["Title"].ToString();
                    video.Description = rdr["Description"].ToString();
                    video.Video = rdr["Video"].ToString();
                    video.Thumbnail = rdr["Thumbnail"] .ToString();
                    video.FolderID = Convert.ToInt32(rdr["FolderID"]);
                    video.Duration = Convert.ToInt32(rdr["Duration"]);
                    video.ViewCount = Convert.ToInt32(rdr["ViewCount"]);
    
                    videolist.Add(video);
                }
            }

            return videolist;
        }
        public string GetFileDuration(int duration)
        {
            return CommonLogic.GetFileDuration(duration);
        }
        public List<tblFolder> getFolderStructure(int folderID)
        {
            List<tblFolder> folderlist = new List<tblFolder>();
            List<tblFolder> folderlistReverse = new List<tblFolder>();
            string query = "";

            using (SqlConnection con = new SqlConnection(CS))
            {
                query = "WITH tblParent AS ( SELECT * FROM tblFolder WHERE DELFG = 0 AND FolderID = @id UNION ALL SELECT tblFolder.*";
                query += " FROM tblFolder  JOIN tblParent  ON tblFolder.FolderID = tblParent.ParentId Where tblFolder.DELFG = 0 ) ";
                query += " SELECT * FROM  tblParent";

 
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", folderID);
                cmd.Parameters.AddWithValue("@BaseFolderID", Convert.ToInt32(Session["FolderID"].ToString()));
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    tblFolder folder = new tblFolder();
                    folder.FolderID = Convert.ToInt32(rdr["FolderID"]);
                    folder.ParentID = Convert.ToInt32(rdr["ParentID"]);
                    folder.Name = rdr["Name"].ToString();
                    folderlistReverse.Add(folder);
                }
            }
            folderlistReverse.Reverse();
            folderlist.AddRange(folderlistReverse);
 
            return folderlist;
        }
        public void UpdDeniedIPAddress(int MediaID,string ErrorID)
        {
            int result = 0;

            using (SqlConnection con = new SqlConnection(CS))
            {
                string query = "";
                con.Open();
                SqlCommand cmd;
                tblUser tblUser = new tblUser();

                //Assing Query String
                query = "Insert into tblDeniedIPAddress(IPAddress,MediaID,Remarks,DELFG,CRTDT,CRTCD) Values " +
                " (@IPAddress,@MediaID,@Remarks,@DELFG,@CRTDT,@CRTCD) ";



                //Intialize Command and pass the paramters


                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());
                cmd.Parameters.AddWithValue("@MediaID", MediaID);
                cmd.Parameters.AddWithValue("@Remarks", System.Configuration.ConfigurationManager.AppSettings[ErrorID] == null ? "エラーメッセージが見つかりません" : System.Configuration.ConfigurationManager.AppSettings[ErrorID]);
                cmd.Parameters.AddWithValue("@DELFG", 0);
                cmd.Parameters.AddWithValue("@CRTDT", DateTime.Now);
                cmd.Parameters.AddWithValue("@CRTCD", Session["UserName"] != null ? Session["UserName"].ToString() : string.Empty);
                

                cmd.CommandType = CommandType.Text;
                result = cmd.ExecuteNonQuery();


            }
           
        }
        public List<tblFolder> getChildFolder(int parentId)
        {
            
            List<tblFolder> folderlist = new List<tblFolder>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select FolderID,ParentID,Name from [tblFolder] WHERE ParentID=@ParentID and DELFG = 0 Order by Name", con);
                cmd.Parameters.AddWithValue("@ParentID", parentId);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    tblFolder folder = new tblFolder();
                    folder.FolderID = Convert.ToInt32(rdr["FolderID"]);
                    folder.ParentID = Convert.ToInt32(rdr["ParentID"]);
                    folder.Name = rdr["Name"].ToString();
                    folderlist.Add(folder);
                }
            }

            return folderlist;
        }
 
        public ActionResult MediaViewLog(int MediaID,int? page)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            CommonLogic.SetCultureInfo();
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
            try
            {
                tblMedia Mediadtl = new tblMedia();
                
                 Mediadtl = getMediaDetails(MediaID);
                List<tblMediaViewLog> mvList = new List<tblMediaViewLog>();
                VideoFeedBack VFeedback = new VideoFeedBack();
                VFeedback.FolderID = Mediadtl.FolderID;
                VFeedback.VideoId = Mediadtl.MediaID;
                VFeedback.VideoTitle = Mediadtl.Title;
                ViewData["VFeedback"] = VFeedback;

                string query = "";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    query = " SELECT TOP 100 L.DateTime, L.CRTDT,L.ClientSubnetID, ";
                    query += " S.StoreName, L.UserName, L.ClientIP, L.UserAgent, L.FormatID ,F.Name AS FormatName ";
                    query += " FROM tblMediaViewLog AS L ";
                    query += " LEFT JOIN tblStoreSubnet AS SS ON L.ClientSubnetID = SS.Subnet ";
                    query += " LEFT JOIN tblStore AS S ON SS.Store = S.StoreID ";
                    query += " LEFT JOIN [tblFormat] AS F ON L.FormatID = F.formatid ";
                    query += " where L.MediaID = @MediaID order by L.MediaViewLogID desc";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@MediaID", MediaID);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        tblMediaViewLog medlog = new tblMediaViewLog();
                        medlog.STRCRTDT = Convert.ToDateTime(rdr["CRTDT"]).ToString("yyyy/MM/dd");// .ToString("yyyy/MM/dd HH:mm:ss tt");
                        medlog.STRCRTDTTIME = Convert.ToDateTime(rdr["CRTDT"]).ToString("HH:mm:ss");

                        if (!rdr.IsDBNull(rdr.GetOrdinal("DateTime")))
                        {
                            medlog.UPDDT = Convert.ToDateTime(rdr["DateTime"]);
                        }
                        medlog.ClientSubnetID = Convert.ToInt32(rdr["ClientSubnetID"].ToString());
                        medlog.StoreName = rdr["StoreName"].ToString();
                        medlog.UserName = rdr["UserName"].ToString();
                        
                        if (Convert.ToInt32(rdr["FormatID"].ToString()) == -1)
                        {
                            medlog.FormatName = MujiStore.Resources.Resource.Auto;
                        }
                        else if (Convert.ToInt32(rdr["FormatID"].ToString()) == 0)
                        {
                            medlog.FormatName = MujiStore.Resources.Resource.High;
                        }
                        else if (Convert.ToInt32(rdr["FormatID"].ToString()) == 1)
                        {
                            medlog.FormatName = MujiStore.Resources.Resource.Low;
                        }
                        else if (Convert.ToInt32(rdr["FormatID"].ToString()) == 2)
                        {
                            medlog.FormatName = MujiStore.Resources.Resource.Medium;
                        }
                        medlog.ClientIP = rdr["ClientIP"].ToString();
                        medlog.UserAgent = rdr["UserAgent"].ToString();
 
                        mvList.Add(medlog);
                    }
                }
                ViewData["getdata"] = mvList;
                return View(mvList);
 
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }
        public ActionResult ShowFolderDetails(int folderID)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            CommonLogic.SetCultureInfo();
            CommonLogic.GetSessionDetails();
            ViewData["PlayVideo"] = "0";
            ViewData["PlayVideoFileName"] = "";
            ViewData["VideoRecommened"] = "1";

            try
            {
                var headFolderStructue = getFolderStructure(folderID);
                ViewData["headFolderStructue"] = headFolderStructue;

                var childFolderDtl = getChildFolder(folderID);
                ViewData["ChildFolderDtl"] = childFolderDtl;

                var mediaFileDtl = getMedialFileDetails(folderID);
                ViewData["VideoFileDetails"] = mediaFileDtl;
   
                return View("ViewUploadDetailsNew");
            }
            catch(Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
    
        }
     
        public ActionResult ViewMeidaLogDetailsByID(int ID, int folderID)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            CommonLogic.SetCultureInfo();
            try
            {
               
                
               

                VideoFeedBack VFeedback = new VideoFeedBack();
                VFeedback.FolderID = folderID;
                VFeedback.VideoId = ID;
                ViewData["VFeedback"] = VFeedback;
                var headFolderStructue = getFolderStructure(folderID);
                ViewData["headFolderStructue"] = headFolderStructue;

                var childFolderDtl = getChildFolder(folderID);
                ViewData["ChildFolderDtl"] = childFolderDtl;

                var mediaFileDtl = getMedialFileDetails(folderID);
                ViewData["VideoFileDetails"] = mediaFileDtl;

                var feedBackDtl = getFeedBackDetails(VFeedback.VideoId);
                ViewData["feedBackDtl"] = feedBackDtl;
                

                tblDeployStatu depStatus = new tblDeployStatu();
                depStatus.IPAddress = Session["VideoIPAddress"].ToString();
                depStatus.Recommend = true;
                depStatus.FormatName = "MP4";

                ViewData["ServerDtl"] = depStatus;

                var FileDtl = mediaFileDtl.Where(a => a.MediaID == ID).SingleOrDefault();
                if (FileDtl == null)
                {
                    return View("ViewUploadDetailsNew");
                }
               
                LogInfo.Comments = "Media Log back to Video File - " + FileDtl.Title.ToString();
                CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
               
                ViewData["FileDetails"] = (tblMedia)FileDtl;
   
                return View("ViewUploadDetailsNew");
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

        }
        
        // public ActionResult FormatChange(int ID, int folderID,int formatid)
        public ActionResult FormatChange(int ID, int folderID, int formatid)
        {
          
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            CommonLogic.SetCultureInfo();
            CommonLogic.GetSessionDetails();
            Session["DefaultFormatID"] = formatid;
            BindFormat(Convert.ToInt32(Session["DefaultFormatID"].ToString()));
            ViewData["DefFormatID"] = Convert.ToInt32(Session["DefaultFormatID"].ToString());
            ViewData["PlayVideo"] = 1;
            ViewData["PlayVideoFileName"] = "";
            ViewData["VideoRecommened"] = "1";
            bool denip = false;
            try
            {
                string query = "";
                string username;

                               
                VideoFeedBack VFeedback = new VideoFeedBack();
                VFeedback.FolderID = folderID;
                VFeedback.VideoId = ID;
                ViewData["VFeedback"] = VFeedback;
                var headFolderStructue = getFolderStructure(folderID);
                ViewData["headFolderStructue"] = headFolderStructue;

                var childFolderDtl = getChildFolder(folderID);
                ViewData["ChildFolderDtl"] = childFolderDtl;

                var mediaFileDtl = getMedialFileDetails(folderID);
                ViewData["VideoFileDetails"] = mediaFileDtl;

                var feedBackDtl = getFeedBackDetails(VFeedback.VideoId);
                ViewData["feedBackDtl"] = feedBackDtl;

                if (Session["SubnetID"].ToString() == "-1")
                {
                    UpdDeniedIPAddress(ID, "IP1");
                    denip = true;
                }

                var FileDtl = mediaFileDtl.Where(a => a.MediaID == ID).SingleOrDefault();
                if (FileDtl == null)
                {
                    return View("ViewUploadDetailsNew");
                }

                username = GetSessionUserorStoreName(Session["IPAddress"].ToString());
                if (username == Session["IPAddress"].ToString())
                {
                    username = Resources.Resource.Unknown;
                }
                using (SqlConnection con = new SqlConnection(CS))
                {

                    query = "Insert into [tblMediaViewLog](MediaID,FormatID,UserName,ClientIP,ClientSubnetID,UserAgent,IPAddress,CRTCD) Values ";
                    query += "(@MediaID,@FormatID,@UserName,@ClientIP,@ClientSubnetID,@UserAgent,@IPAddress,@CRTCD);";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@MediaID", ID);
                    cmd.Parameters.AddWithValue("@FormatID", formatid);
                    cmd.Parameters.AddWithValue("@UserName", username);
                    cmd.Parameters.AddWithValue("@ClientIP", Session["IPAddress"].ToString());
                    cmd.Parameters.AddWithValue("@ClientSubnetID", Session["SubnetID"].ToString());
                    cmd.Parameters.AddWithValue("@UserAgent", Request.ServerVariables["HTTP_USER_AGENT"]);
                    cmd.Parameters.AddWithValue("@IPAddress", Session["StoreIPAddress"].ToString());
                    cmd.Parameters.AddWithValue("@CRTCD", username);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                }

                using (SqlConnection con = new SqlConnection(CS))
                {
                    query = "";
                    query = "UPDATE tblMedia SET ViewCount = ViewCount + 1 WHERE MediaID =@MediaID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@MediaID", ID);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                }
                LogInfo.Comments = "Media File Watched - " + FileDtl.Title.ToString();
                CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                FileDtl.ViewCount += 1;


                List<tblDeployStatu> dpsdtllist = new List<tblDeployStatu>();
                List<tblDeployStatu> dpstdtl = new List<tblDeployStatu>();
                tblDeployStatu dpsauto = new tblDeployStatu();
                if (Session["SubnetID"].ToString() != "-1")
                {

                    dpsauto = BLL.CommonLogic.GetAutoFormat(Convert.ToInt32(Session["SubnetID"]));
                    dpsdtllist = BLL.CommonLogic.GetAllFormat(Convert.ToInt32(Session["SubnetID"]));
                    string fileName = "";
                    if (dpsauto != null && dpsauto.ToString() != "")
                    {
                        foreach (tblDeployStatu dps in dpsdtllist)
                        {
                            if (dps.FormatID == 0)
                            {
                                fileName = ID + ".mp4";
                            }
                            else
                            {
                                fileName = ID + "-" + dps.FormatID + ".mp4";
                            }
                            if (dpsauto.FormatID == dps.FormatID)
                            {
                                tblDeployStatu dpst = new tblDeployStatu();


                                dpst.FormatID = -1;
                                dpst.FileName = fileName;
                                dpst.IPAddress = Session["VideoIPAddress"].ToString();
                                dpst.Recommend = dps.Recommend;
                                dpstdtl.Add(dpst);
                            }
                        }
                    }
                   

                    if (dpstdtl.Count == 0)
                    {
                        foreach (tblDeployStatu dps in dpsdtllist)
                        {
                            if (dps.FormatID == 0)
                            {
                                fileName = ID + ".mp4";
                            }
                            else
                            {
                                fileName = ID + "-" + dps.FormatID + ".mp4";
                            }
                            if (dps.FormatID == Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["VideoDefaultFormat"].ToString()))
                            {
                                tblDeployStatu dpst = new tblDeployStatu();


                                dpst.FormatID = -1;
                                dpst.FileName = fileName;
                                //dpst.FileName = ID + "-3.mp4";
                                dpst.IPAddress = Session["VideoIPAddress"].ToString();
                                dpst.Recommend = dps.Recommend;
                                dpstdtl.Add(dpst);
                            }
                        }

                    }

                    if (dpsdtllist != null && dpsdtllist.Count > 0)
                    {




                        foreach (tblDeployStatu dps in dpsdtllist)
                        {
                            if (dps.FormatID == 0)
                            {
                                fileName = ID + ".mp4";
                            }
                            else
                            {
                                fileName = ID + "-" + dps.FormatID + ".mp4";
                            }

                            tblDeployStatu dpst = new tblDeployStatu();
                            dpst.FormatID = dps.FormatID;
                            dpst.IPAddress = Session["VideoIPAddress"].ToString();
                            dpst.FileName = fileName;
                            dpst.Recommend = dps.Recommend;
 
                            dpstdtl.Add(dpst);
                        }
                        foreach (tblDeployStatu dps in dpstdtl)
                        {
                            if (dps.IPAddress == null || dps.IPAddress == "-1")
                            {
                                if (denip == false)
                                {
                                    UpdDeniedIPAddress(ID, "IP2");
                                }
                            }
                            if (dps.FormatID == formatid)
                            {
                                ViewData["PlayVideoFileName"] = dps.FileName;
                                if (dps.Recommend == true)
                                {
                                    ViewData["VideoRecommened"] = "1";
                                }
                                else
                                {
                                    ViewData["VideoRecommened"] = "0";
                                }

                            }

                        }




                    }
                }

                foreach (tblDeployStatu dps in dpstdtl)
                {
                    
                    if (dps.FormatID == formatid)
                    {
                        
                        if (dps.Recommend == true)
                        {
                            ViewData["VideoRecommened"] = "1";
                        }
                        else
                        {
                            ViewData["VideoRecommened"] = "0";
                        }

                    }

                }

                ViewData["ServerDtl"] = dpstdtl;


               

                ViewData["FileDetails"] = (tblMedia)FileDtl;


                return View("ViewUploadDetailsNew");
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
 
        }

        public JsonResult GetUsersData(int ID, int folderID, int formatid)
        {
            var users = BLL.CommonLogic.GetAllFormat(Convert.ToInt32(Session["SubnetID"]));
            return Json(users, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ViewUploadDetailsByID(int ID,int folderID,int formatid)
        {
            JsonResult jsonresult = new JsonResult();
            var test = Request.Form["ScrollPositionX"];
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            CommonLogic.SetCultureInfo();
            CommonLogic.GetSessionDetails();
            BindFormat(formatid);
            ViewData["DefFormatID"] = formatid;
            ViewData["PlayVideo"] = 1;
            ViewData["PlayVideoFileName"] = "";
            ViewData["VideoRecommened"] = "1";
            playVideoDetails vplayDetail = new playVideoDetails();
 
            bool denip = false;
 
            try
            {
                string query = "";
                string username;

                if(TempData["MediaID"]!= null)
                {
                    ID = Convert.ToInt32(TempData["MediaID"]);
                }
                if (TempData["FolderID"] != null)
                {
                    folderID = Convert.ToInt32(TempData["FolderID"]);
                }
                if (TempData["MediaID"] != null)
                { 
 
                    TempData["MediaID"] = null;
                    TempData["FolderID"] = null;
                    return RedirectToAction("ViewUploadDetailsByID", "VideoFiles", new { id = ID, folderID = folderID, formatid = Convert.ToInt32(Session["DefaultFormatID"].ToString()) });
                }
                
 
                VideoFeedBack VFeedback = new VideoFeedBack();
                VFeedback.FolderID = folderID;
                VFeedback.VideoId = ID;
                ViewData["VFeedback"] = VFeedback;
                var headFolderStructue = getFolderStructure(folderID);
                ViewData["headFolderStructue"] = headFolderStructue;

                var childFolderDtl = getChildFolder(folderID);
                ViewData["ChildFolderDtl"] = childFolderDtl;

                var mediaFileDtl = getMedialFileDetails(folderID);
                ViewData["VideoFileDetails"] = mediaFileDtl;

                var feedBackDtl = getFeedBackDetails(VFeedback.VideoId);
                ViewData["feedBackDtl"] = feedBackDtl;

                if (Session["SubnetID"].ToString() == "-1")
                {
                    UpdDeniedIPAddress(ID, "IP1");
                    denip = true;
                }

                var FileDtl = mediaFileDtl.Where(a => a.MediaID == ID).SingleOrDefault();
                if (FileDtl == null)
                {
                    return View("ViewUploadDetailsNew");
                }
                vplayDetail.MediaID = FileDtl.MediaID;
                vplayDetail.FolderID = FileDtl.FolderID;
                vplayDetail.Title = FileDtl.Title;
                vplayDetail.Description = FileDtl.Description;
                vplayDetail.Video = FileDtl.Video;
                vplayDetail.Thumbnail = FileDtl.Thumbnail;
                vplayDetail.ViewCount = FileDtl.ViewCount +1;


                username = GetSessionUserorStoreName(Session["IPAddress"].ToString());
                if (username == Session["IPAddress"].ToString())
                {
                    username = Resources.Resource.Unknown;
                }
                
                    using (SqlConnection con = new SqlConnection(CS))
                    {

                        query = "Insert into [tblMediaViewLog](MediaID,FormatID,UserName,ClientIP,ClientSubnetID,UserAgent,IPAddress,CRTCD) Values ";
                        query += "(@MediaID,@FormatID,@UserName,@ClientIP,@ClientSubnetID,@UserAgent,@IPAddress,@CRTCD);";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@MediaID", ID);
                        cmd.Parameters.AddWithValue("@FormatID", formatid);
                        cmd.Parameters.AddWithValue("@UserName", username);
                        cmd.Parameters.AddWithValue("@ClientIP", Session["IPAddress"].ToString());
                        cmd.Parameters.AddWithValue("@ClientSubnetID", Session["SubnetID"].ToString());
                        cmd.Parameters.AddWithValue("@UserAgent", Request.ServerVariables["HTTP_USER_AGENT"]);
                        cmd.Parameters.AddWithValue("@IPAddress", Session["StoreIPAddress"].ToString());
                        cmd.Parameters.AddWithValue("@CRTCD", username);
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        int result = cmd.ExecuteNonQuery();
                    }
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        query = "";
                        query = "UPDATE tblMedia SET ViewCount = ViewCount + 1 WHERE MediaID =@MediaID";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@MediaID", ID);
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        int result = cmd.ExecuteNonQuery();
                    }
                    LogInfo.Comments = "Media File Watched - " + FileDtl.Title.ToString();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    FileDtl.ViewCount += 1;

                List<tblDeployStatu> dpsdtllist = new List<tblDeployStatu>();
                List<tblDeployStatu> dpstdtl = new List<tblDeployStatu>();
                tblDeployStatu dpsauto = new tblDeployStatu();
                if (Session["SubnetID"].ToString() != "-1")
                {
 
                    dpsauto = BLL.CommonLogic.GetAutoFormat(Convert.ToInt32(Session["SubnetID"]));
                    dpsdtllist = BLL.CommonLogic.GetAllFormat(Convert.ToInt32(Session["SubnetID"]));
                    string fileName = "";
                    if (dpsauto != null && dpsauto.ToString() != "")
                    {
                        foreach (tblDeployStatu dps in dpsdtllist)
                        {
                            if (dps.FormatID == 0)
                            {
                                fileName = ID + ".mp4";
                            }
                            else
                            {
                                fileName = ID + "-" + dps.FormatID + ".mp4";
                            }
                            if (dpsauto.FormatID == dps.FormatID)
                            {
                                tblDeployStatu dpst = new tblDeployStatu();


                                dpst.FormatID = -1;
                                dpst.FileName = fileName;
                                dpst.IPAddress = Session["VideoIPAddress"].ToString();
                                dpst.Recommend = dps.Recommend;
                                dpstdtl.Add(dpst);
                            }
                        }
                    }
  
                    
                    if(dpstdtl.Count ==0)
                    {
                        foreach (tblDeployStatu dps in dpsdtllist)
                        {
                            if (dps.FormatID == 0)
                            {
                                fileName = ID + ".mp4";
                            }
                            else
                            {
                                fileName = ID + "-" + dps.FormatID + ".mp4";
                            }
                            if (dps.FormatID == Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["VideoDefaultFormat"].ToString()))
                            {
                                tblDeployStatu dpst = new tblDeployStatu();


                                dpst.FormatID = -1;
                                dpst.FileName = fileName;
                                dpst.IPAddress = Session["VideoIPAddress"].ToString();
                                dpst.Recommend = dps.Recommend;
                                dpstdtl.Add(dpst);
                            }
                        }
                       
                    }

                    if (dpsdtllist != null && dpsdtllist.Count > 0)
                    {
                        
                        
                        
                        
                        foreach (tblDeployStatu dps in dpsdtllist)
                        {
                            if (dps.FormatID == 0)
                            {
                                fileName = ID + ".mp4";
                            }
                            else
                            {
                                fileName = ID +"-"+ dps.FormatID + ".mp4";
                            }

                            tblDeployStatu dpst = new tblDeployStatu();
                            dpst.FormatID = dps.FormatID;
                            dpst.IPAddress = Session["VideoIPAddress"].ToString(); 
                            dpst.FileName = fileName;
                            dpst.Recommend = dps.Recommend;
                            dpstdtl.Add(dpst);
                        }

                        foreach (tblDeployStatu dps in dpstdtl)
                        {
                            if (dps.IPAddress == null || dps.IPAddress == "-1")
                            {
                                if (denip == false)
                                {
                                    UpdDeniedIPAddress(ID, "IP2");
                                }
                            }
                            if(dps.FormatID == formatid)
                            {
                                ViewData["PlayVideoFileName"] = dps.FileName;
                                if (dps.Recommend == true)
                                {
                                    ViewData["VideoRecommened"] = "1";
                                }
                                else
                                {
                                    ViewData["VideoRecommened"] = "0";
                                }
                                
                            }
                            
                        }


     
                    }
                }

 
                ViewData["ServerDtl"] = dpstdtl;


                vplayDetail.PlayVideoFileName = ViewData["PlayVideoFileName"].ToString();
                ViewData["FileDetails"] = (tblMedia)FileDtl;
 
                jsonresult = this.Json(vplayDetail);
  
                return View("ViewUploadDetailsNew");
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            
        }

        public ActionResult Delete(int ID)
        {
            string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(CS))
                {
                    string query = "";
                    con.Open();
                    SqlCommand cmd;
  

                    //Assing Query String
                    
                    query = "";

                    tblFeedback tblfeedback = new tblFeedback();
                    tblMedia tblmedia = new tblMedia();

                    query = "select  * from tblfeedback where FeedbackID=@FeedbackID";
                    SqlCommand cmd1 = new SqlCommand(query, con);

                    cmd1.Parameters.AddWithValue("@FeedbackID", ID);


                    SqlDataReader rdr = cmd1.ExecuteReader();
                    while (rdr.Read())
                    {
                        tblfeedback.MovieID = Convert.ToInt32(rdr["MovieID"]);

                    }
                    rdr.Close();
                    query = "";

                    query = "select  * from tblmedia where mediaid=@mediaid";
                    SqlCommand cmd2 = new SqlCommand(query, con);

                    cmd2.Parameters.AddWithValue("@mediaid", tblfeedback.MovieID);

                    SqlDataReader rdr1 = cmd2.ExecuteReader();
                    while (rdr1.Read())
                    {
                        tblmedia.FolderID = Convert.ToInt32(rdr1["FolderID"]);
                        tblmedia.MediaID = Convert.ToInt32(rdr1["MediaID"]);

                    }
                    TempData["MediaID"] = tblmedia.MediaID;
                    TempData["FolderID"] = tblmedia.FolderID;

                    rdr1.Close();
                    query = "delete from  tblfeedback where feedbackid = @FeedbackID";

                    

                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@FeedbackID", ID);

                    cmd.CommandType = CommandType.Text;
                    result = cmd.ExecuteNonQuery();


                }
                if (result == 1)
                {

                    LogInfo.Comments = "Feedback Updated - " + ID.ToString();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.Feedbackdeletedsucessfully;
                    return null;

                }
                else
                {
                    LogInfo.Comments = "Feedback Updated - " + ID.ToString();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    return null;

                }
            }


            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                if (((System.Data.SqlClient.SqlException)ex.InnerException.InnerException).Number == 2627)
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.Unabletodeleteuser;
                }
                else
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.Unabletodeleteuser;
                }

                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }

    
        public ActionResult OriginalVideo(string filename, int MediaID, int FolderID)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            CommonLogic.SetCultureInfo();
            CommonLogic.GetSessionDetails();

            try
            {
 
                string filenameInput = @"\originalmedia\" + filename;
                //return View();
                String strRootDirectory = Server.MapPath("~/");
                string origMediaPath = Server.MapPath("~/") + @"\originalmedia\";
                string destinationFile = strRootDirectory + filenameInput;
                string fileextn = System.IO.Path.GetExtension(filename).Replace(".","");
                if (!System.IO.File.Exists(destinationFile))
                {
                    List<string> ffmt = new List<string>();
                    ffmt = MujiStore.BLL.CommonLogic.GetFileExtn("video");
                    
                    var videoAllFiles = Directory.GetFiles(origMediaPath, MediaID + ".*");
 
                    var videoFiles = from selectfiles in videoAllFiles
                                     where (from filedtl in videoAllFiles
                                            from filextn in ffmt
                                            where filedtl.ToLower().EndsWith(filextn)
                                            select filedtl).Contains(selectfiles)
                                     select selectfiles;

                    if(videoFiles.Count()>0)
                    {
                        destinationFile = videoFiles.First();
                        fileextn = System.IO.Path.GetExtension(destinationFile).Replace(".", "");
                        filename = System.IO.Path.GetFileName(destinationFile);
                    }



     
                }
                if (System.IO.File.Exists(destinationFile))
                {
                    System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                    response.ClearContent();
                    response.Clear();
                    Response.AddHeader("Content-Disposition", string.Format("attachment; filename = \"{0}\"", System.IO.Path.GetFileName(destinationFile)));
                    response.TransmitFile(destinationFile);
                    response.Flush();
                    response.End();

                    return File(destinationFile, "video/"+ fileextn, filename);
 
                }
                else
                {
                    

                    TempData["ErrMsg"] = MujiStore.Resources.Resource.MeidaFileNotFound;
                    return RedirectToAction("ViewUploadDetailsByID", "VideoFiles", new { id = MediaID, folderID = FolderID, formatid = Convert.ToInt32(Session["DefaultFormatID"].ToString()) });

                }
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

        }
        public void BindFormat(int val)
        {
            var lan = System.Threading.Thread.CurrentThread.CurrentCulture;
            ViewBag.Lan = lan.Parent.Name;
            string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            var selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem
            {
                Value = "-1",
                Text = MujiStore.Resources.Resource.Auto
            });


            string query = "Select formatid ";
            query += " from ";
            query += " tblformat where DELFG = 0 ";

            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            if ((Convert.ToString(sdr["formatid"]) == "1"))
                            {

                                selectList.Add(new SelectListItem
                                {
                                    Value = Convert.ToString(sdr["formatid"]),
                                    Text = MujiStore.Resources.Resource.Low,
                                });
                            }

                            if ((Convert.ToString(sdr["formatid"]) == "0"))
                            {
                                selectList.Add(new SelectListItem
                                {
                                    Value = Convert.ToString(sdr["formatid"]),
                                    Text = MujiStore.Resources.Resource.High,
                                });
                            }
                            if ((Convert.ToString(sdr["formatid"]) == "2"))
                            {

                                selectList.Add(new SelectListItem
                                {
                                    Value = Convert.ToString(sdr["formatid"]),
                                    Text = MujiStore.Resources.Resource.Medium,
                                });

                            }
                        }
                    }
                }
            }


            ViewBag.Format = selectList;

        }
    }
}