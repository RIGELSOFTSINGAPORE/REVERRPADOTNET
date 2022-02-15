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
    public class VideoErrorLogController : Controller
    {
        // GET: VideoErrorLog
        private mujiEntities1 db = new mujiEntities1();
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        string status;
        string query1;
        string query2;
        string query3;
        string cvtStatus;
        public ActionResult Index(string sortOrder, int? page,  int? ConvertStatus, int? CvtStatus,  int? MediaID, int? MedID)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int pageSize;
            ViewBag.CurrentSort = sortOrder;
            
            ViewBag.MediaIDSortParm = sortOrder == "MediaID" ? "ID_desc" : "MediaID";
           
            
            List<SelectListItem> lstConvertStatus = new List<SelectListItem>();

            lstConvertStatus.Add(new SelectListItem { Text = "All", Value = "3" });
            lstConvertStatus.Add(new SelectListItem { Text = "Processed", Value = "2" });
            lstConvertStatus.Add(new SelectListItem { Text = "Processing", Value = "1" });
            lstConvertStatus.Add(new SelectListItem { Text = "Not Processed", Value = "0" });
            lstConvertStatus.Add(new SelectListItem { Text = "Upload Completed", Value = "5" });
            ViewBag.ConvertStatus = new SelectList(lstConvertStatus, "Value", "Text", CvtStatus);



            List<tblMedia> VidList = new List<tblMedia>();
            List<tblMedia> VidList1 = new List<tblMedia>();
            

            if ( ConvertStatus != null )
            {
                page = 1;
            }
            else
            {

                ConvertStatus = CvtStatus;

            }
           
            ViewBag.cvtStatus = ConvertStatus;
            ViewBag.MedID = MediaID;
            
           
            try
            {

                
                List<tblMedia> videoList = new List<tblMedia>();
                
                string uName = Session["UserName"].ToString();
               

                List<string> ffmt = new List<string>();
                ffmt = MujiStore.BLL.CommonLogic.GetFileExtn("video");
                var videoAllFiles = Directory.EnumerateFiles(Server.MapPath("~/ffmpeg/tmp"));
                
                var videoConvertedFilesSelect = from selectfiles in videoAllFiles
                                                
                                                select selectfiles;


                foreach (string outputResultFile in videoConvertedFilesSelect)
                {
                    string[] extensions = { ".bat", ".txt" };

                    var path = Server.MapPath("~/ffmpeg/tmp");
                    
                    var files = from file in Directory.EnumerateFiles(path, "*.*",
                                SearchOption.AllDirectories).Where(s => extensions.Any(ext => ext == Path.GetExtension(s)))
                                where Path.GetFileName(file).ToLower().Contains(Path.GetFileNameWithoutExtension(outputResultFile))
                                select file;

                    String strRootDirectory = Server.MapPath("~/");

                   
                    

                    if (files.Count() == 3)
                    {
                        status = "Processing";
                    }
                   else if(files.Count() == 2)
                    {
                        System.IO.FileInfo fi = new System.IO.FileInfo(strRootDirectory + @"ffmpeg\tmp\" + Path.GetFileNameWithoutExtension(outputResultFile) + ".txt");

                        if (fi.Exists)
                        {
                            status = "Processing";
                        }
                        else
                        {
                            status = "Not Processed";
                        }

                    }
                    else if (files.Count() == 1)
                    {
                        System.IO.FileInfo fi = new System.IO.FileInfo(strRootDirectory + @"ffmpeg\tmp\" + Path.GetFileNameWithoutExtension(outputResultFile) + ".txt");
                        if (fi.Exists)
                        {
                            status = "Processed";
                        }
                        else if(!(fi.Exists))
                        {
                            status = "Not Processed";
                        }
                    }
                    else
                    {
                        System.IO.FileInfo fi = new System.IO.FileInfo(strRootDirectory + @"ffmpeg\tmp\" + Path.GetFileNameWithoutExtension(outputResultFile) + ".txt");
                        System.IO.FileInfo fi1 = new System.IO.FileInfo(strRootDirectory + @"ffmpeg\tmp\" + Path.GetFileNameWithoutExtension(outputResultFile) + ".bat");
                        if (fi.Exists && (fi1.Exists))
                        {
                            status = "Processing";
                        }
                        else if (!(fi.Exists) && (fi1.Exists))
                        {
                            status = "Not Processed";
                        }
                        else if(fi.Exists)
                        {
                            status = "Processed";
                        }
                    }
                    

                    query1 = " with cte as  ";
                    query1 += " (Select [MediaID],video,[CRTDT] ";
                    query1 += " , ' " + status + " ' AS STATUS";
                    query1 += " from tblMedia  ";
                    query1 += " where video like  '%" + Path.GetFileNameWithoutExtension(outputResultFile) + "%'  )";
                    query1 += " select * from cte  ";

                    if (ViewBag.cvtStatus != null && ViewBag.cvtStatus != 4 && ViewBag.cvtStatus != 3)
                    {
                        if (ViewBag.cvtStatus == 2)
                        {
                            cvtStatus = "Processed";
                        }
                        else if (ViewBag.cvtStatus == 1)
                        {

                            cvtStatus = "Processing";
                        }
                        else if (ViewBag.cvtStatus == 0)
                        {
                            cvtStatus = "Not Processed";

                        }


                        query1 = query1 + " where  STATUS = ' " + cvtStatus + "' ";
                    }

                    query2 = "SELECT NEXT VALUE FOR item_counter [counter] ";
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        using (SqlCommand cmd = new SqlCommand(query1))
                        {
                            cmd.Connection = con;
                            con.Open();
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    
                                    videoList.Add(new tblMedia
                                    {
                                        
                                        MediaID = Convert.ToInt32(sdr["MediaID"]),
                                        Title = Convert.ToString(sdr["video"]),
                                         Description = status,

                                        STRCRTDT = Convert.ToString(sdr["CRTDT"]),
                                       

                                });
                                }

                               

                                if (sdr.HasRows == false)
                                {
                                    using (SqlCommand cmd1 = new SqlCommand(query2))
                                    {
                                        con.Close();
                                        cmd1.Connection = con;
                                        con.Open();
                                        using (SqlDataReader sdr1 = cmd1.ExecuteReader())
                                        {
                                            while (sdr1.Read())
                                            {
                                                videoList.Add(new tblMedia
                                                {

                                                    MediaID = Convert.ToInt32(sdr1["counter"]),
                                                    Title = Path.GetFileNameWithoutExtension(outputResultFile) + ".mp4",
                                                    Description = status,

                                                    //CRTDT = new FileInfo(Path.GetFileNameWithoutExtension(outputResultFile)).CreationTime.Date,
                                                    STRCRTDT= Path.GetFileNameWithoutExtension(outputResultFile).Substring(0,4)+"/" + Path.GetFileNameWithoutExtension(outputResultFile).Substring(4, 2) + "/" + Path.GetFileNameWithoutExtension(outputResultFile).Substring(6, 2) + " " + Path.GetFileNameWithoutExtension(outputResultFile).Substring(8, 2) + " :" + Path.GetFileNameWithoutExtension(outputResultFile).Substring(10, 2) + ": " + Path.GetFileNameWithoutExtension(outputResultFile).Substring(12, 2),


                                                });
                                            }
                                        }
                                    }
                                }
                            }
                            con.Close();
                        }
                    }
                }

                query3 = "select [MediaID],video,[CRTDT],'Upload Completed' AS STATUS from tblMedia ";

                using (SqlConnection con = new SqlConnection(CS))
                {
                    using (SqlCommand cmd = new SqlCommand(query3))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr3 = cmd.ExecuteReader())
                        {
                            while (sdr3.Read())
                            {

                                videoList.Add(new tblMedia
                                {

                                    MediaID = Convert.ToInt32(sdr3["MediaID"]),
                                    Title = Convert.ToString(sdr3["video"]),
                                    Description = Convert.ToString(sdr3["STATUS"]),

                                    STRCRTDT = Convert.ToString(sdr3["CRTDT"]),


                                });
                            }
                        }
                    }
                }

                if (ViewBag.cvtStatus == 2)
                {
                    cvtStatus = "Processed";
                }
                else if (ViewBag.cvtStatus == 1)
                {

                    cvtStatus = "Processing";
                }
                else if (ViewBag.cvtStatus == 0)
                {
                    cvtStatus = "Not Processed";

                }
                else if (ViewBag.cvtStatus == 5)
                {
                    cvtStatus = "Upload Completed";

                }
               var videoList2= videoList.GroupBy(x => x.MediaID).Select(y => y.First()).ToList();
                if (ViewBag.cvtStatus == 3 || ViewBag.cvtStatus == null)
                {
                     videoList2 = videoList.GroupBy(x => x.MediaID).Select(y => y.First()).ToList();
                }
                else
                {
                     videoList2 = videoList2.Where(x => x.Description == cvtStatus).GroupBy(x => x.MediaID).Select(y => y.First()).ToList();
                }

                switch (sortOrder)
                {
                    case "ID_desc":
                        videoList2 = videoList2.OrderByDescending(o => o.MediaID).ToList();
                        break;
                   
                    case "MediaID":
                        videoList2 = videoList2.OrderBy(o => o.MediaID).ToList();
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

                ViewData["videoList"] = videoList2.ToPagedList(pageNumber, pageSize);

                                return View(VidList);
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