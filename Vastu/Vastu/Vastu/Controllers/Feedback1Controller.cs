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
    public class Feedback1Controller : Controller
    {
        // GET: Feedback1
        private FeedbackBusinessLayer _FeedbackBusinessLayer;
        public Feedback1Controller()
        {

            _FeedbackBusinessLayer = new FeedbackBusinessLayer();
        }
        public ActionResult Index()
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<Feedback> Feedback = new List<Feedback>();
            try
            {

                Feedback = _FeedbackBusinessLayer.feedback();
                ViewBag.feedback = Feedback;

            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("HomeVastu / Index : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = "error msg";
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            return View(); ;
        }
    }
}