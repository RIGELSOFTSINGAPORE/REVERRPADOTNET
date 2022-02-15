using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Vasthu_Models;
using Vastu_Business;

namespace Vastu.Controllers
{
    [SessionExpire]
    [Authorize]
    [VASTUCustomAuthorize(Roles = "1,2")]
    public class VastuTipsController : Controller
    {
        private VastuTipsBusinessLayer _VastuTipsBusinessLayer;
        public VastuTipsController()
        {

            _VastuTipsBusinessLayer = new VastuTipsBusinessLayer();
        }
        
        // GET: VastuTips
        public ActionResult Index()
        {
            ViewBag.VastuTips = "VastuTips";
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<MasterVastuTipsContent> obj = new List<MasterVastuTipsContent>();
            try
            {
               


                obj = _VastuTipsBusinessLayer.GetVastuTipsInformation();

                //var htmlString1 = HttpUtility.HtmlDecode(obj[0].ContentName);


                // string x = FindandReplace.SafeReplaceStartDIV(htmlString1, "<div>&nbsp;</div>", "<br>", true);

                // var htmlString2 = HttpUtility.HtmlDecode(x);

                //string y= FindandReplace.SafeReplaceRemoveNonBreakSpace(htmlString2);

                //var htmlString3 = HttpUtility.HtmlDecode(y);

                //string z = FindandReplace.SafeReplaceStartDIV(htmlString2, "<div>", "", true);


                //string finalresult = FindandReplace.SafeReplaceCloseDIV(z, "</div>", "&nbsp;", true);
                //obj[0].ContentName = finalresult;

                if (obj.Count > 0)
                {
                    if (obj[0].ContentName.ToLower().Contains("&nbsp;"))
                    {
                        string first = FindandReplace.SafeReplaceStartDIV(obj[0].ContentName, "<div>", "", true);
                        string second = FindandReplace.SafeReplaceCloseDIV(first, "</div>", "", true);
                        obj[0].ContentName = second;
                    }
                    else
                    {
                        
                    }
                }

            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("VastuTips / Index : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = "error msg";
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            return View(obj);
        }
    }
}