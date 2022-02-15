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
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

namespace MujiStore.Controllers
{
    [SessionExpire]
    [Authorize]
    [MUJICustomAuthorize(Roles = "16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31")]
    public class SubnetsController : BaseController
    {
        private mujiEntities1 db = new mujiEntities1();
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        // GET: Subnets
        [NonAction]
        public ActionResult Index(string sortOrder, int? page, string SearchID, string status, string SubnetNumber, int? page1)
        {
            string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<tblSubnet> SubnetList = new List<tblSubnet>();
            ViewBag.CurrentSort = sortOrder;
            ViewBag.IDSortParm = sortOrder == "SubnetNumber" ? "SubnetNumber_desc" : "SubnetNumber";
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
            ViewBag.SearchID = SearchID;
            try
            {

                var lan = Session["CreateSpecificCulture"];
                ViewBag.Language = lan;
                
                string query = "SELECT *  ";
                query = query + "FROM tblSubnet  ";

                if (SearchID != null && SearchID != "" && SearchID != string.Empty)
                {
                    query = query + " WHERE  (SNIPAddress like @SNIPAddress or SubnetID like @SubnetNumber)";


                    query = query + " and Physical_DELFG=0  Order by SubnetID ASC";

                    

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
                                    SubnetList.Add(new tblSubnet
                                    {

                                        SubnetID = Convert.ToInt32(sdr["SubnetID"]),
                                        SubnetNumber = Convert.ToInt32(sdr["SubnetNumber"]),
                                        SNIPAddress = Convert.ToString(sdr["SNIPAddress"]),
                                        SubnetMask = Convert.ToString(sdr["SubnetMask"]),
                                        WANBandWidth = Convert.ToInt32(sdr["WANBandWidth"]),
                                        LANBandWidth = Convert.ToInt32(sdr["LANBandWidth"]),
                                        DELFG = Convert.ToBoolean(sdr["DELFG"])

                                    });
                                }
                            }
                            con.Close();
                        }
                    }
                    switch (sortOrder)
                    {

                        case "SubnetNumber":
                            SubnetList = SubnetList.OrderByDescending(o => o.SubnetNumber).ToList();
                            break;
                        default:
                            SubnetList = SubnetList.OrderBy(o => o.SubnetNumber).ToList();
                            break;
                    }
                    if (SubnetList.Count >= 1)
                    {
                        return View(SubnetList.ToPagedList(pageNumber, pageSize));
                    }
                    else
                    {
                        TempData["ErrMsg"] = MujiStore.Resources.Resource.Nodata;
                        return View(SubnetList.OrderBy(x => x.SubnetID).ToPagedList(pageNumber, pageSize));
                    }
                        
                }
                else
                {
                    
                    query = query + " where Physical_DELFG=0  Order by SubnetID ASC";



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
                                    SubnetList.Add(new tblSubnet
                                    {

                                        SubnetID = Convert.ToInt32(sdr["SubnetID"]),
                                        SubnetNumber = Convert.ToInt32(sdr["SubnetNumber"]),
                                        SNIPAddress = Convert.ToString(sdr["SNIPAddress"]),
                                        SubnetMask = Convert.ToString(sdr["SubnetMask"]),
                                        WANBandWidth = Convert.ToInt32(sdr["WANBandWidth"]),
                                        LANBandWidth = Convert.ToInt32(sdr["LANBandWidth"]),
                                        DELFG = Convert.ToBoolean(sdr["DELFG"])

                                    });
                                }
                            }
                            con.Close();
                        }
                    }
                    if (status != null)
                    {
                        TempData["SuccMsg"] = MujiStore.Resources.Resource.SubnetDeletedSucess;
                    }
                    switch (sortOrder)
                    {

                        case "SubnetNumber":
                            SubnetList = SubnetList.OrderByDescending(o => o.SubnetNumber).ToList();
                            break;
                        default:
                            SubnetList = SubnetList.OrderBy(o => o.SubnetNumber).ToList();
                            break;
                    }
                    return View(SubnetList.ToList().ToPagedList(pageNumber, pageSize));
                }
            
            }
            catch (Exception ex)
            {
                
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
               
                TempData["ErrMsg"] = MujiStore.Resources.Resource.Nodata;
                return View(SubnetList.OrderBy(x => x.SubnetID).ToPagedList(pageNumber, pageSize));
            }
        }

        public ActionResult TroubleShoot()
        {
            return View();
        }
        public ActionResult TroubleShoot(tblSubnet tblSubnet)
        {
            if (ModelState.IsValid)
            {
            }
            return View();
        }
        // GET: Subnets/Details/5
        [NonAction]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSubnet tblSubnet = db.tblSubnets.Find(id);
            if (tblSubnet == null)
            {
                return HttpNotFound();
            }
            return View(tblSubnet);
        }

        // GET: Subnets/Create
        [NonAction]
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
            //return View();
        }

        // POST: Subnets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [NonAction]
        public ActionResult Create([Bind(Include = "SubnetNumber,SubnetID,SNIPAddress,SubnetMask,WANBandWidth,LANBandWidth,DELFG,CRTDT,CRTCD,UPDDT,UPDCD,IPAddress,page")] tblSubnet tblSubnet)
        {
            
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
    
                if (ModelState.IsValid)
                {
                    int Subnetcnt = CheckSubnetNumberExist(tblSubnet.SubnetNumber, 0);
                    if(Subnetcnt!=0)
                    {
                        TempData["ErrMsg"] = MujiStore.Resources.Resource.SubnetNumberisAlreadyexists;
                        return View(tblSubnet);
                    }
                    int Ipaddcnt = CheckSubnetIpadd(tblSubnet.SNIPAddress, 0);
                    if (Ipaddcnt != 0)
                    {
                        TempData["ErrMsg"] = MujiStore.Resources.Resource.CntSubnetsCreateErrMsg1;
                        return View(tblSubnet);
                    }
                    int GSubnetID = 0;
                    GSubnetID = GettblSubnetID();

                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        string query = "";
                        query = " Insert Into tblsubnet (SubnetID,SubnetNumber, SNIPAddress, SubnetMask,WANBandwidth, ";
                        query += " LANBandwidth,DELFG,CRTDT,CRTCD,IPAddress,Physical_Delfg) Values ";
                        query += " (@SubnetID,@SubnetNumber, @SNIPAddres, @SubnetMask,@WANBandwidth, ";
                        query += " @LANBandwidth,0,@CRTDT,@CRTCD,@IPAddress,0) ";

                        SqlCommand cmds = new SqlCommand(query, con);

                        cmds.Parameters.AddWithValue("@SubnetNumber", tblSubnet.SubnetNumber);
                        cmds.Parameters.AddWithValue("@SubnetID", GSubnetID);
                        cmds.Parameters.AddWithValue("@SNIPAddres", tblSubnet.SNIPAddress);
                        cmds.Parameters.AddWithValue("@SubnetMask", tblSubnet.SubnetMask);
                        cmds.Parameters.AddWithValue("@WANBandwidth", tblSubnet.WANBandWidth);
                        cmds.Parameters.AddWithValue("@LANBandwidth", tblSubnet.LANBandWidth);
                        cmds.Parameters.AddWithValue("@CRTDT", DateTime.Now);
                        cmds.Parameters.AddWithValue("@CRTCD", Session["UserName"].ToString());
                        cmds.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());
                        cmds.CommandType = CommandType.Text;
                        con.Open();
                        cmds.CommandType = CommandType.Text;
                        int result = cmds.ExecuteNonQuery();
                        if (result == 1)
                        {
                            TempData["SuccMsg"] = MujiStore.Resources.Resource.CntSubnetsCreateSuccMsg;
                            return RedirectToAction("Index", new { page = tblSubnet.page });
                        }
                        else
                        {
                            TempData["ErrMsg"] = MujiStore.Resources.Resource.CntSubnetsCreateErrMsg2;
                            return View(tblSubnet);
                        }
                    }
                    
                }
                TempData["ErrMsg"] = MujiStore.Resources.Resource.CntSubnetsCreateErrMsg2;
                return View(tblSubnet);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                if (((System.Data.SqlClient.SqlException)ex.InnerException.InnerException).Number == 2627)
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntSubnetsCreateErrMsg3;
                }
                else
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntSubnetsCreateErrMsg2;
                }
                TempData["ErrMsg"] = MujiStore.Resources.Resource.CntSubnetsCreateErrMsg2;
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

        }

        public int GettblSubnetID()
        {
            int id = 0;
            id = db.tblSubnets.Select(p => p.SubnetID).DefaultIfEmpty(0).Max();

            id = id + 1;
            return id;
        }
        // GET: Subnets/Edit/5
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
               
                tblSubnet tblsubnet = new tblSubnet();
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string query = "";
                    query = " Select * from tblsubnet where SubnetID = @SubnetID";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@SubnetID", id);
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader rdrs = cmd.ExecuteReader())
                        {
                            while (rdrs.Read())
                            {
                                tblsubnet.SubnetNumber = Convert.ToInt32(rdrs["SubnetNumber"]);
                                tblsubnet.SubnetID = Convert.ToInt32(rdrs["SubnetID"]);
                                tblsubnet.SNIPAddress = (rdrs["SNIPAddress"]).ToString();
                                tblsubnet.SubnetMask = (rdrs["SubnetMask"]).ToString();
                                tblsubnet.LANBandWidth = Convert.ToInt32(rdrs["LANBandWidth"]);
                                tblsubnet.WANBandWidth = Convert.ToInt32(rdrs["WANBandWidth"]);
                                tblsubnet.DELFG = Convert.ToBoolean(rdrs["DELFG"]);
                            }
                        }
                    }

                    if (tblsubnet == null)
                    {
                        return HttpNotFound();
                    }
                    int pageNumber = (page ?? 1);
                    tblsubnet.page = pageNumber;
                    return View(tblsubnet);
                }
                
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

        }

        // POST: Subnets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [NonAction]
        public ActionResult Edit([Bind(Include = "SubnetNumber,SubnetID,SNIPAddress,SubnetMask,WANBandWidth,LANBandWidth,DELFG,CRTDT,CRTCD,UPDDT,UPDCD,IPAddress,page")] tblSubnet tblSubnet)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;
            string query = "";
            try
            {

                if(tblSubnet.DELFG == false)
                {
                    int Subnetcnt = CheckSubnetNumberExist(tblSubnet.SubnetNumber, tblSubnet.SubnetID);
                    if (Subnetcnt != 0)
                    {
                        TempData["ErrMsg"] = MujiStore.Resources.Resource.SubnetNumberisAlreadyexists;
                        return View(tblSubnet);
                    }
                    int Ipaddcnt = CheckSubnetIpadd(tblSubnet.SNIPAddress, tblSubnet.SubnetID);
                    if (Ipaddcnt != 0)
                    {
                        TempData["ErrMsg"] = MujiStore.Resources.Resource.CntSubnetsCreateErrMsg1;
                        return View(tblSubnet);
                    }
                }
                if (ModelState.IsValid)
                {
                    
                    
                    LogInfo.Comments = "Subnet Updated - " + tblSubnet.SNIPAddress.Trim();
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        tblSubnet.UPDDT = DateTime.Now;
                        tblSubnet.UPDCD = Session["UserName"].ToString();
                        tblSubnet.IPAddress = Session["IPAddress"].ToString();
                      
                        query = " update tblSubnet set SNIPAddress=@SNIPAddress,SubnetMask=@SubnetMask, ";
                        query += " WANBandWidth=@WANBandWidth,LANBandWidth=@LANBandWidth,SubnetNumber=@SubnetNumber, ";
                        query += " DELFG=@DELFG,UPDDT=@UPDDT,UPDCD=@UPDCD, ";
                        query += " IPAddress=@IPAddress ";
                        query += " Where SubnetID = @SubnetID ";

                        SqlCommand cmdApp = new SqlCommand(query, con);
                        cmdApp.Parameters.AddWithValue("@SNIPAddress", tblSubnet.SNIPAddress.Trim().ToString());
                        cmdApp.Parameters.AddWithValue("@SubnetMask", tblSubnet.SubnetMask.Trim());
                        cmdApp.Parameters.AddWithValue("@WANBandWidth", tblSubnet.WANBandWidth);
                        cmdApp.Parameters.AddWithValue("@LANBandWidth", tblSubnet.LANBandWidth);
                        cmdApp.Parameters.AddWithValue("@SubnetNumber", tblSubnet.SubnetNumber);
                        cmdApp.Parameters.AddWithValue("@DELFG", tblSubnet.DELFG);
                        cmdApp.Parameters.AddWithValue("@UPDDT", tblSubnet.UPDDT);
                        cmdApp.Parameters.AddWithValue("@UPDCD", tblSubnet.UPDCD);
                        cmdApp.Parameters.AddWithValue("@IPAddress", tblSubnet.IPAddress.Trim().ToString());
                        cmdApp.Parameters.AddWithValue("@SubnetID", tblSubnet.SubnetID);

                        cmdApp.CommandType = CommandType.Text;
                        con.Open();
                        result = cmdApp.ExecuteNonQuery();
                    }
                    

                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.CntSubnetsEditSuccMsg;
                    return RedirectToAction("Index", new { page = tblSubnet.page });
                }
                TempData["ErrMsg"] = MujiStore.Resources.Resource.CntSubnetsEditErrMsg2;
                return View(tblSubnet);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                if (((System.Data.SqlClient.SqlException)ex.InnerException.InnerException).Number == 2627)
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntSubnetsEditErrMsg3;
                }
                else
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntSubnetsEditErrMsg2;
                }
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }

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
                    query = "UPDATE tblsubnet SET Physical_DELFG = 1, UPDDT=@UPDDT," +
                    " UPDCD=@UPDCD, IPAddress=@IPAddress where SubnetID=@UserID; ";



                    //Intialize Command and pass the paramters


                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@UserID", ID);
                    cmd.Parameters.AddWithValue("@UPDDT", DateTime.Now);
                    cmd.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                    cmd.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());

                    cmd.CommandType = CommandType.Text;
                    result = cmd.ExecuteNonQuery();

                    query = "UPDATE tblstoresubnet SET DELFG = 1, UPDDT=@UPDDT," +
                            " UPDCD=@UPDCD, IPAddress=@IPAddress where Subnet=@UserID; ";

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

                    LogInfo.Comments = "Subnet Updated - " + ID.ToString();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.UserDeletedSuccessfully;
                    return RedirectToAction("Index");

                }
                else
                {
                    LogInfo.Comments = "Subnet Updated - " + ID.ToString();
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

        public static int CheckSubnetNumberExist(int Subnetnumber, int SubnetId)
        {
            int result = 0;
            string query = "";
            string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {

                query = "select count(*) Cnt from tblsubnet where Subnetnumber =@Subnetnumber and SubnetId <> @SubnetId and Physical_DELFG = 0 ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Subnetnumber", Subnetnumber);
                cmd.Parameters.AddWithValue("@SubnetId", SubnetId);
                cmd.CommandType = CommandType.Text;
                con.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return result;
        }
        public static int CheckSubnetIpadd(string SNIPAddress, int SubnetId)
        {
            int result = 0;
            string query = "";
            string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {

                query = "select count(*) Cnt from tblsubnet where SNIPAddress =@SNIPAddress and SubnetId <> @SubnetId and Physical_DELFG = 0 ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@SNIPAddress", SNIPAddress);
                cmd.Parameters.AddWithValue("@SubnetId", SubnetId);
                cmd.CommandType = CommandType.Text;
                con.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return result;
        }
        [NonAction]
        // GET: Subnets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSubnet tblSubnet = db.tblSubnets.Find(id);
            if (tblSubnet == null)
            {
                return HttpNotFound();
            }
            return View(tblSubnet);
        }
        [NonAction]
        // POST: Subnets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSubnet tblSubnet = db.tblSubnets.Find(id);
            db.tblSubnets.Remove(tblSubnet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Search(string SearTitle)
        {
            return null;
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
