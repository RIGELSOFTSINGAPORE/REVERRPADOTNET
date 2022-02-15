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
    [MUJICustomAuthorize(Roles = "1,3,5,7,8,9,10,11,12,13,14,15,17,19,21,23,24,25,26,27,28,29,30,31")]
    public class FeedbacksController : BaseController
    {

        private mujiEntities1 db = new mujiEntities1();
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
   
         public ActionResult Index(int? page, int? delfg, int? ConvertStatus, string SearTitle, string SearchTitle, string ip, string ipadd, string writer, string feedbacker,   int? FolderID, int? FolID,string status,int?page1)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
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
            if (page1 != null)
            {
                status = "sucess";
                pageNumber = Convert.ToInt16(page1);
            }
            try
            {
                List<tblFeedback> tblFeedbacks = new List<tblFeedback>();
                List<SelectListItem> lstConvertStatus = new List<SelectListItem>();


                lstConvertStatus.Add(new SelectListItem { Text = "All", Value = "4" });
                lstConvertStatus.Add(new SelectListItem { Text = MujiStore.Resources.Resource.active, Value = "1" });
                lstConvertStatus.Add(new SelectListItem { Text = MujiStore.Resources.Resource.Inactive, Value = "0" });
                ViewBag.ConvertStatus = new SelectList(lstConvertStatus, "Value", "Text", delfg);

                string uName = Session["UserName"].ToString();
                if (SearchTitle != null || ip != null || writer != null || ConvertStatus != null)
                {
                    page = 1;
                }
                else
                {
                    SearchTitle = SearTitle;
                    ip = ipadd;
                    writer = feedbacker;
                    ConvertStatus = delfg;                  
                    FolderID = FolID;
                }
                ViewBag.SearTitle = SearchTitle;
                ViewBag.ipadd = ip;
                ViewBag.writer = writer;
                ViewBag.delfg = ConvertStatus;
                string query = "";
            SqlCommand cmd;
            using (SqlConnection con = new SqlConnection(CS))
            {

                query = "select FeedbackID,MovieID,WriterName,Comments,FileName,tblFeedback.IPAddress, ";
                query += "WriterDatetime,tblFeedback.CRTDT,tblFeedback.CRTCD,tblFeedback.DELFG,Title,Description,Video,tblFolder.Name 'FolderName' ";
                query += "from tblFeedback ";
                query += "left join [tblMedia] on  MediaID = MovieID ";
                query += "left join [tblFolder] on [tblMedia].FolderID = [tblFolder].FolderID where FeedbackID like '%' ";
                    if (ViewBag.delfg != null && ViewBag.delfg != 4)
                    {
                        query = query + " and tblFeedback.DELFG = " + ViewBag.delfg;
                    }
                    if (ViewBag.SearTitle != null && ViewBag.SearTitle != "" && ViewBag.SearTitle != string.Empty)
                    {
                        query = query + " and title like @title ";
                    }
                    if (ViewBag.ipadd != null && ViewBag.ipadd != "" && ViewBag.ipadd != string.Empty)
                    {
                        query = query + " and tblFeedback.IPAddress like @ipadd ";
                    }
                    if (ViewBag.writer != null && ViewBag.writer != "" && ViewBag.writer != string.Empty)
                    {
                        query = query + " and WriterName like @writer ";
                    }

                    if (Session["FeedBackApproval"].ToString() == "D")
                {
                        query += "and tblFeedback.DELFG = 0 Order by FeedbackID desc";
                }
                if (Session["FeedBackApproval"].ToString() == "A")
                {
                        query += "and tblFeedback.DELFG = 1 Order by FeedbackID desc";
                }
                if (Session["FeedBackApproval"].ToString() == "B")
                {
                    query += "Order by FeedbackID desc";
                }

                     cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@title", "%" + ViewBag.SearTitle + "%" );
                    cmd.Parameters.AddWithValue("@ipadd",  "%" +ViewBag.ipadd + "%" );
                    cmd.Parameters.AddWithValue("@writer", "%" + ViewBag.writer + "%" );
                    cmd.CommandType = CommandType.Text;

                    con.Open();
               SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    tblFeedback feedback = new tblFeedback();
                    //tblFeedback fback = new tblFeedback();
                    feedback.FeedbackID = Convert.ToInt32(rdr["FeedbackID"]);
                    feedback.MovieID = Convert.ToInt32(rdr["MovieID"]);
                    feedback.WriterName = rdr["WriterName"].ToString();
                    feedback.Comments = rdr["Comments"].ToString();
                    feedback.FileName = rdr["FileName"].ToString();
                    feedback.IPAddress = rdr["IPAddress"].ToString();
                    feedback.WriterDatetime = Convert.ToDateTime(rdr["WriterDatetime"]);
                    feedback.CRTDT = Convert.ToDateTime(rdr["CRTDT"]);
                    feedback.CRTCD = rdr["CRTCD"].ToString();
                    feedback.DELFG = Convert.ToBoolean(rdr["DELFG"].ToString());
                    feedback.MediaTitle = rdr["Title"].ToString();
                    feedback.MediaDescription = rdr["Description"].ToString();
                    feedback.MediaFileName = rdr["Video"].ToString();
                    feedback.MediaFolderName = rdr["FolderName"].ToString();
                    feedback.STRCRTDT = Convert.ToDateTime(rdr["WriterDatetime"]).ToString("yyyy/MM/dd");// .ToString("yyyy/MM/dd HH:mm:ss tt");
                        feedback.STRCRTDTTIME = Convert.ToDateTime(rdr["WriterDatetime"]).ToString("HH:mm:ss");
                        tblFeedbacks.Add(feedback);
                       
                    }
            }
                if (status != null)
                {
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.Feedbackdeletedsucessfully;
                }
                return View(tblFeedbacks.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }

        // GET: Feedbacks/Details/5
        [NonAction]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFeedback feedback = db.tblFeedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // GET: Feedbacks/Create
        [NonAction]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Feedbacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [NonAction]
        public ActionResult Create([Bind(Include = "FeedbackID,MovieID,Comments,FileName,IPAddress,DELFG,CRTDT,CRTCD,UPDDT,UPDCD,WriterName,WriterDatetime")] tblFeedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedback.IPAddress = Session["IPAddress"].ToString();
                feedback.CRTCD = Session["UserName"].ToString();
                feedback.CRTDT = DateTime.Now;
                feedback.DELFG = false;
                db.SaveChanges();
                TempData["SuccMsg"] = MujiStore.Resources.Resource.CntFeedbackCreateSuccMsg;
                return RedirectToAction("Index");
            }
            TempData["ErrMsg"] = MujiStore.Resources.Resource.CntFeedbackCreateFailMsg;
            return View(feedback);
        }

        // GET: Feedbacks/Edit/5
        public ActionResult Edit(int? id,int ? page )
        {
            tblFeedback feedback = new tblFeedback();
            string query = "";
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            //tblFeedback feedback = db.tblFeedbacks.Find(id);
            try
            {
                ViewBag.Page = page;
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblFeedback tblFeedbacks = new tblFeedback();
                string uName = Session["UserName"].ToString();

                if (Session["FeedBackApproval"].ToString() == "D")
                {
                    tblFeedbacks = db.tblFeedbacks.Where(p => p.DELFG == false && p.FeedbackID == id).SingleOrDefault();
                    //query += "Where tblMedia.DELFG = 0 Order by FeedbackID desc";
                }
                if (Session["FeedBackApproval"].ToString() == "A")
                {
                    tblFeedbacks = db.tblFeedbacks.Where(p => p.DELFG == true && p.FeedbackID == id).SingleOrDefault();
                }
             
               
                if(tblFeedbacks != null)
                {
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        query = "select FeedbackID,MovieID,WriterName,Comments,FileName,tblFeedback.IPAddress, ";
                        query += "WriterDatetime,tblFeedback.CRTDT,tblFeedback.CRTCD,tblFeedback.DELFG,Title,Description,Video,tblFolder.Name 'FolderName' ";
                        query += "from tblFeedback ";
                        query += "left join [tblMedia] on  MediaID = MovieID ";
                        query += "left join [tblFolder] on [tblMedia].FolderID = [tblFolder].FolderID ";
                        query += "where FeedbackID =@FeedbackID";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@FeedbackID", id);
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                           
                            feedback.FeedbackID = Convert.ToInt32(rdr["FeedbackID"]);
                            feedback.MovieID = Convert.ToInt32(rdr["MovieID"]);
                            feedback.WriterName = rdr["WriterName"].ToString();
                            feedback.Comments = rdr["Comments"].ToString();
                            feedback.FileName = rdr["FileName"].ToString();
                            feedback.IPAddress = rdr["IPAddress"].ToString();
                            feedback.WriterDatetime = Convert.ToDateTime(rdr["WriterDatetime"]);
                            feedback.CRTDT = Convert.ToDateTime(rdr["CRTDT"]);
                            feedback.CRTCD = rdr["CRTCD"].ToString();
                            feedback.DELFG = Convert.ToBoolean(rdr["DELFG"].ToString());
                            feedback.MediaTitle = rdr["Title"].ToString();
                            feedback.MediaDescription = rdr["Description"].ToString();
                            feedback.MediaFileName = rdr["Video"].ToString();
                            feedback.MediaFolderName = rdr["FolderName"].ToString();
                            feedback.STRCRTDT = Convert.ToDateTime(rdr["WriterDatetime"]).ToString("yyyy/MM/dd HH:mm:ss");// .ToString("yyyy/MM/dd HH:mm:ss tt");
                           // feedback.STRCRTDTIME = Convert.ToDateTime(rdr["WriterDatetime"]).ToString("yyyy/MM/dd HH:mm:ss tt");
                        }

                    }
                    if (feedback == null)
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        if(Session["FeedBackApproval"].ToString() == "D")
                        {
                            feedback.DELFG = true;
                            //TempData["SuccMsg"] = MujiStore.Resources.Resource.CntFeedbackApprovedSuccMsg;
                        }
                        else if (Session["FeedBackApproval"].ToString() == "A")
                        {
                            feedback.DELFG = false;
                          // TempData["SuccMsg"] = MujiStore.Resources.Resource.CntFeedbackDisApprovedSuccMsg;
                        }
                    }
                    
                }
                
            }
            catch(Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            return View(feedback);

        }

        // POST: Feedbacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FeedbackID,MovieID,Comments,FileName,IPAddress,DELFG,CRTDT,CRTCD,UPDDT,UPDCD,WriterName,WriterDatetime")] tblFeedback feedback)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                if (ModelState.IsValid)
                {
                   
                    LogInfo.Comments = "Feedback updated - " + feedback.Comments;
                    feedback.IPAddress = Session["IPAddress"].ToString();
                    feedback.UPDCD = Session["UserName"].ToString();
                    feedback.UPDDT = DateTime.Now;
                    db.Entry(feedback).State = EntityState.Modified;
                    db.SaveChanges();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                   
                    if(feedback.DELFG == true)
                    {
                        TempData["SuccMsg"] = MujiStore.Resources.Resource.CntFeedbackDisApprovedSuccMsg;
                        
                    }
                    else
                    {
                        TempData["SuccMsg"] = MujiStore.Resources.Resource.CntFeedbackApprovedSuccMsg;
                    }
                    return RedirectToAction("Index");
                }
                
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            return View(feedback);
        }

        // GET: Feedbacks/Delete/5
        [NonAction]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFeedback feedback = db.tblFeedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [NonAction]
        public ActionResult DeleteConfirmed(int id)
        {
            tblFeedback feedback = db.tblFeedbacks.Find(id);
            db.tblFeedbacks.Remove(feedback);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
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
                    query = "delete from tblfeedback " +
                    "  where feedbackID=@UserID; ";



                    //Intialize Command and pass the paramters


                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@UserID", ID);
                   

                    cmd.CommandType = CommandType.Text;
                    result = cmd.ExecuteNonQuery();


                }
                if (result == 1)
                {

                    LogInfo.Comments = "Feedback Updated - " + ID.ToString();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.UserDeletedSuccessfully;
                    return RedirectToAction("Index");

                }
                else
                {
                    LogInfo.Comments = "Feedback Updated - " + ID.ToString();
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
