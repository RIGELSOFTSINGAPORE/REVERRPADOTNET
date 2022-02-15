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
    
    public class VideologsController : Controller
    {
        // GET: Videologs
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
                    query1 += " (Select m.[MediaID],m.video,m.[CRTDT],convert(varchar, m.uploadstartdatetime, 120)uploadstartdatetime,convert(varchar, m.uploadenddatetime, 120)uploadenddatetime,convert(varchar, m.streamingconstartdatetime, 120)streamingconstartdatetime,convert(varchar, m.streamingconenddatetime, 120)streamingconenddatetime ";
                    query1 += " , '" + status + "' AS STATUS";
                    query1 += " , m.Registerer,m.duration,case m.ApprovalStatus when 0 then 'Pending' when 3 then 'Approved' else 'Dis Approved' end[appdis],";
                    query1 += " case when ds.IsExists = 1 then 'Deployed' else 'Not Deployed' end[deploystatus]";
                    query1 += " from tblMedia m left join tblApplication app on app.MediaID = m.MediaID ";
                    query1 += " left join tblDeployStatus ds on ds.MediaID = m.MediaID ";
                    query1 += " where video like  '%" + Path.GetFileNameWithoutExtension(outputResultFile) + "%' and FORMAT(m.CRTDT, 'yyyy-MM-dd') between '" + CdStDate + "' and '" + CdEdDate + "' ),";
                    query1 += " cte2 AS (SELECT mediaid,case  [Delete] when 0 then 'Approval Request' when 1 then  'Delete Request' else '' end  [changerequest],Description,tblfolder.Name ,ROW_NUMBER() OVER   ";
                    query1 += " (PARTITION BY mediaid ORDER BY ApplicationID DESC) AS rn FROM tblapplication join tblfolder on tblfolder.FolderID = tblapplication.FolderID)";
                    query1 += " select * from cte  c join cte2 c2 on c.MediaID=c2.MediaID  where c2.rn = 1 or c2.rn is null ";
                   

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

                                    var column = sdr.GetOrdinal("uploadstartdatetime");

                                    if (!sdr.IsDBNull(column))
                                    {
                                        uploadstartdatetime = Convert.ToDateTime(sdr["uploadstartdatetime"]);

                                    }

                                    var column1 = sdr.GetOrdinal("uploadenddatetime");

                                    if (!sdr.IsDBNull(column1))
                                    {
                                        uploadenddatetime = Convert.ToDateTime(sdr["uploadenddatetime"]);

                                    }


                                    var column3 = sdr.GetOrdinal("streamingconstartdatetime");

                                    if (!sdr.IsDBNull(column3))
                                    {
                                        streamingconstartdatetime = Convert.ToDateTime(sdr["streamingconstartdatetime"]);

                                    }

                                    var column4 = sdr.GetOrdinal("streamingconenddatetime");

                                    if (!sdr.IsDBNull(column4))
                                    {
                                        streamingconenddatetime = Convert.ToDateTime(sdr["streamingconenddatetime"]);

                                    }
                                    videoList.Add(new tblMedia
                                    {

                                        MediaID = Convert.ToInt32(sdr["MediaID"]),
                                        Title = Convert.ToString(sdr["video"]),
                                        Description = Convert.ToString(sdr["STATUS"]),

                                        STRCRTDT = Convert.ToDateTime(sdr["CRTDT"]).ToString("yyyy/MM/dd"),
                                        STRCRTDTTIME = Convert.ToDateTime(sdr["CRTDT"]).ToString("HH:mm:ss"),
                                        suploadstartdatetime = Convert.ToDateTime(uploadstartdatetime).ToString("yyyy/MM/dd HH:mm:ss"),
                                        suploadenddatetime = Convert.ToDateTime(uploadenddatetime).ToString("yyyy/MM/dd HH:mm:ss"),
                                        sstreamingconstartdatetime = Convert.ToDateTime(streamingconstartdatetime).ToString("yyyy/MM/dd HH:mm:ss"),
                                        sstreamingconenddatetime = Convert.ToDateTime(streamingconenddatetime).ToString("yyyy/MM/dd HH:mm:ss"),

                                        Registerer = Convert.ToString(sdr["Registerer"]),
                                        Duration = Convert.ToInt32(sdr["Duration"]),
                                        Thumbnail = Convert.ToString(sdr["appdis"]),
                                        Video = Convert.ToString(sdr["changerequest"]),
                                        IpAddress = Convert.ToString(sdr["deploystatus"]),
                                        UPDCD = Convert.ToString(sdr["Description"]),
                                        UploadType = Convert.ToString(sdr["name"]),


                                    });

                                    
                                }



                                if (sdr.HasRows == false)
                                {
                                    
                                    string output = Path.GetFileNameWithoutExtension(outputResultFile).Substring(Path.GetFileNameWithoutExtension(outputResultFile).IndexOf('_') + 1);
                                    string output1 = output.Substring(output.IndexOf('_') + 1);
                                    // DateTime failed =  Convert.ToDateTime(Path.GetFileNameWithoutExtension(outputResultFile).Substring(0, 4) + "-" + Path.GetFileNameWithoutExtension(outputResultFile).Substring(4, 2) + "-" + Path.GetFileNameWithoutExtension(outputResultFile).Substring(6, 2) );
                                    DateTime failed = Convert.ToDateTime(output1.Substring(0, 4) + "-" + output1.Substring(4, 2) + "-" + output1.Substring(6, 2));
                                    if (ViewBag.CdStDate != null && ViewBag.CdEdDate != null && ViewBag.CdStDate != "" && ViewBag.CdEdDate != "")
                                    {
                                        DateTime stdate = DateTime.ParseExact(ViewBag.CdStDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                                        DateTime entdate = DateTime.ParseExact(ViewBag.CdEdDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                                        if (stdate >= failed && entdate <= failed)
                                        {
                                            videoList.Add(new tblMedia
                                            {

                                                MediaID = Seq(),
                                                Title = Path.GetFileNameWithoutExtension(outputResultFile) + ".mp4",
                                                Description = status,


                                                STRCRTDT = Path.GetFileNameWithoutExtension(outputResultFile).Substring(0, 4) + "/" + Path.GetFileNameWithoutExtension(outputResultFile).Substring(4, 2) + "/" + Path.GetFileNameWithoutExtension(outputResultFile).Substring(6, 2) + " " + Path.GetFileNameWithoutExtension(outputResultFile).Substring(8, 2) + ":" + Path.GetFileNameWithoutExtension(outputResultFile).Substring(10, 2) + ":" + Path.GetFileNameWithoutExtension(outputResultFile).Substring(12, 2),


                                            });
                                        }
                                    }
                                    else
                                    {
                                        videoList.Add(new tblMedia
                                        {

                                            MediaID = Seq(),
                                            Title = Path.GetFileNameWithoutExtension(outputResultFile) + ".mp4",
                                            Description = status,


                                            STRCRTDT = Path.GetFileNameWithoutExtension(outputResultFile).Substring(0, 4) + "/" + Path.GetFileNameWithoutExtension(outputResultFile).Substring(4, 2) + "/" + Path.GetFileNameWithoutExtension(outputResultFile).Substring(6, 2) + " " + Path.GetFileNameWithoutExtension(outputResultFile).Substring(8, 2) + ":" + Path.GetFileNameWithoutExtension(outputResultFile).Substring(10, 2) + ":" + Path.GetFileNameWithoutExtension(outputResultFile).Substring(12, 2),


                                        });
                                    }
                                  
                                }
                            }
                            con.Close();
                        }
                    }
                }
                query3 = "WITH cte AS";
                query3 += " (SELECT mediaid,case  [Delete] when 0 then 'Approval Request' when 1 then  'Delete Request' else ''";
                query3 += " end [changerequest],Description,tblfolder.Name ,ROW_NUMBER() OVER (PARTITION BY mediaid ORDER BY ApplicationID DESC)";
                query3 += " AS rn";
                query3 += " FROM tblapplication join tblfolder on tblfolder.FolderID = tblapplication.FolderID) ,";
                query3 += " cte2 as";
                query3 += " (select m.[MediaID],m.video,m.[CRTDT],case ConvertStatus when 3 then 'Conversion Completed' when 2 then 'Conversion Failed' when 0 then 'Conversion Ongoing' end AS STATUS, convert(varchar, m.uploadstartdatetime, 120)uploadstartdatetime,";
                query3 += " convert(varchar, m.uploadenddatetime, 120)uploadenddatetime,convert(varchar, m.streamingconstartdatetime, 120)streamingconstartdatetime,";
                query3 += " convert(varchar, m.streamingconenddatetime, 120)streamingconenddatetime,m.Registerer,m.duration, case m.ApprovalStatus when 0 then 'Pending'";
                query3 += " when 3 then 'Approved' else 'Dis Approved' end[appdis],case when ds.IsExists = 1 then 'Deployed' else 'Not Deployed' end[deploystatus] from tblMedia m left join ";
                query3 += " tblApplication app on app.MediaID = m.MediaID left join tblDeployStatus ds on ds.MediaID = m.MediaID  ";
                query3 += " where FORMAT(m.CRTDT, 'yyyy-MM-dd') between '" + CdStDate + "' and '" + CdEdDate + "')";
               

                
                if (medid != null)
                {
                   
                    query3 += " SELECT distinct * FROM  cte2 c  left JOIN cte c2 ON c.mediaid = c2.mediaid  where m.mediaid not in (" + medid + ") and c2.rn = 1  or c2.rn is null order by c.mediaid desc";
                }
                else
                {
                    
                    query3 += " SELECT distinct * FROM  cte2 c  left JOIN cte c2 ON c.mediaid = c2.mediaid  where c2.rn = 1  or c2.rn is null order by c.mediaid desc";
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
                                

                                videoList.Add(new tblMedia
                                {

                                    MediaID = Convert.ToInt32(sdr3["MediaID"]),
                                    Title = Convert.ToString(sdr3["video"]),
                                    Description = Convert.ToString(sdr3["STATUS"]),

                                    STRCRTDT = Convert.ToDateTime(sdr3["CRTDT"]).ToString("yyyy/MM/dd"),
                                    STRCRTDTTIME = Convert.ToDateTime(sdr3["CRTDT"]).ToString("HH:mm:ss"),
                                    suploadstartdatetime = Convert.ToDateTime(uploadstartdatetime).ToString("yyyy/MM/dd HH:mm:ss"),
                                    suploadenddatetime = Convert.ToDateTime(uploadenddatetime).ToString("yyyy/MM/dd HH:mm:ss"),
                                    sstreamingconstartdatetime = Convert.ToDateTime(streamingconstartdatetime).ToString("yyyy/MM/dd HH:mm:ss"),
                                    sstreamingconenddatetime = Convert.ToDateTime(streamingconenddatetime).ToString("yyyy/MM/dd HH:mm:ss"),


                                    Registerer = Convert.ToString(sdr3["Registerer"]),
                                    Duration = Convert.ToInt32(sdr3["Duration"]),
                                    Thumbnail = Convert.ToString(sdr3["appdis"]),
                                    Video = Convert.ToString(sdr3["changerequest"]),
                                    IpAddress = Convert.ToString(sdr3["deploystatus"]),
                                    UPDCD= Convert.ToString(sdr3["Description"]),
                                    UploadType= Convert.ToString(sdr3["name"]),
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
                
                var videoList2 = videoList.GroupBy(x => x.MediaID).Select(y => y.First()).ToList();
                if (ViewBag.cvtStatus == 3 || ViewBag.cvtStatus == null)
                {
                    videoList2 = videoList.GroupBy(x => x.MediaID).Select(y => y.First()).ToList();
                }
                else
                {
                    videoList2 = videoList.Where(x => x.Description == cvtStatus).GroupBy(x => x.MediaID).Select(y => y.First()).ToList();
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
    }
    
}