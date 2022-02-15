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
    public class HomeVastuContentController : Controller
    {

        private HomeVastuContentBusinessLayer _HomeVastuContentBusinessLayer;
        public HomeVastuContentController()
        {

            _HomeVastuContentBusinessLayer = new HomeVastuContentBusinessLayer();
        }

        public ActionResult Index()
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<MasterHomeVastuContent> obj = new List<MasterHomeVastuContent>();
            try
            {
                obj = _HomeVastuContentBusinessLayer.GetHomeContent();
                obj.Insert(0, new MasterHomeVastuContent { ContentID = 0, ContentName = Vastu.Resources.Resource.Select });
                ViewBag.HomeVastu = obj;
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("HomeVastuContent / Index : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            return View();
        }

        public JsonResult LoadSelectedHomeVastuContent(string ContentID)
        {
            List<MstrHomeVastuContent> obj = new List<MstrHomeVastuContent>();
            try
            {
                obj = _HomeVastuContentBusinessLayer.LoadDescription(Convert.ToInt32(ContentID));

                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("HomeVastuContent / LoadSelectedContent : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }
            return Json(new { errorcode = "-1", errormessage = Vastu.Resources.Resource.failure }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SavePageInformation(SaveHomeVastuContent savecontent)
        {
            int result = 0;
            try
            {
                SaveHomeVastuContent1 cont = new SaveHomeVastuContent1();
                cont.ContentID = savecontent.ContentID;
                cont.ContentDescription = savecontent.ContentDescription;
                result = _HomeVastuContentBusinessLayer.SaveContentInformation(cont);
                return Json(new { errorcode = result, errormessage = Vastu.Resources.Resource.SuccessfullySaved }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("HomeVastuContent / SavePageInformation : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);

            }
            return Json(new { errorcode = -1, errormessage = Vastu.Resources.Resource.Unabletosave }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteContentById(string ContentID)
        {
            int result = 0;
            try
            {
                result = _HomeVastuContentBusinessLayer.DeleteContentById(Convert.ToInt32(ContentID));
                return Json(new { errorcode = result, errormessage = Vastu.Resources.Resource.SuccessfullySaved }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("HomeVastuContent / DeleteContentById : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);

            }
            return Json(new { errorcode = -1, errormessage = Vastu.Resources.Resource.Unabletodelete }, JsonRequestBehavior.AllowGet);
        }
    }
}