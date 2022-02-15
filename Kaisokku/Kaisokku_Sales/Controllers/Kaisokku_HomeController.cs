using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Kaisokku_Business;
using Kaisokku_Common;
using Kaisokku_Sales.Models;
using System.Net.Mail;
using PagedList;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Mime;
using System.Data;


using System.Web.UI.WebControls;
using System.Web;

namespace Kaisokku_Sales.Controllers
{
    public class Kaisokku_HomeController : BaseController
    {
        private Kaisokku_BusinessLayer kaisokku_businesslayer;
        // GET: ClintMGT
        public Kaisokku_HomeController()
        {
            kaisokku_businesslayer = new Kaisokku_BusinessLayer(base.ConnectionString);
        }
        public ActionResult Index()
        {
            try
            {

                var PriceInfo = kaisokku_businesslayer.GetPrice();
                ViewData["PriceInfo"] = PriceInfo;
                var ClientInfo = kaisokku_businesslayer.GetClient();
                ViewData["ClientInfo"] = ClientInfo;
                var result = kaisokku_businesslayer.Getcontent();
                //ViewBag.FirstDescription = result.AsEnumerable().Where(r => r.Id == 5);
                DataTable table = new DataTable();
                table.Columns.Add("Id", typeof(string));
                table.Columns.Add("Title", typeof(string));
                table.Columns.Add("Description", typeof(string));
                foreach (var str in result)
                {
                    DataRow row = table.NewRow();
                    row["Id"] = str.Id;
                    row["Title"] = str.Title;
                    row["Description"] = str.Description;
                    table.Rows.Add(row);
                }
                if (table.Rows.Count > 0)
                {

                    if (table.Rows.Count >= 1)
                    {
                        ViewBag.FirstH1 = table.Rows[0]["Title"];
                        ViewBag.Description1 = table.Rows[0]["Description"];
                    }

                   
                    if (table.Rows.Count >= 2) { 
                        ViewBag.FirstH2 = table.Rows[1]["Title"];
                    ViewBag.Description2 = table.Rows[1]["Description"];
                }
                if (table.Rows.Count >= 3) { 
                    ViewBag.FirstH3 = table.Rows[2]["Title"];
                ViewBag.Description3 = table.Rows[2]["Description"];
            } 
                    if (table.Rows.Count >= 4) { 
                ViewBag.FirstH4 = table.Rows[3]["Title"];
            ViewBag.Description4 = table.Rows[3]["Description"];
        }
                    if (table.Rows.Count >= 5)
                    {
                        ViewBag.FirstH5 = table.Rows[4]["Title"];
                        ViewBag.Description5 = table.Rows[4]["Description"];
                    }
                    if (table.Rows.Count >= 6)
                    {
                        ViewBag.FirstH6 = table.Rows[5]["Title"];
                        ViewBag.Description6 = table.Rows[5]["Description"];
                    }
                }


                String Usertype = "0";
                if (TempData["SuccMSG"] != null)
                {
                    ViewBag.succmsg = TempData["SuccMSG"].ToString();
                }

                if (HttpContext.Session["Usertype"] != null && HttpContext.Session["Usertype"] != "")
                {
                    if (Session["Usertype"].ToString() == null || Session["Usertype"].ToString() == "")
                    {
                        Usertype = "0";
                    }
                    else
                    {
                        Usertype = Session["Usertype"].ToString();


                    }
                    ViewBag.signName = "Sign Out";
                }
                else
                {
                    ViewBag.signName = "Sign In";
                }




                var videoAllFiles = kaisokku_businesslayer.GetDemovideo(Usertype);
                //List<tbl_Video> VideoList = new List<tbl_Video>();

                //foreach (string outputResultFile in videoAllFiles)
                //{
                //VideoList.Add(new tbl_Video
                //{

                // Filename = outputResultFile,



                //});
                //}

                ViewData["DemoVideos"] = videoAllFiles.ToList();

                return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        public ActionResult ContactUS()
        {
            try
            {
                OutPut result = new OutPut();
                var FullName = Request.Form["FullName"];
                var ToEmail = Request.Form["EmailID"];
                var Subject = Request.Form["Subject"];
                var Message = Request.Form["Message"];
                var FromEmail = "revertest0001@gmail.com";
                var password = "Rever@2021";
                var CC = "revertest0001@gmail.com";
                var msg = "<div>Full Name : "+ FullName +"</div>";
                 msg += "<div>Subject : " + Subject + " </div>";
                 msg += "<div>Email : " + ToEmail + " </div>";
                 msg += "<div>Message : " + Message+" </div>";
                var IsMailSend = SendEmail(FromEmail, ToEmail, CC, Subject, msg, FullName, password);
                //var IsMailSend = SendEmail(crmail.CC, crmail.SenderFrom, crmail.EmailTo, crmail.Subject, crmail.Body);
                //}
                if (IsMailSend == false)
                {
                    return Json(new { errorcode = 1, errormessage = 1 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { errorcode = 0,IsMailSend }, JsonRequestBehavior.AllowGet);
                }

                
            }
            catch(Exception ex)
            {
                return Json(new { errorcode = 1, errormessage = 1}, JsonRequestBehavior.AllowGet);

              
            }
        }
        public bool SendEmail(string From, string EmailTo, string CC, string Subject, string Body, string Name, string password)
        {
            string body = string.Empty;


            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;
            string emailToAddress = EmailTo + "," + CC;


            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(From);
                    mail.To.Add(CC);
                    mail.Subject = "Kaisokku Enquiry";
                    mail.IsBodyHtml = true;
                    AlternateView alterView = ContentToAlternateView(Body);
                    mail.AlternateViews.Add(alterView);
                    //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        //smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(From, password);
                        smtp.EnableSsl = enableSSL;

                        smtp.Send(mail);
                    }

                }
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(From);
                    mail.To.Add(EmailTo);
                    mail.Subject = "Kaisokku Enquiry";
                    mail.IsBodyHtml = true;

                    Body = "<div><p class='MsoNormal'><b>Dear " + Name + ", <o:p></o:p></b></p><p class='MsoNormal'>We appreciate you for contacting Kaisokku. Our team Will get";
                    Body += " back in touch with you soon!<o:p></o:p></p><p class='MsoNormal'>Thank you for getting in touch! Have a great day!<o:p></o:p></p><p class='MsoNormal'>";
                    Body += "<o:p>&nbsp;</o:p></p><p class='MsoNormal'><b>Best regards,<o:p></o:p></b></p><p class='MsoNormal'><b>The Kaisokku Team <o:p></o:p></b></p>";
                    Body += "<p class='MsoNormal' style='mso - margin - bottom - alt:auto; line - height:normal; mso - outline - level:3; background: white'>";
                    Body += "</p><p class='MsoNormal'><b><a href='http://153.153.161.67/Kaisokku/'>Kaisokku</a><o:p></o:p></b></p>";
                    Body += "<p class='MsoNormal' style='mso - margin - bottom - alt:auto; line - height:normal; mso - outline - level:3; background: white'><b></b></p></div>";
                    AlternateView alterView = ContentToAlternateView(Body);
                    mail.AlternateViews.Add(alterView);
                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        //smtp.UseDefaultCredentials = false;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = new NetworkCredential(From, password);
                        //smtp.EnableSsl = enableSSL;

                        smtp.Send(mail);
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Home / SendEmail : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return false;
            }

        }
        private AlternateView ContentToAlternateView(string content)
        {
            var imgCount = 0;
            List<LinkedResource> resourceCollection = new List<LinkedResource>();
            foreach (Match m in Regex.Matches(content, "<img(?<value>.*?)>"))
            {
                imgCount++;
                var imgContent = m.Groups["value"].Value;
                string type = Regex.Match(imgContent, ":(?<type>.*?);base64,").Groups["type"].Value;
                string base64 = Regex.Match(imgContent, "base64,(?<base64>.*?)\"").Groups["base64"].Value;
                if (String.IsNullOrEmpty(type) || String.IsNullOrEmpty(base64))
                {
                    continue;
                }

            }

            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(content, null, MediaTypeNames.Text.Html);
            foreach (var item in resourceCollection)
            {
                alternateView.LinkedResources.Add(item);
            }

            return alternateView;
        }
        public JsonResult Signin(UserManagements obj)
        {
            try
            {

                UserManagements result = kaisokku_businesslayer.GetUserById(obj);

                //Session["Usertype"] = result.CustomerType;
                if (result != null)
                {
                    if (result.errorcode != 1)
                    {
                        result.errorcode = 0;
                        HttpContext.Session["Usertype"] = result.CustomerType;
                        TempData["SuccMSG"] = "You are successfully logged in";
                    }
                }


                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("Home / GetPageListDataById : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }
            return Json(new { errorcode = "1", errormessage = "failure" }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SignOut(UserManagements obj)
        {
            try
            {

                Session["Usertype"] = "";

            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("Home / GetPageListDataById : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }
            return Redirect("Index");
        }


        public JsonResult Signup(UserManagements obj)
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();
            try
            {

                result = kaisokku_businesslayer.AddUser(obj);
                return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("Home / AddUserInformation : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);

                return Json(new { errorcode = "1", errormessage = "Unable to insert" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult CheckEmail(String Email)
        {
            TempData["showClientMenu"] = null;
            UserManagements result = new UserManagements();
            try
            {

                result = kaisokku_businesslayer.CheckEmail(Email);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("Home / AddUserInformation : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);

                return Json(new { errorcode = "1", errormessage = "Unable to insert" }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult UpdateVideoCount(int videoID)
        {
            TempData["showClientMenu"] = null;
            video result = new video();
            try
            {

                result = kaisokku_businesslayer.UpdateVideoView(videoID);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("Home / AddUserInformation : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);

                return Json(new { errorcode = "1", errormessage = "Unable to insert" }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult FAQS()
        {
            return View();
        }
        public ActionResult Privacy()
        {
            return View();
        }
        public ActionResult Termsandcondition()
        {
            return View();
        }
        public ActionResult Demo()
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = Server.MapPath("~/DemoExe/Kaisokku_login.exe");
                process.Start();
                process.Close();
                ViewBag.Result = "Done.";
            }
            catch (Exception ex)
            {
                ViewBag.Result = ex.Message;
            }
            ViewBag.Error = "Successfully Executed.";
            //return View("Index");
            return RedirectToAction("Index");
            //return View();
        }
    }
}