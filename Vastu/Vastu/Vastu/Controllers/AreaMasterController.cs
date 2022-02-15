﻿using System;
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
    public class AreaMasterController : Controller
    {
        private AreaMasterBusinessLayer _AreaMasterBusinessLayer;
        public AreaMasterController()
        {
            _AreaMasterBusinessLayer = new AreaMasterBusinessLayer();
        }
        // GET: AreaMaster
        public ActionResult Index(int? page)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<VS_AREA_MST> _areamst = new List<VS_AREA_MST>();


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

                _areamst = _AreaMasterBusinessLayer.GetAllArea();



            }


            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Area / Index : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = "error msg";
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            return View(_areamst.ToPagedList(pageNumber, pageSize));
        }

       

        // GET: AreaMaster/Create
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
                LogInfo.LogMsg = string.Format("Area / Create : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName)); ;
            }
        }

        // POST: AreaMaster/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VS_AREA_MST areamst)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;
            try
            {

                if (ModelState.IsValid == false)
                {
                    return View(areamst);
                }

                if (ModelState.IsValid)
                {
                    areamst.AREA = areamst.AREA.Trim();
                    areamst.STATUS_ID = 4;
                    //areamst.DELETE_FLAG = false;
                    areamst.CREATED_USER = Convert.ToInt32(Session["USER_ID"].ToString());
                    result = _AreaMasterBusinessLayer.CreateArea(areamst);

                    if (result == 16)
                    {
                        ModelState.Clear();

                        TempData["ErrMsg"] = Vastu.Resources.Resource.AreaDetailsAlreadyExists;
                        return View(areamst);
                    }

                    LogInfo.Comments = "Area Created - " + areamst.AREA.ToString();
                    TempData["SuccMsg"] = Vastu.Resources.Resource.AreaCreatedSuccessfully;
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.Clear();

                    TempData["ErrMsg"] = Vastu.Resources.Resource.UnabletoCreateArea;
                    return View(areamst);
                }


            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Area / Create : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName)); ;
            }
        }

        // GET: AreaMaster/Edit/5
        public ActionResult Edit(int id)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            VS_AREA_MST _areamst = new VS_AREA_MST();



            try
            {

                _areamst = _AreaMasterBusinessLayer.GetAreaByID(id);

            }


            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Area / Edit : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = Vastu.Resources.Resource.errormsg;
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

            return View(_areamst);
        }

        // POST: AreaMaster/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VS_AREA_MST areamst)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;

            try
            {

                if (ModelState.IsValid == false)
                {
                    return View(areamst);
                }

                if (ModelState.IsValid)
                {
                    areamst.AREA = areamst.AREA.Trim();
                    areamst.STATUS_ID = 4;

                    areamst.UPDATED_USER = Convert.ToInt32(Session["USER_ID"].ToString());



                    result = _AreaMasterBusinessLayer.UpdateArea(areamst);

                    if (result == 16)
                    {
                        ModelState.Clear();

                        TempData["ErrMsg"] = Vastu.Resources.Resource.AreaDetailsAlreadyExists;
                        return View(areamst);
                    }

                    LogInfo.Comments = "Area Updated - " + areamst.AREA.ToString();
                    TempData["SuccMsg"] = Vastu.Resources.Resource.AreaUpdatedSuccessfully;
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.Clear();

                    TempData["ErrMsg"] = Vastu.Resources.Resource.UnabletoUpdateArea;
                    return View(areamst);
                }


            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Area / Update : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName)); ;
            }
        }

      
    }
}
