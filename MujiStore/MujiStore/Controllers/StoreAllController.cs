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
    public class StoreAllController : Controller
    {
        // GET: StoreAll
        private mujiEntities1 db = new mujiEntities1();
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        StringBuilder sb = new StringBuilder(" ");
        List<string> sblist = new List<string>();
        String Status;
        public ActionResult Search(string SearchID)
        {
            List<tblStore> StoreList = new List<tblStore>();
            string query = "SELECT TRY_CONVERT(int,S.storeID)[StoreNumber],S.[storeID], S.[storeName], G.[storegroupID] AS GroupName,g.name as groupname1 ,s.DELFG ";
            query = query + "FROM tblStore AS S   ";
            query = query + "LEFT JOIN tblStoreGroup AS G ON S.StoreGroupID = G.StoreGroupID   ";
            query = query + " WHERE (S.[StoreName] LIKE  @StoreName  or  S.[Storeid] LIKE  @StoreID )";
            query = query + "  and  s.delfg = 0 and TRY_CONVERT(int,S.StoreID) is not null Order by [storeID] ASC";

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
                            StoreList.Add(new tblStore
                            {

                                StoreID = Convert.ToInt32(sdr["StoreID"]),
                                StoreName = Convert.ToString(sdr["StoreName"]),
                                Country = Convert.ToString(sdr["groupname1"]),
                                Storegroupname = Convert.ToString(sdr["GroupName"]),
                                DELFG = Convert.ToBoolean(sdr["DELFG"])

                            });
                        }
                    }
                    con.Close();
                }
            }
            return Json(StoreList);
        }
        public ActionResult Index(string SearchID, string page1)
        {
            try
            {

                BindStoreGroup(0);
                ViewBag.SearchID = SearchID;

                var lan = Session["CreateSpecificCulture"];
                ViewBag.Language = lan;
                List<tblStore> StoreList = new List<tblStore>();
                List<tblStore> StoreListCount = new List<tblStore>();
                string query = "SELECT TRY_CONVERT(int,S.storeID)[StoreNumber],S.[storeID], S.[storeName], G.[storegroupID] AS GroupName,g.name as groupname1 ,s.DELFG ";
                query = query + "FROM tblStore AS S   ";
                query = query + "LEFT JOIN tblStoreGroup AS G ON S.StoreGroupID = G.StoreGroupID   ";

                if (SearchID != null && SearchID != "" && SearchID != string.Empty)
                {
                    query = query + " WHERE (S.[StoreName] LIKE  @StoreName  or  S.[Storeid] LIKE  @StoreID )";


                    query = query + "  and  s.delfg = 0 and TRY_CONVERT(int,S.StoreID) is not null Order by [storeID] ASC";

                    string query1 = "with cte as (SELECT TRY_CONVERT(int,S.storeID)[StoreNumber],S.[storeID], S.[storeName], G.[storegroupID] AS GroupName,g.name as groupname1 ,s.DELFG ";
                    query1 = query1 + "FROM tblStore AS S   ";
                    query1 = query1 + "LEFT JOIN tblStoreGroup AS G ON S.StoreGroupID = G.StoreGroupID   ";
                    query1 = query1 + " WHERE (S.[StoreName] LIKE  @StoreName  or  S.[Storeid] LIKE  @StoreID )";
                    query1 = query1 + "  and  s.delfg = 0 and TRY_CONVERT(int,S.StoreID) is not null)";
                    query1 = query1 + "select count(*)count1 from cte ";

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
                                    StoreList.Add(new tblStore
                                    {

                                        StoreID = Convert.ToInt32(sdr["StoreID"]),
                                        StoreName = Convert.ToString(sdr["StoreName"]),
                                        Country = Convert.ToString(sdr["groupname1"]),
                                        Storegroupname = Convert.ToString(sdr["GroupName"]),
                                        DELFG = Convert.ToBoolean(sdr["DELFG"])

                                    });
                                }
                            }
                            con.Close();
                        }
                        using (SqlCommand cmd = new SqlCommand(query1))
                        {
                            cmd.Connection = con;
                            con.Open();
                            cmd.Parameters.AddWithValue("@StoreName", "%" + SearchID + "%");
                            cmd.Parameters.AddWithValue("@StoreID", "%" + SearchID + "%");
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    StoreListCount.Add(new tblStore
                                    {

                                        StoreID = Convert.ToInt32(sdr["count1"]),



                                    });
                                }
                            }
                            con.Close();
                        }

                    }
                }
                else
                {
                    query = query + " where  s.delfg = 0 and TRY_CONVERT(int,S.storeID) is not null Order by [storeID] ASC";

                    string query1 = "with cte as (SELECT TRY_CONVERT(int,S.storeID)[StoreNumber],S.[storeID], S.[storeName], G.[storegroupID] AS GroupName,g.name as groupname1 ,s.DELFG ";
                    query1 = query1 + "FROM tblStore AS S   ";
                    query1 = query1 + "LEFT JOIN tblStoreGroup AS G ON S.StoreGroupID = G.StoreGroupID   ";

                    query1 = query1 + "  where  s.delfg = 0 and TRY_CONVERT(int,S.StoreID) is not null)";
                    query1 = query1 + "select count(*)count1 from cte ";


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

                                        StoreID = Convert.ToInt32(sdr["StoreID"]),
                                        StoreName = Convert.ToString(sdr["StoreName"]),
                                        Country = Convert.ToString(sdr["groupname1"]),
                                        Storegroupname = Convert.ToString(sdr["GroupName"]),
                                        DELFG = Convert.ToBoolean(sdr["DELFG"])

                                    });
                                }
                            }
                            con.Close();
                        }
                        using (SqlCommand cmd = new SqlCommand(query1))
                        {
                            cmd.Connection = con;
                            con.Open();

                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    StoreListCount.Add(new tblStore
                                    {

                                        StoreID = Convert.ToInt32(sdr["count1"]),



                                    });
                                }
                            }
                            con.Close();
                        }
                    }
                }
                ViewData["StoreInfo"] = StoreList;
                ViewData["StoreInfocount"] = StoreListCount;

                List<tblStore> tblVideoDemoStoreMst;
                List<tblStore> VidList = new List<tblStore>();
                if (TempData["StoreDtl"] != null)
                {
                    tblVideoDemoStoreMst = (List<tblStore>)TempData["StoreDtl"];
                }


                if (TempData["StoreDtl"] != null)
                {

                    VidList = (List<tblStore>)TempData["StoreDtl"];
                }
                else
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        VidList.Add(new tblStore
                        {

                        });
                    }
                }
                ViewData["SGList"] = VidList;

                if (page1 != null)
                {
                    TempData["SuccMsg"] = "入力欄が一杯です。";
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


        [HttpPost]

        public ActionResult create(List<tblStore> tblVideoDemoStoreMst)
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
                foreach (var bupload in tblVideoDemoStoreMst)
                {

                    if (bupload.StoreIDdummy != null && bupload.StoreName != null && bupload.StoreIDdummy > 0)
                    {
                        if (bupload.DELFG == false)
                        {
                            using (SqlConnection con = new SqlConnection(CS))
                            {
                                con.Open();
                                var selectList = new List<tblStore>();
                                string querySDtl = "";
                                querySDtl = "if exists (select StoreID from tblStore where StoreID =@StoreID  and DELFG = 0) ";
                                querySDtl += " begin ";
                                querySDtl += " select 0 Cnt,'U' Type ";

                                querySDtl += " end else begin ";
                                querySDtl += " select 0 Cnt,'I' Type ";

                                querySDtl += " end ";
                                SqlCommand cmd = new SqlCommand(querySDtl, con);
                                cmd.Parameters.AddWithValue("@StoreName", bupload.StoreName);
                                cmd.Parameters.AddWithValue("@StoreID", bupload.StoreIDdummy);


                                using (SqlDataReader sdr = cmd.ExecuteReader())
                                {
                                    while (sdr.Read())
                                    {

                                        selectList.Add(new tblStore
                                        {
                                            // MediaID,Title,Description,Video,ConvertStatus,FolderID
                                            StoreName = Convert.ToString(sdr["Type"]),
                                            StoreNumber = Convert.ToInt32(sdr["Cnt"]),


                                        });
                                    }
                                }

                                if (selectList[0].StoreNumber == 0)
                                {
                                    if (selectList[0].StoreName == "U")
                                    {
                                        bupload.UPDDT = DateTime.Now;
                                        bupload.UPDCD = Session["UserName"].ToString();
                                        bupload.IPAddress = Session["IPAddress"].ToString();



                                        string query = "";
                                        query = " update tblstore set StoreName=@StoreName, ";
                                        query += " DELFG=@DELFG,UPDDT=@UPDDT,UPDCD=@UPDCD, ";
                                        query += " IPAddress=@IPAddress,StoreGroupID=@StoreGroupID ";
                                        query += " Where storeid = @StoreID ";



                                        SqlCommand cmdApp = new SqlCommand(query, con);
                                        cmdApp.Parameters.AddWithValue("@StoreName", bupload.StoreName.Trim().ToString());
                                        cmdApp.Parameters.AddWithValue("@DELFG", bupload.DELFG);
                                        cmdApp.Parameters.AddWithValue("@UPDDT", bupload.UPDDT);
                                        cmdApp.Parameters.AddWithValue("@UPDCD", bupload.UPDCD);
                                        cmdApp.Parameters.AddWithValue("@IPAddress", bupload.IPAddress.Trim().ToString());
                                        if (bupload.StoreGroupID != 0)
                                        {
                                            cmdApp.Parameters.AddWithValue("@StoreGroupID", bupload.StoreGroupID);
                                        }
                                        else
                                        {
                                            cmdApp.Parameters.AddWithValue("@StoreGroupID", DBNull.Value);
                                        }
                                        cmdApp.Parameters.AddWithValue("@StoreID", bupload.StoreIDdummy);


                                        cmdApp.CommandType = CommandType.Text;

                                        result = cmdApp.ExecuteNonQuery();
                                        if (lan.ToString() == "en")
                                        {

                                            sb.Append(" store number ");
                                            sb.Append(bupload.StoreIDdummy);
                                            sb.Append(" has been updated.");
                                            sb.Append("br");
                                            SuccessMsg.Rows.Add("store number " + bupload.StoreIDdummy + " has been updated.");

                                        }
                                        else
                                        {
                                            sb.Append(" 店舗番号 ");
                                            sb.Append(bupload.StoreIDdummy);
                                            sb.Append(" を更新しました。");
                                            sb.Append("br");
                                            SuccessMsg.Rows.Add("店舗番号 " + bupload.StoreIDdummy + "を更新しました。");

                                        }

                                    }
                                    else
                                    {
                                        bupload.CRTDT = DateTime.Now;
                                        bupload.CRTCD = Session["UserName"].ToString();
                                        bupload.IPAddress = Session["IPAddress"].ToString();
                                        bupload.DELFG = false;

                                        string query = "";

                                        query = "Insert into  tblStore(StoreName ";
                                        query += " ,StoreGroupID,storeid,DELFG,CRTDT, ";
                                        query += " CRTCD,IPAddress ";

                                        query += ") Values  ";
                                        query += "(@StoreName,@StoreGroupID,@StoreID,0,@CRTDT,@CRTCD,@IPAddress)";


                                        cmd = new SqlCommand(query, con);
                                        cmd.Parameters.AddWithValue("@StoreName", bupload.StoreName);

                                        cmd.Parameters.AddWithValue("@StoreID", bupload.StoreIDdummy);
                                        if (bupload.StoreGroupID != 0)
                                        {
                                            cmd.Parameters.AddWithValue("@StoreGroupID", bupload.StoreGroupID);
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@StoreGroupID", DBNull.Value);
                                        }
                                        cmd.Parameters.AddWithValue("@CRTDT", DateTime.Now);
                                        cmd.Parameters.AddWithValue("@CRTCD", Session["UserName"].ToString());
                                        cmd.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());

                                        cmd.CommandType = CommandType.Text;
                                        result = cmd.ExecuteNonQuery();

                                        if (lan.ToString() == "en")
                                        {

                                            sb.Append("New store number ");
                                            sb.Append(bupload.StoreIDdummy);
                                            sb.Append(" has been created.");
                                            sb.Append("br");
                                            SuccessMsg.Rows.Add("New store number " + bupload.StoreIDdummy + "has been created.");
                                        }
                                        else
                                        {
                                            sb.Append("店舗番号 ");
                                            sb.Append(bupload.StoreIDdummy);
                                            sb.Append(" 店舗番号");
                                            sb.Append("br");
                                            SuccessMsg.Rows.Add("店舗番号 " + bupload.StoreIDdummy + "店舗番号");
                                        }

                                    }
                                }
                                else
                                {
                                    if (lan.ToString() == "en")
                                    {
                                        sb.Append("store name ");
                                        sb.Append(bupload.StoreName);
                                        sb.Append(" already Exist.");
                                        sb.Append("br");
                                        SuccessMsg.Rows.Add("store name " + bupload.StoreIDdummy + "already Exist.");
                                    }
                                    else
                                    {
                                        sb.Append("店舗名 ");
                                        sb.Append(bupload.StoreName);
                                        sb.Append(" すでに存在しています。");
                                        sb.Append("br");
                                        SuccessMsg.Rows.Add("店舗名 " + bupload.StoreIDdummy + "すでに存在しています。");
                                    }
                                }

                            }

                        }
                        else

                        {
                            DeleteID.Rows.Add(bupload.StoreIDdummy);
                            getmsgint += bupload.StoreIDdummy + ", ";


                            LogInfo.Comments = "Store Deleted - " + bupload.StoreIDdummy;
                            CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);

                        }


                    }
                    else
                    {


                        if (bupload.StoreIDdummy != null && bupload.StoreName == null)
                        {
                            if (lan.ToString() == "en")
                            {
                                sb.Append(" Row ");
                                sb.Append(row);
                                sb.Append(" - ");
                                sb.Append(" Enter  store name ");
                                sb.Append("br");
                                SuccessMsg.Rows.Add("Row " + row + " Enter  store name.");
                            }
                            else
                            {
                                sb.Append(" 行 ");
                                sb.Append(row);
                                sb.Append(" - ");
                                sb.Append(" 店舗名を入力してください ");
                                sb.Append("br");
                                SuccessMsg.Rows.Add("行 " + row + " 店舗名を入力してください。");
                            }
                        }
                        if ((bupload.StoreIDdummy == null || bupload.StoreIDdummy < 1) && bupload.StoreName != null)
                        {
                            if (lan.ToString() == "en")
                            {
                                sb.Append(" Row ");
                                sb.Append(row);
                                sb.Append(" - ");
                                sb.Append(" Enter Valid store number ");
                                sb.Append("br");
                                SuccessMsg.Rows.Add("Row " + row + " Enter Valid store number.");
                            }
                            else
                            {
                                sb.Append(" 行 ");
                                sb.Append(row);
                                sb.Append(" - ");
                                sb.Append(" 有効な店舗番号を入力してください ");
                                sb.Append("br");
                                SuccessMsg.Rows.Add("行 " + row + " 有効な店舗番号を入力してください。");
                            }
                        }

                    }
                    row = row + 1;
                }

                if (getmsgint != "")
                {
                    Session["DeleteID"] = DeleteID;
                    Session["Succsmsg"] = SuccessMsg;
                    if (lan.ToString() == "en")
                    {
                        TempData["Deletemsg"] = "Are You Want to Delete Store ID " + getmsgint;
                    }
                    else
                    {

                        TempData["Deletemsg"] = "店舗 " + getmsgint + "を削除してもよろしいですか?";
                    }
                    TempData["StoreDtl"] = tblVideoDemoStoreMst;
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

            return View();
        }
        public ActionResult DeleteStore()
        {
            var lan = Session["CreateSpecificCulture"];
            ViewBag.Language = lan;
            DataTable DeleteID = (DataTable)Session["DeleteID"];
            DataTable SuccessMsg = (DataTable)Session["Succsmsg"];
            ViewData["DeleteID"] = DeleteID;
            int result = 0;
            if (DeleteID.Rows.Count != 0)
            {

                for (int i = 0; i < DeleteID.Rows.Count; i++)
                {
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        con.Open();
                        string query = "";
                        query = " delete from tblStoreSubnet ";

                        query += " Where Store = @StoreID ";

                        SqlCommand cmdApp = new SqlCommand(query, con);

                        cmdApp.Parameters.AddWithValue("@StoreID", DeleteID.Rows[i]["ID"]);


                        cmdApp.CommandType = CommandType.Text;

                        result = cmdApp.ExecuteNonQuery();

                        query = "";
                        query = " delete from tblStore ";

                        query += " Where Storeid = @StoreID ";

                        SqlCommand cmdApp1 = new SqlCommand(query, con);

                        cmdApp1.Parameters.AddWithValue("@StoreID", DeleteID.Rows[i]["ID"]);


                        cmdApp1.CommandType = CommandType.Text;

                        cmdApp1.ExecuteNonQuery();


                    }
                    if (lan.ToString() == "en")
                    {

                        SuccessMsg.Rows.Add("store number " + DeleteID.Rows[i]["ID"] + " has been deleted.。");
                    }
                    else
                    {
                        SuccessMsg.Rows.Add("店舗番号 " + DeleteID.Rows[i]["ID"] + " 削除されました。");
                    }
                }
            }
            if (SuccessMsg.Rows.Count != 0)
            {
                TempData["deletesucmsg"] = "message";
                Session["DeleteID"] = SuccessMsg;
            }
            return Redirect("Index");
        }
        public int getstoreid(int storename)
        {
            tblStore tblstore = new tblStore();
            using (SqlConnection con = new SqlConnection(CS))
            {


                con.Open();

                string query = "";

                query = "select  StoreID from tblStore where StoreID=@storenumber";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@storenumber", storename);


                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    tblstore.StoreID = Convert.ToInt32(rdr["StoreID"]);

                }
            }

            return tblstore.StoreID;
        }









    }


    public static class HtmlExtensions
    {
        public static MvcHtmlString Nl2Br(this HtmlHelper htmlHelper, string text)
        {
            if (string.IsNullOrEmpty(text))
                return MvcHtmlString.Create(text);
            else
            {
                StringBuilder builder = new StringBuilder();
                string[] lines = text.Split('\n');
                for (int i = 0; i < lines.Length; i++)
                {
                    if (i > 0)
                        builder.Append("<br/>\n");
                    builder.Append(HttpUtility.HtmlEncode(lines[i]));
                }
                return MvcHtmlString.Create(builder.ToString());
            }
        }
    }


}





