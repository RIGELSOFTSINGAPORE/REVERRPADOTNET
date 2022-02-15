using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MujiStore.Models;
using System.Configuration;
using System.Data.SqlClient;
using MujiStore.BLL;
using System.Diagnostics;
using PagedList;
using System.Text;
using System.Threading;
using System.Globalization;

namespace MujiStore.Controllers
{
    [SessionExpire]
    [Authorize]
    // [Authorize(Roles = "A,U")]
    [MUJICustomAuthorize(Roles = "8,9,10,11,12,13,14,15,24,25,27,26,28,29,30,31")]
    public class AppDisVideoListController : Controller
    {
        // GET: AppDisVideoList
        private mujiEntities1 db = new mujiEntities1();
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        int ApprovalStatus;
        DateTime UPDDT;
        string UPDCD;
        public ActionResult Index(string sortOrder, int? page, string SearTitle, string SearchTitle, string SearchFromCRTDT, string CdStDate, string SearchToCRTDT, string CdEdDate, int? ConvertStatus, int? CvtStatus, int? DelFlag, int? DFlag, int? FolderID, int? FolID, int? MediaID, int? MedID, string status)
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

            lstConvertStatus.Add(new SelectListItem { Text = "All", Value = "4" });
            lstConvertStatus.Add(new SelectListItem { Text = "Approved", Value = "1" });//VJ 20200603 ConvertStatus Changed
            lstConvertStatus.Add(new SelectListItem { Text = "Disapproved", Value = "0" });
            lstConvertStatus.Add(new SelectListItem { Text = "Pending", Value = "3" });
            ViewBag.ConvertStatus = new SelectList(lstConvertStatus, "Value", "Text", CvtStatus);



            List<tblMedia> VidList = new List<tblMedia>();
            List<SelectListItem> lstFolderName = new List<SelectListItem>();
            List<SelectListItem> lstFolderNameBulk = new List<SelectListItem>();
            List<SelectListItem> lstMediaDtl = new List<SelectListItem>();
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

                FillApprovalStatus();


                //var videoList="";
                List<tblMedia> videoList = new List<tblMedia>();
                //var videoList;
                string uName = Session["UserName"].ToString();
               
                string query = " Select ApplicationID,MA.MediaID,MA.Title,MA.Description,[Delete] IsDelete, ";
                query += " MA.Registerer,MA.Accepter,Memo,RegisteredDate,CompleteDate,Approved,Video,Thumbnail,ma.UPDDT,ma.UPDCD ";
                query += " from tblApplication MA ";
               
                query += " Left Join tblMedia  M on M.MediaID = MA.MediaID ";
                query += " where ";
                query += " FORMAT(MA.registereddate, 'yyyy-MM-dd') between '" + CdStDate + "' and '" + CdEdDate + "'";
                

                if (ViewBag.MedID != null && ViewBag.MedID != 0)
                {
                    query = query + " and M.MediaID = " + ViewBag.MedID;
                }

                if (ViewBag.SearTitle != null && ViewBag.SearTitle != "" && ViewBag.SearTitle != string.Empty)
                {
                    query = query + " and MA.title like '%" + ViewBag.SearTitle + "%'";
                }

                if (ViewBag.cvtStatus != null && ViewBag.cvtStatus != 4 && ViewBag.cvtStatus != 3)
                {
                    query = query + " and MA.Approved = " + ViewBag.cvtStatus;
                }
                if (ViewBag.cvtStatus == 3)
                {
                    query = query + " and MA.Approved is null";
                }
                query = query + " Order by MediaID Desc, ApplicationID desc";
               
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
                                var column = sdr.GetOrdinal("Approved");
                                
                                if (!sdr.IsDBNull(column))
                                {
                                     ApprovalStatus = Convert.ToInt32(sdr["Approved"]);
  
                                }
                                else
                                {
                                    ApprovalStatus = 3;
                                }
                                
                                

                                videoList.Add(new tblMedia
                                {
                                    
                                    ApplicationID = Convert.ToInt32(sdr["ApplicationID"]),
                                    MediaID = Convert.ToInt32(sdr["MediaID"]),
                                    Title = Convert.ToString(sdr["Title"]),
                                    Description = Convert.ToString(sdr["Description"]),

                                     
                                    ApprovalStatus = ApprovalStatus,
  
                                   
                                    UPDDT = Convert.ToDateTime(sdr["RegisteredDate"]),
                                    UPDCD = Convert.ToString(sdr["UPDCD"]),
                                    Video = Convert.ToString(sdr["Video"]),
                                   

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
                        videoList = videoList.OrderByDescending(o => o.ApprovalStatus).ToList();
                        break;
                    case "ConvertStatus":
                        videoList = videoList.OrderBy(o => o.ApprovalStatus).ToList();
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
        public void FillApprovalStatus()
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "Un Approved", Value = "0" });
            list.Add(new SelectListItem { Text = "Approved", Value = "3" });
            ViewData["ApprovalDtl"] = list;
        }
        public List<SelectListItem> BindMediaDetails()
        {

            List<SelectListItem> items = new SelectList(db.tblMedias, "MediaID", "MediaID").ToList();


            var selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem
            {
                Value = "0",
                Text = "Select"
            });
            foreach (var element in items)
            {

                selectList.Add(new SelectListItem
                {
                    Value = element.Value,
                    Text = element.Text
                });


            }

            return selectList;



        }
    }
   
}
