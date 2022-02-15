using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Threading;

namespace Vastu.Controllers
{
    
    public class LanguageController : Controller
    {
        //GET: Language
       public ActionResult Index()
        {
            ViewBag.Language = "Language";

            return View();
        }
        public ActionResult Change(string LanguageAbbrevation,string type)
        {

            if (LanguageAbbrevation != null)
            {

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbrevation);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageAbbrevation);

            }

            ViewBag.Language = "Language";
            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = LanguageAbbrevation;
            Response.Cookies.Add(cookie);
            Session["Values"] = LanguageAbbrevation;
            TempData["lan"] = LanguageAbbrevation;
            if (type == "1")
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "UserMaster");

        }
    }
}