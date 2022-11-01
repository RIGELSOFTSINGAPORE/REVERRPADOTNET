using ClosedXML.Excel;
using MySqlConnector;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PennaMiddleWare.BLL;
using PennaMiddleWare.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Mvc;
using PagedList;

namespace PennaMiddleWare.Controllers
{
    public class StateWiseODController : Controller
    {
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        StreamWriter log1 = System.IO.StreamWriter.Null;

        // GET: StateWiseOD
        public ActionResult Index(string startDate, string endDate, string InputID, int? page, int? page1)
        {
            string filename = System.Configuration.ConfigurationManager.AppSettings["LogFile"].ToString();



            if (startDate != null)
            {
                ViewBag.startDate = startDate;
                ViewBag.endDate = endDate;
                DateTime date = new DateTime();
                DateTime.TryParseExact(startDate, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date);
                startDate = date.ToString("yyyy-MM-dd");
                DateTime.TryParseExact(endDate, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date);
                endDate = date.ToString("yyyy-MM-dd");
                startDate = startDate.Replace("-", string.Empty);
                endDate = endDate.Replace("-", string.Empty);

            }



            int Maxid = 0;
            List<ZFI_MW_STATEWISE_OD_SRV> lstsrvdeal = new List<ZFI_MW_STATEWISE_OD_SRV>();
            using (MySqlConnection con = new MySqlConnection(CS))
            {
                using (MySqlCommand cmd = new MySqlCommand("Select * from ZSD_MW_STATEWISE_OD_SRV where  ZSD_MW_STATEWISE_OD_SRV_PKID = " + Maxid))
                {

                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            lstsrvdeal.Add(new ZFI_MW_STATEWISE_OD_SRV
                            {
                                CreationDate = Convert.ToString(sdr["CreationDate"]),
                                Regio = Convert.ToString(sdr["Regio"]),
                                Ktokd = Convert.ToString(sdr["Ktokd"]),
                                TotalOs = Convert.ToDecimal(sdr["TotalOs"]),
                                TotalOverdue = Convert.ToDecimal(sdr["TotalOverdue"]),
                                TotalChqnrAmt = Convert.ToDecimal(sdr["TotalChqnrAmt"]),
                                CurrFyOdOs = Convert.ToDecimal(sdr["CurrFyOdOs"]),
                                PreFyOdOs = Convert.ToDecimal(sdr["PreFyOdOs"]),
                                PreFyClsOdOs = Convert.ToDecimal(sdr["PreFyClsOdOs"])
                            });
                        }
                    }
                    con.Close();
                }
            }
            if (InputID == "E")
            {
                DataTable dt1 = new DataTable("ZSD_MW_STATEWISE_OD_SRV");
                dt1.Columns.AddRange(new DataColumn[9]
                {

                        new DataColumn("Date"),
                        new DataColumn("Region"),
                        new DataColumn("Account group"),
                        new DataColumn("Total OS amt"),
                        new DataColumn("Total Overdue"),
                        new DataColumn("Cheque NR Amt"),
                        new DataColumn("Current yr OD OS"),
                        new DataColumn("Pre fy OD OS"),
                        new DataColumn("Pre fy closing OD OS")
                 });

                using (MySqlConnection con = new MySqlConnection(CS))
                {
                    string query = " Select * from ZSD_MW_STATEWISE_OD_SRV ";
                    query += " where date_format(cast( str_to_date(CreationDate,'%d.%m.%Y') as date),'%Y%m%d')  ";
                    query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";
                    query += " order by date_format(cast( str_to_date(CreationDate,'%d.%m.%Y') as date),'%Y%m%d') ";
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {

                        cmd.Connection = con;
                        con.Open();
                        using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                DataRow _dr = dt1.NewRow();
                                _dr["Date"] = Convert.ToString(sdr["CreationDate"]);
                                _dr["Region"] = Convert.ToString(sdr["Regio"]);
                                _dr["Account group"] = Convert.ToString(sdr["Ktokd"]);
                                _dr["Total OS amt"] = Convert.ToDecimal(sdr["TotalOs"]);
                                _dr["Total Overdue"] = Convert.ToDecimal(sdr["TotalOverdue"]);
                                _dr["Cheque NR Amt"] = Convert.ToDecimal(sdr["TotalChqnrAmt"]);
                                _dr["Current yr OD OS"] = Convert.ToDecimal(sdr["CurrFyOdOs"]);
                                _dr["Pre fy OD OS"] = Convert.ToDecimal(sdr["PreFyOdOs"]);
                                _dr["Pre fy closing OD OS"] = Convert.ToDecimal(sdr["PreFyClsOdOs"]);

                                dt1.Rows.Add(_dr);

                            }
                        }
                        con.Close();
                    }
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt1);
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ZSD_MW_STATEWISE_OD_SRV.xlsx");
                    }
                }
            }


            if (InputID == "S")
            {
                lstsrvdeal = GetStateWiseODDetails(startDate, endDate);


            }
            ViewData["GroupID"] = 0;
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
            if (page1 != null)
            {

                pageNumber = Convert.ToInt16(page1);
            }


            ViewData["lstsrvdeal"] = lstsrvdeal.ToPagedList(pageNumber, pageSize);

            return View(lstsrvdeal);
        }

        [HttpPost]
        public ActionResult Index(string startDate, string endDate, string InputID, int? page)
        {
            string filename = System.Configuration.ConfigurationManager.AppSettings["LogFile"].ToString();

            try
            {

                if (startDate != null)
                {
                    ViewBag.startDate = startDate;
                    ViewBag.endDate = endDate;
                    DateTime date = new DateTime();
                    DateTime.TryParseExact(startDate, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date);
                    startDate = date.ToString("yyyy-MM-dd");
                    DateTime.TryParseExact(endDate, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date);
                    endDate = date.ToString("yyyy-MM-dd");
                    startDate = startDate.Replace("-", string.Empty);
                    endDate = endDate.Replace("-", string.Empty);

                }

                string query = "";

                List<ZFI_MW_STATEWISE_OD_SRV> lstsrvdeal = new List<ZFI_MW_STATEWISE_OD_SRV>();
                DateTime fromDateValue;
                var formats = new[] { "ddMMyyyy", "yyyyMMdd", "yyyyMMdd" };
                if (!DateTime.TryParseExact(startDate.Trim(), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue) || !(DateTime.TryParseExact(endDate.Trim(), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue)))
                {
                    TempData["ErrMsg"] = "From Date or to Date is not Valid.Unable Process Request.";
                    return RedirectToAction("LogiCost");
                }


                if (InputID == "I")
                {


                    if (!System.IO.File.Exists(filename))
                    {
                        log1 = new StreamWriter(filename, append: true);
                    }
                    else
                    {
                        log1 = System.IO.File.AppendText(filename);
                    }
                    log1.WriteLine("===========================================");
                    log1.WriteLine("Application From Date  " + startDate);
                    log1.WriteLine("Application To Date  " + endDate);
                    log1.WriteLine("Executed on : " + DateTime.Now);
                    //log1.WriteLine("Table Name : ZSD_LCOST_DATA_SRV");
                    //string query = "";
                    int reccount = 0;



                    string startDateOrig = startDate;
                    string endDateOrig = endDate;
                    startDate = DateTime.ParseExact(startDate, "yyyyMMdd", null).ToString("yyyyMMdd");
                    endDate = DateTime.ParseExact(endDate, "yyyyMMdd", null).ToString("yyyyMMdd");

                    //Prod
                    //var url = "https://netwaver-prd.pennacement.com:443/sap/opu/odata/sap/ZFI_MW_STATEWISE_OD_SRV/STATEWISE_ODSet/?$filter=(CreationDate ge '" + startDateOrig.Trim() + "' and CreationDate le '" + endDateOrig.Trim() + "')&$format=json";
                    //string userName = "NWGW037";
                    //string passwd = "Admin@123456";


                    //Dev
                    var url = "https://netwaver-dev.pennacement.com:443/sap/opu/odata/sap/ZFI_MW_STATEWISE_OD_SRV/STATEWISE_ODSet/?$filter=(CreationDate ge '" + startDateOrig.Trim() + "' and CreationDate le '" + endDateOrig.Trim() + "')&$format=json";
                    string userName = "NWGW001";
                    string passwd = "Penna@123";

                    log1.WriteLine("Insert Table : ZSD_MW_STATEWISE_OD_SRV");

                    HttpClient client = new HttpClient();

                    string authInfo = userName + ":" + passwd;
                    authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);

                    client.BaseAddress = new Uri(url);

                    HttpResponseMessage response = client.GetAsync(url).ContinueWith(task => task.Result).Result;
                    // Parse the response body. Blocking!
                    if (response.IsSuccessStatusCode)
                    {
                        var httpResponseResult = response.Content.ReadAsStringAsync().ContinueWith(task => task.Result).Result;

                        JToken token1 = JToken.Parse(httpResponseResult);
                        JArray men1 = (JArray)token1.SelectToken("['d']['results']");
                        List<ZFI_MW_STATEWISE_OD_SRV> varoutput = men1.ToObject<List<ZFI_MW_STATEWISE_OD_SRV>>();
                        //var o = JsonConvert.DeserializeObject<List<ZSD_MW_REALISATION_SRV>>(men1.ToString());

                        //XElement elem = XElement.Parse(httpResponseResult);
                        //List<ZSD_MW_REALISATION_SRV> varoutput = new List<ZSD_MW_REALISATION_SRV>();

                        //foreach (XElement xo in elem.Elements())
                        //{
                        //    if (xo.Name.LocalName == "entry")
                        //    {
                        //        foreach (XElement xi in xo.Elements())
                        //        {
                        //            if (xi.Name.LocalName == "content")
                        //            {
                        //                foreach (XElement xc in xi.Elements())
                        //                {
                        //                    ZSD_MW_REALISATION_SRV objSW = new ZSD_MW_REALISATION_SRV();


                        //                    objSW.BillDate = ((System.Xml.Linq.XElement)xc.Nodes().ToList()[0]).Value;
                        //                    objSW.Depart = ((System.Xml.Linq.XElement)xc.Nodes().ToList()[1]).Value;
                        //                    objSW.Sno = ((System.Xml.Linq.XElement)xc.Nodes().ToList()[2]).Value;
                        //                    objSW.Statedesc = ((System.Xml.Linq.XElement)xc.Nodes().ToList()[3]).Value;
                        //                    objSW.TNetper = ((System.Xml.Linq.XElement)xc.Nodes().ToList()[4]).Value;
                        //                    objSW.TPerton = ((System.Xml.Linq.XElement)xc.Nodes().ToList()[5]).Value;
                        //                    objSW.NNetper = ((System.Xml.Linq.XElement)xc.Nodes().ToList()[6]).Value;
                        //                    objSW.NPerton = ((System.Xml.Linq.XElement)xc.Nodes().ToList()[7]).Value;
                        //                    objSW.TotNetper = ((System.Xml.Linq.XElement)xc.Nodes().ToList()[8]).Value;
                        //                    objSW.TotPerton = ((System.Xml.Linq.XElement)xc.Nodes().ToList()[9]).Value;
                        //                    objSW.MtNetper = ((System.Xml.Linq.XElement)xc.Nodes().ToList()[10]).Value;
                        //                    objSW.MtPerton = ((System.Xml.Linq.XElement)xc.Nodes().ToList()[11]).Value;
                        //                    objSW.MnNetper = ((System.Xml.Linq.XElement)xc.Nodes().ToList()[12]).Value;
                        //                    objSW.MnPerton = ((System.Xml.Linq.XElement)xc.Nodes().ToList()[13]).Value;
                        //                    objSW.MtotPerton = ((System.Xml.Linq.XElement)xc.Nodes().ToList()[14]).Value;
                        //                    objSW.MtotNetper = ((System.Xml.Linq.XElement)xc.Nodes().ToList()[15]).Value;
                        //                    objSW.Regio = ((System.Xml.Linq.XElement)xc.Nodes().ToList()[16]).Value;

                        //                    varoutput.Add(objSW);

                        //                }

                        //            }

                        //        }

                        //    }

                        //}

                        Common converter = new Common();


                        DataTable dt = converter.ToDataTable(varoutput);

                        if (dt.Rows.Count > 0)
                        {
                            Console.WriteLine();
                            log1.WriteLine("WebApi Record Count : " + dt.Rows.Count);

                        }
                        else
                        {
                            log1.WriteLine("WebApi Record Count : 0");
                        }

                        query = "";
                        query = " Delete from ZSD_MW_STATEWISE_OD_SRV ";
                        query += " where date_format(cast( str_to_date(CreationDate,'%d.%m.%Y') as date),'%Y%m%d')  ";
                        query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";



                        using (MySqlConnection sqlCon = new MySqlConnection(CS))
                        {
                            sqlCon.Open();
                            MySqlCommand Cmnd = new MySqlCommand(query, sqlCon);

                            int result = Cmnd.ExecuteNonQuery();

                            sqlCon.Close();
                        }




                        int i = 0;
                        using (MySqlConnection con = new MySqlConnection(CS))
                        {

                            con.Open();
                            foreach (DataRow row in dt.Rows)
                            {
                                query = "";
                                query = "Insert into zsd_mw_statewise_od_srv(CreationDate,Regio,Ktokd,TotalOs,";
                                query += "TotalOverdue,TotalChqnrAmt,CurrFyOdOs,PreFyOdOs,PreFyClsOdOs) Values ";
                                query += "(@CreationDate,@Regio,@Ktokd,@TotalOs,@TotalOverdue,";
                                query += "@TotalChqnrAmt,@CurrFyOdOs,@PreFyOdOs,@PreFyClsOdOs);";

                                MySqlCommand cmdt = new MySqlCommand(query, con);

                                cmdt.Parameters.AddWithValue("@CREATIONDATE", row["CREATIONDATE"].ToString());
                                cmdt.Parameters.AddWithValue("@REGIO", row["REGIO"].ToString());
                                cmdt.Parameters.AddWithValue("@KTOKD", row["KTOKD"].ToString());
                                cmdt.Parameters.AddWithValue("@TOTALOS", Convert.ToDecimal(row["TOTALOS"]));
                                cmdt.Parameters.AddWithValue("@TOTALOVERDUE", Convert.ToDecimal(row["TOTALOVERDUE"]));
                                cmdt.Parameters.AddWithValue("@TOTALCHQNRAMT", Convert.ToDecimal(row["TOTALCHQNRAMT"]));
                                cmdt.Parameters.AddWithValue("@CURRFYODOS", Convert.ToDecimal(row["CURRFYODOS"]));
                                cmdt.Parameters.AddWithValue("@PREFYODOS", Convert.ToDecimal(row["PREFYODOS"]));
                                cmdt.Parameters.AddWithValue("@PREFYCLSODOS", Convert.ToDecimal(row["PREFYCLSODOS"]));


                                cmdt.CommandType = CommandType.Text;
                                int result = cmdt.ExecuteNonQuery();

                                if (result == 1)
                                {
                                    i = i + 1;
                                }

                            }

                        }
                        log1.WriteLine("Executed End : " + DateTime.Now);
                        query = "";
                        query = " Select Count(*) from ZSD_MW_STATEWISE_OD_SRV ";
                        query += " where date_format(cast( str_to_date(CreationDate,'%d.%m.%Y') as date),'%Y%m%d')  ";
                        query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";

                        using (MySqlConnection sqlCon = new MySqlConnection(CS))
                        {
                            sqlCon.Open();
                            MySqlCommand Cmnd = new MySqlCommand(query, sqlCon);

                            object resultexscalar = Cmnd.ExecuteScalar();

                            if (resultexscalar != null)
                            {
                                reccount = Convert.ToInt32(resultexscalar);
                            }


                            sqlCon.Close();
                        }
                        if (dt.Rows.Count == reccount)
                        {
                            log1.WriteLine("Table record Count : " + reccount);
                            log1.WriteLine("Record Mathing");


                        }
                        else
                        {
                            log1.WriteLine("Table record Count : " + reccount);
                            log1.WriteLine("Record Insert Failed");
                        }


                    }
                    else
                    {
                        if (Convert.ToInt16(response.StatusCode) == 400)
                        {
                            query = "";
                            query = " Delete from ZSD_MW_STATEWISE_OD_SRV ";
                            query += " where date_format(cast( str_to_date(CreationDate,'%d.%m.%Y') as date),'%Y%m%d')  ";
                            query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";

                            using (MySqlConnection sqlCon = new MySqlConnection(CS))
                            {
                                sqlCon.Open();
                                MySqlCommand Cmnd = new MySqlCommand(query, sqlCon);

                                int result = Cmnd.ExecuteNonQuery();

                                sqlCon.Close();
                            }

                            query = "";
                            query = " Select Count(*) from ZSD_MW_STATEWISE_OD_SRV ";
                            query += " where date_format(cast( str_to_date(CreationDate,'%d.%m.%Y') as date),'%Y%m%d')  ";
                            query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";

                            using (MySqlConnection sqlCon = new MySqlConnection(CS))
                            {
                                sqlCon.Open();
                                MySqlCommand Cmnd = new MySqlCommand(query, sqlCon);

                                object resultexscalar = Cmnd.ExecuteScalar();

                                if (resultexscalar != null)
                                {
                                    reccount = Convert.ToInt32(resultexscalar);
                                }
                                sqlCon.Close();
                            }

                            if (reccount == 0)
                            {
                                log1.WriteLine("No Records found in API");
                            }
                        }
                        else
                        {
                            log1.WriteLine("Web API Response Status Code: " + Convert.ToInt16(response.StatusCode) + ", Status : " + response.StatusCode);
                        }
                    }

                    log1.WriteLine("===========================================");
                    log1.Close();

                }


                lstsrvdeal = GetStateWiseODDetails(startDate, endDate);
                //Index(startDate,endDate,"S",1,null);



                int pageSize;
                if (System.Configuration.ConfigurationManager.AppSettings["PageSize"] == null)
                {
                    pageSize = 10;
                }
                else
                {
                    pageSize = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["PageSize"].ToString());
                }
                int page1 = 1;
                int pageNumber = (page ?? 1);
                if (page1 != 0)
                {

                    pageNumber = Convert.ToInt16(page1);
                }

                ViewData["lstsrvdeal"] = lstsrvdeal.ToPagedList(pageNumber, pageSize);

                return View(lstsrvdeal);
            }
            catch (Exception ex)
            {
                if (!System.IO.File.Exists(filename))
                {
                    log1 = new StreamWriter(filename, append: true);
                }
                else
                {
                    log1 = System.IO.File.AppendText(filename);
                }
                log1.WriteLine("ZSD_MW_STATEWISE_OD_SRV Error Message : " + ex.Message);
                log1.WriteLine("===========================================");
                log1.Close();


                return View();


            }


        }

        private List<ZFI_MW_STATEWISE_OD_SRV> GetStateWiseODDetails(string startDate, string endDate)
        {
            List<ZFI_MW_STATEWISE_OD_SRV> lstsrvdeal = new List<ZFI_MW_STATEWISE_OD_SRV>();

            using (MySqlConnection con = new MySqlConnection(CS))
            {
                string query = " Select * from ZSD_MW_STATEWISE_OD_SRV ";
                query += " where date_format(cast( str_to_date(CreationDate,'%d.%m.%Y') as date),'%Y%m%d')  ";
                query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";
                query += " order by date_format(cast( str_to_date(CreationDate,'%d.%m.%Y') as date),'%Y%m%d') ";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {

                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            lstsrvdeal.Add(new ZFI_MW_STATEWISE_OD_SRV
                            {
                                CreationDate = Convert.ToString(sdr["CreationDate"]),
                                Regio = Convert.ToString(sdr["Regio"]),
                                Ktokd = Convert.ToString(sdr["Ktokd"]),
                                TotalOs = Convert.ToDecimal(sdr["TotalOs"]),
                                TotalOverdue = Convert.ToDecimal(sdr["TotalOverdue"]),
                                TotalChqnrAmt = Convert.ToDecimal(sdr["TotalChqnrAmt"]),
                                CurrFyOdOs = Convert.ToDecimal(sdr["CurrFyOdOs"]),
                                PreFyOdOs = Convert.ToDecimal(sdr["PreFyOdOs"]),
                                PreFyClsOdOs = Convert.ToDecimal(sdr["PreFyClsOdOs"]),
                            });
                        }
                    }
                    con.Close();
                }
            }

            return lstsrvdeal;
        }
    }
}