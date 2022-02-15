using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MujiStore.Models;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using MujiStore.BLL;
using PagedList;


namespace MujiStore.Controllers
{
    public class DeniedUserController : Controller
    {

        private mujiEntities1 db = new mujiEntities1();
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        int depth = 0;
        // GET: DeniedUser
        public ActionResult Index(int? page, string SearTitle, string SearchTitle, string SearchFromCRTDT, string CdStDate, string SearchToCRTDT, string CdEdDate, string ipadd, string ip)
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

            List<tblDeniedIPAddress> deniedusers = new List<tblDeniedIPAddress>();
            string query = "";
           
            try
            {

                string uName = Session["UserName"].ToString();
                if (SearchTitle != null || ip != null || SearchFromCRTDT != null || SearchToCRTDT != null)
                {
                    page = 1;
                }
                else
                {
                    SearchTitle = SearTitle;
                    ip = ipadd;
                    SearchFromCRTDT = CdStDate;
                    SearchToCRTDT = CdEdDate;
                }
                ViewBag.SearTitle = SearchTitle;
                ViewBag.ipadd = ip;
                ViewBag.CdStDate = SearchFromCRTDT;
                ViewBag.CdEdDate = SearchToCRTDT;
                if (ViewBag.CdStDate == null || ViewBag.CdStDate == "")
                {
                    CdStDate = DateTime.Now.AddYears(-200).ToString("yyyy/MM/dd");
                }
                else
                {
                    CdStDate = ViewBag.CdStDate;
                }
                if (ViewBag.CdEdDate == null || ViewBag.CdEdDate == "")
                {
                    CdEdDate = DateTime.Now.AddYears(100).ToString("yyyy/MM/dd");
                }
                else
                {
                    CdEdDate = ViewBag.CdEdDate;
                }
                SqlCommand cmd;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    
                        query = "Select denied.IPAddress,denied.MediaID,denied.DeniedIPAddressID,denied.CRTDT,denied.Remarks,denied.IPAddress, ";
                        query += "tblMedia.Title from tblDeniedIPAddress as denied left join tblMedia on tblMedia.MediaID=denied.MediaID where denied.DeniedIPAddressID like '%'";
                    query = query + " and FORMAT(denied.CRTDT, 'yyyy-MM-dd') between '" + CdStDate + "' and '" + CdEdDate + "'";
                    if (ViewBag.SearTitle != null && ViewBag.SearTitle != "" && ViewBag.SearTitle != string.Empty)
                    {
                        query = query + " and tblMedia.title like @title ";
                    }
                    if (ViewBag.ipadd != null && ViewBag.ipadd != "" && ViewBag.ipadd != string.Empty)
                    {
                        query = query + " and denied.IPAddress like @ipadd ";
                    }
                    query = query + " Order by denied.DeniedIPAddressID Desc";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@title", "%" + ViewBag.SearTitle + "%");
                    cmd.Parameters.AddWithValue("@ipadd", "%" + ViewBag.ipadd + "%");
                    cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        
                            while (sdr.Read())
                            {
                        tblDeniedIPAddress Denieduser = new tblDeniedIPAddress();
                        Denieduser.IPAddress = Convert.ToString(sdr["IPAddress"]);
                        Denieduser.DeniedIPAddressID = Convert.ToInt32(sdr["DeniedIPAddressID"]);
                        Denieduser.title = sdr["title"].ToString();
                        Denieduser.MediaID = Convert.ToInt32(sdr["MediaID"]);
                        Denieduser.CRTDT = Convert.ToDateTime(sdr["CRTDT"]);
                        Denieduser.STRCRTDT = Convert.ToDateTime(sdr["CRTDT"]).ToString("yyyy/MM/dd");// .ToString("yyyy/MM/dd HH:mm:ss tt");
                        Denieduser.STRCRTDTTIME = Convert.ToDateTime(sdr["CRTDT"]).ToString("HH:mm:ss");// .ToString("yyyy/MM/dd HH:mm:ss tt");
                        Denieduser.Remarks = sdr["Remarks"].ToString();

                        deniedusers.Add(Denieduser);

                    }
                        
                        con.Close();
                    
                }
                return View(deniedusers.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
                return View();
        }
    }
}