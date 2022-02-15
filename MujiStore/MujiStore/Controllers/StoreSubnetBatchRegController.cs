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
    public class StoreSubnetBatchRegController : Controller
    {
        private mujiEntities1 db = new mujiEntities1();
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        
        public ActionResult Create()
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                BindStoreGroup(0);
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
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StoreID,StoreNumber,StoreName,StoreGroupID,SubnetID,SNIPAddress,SubnetMask,WANBandWidth, LANBandWidth,DELFG,CRTDT,CRTCD,UPDDT,UPDCD,IPAddress")] tblStoreSubnetReg tblVideoDemoStoreMst)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;
            try
            {
                
                BindStoreGroup(tblVideoDemoStoreMst.StoreGroupID);

                ModelState.Remove("WANBandWidth");
                ModelState.Remove("LANBandWidth");
                if (ModelState.IsValid)
                {
                    int StoreNumCnt = CheckStoreNumberExists(tblVideoDemoStoreMst.StoreNumber.ToString());
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
                        query = "Insert into  tblStore(StoreName, ";
                        query += " StoreGroupID,StoreID,DELFG,CRTDT, ";
                        query += " CRTCD,IPAddress";

                        query += ") Values ( ";
                        query += "N'" + tblVideoDemoStoreMst.StoreName + "',";
                       
                        query += " '" + tblVideoDemoStoreMst.StoreGroupID + "',";
                        query += "N'" + tblVideoDemoStoreMst.StoreNumber + "','0','" + DateTime.Now + "',N'" + tblVideoDemoStoreMst.CRTCD + "',";
                        query += "'" + tblVideoDemoStoreMst.IPAddress + "')";
                        

                        SqlCommand cmd;
                        cmd = new SqlCommand(query, con);
                        cmd.CommandType = CommandType.Text;
                        result = cmd.ExecuteNonQuery();

                        

                        query = "";
                        query = "Insert into  tblsubnet(SubnetID, ";
                        query += " SNIPAddress,SubnetMask,WANBandWidth,LANBandWidth,DELFG,CRTDT, ";
                        query += " CRTCD,IPAddress ";

                        query += ") Values ( ";
                        query += "'" + tblVideoDemoStoreMst.StoreNumber + "',";
                        
                        query += "N'" + tblVideoDemoStoreMst.SNIPAddress + "',";
                        query += "N'" + tblVideoDemoStoreMst.SubnetMask + "',N'" + tblVideoDemoStoreMst.WANBandWidth + "',N'" + tblVideoDemoStoreMst.LANBandWidth + "','0','" + DateTime.Now + "',N'" + tblVideoDemoStoreMst.CRTCD + "',";
                        query += "'" + tblVideoDemoStoreMst.IPAddress + "')";
                        

                        
                        cmd = new SqlCommand(query, con);
                        cmd.CommandType = CommandType.Text;
                        result = cmd.ExecuteNonQuery();


                        query = "";
                        query = "Insert into  tblStoreSubnet(Store, ";
                        query += " Subnet,DELFG,CRTDT, ";
                        query += " CRTCD,IPAddress ";

                        query += ") Values ( ";
                        query += "'" + tblVideoDemoStoreMst.StoreNumber + "',";
                       
                        query += "'" + tblVideoDemoStoreMst.StoreNumber + "',";
                        query += "'0','" + DateTime.Now + "',N'" + tblVideoDemoStoreMst.CRTCD + "',";
                        query += "'" + tblVideoDemoStoreMst.IPAddress + "' )";
                        


                        cmd = new SqlCommand(query, con);
                        cmd.CommandType = CommandType.Text;
                        result = cmd.ExecuteNonQuery();

                        string streamserver = System.Configuration.ConfigurationManager.AppSettings["Streamserver"];
                        string StreamIpaddress = System.Configuration.ConfigurationManager.AppSettings["StreamIpaddress"];

                        query = "";

                        query = " Insert Into tblStreamServer (SSServer,IPAddress,BelongingSubnet,DELFG,CRTDT,CRTCD,UserIPAddress ";
                        query += " ) Values ";
                        query += " (@streamserver, @StreamIpaddress, @SubnetID ";
                        query += "  ,0,@CRTDT,@CRTCD,@IPAddress) ";

                        SqlCommand cmds = new SqlCommand(query, con);
                        cmds.Parameters.AddWithValue("@streamserver", streamserver);
                        cmds.Parameters.AddWithValue("@StreamIpaddress", StreamIpaddress);
                        cmds.Parameters.AddWithValue("@SubnetID", tblVideoDemoStoreMst.StoreNumber);
                        cmds.Parameters.AddWithValue("@CRTDT", DateTime.Now);
                        cmds.Parameters.AddWithValue("@CRTCD", Session["UserName"].ToString());
                        cmds.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());
                        cmds.CommandType = CommandType.Text;
                        result = cmds.ExecuteNonQuery();

                    }
                                        

                    LogInfo.Comments = "Store subnet Created - " + tblVideoDemoStoreMst.StoreNumber;

                                                           
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.CntStoreSubnetsCreateSuccMsg;
                    return RedirectToAction("Create");
                }
                if (tblVideoDemoStoreMst.StoreGroupID == null)
                {
                    tblVideoDemoStoreMst.StoreGroupID = 0;
                }

                TempData["ErrMsg"] = MujiStore.Resources.Resource.CntStoreSubnetsCreateErrMsg2;
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
        public static int CheckStoreNameExists(string storeName, int StoreID)
        {
            int result = 0;
            string query = "";
            string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {

                query = "select count(*) Cnt from tblStore where StoreName =@StoreName and StoreID <> @StoreID and DELFG = 0";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StoreName", storeName);
                cmd.Parameters.AddWithValue("@StoreID", StoreID);
                cmd.CommandType = CommandType.Text;
                con.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());

                
            }
            return result;
        }
        public static int CheckSubnetIPAddressExists(string SubnetIPAddress, int SubnetID)
        {
            int result = 0;
            string query = "";
            string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {

                query = "select count(*) Cnt from tblsubnet where SNipaddress =@SubnetIPAddress and Subnetid <> @SubnetID and DELFG = 0";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@SubnetIPAddress", SubnetIPAddress);
                cmd.Parameters.AddWithValue("@SubnetID", SubnetID);
                cmd.CommandType = CommandType.Text;
                con.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());


            }
            return result;
        }
        public static int CheckStoreNumberExists(string StoreNumber)
        {
            int result = 0;
            string query = "";
            string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {

               
                query = " select sum(Cnt) Cnt from ";
                query += " ( ";
                query += " select count(*) Cnt from tblStore where storeid = @StoreNumber and DELFG = 0 ";
                query += " Union All ";
                query += " select count(*) Cnt from tblSubnet where SubnetID = @StoreNumber and DELFG = 0 ";
                query += " ) A";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StoreNumber", StoreNumber);
                cmd.CommandType = CommandType.Text;
                con.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());

                
            }
            return result;
        }
        public static int CheckSubnetNumberExists(string SubnetNumber, int subnetid)
        {
            int result = 0;
            string query = "";
            string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {

                query = "select count(*) Cnt from tblsubnet where subnetid <> @subnetid and DELFG = 0";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@SubnetNumber", SubnetNumber);
                cmd.Parameters.AddWithValue("@subnetid", subnetid);
                cmd.CommandType = CommandType.Text;
                con.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());


            }
            return result;
        }
        public int GettblSubnetID()
        {
            int id = 0;
            id = db.tblSubnets.Select(p => p.SubnetID).DefaultIfEmpty(0).Max();

            id = id + 1;
            return id;
        }


        public int GettblStoreID(string storenumber)
        {
            int result = 0;
            string query = "";
            string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {

                query = "select storeid  from tblStore where storenumber =@storenumber and DELFG = 0";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@storenumber", storenumber);
                
                cmd.CommandType = CommandType.Text;
                con.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());


            }
            return result;
        }
        
    }

}