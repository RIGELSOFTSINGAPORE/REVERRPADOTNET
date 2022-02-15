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
    public class BusinessVastuController : Controller
    {
        private BusinessVastuBusineesLayer _BusinessVastuBusineesLayer;
        public BusinessVastuController()
        {

            _BusinessVastuBusineesLayer = new BusinessVastuBusineesLayer();
        }


        // GET: BusinessVastu
        public ActionResult Index()
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {

                //_BusinessVastuBusineesLayer.Test();

            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("BusinessVastu / Index : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = "error msg";
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            return View();
        }
    }
}