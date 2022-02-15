﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vasthu_Models;
using Vastu_Business;
using System.Web.Security;
using System.Security.Principal;



namespace Vastu.Controllers
{
    public class LoginController : Controller
    {
        private LoginBusiness _LoginBusiness;
        public LoginController()
        {
            _LoginBusiness = new LoginBusiness();
        }

        // GET: Login
        public ActionResult Index()
        {
            ViewBag.Login = "Login";
            Login login= new Login();
            if (Request.Cookies["UserName"] != null && Request.Cookies["password"] != null)
            {

 

                login.LOGIN_NAME = Request.Cookies["UserName"].Value;
                login.LOGIN_PASSWORD = Base64Decode(Request.Cookies["password"].Value);

            }
            return View(login);
        }

        [HttpPost]
        public ActionResult SignIn(Login user, string returnUrl = "")
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;

            //string message = string.Empty;
            //AuthenticatedUsers AuthenticatUser = null;
            List<Login> Login = new List<Login>();
            try
            {
                if (ModelState.IsValid)
                {
                    
                    Session["LOGIN_NAME"] = user.LOGIN_NAME;
                    Session["LOGIN_PASSWORD"] = user.LOGIN_PASSWORD;
                    Session["USER_TYPE"]  = user.USER_TYPE;
                    if (user.LOGIN_NAME == null || user.LOGIN_PASSWORD == null)
                    {
                        TempData["Message"] = Vastu.Resources.Resource.Usernameandpasswordismandatory;
                        return RedirectToAction("Index", "Login");
                    }

                    //if(Login.Count>0)
                    if (Membership.ValidateUser(user.LOGIN_NAME, user.LOGIN_PASSWORD))
                    {
                        Login = GetUserDetails(user.LOGIN_NAME, user.LOGIN_PASSWORD);
                        Session["USER_ID"] = Login[0].USER_ID;
                        Session["FIRST_NAME"] = Login[0].FIRST_NAME;
                        Session["EMAIL_ID"] = Login[0].EMAIL_ID;
                        Session["USER_TYPE"]= Login[0].USER_TYPE;

                        FormsAuthentication.SetAuthCookie(user.LOGIN_NAME, false);
                        if (user.RememberMe)
                        {
                            Response.Cookies["UserName"].Value = user.LOGIN_NAME;
                            Response.Cookies["password"].Value = Base64Encode(user.LOGIN_PASSWORD);
                            Response.Cookies["UserName"].Expires = DateTime.Now.AddYears(1);// Remember for 1 yr
                            Response.Cookies["password"].Expires = DateTime.Now.AddYears(1);

                        }
                        else
                        {
                            Response.Cookies["UserName"].Expires = DateTime.Now.AddMinutes(-1);
                            Response.Cookies["password"].Expires = DateTime.Now.AddMinutes(-1);

                        }
                        if (String.IsNullOrEmpty(returnUrl))
                        {
                            //return RedirectToAction("Index", "UserMaster");
                            var userType = Session["USER_TYPE"];
                            //if (userType.ToString() != "1")
                            //{

                            //    return RedirectToAction("Index", "UserMaster");
                            //}
                            //else 
                            //{
                                return RedirectToAction("Index", "Home");
                            //}
                        }
                       
                        else
                        {
                            RedirectToLocal(returnUrl);
                        }
                    }
                    else
                    {
                        TempData["Message"] =Vastu.Resources.Resource.Usernameandorpasswordisincorrect;
                        return RedirectToAction("Index", "Login");
                    }                                
                                          
                    
                }
            }
            catch (Exception ex)
            {
                //LogInfo.LogMsg = string.Format("SearchVastu / Index : {0} Message: {1} ", "", ex.Message);
                //Log.Error(LogInfo.LogMsg, ex);
                //TempData["ErrMsg"] = "error msg";
                //return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            return RedirectToAction("Index");
        }
       
       public List<Login> GetUserDetails(string UserName, string password)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<Login> Login = new List<Login>();

            try
            {
                Login = _LoginBusiness.Login(UserName, password);
               
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("LoginVastu / Index : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = "error msg";
            }

            return Login;
        }
        public ActionResult SignOut()
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
           
            try
            {
                if (Session["FIRST_NAME"] == null || Session["FIRST_NAME"].ToString().Trim() == "")
                {
                    Session["FIRST_NAME"] = "Unknown";
                }
                else
                {
                    Session["FIRST_NAME"] = Session["FIRST_NAME"];
                }
                Session["LOGIN_NAME"] = "";
                Session["LOGIN_PASSWORD"] = "";
                Session["USER_ID"] = "";
                Session["FIRST_NAME"] = "";
                Session["EMAIL_ID"] = "";
                Session["USER_TYPE"]= "";
                //// Sign Out.
                //authenticationManager.SignOut();
                FormsAuthentication.SignOut();
                HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
                foreach (var cookie in Request.Cookies.AllKeys)
                {
                    Request.Cookies.Remove(cookie);
                }
                foreach (var cookie in Response.Cookies.AllKeys)
                {
                    Response.Cookies.Remove(cookie);
                }

                // Clear authentication cookie
                HttpCookie rFormsCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
                rFormsCookie.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(rFormsCookie);

                // Clear session cookie 
                HttpCookie rSessionCookie = new HttpCookie("ASP.NET_SessionId", "");
                rSessionCookie.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(rSessionCookie);
                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }


        }

        [HttpPost]   
        public ActionResult ForgotPassword(Login Login)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<Login> Forgotten = new List<Login>();
            try
            {
                if(Login.LOGIN_NAME==null & Login.EMAIL_ID==null)
                {
                    TempData["Msg"] = Vastu.Resources.Resource.PleaseenterAllField;
                }
                if (Login.ConfrimPassword == Login.NewPassword)
                {

                    Forgotten = _LoginBusiness.Forgotten(Login);
                }
                else
                {
                    TempData["Msg"] = "Password Mismatch.";
                }
                
            }
            catch (Exception ex)
            {
                //TempData["Message"] = "Unable to send";
                LogInfo.LogMsg = string.Format("Login / ForgotPassword : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);

            }
            return RedirectToAction("Index", "Login");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
           
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Employer");
            }
        }
        [NonAction]
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        [NonAction]
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}