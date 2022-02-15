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
    public class ContentMasterController : Controller
    {
        private ContentMasterBusinessLayer _ContentMasterBusinessLayer;
        public ContentMasterController()
        {
            _ContentMasterBusinessLayer = new ContentMasterBusinessLayer();
        }
        // GET: ContentMaster
        public ActionResult Index(int? page)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<VS_CONTENT_MST> _contentmst = new List<VS_CONTENT_MST>();


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

                _contentmst = _ContentMasterBusinessLayer.GetAllContent();



            }


            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Content / Index : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = "error msg";
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            return View(_contentmst.ToPagedList(pageNumber, pageSize));
        }

       

        // GET: ContentMaster/Create
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
                LogInfo.LogMsg = string.Format("Content / Create : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName)); ;
            }
        }

        // POST: ContentMaster/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VS_CONTENT_MST contentnmst)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;
            try
            {

                if (ModelState.IsValid == false)
                {
                    return View(contentnmst);
                }

                if (ModelState.IsValid)
                {
                    contentnmst.CONTENT_NAME = contentnmst.CONTENT_NAME.Trim();
                    contentnmst.STATUS_ID = 4;
                    contentnmst.DELETE_FLAG = false;
                    contentnmst.CREATED_USER = Convert.ToInt32(Session["USER_ID"].ToString());
                    result = _ContentMasterBusinessLayer.CreateContent(contentnmst);

                    if (result == 16)
                    {
                        ModelState.Clear();

                        TempData["ErrMsg"] = "Content Details Already Exists";
                        return View(contentnmst);
                    }

                    LogInfo.Comments = "Content Created - " + contentnmst.CONTENT_NAME.ToString();
                    TempData["SuccMsg"] = "Content Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.Clear();

                    TempData["ErrMsg"] = "Unable Create Content";
                    return View(contentnmst);
                }


            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Content / Create : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName)); ;
            }
        }

        // GET: ContentMaster/Edit/5
        public ActionResult Edit(int id)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            VS_CONTENT_MST _contentmst = new VS_CONTENT_MST();



            try
            {

                _contentmst = _ContentMasterBusinessLayer.GetContentByID(id);

            }


            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Content / Edit : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = "error msg";
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

            return View(_contentmst);
        }

        // POST: ContentMaster/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VS_CONTENT_MST contentnmst)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;

            try
            {

                if (ModelState.IsValid == false)
                {
                    return View(contentnmst);
                }

                if (ModelState.IsValid)
                {
                    contentnmst.CONTENT_NAME = contentnmst.CONTENT_NAME.Trim();
                    contentnmst.STATUS_ID = 4;

                    contentnmst.UPDATED_USER = Convert.ToInt32(Session["USER_ID"].ToString());



                    result = _ContentMasterBusinessLayer.UpdateContent(contentnmst);

                    if (result == 16)
                    {
                        ModelState.Clear();

                        TempData["ErrMsg"] = "Content Details Already Exists";
                        return View(contentnmst);
                    }

                    LogInfo.Comments = "Content Updated - " + contentnmst.CONTENT_NAME.ToString();
                    TempData["SuccMsg"] = "Content Updated Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.Clear();

                    TempData["ErrMsg"] = "Unable Update Content";
                    return View(contentnmst);
                }


            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Content / Update : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName)); ;
            }
        }

      
    }
}
