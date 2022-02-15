using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MujiStore.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using MujiStore.BLL;
namespace MujiStore.Controllers
{
    [SessionExpire]
    [Authorize]
    [MUJICustomAuthorize(Roles = "2,3,6,7,10,11,14,15,18,19,22,23,26,27,30,31")]
    public class TroubleShootController : BaseController
    {
        // GET: TroubleShoot
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        [HttpGet]
        public ActionResult Search()
        {
            

            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
      
                ViewData["Search"] = "0";
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
        [ValidateAntiForgeryToken]
        public ActionResult Search(tblSubnet subnet)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
           
            ModelState["SubnetMask"].Errors.Clear();
            ModelState["WANBandWidth"].Errors.Clear();
            ModelState["LANBandWidth"].Errors.Clear();
            ModelState["SubnetNumber"].Errors.Clear();
            ViewData["Search"] = "0";
            if (ModelState.IsValid)
            {
                string querySDtnt = "";
       
                    List<tblSubnet> snetlist = new List<tblSubnet>();
                    List<tblDeployStatu> dssamesnet = new List<tblDeployStatu>();
                    List<tblDeployStatu> dsdifsnet = new List<tblDeployStatu>();
                    List<tblStore> stelist = new List<tblStore>();
                    tblMedia media = new tblMedia();
                    bool isMediaExists = false;


                    //snetlist = CommonLogic.getSubNetDetails(subnet.SNIPAddress);
                    snetlist = MujiStore.BLL.CommonLogic.getSubNetDetailsIPDtl(subnet.SNIPAddress);
                    if (snetlist.Count > 0)
                    {
                        ViewData["subnet"] = "1";
                    }
                    else
                    {
                        ViewData["subnet"] = "0";
                    }
                

                if(snetlist.Count > 0)
                {
                        int subnetID = 0;
                        foreach (MujiStore.Models.tblSubnet items in snetlist)
                        {
                            subnetID = Convert.ToInt32(items.SubnetID);
                        }
                        using (SqlConnection con = new SqlConnection(CS))
                        {
                            querySDtnt = "select S.StoreID,S.StoreName from tblStore S ";
                            querySDtnt += " Join tblStoreSubnet SS on SS.Store = s.StoreID ";
                            querySDtnt += " where ss.Subnet = " + subnetID;
                            querySDtnt += " and SS.DELFG = 0 and S.DELFG = 0 ";
                            SqlCommand cmds = new SqlCommand(querySDtnt, con);
                            cmds.CommandType = CommandType.Text;
                            con.Open();
                            SqlDataReader rdrs = cmds.ExecuteReader();
                            while (rdrs.Read())
                            {
                                tblStore ste = new tblStore();
                                ste.StoreID = Convert.ToInt32(rdrs["StoreID"]);
                                ste.StoreName = rdrs["StoreName"].ToString();
                                stelist.Add(ste);
                            }
                        }
                }
                if (stelist.Count > 0)
                {
                    ViewData["stre"] = "1";
                    ViewData["stredtl"] = stelist;
                }
                else
                {
                    ViewData["stre"] = "0";
                }
                if (stelist.Count > 0)
                {
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        querySDtnt = "select TOP 1 M.MediaID, M.Title From tblStore AS S ";
                        querySDtnt += " LEFT JOIN tblStoreGroupFolder AS SGF ON S.StoreGroupID = SGF.StoreGroupID ";
                        querySDtnt += " LEFT JOIN tblMedia AS M ON SGF.FolderID = M.FolderID ";
                        querySDtnt += " LEFT JOIN tblStoreGroup SG ON SGF.StoreGroupID = SG.StoreGroupID  ";
                        querySDtnt += " where S.StoreID =  " + stelist.FirstOrDefault().StoreID;
                        querySDtnt += " And S.DELFG = 0 And SGF.DELFG = 0 and M.DELFG = 0 ";
                        querySDtnt += " and SG.DELFG=0 ";
                        SqlCommand cmdr = new SqlCommand(querySDtnt, con);
                        cmdr.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader rdrm = cmdr.ExecuteReader();
                        while (rdrm.Read())
                        {
                            media.MediaID = Convert.ToInt32(rdrm["MediaID"]);
                            media.Title = rdrm["Title"].ToString();
                        
                            isMediaExists = true;
                            ViewData["mediadtl"] = media;
            
                        }
                    }
                }

                    ViewData["WANBandWidth"] = Session["WANBandWidth"].ToString();

                    ViewData["Search"] = "1";
                    if(isMediaExists == true)
                    {
                        string dssamesnetstr = "";
                        dssamesnet = BLL.CommonLogic.GetDSWithSS(media.MediaID, Convert.ToInt32(Session["SubnetID"]));
                        if(dssamesnet.Count > 0)
                        {
                            foreach (tblDeployStatu items in dssamesnet)
                            {
                                dssamesnetstr += items.DSServer + " (" + items.IPAddress + "), ";
                            }
                            dssamesnetstr = dssamesnetstr.Substring(0, dssamesnetstr.Length - 1);
                            ViewData["samesnetdtl"] = dssamesnetstr;
                        }
                    }
                    if (isMediaExists == true)
                    {
                        string dsdiffsnetstr = "";
                        dsdifsnet = BLL.CommonLogic.GetDSWithSNSS(media.MediaID, Convert.ToInt32(Session["SubnetID"]));
                        if(dsdifsnet.Count > 0)
                            {
                            foreach (tblDeployStatu items in dsdifsnet)
                            {
                                dsdiffsnetstr += items.DSServer + " (" + items.IPAddress + " / " + items.RequiredBandWidth + "byte/s), ";
                            }
                            dsdiffsnetstr = dsdiffsnetstr.Substring(0, dsdiffsnetstr.Length - 1);
                            ViewData["diffsnetdtl"] = dsdiffsnetstr;
                        }
                    }
                
                    return View();
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
    }
}