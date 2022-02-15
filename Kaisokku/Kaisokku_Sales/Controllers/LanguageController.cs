using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Threading.Tasks;
using Kaisokku_Business;
using Kaisokku_Common;
using Kaisokku_Sales.Models;
using System.Net.Mail;
using PagedList;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Mime;
using System.Data;
using ClosedXML.Excel;
using System.Text;
using Rotativa;
using System.Web.Helpers;
using System.Threading;
using System.Globalization;

namespace Kaisokku_Sales.Controllers
{
    public class LanguageController : BaseController
    {
        private string UserId = string.Empty;
        private Kaisokku_BusinessLayer kaisokku_businesslayer;

        public LanguageController()
        {
            kaisokku_businesslayer = new Kaisokku_BusinessLayer(base.ConnectionString);
        }
        // GET: Language
        public ActionResult LanguageSetting()
        {
            return View();
        }
        [HttpGet]
        [Authorize]
        public ActionResult Change(string LanguageAbbrevation)
        {
            

            if (LanguageAbbrevation != null)
            {

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbrevation);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageAbbrevation);

            }

            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = LanguageAbbrevation;
            Response.Cookies.Add(cookie);

            //Session["Values"] = LanguageAbbrevation;

            OutPut result = new OutPut();
            try
            {
                result = kaisokku_businesslayer.UpdateLanguageType(LanguageAbbrevation);
                

            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Language / Change : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }


            if (TempData["showClientMenu"] == null)
            {
                
                return RedirectToAction("DashBoard", "Home");
                //return RedirectToAction("Index", "Home", new { showUserMenu = false });

            }
            else
            {
                
                return RedirectToAction("Index", "Home",new { showUserMenu = true });
            }

        }

    }
}