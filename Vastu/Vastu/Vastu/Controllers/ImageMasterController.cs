using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vasthu_Models;
using Vastu_Business;
using System.IO;
using PagedList;

namespace Vastu.Controllers
{
    [SessionExpire]
    [Authorize]
    [VASTUCustomAuthorize(Roles = "1")]
    public class ImageMasterController : Controller
    {
        // GET: ImageMaster

        private ImageMasterBusinessLayer _ImageMasterBusinessLayer;
        public ImageMasterController()
        {
            _ImageMasterBusinessLayer = new ImageMasterBusinessLayer();
        }
        public ActionResult Index(int? page)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<VS_IMAGE_MST> _imagemst = new List<VS_IMAGE_MST>();

            
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

                _imagemst = _ImageMasterBusinessLayer.GetAllImage();


                
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

        // GET: ImageMaster/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ImageMaster/Create
        public ActionResult Create()
        {
            
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
          
            try
            {

                return View();

            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Image Vastu / Create : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName)); ;
            }
        }

        // POST: ImageMaster/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VS_IMAGE_MST imgmst)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;
            try
            {
                ModelState["IMAGE_URL"].Errors.Clear();
                if (ModelState.IsValid == false)
                {
                    return View(imgmst);
                }
                
                if (ModelState.IsValid)
                {
                    imgmst.IMAGE_DETAILS = imgmst.IMAGE_DETAILS.Trim();
                    imgmst.STATUS_ID = 4;

                    imgmst.CREATED_USER = Convert.ToInt32(Session["USER_ID"].ToString());
                    var fileName = Vasthu_Models.Common.ModifiedFileName(imgmst.PostedFile.FileName);
                   
                    var fileNameTmp = Path.Combine(Server.MapPath("~/ScoreImage"), fileName);
                    imgmst.IMAGE_URL = fileName;
                    result = _ImageMasterBusinessLayer.CreateImage(imgmst);
                    
                    if (result == 16)
                    {
                        ModelState.Clear();

                        TempData["ErrMsg"] = Vastu.Resources.Resource.ImageDetailsAlreadyExists;
                        return View(imgmst);
                    }
                    else
                    {
                        

                        imgmst.PostedFile.SaveAs(fileNameTmp);
                    }
                    LogInfo.Comments = "Image Created - " + imgmst.IMAGE_DETAILS.ToString();
                    TempData["SuccMsg"] = Vastu.Resources.Resource.ImageCreatedSuccessfully;
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.Clear();

                    TempData["ErrMsg"] = Vastu.Resources.Resource.UnabletoCreateImage;
                    return View(imgmst);
                }
              

            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Image Vastu / Create : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName)); ;
            }
        }

        // GET: ImageMaster/Edit/5
        public ActionResult Edit(int id)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            VS_IMAGE_MST _imagemst = new VS_IMAGE_MST();



            try
            {

                _imagemst = _ImageMasterBusinessLayer.GetImageByID(id);
               
            }


            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Image Vastu / Edit : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = Vastu.Resources.Resource.errormsg;
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

            return View(_imagemst);
        }

        // POST: ImageMaster/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VS_IMAGE_MST imgmst)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;
            string oldFileName = imgmst.IMAGE_URL;
            var fileName = "";
            var fileNameTmp = "";
            try
            {
                ModelState["PostedFile"].Errors.Clear();
                if (ModelState.IsValid == false)
                {
                    return View(imgmst);
                }

                if (ModelState.IsValid)
                {
                    imgmst.IMAGE_DETAILS = imgmst.IMAGE_DETAILS.Trim();
                    imgmst.STATUS_ID = 4;
                    //imgmst.DELETE_FLAG = false;
                    imgmst.UPDATED_USER = Convert.ToInt32(Session["USER_ID"].ToString());

                    if(imgmst.PostedEditFile != null)
                    {
                        fileName = Vasthu_Models.Common.ModifiedFileName(imgmst.PostedEditFile.FileName);
                        ////To save file
                        fileNameTmp = Path.Combine(Server.MapPath("~/ScoreImage"), fileName);
                        imgmst.IMAGE_URL = fileName;
                    }
                    
                    result = _ImageMasterBusinessLayer.UpdateImage(imgmst);

                    if (result == 16)
                    {
                        ModelState.Clear();

                        TempData["ErrMsg"] = Vastu.Resources.Resource.ImageDetailsAlreadyExists;
                        return View(imgmst);
                    }
                    else
                    {
                        if (imgmst.PostedEditFile != null)
                        {
                            if (System.IO.File.Exists(Path.Combine(Server.MapPath("~/ScoreImage"), oldFileName)))
                            {
                                System.IO.File.Delete(Path.Combine(Server.MapPath("~/ScoreImage"), oldFileName));
                            }

                            imgmst.PostedEditFile.SaveAs(fileNameTmp);
                        }
                        
                    }
                    LogInfo.Comments = "Image Updated - " + imgmst.IMAGE_DETAILS.ToString();
                    TempData["SuccMsg"] = Vastu.Resources.Resource.ImageUpdatedSuccessfully;
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.Clear();

                    TempData["ErrMsg"] = Vastu.Resources.Resource.UnabletoUpdateImage;
                    return View(imgmst);
                }


            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Image Vastu / Update : {0} Message: {1} ", Session["LOGIN_NAME"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName)); ;
            }
        }

        // GET: ImageMaster/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ImageMaster/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
