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
    public class VastuTypeMasterController : Controller
    {
        // GET: VastuTypeMaster

        private VastuTypeMasterBusinessLayer _VastuTypeMasterBusinessLayer;
        public VastuTypeMasterController()
        {
            _VastuTypeMasterBusinessLayer = new VastuTypeMasterBusinessLayer();
        }
        public ActionResult Index(int? page)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<VS_VASTU_TYPE_MST> _vtmst = new List<VS_VASTU_TYPE_MST>();


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

                _vtmst = _VastuTypeMasterBusinessLayer.GetAllVastuType();



            }


            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Vastu Type / Index : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = Vastu.Resources.Resource.errormsg;
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            return View(_vtmst.ToPagedList(pageNumber, pageSize));
        }

        // GET: VastuTypeMaster/Details/5
       

        // GET: VastuTypeMaster/Create
        public ActionResult Create()
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;

            try
            {

                return View();

            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Vastu Type / Create : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName)); ;
            }
        }

        // POST: VastuTypeMaster/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VS_VASTU_TYPE_MST vtmst)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;
            try
            {
               
                if (ModelState.IsValid == false)
                {
                    return View(vtmst);
                }

                if (ModelState.IsValid)
                {
                    vtmst.VASTU_TYPE = vtmst.VASTU_TYPE.Trim();
                    vtmst.STATUS_ID = 4;
                    vtmst.DELETE_FLAG = false;
                    vtmst.CREATED_USER = Convert.ToInt32(Session["USER_ID"].ToString());
                    result = _VastuTypeMasterBusinessLayer.CreateVastuType(vtmst);

                    if (result == 16)
                    {
                        ModelState.Clear();

                        TempData["ErrMsg"] = Vastu.Resources.Resource.VastuDetailsAlreadyExists;
                        return View(vtmst);
                    }
                   
                    LogInfo.Comments = "Vastu Type Created - " + vtmst.VASTU_TYPE.ToString();
                    TempData["SuccMsg"] = Vastu.Resources.Resource.VastuTypeCreatedSuccessfully;
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.Clear();

                    TempData["ErrMsg"] = Vastu.Resources.Resource.UnabletoCreateVastuType;
                    return View(vtmst);
                }


            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Vastu Type / Create : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName)); ;
            }
        }

        // GET: VastuTypeMaster/Edit/5
        public ActionResult Edit(int id)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            VS_VASTU_TYPE_MST _vtmst = new VS_VASTU_TYPE_MST();



            try
            {

                _vtmst = _VastuTypeMasterBusinessLayer.GetVastuTypeByID(id);

            }


            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Vastu Type / Edit : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = "error msg";
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

            return View(_vtmst);
        }

        // POST: VastuTypeMaster/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VS_VASTU_TYPE_MST vtmst)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;
           
            try
            {
               
                if (ModelState.IsValid == false)
                {
                    return View(vtmst);
                }

                if (ModelState.IsValid)
                {
                    vtmst.VASTU_TYPE = vtmst.VASTU_TYPE.Trim();
                    vtmst.STATUS_ID = 4;

                    vtmst.UPDATED_USER = Convert.ToInt32(Session["USER_ID"].ToString());

                   

                    result = _VastuTypeMasterBusinessLayer.UpdateVastuType(vtmst);

                    if (result == 16)
                    {
                        ModelState.Clear();

                        TempData["ErrMsg"] = Vastu.Resources.Resource.VastuDetailsAlreadyExists;
                        return View(vtmst);
                    }
                    
                    LogInfo.Comments = "Vastu Type Updated - " + vtmst.VASTU_TYPE.ToString();
                    TempData["SuccMsg"] = Vastu.Resources.Resource.VastuTypeUpdatedSuccessfully;
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.Clear();

                    TempData["ErrMsg"] = Vastu.Resources.Resource.UnabletoUpdateVastuType;
                    return View(vtmst);
                }


            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Vastu Type / Update : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName)); ;
            }
        }

      

        
    }
}
