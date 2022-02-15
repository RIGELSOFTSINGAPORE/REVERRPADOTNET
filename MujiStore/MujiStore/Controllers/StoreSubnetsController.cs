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
    public class StoreSubnetsController : BaseController
    {
        private mujiEntities1 db = new mujiEntities1();
        static string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        // GET: StoreSubnets

        [NonAction]
        public ActionResult Index(int? page, string SearchID)
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
            ViewBag.SearchID = SearchID;
            try
            {
                List<tblStoreSubnet> StoreList = new List<tblStoreSubnet>();

                string query = "SELECT ts.StoreNumber,ss.StoreSubnetID,convert(varchar,tsn.SubnetNumber) + ' - '+ tsn.SNIPAddress as SNIPAddress ,ts.StoreName,ss.DELFG from tblstoreSubnet ss ";
                query = query + "join tblStore  ts  ";
                query = query + "on ss.store = ts.StoreID   ";
                query = query + "join tblsubnet  tsn   ";
                query = query + "on ss.Subnet = tsn.SubnetID  ";
                query = query + "left join tblStoreGroup tsb on ts.StoreGroupID=tsb.StoreGroupID  ";
                query = query + "where ts.DELFG = 0 and tsn.DELFG = 0";
                
                query = query + "and tsb.DELFG=0 ";

                if (SearchID != null && SearchID != "" && SearchID != string.Empty)
                {
                    query = "";
                    query = "SELECT ts.StoreNumber,ss.StoreSubnetID,convert(varchar,tsn.SubnetNumber) + ' - '+ tsn.SNIPAddress as SNIPAddress,ts.StoreName,ss.DELFG from tblstoreSubnet ss ";
                    query = query + "join tblStore  ts  ";
                    query = query + "on ss.store = ts.StoreID   ";
                    query = query + "join tblsubnet  tsn   ";
                    query = query + "on ss.Subnet = tsn.SubnetID  ";
                    query = query + "left join tblStoreGroup tsb on ts.StoreGroupID=tsb.StoreGroupID  ";
                    query = query + "where ts.DELFG = 0 and tsn.DELFG = 0 ";
                   
                    query = query + "and  tsb.DELFG=0 ";
                    query = query + " and (tsn.SNIPAddress like @SNIPAddress or tsn.SubnetNumber like  @SubnetNumber)";


                    query = query + " Order by ss.StoreSubnetID ASC";

                 

                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            con.Open();
                            cmd.Parameters.AddWithValue("@SNIPAddress", "%" + SearchID + "%");
                            cmd.Parameters.AddWithValue("@SubnetNumber", "%" + SearchID + "%");
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    StoreList.Add(new tblStoreSubnet
                                    {
                                 
                                        StoreNumber = Convert.ToString(sdr["StoreNumber"]),
                                        StoreSubnetID = Convert.ToInt32(sdr["StoreSubnetID"]),
                                        IPAddress = Convert.ToString(sdr["SNIPAddress"]),
                                        StoreName = Convert.ToString(sdr["StoreName"]),
                                        DELFG = Convert.ToBoolean(sdr["DELFG"])

                                    });
                                }
                            }
                            con.Close();
                        }
                    }
                    if (StoreList.Count >= 1)
                    {
                        ViewData["StoreInfo"] = StoreList.OrderByDescending(x => x.StoreSubnetID).ToPagedList(pageNumber, pageSize);
                        return View();
                    }
                    else
                    {
                        TempData["ErrMsg"] = MujiStore.Resources.Resource.Nodata;
                        ViewData["StoreInfo"] = StoreList.OrderByDescending(x => x.StoreSubnetID).ToPagedList(pageNumber, pageSize);
                        return View();
                    }
                }
                else
                {
                    query = query + " Order by ss.StoreSubnetID ASC";

                 

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
                                    StoreList.Add(new tblStoreSubnet
                                    {
                                       
                                        StoreNumber = Convert.ToString(sdr["StoreNumber"]),
                                        StoreSubnetID = Convert.ToInt32(sdr["StoreSubnetID"]),
                                        IPAddress = Convert.ToString(sdr["SNIPAddress"]),
                                        StoreName = Convert.ToString(sdr["StoreName"]),
                                        DELFG = Convert.ToBoolean(sdr["DELFG"])

                                    });
                                }
                            }
                            con.Close();
                        }
                    }

                    ViewData["StoreInfo"] = StoreList.OrderByDescending(x => x.StoreSubnetID).ToPagedList(pageNumber, pageSize);
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
        // GET: StoreSubnets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStoreSubnet tblStoreSubnet = db.tblStoreSubnets.Find(id);
            if (tblStoreSubnet == null)
            {
                return HttpNotFound();
            }
            return View(tblStoreSubnet);
        }

        // GET: StoreSubnets/Create
        public ActionResult Create(int? page)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                BindStore(0);
                
                BindSubnet(0);
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

        // POST: StoreSubnets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StoreSubnetID,Store,Subnet,DELFG,CRTDT,CRTCD,UPDDT,UPDCD,IPAddress,page")] tblStoreSubnet tblStoreSubnet)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;

            try
            {
                string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
                BindStore(tblStoreSubnet.Store);
                BindSubnet(tblStoreSubnet.Subnet);
               
                if (tblStoreSubnet.Store == 0)
                {
                
                    ModelState.AddModelError("Store", MujiStore.Resources.Resource.ModtblStoreSubnetStoreDataAnnaValida1);
                    
                }
                if (tblStoreSubnet.Subnet == 0)
                {
                    ModelState.AddModelError("Subnet",  MujiStore.Resources.Resource.ModtblStoreSubnetSubnetDataAnnaValida1);
                }
               
                if (ModelState.IsValid)
                {

                    
                    var tblstoreid = db.tblStoreSubnets.Where(x => x.Store == tblStoreSubnet.Store && x.DELFG == false).FirstOrDefault();
                    if (tblstoreid != null)
                    {
                        TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreSubnetsCreateErrMsg1;
                        return View(tblStoreSubnet);
                    }
                    var tblsubnetid = db.tblStoreSubnets.Where(x => x.Subnet == tblStoreSubnet.Subnet && x.DELFG == false).FirstOrDefault();
                    if (tblsubnetid != null)
                    {
                        TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreSubnetsCreateErrMsg1;
                        return View(tblStoreSubnet);
                    }
                    LogInfo.Comments = "Store Subnet Created - " + tblStoreSubnet.Store+ "," + tblStoreSubnet.tblSubnet;

                    tblStoreSubnet.CRTDT = DateTime.Now;
                    tblStoreSubnet.CRTCD = Session["UserName"].ToString();
                    tblStoreSubnet.IPAddress = Session["IPAddress"].ToString();
                    tblStoreSubnet.DELFG = false;
                    db.tblStoreSubnets.Add(tblStoreSubnet);
                    db.SaveChanges();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.CntStoreSubnetsCreateSuccMsg;
                    return RedirectToAction("Index", new { page = tblStoreSubnet.page });
                }
                
                TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreSubnetsCreateErrMsg2;

                BindStore(tblStoreSubnet.Store);
                
                
                BindSubnet(tblStoreSubnet.Subnet);
                return View(tblStoreSubnet);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                if (((System.Data.SqlClient.SqlException)ex.InnerException.InnerException).Number == 2627)
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreSubnetsCreateErrMsg3;
                }
                else
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreSubnetsCreateErrMsg2;
                }
                TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreSubnetsCreateErrMsg2;
                BindStore(tblStoreSubnet.Store);
                BindSubnet(tblStoreSubnet.Subnet);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

     
        }

        // GET: StoreSubnets/Edit/5
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
                tblStoreSubnet tblStoreSubnet = db.tblStoreSubnets.Find(id);

                if (tblStoreSubnet == null)
                {
                    return HttpNotFound();
                }
                BindStore(tblStoreSubnet.Store);
                
                BindSubnet(tblStoreSubnet.Subnet);
                int pageNumber = (page ?? 1);
                tblStoreSubnet.page = pageNumber;
                return View(tblStoreSubnet);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        } 

        // POST: StoreSubnets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StoreSubnetID,Store,Subnet,DELFG,CRTDT,CRTCD,UPDDT,UPDCD,IPAddress,page")] tblStoreSubnet tblStoreSubnet)
        {

            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                BindStore(tblStoreSubnet.Store);
                BindSubnet(tblStoreSubnet.Subnet);

                if (tblStoreSubnet.Store == 0)
                {
                    ModelState.AddModelError("Store", MujiStore.Resources.Resource.ModtblStoreSubnetStoreDataAnnaValida1);   

                }
                if (tblStoreSubnet.Subnet == 0)
                {
                    ModelState.AddModelError("Subnet", MujiStore.Resources.Resource.ModtblStoreSubnetSubnetDataAnnaValida1); 
                }
                if (ModelState.IsValid)
                {

                    LogInfo.Comments = "Store Subnet Updated - " + tblStoreSubnet.Store + "," + tblStoreSubnet.Subnet;
                    if (tblStoreSubnet.DELFG == false)
                    {
                        
                        var tblstoreid = db.tblStoreSubnets.Where(x => x.StoreSubnetID != tblStoreSubnet.StoreSubnetID && x.Store == tblStoreSubnet.Store && x.DELFG == false).FirstOrDefault();

                        if (tblstoreid != null)
                        {
                            TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreSubnetsEditErrMsg1;
                            return View(tblStoreSubnet);
                        }

                        var tblsubnetid = db.tblStoreSubnets.Where(x => x.StoreSubnetID != tblStoreSubnet.StoreSubnetID && x.Subnet == tblStoreSubnet.Subnet && x.DELFG == false).FirstOrDefault();

                        if (tblsubnetid != null)
                        {
                            TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreSubnetsEditErrMsg1;
                            return View(tblStoreSubnet);
                        }
                        
                            LogInfo.Comments = "Subnet Updated - Store ID : "  +tblStoreSubnet.Store + " ,Subnet ID : " + tblStoreSubnet.Subnet;

                            tblStoreSubnet.UPDDT = DateTime.Now;
                            tblStoreSubnet.UPDCD = Session["UserName"].ToString();
                            tblStoreSubnet.IPAddress = Session["IPAddress"].ToString();
                            db.Entry(tblStoreSubnet).State = EntityState.Modified;
                            db.SaveChanges();
                            CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                            TempData["SuccMsg"] = MujiStore.Resources.Resource.CntStoreSubnetsEditSuccMsg;
                            return RedirectToAction("Index", new { page = tblStoreSubnet.page });
                      
                    }
                    else
                    {
                        tblStoreSubnet.UPDDT = DateTime.Now;
                        tblStoreSubnet.UPDCD = Session["UserName"].ToString();
                        tblStoreSubnet.IPAddress = Session["IPAddress"].ToString();
                        db.Entry(tblStoreSubnet).State = EntityState.Modified;
                        db.SaveChanges();
                        CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                        TempData["SuccMsg"] = MujiStore.Resources.Resource.CntStoreSubnetsEditSuccMsg;
                        return RedirectToAction("Index", new { page = tblStoreSubnet.page });
                    }
                    
                }
                TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreSubnetsEditErrMsg2;
                BindStore(tblStoreSubnet.Store);
                BindSubnet(tblStoreSubnet.Subnet);
                return View(tblStoreSubnet);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                
                if (((System.Data.SqlClient.SqlException)ex.InnerException.InnerException).Number == 2627)
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreSubnetsEditErrMsg3;
                }
                else
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreSubnetsEditErrMsg2;
                }
                BindStore(tblStoreSubnet.Store);
                BindSubnet(tblStoreSubnet.Subnet);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }


        public void BindStore(int val)
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
                
                querySDtnt = "select ts.storeid, CONVERT(varchar, ts.storeid)  + '-' + ts.storename storename from tblstore ts";
                querySDtnt += " left join tblStoreGroup tsb on ts.StoreGroupID=tsb.StoreGroupID ";
                
                querySDtnt += " where ts.DELFG=0  and tsb.DELFG=0   ORDER BY ts.storeid ASC ";

                SqlCommand cmds = new SqlCommand(querySDtnt, con);
                cmds.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdrs = cmds.ExecuteReader();
                while (rdrs.Read())
                {
                    if (val == Convert.ToInt32(rdrs["storeid"]))
                    {
                        selectList.Add(new SelectListItem
                        {
                            Value = rdrs["storeid"].ToString(),
                            Text = rdrs["storename"].ToString(),
                            Selected = true

                        });
                    }
                    else
                    {
                        selectList.Add(new SelectListItem
                        {
                            Value = rdrs["storeid"].ToString(),
                            Text = rdrs["storename"].ToString(),
                        });

                    }

                }
            }

            ViewBag.Store = selectList;
            
        }

        
        public void BindSubnet(int val)
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
                

                querySDtnt = "select subnetid,convert(varchar,subnetid) + ' - '+ SNIPAddress as  snipaddress from tblsubnet ";

                querySDtnt += " where DELFG=0 ORDER BY snipaddress ASC ";

                SqlCommand cmds = new SqlCommand(querySDtnt, con);
                cmds.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdrs = cmds.ExecuteReader();
                while (rdrs.Read())
                {
                    if (val == Convert.ToInt32(rdrs["subnetid"]))
                    {
                        selectList.Add(new SelectListItem
                        {
                            Value = rdrs["subnetid"].ToString(),
                            Text = rdrs["snipaddress"].ToString(),
                            Selected = true

                        });
                    }
                    else
                    {
                        selectList.Add(new SelectListItem
                        {
                            Value = rdrs["subnetid"].ToString(),
                            Text = rdrs["snipaddress"].ToString(),
                        });

                    }

                }
            }

            ViewBag.Subnet = selectList;
        }
        [NonAction]
        // GET: StoreSubnets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStoreSubnet tblStoreSubnet = db.tblStoreSubnets.Find(id);
            if (tblStoreSubnet == null)
            {
                return HttpNotFound();
            }
            return View(tblStoreSubnet);
        }
        [NonAction]
        // POST: StoreSubnets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblStoreSubnet tblStoreSubnet = db.tblStoreSubnets.Find(id);
            db.tblStoreSubnets.Remove(tblStoreSubnet);
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
        public ActionResult Index_New(int? page, string SearchID,int? store,tblSubnet subnetdtl, tblSubnet storedtl, int? btnSubmit)
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
            ViewBag.SearchID = SearchID;
           
            ViewData["SubnetInfo"] = subnetdtl;

            try
            {
                ViewBag.store = store;
              
                List<tblSubnet> tblSubnet = new List<tblSubnet>();
                List<tblSubnet> tblSubnet1 = new List<tblSubnet>();
                BindStore(0);

              
                if (Request.Form["SubmitSubnet"] != null)
                {
                    btnSubmit = 1;
                }
                ViewBag.btnSubmit = btnSubmit;

                if(store == 0)
                {
                    store = null;
                }
                if (store != null )
                {
                    string storename = GetStore(store);
                    ViewBag.storename = storename;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        string query = "";
                        query = "select SB.SubnetID,SubnetMask,SB.SNIPAddress from tblStoreSubnet SS ";
                        query += "left Join tblStore ST on SS.Store=ST.StoreID ";
                        query += "left Join tblSubnet SB on SS.Subnet=SB.SubnetID ";
                        query += "where SS.Store=@store and SS.DELFG=0 and ST.DELFG=0 and ";
                        query += " SB.DELFG=0 order by SB.SubnetID asc";

                        SqlCommand cmds = new SqlCommand(query, con);
                        cmds.CommandType = CommandType.Text;
                        cmds.Parameters.AddWithValue("@store", store);
                        con.Open();
                        SqlDataReader rdrs = cmds.ExecuteReader();
                        while (rdrs.Read())
                        {
                            tblSubnet subnet = new tblSubnet();

                            subnet.SubnetID = Convert.ToInt32(rdrs["SubnetID"]);
                            subnet.SNIPAddress = Convert.ToString(rdrs["SNIPAddress"]);
                            subnet.SubnetMask = Convert.ToString(rdrs["SubnetMask"]);



                            tblSubnet.Add(subnet);
                            ViewData["StoreInfo"] = tblSubnet.ToPagedList(pageNumber, pageSize);
                         

                        }

                    }
                }
               
                if(btnSubmit==1)
                {

                
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        string query = "";
                        query = "Select * from tblsubnet where DELFG=0 ";
                        
                        if (SearchID != null && SearchID != "" && SearchID != string.Empty)
                        {
                            query += "and SNIPAddress like @SNIPAddress or SubnetID like @SubnetID ";
                        }
                    query += "order by SubnetID asc ";
                    SqlCommand cmds = new SqlCommand(query, con);
                        cmds.CommandType = CommandType.Text;
                        cmds.Parameters.AddWithValue("@SNIPAddress", "%" + SearchID + "%");
                        cmds.Parameters.AddWithValue("@SubnetID", "%" + SearchID + "%");
                      
                        con.Open();
                        SqlDataReader rdrs = cmds.ExecuteReader();
                        while (rdrs.Read())
                        {
                            tblSubnet tbl_subnet = new tblSubnet();

                            tbl_subnet.SubnetID = Convert.ToInt32(rdrs["SubnetID"]);
                            tbl_subnet.SNIPAddress = Convert.ToString(rdrs["SNIPAddress"]);
                            tbl_subnet.SubnetMask = Convert.ToString(rdrs["SubnetMask"]);
                            tbl_subnet.WANBandWidth = Convert.ToInt32(rdrs["WANBandWidth"]);
                            tbl_subnet.LANBandWidth = Convert.ToInt32(rdrs["WANBandWidth"]);
                            tblSubnet1.Add(tbl_subnet);
                            ViewData["SubnetInfo"] = tblSubnet1;
                            

                    }

                    }
                }
                return View();
            }

            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }
        [HttpPost]
        public ActionResult updatestoresubnet(int subnetID,int Store)
        {
            int result;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string query = "";
                query  = "Delete tblstoresubnet ";
                query += " where subnet=@subnet and store=@store ";
                SqlCommand cmds = new SqlCommand(query, con);
                cmds.CommandType = CommandType.Text;
                con.Open();
                cmds = new SqlCommand(query, con);
                cmds.Parameters.AddWithValue("@Store", Store);
                cmds.Parameters.AddWithValue("@subnet", subnetID);
                cmds.Parameters.AddWithValue("@delfg", 1);
                cmds.Parameters.AddWithValue("@UPDDT", DateTime.Now);
                cmds.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                cmds.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());
                cmds.CommandType = CommandType.Text;
                result = cmds.ExecuteNonQuery();
                if(result==1)
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.SubnetRemovedSuccessfully;

                }
                else
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreSubnetsCreateErrMsg1;
                }

            }
            return View("");

           
        }
        [HttpPost]
        public ActionResult updatesubnet(int subnetID, int Store)
        {
            int result;
            if (Store==0)
            {
                TempData["ErrMsg"] = MujiStore.Resources.Resource.Pleaseselectthestore;

            }
            else
            {

            
            int checksubnet = CheckSubnetExists(subnetID,  Store);
            if(checksubnet==0)
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string query = "";
                    query = "Insert Into tblStoreSubnet (Store,subnet,DELFG,CRTDT,CRTCD,IPAddress) Values";
                    query += "(@store,@subnet,@delfg,@CRTDT,@CRTCD,@IPAddress)";
                    SqlCommand cmds = new SqlCommand(query, con);
                    cmds.CommandType = CommandType.Text;
                    con.Open();
                    cmds = new SqlCommand(query, con);
                    cmds.Parameters.AddWithValue("@Store", Store);                    
                    cmds.Parameters.AddWithValue("@subnet", subnetID);
                    cmds.Parameters.AddWithValue("@delfg", 0);
                    cmds.Parameters.AddWithValue("@CRTDT", DateTime.Now);
                    cmds.Parameters.AddWithValue("@CRTCD", Session["UserName"].ToString());
                    cmds.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());
                    cmds.CommandType = CommandType.Text;
                    result = cmds.ExecuteNonQuery();
                    if (result == 1)
                    {
                        TempData["ErrMsg"] = MujiStore.Resources.Resource.SubnetUpdatedSuccessfully;

                    }
                    else
                    {
                        TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreSubnetsCreateErrMsg1;
                    }
                }
                return View("");
            }
            if (checksubnet == 1)
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string query = "";
                    query = "Update tblstoresubnet set delfg=0,UPDDT=@UPDDT,UPDCD=@UPDCD,IPAddress=@IPAddress ";
                    query += " where subnet=@subnet and store=@store ";
                    SqlCommand cmds = new SqlCommand(query, con);
                    cmds.CommandType = CommandType.Text;
                    con.Open();
                    cmds = new SqlCommand(query, con);
                    cmds.Parameters.AddWithValue("@Store", Store);
                    cmds.Parameters.AddWithValue("@subnet", subnetID);
                    cmds.Parameters.AddWithValue("@UPDDT", DateTime.Now);
                    cmds.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                    cmds.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());
                    cmds.CommandType = CommandType.Text;
                    result = cmds.ExecuteNonQuery();
                    if (result == 1)
                    {
                        TempData["ErrMsg"] = MujiStore.Resources.Resource.SubnetUpdatedSuccessfully;

                    }
                    else
                    {
                        TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreSubnetsCreateErrMsg1;
                    }
                }

            }
            if (checksubnet == 2)
            {
               
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.SubnetAlreadyExists;

                
            }
            }
            return View();
        }

        public static int CheckSubnetExists(int subnetID, int Store)
        {
            int result = 0;
            string query = "";

            using (SqlConnection con = new SqlConnection(CS))
            {
                query = "Select * from tblStoreSubnet where subnet=@subnet and store=@Store  ";
                SqlCommand cmds = new SqlCommand(query, con);
                cmds.CommandType = CommandType.Text;
                con.Open();
                cmds.Parameters.AddWithValue("@Store", Store);
                cmds.Parameters.AddWithValue("@subnet", subnetID);
                SqlDataReader rdrs = cmds.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdrs);

                if (dt.Rows.Count!=0)
                {
                    bool DELFG =Convert.ToBoolean(dt.Rows[0]["DELFG"]);
                    if (DELFG == false)
                    {
                        
                        result = 2;
                    }
                    else
                    {
                        result = 1;
                    }
                }
                
            }
            return result;


        }
        public static string GetStore( int? Store)
        {
            string result ="";
            string query = "";
            
            using (SqlConnection con = new SqlConnection(CS))
            {
                query = "Select StoreName from tblstore where  StoreID=@Store  ";
                SqlCommand cmds = new SqlCommand(query, con);
                cmds.CommandType = CommandType.Text;
                con.Open();
                cmds.Parameters.AddWithValue("@Store", Store);
                SqlDataReader rdrs = cmds.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdrs);
                result = (dt.Rows[0]["StoreName"]).ToString();

            }
            
            return result;

        }

    }
}
