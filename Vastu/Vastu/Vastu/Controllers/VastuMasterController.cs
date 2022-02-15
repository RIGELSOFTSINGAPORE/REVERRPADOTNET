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
    public class VastuMasterController : Controller
    {
      
        private VastuMasterBusinessLayer _VastuMasterBusinessLayer;
  
        public VastuMasterController()
        {
            _VastuMasterBusinessLayer = new VastuMasterBusinessLayer();
 
        }
        // GET: VastuMaster
        public ActionResult Index(int? page,int ? area)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<VS_VASTU_MST> _vastumst = new List<VS_VASTU_MST>();

            int pageSize;
            if (System.Configuration.ConfigurationManager.AppSettings["PageSize"] == null)
            {
                pageSize = 9;
            }
            else
            {
                //pageSize = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["PageSize"].ToString());
                pageSize = 9;
            }

            int pageNumber = (page ?? 1);

            List<AreaVasthu> obj = new List<AreaVasthu>();
            obj = _VastuMasterBusinessLayer.Area();
            obj.Insert(0, new AreaVasthu { AREA_ID = 0, AREA = Vastu.Resources.Resource.Reportselect });

            ViewBag.SelectedAreaID = obj;

            try
            {
                var Area = Request.Form["Areadp"];           
                
                if (Area != null && Area != "0" && area == null)
                {
                    int AREAID = Convert.ToInt16(Area);
                    _vastumst = _VastuMasterBusinessLayer.GetAllVastu(AREAID);
                    ViewBag.AreaID = AREAID;

                }
                else if(area != null)
                {
                    int AREAID = Convert.ToInt16(area);
                    _vastumst = _VastuMasterBusinessLayer.GetAllVastu(AREAID);
                    ViewBag.AreaID = AREAID;

                }
                else
                {
                    _vastumst = _VastuMasterBusinessLayer.GetAllVastu(1);
                }
            }


            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Vastu Master/ Index : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = "error msg";
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            return View(_vastumst.ToPagedList(pageNumber, pageSize));
            
        }

        public void GetAllVastuTypeList(int? val)
        {

            var selectList = new List<SelectListItem>();
            //selectList.Add(new SelectListItem
            //{
            //    Value = "",
            //    Text = Vastu.Resources.Resource.Select
            //});
            List<VS_VASTU_TYPE_MST> imgmst = new List<VS_VASTU_TYPE_MST>();

            imgmst = _VastuMasterBusinessLayer.GetAllVastuTypeList();

            foreach (var element in imgmst)
            {
                if (val == Convert.ToInt32(element.VASTU_TYPE_ID))
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.VASTU_TYPE_ID.ToString(),
                        Text = element.VASTU_TYPE,
                        Selected = true

                    });
                }
                else
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.VASTU_TYPE_ID.ToString(),
                        Text = element.VASTU_TYPE,
                    });

                }

            }
           

            ViewBag.vastuTypeID = selectList;


        }
        public void GetAllAreaList(int? val)
        {

            var selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem
            {
                Value = "",
                Text = Vastu.Resources.Resource.Select
            });
            List<VS_AREA_MST> imgmst = new List<VS_AREA_MST>();

            imgmst = _VastuMasterBusinessLayer.GetAllAreaList();

            foreach (var element in imgmst)
            {
                if (val == Convert.ToInt32(element.AREA_ID))
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.AREA_ID.ToString(),
                        Text = element.AREA,
                        Selected = true

                    });
                }
                else
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.AREA_ID.ToString(),
                        Text = element.AREA,
                    });

                }

            }


            ViewBag.areaID = selectList;


        }
        public void GetAllDirectionList(int? val)
        {

            var selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem
            {
                Value = "",
                Text = Vastu.Resources.Resource.Select
            });
            List<VS_DIRECTION_MST> imgmst = new List<VS_DIRECTION_MST>();

            imgmst = _VastuMasterBusinessLayer.GetAllDirectionList();

            foreach (var element in imgmst)
            {
                if (val == Convert.ToInt32(element.DIRECTION_ID))
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.DIRECTION_ID.ToString(),
                        Text = element.DIRECTION,
                        Selected = true

                    });
                }
                else
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.DIRECTION_ID.ToString(),
                        Text = element.DIRECTION,
                    });

                }

            }


            ViewBag.directionID = selectList;


        }
        public void GetAllScoreList(int? val)
        {

            var selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem
            {
                Value = "",
                Text = Vastu.Resources.Resource.Select
            });
            List<VS_SCORE_MST> imgmst = new List<VS_SCORE_MST>();

            imgmst = _VastuMasterBusinessLayer.GetAllScoreList();

            foreach (var element in imgmst)
            {
                if (val == Convert.ToInt32(element.SCORE_ID))
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.SCORE_ID.ToString(),
                        Text = element.SCORE.ToString(),
                        Selected = true

                    });
                }
                else
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = element.SCORE_ID.ToString(),
                        Text = element.SCORE.ToString(),
                    });

                }

            }


            ViewBag.scoreID = selectList;


        }
        // GET: VastuMaster/Details/5


        // GET: VastuMaster/Create
        public ActionResult Create(int? area)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                GetAllVastuTypeList(2);
                if (area != 0)
                {
                    GetAllAreaList(area);
                }
                else
                {
                    GetAllAreaList(0);
                }
                GetAllDirectionList(0);
                GetAllScoreList(0);
              

                return View();
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Vastu / Create {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
         
        }

        // POST: VastuMaster/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VS_VASTU_MST vastumst)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;
            vastumst.DELETE_FLAG = false;
            GetAllVastuTypeList(vastumst.VASTU_TYPE_ID);
            GetAllAreaList(vastumst.AREA_ID);
            GetAllDirectionList(vastumst.DIRECTION_ID);
            GetAllScoreList(vastumst.SCORE_ID);
            try
            {

                if (ModelState.IsValid == false)
                {

                    return View(vastumst);
                }

                if (ModelState.IsValid)
                {
                    vastumst.SHORT_DESCRIPTION = vastumst.SHORT_DESCRIPTION == null ? null : vastumst.SHORT_DESCRIPTION.Trim();
                    vastumst.LONG_DESCRIPTION = vastumst.LONG_DESCRIPTION == null ? null : vastumst.LONG_DESCRIPTION.Trim();
                    
                    
                    vastumst.STATUS_ID = 4;
                    vastumst.DELETE_FLAG = false;

                    vastumst.CREATED_USER = Convert.ToInt32(Session["USER_ID"].ToString());

                    result = _VastuMasterBusinessLayer.CreateVastu(vastumst);
                    var area = vastumst.AREA_ID;
                    if (result == 16)
                    {
                        ModelState.Clear();
                       
                        TempData["ErrMsg"] = Vastu.Resources.Resource.ScoreDetailsAlreadyExists;
                        return View(vastumst);
                    }

                    LogInfo.Comments = "Vastu Created - " + vastumst.SCORE_ID.ToString();
                    TempData["SuccMsg"] = Vastu.Resources.Resource.VastuCreatedSuccessfully;
                    return RedirectToAction("Index", new { area = area });
                }
                else
                {
                    ModelState.Clear();
                    
                    TempData["ErrMsg"] = Vastu.Resources.Resource.UnabletoCreateVastu;
                    return View(vastumst);
                }


            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Vastu / Create : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName)); ;
            }
        }

        // GET: VastuMaster/Edit/5
        public ActionResult Edit(int vastuid)
        {
            
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            VS_VASTU_MST _vastumst = new VS_VASTU_MST();
        
           

            try
            {

                _vastumst = _VastuMasterBusinessLayer.GetVastuByID(vastuid);
                //GetAllVastuTypeList(_vastumst.VASTU_TYPE_ID);
                //GetAllAreaList(_vastumst.AREA_ID);
               // GetAllDirectionList(_vastumst.DIRECTION_ID);
                GetAllScoreList(_vastumst.SCORE_ID);


            }


            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Score Vastu / Index : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = Vastu.Resources.Resource.errormsg;
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

            return View(_vastumst);
        }

        // POST: VastuMaster/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VS_VASTU_MST vastumst)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;
            //GetAllVastuTypeList(vastumst.VASTU_TYPE_ID);
           // GetAllAreaList(vastumst.AREA_ID);
            //GetAllDirectionList(vastumst.DIRECTION_ID);
            GetAllScoreList(vastumst.SCORE_ID);

            try
            {

                if (ModelState.IsValid == false)
                {
                    return View(vastumst);
                }

                if (ModelState.IsValid)
                {
                    vastumst.SHORT_DESCRIPTION = vastumst.SHORT_DESCRIPTION == null ? null : vastumst.SHORT_DESCRIPTION.Trim();
                    vastumst.LONG_DESCRIPTION = vastumst.LONG_DESCRIPTION == null ? null : vastumst.LONG_DESCRIPTION.Trim();

                   
                    vastumst.STATUS_ID = 4;


                    vastumst.UPDATED_USER = Convert.ToInt32(Session["USER_ID"].ToString());



                    result = _VastuMasterBusinessLayer.UpdateVastu(vastumst);
                    var area = vastumst.AREA_ID;
                    if (result == 16)
                    {
                        ModelState.Clear();
                        
                        TempData["ErrMsg"] = Vastu.Resources.Resource.VastuDetailsAlreadyExists;
                        return View(vastumst);
                    }

                    LogInfo.Comments = "Vastu Updated - " + vastumst.VASTU_ID.ToString();
                    TempData["SuccMsg"] = Vastu.Resources.Resource.VastuTypeUpdatedSuccessfully;
                    return RedirectToAction("Index", new { area = area });
                }
                else
                {
                    ModelState.Clear();
                    
                    TempData["ErrMsg"] = Vastu.Resources.Resource.UnabletoUpdateVastuType;
                    return View(vastumst);
                }


            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Vastu / Update : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName)); ;
            }
        }

        public JsonResult DeleteVastuMaster(VS_VASTU_MST vastumst)
        {


            int result = 0;
            var VASTUID = Request.Form["VastuID"];
            int vastuid = Convert.ToInt16(VASTUID);
            result = _VastuMasterBusinessLayer.DeleteVastu(vastuid);


            return Json(new { errorcode = result }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteAreaMaster(VS_VASTU_MST vastumst)
        {


            int result = 0;
            var VASTUID = Request.Form["VastuID"];
            int vastuid = Convert.ToInt16(VASTUID);
            result = _VastuMasterBusinessLayer.DeleteArea(vastuid);


            return Json(new { errorcode = result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteVastuTypeMaster(VS_VASTU_MST vastumst)
        {


            int result = 0;
            var VASTUID = Request.Form["VastuID"];
            int vastuid = Convert.ToInt16(VASTUID);
            result = _VastuMasterBusinessLayer.DeleteVastuType(vastuid);


            return Json(new { errorcode = result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteScoreMaster(VS_VASTU_MST vastumst)
        {


            int result = 0;
            var VASTUID = Request.Form["VastuID"];
            int vastuid = Convert.ToInt16(VASTUID);
            result = _VastuMasterBusinessLayer.DeleteScoreMaster(vastuid);


            return Json(new { errorcode = result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteImageMaster(VS_VASTU_MST vastumst)
        {


            int result = 0;
            var VASTUID = Request.Form["VastuID"];
            int vastuid = Convert.ToInt16(VASTUID);
            result = _VastuMasterBusinessLayer.DeleteImageMaster(vastuid);


            return Json(new { errorcode = result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteUserMaster(VS_VASTU_MST vastumst)
        {


            int result = 0;
            var VASTUID = Request.Form["VastuID"];
            int vastuid = Convert.ToInt16(VASTUID);
            result = _VastuMasterBusinessLayer.DeleteUserMaster(vastuid);


            return Json(new { errorcode = result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteDirectionMaster(VS_VASTU_MST vastumst)
        {


            int result = 0;
            var VASTUID = Request.Form["VastuID"];
            int vastuid = Convert.ToInt16(VASTUID);
            result = _VastuMasterBusinessLayer.DeleteDirectionMaster(vastuid);


            return Json(new { errorcode = result }, JsonRequestBehavior.AllowGet);
        }

    }
}
