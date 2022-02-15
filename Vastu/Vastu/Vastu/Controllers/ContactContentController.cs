using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vasthu_Models;
using Vastu.Models;
using Vastu_Business;

namespace Vastu.Controllers
{
    [SessionExpire]
    [Authorize]
    [VASTUCustomAuthorize(Roles = "1")]
    public class ContactContentController : Controller
    {
        // GET: ContactContent
        private ContactBusinessLayer _ContactContentBusinessLayer;

        public ContactContentController()
        {

            _ContactContentBusinessLayer = new ContactBusinessLayer();
        }
        public ActionResult Index()
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<MasterAboutContent> obj = new List<MasterAboutContent>();
            try
            {
                obj = _ContactContentBusinessLayer.GetHomeContent();
                obj.Insert(0, new MasterAboutContent { ContentID = 0, ContentName = Vastu.Resources.Resource.Select });
                ViewBag.About = obj;
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("AboutContent / Index : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            return View();
        }

        public JsonResult LoadSelectedAboutContent(string ContentID)
        {
            List<MstrAboutContent> obj = new List<MstrAboutContent>();
            try
            {
                obj = _ContactContentBusinessLayer.LoadDescription(Convert.ToInt32(ContentID));

                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("AboutContent / LoadSelectedVastuTipContent : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }
            return Json(new { errorcode = "-1", errormessage = "failure" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SavePageInformation(Models.SaveAboutContent savecontent)
        {
            int result = 0;
            try
            {
                Vasthu_Models.SaveAboutContent cont = new Vasthu_Models.SaveAboutContent();
                cont.ContentID = savecontent.ContentID;
                cont.ContentDescription = savecontent.ContentDescription;
                result = _ContactContentBusinessLayer.SaveContentInformation(cont);
                return Json(new { errorcode = result, errormessage = "Successfully Saved" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("HomeContent / SavePageInformation : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);

            }
            return Json(new { errorcode = -1, errormessage = "Unable to save" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteContentById(string ContentID)
        {
            int result = 0;
            try
            {
                result = _ContactContentBusinessLayer.DeleteContentById(Convert.ToInt32(ContentID));
                return Json(new { errorcode = result, errormessage = "Successfully Saved" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("HomeContent / DeleteContentById : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);

            }
            return Json(new { errorcode = -1, errormessage = "Unable to delete" }, JsonRequestBehavior.AllowGet);
        }
    }
}