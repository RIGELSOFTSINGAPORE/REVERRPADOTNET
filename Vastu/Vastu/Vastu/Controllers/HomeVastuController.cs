using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vasthu_Models;
using Vastu_Business;

namespace Vastu.Controllers
{
    [SessionExpire]
    [Authorize]
    [VASTUCustomAuthorize(Roles = "1,2")]
    public class HomeVastuController : Controller
    {
        private HomeVastuBusinessLayer _HomeVastuBusinessLayer;
        public HomeVastuController()
        {

            _HomeVastuBusinessLayer = new HomeVastuBusinessLayer();
        }
        
        // GET: HomeVastu
        public ActionResult Index()
        {
            ViewBag.HomeVastu = "HomeVastu";
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<MasterHomeVastuContent> obj = new List<MasterHomeVastuContent>();
            try
            {

                obj = _HomeVastuBusinessLayer.GetHomeVastuInformation();

                //var htmlString1 = HttpUtility.HtmlDecode(obj[0].ContentName);


                // string x = FindandReplace.SafeReplaceStartDIV(htmlString1, "<div>&nbsp;</div>", "<br>", true);

                // var htmlString2 = HttpUtility.HtmlDecode(x);

                //string y= FindandReplace.SafeReplaceRemoveNonBreakSpace(htmlString2);

                //var htmlString3 = HttpUtility.HtmlDecode(y);

                //string z = FindandReplace.SafeReplaceStartDIV(htmlString2, "<div>", "", true);


                //string finalresult = FindandReplace.SafeReplaceCloseDIV(z, "</div>", "&nbsp;", true);
                //obj[0].ContentName = finalresult;

                if (obj.Count > 0)
                {
                    if (obj[0].ContentName.ToLower().Contains("&nbsp;"))
                    {
                        string first = FindandReplace.SafeReplaceStartDIV(obj[0].ContentName, "<div>", "", true);
                        string second = FindandReplace.SafeReplaceCloseDIV(first, "</div>", "", true);
                        obj[0].ContentName = second;
                    }
                    else
                    {

                    }
                }


            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("HomeVastu / Index : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = "error msg";
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            return View(obj); ;
        }
    }
}