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
using System.Text;

namespace MujiStore.Controllers
{
    [SessionExpire]
    [Authorize]
    [MUJICustomAuthorize(Roles = "16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31")]
    public class StoregroupAllController : Controller
    {
        // GET: Storegroup
        private mujiEntities1 db = new mujiEntities1();
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        StringBuilder sb = new StringBuilder(" ");
        List<string> sblist = new List<string>();
        String Status;


        public ActionResult Search(string SearchID)
        {
            List<tblStoreGroup> StoreList = new List<tblStoreGroup>();
            string query = "SELECT * from tblstoregroup ";


            if (SearchID != null && SearchID != "" && SearchID != string.Empty)
            {
                query = query + " WHERE ([name] LIKE  @StoreName  or  [Storegroupid] LIKE  @StoreID )";


                query = query + "  and  delfg=0  Order by [Storegroupid] ASC";

                using (SqlConnection con = new SqlConnection(CS))
                {

                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.Parameters.AddWithValue("@StoreName", "%" + SearchID + "%");
                        cmd.Parameters.AddWithValue("@StoreID", "%" + SearchID + "%");
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                StoreList.Add(new tblStoreGroup
                                {

                                    StoreGroupID = Convert.ToInt32(sdr["StoregroupID"]),

                                    Name = Convert.ToString(sdr["Name"]),


                                });
                            }
                        }
                        con.Close();
                    }
                }
            }
            else
            {
                query = query + " where  delfg = 0   Order by [storegroupID] ASC";
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
                                    StoreGroupID = Convert.ToInt32(sdr["StoregroupID"]),

                                    Name = Convert.ToString(sdr["Name"]),

                                });
                            }
                        }
                        con.Close();
                    }
                }
            }

            return Json(StoreList);
        }
        public ActionResult Index(string SearchID, string page1)
        {
            try
            {
                
                ViewBag.SearchID = SearchID;

                var lan = Session["CreateSpecificCulture"];
                ViewBag.Language = lan;
                List<tblStoreGroup> StoreList = new List<tblStoreGroup>();
                string query = "SELECT * from tblstoregroup ";
                

                if (SearchID != null && SearchID != "" && SearchID != string.Empty)
                {
                    query = query + " WHERE ([name] LIKE  @StoreName  or  [Storegroupid] LIKE  @StoreID )";


                    query = query + "  and  delfg=0  Order by [Storegroupid] ASC";

                    using (SqlConnection con = new SqlConnection(CS))
                    {

                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            con.Open();
                            cmd.Parameters.AddWithValue("@StoreName", "%" + SearchID + "%");
                            cmd.Parameters.AddWithValue("@StoreID", "%" + SearchID + "%");
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    StoreList.Add(new tblStoreGroup
                                    {

                                        StoreGroupID = Convert.ToInt32(sdr["StoregroupID"]),

                                        Name = Convert.ToString(sdr["Name"]),
                                       

                                    });
                                }
                            }
                            con.Close();
                        }
                    }
                }
                else
                {
                    query = query + " where  delfg = 0   Order by [storegroupID] ASC";
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
                                        StoreGroupID = Convert.ToInt32(sdr["StoregroupID"]),

                                        Name = Convert.ToString(sdr["Name"]),

                                    });
                                }
                            }
                            con.Close();
                        }
                    }
                }
                ViewData["StoreInfo"] = StoreList;
                List<tblStoreGroup> VidList = new List<tblStoreGroup>();
                if (TempData["StoreGrpDtl"] != null)
                {

                    VidList = (List<tblStoreGroup>)TempData["StoreGrpDtl"];
                }
                else
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        VidList.Add(new tblStoreGroup
                        {

                        });
                    }
                }
                
                

                return View(VidList);

            }

            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }

        [HttpPost]

        public ActionResult Create(List<tblStoreGroup> tblStrGrpDtl)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                int result = 0;
                int row = 1;
                string msg = "";
                var lan = Session["CreateSpecificCulture"];
                ViewBag.Language = lan;
                string getmsgint = "";
                Session["DeleteID"] = null;
                Session["Succsmsg"] = null;
                DataTable DeleteID = new DataTable();
                DataTable SuccessMsg = new DataTable();
                DeleteID.Columns.Add("ID");
                SuccessMsg.Columns.Add("msg");
                int checkID = 0;
                foreach (var bupload in tblStrGrpDtl)
                {
                    if(bupload.Name!=null)
                    {
                        break;
                    }
                    else
                    {
                        checkID += 1;
                    }
                }
                if(checkID==5)
                {
                    TempData["validatemsg"] = MujiStore.Resources.Resource.PleaseEnterTheStoreGroupName;
                    return Redirect("Index");
                }
                    foreach (var bupload in tblStrGrpDtl)
                {

                    if (bupload.StoreGroupIDdummy != null && bupload.Name != null)
                    {
                       
                        if (bupload.DELFG == false)
                        {
                            using (SqlConnection con = new SqlConnection(CS))
                            {
                                con.Open();
                                var selectList = new List<tblStoreGroup>();

                                selectList.Add(new tblStoreGroup
                                {
                                    StoreGroupID = 0,


                                });
                                string querySDtl = "";


                                if (selectList[0].StoreGroupID == 0)
                                {
                                    
                                        bupload.UPDDT = DateTime.Now;
                                        bupload.UPDCD = Session["UserName"].ToString();
                                        bupload.IPAddress = Session["IPAddress"].ToString();



                                        string query = "";
                                        query = " update tblstoregroup set Name=@StoreName, ";
                                        query += " DELFG=@DELFG,UPDDT=@UPDDT,UPDCD=@UPDCD, ";
                                        query += " IPAddress=@IPAddress ";
                                        query += " Where storegroupid = @StoreID ";



                                        SqlCommand cmdApp = new SqlCommand(query, con);
                                        cmdApp.Parameters.AddWithValue("@StoreName", bupload.Name.Trim().ToString());
                                        cmdApp.Parameters.AddWithValue("@DELFG", bupload.DELFG);
                                        cmdApp.Parameters.AddWithValue("@UPDDT", bupload.UPDDT);
                                        cmdApp.Parameters.AddWithValue("@UPDCD", bupload.UPDCD);
                                        cmdApp.Parameters.AddWithValue("@IPAddress", bupload.IPAddress.Trim().ToString());
                                        
                                        cmdApp.Parameters.AddWithValue("@StoreID", bupload.StoreGroupIDdummy);


                                        cmdApp.CommandType = CommandType.Text;

                                        result = cmdApp.ExecuteNonQuery();
                                        if (lan.ToString() == "en")
                                        {
                                            sb.Append(" storegroup ID ");
                                            sb.Append(bupload.StoreGroupIDdummy);
                                            sb.Append(" has been updated.");
                                            sb.Append("br");
                                        SuccessMsg.Rows.Add("storegroup ID " + bupload.StoreGroupIDdummy + " has been updated.");

                                        }
                                        else
                                        {
                                            sb.Append(" ストアグループID ");
                                            sb.Append(bupload.StoreGroupIDdummy);
                                            sb.Append(" を更新しました。");
                                            sb.Append("br");
                                        SuccessMsg.Rows.Add("ストアグループID " + bupload.StoreGroupIDdummy + " を更新しました。");
                                    }                                       
                                
                                }
                                else
                                {
                                    if (lan.ToString() == "en")
                                    {
                                        sb.Append("storegroup name ");
                                        sb.Append(bupload.Name);
                                        sb.Append(" already Exist.");
                                        sb.Append("br");
                                        SuccessMsg.Rows.Add("storegroup name " + bupload.StoreGroupIDdummy + " already Exist.");
                                    }
                                    else
                                    {
                                        sb.Append("ストアグループ名 ");
                                        sb.Append(bupload.Name);
                                        sb.Append(" すでに存在しています。");
                                        sb.Append("br");
                                        SuccessMsg.Rows.Add("ストアグループ名 " + bupload.StoreGroupIDdummy + " すでに存在しています。");
                                    }
                                    
                                }

                            }

                        }
                        else
                        {
                            DeleteID.Rows.Add(bupload.StoreGroupIDdummy);
                            getmsgint += bupload.StoreGroupIDdummy + ", ";
                        }
                        


                    }
                    else
                    {

                        
                        if (bupload.StoreGroupIDdummy == null && bupload.Name != null && bupload.DELFG == false)
                        {

                            using (SqlConnection con = new SqlConnection(CS))
                            {
                                con.Open();
                                List<tblStoreGroup> selectList = new List<tblStoreGroup>();

                                string querySDtl = "";
                                selectList.Add(new tblStoreGroup
                                {
                                    StoreGroupID = 0,


                                });

                                if (selectList[0].StoreGroupID == 0)
                                {
                                    bupload.CRTDT = DateTime.Now;
                                    bupload.CRTCD = Session["UserName"].ToString();
                                    bupload.IPAddress = Session["IPAddress"].ToString();
                                    bupload.DELFG = false;

                                    string query = "";

                                    query = "Insert into  tblStoregroup(Name, ";
                                    query += " DELFG,CRTDT, ";
                                    query += " CRTCD,IPAddress ";

                                    query += ") Values  ";
                                    query += "(@StoreName,0,@CRTDT,@CRTCD,@IPAddress)";

                                    SqlCommand cmd1 = new SqlCommand(query, con);


                                    cmd1 = new SqlCommand(query, con);
                                    cmd1.Parameters.AddWithValue("@StoreName", bupload.Name);


                                    cmd1.Parameters.AddWithValue("@CRTDT", DateTime.Now);
                                    cmd1.Parameters.AddWithValue("@CRTCD", Session["UserName"].ToString());
                                    cmd1.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());

                                    cmd1.CommandType = CommandType.Text;
                                    result = cmd1.ExecuteNonQuery();

                                    if (lan.ToString() == "en")
                                    {

                                        sb.Append("New storegroup ID ");
                                        sb.Append(bupload.StoreGroupIDdummy);
                                        sb.Append(" has been created.");
                                        sb.Append("br");
                                        SuccessMsg.Rows.Add("New storegroup ID " + bupload.StoreGroupIDdummy + " has been created.");

                                    }
                                    else
                                    {
                                        sb.Append("新しいストアグループID ");
                                        sb.Append(bupload.StoreGroupIDdummy);
                                        sb.Append(" を新規作成しました。");
                                        sb.Append("br");
                                        SuccessMsg.Rows.Add("新しいストアグループID " + bupload.StoreGroupIDdummy + " を新規作成しました。");

                                    }
                                }
                                else
                                {
                                    if (lan.ToString() == "en")
                                    {
                                        sb.Append("storegroup name ");
                                        sb.Append(bupload.Name);
                                        sb.Append(" already Exist.");
                                        sb.Append("br");
                                        SuccessMsg.Rows.Add("storegroup name " + bupload.StoreGroupIDdummy + " already Exist.");

                                    }
                                    else
                                    {
                                        sb.Append("ストアグループ名 ");
                                        sb.Append(bupload.Name);
                                        sb.Append(" すでに存在しています。");
                                        sb.Append("br");
                                        SuccessMsg.Rows.Add("ストアグループ名 " + bupload.StoreGroupIDdummy + " すでに存在しています。");

                                    }
                                }

                            }
                            if (bupload.StoreGroupIDdummy != null && bupload.Name == null)
                            {
                                if (lan.ToString() == "en")
                                {
                                    sb.Append(" Row ");
                                    sb.Append(row);
                                    sb.Append(" - ");
                                    sb.Append(" Enter  storegroup name ");
                                    sb.Append("br");
                                    SuccessMsg.Rows.Add("Row " + row + " - Enter  storegroup name");

                                }
                                else
                                {
                                    sb.Append(" 行 ");
                                    sb.Append(row);
                                    sb.Append(" - ");
                                    sb.Append(" ストアグループ名を入力してください ");
                                    sb.Append("br");
                                    SuccessMsg.Rows.Add("ストアグループ名 " + bupload.StoreGroupIDdummy + " すでに存在しています。");

                                }

                            }
                        }

                    }
                    row = row + 1;
                }
                
                
                if(getmsgint!="")
                {
                    Session["DeleteID"] = DeleteID;
                    Session["Succsmsg"] = SuccessMsg;
                    if (lan.ToString() == "en")
                    {
                        TempData["Deletemsg"] = "Are You Want to Delete Store Group ID " + getmsgint;
                    }
                    else
                    {
                         
                        TempData["Deletemsg"] = "店舗グループID " + getmsgint+ "を削除してもよろしいですか?";
                    }
                    TempData["StoreGrpDtl"] = tblStrGrpDtl;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["deletesucmsg"] = "message";
                    Session["Succsmsg"] = SuccessMsg;
                    return Redirect("index");
                }
               
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

        }
        public ActionResult result(string id)
        {
            ViewData["sb"] = TempData["Message"];

            return View("");
        }
        public ActionResult deletestoregroup(string id)
        {
            var lan = Session["CreateSpecificCulture"];
            ViewBag.Language = lan;
            DataTable DeleteID = (DataTable)Session["DeleteID"];
            DataTable Message = (DataTable)Session["Succsmsg"];
            ViewData["DeleteID"] = DeleteID;
            if (DeleteID.Rows.Count != 0)
            {
                
                for (int i = 0; i < DeleteID.Rows.Count; i++)
                {
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        con.Open();
                        string query = "";

                        query = " delete from tblStore ";

                        query += " Where Storegroupid = @StoreID ";

                        SqlCommand cmdApp2 = new SqlCommand(query, con);

                        cmdApp2.Parameters.AddWithValue("@StoreID", DeleteID.Rows[i]["ID"]);


                        cmdApp2.CommandType = CommandType.Text;

                        cmdApp2.ExecuteNonQuery();


                        query = "";

                        query = " delete from tblStoregroupfolder ";

                        query += " Where Storegroupid = @StoreID ";

                        SqlCommand cmdApp1 = new SqlCommand(query, con);

                        cmdApp1.Parameters.AddWithValue("@StoreID", DeleteID.Rows[i]["ID"]);


                        cmdApp1.CommandType = CommandType.Text;

                        cmdApp1.ExecuteNonQuery();

                        query = "";

                        query = " delete from tblStoregroup ";

                        query += " Where Storegroupid = @StoreID ";

                        SqlCommand cmdApp3 = new SqlCommand(query, con);

                        cmdApp3.Parameters.AddWithValue("@StoreID", DeleteID.Rows[i]["ID"]);


                        cmdApp3.CommandType = CommandType.Text;

                        cmdApp3.ExecuteNonQuery();

                    }
                    if (lan.ToString() == "en")
                    {
                   
                        Message.Rows.Add("storegroup ID " + DeleteID.Rows[i]["ID"] + " has been deleted.");
                    }
                    else
                    {
                      
                        Message.Rows.Add("ストアグループID " + DeleteID.Rows[i]["ID"] + " 削除されました。");
                    }


                    
                }

            }
            if(Message.Rows.Count!=0)
            {
                TempData["deletesucmsg"] = "message";
                Session["DeleteID"] = Message;
            }
            return RedirectToAction("Index");
        }
    }
}