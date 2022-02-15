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
    public class ContactController : Controller
    {
        private ContactContentBusinessLayer _ContactBusinessLayer;
        public ContactController()
        {
            _ContactBusinessLayer = new ContactContentBusinessLayer();
        }


        // GET: Contact
        public ActionResult Index()
        {
            ViewBag.Contact = "Contact";
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<MasterContent> obj = new List<MasterContent>();
            try
            {

                obj = _ContactBusinessLayer.GetHomePageInformation();


                if (obj.Count > 0)
                {

                    string x = FindandReplace.SafeReplaceStartDIV(obj[0].ContentName, "<div>", "", true);
                    string y = FindandReplace.SafeReplaceCloseDIV(x, "</div>", "&nbsp;", true);
                    obj[0].ContentName = y;
                }

            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("About / Index : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = "error msg";
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            return View(obj);
        }
    }
}