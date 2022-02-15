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
using Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Core;
using System.Drawing;
using System.Threading;
using System.Globalization;


namespace Kaisokku_Sales.Controllers
{
    public class ContentController : BaseController
    {
        private Kaisokku_BusinessLayer kaisokku_businesslayer;
        // GET: ClintMGT
        public ContentController()
        {
            kaisokku_businesslayer = new Kaisokku_BusinessLayer(base.ConnectionString);
        }

        public ActionResult Index()
        {
            TempData["showClientMenu"] = null;
            return View();
        }
        public ActionResult ContentCreate()
        {
            TempData["showClientMenu"] = null;
            return View();
        }
        public ActionResult LoadContentdata(jQueryDataTableParamModel<Content> param)
        {
            TempData["showClientMenu"] = null;
            try
            {

                var draw = param.draw;
                int recordsTotal = 0;
                var result = kaisokku_businesslayer.Getcontent();

                recordsTotal = result.Count();
                var data = result.ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception )
            {
                throw;
            }

        }
        public ActionResult Savecontent(SaveContent content)
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();

            string Description = content.Description;
            var Title = content.Title;
            var User ="User" ;
            var ID = Convert.ToInt32(content.Id);

            if (Request.Form["Edit"] == "EditTrue")
            {
                result = kaisokku_businesslayer.SaveContentListData(ID, Title, Description, User);
                return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage,status="Edit" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                result = kaisokku_businesslayer.Createcontent(Title, Description, User);
                return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage, status = "Create" }, JsonRequestBehavior.AllowGet);

            }




        }
        //public ActionResult GetContentDataById(Content obj)
        //{
        //    TempData["showClientMenu"] = null;
        //    Content result = kaisokku_businesslayer.GetcontentId(obj);          

        //    return View("Index", result);
        //}
        public JsonResult GetContentDataById(Content obj)
        {
            try
            {
                TempData["showClientMenu"] = null;
                Content result = kaisokku_businesslayer.GetcontentId(obj);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("Home / GetPageListDataById : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }
            return Json(new { errorcode = "1", errormessage = "failure" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SaveContentListData()
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();
            var Description = Request.Form["Description"];
            var Image = Request.Form["Image"];
            var clintName = Request.Form["clintName"];
            var Website = Request.Form["Website"];
            int Id = Int32.Parse(Request.Form["Id"]);


            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeletecontentById(Content obj)
        {
            OutPut result = new OutPut();
            result = kaisokku_businesslayer.DeleteContentId(obj.Id);


            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }

    }
}
