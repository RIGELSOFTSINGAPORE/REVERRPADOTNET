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

using System.Net.Mail;
using PagedList;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Mime;
using System.Data;
using ClosedXML.Excel;
using System.Text;


namespace Kaisokku_Upload_Download.Controllers
{
    public class HomeController : BaseController
    {
        private Kaisokku_BusinessLayer kaisokku_businesslayer;
        public HomeController()
        {
            kaisokku_businesslayer = new Kaisokku_BusinessLayer(base.ConnectionString);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Upload()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Email()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(jQueryDataTableParamModel<Tasks> param)
        {
            var option = Request["ReportName"];
            var reporttype = Request["ReportType"];
            var startdate = Request["startdate"];
            var enddate = Request["enddate"];
            DataTable dt = new DataTable("Report");
            var result = kaisokku_businesslayer.GetDRSRep();
            var draw = param.draw;
            int recordsTotal = 0;
            var data = result.ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            
        }
        public JsonResult SaveFileData()
        {

            OutPut result = new OutPut();

            string path = Server.MapPath("~/Files/");
            HttpFileCollectionBase files = Request.Files;

            // result = kaisokku_businesslayer.SaveVideoListData(VideoId, VideoTitle, VideoDesc);

            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];
                file.SaveAs(path + file.FileName);
                //result = kaisokku_businesslayer.SaveCreateVideoFileList(file.FileName, VideoId);
            }
            result.ErrorCode = "0";
            return Json(new { errorcode = result.ErrorCode, errormessage = result.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Export()
        {
            DataTable dt = new DataTable("Report");
            var result = kaisokku_businesslayer.GetDRSRep();
            dt.Columns.AddRange(new DataColumn[15] { new DataColumn("Service Order No"),
                                            new DataColumn("Engineer"),
                                            new DataColumn("Product"),
                                            new DataColumn("Inwarranty Labour"),
                                            new DataColumn("Inwarranty Parts"),
                                            new DataColumn("Inwarranty Transport"),
                                            new DataColumn("Inwarranty Others"),
                                            new DataColumn("Inwarranty Tax"),
                                            new DataColumn("Inwarranty Total"),
                                            new DataColumn("Outwarranty Labour"),
                                            new DataColumn("Outwarranty Parts"),
                                            new DataColumn("Outwarranty Transport"),

                                            new DataColumn("Outwarranty Others"),
                                            new DataColumn("Outwarranty Tax"),
                                            new DataColumn("Outwarranty Total")

            });
            foreach (var Results in result)
            {
                dt.Rows.Add(Results.ServiceOrderNo, Results.Engineer, Results.Product, Results.inLabour,Results.inParts,Results.inTransport,Results.inothers,Results.inTax,Results.inTotal,Results.outParts,Results.outParts,Results.outTransport,Results.outthers,Results.outTax,Results.outTotal);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DRS-Report.xlsx");
                }
            }
        }
    }
    
}