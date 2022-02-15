using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Threading.Tasks;
using Kaisokku_Business;
using Kaisokku_Common;
using Kaisokku_Sales.Models;
using System.Net.Mail;
using PagedList;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Mime;
using System.Data;
using ClosedXML.Excel;
using System.Text;
using Rotativa;
using System.Web.Helpers;

using Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Core;
using System.Drawing;
using System.Threading;
using System.Globalization;
namespace Kaisokku_Sales.Controllers
{
    public class HomeController : BaseController
    {
        private string UserId = string.Empty;
        private Kaisokku_BusinessLayer kaisokku_businesslayer;
        public HomeController()
        {
            kaisokku_businesslayer = new Kaisokku_BusinessLayer(base.ConnectionString);
        }


        [HttpGet]
        [Authorize]
        public ActionResult Index(bool showUserMenu = false)
        {
            
            if (showUserMenu == false)
            {
                ViewBag.AdminPage = "Admin";
                
            }
            var LanguageAbbrevation = Request.QueryString["LanguageAbbrevation"];
            TempData["LanguageAbbrevation"] = LanguageAbbrevation;
            TempData["showUserMenu"] = showUserMenu;

           
            
            return View();
        }


        [Authorize]
        public ActionResult Menu()
        {
            IEnumerable<Menu> Menu = null;
            
            try
            {

                string Language = Convert.ToString(TempData["LanguageAbbrevation"]);
                if (!string.IsNullOrEmpty(Language))
                {
                    SetCookiesForLanguage(Language);
                    OutPut result = new OutPut();
                    result = kaisokku_businesslayer.UpdateLanguageType(Language);
                    TempData["LanguageAbbrevation"] = null;
                }

                if (TempData["showClientMenu"] != null)
                {

                    string crl = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;

                    int questionMarkLocation = crl.IndexOf ('?');

                    string newString = crl.Substring(questionMarkLocation + 1);
                    if(newString== "showUserMenu=False")
                    {
                        ViewBag.showUserMenu = null;
                        TempData["showClientMenu"] = null;
                    }
                    else
                    {
                        ViewBag.showUserMenu = true;
                    }

                    //client
                    //ViewBag.showUserMenu = true;
                    
                }
                else
                {
                    //string crl1 = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
                    //admin
                    ViewBag.showUserMenu = TempData["showUserMenu"];
                    //Session["prevURL"] = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
                }
                
                if (!string.IsNullOrEmpty(Session["UserId"] as string))
                {
                    UserId = Convert.ToString(Session["UserId"]);
                }

                Menu = kaisokku_businesslayer.ShowMenus(UserId);//10012
                
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Home / Menu : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }
            return PartialView("_Menu", Menu);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Change(string LanguageAbbrevation)
        {


            SetCookiesForLanguage(LanguageAbbrevation);
              OutPut result = new OutPut();
            try
            {
                result = kaisokku_businesslayer.UpdateLanguageType(LanguageAbbrevation);


            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Language / Change : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }






            if (TempData["showClientMenu"] != null)
            {
               
                return RedirectToAction("Index", "Home", new { showUserMenu = true });
            }
            else
            {
                return RedirectToAction("DashBoard", "Home");
            }
            

        }


        public void SetCookiesForLanguage(string LanguageAbbrevation)
        {
            if (LanguageAbbrevation != null)
            {

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbrevation);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageAbbrevation);

            }

            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = LanguageAbbrevation;
            Response.Cookies.Add(cookie);
        }


        #region Bharathiraja-MenuManagement
        [HttpGet]
        [Authorize]
        public ActionResult MenuManagement()
        {
            TempData["showClientMenu"] = null;
            try
            {
                kaisokku_businesslayer.SaveActivity(Convert.ToString(Session["UserId"]), Convert.ToString(Session["UserName"]), (int)MenusActivity.MenuManagement, "Menu Management");
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("Home / MenuManagement : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["Message"] = "Operation Failed.";
                TempData["ErrorCode"] = "-1";
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult MenuManagement(AddDynamicMenu dynamicmenu)
        {
            TempData["showClientMenu"] = null;
            OutPut obj = new OutPut();
            try
            {
                LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
                LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
                if (ModelState.IsValid)
                {

                    obj = kaisokku_businesslayer.CreateDynamicMenu(dynamicmenu, Convert.ToInt32(Session["RoleId"]), Convert.ToBoolean(Session["IsActive"]), Convert.ToString(Session["UserName"]));
                    if (obj.ErrorCode == "1")
                    {
                        TempData["Message"] = "Menu Added Successfully.";
                        TempData["ErrorCode"] = "1";
                    }
                }
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("Home / MenuManagement : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["Message"] = "Operation Failed.";
                TempData["ErrorCode"] = "-1";
            }

            return RedirectToAction("MenuManagement");
        }


        public ActionResult GetMenuListDataById(EditMenuDetails obj)
        {
            TempData["showClientMenu"] = null;
            EditMenuDetails result = kaisokku_businesslayer.GetMenuById(obj);
            return View("EditMenuListData", result);
        }

        public JsonResult SaveMenuListData(int MenuId, string MenuName, string updatedby)
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();

            result = kaisokku_businesslayer.SaveMenuListData(MenuId, MenuName, updatedby);

            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteMenuById(EditMenuDetails obj)
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();
            try
            {
                result = kaisokku_businesslayer.DeleteMenu(obj.MenuId);

            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Home / Menu : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }

            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult LoadMenuListData(jQueryDataTableParamModel<Menu> param)
        {
            TempData["showClientMenu"] = null;
            try
            {
                //var draw = Request.Form.GetValues("draw").FirstOrDefault();
                //var start = Request.Form.GetValues("start").FirstOrDefault();
                //var length = Request.Form.GetValues("length").FirstOrDefault();
                //var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                //var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                //var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();
                var draw = param.draw;
                //param.data[0].MenuName

                //Paging Size (10,20,50,100)    
                //int pageSize = length != null ? Convert.ToInt32(length) : 0;
                //int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                // Getting all Customer data    
                var result = kaisokku_businesslayer.ShowGridMenus();

                ////Sorting    
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                //{
                //    result = result.OrderBy(sortColumn + " " + sortColumnDir);
                //}
                ////Search    
                //if (!string.IsNullOrEmpty(searchValue))
                //{
                //    result = result.Where(m => m.MenuName == searchValue);
                //}

                //total number of rows count     
                recordsTotal = result.Count();
                //Paging     
                //var data = result.Skip(skip).Take(pageSize).ToList();
                var data = result.ToList();
                //Returning Json Data    

                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception )
            {
                throw;
            }

        }
        #endregion


        public JsonResult DeletePageById(string PageId,string PageMenuId)
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();
            try
            {
                result = kaisokku_businesslayer.DeletePage(Convert.ToInt32(PageId), Convert.ToInt32(PageMenuId));

            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Home / Menu : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }

            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize]
        public ActionResult PageManagement(string PageMenuName = "", int MID=0)
        {
            TempData["showClientMenu"] = null;
            bool result= kaisokku_businesslayer.PageMenuIdExists(MID,PageMenuName);
            if(result==true)
            {
                ViewBag.MyPageName = PageMenuName;
                kaisokku_businesslayer.SaveActivity(Convert.ToString(Session["UserId"]), Convert.ToString(Session["UserName"]), MID, PageMenuName);

                ViewBag.UsersName = new SelectList(kaisokku_businesslayer.PageUsers(), "UserId", "UserName");
                ViewBag.PageMenuId = MID;
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }

           
        }

        public JsonResult AddPageInformation(SavePageContent savepagecontent)
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();
            InsertPage obj = new InsertPage();
            if (savepagecontent.Editable == "EditTrue")
            {
                obj.IsActive = savepagecontent.IsActive;
                obj.UserId = savepagecontent.UserId;
                obj.pagecontent = savepagecontent.pagecontent;
                obj.pagedescription = savepagecontent.pagedescription;
                obj.UpdatedBy = Convert.ToString(Session["UserName"]);
                obj.Editable = savepagecontent.Editable;
                obj.EditPageId = savepagecontent.EditPageId;
            }
            else
            {

                obj.IsActive = savepagecontent.IsActive;
                obj.createdby = Convert.ToString(Session["UserName"]);
                obj.pagefilename = savepagecontent.pagefilename;
                obj.pagedescription = savepagecontent.pagedescription;
                obj.pagecontent = savepagecontent.pagecontent;
                obj.UserId = savepagecontent.UserId;
                obj.AdminRights = "Yes";
                obj.IpAddress = "testip";
                obj.PageMenuId = savepagecontent.PageMenuId;
            }
            try
            {
                result = kaisokku_businesslayer.SavePageInformation(obj);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Home / AddPageInformation : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }
            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadPageListData(jQueryDataTableParamModel<ShowPageGrid> param, string PageName)
        {
            try
            {
                TempData["showClientMenu"] = null;
                var draw = param.draw;
                int recordsTotal = 0;
                // Getting all Customer data    
                var result = kaisokku_businesslayer.ShowPageDetails(PageName);
                recordsTotal = result.Count();
                var data = result.ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception)
            {
                throw;
            }

        }

        public JsonResult GetPageListDataById(string PageId)
        {
            try
            {
                TempData["showClientMenu"] = null;
                ShowEditablePage obj = kaisokku_businesslayer.GetPageListDataById(PageId);

                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("Home / GetPageListDataById : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }
            return Json(new { errorcode = "1", errormessage = "failure" }, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult LogOut()
        {

            try
            {

                Session["UserId"] = "";
                Session["UserName"] = "";
                Session["RoleId"] = "";
                Session["IsActive"] = "";

                Session["RoleName"] = "";

                FormsAuthentication.SignOut();
                HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
                foreach (var cookie in Request.Cookies.AllKeys)
                {
                    Request.Cookies.Remove(cookie);
                }

                // Clear authentication cookie
                HttpCookie rFormsCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
                rFormsCookie.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(rFormsCookie);

                // Clear session cookie 
                HttpCookie rSessionCookie = new HttpCookie("ASP.NET_SessionId", "");
                rSessionCookie.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(rSessionCookie);
                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Home / LogOut : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }


        }

        [HttpGet]
        [Authorize]
        public ActionResult Widgets()
        {
            TempData["showClientMenu"] = null;
            try
            {
                //kaisokku_businesslayer.SaveActivity(Convert.ToString(Session["UserId"]), Convert.ToString(Session["UserName"]), (int)MenusActivity.UserManagement, "User Management");
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("Home / Widgets : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }

            return View();
        }


        [Authorize]
        [HttpGet]
        public ActionResult SampleT(int myid, string action1)
        {
            TempData["showClientMenu"] = null;
            return View();
        }


        [HttpGet]
        [Authorize]
        public ActionResult SocialMedia()
        {
            TempData["showClientMenu"] = null;
            try
            {
                kaisokku_businesslayer.SaveActivity(Convert.ToString(Session["UserId"]), Convert.ToString(Session["UserName"]), (int)MenusActivity.SocialMedia, "SocialMedia");
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("Home / LogOut : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }

            return View();
        }


        [HttpGet]
        [Authorize]
        public ActionResult UserHome()
        {
            TempData["showClientMenu"] = true;
            //kaisokku_businesslayer.SaveActivity(Convert.ToString(Session["UserId"]), Convert.ToString(Session["UserName"]), "UserHome");

            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult UserKaisokku()
        {
            TempData["showClientMenu"] = true;
            //kaisokku_businesslayer.SaveActivity(Convert.ToString(Session["UserId"]), Convert.ToString(Session["UserName"]), (int)MenusActivity.UserManagement, "UserKaisokku");
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult UserClient()
        {
            TempData["showClientMenu"] = true;
            //kaisokku_businesslayer.SaveActivity(Convert.ToString(Session["UserId"]), Convert.ToString(Session["UserName"]), "UserClient");
            List<ClintUser> Clintimg = new List<ClintUser>();
            try
            {
                TempData["showClientMenu"] = true;
                Clintimg = kaisokku_businesslayer.SelectClint();

            }

            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format(" ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }
            return View(Clintimg);

        }

        [HttpGet]
        [Authorize]
        public ActionResult UserContactUs()
        {
            TempData["showClientMenu"] = true;
            // kaisokku_businesslayer.SaveActivity(Convert.ToString(Session["UserId"]), Convert.ToString(Session["UserName"]), "UserContactUs");
            UserContactUsViewModel obj = new UserContactUsViewModel();

            obj.ClientDetails = kaisokku_businesslayer.Selectadd();
            try
            {
                TempData["showClientMenu"] = true;
            }
            catch (Exception ex)
            {


                LogInfo.LogMsg = string.Format(" ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }

            return View(obj);
        }

        [HttpPost]
        [Authorize]
        [ActionName("UserContactUs")]
        public ActionResult UserContactUsSubmit(UserContactUsViewModel obj)
        {
            TempData["showClientMenu"] = true;
          
            try
            {
                kaisokku_businesslayer.insertEnquiry(obj.EnquiryFormDetails);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format(" ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }

            return RedirectToAction("UserContactUs", "Home");
        }

        [HttpGet]
        [Authorize]
        public ActionResult showadd()
        {
            try
            {
                TempData["showClientMenu"] = true;
                kaisokku_businesslayer.Selectadd();

            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format(" ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult UserPages()
        {
            TempData["showClientMenu"] = true;
            List<UserPageManagement> obj = new List<UserPageManagement>();
            obj = kaisokku_businesslayer.UserManagementForClients();
            var pages = obj.Select(s => s.pagefilename).Distinct();
            return PartialView("_UserPages", pages);
        }

        [HttpGet]
        [Authorize]
        public ActionResult UserClientPage(string PageFileName)
        {
            TempData["showClientMenu"] = true;
            List<UserPageManagement> lstpages = new List<UserPageManagement>();
            lstpages = kaisokku_businesslayer.ShowClientPage(PageFileName, Convert.ToInt32(Session["RoleId"]), Convert.ToString(Session["UserId"]));
            return View(lstpages);
        }

        #region Bharathiraja-Dashboard
        [HttpGet]
        [Authorize]
        public ActionResult DashBoard()
        {
            TempData["showClientMenu"] = null;
            List<VideoViewLog> obj = new List<VideoViewLog>();
            try
            {
                kaisokku_businesslayer.SaveActivity(Convert.ToString(Session["UserId"]), Convert.ToString(Session["UserName"]), (int)MenusActivity.DashBoard, "DashBoard");
                //obj = kaisokku_businesslayer.GetHitCounter();
                //kaisokku_businesslayer.ShowPPTChart();

            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Home / DashBoard : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }
            return View();
        }


        public ActionResult CreateBar()
        {
            //Create bar chart
            //List<PPTChart> obj = new List<PPTChart>();
            //obj= kaisokku_businesslayer.ShowPPTChart();

            List<ActivityReportChart> obj = new List<ActivityReportChart>();
            obj = kaisokku_businesslayer.ShowActivityReportChart();

            var chart = new System.Web.Helpers.Chart(width: 300, height: 200, theme: ChartTheme.Yellow)
                 .AddTitle(" Show Maximum activity count on menus")
            .AddSeries(chartType: "bar",
                              xValue: obj, xField: "MenuName",
                            yValues: obj, yFields: "Hits")
                            .GetBytes("png");
            return File(chart, "image/bytes");
        }

        public ActionResult CreatePie()
        {
            //Create pie chart
            List<ClientVisitedVideos> obj = new List<ClientVisitedVideos>();
            obj = kaisokku_businesslayer.ShowClientVisitedVideos();
            var chart = new System.Web.Helpers.Chart(width: 300, height: 200, theme: ChartTheme.Green)
                .AddTitle("Shows Watched videos based on users like")
                .AddLegend()
            .AddSeries(chartType: "pie",
                             xValue: obj, xField: "VideoName",
                            yValues: obj, yFields: "ViewCount")
                            .GetBytes("png");
            return File(chart, "image/bytes");
        }

        public ActionResult CreateLine()
        {
            //Create line chart
            List<PPTChart> obj = new List<PPTChart>();
            obj = kaisokku_businesslayer.ShowPPTChart();
            var chart = new System.Web.Helpers.Chart(width: 300, height: 200, theme: ChartTheme.Blue)
                .AddTitle("Show PPT based on Created date")
                  .AddLegend()
            .AddSeries(chartType: "line",
                              xValue: obj, xField: "Title",
                            yValues: obj, yFields: "CreatedDate")
                            .GetBytes("png");
            return File(chart, "image/bytes");
        }

        #endregion

        #region Prabhu Social Media
        public ActionResult CreateSocialMediaListData()
        {
            TempData["showClientMenu"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult SaveCreateSocialMediaData()
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();
            // OutPut mediaid = new OutPut();
            var Title = Request.Form["Title"];
            var ImageUrl = Request.Form["ImageUrl"];
            string path = Server.MapPath("~/Images/");
            HttpFileCollectionBase files = Request.Files;

            result = kaisokku_businesslayer.SaveCreateSocialMeida(Title, ImageUrl, path);

            var social = kaisokku_businesslayer.GetSocialMediaId();
            var SocialMediaId = social.SocialMediaId;

            try
            {
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];
                    file.SaveAs(path + file.FileName);
                    result = kaisokku_businesslayer.SaveCreateSocialFileList(file.FileName, SocialMediaId);
                }
            }
            catch (Exception  ex)
            {

                LogInfo.LogMsg = string.Format("Home / SaveCreateSocialMediaData : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return Json(new { errorcode = -1, errormessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult LoadSocialMediaListData(jQueryDataTableParamModel<SocialMediaGrid> param)
        {
            TempData["showClientMenu"] = null;
            try
            {

                var draw = param.draw;

                int recordsTotal = 0;

                // Getting all Customer data    
                var result = kaisokku_businesslayer.ShowGridSocialMedia();

                //total number of rows count     
                recordsTotal = result.Count();
                //Paging     
                //var data = result.Skip(skip).Take(pageSize).ToList();
                var data = result.ToList();
                //Returning Json Data    
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception )
            {
                throw;
            }

        }

        public JsonResult SaveSocialMediaListData()
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();

            var Title = Request.Form["Title"];
            var URL = Request.Form["URL"];
            int SocialMediaID = Int32.Parse(Request.Form["SocialMediaID"]);
            //var Filename = Request.Form["Filename"];
            string path = Server.MapPath("~/Images/");
            HttpFileCollectionBase files = Request.Files;

            //result = kaisokku_businesslayer.SaveSocialMediaListData(SocialMediaID, Title, URL, Filename);
            try
            {
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];
                    file.SaveAs(path + file.FileName);
                    result = kaisokku_businesslayer.SaveSocialMediaListData(SocialMediaID, Title, URL, file.FileName);
                }
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("Home / SaveSocialMediaListData : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return Json(new { errorcode = -1, errormessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
           

            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewFileSocialListById(SocialMediaGrid obj)
        {
            TempData["showClientMenu"] = null;
            SocialMediaGrid result = kaisokku_businesslayer.GetSocialById(obj);
            return View("ViewSocialMedia", result);
        }



        public ActionResult ViewSocialListDataById(SocialMediaGrid obj)
        {
            TempData["showClientMenu"] = null;
            SocialMediaGrid result = kaisokku_businesslayer.GetSocialById(obj);

            //var dplist = result.Filename.ToList();
            //SelectList list = new SelectList(dplist, "filename", "filename");
            List<SocialMediaGrid> SelectVideonew = kaisokku_businesslayer.GetSocialListById(obj);
            var list = new SelectList(SelectVideonew, "Filename", "Filename");
            //List<System.Web.Mvc.SelectListItem> SelectVideo = new List<System.Web.Mvc.SelectListItem>()
            //{
            //    //new SelectListItem 
            //    //{
            //    //       Text = videolist,
            //    //       Value = videolist.Filename
            //    //   },
            //};

            TempData["SelectVideo"] = list;

            return View("ViewSocialMedia", result);
        }

        public JsonResult DeleteSocialMediaById(SocialMediaGrid obj)
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();

            result = kaisokku_businesslayer.DeleteSocialMediaId(obj.SocialMediaID);


            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetSocialMediaListDataById(SocialMediaGrid obj)
        {
            TempData["showClientMenu"] = null;
            SocialMediaGrid result = kaisokku_businesslayer.GetSocialLiById(obj);
            List<SocialMediaGrid> SelectVideonew = kaisokku_businesslayer.GetSocialListById(obj);
            var list = new SelectList(SelectVideonew, "Filename", "Filename");

            TempData["SelectVideo"] = list;
            return View("SocialMediaCreate", result);
        }


        [HttpGet]
        [Authorize]
        public ActionResult UserSocialMedia()
        {
            List<Social> socialimag = new List<Social>();
            try
            {
                TempData["showClientMenu"] = true;
                socialimag = kaisokku_businesslayer.Selectsocial();

            }

            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format(" ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }
            return View(socialimag);
        }

        #endregion

        #region Prabhu-PPT
        [HttpGet]
        [Authorize]
        public ActionResult UserPresentation()
        {

            TempData["showClientMenu"] = true;

            List<GetPresentation> getpresen = new List<GetPresentation>();

            getpresen = kaisokku_businesslayer.GetPresentationgetvalues();

            return View(getpresen);
        }

        [HttpGet]
        [Authorize]
        public ActionResult DownLoadPPT(int pptid, string pptfilename)
        {
            TempData["showClientMenu"] = true;

            //string fileName = "Natural_1.pptx";
            //GetPresentation obj = new GetPresentation();
            //obj = kaisokku_businesslayer.Presentationgetvalues(1);

            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath("~/PPT/" + pptfilename));


            //for (int i = 0; i < fileBytes.Count; i++)
            //{
            //    HttpPostedFileBase file = files[i];

            //    result = kaisokku_businesslayer.UserPresentation(pptfilename);
            //}

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, pptfilename);
        }

        #endregion

        #region Bharthiraja-User Management
        [HttpGet]
        [Authorize]
        public ActionResult UserManagement()
        {
            TempData["showClientMenu"] = null;
            try
            {
                kaisokku_businesslayer.SaveActivity(Convert.ToString(Session["UserId"]), Convert.ToString(Session["UserName"]), (int)MenusActivity.UserManagement, "User Management");
                List<SelectListItem> customerselection = new List<SelectListItem>() {
                new SelectListItem {
                Text = "Existing Customer", Value = "1"
                },
                new SelectListItem {
                Text = "General Cusotmer", Value = "2"
                },

                };
                ViewBag.userid = Convert.ToString(Session["UserMasterID"]);
                TempData["CustomerSelection"] = customerselection;

            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("Home / DashBoard : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }

            return View();
        }

        [HttpGet]
        public JsonResult GetLastUserId()
        {
            TempData["showClientMenu"] = null;
            string LastUserId = string.Empty;
            try
            {
                LastUserId = kaisokku_businesslayer.GetLastUserId();
                return Json(LastUserId, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("Home / GetLastUserId : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);

                return Json("nouserid", JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult AddUserInformation(UserManagements obj)
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();
            try
            {
                obj.CreatedBy = Convert.ToString(Session["UserName"]);
                result = kaisokku_businesslayer.AddUserInformation(obj);
                return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("Home / AddUserInformation : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);

                return Json(new { errorcode = "1", errormessage = "Unable to insert" }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult LoadUserListData(jQueryDataTableParamModel<ShowPageGrid> param)
        {
            try
            {
                TempData["showClientMenu"] = null;
                var draw = param.draw;
                int recordsTotal = 0;
                // Getting all Customer data    
                var result = kaisokku_businesslayer.GetUserDetails();
                recordsTotal = result.Count();
                var data = result.ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception)
            {
                throw;
            }

        }


        public ActionResult GetUserListDataById(EditUserDetails obj)
        {
            TempData["showClientMenu"] = null;
            EditUserDetails result = kaisokku_businesslayer.GetUserListDataById(obj);
            return PartialView("EditUserListData", result);
        }

        public JsonResult SaveUserListData(int UserMasterId, string UserName, string Password, bool Active,string Email,int CustomerTYpe, bool Client)
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();

            result = kaisokku_businesslayer.SaveUserListData(UserMasterId, UserName, Password, Active, Convert.ToString(Session["UserName"]), Email, CustomerTYpe, Client);

            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteUserById(int UserMasterId)
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();
            try
            {
                result = kaisokku_businesslayer.DeleteUserById(UserMasterId);

            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Home / Menu : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }

            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Balraj-CRM
        [Authorize]
        [HttpGet]
        public ActionResult CRM()
        {
            TempData["showClientMenu"] = null;
            try
            {
                kaisokku_businesslayer.SaveActivity(Convert.ToString(Session["UserId"]), Convert.ToString(Session["UserName"]), (int)MenusActivity.CRM, "CRM");
                List<SelectListItem> selecttype = new List<SelectListItem>() {
            new SelectListItem {
            Text = "News Letter", Value = "1"
            },
            new SelectListItem {
            Text = "Promotions", Value = "2"
            },
            new SelectListItem {
            Text = "Greetings", Value = "3"
            },
            };

                TempData["SelectTypes"] = selecttype;
                //ViewBag.SelectTypes = selecttype;


            List<SelectListItem> customerselection = new List<SelectListItem>() {
            new SelectListItem {
            Text = "Existing Customer", Value = "1"
            },
            new SelectListItem {
            Text = "General Cusotmer", Value = "2"
            },

            };
                //ViewBag.CustomerSelection = customerselection;
                TempData["CustomerSelection"] = customerselection;
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Home / Widgets : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public JsonResult CRM(CRMEmail crmail)
        {
            TempData["showClientMenu"] = null;
            //string ImageUrl = string.Empty;
            try
            {
                //string result = string.Empty;
                //HttpPostedFileBase file = HttpContext.Request.Files[0];

                //using (BinaryReader b = new BinaryReader(file.InputStream))
                //{
                //    byte[] binData = b.ReadBytes(file.ContentLength);
                //    string base64String = Convert.ToBase64String(binData, 0, binData.Length);
                //    ImageUrl = "data:image/png;base64," + base64String;
                //}



                //List<CRMBulkEmail> obj = kaisokku_businesslayer.CRMMails(Convert.ToInt32(collection["CustomerSelection"]));
                //foreach (var item in obj)
                //{
                var IsMailSend = SendEmail(crmail.CC, crmail.SenderFrom, crmail.EmailTo, crmail.Subject, crmail.Body);
                //}

                return Json(IsMailSend, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Home / CRM : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);

                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public JsonResult GetCRMMail(int id)
        {
            TempData["showClientMenu"] = null;
            string email = "";
            List<CRMBulkEmail> lstBulkEmail = kaisokku_businesslayer.CRMMails(Convert.ToInt32(id));
            foreach (var result in lstBulkEmail)
            {
                email = email + "," + result.Email;
            }
            email = email.Remove(0, 1);
            return Json(email, JsonRequestBehavior.AllowGet);
        }

        public bool SendEmail(string CC, string From, string EmailTo, string Subject, string Body)
        {
            string body = string.Empty;
            //using (StreamReader reader = new StreamReader(Server.MapPath("~/CRMEMAIL/HtmlPage1.html")))
            //{
            //    Body = reader.ReadToEnd();
            //}

            string smtpAddress = "smtp.gmail.com";
            //string smtpAddress = "smtp.google.com";
            int portNumber = 587;
            bool enableSSL = true;
            string emailFromAddress = "gnanavallal1900@gmail.com"; //Sender Email Address  
            string password = "sugan1978!"; //Sender Password  
            //string emailToAddress = "smartdavidm@gmail.com";
            string emailToAddress = EmailTo + "," + CC;

            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFromAddress);
                    mail.To.Add(emailToAddress);
                    mail.Subject = Subject;
                    //mail.Body = Body;
                    mail.IsBodyHtml = true;
                    AlternateView alterView = ContentToAlternateView(Body);
                    mail.AlternateViews.Add(alterView);
                    //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        //smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                        smtp.EnableSsl = enableSSL;

                        smtp.Send(mail);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Home / SendEmail : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return false;
            }

        }

        private AlternateView ContentToAlternateView(string content)
        {
            var imgCount = 0;
            List<LinkedResource> resourceCollection = new List<LinkedResource>();
            foreach (Match m in Regex.Matches(content, "<img(?<value>.*?)>"))
            {
                imgCount++;
                var imgContent = m.Groups["value"].Value;
                string type = Regex.Match(imgContent, ":(?<type>.*?);base64,").Groups["type"].Value;
                string base64 = Regex.Match(imgContent, "base64,(?<base64>.*?)\"").Groups["base64"].Value;
                if (String.IsNullOrEmpty(type) || String.IsNullOrEmpty(base64))
                {
                    //ignore replacement when match normal <img> tag
                    continue;
                }
                var replacement = " src=\"cid:" + imgCount + "\"";
                content = content.Replace(imgContent, replacement);
                var tempResource = new LinkedResource(Base64ToImageStream(base64), new ContentType(type))
                {
                    ContentId = imgCount.ToString()
                };
                resourceCollection.Add(tempResource);
            }

            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(content, null, MediaTypeNames.Text.Html);
            foreach (var item in resourceCollection)
            {
                alternateView.LinkedResources.Add(item);
            }

            return alternateView;
        }

        public Stream Base64ToImageStream(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            return ms;
        }
        #endregion

        #region Sabeena Reports
        [HttpGet]
        [Authorize]
        public ActionResult Reports()
        {
            TempData["showClientMenu"] = null;
            try
            {
                kaisokku_businesslayer.SaveActivity(Convert.ToString(Session["UserId"]), Convert.ToString(Session["UserName"]), (int)MenusActivity.Reports, "Reports");
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("Home / LogOut : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Export()
        {
            TempData["showClientMenu"] = null;
            var option = Request["ReportName"];
            var reporttype = Request["ReportType"];
            var startdate = Request["startdate"];
            var enddate = Request["enddate"];
            System.Data.DataTable dt = new System.Data.DataTable("Report");

            if (reporttype == "1")
            {
                if (option == "1")
                {
                    var result = kaisokku_businesslayer.GetVideoRepId(startdate, enddate);

                    dt.Columns.AddRange(new DataColumn[4] { new DataColumn("mediaid"),
                                            new DataColumn("title"),
                                            new DataColumn("description"),
                                            new DataColumn("filename") });
                    foreach (var Results in result)
                    {
                        dt.Rows.Add(Results.MediaID, Results.Title, Results.Description, Results.Filename);
                    }
                }
                else if (option == "2")
                {
                    var result = kaisokku_businesslayer.GetPPTRepId(startdate, enddate);

                    dt.Columns.AddRange(new DataColumn[4] { new DataColumn("mediaid"),
                                            new DataColumn("title"),
                                            new DataColumn("description"),
                                            new DataColumn("filename") });
                    foreach (var Results in result)
                    {
                        dt.Rows.Add(Results.MediaID, Results.Title, Results.Description, Results.Filename);
                    }
                }
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt);
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Report.xlsx");
                    }
                }
            }

            else if (reporttype == "2")
            {
                if (option == "1")
                {
                    var sb = new StringBuilder();
                    var result = kaisokku_businesslayer.GetVideoRepId(startdate, enddate);
                    var list = result;
                    sb.AppendFormat("{0},{1},{2},{3},{4},{5},{6}", "MediaID", "Title", "Description", "IPaddress", "Viewcount", "uploadtype", Environment.NewLine);
                    foreach (var item in list)
                    {
                        sb.AppendFormat("{0},{1},{2},{3},{4},{5},{6}", item.MediaID, item.Title, item.Description, item.IPaddress, item.Viewcount, item.uploadtype, Environment.NewLine);
                    }
                    var response = System.Web.HttpContext.Current.Response;
                    response.BufferOutput = true;
                    response.Clear();
                    response.ClearHeaders();
                    response.ContentEncoding = Encoding.Unicode;
                    response.AddHeader("content-disposition", "attachment;filename=Report.CSV ");
                    response.ContentType = "text/plain";
                    response.Write(sb.ToString());
                    response.End();
                }
                else if (option == "2")
                {
                    var sb = new StringBuilder();
                    var result = kaisokku_businesslayer.GetPPTRepId(startdate, enddate);
                    var list = result;
                    sb.AppendFormat("{0},{1},{2},{3},{4},{5},{6}", "MediaID", "Title", "Description", "IPaddress", "Viewcount", "uploadtype", Environment.NewLine);
                    foreach (var item in list)
                    {
                        sb.AppendFormat("{0},{1},{2},{3},{4},{5},{6}", item.MediaID, item.Title, item.Description, item.IPaddress, item.Viewcount, item.uploadtype, Environment.NewLine);
                    }
                    var response = System.Web.HttpContext.Current.Response;
                    response.BufferOutput = true;
                    response.Clear();
                    response.ClearHeaders();
                    response.ContentEncoding = Encoding.Unicode;
                    response.AddHeader("content-disposition", "attachment;filename=Report.CSV ");
                    response.ContentType = "text/plain";
                    response.Write(sb.ToString());
                    response.End();
                }


            }
            //else if (option == "1" && reporttype == "3")
            //{
            //    var result = kaisokku_businesslayer.GetVideoRepId(startdate, enddate);
            //    var grid= new System.Web.UI.WebControls.GridView();
            //    grid.DataSource = result;
            //    grid.DataBind();
            //    Response.ClearContent();
            //    Response.AddHeader("content-disposition", "attachment; filename=video.xlsx");
            //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //    StringWriter sw = new StringWriter();
            //    System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
            //    grid.RenderControl(htw);
            //    Response.Write(sw.ToString());

            //    Response.End();

            //}
            else
            {
                if (option == "1")
                {
                    var result = kaisokku_businesslayer.GetVideoRepId(startdate, enddate);
                    var data = result.ToList();
                    return new PartialViewAsPdf("ExportVideo", data);
                }
                else if (option == "2")
                {
                    var result = kaisokku_businesslayer.GetPPTRepId(startdate, enddate);
                    var data = result.ToList();
                    return new PartialViewAsPdf("ExportPPT", data);
                }
            }
            return null;
        }
        #endregion

        #region Bharathiraja-Video Feedback
        [HttpGet]
        [Authorize]
        public ActionResult UserVideo()
        {
            TempData["showClientMenu"] = true;
            //GetVideo obj = new GetVideo();
            //obj = kaisokku_businesslayer.Mediagetvalues(1, Convert.ToString(Session["UserName"]));
            //return View(obj);
            kaisokku_businesslayer.SaveActivity(Convert.ToString(Session["UserId"]), Convert.ToString(Session["UserName"]), (int)MenusActivity.ManageComments, "ManageComments");
            var lstVideoComments = kaisokku_businesslayer.LoadVideoCommentsListData();


            List<VideoComments> SelectVideo = kaisokku_businesslayer.GetVideosForComments();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in SelectVideo)
            {
                list.Add(new SelectListItem() { Text = item.filename, Value = item.mediaid.ToString() });
            }
            TempData["SelectVideoTest"] = list;
            return View(lstVideoComments);
        }


        public JsonResult SaveVideoComments()
        {
            OutPut result = new OutPut();
            var VideoId = Request.Form["VideoId"];
            var VideoName = Request.Form["VideoName"];
            var VideoComments = Request.Form["VideoComments"];

            string path = Server.MapPath("~/VideoComments/");
            HttpFileCollectionBase files = Request.Files;

            if (files.Count > 0)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];

                    file.SaveAs(path + file.FileName);
                    result = kaisokku_businesslayer.SaveVideoComments(Convert.ToInt32(VideoId), VideoName, VideoComments, path, false, Convert.ToString(Session["UserId"]),
                   Convert.ToString(Session["UserName"]), file.FileName, false);
                }
            }
            else
            {
                result = kaisokku_businesslayer.SaveVideoComments(Convert.ToInt32(VideoId), VideoName, VideoComments, path, false, Convert.ToString(Session["UserId"]),
                 Convert.ToString(Session["UserName"]), "", false);
            }



            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult UpdateVideoViewCount(int VideoId,string VideoFileName)
        {
            //OutPut result = new OutPut();
            int result = kaisokku_businesslayer.UpdateVideoViewCount(VideoId, VideoFileName);

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ShowVideoComments(string Sno, string IsDeleted, string IsApproved, string VideoName, string FilePath, string VideoComments, string FileName)
        {
            ShowVideoComments obj = new ShowVideoComments();
            obj.Sno = Convert.ToInt32(Sno);
            obj.VideoName = VideoName;
            obj.FilePath = FilePath;
            obj.VideoComments = VideoComments;
            obj.FileName = FileName;
            obj.IsApproved = Convert.ToBoolean(IsApproved);
            obj.IsDeleted = Convert.ToBoolean(IsDeleted);
            return PartialView("ShowVideoComments", obj);
        }



        [HttpGet]
        [Authorize]
        public ActionResult VideoComments(string PageMenuName = "", int MID = 0)
        {
            TempData["showClientMenu"] = null;
            ViewBag.VideoCommentsPageName = PageMenuName;
            //kaisokku_businesslayer.SaveActivity(Convert.ToString(Session["UserId"]), Convert.ToString(Session["UserName"]), MID, PageMenuName);
            kaisokku_businesslayer.SaveActivity(Convert.ToString(Session["UserId"]), Convert.ToString(Session["UserName"]), (int)MenusActivity.ManageComments, "ManageComments");

            return View();
        }


        public JsonResult SaveVideoApprove(string Sno, bool IsApproved)
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();
            try
            {
                IsApproved = true;
                result = kaisokku_businesslayer.SaveVideoApprove(Convert.ToInt32(Sno), IsApproved);
                if (result == null)
                {
                    return Json(new { errorcode = 0, errormessage = "Success" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Home / SaveVideoApprove : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult RejectVideoApprove(string Sno, bool IsDeleted)
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();
            try
            {
                IsDeleted = true;
                result = kaisokku_businesslayer.RejectVideoApprove(Convert.ToInt32(Sno), IsDeleted);
                if (result == null)
                {
                    return Json(new { errorcode = 0, errormessage = "Success" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Home / RejectVideoApprove : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult LoadVideoCommentsListData(jQueryDataTableParamModel<ShowPageGrid> param)
        {
            try
            {
                TempData["showClientMenu"] = null;
                var draw = param.draw;
                int recordsTotal = 0;
                // Getting all Customer data    
                var result = kaisokku_businesslayer.LoadVideoCommentsListData();
                recordsTotal = result.Count();
                var data = result.ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Home / LoadVideoCommentsListData : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return Json(null, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region Sabeena Video Management
        [HttpGet]
        [Authorize]
        public ActionResult VideoManagement(string PageMenuName = "", int MID = 0)
        {
            TempData["showClientMenu"] = null;
            ViewBag.MyPageName = PageMenuName;
            kaisokku_businesslayer.SaveActivity(Convert.ToString(Session["UserId"]), Convert.ToString(Session["UserName"]), (int)MenusActivity.ManageVideos, "ManageVideos");
            return View();
        }
        public ActionResult LoadVideoListData(jQueryDataTableParamModel<video> param)
        {
            TempData["showClientMenu"] = null;
            try
            {

                var draw = param.draw;

                int recordsTotal = 0;

                // Getting all Customer data    
                var result = kaisokku_businesslayer.ShowGridVideos();

                //total number of rows count     
                recordsTotal = result.Count();
                //Paging     
                //var data = result.Skip(skip).Take(pageSize).ToList();
                var data = result.ToList();
                //Returning Json Data    
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }

        }
        public JsonResult DeleteVideoById(video obj)
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();
            video medfile = kaisokku_businesslayer.GetVideoById(obj);
            
            var fileNameTmp = Path.Combine(Server.MapPath("~/Video"), medfile.PlayVideoFileName);
            if (System.IO.File.Exists(fileNameTmp))
            {
                System.IO.File.Delete(fileNameTmp);
            }
            result = kaisokku_businesslayer.DeleteVideo(obj.MediaID);


            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveCreateVideoListData(video obj)
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();
            // OutPut mediaid = new OutPut();
            var VideoTitle = Request.Form["VideoTitle"];
            var VideoDesc = Request.Form["VideoDesc"];
            int UserType = Int32.Parse(Request.Form["UserType"]);
            string path = Server.MapPath("~/Video/");
            HttpFileCollectionBase files = Request.Files;
            var ext = Path.GetExtension(((System.Web.HttpPostedFileWrapper)files[0]).FileName);
            var name = Path.GetFileNameWithoutExtension(((System.Web.HttpPostedFileWrapper)files[0]).FileName);
            result = kaisokku_businesslayer.SaveCreateVideoListData(VideoTitle, VideoDesc, path, name,ext, UserType, Session["UserName"].ToString(), Session["IPAddress"].ToString());

            try
            {
                //var mediaid = kaisokku_businesslayer.GetVideoId();
                //var fileid = mediaid.MediaID;

                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];
                    // file.SaveAs(path + file.FileName);
                    //var fileNameTmp = Path.Combine(Server.MapPath("~/Video"), file.FileName);
                    var fileNameTmp = Path.Combine(Server.MapPath("~/Video"), result.ScopeIden+ ext);
                    file.SaveAs(fileNameTmp);
                    //result = kaisokku_businesslayer.SaveCreateVideoFileList(file.FileName, fileid,false,true);
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Home / SaveCreateVideoListData : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return Json(new { errorcode = -1, errormessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
           

            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SaveVideoListData()
        {
            //bool IsResetCount = false;
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();

            var VideoTitle = Request.Form["VideoTitle"];
            var VideoDesc = Request.Form["VideoDesc"];
            int VideoId = Int32.Parse(Request.Form["VideoId"]);
            int UserType = Int32.Parse(Request.Form["UserType"]);
            string path = Server.MapPath("~/Video/");
            string ExistingVideoName = Request.Form["ExistingVideoName"];
            int isNewVideo = 0;
            HttpFileCollectionBase files = Request.Files;
            var ext = "";
            var name = "";

            if (files.Count > 0)
            {
                isNewVideo = 1;
                ext = Path.GetExtension(((System.Web.HttpPostedFileWrapper)files[0]).FileName);
                name = Path.GetFileNameWithoutExtension(((System.Web.HttpPostedFileWrapper)files[0]).FileName);

                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];
                    // file.SaveAs(path + file.FileName);
                    //var fileNameTmp = Path.Combine(Server.MapPath("~/Video"), file.FileName);
                    var fileNameTmp = Path.Combine(Server.MapPath("~/Video"), VideoId + ext);
                    if (System.IO.File.Exists(fileNameTmp))
                    {
                        System.IO.File.Delete(fileNameTmp);
                    }
                    file.SaveAs(fileNameTmp);
                    //result = kaisokku_businesslayer.SaveCreateVideoFileList(file.FileName, fileid,false,true);
                }
            }
            result = kaisokku_businesslayer.SaveVideoListData(VideoId, VideoTitle, VideoDesc, isNewVideo, path, name, ext, ExistingVideoName, UserType, Session["UserName"].ToString(), Session["IPAddress"].ToString());
            //if (files.Count > 0)
            //{
            //   result = kaisokku_businesslayer.SaveVideoListData(VideoId, VideoTitle, VideoDesc, true);
            //    for (int i = 0; i < files.Count; i++)
            //    {
            //        HttpPostedFileBase file = files[i];
            //        file.SaveAs(path + file.FileName);
            //        string NewVideoName = Convert.ToString(file.FileName);
            //        try
            //        {
            //            if (ExistingVideoName.Trim() == NewVideoName.Trim())
            //            {
            //                IsResetCount = false;
            //            }
            //            else
            //            {
            //                IsResetCount = true;
            //            }
            //            result = kaisokku_businesslayer.SaveCreateVideoFileList(file.FileName, VideoId, IsResetCount,true);
            //        }
            //        catch (Exception ex)
            //        {

            //            LogInfo.LogMsg = string.Format("Home / SaveVideoListData : {0} Message: {1} ", "", ex.Message);
            //            Log.Error(LogInfo.LogMsg, ex);
            //            return Json(new { errorcode = -1, errormessage = ex.Message }, JsonRequestBehavior.AllowGet);
            //        }

            //    }
            //}
            //else
            //{
            //    result = kaisokku_businesslayer.SaveVideoListData(VideoId, VideoTitle, VideoDesc, false);
            //    result = kaisokku_businesslayer.SaveCreateVideoFileList(ExistingVideoName, VideoId, IsResetCount,false);
            //}


            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ViewFileVideoListById(video obj)
        {
            TempData["showClientMenu"] = null;
            video result = kaisokku_businesslayer.GetVideoById(obj);

            return View("ViewVideo", result);
        }
        public ActionResult ViewVideoListDataById(video obj)
        {
            TempData["showClientMenu"] = null;
            video result = kaisokku_businesslayer.GetVideoById(obj);

            //var dplist = result.Filename.ToList();
            //SelectList list = new SelectList(dplist, "filename", "filename");
            //List<video> SelectVideonew = kaisokku_businesslayer.GetVideoListById(obj);
            List<video> SelectVideonew = new List<video>();
            video vdfile = new video();
            vdfile.Filename = result.PlayVideoFileName;
            SelectVideonew.Add(vdfile);
            var list = new SelectList(SelectVideonew, "Filename", "Filename");
            //List<System.Web.Mvc.SelectListItem> SelectVideo = new List<System.Web.Mvc.SelectListItem>()
            //{
            //    //new SelectListItem 
            //    //{
            //    //       Text = videolist,
            //    //       Value = videolist.Filename
            //    //   },
            //};

            TempData["SelectVideo"] = list;

            return View("ViewVideo", result);
        }
        public ActionResult CreateVideoListData()
        {
            TempData["showClientMenu"] = null;
            video result = new video();
            BindVideoUserType(0);
            return View(result);
        }
        public ActionResult GetVideoListDataById(video obj)
        {
            TempData["showClientMenu"] = null;
            video result = kaisokku_businesslayer.GetVideoById(obj);

            List<video> SelectVideonew = new List<video>();
            video vdfile = new video();
            vdfile.Filename = result.PlayVideoFileName;
            SelectVideonew.Add(vdfile);
            BindVideoUserType(result.Usertype);
            //List<video> SelectVideonew = kaisokku_businesslayer.GetVideoListById(obj);
            var list = new SelectList(SelectVideonew, "Filename", "Filename");

            TempData["SelectVideo"] = list;
            return View("VideoCreate", result);
        }
       
        public void BindVideoUserType(int? val)
        {
            var selectList = new List<SelectListItem>();
            if (val == 0)
            {
                selectList.Add(new SelectListItem
                {
                    Value = "0",
                    Text = "None",
                    Selected=true
                });
            }
            else
            {
                selectList.Add(new SelectListItem
                {
                    Value = "0",
                    Text = "None"
                    
                });
            }
           if(val == 1)
            {
                selectList.Add(new SelectListItem
                {
                    Value = "1",
                    Text = "Existing",
                    Selected = true
                });

            }
            else
            {
                selectList.Add(new SelectListItem
                {
                    Value = "1",
                    Text = "Existing"
                });
            }
            if (val == 2)
            {
                selectList.Add(new SelectListItem
                {
                    Value = "2",
                    Text = "General",
                    Selected = true
                });
            }
            else
            {
                selectList.Add(new SelectListItem
                {
                    Value = "2",
                    Text = "General"
                });

            }
          
            

           
            ViewBag.UserType = selectList;
        }

        #endregion

        #region Sabeena PPT Management
        [HttpGet]
        [Authorize]
        public ActionResult PPTManagement()
        {
            TempData["showClientMenu"] = null;
            try
            {
                kaisokku_businesslayer.SaveActivity(Convert.ToString(Session["UserId"]), Convert.ToString(Session["UserName"]), (int)MenusActivity.PPTManagement, "PPT Management");
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("Home / Widgets : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }

            

            //Application pptApplication = new Application();
            //Microsoft.Office.Interop.PowerPoint.Presentation pptPresentation = pptApplication.Presentations
            //.Open(@"E:\jjj.pptx", MsoTriState.msoFalse, MsoTriState.msoFalse
            //, MsoTriState.msoFalse);

            //for (int i = 0; i < pptPresentation.Slides.Count; i++)
            //{
            //    string OutputPagePathFormat = Path.Combine("E:\\output123", i+1+".png");
            //    pptPresentation.Slides[i+1].Export(OutputPagePathFormat, "png", 1024, 768);
            //}



            return View();
        }
        public ActionResult LoadPPTListData(jQueryDataTableParamModel<PPT> param)
        {
            TempData["showClientMenu"] = null;
            try
            {

                var draw = param.draw;

                int recordsTotal = 0;

                // Getting all Customer data    
                var result = kaisokku_businesslayer.ShowGridPpts();

                //total number of rows count     
                recordsTotal = result.Count();
                //Paging     
                //var data = result.Skip(skip).Take(pageSize).ToList();
                var data = result.ToList();
                //Returning Json Data    
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpGet]
        [Authorize]
        public ActionResult DownLoad()
        {
            TempData["showClientMenu"] = null;
            var ppt = Request.QueryString["ppt"];
            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath("~/PPT/" + ppt));

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, ppt);
        }
        public JsonResult DeletePPTById(PPT obj)
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();

            result = kaisokku_businesslayer.DeletePPT(obj.MediaID);


            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveCreatePPTListData()
        {
            try
            {
                TempData["showClientMenu"] = null;
                OutPut result = new OutPut();
                // OutPut mediaid = new OutPut();
                var VideoTitle = Request.Form["VideoTitle"];
                var VideoDesc = Request.Form["VideoDesc"];
                string path = Server.MapPath("~/PPT/");
                HttpFileCollectionBase files = Request.Files;

                result = kaisokku_businesslayer.SaveCreatePPTListData(VideoTitle, VideoDesc, path);

                var mediaid = kaisokku_businesslayer.GetPPTId();
                var fileid = mediaid.MediaID;

                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];

                    string filename = "";
                    string[] filepatharray = file.FileName.Split('\\');
                    filename = filepatharray[filepatharray.Count() - 1];

                    LogInfo.LogMsg = string.Format("path: {0} ",path);
                    Log.Info(LogInfo.LogMsg);

                    LogInfo.LogMsg = string.Format("file.FileName: {0} ", filename);
                    Log.Info(LogInfo.LogMsg);
                    
                    file.SaveAs(path + filename);
                    result = kaisokku_businesslayer.SaveCreatePPTFileList(filename, fileid);

                    try
                    {



                        LogInfo.LogMsg = string.Format("SaveCreatePPTFileList: {0} ", "save create ppt");
                        Log.Info(LogInfo.LogMsg);

                        LogInfo.LogMsg = string.Format("pathcombine: {0} ", Path.Combine(path, filename));
                        Log.Info(LogInfo.LogMsg);

                        Application pptApplication = new Application();

                        LogInfo.LogMsg = string.Format("pptApplication: {0} ", "object created");
                        Log.Info(LogInfo.LogMsg);

                        Presentation pptPresentation = pptApplication.Presentations.Open(Path.Combine(path, filename), MsoTriState.msoFalse, MsoTriState.msoFalse
                        , MsoTriState.msoFalse);

                        LogInfo.LogMsg = string.Format("pptApplication: {0} ", "ppt failed");
                        Log.Info(LogInfo.LogMsg);

                        if (!Directory.Exists(Path.Combine(path, filename.Split('.')[0])))
                        {
                            Directory.CreateDirectory(Path.Combine(path, filename.Split('.')[0]));
                        }

                        for (int J = 0; J < pptPresentation.Slides.Count; J++)
                        {

                            string OutputPagePathFormat = Path.Combine(path + filename.Split('.')[0], J + 101 + ".png");
                            pptPresentation.Slides[J + 1].Export(OutputPagePathFormat, "png", 1024, 768);
                            
                        }

                        for (int J = 0; J < pptPresentation.Slides.Count; J++)
                        {
                            LogInfo.LogMsg = string.Format("jpg path: {0} ", path);
                            Log.Info(LogInfo.LogMsg);

                            string OutputPagePathFormat = Path.Combine(path, J + 101 + ".png");

                            LogInfo.LogMsg = string.Format("OutputPagePathFormat: {0} ", OutputPagePathFormat);
                            Log.Info(LogInfo.LogMsg);

                            pptPresentation.Slides[J + 1].Export(OutputPagePathFormat, "png", 1024, 768);
                        }


                    }
                    catch (Exception ex)
                    {

                        LogInfo.LogMsg = string.Format("Home / SaveCreatePPTListData : {0} Message: {1} ", "", ex.Message);
                        Log.Error(LogInfo.LogMsg, ex);
                    }

                }
                return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Home / SaveCreatePPTListData : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return Json(new { errorcode = -1, errormessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
           
        }
        public JsonResult SavePPTListData()
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();

            var VideoTitle = Request.Form["VideoTitle"];
            var VideoDesc = Request.Form["VideoDesc"];
            int VideoId = Int32.Parse(Request.Form["VideoId"]);
            string path = Server.MapPath("~/PPT/");
            HttpFileCollectionBase files = Request.Files;

            result = kaisokku_businesslayer.SavePPTListData(VideoId, VideoTitle, VideoDesc);

            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];
                file.SaveAs(path + file.FileName);
                result = kaisokku_businesslayer.SaveCreatePPTFileList(file.FileName, VideoId);
            }

            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize]
        public ActionResult ShowAdminPPT(string PPTFolder)
        {
            TempData["showClientMenu"] = null;
            try
            {
                string folderPath = Path.Combine(Server.MapPath("~/PPT/"), PPTFolder);
                string[] filePaths = Directory.GetFiles(@folderPath, "*.png");
                ViewBag.fileCount = filePaths.Count();
                ViewBag.PPTFolder = PPTFolder;
                string[] rootpaths = Request.Url.AbsolutePath.Split('/');
                string rootpath = "/";
                if (rootpaths[1] == "Home")
                {
                    rootpath = "";
                }
                else
                {
                    rootpath = "/" + rootpaths[1];
                }
                ViewBag.rootpath = rootpath;
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Home / ShowAdminPPT : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }
            
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult ShowClientPPT(string PPTFolder)
        {
            TempData["showClientMenu"] = true;
            try
            {
                string folderPath = Path.Combine(Server.MapPath("~/PPT/"), PPTFolder);
            }
            catch (Exception ex )
            {
                LogInfo.LogMsg = string.Format("Home / ShowClientPPT : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }

            return View();
        }


        

        public ActionResult ViewFilePPTListById(PPT obj)
        {
            TempData["showClientMenu"] = null;
            PPT result = kaisokku_businesslayer.GetPPTById(obj);
            return View("ViewPPT", result);
        }
        public ActionResult ViewPPTListDataById(PPT obj)
        {
            TempData["showClientMenu"] = null;
            PPT result = kaisokku_businesslayer.GetPPTById(obj);

            //var dplist = result.Filename.ToList();
            //SelectList list = new SelectList(dplist, "filename", "filename");
            List<PPT> SelectVideonew = kaisokku_businesslayer.GetPPTListById(obj);
            var list = new SelectList(SelectVideonew, "Filename", "Filename");
            //List<System.Web.Mvc.SelectListItem> SelectVideo = new List<System.Web.Mvc.SelectListItem>()
            //{
            //    //new SelectListItem 
            //    //{
            //    //       Text = videolist,
            //    //       Value = videolist.Filename
            //    //   },
            //};

            TempData["SelectVideo"] = list;

            return View("ViewPPT", result);
        }
        public ActionResult CreatePPTListData()
        {
            TempData["showClientMenu"] = null;
            return View();
        }
        public ActionResult GetPPTListDataById(PPT obj)
        {
            TempData["showClientMenu"] = null;
            PPT result = kaisokku_businesslayer.GetPPTById(obj);
            List<PPT> SelectVideonew = kaisokku_businesslayer.GetPPTListById(obj);
            var list = new SelectList(SelectVideonew, "Filename", "Filename");

            TempData["SelectVideo"] = list;
            return View("PPTCreate", result);
        }
        #endregion

        #region Monisha Task Management
        [HttpGet]
        [Authorize]
        public ActionResult KaisokkuSampleReports(string PageMenuName = "", int MID = 0)
        {
            TempData["showClientMenu"] = null;
            try
            {
                kaisokku_businesslayer.SaveActivity(Convert.ToString(Session["UserId"]), Convert.ToString(Session["UserName"]), (int)MenusActivity.TaskManagement, "TaskManagement");
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("Home / Widgets : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }

            return View();
        }

        public ActionResult GetTaskListDataById(Tasks obj)
        {
            TempData["showClientMenu"] = null;
            Tasks result = kaisokku_businesslayer.GetTaskById(obj);

            List<UserManagements> SelectVideonew = kaisokku_businesslayer.GetUserList();
            var list = new SelectList(SelectVideonew, "userid", "username");

            TempData["SelectUser"] = list;
            return View("TaskCreate", result);
        }
        public ActionResult CreateTaskListData()

        {
            TempData["showClientMenu"] = null;
            List<UserManagements> SelectVideonew = kaisokku_businesslayer.GetUserList();
            var list = new SelectList(SelectVideonew, "userid", "username");

            TempData["SelectUser"] = list;
            return View();
        }

        public JsonResult SaveTaskListData()
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();

            var TaskTitle = Request.Form["TaskName"];
            var TaskDesc = Request.Form["TaskDescription"];
            var UserID = Request.Form["userid"];
            int Taskid = Int32.Parse(Request.Form["Taskid"]);

            result = kaisokku_businesslayer.SaveTaskListData(TaskTitle, TaskDesc, UserID, Taskid);

            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveCreateTaskListData(string TaskName, string TaskDescription, int userid)
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();

            result = kaisokku_businesslayer.SaveCreateTaskListData(TaskName, TaskDescription, userid);

            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteTaskById(Tasks obj)
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();

            result = kaisokku_businesslayer.DeleteTask(obj.TaskMasterId);


            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LoadTaskListData(jQueryDataTableParamModel<Tasks> param)
        {
            TempData["showClientMenu"] = null;
            try
            {

                var draw = param.draw;

                int recordsTotal = 0;

                var result = kaisokku_businesslayer.ShowGridTasks();

                recordsTotal = result.Count();

                var data = result.ToList();

                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region Bharathiraja-Activity Management
        [HttpGet]
        [Authorize]
        public ActionResult ActivityManagement()
        {
            TempData["showClientMenu"] = null;

            return View();
        }


        public JsonResult ViewLogHistory(jQueryDataTableParamModel<ViewLogHistory> param)
        {
            TempData["showClientMenu"] = null;
            List<ViewLogHistory> lstActivity = new List<ViewLogHistory>();
            try
            {

                var draw = param.draw;
                int recordsTotal = 0;
                // Getting all Customer data    
                var result = kaisokku_businesslayer.ShowActivityCount();
                recordsTotal = result.Count();
                var data = result.ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Home / ViewLogHistory : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                throw;
            }



        }

        public JsonResult GetViewLogHistoryById(jQueryDataTableParamModel<ShowAllActivity> param, int MenuId)
        {
            TempData["showClientMenu"] = null;
            try
            {

                var draw = param.draw;
                int recordsTotal = 0;
                // Getting all Customer data    
                var result = kaisokku_businesslayer.GetViewLogHistoryById(MenuId);
                recordsTotal = result.Count();
                var data = result.ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Home / GetViewLogHistoryById : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                throw;
            }
        }


        #endregion

        #region Balraj-FullKeySearch
        public JsonResult SearchMenus(string SearchMenu)
        {

            List<SearchDetails> lstsearch = new List<SearchDetails>();
            List<SearchDetailsClient> lstsearchclient = new List<SearchDetailsClient>();
            try
            {
                if (Convert.ToBoolean( TempData["showClientMenu"])==false || TempData["showClientMenu"]==null )
                {
                    
                    if (string.IsNullOrEmpty(SearchMenu))
                    {
                        return Json(null, JsonRequestBehavior.AllowGet);
                    }

                    lstsearch = kaisokku_businesslayer.MenuSearch(SearchMenu);
                    return Json(new { IsAdminMenu = true, MenuList = lstsearch }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    TempData["showClientMenu"]= true;
                    if (string.IsNullOrEmpty(SearchMenu))
                    {
                        return Json(null, JsonRequestBehavior.AllowGet);
                    }

                    lstsearchclient = kaisokku_businesslayer.MenuSearchForClient(SearchMenu);
                    return Json(new { IsAdminMenu =false , MenuList = lstsearchclient }, JsonRequestBehavior.AllowGet);
                }

                
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("Home / SearchMenus : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);

                return Json(null, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion


        #region Bharathiraja CRM-Contact
        [HttpGet]
        [Authorize]
        public ActionResult CRMContact()
        {
            TempData["showClientMenu"] = null;
            try
            {
                kaisokku_businesslayer.SaveActivity(Convert.ToString(Session["UserId"]), Convert.ToString(Session["UserName"]), (int)MenusActivity.CRMContact, "CRM Contact");
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("Home / CRMContact : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }
            return View();
        }


        #endregion


        #region Sabeena Doc Management

        [HttpGet]
        [Authorize]
        public ActionResult DocManagement()
        {
            TempData["showClientMenu"] = null;
            try
            {
                 kaisokku_businesslayer.SaveActivity(Convert.ToString(Session["UserId"]), Convert.ToString(Session["UserName"]), (int)MenusActivity.DocManagement, "Document Management");
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("Home / Widgets : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }

            return View();
        }
        public ActionResult LoadDocListData(jQueryDataTableParamModel<Document> param)
        {
            TempData["showClientMenu"] = null;
            try
            {

                var draw = param.draw;

                int recordsTotal = 0;

                // Getting all Customer data    
                var result = kaisokku_businesslayer.ShowGridDocs();

                //total number of rows count     
                recordsTotal = result.Count();
                //Paging     
                //var data = result.Skip(skip).Take(pageSize).ToList();
                var data = result.ToList();
                //Returning Json Data    
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpGet]
        [Authorize]
        public ActionResult DocDownLoad()
        {
            TempData["showClientMenu"] = null;
            var ppt = Request.QueryString["ppt"];
            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath("~/Document/" + ppt));

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, ppt);
        }
        public JsonResult DeleteDocById(PPT obj)
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();

            result = kaisokku_businesslayer.DeleteDoc(obj.MediaID);


            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveCreateDocListData()
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();
            // OutPut mediaid = new OutPut();
            var VideoTitle = Request.Form["VideoTitle"];
            var VideoDesc = Request.Form["VideoDesc"];
            string path = Server.MapPath("~/Document/");
            HttpFileCollectionBase files = Request.Files;

            result = kaisokku_businesslayer.SaveCreateDocListData(VideoTitle, VideoDesc, path);

            var mediaid = kaisokku_businesslayer.GetDocId();
            var fileid = mediaid.MediaID;

            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];
                file.SaveAs(path + file.FileName);
                result = kaisokku_businesslayer.SaveCreateDocFileList(file.FileName, fileid);
            }

            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SaveDocListData()
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();

            var VideoTitle = Request.Form["VideoTitle"];
            var VideoDesc = Request.Form["VideoDesc"];
            int VideoId = Int32.Parse(Request.Form["VideoId"]);
            string path = Server.MapPath("~/Document/");
            HttpFileCollectionBase files = Request.Files;

            result = kaisokku_businesslayer.SaveDocListData(VideoId, VideoTitle, VideoDesc);

            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];
                file.SaveAs(path + file.FileName);
                result = kaisokku_businesslayer.SaveCreateDocFileList(file.FileName, VideoId);
            }

            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ViewFileDocListById(Document obj)
        {
            TempData["showClientMenu"] = null;
            Document result = kaisokku_businesslayer.GetDocById(obj);
            return View("ViewPPT", result);
        }
        public ActionResult ViewDocListDataById(Document obj)
        {
            TempData["showClientMenu"] = null;
            Document result = kaisokku_businesslayer.GetDocById(obj);

            //var dplist = result.Filename.ToList();
            //SelectList list = new SelectList(dplist, "filename", "filename");
            List<Document> SelectVideonew = kaisokku_businesslayer.GetDocListById(obj);
            var list = new SelectList(SelectVideonew, "Filename", "Filename");
            //List<System.Web.Mvc.SelectListItem> SelectVideo = new List<System.Web.Mvc.SelectListItem>()
            //{
            //    //new SelectListItem 
            //    //{
            //    //       Text = videolist,
            //    //       Value = videolist.Filename
            //    //   },
            //};

            TempData["SelectDoc"] = list;

            return View("ViewDoc", result);
        }
        public ActionResult CreateDocListData()
        {
            TempData["showClientMenu"] = null;
            return View();
        }
        public ActionResult GetDocListDataById(Document obj)
        {
            TempData["showClientMenu"] = null;
            Document result = kaisokku_businesslayer.GetDocById(obj);
            List<Document> SelectVideonew = kaisokku_businesslayer.GetDocListById(obj);
            var list = new SelectList(SelectVideonew, "Filename", "Filename");

            TempData["SelectDoc"] = list;
            return View("DocCreate", result);
        }
        [HttpGet]
        [Authorize]
        public ActionResult DownLoadDoc()
        {
            TempData["showClientMenu"] = null;
            var Doc = Request.QueryString["doc"];
            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath("~/Document/" + Doc));

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, Doc);
        }

        #endregion

        #region bulkCRM
        public JsonResult AddCRMContentInformation(CRMContent obj)
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();
            try
            {
                obj.CreatedBy = Convert.ToString(Session["UserName"]);
                result = kaisokku_businesslayer.AddCRMContentInformation(obj);
                return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("Home / AddCRMContentInformation : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);

                return Json(new { errorcode = "1", errormessage = "Unable to insert" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetCRMLastUserId()
        {
            TempData["showClientMenu"] = null;
            string LastUserId = string.Empty;
            try
            {
                LastUserId = kaisokku_businesslayer.GetCRMLastUserId();
                return Json(LastUserId, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("Home / GetCRMLastUserId : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);

                return Json("nouserid", JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult LoadCRMListData(jQueryDataTableParamModel<ShowPageGrid> param)
        {
            try
            {
                TempData["showClientMenu"] = null;
                var draw = param.draw;
                int recordsTotal = 0;
                // Getting all Customer data    
                var result = kaisokku_businesslayer.GetCRMUserDetails();
                recordsTotal = result.Count();
                var data = result.ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult GetCRMListDataById(EditCRMDetails obj)
        {
            TempData["showClientMenu"] = null;
            EditCRMDetails result = kaisokku_businesslayer.GetCRMListDataById(obj);
            return PartialView("EditCRMListData", result);
        }

        public JsonResult DeleteCRMById(int UserCustomId)
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();
            try
            {
                result = kaisokku_businesslayer.DeleteCRMById(UserCustomId);

            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Home / Menu : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }

            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateBulkimportList()
        {
            TempData["showClientMenu"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult importbullkcontact(System.Data.DataTable dt)
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();
            // OutPut mediaid = new OutPut();

            string filePath = string.Empty;
            string path = Server.MapPath("~/Files/");
            HttpFileCollectionBase files = Request.Files;

            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];
                file.SaveAs(path + file.FileName);
                //  result = kaisokku_businesslayer.SaveCreatePPTFileList(file.FileName, fileid);
                filePath = path + Path.GetFileName(file.FileName);
                string extension = Path.GetExtension(file.FileName);

                //DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("ContactName", typeof(string)),
                                new DataColumn("CompanyName", typeof(string)),
                                new DataColumn("Email",typeof(string)) });

                string csvData = System.IO.File.ReadAllText(filePath);
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        dt.Rows.Add();
                        int j = 0;

                        //Execute a loop over the columns.
                        foreach (string cell in row.Split(','))
                        {
                            dt.Rows[dt.Rows.Count - 1][j] = cell;
                            j++;
                        }
                    }
                }
                var res = kaisokku_businesslayer.GetCRMBulkImport(dt);

            }
            return Json(new { errorcode = "0", errormessage = "Sucess" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveCRMListData(int UserCustomId, string ContactName, string CompanyName, string Email)
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();

            result = kaisokku_businesslayer.SaveCRMListData(UserCustomId, ContactName, CompanyName, Email);

            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public ActionResult LoadTaskListDatas(jQueryDataTableParamModel<Tasks> param)
        {
            TempData["showClientMenu"] = null;
            try
            {

                var draw = param.draw;

                int recordsTotal = 0;

                var result = kaisokku_businesslayer.ShowGridRepTasks(Convert.ToString(Session["UserName"]));

                recordsTotal = result.Count();

                var data = result.ToList();

                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpPost]
        public void UpdateVideoCount(int mediaID)
        {
            try
            {
                var result = kaisokku_businesslayer.UpdateVideoCount(mediaID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public JsonResult DeleteCRMById(int UserCustomId)
        //{
        //    TempData["showClientMenu"] = null;
        //    OutPut result = new OutPut();
        //    try
        //    {
        //        result = kaisokku_businesslayer.DeleteCRMById(UserCustomId);

        //    }
        //    catch (Exception ex)
        //    {
        //        LogInfo.LogMsg = string.Format("Home / Menu : {0} Message: {1} ", "", ex.Message);
        //        Log.Error(LogInfo.LogMsg, ex);
        //    }

        //    return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        //}


        [HttpGet]
        [Authorize]
        public ActionResult RegisteredTaskExport()
        {
            TempData["showClientMenu"] = null;

            return View();
         }
        public enum MenusActivity
        {
            DashBoard = 1,
            UserManagement = 2,
            //VideoManagement = 80,
            PPTManagement = 5,
            //KaisokkuSampleReport = 6,
            TaskManagement = 18,
            PageManagement = 7,
            MenuManagement = 8,
            ActivityManagement = 9,
            CRM = 22,
            SocialMedia = 11,
            Reports = 12,
            HitCounter = 13,
            KaisokkuSampleReportsSample1 = 18,
            CRM1=22,
            SocialMedia1=23,
            ManageVideos=80,
            ManageComments=83,
            RegisteredTaskReport=85,
            CRMContact=109,
            DocManagement=115
        }

    }
}

