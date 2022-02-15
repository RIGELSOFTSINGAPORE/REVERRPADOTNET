using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc;
using MujiStore.Models;
using System.Configuration;
using System.Data.SqlClient;
using MujiStore.BLL;
using System.Diagnostics;
using PagedList;
using System.Text;
using System.Threading;
using System.Data;
using System.Net;

namespace MujiStore.Controllers
{
    [SessionExpire]
    [Authorize]
    
    [MUJICustomAuthorize(Roles = "8,9,10,11,12,13,14,15,24,25,27,26,28,29,30,31")]
    public class VideoApprovalController : Controller
    {
        private mujiEntities1 db = new mujiEntities1();
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        DateTime uploadstartdatetime;
        DateTime uploadenddatetime;
        // GET: VideoApprovalnew
        public ActionResult Index(string ID)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int pageSize;
            

            List<SelectListItem> lstConvertStatus = new List<SelectListItem>();

            lstConvertStatus.Add(new SelectListItem { Text = MujiStore.Resources.Resource.All, Value = "4" });
            lstConvertStatus.Add(new SelectListItem { Text = MujiStore.Resources.Resource.Approvalrequest, Value = "0" });//VJ 20200603 ConvertStatus Changed
            lstConvertStatus.Add(new SelectListItem { Text = MujiStore.Resources.Resource.Deleterequest, Value = "1" });
           



            List<tblMedia> VidList = new List<tblMedia>();
            List<SelectListItem> lstFolderName = new List<SelectListItem>();
            List<SelectListItem> lstFolderNameBulk = new List<SelectListItem>();
            List<SelectListItem> lstMediaDtl = new List<SelectListItem>();
            lstFolderName = BLL.CommonLogic.FillFolderList();
            lstFolderNameBulk = BLL.CommonLogic.FillFolderList();
            ViewBag.FolderList = new SelectList(lstFolderNameBulk, "Value", "Text");
            lstFolderName.Insert(0, (new SelectListItem { Text = "All", Value = "0" }));
        
            try
            {
                var lan = Session["CreateSpecificCulture"];
                ViewBag.Language = lan;
               
                List<tblMedia> videoList = new List<tblMedia>();
                
                string uName = Session["UserName"].ToString();
                ViewData["FolderDtl"] = BLL.CommonLogic.FillFolderList();
                string query = " Select ApplicationID,MA.MediaID,MA.Title,MA.Description,Name,NewApprovalStatus,[Delete] IsDelete, ";
                query += " MA.Registerer,MA.Accepter,Memo,RegisteredDate,CompleteDate,Approved,Video,Thumbnail,ma.VideoPlayStartDate,ma.VideoPlayEndDate ";
                query += " from tblApplication MA ";
                query += " left join tblFolder F on F.FolderID = MA.FolderID ";
                query += " LEFT JOIN tblUser AS U ON MA.Registerer = U.ID ";
                query += " Left Join tblMedia  M on M.MediaID = MA.MediaID ";
                query += " where MA.CompleteDate is null order by ma.applicationID desc ";
         
               
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
                                var column = sdr.GetOrdinal("VideoPlayStartDate");

                                if (!sdr.IsDBNull(column))
                                {

                                    uploadstartdatetime = Convert.ToDateTime(sdr["VideoPlayStartDate"]);

                                }
                                var column1 = sdr.GetOrdinal("VideoPlayEndDate");

                                if (!sdr.IsDBNull(column1))
                                {
                                    uploadenddatetime = Convert.ToDateTime(sdr["VideoPlayEndDate"]);

                                }
                                videoList.Add(new tblMedia
                                {
                             
                                    ApplicationID = Convert.ToInt32(sdr["ApplicationID"]),
                                    MediaID = Convert.ToInt32(sdr["MediaID"]),
                                    Title = Convert.ToString(sdr["Title"]),
                                    Description = Convert.ToString(sdr["Description"]),
                                    FolderName = Convert.ToString(sdr["Name"]),
                                    ApprovalStatus = Convert.ToInt32(sdr["NewApprovalStatus"]),
                                    PhysicalDELFG = Convert.ToBoolean(sdr["IsDelete"]),
                                    Registerer = Convert.ToString(sdr["Registerer"]),
                                    CRTDT = Convert.ToDateTime(sdr["RegisteredDate"]),
                                    STRCRTDT = Convert.ToDateTime(sdr["RegisteredDate"]).ToString("yyyy/MM/dd"),// .ToString("yyyy/MM/dd HH:mm:ss tt");
                                    STRCRTDTTIME = Convert.ToDateTime(sdr["RegisteredDate"]).ToString("HH:mm:ss"),
                                    Video = Convert.ToString(sdr["Video"]),
                                    Thumbnail = Convert.ToString(sdr["Thumbnail"]),
                                    Delete = Convert.ToBoolean(sdr["ISdelete"]),
                                   sstreamingconstartdatetime = Convert.ToDateTime(uploadstartdatetime).ToString("yyyy/MM/dd HH:mm:ss"),
                                   sstreamingconenddatetime = Convert.ToDateTime(uploadenddatetime).ToString("yyyy/MM/dd HH:mm:ss"),


                            });
                            }
                        }
                        con.Close();
                    }
                }


             
                ViewData["videoList"] = videoList;

                if(ID != "")
                {
                    TempData["Video"] = ID;
                }
                return View(VidList);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }
        
        public ActionResult Approve(int? ID,int ? NewApprovalStatus)
        {

                LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
                LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
                tblMedia med = new tblMedia();
                string query = "";
                int result;
                try
                {
                
                using (SqlConnection con = new SqlConnection(CS))
                    {
                        con.Open();
                        SqlCommand cmd;
                        tblMedia tblVideoDemo = new tblMedia();
                        med = GetApplicationDetails(ID);
                        if (NewApprovalStatus == 1)
                        {

                            if (med.PhysicalDELFG == false)
                            {
                                query = "Update tblMedia set Title=@Title,Description=@Description,";
                                query += "Accepter=@Accepter,FolderID=@FolderID,ApprovalStatus=@ApprovalStatus,";
                                query += "IpAddress=@IpAddress,UPDDT=@UPDDT,UPDCD=@UPDCD,VideoPlayStartDate=@VideoPlayStartDate,VideoPlayEndDate=@VideoPlayEndDate";
                                query += " Where MediaID=@MediaID";

                                cmd = new SqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@Title", med.Title);
                                cmd.Parameters.AddWithValue("@Description", med.Description);
                                cmd.Parameters.AddWithValue("@FolderID", med.FolderID);
                                cmd.Parameters.AddWithValue("@Accepter", Session["UserName"].ToString());
                                cmd.Parameters.AddWithValue("@ApprovalStatus", med.ApprovalStatus);
                                cmd.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                                cmd.Parameters.AddWithValue("@UPDDT", DateTime.Now);
                                cmd.Parameters.AddWithValue("@IpAddress", Session["IPAddress"].ToString());
                                cmd.Parameters.AddWithValue("@MediaID", med.MediaID);
                                uploadstartdatetime = Convert.ToDateTime(med.sstreamingconstartdatetime);
                                uploadenddatetime = Convert.ToDateTime(med.sstreamingconenddatetime);
                                cmd.Parameters.AddWithValue("@VideoPlayStartDate", uploadstartdatetime);
                                if (uploadenddatetime == DateTime.MinValue)
                                {
                                    cmd.Parameters.AddWithValue("@VideoPlayEndDate", DBNull.Value);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@VideoPlayEndDate", uploadenddatetime);
                                }
                                cmd.CommandType = CommandType.Text;
                                result = cmd.ExecuteNonQuery();

                                cmd.Parameters.Clear();
                                query = "";
                                query += "Update tblApplication set Accepter = @Accepter,CompleteDate = GETDATE(),";
                                query += "Approved =1,IpAddress=@IpAddress,UPDDT=@UPDDT,UPDCD=@UPDCD ";
                                query += " Where ApplicationID=@ApplicationID";

                                cmd = new SqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@Accepter", Session["UserName"].ToString());
                                cmd.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                                cmd.Parameters.AddWithValue("@UPDDT", DateTime.Now);
                                cmd.Parameters.AddWithValue("@IpAddress", Session["IPAddress"].ToString());
                                cmd.Parameters.AddWithValue("@ApplicationID", med.ApplicationID);
                                cmd.CommandType = CommandType.Text;
                                result = cmd.ExecuteNonQuery();

                                cmd.Parameters.Clear();

                                query = "";
                                query = " Update tblMediaFormatInfo set ";
                                query += " DELFG=@DELFG,IpAddress=@IpAddress,UPDDT=@UPDDT,UPDCD=@UPDCD ";
                                query += " Where MediaID=@MediaID";
                                cmd = new SqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@DELFG", 0);
                                cmd.Parameters.AddWithValue("@UPDDT", DateTime.Now);
                                cmd.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                                cmd.Parameters.AddWithValue("@IpAddress", Session["IPAddress"].ToString());
                                cmd.Parameters.AddWithValue("@MediaID", med.MediaID);
                                cmd.CommandType = CommandType.Text;
                                result = cmd.ExecuteNonQuery();

                                cmd.Parameters.Clear();
                     
                            }
                            else
                            {

                            

                            query = "";
                            query += " Update tblMedia set ";
                            query += " UPDDT=@UPDDT,UPDCD=@UPDCD,IpAddress=@IpAddress ";
                            query += " Where MediaID=@MediaID";

                            cmd = new SqlCommand(query, con);
       
                                cmd.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                                cmd.Parameters.AddWithValue("@UPDDT", DateTime.Now);
                                cmd.Parameters.AddWithValue("@IpAddress", Session["IPAddress"].ToString());
                                cmd.Parameters.AddWithValue("@MediaID", med.MediaID);
                                cmd.CommandType = CommandType.Text;
                                result = cmd.ExecuteNonQuery();

                                cmd.Parameters.Clear();

                                query = "";
                                query = " Update tblMediaFormatInfo set ";
                                query += " DELFG=@DELFG,IpAddress=@IpAddress,UPDDT=@UPDDT,UPDCD=@UPDCD ";
                                query += " Where MediaID=@MediaID";
                                cmd = new SqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@DELFG", med.PhysicalDELFG);
                                cmd.Parameters.AddWithValue("@UPDDT", DateTime.Now);
                                cmd.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                                cmd.Parameters.AddWithValue("@IpAddress", Session["IPAddress"].ToString());
                                cmd.Parameters.AddWithValue("@MediaID", med.MediaID);
                                cmd.CommandType = CommandType.Text;
                                result = cmd.ExecuteNonQuery();

                                cmd.Parameters.Clear();

                                query = "";
                                query += "Update tblApplication set Accepter = @Accepter,CompleteDate = GETDATE(),";
                                query += "Approved =1,IpAddress=@IpAddress,UPDDT=@UPDDT,UPDCD=@UPDCD ";
                                query += " Where ApplicationID=@ApplicationID";

                                cmd = new SqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@Accepter", Session["UserName"].ToString());
                                cmd.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                                cmd.Parameters.AddWithValue("@UPDDT", DateTime.Now);
                                cmd.Parameters.AddWithValue("@IpAddress", Session["IPAddress"].ToString());
                                cmd.Parameters.AddWithValue("@ApplicationID", med.ApplicationID);
                                cmd.CommandType = CommandType.Text;
                                result = cmd.ExecuteNonQuery();

                                cmd.Parameters.Clear();
                 
                            }
                        TempData["deletesucmsg"] = MujiStore.Resources.Resource.CntVideoDemoSaveThumbnailImageSuccMsg2;
                        }
                        else
                        {
                            query = "";
                            query += "Update tblApplication set Accepter = @Accepter,CompleteDate = GETDATE(),";
                            query += "Approved =0,IpAddress=@IpAddress,UPDDT=@UPDDT,UPDCD=@UPDCD ";
                            query += " Where ApplicationID=@ApplicationID";

                            cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@Accepter", Session["UserName"].ToString());
                            cmd.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                            cmd.Parameters.AddWithValue("@UPDDT", DateTime.Now);
                            cmd.Parameters.AddWithValue("@IpAddress", Session["IPAddress"].ToString());
                            cmd.Parameters.AddWithValue("@ApplicationID", med.ApplicationID);
                            cmd.CommandType = CommandType.Text;
                            result = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();

                          

                            cmd.Parameters.Clear();

                            
                            TempData["deletesucmsg"] = MujiStore.Resources.Resource.CntVideoDemoSaveThumbnailImageSuccMsg1;
                        }


                    }
                    LogInfo.Comments = "Video Approval Updated - " + med.ApplicationID.ToString();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    
                    return RedirectToAction("result");

                  
                }
                catch (Exception ex)
                {
                    LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                    Log.Error(LogInfo.LogMsg, ex);
                    return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
                }

            
        }
        public ActionResult result()
        {
            var lan = Session["CreateSpecificCulture"];
            ViewBag.Language = lan;

            return View();
        }
        public ActionResult resultapprove()
        {
            var lan = Session["CreateSpecificCulture"];
            ViewBag.Language = lan;

            return View();
        }
        public ActionResult video()
        {

            TempData["Videoplay"] = TempData["Video"];
            return View();
        }
        public tblMedia GetApplicationDetails(int? id)
        {
            tblMedia tblApp = new tblMedia();

            string query = " Select ApplicationID,MA.MediaID,MA.Title,MA.Description,Name,NewApprovalStatus,[Delete] IsDelete, ";
            query += " MA.Registerer,MA.Accepter,Memo,RegisteredDate,CompleteDate,Approved,Video,Thumbnail,Memo,MA.FolderID,ma.VideoPlayStartDate,ma.VideoPlayEndDate ";
            query += " from tblApplication MA ";
            query += " left join tblFolder F on F.FolderID = MA.FolderID ";
            query += " LEFT JOIN tblUser AS U ON MA.Registerer = U.ID ";
            query += " Left Join tblMedia  M on M.MediaID = MA.MediaID ";
            query += " where MA.CompleteDate is null  ";
            query += " and MA.ApplicationID =" + id;

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
                            var column = sdr.GetOrdinal("VideoPlayStartDate");

                            if (!sdr.IsDBNull(column))
                            {

                                uploadstartdatetime = Convert.ToDateTime(sdr["VideoPlayStartDate"]);

                            }
                            var column1 = sdr.GetOrdinal("VideoPlayEndDate");

                            if (!sdr.IsDBNull(column1))
                            {
                                uploadenddatetime = Convert.ToDateTime(sdr["VideoPlayEndDate"]);

                            }
 
                            tblApp.ApplicationID = Convert.ToInt32(sdr["ApplicationID"]);
                            tblApp.MediaID = Convert.ToInt32(sdr["MediaID"]);
                            tblApp.Title = Convert.ToString(sdr["Title"]);
                            tblApp.Description = Convert.ToString(sdr["Description"]);
                            tblApp.FolderName = Convert.ToString(sdr["Name"]);
                            tblApp.FolderID = Convert.ToInt32(sdr["FolderID"]);
                            tblApp.ApprovalStatus = Convert.ToInt32(sdr["NewApprovalStatus"]);
                            tblApp.PhysicalDELFG = Convert.ToBoolean(sdr["IsDelete"]);
                            tblApp.Comments = Convert.ToString(sdr["Memo"]);
                            tblApp.Registerer = Convert.ToString(sdr["Registerer"]);
                            tblApp.CRTDT = Convert.ToDateTime(sdr["RegisteredDate"]);
                            tblApp.Video = Convert.ToString(sdr["Video"]);
                            tblApp.Thumbnail = Convert.ToString(sdr["Thumbnail"]);
                            tblApp.STRCRTDT = Convert.ToDateTime(sdr["RegisteredDate"]).ToString("yyyy/MM/dd HH:mm:ss");
                            tblApp.sstreamingconstartdatetime = Convert.ToDateTime(uploadstartdatetime).ToString("yyyy/MM/dd HH:mm:ss");
                            tblApp.sstreamingconenddatetime = Convert.ToDateTime(uploadenddatetime).ToString("yyyy/MM/dd HH:mm:ss");

                        }
                    }
                    con.Close();
                }
            }
            return tblApp;
        }
    }
}