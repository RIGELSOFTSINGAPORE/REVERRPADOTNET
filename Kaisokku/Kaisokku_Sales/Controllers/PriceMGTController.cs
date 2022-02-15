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
    public class PriceMGTController : BaseController
    {
        private Kaisokku_BusinessLayer kaisokku_businesslayer;
        // GET: ClintMGT
        public PriceMGTController()
        {
            kaisokku_businesslayer = new Kaisokku_BusinessLayer(base.ConnectionString);
        }

        // GET: PriceMGT
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
          
            return View();
        }
        public ActionResult LoadPricedata(jQueryDataTableParamModel<Pricemgt> param)
        {
            TempData["showClientMenu"] = null;
            try
            {

                var draw = param.draw;

                int recordsTotal = 0;

                // Getting all Customer data    
                var result = kaisokku_businesslayer.GetPrice();

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
        public ActionResult SavePrice()
        {
            OutPut result = new OutPut();
            try
            {

              
                var Productname = Request.Form["Productname"];
                var Validity = Request.Form["Validity"];
                var Price = Convert.ToDecimal(Request.Form["Price"]);
                
                result = kaisokku_businesslayer.CreatePrice(Productname, Validity, Price);
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("Home / SaveCreateSocialMediaData : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return Json(new { errorcode = -1, errormessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetPriceDataById(Pricemgt obj)
        {
            Pricemgt result = kaisokku_businesslayer.GetPriceLiById(obj);            
            return View("Create", result);
        }
        public JsonResult SavePriceListData()
        {
            
            OutPut result = new OutPut();
            var Productname = Request.Form["Productname"];
            var Validity = Request.Form["Validity"];
            decimal Price = Convert.ToDecimal( Request.Form["Price"]);
            //var Price = Convert.ToDecimal(Request.Form["Price"]).ToString();
            int Id = Int32.Parse(Request.Form["Id"]);
            
            try
            {
               
                result = kaisokku_businesslayer.SavePriceListData(Id, Productname, Validity, Price);
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("Home / SaveSocialMediaListData : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return Json(new { errorcode = -1, errormessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }


            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeletepriceById(Pricemgt obj)
        {
            TempData["showClientMenu"] = null;
            OutPut result = new OutPut();

            result = kaisokku_businesslayer.DeletePriceId(obj.ID);


            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }
    }
}