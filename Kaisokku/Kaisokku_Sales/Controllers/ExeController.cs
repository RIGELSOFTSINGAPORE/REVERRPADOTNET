using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kaisokku_Sales.Controllers
{
    public class ExeController : Controller
    {
        // GET: Exe
        public ActionResult Index()
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = Server.MapPath("~/DemoExe/Kaisokku_login.exe");
                process.Start();
                process.Close();
                ViewBag.Result = "Done.";
            }
            catch(Exception ex)
            {
                ViewBag.Result = ex.Message;
            }
            ViewBag.Error = "Successfully Executed.";
            return RedirectToAction("Index", "Kaisokku_Home");
            //return View();
        }
    }
}