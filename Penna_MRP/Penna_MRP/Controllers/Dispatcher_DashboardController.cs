using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Penna_Business;
using Penna_Common;
using System.Data;
using ClosedXML.Excel;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
namespace Penna_MRP.Controllers
{
   // [Authorize(Roles = "3")]
    public class Dispatcher_DashboardController : BaseController
    {
        private Penna_BusinessLayer _Penna_BusinessLayer;
        public Dispatcher_DashboardController()
        {
            _Penna_BusinessLayer = new Penna_BusinessLayer(base.ConnectionString);
        }
        public ActionResult Index()
        {
            try {
                Penna_PackerDetails penna_PackerDetails = new Penna_PackerDetails();
                List<Penna_PackerDetails> _Penna_PackerDetails = new List<Penna_PackerDetails>();
                _Penna_PackerDetails = _Penna_BusinessLayer.GetPackerDetails(penna_PackerDetails);

                ViewData["PackerDetails"] = _Penna_PackerDetails;
            }
            catch (Exception ex){
                LogInfo.LogMsg = string.Format("Dispatcher / Index : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }
            
            return View();
        }
        public ActionResult Create(Penna_PackerDetails penna_PackerDetails)
        {
            int result = 0;
            try
            {
                penna_PackerDetails.Created_By =1;
                penna_PackerDetails.Created_Date =DateTime.Now;
                
                List<Penna_PackerDetails> _Penna_PackerDetails = new List<Penna_PackerDetails>();
                _Penna_PackerDetails = _Penna_BusinessLayer.GetPackerDetails(penna_PackerDetails);
                ViewData["PackerDetails"] = _Penna_PackerDetails;
                ViewBag.Manual = "ManualEntry()";
                var result1 = _Penna_PackerDetails.Where(a => a.Delivery_Number == penna_PackerDetails.Delivery_Number);
                int cnt = result1.Count();
              
                if (penna_PackerDetails.Delivery_Number==""|| penna_PackerDetails.Delivery_Number==null||
                   penna_PackerDetails.Vehicle_Number==""|| penna_PackerDetails.Vehicle_Number == null||
                    penna_PackerDetails.Grade == "" || penna_PackerDetails.Grade == null ||
                   penna_PackerDetails.Set_Count == 0|| cnt>0)
                {
                    if (cnt > 0)
                    {
                        ViewBag.DNumber = "Delivery Number Is Already Exists";
                    }
                    if (penna_PackerDetails.Delivery_Number == "" || penna_PackerDetails.Delivery_Number == null)
                    {
                        ViewBag.DNumber = "Delivery Number Is Required";
                    }
                    if (penna_PackerDetails.Vehicle_Number == "" || penna_PackerDetails.Vehicle_Number == null)
                    {
                        ViewBag.VNumber = "Vehicle Number Is Required";
                    }
                    if (penna_PackerDetails.Grade == "" || penna_PackerDetails.Grade == null)
                    {
                        ViewBag.gmsg = "Grade Is Required";
                    }
                    if(penna_PackerDetails.Bag_Count == 0)
                    {
                        ViewBag.bCount = "Set count Is Required";
                    }
                    _Penna_PackerDetails = _Penna_BusinessLayer.GetPackerDetails(null);
                    ViewData["PackerDetails"] = _Penna_PackerDetails;
                    return View("Index", penna_PackerDetails);
                }
                if (penna_PackerDetails.MRP == 0)
                {
                    penna_PackerDetails.Message_Format = "No MRP";
                }
                else
                {
                    penna_PackerDetails.Message_Format = "MRP";
                }
                result = _Penna_BusinessLayer.insertpacker(penna_PackerDetails);
                _Penna_PackerDetails = _Penna_BusinessLayer.GetPackerDetails(null);
                ViewData["PackerDetails"] = _Penna_PackerDetails;
                ViewBag.Manual = "ManualEntry()";
                if (result == 0)
                {
                    penna_PackerDetails = null;
                    ViewBag.succmsg = "Record Saved Succesfully";
                    return RedirectToAction("Index", penna_PackerDetails);
                }
                else
                {
                    ViewBag.succmsg = "Record Saved Failed";
                    return View("Index");
                }
            }
            catch(Exception ex)
            {
                LogInfo.LogMsg = string.Format("Dispatcher / Create : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }

            return View("Index");
        }
        public ActionResult SAP()
        {
            try
            {
                var url = "https://netwaver-dev.pennacement.com:443/sap/opu/odata/sap/ZSD_MRP_PRINTING_SRV/MRPSet?$format=json&$filter=(Plant eq '1003')";
                string userName = "NWGW001";
                string passwd = "Penna@123";
                HttpClient client = new HttpClient();

                string authInfo = userName + ":" + passwd;
                authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = client.GetAsync(url).ContinueWith(task => task.Result).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("HTTP Response : " + response.IsSuccessStatusCode);
                    var httpResponseResult = response.Content.ReadAsStringAsync().ContinueWith(task => task.Result).Result;
                    JToken token1 = JToken.Parse(httpResponseResult);
                    JArray men1 = (JArray)token1.SelectToken("['d']['results']");
                    List<Penna_PackerDetails_SAP> varoutput = men1.ToObject<List<Penna_PackerDetails_SAP>>();
                    Penna_PackerDetails penna_PackerDetails = new Penna_PackerDetails();
                    foreach (var i in varoutput)
                    {
                        penna_PackerDetails.Delivery_Number = i.Vbeln;
                        penna_PackerDetails.Vehicle_Number = i.Traid;
                        decimal result;
                        int result2;
                        if (decimal.TryParse((i.Mrp), out result))
                        {
                            penna_PackerDetails.Message_Format = "MRP";
                            penna_PackerDetails.MRP = Convert.ToDecimal(i.Mrp);
                        }
                        else if (int.TryParse((i.Mrp), out result2))
                        {
                            penna_PackerDetails.Message_Format = "MRP";
                            penna_PackerDetails.MRP = Convert.ToDecimal(i.Mrp);
                        }
                        else
                        {
                            penna_PackerDetails.MRP = 0;
                            penna_PackerDetails.Message_Format = i.Mrp;
                        }
                        penna_PackerDetails.Bag_Count = Convert.ToInt32(i.Bags);
                        penna_PackerDetails.Set_Count = Convert.ToInt32(i.Bags);
                        penna_PackerDetails.Created_By = Convert.ToInt32(Session["UserId"]);
                        penna_PackerDetails.Grade = i.Vtext;
                        penna_PackerDetails.IsActive = "1";
                        _Penna_BusinessLayer.insertpacker(penna_PackerDetails);
                    }
                }
                else if (response.StatusCode.ToString() == "BadRequest")
                {
                }
                else
                {
                    Console.WriteLine("Web API Response Status Code: " + Convert.ToInt16(response.StatusCode) + ", Status : " + response.StatusCode);
                }
                Penna_PackerDetails penna_PackerDetails1 = new Penna_PackerDetails();
                List<Penna_PackerDetails> _Penna_PackerDetails = new List<Penna_PackerDetails>();
                _Penna_PackerDetails = _Penna_BusinessLayer.GetPackerDetails(penna_PackerDetails1);

                ViewData["PackerDetails"] = _Penna_PackerDetails;
                return View("Index");
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Packer Dashboard / SAP : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                ViewBag.err = ex;
                return View();
            }
        }
        internal static List<string> ModifiedFileName(string OrigFileName)
        {
            List<string> filename = new List<string>();
            var ext = Path.GetExtension(OrigFileName);
            var name = Path.GetFileNameWithoutExtension(OrigFileName);
            var dt = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            //var fileName = name + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ext;
            filename.Add(name + "_" + dt + ext);
            filename.Add(name + "_Error_" + dt + ext);
            return filename;

        }
        public ActionResult BulkUpload(Penna_PackerDetails penna_PackerDetails, HttpPostedFileBase file)
        {
            int result = 0;
            bool validFile = false;
            int failedRowCount = 0;
            int TotalRowCount = 0;
           // var regcurex = @"^\-?[0-9]+(?:\.[0-9]{1,2})?$";
            var regNumrex = @"\D";
            try
            {
                var fileName1 = file.FileName;
                var modFileName1 = ModifiedFileName(file.FileName);

                string path1 = Path.Combine(Server.MapPath("~/Files"),"bulkubload.xls".ToString());
                string path2 = Path.Combine(Server.MapPath("~/Files"),"bulkubload.xlsx".ToString());

                if (System.IO.File.Exists(@path1))
                {
                    System.IO.File.Delete(@path1);
                }
                if (System.IO.File.Exists(@path2))
                {
                    System.IO.File.Delete(@path2);
                }
                file.SaveAs(Path.Combine(Server.MapPath("~/Files"), "bulkubload.xls".ToString()));

                var converter = new GroupDocs.Conversion.Converter(path1);
               
                var convertOptions = converter.GetPossibleConversions()["xlsx"].ConvertOptions;
                
                converter.Convert(path2, convertOptions);

                DataTable dt = new DataTable();
                //if (file != null && file.ContentLength > 0 && System.IO.Path.GetExtension(file.FileName).ToLower() == ".xlsx")
                //{
                    var fileName = file.FileName;
                    var modFileName = ModifiedFileName(file.FileName);

                    string path = Path.Combine(Server.MapPath("~/UploadedFiles"), path2.ToString());
                    //Saving the file  
                  //  file.SaveAs(path);

                    //Started reading the Excel file.  
                    using (XLWorkbook workbook = new XLWorkbook(path2))
                    {
                        IXLWorksheet worksheet = workbook.Worksheet(1);
                        bool FirstRow = true;
                        //Range for reading the cells based on the last cell used.  
                        string readRange = "1:1";


                        IXLRow Firstrow = worksheet.RowsUsed().First();
                        readRange = string.Format("{0}:{1}", 1, Firstrow.LastCellUsed().Address.ColumnNumber);
                     
                        if (Firstrow.Cells(readRange).Count() == 5 &&
                            Firstrow.Cells(readRange).ToArray()[0].Value.ToString() == "Delivery" &&
                            Firstrow.Cells(readRange).ToArray()[1].Value.ToString() == "No.of Bags" &&
                            Firstrow.Cells(readRange).ToArray()[2].Value.ToString() == "Means of Trans. ID" &&
                            Firstrow.Cells(readRange).ToArray()[3].Value.ToString() == "Description" &&
                            Firstrow.Cells(readRange).ToArray()[4].Value.ToString() == "M.R.P" 
                          )
                        {
                            validFile = true;
                        }


                        if (validFile == true)
                        {
                                foreach (IXLRow row in worksheet.RowsUsed())
                                {
                                    TotalRowCount += 1;
                                    if (FirstRow)
                                    {
                                         readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                                        foreach (IXLCell cell in row.Cells(readRange))
                                        {
                                            dt.Columns.Add(cell.Value.ToString());
                                        }
                                        FirstRow = false;
                                    }
                                    else
                                    {
                                       
                                    dt.Rows.Add();
                                    int cellIndex = 0;
                                    bool isValid = true;
                                    //Updating the values of datatable  
                                    foreach (IXLCell cell in row.Cells(readRange))
                                        {
                                            var val = cell.Value.ToString().Trim();
                                            FirstRow = false;
                                        if (cellIndex == 0 && (val == null ||val == string.Empty|| val == ""))
                                        {
                                            
                                            isValid = false;
                                        }
                                        if (cellIndex == 1 &&(val == null ||val == string.Empty|| val == ""))
                                        {

                                            isValid = false;
                                        }
                                      
                                        dt.Rows[dt.Rows.Count - 1][cellIndex] = val;
                                        cellIndex++;
                                    }
                                    if (isValid == true)
                                    {
                                        penna_PackerDetails.Delivery_Number = dt.Rows[dt.Rows.Count - 1][0].ToString();
                                        penna_PackerDetails.Vehicle_Number = dt.Rows[dt.Rows.Count - 1][2].ToString();
                                        if (Regex.IsMatch(dt.Rows[dt.Rows.Count - 1][1].ToString(), regNumrex) == false)
                                        {
                                            penna_PackerDetails.Bag_Count =0;
                                            penna_PackerDetails.Bag_Count = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][1]);
                                            penna_PackerDetails.Set_Count = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][1]);

                                        }
                                        else
                                        {
                                            penna_PackerDetails.Bag_Count = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][1]);

                                        }
                                        if (dt.Rows[dt.Rows.Count - 1][4].ToString() == "" || dt.Rows[dt.Rows.Count - 1][4].ToString().ToUpper().Trim().Contains("MRP")==true)
                                        {
                                            penna_PackerDetails.MRP = 0;
                                        }
                                        else
                                        {
                                            penna_PackerDetails.MRP = Convert.ToDecimal(dt.Rows[dt.Rows.Count - 1][4]);
                                        }
                                        if (penna_PackerDetails.MRP == 0)
                                        {
                                            penna_PackerDetails.Message_Format = "No MRP";
                                        }
                                        else
                                        {
                                            penna_PackerDetails.Message_Format = "MRP";
                                        }
                                        penna_PackerDetails.Grade = dt.Rows[dt.Rows.Count - 1][3].ToString();
                                        penna_PackerDetails.Created_Date = DateTime.Now;
                                        penna_PackerDetails.Created_By = 1;
                                        List<Penna_PackerDetails> _PackerDetails = new List<Penna_PackerDetails>();
                                        _PackerDetails = _Penna_BusinessLayer.GetPackerDetails(penna_PackerDetails);
                                        if (_PackerDetails.Count <= 0)
                                        {
                                            result = _Penna_BusinessLayer.insertpacker(penna_PackerDetails);
                                        }
                                    }
                                }
                               


                            }

                            // datatable row = 0 then nows found
                            // datatable row > 0 and failedRowCount = 0 then all rows success
                            // datatable row = failedRowCount all are fail
                            // datatable row > 0 and failedRowCount > 0 and datatable row <> failedRowCount Partrial success

                            if (failedRowCount == TotalRowCount)
                            {

                               
                            }
                            else if (failedRowCount == 0)
                            {
                              
                            }
                            else
                            {
                            }
                        }

                        if (validFile == false)
                        {
                           
                        }
                        else if (FirstRow)
                        {
                            ViewBag.msg = "Empty Excel File!";
                        }
                    }
                //}
                //else
                //{
                //    //If file extension of the uploaded file is different then .xlsx  
                //}

                
                List<Penna_PackerDetails> _Penna_PackerDetails = new List<Penna_PackerDetails>();
                _Penna_PackerDetails = _Penna_BusinessLayer.GetPackerDetails(penna_PackerDetails);
                ViewData["PackerDetails"] = _Penna_PackerDetails;
                if (result == 0)
                {
                    penna_PackerDetails = null;
                    ViewBag.succmsg = "Record Saved Succesfully";
                    return RedirectToAction("Index", penna_PackerDetails);
                }
                else
                {
                    ViewBag.succmsg = "Record Saved Failed";
                    return View("Index");
                }
            }
            catch(Exception ex)
            {
                LogInfo.LogMsg = string.Format("BulkUpload / Index : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }

            return View("Index");
        }
    }
}