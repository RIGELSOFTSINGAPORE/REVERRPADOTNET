using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Penna_Business;
using Penna_Common;
using PagedList;


namespace Penna_MRP.Controllers
{
    [Authorize(Roles ="1")]
    
    public class AdminManageUsersController : BaseController
    {
        // GET: AdminManageUsers
        private Penna_BusinessLayer Penna_businesslayer;
        public AdminManageUsersController()
        {
            Penna_businesslayer = new Penna_BusinessLayer(base.ConnectionString);
            base.Penna_Home();
        }
       
        public ActionResult Index()
        {

            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            
            
           
            try
            {
                List<PennaUser_Master> _PennaUsrmst = new List<PennaUser_Master>();
                GetFDintenanalcode(0);
                _PennaUsrmst = Penna_businesslayer.Get_UserMaster();
                ViewData["UserMaster"] = _PennaUsrmst;
            }

            catch (Exception ex)
            {
               // LogInfo.LogMsg = string.Format("User / Index : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = "error msg";
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
           
            return View();
        }

        public ActionResult Create(PennaUser_Master _PennaUsrmst)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;
            try
            {
                List<PennaUser_Master> pennaUsrmst = new List<PennaUser_Master>();
                GetFDintenanalcode(0);
                pennaUsrmst = Penna_businesslayer.Get_UserMaster();
                ViewData["UserMaster"] = pennaUsrmst;
                //if (ModelState.IsValid == false)
                //{
                //    return View("Index",_PennaUsrmst);
                //}
                ModelState.Clear();
                if (ModelState.IsValid)
                {
                    int roleid = 0;
                    int checkUName = 0;
                    checkUName = Penna_businesslayer.CheckUname(_PennaUsrmst.UserId, _PennaUsrmst.UserName);
                    roleid =Convert.ToInt32(Session["Edit"]) ;
                   

                    if (checkUName > 0)
                    {
                        ViewBag.Uname = "User Name Already Exist";
                        return View("Index");
                    }
                    if (roleid != 0)
                    {
                        if (roleid > 0)
                        {
                            //edit
                            _PennaUsrmst.ModifiedBy = -1;
                            _PennaUsrmst.ModifiedDate = DateTime.Now;
                            // _PennaUsrmst.DisplayName = "Administrator";
                            
                            result = Penna_businesslayer.UpdateUserMaster(_PennaUsrmst);

                            if (result == 1)
                            {
                                ModelState.Clear();
                                ViewBag.suumsg = "failure";
                                TempData["ErrMsg"] = "User Master Updated Failed";
                                Session["Edit"] = 0;
                                return View(_PennaUsrmst);
                                
                            }

                            // LogInfo.Comments = "Area Created - " + areamst.AREA.ToString();
                            ViewBag.suumsg = "success";
                            TempData["SuccMsg"] = "User Master Update Successfully";
                            Session["Edit"] = 0;

                            List<PennaUser_Master> data = new List<PennaUser_Master>();
                            GetFDintenanalcode(0);
                            data = Penna_businesslayer.Get_UserMaster();
                            ViewData["UserMaster"] = data;
                            return View("Index");
                           
                        }
                        else
                        {
                            //create
                            _PennaUsrmst.CreatedBy = -1;
                            _PennaUsrmst.CreatedDate = DateTime.Now;
                            _PennaUsrmst.DisplayName = "Administrator";

                            result = Penna_businesslayer.CreateUserMaster(_PennaUsrmst);
                            if (result == 1)
                            {
                                ModelState.Clear();
                                ViewBag.suumsg = "failure";
                                TempData["ErrMsg"] = "User Master Create Failed";
                              Session["Edit"] = 0;
                                return View(_PennaUsrmst);
                                
                            }

                            // LogInfo.Comments = "Area Created - " + areamst.AREA.ToString();
                            ViewBag.suumsg = "success";
                            TempData["SuccMsg"] = "User Master Create Successfully";
                            Session["Edit"] = 0;
                            return View("Index");
                            
                        }
                    }
                    else
                    {
                        _PennaUsrmst.CreatedBy = -1;
                        _PennaUsrmst.CreatedDate = DateTime.Now;
                        _PennaUsrmst.DisplayName = "Administrator";

                        result = Penna_businesslayer.CreateUserMaster(_PennaUsrmst);
                        if (result == 1)
                        {
                            ModelState.Clear();
                            ViewBag.suumsg = "failure";
                            TempData["ErrMsg"] = "User Master Create Failed";
                            Session["Edit"] = 0;
                            List<PennaUser_Master> datas = new List<PennaUser_Master>();
                            GetFDintenanalcode(0);
                            datas = Penna_businesslayer.Get_UserMaster();
                            ViewData["UserMaster"] = datas;
                            return View("Index");

                        }
                        ViewBag.suumsg = "success";
                        // LogInfo.Comments = "Area Created - " + areamst.AREA.ToString();
                        TempData["SuccMsg"] = "User Master Create Successfully";
                        Session["Edit"] = 0;
                        List<PennaUser_Master> data = new List<PennaUser_Master>();
                        GetFDintenanalcode(0);
                        data = Penna_businesslayer.Get_UserMaster();
                        ViewData["UserMaster"] = data;
                        return View("Index");
                    }

                   
                }
                else
                {
                    ModelState.Clear();
                    GetFDintenanalcode(0);
                    pennaUsrmst = Penna_businesslayer.Get_UserMaster();
                    ViewData["UserMaster"] = _PennaUsrmst;
                    TempData["ErrMsg"] = "Unable to Create User";
                    return View("Index",_PennaUsrmst);
                }


            }
            catch (Exception ex)
            {
                ViewBag.suumsg = "failure";
                //LogInfo.LogMsg = string.Format("Area / Create : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName)); ;
            }
        }


        public ActionResult GetFDintenanalcode(int RoleId)
        {

            try
            {

                var RoleList = new List<SelectListItem>();
                List<PennaUser_Master> result = new List<PennaUser_Master>();

                result = Penna_businesslayer.GetAdminRole();
                RoleList.Add(new SelectListItem
                {
                    Text = "Select",
                    Value = "0",

                });
                foreach (var element in result)
                {
                    if (RoleId == element.RoleId)
                    {
                        RoleList.Add(new SelectListItem
                        {
                            Text = Convert.ToString(element.Role_Name),
                            Value = Convert.ToString(element.RoleId),
                            Selected = true

                        });
                    }
                    else
                    {
                        RoleList.Add(new SelectListItem
                        {
                            Text = Convert.ToString(element.Role_Name),
                            Value = Convert.ToString(element.RoleId),


                        });
                    }
                }
                ViewBag.RoleList = RoleList;


                return View("");
            }
            catch (Exception ex)
            {
                //LogInfo.LogMsg = string.Format("Login / SignIn : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("");
            }

        }

        public ActionResult Edit(int? id)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            PennaUser_Master _usermst = new PennaUser_Master();
            try
            {
                List<PennaUser_Master> _PennaUsrmst = new List<PennaUser_Master>();
                GetFDintenanalcode(0);
                _PennaUsrmst = Penna_businesslayer.Get_UserMaster();
                ViewData["UserMaster"] = _PennaUsrmst;
                _usermst = Penna_businesslayer.Get_UserMasterDetails(id);
                Session["Edit"] = 1;

            }
            catch (Exception ex)
            {
               // LogInfo.LogMsg = string.Format("Manage Users / Edit : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = ex.Message;
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

            return View("Index",_usermst);
        }

        public ActionResult DeleteUser(int id)
        {

            try
            {
               
                //var Description = Request.Form["id"];
                PennaUser_Master result = new PennaUser_Master();
                result = Penna_businesslayer.DeleteUser(id);
                ViewBag.suumsg = "delete";
                List<PennaUser_Master> data = new List<PennaUser_Master>();
                GetFDintenanalcode(0);
                data = Penna_businesslayer.Get_UserMaster();
                ViewData["UserMaster"] = data;
                return View("Index");
            }
            catch (Exception ex)
            {
               // LogInfo.LogMsg = string.Format("Login / SignIn : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Index");
            }

        }
        //DeleteUserMaster

    }
}