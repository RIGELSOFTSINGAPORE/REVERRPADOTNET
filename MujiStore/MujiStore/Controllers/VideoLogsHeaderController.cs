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
    [MUJICustomAuthorize(Roles = "8,9,10,11,12,13,14,15,24,25,27,26,28,29,30,31")]
    public class VideoLogsHeaderController : Controller
    {
        // GET: VideoLogsHeader
        private mujiEntities1 db = new mujiEntities1();
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        string status;
        string query1;
        string query2;
        string query3;
        string cvtStatus;
        DateTime uploadstartdatetime;
        DateTime uploadenddatetime;
        DateTime streamingconstartdatetime;
        DateTime streamingconenddatetime;
        DateTime appuploadstartdatetime;
        DateTime appuploadenddatetime;
        DateTime depuploadstartdatetime;
        DateTime depuploadenddatetime;
        String medid;
        StringBuilder sb = new StringBuilder(" ");
        List<string> sblist = new List<string>();

        private static int orderNumber = 0;
        public ActionResult Index(string sortOrder, int? page, int? ConvertStatus, int? CvtStatus, int? MediaID, int? MedID, string CdStDate, string CdEdDate, string SearchFromCRTDT, string SearchToCRTDT)

        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int pageSize;
            ViewBag.CurrentSort = sortOrder;

            ViewBag.MediaIDSortParm = sortOrder == "MediaID" ? "ID_desc" : "MediaID";


            List<SelectListItem> lstConvertStatus = new List<SelectListItem>();

            lstConvertStatus.Add(new SelectListItem { Text = MujiStore.Resources.Resource.All, Value = "3" });
            lstConvertStatus.Add(new SelectListItem { Text = MujiStore.Resources.Resource.Conversioncompleted, Value = "2" });
            lstConvertStatus.Add(new SelectListItem { Text = MujiStore.Resources.Resource.Conversionongoing, Value = "1" });
            lstConvertStatus.Add(new SelectListItem { Text = MujiStore.Resources.Resource.Conversionfailed, Value = "0" });
            
            ViewBag.ConvertStatus = new SelectList(lstConvertStatus, "Value", "Text", CvtStatus);



            List<tblMedia> VidList = new List<tblMedia>();
            List<tblMedia> VidList1 = new List<tblMedia>();


            if (ConvertStatus != null)
            {
                page = 1;
            }
            else
            {

                ConvertStatus = CvtStatus;
                SearchFromCRTDT = CdStDate;
                SearchToCRTDT = CdEdDate;
            }

            ViewBag.cvtStatus = ConvertStatus;
            ViewBag.MedID = MediaID;
            ViewBag.CdStDate = SearchFromCRTDT;
            ViewBag.CdEdDate = SearchToCRTDT;
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

            try
            {


                List<tblMedia> videoList = new List<tblMedia>();
                List<tblMedia> videoListem = new List<tblMedia>();

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
                        status = "Conversion Ongoing";
                    }
                    else if (files.Count() == 2)
                    {
                        System.IO.FileInfo fi = new System.IO.FileInfo(strRootDirectory + @"ffmpeg\tmp\" + Path.GetFileNameWithoutExtension(outputResultFile) + ".txt");

                        if (fi.Exists)
                        {
                            status = "Conversion Ongoing";
                        }
                        else
                        {
                            status = "Conversion Failed";
                        }

                    }
                    else if (files.Count() == 1)
                    {
                        System.IO.FileInfo fi = new System.IO.FileInfo(strRootDirectory + @"ffmpeg\tmp\" + Path.GetFileNameWithoutExtension(outputResultFile) + ".txt");
                        if (fi.Exists)
                        {
                            status = "Conversion Completed";
                        }
                        else if (!(fi.Exists))
                        {
                            status = "Conversion Failed";
                        }
                    }
                    else
                    {
                        System.IO.FileInfo fi = new System.IO.FileInfo(strRootDirectory + @"ffmpeg\tmp\" + Path.GetFileNameWithoutExtension(outputResultFile) + ".txt");
                        System.IO.FileInfo fi1 = new System.IO.FileInfo(strRootDirectory + @"ffmpeg\tmp\" + Path.GetFileNameWithoutExtension(outputResultFile) + ".bat");
                        if (fi.Exists && (fi1.Exists))
                        {
                            status = "Conversion Ongoing";
                        }
                        else if (!(fi.Exists) && (fi1.Exists))
                        {
                            status = "Conversion Failed";
                        }
                        else if (fi.Exists)
                        {
                            status = "Conversion Completed";
                        }
                    }

                    query1 = " with cte as  ";
                    query1 += " (Select MediaID,title,video ";
                    query1 += " , '" + status + "' AS STATUS from tblmedia";
                    query1 += " where video like  '%" + Path.GetFileNameWithoutExtension(outputResultFile) + "%' and FORMAT(CRTDT, 'yyyy-MM-dd') between '" + CdStDate + "' and '" + CdEdDate + "' )";     
                    query1 += " select * from cte   where MediaID is not null ";


                    if (ViewBag.cvtStatus != null && ViewBag.cvtStatus != 4 && ViewBag.cvtStatus != 3)

                    {
                        if (ViewBag.cvtStatus == 2)
                        {
                            cvtStatus = "Conversion Completed";
                            query1 = query1 + " and  STATUS = '" + cvtStatus + "' ";
                        }
                        else if (ViewBag.cvtStatus == 1)
                        {

                            cvtStatus = "Conversion Ongoing";
                            query1 = query1 + " and  STATUS = '" + cvtStatus + "' ";
                        }
                        else if (ViewBag.cvtStatus == 0)
                        {
                            cvtStatus = "Conversion Failed";
                            query1 = query1 + " and  STATUS = '" + cvtStatus + "' ";

                        }


                    }

                   
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

                                    
                                    sblist.Add(Convert.ToString(Convert.ToInt32(sdr["MediaID"])));
                                    medid = String.Join(",", sblist.ToArray());

                                   
                                    videoList.Add(new tblMedia
                                    {

                                        MediaID = Convert.ToInt32(sdr["MediaID"]),
                                        Title = Convert.ToString(sdr["title"]),
                                        Description = Convert.ToString(sdr["video"]),
                                        UPDCD = Convert.ToString(sdr["STATUS"]),

                                       

                                    });


                                }



                                if (sdr.HasRows == false)
                                {
                                    
                                    string output = Path.GetFileNameWithoutExtension(outputResultFile).Substring(Path.GetFileNameWithoutExtension(outputResultFile).IndexOf('_') + 1);
                                    string output1 = output.Substring(output.IndexOf('_') + 1);
                                    
                                    DateTime failed = Convert.ToDateTime(output1.Substring(0, 4) + "-" + output1.Substring(4, 2) + "-" + output1.Substring(6, 2));
                                    if (ViewBag.CdStDate != null && ViewBag.CdEdDate != null && ViewBag.CdStDate != "" && ViewBag.CdEdDate != "")
                                    {
                                        DateTime stdate = DateTime.ParseExact(ViewBag.CdStDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                                        DateTime entdate = DateTime.ParseExact(ViewBag.CdEdDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                                        if (stdate >= failed && entdate <= failed)
                                        {
                                            videoListem.Add(new tblMedia
                                            {

                                                MediaID = Seq(),
                                                Title = Path.GetFileNameWithoutExtension(outputResultFile) + ".mp4",
                                                Description = Path.GetFileNameWithoutExtension(outputResultFile),
                                                UPDCD = "Conversion Failed",
                                            });
                                        }
                                    }
                                    else
                                    {
                                        videoListem.Add(new tblMedia
                                        {

                                            MediaID = Seq(),
                                            Title = Path.GetFileNameWithoutExtension(outputResultFile) + ".mp4",
                                            Description = Path.GetFileNameWithoutExtension(outputResultFile),
                                            UPDCD = "Conversion Failed",
 
                                        });
                                    }
                                   
                                }
                            }
                            con.Close();
                        }
                    }
                }
                query3 = " with cte as  ";
                query3 += " (Select MediaID,title,video,case ConvertStatus when 3 then 'Conversion Completed' when 2 then 'Conversion Failed' when 0 then 'Conversion Ongoing' end AS STATUS ";
                query3 += "  from tblmedia";
                query3 += " where  FORMAT(CRTDT, 'yyyy-MM-dd') between '" + CdStDate + "' and '" + CdEdDate + "' )";
                
                if (medid != null)
                {
                    
                    query3 += " SELECT  * FROM  cte  where mediaid not in (" + medid + ") order by mediaid desc";
                }
                else
                {
                    
                    query3 += " SELECT  * FROM  cte   order by mediaid desc";
                }
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



                                videoListem.Add(new tblMedia
                                {

                                    MediaID = Convert.ToInt32(sdr3["MediaID"]),
                                    Title = Convert.ToString(sdr3["title"]),
                                    Description = Convert.ToString(sdr3["video"]),
                                    UPDCD = Convert.ToString(sdr3["STATUS"]),

                                    
                                });
                            }
                        }
                    }
                }

                if (ViewBag.cvtStatus == 2)
                {
                    cvtStatus = "Conversion Completed";
                }
                else if (ViewBag.cvtStatus == 1)
                {

                    cvtStatus = "Conversion Ongoing";
                }
                else if (ViewBag.cvtStatus == 0)
                {
                    cvtStatus = "Conversion Failed";

                }
                
                var videoList2 = videoListem.GroupBy(x => x.MediaID).Select(y => y.First()).ToList();
                if (ViewBag.cvtStatus == 3 || ViewBag.cvtStatus == null)
                {
                    videoList2 = videoListem.GroupBy(x => x.MediaID).Select(y => y.First()).ToList();
                }
                else
                {
                    videoList2 = videoListem.Where(x => x.UPDCD == cvtStatus).GroupBy(x => x.MediaID).Select(y => y.First()).ToList();
                }
                videoList2 = videoList2.OrderByDescending(o => o.MediaID).ToList();

                

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
        int Seq()
        {
            return Interlocked.Increment(ref orderNumber);
        }
        public ActionResult Edit(int? id,int?page)
            {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;

            try
            {
                ViewBag.Page = page;
                tblMedia tblmedia = new tblMedia();
                 tblmedia = db.tblMedias.Find(id);

                List<tblapplication> VidList = new List<tblapplication>();
                List<tblMedia> VidList1 = new List<tblMedia>();
                List<tblDeployStatu> VidList2 = new List<tblDeployStatu>();
                List<tblMedia> videoList = new List<tblMedia>();


                query3 = "select * from tblmedia where mediaid = " + id + "";


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
                                var column = sdr3.GetOrdinal("uploadstartdatetime");

                                if (!sdr3.IsDBNull(column))
                                {
                                    
                                    uploadstartdatetime = Convert.ToDateTime(sdr3["uploadstartdatetime"]);

                                }
                                var column1 = sdr3.GetOrdinal("uploadenddatetime");

                                if (!sdr3.IsDBNull(column1))
                                {
                                    uploadenddatetime = Convert.ToDateTime(sdr3["uploadenddatetime"]);

                                }

                                var column3 = sdr3.GetOrdinal("streamingconstartdatetime");

                                if (!sdr3.IsDBNull(column3))
                                {
                                    streamingconstartdatetime = Convert.ToDateTime(sdr3["streamingconstartdatetime"]);

                                }

                                var column4 = sdr3.GetOrdinal("streamingconenddatetime");

                                if (!sdr3.IsDBNull(column4))
                                {
                                    streamingconenddatetime = Convert.ToDateTime(sdr3["streamingconenddatetime"]);

                                }
                                VidList1.Add(new tblMedia
                                {

                                    MediaID = Convert.ToInt32(sdr3["MediaID"]),
                                    Title = Convert.ToString(sdr3["title"]),
                                    Video = Convert.ToString(sdr3["Video"]),
                                    suploadstartdatetime = Convert.ToDateTime(uploadstartdatetime).ToString("yyyy/MM/dd HH:mm:ss"),

                                    suploadenddatetime = Convert.ToDateTime(uploadenddatetime).ToString("yyyy/MM/dd HH:mm:ss"),
                                    sstreamingconstartdatetime = Convert.ToDateTime(streamingconstartdatetime).ToString("yyyy/MM/dd HH:mm:ss"),
                                    sstreamingconenddatetime = Convert.ToDateTime(streamingconenddatetime).ToString("yyyy/MM/dd HH:mm:ss"),
                                    Registerer = Convert.ToString(sdr3["Registerer"]),
                                    Accepter = Convert.ToString(sdr3["Accepter"]),
                                    ConvertStatus = Convert.ToInt32(sdr3["ConvertStatus"]),

                                });
                            }
                        }
                    }
                }

                query3 = "";
                query3 = "select case  [Delete] when 0 then 'Approval Request' when 1 then  'Delete Request' else '' end [changerequest],";
                query3 += " a.registerer,a.RegisteredDate,a.mediaid,a.ApplicationID,";
                query3 += " isnull(a.completedate,a.registereddate)[Completedate],isnull(a.Accepter,a.registerer)[Accepter],case a.approved when 0 then  N'" + MujiStore.Resources.Resource.disapproved + "' when 1 then  N'" + MujiStore.Resources.Resource.Approved + "' else N'" + MujiStore.Resources.Resource.ChangeRequested+"' end [astatus]";
                query3 += " ,a.Title , a.[Description] ,f.Name";
                query3 += " from tblapplication a";
                query3 += " join tblmedia M on m.mediaid =  a.MediaID";
                query3 += " left join tblFolder  f on a.FolderID=f.FolderID";
                query3 += " where a.mediaid = " + id + " order by a.ApplicationID desc";
                

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
                                var column = sdr3.GetOrdinal("Registereddate");

                                if (!sdr3.IsDBNull(column))
                                {
                                    appuploadstartdatetime = Convert.ToDateTime(sdr3["Registereddate"]);

                                }
                                var column1 = sdr3.GetOrdinal("Completedate");

                                if (!sdr3.IsDBNull(column1))
                                {
                                    appuploadenddatetime = Convert.ToDateTime(sdr3["Completedate"]);

                                }
                                VidList.Add(new tblapplication
                                {

                                    MediaID = Convert.ToInt32(sdr3["MediaID"]),
                                    Delete = Convert.ToString(sdr3["changerequest"]),
                                    Register = Convert.ToString(sdr3["Registerer"]),

                                    Registereddate = Convert.ToDateTime(appuploadstartdatetime).ToString("yyyy/MM/dd HH:mm:ss"),
                                    Completedate = Convert.ToDateTime(appuploadenddatetime).ToString("yyyy/MM/dd HH:mm:ss"),
                                    Accepter = Convert.ToString(sdr3["Accepter"]),
                                   // Approved = Convert.ToBoolean(sdr3["Approved"]),
                                    ApplicationID = Convert.ToInt32(sdr3["ApplicationID"]),
                                    status = Convert.ToString(sdr3["astatus"]),
                                    title = Convert.ToString(sdr3["Title"]),
                                    description = Convert.ToString(sdr3["description"]),
                                    name = Convert.ToString(sdr3["name"]),


                                });
                            }
                        }
                    }
                }

                query3 = "";
                query3 = "select case isexists when 1 then N'"+MujiStore.Resources.Resource.VideoDeployed+"' else 'Video Not Deployed' end [deploy] ,* from tblDeployStatus where mediaid = " + id + " order by deploystatusid desc";


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
                                var column = sdr3.GetOrdinal("UPDDT");

                                if (!sdr3.IsDBNull(column))
                                {
                                    depuploadstartdatetime = Convert.ToDateTime(sdr3["UPDDT"]);

                                }
                                var column1 = sdr3.GetOrdinal("CRTDT");

                                if (!sdr3.IsDBNull(column1))
                                {
                                    depuploadenddatetime = Convert.ToDateTime(sdr3["CRTDT"]);

                                }
                                VidList2.Add(new tblDeployStatu
                                {

                                    MediaID = Convert.ToInt32(sdr3["MediaID"]),
                                    DSServer = Convert.ToString(sdr3["DSServer"]),
                                    FormatName = Convert.ToString(sdr3["deploy"]),
                                    IPAddress = Convert.ToDateTime(depuploadenddatetime).ToString("yyyy/MM/dd HH:mm:ss"),

                                    UPDCD = Convert.ToString(sdr3["CRTCD"]),
                                    UserIPAddress = Convert.ToDateTime(depuploadstartdatetime).ToString("yyyy/MM/dd HH:mm:ss"),
                                    CRTCD = Convert.ToString(sdr3["UPDCD"]),

                                });
                            }
                        }
                    }
                }

                tblmedia.approvalSta = VidList;
                tblmedia.deployStatus = VidList2;

                ViewData["videoList"] = videoList;
                ViewData["videoList1"] = VidList1;
                return View(tblmedia);
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
