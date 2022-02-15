using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vasthu_Models;
using Vastu_Business;
using PagedList;
namespace Vastu.Controllers
{
    [SessionExpire]
    [Authorize]
    [VASTUCustomAuthorize(Roles = "1")]
    public class AreaMasterTranDtlController : Controller
    {
        // GET: AreaMasterTranDtl

        private AreaMasterTranDtlBusinessLayer _AreaMasterTranDtlBusinessLayer;

        public AreaMasterTranDtlController()
        {
            _AreaMasterTranDtlBusinessLayer = new AreaMasterTranDtlBusinessLayer();

        }
        public ActionResult Index(int? page)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<VS_AREA_MST_TRAN_DETAILS> _vastumst = new List<VS_AREA_MST_TRAN_DETAILS>();

            int pageSize;
            if (System.Configuration.ConfigurationManager.AppSettings["PageSize"] == null)
            {
                pageSize = 10;
            }
            else
            {
                pageSize = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["PageSize"].ToString());

            }

            int pageNumber = (page ?? 1);

            try
            {
                _vastumst = _AreaMasterTranDtlBusinessLayer.GetAllAreaTranDtl();
            }


            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Area Master Transaction Log/ Index : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = "error msg";
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            return View(_vastumst.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Details(int id)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            VS_AREA_MST_TRAN_DETAILS _vastumst = new VS_AREA_MST_TRAN_DETAILS();



            try
            {

                _vastumst = _AreaMasterTranDtlBusinessLayer.GetAllAreaTranDtlByID(id);



            }


            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Area Master Transaction Log / Details : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = Vastu.Resources.Resource.errormsg;
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

            return View(_vastumst);
        }
    }
}