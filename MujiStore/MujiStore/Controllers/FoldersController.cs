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
using System.Configuration;
using System.Data.SqlClient;

namespace MujiStore.Controllers
{
    [SessionExpire]
    [Authorize]
    [MUJICustomAuthorize(Roles = "16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31")]
    public class FoldersController : BaseController
    {
        private mujiEntities1 db = new mujiEntities1();
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;

        // GET: Folders
        public ActionResult Index(int? id)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;

            List<SelectListItem> lstFolderName = new List<SelectListItem>();
            lstFolderName = BLL.CommonLogic.FillFolderListNew();
            ViewBag.ParentID = new SelectList(lstFolderName, "Value", "Text");
            if(id == -1)
            {
                TempData["SuccMsg"] = MujiStore.Resources.Resource.Youcannotedittherootfolder;
                return RedirectToAction("Index", new { id = string.Empty });
            }
            if (id == null)
            {
                id = 0;
            }

            tblFolder tfolder = db.tblFolders.Find(id);
            if (id == 0 || id == -1)
            {
                ViewBag.ParentID = new SelectList(lstFolderName, "Value", "Text");
            }
            else
            {
                ViewBag.ParentID = new SelectList(lstFolderName, "Value", "Text", tfolder.ParentID);
            }
            
            if (tfolder != null)
            {
                ViewBag.StoreGroupDetails = GetStoreGroupByFolder(tfolder.FolderID);
            }


              BindStoreGroup(0);
 
            try
            {

 

                //Sabeena San 2021/03/05
                ViewData["FoldDTl"] = BLL.CommonLogic.GetFolderStructure();
                 return View(tfolder);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }

     

        public List<tblStoreGroup> GetStoreGroupByFolder(int folderid)
        {
            List<tblStoreGroup> sgdetails = new List<tblStoreGroup>();
            

            string query = "Select StoreGroupID,Name StoreGroupName";
            query += " from ";
            query += " tblstoregroup where StoreGroupID in ";
            query += " (Select StoreGroupID from tblStoreGroupFolder where FolderID =@FolderID  ";
            query += "  and DELFG = 0 ) and DELFG = 0";

            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@FolderID", folderid);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        
                        while (sdr.Read())
                        {
                            tblStoreGroup sg = new tblStoreGroup();
                            sg.StoreGroupID = Convert.ToInt32(sdr["StoreGroupID"]);
                            sg.StoreGroupName = sdr["StoreGroupName"].ToString();
                            sgdetails.Add(sg);
                        }
                        
                    }
                    con.Close();
                }
            }
            return sgdetails;
        }
        public void BindStoreGroup(int? val)
        {

            List<SelectListItem> videoList = new List<SelectListItem>();
            string query = "Select StoreGroupID,Name ";
            query += " from ";
            query += " tblstoregroup where DELFG = 0";

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

 

                            videoList.Add(new SelectListItem
                            {
                                Value = Convert.ToString(sdr["StoreGroupID"]),
                                Text = Convert.ToString(sdr["Name"]),
  
                            });


                        }
                    }
                    con.Close();
                }
            }

            var selectList = new List<SelectListItem>();
   
            foreach (var element in videoList)
            {
                if (val == Convert.ToInt32(element.Value))
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.Value,
                        Text = element.Text,
                        Selected = true

                    });
                }
                else
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.Value,
                        Text = element.Text
                    });

                }

            }

            ViewBag.StoreGroupID = selectList;


        }
        // GET: Folders/Details/5
        [NonAction]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFolder folder = db.tblFolders.Find(id);
            if (folder == null)
            {
                return HttpNotFound();
            }
            return View(folder);
        }

        // GET: Folders/Create
        [NonAction]
        public ActionResult Create()
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                List<SelectListItem> lstFolderName = new List<SelectListItem>();
                lstFolderName = BLL.CommonLogic.FillFolderList();
                ViewBag.ParentID = new SelectList(lstFolderName, "Value", "Text");
                return View();
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }

        // POST: Folders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [NonAction]
        public ActionResult Create([Bind(Include = "FolderID,ParentID,Name")] tblFolder folder)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            
            List<SelectListItem> lstFolderName = new List<SelectListItem>();
            lstFolderName = BLL.CommonLogic.FillFolderList();
            ViewBag.ParentID = new SelectList(lstFolderName, "Value", "Text", folder.FolderID);
            try
            {
                var sname = db.tblFolders.Where(x => x.Name.ToLower().Trim().ToString() == folder.Name.ToLower().ToString()).FirstOrDefault();
                if (sname != null)
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntFoldersCreateErrMsg;
                    //return View(folder);
                    return RedirectToAction("Index");
                }

                if (ModelState.IsValid)
                {
                   
                    LogInfo.Comments = MujiStore.Resources.Resource.CommonNameFolderCreated + folder.Name.ToString();

                    folder.DELFG = false;
                    folder.CRTDT = DateTime.Now;
                    folder.CRTCD = Session["UserName"].ToString();
                    folder.IPAddress = Session["IPAddress"].ToString();
                    db.tblFolders.Add(folder);
                    db.SaveChanges();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.CntFoldersCreateSuccMsg;
                    return RedirectToAction("Index");
                }
                
                return View(folder);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = MujiStore.Resources.Resource.CommonNameUnableCreateFolder;
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }

        
        public ActionResult DeleteStoreGroup(int storeGroupID,int folderID)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;
            string query = "";

            try
            {
                ViewData["FoldDTl"] = BLL.CommonLogic.GetFolderStructure();

                tblFolder tfolder = db.tblFolders.Find(folderID);

                List<SelectListItem> lstFolderName = new List<SelectListItem>();
                lstFolderName = BLL.CommonLogic.FillFolderListNew();
                ViewBag.ParentID = new SelectList(lstFolderName, "Value", "Text", tfolder.ParentID);
                BindStoreGroup(0);
                ViewBag.StoreGroupDetails = GetStoreGroupByFolder(folderID);


                LogInfo.Comments = "Store Group Folder Deleted - Store Group ID " + storeGroupID + " - Folder ID "+ folderID;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    query = "Delete from tblStoreGroupFolder where StoreGroupID = @StoreGroupID and FolderID = @FolderID ";
                    SqlCommand cmdApp = new SqlCommand(query, con);
                    cmdApp.Parameters.AddWithValue("@StoreGroupID", storeGroupID);
                    cmdApp.Parameters.AddWithValue("@FolderID", folderID);
                    cmdApp.CommandType = CommandType.Text;
                    con.Open();
                    result = cmdApp.ExecuteNonQuery();
                }
                CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                TempData["SuccMsg"] = MujiStore.Resources.Resource.CntStoreGroupFoldersDeletedSuccMsg;
                return RedirectToAction("Index", new { id = folderID });
                
   
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }
       
        [HttpPost]
        public ActionResult AddStoreGroup(tblFolder folder)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;
            string query = "";
            folder.UPDDT = DateTime.Now;
            folder.UPDCD = Session["UserName"].ToString();
            folder.IPAddress = Session["IPAddress"].ToString();

            ViewData["FoldDTl"] = BLL.CommonLogic.GetFolderStructure();

            tblFolder tfolder = db.tblFolders.Find(folder.FolderID);

            List<SelectListItem> lstFolderName = new List<SelectListItem>();
            lstFolderName = BLL.CommonLogic.FillFolderListNew();


            if (tfolder == null)
            {
                ViewBag.ParentID = new SelectList(lstFolderName, "Value", "Text");
                BindStoreGroup(0);
            }
            else
            {
                ViewBag.ParentID = new SelectList(lstFolderName, "Value", "Text", tfolder.ParentID);
                BindStoreGroup(folder.StoreGroupID);
            }

            
            ViewBag.StoreGroupDetails = GetStoreGroupByFolder(folder.FolderID);

            if (folder.FolderID == 0)
            {
                TempData["SuccMsg"] = MujiStore.Resources.Resource.Nofolderisselected;
                
                return RedirectToAction("Index", new { id = string.Empty });
            }

            if(folder.StoreGroupID == 0)
            {
                TempData["SuccMsg"] = MujiStore.Resources.Resource.NoStoreGroupisselected;
                return RedirectToAction("Index", new { id = folder.FolderID });
            }


            try
            {
                LogInfo.Comments = "Store Group Folder Deleted - Store Group ID " + folder.StoreGroupID + " - Folder ID " + folder.FolderID;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    query = "  if not exists (select StoreGroupFolderID from tblStoreGroupFolder where StoreGroupID = @StoreGroupID and FolderID = @FolderID and DELFG = 0 ) ";
                    query += " begin ";
                    query += " if exists (select top 1 StoreGroupFolderID from tblStoreGroupFolder where StoreGroupID = @StoreGroupID and FolderID = @FolderID and DELFG = 1 ) ";
                    query += " begin ";
                    query += " update tblStoreGroupFolder set DELFG = 0,UPDDT=@UPDDT,UPDCD=@UPDCD,IPAddress=@IPAddress where StoreGroupFolderID in ";
                    query += " (select top 1 StoreGroupFolderID from tblStoreGroupFolder where StoreGroupID = @StoreGroupID and FolderID = @FolderID and DELFG = 1) ";
                    query += " end ";
                    query += " else ";
                    query += " begin ";
                    query += " insert into tblStoreGroupFolder(StoreGroupID,FolderID,DELFG,CRTDT,CRTCD,IPAddress) ";
                    query += " values (@StoreGroupID,@FolderID,0,@UPDDT,@UPDCD,@IPAddress) ";
                    query += " end ";
                    query += " end ";
                    SqlCommand cmdApp = new SqlCommand(query, con);
                    cmdApp.Parameters.AddWithValue("@StoreGroupID", folder.StoreGroupID);
                    cmdApp.Parameters.AddWithValue("@FolderID", folder.FolderID);
                    cmdApp.Parameters.AddWithValue("@UPDDT", folder.UPDDT);
                    cmdApp.Parameters.AddWithValue("@UPDCD", folder.UPDCD);
                    cmdApp.Parameters.AddWithValue("@IPAddress", folder.IPAddress);
                    cmdApp.CommandType = CommandType.Text;
                    con.Open();
                    result = cmdApp.ExecuteNonQuery();
                }
                CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                TempData["SuccMsg"] = MujiStore.Resources.Resource.CntStoreGroupFoldersCreateSuccMsg;
                return RedirectToAction("Index", new { id = folder.FolderID });

            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }
        [NonAction]
        public ActionResult Edit(int? id)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblFolder folder = db.tblFolders.Find(id);
                if (folder == null)
                {
                    return HttpNotFound();
                }

                List<SelectListItem> lstFolderName = new List<SelectListItem>();
                lstFolderName = BLL.CommonLogic.FillFolderList();
                ViewBag.ParentID = new SelectList(lstFolderName, "Value", "Text", folder.ParentID);

                //ViewBag.ParentID = new SelectList(db.tblFolders.Where(x => x.DELFG == false), "FolderID", "Name", folder.ParentID);
                return View(folder);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }
        // POST: Folders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [NonAction]
        public ActionResult Edit([Bind(Include = "FolderID,ParentID,Name,DELFG,CRTDT,CRTCD")] tblFolder folder)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                List<SelectListItem> lstFolderName = new List<SelectListItem>();
                lstFolderName = BLL.CommonLogic.FillFolderList();
                ViewBag.ParentID = new SelectList(lstFolderName, "Value", "Text", folder.ParentID);



                var fname = db.tblFolders.Where(x => x.Name.ToLower().Trim().ToString() == folder.Name.ToLower().ToString() && x.FolderID != folder.FolderID).FirstOrDefault();
                if (fname != null)
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntFoldersEditErrMsg1;
                    return View(folder);
                }

                var pcCheck = db.tblFolders.Where(x => x.ParentID == folder.FolderID && x.FolderID == folder.ParentID).FirstOrDefault();
                if (pcCheck != null)
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntFoldersEditErrMsg2;
                    return View(folder);
                }

                if (folder.FolderID == folder.ParentID)
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntFoldersEditErrMsg2;
                    return View(folder);
                }
                if (ModelState.IsValid)
                {
                    //Sabeena San 2021/03/05
                    if (folder.ParentID == 0 && folder.FolderID == 1)
                    {
                        folder.ParentID = -1;
                    }
                    //Sabeena San 2021/03/05

                    LogInfo.Comments = @MujiStore.Resources.Resource.CommonFolderUpdated + folder.Name.ToString();
                    folder.UPDDT = DateTime.Now;
                    folder.UPDCD = Session["UserName"].ToString();
                    folder.IPAddress = Session["IPAddress"].ToString();
                    db.Entry(folder).State = EntityState.Modified;
                    db.SaveChanges();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.CntFoldersEditSuccMsg1;
                    return RedirectToAction("Index");
                }
                
                TempData["ErrMsg"] = MujiStore.Resources.Resource.CntFoldersEditErrMsg3;
                return View(folder);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = MujiStore.Resources.Resource.CommonFolderUnableUpdateFolder;
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "FolderID,StoreGroupID,ParentID,Name,DELFG,CRTDT,CRTCD")] tblFolder folder)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                ViewData["FoldDTl"] = BLL.CommonLogic.GetFolderStructure();

                List<SelectListItem> lstFolderName = new List<SelectListItem>();
                lstFolderName = BLL.CommonLogic.FillFolderListNew();
                ViewBag.ParentID = new SelectList(lstFolderName, "Value", "Text", folder.ParentID);
                BindStoreGroup(0);
                ViewBag.StoreGroupDetails = GetStoreGroupByFolder(folder.FolderID);
               

                if (folder.FolderID == 0)
                {
 
                    ModelState["FolderID"].Errors.Clear();
                    ModelState["DELFG"].Errors.Clear();
                    ModelState["CRTDT"].Errors.Clear();

                    if (ModelState.IsValid)
                    {

                        LogInfo.Comments = MujiStore.Resources.Resource.CommonNameFolderCreated + folder.Name.ToString();

                        folder.DELFG = false;
                        folder.CRTDT = DateTime.Now;
                        folder.CRTCD = Session["UserName"].ToString();
                        folder.IPAddress = Session["IPAddress"].ToString();
                        db.tblFolders.Add(folder);
                        db.SaveChanges();
                        CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                        TempData["SuccMsg"] = MujiStore.Resources.Resource.CntFoldersCreateSuccMsg;
                        return RedirectToAction("Index");
                    }

                    if (ModelState["Name"].Errors.Count == 1)
                    {
                        TempData["SuccMsg"] = MujiStore.Resources.Resource.ModtblFolderParentIDDataAnnaValida3;
                    }
                    

                    return View(folder);
                }
                else
                {
 

                    var pcCheck = db.tblFolders.Where(x => x.ParentID == folder.FolderID && x.FolderID == folder.ParentID).FirstOrDefault();
                    if (pcCheck != null)
                    {
                        TempData["ErrMsg"] = MujiStore.Resources.Resource.CntFoldersEditErrMsg2;
                        return View(folder);
                    }

                    if (folder.FolderID == folder.ParentID)
                    {
                        TempData["ErrMsg"] = MujiStore.Resources.Resource.CntFoldersEditErrMsg2;
                        return View(folder);
                    }
                    if (ModelState.IsValid)
                    {
                        //Sabeena San 2021/03/05
                        if (folder.ParentID == 0 && folder.FolderID == 1)
                        {
                            folder.ParentID = -1;
                        }
                        //Sabeena San 2021/03/05

                        LogInfo.Comments = @MujiStore.Resources.Resource.CommonFolderUpdated + folder.Name.ToString();
                        folder.UPDDT = DateTime.Now;
                        folder.UPDCD = Session["UserName"].ToString();
                        folder.IPAddress = Session["IPAddress"].ToString();
                        db.Entry(folder).State = EntityState.Modified;
                        db.SaveChanges();
                        CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                        TempData["SuccMsg"] = MujiStore.Resources.Resource.CntFoldersEditSuccMsg1;
                        //return RedirectToAction("Index");
                        return RedirectToAction("Index", new { id = string.Empty });
                    }

                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntFoldersEditErrMsg3;
                    return View(folder);
                }
 

                
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = MujiStore.Resources.Resource.CommonFolderUnableUpdateFolder;
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

        }
        // GET: Folders/Delete/5
        [NonAction]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFolder folder = db.tblFolders.Find(id);
            if (folder == null)
            {
                return HttpNotFound();
            }
            return View(folder);
        }

        // POST: Folders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [NonAction]
        public ActionResult DeleteConfirmed(int id)
        {
            tblFolder folder = db.tblFolders.Find(id);
            db.tblFolders.Remove(folder);
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
    }
}
