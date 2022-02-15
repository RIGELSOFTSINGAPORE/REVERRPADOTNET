using DocumentFormat.OpenXml.InkML;
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
    public class ScoreMasterController : Controller
    {
        // GET: ScoreMaster
        private ScoreMasterBusinessLayer _ScoreMasterBusinessLayer;
        private ImageMasterBusinessLayer _ImageMasterBusinessLayer;
        public ScoreMasterController()
        {
            _ScoreMasterBusinessLayer = new ScoreMasterBusinessLayer();
            _ImageMasterBusinessLayer = new ImageMasterBusinessLayer();
        }
        public ActionResult Index(int? page)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<VS_SCORE_MST> _scoremst = new List<VS_SCORE_MST>();

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
            

            try
            {

                _scoremst = _ScoreMasterBusinessLayer.GetAllScore();


            
            }


            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Score Vastu / Index : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = "error msg";
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            return View(_scoremst.ToPagedList(pageNumber, pageSize));
        }

        // GET: ScoreMaster/Details/5


        // GET: ScoreMaster/Create

        public void BindImageDetails(int? val)
        {

          

            var selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem
            {
                Value = "",
                Text = Vastu.Resources.Resource.Select
            });
            List<VS_IMAGE_MST> imgmst = new List<VS_IMAGE_MST>();

            imgmst = _ImageMasterBusinessLayer.GetAllImageList();

            foreach(var element in imgmst)
            {
                if (val == Convert.ToInt32(element.IMAGE_ID))
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.IMAGE_ID.ToString(),
                        Text = element.IMAGE_DETAILS,
                        Selected = true

                    });
                }
                else
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.IMAGE_ID.ToString(),
                        Text = element.IMAGE_DETAILS,
                    });

                }

            }
            

            ViewBag.ImageID = selectList;


        }
        public ActionResult Create()
        {
           

            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                BindImageDetails(0);
                ViewData["ImageDDL"] = _ImageMasterBusinessLayer.GetAllImageList();

                return View();
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Score Vastu / Create {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }

        // POST: ScoreMaster/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VS_SCORE_MST scoremst)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;
            BindImageDetails(scoremst.IMAGE_ID);
          
            ViewData["ImageDDL"] = _ImageMasterBusinessLayer.GetAllImageList();
            VS_IMAGE_MST imgmst = new VS_IMAGE_MST();
            imgmst = _ImageMasterBusinessLayer.GetImageByID(scoremst.IMAGE_ID);
            scoremst.IMAGE_URL = imgmst.IMAGE_URL;
            try
            {
               
                if (ModelState.IsValid == false)
                {
                    
                    return View(scoremst);
                }

                if (ModelState.IsValid)
                {
                    scoremst.SCORE_TEXT = scoremst.SCORE_TEXT.Trim();
                    
                    scoremst.STATUS_ID = 4;
                    scoremst.DELETE_FLAG = false;
                    scoremst.CREATED_USER = Convert.ToInt32(Session["USER_ID"].ToString());
                    
                    result = _ScoreMasterBusinessLayer.CreateScore(scoremst);

                    if (result == 16)
                    {
                        ModelState.Clear();
                        
                        TempData["ErrMsg"] = Vastu.Resources.Resource.ScoreDetailsAlreadyExists;
                        return View(scoremst);
                    }
                    
                    LogInfo.Comments = "Image Created - " + scoremst.SCORE.ToString();
                    TempData["SuccMsg"] = Vastu.Resources.Resource.ScoreCreatedSuccessfully;
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.Clear();
                    
                    TempData["ErrMsg"] = Vastu.Resources.Resource.UnabletoCreateScore;
                    return View(scoremst);
                }


            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Score Vastu / Create : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName)); ;
            }
        }

        // GET: ScoreMaster/Edit/5
        public ActionResult Edit(int scoreid)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            VS_SCORE_MST _scoremst = new VS_SCORE_MST();
           
            ViewData["ImageDDL"] = _ImageMasterBusinessLayer.GetAllImageList();

            try
            {

                _scoremst = _ScoreMasterBusinessLayer.GetScoreByID(scoreid);
                 BindImageDetails(_scoremst.IMAGE_ID);

            }


            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Score Vastu / Index : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = Vastu.Resources.Resource.errormsg;
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

            return View(_scoremst);
        }

        // POST: ScoreMaster/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VS_SCORE_MST scoremst)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;
            BindImageDetails(scoremst.IMAGE_ID);
            ViewData["ImageDDL"] = _ImageMasterBusinessLayer.GetAllImageList();

            VS_IMAGE_MST imgmst = new VS_IMAGE_MST();
            imgmst = _ImageMasterBusinessLayer.GetImageByID(scoremst.IMAGE_ID);
            scoremst.IMAGE_URL = imgmst.IMAGE_URL;
            try
            {
                
                if (ModelState.IsValid == false)
                {
                    return View(scoremst);
                }

                if (ModelState.IsValid)
                {
                    scoremst.SCORE_TEXT = scoremst.SCORE_TEXT.Trim();
                    scoremst.STATUS_ID = 4;

                    scoremst.UPDATED_USER = Convert.ToInt32(Session["USER_ID"].ToString());

                    

                    result = _ScoreMasterBusinessLayer.UpdateScore(scoremst);

                    if (result == 16)
                    {
                        ModelState.Clear();
                        
                        TempData["ErrMsg"] = Vastu.Resources.Resource.ScoreDetailsAlreadyExists;
                        return View(scoremst);
                    }
                    
                    LogInfo.Comments = "Score Updated - " + scoremst.SCORE.ToString();
                    TempData["SuccMsg"] = Vastu.Resources.Resource.ScoreUpdatedSuccessfully;
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.Clear();
                   
                    TempData["ErrMsg"] = Vastu.Resources.Resource.UnabletoUpdateScore;
                    return View(scoremst);
                }


            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Score Vastu / Update : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName)); ;
            }
        }

    }
}
