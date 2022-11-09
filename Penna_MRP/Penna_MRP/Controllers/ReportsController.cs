using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Penna_Common;
using Penna_Business;
using System.Data;
using ClosedXML.Excel;
using System.IO;

namespace Penna_MRP.Controllers
{
    [Authorize]
    public class ReportsController : BaseController
    {
        private Penna_BusinessLayer _Penna_BusinessLayer;
        public ReportsController()
        {
            _Penna_BusinessLayer = new Penna_BusinessLayer(base.ConnectionString);
        }
        public ActionResult Index()
        {
            try
            {
                //List<Penna_PackerDetails> _Penna_PackerDetails = new List<Penna_PackerDetails>();
                //_Penna_PackerDetails = _Penna_BusinessLayer.GetPackerDetails(null);
                //ViewData["PackerDetails"] = _Penna_PackerDetails;
                GetDeliveryNo("");

               
                return View();
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Report / Index : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                ViewBag.err = ex;
                return View();
            }

        }
        public ActionResult ClickQuery(Penna_PackerDetails penna_PackerDetails)
        {
            try
            {
                List<Penna_PackerDetails> _Penna_PackerDetails = new List<Penna_PackerDetails>();
                _Penna_PackerDetails = _Penna_BusinessLayer.GetPackerDetails(penna_PackerDetails);
                ViewData["PackerDetails"] = _Penna_PackerDetails;
                GetDeliveryNo("");
                return View("Index");
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Report / ClickQuery : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                ViewBag.err = ex;
                return View("Index", penna_PackerDetails);
            }

        }

        public ActionResult Export(string packer, string startdate,string Enddate,string bustedbag,string checkbox)
        {
            try
            {
                Penna_PackerDetails penna_PackerDetails = new Penna_PackerDetails();

                if(startdate!=""&& startdate != null)
                {
                    penna_PackerDetails.Start_Date_Time = Convert.ToDateTime(startdate);
                }
                if (Enddate != "" && Enddate != null)
                {
                    penna_PackerDetails.End_Date_Time = Convert.ToDateTime(Enddate);
                }

               
                if(bustedbag!=""&& bustedbag!=null)
                {
                    penna_PackerDetails.Busted_Bag_Count = Convert.ToInt32(bustedbag);
                }
                if (packer != "" && packer != null)
                {
                    penna_PackerDetails.Packer = Convert.ToInt32(packer);
                }
                List<Penna_PackerDetails> _Penna_PackerDetails = new List<Penna_PackerDetails>();
                _Penna_PackerDetails = _Penna_BusinessLayer.GetPackerDetails(penna_PackerDetails);
               // ViewData["PackerDetails"] = _Penna_PackerDetails;
                GetDeliveryNo(""); 
                var fileName = "Packer" + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".xlsx";
                
                DataTable dt = new DataTable("Packer");
                dt.Columns.Add("Package_Details_PKID");
                dt.Columns.Add("Delivery_Number");
                dt.Columns.Add("Vehicle_Number");
                dt.Columns.Add("Message_Format");
                dt.Columns.Add("MRP");
                dt.Columns.Add("Grade");
                dt.Columns.Add("Set_Count");
                dt.Columns.Add("Bag_Count");
                dt.Columns.Add("InProgress_Bag_Count");
                dt.Columns.Add("Start_Date_Time");
                dt.Columns.Add("End_Date_Time");
                dt.Columns.Add("Status");
                dt.Columns.Add("IsActive");

               
                foreach (var element in _Penna_PackerDetails)
                {

                    DataRow dr = dt.NewRow();
                    dr[0] = element.packing_Status_details_PKID;
                    dr[1] = element.Delivery_Number;
                    dr[2] = element.Vehicle_Number;
                    dr[3] = element.Message_Format;
                    dr[4] = element.MRP;
                    dr[5] = element.Grade;
                    dr[7] = element.Set_Count;
                    dr[8] = element.Bag_Count;
                    dr[9] = element.InProgress_Bag_Count;
                    dr[10] = element.Start_Date_Time;
                    dr[11] = element.End_Date_Time;
                    dr[12] = element.Status;
                    dr[12] = element.IsActive;
                    dt.Rows.Add(dr);
                }
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt);
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                    }
                }
              
                
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Report / Export : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                ViewBag.err = ex;
                return View("Index");
            }

        }
        public ActionResult GetDeliveryNo(string DeliveryNo)
        {
            try
            {
                ViewBag.DeliveryNo = DeliveryNo;
                var Packer = new List<SelectListItem>();
                //List<Penna_PackerDetails> result = new List<Penna_PackerDetails>();
                //result = _Penna_BusinessLayer.GetPackerDetails(null);


                Packer.Add(new SelectListItem
                {
                    Text = "",
                    Value = ""

                });
                Packer.Add(new SelectListItem
                    {
                        Text ="Packer1",
                        Value = "1"

                    });

                Packer.Add(new SelectListItem
                {
                    Text = "Packer2",
                    Value = "2"

                });
                Packer.Add(new SelectListItem
                {
                    Text = "Packer3",
                    Value = "3"

                });
                Packer.Add(new SelectListItem
                {
                    Text = "Packer4",
                    Value = "4"

                });


                ViewBag.Packer = Packer;

                return View();
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Report / GetDeliveryNumber : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                Log.Error(LogInfo.LogMsg, ex);
                return View();
            }


        }
       
    }
}