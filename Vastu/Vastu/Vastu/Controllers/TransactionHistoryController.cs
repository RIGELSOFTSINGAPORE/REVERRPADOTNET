using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vasthu_Models;
using Vastu_Business;
using PagedList;

namespace Vastu.Controllers
{
    [SessionExpire]
    [Authorize]
    [VASTUCustomAuthorize(Roles = "1")]
    public class TransactionHistoryController : Controller
    {
        // GET: TransactionHistory
        private TransactionReportBusinessLayer _TransactionReportBusinessLayer;
        public TransactionHistoryController()
        {
            _TransactionReportBusinessLayer = new TransactionReportBusinessLayer();
        }
        
        public ActionResult Index(int? page, DateTime? fromDate, DateTime? toDate)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<TransReport> _imagemst = new List<TransReport>();


            int pageSize;
            if (System.Configuration.ConfigurationManager.AppSettings["PageSize"] == null)
            {
                pageSize = 10;
            }
            else
            {
                pageSize = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["PageSize"].ToString());
            }

            int pageNumber = (page ?? 1);
            if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
            if (!toDate.HasValue) toDate = DateTime.Now.Date;
            if (toDate < fromDate) ViewBag.error = "Select Valid Date";

            ViewBag.fromDate = fromDate;
            ViewBag.toDate = toDate;
            if (ViewBag.error == null)
            {
                try


                {
                    _imagemst = _TransactionReportBusinessLayer.SearchTransDate(ViewBag.fromDate, ViewBag.toDate);
                }


                catch (Exception ex)
                {
                    LogInfo.LogMsg = string.Format("Image Vastu / Index : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                    Log.Error(LogInfo.LogMsg, ex);
                    TempData["ErrMsg"] = "error msg";
                    return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
                }
                return View(_imagemst.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return View(_imagemst.ToPagedList(pageNumber, pageSize));
            }
        }
    }
}