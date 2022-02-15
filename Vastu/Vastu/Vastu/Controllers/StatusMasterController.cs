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
    public class StatusMasterController : Controller
    {
        // GET: StatusMaster
        private StatusMasterBusinessLayer _StatusMasterBusinessLayer;
        public StatusMasterController()
        {
            _StatusMasterBusinessLayer = new StatusMasterBusinessLayer();
        }
        public ActionResult Index(int? page)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<VS_STATUS_MST> _statmst = new List<VS_STATUS_MST>();


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

                _statmst = _StatusMasterBusinessLayer.GetAllStatus();



            }


            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Status / Index : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = "error msg";
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            return View(_statmst.ToPagedList(pageNumber, pageSize));
        }

     
        // GET: StatusMaster/Create
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
                LogInfo.LogMsg = string.Format("Status / Create : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName)); ;
            }
        }

        // POST: StatusMaster/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VS_STATUS_MST statmst)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;
            try
            {

                if (ModelState.IsValid == false)
                {
                    return View(statmst);
                }

                if (ModelState.IsValid)
                {
                    statmst.STATUS = statmst.STATUS.Trim();
                    statmst.STATUS_ID = 4;
                    statmst.DELETE_FLAG = false;
                    statmst.CREATED_USER = Convert.ToInt32(Session["USER_ID"].ToString());
                    result = _StatusMasterBusinessLayer.CreateStatus(statmst);

                    if (result == 16)
                    {
                        ModelState.Clear();

                        TempData["ErrMsg"] = "Status Details Already Exists";
                        return View(statmst);
                    }

                    LogInfo.Comments = "Status Created - " + statmst.STATUS.ToString();
                    TempData["SuccMsg"] = "Status Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.Clear();

                    TempData["ErrMsg"] = "Unable Create Status";
                    return View(statmst);
                }


            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Status / Create : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName)); ;
            }
        }

        // GET: StatusMaster/Edit/5
        public ActionResult Edit(int id)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            VS_STATUS_MST _statmst = new VS_STATUS_MST();



            try
            {

                _statmst = _StatusMasterBusinessLayer.GetStatusByID(id);

            }


            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Status / Edit : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = "error msg";
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

            return View(_statmst);
        }

        // POST: StatusMaster/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VS_STATUS_MST statmst)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;

            try
            {

                if (ModelState.IsValid == false)
                {
                    return View(statmst);
                }

                if (ModelState.IsValid)
                {
                    statmst.STATUS = statmst.STATUS.Trim();
                    statmst.STATUS_ID = statmst.STATUS_ID;

                    statmst.UPDATED_USER = Convert.ToInt32(Session["USER_ID"].ToString());



                    result = _StatusMasterBusinessLayer.UpdateStatus(statmst);

                    if (result == 16)
                    {
                        ModelState.Clear();

                        TempData["ErrMsg"] = "Status Details Already Exists";
                        return View(statmst);
                    }

                    LogInfo.Comments = "Status Updated - " + statmst.STATUS.ToString();
                    TempData["SuccMsg"] = "Status Updated Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.Clear();

                    TempData["ErrMsg"] = "Unable Update Status";
                    return View(statmst);
                }


            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Status / Update : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName)); ;
            }
        }

     
    }
}
