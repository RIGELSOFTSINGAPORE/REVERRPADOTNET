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
    public class MediaApprovalController : BaseController
    {
        private mujiEntities1 db = new mujiEntities1();
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        DateTime uploadstartdatetime;
        DateTime uploadenddatetime;
        // GET: MediaApproval
        public ActionResult Index(string sortOrder, int? page, string SearTitle, string SearchTitle, string SearchFromCRTDT, string CdStDate, string SearchToCRTDT, string CdEdDate, int? ConvertStatus, int? CvtStatus, int? DelFlag, int? DFlag, int? FolderID, int? FolID,int? MediaID, int? MedID,string status,int?page1 )
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int pageSize;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ApplicationIDSortParm = sortOrder == "ApplicationID" ? "ApplicationID_desc" : "ApplicationID";
            ViewBag.MediaIDSortParm = sortOrder == "MediaID" ? "MediaID_desc" : "MediaID";
            ViewBag.TitleSortParm = sortOrder == "Title" ? "Title_desc" : "Title";
            ViewBag.ConvertStatusSortParm = sortOrder == "ConvertStatus" ? "ConvertStatus_desc" : "ConvertStatus";
            ViewBag.FolderSortParm = sortOrder == "Folder" ? "Folder_desc" : "Folder";

            List<SelectListItem> lstConvertStatus = new List<SelectListItem>();

            lstConvertStatus.Add(new SelectListItem { Text = MujiStore.Resources.Resource.All, Value = "4" });
            lstConvertStatus.Add(new SelectListItem { Text = MujiStore.Resources.Resource.Approvalrequest, Value = "0" });//VJ 20200603 ConvertStatus Changed
            lstConvertStatus.Add(new SelectListItem { Text = MujiStore.Resources.Resource.Deleterequest, Value = "1" });
            ViewBag.ConvertStatus = new SelectList(lstConvertStatus, "Value", "Text", CvtStatus);



            List<tblMedia> VidList = new List<tblMedia>();
            List<SelectListItem> lstFolderName = new List<SelectListItem>();
            List<SelectListItem> lstFolderNameBulk = new List<SelectListItem>();
            List<SelectListItem> lstMediaDtl = new List<SelectListItem>();
            lstFolderName =BLL.CommonLogic.FillFolderList();
            lstFolderNameBulk = BLL.CommonLogic.FillFolderList();
            ViewBag.FolderList = new SelectList(lstFolderNameBulk, "Value", "Text");
            lstFolderName.Insert(0, (new SelectListItem { Text = "All", Value = "0" }));
            ViewBag.FolderID = new SelectList(lstFolderName, "Value", "Text", FolID);
            lstMediaDtl = BindMediaDetails();
            ViewBag.MediaID = new SelectList(lstMediaDtl, "Value", "Text", MedID);

            if (SearchTitle != null || SearchFromCRTDT != null || SearchToCRTDT != null || ConvertStatus != null || DelFlag != null)
            {
                page = 1;
            }
            else
            {
                SearchTitle = SearTitle;
                SearchFromCRTDT = CdStDate;
                SearchToCRTDT = CdEdDate;
                ConvertStatus = CvtStatus;
                MediaID = MedID;
                FolderID = FolID;
            }
            ViewBag.SearTitle = SearchTitle;
            ViewBag.CdStDate = SearchFromCRTDT;
            ViewBag.CdEdDate = SearchToCRTDT;
            ViewBag.cvtStatus = ConvertStatus;
            ViewBag.MedID = MediaID;
            ViewBag.FolID = FolderID;
            if (ViewBag.CdStDate == null || ViewBag.CdStDate == "")
            {
                CdStDate = DateTime.Now.AddYears(-200).ToString("yyyy/MM/dd");
            }
            else
            {
                CdStDate = ViewBag.CdStDate;
            }
            if (ViewBag.CdEdDate == null || ViewBag.CdEdDate == "")
            {
                CdEdDate = DateTime.Now.AddYears(100).ToString("yyyy/MM/dd");
            }
            else
            {
                CdEdDate = ViewBag.CdEdDate;
            }
            //New
            try
            {
                //Datepicker changed by sabeena 
                DateTime fromDateValue;
                var formats = new[] { "dd/MM/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" };
                if (!DateTime.TryParseExact(CdStDate.Trim(), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue) || !(DateTime.TryParseExact(CdEdDate.Trim(), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue)))
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.datevalidation;
                }


                FillApprovalStatus();
       
               
                //var videoList="";
                List<tblMedia> videoList = new List<tblMedia>();
                //var videoList;
                string uName = Session["UserName"].ToString();
                ViewData["FolderDtl"] = BLL.CommonLogic.FillFolderList();
                string query = " Select ApplicationID,MA.MediaID,MA.Title,MA.Description, ";
                query += " Name,NewApprovalStatus,[Delete] IsDelete, ";
                query += " MA.Registerer,MA.Accepter,Memo,RegisteredDate,CompleteDate,Approved,convert(varchar,MA.MediaID)+'.mp4' Video,Thumbnail ";
                query += " from tblApplication MA ";
                query += " left join (";
                if (Session["CreateSpecificCulture"].ToString() == "en")
                {
                    query += " select -1 FolderID,-2 ParentID,N' (Root folder) ' Name ";
                }
                else
                {
                    query += " select -1 FolderID,-2 ParentID,N'（ルートフォルダ）' Name ";
                }
                query += " union all ";
                query += " select FolderID,ParentID,Name from [tblFolder] where DELFG = 0 ";
                query += " ) F on F.FolderID = MA.FolderID ";
                query += " LEFT JOIN tblUser AS U ON MA.Registerer = U.ID ";
                query += " Left Join tblMedia  M on M.MediaID = MA.MediaID ";
                query += " where MA.CompleteDate is null  ";
                //Datepicker changed by sabeena 
                query += " and FORMAT(MA.RegisteredDate, 'yyyy/MM/dd') between '" + CdStDate + "' and '" + CdEdDate + "'";

                
                if(ViewBag.MedID != null && ViewBag.MedID != 0)
                {
                    query = query + " and M.MediaID = " + ViewBag.MedID;
                }

                if (ViewBag.SearTitle != null && ViewBag.SearTitle != "" && ViewBag.SearTitle != string.Empty)
                {
                    query = query + " and MA.title like @title";
                }

                if (ViewBag.cvtStatus != null && ViewBag.cvtStatus != 4)
                {
                    query = query + " and MA.[Delete] = " + ViewBag.cvtStatus;
                }
                if (ViewBag.FolID != null && ViewBag.FolID != 0)
                {
                    query = query + " and MA.FolderID = " + Convert.ToInt32(ViewBag.FolID);
                }


                using (SqlConnection con = new SqlConnection(CS))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@title", "%" + ViewBag.SearTitle+"%" );
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
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
                                    Delete= Convert.ToBoolean(sdr["ISdelete"]),

                                });
                            }
                        }
                        con.Close();
                    }
                }


                switch (sortOrder)
                {

                    case "ApplicationID":
                        videoList = videoList.OrderBy(o => o.ApplicationID).ToList();
                        break;
                    case "MediaID":
                        videoList = videoList.OrderBy(o => o.MediaID).ToList();
                        break;
                    case "MediaID_desc":
                        videoList = videoList.OrderByDescending(o => o.MediaID).ToList();
                        break;
                    case "Title":
                        videoList = videoList.OrderBy(o => o.Title).ToList();
                        break;
                    case "Title_desc":
                        videoList = videoList.OrderByDescending(o => o.Title).ToList();
                        break;
                    case "ConvertStatus_desc":
                        videoList = videoList.OrderByDescending(o => o.Delete).ToList();
                        break;
                    case "ConvertStatus":
                        videoList = videoList.OrderBy(o => o.Delete).ToList();
                        break;
                    case "Folder_desc":
                        videoList = videoList.OrderByDescending(o => o.FolderName).ToList();
                        break;
                    case "Folder":
                        videoList = videoList.OrderBy(o => o.FolderName).ToList();
                        break;
                    default:  // Name ascending 
                        videoList = videoList.OrderByDescending(o => o.ApplicationID).ToList();
                        break;
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
                if (page1 != null)
                {
                    status = "sucess";
                    pageNumber = Convert.ToInt16(page1);
                }

                ViewData["videoList"] = videoList.ToPagedList(pageNumber, pageSize);

                if (status != null)
                {
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.deletedsucessfully;
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

        public tblMedia GetApplicationDetails(int? id)
        {
            tblMedia tblApp = new tblMedia();

            string query = " Select ApplicationID,MA.MediaID,MA.Title,MA.Description,Name,NewApprovalStatus,[Delete] IsDelete, ";
            query += " U.UserName Registerer,MA.Accepter,Memo,RegisteredDate,CompleteDate,Approved,convert(varchar,MA.MediaID)+'-1.mp4' Video,Thumbnail,Memo,MA.FolderID,ma.VideoPlayStartDate,ma.VideoPlayEndDate ";
            query += " from tblApplication MA ";
            query += " left join (";
            if (Session["CreateSpecificCulture"].ToString() == "en")
            {
                query += " select -1 FolderID,-2 ParentID,N' (Root folder) ' Name ";
            }
            else
            {
                query += " select -1 FolderID,-2 ParentID,N'（ルートフォルダ）' Name ";
            }
            query += " union all ";
            query += " select FolderID,ParentID,Name from [tblFolder] where DELFG = 0 ";
            query += " ) F on F.FolderID = MA.FolderID ";
            query += " LEFT JOIN tblUser AS U ON MA.Registerer = U.ID ";
            query += " Left Join tblMedia  M on M.MediaID = MA.MediaID ";
            query += " where MA.DelFG = 0  and MA.CompleteDate is null  ";
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
        public ActionResult Edit(int? id, int? page)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            tblMedia tblApp = new tblMedia();
            try
            {
                string uName = Session["UserName"].ToString();


                

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }


                tblApp = GetApplicationDetails(id);



                if (tblApp.ApplicationID == 0)
                {
                    return HttpNotFound();
                }


                int pageNumber = (page ?? 1);
                tblApp.page = pageNumber;
                TempData["Page"] = page;
                ViewBag.Page = page;
                return View(tblApp);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApplicationID,MediaID,NewApprovalStatus")] tblMedia tblVideoDemo)
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
                    med = GetApplicationDetails(tblVideoDemo.ApplicationID);
                    if (tblVideoDemo.NewApprovalStatus == 1)
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
                            uploadenddatetime= Convert.ToDateTime(med.sstreamingconenddatetime);
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
                            query += " Update tblMedia set DELFG=@PhysicalDELFG, ";
                            query += " UPDDT=@UPDDT,UPDCD=@UPDCD,IpAddress=@IpAddress ";
                            query += " Where MediaID=@MediaID";

                            cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@PhysicalDELFG", med.PhysicalDELFG);
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
                        TempData["SuccMsg"] = MujiStore.Resources.Resource.CntVideoDemoSaveThumbnailImageSuccMsg2;
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


                        TempData["SuccMsg"] = MujiStore.Resources.Resource.CntVideoDemoSaveThumbnailImageSuccMsg1;
                    }
                    
                    
                }
                LogInfo.Comments = "Video Approval Updated - " + med.ApplicationID.ToString();
                CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
 
                return RedirectToAction("Index", new { page = TempData["Page"] });

 
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

        }

        public void FillApprovalStatus()
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "Un Approved", Value = "0" });
            list.Add(new SelectListItem { Text = "Approved", Value = "3" });
            ViewData["ApprovalDtl"] = list;
        }

        public List<SelectListItem> BindMediaDetails()
        {

             

            var selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem
            {
                Value = "0",
                Text = "Select"
            });

            using (SqlConnection con = new SqlConnection(CS))
            {
                string query = "";
                query = "Select distinct MA.MediaID from tblApplication MA   ";
                query += "Left Join tblMedia  M on M.MediaID = MA.MediaID   ";
                query += "where MA.DelFG = 0  and MA.CompleteDate is null  ";
                query += "Order by MediaID Desc  ";
                SqlCommand cmds = new SqlCommand(query, con);
                cmds.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdrs = cmds.ExecuteReader();
                while (rdrs.Read())
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = rdrs["MediaID"].ToString(),
                        Text = rdrs["MediaID"].ToString()
                    });
                }
            }




            return selectList;
           


        }
 

        [HttpPost]
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
                    tblUser tblUser = new tblUser();

                    //Assing Query String
                    query = "delete from tblapplication " +
                    "  where applicationID=@UserID; ";



                    //Intialize Command and pass the paramters


                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@UserID", ID);


                    cmd.CommandType = CommandType.Text;
                    result = cmd.ExecuteNonQuery();


                }
                if (result == 1)
                {

                    LogInfo.Comments = " Updated - " + ID.ToString();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.UserDeletedSuccessfully;
                    return RedirectToAction("Index");

                }
                else
                {
                    LogInfo.Comments = " Updated - " + ID.ToString();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.Unabletodeleteuser;
                    return RedirectToAction("Index");

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
    }
}