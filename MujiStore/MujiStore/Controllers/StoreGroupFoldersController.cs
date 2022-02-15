using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MujiStore.Models;
using MujiStore.BLL;
using PagedList;
using System.Data.SqlClient;
using System.Configuration;

namespace MujiStore.Controllers
{
    
    [SessionExpire]
    [Authorize]
    [MUJICustomAuthorize(Roles = "16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31")]
    public class StoreGroupFoldersController : BaseController
    {
        private mujiEntities1 db = new mujiEntities1();
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        // GET: StoreGroupFolders

        [NonAction]
        public ActionResult Index(int? page)
        {
            string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
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

            try
            {
                List<tblStoreGroupFolder> StoreList = new List<tblStoreGroupFolder>();
                string query = "select tblStoreGroupFolder.StoreGroupFolderID,tblStoreGroupFolder.StoreGroupID,tblStoreGroup.name[Name],tblfolder.Name[FolderName],tblStoreGroupFolder.DELFG from tblStoreGroupFolder";
                       query = query + " left join tblStoreGroup on tblStoreGroup.StoreGroupID = tblStoreGroupFolder.StoreGroupID";
                       query = query + " left join tblFolder on tblFolder.FolderID = tblStoreGroupFolder.FolderID";
                       query = query + " where tblStoreGroup.DELFG = 0 and tblFolder.DELFG = 0 ";
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
                                StoreList.Add(new tblStoreGroupFolder
                                {
                                    // MediaID,Title,Description,Video,ConvertStatus,FolderID
                                    StoreGroupFolderID = Convert.ToInt32(sdr["StoreGroupFolderID"]),
                                    StoreGroupID = Convert.ToInt32(sdr["StoreGroupID"]),
                                    CRTCD = Convert.ToString(sdr["Name"]),
                                    UPDCD = Convert.ToString(sdr["FolderName"]),
                                    DELFG = Convert.ToBoolean(sdr["DELFG"]),

                                });
                            }
                        }
                        con.Close();
                    }
                    return View(StoreList.ToList().OrderByDescending(x => x.StoreGroupFolderID).ToPagedList(pageNumber, pageSize));
                }
            }

            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }
        [NonAction]
        // GET: StoreGroupFolders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStoreGroupFolder tblStoreGroupFolder = db.tblStoreGroupFolders.Find(id);
            if (tblStoreGroupFolder == null)
            {
                return HttpNotFound();
            }
            return View(tblStoreGroupFolder);
        }

        // GET: StoreGroupFolders/Create
        [NonAction]
        public ActionResult Create(int? page)
        {

            string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                List<SelectListItem> lstFolderName = new List<SelectListItem>();
                lstFolderName = BLL.CommonLogic.FillFolderList();
                ViewBag.FolderID = new SelectList(lstFolderName, "Value", "Text");

                //ViewBag.FolderID = new SelectList(db.tblFolders.Where(x =>x.DELFG == false), "FolderID", "Name");
                BindStoreGroup(0);
                ViewBag.Page = page;
                return View();
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }

        // POST: StoreGroupFolders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [NonAction]
        public ActionResult Create([Bind(Include = "StoreGroupFolderID,StoreGroupID,FolderID,DELFG,CRTDT,CRTCD,UPDDT,UPDCD,IPAddress,page")] tblStoreGroupFolder tblStoreGroupFolder)
        {
          
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;

            try
            {
                BindStoreGroup(tblStoreGroupFolder.StoreGroupID);
                ViewBag.FolderID = new SelectList(db.tblFolders.Where(x => x.DELFG == false), "FolderID", "Name", tblStoreGroupFolder.FolderID);
                
                int StoreGroupNameCnt = CheckStoreGroupNameExists(tblStoreGroupFolder.StoreGroupID, 0);

                if (StoreGroupNameCnt != 0)
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreGroupNameErrMsg1;
                    return View(tblStoreGroupFolder);
                }
                if (ModelState.IsValid)
                {
                    LogInfo.Comments = @MujiStore.Resources.Resource.StoreGroupCreateFolderCreate + tblStoreGroupFolder.StoreGroupID + ","+ tblStoreGroupFolder.FolderID;

                    tblStoreGroupFolder.CRTDT = DateTime.Now;
                    tblStoreGroupFolder.CRTCD = Session["UserName"].ToString();
                    tblStoreGroupFolder.IPAddress = Session["IPAddress"].ToString();
                    tblStoreGroupFolder.DELFG = false;
                    db.tblStoreGroupFolders.Add(tblStoreGroupFolder);
                    db.SaveChanges();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.CntStoreGroupFoldersCreateSuccMsg;
                    return RedirectToAction("Index", new { page = tblStoreGroupFolder.page });
                }

                TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreGroupFoldersCreateErrMsg1;
 
                return View(tblStoreGroupFolder);
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                if (((System.Data.SqlClient.SqlException)ex.InnerException.InnerException).Number == 2627)
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreGroupFoldersCreateErrMsg2;
                    return View(tblStoreGroupFolder);
                }
                else
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreGroupFoldersCreateErrMsg3;
                }

                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
     
        }

        // GET: StoreGroupFolders/Edit/5
        [NonAction]
        public ActionResult Edit(int? id, int? page)
        {
            string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

               tblStoreGroupFolder tblStoreGroupFolder = db.tblStoreGroupFolders.Find(id);

                

                if (tblStoreGroupFolder == null)
                {
                    return HttpNotFound();
                }
                BindStoreGroup(tblStoreGroupFolder.StoreGroupID);
                List<SelectListItem> lstFolderName = new List<SelectListItem>();
                lstFolderName = BLL.CommonLogic.FillFolderList();
                ViewBag.FolderID = new SelectList(lstFolderName, "Value", "Text",tblStoreGroupFolder.FolderID);



                int pageNumber = (page ?? 1);
                tblStoreGroupFolder.page = pageNumber;

                return View(tblStoreGroupFolder);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

        }

        // POST: StoreGroupFolders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [NonAction]
        public ActionResult Edit([Bind(Include = "StoreGroupFolderID,StoreGroupID,FolderID,DELFG,CRTDT,CRTCD,UPDDT,UPDCD,IPAddress,page")] tblStoreGroupFolder tblStoreGroupFolder)
        {
         
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                ViewBag.FolderID = new SelectList(db.tblFolders.Where(x => x.DELFG == false), "FolderID", "Name", tblStoreGroupFolder.FolderID);

                BindStoreGroup(tblStoreGroupFolder.StoreGroupID);

                int StoreGroupNameCnt = CheckStoreGroupNameExists(tblStoreGroupFolder.StoreGroupID, tblStoreGroupFolder.StoreGroupFolderID);

                if (StoreGroupNameCnt != 0)
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreGroupNameErrMsg2;
                    return View(tblStoreGroupFolder);
                }

                if (ModelState.IsValid)
                {

                    LogInfo.Comments = MujiStore.Resources.Resource.CntStoreGroupUpdateCommon + tblStoreGroupFolder.StoreGroupFolderID.ToString();

                    tblStoreGroupFolder.UPDDT = DateTime.Now;
                    tblStoreGroupFolder.UPDCD = Session["UserName"].ToString();
                    tblStoreGroupFolder.IPAddress = Session["IPAddress"].ToString();
                    db.Entry(tblStoreGroupFolder).State = EntityState.Modified;
                    db.SaveChanges();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.CntStoreGroupFoldersEditSuccMsg;
                    return RedirectToAction("Index", new { page = tblStoreGroupFolder.page });
                }
                TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreGroupFoldersEditErrMsg1;
       
                return View(tblStoreGroupFolder);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                if (((System.Data.SqlClient.SqlException)ex.InnerException.InnerException).Number == 2627)
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreGroupFoldersEditErrMsg2;
                }
                else
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreGroupFoldersEditErrMsg3;
                }

                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }

        public static int CheckStoreGroupNameExists(int? StoreGroupID, int StoreGroupFolderID)
        {
            int result = 0;
            string query = "";
            string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {

                query = "select count(*) Cnt from tblStoreGroupFolder where StoreGroupID =@StoreGroupID and StoreGroupFolderID <> @StoreGroupFolderID and DELFG = 0 ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StoreGroupID", StoreGroupID);
                cmd.Parameters.AddWithValue("@StoreGroupFolderID", StoreGroupFolderID);
                cmd.CommandType = CommandType.Text;
                con.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());

                
            }
            return result;
        }
        [NonAction]
        // GET: StoreGroupFolders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStoreGroupFolder tblStoreGroupFolder = db.tblStoreGroupFolders.Find(id);
            if (tblStoreGroupFolder == null)
            {
                return HttpNotFound();
            }
            return View(tblStoreGroupFolder);
        }
        [NonAction]
        // POST: StoreGroupFolders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblStoreGroupFolder tblStoreGroupFolder = db.tblStoreGroupFolders.Find(id);
            db.tblStoreGroupFolders.Remove(tblStoreGroupFolder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public void BindStoreGroup(int? val)
        {
            var selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem
            {
                Value = "0",
                Text = MujiStore.Resources.Resource.dropselect
            });

            string querySDtnt = "";

            using (SqlConnection con = new SqlConnection(CS))
            {

                querySDtnt = " select StoreGroupID,name from tblStoregroup where DELFG = 0 order by storegroupid asc";

                SqlCommand cmds = new SqlCommand(querySDtnt, con);
                cmds.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdrs = cmds.ExecuteReader();
                while (rdrs.Read())
                {
                    
                        if (val == Convert.ToInt32(rdrs["StoreGroupID"]))
                        {
                            selectList.Add(new SelectListItem
                            {
                                Value = rdrs["StoreGroupID"].ToString(),
                                Text = rdrs["name"].ToString(),
                                Selected = true

                            });
                        }
                        else
                        {
                            selectList.Add(new SelectListItem
                            {
                                Value = rdrs["StoreGroupID"].ToString(),
                                Text = rdrs["name"].ToString(),
                            });

                        }

                }
            }

            ViewBag.StoreGroupID = selectList;

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
