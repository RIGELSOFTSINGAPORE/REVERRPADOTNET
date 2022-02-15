using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Vasthu_Models;
using Vastu_Business;
using System.Globalization;
using System.Threading;

namespace Vastu.Controllers
{
    [HandleError]
    [SessionExpire]
    [Authorize]
    [VASTUCustomAuthorize(Roles = "1,2")]
    public class HomeController : Controller
    {
        private HomeBusinessLayer _HomeBusinessLayer;
        public HomeController()
        {

            _HomeBusinessLayer = new HomeBusinessLayer();
        }
        public ActionResult Index()
        {
           
            ViewBag.Home = "Home";
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<MasterContent> obj = new List<MasterContent>();
            try
            {

                obj= _HomeBusinessLayer.GetHomePageInformation();
               
           
                if (obj.Count > 0)
                {

                    string x = FindandReplace.SafeReplaceStartDIV(obj[0].ContentName, "<div>", "", true);
                    string y = FindandReplace.SafeReplaceCloseDIV(x, "</div>", "&nbsp;", true);
                    obj[0].ContentName = y;
                }

            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Home / Index : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = "error msg";
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            return View(obj);
        }
        //public string SafeReplace(this string input, string find, string replace, bool matchWholeWord)
        //{
        //    string textToFind = matchWholeWord ? string.Format(@"\b{0}\b", find) : find;

        //    return Regex.Replace(input, textToFind, replace);
        //}
        
    }
}