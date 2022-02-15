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
    public class ClintMGTController : BaseController
    {
        private Kaisokku_BusinessLayer kaisokku_businesslayer;
        // GET: ClintMGT
        public ClintMGTController()
        {
            kaisokku_businesslayer = new Kaisokku_BusinessLayer(base.ConnectionString);
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ClintCreate()
        {
            TempData["showClientMenu"] = null;
            return View();
        }
        public ActionResult LoadClienddata(jQueryDataTableParamModel<ClintUser> param)
        {
            TempData["showClientMenu"] = null;
            try
            {

                var draw = param.draw;

                int recordsTotal = 0;

                // Getting all Customer data    
                var result = kaisokku_businesslayer.GetClient();

                //total number of rows count     
                recordsTotal = result.Count();
                //Paging     
                //var data = result.Skip(skip).Take(pageSize).ToList();
                var data = result.ToList();
                //Returning Json Data    
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception )
            {
                throw;
            }

        }
        public ActionResult SaveClient()
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();
            // OutPut mediaid = new OutPut();
            var Description = Request.Form["Description"];
            var Image = Request.Form["Image"];
            var clintName = Request.Form["clintName"];
            var Website = Request.Form["Website"];
            string path = Server.MapPath("~/Images/");
            HttpFileCollectionBase files = Request.Files;

          

           

            try
            {
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];
                    file.SaveAs(path + file.FileName);
                    result = kaisokku_businesslayer.CreateClient(Description, file.FileName, clintName, Website);
                }
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("Home / SaveCreateSocialMediaData : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return Json(new { errorcode = -1, errormessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetClientDataById(ClintUser obj)
        {
            TempData["showClientMenu"] = null;
            ClintUser result = kaisokku_businesslayer.GetClientLiById(obj);
            List<ClintUser> SelectVideonew = kaisokku_businesslayer.GetClintListById(obj);
            var list = new SelectList(SelectVideonew, "Filename", "Filename");

            TempData["SelectVideo"] = list;
            return View("ClintCreate", result);
        }
        public JsonResult SaveClientListData()
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();
            var Description = Request.Form["Description"];
            var Image = Request.Form["Image"];
            var img= Request.Form["img"];
            var clintName = Request.Form["clintName"];
            var Website = Request.Form["Website"];
            string path = Server.MapPath("~/Images/");
            HttpFileCollectionBase files = Request.Files;
            int Id = Int32.Parse(Request.Form["Id"]);
            //var Filename = Request.Form["Filename"];
            var fname = "";
            //result = kaisokku_businesslayer.SaveSocialMediaListData(SocialMediaID, Title, URL, Filename);
            try
            {
                if(img==""||img==null||img== "Noimg") { 
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];
                    file.SaveAs(path + file.FileName);
                    fname =  file.FileName;
                }
                }
                else
                {
                    fname = img;
                }
                result = kaisokku_businesslayer.SaveClintListData(Id, Description, clintName, Website, fname);
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("Home / SaveSocialMediaListData : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return Json(new { errorcode = -1, errormessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }


            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteClientById(ClintUser obj)
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();

            result = kaisokku_businesslayer.DeleteClientId(obj.Id);


            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }

    }
}
