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
using System.Text.RegularExpressions;

namespace MujiStore.Controllers
{
    [SessionExpire]
    [Authorize]

    [MUJICustomAuthorize(Roles = "4,5,6,7,12,13,14,15,20,21,22,23,28,29,30,31")]

    public class VideoDemoController : BaseController
    {
        private mujiEntities1 db = new mujiEntities1();
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        int depth = 0;
        DateTime uploadstartdatetime;
        DateTime uploadenddatetime;
        string emptydate;
        string streamserver = System.Configuration.ConfigurationManager.AppSettings["Streamserver"];
        // GET: VideoDemo
        public ActionResult Index(string sortOrder, int? page, string SearTitle, string SearchTitle, string SearchFromCRTDT, string CdStDate, string SearchToCRTDT, string CdEdDate, int? Convertstatus, int? ConvtStatus, int? FolderID, int? FolID)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int pageSize;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.IDSortParm = sortOrder == "ID" ? "ID_desc" : "ID";
            ViewBag.TitleSortParm = sortOrder == "Title" ? "Title_desc" : "Title";
            ViewBag.ConvertStatusSortParm = sortOrder == "ConvertStatus" ? "ConvertStatus_desc" : "ConvertStatus";
            ViewBag.FolderSortParm = sortOrder == "Folder" ? "Folder_desc" : "Folder";



            List<SelectListItem> lstApprovalstatus = new List<SelectListItem>();

            List<SelectListItem> lstConvertstatus = new List<SelectListItem>();

            lstConvertstatus.Add(new SelectListItem { Text = MujiStore.Resources.Resource.All, Value = "4" });
            lstConvertstatus.Add(new SelectListItem { Text = MujiStore.Resources.Resource.Conversionongoing, Value = "0" });
            lstConvertstatus.Add(new SelectListItem { Text = MujiStore.Resources.Resource.Conversioncompleted, Value = "3" });//VJ 20200603 ConvertStatus Changed
            lstConvertstatus.Add(new SelectListItem { Text = MujiStore.Resources.Resource.Conversionfailed, Value = "2" });
            ViewBag.Convertstatus = new SelectList(lstConvertstatus, "Value", "Text", ConvtStatus);

            List<SelectListItem> lstFolderName = new List<SelectListItem>();
            List<SelectListItem> lstFolderNameBulk = new List<SelectListItem>();
            lstFolderName = BLL.CommonLogic.FillFolderList();
            lstFolderNameBulk = BLL.CommonLogic.FillFolderList();
 
            ViewBag.FolderList = new SelectList(lstFolderNameBulk, "Value", "Text");
            lstFolderName.Insert(0, (new SelectListItem { Text = "All", Value = "0" }));
            ViewBag.FolderID = new SelectList(lstFolderName, "Value", "Text", FolID);

            if (SearchTitle != null || SearchFromCRTDT != null || SearchToCRTDT != null || Convertstatus != null)
            {
                page = 1;
            }
            else
            {
                SearchTitle = SearTitle;
                SearchFromCRTDT = CdStDate;
                SearchToCRTDT = CdEdDate;
                Convertstatus = ConvtStatus;
                FolderID = FolID;
            }
            ViewBag.SearTitle = SearchTitle;
            ViewBag.CdStDate = SearchFromCRTDT;
            ViewBag.CdEdDate = SearchToCRTDT;
            ViewBag.ConvtStatus = Convertstatus;
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
                var formats = new[] { "dd/MM/yyyy", "yyyy-MM-dd","yyyy/MM/dd" };
                if (!DateTime.TryParseExact(CdStDate.Trim(), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue) || !(DateTime.TryParseExact(CdEdDate.Trim(), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue)))
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.datevalidation;
                }

                List<string> ffmt = new List<string>();
                ffmt = MujiStore.BLL.CommonLogic.GetFileExtn("video");
                List<BulkUploadVideo> VidList = new List<BulkUploadVideo>();
                var videoAllFiles = Directory.EnumerateFiles(Server.MapPath("~/FtpVideo")); 

                var videoFiles = from selectfiles in videoAllFiles
                                 where (from filedtl in videoAllFiles
                                        from filextn in ffmt
                                        where filedtl.ToLower().EndsWith(filextn)
                                        select filedtl).Contains(selectfiles)
                                 select selectfiles;

                foreach (string file in videoFiles)
                {
                    BulkUploadVideo buMedia = new BulkUploadVideo();
                    buMedia.UploadFileName = Path.GetFileName(file);
                    buMedia.UploadTitle = string.Empty;
                    buMedia.UploadDescription = string.Empty;
                    buMedia.UploadFolderID = 1;
                    buMedia.IsUpload = false;
                    buMedia.IsDelete = false;
                    VidList.Add(buMedia);
                    // Console.WriteLine(Path.GetFileName(file));
                }
                FillApprovalStatus();
                ViewData["videoFiles"] = VidList;
                //When fils is exit, then need to show for the update. Count will send to Index Page
                var videoFilesCount = Directory.EnumerateFiles(Server.MapPath("~/FtpVideo")).Count(); 
 
                ViewBag.VideoFilesCount = VidList.Count;
                //Verify that file is convered
                var videoConvertedFiles = Directory.EnumerateFiles(Server.MapPath("~/ffmpeg/tmp"), "*.txt"); 

                var videoConvertedFilesSelect = from selectfiles in videoConvertedFiles
                                                select selectfiles;
                //By Default
                Boolean convertStatus = false;
                int convertedcount = 0;
                foreach (string outputResultFile in videoConvertedFilesSelect)
                {
                    convertedcount = convertedcount + 1;
                    var fileCheck = new FileInfo(outputResultFile);
                    if (IsFileLocked(fileCheck) == false) // If file is not locked then it can be delete
                    {
                        convertStatus = true;
                    }

                }
                //Check the converted count
                if (convertedcount == 0)
                {
                    //Verify that any batch file is available , hence the conversion process start with batch file
                    var batchCouunt = Directory.EnumerateFiles(Server.MapPath("~/ffmpeg/tmp"), "*.bat").Count(); 
 
                    if (batchCouunt > 0)
                    {
                        ViewBag.videoConvertedFilesCount = -99;
                    }
                    else
                    {
                        ViewBag.videoConvertedFilesCount = 0;
                    }
                }
                else
                {
                    if (convertStatus == true)
                    {
                        ViewBag.videoConvertedFilesCount = 1;
                    }
                    else
                    {
                        ViewBag.videoConvertedFilesCount = -99;
                    }

                }
                //var videoList="";
                List<tblMedia> videoList = new List<tblMedia>();
                //var videoList;
                string uName = Session["UserName"].ToString();
                ViewData["FolderDtl"] = BLL.CommonLogic.FillFolderList();
                string query = "select MediaID,tblMedia.CRTDT,Title,Description, convert(varchar,MediaID)+'.mp4' Video,ConvertStatus,ApprovalStatus,tblMedia.FolderID,Name ,case ApprovalStatus when 0 then 'Change Requested' when 2 then 'Disapproved' when 3 then 'Approved'end [astatus]";
                query = query + "from [dbo].[tblMedia] ";
                query = query + " LEFT JOIN [tblUser] AS U1 ON [tblMedia].Registerer = U1.ID ";
                query = query + " LEFT JOIN [tblUser] AS U2 ON [tblMedia].Accepter = U2.ID ";
                query = query + " left join tblFolder on tblMedia.FolderID = tblFolder.FolderID where ";

                query = query + " [tblMedia].DELFG = 0 and [tblMedia].ApprovalStatus < 3 ";



                //Datepicker changed by sabeena 
                query = query + " and FORMAT(tblMedia.CRTDT, 'yyyy/MM/dd') between '" + CdStDate + "' and '" + CdEdDate + "'";

 

                if (ViewBag.SearTitle != null && ViewBag.SearTitle != "" && ViewBag.SearTitle != string.Empty)
                {
                    query = query + " and title like @title";
                }

 
                if (ViewBag.ConvtStatus != null && ViewBag.ConvtStatus != 4)
                {
                    query = query + " and ConvertStatus = " + ViewBag.ConvtStatus;

                }
                if (ViewBag.FolID != null && ViewBag.FolID != 0)
                {
                    query = query + " and tblMedia.FolderID = " + Convert.ToInt32(ViewBag.FolID);
                }
                query = query + " Order by MediaID Desc";

                using (SqlConnection con = new SqlConnection(CS))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@title", "%" + ViewBag.SearTitle + "%" );
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                videoList.Add(new tblMedia
                                {
                                    MediaID = Convert.ToInt32(sdr["MediaID"]),
                                    Title = Convert.ToString(sdr["Title"]),
                                    Description = Convert.ToString(sdr["Description"]),
                                    Video = Convert.ToString(sdr["Video"]),
                                    ApprovalStatus = Convert.ToInt32(sdr["ApprovalStatus"]),
                                    FolderID = Convert.ToInt32(sdr["FolderID"]),
                                    FolderName = Convert.ToString(sdr["Name"]),
                                    CRTDT = Convert.ToDateTime(sdr["CRTDT"]),
                                    STRCRTDT = Convert.ToDateTime(sdr["CRTDT"]).ToString("yyyy/MM/dd"),// .ToString("yyyy/MM/dd HH:mm:ss tt");
                                    STRCRTDTTIME = Convert.ToDateTime(sdr["CRTDT"]).ToString("HH:mm:ss"),// .ToString("yyyy/MM/dd HH:mm:ss tt");
                                    ConvertStatus = Convert.ToInt32(sdr["ConvertStatus"]),
                                    Thumbnail = Convert.ToString(sdr["astatus"]),
                                });
                            }
                        }
                        con.Close();
                    }
                }


                switch (sortOrder)
                {
 
                    case "ID":
                        videoList = videoList.OrderBy(o => o.MediaID).ToList();
                        break;
                    case "Title":
                        videoList = videoList.OrderBy(o => o.Title).ToList();
                        break;
                    case "Title_desc":
                        videoList = videoList.OrderByDescending(o => o.Title).ToList();
                        break;
                    case "ConvertStatus_desc":
                        videoList = videoList.OrderByDescending(o => o.ConvertStatus).ToList();
                        break;

                    case "ConvertStatus":
                        videoList = videoList.OrderBy(o => o.ConvertStatus).ToList();
                        break;
  
                    case "Folder_desc":
                        videoList = videoList.OrderByDescending(o => o.FolderName).ToList();
                        break;
                    case "Folder":
                        videoList = videoList.OrderBy(o => o.FolderName).ToList();
                        break;
                    default:  // Name ascending 
                        videoList = videoList.OrderByDescending(o => o.MediaID).ToList();
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


                return View(VidList);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }


        }

        /// <summary>
        /// Update Video converted status
        /// </summary>
        /// <returns></returns>
        ///

        public ActionResult UpdateVideoConvertedStatus()
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {

                //Loading text file list
                var videoAllFiles = Directory.EnumerateFiles(Server.MapPath("~/ffmpeg/tmp"), "*.txt"); 

                //Select 
                var videoFiles = from selectfiles in videoAllFiles
                                 select selectfiles;

                String strUpdatedText = "";
                //Intialize fi
                System.IO.FileInfo fi = null;
                //Update and delete the file about conversion status
                foreach (string outputResultFile in videoFiles)
                {
                    //Read line
                    string strTextLine;
                    int durationIndex = -1;
                    int fileDuration = 0;
                    System.IO.StreamReader file = null;
                    int convertStatus = 0;
                    //Assign text file from the list
                    string strFileName = Path.GetFileNameWithoutExtension(outputResultFile);
                    //Get extension
                    string strExt = Path.GetExtension(outputResultFile);
                    var fileCheck = new FileInfo(outputResultFile);

                    DateTime creation = fileCheck.CreationTime;
                    

                    //Verify that file is locked (the file is read only mode or RW mode)
                    if (IsFileLocked(fileCheck) == false)
                    {
                        try
                        {
                            //Read from the text file
                            file = new System.IO.StreamReader(outputResultFile);
                            //Read the ile until reach the duration
                            while ((strTextLine = file.ReadLine()) != null)
                            {
                                //find the text of Duration
                                durationIndex = strTextLine.IndexOf("Duration: ");
                                if (durationIndex >= 0)
                                {
                                    //Reading File Duration and Size
                                    //Sample  Duration: 00:00:11.83, start: 0.000000, bitrate: 1011 kb/s
                                    string[] durationLine = strTextLine.Split(',');
                                    StringBuilder sbDuration = new StringBuilder(durationLine[0]); //0 Duration, 1 start 2 bitrate
                                    sbDuration.Replace("Duration: ", "");
                                    sbDuration.Replace(" ", "");
                                    sbDuration.Replace(".", ":");
                                    //Convert String;
                                    String strTmp = sbDuration.ToString();
                                    string[] durationDelimiter = strTmp.Split(':');
                                    // 0 hours 1 minutes 2 seconds 3 millisecond
                                    int intHours = Int32.Parse(durationDelimiter[0]);
                                    int intMinutes = Int32.Parse(durationDelimiter[1]);
                                    int intSeconds = Int32.Parse(durationDelimiter[2]);
                                    convertStatus = 3;
                                    //Calculate the duration
                                    fileDuration = (intHours * 3600) + (intMinutes * 60) + intSeconds; //millisecond not included
                                    break;
                                }
                            }
                            file.Close();
                            file = new System.IO.StreamReader(outputResultFile);
                            while ((strTextLine = file.ReadLine()) != null)
                            {
                                //find the text of Duration
                                durationIndex = strTextLine.IndexOf("Error");
                                if (durationIndex >= 0)
                                {
                                    convertStatus = 2;
                                    //Calculate the duration

                                    break;
                                }
                            }
  
                        }
                        catch { }
                        finally
                        {

                            file.Close();
                        }

                        //Reading for FileSize in  file itself
                        String strRootDirectory = Server.MapPath("~/");
                        fi = new FileInfo(strRootDirectory + @"\Video\" + strFileName + ".mp4");
                        // Get file size  
                        long fileSize = fi.Length / 1024;

                        //Update Status
                        tblMedia tblmed = new tblMedia();
                        tblmed.Video = strFileName + ".mp4";
                        tblmed.FileSize = fileSize;
                        tblmed.Duration = fileDuration;
                        tblmed.ConvertStatus = convertStatus;  //0 Not Converted 1 Converted //VJ 20200603 ConvertStatus 3 Converted  Changed
                                                   //For Return to the user
                        strUpdatedText = strUpdatedText + strFileName + ".mp4, ";
                        //Update the status to the database 
                        

                        DateTime modification = fileCheck.LastWriteTime;
                        tblmed.streamingconstartdatetime = creation;
                        tblmed.streamingconenddatetime = modification;
                        tblmed.MediaID = Convert.ToInt32(strFileName);

                        int result = UpdateConvertedStatusMediaFile(tblmed);
                        //Delete File .txt File 
                        fi = new System.IO.FileInfo(outputResultFile);
                        if (fi.Exists)
                        {
                            System.IO.File.Copy(outputResultFile, Server.MapPath("~/ffmpeg/log/"+ tblmed.MediaID + ".txt"));
                            fi.Delete();
                        }
                    }
                }
                //Remove comma
                if(strUpdatedText.Length > 2)
                {
                    string strUpdatedText1 = strUpdatedText.Remove(strUpdatedText.Length - 1, 1);
                    strUpdatedText1 = " ( " + strUpdatedText1 + " ) ";
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.CntVideoDemoUpdateVCSSuccMsg + strUpdatedText1;
                }


                return RedirectToAction("Index", new { page = TempData["Page"] });

            }
            catch (Exception ex)
            {
                //Write exception to log
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                //To know about the error to the user
                TempData["ErrMsg"] = MujiStore.Resources.Resource.CntVideoDemoUpdateVCSErrMsg;
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }
        /// <summary>
        /// Verify that File is Read only / RW permission
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        protected virtual bool IsFileLocked(FileInfo file)
        {
            //Initialze Filestream
            FileStream stream = null;
            try
            {
                //Open the file with RW, if error raise then the file is read mode.
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                //Close the stream
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

 
        /// <summary>
        /// Streaming video conversion
        /// </summary>
        /// <param name="_tblVideoDemo"></param>
        /// <returns></returns>
        /// 
        public int UpdateDeployStatusAll(IEnumerable<tblDeployStatu> _tblDeployStatus)
        {
            int result = 0;


            foreach (var bupload in _tblDeployStatus)
            {
                if (bupload.DeployStatusID > 0)
                {
 
                    bupload.IsExists = bupload.DELFG;
                    bupload.DELFG = bupload.DELFG == true ? false : true;
                    bupload.DateTime = DateTime.Now;
                    bupload.UPDDT = DateTime.Now;
                    bupload.UPDCD = Session["UserName"].ToString();
                    bupload.UserIPAddress = Session["IPAddress"].ToString();
                    bupload.Duration = bupload.Duration;
                    bupload.FileSize = bupload.FileSize;
                    UpdateDeployStatus(bupload);
 
                }
                else if (bupload.DeployStatusID == 0 && bupload.DELFG == true)
                {
                    
                    bupload.IsExists = bupload.DELFG;
                    bupload.DateTime = DateTime.Now;
                    bupload.DELFG = bupload.DELFG == true ? false : true;
                    bupload.CRTDT = DateTime.Now;
                    bupload.CRTCD = Session["UserName"].ToString();
                    bupload.UserIPAddress = Session["IPAddress"].ToString();
                    bupload.Duration = bupload.Duration;
                    bupload.FileSize = bupload.FileSize;
                    InsertDeployStatus(bupload);
               
                }
            }
            return result;
        }
        [HttpPost]
        public ActionResult CreateFtpvideo(IEnumerable<BulkUploadVideo> _tblVideoDemo)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                //Root Path
                String strRootDirectory = Server.MapPath("~/");
                string sourcePath = strRootDirectory + @"\FtpVideo";
                string OriginalPath = strRootDirectory + @"\originalmedia";
                string targetPath = strRootDirectory + @"\Video";

                //Batch Processing Flag
                Boolean IsBatchProcesing = false;
                foreach (var bupload in _tblVideoDemo)
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(strRootDirectory + @"\FtpVideo\" + bupload.UploadFileName);
                    if (fi.Exists)
                    {
                        if (bupload.IsDelete == true)
                        {
                            fi.Delete();
                        }
                        else if (bupload.IsUpload == true)
                        {
                            if (bupload.UploadTitle == null || bupload.UploadTitle == string.Empty || bupload.UploadTitle.Trim() == "")
                            {

                                TempData["ErrMsg"] = MujiStore.Resources.Resource.ModtblMediaTitleDataAnnaValida1 + bupload.UploadFileName;
                                 return RedirectToAction("Index");
 
                            }
                        }
                    }
                }

 
                //Batch FileName
                string strBatchFile = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".bat";
                //Master Batch File
                FileInfo fileMasterBatch = new FileInfo(strRootDirectory + @"ffmpeg\tmp\" + strBatchFile);

                using (StreamWriter swMaster = fileMasterBatch.CreateText())
                {
                    foreach (var bupload in _tblVideoDemo)
                    {
                        var startdatetime = DateTime.Now;
                        System.IO.FileInfo fi = new System.IO.FileInfo(strRootDirectory + @"\FtpVideo\" + bupload.UploadFileName);
 
                        if (fi.Exists)
                        {
                            //If the checkbox (Delete) is selected, then delete the file from FTP folder
                            if (bupload.IsDelete == true)
                            {
                                fi.Delete();
                            }
                            else if (bupload.IsUpload == true)
                            {
                                //Verify that title should not empty
                                if (bupload.UploadTitle == null || bupload.UploadTitle == string.Empty || bupload.UploadTitle.Trim() == "")
                                {
                                    TempData["SuccMsg"] = MujiStore.Resources.Resource.CntVideoDemoCreateFtpvideoErrMsg1 + bupload.UploadFileName;

 
                                }
                                else
                                {
                                    //Assign true for batch processing 
                                    IsBatchProcesing = true;
  

                                    tblMedia tblmed = new tblMedia();
                                    tblmed.Title = bupload.UploadTitle;
                                    tblmed.Description = bupload.UploadDescription;
                                    tblmed.Video = bupload.UploadFileName;
                                    tblmed.FolderID = bupload.UploadFolderID;
                                    tblmed.UploadType = "F";
                                    tblmed.FileSize = 0;
                                    tblmed.Duration = 0;
                                    tblmed.ConvertStatus = 0;  //0 Not Converted 3 Converted

                                    //Update video information to the database
                                    int result = InsertMediaFile(tblmed);
                                    tblmed.MediaID = result;

                                    Regex rgx = new Regex("[`~@#%&!$*()+={[}:',<>/]");
 
                                    FileInfo file = new FileInfo(System.IO.Path.Combine(sourcePath, bupload.UploadFileName));
                                    bupload.UploadFileName = rgx.Replace(bupload.UploadFileName, "");
                                    file.MoveTo(System.IO.Path.Combine(sourcePath, bupload.UploadFileName.Replace(" ", "_").Replace(";", "").Replace("\",\"", "").Replace(@""",""", "").Replace("^", "").Replace("]", "").Replace("|", "").Replace("?", "")));
                                    bupload.UploadFileName = bupload.UploadFileName.Trim().Replace(" ", "_").Replace(";", "").Replace("\",\"", "").Replace(@""",""", "").Replace("^", "").Replace("]", "").Replace("|", "").Replace("?", "");
 
                                    string sourceFile = System.IO.Path.Combine(sourcePath, bupload.UploadFileName);
                                    string ModFileName = tblmed.MediaID + ".mp4"; //ModifiedFileName
                                    string destFile = System.IO.Path.Combine(targetPath, ModFileName);
                                    
                                    if (!System.IO.File.Exists(System.IO.Path.Combine(OriginalPath, tblmed.MediaID + System.IO.Path.GetExtension(bupload.UploadFileName))))
                                    {
                                        
                                        System.IO.File.Move(sourceFile, System.IO.Path.Combine(OriginalPath, tblmed.MediaID+ System.IO.Path.GetExtension(bupload.UploadFileName)));
                                    }
                                    else
                                    {
                                        System.IO.File.Delete(sourceFile);
                                    }

                                    bupload.UploadFileName = tblmed.MediaID + System.IO.Path.GetExtension(bupload.UploadFileName);
 
                                    //Write to log
                                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                                    //For Temporary File Handling
                                    string tmpFileName = Path.GetFileNameWithoutExtension(ModFileName);
                                    //Output conversion file

                                    string fileNameBas = strRootDirectory + @"\ffmpeg\tmp\" + tmpFileName + ".bat";
                                    // Check if file already exists. If yes, delete it.     
                                    if (System.IO.File.Exists(fileNameBas))
                                    {
                                        System.IO.File.Delete(fileNameBas);
                                    }

                                    var enddatetime = DateTime.Now;
                                    tblmed.Video = bupload.UploadFileName;
                                    tblmed.uploadstartdatetime = startdatetime;
                                    tblmed.uploadenddatetime = enddatetime;
                                    Updateuploadstartenddatetime(tblmed);

                                    //Move Orginal file to Backup folder when web.config videosrccbackup=true
                                    string videosrccbackup = "";
                                    try
                                    {
                                        videosrccbackup = System.Configuration.ConfigurationManager.AppSettings["videosrccbackup"];
                                    }
                                    catch
                                    {

                                    }

                                    FileInfo fileFfmpeg = new FileInfo(fileNameBas);
                                    using (StreamWriter sw = fileFfmpeg.CreateText())
                                    {



                                        System.IO.FileInfo fiOrig = new System.IO.FileInfo(strRootDirectory + @"\originalmedia\" + bupload.UploadFileName);
                                        string sourceFileLoc = System.IO.Path.Combine(OriginalPath, bupload.UploadFileName);//System.IO.Path.Combine(sourcePath, bupload.UploadFileName);
                                        string destFile_0 = System.IO.Path.Combine(targetPath, ModFileName);
                                        string destFile_1 = System.IO.Path.Combine(targetPath, System.IO.Path.GetFileNameWithoutExtension(bupload.UploadFileName) + "-1.mp4");
                                        string destFile_2 = System.IO.Path.Combine(targetPath, System.IO.Path.GetFileNameWithoutExtension(bupload.UploadFileName) + "-2.mp4");

                                        string outputResultFile = strRootDirectory + @"ffmpeg\tmp\" + tmpFileName + ".txt";
                                        string outputResultFile_0 = strRootDirectory + @"ffmpeg\tmp\" + tmpFileName + "_0.txt";
                                        string outputResultFile_1 = strRootDirectory + @"ffmpeg\tmp\" + tmpFileName + "_1.txt";
                                        string outputResultFile_2 = strRootDirectory + @"ffmpeg\tmp\" + tmpFileName + "_2.txt";


                                        swMaster.WriteLine("chcp 65001");
                                        swMaster.WriteLine("call " + strRootDirectory + @"\ffmpeg\tmp\" + tmpFileName);

                                        //Setting Path
                                        sw.WriteLine("chcp 65001");
                                        sw.WriteLine("SET PATH=%PATH%;" + strRootDirectory + @"\ffmpeg\bin");
                                        //For file conversion to MP4
                                          if (System.IO.Path.GetExtension(bupload.UploadFileName).ToLower() == ".wmv" || System.IO.Path.GetExtension(bupload.UploadFileName).ToLower() == ".vob" || System.IO.Path.GetExtension(bupload.UploadFileName).ToLower() == ".mts" || System.IO.Path.GetExtension(bupload.UploadFileName).ToLower() == ".mpg" || System.IO.Path.GetExtension(bupload.UploadFileName).ToLower() == ".mpeg" || System.IO.Path.GetExtension(bupload.UploadFileName).ToLower() == ".avi")
                                        {
                                            sw.WriteLine("ffmpeg -y -i " + sourceFile + " -level 40 -crf 25 -ab 96000 -movflags faststart " + destFile_0 + " 2>>" + outputResultFile);
                                            sw.WriteLine("ffmpeg -y -i " + sourceFile + " -level 40 -crf 30 -s 864x486 -ab 48000 -maxrate 250000 -bufsize 250000 -movflags faststart " + destFile_1 + " 2>>" + outputResultFile);
                                            sw.WriteLine("ffmpeg -y -i " + sourceFile + " -level 40 -crf 27 -s 1280x720 -ab 64000 -maxrate 1000000 -bufsize 1000000 -movflags faststart " + destFile_2 + " 2>>" + outputResultFile);
                                        }
                                        else
                                        {
                                            sw.WriteLine("ffmpeg -y -i " + sourceFileLoc + " -vcodec libx264 -level 40 -crf 25 -acodec copy -ab 96000 -movflags faststart " + destFile_0 + " 2>>" + outputResultFile);
                                            sw.WriteLine("ffmpeg -y -i " + sourceFileLoc + " -vcodec libx264 -level 40 -crf 30 -s 864x486 -acodec copy -ab 48000 -maxrate 250000 -bufsize 250000 -movflags faststart " + destFile_1 + " 2>>" + outputResultFile);
                                            sw.WriteLine("ffmpeg -y -i " + sourceFileLoc + " -vcodec libx264 -level 40 -crf 27 -s 1280x720 -acodec copy -ab 64000 -maxrate 1000000 -bufsize 1000000 -movflags faststart " + destFile_2 + " 2>>" + outputResultFile);
                                        }



 
                                        // Finally delete the batch file once the execution is completed
                                        sw.WriteLine("del " + fileNameBas);
                                        sw.WriteLine("exit");
                                        sw.Close();
                                    }
                                }
                            }
                        }
                    }
                    //Finally the master batch file must delete from the system. 
                    swMaster.WriteLine("Del " + strRootDirectory + @"ffmpeg\tmp\" + strBatchFile);
                    swMaster.WriteLine("exit");
                    //Master Batch File Execution
                    swMaster.Close();
                    //*******************************************************
                    if (IsBatchProcesing == true)
                    {
                        //Intialize Thread class
                        ThreadProcess thProcess = new ThreadProcess();
                        //Assing Batch Task to thread                       
                        Thread job = new Thread(() => thProcess.ThreadTask(strRootDirectory + @"ffmpeg\tmp\" + strBatchFile));
                        //Start the batch job
                        job.Start();
                        //Inform to the user that video conversion is under process..
                        TempData["SuccMsg"] = MujiStore.Resources.Resource.CntVideoDemoCreateFtpvideoSuccMsg;
                    }
                    else
                    {
                        //No Batch Processing, delete the file
                        fileMasterBatch = new System.IO.FileInfo(strRootDirectory + @"ffmpeg\tmp\" + strBatchFile);
                        if (fileMasterBatch.Exists)
                        {
                            fileMasterBatch.Delete();
                        }

                    }

                }
                return Redirect("Index");
            }
            catch (Exception ex)
            {
                //Write exception to log
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                //To know about the error to the user
                TempData["ErrMsg"] = MujiStore.Resources.Resource.CntVideoDemoCreateFtpvideoErrMsg2;
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }



        


        public ActionResult Create(int? page)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                List<SelectListItem> lstFolderName = new List<SelectListItem>();
                lstFolderName = BLL.CommonLogic.FillFolderList();
  
                ViewBag.FolderList = new SelectList(lstFolderName, "Value", "Text");
                tblMedia tblVideoDemo = new tblMedia();
                tblVideoDemo.VideoPlayStartDate = DateTime.Now;
  
                ViewBag.Page = page;
                TempData["Page"] = page;
                return View(tblVideoDemo);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

        }
       
        // POST: VideoDemo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblMedia _tblVideoDemo)
        {
            //Write to Log
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                //Populate Folder
                var startdatetime = DateTime.Now;

                List<SelectListItem> lstFolderName = new List<SelectListItem>();
                lstFolderName = BLL.CommonLogic.FillFolderList();

                ViewBag.FolderList = new SelectList(lstFolderName, "Value", "Text");
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                var errors1 = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
                //Verify the model state
                if (ModelState.IsValid == false)
                {
                    return View(_tblVideoDemo);
                }
  
                if (_tblVideoDemo.VideoPlayEndDate != DateTime.MinValue)
                {
                    if (_tblVideoDemo.VideoPlayStartDate > _tblVideoDemo.VideoPlayEndDate)
                    {
                        ModelState.AddModelError("VideoPlayStartDate", MujiStore.Resources.Resource.dateval);
                        return View(_tblVideoDemo);
                    }
                }
  
                //File must be selected
                if (_tblVideoDemo.PostedFile != null)
                {
                    //Root Path
                    //Assign File name to object 
                    _tblVideoDemo.Video = _tblVideoDemo.PostedFile.FileName;
                    _tblVideoDemo.FileSize = 0;
                    _tblVideoDemo.Duration = 0;
                    _tblVideoDemo.ConvertStatus = 0;  //0 Not Converted 3 Converted
                    _tblVideoDemo.UploadType = "B"; //B - indicate Browser
                                                    //Update video information to the database
                    int result = InsertMediaFile(_tblVideoDemo);
                    _tblVideoDemo.MediaID = result;

                    String strRootDirectory = Server.MapPath("~/"); 
  
                    string sourcePath = strRootDirectory + @"\originalmedia";
                    string targetPath = strRootDirectory + @"\Video";
                    //Original File Name conver to sequance file name
 
                    Regex rgx = new Regex("[`~@#%&!$*()+={[}:',<>/]");
                    string strfname = rgx.Replace(_tblVideoDemo.PostedFile.FileName, "");
  
                    var fileName = _tblVideoDemo.MediaID + System.IO.Path.GetExtension(_tblVideoDemo.PostedFile.FileName);
  
                    var fileNameTmp = Path.Combine(Server.MapPath("~/originalmedia"), fileName);
 
                    _tblVideoDemo.PostedFile.SaveAs(fileNameTmp);
                    var enddatetime = DateTime.Now;
                    //Batch Processing Flag
                    Boolean IsBatchProcesing = false;

                    System.IO.FileInfo fi = new System.IO.FileInfo(strRootDirectory + @"\originalmedia\" + fileName);
                    string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                    string ModFileName = System.IO.Path.GetFileNameWithoutExtension(fileName) + ".mp4";
                    string destFile_0 = System.IO.Path.Combine(targetPath, ModFileName);
                    string destFile_1 = System.IO.Path.Combine(targetPath, System.IO.Path.GetFileNameWithoutExtension(fileName)+ "-1.mp4");
                    string destFile_2 = System.IO.Path.Combine(targetPath, System.IO.Path.GetFileNameWithoutExtension(fileName) + "-2.mp4");
                    if (fi.Exists)
                    {
                        //Assign true for batch processing 
                        IsBatchProcesing = true;
                        //Intialize File

                        _tblVideoDemo.Video = fileName;
                        _tblVideoDemo.uploadstartdatetime = startdatetime;
                        _tblVideoDemo.uploadenddatetime = enddatetime;
                        Updateuploadstartenddatetime(_tblVideoDemo);

                        //Write to log
                        CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    }
                        //Batch FileName
                    string strBatchFile = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".bat";
                    //Master Batch File
                    FileInfo fileMasterBatch = new FileInfo(strRootDirectory + @"ffmpeg\tmp\" + strBatchFile);
                    using (StreamWriter swMaster = fileMasterBatch.CreateText())
                    {
         
                        if (fi.Exists)
                        {
                            
                            //For Temporary File Handling
                            string tmpFileName = Path.GetFileNameWithoutExtension(ModFileName);
                            //Output conversion file
                            string outputResultFile = strRootDirectory + @"ffmpeg\tmp\" + tmpFileName + ".txt";
                            string outputResultFile_0 = strRootDirectory + @"ffmpeg\tmp\" + tmpFileName + "_0.txt";
                            string outputResultFile_1 = strRootDirectory + @"ffmpeg\tmp\" + tmpFileName + "_1.txt";
                            string outputResultFile_2 = strRootDirectory + @"ffmpeg\tmp\" + tmpFileName + "_2.txt";

                            string fileNameBas = strRootDirectory + @"\ffmpeg\tmp\" + tmpFileName + ".bat";
                            // Check if file already exists. If yes, delete it.     
                            if (System.IO.File.Exists(fileNameBas))
                            {
                                System.IO.File.Delete(fileNameBas);
                            }

                            //Move Orginal file to Backup folder when web.config videosrccbackup=true
                            string videosrccbackup = "";
                            try
                            {
                                videosrccbackup = System.Configuration.ConfigurationManager.AppSettings["videosrccbackup"];
                            }
                            catch
                            {

                            }
                            FileInfo fileFfmpeg = new FileInfo(fileNameBas);
                            using (StreamWriter sw = fileFfmpeg.CreateText())
                            {
                                //Write to Master Batch File
                                swMaster.WriteLine("chcp 65001");
                                swMaster.WriteLine("call " + strRootDirectory + @"\ffmpeg\tmp\" + tmpFileName);
                                //Setting Path
                                sw.WriteLine("chcp 65001");
                                sw.WriteLine("SET PATH=%PATH%;" + strRootDirectory + @"\ffmpeg\bin");
        
                                if (System.IO.Path.GetExtension(fileName).ToLower() == ".wmv" || System.IO.Path.GetExtension(fileName).ToLower() == ".vob" || System.IO.Path.GetExtension(fileName).ToLower() == ".mts" || System.IO.Path.GetExtension(fileName).ToLower() == ".mpg" || System.IO.Path.GetExtension(fileName).ToLower() == ".mpeg" || System.IO.Path.GetExtension(fileName).ToLower() == ".avi")
                                {
                                    sw.WriteLine("ffmpeg -y -i " + sourceFile + " -level 40 -crf 25 -ab 96000 -movflags faststart " + destFile_0 + " 2>>" + outputResultFile);
                                    sw.WriteLine("ffmpeg -y -i " + sourceFile + " -level 40 -crf 30 -s 864x486 -ab 48000 -maxrate 250000 -bufsize 250000 -movflags faststart " + destFile_1 + " 2>>" + outputResultFile);
                                    sw.WriteLine("ffmpeg -y -i " + sourceFile + " -level 40 -crf 27 -s 1280x720 -ab 64000 -maxrate 1000000 -bufsize 1000000 -movflags faststart " + destFile_2 + " 2>>" + outputResultFile);
                                }
                                else
                                {
                                    sw.WriteLine("ffmpeg -y -i " + sourceFile + " -vcodec libx264 -level 40 -crf 25 -acodec copy -ab 96000 -movflags faststart " + destFile_0 + " 2>>" + outputResultFile);
                                    sw.WriteLine("ffmpeg -y -i " + sourceFile + " -vcodec libx264 -level 40 -crf 30 -s 864x486 -acodec copy -ab 48000 -maxrate 250000 -bufsize 250000 -movflags faststart " + destFile_1 + " 2>>" + outputResultFile);
                                    sw.WriteLine("ffmpeg -y -i " + sourceFile + " -vcodec libx264 -level 40 -crf 27 -s 1280x720 -acodec copy -ab 64000 -maxrate 1000000 -bufsize 1000000 -movflags faststart " + destFile_2 + " 2>>" + outputResultFile);
                                }


                                // Finally delete the batch file once the execution is completed
                                sw.WriteLine("del " + fileNameBas);
                                sw.WriteLine("exit");
                                sw.Close();
                            }
                        }
                        //Finally the master batch file must delete from the system. 
                        swMaster.WriteLine("Del " + strRootDirectory + @"ffmpeg\tmp\" + strBatchFile);
                        swMaster.WriteLine("exit");
                        //Master Batch File Execution
                        swMaster.Close();
                        //*******************************************************
                        if (IsBatchProcesing == true)
                        {
                            //Intialize Thread class
                            ThreadProcess thProcess = new ThreadProcess();
                            //Assing Batch Task to thread    
                            Thread job = new Thread(() => thProcess.ThreadTask(strRootDirectory + @"ffmpeg\tmp\" + strBatchFile));
                            //Start the batch job
                            job.Start();
                            //Inform to the user that video conversion is under process..
                            TempData["SuccMsg"] = MujiStore.Resources.Resource.CntVideoDemoCreateSuccMsg;
                        }
                        else
                        {
                            //No Batch Processing, delete the file
                            fileMasterBatch = new System.IO.FileInfo(strRootDirectory + @"ffmpeg\tmp\" + strBatchFile);
                            if (fileMasterBatch.Exists)
                            {
                                fileMasterBatch.Delete();
                            }

                        }

                    }
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.CntVideoDemoCreateSuccMsg;
                    return RedirectToAction("Index", new { page = TempData["Page"] });
                }
                TempData["ErrMsg"] = MujiStore.Resources.Resource.CntVideoDemoCreateErrMsg;
                return View(_tblVideoDemo);
            }

            catch (Exception ex)
            {
                //Write exception to log
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                //To know about the error to the user
                TempData["ErrMsg"] = MujiStore.Resources.Resource.CntVideoDemoCreateErrMsg;
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create1(tblMedia _tblVideoDemo)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                // PopulateFolder();
                List<SelectListItem> lstFolderName = new List<SelectListItem>();
                lstFolderName = BLL.CommonLogic.FillFolderList();

                ViewBag.FolderList = new SelectList(lstFolderName, "Value", "Text");
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                var errors1 = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
                if (ModelState.IsValid == false)
                {
                    return View(_tblVideoDemo);
                }
                if (_tblVideoDemo.PostedFile != null)
                {
                    //Original File Name
                    var fileName = CommonLogic.ModifiedFileName(_tblVideoDemo.PostedFile.FileName);
                    //Temporary 
                    var fileNameTmp = Path.Combine(Server.MapPath("~/FtpVideo"), fileName);
                    LogInfo.Comments = "Video Created - " + _tblVideoDemo.Title.ToString();
                    //For store uploaded file 
                    _tblVideoDemo.PostedFile.SaveAs(fileNameTmp);
                    //*****************************************
                    //File Conversion to MP4
                    //Begin
                    String strRootDirectory = Server.MapPath("~/");
                    string sourcePath = strRootDirectory + @"\FtpVideo";
                    string targetPath = strRootDirectory + @"\Video";
                    string sourceFile = fileNameTmp;
                    string ModFileName = CommonLogic.GetFileNameActualMp4(fileName); //ModifiedFileName
                    string destFile = System.IO.Path.Combine(targetPath, ModFileName);
                    //For Temporary File Handling
                    string tmpFileName = ModFileName;
                    tmpFileName = tmpFileName.Replace(".", ""); //Remove . with extension
                    //Output conversion file
                    string outputResultFile = strRootDirectory + @"ffmpeg\tmp\" + tmpFileName + ".txt";
                    string fileNameBas = strRootDirectory + @"\ffmpeg\tmp\" + tmpFileName + ".bat";
                    // Check if file already exists. If yes, delete it.     
                    if (System.IO.File.Exists(fileNameBas))
                    {
                        System.IO.File.Delete(fileNameBas);
                    }
                    FileInfo fileFfmpeg = new FileInfo(fileNameBas);
                    using (StreamWriter sw = fileFfmpeg.CreateText())
                    {
                        //Setting Path
                        sw.WriteLine("chcp 65001");
                        sw.WriteLine("SET PATH=%PATH%;" + strRootDirectory + @"\ffmpeg\bin");
                        //For file conversion to MP4
                        sw.WriteLine("ffmpeg -i " + sourceFile + " -c:a aac -b:a 128k -c:v libx264 -crf 23 " + destFile + " 2>" + outputResultFile);
                    }
                    System.Diagnostics.ProcessStartInfo p = new System.Diagnostics.ProcessStartInfo(fileNameBas);
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.CreateNoWindow = true;
                    proc.StartInfo = p;
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.Start();
                    proc.WaitForExit();
                    //Batch File End

                    //Reading File Duration and Size
                    //Sample  Duration: 00:00:11.83, start: 0.000000, bitrate: 1011 kb/s
                    string strTextLine;
                    int durationIndex = -1;
                    int fileDuration = 0;
                    System.IO.StreamReader file = null;
                    try
                    {
                        file = new System.IO.StreamReader(@outputResultFile);
                        while ((strTextLine = file.ReadLine()) != null)
                        {
                            durationIndex = strTextLine.IndexOf("Duration: ");
                            if (durationIndex >= 0)
                            {
                                string[] durationLine = strTextLine.Split(',');
                                StringBuilder sbDuration = new StringBuilder(durationLine[0]); //0 Duration, 1 start 2 bitrate
                                sbDuration.Replace("Duration: ", "");
                                sbDuration.Replace(" ", "");
                                sbDuration.Replace(".", ":");
                                //Convert String;
                                String strTmp = sbDuration.ToString();
                                string[] durationDelimiter = strTmp.Split(':');
                                // 0 hours 1 minutes 2 seconds 3 millisecond
                                int intHours = Int32.Parse(durationDelimiter[0]);
                                int intMinutes = Int32.Parse(durationDelimiter[1]);
                                int intSeconds = Int32.Parse(durationDelimiter[2]);
                                fileDuration = (intHours * 3600) + (intMinutes * 60) + intSeconds; //millisecond not included
                                break;
                            }
                        }
                    }
                    catch { }
                    finally
                    {
                        file.Close();
                    }

                    //Reading for FileSize in  file itself
                    System.IO.FileInfo fi;
                    fi = new FileInfo(destFile);
                    // Get file size  
                    long fileSize = fi.Length / 1024;

                    //Move Orginal file to Backup folder when web.config videosrccbackup=true
                    string videosrccbackup = "";
                    try
                    {
                        videosrccbackup = System.Configuration.ConfigurationManager.AppSettings["videosrccbackup"];
                    }
                    catch
                    {

                    }
                    if (videosrccbackup == "true")
                    {
                        System.IO.File.Move(sourceFile, strRootDirectory + @"ffmpeg\tmp\backup\" + fileName);
                    }
                    else
                    {
                        fi = new System.IO.FileInfo(sourceFile);
                        if (fi.Exists)
                        {
                            fi.Delete();
                        }
                    }
                    //Delete Temporary Handled File
                    //Output File
                    fi = new System.IO.FileInfo(outputResultFile);
                    if (fi.Exists)
                    {
                        fi.Delete();
                    }
                    //Batch File Delete
                    fi = new System.IO.FileInfo(fileNameBas);
                    if (fi.Exists)
                    {
                        fi.Delete();
                    }
                    //End of File Conversion
                    //*****************************************

                    _tblVideoDemo.Video = ModFileName;
                    _tblVideoDemo.FileSize = fileSize;
                    _tblVideoDemo.Duration = fileDuration;
                    _tblVideoDemo.ConvertStatus = 3;  //0 Not Converted 3 Converted //VJ 20200603 ConvertStatus 3 Converted  Changed
                    _tblVideoDemo.UploadType = "B";
                    
                    //Comment on 20200331
                    int result = InsertMediaFile(_tblVideoDemo);
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.CntVideoDemoCreate1SuccMsg;
                    return RedirectToAction("Index");
                }
                //}





                TempData["ErrMsg"] = MujiStore.Resources.Resource.CntVideoDemoCreateErrMsg;
                return View(_tblVideoDemo);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = MujiStore.Resources.Resource.CntVideoDemoCreateErrMsg;
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

        }
      

        /// <summary>
        /// Update about filesize, duration and video conversion status
        /// </summary>
        /// <param name="_tblVideoDemo"></param>
        /// <returns></returns>
        public int UpdateConvertedStatusMediaFile(tblMedia _tblVideoDemo)
        {
            int result;
            System.IO.FileInfo fi = null;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string query = "";
                con.Open();
                SqlCommand cmd;
 
                //Assing Query String
                query = "UPDATE tblMedia SET FileSize=@FileSize,ConvertStatus=@ConvertStatus,Duration=@Duration,";
                 query +="streamingconstartdatetime = @streamingconstartdatetime,streamingconenddatetime = @streamingconenddatetime where MediaID =@MediaID; ";
                //Intialize Command and pass the paramters
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FileSize", _tblVideoDemo.FileSize);
                cmd.Parameters.AddWithValue("@ConvertStatus", _tblVideoDemo.ConvertStatus);
                cmd.Parameters.AddWithValue("@Duration", _tblVideoDemo.Duration);
                cmd.Parameters.AddWithValue("@streamingconstartdatetime", _tblVideoDemo.streamingconstartdatetime);
                cmd.Parameters.AddWithValue("@streamingconenddatetime", _tblVideoDemo.streamingconenddatetime);
                cmd.Parameters.AddWithValue("@MediaID", _tblVideoDemo.MediaID);
                cmd.CommandType = CommandType.Text;
                result = cmd.ExecuteNonQuery();

 

                query = "";
                query = "UPDATE tblMediaFormatInfo SET FileSize=@FileSize where MediaID=@MediaID; ";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MediaID", _tblVideoDemo.MediaID);
                cmd.Parameters.AddWithValue("@FileSize", _tblVideoDemo.FileSize);
                cmd.CommandType = CommandType.Text;
                result = cmd.ExecuteNonQuery();

  
                String strRootDirectory = Server.MapPath("~/");
                fi = new System.IO.FileInfo(strRootDirectory + @"\Video\" + _tblVideoDemo.MediaID + "-1.mp4");
                
                if (fi.Exists)
                {

                    tblMediaFormatInfo medidformt = new tblMediaFormatInfo();
                    medidformt = db.tblMediaFormatInfoes.Where(x => x.MediaID  == _tblVideoDemo.MediaID && x.FormatID == 1).SingleOrDefault();
                    if (medidformt == null)
                    {
                        long fileSize = fi.Length / 1024;
                        query = "insert into tblMediaFormatInfo";
                        query += " (MediaID,FormatID,FileSize,DELFG,CRTDT,CRTCD,IPAddress) ";
                        query += " values ";
                        query += " (@MediaID,@FormatID,@FileSize,@DELFG,@CRTDT,@CRTCD,@IPAddress) ";
                        //Intialize Command and pass the paramters
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@MediaID", _tblVideoDemo.MediaID);
                        cmd.Parameters.AddWithValue("@FormatID", 1);
                        cmd.Parameters.AddWithValue("@FileSize", fileSize);
                        cmd.Parameters.AddWithValue("@DELFG", false);
                        cmd.Parameters.AddWithValue("@CRTCD", Session["UserName"].ToString());
                        cmd.Parameters.AddWithValue("@CRTDT", DateTime.Now);
                        cmd.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());

                        cmd.CommandType = CommandType.Text;
                        result = cmd.ExecuteNonQuery();
                    }

 
                    

                }
                fi = new System.IO.FileInfo(strRootDirectory + @"\Video\" + _tblVideoDemo.MediaID + "-2.mp4");
                if (fi.Exists)
                {

                    tblMediaFormatInfo medidformt = new tblMediaFormatInfo();
                    medidformt = db.tblMediaFormatInfoes.Where(x => x.MediaID == _tblVideoDemo.MediaID && x.FormatID == 2).SingleOrDefault();
                    if (medidformt == null)
                    {
                        long fileSize = fi.Length / 1024;
                        query = "insert into tblMediaFormatInfo";
                        query += " (MediaID,FormatID,FileSize,DELFG,CRTDT,CRTCD,IPAddress) ";
                        query += " values ";
                        query += " (@MediaID,@FormatID,@FileSize,@DELFG,@CRTDT,@CRTCD,@IPAddress) ";
                        //Intialize Command and pass the paramters
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@MediaID", _tblVideoDemo.MediaID);
                        cmd.Parameters.AddWithValue("@FormatID", 2);
                        cmd.Parameters.AddWithValue("@FileSize", fileSize);
                        cmd.Parameters.AddWithValue("@DELFG", false);
                        cmd.Parameters.AddWithValue("@CRTCD", Session["UserName"].ToString());
                        cmd.Parameters.AddWithValue("@CRTDT", DateTime.Now);
                        cmd.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());

                        cmd.CommandType = CommandType.Text;
                        result = cmd.ExecuteNonQuery();
                    }

 
                }
            }
            return result;
        }

        public int InsertDeployStatus(tblDeployStatu _tblDeployStatus)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string query = "";
               
               
                con.Open();
                SqlCommand cmd;
                SqlTransaction transaction;
                // Start a local transaction.
                transaction = con.BeginTransaction("SampleTransaction");
                //cmd.Connection = con;
                try
                {
                    
                    // string query = "";
                    query = "Insert into tblDeployStatus(DSServer,MediaID,FormatID,IsExists,DateTime,DELFG,CRTDT,CRTCD,UserIPAddress) Values ";
                    query += "(@DSServer,@MediaID,@FormatID,@IsExists,@DateTime,@DELFG,@CRTDT,@CRTCD,@UserIPAddress);";
 
                    cmd = new SqlCommand(query, con);
                    cmd.Transaction = transaction;
                    cmd.Parameters.AddWithValue("@DSServer", _tblDeployStatus.DSServer);
                    cmd.Parameters.AddWithValue("@MediaID", _tblDeployStatus.MediaID);
                    cmd.Parameters.AddWithValue("@FormatID", _tblDeployStatus.FormatID);
                    cmd.Parameters.AddWithValue("@IsExists", _tblDeployStatus.IsExists);
                    cmd.Parameters.AddWithValue("@DateTime", _tblDeployStatus.DateTime);
                    cmd.Parameters.AddWithValue("@DELFG", _tblDeployStatus.DELFG);
                    cmd.Parameters.AddWithValue("@CRTCD", _tblDeployStatus.CRTCD);
                    cmd.Parameters.AddWithValue("@CRTDT", _tblDeployStatus.CRTDT);
                    cmd.Parameters.AddWithValue("@UserIPAddress", _tblDeployStatus.UserIPAddress);

                    cmd.CommandType = CommandType.Text;

                    result = cmd.ExecuteNonQuery();
                    //  CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);


                    query = "";
                    query = "Insert into tblDeployLog(Server,MediaID,FormatID,ElapsedTime,CopiedBytes,Result,DELFG,CRTDT,CRTCD,IPAddress,DateTime) Values ";
                    query += "(@Server,@MediaID,@FormatID,@ElapsedTime,@CopiedBytes,@Result,@DELFG,@CRTDT,@CRTCD,@IPAddress,@DateTime);";
                    cmd = new SqlCommand(query, con);
                    cmd.Transaction = transaction;
                    cmd.Parameters.AddWithValue("@Server", _tblDeployStatus.DSServer);
                    cmd.Parameters.AddWithValue("@MediaID", _tblDeployStatus.MediaID);
                    cmd.Parameters.AddWithValue("@FormatID", _tblDeployStatus.FormatID);
                    cmd.Parameters.AddWithValue("@ElapsedTime",Convert.ToInt32(_tblDeployStatus.Duration));
                    cmd.Parameters.AddWithValue("@CopiedBytes", Convert.ToInt32(_tblDeployStatus.FileSize));
                    cmd.Parameters.AddWithValue("@Result", _tblDeployStatus.Result);
                    cmd.Parameters.AddWithValue("@DELFG", _tblDeployStatus.DELFG);
                    cmd.Parameters.AddWithValue("@CRTCD", _tblDeployStatus.CRTCD);
                    cmd.Parameters.AddWithValue("@CRTDT", _tblDeployStatus.CRTDT);
                    cmd.Parameters.AddWithValue("@IPAddress", _tblDeployStatus.UserIPAddress);
                    cmd.Parameters.AddWithValue("@DateTime", _tblDeployStatus.CRTDT);

                    cmd.CommandType = CommandType.Text;

                    result = cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                    Log.Error(LogInfo.LogMsg, ex);
                }

            }
            return result;
        }

        public int UpdateDeployStatus(tblDeployStatu _tblDeployStatus)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string query = "";


                con.Open();
                SqlCommand cmd;
                SqlTransaction transaction;
                // Start a local transaction.
                transaction = con.BeginTransaction("SampleTransaction");
 
                try
                {
                    
                    query = "Update tblDeployStatus set FormatID=@FormatID,IsExists=@IsExists,DateTime=@DateTime,";
                    query += "DELFG=@DELFG,UPDDT=@UPDDT,UPDCD=@UPDCD,UserIPAddress=@UserIPAddress";
                    query += " Where DeployStatusID=@DeployStatusID";

                    cmd = new SqlCommand(query, con);
                    cmd.Transaction = transaction;
                    cmd.Parameters.AddWithValue("@FormatID", _tblDeployStatus.FormatID);
                    cmd.Parameters.AddWithValue("@IsExists", _tblDeployStatus.IsExists);
                    cmd.Parameters.AddWithValue("@DateTime", _tblDeployStatus.DateTime);
                    cmd.Parameters.AddWithValue("@DELFG", _tblDeployStatus.DELFG);
                    cmd.Parameters.AddWithValue("@UPDDT", _tblDeployStatus.UPDDT);
                    cmd.Parameters.AddWithValue("@UPDCD", _tblDeployStatus.UPDCD);
                    cmd.Parameters.AddWithValue("@UserIPAddress", _tblDeployStatus.UserIPAddress);
                    cmd.Parameters.AddWithValue("@DeployStatusID", _tblDeployStatus.DeployStatusID);
                    cmd.CommandType = CommandType.Text;
                    
                    result = cmd.ExecuteNonQuery();

                    query = "";
                    query = "Update tblDeployLog set DELFG=@DELFG,UPDDT=@UPDDT,UPDCD=@UPDCD";
                    if (_tblDeployStatus.DELFG == false)
                    {
                        query += ",Result = @Result";
                    }
                    query += ",IPAddress=@IPAddress";
                    query += " Where DeployLogID=@DeployLogID ";

                    cmd = new SqlCommand(query, con);
                    cmd.Transaction = transaction;
                    cmd.Parameters.AddWithValue("@DeployLogID", _tblDeployStatus.DeployLogID);
                    if (_tblDeployStatus.DELFG == false)
                    {
                        cmd.Parameters.AddWithValue("@Result", _tblDeployStatus.Result);
                    }
                    cmd.Parameters.AddWithValue("@DELFG", _tblDeployStatus.DELFG);
                    cmd.Parameters.AddWithValue("@UPDDT", _tblDeployStatus.UPDDT);
                    cmd.Parameters.AddWithValue("@UPDCD", _tblDeployStatus.UPDCD);
                    cmd.Parameters.AddWithValue("@IPAddress", _tblDeployStatus.UserIPAddress);
                    cmd.CommandType = CommandType.Text;
               
                    result = cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                    Log.Error(LogInfo.LogMsg, ex);
                }
            }
  
            return result;
        }
        public int GetFormatID(string formatName)
        {
            int result = 0;
            
              string  query = "select formatid from tblFormat where Name= @formatName";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@formatName", formatName);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {

                            result = Convert.ToInt32(sdr["formatid"]);
                            
                        }
                    }
                    con.Close();

                }
            
            return result;
        }
        public tblMedia GetMediaDetails(int mediaID, string video, bool delflag)
        {
            tblMedia medDtl = new tblMedia();
            string query = "";
            if (mediaID == 0)
            {
                query = "select top 1 MediaID from tblmedia where Video= @Video Order by MediaID Desc ";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Video", video);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            
                            medDtl.MediaID = Convert.ToInt32(sdr["MediaID"]);
                            medDtl.Video = video;
    
                        }
                    }
                    con.Close();

                }
            }
            else if (mediaID > 0 && delflag == true)
            {
                query = "select Video from tblmedia where MediaID= @MediaID ";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@MediaID", mediaID);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            medDtl.Video = sdr["Video"].ToString();
                            medDtl.MediaID = mediaID;
  
                        }
                    }
                    con.Close();

                }
            }
            else if (mediaID > 0 && delflag == false)
            {

                query = "select MediaID,Title,Description, ";
                query += " convert(varchar,MediaID)+'-1.mp4' Video,Thumbnail,tblmedia.IpAddress, ";
                query += " FolderID,tblmedia.DELFG,tblmedia.CRTDT,tblmedia.CRTCD,tblmedia.UPDDT,tblmedia.UPDCD,UploadType, ";
                query += " ViewCount,FileSize,U1.UserName Registerer,U2.UserName Accepter,ApprovalStatus, ";
                query += " ConvertStatus,Duration,UploadStartDatetime, ";
                query += " UploadEndDatetime,StreamingConStartDatetime, ";
                query += " StreamingConEndDatetime,VideoPlayStartDate,VideoPlayEndDate ";
                query += " from tblmedia ";
                query += " LEFT JOIN tblUser AS U1 ON tblmedia.Registerer = U1.ID ";
                query += " LEFT JOIN tblUser AS U2 ON tblmedia.Accepter = U2.ID ";
                query += " where MediaID= @MediaID and tblmedia.DELFG = 0 ";


                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@MediaID", mediaID);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            medDtl.MediaID = Convert.ToInt32(sdr["MediaID"]);
                            medDtl.Title = sdr["Title"].ToString();
                            medDtl.Description = sdr["Description"].ToString();
                            medDtl.Video = sdr["Video"].ToString();
                            medDtl.Thumbnail = sdr["Thumbnail"].ToString();
                            medDtl.IpAddress = sdr["IpAddress"].ToString();
                            medDtl.FolderID = Convert.ToInt32(sdr["FolderID"]);
                            medDtl.DELFG = Convert.ToBoolean(sdr["DELFG"]);
                            medDtl.CRTDT = Convert.ToDateTime(sdr["CRTDT"]);
                            medDtl.CRTCD = sdr["CRTCD"].ToString();
                            if (!sdr.IsDBNull(sdr.GetOrdinal("UPDDT")))
                            {
                                medDtl.UPDDT = Convert.ToDateTime(sdr["UPDDT"]);
                                medDtl.UPDCD = sdr["UPDCD"].ToString();
                            }
                            medDtl.UploadType = sdr["UploadType"].ToString();
                            medDtl.ViewCount = Convert.ToInt32(sdr["ViewCount"]);
                            medDtl.FileSize = Convert.ToInt64(sdr["FileSize"]);
                            medDtl.Registerer = sdr["Registerer"].ToString();
                            medDtl.Accepter = sdr["Accepter"].ToString();
                            medDtl.ApprovalStatus = Convert.ToInt32(sdr["ApprovalStatus"]);
                            medDtl.ConvertStatus = Convert.ToInt32(sdr["ConvertStatus"]);
                            medDtl.Duration = Convert.ToInt32(sdr["Duration"]);
                            if (!sdr.IsDBNull(sdr.GetOrdinal("UploadStartDatetime")))
                            {
                                medDtl.uploadstartdatetime = Convert.ToDateTime(sdr["UploadStartDatetime"]);
                            }
                            if (!sdr.IsDBNull(sdr.GetOrdinal("UploadEndDatetime")))
                            {
                                medDtl.uploadenddatetime = Convert.ToDateTime(sdr["UploadEndDatetime"]);
                            }
                            if (!sdr.IsDBNull(sdr.GetOrdinal("StreamingConStartDatetime")))
                            {
                                medDtl.streamingconstartdatetime = Convert.ToDateTime(sdr["StreamingConStartDatetime"]);
                            }
                            if (!sdr.IsDBNull(sdr.GetOrdinal("StreamingConEndDatetime")))
                            {
                                medDtl.streamingconenddatetime = Convert.ToDateTime(sdr["StreamingConEndDatetime"]);
                            }
                            if (!sdr.IsDBNull(sdr.GetOrdinal("VideoPlayStartDate")))
                            {
                                medDtl.VideoPlayStartDate = Convert.ToDateTime(sdr["VideoPlayStartDate"]);
                            }
                            if (!sdr.IsDBNull(sdr.GetOrdinal("VideoPlayEndDate")))
                            {
                                medDtl.VideoPlayEndDate = Convert.ToDateTime(sdr["VideoPlayEndDate"]);
                            }
 
                        }
                    }
                    con.Close();

                }
            }
             
            return medDtl;
        }
        public int InsertMediaFile(tblMedia _tblVideoDemo)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string query = "";
                query = "Insert into tblMedia(Title,Description,Video,IpAddress,FolderID,DELFG,CRTDT,CRTCD,UploadType,ViewCount,FileSize,Registerer,ApprovalStatus,ConvertStatus,Duration,VideoPlayStartDate,VideoPlayEndDate) Values ";
                query += "(@Title,@Description,@Video,@IpAddress,@FolderID,@DELFG,@CRTDT,@CRTCD,@UploadType,@ViewCount,@FileSize,@Registerer,@ApprovalStatus,@ConvertStatus,@Duration,@VideoPlayStartDate,@VideoPlayEndDate); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Title", _tblVideoDemo.Title);
                if (_tblVideoDemo.Description == null)
                {
                    _tblVideoDemo.Description = " ";
                }
                cmd.Parameters.AddWithValue("@Description", _tblVideoDemo.Description);
                cmd.Parameters.AddWithValue("@Video", _tblVideoDemo.Video);
                cmd.Parameters.AddWithValue("@IpAddress", Session["IPAddress"].ToString());
                cmd.Parameters.AddWithValue("@FolderID", _tblVideoDemo.FolderID);
                cmd.Parameters.AddWithValue("@DELFG", false);
                cmd.Parameters.AddWithValue("@CRTCD", Session["UserName"].ToString());
                cmd.Parameters.AddWithValue("@CRTDT", DateTime.Now);
                cmd.Parameters.AddWithValue("@UploadType", _tblVideoDemo.UploadType);
                cmd.Parameters.AddWithValue("@ViewCount", 0);
                //cmd.Parameters.AddWithValue("@PhysicalDELFG", false);
                cmd.Parameters.AddWithValue("@FileSize", _tblVideoDemo.FileSize);
                cmd.Parameters.AddWithValue("@Registerer", Session["UserName"].ToString());
                cmd.Parameters.AddWithValue("@ApprovalStatus", 0);
                cmd.Parameters.AddWithValue("@ConvertStatus", _tblVideoDemo.ConvertStatus);
                cmd.Parameters.AddWithValue("@Duration", _tblVideoDemo.Duration);
                if (_tblVideoDemo.VideoPlayStartDate == null || _tblVideoDemo.VideoPlayStartDate == DateTime.MinValue)
                {
                    cmd.Parameters.AddWithValue("@VideoPlayStartDate", DateTime.Now.ToString("yyyy-MM-dd HH: mm"));
                    
                }
                else
                {
                    cmd.Parameters.AddWithValue("@VideoPlayStartDate", _tblVideoDemo.VideoPlayStartDate);
                }
                if (_tblVideoDemo.VideoPlayEndDate == null || _tblVideoDemo.VideoPlayEndDate == DateTime.MinValue )
                {
                    cmd.Parameters.AddWithValue("@VideoPlayEndDate", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@VideoPlayEndDate", _tblVideoDemo.VideoPlayEndDate);
                }
                cmd.CommandType = CommandType.Text;
                con.Open();
 
                int modified = Convert.ToInt32(cmd.ExecuteScalar());

                tblMedia med = new tblMedia();
                med = GetMediaDetails(modified, string.Empty, true);
                result = med.MediaID;


                string fileName = med.Video;
                FileInfo fi = new FileInfo(fileName);
                string extn = fi.Extension.TrimStart('.');

                tblMediaFormatInfo mfinfo = new tblMediaFormatInfo();
                mfinfo.MediaID = modified;
                mfinfo.FormatID = 0;
                mfinfo.FileSize = _tblVideoDemo.FileSize;
                mfinfo.DELFG = false;
                mfinfo.CRTCD = Session["UserName"].ToString();
                mfinfo.CRTDT = DateTime.Now;
                mfinfo.IPAddress = Session["IPAddress"].ToString();
                db.tblMediaFormatInfoes.Add(mfinfo);
                db.SaveChanges();



            }


            return result;
        }

        public int InsertMediaApplication(tblMedia _tblVideoDemo, bool ImageUpd)
        {
            int result = 0;
            try
            {
               
                string query = "";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    if (ImageUpd == true)
                    {
                        query = "  Update tblMedia set Thumbnail=@Thumbnail,IpAddress=@IpAddress,UPDDT=@UPDDT,UPDCD=@UPDCD";
                        query += " Where MediaID=@MediaID";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Thumbnail", _tblVideoDemo.Thumbnail== null ? "" : _tblVideoDemo.Thumbnail);
                        cmd.Parameters.AddWithValue("@UPDDT", DateTime.Now);
                        cmd.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                        cmd.Parameters.AddWithValue("@IpAddress", Session["IPAddress"].ToString());
                        cmd.Parameters.AddWithValue("@MediaID", _tblVideoDemo.MediaID);
 
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        result = cmd.ExecuteNonQuery();
                        con.Close();
                    }
 
                        query = "";
                        query = "Insert into tblApplication(MediaID,Title,Description,FolderID,NewApprovalStatus,[Delete],Registerer,Memo,RegisteredDate,DELFG,CRTDT,CRTCD,IPAddress,VideoPlayStartDate,VideoPlayEndDate) Values ";
                        query += "(@MediaID,@Title,@Description,@FolderID,@ApprovalStatus,@PhysicalDELFG,@Registerer,@Memo,@RegisteredDate,@DELFG,@CRTDT,@CRTCD,@IpAddress,@VideoPlayStartDate,@VideoPlayEndDate); SELECT SCOPE_IDENTITY();";
 
                        SqlCommand cmdApp = new SqlCommand(query, con);
                        cmdApp.Parameters.AddWithValue("@MediaID", _tblVideoDemo.MediaID);
                        cmdApp.Parameters.AddWithValue("@Title", _tblVideoDemo.Title);
                        if(_tblVideoDemo.Description == null)
                        {
                            _tblVideoDemo.Description = " ";
                        }
                        cmdApp.Parameters.AddWithValue("@Description", _tblVideoDemo.Description);
                        cmdApp.Parameters.AddWithValue("@FolderID", _tblVideoDemo.FolderID);
                        cmdApp.Parameters.AddWithValue("@ApprovalStatus", _tblVideoDemo.ApprovalStatus);
                        cmdApp.Parameters.AddWithValue("@PhysicalDELFG", _tblVideoDemo.PhysicalDELFG);
                        cmdApp.Parameters.AddWithValue("@Registerer", Session["UserName"].ToString());
                        cmdApp.Parameters.AddWithValue("@Memo", _tblVideoDemo.Comments == null ? "" : _tblVideoDemo.Comments);
                        cmdApp.Parameters.AddWithValue("@RegisteredDate", DateTime.Now);
                        cmdApp.Parameters.AddWithValue("@DELFG", false);
                        cmdApp.Parameters.AddWithValue("@CRTCD", Session["UserName"].ToString());
                        cmdApp.Parameters.AddWithValue("@CRTDT", DateTime.Now);
                        cmdApp.Parameters.AddWithValue("@IpAddress", Session["IPAddress"].ToString());
						cmdApp.Parameters.AddWithValue("@VideoPlayStartDate", _tblVideoDemo.VideoPlayStartDate);
                    if (_tblVideoDemo.VideoPlayEndDate == null)
                    {
                        cmdApp.Parameters.AddWithValue("@VideoPlayEndDate", DBNull.Value);
                    }
  
                    else if (_tblVideoDemo.VideoPlayEndDate != null && _tblVideoDemo.VideoPlayEndDate != DateTime.MinValue)
                    {
                        cmdApp.Parameters.AddWithValue("@VideoPlayEndDate", _tblVideoDemo.VideoPlayEndDate);
                    }
                    else
                    {
                        cmdApp.Parameters.AddWithValue("@VideoPlayEndDate", DBNull.Value);
                    }
                    cmdApp.CommandType = CommandType.Text;
                        con.Open();
  
                        result = Convert.ToInt32(cmdApp.ExecuteScalar());


                    
                }

            }
            catch(Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = MujiStore.Resources.Resource.CntVideoDemoSaveThumbnailImageErrMsg;
              
            }


                return result;
        }

        
        [HttpPost]
        public ActionResult SaveThumbnailImage(tblMedia _tblVideoDemo)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result;
 
         
            try
            {

                FillApprovalStatus();
                List<SelectListItem> lstFolderName = new List<SelectListItem>();
                lstFolderName = BLL.CommonLogic.FillFolderList();
                ViewData["FolderDtl"] = lstFolderName;

                List<SelectListItem> lstRobocopyExitcodeList = new List<SelectListItem>();
                ViewData["roboResult"] = FillRobocopyExitcodeList();
                if (_tblVideoDemo.FolderID == 0)
                {
                    ModelState.AddModelError("FolderID", "Select Folder");
                    return View("Edit", _tblVideoDemo);
                }
                if (_tblVideoDemo.VideoPlayEndDate != DateTime.MinValue)
                {
                    if (_tblVideoDemo.VideoPlayStartDate > _tblVideoDemo.VideoPlayEndDate)
                    {
                        ModelState.AddModelError("VideoPlayStartDate", MujiStore.Resources.Resource.dateval);
                         _tblVideoDemo.Thumbnail = _tblVideoDemo.ThumbnailFileName ;
                        _tblVideoDemo.ConvertStatus = 3;
                        _tblVideoDemo.Registerer = Session["UserName"].ToString();
                        return View("Edit", _tblVideoDemo);
                    }
                }
                var fileName = "";
                db.Entry(_tblVideoDemo).State = EntityState.Modified;
                if (_tblVideoDemo.PhysicalDELFG == true)
                {
   
                    _tblVideoDemo.Thumbnail = _tblVideoDemo.ThumbnailFileName;
                     result = InsertMediaApplication(_tblVideoDemo, true);

                }
                else
                {
                    //path of folder taht you want to save the canvas
                    var path = Server.MapPath("~/thumbs");
     
                    //produce new file name
                    fileName = _tblVideoDemo.Video.ToLower().Replace(".mp4", ".jpg");
  

                    //get full file path
                    var fileNameWitPath = Path.Combine(path, fileName);

                    //save canvas
                    using (var fs = new FileStream(fileNameWitPath, FileMode.Create))
                    {
                        using (var bw = new BinaryWriter(fs))
                        {
                            var data = Convert.FromBase64String(_tblVideoDemo.Thumbnail);
                            bw.Write(data);
                            bw.Close();
                        }
                        fs.Close();
                    }

                    _tblVideoDemo.Thumbnail = fileName;
 
                    result = InsertMediaApplication(_tblVideoDemo, true);
 
                }
            
                  
               
 

                LogInfo.Comments = "Thumbnail and Details Updated - " + _tblVideoDemo.Title.ToString();
                CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                TempData["SuccMsg"] = MujiStore.Resources.Resource.CntVideoDemoSaveThumbnailImageSuccMsg;
                //do somthing with model
                return RedirectToAction("Index",  new { page = TempData["Page"] });
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = MujiStore.Resources.Resource.CntVideoDemoSaveThumbnailImageErrMsg;
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

        }

        [HttpPost]
        public ActionResult SaveVideoDetails(tblMedia _tblVideoDemo)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result;

            try
            {
                FillApprovalStatus();
                List<SelectListItem> lstFolderName = new List<SelectListItem>();
                lstFolderName = BLL.CommonLogic.FillFolderList();
                //lstFolderName.Insert(0, (new SelectListItem { Text = "Select", Value = "0" }));
                ViewData["FolderDtl"] = lstFolderName;

                List<SelectListItem> lstRobocopyExitcodeList = new List<SelectListItem>();
                ViewData["roboResult"] = FillRobocopyExitcodeList();

                var fileName = "";

                if (_tblVideoDemo.FolderID == 0)
                {
                    ModelState.AddModelError("FolderID", "Select Folder");
                    return View("Edit", _tblVideoDemo);
                }
                db.Entry(_tblVideoDemo).State = EntityState.Modified;
                if (_tblVideoDemo.VideoPlayEndDate != DateTime.MinValue)
                {
                    if (_tblVideoDemo.VideoPlayStartDate > _tblVideoDemo.VideoPlayEndDate)
                    {
                        ModelState.AddModelError("VideoPlayStartDate", MujiStore.Resources.Resource.dateval);
                        _tblVideoDemo.ConvertStatus = 3;
                        _tblVideoDemo.Thumbnail = _tblVideoDemo.ThumbnailFileName;
                        _tblVideoDemo.Registerer = Session["UserName"].ToString();
                        return View("Edit", _tblVideoDemo);
                    }
                }


                if (_tblVideoDemo.PhysicalDELFG == true)
                {
 
                    result = InsertMediaApplication(_tblVideoDemo, false);
                }
                else
                {
                    //result = UpdateMediaFile(_tblVideoDemo, false, false);
                    result = InsertMediaApplication(_tblVideoDemo, false);
                }

   
                LogInfo.Comments = "Video Details Updated - " + _tblVideoDemo.Title.ToString();
                CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
  
                TempData["SuccMsg"] = MujiStore.Resources.Resource.CntVideoDemoSaveSaveVideoDetailsSuccMsg;
                //do somthing with model
                return RedirectToAction("Index", new { page = TempData["Page"] });
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = MujiStore.Resources.Resource.CntVideoDemoSaveSaveVideoDetailsErrMsg;
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

        }

        public void FillApprovalStatus()
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = MujiStore.Resources.Resource.UnApproved, Value = "0" });
            list.Add(new SelectListItem { Text = MujiStore.Resources.Resource.Approved, Value = "3" });
            ViewData["ApprovalDtl"] = list;
        }

        public string GetMediaServerIPAddress(int? MediaID)
        {
            string query = "";
            string result = "";
            using (SqlConnection con = new SqlConnection(CS))
            {
                query = "SELECT TOP 1 SS.IPAddress FROM [tblDeployStatus] AS DS ";
                query += " LEFT JOIN tblStreamServer AS SS ON DS.DSServer = SS.SSServer ";
                query += " LEFT JOIN tblFormat MF ON MF.FormatID = DS.FormatID ";
                query += " WHERE DS.DSServer = @DSServer  ";
                query += " AND DS.MediaID = @MediaID AND DS.DELFG = 0 ";
                query += " AND MF.Name = 'MP4' AND SS.DELFG = 0 ";
                query += " AND DS.IsExists = 1 AND MF.DELFG = 0 ";

                SqlCommand cmds = new SqlCommand(query, con);
                cmds.Parameters.AddWithValue("@MediaID", MediaID);
                cmds.Parameters.AddWithValue("@DSServer", System.Configuration.ConfigurationManager.AppSettings["MediaServer"]);
                cmds.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdrs = cmds.ExecuteReader();
                while (rdrs.Read())
                {
                    result = rdrs["IPAddress"].ToString();
                }
            }
            return result;
        }
       

        
        
        


      
        public List<SelectListItem> FillRobocopyExitcodeList()
        {
            string query = "";
            var list = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(CS))
            {
 
                query = "Select RobocopyExitcodeID,Content from tblRobocopyExitcode where Delfg = 0 Order by Content ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                list.Add(new SelectListItem { Text = "Select", Value = "0" });
                while (rdr.Read())
                {
                    list.Add(new SelectListItem { Text = rdr["Content"].ToString(), Value = Convert.ToInt32(rdr["RobocopyExitcodeID"]).ToString() });

                }
            }


            return list;
        }
 
        
        public ActionResult Edit(int? id, int? page)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;

            try
            {
                if (page == null)
                {
                    ViewBag.checkpage = "VideoAll";
                }

                string uName = Session["UserName"].ToString();
                FillApprovalStatus();
                List<SelectListItem> lstFolderName = new List<SelectListItem>();
                lstFolderName = BLL.CommonLogic.FillFolderList();

                ViewData["FolderDtl"] = lstFolderName;

                List<SelectListItem> lstRobocopyExitcodeList = new List<SelectListItem>();
                ViewData["roboResult"] = FillRobocopyExitcodeList();
 

                tblMedia tblVideoDemo = new tblMedia();

                List<tblMedia> StoreList = new List<tblMedia>();
                string query = "select MediaID,Title,Description, ";
                query += " convert(varchar,MediaID)+'-1.mp4' Video,Thumbnail,tblmedia.IpAddress, ";
                query += " FolderID,tblmedia.DELFG,tblmedia.CRTDT, ";
                query += " tblmedia.CRTCD,tblmedia.UPDDT,tblmedia.UPDCD,UploadType, ";
                query += " ViewCount,FileSize,U1.UserName Registerer,U2.UserName Accepter,ApprovalStatus, ";
                query += " ConvertStatus,Duration,UploadStartDatetime, ";
                query += " UploadEndDatetime,StreamingConStartDatetime, ";
                query += " StreamingConEndDatetime,VideoPlayStartDate,VideoPlayEndDate ";
                query += " from tblmedia ";
                query += " LEFT JOIN tblUser AS U1 ON tblmedia.Registerer = U1.ID ";
                query += " LEFT JOIN tblUser AS U2 ON tblmedia.Accepter = U2.ID ";
                query += " where mediaid = " + id + " and tblmedia.DELFG = 0 ";
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
                                
   
                            }
                        }
                        con.Close();
                    }
                }

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                
 
                tblVideoDemo = GetMediaDetails(Convert.ToInt32(id), string.Empty,false);
                if (tblVideoDemo != null)
                {
                    tblVideoDemo.VideoPlayStartDate = uploadstartdatetime;
                    tblVideoDemo.ThumbnailFileName = tblVideoDemo.Thumbnail;

                    if (uploadenddatetime != DateTime.MinValue)
                    {
                        tblVideoDemo.VideoPlayEndDate = uploadenddatetime;

                    }
                }

  
                if (tblVideoDemo == null)
                {
                    return HttpNotFound();
                }
  

                int pageNumber = (page ?? 1);
                tblVideoDemo.page = pageNumber;
                TempData["Page"] = page;
                return View(tblVideoDemo);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

        }

        // POST: VideoDemo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [NonAction]
        //[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VideoId,Title,Description,Video,Thumbnail,IpAddress,DelFlg,CrDate,UdDate,page")] tblMedia tblVideoDemo)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;

            try
            {

                if (ModelState.IsValid)
                {
                    FillApprovalStatus();
                    List<SelectListItem> lstFolderName = new List<SelectListItem>();
                    lstFolderName = BLL.CommonLogic.FillFolderList();
 
                    ViewData["FolderDtl"] = lstFolderName;
                   

                    if (tblVideoDemo.PhysicalDELFG == true)
                    {
                        String strRootDirectory = Server.MapPath("~/");
                        string targetPath = strRootDirectory + @"\Video\";
                        if (tblVideoDemo.Video != null && tblVideoDemo.Video.Trim() != "" && tblVideoDemo.Video.Trim().Length > 4)
                        {
                            System.IO.FileInfo fiV = new System.IO.FileInfo(targetPath + tblVideoDemo.Video);
                            if (fiV.Exists)
                            {
                                fiV.Delete();
                            }
                        }

                        if (tblVideoDemo.Thumbnail != null && tblVideoDemo.Thumbnail.Trim() != "" && tblVideoDemo.Thumbnail.Trim().Length > 4)
                        {
                            System.IO.FileInfo fiV = new System.IO.FileInfo(targetPath + tblVideoDemo.Thumbnail);
                            if (fiV.Exists)
                            {
                                fiV.Delete();
                            }
                        }

                    }

                    db.Entry(tblVideoDemo).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", new { page = tblVideoDemo.page });
                }
                return View(tblVideoDemo);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

        }

        
        public int Updateuploadstartdatetime(tblMedia _tblVideoDemo)
        {
            int result;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string query = "";
                query = "Update tblMedia set uploadstartdatetime=@uploadstartdatetime";
                               
                query += " Where MediaID=@MediaID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@uploadstartdatetime", DateTime.Now);
                             
                cmd.Parameters.AddWithValue("@MediaID", _tblVideoDemo.MediaID);
                cmd.CommandType = CommandType.Text;
                con.Open();
                result = cmd.ExecuteNonQuery();

                
            }
            return result;
        }

        public int Updateuploadenddatetime(tblMedia _tblVideoDemo)
        {
            int result;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string query = "";
                query = "Update tblMedia set uploadenddatetime=@uploadenddatetime";

                query += " Where MediaID=@MediaID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@uploadenddatetime", DateTime.Now);

                cmd.Parameters.AddWithValue("@MediaID", _tblVideoDemo.MediaID);
                cmd.CommandType = CommandType.Text;
                con.Open();
                result = cmd.ExecuteNonQuery();


            }
            return result;
        }
        public int Updatestreamconvertstartenddatetime(tblMedia _tblVideoDemo)
        {
            int result;
            using (SqlConnection con = new SqlConnection(CS))
            {
 
                string query = "";
                query = "Update tblMedia set streamingconstartdatetime=@streamingconstartdatetime,streamingconenddatetime=@streamingconenddatetime";

                query += " Where MediaID=@MediaID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@streamingconstartdatetime", _tblVideoDemo.streamingconstartdatetime);
                cmd.Parameters.AddWithValue("@streamingconenddatetime", _tblVideoDemo.streamingconenddatetime);
                cmd.Parameters.AddWithValue("@MediaID", _tblVideoDemo.MediaID);
                cmd.CommandType = CommandType.Text;
                con.Open();
                result = cmd.ExecuteNonQuery();


            }
            return result;
        }
        public int Updateuploadstartenddatetime(tblMedia _tblVideoDemo)
        {
            int result;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string query = "";
                query = "Update tblMedia set uploadstartdatetime=@uploadstartdatetime,uploadenddatetime=@uploadenddatetime,Video=@Video ";

                query += " Where MediaID=@MediaID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@uploadstartdatetime", _tblVideoDemo.uploadstartdatetime);
                cmd.Parameters.AddWithValue("@uploadenddatetime", _tblVideoDemo.uploadenddatetime);
                cmd.Parameters.AddWithValue("@MediaID", _tblVideoDemo.MediaID);
                cmd.Parameters.AddWithValue("@Video", _tblVideoDemo.Video);
                cmd.CommandType = CommandType.Text;
                con.Open();
                result = cmd.ExecuteNonQuery();


            }
            return result;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Index_new(string sortOrder, int? page, string SearTitle, string SearchTitle, string SearchFromCRTDT, string CdStDate, string SearchToCRTDT, string CdEdDate, int? Approvalstatus, int? Convertstatus, int? CvtStatus, int? ConvtStatus, int? FolderID, int? FolID)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int pageSize;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.IDSortParm = sortOrder == "ID" ? "ID_desc" : "ID";
            ViewBag.TitleSortParm = sortOrder == "Title" ? "Title_desc" : "Title";
            ViewBag.ApprovalstatusSortParm = sortOrder == "Approvalstatus" ? "Approvalstatus_desc" : "Approvalstatus";
            ViewBag.ConvertStatusSortParm = sortOrder == "ConvertStatus" ? "ConvertStatus_desc" : "ConvertStatus";
            ViewBag.FolderSortParm = sortOrder == "Folder" ? "Folder_desc" : "Folder";

            List<SelectListItem> lstApprovalstatus = new List<SelectListItem>();

            List<SelectListItem> lstConvertstatus = new List<SelectListItem>();

            lstApprovalstatus.Add(new SelectListItem { Text = MujiStore.Resources.Resource.All, Value = "4" });
            lstApprovalstatus.Add(new SelectListItem { Text = MujiStore.Resources.Resource.ChangeRequested, Value = "0" });
            lstApprovalstatus.Add(new SelectListItem { Text = MujiStore.Resources.Resource.Approved, Value = "3" });//VJ 20200603 ConvertStatus Changed
            lstApprovalstatus.Add(new SelectListItem { Text = MujiStore.Resources.Resource.disapproved, Value = "2" });
            ViewBag.Approvalstatus = new SelectList(lstApprovalstatus, "Value", "Text", CvtStatus);

            lstConvertstatus.Add(new SelectListItem { Text = MujiStore.Resources.Resource.All, Value = "4" });
            lstConvertstatus.Add(new SelectListItem { Text = MujiStore.Resources.Resource.Conversionongoing, Value = "0" });
            lstConvertstatus.Add(new SelectListItem { Text = MujiStore.Resources.Resource.Conversioncompleted, Value = "3" });//VJ 20200603 ConvertStatus Changed
            lstConvertstatus.Add(new SelectListItem { Text = MujiStore.Resources.Resource.Conversionfailed, Value = "2" });
            ViewBag.Convertstatus = new SelectList(lstConvertstatus, "Value", "Text", ConvtStatus);

            List<SelectListItem> lstFolderName = new List<SelectListItem>();
            List<SelectListItem> lstFolderNameBulk = new List<SelectListItem>();
            lstFolderName = BLL.CommonLogic.FillFolderList();
            lstFolderNameBulk = BLL.CommonLogic.FillFolderList();
            ViewBag.FolderList = new SelectList(lstFolderNameBulk, "Value", "Text");
            lstFolderName.Insert(0, (new SelectListItem { Text = "All", Value = "0" }));
            ViewBag.FolderID = new SelectList(lstFolderName, "Value", "Text", FolID);

            if (SearchTitle != null || SearchFromCRTDT != null || SearchToCRTDT != null || Approvalstatus != null || Convertstatus != null)
            {
                page = 1;
            }
            else
            {
                SearchTitle = SearTitle;
                SearchFromCRTDT = CdStDate;
                SearchToCRTDT = CdEdDate;
                Approvalstatus = CvtStatus;
                Convertstatus = ConvtStatus;
                FolderID = FolID;
            }
            ViewBag.SearTitle = SearchTitle;
            ViewBag.CdStDate = SearchFromCRTDT;
            ViewBag.CdEdDate = SearchToCRTDT;
            ViewBag.cvtStatus = Approvalstatus;
            ViewBag.ConvtStatus = Convertstatus;
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
                List<string> ffmt = new List<string>();
                ffmt = MujiStore.BLL.CommonLogic.GetFileExtn("video");
                List<BulkUploadVideo> VidList = new List<BulkUploadVideo>();
                var videoAllFiles = Directory.EnumerateFiles(Server.MapPath("~/FtpVideo"));
                var videoFiles = from selectfiles in videoAllFiles
                                 where (from filedtl in videoAllFiles
                                        from filextn in ffmt
                                        where filedtl.ToLower().EndsWith(filextn)
                                        select filedtl).Contains(selectfiles)
                                 select selectfiles;

                foreach (string file in videoFiles)
                {
                    BulkUploadVideo buMedia = new BulkUploadVideo();
                    buMedia.UploadFileName = Path.GetFileName(file);
                    buMedia.UploadTitle = string.Empty;
                    buMedia.UploadDescription = string.Empty;
                    buMedia.UploadFolderID = 1;
                    buMedia.IsUpload = false;
                    buMedia.IsDelete = false;
                    VidList.Add(buMedia);
 
                }
                FillApprovalStatus();
                ViewData["videoFiles"] = VidList;
                //When fils is exit, then need to show for the update. Count will send to Index Page
                var videoFilesCount = Directory.EnumerateFiles(Server.MapPath("~/FtpVideo")).Count();
                ViewBag.VideoFilesCount = VidList.Count;
                //Verify that file is convered
                var videoConvertedFiles = Directory.EnumerateFiles(Server.MapPath("~/ffmpeg/tmp"), "*.txt");
                var videoConvertedFilesSelect = from selectfiles in videoConvertedFiles
                                                select selectfiles;
                //By Default
                Boolean convertStatus = false;
                int convertedcount = 0;
                foreach (string outputResultFile in videoConvertedFilesSelect)
                {
                    convertedcount = convertedcount + 1;
                    var fileCheck = new FileInfo(outputResultFile);
                    if (IsFileLocked(fileCheck) == false) // If file is not locked then it can be delete
                    {
                        convertStatus = true;
                    }

                }
                //Check the converted count
                if (convertedcount == 0)
                {
                    //Verify that any batch file is available , hence the conversion process start with batch file
                    var batchCouunt = Directory.EnumerateFiles(Server.MapPath("~/ffmpeg/tmp"), "*.bat").Count();
                    if (batchCouunt > 0)
                    {
                        ViewBag.videoConvertedFilesCount = -99;
                    }
                    else
                    {
                        ViewBag.videoConvertedFilesCount = 0;
                    }
                }
                else
                {
                    if (convertStatus == true)
                    {
                        ViewBag.videoConvertedFilesCount = 1;
                    }
                    else
                    {
                        ViewBag.videoConvertedFilesCount = -99;
                    }

                }
 
                List<tblMedia> videoList = new List<tblMedia>();

                string uName = Session["UserName"].ToString();
                ViewData["FolderDtl"] = BLL.CommonLogic.FillFolderList();
                string query = "select MediaID,tblMedia.CRTDT,Title,Description,Thumbnail,Video,ConvertStatus,ApprovalStatus,tblMedia.FolderID,Name ,case ApprovalStatus when 0 then 'Change Requested' when 2 then 'Disapproved' when 3 then 'Approved'end [astatus]";
                query = query + "from [dbo].[tblMedia] ";
                query = query + " LEFT JOIN [tblUser] AS U1 ON [tblMedia].Registerer = U1.ID ";
                query = query + " LEFT JOIN [tblUser] AS U2 ON [tblMedia].Accepter = U2.ID ";
                query = query + " left join tblFolder on tblMedia.FolderID = tblFolder.FolderID where ";
                query = query + " [tblMedia].DELFG = 0 and [tblMedia].ApprovalStatus < 3 ";
                query = query + " and FORMAT(tblMedia.CRTDT, 'yyyy-MM-dd') between '" + CdStDate + "' and '" + CdEdDate + "'";
 

                if (ViewBag.SearTitle != null && ViewBag.SearTitle != "" && ViewBag.SearTitle != string.Empty)
                {
                    query = query + " and title like @title";
                }

                if (ViewBag.cvtStatus != null && ViewBag.cvtStatus != 4)
                {
                    query = query + " and Approvalstatus = " + ViewBag.cvtStatus;
                }
                if (ViewBag.ConvtStatus != null && ViewBag.ConvtStatus != 4)
                {
                    query = query + " and ConvertStatus = " + ViewBag.ConvtStatus;
                }
                if (ViewBag.FolID != null && ViewBag.FolID != 0)
                {
                    query = query + " and tblMedia.FolderID = " + Convert.ToInt32(ViewBag.FolID);
                }
                query = query + " Order by MediaID Desc";

                using (SqlConnection con = new SqlConnection(CS))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@title", "%" + ViewBag.SearTitle + "%");
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                videoList.Add(new tblMedia
                                {

                                    MediaID = Convert.ToInt32(sdr["MediaID"]),
                                    Title = Convert.ToString(sdr["Title"]),
                                    Description = Convert.ToString(sdr["Description"]),
                                    Video = Convert.ToString(sdr["Video"]),
                                    ApprovalStatus = Convert.ToInt32(sdr["ApprovalStatus"]),
                                    FolderID = Convert.ToInt32(sdr["FolderID"]),
                                    FolderName = Convert.ToString(sdr["Name"]),
                                    CRTDT = Convert.ToDateTime(sdr["CRTDT"]),
                                    STRCRTDT = Convert.ToDateTime(sdr["CRTDT"]).ToString("yyyy/MM/dd"),// .ToString("yyyy/MM/dd HH:mm:ss tt");
                                    STRCRTDTTIME = Convert.ToDateTime(sdr["CRTDT"]).ToString("HH:mm:ss"),// .ToString("yyyy/MM/dd HH:mm:ss tt");
                                    ConvertStatus = Convert.ToInt32(sdr["ConvertStatus"]),
                                    Thumbnail = Convert.ToString(sdr["Thumbnail"]),
                                });
                            }
                        }
                        con.Close();
                    }
                }


                switch (sortOrder)
                {
 
                    case "ID":
                        videoList = videoList.OrderBy(o => o.MediaID).ToList();
                        break;
                    case "Title":
                        videoList = videoList.OrderBy(o => o.Title).ToList();
                        break;
                    case "Title_desc":
                        videoList = videoList.OrderByDescending(o => o.Title).ToList();
                        break;
                    case "ConvertStatus_desc":
                        videoList = videoList.OrderByDescending(o => o.ConvertStatus).ToList();
                        break;

                    case "ConvtStatus":
                        videoList = videoList.OrderBy(o => o.ConvertStatus).ToList();
                        break;
                    case "Approvalstatus_desc":
                        videoList = videoList.OrderByDescending(o => o.Thumbnail).ToList();
                        break;

                    case "Approvalstatus":
                        videoList = videoList.OrderBy(o => o.Thumbnail).ToList();
                        break;
                    case "Folder_desc":
                        videoList = videoList.OrderByDescending(o => o.FolderName).ToList();
                        break;
                    case "Folder":
                        videoList = videoList.OrderBy(o => o.FolderName).ToList();
                        break;
                    default:  // Name ascending 
                        videoList = videoList.OrderByDescending(o => o.MediaID).ToList();
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


                return View(VidList);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }


        }
        public ActionResult Edit_new(int? id, int? page)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;

            try
            {
                string uName = Session["UserName"].ToString();
                FillApprovalStatus();
                List<SelectListItem> lstFolderName = new List<SelectListItem>();
                lstFolderName = BLL.CommonLogic.FillFolderList();

                ViewData["FolderDtl"] = lstFolderName;

                List<SelectListItem> lstRobocopyExitcodeList = new List<SelectListItem>();
                ViewData["roboResult"] = FillRobocopyExitcodeList();
  

                tblMedia tblVideoDemo = new tblMedia();

                List<tblMedia> StoreList = new List<tblMedia>();
                string query = "select * from tblmedia where mediaid= " + id + "  ";
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

  
                            }
                        }
                        con.Close();
                    }
                }

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }


                tblVideoDemo = GetMediaDetails(Convert.ToInt32(id), string.Empty, false);
                if (tblVideoDemo != null)
                {
                    tblVideoDemo.VideoPlayStartDate = uploadstartdatetime;
                    tblVideoDemo.ThumbnailFileName = tblVideoDemo.Thumbnail; 

                    if (uploadenddatetime != DateTime.MinValue)
                    {
                        tblVideoDemo.VideoPlayEndDate = uploadenddatetime;

                    }
                }
                

          
                if (tblVideoDemo == null)
                {
                    return HttpNotFound();
                }
 

                int pageNumber = (page ?? 1);
                tblVideoDemo.page = pageNumber;
                TempData["Page"] = page;
                return View(tblVideoDemo);
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
        public ActionResult Edit_new(tblMedia tblVideoDemo)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result;
 
            try
            {
                FillApprovalStatus();
                List<SelectListItem> lstFolderName = new List<SelectListItem>();
                lstFolderName = BLL.CommonLogic.FillFolderList();
                ViewData["FolderDtl"] = lstFolderName;

                List<SelectListItem> lstRobocopyExitcodeList = new List<SelectListItem>();
                ViewData["roboResult"] = FillRobocopyExitcodeList();

                var fileName = "";

                if (tblVideoDemo.FolderID == 0)
                {
                    ModelState.AddModelError("FolderID", "Select Folder");
                    return View("Edit_new", tblVideoDemo);
                }
                db.Entry(tblVideoDemo).State = EntityState.Modified;
                if (tblVideoDemo.VideoPlayEndDate != DateTime.MinValue)
                {
                    if (tblVideoDemo.VideoPlayStartDate > tblVideoDemo.VideoPlayEndDate)
                    {
                        ModelState.AddModelError("VideoPlayStartDate", MujiStore.Resources.Resource.dateval);
                        tblVideoDemo.ConvertStatus = 3;
                        tblVideoDemo.Thumbnail = tblVideoDemo.ThumbnailFileName;
                        tblVideoDemo.Registerer = Session["UserName"].ToString();
                        return View("Edit_new", _=tblVideoDemo);
                    }
                }
                
                if (tblVideoDemo.PhysicalDELFG == true)
                {
                 
                    result = InsertMediaApplication(tblVideoDemo, false);
                }
                else
                {
                    result = InsertMediaApplication(tblVideoDemo, false);
                }
                LogInfo.Comments = "Video Details Updated - " + tblVideoDemo.Title.ToString();
                CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                TempData["SuccMsg"] = MujiStore.Resources.Resource.CntVideoDemoSaveSaveVideoDetailsSuccMsg;
                //do somthing with model
                return RedirectToAction("Index_new", new { page = TempData["Page"] });
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = MujiStore.Resources.Resource.CntVideoDemoSaveSaveVideoDetailsErrMsg;
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }


        }

    }
}
