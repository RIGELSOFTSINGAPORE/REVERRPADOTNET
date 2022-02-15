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
    public class StoreGroupsController : BaseController
    {
        private mujiEntities1 db = new mujiEntities1();

        // GET: StoreGroups
        public ActionResult Index(int? page,string status, int? page1)
        {
            string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;

            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;

            var lan = Session["CreateSpecificCulture"];
            ViewBag.Language = lan;

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
                

                List<tblStoreGroup> StoreList = new List<tblStoreGroup>();
                string query = "select * from tblStoreGroup  Order by storegroupid Desc ";
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
                                StoreList.Add(new tblStoreGroup
                                {
                                    // MediaID,Title,Description,Video,ConvertStatus,FolderID
                                    Name = Convert.ToString(sdr["Name"]),
                                    DELFG = Convert.ToBoolean(sdr["DELFG"]),
                                    StoreGroupID = Convert.ToInt32(sdr["StoreGroupID"])

                                });
                            }
                        }
                        con.Close();
                    }
                }
                if (StoreList.Count >= 1)
                {
                    if (status != null)
                    {
                        TempData["SuccMsg"] = MujiStore.Resources.Resource.Storegroupdeletedsucessfully;
                    }
                    ViewData["StoreInfo"] = StoreList.OrderByDescending(x => x.StoreGroupID).ToPagedList(pageNumber, pageSize);
                    return View();
                }
                else
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.Nodata;
                    ViewData["StoreInfo"] = StoreList.OrderByDescending(x => x.StoreGroupID).ToPagedList(pageNumber, pageSize);
                    return View();
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
        // GET: StoreGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStoreGroup tblStoreGroup = db.tblStoreGroups.Find(id);
            if (tblStoreGroup == null)
            {
                return HttpNotFound();
            }
            return View(tblStoreGroup);
        }

        // GET: StoreGroups/Create
        public ActionResult Create(int? page)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
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

        // POST: StoreGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StoreGroupID,Name,DELFG,CRTDT,CRTCD,UPDDT,UPDCD,IPAddress,page")] tblStoreGroup tblStoreGroup)
        {
         
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                if (ModelState.IsValid)
                {
                    int StoreGroupCnt = CheckStoreGroupNameExists(tblStoreGroup.Name, 0);
                    if (StoreGroupCnt != 0)
                    {
                        TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreGroupsCreateErrMsg2;
                        return View(tblStoreGroup);
                    }
                    LogInfo.Comments = @MujiStore.Resources.Resource.StoreGroupCreateCommon + tblStoreGroup.Name.Trim();

                    tblStoreGroup.CRTDT = DateTime.Now;
                    tblStoreGroup.CRTCD = Session["UserName"].ToString();
                    tblStoreGroup.IPAddress = Session["IPAddress"].ToString();
                    tblStoreGroup.DELFG = false;

                    db.tblStoreGroups.Add(tblStoreGroup);
                    db.SaveChanges();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.CntStoreGroupsCreateSuccMsg;
                    return RedirectToAction("Index", new { page = tblStoreGroup.page });
                }
               
                TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreGroupsCreateErrMsg1;

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                if (((System.Data.SqlClient.SqlException)ex.InnerException.InnerException).Number == 2627)
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreGroupsCreateErrMsg2;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreGroupsCreateErrMsg3;
                    return RedirectToAction("Index");
                }
                
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }

        // GET: StoreGroups/Edit/5
        public ActionResult Edit(int? id, int? page)
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
                tblStoreGroup tblStoregroup = db.tblStoreGroups.Find(id);
                
                if (tblStoregroup == null)
                {
                    return HttpNotFound();
                }
                int pageNumber = (page ?? 1);
                tblStoregroup.page = pageNumber;
                return View(tblStoregroup);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }

        // POST: StoreGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StoreGroupID,Name,DELFG,CRTDT,CRTCD,UPDDT,UPDCD,IPAddress,page")] tblStoreGroup tblStoreGroup)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                if (ModelState.IsValid)
                {
                    if (tblStoreGroup.DELFG == false)
                    {
                        int StoreGroupCnt = CheckStoreGroupNameExists(tblStoreGroup.Name, tblStoreGroup.StoreGroupID);
                        if (StoreGroupCnt != 0)
                        {
                            TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreGroupsEditErrMsg2;
                            return View(tblStoreGroup);
                        }
                    }

                    LogInfo.Comments = @MujiStore.Resources.Resource.StoreGroupCreateCommon + tblStoreGroup.Name.Trim();

                    tblStoreGroup.UPDDT = DateTime.Now;
                    tblStoreGroup.UPDCD = Session["UserName"].ToString();
                    tblStoreGroup.IPAddress = Session["IPAddress"].ToString();
                    db.Entry(tblStoreGroup).State = EntityState.Modified;
                    db.SaveChanges();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.CntStoreGroupsEditSuccMsg;
                    return RedirectToAction("Index", new { page = tblStoreGroup.page });
                }
                TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreGroupsEditErrMsg1;
                return View(tblStoreGroup);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                if (((System.Data.SqlClient.SqlException)ex.InnerException.InnerException).Number == 2627)
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreGroupsEditErrMsg2;
                }
                else
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreGroupsEditErrMsg3;
                }
               
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }
        [NonAction]
        // GET: StoreGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStoreGroup tblStoreGroup = db.tblStoreGroups.Find(id);
            if (tblStoreGroup == null)
            {
                return HttpNotFound();
            }
            return View(tblStoreGroup);
        }
        [NonAction]
        // POST: StoreGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblStoreGroup tblStoreGroup = db.tblStoreGroups.Find(id);
            db.tblStoreGroups.Remove(tblStoreGroup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public static int CheckStoreGroupNameExists(string storeGroupName, int StoreGroupID)
        {
            int result = 0;
            string query = "";
            string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {

                query = "select count(*) Cnt from tblStoreGroup where Name =@Name and StoreGroupID <> @StoreGroupID and DELFG = 0";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", storeGroupName);
                cmd.Parameters.AddWithValue("@StoreGroupID", StoreGroupID);
                cmd.CommandType = CommandType.Text;
                con.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());


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
                deletestoregroupfolder(ID);
                deletestoreSubnet(ID);
                deletestore(ID);
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string query = "";
                    con.Open();
                    SqlCommand cmd;
                    tblUser tblUser = new tblUser();


                    //Assing Query String
                    query = "Delete From  tblstoregroup where storegroupID=@storegroupID";
                   



                    //Intialize Command and pass the paramters


                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@storegroupID", ID);
                 

                    cmd.CommandType = CommandType.Text;
                    result = cmd.ExecuteNonQuery();


                }
                if (result == 1)
                {

                    LogInfo.Comments = "StoreGroup Updated - " + ID.ToString();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.UserDeletedSuccessfully;
                    return RedirectToAction("Index");

                }
                else
                {
                    LogInfo.Comments = "StoreGroup Updated - " + ID.ToString();
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
        public  void deletestoregroupfolder(int StoreGroupId)
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
                    query = "Delete from tblStoreGroupFolder where  StoreGroupId=@StoreGroupId";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@StoregroupId", StoreGroupId);
                    cmd.CommandType = CommandType.Text;
                    result = cmd.ExecuteNonQuery();
                }
                if (result == 1)
                {
                    LogInfo.Comments = "StoreGroupfolder Updated - " + StoreGroupId.ToString();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                }
                else
                {
                    LogInfo.Comments = "StoreGroup Updated - " + StoreGroupId.ToString();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                }
            }


            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }
        }
        public void deletestore(int StoreGroupId)
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
                    query = "Delete from tblStore where  StoreGroupId=@StoreGroupId";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@StoregroupId", StoreGroupId);
                    cmd.CommandType = CommandType.Text;
                    result = cmd.ExecuteNonQuery();
                }
                if (result == 1)
                {
                    LogInfo.Comments = "StoreGroupfolder Updated - " + StoreGroupId.ToString();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                }
                else
                {
                    LogInfo.Comments = "StoreGroup Updated - " + StoreGroupId.ToString();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                }
            }


            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }
        }
        public void deletestoreSubnet(int StoreGroupId)
        {
            string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;
            int storeid=0;
            try
            {

                using (SqlConnection con = new SqlConnection(CS))
                {
                    string query = "";
                    con.Open();
                   
                    SqlCommand cmd;
                    

                    query = "Delete from tblStoreSubnet where store in " +
                        "(Select StoreID from tblStore where StoreGroupID = @StoreGroupId)";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@StoreGroupId", StoreGroupId);
                    cmd.CommandType = CommandType.Text;
                    result = cmd.ExecuteNonQuery();
                }
                if (result == 1)
                {
                    LogInfo.Comments = "StoreGroupfolder Updated - " + StoreGroupId.ToString();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                }
                else
                {
                    LogInfo.Comments = "StoreGroup Updated - " + StoreGroupId.ToString();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                }
            }


            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }
        }
    }
}
