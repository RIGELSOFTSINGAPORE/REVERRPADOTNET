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
    public class FeedbackController : Controller
    {
        private FeedbackBusinessLayer _FeedbackBusinessLayer;
        public FeedbackController()
        {

            _FeedbackBusinessLayer = new FeedbackBusinessLayer();
        }
        

        // GET: Feedback
        public ActionResult Index()
        {
            ViewBag.Feedback2 = "Feedback";
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<Feedback> Feedback = new List<Feedback>();
            try
            {

                // _FeedbackBusinessLayer.Test();
                Feedback = _FeedbackBusinessLayer.feedback();
                ViewBag.feedback = Feedback;

            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Feedback / Index : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = "error msg";
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            return View(); 
        }
        //public ActionResult SaveFeedback(string name,string address,string comment,string city,string state,string country,string file)
        public JsonResult SaveFeedback()
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;
            try
            {
                var name = Request.Form["name"];
                var lname = Request.Form["lname"];
                var address = Request.Form["address"];
                var comment = Request.Form["comment"];
                var city = Request.Form["city"];
                var state = Request.Form["state"];
                var country = Request.Form["country"];
                int UserID = Convert.ToInt32(Session["USER_ID"].ToString());

                string path = Server.MapPath("~/Photo/");
                HttpFileCollectionBase files = Request.Files;
                if (files.Count > 0)
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];

                        file.SaveAs(path + file.FileName);

                        result = _FeedbackBusinessLayer.savefeedback(name,lname, address, comment, city, state, country,file.FileName, UserID);
                    }
                }
                else
                {
                    result = _FeedbackBusinessLayer.savefeedback(name,lname, address, comment, city, state, country, "empty.png", UserID);
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Feedback / Index : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = "error msg";
            }
            return Json(new { errorcode = result }, JsonRequestBehavior.AllowGet);
        }
    }
}