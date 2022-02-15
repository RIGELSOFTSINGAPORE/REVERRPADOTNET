using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MujiStore.BLL;
using MujiStore.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace MujiStore.Views
{
    [SessionExpire]
    [Authorize]
    [MUJICustomAuthorize(Roles = "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31")]
    public class MenusController : Controller
    {
        // GET: Menus
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InfoMenus()
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                SqlCommand cmd;
                string querystr = "";

                List<tblSubnet> snlist = new List<tblSubnet>();
                List<tblStreamServer> sslist1 = new List<tblStreamServer>();
                List<tblStreamServer> sslist2 = new List<tblStreamServer>();
                List<tblStore> storelist = new List<tblStore>();
                bool RecExists = false;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    querystr = " SELECT Distinct SN.SubnetID AS SubnetID  ";
                    querystr += " FROM tblSubnet AS SN ";
                    querystr += " LEFT JOIN tblStoreSubnet AS SS ON SS.Subnet = SN.SubnetID  ";
                    querystr += " LEFT JOIN tblStore AS S ON S.StoreID = SS.Store  ";
                    querystr += " WHERE (isnull(SN.DELFG,1) = 1   ";
                    querystr += " OR isnull(SS.DELFG,1) = 1  ";
                    querystr += " OR isnull(S.DELFG,1) = 1  OR (S.DELFG = 1) ";
                    querystr += " OR S.StoreID IS NULL) ";

                    cmd = new SqlCommand(querystr, con);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader sndr = cmd.ExecuteReader();
                    while (sndr.Read())
                    {
                        RecExists = true;
                        snlist.Add(new tblSubnet { SubnetID = Convert.ToInt32(sndr["SubnetID"]) });
                        ViewData["snlist"] = snlist;
                    }
                    sndr.Close();

                    querystr = "";
                    querystr = " SELECT Distinct SV.[SSServer] ";
                    querystr += " FROM tblStreamServer AS SV ";
                    querystr += " LEFT JOIN tblSubnet AS SN ON SV.BelongingSubnet = SN.SubnetID ";
                    querystr += " WHERE (isnull(SV.DELFG,1) = 1 ";
                    querystr += " OR isnull(SN.DELFG,1) = 1  ";
                    querystr += " OR SN.SubnetID IS NULL ) ";

                    cmd = new SqlCommand(querystr, con);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader sslist1dr = cmd.ExecuteReader();
                    while (sslist1dr.Read())
                    {
                        RecExists = true;
                        sslist1.Add(new tblStreamServer { SSServer = sslist1dr["SSServer"].ToString() });
                        ViewData["sslist1"] = sslist1;
                    }
                    sslist1dr.Close();

                    querystr = "";
                    querystr = " SELECT Distinct SV.[SSServer] ";
                    querystr += " FROM tblStreamServer AS SV ";
                    querystr += " LEFT JOIN tblSubnet AS SN ON SV.BelongingSubnet = SN.SubnetID  ";
                    querystr += " WHERE (isnull(SV.DELFG,1) = 1 ";
                    querystr += " OR isnull(SN.DELFG,1) = 1  ";
                    querystr += " OR SN.SubnetID IS NULL) ";

                    cmd = new SqlCommand(querystr, con);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader sslist2dr = cmd.ExecuteReader();
                    while (sslist2dr.Read())
                    {
                        RecExists = true;
                        sslist2.Add(new tblStreamServer { SSServer = sslist2dr["SSServer"].ToString() });
                        ViewData["sslist2"] = sslist2;
                    }
                    sslist2dr.Close();

                    querystr = "";
                    querystr = " SELECT Distinct ST.[StoreID] AS StoreID, ST.[StoreName] AS StoreName ";
                    querystr += " FROM tblStore AS ST ";
                    querystr += " LEFT JOIN tblStoreSubnet AS SS ON SS.Store = ST.StoreID ";
                    querystr += " LEFT JOIN tblSubnet AS SN ON SS.Subnet = SN.SubnetID ";
                    querystr += " WHERE (isnull(ST.DELFG,1) = 1 OR (ST.DELFG = 1) ";
                    querystr += " OR isnull(SS.DELFG,1) = 1  ";
                    querystr += " OR isnull(SN.DELFG,1) = 1  ";
                    querystr += " OR SN.SubnetID IS NULL) ";

                    cmd = new SqlCommand(querystr, con);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader storelistdr = cmd.ExecuteReader();
                    while (storelistdr.Read())
                    {
                        RecExists = true;
                        storelist.Add(new tblStore
                        {
                            StoreID = Convert.ToInt32(storelistdr["StoreID"]),
                            StoreName = storelistdr["StoreName"].ToString()
                        });

                        ViewData["storelist"] = storelist;
                    }
                    storelistdr.Close();

                }
                ViewData["RecExists"] = RecExists;
                return View("");
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
           
        }
    }
}