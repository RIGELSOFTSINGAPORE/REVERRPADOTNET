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
    public class FeedbackApprovalController : Controller
    {
        // GET: TransactionHistory
        private FeedbackBusinessLayer _FeedbackBusinessLayer;
        public FeedbackApprovalController()
        {
            _FeedbackBusinessLayer = new FeedbackBusinessLayer();
        }
        //public ActionResult Index(string Frmdate, string Todate)
        //{
        //    LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
        //    LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
        //    LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
        //    List<Feedback> _usermst = new List<Feedback>();

        //    var GetUser = new List<Feedback>();

        //    try
        //    { 

        //        var frmDate = Request.Form["Frmdate"];
        //        var toDate = Request.Form["Todate"];
        //        //var address = Request.Form["address"];
        //        if (Frmdate != null && Todate != null)
        //        {
        //            _usermst = _FeedbackBusinessLayer.SearchFeedbackAdmin(Frmdate, Todate);
        //        }
        //        else
        //        {
        //            _usermst = _FeedbackBusinessLayer.feedbackend();

        //        }
        //    }


        //    catch (Exception ex)
        //    {
        //        LogInfo.LogMsg = string.Format("UserVastu / Index : {0} Message: {1} ", "", ex.Message);
        //        Log.Error(LogInfo.LogMsg, ex);
        //        TempData["ErrMsg"] = "error msg";
        //        return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
        //    }
        //    return View(_usermst);
        //}
        public ActionResult Index(int? page, DateTime? fromDate, DateTime? toDate)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<Feedback> _imagemst = new List<Feedback>();


            int pageSize;
            if (System.Configuration.ConfigurationManager.AppSettings["PageSize"] == null)
            {
                pageSize = 5;
            }
            else
            {
                pageSize = 5;
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
                    _imagemst = _FeedbackBusinessLayer.SearchFeedbackAdmin(ViewBag.fromDate, ViewBag.toDate);
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


        public ActionResult update(int? id,int ?del, int? page, DateTime? fromDate, DateTime? toDate)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<Feedback> _usermst = new List<Feedback>();

            var GetUser = new List<Feedback>();

            try
            {
                int ID = Convert.ToInt16(id);
                int DEL = Convert.ToInt16(del);
                //var address = Request.Form["address"];
                _usermst = _FeedbackBusinessLayer.FeedbackAdmin(ID,DEL);
                if (DEL == 3)
                {
                     TempData["SuccMsg"] = Vastu.Resources.Resource.Feedbackrejectedsuccessfully;
                }
                else
                {
                     TempData["SuccMsg"] = Vastu.Resources.Resource.Feedbackapprovedsuccessfully;
                }
            }


            catch (Exception ex)
            {
                if (del == 3)
                {
                    TempData["ErrMsg"] = Vastu.Resources.Resource.Feedbackrejectionfailed;
                }
                else
                {
                    TempData["ErrMsg"] = Vastu.Resources.Resource.Feedbackapprovalfailed;
                }
                LogInfo.LogMsg = string.Format("UserVastu / Index : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = "error msg";
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            return RedirectToAction("Index",new { fromDate= fromDate, toDate = toDate,page = page });
        }
        public ActionResult DeleteFeedbackMaster(int? id, int? del, int? page, DateTime? fromDate, DateTime? toDate)
        {

            try
            {
                int result = 0;
                int ID = Convert.ToInt16(id);

                result = _FeedbackBusinessLayer.deletefeedback(ID);


                TempData["SuccMsg"] = Vastu.Resources.Resource.feedbackdeletedsucessfully;
            }
            catch (Exception ex)
            {
                TempData["ErrMsg"] = Vastu.Resources.Resource.Feedbackdeletionfailed;
            }
            return RedirectToAction("Index", new { fromDate = fromDate, toDate = toDate, page = page });
        }

    }
}