using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Kaisokku_Business;
using Kaisokku_Common;
using System.Net.Mail;
using System.Threading;
namespace Kaisokku_Upload_Download.Controllers
{
    public class LoginController : BaseController
    {
        private Kaisokku_BusinessLayer kaisokku_businesslayer;
        
        public LoginController()
        {
            kaisokku_businesslayer = new Kaisokku_BusinessLayer(base.ConnectionString);
        }

        public ActionResult Index()
        {
            
            Login login = new Login();
            if (Request.Cookies["UserName"] != null && Request.Cookies["password"] != null)
            {
                login.Name = Request.Cookies["UserName"].Value;
                login.password = Base64Decode(Request.Cookies["password"].Value);
              
            }
            return View(login);
        }

        [HttpPost]        
        public ActionResult SignIn(Login login, string ReturnUrl = "")
        {
            string message = string.Empty;
            AuthenticatedUsers AuthenticatUser = null;
            try
            {
                if (ModelState.IsValid)
                {
                    //        AuthenticatUser = kaisokku_businesslayer.IsValidUser(login);

                    //        if ((AuthenticatUser.UserId == "0" || AuthenticatUser.UserId == null) 
                    //            && (AuthenticatUser.UserName == "Test" || AuthenticatUser.UserName == null) 
                    //            && (AuthenticatUser.RoleId == 0 ) 
                    //            && AuthenticatUser.IsActive == false 
                    //            && (AuthenticatUser.RoleName == "Test" || AuthenticatUser.RoleName == null))
                    //        {
                    //            //invalid user                   
                    //            TempData["Message"] = "Username and/or password is incorrect.";
                    //            return RedirectToAction("Index", "Login");
                    //        }
                    //        else
                    //        {
                    //            //valid user

                    //            Session["UserId"] = AuthenticatUser.UserId;
                    //            Session["UserName"] = AuthenticatUser.UserName;
                    //            Session["RoleId"] = AuthenticatUser.RoleId;
                    //            Session["IsActive"] = AuthenticatUser.IsActive;

                    //            Session["RoleName"] = AuthenticatUser.RoleName;

                    //            //remember password
                    //            if (login.RememberMe)
                    //            {
                    //                Response.Cookies["UserName"].Value = login.Name;
                    //                Response.Cookies["password"].Value = Base64Encode(login.password);
                    //                Response.Cookies["UserName"].Expires = DateTime.Now.AddYears(1);// Remember for 1 yr
                    //                Response.Cookies["password"].Expires = DateTime.Now.AddYears(1);

                    //            }
                    //            else
                    //            {
                    //                Response.Cookies["UserName"].Expires = DateTime.Now.AddMinutes(-1);
                    //                Response.Cookies["password"].Expires = DateTime.Now.AddMinutes(-1);

                    //            }


                    //            int timeout = 10; // logout time 10 minutes
                    //            var ticket = new FormsAuthenticationTicket(login.Name, login.RememberMe, timeout);
                    //            string encrypted = FormsAuthentication.Encrypt(ticket);
                    //            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                    //            cookie.Expires = DateTime.Now.AddMinutes(timeout);
                    //            cookie.HttpOnly = true;
                    //            Response.Cookies.Add(cookie);
                    //            if (Url.IsLocalUrl(ReturnUrl))
                    //            {
                    //                return Redirect(ReturnUrl);
                    //            }
                    //            else
                    //            {
                    //                if (Convert.ToString(Session["RoleName"]) == "Admin")
                    //                {
                    //                    return RedirectToAction("Index", "Home", new { showUserMenu = false });
                    //                }
                    //                else
                    //                {
                    //                    return RedirectToAction("Index", "Home", new { showUserMenu = true });
                    //                }
                    //            }

                    //        }
                    //    }
                    //    else
                    //    {
                    //        TempData["Message"] = "Username and/or password is incorrect.";
                    //        return RedirectToAction("Index", "Login");
                    //    }

                }
            }
            catch (Exception ex)
            {
                //    LogInfo.LogMsg = string.Format("Login / SignIn : {0} Message: {1} ", "", ex.Message);
                //    Log.Error(LogInfo.LogMsg, ex);
            }

            return RedirectToAction("Index", "Home");
        }

      

        [HttpPost]
        public ActionResult ForgotPassword(Login login)
        {
            try
            {
                //RecoveryPassword forgot = new RecoveryPassword();
                //forgot = kaisokku_businesslayer.PassWordRecovery(login.Email);
                //if (Convert.ToString(forgot.password) == "NP")
                //{
                //    TempData["Message"] = "Incorrect Email Id";
                //    return RedirectToAction("Index", "Login");
                //}
                //else
                //{
                //    MailMessage m = new MailMessage();
                //    m.To.Add(new MailAddress(Convert.ToString(login.Email)));
                //    m.From = new MailAddress("bharathiraja.r@rever.com.sg");
                //    m.Subject = "ForGotPassword";
                //    m.IsBodyHtml = true;
                //    m.Body = "Hi" + "<p/> Your Password is.<p/>" + Convert.ToString(forgot.password);
                //    SmtpClient server = new SmtpClient("smtp.rever.com.sg", 465);
                //    server.EnableSsl = true;
                //    server.Send(m);

                //}
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Unable to send";
                LogInfo.LogMsg = string.Format("Login / ForgotPassword : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);

            }
            return RedirectToAction("Index", "Login");
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