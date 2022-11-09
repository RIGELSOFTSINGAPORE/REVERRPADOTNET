using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Penna_Business;
using Penna_Common;
using System.Net.Mail;
using System.Threading;

namespace Penna_MRP.Controllers
{
    public class LoginController : BaseController
    {
        private Penna_BusinessLayer Penna_businesslayer;
        
        public LoginController()
        {
            Penna_businesslayer = new Penna_BusinessLayer(base.ConnectionString);
        }

        public ActionResult Index()
        {
            
            Login login = new Login();
            if (Request.Cookies["UserName"] != null && Request.Cookies["password"] != null)
            {
                login.Name = Request.Cookies["UserName"].Value;
                login.password = Base64Decode(Request.Cookies["password"].Value);
              
            }
            Session["UserId"] = "";
            Session["UserName"] = "";
        
            Session["IsActive"] = "";
            Session["UserMasterID"] = "";

            Session["RoleName"] = "";
            Session["RoleId"] = "";

            FormsAuthentication.SignOut();
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
                    AuthenticatUser = Penna_businesslayer.IsValidUser(login);

                    if (AuthenticatUser != null)
                    {

                    
                    if ((AuthenticatUser.User_Master_PKID == 0 ) 
                        && (AuthenticatUser.User_Name == "" || AuthenticatUser.User_Name == null) 
                        && (AuthenticatUser.Role_FKID == 0 ) 
                        && AuthenticatUser.IsActive == "" 
                        && (AuthenticatUser.Role_Name == "" || AuthenticatUser.Role_Name == null))
                    {
                        //invalid user                   
                        TempData["Message"] = "Username and/or password is incorrect.";
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        //valid user

                        Session["UserId"] = AuthenticatUser.User_Master_PKID;
                        Session["UserName"] = AuthenticatUser.User_Name;
                        Session["RoleId"] = AuthenticatUser.Role_FKID;
                        Session["IsActive"] = AuthenticatUser.IsActive;
                        Session["UserMasterID"] = AuthenticatUser.User_Master_PKID;
                       
                        Session["RoleName"] = AuthenticatUser.Role_Name;
                        FormsAuthentication.SetAuthCookie(AuthenticatUser.Role_Name,true);
                        FormsAuthentication.SetAuthCookie(Convert.ToString(AuthenticatUser.Role_FKID), true);
                            //remember password
                            if (login.RememberMe)
                        {
                            Response.Cookies["UserName"].Value = login.Name;
                            Response.Cookies["password"].Value = Base64Encode(login.password);
                            Response.Cookies["UserName"].Expires = DateTime.Now.AddYears(1);// Remember for 1 yr
                            Response.Cookies["password"].Expires = DateTime.Now.AddYears(1);
                            
                        }
                        else
                        {
                            Response.Cookies["UserName"].Expires = DateTime.Now.AddMinutes(-1);
                            Response.Cookies["password"].Expires = DateTime.Now.AddMinutes(-1);
                            
                        }

                          string roles =Convert.ToString(AuthenticatUser.Role_FKID);
                        //int timeout = 10; // logout time 10 minutes
                        var ticket = new FormsAuthenticationTicket(1, AuthenticatUser.User_Name, DateTime.Now, DateTime.Now.AddMinutes(2880), login.RememberMe, roles, FormsAuthentication.FormsCookiePath);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        //cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);
                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            if (Convert.ToString(Session["RoleId"]) == "1")
                            {
                                return RedirectToAction("Index", "AdminManageUsers");
                            }
                            else if (Convert.ToString(Session["RoleId"]) == "2")
                                {
                                    return RedirectToAction("Index", "Packer_dashboard");
                                }
                            else if (Convert.ToString(Session["RoleId"]) == "3")
                                {
                                return RedirectToAction("Index", "Dispatcher_Dashboard");
                            }
                        }

                    }
                    }
                    else
                    {
                        //invalid user                   
                        TempData["Message"] = "Username and/or password is incorrect.";
                        return RedirectToAction("Index", "Login");
                    }
                }
                else
                {
                    TempData["Message"] = "Enter valid Username and/or password.";
                    return RedirectToAction("Index", "Login");
                }

            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Login / SignIn : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }

            return RedirectToAction("Index", "Login");
        }

      

        [HttpPost]
        public ActionResult ForgotPassword(Login login)
        {
            try
            {
                //RecoveryPassword forgot = new RecoveryPassword();
                //forgot = Penna_businesslayer.PassWordRecovery(login.Email);
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
        [HttpPost]
        public ActionResult Signout(Login login)
        {
            try
            {
                //int singnout=Penna_businesslayer.
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Unable to send";
                LogInfo.LogMsg = string.Format("Login / ForgotPassword : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);

            }
            return RedirectToAction("Index", "Login");
        }
    }
}