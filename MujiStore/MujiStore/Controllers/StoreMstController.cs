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
    public class StoreMstController : BaseController
    {
        private mujiEntities1 db = new mujiEntities1();
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        // GET: StoreMst
        [NonAction]
        public ActionResult Index(int? page,  string SearchID,string status, string sortOrder,int ? page1)
        {
            string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;

            int pageSize;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.IDSortnumber = sortOrder == "ID" ? "ID_desc" : "ID";

            if (System.Configuration.ConfigurationManager.AppSettings["PageSize"] == null)
            {
                pageSize = 10;
            }
            else
            {
                pageSize = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["PageSize"].ToString());
            }

            int pageNumber = (page ?? 1);
            if(page1 != null)
            {
                status = "sucess";
                pageNumber = Convert.ToInt16(page1);
            }

            ViewBag.SearchID = SearchID;
            try
            {
                List<tblStore> StoreList = new List<tblStore>();
                string query = "SELECT TRY_CONVERT(int,S.StoreNumber)[StoreNumber],S.[storeID], S.[storeName],s.AddressLine1,s.AddressLine2,s.City,s.State,s.zip,s.country,  G.[Name] AS GroupName ,s.DELFG ";
                query = query + "FROM tblStore AS S   ";
                query = query + "LEFT JOIN tblStoreGroup AS G ON S.StoreGroupID = G.StoreGroupID   ";

                if (SearchID != null && SearchID != "" && SearchID != string.Empty)
                {
                    query = query + " WHERE (S.[StoreName] LIKE  @StoreName  or  S.[StoreNumber] LIKE  @StoreID )";


                    query = query + " and G.Physical_DELFG = 0  and s.Physical_DELFG=0 and TRY_CONVERT(int,S.StoreNumber) is not null Order by [storeID] ASC";

                    using (SqlConnection con = new SqlConnection(CS))
                    {

                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            con.Open();
                            cmd.Parameters.AddWithValue("@StoreName", "%" + SearchID + "%");
                            cmd.Parameters.AddWithValue("@StoreID",  "%" + SearchID + "%");
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    StoreList.Add(new tblStore
                                    {
                                        // MediaID,Title,Description,Video,ConvertStatus,FolderID
                                        StoreID = Convert.ToInt32(sdr["StoreID"]),
                                        StoreNumber = Convert.ToInt32(sdr["StoreNumber"]),
                                        StoreName = Convert.ToString(sdr["StoreName"]),
                                        AddressLine1 = Convert.ToString(sdr["AddressLine1"]),
                                        AddressLine2 = Convert.ToString(sdr["AddressLine2"]),
                                        City = Convert.ToString(sdr["City"]),
                                        State = Convert.ToString(sdr["State"]),
                                        Zip = Convert.ToString(sdr["Zip"]),
                                        Country=Convert.ToString(sdr["Country"]),
                                        Storegroupname = Convert.ToString(sdr["GroupName"]),
                                        DELFG = Convert.ToBoolean(sdr["DELFG"])

                                    });
                                }
                            }
                            con.Close();
                        }
                        switch (sortOrder)
                        {
                      
                            case "ID":
                                StoreList = StoreList.OrderBy(o => o.StoreNumber).ToList();
                                break;
                            case "ID_desc":
                                StoreList = StoreList.OrderByDescending(o => o.StoreNumber).ToList();
                                break;
                        }
                    }
                    if (StoreList.Count >= 1)
                    {
                        if (status != null)
                        {
                            TempData["SuccMsg"] = MujiStore.Resources.Resource.Storedeletedsucessfully;
                        }
                        ViewData["StoreInfo"] = StoreList.ToPagedList(pageNumber, pageSize);
                        return View();
                    }
                    else
                    {
                        TempData["ErrMsg"] = MujiStore.Resources.Resource.Nodata;
                        ViewData["StoreInfo"] = StoreList.OrderByDescending(x => x.StoreID).ToPagedList(pageNumber, pageSize);
                        return View();
                    }

                }
                else
                {
                    query = query + " where s.Physical_DELFG=0 and G.Physical_DELFG = 0 and TRY_CONVERT(int,S.StoreNumber) is not null Order by [storeID] ASC";

                   

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
                                    
                                    StoreList.Add(new tblStore
                                    {
                                        // MediaID,Title,Description,Video,ConvertStatus,FolderID
                                        StoreID = Convert.ToInt32(sdr["StoreID"]),
                                        StoreNumber = Convert.ToInt32(sdr["StoreNumber"]),
                                        StoreName = Convert.ToString(sdr["StoreName"]),
                                        AddressLine1 = Convert.ToString(sdr["AddressLine1"]),
                                        AddressLine2 = Convert.ToString(sdr["AddressLine2"]),
                                        City = Convert.ToString(sdr["City"]),
                                        State = Convert.ToString(sdr["State"]),
                                        Zip = Convert.ToString(sdr["Zip"]),
                                        Country = Convert.ToString(sdr["Country"]),
                                        Storegroupname = Convert.ToString(sdr["GroupName"]),
                                        DELFG = Convert.ToBoolean(sdr["DELFG"])

                                    });
                                }
                            }
                            con.Close();
                        }
                        switch (sortOrder)
                        {
                            
                            case "ID":
                                StoreList = StoreList.OrderBy(o => o.StoreNumber).ToList();
                                break;
                            case "ID_desc":
                                StoreList = StoreList.OrderByDescending(o => o.StoreNumber).ToList();
                                break;
                        }
                    }
                    if (status != null)
                    {
                        TempData["SuccMsg"] = MujiStore.Resources.Resource.Storedeletedsucessfully;
                    }
                    ViewData["StoreInfo"] = StoreList.ToPagedList(pageNumber, pageSize);
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

        // GET: StoreMst/Details/5
        [NonAction]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStore tblStore = db.tblStores.Find(id);
            if (tblStore == null)
            {
                return HttpNotFound();
            }
            return View(tblStore);
        }

        // GET: StoreMst/Create
        [NonAction]
        public ActionResult Create( int? page)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
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

        public void BindStoreGroup(int? val)
        {
            string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            
            
             List<SelectListItem> videoList = new List<SelectListItem>();
            
            string query = "Select StoreGroupID,Name ";
            query += " from ";
            query += " tblstoregroup where DELFG = 0 ";

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

                            // MediaID,Title,Description,Video,ConvertStatus,FolderID

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
            selectList.Add(new SelectListItem
            {
                Value = "0",
                Text = MujiStore.Resources.Resource.dropselect
            });
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
        

        // POST: StoreMst/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [NonAction]
        public ActionResult Create([Bind(Include = "StoreID,StoreNumber,StoreName,AddressLine1,AddressLine2,City,State,Zip,Country,DELFG,CRTDT,CRTCD,UPDDT,UPDCD,IPAddress,StoreIPAddress,StoreGroupID,page")] tblStore tblVideoDemoStoreMst)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;
            try
            {
                ModelState["StoreGroupID"].Errors.Clear();
                BindStoreGroup(tblVideoDemoStoreMst.StoreGroupID);
                if (ModelState.IsValid)
                {


                 

                    int StoreCnt = CheckStoreNameExists(tblVideoDemoStoreMst.StoreName, 0);
                    if (StoreCnt != 0)
                    {
                        TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreMstCreateErrMsg1;
                        return View(tblVideoDemoStoreMst);
                    }

                    int StoreNumCnt = CheckStoreNumberExists(tblVideoDemoStoreMst.StoreNumber.ToString(), 0);
                    if (StoreNumCnt != 0)
                    {
                        TempData["ErrMsg"] = MujiStore.Resources.Resource.StoreNumberAlreadyExists;
                        return View(tblVideoDemoStoreMst);
                    }

                    if (tblVideoDemoStoreMst.StoreGroupID == 0)
                    {
                        
                        ModelState.AddModelError("StoreGroupID", MujiStore.Resources.Resource.selectstoregroupID);
                        return View(tblVideoDemoStoreMst);
                    }
                    tblVideoDemoStoreMst.CRTDT = DateTime.Now;
                    tblVideoDemoStoreMst.CRTCD = Session["UserName"].ToString();
                    tblVideoDemoStoreMst.IPAddress = Session["IPAddress"].ToString();
                    tblVideoDemoStoreMst.DELFG = false;

                    using (SqlConnection con = new SqlConnection(CS))
                    {
                      
                        con.Open();
                        string query = "";
                        query = "Insert into  tblStore(StoreName,AddressLine1,AddressLine2,City,State,Zip, ";
                        query += " Country,StoreGroupID,StoreNumber,DELFG,CRTDT, ";
                        query += " CRTCD,IPAddress,Physical_DELFG ";

                        query += ") Values ( ";
                        query += "N'" + tblVideoDemoStoreMst.StoreName + "',N'" + tblVideoDemoStoreMst.AddressLine1 + "',";
                        query += "N'" + tblVideoDemoStoreMst.AddressLine2 + "',N'" + tblVideoDemoStoreMst.City + "',";
                        query += "N'" + tblVideoDemoStoreMst.State + "',N'" + tblVideoDemoStoreMst.Zip + "',";
                        query += "N'" + tblVideoDemoStoreMst.Country + "','" + tblVideoDemoStoreMst.StoreGroupID + "',";
                        query += "N'" + tblVideoDemoStoreMst.StoreNumber + "','0','" + DateTime.Now + "',N'"+ tblVideoDemoStoreMst.CRTCD  + "',";
                        query += "'"+ tblVideoDemoStoreMst.IPAddress  + "','0' )";
                      
                        SqlCommand cmd;
                        cmd = new SqlCommand(query, con);
                        cmd.CommandType = CommandType.Text;
                        result = cmd.ExecuteNonQuery();

                       
                    }
                    LogInfo.Comments = "Store Created - " + tblVideoDemoStoreMst.StoreNumber;

                    



               
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.CntStoreMstCreateSuccMsg;
                    return RedirectToAction("Index", new { page = tblVideoDemoStoreMst.page });
                }
                if (tblVideoDemoStoreMst.StoreGroupID == null)
                {
                    tblVideoDemoStoreMst.StoreGroupID = 0;
                }
                
                TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreMstCreateErrMsg2;
                return View(tblVideoDemoStoreMst);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                if (((System.Data.SqlClient.SqlException)ex.InnerException.InnerException).Number == 2627)
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreMstCreateErrMsg3;
                }
                else
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreMstCreateErrMsg2;
                }
                TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreMstCreateErrMsg2;
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

            
        }

        // GET: StoreMst/Edit/5
        [NonAction]
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

                //tblStore tblStoreMst =  db.tblStores.Find(id);
                tblStore tblStoreMst = GetStoreDetails(id);
                BindStoreGroup(tblStoreMst.StoreGroupID);
                int pageNumber = (page ?? 1);
                tblStoreMst.page = pageNumber;
                if (tblStoreMst == null)
                {
                    return HttpNotFound();
                }
                return View(tblStoreMst);
            }
            catch(Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            
            //return View(tblStore);
        }

        public tblStore GetStoreDetails(int? StoreID)
        {
            tblStore tbstore = new tblStore();

            using (SqlConnection con = new SqlConnection(CS))
            {

                string query = "";
                query = " Select StoreID,StoreName,AddressLine1,AddressLine2,City,State, ";
                query += " Zip,Country,DELFG,CRTDT,CRTCD,UPDDT,UPDCD,IPAddress, ";
                query += " StoreGroupID,Physical_DELFG,StoreNumber ";
                query += " From tblstore where StoreID = @StoreID ";

                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@StoreID", StoreID);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader rdrs = cmd.ExecuteReader())
                    {
                        while (rdrs.Read())
                        {
                            tbstore.StoreID = Convert.ToInt32(rdrs["StoreID"]);
                            tbstore.StoreName = rdrs["StoreName"].ToString();
                            tbstore.AddressLine1 = rdrs["AddressLine1"].ToString();
                            tbstore.AddressLine2 = rdrs["AddressLine2"].ToString();
                            tbstore.City = rdrs["City"].ToString();
                            tbstore.State = rdrs["State"].ToString();
                            tbstore.Zip = rdrs["Zip"].ToString();
                            tbstore.Country = rdrs["Country"].ToString();
                            tbstore.DELFG = Convert.ToBoolean(rdrs["DELFG"].ToString());
                            tbstore.CRTCD = rdrs["CRTCD"].ToString();
                            tbstore.CRTDT = Convert.ToDateTime(rdrs["CRTDT"]);
                            tbstore.UPDCD = rdrs["UPDCD"].ToString();
                            tbstore.UPDDT = rdrs["UPDDT"].ToString() != "" ? Convert.ToDateTime(rdrs["UPDDT"].ToString()) : (DateTime?)null;
                            tbstore.IPAddress = rdrs["IPAddress"].ToString();
                            tbstore.StoreGroupID = Convert.ToInt32(rdrs["StoreGroupID"]);
                            tbstore.Physical_DELFG = Convert.ToBoolean(rdrs["Physical_DELFG"].ToString());
                            tbstore.StoreNumber = Convert.ToInt32(rdrs["StoreNumber"]);
                        }
                    }
                    con.Close();
                }
                

                

            
            }
            return tbstore;
        }
        // POST: StoreMst/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [NonAction]
        public ActionResult Edit([Bind(Include = "StoreID,StoreName,AddressLine1,AddressLine2,City,State,Zip,Country,DELFG,CRTDT,CRTCD,UPDDT,UPDCD,IPAddress,StoreIPAddress,StoreGroupID,StoreNumber,page")] tblStore tblStore)
        {
   
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;
            string query = "";
            try
            {
                BindStoreGroup(tblStore.StoreGroupID);

          
                if(tblStore.DELFG == false)
                {
                    int StoreCnt = CheckStoreNameExists(tblStore.StoreName, tblStore.StoreID);
                    if (StoreCnt != 0)
                    {
                        TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreMstEditErrMsg1;
                        return View(tblStore);
                    }

                    int StoreNumCnt = CheckStoreNumberExists(tblStore.StoreNumber.ToString(), tblStore.StoreID);
                    if (StoreNumCnt != 0)
                    {
                        TempData["ErrMsg"] = MujiStore.Resources.Resource.StoreNumberAlreadyExists;
                        return View(tblStore);
                    }
                }
                if (tblStore.StoreGroupID == 0)
                {
                    
                    ModelState.AddModelError("StoreGroupID", MujiStore.Resources.Resource.selectstoregroupID);
                    return View(tblStore);
                }
            
                if (ModelState.IsValid)
                {
                    
                    LogInfo.Comments = "Store Updated - " + tblStore.StoreName.Trim();

                    
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        tblStore.UPDDT = DateTime.Now;
                        tblStore.UPDCD = Session["UserName"].ToString();
                        tblStore.IPAddress = Session["IPAddress"].ToString();

                        query = " update tblstore set StoreName=@StoreName,AddressLine1=@AddressLine1, ";
                        query += " AddressLine2=@AddressLine2,City=@City,State=@State,Zip=@Zip, ";
                        query += " Country=@Country,DELFG=@DELFG,UPDDT=@UPDDT,UPDCD=@UPDCD, ";
                        query += " IPAddress=@IPAddress,StoreGroupID=@StoreGroupID,StoreNumber=@StoreNumber ";
                        query += " Where StoreID = @StoreID ";
                       
                        tblStore.AddressLine1 = tblStore.AddressLine1 != null ? tblStore.AddressLine1.ToString().Trim() : "";
                        tblStore.AddressLine2 = tblStore.AddressLine2 != null ? tblStore.AddressLine2.ToString().Trim() : "";
                        tblStore.City = tblStore.City != null ? tblStore.City.ToString().Trim() : "";
                        tblStore.State = tblStore.State != null ? tblStore.State.ToString().Trim() : "";
                        tblStore.Zip = tblStore.Zip != null ? tblStore.Zip.ToString().Trim() : "";
                        tblStore.Country = tblStore.Country != null ? tblStore.Country.ToString().Trim() : "";


                        SqlCommand cmdApp = new SqlCommand(query, con);
                        cmdApp.Parameters.AddWithValue("@StoreName", tblStore.StoreName.Trim().ToString());
                        cmdApp.Parameters.AddWithValue("@AddressLine1", tblStore.AddressLine1);
                        cmdApp.Parameters.AddWithValue("@AddressLine2", tblStore.AddressLine2);
                        cmdApp.Parameters.AddWithValue("@City", tblStore.City);
                        cmdApp.Parameters.AddWithValue("@State", tblStore.State);
                        cmdApp.Parameters.AddWithValue("@Zip", tblStore.Zip);
                        cmdApp.Parameters.AddWithValue("@Country", tblStore.Country);
                        cmdApp.Parameters.AddWithValue("@DELFG", tblStore.DELFG);
                        cmdApp.Parameters.AddWithValue("@UPDDT", tblStore.UPDDT);
                        cmdApp.Parameters.AddWithValue("@UPDCD", tblStore.UPDCD);
                        cmdApp.Parameters.AddWithValue("@IPAddress", tblStore.IPAddress.Trim().ToString());
                        cmdApp.Parameters.AddWithValue("@StoreGroupID", tblStore.StoreGroupID);
                        cmdApp.Parameters.AddWithValue("@StoreNumber", tblStore.StoreNumber);
                        cmdApp.Parameters.AddWithValue("@StoreID", tblStore.StoreID);

                        cmdApp.CommandType = CommandType.Text;
                        con.Open();
                        result = cmdApp.ExecuteNonQuery();
                 

                    }
                    
               



                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.CntStoreMstEditSuccMsg;
                    return RedirectToAction("Index",new { page = tblStore.page});
                    
                }
                TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreMstEditErrMsg2;
                return View(tblStore);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                 if (((System.Data.SqlClient.SqlException)ex.InnerException.InnerException).Number == 2627)
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreMstEditErrMsg3;
                }
                else
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreMstEditErrMsg2;
                }
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }
        [NonAction]
        // GET: StoreMst/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStore tblStore = db.tblStores.Find(id);
            if (tblStore == null)
            {
                return HttpNotFound();
            }
            return View(tblStore);
        }
        [NonAction]
        // POST: StoreMst/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblStore tblStore = db.tblStores.Find(id);
            db.tblStores.Remove(tblStore);
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
        [NonAction]
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
                    query = "UPDATE tblStore SET Physical_DELFG = 1, UPDDT=@UPDDT," +
                    " UPDCD=@UPDCD, IPAddress=@IPAddress where storeID=@UserID; ";



                    //Intialize Command and pass the paramters


                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@UserID", ID);
                    cmd.Parameters.AddWithValue("@UPDDT", DateTime.Now);
                    cmd.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                    cmd.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());

                    cmd.CommandType = CommandType.Text;
                    result = cmd.ExecuteNonQuery();


                }
                if (result == 1)
                {

                    LogInfo.Comments = "Store Updated - " + ID.ToString();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.UserDeletedSuccessfully;
                    return RedirectToAction("Index");

                }
                else
                {
                    LogInfo.Comments = "Store Updated - " + ID.ToString();
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


        public static int CheckStoreNameExists(string storeName, int StoreID)
        {
            int result = 0;
            string query = "";
            string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {

                query = "select count(*) Cnt from tblStore where StoreName =@StoreName and StoreID <> @StoreID and Physical_DELFG = 0 and DELFG = 0";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StoreName", storeName);
                cmd.Parameters.AddWithValue("@StoreID", StoreID);
                cmd.CommandType = CommandType.Text;
                con.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());

                
            }
            return result;
        }

        public static int CheckStoreNumberExists(string StoreNumber, int StoreID)
        {
            int result = 0;
            string query = "";
            string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {

                query = "select count(*) Cnt from tblStore where StoreNumber =@StoreNumber and StoreID <> @StoreID and Physical_DELFG = 0 and DELFG = 0";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StoreNumber", StoreNumber);
                cmd.Parameters.AddWithValue("@StoreID", StoreID);
                cmd.CommandType = CommandType.Text;
                con.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());

               
            }
            return result;
        }
    }
}