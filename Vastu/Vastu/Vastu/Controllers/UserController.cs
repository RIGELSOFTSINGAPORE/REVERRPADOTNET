using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vasthu_Models;
using Vastu_Business;


namespace Vastu.Controllers
{
    //[RoutePrefix("User")]
    //[SessionExpire]
    //[Authorize]
    //[VASTUCustomAuthorize(Roles = "1")]
   
    public class UserController : Controller
    {
        
        private UserVastuBusinessLayer _UserVastuBusinessLayer;
        public UserController()
        {
            _UserVastuBusinessLayer = new UserVastuBusinessLayer();
        }

        [NonAction]
        // [Route("Index1")]
        public ActionResult Index()
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<USER_MST> _usermst = new List<USER_MST>();            
           
            var GetUser = new List<USER_MST>();           

            try
            {
                _usermst = _UserVastuBusinessLayer.GetUser();
            }


            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("UserVastu / Index : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = "error msg";
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            return View(_usermst);
        }

        [NonAction]
        public ActionResult Create()
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("UserVastu / Index : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }
            return View();

        }

        [NonAction]
        [HttpPost, ActionName("Create")]
        public ActionResult CreatePost(USER_MST usermst)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                usermst.FIRST_NAME = "admin";
                usermst.CREATED_USER = 1;
                usermst.STATUS_ID = 4;
                usermst.USER_TYPE = 2;

                if (usermst.ConfrimPassword != usermst.NewPassword)
                {

                    TempData["Message"] = "Password does not match";

                }
                else 
                {
                    _UserVastuBusinessLayer.CreateUser(usermst);
                     return RedirectToAction("Index");
                }
               
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("UserVastu / Index : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = "error msg";
            }
            return RedirectToAction("Index");
        }


        [NonAction]
        public ActionResult Update(int? id)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<USER_MST> _usermst = new List<USER_MST>();
            try
            {
                int ID = Convert.ToInt16(id);
                _usermst = _UserVastuBusinessLayer.Update(ID);
                return View(_usermst[0]);
            }

            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

        }
        [NonAction]
        [HttpPost]
        public ActionResult Update(USER_MST Update)
        {

            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<USER_MST> _usermst = new List<USER_MST>();
            try
            {
                if (Update.NewPassword != null)
                {
                    if (Update.NewPassword == Update.ConfrimPassword)
                    {
                        TempData["Message"] = "Password does not match";
                    }
                }
                _usermst = _UserVastuBusinessLayer.UpdateDetails(Update);
                return RedirectToAction("Index");


            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }



    }
}