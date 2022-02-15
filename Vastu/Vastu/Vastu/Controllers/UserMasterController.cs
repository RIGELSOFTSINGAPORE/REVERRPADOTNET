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
    public class UserMasterController : Controller
    {
        private UserMasterBusinessLayer _UserMasterBusinessLayer;
        public UserMasterController()
        {
            _UserMasterBusinessLayer = new UserMasterBusinessLayer();
        }

        // GET: UserMaster
        public ActionResult Index(int? page)
        {
            
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<VS_USER_MST> _usermst = new List<VS_USER_MST>();

            var GetUser = new List<USER_MST>();

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

                _usermst = _UserMasterBusinessLayer.GetAllUser();


                
            }


            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("UserVastu / Index : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = "error msg";
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            return View(_usermst.ToPagedList(pageNumber, pageSize));
        }

        // GET: UserMaster/Details/5
        

        // GET: UserMaster/Create
        public ActionResult Create()
        {
            
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                ModelState.Clear();
                BindUserType(2);
                return View();
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("UserVastu / Create : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName)); ;
            }

        }
        
        public void BindUserType(int? val)
        {
           
           

            var selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem
            {
                Value = "",
                Text = Vastu.Resources.Resource.Select
            });
            selectList.Add(new SelectListItem
            {
                Value = "2",
                Text = Vastu.Resources.Resource.User
            });
            selectList.Add(new SelectListItem
            {
                Value = "1",
                Text = Vastu.Resources.Resource.Admin
            });
            
            

            ViewBag.UserTypeID = selectList;
           
 
        }
        // POST: UserMaster/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "LOGIN_NAME,LOGIN_PASSWORD,FIRST_NAME,MIDDLE_NAME,LAST_NAME,ADDRESS_LINE1,ADDRESS_LINE2,CITY,COUNTRY,EMAIL_ID,CONTACT_NO,USER_TYPE,DELETE_FLAG")] VS_USER_MST usermst)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result;
            BindUserType(usermst.USER_TYPE);
            try
            {
                ModelState["LOGIN_CONFIRM_PASSWORD"].Errors.Clear();
                ModelState["LOGIN_CONFIRM_NEW_PASSWORD"].Errors.Clear();
              
                
                if (ModelState.IsValid)
                {
                    usermst.LOGIN_NAME = usermst.LOGIN_NAME.Trim();
                    usermst.STATUS_ID = 4;
                    usermst.DELETE_FLAG = false;
                    usermst.CREATED_USER = Convert.ToInt32(Session["USER_ID"].ToString());
                    result = _UserMasterBusinessLayer.CreateUser(usermst);

                    if(result == 16)
                    {
                        ModelState.Clear();
                       
                        TempData["ErrMsg"] = Vastu.Resources.Resource.UserNameAlreadyExists;
                        return View(usermst);
                    }
                    LogInfo.Comments = "User Created - " + usermst.LOGIN_NAME.ToString();
                    TempData["SuccMsg"] = Vastu.Resources.Resource.UserCreatedSuccessfully;
                    return RedirectToAction("Index");
                }
                ModelState.Clear();
                
                TempData["ErrMsg"] = Vastu.Resources.Resource.UnabletoCreateUser;
                return View(usermst);
              
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("UserVastu / Create : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName)); ;
            }
        }

        // GET: UserMaster/Edit/5
        public ActionResult Edit(int id)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            VS_USER_MST _usermst = new VS_USER_MST();

            

            try
            {

                _usermst = _UserMasterBusinessLayer.GetUserByID(id);
                BindUserType(_usermst.USER_TYPE);

                
            }


            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("UserVastu / Index : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = "error msg";
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

            return View(_usermst);
  
        }
        
        // POST: UserMaster/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "USER_ID,LOGIN_NAME,LOGIN_PASSWORD,FIRST_NAME,MIDDLE_NAME,LAST_NAME,ADDRESS_LINE1,ADDRESS_LINE2,CITY,COUNTRY,EMAIL_ID,CONTACT_NO,USER_TYPE,DELETE_FLAG")] VS_USER_MST usermst)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result;
            try
            {
                ModelState["LOGIN_CONFIRM_PASSWORD"].Errors.Clear();
                ModelState["LOGIN_CONFIRM_NEW_PASSWORD"].Errors.Clear();
                

                if (ModelState.IsValid)
                {
                    usermst.LOGIN_NAME = usermst.LOGIN_NAME.Trim();
                    usermst.STATUS_ID = 4;

                    usermst.UPDATED_USER = Convert.ToInt32(Session["USER_ID"].ToString());
                    result = _UserMasterBusinessLayer.UpdateUser(usermst);

                    if (result == 16)
                    {
                        ModelState.Clear();
                        BindUserType(usermst.USER_TYPE);
                        TempData["ErrMsg"] = Vastu.Resources.Resource.UserNameAlreadyExists;
                        return View(usermst);
                    }
                    LogInfo.Comments = "User Created - " + usermst.LOGIN_NAME.ToString();
                    TempData["SuccMsg"] = Vastu.Resources.Resource.UserUpdatedSuccessfully;
                    return RedirectToAction("Index");
                }
                ModelState.Clear();
                BindUserType(usermst.USER_TYPE);
                TempData["ErrMsg"] = Vastu.Resources.Resource.UnabletoUpdateUser;
                return View(usermst);

            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("UserVastu / Create : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName)); ;
            }
        }

        
    }
}
