using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Penna_MRP.Controllers
{
    public class BaseController : Controller
    {
        private string _ConnectionString = ConfigurationManager.ConnectionStrings["Penna_SaleDBContext"].ConnectionString;
        public string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
        }

        public BaseController()
        {

        }
        public ActionResult Penna_Home()
        {
            //try
            //{
            //    if (Session["UserId"] != null)
            //    {
            //        return RedirectToAction("index", "Login");
            //    }

            //}
            //catch {
            //    return RedirectToAction("index", "Login");
            //}
            
            return View();
        }

    }
}