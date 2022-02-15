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
using System.Globalization;
using System.Text.RegularExpressions;

namespace MujiStore.Controllers
{
    [SessionExpire]
    [Authorize]
    [MUJICustomAuthorize(Roles = "16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31")]
    public class SubnetAllController : Controller
    {
        // GET: SubnetAll
        private mujiEntities1 db = new mujiEntities1();
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        StringBuilder sb = new StringBuilder(" ");
        List<string> sblist = new List<string>();
        String Status;
        public ActionResult Search(string SearchID)
        {
            List<tblSubnet> SubnetList = new List<tblSubnet>();
            List<tblSubnet> SubnetListcount = new List<tblSubnet>();
            string query = "SELECT SubnetID,SNIPAddress,SubnetMask,WANBandWidth,  ";
            query = query + "cast(WANBandWidth as numeric(36,2)) ModWANBandWidth,  ";
            query = query + "LANBandWidth,cast(LANBandWidth as numeric(36,2)) ModLANBandWidth,DELFG  ";
            query = query + "FROM tblSubnet  ";
            query = query + " WHERE  (SNIPAddress like @SNIPAddress or Subnetid like @SubnetID)";
            query = query + " and delfg=0 Order by SubnetID ASC";
            using (SqlConnection con = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@SNIPAddress", "%" + SearchID + "%");
                    cmd.Parameters.AddWithValue("@SubnetID", "%" + SearchID + "%");
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            SubnetList.Add(new tblSubnet
                            {

                                SubnetID = Convert.ToInt32(sdr["SubnetID"]),

                                SNIPAddress = Convert.ToString(sdr["SNIPAddress"]),
                                SubnetMask = Convert.ToString(sdr["SubnetMask"]),
                                UpdWANBandWidth = Convert.ToString(sdr["WANBandWidth"]),
                                UpdLANBandWidth = Convert.ToString(sdr["LANBandWidth"]),
                                //LANBandWidth= double.Parse(sdr["LANBandWidth"].ToString(), CultureInfo.InvariantCulture),
                                ModWANBandWidth = Convert.ToString(sdr["ModWANBandWidth"]),
                                ModLANBandWidth = Convert.ToString(sdr["ModLANBandWidth"]),
                                DELFG = Convert.ToBoolean(sdr["DELFG"])

                            });
                        }
                    }
                    con.Close();
                }
            }
            return Json(SubnetList);
        }
        public ActionResult Index(string SearchID, string page1)
        {
            
            ViewBag.SearchID = SearchID;
            try
            {
                var lan = Session["CreateSpecificCulture"];
                ViewBag.Language = lan;
               
                List<tblSubnet> SubnetList = new List<tblSubnet>();
                List<tblSubnet> SubnetListcount = new List<tblSubnet>();
                string query = "SELECT SubnetID,SNIPAddress,SubnetMask,WANBandWidth,  ";
                query = query + "cast(WANBandWidth as numeric(36,2)) ModWANBandWidth,  ";
                query = query + "LANBandWidth,cast(LANBandWidth as numeric(36,2)) ModLANBandWidth,DELFG  ";
                query = query + "FROM tblSubnet  ";
                query = query + " WHERE  (SNIPAddress like @SNIPAddress or Subnetid like @SubnetID)";
                query = query + " and delfg=0 Order by SubnetID ASC";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            con.Open();
                            cmd.Parameters.AddWithValue("@SNIPAddress", "%" + SearchID + "%");
                            cmd.Parameters.AddWithValue("@SubnetID", "%" + SearchID + "%");
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    SubnetList.Add(new tblSubnet
                                    {

                                        SubnetID = Convert.ToInt32(sdr["SubnetID"]),

                                        SNIPAddress = Convert.ToString(sdr["SNIPAddress"]),
                                        SubnetMask = Convert.ToString(sdr["SubnetMask"]),
                                        UpdWANBandWidth = Convert.ToString(sdr["WANBandWidth"]),
                                        UpdLANBandWidth = Convert.ToString(sdr["LANBandWidth"]),
                                        //LANBandWidth= double.Parse(sdr["LANBandWidth"].ToString(), CultureInfo.InvariantCulture),
                                        ModWANBandWidth = Convert.ToString(sdr["ModWANBandWidth"]),
                                        ModLANBandWidth = Convert.ToString(sdr["ModLANBandWidth"]),
                                        DELFG = Convert.ToBoolean(sdr["DELFG"])

                                    });
                                }
                            }
                            con.Close();
                        }
                    }

                //if (SearchID != null && SearchID != "" && SearchID != string.Empty)
                //{

                //    query = query + " WHERE  (SNIPAddress like @SNIPAddress or Subnetid like @SubnetID)";


                //    query = query + " and delfg=0 Order by SubnetID ASC";

                //    //string query1 = "with cte as (SELECT * FROM tblSubnet WHERE  (SNIPAddress like @SNIPAddress or Subnetid like @SubnetID) and delfg=0) select count(*)count1 from cte  ";

                //    using (SqlConnection con = new SqlConnection(CS))
                //    {

                //        using (SqlCommand cmd = new SqlCommand(query))
                //        {
                //            cmd.Connection = con;
                //            con.Open();
                //            cmd.Parameters.AddWithValue("@SNIPAddress", "%" + SearchID + "%");
                //            cmd.Parameters.AddWithValue("@SubnetID", "%" + SearchID + "%");
                //            using (SqlDataReader sdr = cmd.ExecuteReader())
                //            {
                //                while (sdr.Read())
                //                {
                //                    SubnetList.Add(new tblSubnet
                //                    {

                //                        SubnetID = Convert.ToInt32(sdr["SubnetID"]),

                //                        SNIPAddress = Convert.ToString(sdr["SNIPAddress"]),
                //                        SubnetMask = Convert.ToString(sdr["SubnetMask"]),
                //                        WANBandWidth = Convert.ToDouble(sdr["WANBandWidth"]),
                //                        LANBandWidth = Convert.ToDouble(sdr["LANBandWidth"]),
                //                        ModWANBandWidth = Convert.ToString(sdr["ModWANBandWidth"]),
                //                        ModLANBandWidth = Convert.ToString(sdr["ModLANBandWidth"]),
                //                        DELFG = Convert.ToBoolean(sdr["DELFG"])

                //                    });
                //                }
                //            }
                //            con.Close();
                //        }
                        

                //        //using (SqlCommand cmd = new SqlCommand(query1))
                //        //{
                //        //    cmd.Connection = con;
                //        //    con.Open();
                //        //    cmd.Parameters.AddWithValue("@SNIPAddress", "%" + SearchID + "%");
                //        //    cmd.Parameters.AddWithValue("@SubnetID", "%" + SearchID + "%");
                //        //    using (SqlDataReader sdr = cmd.ExecuteReader())
                //        //    {
                //        //        while (sdr.Read())
                //        //        {
                //        //            SubnetListcount.Add(new tblSubnet
                //        //            {

                //        //                SubnetID = Convert.ToInt32(sdr["count1"]),

                                        

                //        //            });
                //        //        }
                //        //    }
                //        //    con.Close();
                //        //}
                //    }
                //}
                //else
                //{
                //    query = query + " where  delfg=0 Order by SubnetID ASC";
                //    //string query1 = "with cte as (SELECT * FROM tblSubnet WHERE  delfg=0) select count(*)count1 from cte  ";

                //    using (SqlConnection con = new SqlConnection(CS))
                //    {
                //        using (SqlCommand cmd = new SqlCommand(query))
                //        {
                //            cmd.Connection = con;
                //            con.Open();
                //            using (SqlDataReader sdr = cmd.ExecuteReader())
                //            {
                //                while (sdr.Read())
                //                {

                //                    SubnetList.Add(new tblSubnet
                //                    {

                //                        SubnetID = Convert.ToInt32(sdr["SubnetID"]),

                //                        SNIPAddress = Convert.ToString(sdr["SNIPAddress"]),
                //                        SubnetMask = Convert.ToString(sdr["SubnetMask"]),
                //                        WANBandWidth = Convert.ToDouble(sdr["WANBandWidth"]),
                //                        LANBandWidth = Convert.ToDouble(sdr["LANBandWidth"]),
                //                        ModWANBandWidth = Convert.ToString(sdr["ModWANBandWidth"]),
                //                        ModLANBandWidth = Convert.ToString(sdr["ModLANBandWidth"]),
                //                        DELFG = Convert.ToBoolean(sdr["DELFG"])

                //                    });
                //                }
                //            }
                //            con.Close();
                //        }

                //        //using (SqlCommand cmd = new SqlCommand(query1))
                //        //{
                //        //    cmd.Connection = con;
                //        //    con.Open();
                            
                //        //    using (SqlDataReader sdr = cmd.ExecuteReader())
                //        //    {
                //        //        while (sdr.Read())
                //        //        {
                //        //            SubnetListcount.Add(new tblSubnet
                //        //            {

                //        //                SubnetID = Convert.ToInt32(sdr["count1"]),



                //        //            });
                //        //        }
                //        //    }
                //        //    con.Close();
                //        //}
                //    }
                //}
                ViewData["StoreInfo"] = SubnetList;

                //SubnetListcount.Add(new tblSubnet
                //{

                //    SubnetID = Convert.ToInt32(SubnetList.Count),



                //});

                ViewData["StoreInfocount"] = SubnetList.Count;
                List<tblSubnet> VidList = new List<tblSubnet>();
                if (TempData["SubnetDtl"] != null)
                {

                    VidList = (List<tblSubnet>)TempData["SubnetDtl"];
                }
                else
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        VidList.Add(new tblSubnet
                        {

                            SubnetMask = "255.255.255.0",
                            UpdWANBandWidth = "250000",
                            UpdLANBandWidth = "10000000"

                        });
                    }
                }
                
                if (page1 != null)
                {
                    TempData["SuccMsg"] = "入力欄が一杯です。";
                }

                return View(VidList);
            }

            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("subnet : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }



        }
        
        [HttpPost]

        public ActionResult create(List<tblSubnet> tblSubnetMstDtl)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                int result = 0;
                int row = 1;
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
                
                foreach (var bupload in tblSubnetMstDtl)
                {

                    //bupload.SubnetMask = "255.255.255.0";
                    //bupload.LANBandWidth = 10000000;
                    bool isValidWan = false;
                    bool isValidWanRange = false;
                    bool isValidLan = false;
                    bool isValidLanRange = false;

                    Double numericValue;
                    Double stringValue;

                    isValidWan = Double.TryParse(bupload.UpdWANBandWidth, out numericValue);
                    if(isValidWan == true)
                    {
                        stringValue = Convert.ToDouble(bupload.UpdWANBandWidth);
                        if (stringValue >= 1 && stringValue <= 50000000)
                        {
                            isValidWanRange = true;
                        }
                    }

                    isValidLan = Double.TryParse(bupload.UpdLANBandWidth, out numericValue);
                    if (isValidLan == true)
                    {
                        stringValue = Convert.ToDouble(bupload.UpdLANBandWidth);
                        if (stringValue >= 1 && stringValue <= 50000000)
                        {
                            isValidLanRange = true;
                        }
                    }

                    if (
                        (bupload.SubnetIDdummy != null && bupload.SubnetIDdummy > 0 ) 
                        && bupload.SNIPAddress != null && ValidateIPv4(bupload.SNIPAddress)
                        && bupload.SubnetMask != null && ValidateIPv4(bupload.SubnetMask)
                        && (isValidWan == true && isValidWanRange == true)
                        && (isValidLan == true && isValidLanRange == true)
                        )
                    {
                      

                        if (bupload.DELFG == false)
                        {
                            using (SqlConnection con = new SqlConnection(CS))
                            {
                                con.Open();
                                var selectList = new List<tblSubnet>();
                                string querySDtl = "";

                                querySDtl = "if exists (select SubnetID from tblsubnet where SubnetID =@SubnetID  and DELFG = 0) ";
                                querySDtl += " begin ";
                                querySDtl += " select 0 Cnt,'U' Type ";

                                querySDtl += " end else begin ";
                                querySDtl += " select 0 Cnt,'I' Type ";

                                querySDtl += " end";
                                SqlCommand cmd = new SqlCommand(querySDtl, con);
                                cmd.Parameters.AddWithValue("@SubnetID", bupload.SubnetIDdummy);
                                cmd.Parameters.AddWithValue("@SubnetIPaddress", bupload.SNIPAddress);


                                using (SqlDataReader sdr = cmd.ExecuteReader())
                                {
                                    while (sdr.Read())
                                    {

                                        selectList.Add(new tblSubnet
                                        {

                                            SNIPAddress = Convert.ToString(sdr["Type"]),
                                            SubnetNumber = Convert.ToInt32(sdr["Cnt"]),


                                        });
                                    }
                                }

                                if (selectList[0].SubnetNumber == 0)
                                {
                                    if (selectList[0].SNIPAddress == "U")
                                    {
                                        bupload.UPDDT = DateTime.Now;
                                        bupload.UPDCD = Session["UserName"].ToString();
                                        bupload.IPAddress = Session["IPAddress"].ToString();



                                        string query = "";
                                        query = " update tblSubnet set SNIPAddress=@SNIPAddress,SubnetMask=@SubnetMask, ";
                                        query += " WANBandWidth=@WANBandWidth,LANBandWidth=@LANBandWidth, ";
                                        query += " DELFG=@DELFG,UPDDT=@UPDDT,UPDCD=@UPDCD, ";
                                        query += " IPAddress=@IPAddress ";
                                        query += " Where SubnetID = @SubnetID ";

                                        SqlCommand cmdApp = new SqlCommand(query, con);
                                        cmdApp.Parameters.AddWithValue("@SNIPAddress", bupload.SNIPAddress.Trim().ToString());
                                        cmdApp.Parameters.AddWithValue("@SubnetMask", bupload.SubnetMask.Trim());
                                        
                                        cmdApp.Parameters.AddWithValue("@LANBandWidth", bupload.UpdLANBandWidth);
                                        cmdApp.Parameters.AddWithValue("@WANBandWidth", bupload.UpdWANBandWidth);
                                        cmdApp.Parameters.AddWithValue("@SubnetID", bupload.SubnetIDdummy);
                                        cmdApp.Parameters.AddWithValue("@DELFG", bupload.DELFG);
                                        cmdApp.Parameters.AddWithValue("@UPDDT", bupload.UPDDT);
                                        cmdApp.Parameters.AddWithValue("@UPDCD", bupload.UPDCD);
                                        cmdApp.Parameters.AddWithValue("@IPAddress", bupload.IPAddress.Trim().ToString());


                                        cmdApp.CommandType = CommandType.Text;

                                        result = cmdApp.ExecuteNonQuery();
                                        if (lan.ToString() == "en")
                                        {
                                            sb.Append("Updated subnet  ");
                                            sb.Append(bupload.SubnetIDdummy);
                                            sb.Append("br");
                                            SuccessMsg.Rows.Add("Updated subnet " + bupload.SubnetIDdummy + ".");

                                        }
                                        else
                                        {
                                            sb.Append("サブネットID ");
                                            sb.Append(bupload.SubnetIDdummy);
                                            sb.Append("を更新しました");
                                            sb.Append("br");
                                            SuccessMsg.Rows.Add("サブネットID " + bupload.SubnetIDdummy + " を更新しました");

                                        }
                                    }
                                    else
                                    {
                                        bupload.CRTDT = DateTime.Now;
                                        bupload.CRTCD = Session["UserName"].ToString();
                                        bupload.IPAddress = Session["IPAddress"].ToString();
                                        bupload.DELFG = false;

                                        string query = "";

                                        query = " Insert Into tblsubnet (SubnetID, SNIPAddress, SubnetMask,WANBandwidth, ";
                                        query += " LANBandwidth,DELFG,CRTDT,CRTCD,IPAddress) Values ";
                                        query += " (@SubnetID, @SNIPAddres, @SubnetMask,@WANBandWidth ";
                                        query += " ,@LANBandwidth,0,@CRTDT,@CRTCD,@IPAddress) ";

                                        SqlCommand cmds = new SqlCommand(query, con);


                                        cmds.Parameters.AddWithValue("@SubnetID", bupload.SubnetIDdummy);
                                        cmds.Parameters.AddWithValue("@SNIPAddres", bupload.SNIPAddress);
                                        cmds.Parameters.AddWithValue("@SubnetMask", bupload.SubnetMask);
                                        cmds.Parameters.AddWithValue("@LANBandWidth", bupload.UpdLANBandWidth);
                                        cmds.Parameters.AddWithValue("@WANBandWidth", bupload.UpdWANBandWidth);
//                                        cmds.Parameters.AddWithValue("@WANBandWidth", bupload.WANBandWidth);
//                                        cmds.Parameters.AddWithValue("@LANBandwidth", bupload.LANBandWidth);
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

                                        cmds1.Parameters.AddWithValue("@SubnetID", bupload.SubnetIDdummy);

                                        cmds1.Parameters.AddWithValue("@SNIPAddres", bupload.SNIPAddress);
                                        cmds1.Parameters.AddWithValue("@SubnetMask", bupload.SubnetMask);

                                        //cmds1.Parameters.AddWithValue("@LANBandwidth", bupload.LANBandWidth);
                                        cmds1.Parameters.AddWithValue("@CRTDT", DateTime.Now);
                                        cmds1.Parameters.AddWithValue("@CRTCD", Session["UserName"].ToString());
                                        cmds1.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());
                                        cmds1.Parameters.AddWithValue("@streamserver", streamserver);
                                        cmds1.Parameters.AddWithValue("@StreamIpaddress", StreamIpaddress);

                                        cmds1.CommandType = CommandType.Text;

                                        cmds1.CommandType = CommandType.Text;
                                        cmds1.ExecuteNonQuery();

                                        query = "";


                                        if (lan.ToString() == "en")
                                        {
                                            sb.Append("You have created a new subnet  ");
                                            sb.Append(bupload.SubnetIDdummy);
                                            sb.Append("br");
                                            SuccessMsg.Rows.Add("You have created a new subnet " + bupload.SubnetIDdummy + ".");
                                        }
                                        else
                                        {
                                            sb.Append("サブネットID  ");
                                            sb.Append(bupload.SubnetIDdummy);
                                            sb.Append("を新規作成しました。");
                                            sb.Append("br");
                                            SuccessMsg.Rows.Add("サブネットID " + bupload.SubnetIDdummy + " を新規作成しました。");
                                        }


                                    }
                                }
                                else
                                {
                                    if (lan.ToString() == "en")
                                    {
                                        sb.Append("Subnet IPAddress ");
                                        sb.Append(bupload.SNIPAddress);
                                        sb.Append(" already Exist.");
                                        sb.Append("br");
                                        SuccessMsg.Rows.Add("Subnet IPAddress " + bupload.SNIPAddress + " already Exist.");
                                    }
                                    else
                                    {
                                        sb.Append("サブネットIPアドレス ");
                                        sb.Append(bupload.SNIPAddress);
                                        sb.Append(" すでに存在しています。");
                                        sb.Append("br");
                                        SuccessMsg.Rows.Add("サブネットIPアドレス " + bupload.SNIPAddress + " すでに存在しています。");
                                    }
                                }

                            }

                        }
                        else
                        {
                            DeleteID.Rows.Add(bupload.SubnetIDdummy);
                            getmsgint += bupload.SubnetIDdummy + ", ";


 

                        }


                    }
                    else
                    {


                        if (bupload.SubnetIDdummy != null && bupload.SNIPAddress == null)
                        {
                            //chkflag = true;
                            if (lan.ToString() == "en")
                            {
                                sb.Append(" Row ");
                                sb.Append(row);
                                sb.Append(" - ");
                                sb.Append(" Enter  subnet IPAddress ");
                                sb.Append("br");
                                SuccessMsg.Rows.Add("Row " + row + " - Enter  subnet IPAddress");
                            }
                            else
                            {
                                sb.Append(" 行 ");
                                sb.Append(row);
                                sb.Append(" - ");
                                sb.Append(" サブネットIPアドレスを入力してください ");
                                sb.Append("br");
                                SuccessMsg.Rows.Add("行 " + row + " - サブネットIPアドレスを入力してください");
                            }
                        }
                        if (!ValidateIPv4(bupload.SNIPAddress) && bupload.SNIPAddress != null)
                        {
                            //chkflag = true;
                            if (lan.ToString() == "en")
                            {
                                sb.Append(" Row ");
                                sb.Append(row);
                                sb.Append(" - ");
                                sb.Append(" Enter Valid subnet IPAddress ");
                                sb.Append("br");
                                SuccessMsg.Rows.Add("Row " + row + " - Enter Valid subnet IPAddress");
                            }
                            else
                            {
                                sb.Append(" 行 ");
                                sb.Append(row);
                                sb.Append(" - ");
                                sb.Append(" 有効なサブネットIPアドレスを入力してください ");
                                sb.Append("br");
                                SuccessMsg.Rows.Add("行 " + row + " - 有効なサブネットIPアドレスを入力してください");
                            }
                        }
                        if ((bupload.SubnetIDdummy == null || bupload.SubnetIDdummy < 1 )  && bupload.SNIPAddress != null)
                        {
                            //chkflag = true;
                            if (lan.ToString() == "en")
                            {
                                sb.Append(" Row ");
                                sb.Append(row);
                                sb.Append(" - ");
                                sb.Append(" Enter Valid Subnet number  ");
                                sb.Append("br");
                                SuccessMsg.Rows.Add("Row " + row + " - Enter Valid Subnet number");
                            }
                            else
                            {
                                sb.Append(" 行 ");
                                sb.Append(row);
                                sb.Append(" - ");
                                sb.Append(" 有効なサブネット番号を入力してください ");
                                sb.Append("br");
                                SuccessMsg.Rows.Add("行 " + row + " - 有効なサブネット番号を入力してください");
                            }
                        }
                        if(bupload.SubnetIDdummy != null || bupload.SNIPAddress != null)
                        {
                            if((bupload.SubnetMask == null) || (bupload.SubnetMask.Trim() == null) || (!ValidateIPv4(bupload.SubnetMask)))
                            {
                                if (lan.ToString() == "en")
                                {
                                    sb.Append(" Row ");
                                    sb.Append(row);
                                    sb.Append(" - ");
                                    sb.Append(" Enter Valid Subnet Mask  ");
                                    sb.Append("br");
                                    SuccessMsg.Rows.Add("Row " + row + " - Enter Valid Subnet Mask");
                                }
                                else
                                {
                                    sb.Append(" 行 ");
                                    sb.Append(row);
                                    sb.Append(" - ");
                                    sb.Append(" 有効なサブネットマスクを入力してください ");
                                    sb.Append("br");
                                    SuccessMsg.Rows.Add("行 " + row + " - 有効なサブネットマスクを入力してください");
                                }
                            }
                            //isValidWan == true && isValidWanRange == true
                            if ((isValidLan == false) || (isValidLanRange == false) )
                            {
                                if (lan.ToString() == "en")
                                {
                                    sb.Append(" Row ");
                                    sb.Append(row);
                                    sb.Append(" - ");
                                    sb.Append(" Enter Valid Lanband Width ");
                                    sb.Append("br");
                                    SuccessMsg.Rows.Add("Row " + row + " - Enter Valid Lanband Width ");
                                }
                                else
                                {
                                    sb.Append(" 行 ");
                                    sb.Append(row);
                                    sb.Append(" - ");
                                    sb.Append(" 有効な	LAN帯域幅を入力してください ");
                                    sb.Append("br");
                                    SuccessMsg.Rows.Add("行 " + row + " - 有効な	LAN帯域幅を入力してください ");
                                }
                            }

                            if ((isValidWan == false) || (isValidWanRange == false))
                            {
                                if (lan.ToString() == "en")
                                {
                                    sb.Append(" Row ");
                                    sb.Append(row);
                                    sb.Append(" - ");
                                    sb.Append(" Enter Valid Wanband Width ");
                                    sb.Append("br");
                                    SuccessMsg.Rows.Add("Row " + row + " - Enter Valid Wanband Width ");
                                }
                                else
                                {
                                    sb.Append(" 行 ");
                                    sb.Append(row);
                                    sb.Append(" - ");
                                    sb.Append(" 有効な	WAN帯域幅を入力してください ");
                                    sb.Append("br");
                                    SuccessMsg.Rows.Add("行 " + row + " - 有効な	WAN帯域幅を入力してください ");
                                }
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
                        TempData["Deletemsg"] = "Are You Want to Delete Subnet " + getmsgint;
                    }
                    else
                    {
                        
                        TempData["Deletemsg"] = "サブネット " + getmsgint+ "を削除してもよろしいですか?";
                    }
                       
                    TempData["SubnetDtl"] = tblSubnetMstDtl;
                    return RedirectToAction("Index" );
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
                LogInfo.LogMsg = string.Format("subnet : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }
        
        
        
        public bool ValidateIPv4(string ipString)
        {
            string Pattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";

            Regex check = new Regex(Pattern);

            //check to make sure an ip address was provided    
            if (string.IsNullOrEmpty(ipString))
                //returns false if IP is not provided    
                return false;
            else
                //Matching the pattern    
                return check.IsMatch(ipString, 0);
            //if (String.IsNullOrWhiteSpace(ipString))

            //{
            //    return false;
            //}

            //string[] splitValues = ipString.Split('.');
            //if (splitValues.Length != 4)
            //{
            //    return false;
            //}

            //return true;
        }

        public ActionResult result(string id)
        {
            ViewData["sb"] = TempData["Message"];

            return View();
        }
        public ActionResult DeleteSubnet()
        {
            var lan = Session["CreateSpecificCulture"];
            ViewBag.Language = lan;
            DataTable DeleteID = (DataTable)Session["DeleteID"];
            DataTable SuccessMsg = (DataTable)Session["Succsmsg"];
            ViewData["DeleteID"] = DeleteID;
            int result;
            if (DeleteID.Rows.Count != 0)
            {

                for (int i = 0; i < DeleteID.Rows.Count; i++)
                {
                    using (SqlConnection con = new SqlConnection(CS))
                    {

                        con.Open();
                        string query = "";
                        query = " delete from tblStoreSubnet ";

                        query += " Where subnet = @subnetid ";

                        SqlCommand cmdApp = new SqlCommand(query, con);

                        cmdApp.Parameters.AddWithValue("@subnetid", DeleteID.Rows[i]["ID"]);


                        cmdApp.CommandType = CommandType.Text;

                        result = cmdApp.ExecuteNonQuery();

                        

                        query = "";
                        query = " delete from tblStreamServer ";

                        query += " Where belongingsubnet = @subnetid ";

                        SqlCommand cmdApp3 = new SqlCommand(query, con);

                        cmdApp3.Parameters.AddWithValue("@subnetid", DeleteID.Rows[i]["ID"]);


                        cmdApp3.CommandType = CommandType.Text;

                        result = cmdApp3.ExecuteNonQuery();

                        query = "";
                        query = " delete from tblSubnet ";

                        query += " Where subnetid = @subnetid ";

                        SqlCommand cmdApp1 = new SqlCommand(query, con);

                        cmdApp1.Parameters.AddWithValue("@subnetid", DeleteID.Rows[i]["ID"]);


                        cmdApp1.CommandType = CommandType.Text;

                        cmdApp1.ExecuteNonQuery();


                    }
                    if (lan.ToString() == "en")
                    {
                       
                        SuccessMsg.Rows.Add("subnet " + DeleteID.Rows[i]["ID"] + " has been deleted.");
                    }
                    else
                    {
                        SuccessMsg.Rows.Add("サブネット " + DeleteID.Rows[i]["ID"] + " 削除されました。");
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

    }
}