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
    public class VastuTipsContentController : Controller
    {
        private VastuTipsContentBusinessLayer _VastuTipsContentBusinessLayer;
        public VastuTipsContentController()
        {

            _VastuTipsContentBusinessLayer = new VastuTipsContentBusinessLayer();
        }
        public ActionResult Index()
        {
         
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<MasterVastuTipsContent> obj = new List<MasterVastuTipsContent>();
            try
            {
                obj = _VastuTipsContentBusinessLayer.GetHomeContent();
                obj.Insert(0, new MasterVastuTipsContent { ContentID = 0, ContentName = Vastu.Resources.Resource.Select });
                ViewBag.VastuTips = obj;
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("HomeContent / Index : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            return View();
        }

        public JsonResult LoadSelectedVastuTipContent(string ContentID)
        {
            List<MstrVastuTipsContent> obj = new List<MstrVastuTipsContent>();
            try
            {
                obj = _VastuTipsContentBusinessLayer.LoadDescription(Convert.ToInt32(ContentID));

                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("HomeContent / LoadSelectedContent : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }
            return Json(new { errorcode = "-1", errormessage = Vastu.Resources.Resource.failure }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SavePageInformation(SaveVastuTipContent savecontent)
        {
            int result = 0;
            try
            {
                SaveVastuTipsContent cont = new SaveVastuTipsContent();
                cont.ContentID = savecontent.ContentID;
                cont.ContentDescription = savecontent.ContentDescription;
                result = _VastuTipsContentBusinessLayer.SaveContentInformation(cont);
                return Json(new { errorcode = result, errormessage = Vastu.Resources.Resource.SuccessfullySaved }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("HomeContent / SavePageInformation : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);

            }
            return Json(new { errorcode = -1, errormessage = Vastu.Resources.Resource.Unabletosave }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteContentById(string ContentID)
        {
            int result = 0;
            try
            {
                result = _VastuTipsContentBusinessLayer.DeleteContentById(Convert.ToInt32(ContentID));
                return Json(new { errorcode = result, errormessage = Vastu.Resources.Resource.SuccessfullySaved }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("HomeContent / DeleteContentById : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);

            }
            return Json(new { errorcode = -1, errormessage = Vastu.Resources.Resource.Unabletodelete }, JsonRequestBehavior.AllowGet);
        }
    }
}