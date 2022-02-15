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
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace MujiStore.Controllers
{
    [SessionExpire]
    [Authorize]
    [MUJICustomAuthorize(Roles = "16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31")]
    public class StreamServersController : BaseController
    {
        private mujiEntities1 db = new mujiEntities1();
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        String Remarks;
        String Remarks_ja;
        String Status;
        string sucmsg;
        int maxvalue = 999999;
        StringBuilder sb = new StringBuilder(" ");
        List<string> sblist = new List<string>();
        List<string> sblist1 = new List<string>();
        List<string> sblist2 = new List<string>();

        
        public ActionResult Index(int? page, string SearchID)
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
            ViewBag.SearchID = SearchID;
            try
            {
                var selectList = new List<tblStreamServer>();
                DataTable MyDT = new DataTable();
                if (Request.Form["submitbutton1"] != null)
                {
                    
                    ViewBag.filename = "Streamserver";
                    DataTable DT = (DataTable)Session["dtTest"];
                    ExportCSV(DT);

                }
                else
                {
                    string querySDtnt = "";
                    if (SearchID != null && SearchID != "" && SearchID != string.Empty)
                    {
                        using (SqlConnection con = new SqlConnection(CS))
                        {
                            querySDtnt = " SELECT distinct SRS.StreamServerID,SN.SubnetNumber, SRS.CRTDT,SRS.CRTCD,SN.SNIPAddress ,ST.StoreName, ST.StoreNumber, f.Name as foldername, ";
                            querySDtnt += " convert(varchar,ST.StoreNumber) + ' - '+ST.StoreName+ ' : ' + convert(varchar,SN.SubnetNumber) + ' - '+ SN.SNIPAddress SubNetName,  ";
                            querySDtnt += " SSServer, SRS.IPAddress,SRS.DELFG,SRS.UPDCD,SRS.UPDDT,SRS.UserIPAddress,SG.Name as StoreGroup";
                            querySDtnt += " FROM tblStreamServer SRS ";
                            querySDtnt += " Left Join tblSubnet AS SN ON SN.SubnetID = SRS.BelongingSubnet ";
                            querySDtnt += " LEFT JOIN tblStoreSubnet AS SS ON SN.SubnetID = SS.Subnet";
                            querySDtnt += " LEFT JOIN tblStore AS ST ON SS.Store = ST.StoreID";
                            querySDtnt += " left join tblStoreGroup AS SG ON SG.StoreGroupID=ST.StoreGroupID";
                            querySDtnt += " left jOIN tblStoreGroupFolder AS SGF ON SG.StoreGroupID = SGF.StoreGroupID";
                            querySDtnt += " LEFT JOIN tblFolder AS F ON F.FolderID = SGF.FolderID ";
                            querySDtnt += " where (srs.ipaddress like  @ipaddress  or SSServer like @SSServer or SN.SubnetNumber like @SubnetNumber) and";
                            querySDtnt += "  st.DELFG = 0  ";
                            querySDtnt += " and SN.DELFG=0  and SS.DELFG=0 ";
                            querySDtnt += " and SG.DELFG=0 ";

                            querySDtnt += " ORDER BY SRS.StreamServerID Desc";

                            SqlCommand cmds = new SqlCommand(querySDtnt, con);

                            cmds.CommandType = CommandType.Text;
                            con.Open();
                            cmds.Parameters.AddWithValue("@ipaddress", "%" + SearchID + "%");
                            cmds.Parameters.AddWithValue("@SSServer", "%" + SearchID + "%");
                            cmds.Parameters.AddWithValue("@SubnetNumber", "%" + SearchID + "%");
                            SqlDataReader rdrs = cmds.ExecuteReader();
                            while (rdrs.Read())
                            {

                                selectList.Add(new tblStreamServer
                                {

                                    StreamServerID = Convert.ToInt32(rdrs["StreamServerID"]),
                                    SubNetName = rdrs["SubNetName"].ToString(),
                                    SSServer = rdrs["SSServer"].ToString(),
                                    IPAddress = rdrs["IPAddress"].ToString(),
                                    UserIPAddress = rdrs["UserIPAddress"].ToString(),
                                    SNIPAddress = rdrs["SNIPAddress"].ToString(),
                                    StoreName = rdrs["StoreName"].ToString(),
                                    StoreNumber = Convert.ToInt32(rdrs["StoreNumber"]),
                                    SubnetNumber = Convert.ToInt32(rdrs["SubnetNumber"]),
                                    FolderName = rdrs["FolderName"].ToString(),
                                    StoreGroup = rdrs["StoreGroup"].ToString(),
                                    DELFG = Convert.ToBoolean(rdrs["DELFG"]),
                                    CRTCD = rdrs["CRTCD"].ToString(),
                                    UPDCD = rdrs["UPDCD"].ToString(),
                                    CRTDT = Convert.ToDateTime(rdrs["CRTDT"]),
                                    
                                    UPDDT = rdrs["UPDDT"].ToString() != "" ? Convert.ToDateTime(rdrs["UPDDT"].ToString()) : (DateTime?)null
                                   
                                });


                            }


                        }
                    }

                    else
                    {
                        using (SqlConnection con = new SqlConnection(CS))
                        {


                            querySDtnt = " SELECT distinct SRS.StreamServerID,SN.SubnetNumber, SRS.CRTDT,SRS.CRTCD,SN.SNIPAddress ,RTRIM(ST.StoreName) as StoreName, ST.StoreNumber,f.Name as foldername,  ";
                            querySDtnt += " convert(varchar,ST.StoreNumber) + ' - '+ST.StoreName+ ' : ' + convert(varchar,SN.SubnetNumber) + ' - '+ SN.SNIPAddress SubNetName,  ";
                            querySDtnt += " SSServer, SRS.IPAddress,SRS.DELFG,SRS.UPDCD,SRS.UPDDT,SRS.UserIPAddress,RTRIM(SG.Name ) as StoreGroup";
                            querySDtnt += " FROM tblStreamServer SRS ";
                            querySDtnt += " Left Join tblSubnet AS SN ON SN.SubnetID = SRS.BelongingSubnet ";
                            querySDtnt += " LEFT JOIN tblStoreSubnet AS SS ON SN.SubnetID = SS.Subnet";
                            querySDtnt += " LEFT JOIN tblStore AS ST ON SS.Store = ST.StoreID";
                            querySDtnt += " left join tblStoreGroup AS SG ON SG.StoreGroupID=ST.StoreGroupID";
                            querySDtnt += " left jOIN tblStoreGroupFolder AS SGF ON SG.StoreGroupID = SGF.StoreGroupID";
                            querySDtnt += " LEFT JOIN tblFolder AS F ON F.FolderID = SGF.FolderID ";
                            querySDtnt += " where st.DELFG = 0  ";
                            querySDtnt += " and SN.DELFG=0  AND SS.DELFG = 0";
                            querySDtnt += " and SG.DELFG=0 ";
                            querySDtnt += " ORDER BY SRS.StreamServerID Desc";


                            SqlCommand cmds = new SqlCommand(querySDtnt, con);
                            cmds.CommandType = CommandType.Text;
                            con.Open();
                            SqlDataReader rdrs = cmds.ExecuteReader();
                            while (rdrs.Read())
                            {

                                selectList.Add(new tblStreamServer
                                {
                                    StreamServerID = Convert.ToInt32(rdrs["StreamServerID"]),
                                    SubNetName = rdrs["SubNetName"].ToString(),
                                    SSServer = rdrs["SSServer"].ToString(),
                                    IPAddress = rdrs["IPAddress"].ToString(),
                                    UserIPAddress = rdrs["UserIPAddress"].ToString(),
                                    SNIPAddress = rdrs["SNIPAddress"].ToString(),
                                    StoreName = rdrs["StoreName"].ToString(),
                                    StoreNumber = Convert.ToInt32(rdrs["StoreNumber"]),
                                    SubnetNumber = Convert.ToInt32(rdrs["SubnetNumber"]),
                                    StoreGroup = rdrs["StoreGroup"].ToString(),
                                    FolderName = rdrs["FolderName"].ToString(),
                                    DELFG = Convert.ToBoolean(rdrs["DELFG"]),
                                    CRTCD = rdrs["CRTCD"].ToString(),
                                    UPDCD = rdrs["UPDCD"].ToString(),
                                    CRTDT = Convert.ToDateTime(rdrs["CRTDT"]),
                                    UPDDT = rdrs["UPDDT"].ToString() != "" ? Convert.ToDateTime(rdrs["UPDDT"].ToString()) : (DateTime?)null
                                });


                            }
                        }

                    }


                    MyDT.Clear();

                    if (selectList.Count != 0)
                    {

                        MyDT.Clear();
                        MyDT.Columns.Add("SSServer");
                        MyDT.Columns.Add("IPAddress");
                        MyDT.Columns.Add("SubnetNumber");
                        MyDT.Columns.Add("SNIPAddress");
                        MyDT.Columns.Add("StoreName");
                        MyDT.Columns.Add("StoreNumber");
                        MyDT.Columns.Add("StoreGroup");
                        MyDT.Columns.Add("FolderName");
                        MyDT.Columns.Add("CRTDT");
                        MyDT.Columns.Add("CRTCD");
                        MyDT.Columns.Add("UPDDT");
                        MyDT.Columns.Add("UPDCD");
                        MyDT.Columns.Add("UserIPAddress");
                        for (int i = 0; i < selectList.Count; i++)
                        {

                            DataRow dr = MyDT.NewRow();
                            dr[0] = selectList[i].SSServer;
                            dr[1] = selectList[i].IPAddress;
                            dr[2] = selectList[i].SubnetNumber;
                            dr[3] = selectList[i].SNIPAddress;
                            dr[4] = selectList[i].StoreName;
                            dr[5] = selectList[i].StoreNumber;
                            dr[6] = selectList[i].StoreGroup;
                            dr[7] = selectList[i].FolderName;
                            dr[8] = selectList[i].CRTDT;
                            dr[9] = selectList[i].CRTCD;
                            dr[10] = selectList[i].UPDDT;
                            dr[11] = selectList[i].UPDCD;
                            dr[12] = selectList[i].UserIPAddress;

                            MyDT.Rows.Add(dr);
                        }
                    }
                    Session["dtTest"] = null;
                    Session["dtTest"] = MyDT;


                }
                if (selectList.Count >= 1)
                {
                    return View(selectList.ToList().ToPagedList(pageNumber, pageSize));
                }
                else
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.Nodata;
                    return View(selectList.ToList().ToPagedList(pageNumber, pageSize));
                }

            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }
        // GET: StreamServers/Details/5
        [NonAction]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStreamServer tblStreamServer = db.tblStreamServers.Find(id);
            if (tblStreamServer == null)
            {
                return HttpNotFound();
            }
            return View(tblStreamServer);
        }
        public void BindSubnet(int? val)
        {
            var selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem
            {
                Value = "0",
                Text = MujiStore.Resources.Resource.Select
            });
            string querySDtnt = "";

            using (SqlConnection con = new SqlConnection(CS))
            {
 
                querySDtnt = "SELECT SN.SubnetID,  convert(varchar,ST.StoreNumber) + ' - '+ST.StoreName+ ' : ' + convert(varchar,SN.SubnetNumber) + ' - '+ SN.SNIPAddress ";
                querySDtnt += " SNetName  FROM tblSubnet AS SN  LEFT JOIN tblStoreSubnet AS SS ON ";
                querySDtnt += "SN.SubnetID = SS.Subnet  LEFT JOIN tblStore AS ST ON SS.Store = ST.StoreID   ";
                querySDtnt += "LEFT JOIN tblStoreGroup tsb on st.StoreGroupID=tsb.StoreGroupID   ";
                querySDtnt += "where SN.DELFG = 0 and ss.DELFG = 0 and St.DELFG = 0  and st.DELFG = 0";
                querySDtnt += "  ORDER BY SN.SubnetID ASC ";

                SqlCommand cmds = new SqlCommand(querySDtnt, con);
                cmds.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdrs = cmds.ExecuteReader();
                while (rdrs.Read())
                {
                    if (val == Convert.ToInt32(rdrs["SubnetID"]))
                    {
                        selectList.Add(new SelectListItem
                        {
                            Value = rdrs["SubnetID"].ToString(),
                            Text = rdrs["SNetName"].ToString(),
                            Selected = true

                        });
                    }
                    else
                    {
                        selectList.Add(new SelectListItem
                        {
                            Value = rdrs["SubnetID"].ToString(),
                            Text = rdrs["SNetName"].ToString(),
                        });

                    }

                }
            }
            ViewBag.BelongingSubnet = selectList;

        }
        
        // GET: StreamServers/Create
        public ActionResult Create(int? page)
        {

            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {

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

        // POST: StreamServers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.





        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StreamServerID,FormatID,SSServer,IPAddress,BelongingSubnet,DeploySchedule,Status,LastDeployDate,LastStatusCheckDateDatetime,DriveCTotal,DriveCFree,DriveDTotal,DriveDFree,DELFG,CRTDT,CRTCD,UPDDT,UPDCD,UserIPAddress,page")] tblStreamServer tblStreamServer)
        {

            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;
            try
            {
  
                BindSubnet(tblStreamServer.BelongingSubnet);
    
                if (tblStreamServer.BelongingSubnet == 0)
                {
                    // ModelState["Store"] = true;
                    ModelState.AddModelError("BelongingSubnet", MujiStore.Resources.Resource.SelectSubnet);

                }
    

                var tblsubnt = db.tblStreamServers.Where(x => x.BelongingSubnet == tblStreamServer.BelongingSubnet && x.DELFG == false).FirstOrDefault();
                if (tblsubnt != null)
                {
                    ModelState.AddModelError("BelongingSubnet", MujiStore.Resources.Resource.SubnetAlreadyExists);
                }

    
                ModelState["DeploySchedule"].Errors.Clear();

                if (ModelState.IsValid)
                {

                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        tblStreamServer.CRTCD = Session["UserName"].ToString();
                        tblStreamServer.UserIPAddress = Session["IPAddress"].ToString();
                        con.Open();
                        string query = "";
                        query = "Insert into  tblStreamServer(SSServer,IPAddress,BelongingSubnet,DELFG,CRTDT,CRTCD,UserIPAddress) Values ( ";
                        query += "N'" + tblStreamServer.SSServer + "','" + tblStreamServer.IPAddress + "',";
                        query += "'" + tblStreamServer.BelongingSubnet + "','0','" + DateTime.Now + "',N'" + tblStreamServer.CRTCD + "',";
                        query += "'" + tblStreamServer.UserIPAddress + "')";

                        SqlCommand cmd;
                        cmd = new SqlCommand(query, con);
                        cmd.CommandType = CommandType.Text;
                        result = cmd.ExecuteNonQuery();

   
                    }


      

                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.CommonCreateStreamServerCreatedSuccess;
                    return RedirectToAction("Index", new { page = tblStreamServer.page });
                }
                else
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CommonCreateUnableCreateStreamSer;
                    return View(tblStreamServer);
                }

                return View(tblStreamServer);
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }

        // GET: StreamServers/Edit/5
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
                tblStreamServer tblStreamServer = db.tblStreamServers.Find(id);
                if (tblStreamServer == null)
                {
                    return HttpNotFound();
                }
               
                BindSubnet(tblStreamServer.BelongingSubnet);
            
                tblStreamServer.OrigSSServer = tblStreamServer.SSServer;
                int pageNumber = (page ?? 1);
                tblStreamServer.page = pageNumber;
    
                return View(tblStreamServer);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }

        // POST: StreamServers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StreamServerID,OrigSSServer,SSServer,FormatID,IPAddress,BelongingSubnet,DeploySchedule,Status,LastDeployDate,LastStatusCheckDateDatetime,DriveCTotal,DriveCFree,DriveDTotal,DriveDFree,DELFG,CRTDT,CRTCD,UPDDT,UPDCD,UserIPAddress,page")] tblStreamServer tblStreamServer)
        {

            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {


                BindSubnet(tblStreamServer.BelongingSubnet);
              
                if (tblStreamServer.BelongingSubnet == 0)
                {
                    
                    ModelState.AddModelError("BelongingSubnet", MujiStore.Resources.Resource.SelectSubnet);

                }
                

                var tblsubnt = db.tblStreamServers.Where(x => x.BelongingSubnet == tblStreamServer.BelongingSubnet && x.StreamServerID != tblStreamServer.StreamServerID && x.DELFG == false).FirstOrDefault();
                if (tblsubnt != null)
                {
                    ModelState.AddModelError("BelongingSubnet", MujiStore.Resources.Resource.SubnetAlreadyExists);
                }
               
                ModelState["DeploySchedule"].Errors.Clear();
                if (ModelState.IsValid)
                {
                    int result = 0;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        tblStreamServer.UPDCD = Session["UserName"].ToString();
                        tblStreamServer.UserIPAddress = Session["IPAddress"].ToString();
                        con.Open();
                        string query = "";
                        query = "Update tblStreamServer Set SSServer =N'" + tblStreamServer.SSServer + "',DELFG='" + tblStreamServer.DELFG + "', ";
                        query += "IPAddress='" + tblStreamServer.IPAddress + "',BelongingSubnet='" + tblStreamServer.BelongingSubnet + "', ";
                        query += "UPDDT='" + DateTime.Now + "',UPDCD=N'" + tblStreamServer.CRTCD + "',";
                        query += "UserIPAddress='" + tblStreamServer.UserIPAddress + "' where StreamServerID='" + tblStreamServer.StreamServerID + "'";

                        SqlCommand cmd;
                        cmd = new SqlCommand(query, con);
                        cmd.CommandType = CommandType.Text;
                        result = cmd.ExecuteNonQuery();

                   
                    }
                    LogInfo.Comments = "Stream Server Updated - " + tblStreamServer.SSServer.ToString() + "," + tblStreamServer.IPAddress.ToString();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.StreamServerupdatedsuccessfully;
                    return RedirectToAction("Index", new { page = tblStreamServer.page });

                }
                else
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CommonCreateUnableUpdateStreamSer;
                    return View(tblStreamServer);
                }






                



            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = MujiStore.Resources.Resource.Unabletoimportstreamserver;
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }
       

        // GET: StreamServers/Delete/5
        [NonAction]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStreamServer tblStreamServer = db.tblStreamServers.Find(id);
            if (tblStreamServer == null)
            {
                return HttpNotFound();
            }
            return View(tblStreamServer);
        }

        // POST: StreamServers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [NonAction]
        public ActionResult DeleteConfirmed(int id)
        {
            tblStreamServer tblStreamServer = db.tblStreamServers.Find(id);
            db.tblStreamServers.Remove(tblStreamServer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Upload()
        {
            //return View(new List<CustomerModel>());
            return View(new List<SSDetails>());
        }

       

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase postedFile)
        {


            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;

            try
            {
                
                List<SSDetails> ssdetails = new List<SSDetails>();

                string filePath = string.Empty;
                if (postedFile != null)
                {
                    string path = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    filePath = path + Path.GetFileName(postedFile.FileName);
                    string extension = Path.GetExtension(postedFile.FileName);
                    String filename1 = Path.GetFileName(postedFile.FileName);
                    string removeexten = filename1.Substring(0, filename1.LastIndexOf('.'));
                    string filename = removeexten + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + extension;
                    if (extension != ".csv")
                    {
                        ViewBag.Status = "Select csv file only";
                        TempData["SuccMsg"] = MujiStore.Resources.Resource.SelectCSVfileonly;
                        return View(ssdetails);
                    }
                    var fileNameTmp = Path.Combine(Server.MapPath("~/Uploads"), filename);
                    postedFile.SaveAs(fileNameTmp);

                    string csvData = System.IO.File.ReadAllText(Path.Combine(Server.MapPath("~/Uploads"), filename));
                    bool flag = false;
                    if (csvData.Split('\n').Length > 1)
                    {
                        flag = checkColheader(csvData.Split('\n')[0]);
                    }
                    if (flag == true)
                    {
                        foreach (string row in csvData.Split('\n').Skip(1))
                        {
                            if (!string.IsNullOrEmpty(row))
                            {
                                ssdetails.Add(new SSDetails
                                {
                                    BelongingSubnet = row.Split(',')[0].Trim(),
                                    StoreName = row.Split(',')[1].Trim(),
                                    StoreGroupName = row.Split(',')[2].Trim(),

                                    StoreNumber = row.Split(',')[3].Trim(),
                                    FolderName = row.Split(',')[4].Trim(),
                                    SubnetNumber = row.Split(',')[5].Trim(),
                                });
                            }
                            



                        }
                    }
                    else
                    {
                        TempData["SuccMsg"] = MujiStore.Resources.Resource.Fileheadernamenotmatch;
                        return View("Upload");
                    }

                    DataTable MyDT = new DataTable();
                    MyDT.Clear();
                    
                    if (ssdetails.Count != 0)
                    {

                        MyDT.Clear();
                        MyDT.Columns.Add("SSServer");
                        MyDT.Columns.Add("IPAddress");
                        MyDT.Columns.Add("BelongingSubnet");

                        MyDT.Columns.Add("FileName");
                        MyDT.Columns.Add("UserIPAddress");
                        MyDT.Columns.Add("CRTCD");
                        MyDT.Columns.Add("StoreName");
                        MyDT.Columns.Add("StoreGroupName");
                        MyDT.Columns.Add("StoreNumber");

                        MyDT.Columns.Add("FolderName");
                        MyDT.Columns.Add("SubnetNumber");

                        string streamserver = System.Configuration.ConfigurationManager.AppSettings["Streamserver"];
                        string StreamIpaddress = System.Configuration.ConfigurationManager.AppSettings["StreamIpaddress"];

                        for (int i = 0; i < ssdetails.Count; i++)
                        {
                            DataRow dr = MyDT.NewRow();
                            dr[0] = streamserver;
                            dr[1] = StreamIpaddress;
                            dr[2] = ssdetails[i].BelongingSubnet;

                            dr[3] = filename;
                            dr[4] = Session["IPAddress"].ToString();
                            dr[5] = Session["UserName"].ToString();
                            dr[6] = ssdetails[i].StoreName;
                            dr[7] = ssdetails[i].StoreGroupName;
                            dr[8] = ssdetails[i].StoreNumber;
                            dr[9] = ssdetails[i].FolderName;
                            dr[10] = ssdetails[i].SubnetNumber;
                            MyDT.Rows.Add(dr);
                        }


                        if (MyDT.Rows.Count >= 1)
                        {
                            ViewBag.result = ssdetails;

                            Session["dtTest"] = MyDT;
                            ViewBag.flag = flag;
                        }
      


                    }
                    else
                    {
                        sucmsg = MujiStore.Resources.Resource.Uploadedfileisempty;
                    }
                    Update_Click();


                    

                    TempData["SuccMsg"] = sucmsg;

                }
                else
                {
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.Pleaseselectthefile;

                }
                return View("Upload");

            }
            catch (Exception ex)
            {
                TempData["ErrMsg"] = MujiStore.Resources.Resource.Unabletoimportstreamserver; 
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

        }

        [HttpPost]
        // For Insert CSV files into Sql Db
        public ActionResult Update_Click()
        {

            
            if (Session["dtTest"] == null)
            {
                ViewBag.Status = MujiStore.Resources.Resource.Fileheadernamenotmatch;
                return RedirectToAction("Upload", "StreamServers");
            }

            DataTable tblcsv = (DataTable)Session["dtTest"];

            InsertCSVRecords(tblcsv);
            ValidateCSVRecords(tblcsv);

            Session["dtTest"] = null;

            DeleteInsertSubnet(tblcsv.Rows[0]["filename"].ToString());
 

            int UpdSGResult = UpdateInActiveStoreGroupNameList(tblcsv.Rows[0]["filename"].ToString());
            int INSSGResult = InsertStoreGroupNameList(tblcsv.Rows[0]["filename"].ToString());
            DeleteInsertStore(tblcsv.Rows[0]["filename"].ToString());


            InsertStoreGroupFoloder(tblcsv.Rows[0]["filename"].ToString());
            InsertStoreSubet(tblcsv.Rows[0]["filename"].ToString());




            var selectList = new List<SSDetails>();

            string querySDtnt = "";

            using (SqlConnection con = new SqlConnection(CS))
            {
                querySDtnt = " with cte as";
                querySDtnt += " (SELECT ROW_NUMBER() OVER ( ";

                querySDtnt += " ORDER BY streamServerImportID asc ";
                querySDtnt += " )rn,StreamServerImportID,RecStatus  ";

                querySDtnt += " from tblStreamServerImport  where FileName = '" + tblcsv.Rows[0]["filename"].ToString() + "')";

                querySDtnt += " select * from cte where RecStatus = 'E'";



                SqlCommand cmds = new SqlCommand(querySDtnt, con);
                cmds.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdrs = cmds.ExecuteReader();
                while (rdrs.Read())
                {
                    int rns = Convert.ToInt32(rdrs["rn"]);
                    rns = rns + 1;
                    selectList.Add(new SSDetails
                    {

                        Remarks = rns.ToString()
                    });


                }

            }
            ViewData["videostatusList"] = selectList;
            if (tblcsv.Rows.Count == selectList.Count)
            {
                sucmsg = MujiStore.Resources.Resource.Unabletoimportstreamserver;
            }
            else
            {
                sucmsg = MujiStore.Resources.Resource.Streamserverimportedsuccessfully;
            }


            return RedirectToAction("Upload", "StreamServers");
        }
        //Function to Insert Records  
        private void InsertCSVRecords(DataTable csvdt)
        {

   
            //creating object of SqlBulkCopy    
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlBulkCopy objbulk = new SqlBulkCopy(con);
   
                objbulk.DestinationTableName = "tblStreamServerImport";
                //Mapping Table column    
                objbulk.ColumnMappings.Add("SSServer", "SSServer");
                objbulk.ColumnMappings.Add("IPAddress", "IPAddress");
                objbulk.ColumnMappings.Add("BelongingSubnet", "BelongingSubnet");
 
                objbulk.ColumnMappings.Add("CRTCD", "CRTCD");
                objbulk.ColumnMappings.Add("UserIPAddress", "UserIPAddress");
                objbulk.ColumnMappings.Add("FileName", "FileName");
                objbulk.ColumnMappings.Add("StoreName", "StoreName");
                objbulk.ColumnMappings.Add("StoreGroupName", "StoreGroupName");
                objbulk.ColumnMappings.Add("StoreNumber", "StoreNumber");
                objbulk.ColumnMappings.Add("FolderName", "FolderName");
                objbulk.ColumnMappings.Add("SubnetNumber", "SubnetNumber");
 
                objbulk.WriteToServer(csvdt);

               


                con.Close();

            }
        }

       

        public int UpdateInActiveSubnetIDList(string fileName)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string UpdQuery = "";
                UpdQuery = "Update tblSubnet set DELFG = 0,UPDDT=getdate(),UPDCD=@UPDCD ";
                UpdQuery += " where SubnetID in ";
                UpdQuery += " ( ";
                UpdQuery += " select top 1 with ties SubnetID from tblSubnet where SNIPAddress in ";
                UpdQuery += " ( ";
                UpdQuery += " Select distinct BelongingSubnet from tblStreamServerImport ";
                UpdQuery += " where BelongingSubnet NOT IN ( ";
                UpdQuery += " select SNIPAddress from tblSubnet where DELFG = 0) ";
                UpdQuery += " and FileName =@FileName ";
                UpdQuery += " and RecStatus in ('I','W') ";
                UpdQuery += " ) and DELFG = 1";
                UpdQuery += " order by row_number() over (partition by SNIPAddress order by CRTDT desc) ";
                UpdQuery += " ) ";
                SqlCommand cmd = new SqlCommand(UpdQuery, con);
                cmd.Parameters.AddWithValue("@FileName", fileName);
                cmd.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                cmd.CommandType = CommandType.Text;
                con.Open();
                result = cmd.ExecuteNonQuery();
            }




            return result = 0;
        }

        public int UpdateInActiveDeployScheduleList(string fileName)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string UpdQuery = "";
                UpdQuery = "Update tblDeploySchedule set DELFG = 0,UPDDT=getdate(),UPDCD=@UPDCD ";
                UpdQuery += " where DeployScheduleID in ";
                UpdQuery += " ( ";
                UpdQuery += " select top 1 with ties DeployScheduleID from tblDeploySchedule where Name in ";
                UpdQuery += " ( ";
                UpdQuery += " Select distinct DeploySchedule from tblStreamServerImport ";
                UpdQuery += " where DeploySchedule NOT IN ( ";
                UpdQuery += " select Name from tblDeploySchedule where DELFG = 0) ";
                UpdQuery += " and FileName =@FileName ";
                UpdQuery += " and RecStatus in ('I','W') ";
                UpdQuery += " ) and DELFG = 1 ";
                UpdQuery += " order by row_number() over (partition by Name order by CRTDT desc) ";
                UpdQuery += " ) ";
                SqlCommand cmd = new SqlCommand(UpdQuery, con);
                cmd.Parameters.AddWithValue("@FileName", fileName);
                cmd.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                cmd.CommandType = CommandType.Text;
                con.Open();
                result = cmd.ExecuteNonQuery();
            }




            return result = 0;
        }

        public int UpdateInActiveStoreNameList(string fileName)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string UpdQuery = "";
                UpdQuery = "Update tblStore set DELFG = 0,UPDDT=getdate(),UPDCD=@UPDCD ";
                UpdQuery += " where StoreID in ";
                UpdQuery += " ( ";
                UpdQuery += " select top 1 with ties StoreID from tblStore where StoreName in ";
                UpdQuery += " ( ";
                UpdQuery += " Select distinct StoreName from tblStreamServerImport ";
                UpdQuery += " where StoreName NOT IN ( ";
                UpdQuery += " select StoreName from tblStore where DELFG = 0) ";
                UpdQuery += " and FileName =@FileName ";
                UpdQuery += " and RecStatus in ('I','W') ";
                UpdQuery += " ) and DELFG = 1  ";
                UpdQuery += " order by row_number() over (partition by StoreName order by CRTDT desc) ";
                UpdQuery += " ) ";
                SqlCommand cmd = new SqlCommand(UpdQuery, con);
                cmd.Parameters.AddWithValue("@FileName", fileName);
                cmd.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                cmd.CommandType = CommandType.Text;
                con.Open();
                result = cmd.ExecuteNonQuery();
            }




            return result = 0;
        }

        public int UpdateInActiveStoreGroupNameList(string fileName)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string UpdQuery = "";
                UpdQuery = "Update tblStoreGroup set DELFG = 0,UPDDT=getdate(),UPDCD=@UPDCD ";
                UpdQuery += " where StoreGroupID in ";
                UpdQuery += " ( ";
                UpdQuery += " select top 1 with ties StoreGroupID from tblStoreGroup where Name in ";
                UpdQuery += " ( ";
                UpdQuery += " Select distinct StoreGroupName from tblStreamServerImport ";
                UpdQuery += " where StoreGroupName NOT IN ( ";
                UpdQuery += " select Name from tblStoreGroup where DELFG = 0) ";
                UpdQuery += " and FileName =@FileName ";
                UpdQuery += " and RecStatus in ('I','W') ";
                UpdQuery += " ) and DELFG = 1 ";
                UpdQuery += " order by row_number() over (partition by Name order by CRTDT desc) ";
                UpdQuery += " ) ";
                SqlCommand cmd = new SqlCommand(UpdQuery, con);
                cmd.Parameters.AddWithValue("@FileName", fileName);
                cmd.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                cmd.CommandType = CommandType.Text;
                con.Open();
                result = cmd.ExecuteNonQuery();
            }




            return result = 0;
        }

        public int InsertStoreGroupNameList(string fileName)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string UpdQuery = "";
                UpdQuery = " insert into tblStoreGroup(Name,DELFG,CRTDT,CRTCD,IPAddress)  ";
                UpdQuery += " Select distinct StoreGroupName,0,getdate(),@UPDCD,@IPAddress ";
                UpdQuery += " from tblStreamServerImport where StoreGroupName NOT IN ";
                UpdQuery += " (select Name from tblStoreGroup where DELFG = 0)  ";
                UpdQuery += " and FileName =@FileName ";
                UpdQuery += " and RecStatus in ('I','W') and isnull(StoreGroupName,'') != '' ";

                SqlCommand cmd = new SqlCommand(UpdQuery, con);
                cmd.Parameters.AddWithValue("@FileName", fileName);
                cmd.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                cmd.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());
                cmd.CommandType = CommandType.Text;
                con.Open();
                result = cmd.ExecuteNonQuery();
            }




            return result = 0;
        }
        public int UpdateInActiveFormatList(string fileName)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string UpdQuery = "";
                UpdQuery = "Update tblFormat set DELFG = 0,UPDDT=getdate(),UPDCD=@UPDCD ";
                UpdQuery += " where FormatID in ";
                UpdQuery += " ( ";
                UpdQuery += " select top 1 with ties FormatID from tblFormat where Name in ";
                UpdQuery += " ( ";
                UpdQuery += " Select distinct FileType from tblStreamServerImport ";
                UpdQuery += " where FileType NOT IN ( ";
                UpdQuery += " select Name from tblFormat where DELFG = 0) ";
                UpdQuery += " and FileName =@FileName ";
                UpdQuery += " and RecStatus in ('I','W') ";
                UpdQuery += " ) and DELFG = 1 ";
                UpdQuery += " order by row_number() over (partition by Name order by CRTDT desc) ";
                UpdQuery += " ) ";

                SqlCommand cmd = new SqlCommand(UpdQuery, con);
                cmd.Parameters.AddWithValue("@FileName", fileName);
                cmd.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                cmd.CommandType = CommandType.Text;
                con.Open();
                result = cmd.ExecuteNonQuery();
            }




            return result = 0;
        }

        public List<String> GetMissingSubnetIDList(string fileName)
        {
            var selectList = new List<String>();
            using (SqlConnection con = new SqlConnection(CS))
            {

                string queryList = "";
                queryList = "Select distinct BelongingSubnet from tblStreamServerImport where BelongingSubnet NOT IN (select SNIPAddress from tblSubnet where DELFG = 0 ) and FileName =@FileName and RecStatus in ('I','W') ";


                SqlCommand cmds = new SqlCommand(queryList, con);

                cmds.Parameters.AddWithValue("@FileName", fileName);
                cmds.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdrs = cmds.ExecuteReader();
                while (rdrs.Read())
                {
                    if (rdrs["BelongingSubnet"] != null)
                    {
                        selectList.Add(rdrs["BelongingSubnet"].ToString());
                    }
                };
            }
            return selectList;
        }

        public List<String> GetExistingSubnetIDList()
        {
            var selectList = new List<String>();
            using (SqlConnection con = new SqlConnection(CS))
            {

                string queryList = "";
                queryList = "Select distinct BelongingSubnet from tblStreamServerImport where BelongingSubnet IN (select SNIPAddress from tblSubnet)";
                SqlCommand cmds = new SqlCommand(queryList, con);
                cmds.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdrs = cmds.ExecuteReader();
                while (rdrs.Read())
                {
                    if (rdrs["BelongingSubnet"] != null)
                    {
                        selectList.Add(rdrs["BelongingSubnet"].ToString());
                    }
                };
            }
            return selectList;
        }

        public int getMaxSubnetId()
        {
            int maxSubnetId = 1;

            using (SqlConnection con = new SqlConnection(CS))
            {

                string query = "select MAX(SubnetID) from tblSubnet";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                maxSubnetId = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();

            }
            return maxSubnetId;
        }

        

        public void InsertSubnetRecord(int SubnetID, String SNIPAddress, String SubnetMask, float WANBandWidth, float LANBandWidth, int DELFG, DateTime CRTDT, String CRTCD, String IPAddress)
        {
            List<SubnetDetails> SubnetDetails = new List<SubnetDetails>();
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string query = "INSERT INTO tblSubnet (SubnetID, SNIPAddress, SubnetMask, WANBandWidth, LANBandWidth, DELFG, CRTDT, CRTCD,  IPAddress)";
                    query += " VALUES (@SubnetID, @SNIPAddress, @SubnetMask, @WANBandWidth, @LANBandWidth, @DELFG, @CRTDT, @CRTCD, @IPAddress)";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@SubnetID", SubnetID);
                    
                    cmd.Parameters.AddWithValue("@SNIPAddress", SNIPAddress);
               

                    cmd.Parameters.AddWithValue("@SubnetMask", SubnetMask);
                    cmd.Parameters.AddWithValue("@WANBandWidth", WANBandWidth);
                    cmd.Parameters.AddWithValue("@LANBandWidth", LANBandWidth);
                    cmd.Parameters.AddWithValue("@DELFG", DELFG);
                    cmd.Parameters.AddWithValue("@CRTDT", CRTDT);
                    cmd.Parameters.AddWithValue("@CRTCD", CRTCD);
                   
                    cmd.Parameters.AddWithValue("@IPAddress", IPAddress);
                  
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
              
            }
            
        }

        public void updateSubnetRecord(String SNIPAddress)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string query = "Update tblSubnet set DELFG = 0 where SNIPAddress = @SNIPAddress";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@SNIPAddress", SNIPAddress);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Not Updated due to error");
            }

        }


        public List<String> GetMissingDeployScheduleList(string FileName)
        {
            var selectList = new List<String>();
            using (SqlConnection con = new SqlConnection(CS))
            {

                string queryList = "";
                queryList = "Select distinct DeploySchedule from tblStreamServerImport where DeploySchedule NOT IN (select Name from tblDeploySchedule where DELFG = 0) and FileName =@FileName and RecStatus in ('I','W') ";


                SqlCommand cmds = new SqlCommand(queryList, con);
                cmds.Parameters.AddWithValue("@FileName", FileName);
                cmds.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdrs = cmds.ExecuteReader();
                while (rdrs.Read())
                {
                    if (rdrs["DeploySchedule"] != null)
                    {
                        selectList.Add(rdrs["DeploySchedule"].ToString());
                    }
                };
            }
            return selectList;
        }


        public List<String> GetExistingDeployScheduleList()
        {
            var selectList = new List<String>();
            using (SqlConnection con = new SqlConnection(CS))
            {

                string queryList = "";
                queryList = "Select distinct DeploySchedule from tblStreamServerImport where DeploySchedule IN (select Name from tblDeploySchedule)";

                SqlCommand cmds = new SqlCommand(queryList, con);
                cmds.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdrs = cmds.ExecuteReader();
                while (rdrs.Read())
                {
                    if (rdrs["DeploySchedule"] != null)
                    {
                        selectList.Add(rdrs["DeploySchedule"].ToString());
                    }
                };
            }
            return selectList;
        }


        public int getMaxDeployScheduleId()
        {
            int maxDeployScheduleId = 1;

            using (SqlConnection con = new SqlConnection(CS))
            {

                string query = "select MAX(DeployScheduleID) from tblDeploySchedule";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                maxDeployScheduleId = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();

            }
            return maxDeployScheduleId;
        }

        public void InsertDeployScheduleRecord(String Name, String Schedule, int DELFG, String CRTCD, String IPAddress)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string query = "INSERT INTO tblDeploySchedule (Name, Schedule, DELFG, CRTDT, CRTCD,  IPAddress)";
                    query += " VALUES (@Name, @Schedule, @DELFG, @CRTDT, @CRTCD,@IPAddress)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@Schedule", Schedule);
                    cmd.Parameters.AddWithValue("@DELFG", DELFG);
                    cmd.Parameters.AddWithValue("@CRTDT", DateTime.Now);
                    cmd.Parameters.AddWithValue("@CRTCD", CRTCD);
                    cmd.Parameters.AddWithValue("@IPAddress", IPAddress);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Not inserted due to error");
            }

        }


        public void updateDeployScheduleRecord(String Name)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string query = "Update tblDeploySchedule set DELFG = 0 where Name = @Name";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Not Updated due to error");
            }

        }

        public List<String> GetMissingFormatList(string FileName)
        {
            var selectList = new List<String>();
            using (SqlConnection con = new SqlConnection(CS))
            {

                string queryList = "";
                queryList = "Select distinct FileType from tblStreamServerImport where FileType NOT IN (select Name from tblFormat where DELFG = 0) and FileName =@FileName and RecStatus in ('I','W') ";


                SqlCommand cmds = new SqlCommand(queryList, con);
                cmds.Parameters.AddWithValue("@FileName", FileName);
                cmds.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdrs = cmds.ExecuteReader();
                while (rdrs.Read())
                {
                    if (rdrs["FileType"] != null)
                    {
                        selectList.Add(rdrs["FileType"].ToString());
                    }
                };
            }
            return selectList;
        }



        public List<String> GetExistingFormatList()
        {
            var selectList = new List<String>();
            using (SqlConnection con = new SqlConnection(CS))
            {

                string queryList = "";
                queryList = "Select distinct FileType from tblStreamServerImport where FileType IN (select Name from tblFormat)";

                SqlCommand cmds = new SqlCommand(queryList, con);
                cmds.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdrs = cmds.ExecuteReader();
                while (rdrs.Read())
                {
                    if (rdrs["FileType"] != null)
                    {
                        selectList.Add(rdrs["FileType"].ToString());
                    }
                };
            }
            return selectList;
        }


        public int getMaxFormatId()
        {
            int maxFormatID = 1;

            using (SqlConnection con = new SqlConnection(CS))
            {

                string query = "select MAX(FormatID) from tblFormat";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                maxFormatID = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();

            }
            return maxFormatID;
        }

        public void UpdateSubnetNumber(string FileName)
        {
            List<SSDetails> SubnetDtl = new List<SSDetails>();

            using (SqlConnection con = new SqlConnection(CS))
            {
                string querySubnetList = "";
                querySubnetList =  " Select SSI.BelongingSubnet,SSI.SubnetNumber ";
                querySubnetList += " From tblStreamServerImport SSI ";
                querySubnetList += " Join tblSubnet S On SSI.BelongingSubnet = S.SNIPAddress ";
                querySubnetList += " where FileName =@FileName ";
                querySubnetList += " and RecStatus in ('I','W') ";
                querySubnetList += " and S.DELFG = 0  Order by SSI.StreamServerImportID";

                SqlCommand cmds = new SqlCommand(querySubnetList, con);
                cmds.Parameters.AddWithValue("@FileName", FileName);
                cmds.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdrs = cmds.ExecuteReader();
                while (rdrs.Read())
                {
                    SSDetails snd = new SSDetails();
                    snd.BelongingSubnet = rdrs["BelongingSubnet"].ToString();
                    snd.SubnetNumber = rdrs["SubnetNumber"].ToString();


                    SubnetDtl.Add(snd);
                }
            }

            if (SubnetDtl.Count > 0)
            {
                string querySDtl = "";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    foreach (SSDetails items in SubnetDtl)
                    {
                        querySDtl =  "";
                        querySDtl += " update tblstoresubnet set IPAddress = @IPAddress,  DELFG = 1,UPDDT = @UPDDT,UPDCD = @UPDCD where Subnet in ";
                        querySDtl += " (select SubnetID from tblSubnet where SNIPAddress <> @BelongingSubnet and Subnetid = @SubnetNumber and DELFG = 0  ) and DELFG = 0 ";


                        SqlCommand cmd3 = new SqlCommand(querySDtl, con);


                        cmd3.Parameters.AddWithValue("@BelongingSubnet", items.BelongingSubnet);
                        cmd3.Parameters.AddWithValue("@SubnetNumber", items.SubnetNumber);
                        cmd3.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());
                        cmd3.Parameters.AddWithValue("@UPDDT", DateTime.Now);
                        cmd3.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                        cmd3.CommandType = CommandType.Text;

                        int result3 = cmd3.ExecuteNonQuery();

                        querySDtl = "";
                        querySDtl = "Update tblStreamServer set  IPAddress = @IPAddress,  DELFG = 1,UPDDT = @UPDDT,UPDCD = @UPDCD where BelongingSubnet in ";
                        querySDtl += " (select SubnetID from tblSubnet where SNIPAddress <> @BelongingSubnet and Subnetid = @SubnetNumber and DELFG = 0  ) and DELFG = 0 ";

                        SqlCommand cmd4 = new SqlCommand(querySDtl, con);


                        cmd4.Parameters.AddWithValue("@BelongingSubnet", items.BelongingSubnet);
                        cmd4.Parameters.AddWithValue("@SubnetNumber", items.SubnetNumber);
                        cmd4.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());
                        cmd4.Parameters.AddWithValue("@UPDDT", DateTime.Now);
                        cmd4.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                        cmd4.CommandType = CommandType.Text;

                        int result4 = cmd4.ExecuteNonQuery();


                        querySDtl = "";
                        querySDtl += "update tblSubnet set IPAddress = @IPAddress,  DELFG = 1,UPDDT = @UPDDT,UPDCD = @UPDCD where SubnetID in ";
                        querySDtl += "(select SubnetID from tblSubnet where SNIPAddress <> @BelongingSubnet and Subnetid = @SubnetNumber and DELFG = 0  ) and DELFG = 0  ";


                        SqlCommand cmd5 = new SqlCommand(querySDtl, con);


                        cmd5.Parameters.AddWithValue("@BelongingSubnet", items.BelongingSubnet);
                        cmd5.Parameters.AddWithValue("@SubnetNumber", items.SubnetNumber);
                        cmd5.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());
                        cmd5.Parameters.AddWithValue("@UPDDT", DateTime.Now);
                        cmd5.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                        cmd5.CommandType = CommandType.Text;

                        int result5 = cmd5.ExecuteNonQuery();




                    }
                }
                
            }
        }
        public void InsertUpdateStore(string FileName)
        {
            List<tblStore> StoreDtl = new List<tblStore>();
            List<tblStore> StoreDtl1 = new List<tblStore>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                string queryStoreList = "";
                queryStoreList = " Select StoreName,SG.StoreGroupID,ssi.StoreNumber ";
                queryStoreList += " from tblStreamServerImport SSI ";
                queryStoreList += " Left join tblStoreGroup SG on SG.Name = SSI.StoreGroupName ";
                queryStoreList += " and SG.DELFG = 0  ";
                queryStoreList += " where FileName =@FileName ";
                queryStoreList += " and RecStatus in ('I','W') Order by SSI.StreamServerImportID ";

                SqlCommand cmds = new SqlCommand(queryStoreList, con);
                cmds.Parameters.AddWithValue("@FileName", FileName);
                cmds.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdrs = cmds.ExecuteReader();
                while (rdrs.Read())
                {
                    tblStore ssr = new tblStore();
                    ssr.StoreName = rdrs["StoreName"].ToString();
                    ssr.StoreNumber = Convert.ToInt32(rdrs["StoreNumber"].ToString());
                    if (rdrs["StoreGroupID"].ToString() == "")
                    {
                        ssr.StoreGroupID = null;
                    }
                    else
                    {
                        ssr.StoreGroupID = Convert.ToInt32(rdrs["StoreGroupID"].ToString());
                    }

                    StoreDtl.Add(ssr);
                }
            }

            if (StoreDtl.Count > 0)
            {
                string querySDtl = "";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    foreach (tblStore items in StoreDtl)
                    {
                        querySDtl = "if exists(select StoreID from tblStore where StoreName = @StoreName and DELFG = 0 )  ";
                        querySDtl += " begin ";
                        querySDtl += " update tblStore set StoreGroupID = @StoreGroupID,IPAddress = @IPAddress, ";
                        querySDtl += " DELFG = 0,UPDDT = @UPDDT,UPDCD = @UPDCD ";
                        querySDtl += " where StoreName = @StoreName ";
                        querySDtl += " end ";
                        querySDtl += " else if exists (select StoreID from tblStore where StoreName = @StoreName and DELFG = 1 )  ";
                        querySDtl += " begin ";
                        querySDtl += " update tblStore set StoreGroupID = @StoreGroupID,IPAddress = @IPAddress, ";
                        querySDtl += " DELFG = 0,UPDDT = @UPDDT,UPDCD = @UPDCD ";
                        querySDtl += " where StoreID in ";
                        querySDtl += " (select top 1 StoreID from tblStore where StoreName = @StoreName and DELFG = 1 Order by CRTDT DESC) ";
                        querySDtl += " end ";
                        querySDtl += " else ";
                        querySDtl += " begin ";
                        querySDtl += " insert into tblStore(storeid,StoreName, DELFG, CRTDT, CRTCD,IPAddress,StoreGroupID) ";
                        querySDtl += " values(@StoreNumber,@StoreName, 0,@UPDDT, @UPDCD, @IPAddress,@StoreGroupID)";
                        querySDtl += " end ";


                        SqlCommand cmd = new SqlCommand(querySDtl, con);
                        cmd.Parameters.AddWithValue("@StoreName", items.StoreName);
                        cmd.Parameters.AddWithValue("@StoreNumber", items.StoreNumber);
                        if (items.StoreGroupID == null)
                        {
                            cmd.Parameters.AddWithValue("@StoreGroupID", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@StoreGroupID", items.StoreGroupID);
                        }

                        cmd.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());
                        cmd.Parameters.AddWithValue("@UPDDT", DateTime.Now);
                        cmd.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                        cmd.CommandType = CommandType.Text;

                        int result = cmd.ExecuteNonQuery();

                        //update

                        querySDtl = "";
                        querySDtl = "update tblstoresubnet set IPAddress = @IPAddress,  DELFG = 1,UPDDT = @UPDDT,UPDCD = @UPDCD where Store in " +
                            "(select StoreID from tblStore where StoreName <> @StoreName  and DELFG = 0  ) and DELFG = 0";


                        SqlCommand cmd3 = new SqlCommand(querySDtl, con);


                        cmd3.Parameters.AddWithValue("@StoreName", items.StoreName);

                        cmd3.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());
                        cmd3.Parameters.AddWithValue("@UPDDT", DateTime.Now);
                        cmd3.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                        cmd3.CommandType = CommandType.Text;
                     
                        int result3 = cmd3.ExecuteNonQuery();

                        querySDtl = "";
                        querySDtl = "update tblstore set IPAddress = @IPAddress,  DELFG = 1,UPDDT = @UPDDT,UPDCD = @UPDCD where StoreID in " +
                            "(select StoreID from tblStore where StoreName <> @StoreName  and DELFG = 0  ) and DELFG = 0 ";


                        SqlCommand cmd4 = new SqlCommand(querySDtl, con);


                        cmd4.Parameters.AddWithValue("@StoreName", items.StoreName);

                        cmd4.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());
                        cmd4.Parameters.AddWithValue("@UPDDT", DateTime.Now);
                        cmd4.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                        cmd4.CommandType = CommandType.Text;

                       

                    }
                }
            }
        }
        public void InsertStoreGroupFoloder(string FileName)
        {
            List<tblStoreGroupFolder> SGroupFolder = new List<tblStoreGroupFolder>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                string queryStoreSubnetList = "";
                queryStoreSubnetList = " Select SSI.FolderName,SG.StoreGroupID from tblStreamServerImport SSI ";
                queryStoreSubnetList += " join tblFolder F on F.Name = SSI.FolderName ";
                queryStoreSubnetList += " join tblStoreGroup SG on SG.Name=SSI.StoreGroupName ";
                queryStoreSubnetList += "Where SSI.FileName =@FileName and RecStatus in ('I','W')  and SG.DELFG=0   Order by SSI.StreamServerImportID ";


                SqlCommand cmds = new SqlCommand(queryStoreSubnetList, con);
                cmds.Parameters.AddWithValue("@FileName", FileName);
                cmds.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdrs = cmds.ExecuteReader();
                while (rdrs.Read())
                {
                    tblStoreGroupFolder SGFfolder = new tblStoreGroupFolder();
                    SGFfolder.StoreGroupID = Convert.ToInt32(rdrs["StoreGroupID"]);
                    SGFfolder.FolderName = rdrs["FolderName"].ToString();
                    SGroupFolder.Add(SGFfolder);
                }
            }
            if (SGroupFolder.Count > 0)
            {
                string querySSDtl = "";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    foreach (tblStoreGroupFolder items in SGroupFolder)
                    {

                        querySSDtl = "";

   

                        querySSDtl =  " if exists (select top 1 StoreGroupFolderID from tblStoreGroupFolder where StoreGroupID =@StoreGroupID and DELFG = 0) ";
                        querySSDtl += " begin ";
                        querySSDtl += " update tblStoreGroupFolder set FolderID = (select FolderID from tblFolder where Name = @Name and DELFG = 0), ";
                        querySSDtl += " DELFG = 0,UPDDT=@UPDDT,UPDCD=@UPDCD,IPAddress=@IPAddress ";
                        querySSDtl += " where StoreGroupID =@StoreGroupID and DELFG = 0 ";
                        querySSDtl += " end ";
                        querySSDtl += " else if exists (select top 1 StoreGroupFolderID from tblStoreGroupFolder where StoreGroupID =@StoreGroupID and DELFG = 1) ";
                        querySSDtl += " begin ";
                        querySSDtl += " update tblStoreGroupFolder set FolderID = (select FolderID from tblFolder where Name = @Name and DELFG = 0), ";
                        querySSDtl += " DELFG = 0,UPDDT=@UPDDT,UPDCD=@UPDCD,IPAddress=@IPAddress ";
                        querySSDtl += " where StoreGroupFolderID in ";
                        querySSDtl += " (select top 1 StoreGroupFolderID from tblStoreGroupFolder where StoreGroupID =@StoreGroupID and DELFG = 1 Order by StoreGroupFolderID desc) ";
                        querySSDtl += " end ";
                        querySSDtl += " else ";
                        querySSDtl += " begin ";
                        querySSDtl += " insert into tblStoreGroupFolder(StoreGroupID,FolderID,DELFG,CRTDT,CRTCD,IPAddress) ";
                        querySSDtl += " Select @StoreGroupID,FolderID,0,@UPDDT,@UPDCD,@IPAddress from tblFolder ";
                        querySSDtl += " Where Name = @Name and DELFG = 0 ";
                        querySSDtl += " end ";



                        SqlCommand cmdSS = new SqlCommand(querySSDtl, con);
                        cmdSS.Parameters.AddWithValue("@Name", items.FolderName);
                        cmdSS.Parameters.AddWithValue("@StoreGroupID", items.StoreGroupID);
                        cmdSS.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());
                        cmdSS.Parameters.AddWithValue("@UPDDT", DateTime.Now);
                        cmdSS.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                        cmdSS.CommandType = CommandType.Text;

                        int resultSS = cmdSS.ExecuteNonQuery();

                    }
                }
            }
        }
        public void InsertUpdateStoreSubnet(string FileName)
        {
            List<tblStoreSubnet> StoreSntDtl = new List<tblStoreSubnet>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                string queryStoreSubnetList = "";
                queryStoreSubnetList = " select SN.SubnetID,S.StoreID ";
                queryStoreSubnetList += " from tblStreamServerImport SSI ";
                queryStoreSubnetList += " left join tblSubnet SN on SSI.BelongingSubnet = SN.SNIPAddress ";
                queryStoreSubnetList += " Left Join tblStore S on S.StoreName = SSI.StoreName ";
                queryStoreSubnetList += " where FileName =@FileName ";
                queryStoreSubnetList += " and RecStatus in ('I','W') ";
                queryStoreSubnetList += " and SN.DELFG = 0 and S.DELFG = 0  Order by SSI.StreamServerImportID";

                SqlCommand cmds = new SqlCommand(queryStoreSubnetList, con);
                cmds.Parameters.AddWithValue("@FileName", FileName);
                cmds.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdrs = cmds.ExecuteReader();
                while (rdrs.Read())
                {
                    tblStoreSubnet ssnet = new tblStoreSubnet();
                    ssnet.Subnet = Convert.ToInt32(rdrs["SubnetID"]);
                    ssnet.Store = Convert.ToInt32(rdrs["StoreID"]);
                    StoreSntDtl.Add(ssnet);
                }
            }

            if (StoreSntDtl.Count > 0)
            {
                string querySSDtl = "";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    foreach (tblStoreSubnet items in StoreSntDtl)
                    {
                        querySSDtl = " if exists (select * from tblStoreSubnet where Store =@Store and Subnet != @Subnet and DELFG = 0) ";
                        querySSDtl += " begin ";
                        querySSDtl += " update tblStoreSubnet set DELFG =1,UPDDT=@UPDDT,UPDCD=@UPDCD,IPAddress = @IPAddress ";
                        querySSDtl += " where StoreSubnetID in (select StoreSubnetID from tblStoreSubnet where Store =@Store and Subnet != @Subnet and DELFG = 0) ";
                        querySSDtl += " end ";

                        SqlCommand cmd = new SqlCommand(querySSDtl, con);
                        cmd.Parameters.AddWithValue("@Store", items.Store);
                        cmd.Parameters.AddWithValue("@Subnet", items.Subnet);
                        cmd.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());
                        cmd.Parameters.AddWithValue("@UPDDT", DateTime.Now);
                        cmd.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                        cmd.CommandType = CommandType.Text;

                        int result = cmd.ExecuteNonQuery();

                        querySSDtl = "";

                        querySSDtl = " if exists (select * from tblStoreSubnet where Store !=@Store and Subnet = @Subnet and DELFG = 0) ";
                        querySSDtl += " begin ";
                        querySSDtl += " update tblStoreSubnet set DELFG =1,UPDDT=@UPDDT,UPDCD=@UPDCD,IPAddress = @IPAddress ";
                        querySSDtl += " where StoreSubnetID in (select StoreSubnetID from tblStoreSubnet where Store != @Store and Subnet = @Subnet and DELFG = 0) ";
                        querySSDtl += " end ";

                        SqlCommand cmdST = new SqlCommand(querySSDtl, con);
                        cmdST.Parameters.AddWithValue("@Store", items.Store);
                        cmdST.Parameters.AddWithValue("@Subnet", items.Subnet);
                        cmdST.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());
                        cmdST.Parameters.AddWithValue("@UPDDT", DateTime.Now);
                        cmdST.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                        cmdST.CommandType = CommandType.Text;

                        int resultST = cmdST.ExecuteNonQuery();

                        querySSDtl = "";
                        querySSDtl = " if not exists (select * from tblStoreSubnet where Store =@Store and Subnet = @Subnet and DELFG = 0 ) ";
                        querySSDtl += " begin ";
                        querySSDtl += " if exists (select * from tblStoreSubnet where Store =@Store and Subnet = @Subnet and DELFG = 1) ";
                        querySSDtl += " begin ";
                        querySSDtl += " update tblStoreSubnet set DELFG = 0,UPDDT=@UPDDT,UPDCD=@UPDCD,IPAddress = @IPAddress ";
                        querySSDtl += " where StoreSubnetID in (select Top 1StoreSubnetID from tblStoreSubnet where Subnet = @Subnet and Store =@Store  and DELFG = 1 Order by CRTDT DESC)";
                        querySSDtl += " end ";
                        querySSDtl += " else ";
                        querySSDtl += " begin ";
                        querySSDtl += " Insert into tblStoreSubnet(Store,Subnet,DELFG,CRTDT,CRTCD,IPAddress)  ";
                        querySSDtl += " values (@Store,@Subnet,0,@UPDDT,@UPDCD,@IPAddress) ";
                        querySSDtl += " end ";
                        querySSDtl += " end ";

                        SqlCommand cmdSS = new SqlCommand(querySSDtl, con);
                        cmdSS.Parameters.AddWithValue("@Store", items.Store);
                        cmdSS.Parameters.AddWithValue("@Subnet", items.Subnet);
                        cmdSS.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());
                        cmdSS.Parameters.AddWithValue("@UPDDT", DateTime.Now);
                        cmdSS.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                        cmdSS.CommandType = CommandType.Text;

                        int resultSS = cmdSS.ExecuteNonQuery();




                    }


               
                }
            }
        }
        public void InsertUpdateStreamServer(string FileName)
        {

            
            List<tblStreamServer> SsDtl = new List<tblStreamServer>();

            using (SqlConnection con = new SqlConnection(CS))
            {

                string queryList = "";
                
                queryList += "Select StreamServerImportID,tblStreamServer.StreamServerID,  ";
                queryList += "tblStreamServerImport.SSServer,tblStreamServerImport.IPAddress,SubnetID,  ";
                queryList += "RecStatus,Remarks,tblStreamServer.DELFG from tblStreamServerImport   ";
                queryList += "left join tblSubnet on tblSubnet.SNIPAddress =  tblStreamServerImport.BelongingSubnet  ";
                queryList += "left join tblStreamServer on tblStreamServer.BelongingSubnet = tblSubnet.SubnetID  where RecStatus in ('I','W') and  ";
                queryList += "FileName = @FileName  and tblSubnet.DELFG = 0  Order by StreamServerImportID  ";

                SqlCommand cmds = new SqlCommand(queryList, con);
                cmds.Parameters.AddWithValue("@FileName", FileName);
                cmds.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdrs = cmds.ExecuteReader();
                while (rdrs.Read())
                {
                    tblStreamServer sser = new tblStreamServer();
                    sser.SSServer = rdrs["SSServer"].ToString();
                    sser.IPAddress = rdrs["IPAddress"].ToString();
                    sser.BelongingSubnet = Convert.ToInt32(rdrs["SubnetID"]);
                    
                };

            }


            if (SsDtl.Count > 0)
            {
                string querySDtl = "";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    foreach (tblStreamServer items in SsDtl)
                    {
                        
                        querySDtl = "  if exists(select StreamServerID from tblStreamServer  ";
                        querySDtl += " where BelongingSubnet = @BelongingSubnet)   begin  update  ";
                        querySDtl += " tblStreamServer set SSServer = @SSServer,IPAddress = @IPAddress,   ";
                        querySDtl += " DELFG = 0,UPDDT = @UPDDT,UPDCD = @UPDCD,UserIPAddress = @UserIPAddress   ";
                        querySDtl += " where BelongingSubnet = @BelongingSubnet  end   ";
                        querySDtl += " else if exists (select StreamServerID from tblStreamServer where BelongingSubnet = @BelongingSubnet and DELFG = 1) begin ";
                        querySDtl += " update tblStreamServer set SSServer = @SSServer,IPAddress = @IPAddress,   ";
                        querySDtl += " DELFG = 0,UPDDT = @UPDDT,UPDCD = @UPDCD,UserIPAddress = @UserIPAddress   ";
                        querySDtl += " where StreamServerID in  (select top 1 StreamServerID from tblStreamServer  ";
                        querySDtl += " where BelongingSubnet = @BelongingSubnet   and DELFG = 1)  end   ";
                        querySDtl += " else  begin  insert into tblStreamServer(SSServer, IPAddress, BelongingSubnet, DELFG, CRTDT, CRTCD, UserIPAddress)   ";
                        querySDtl += " values(@SSServer, @IPAddress,@BelongingSubnet, 0, @UPDDT, @UPDCD, @UserIPAddress)  end  ";

                       

                        SqlCommand cmd = new SqlCommand(querySDtl, con);
                        cmd.Parameters.AddWithValue("@BelongingSubnet", items.BelongingSubnet);
                        cmd.Parameters.AddWithValue("@SSServer", items.SSServer);
                        cmd.Parameters.AddWithValue("@IPAddress", items.IPAddress);
                        
                        cmd.Parameters.AddWithValue("@UPDDT", DateTime.Now);
                        cmd.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                        cmd.Parameters.AddWithValue("@UserIPAddress", Session["IPAddress"].ToString());
                        cmd.CommandType = CommandType.Text;

                        int result = cmd.ExecuteNonQuery();

                    }


                }
            }

         
        }
        public void DeleteInsertSubnet(string fileName)
        {
            List<tblSubnet> snetdtl = new List<tblSubnet>();
            int result;
            string querySDtl = "Select StreamServerImportID,BelongingSubnet,SubnetNumber";
            querySDtl += " from[dbo].[tblStreamServerImport] ";
            querySDtl += " where FileName = @FileName ";
            querySDtl += "and RecStatus in ('I', 'W') Order by StreamServerImportID";
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(querySDtl, con);
                cmd.Parameters.AddWithValue("@FileName", fileName);

                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        tblSubnet snet = new tblSubnet();
                        snet.SubnetID = Convert.ToInt32(sdr["SubnetNumber"]);
                        snet.SubnetNumber = Convert.ToInt32(sdr["StreamServerImportID"]);
                        snet.SNIPAddress = Convert.ToString(sdr["BelongingSubnet"]);
                        snetdtl.Add(snet);
                    }
                }
            }
                if(snetdtl.Count > 0)
                {
                    
                    foreach (var items in snetdtl)
                    {
                        tblSubnet tblsubnetid = db.tblSubnets.Find(items.SubnetID);
                        if (tblsubnetid == null)
                        {
                            tblsubnetid = new tblSubnet();
                            tblsubnetid.SubnetMask = "255.255.255.0";
                            tblsubnetid.WANBandWidth = 3000000;
                            tblsubnetid.LANBandWidth = 10000000;
                        }
                            using (SqlConnection con = new SqlConnection(CS))
                            {

                                    con.Open();
                                    string query = "";
                                    query = " delete from tblStoreSubnet Where subnet in ( ";

                                    query += " select SubnetID from tblSubnet where SubnetID = @SubnetID  ";
                                    query += " union ";
                                    query += " select SubnetID from tblSubnet where Snipaddress = @BelongingSubnet )";

                                    SqlCommand cmdApp = new SqlCommand(query, con);

                                    cmdApp.Parameters.AddWithValue("@SubnetID", items.SubnetID);
                                    cmdApp.Parameters.AddWithValue("@BelongingSubnet", items.SNIPAddress);

                                    cmdApp.CommandType = CommandType.Text;

                                    result = cmdApp.ExecuteNonQuery();

                                    query = "";
                                    query = " delete from tblStreamServer Where belongingsubnet  in (";
                                    query += " select SubnetID from tblSubnet where SubnetID = @SubnetID  ";
                                    query += " union ";
                                    query += " select SubnetID from tblSubnet where Snipaddress = @BelongingSubnet )";


                                    SqlCommand cmdApp3 = new SqlCommand(query, con);

                                    cmdApp3.Parameters.AddWithValue("@SubnetID", items.SubnetID);
                                    cmdApp3.Parameters.AddWithValue("@BelongingSubnet", items.SNIPAddress);

                                    cmdApp3.CommandType = CommandType.Text;

                                    result = cmdApp3.ExecuteNonQuery();

                                    query = "";
                                    query = " delete from tblSubnet  Where subnetid in ( ";
                                    query += " select SubnetID from tblSubnet where SubnetID = @SubnetID  ";
                                    query += " union ";
                                    query += " select SubnetID from tblSubnet where Snipaddress = @BelongingSubnet )";


                                    SqlCommand cmdApp1 = new SqlCommand(query, con);

                                    cmdApp1.Parameters.AddWithValue("@SubnetID", items.SubnetID);
                                    cmdApp1.Parameters.AddWithValue("@BelongingSubnet", items.SNIPAddress);

                                    cmdApp1.CommandType = CommandType.Text;

                                    cmdApp1.ExecuteNonQuery();

                                    query = "";

                                    query = " Insert Into tblsubnet (SubnetID, SNIPAddress, SubnetMask,WANBandwidth, ";
                                    query += " LANBandwidth,DELFG,CRTDT,CRTCD,IPAddress) Values ";
                                    query += " (@SubnetID, @SNIPAddres, @SubnetMask,@WANBandwidth ";
                                    query += " ,@LANBandwidth,0,@CRTDT,@CRTCD,@IPAddress) ";

                                    SqlCommand cmds = new SqlCommand(query, con);


                                    cmds.Parameters.AddWithValue("@SubnetID", items.SubnetID);
                                    cmds.Parameters.AddWithValue("@SNIPAddres", items.SNIPAddress);
                                    cmds.Parameters.AddWithValue("@SubnetMask", tblsubnetid.SubnetMask);
                                    cmds.Parameters.AddWithValue("@WANBandwidth", tblsubnetid.WANBandWidth);
                                    cmds.Parameters.AddWithValue("@LANBandwidth", tblsubnetid.LANBandWidth);
                                    cmds.Parameters.AddWithValue("@CRTDT", DateTime.Now);
                                    cmds.Parameters.AddWithValue("@CRTCD", Session["UserName"].ToString());
                                    cmds.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());
                                    cmds.CommandType = CommandType.Text;

                                    cmds.CommandType = CommandType.Text;
                                    cmds.ExecuteNonQuery();

                                    string streamserver = System.Configuration.ConfigurationManager.AppSettings["Streamserver"];
                                    string StreamIpaddress = System.Configuration.ConfigurationManager.AppSettings["StreamIpaddress"];


                                    query = "";

                                    query = " Insert Into tblStreamServer (SSServer,IPAddress,BelongingSubnet,DELFG,CRTDT,CRTCD,UserIPAddress ";
                                    query += " ) Values ";
                                    query += " (@streamserver, @StreamIpaddress, @SubnetID ";
                                    query += "  ,0,@CRTDT,@CRTCD,@IPAddress) ";

                                    SqlCommand cmds1 = new SqlCommand(query, con);
                                    cmds1.Parameters.AddWithValue("@streamserver", streamserver);
                                    cmds1.Parameters.AddWithValue("@StreamIpaddress", StreamIpaddress);
                                    cmds1.Parameters.AddWithValue("@SubnetID", items.SubnetID);
                                    cmds1.Parameters.AddWithValue("@CRTDT", DateTime.Now);
                                    cmds1.Parameters.AddWithValue("@CRTCD", Session["UserName"].ToString());
                                    cmds1.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());

                                    cmds1.CommandType = CommandType.Text;
                                    cmds1.ExecuteNonQuery();
                            }

                    }
                }
            
        }
        public void InsertStoreSubet(string fileName)
        {
            List<tblStoreSubnet> strdtl = new List<tblStoreSubnet>();
            int result;
            string querySDtl = "Select Distinct BelongingSubnet,SI.StoreName,SN.SubnetID,S.StoreID ";
            querySDtl += " from [dbo].[tblStreamServerImport] SI ";
            querySDtl += " left join tblSubnet SN on SN.SNIPAddress = SI.BelongingSubnet ";
            querySDtl += " left join tblStore S on S.StoreName = SI.StoreName ";
            querySDtl += " where FileName = @FileName ";
            querySDtl += "and RecStatus in ('I', 'W') and SN.SubnetID is not null and S.StoreID is not null ";
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(querySDtl, con);
                cmd.Parameters.AddWithValue("@FileName", fileName);

                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        tblStoreSubnet snet = new tblStoreSubnet();
                        snet.Store = Convert.ToInt32(sdr["StoreID"]);
                        snet.Subnet = Convert.ToInt32(sdr["SubnetID"]);
                        strdtl.Add(snet);
                    }
                }
            }
            if (strdtl.Count > 0)
            {
                foreach (var items in strdtl)
                {
                    using (SqlConnection con = new SqlConnection(CS))
                    {

                        con.Open();
                        string query = "";
                        query = " If not exists (select StoreSubnetID from tblStoreSubnet where Subnet =@Subnet and Store =@Store and DELFG = 0)";
                        query += " Begin ";
                        query += " Insert into tblStoreSubnet(Store,Subnet,DELFG,CRTDT,CRTCD,IPAddress) Values ";
                        query += " (@Store,@Subnet,0,@CRTDT,@CRTCD,@IPAddress) ";
                        query += " End ";
                        SqlCommand cmdApp1 = new SqlCommand(query, con);

                        cmdApp1.Parameters.AddWithValue("@Store", items.Store);
                        cmdApp1.Parameters.AddWithValue("@Subnet", items.Subnet);
                        cmdApp1.Parameters.AddWithValue("@CRTDT", DateTime.Now);
                        cmdApp1.Parameters.AddWithValue("@CRTCD", Session["UserName"].ToString());
                        cmdApp1.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());
                        cmdApp1.CommandType = CommandType.Text;

                        cmdApp1.ExecuteNonQuery();
                    }
                }
            }
        }
        public void DeleteInsertStore(string fileName)
        {
            List<tblStore> strdtl = new List<tblStore>();
            int result;
            string querySDtl = "Select StreamServerImportID,StoreName,StoreGroupName,StoreNumber,SG.StoreGroupID";
            querySDtl += " from [dbo].[tblStreamServerImport] SI ";
            querySDtl += " left join tblStoreGroup SG on SG.Name = SI.StoreGroupName and SG.DELFG = 0 ";
            querySDtl += " where FileName = @FileName ";
            querySDtl += "and RecStatus in ('I', 'W') Order by StreamServerImportID";
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(querySDtl, con);
                cmd.Parameters.AddWithValue("@FileName", fileName);

                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        tblStore snet = new tblStore();
                        snet.StoreID = Convert.ToInt32(sdr["StoreNumber"]);
                        snet.StoreNumber = Convert.ToInt32(sdr["StreamServerImportID"]);
                        snet.StoreName = Convert.ToString(sdr["StoreName"]);
                        if (sdr["StoreGroupID"].ToString() == "")
                        {
                            snet.StoreGroupID = null;
                        }
                        else
                        {
                            snet.StoreGroupID = Convert.ToInt32(sdr["StoreGroupID"]);
                            //cmdApp.Parameters.AddWithValue("@StoreGroupID", DBNull.Value);
                        }

                        strdtl.Add(snet);
                    }
                }
            }
            if (strdtl.Count > 0)
            {
                foreach (var items in strdtl)
                {
                   
                    using (SqlConnection con = new SqlConnection(CS))
                    {

                        con.Open();
                        string query = "";
                        query = " delete from tblStoreSubnet Where Store in ( ";

                        query += " select StoreID from tblStore where StoreID = @StoreID  ";
                        query += " union ";
                        query += " select StoreID from tblStore where StoreName = @StoreName )";

                        SqlCommand cmdApp = new SqlCommand(query, con);

                        cmdApp.Parameters.AddWithValue("@StoreID", items.StoreID);
                        cmdApp.Parameters.AddWithValue("@StoreName", items.StoreName);

                        cmdApp.CommandType = CommandType.Text;

                        result = cmdApp.ExecuteNonQuery();

                        

                        query = "";
                        query = " delete from tblStore  Where StoreID in ( ";
                        query += " select StoreID from tblStore where StoreID = @StoreID  ";
                        query += " union ";
                        query += " select StoreID from tblStore where StoreName = @StoreName )";


                        SqlCommand cmdApp1 = new SqlCommand(query, con);

                        cmdApp1.Parameters.AddWithValue("@StoreID", items.StoreID);
                        cmdApp1.Parameters.AddWithValue("@StoreName", items.StoreName);

                        cmdApp1.CommandType = CommandType.Text;

                        cmdApp1.ExecuteNonQuery();

                        query = "";

                        query = " Insert Into tblStore (StoreID, StoreName, StoreGroupID, ";
                        query += " DELFG,CRTDT,CRTCD,IPAddress) Values ";
                        query += " (@StoreID, @StoreName, @StoreGroupID ";
                        query += " ,0,@CRTDT,@CRTCD,@IPAddress) ";

                        SqlCommand cmds = new SqlCommand(query, con);


                        cmds.Parameters.AddWithValue("@StoreID", items.StoreID);
                        cmds.Parameters.AddWithValue("@StoreName", items.StoreName);

                        if (items.StoreGroupID.ToString() != "")
                        {
                            cmds.Parameters.AddWithValue("@StoreGroupID", items.StoreGroupID);
                        }
                        else
                        {
                            cmds.Parameters.AddWithValue("@StoreGroupID", DBNull.Value);
                        }
                        cmds.Parameters.AddWithValue("@CRTDT", DateTime.Now);
                        cmds.Parameters.AddWithValue("@CRTCD", Session["UserName"].ToString());
                        cmds.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());
 
                        cmds.CommandType = CommandType.Text;
                        cmds.ExecuteNonQuery();

                        
                    }

                }
            }

        }
        private void ValidateCSVRecords(DataTable csvdt)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                string query;
                query = "SELECT * from tblStreamServerimport where filename = '" + csvdt.Rows[0]["filename"].ToString() + "' ";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {



                    if (rdr["FolderName"].ToString().Trim() != "")

                    {
                        using (SqlConnection con2 = new SqlConnection(CS))
                        {
                            string query1;
                            query1 = "SELECT Name FROM tblFolder Where Name = N'" + rdr["FolderName"].ToString() + "'";
                            //query1 += "where exists (select FolderName from tblStreamServerImport SSI ";
                            //query1 += "where F.Name = SSI.FolderName and  SSI.FolderName = N'" + rdr["FolderName"].ToString() + "') ";
                            con2.Open();
                            SqlCommand cmd1 = new SqlCommand(query1, con2);
                            cmd1.CommandType = CommandType.Text;
                            SqlDataReader rdr1 = cmd1.ExecuteReader();
                            if (rdr1.HasRows == false)
                            {
                                sblist.Add("E");
                                sblist1.Add("Folder Name does not exist in Folder Managemant");
                                sblist2.Add("フォルダ管理にフォルダ名が存在しない");
                                if (sblist.Count != 0)
                                {
                                    Status = "E";
                                }
                                if (sblist1.Count != 0)
                                {
                                    Remarks = String.Join(",", sblist1.ToArray());
                                }
                                if (sblist2.Count != 0)
                                {
                                    Remarks_ja = String.Join(",", sblist2.ToArray());
                                }
                            }
                        }
                    }
                    if (rdr["StoreGroupName"].ToString().Trim() == "")

                    {
                        sblist.Add("W");
                        sblist1.Add("Corresponding Store Group not Available");
                        sblist2.Add("対応するストアグループは利用できません");
                        if (sblist.Count != 0)
                        {
                            if (Status != "E")
                            {
                                Status = String.Join(",", sblist.ToArray());
                            }
                            else
                            {

                                Status = "E";

                            }
                        }
                        if (sblist1.Count != 0)
                        {
                            Remarks = String.Join(",", sblist1.ToArray());
                        }
                        if (sblist2.Count != 0)
                        {
                            Remarks_ja = String.Join(",", sblist2.ToArray());
                        }
                    }

                    if (rdr["StoreNumber"].ToString().Trim() == "")
                    {
                        sblist.Add("E");
                        sblist1.Add("Store Number is Empty");
                        sblist2.Add("店舗番号が空です");
                        if (sblist.Count != 0)
                        {
                            Status = "E";
                        }
                        if (sblist1.Count != 0)
                        {
                            Remarks = String.Join(",", sblist1.ToArray());
                        }
                        if (sblist2.Count != 0)
                        {
                            Remarks_ja = String.Join(",", sblist2.ToArray());
                        }
                    }

                    if (rdr["StoreNumber"].ToString().Trim() != "")
                    {
                        int ignoreMe;
                        bool successfullyParsed = int.TryParse(rdr["StoreNumber"].ToString(), out ignoreMe);
                        if (!successfullyParsed)
                        {
                            sblist.Add("E");

                            sblist1.Add("Store Number is Invalid");
                            sblist2.Add("店舗番号が無効です");
                            if (sblist.Count != 0)
                            {
                                Status = "E";
                            }
                            if (sblist1.Count != 0)
                            {
                                Remarks = String.Join(",", sblist1.ToArray());
                            }
                        }
                        else
                        {
                            int MaxStorenum = Convert.ToInt32(rdr["StoreNumber"].ToString());

                            if (MaxStorenum < 1 || MaxStorenum > maxvalue)
                            {
                                sblist.Add("E");
                                sblist1.Add("Store number must be between 1 and 999999");
                                sblist2.Add("店舗番号は 1 から 999999 の間でなければなりません");
                                if (sblist.Count != 0)
                                {
                                    Status = "E";
                                }
                                if (sblist1.Count != 0)
                                {
                                    Remarks = String.Join(",", sblist1.ToArray());
                                }
                            }
                            else
                            {
                                if (rdr["StoreName"].ToString().Trim() == "")
                                {
                                    sblist.Add("E");
                                    sblist1.Add("Store Name is Empty");
                                    sblist2.Add("ストア名が空です。");
                                    if (sblist.Count != 0)
                                    {


                                        Status = "E";


                                    }
                                    if (sblist1.Count != 0)
                                    {
                                        Remarks = String.Join(",", sblist1.ToArray());
                                    }
                                    if (sblist2.Count != 0)
                                    {
                                        Remarks_ja = String.Join(",", sblist2.ToArray());
                                    }
                                }
                                else
                                {
                                }
                            }

                        }
                    }

                    if (rdr["SubnetNumber"].ToString().Trim() == "")
                    {
                        sblist.Add("E");
                        sblist1.Add("Subnet Number is Empty");
                        sblist2.Add("サブネット番号が空です");
                        if (sblist.Count != 0)
                        {
                            Status = "E";
                        }
                        if (sblist1.Count != 0)
                        {
                            Remarks = String.Join(",", sblist1.ToArray());
                        }
                        if (sblist2.Count != 0)
                        {
                            Remarks_ja = String.Join(",", sblist2.ToArray());
                        }
                    }
                    if (rdr["SubnetNumber"].ToString().Trim() != "")
                    {
                        int ignoreMe;
                        bool successfullyParsed = int.TryParse(rdr["SubnetNumber"].ToString(), out ignoreMe);
                        if (!successfullyParsed)
                        {
                            sblist.Add("E");
                            sblist1.Add(MujiStore.Resources.Resource.ValidateSubnetNumberInvalid);
                            if (sblist.Count != 0)
                            {
                                Status = "E";
                            }
                            if (sblist1.Count != 0)
                            {
                                Remarks = String.Join(",", sblist1.ToArray());
                            }
                        }
                        else
                        {
                            int MaxSubnetnum = Convert.ToInt32(rdr["SubnetNumber"].ToString());

                            if (MaxSubnetnum < 1 || MaxSubnetnum > maxvalue)
                            {
                                sblist.Add("E");
                                sblist1.Add("Subnet number must be between 1 and 999999");
                                sblist2.Add("サブネット番号は1から999999の間でなければなりません");
                                if (sblist.Count != 0)
                                {
                                    Status = "E";
                                }
                                if (sblist1.Count != 0)
                                {
                                    Remarks = String.Join(",", sblist1.ToArray());
                                }
                            }
                            else
                            {
                                if (rdr["BelongingSubnet"].ToString() == "")
                                {

                                    sblist.Add("E");
                                    sblist1.Add("Subnet IP Address is empty");
                                    sblist2.Add("サブネットIPアドレスが空です。");
                                    if (sblist.Count != 0)
                                    {

                                        Status = "E";


                                    }
                                    if (sblist1.Count != 0)
                                    {
                                        Remarks = String.Join(",", sblist1.ToArray());
                                    }
                                    if (sblist2.Count != 0)
                                    {
                                        Remarks_ja = String.Join(",", sblist2.ToArray());
                                    }
                                }
                                string BelongingSubnet = rdr["BelongingSubnet"].ToString();
                                if (rdr["BelongingSubnet"].ToString() != "")
                                {

                                    if (!ValidateIPv4(BelongingSubnet))
                                    {

                                        sblist.Add("E");
                                        sblist1.Add("Subnet IP Address is not valid");
                                        sblist2.Add("サブネットIPアドレスが無効です");
                                        if (sblist.Count != 0)
                                        {
                                            
                                            {
                                                Status = "E";

                                            }
                                        }
                                        if (sblist1.Count != 0)
                                        {
                                            Remarks = String.Join(",", sblist1.ToArray());
                                        }
                                        if (sblist2.Count != 0)
                                        {
                                            Remarks_ja = String.Join(",", sblist2.ToArray());
                                        }
                                    }
                                }

                            }
                        }
                    }


                    string ipaddress = rdr["IPAddress"].ToString();
                    if (rdr["IPAddress"].ToString() != "")
                    {
                        if (!ValidateIPv4(ipaddress))
                        {

                            sblist.Add("E");
                            sblist1.Add("Server IP Address is not valid");
                            sblist2.Add("サーバーのIPアドレスが無効です。");
                            if (sblist.Count != 0)
                            {
                                if (Status != "E")
                                {
                                    Status = String.Join(",", sblist.ToArray());
                                }
                                else
                                {
                                    Status = "E";

                                }
                            }
                            if (sblist1.Count != 0)
                            {
                                Remarks = String.Join(",", sblist1.ToArray());
                            }
                            if (sblist2.Count != 0)
                            {
                                Remarks_ja = String.Join(",", sblist2.ToArray());
                            }
                        }

                    }


                    using (SqlConnection con1 = new SqlConnection(CS))
                    {
                        if (sblist.Count != 0)
                        {
                            string UpdQuery = "";
                            UpdQuery = "Update tblStreamServerimport set RecStatus = N'" + Status + "',Remarks=N'" + Remarks + "',Remarks_ja=N'" + Remarks_ja + "' where StreamServerImportID = @id";

                            SqlCommand cmd1 = new SqlCommand(UpdQuery, con1);
                            cmd1.Parameters.AddWithValue("@id", rdr["StreamServerImportID"]);

                            cmd1.CommandType = CommandType.Text;

                            con1.Open();
                            cmd1.ExecuteNonQuery();
                            sblist.Clear();
                            sblist1.Clear();
                            Status = "";
                        }
                        else
                        {
                            string UpdQuery = "";
                            UpdQuery = "Update tblStreamServerimport set RecStatus = 'I' where StreamServerImportID = @id";

                            SqlCommand cmd1 = new SqlCommand(UpdQuery, con1);
                            cmd1.Parameters.AddWithValue("@id", rdr["StreamServerImportID"]);

                            cmd1.CommandType = CommandType.Text;

                            con1.Open();
                            cmd1.ExecuteNonQuery();
                            sblist.Clear();
                            sblist1.Clear();
                            Status = "";
                        }

                    }
                }
            }
        }

        

        public bool ValidateIPv4(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString))

            {
                return false;
            }

            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }

            return true;
        }
        public void updateStore(int storeid)
        {
            try
            {
                List<tblStore> StoreList = new List<tblStore>();
                string query1 = "SELECT * from tblstore where storeid = " + storeid + "";

                using (SqlConnection con2 = new SqlConnection(CS))
                {
                    using (SqlCommand cmd2 = new SqlCommand(query1))
                    {
                        cmd2.Connection = con2;
                        con2.Open();
                        
                        using (SqlDataReader sdr1 = cmd2.ExecuteReader())
                        {
                            while (sdr1.Read())
                            {
                                StoreList.Add(new tblStore
                                {
                                    
                                    StoreID = Convert.ToInt32(sdr1["StoreID"]),
                                    

                                });
                            }
                        }
                        con2.Close();
                    }
                }
                if (StoreList.Count >= 1)
                {
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        string query4 = "";
                        con.Open();
                        SqlCommand cmd;

                        tblUser tblUser = new tblUser();

                        //Assing Query String
                        query4 = "UPDATE tblStore SET DELFG = 1, UPDDT=@UPDDT," +
                        " UPDCD=@UPDCD, IPAddress=@IPAddress where storeID=@StoreID; ";


                        cmd = new SqlCommand(query4, con);
                        cmd.Parameters.AddWithValue("@StoreID", storeid);
                        cmd.Parameters.AddWithValue("@UPDDT", DateTime.Now);
                        cmd.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                        cmd.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());

                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();

                        query4 = "UPDATE tblStoreSubnet SET DELFG = 1, UPDDT=@UPDDT," +
                        " UPDCD=@UPDCD, IPAddress=@IPAddress where storeID=@StoreID; ";

                        cmd = new SqlCommand(query4, con);
                        cmd.Parameters.AddWithValue("@StoreID", storeid);
                        cmd.Parameters.AddWithValue("@UPDDT", DateTime.Now);
                        cmd.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                        cmd.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());

                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();

                        con.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        public void InsertFormatRecord(String Name, int RequiredBandWidth, int DELFG, String CRTCD, String IPAddress)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string query = "INSERT INTO tblFormat (Name, RequiredBandWidth, DELFG, CRTDT, CRTCD, IPAddress)";
                    query += " VALUES (@Name, @RequiredBandWidth, @DELFG, @CRTDT, @CRTCD, @IPAddress)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@RequiredBandWidth", RequiredBandWidth);
                    cmd.Parameters.AddWithValue("@DELFG", DELFG);
                    cmd.Parameters.AddWithValue("@CRTDT", DateTime.Now);
                    cmd.Parameters.AddWithValue("@CRTCD", CRTCD);
                    cmd.Parameters.AddWithValue("@IPAddress", IPAddress);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Not inserted due to error");
            }

        }


        public void updateFormatRecord(String Name)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string query = "Update tblFormat set DELFG = 0 where Name = @Name";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Not Updated due to error");
            }

        }




     

        int StreamServerID;
        string SSServer = "";
        string IPAddress = "192.168.43.51";
        int BelongingSubnet;
        int DeploySchedule;
        int status;
   
        int DriveCTotal;
        int DriveCFree;
        int DriveDTotal;
        int DriveDFree;
        int DELFG;
        DateTime CRTDT = System.DateTime.Now;
        String CRTCD;
        DateTime UPDDT = System.DateTime.Now;
        String UPDCD;
        string UserIPAddress = "192.168.43.51";

        public List<String> SubnetDeployRecordDetails()
        {
            var selectList = new List<String>();

            string query = "";

            using (SqlConnection con = new SqlConnection(CS))
            {
                query = "SELECT a.SSServer, a.IPAddress, b.SubnetID,b.SNIPAddress,c.DeployScheduleID, c.Name, a.DriveCTotal,a.DriveCFree,  a.DriveDFree, a.DriveDTotal from tblStreamServerImport a ";
                query += "INNER JOIN tblSubnet b";
                query += " ON a.BelongingSubnet = b.SNIPAddress";
                query += " INNER JOIN tblDeploySchedule c";
                query += " ON a.DeploySchedule = c.Name";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    InsertStreamServerRecord();
                }


           
                return selectList;
            }
        }



        public void InsertStreamServerRecord()
        {
            try
            {

                
                string SSServer = "Demo6";
                string IPAddress = "192.168.43.51";
                int BelongingSubnet = 10;
                int DeploySchedule = 6;
                int status = 0;
                int DriveCTotal = 0;
                int DriveCFree = 0;
                int DriveDTotal = 0;
                int DriveDFree = 0;
                int DELFG = 0;
                DateTime CRTDT = System.DateTime.Now;
                string CRTCD = "testadmin";

                string UserIPAddress = "192.168.43.51";


                using (SqlConnection con = new SqlConnection(CS))
                {
                    string query = "INSERT INTO tblStreamServer (SSServer, IPAddress, BelongingSubnet,DeploySchedule,status,DriveCTotal,DriveCFree,DriveDTotal,DriveDFree,DELFG, CRTDT, CRTCD, UserIPAddress)";
                    query += " VALUES ( @SSServer,@IPAddress, @BelongingSubnet, @DeploySchedule,@status,@DriveCTotal,@DriveCFree,@DriveDTotal,@DriveDFree,@DELFG, @CRTDT, @CRTCD, @UserIPAddress)";


                    SqlCommand cmd = new SqlCommand(query, con);
                     cmd.Parameters.AddWithValue("@SSServer", SSServer);
                    cmd.Parameters.AddWithValue("@IPAddress", IPAddress);
                    cmd.Parameters.AddWithValue("@BelongingSubnet", BelongingSubnet);
                    cmd.Parameters.AddWithValue("@DeploySchedule", DeploySchedule);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@DriveCTotal", DriveCTotal);
                    cmd.Parameters.AddWithValue("@DriveDTotal", DriveDTotal);
                    cmd.Parameters.AddWithValue("@DriveCFree", DriveCFree);
                    cmd.Parameters.AddWithValue("@DriveDFree", DriveDFree);
                    cmd.Parameters.AddWithValue("@DELFG", DELFG);
                    cmd.Parameters.AddWithValue("@CRTDT", CRTDT);
                    cmd.Parameters.AddWithValue("@CRTCD", CRTCD);
                    cmd.Parameters.AddWithValue("@UserIPAddress", UserIPAddress);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Not inserted due to error");
            }

        }





        string SSFServer = "Demo6";
        int FormatID = 8;
      

        public List<String> FormatRecordDetails()
        {
            var selectList = new List<String>();
            string query = "";

            using (SqlConnection con = new SqlConnection(CS))
            {
                query = "SELECT A.SSServer,A.IPAddress,B.FormatID from tblStreamServerImport A   ";
                query += "inner join tblFormat B";
                query += " ON A.FileType=B.Name and A.DELFG=B.DELFG";


                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                //DataTable tblcsv = (DataTable)Session["dtTest"];

                while (rdr.Read())
                {
                    InsertStreamServerFormatRecord(SSFServer, FormatID, DELFG, CRTDT, CRTCD, UPDDT, UPDCD, IPAddress);
                }

                return selectList;

            }
        }


        public void InsertStreamServerFormatRecord(string SSFServer, int FormatID, int DELFG, DateTime CRTDT, String CRTCD, DateTime UPDDT, String UPDCD, string IPAddress)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string query = "INSERT INTO tblStreamServerFormat ( SSFServer, FormatID,DELFG, CRTDT, CRTCD, UPDDT, UPDCD, IPAddress)";
                    query += " VALUES ( @SSFServer, @FormatID,@DELFG, @CRTDT, @CRTCD, @UPDDT, @UPDCD,@IPAddress)";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@SSFServer", SSFServer);
                    cmd.Parameters.AddWithValue("@FormatID", FormatID);
                    cmd.Parameters.AddWithValue("@DELFG", DELFG);
                    cmd.Parameters.AddWithValue("@CRTDT", CRTDT);
                    cmd.Parameters.AddWithValue("@CRTCD", CRTCD);
                    cmd.Parameters.AddWithValue("@UPDDT", UPDDT);
                    cmd.Parameters.AddWithValue("@UPDCD", UPDCD);
                    cmd.Parameters.AddWithValue("@IPAddress", IPAddress);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Not inserted due to error");
            }

        }





        public bool checkColheader(string header)
        {
            bool flag = false;
            int i = 0;
            foreach (string row in header.Split('\n'))
            {

                
                if (row.Split(',')[0].ToUpper() == "Subnet IP Address".ToUpper())
                {
                    i += 1;
                }
               
                if (row.Split(',')[1].ToUpper() == "StoreName".ToUpper())
                {
                    i += 1;
                }
                if (row.Split(',')[2].Replace("\n", "").Trim().ToUpper() == "StoreGroupName".ToUpper())
                {
                    i += 1;
                }
                if (row.Split(',')[3].Replace("\n", "").Trim().ToUpper() == "StoreNumber".ToUpper())
                {
                    i += 1;
                }
                if (row.Split(',')[4].Replace("\n", "").Trim().ToUpper() == "FolderName".ToUpper())
                {
                    i += 1;
                }
                if (row.Split(',')[5].Replace("\n", "").Trim().ToUpper() == "SubnetNumber".ToUpper())
                {
                    i += 1;
                }
            }
            if (i == 6)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        public ActionResult ExportCSV(DataTable CSV)
        {
            

            string Filename = ViewBag.filename;
            string csv = string.Empty;

            foreach (DataColumn column in CSV.Columns)
            {
                //Add the Header row for CSV file.
                csv += column.ColumnName + ',';
            }

            //Add new line.
            csv += "\r\n";

            foreach (DataRow row in CSV.Rows)
            {
                foreach (DataColumn column in CSV.Columns)
                {
                    //Add the Data rows.
                    csv += row[column.ColumnName].ToString().Replace(",", ";") + ',';
                }

                //Add new line.
                csv += "\r\n";
            }

            Response.Clear();
            Response.Buffer = true;
            Response.ContentEncoding = Encoding.UTF8;
            Response.AddHeader("content-disposition", "attachment;filename=" + Filename + ".csv");
            Response.Charset = "";
            Response.ContentType = "application/text";
            Response.Output.Write(csv, " charset = utf - 8");
            Response.Flush();
            Response.End();
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
