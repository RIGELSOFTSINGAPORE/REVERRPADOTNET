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
    public class DirectionMasterController : Controller
    {
        private DirectionMasterBusinessLayer _DirectionMasterBusinessLayer;
        public DirectionMasterController()
        {
            _DirectionMasterBusinessLayer = new DirectionMasterBusinessLayer();
        }
        // GET: DirectionMaster
        public ActionResult Index(int? page)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<VS_DIRECTION_MST> _directmst = new List<VS_DIRECTION_MST>();


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

                _directmst = _DirectionMasterBusinessLayer.GetAllDirection();



            }


            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Direction / Index : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = "error msg";
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            return View(_directmst.ToPagedList(pageNumber, pageSize));
        }

       

        // GET: DirectionMaster/Create
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
                LogInfo.LogMsg = string.Format("Direction / Create : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName)); ;
            }
        }

        // POST: DirectionMaster/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VS_DIRECTION_MST directionmst)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;
            try
            {

                if (ModelState.IsValid == false)
                {
                    return View(directionmst);
                }

                if (ModelState.IsValid)
                {
                    directionmst.DIRECTION = directionmst.DIRECTION.Trim();
                    directionmst.STATUS_ID = 4;
                    directionmst.DELETE_FLAG = false;
                    directionmst.CREATED_USER = Convert.ToInt32(Session["USER_ID"].ToString());
                    result = _DirectionMasterBusinessLayer.CreateDirection(directionmst);

                    if (result == 16)
                    {
                        ModelState.Clear();

                        TempData["ErrMsg"] = Vastu.Resources.Resource.DirectionDetailsAlreadyExists;
                        return View(directionmst);
                    }

                    LogInfo.Comments = "Direction Created - " + directionmst.DIRECTION.ToString();
                    TempData["SuccMsg"] = Vastu.Resources.Resource.DirectionCreatedSuccessfully;
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.Clear();

                    TempData["ErrMsg"] = Vastu.Resources.Resource.UnabletoCreateDirection;
                    return View(directionmst);
                }


            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Direction / Create : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName)); ;
            }
        }

        // GET: DirectionMaster/Edit/5
        public ActionResult Edit(int id)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            VS_DIRECTION_MST _directmst = new VS_DIRECTION_MST();



            try
            {

                _directmst = _DirectionMasterBusinessLayer.GetDirectionByID(id);

            }


            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Direction / Edit : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = Vastu.Resources.Resource.errormsg;
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

            return View(_directmst);
        }

        // POST: DirectionMaster/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VS_DIRECTION_MST directionmst)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;

            try
            {

                if (ModelState.IsValid == false)
                {
                    return View(directionmst);
                }

                if (ModelState.IsValid)
                {
                    directionmst.DIRECTION = directionmst.DIRECTION.Trim();
                    directionmst.STATUS_ID = 4;

                    directionmst.UPDATED_USER = Convert.ToInt32(Session["USER_ID"].ToString());



                    result = _DirectionMasterBusinessLayer.UpdateDirection(directionmst);

                    if (result == 16)
                    {
                        ModelState.Clear();

                        TempData["ErrMsg"] = Vastu.Resources.Resource.DirectionDetailsAlreadyExists;
                        return View(directionmst);
                    }

                    LogInfo.Comments = "Direction Updated - " + directionmst.DIRECTION.ToString();
                    TempData["SuccMsg"] = Vastu.Resources.Resource.DirectionUpdatedSuccessfully;
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.Clear();

                    TempData["ErrMsg"] = Vastu.Resources.Resource.UnabletoUpdateDirection;
                    return View(directionmst);
                }


            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Direction / Update : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName)); ;
            }
        }

       
    }
}
