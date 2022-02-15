﻿using System;
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
    public class SearchVastuController : Controller
    {
        private SearchVastuBusinessLayer _SearchVastuBusinessLayer;
        public SearchVastuController()
        {
            _SearchVastuBusinessLayer = new SearchVastuBusinessLayer();
        }
        public ActionResult Index()
        {
            ViewBag.SearchVastu = "SearchVastu";
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            ViewModel obj = new ViewModel();
            try
            {
                //obj.lstViewModelTypeVasthu = _SearchVastuBusinessLayer.Type();
                obj.lstViewModelAreaVasthu = _SearchVastuBusinessLayer.Area();
                obj.lstViewModelDirctionVasthu = _SearchVastuBusinessLayer.Direction();

                ViewBag.TestResult = TempData["GetData"];
                ViewBag.SelectedAreaID = TempData["Area"];
                ViewBag.SelectedDirectionID = TempData["Direction"];
                //ViewBag.SelectedTypeID = TempData["Type"];

            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("SearchVastu / Index : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = "error msg";
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            return View(obj);
        }

        [HttpPost]
        public ActionResult Getsearchvalue()
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            ViewModel objec = new ViewModel();
            string errmsg = "";
            try
            {
                
               

                int aid = Convert.ToInt32(Request.Form["AreaVasthuDetail.AREA_ID"]);
                int did = Convert.ToInt32(Request.Form["DirctionVasthuDetail.DIRECTION_ID"]);
                //int vid = Convert.ToInt32(Request.Form["TypeVasthuDetail.VASTU_TYPE_ID"]);
               // objec.lstViewModelVasthumst = _SearchVastuBusinessLayer.GetValues(aid, did, vid);
                objec.lstViewModelVasthumst = _SearchVastuBusinessLayer.GetValues(aid, did);
                TempData["GetData"] = objec.lstViewModelVasthumst;
                TempData["Area"] = aid;
                TempData["Direction"] = did;
                if(objec.lstViewModelVasthumst.Count==0)
                {
                    errmsg = Vastu.Resources.Resource.NoResultandDescriptionFound;
                    TempData["msgerror"] = errmsg;
                }
                //TempData["Type"] = vid;
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("SearchVastu / Edit : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = errmsg;
            }
            return RedirectToAction("Index");
        }
    }
}