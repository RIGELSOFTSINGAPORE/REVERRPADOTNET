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
    public class CollnController : Controller
    {
        // GET: Colln
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        StreamWriter log1 = System.IO.StreamWriter.Null;
        


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
            List<ZSD_COLLN_SRV> lstsrvdeal = new List<ZSD_COLLN_SRV>();
            using (MySqlConnection con = new MySqlConnection(CS))
            {
                using (MySqlCommand cmd = new MySqlCommand("Select * from ZSD_COLLN_SRV where  ZSD_COLLN_SRV_PKID = " + Maxid))
                {

                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            lstsrvdeal.Add(new ZSD_COLLN_SRV
                            {
                                BillDate = Convert.ToString(sdr["BillDate"]),
                                Depart = Convert.ToString(sdr["Depart"]),
                                Sno = Convert.ToString(sdr["Sno"]),
                                Regio = Convert.ToString(sdr["Regio"]),
                                DayTagt = Convert.ToString(sdr["DayTagt"]),
                                DayActls = Convert.ToString(sdr["DayActls"]),
                                DayDif = Convert.ToString(sdr["DayDif"]),
                                MTar = Convert.ToString(sdr["MTar"]),
                                MtdTar = Convert.ToString(sdr["MtdTar"]),
                                MtdAct = Convert.ToString(sdr["MtdAct"]),
                                DishonrsAmt = Convert.ToString(sdr["DishonrsAmt"]),
                                Cnt = Convert.ToString(sdr["Cnt"]),
                                ActInBank = Convert.ToString(sdr["ActInBank"]),
                                MtdDiff = Convert.ToString(sdr["MtdDiff"]),
                                Achvd = Convert.ToString(sdr["Achvd"]),
                                TotParMon = Convert.ToString(sdr["TotParMon"]),
                                TotParDat = Convert.ToString(sdr["TotParDat"]),
                                TotParRem = Convert.ToString(sdr["TotParRem"]),


                            });
                        }
                    }
                    con.Close();
                }
            }
            if (InputID == "E")
            {
                DataTable dt1 = new DataTable("ZSD_COLLN_SRV");
                dt1.Columns.AddRange(new DataColumn[18]
                {
                        new DataColumn("Date"),
                        new DataColumn("Department"),
                        new DataColumn("Serial Number"),
                        new DataColumn("Region"),
                        new DataColumn("Day Target"),
                        new DataColumn("Day Actual"),
                        new DataColumn("Day + (or) -"),
                        new DataColumn("Month Target"),
                        new DataColumn("MTD Target"),
                        new DataColumn("MTD Receipts Collect"),
                        new DataColumn("Dishonrs Amount"),
                        new DataColumn("No of Cheques"),
                        new DataColumn("Actuals in BNK"),
                        new DataColumn("MTD + or -"),
                        new DataColumn("Achvd%"),
                        new DataColumn("Tar Prorata month"),
                        new DataColumn("Trgt per Day"),
                        new DataColumn("Tar Rem working days")
                 });

                using (MySqlConnection con = new MySqlConnection(CS))
                {
                    string query = " Select * from ZSD_COLLN_SRV ";
                    query += " where date_format(cast( str_to_date(Billdate,'%d.%m.%Y') as date),'%Y%m%d')  ";
                    query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";
                    query += " order by date_format(cast( str_to_date(Billdate,'%d.%m.%Y') as date),'%Y%m%d') ";
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {

                        cmd.Connection = con;
                        con.Open();
                        using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                DataRow _dr = dt1.NewRow();
                                _dr["Date"] = Convert.ToString(sdr["BillDate"]);
                                _dr["Department"] = Convert.ToString(sdr["Depart"]);
                                _dr["Serial Number"] = Convert.ToString(sdr["Sno"]);
                                _dr["Region"] = Convert.ToString(sdr["Regio"]);
                                _dr["Day Target"] = Convert.ToString(sdr["DayTagt"]);
                                _dr["Day Actual"] = Convert.ToString(sdr["DayActls"]);
                                _dr["Day + (or) -"] = Convert.ToString(sdr["DayDif"]);
                                _dr["Month Target"] = Convert.ToString(sdr["MTar"]);
                                _dr["MTD Target"] = Convert.ToString(sdr["MtdTar"]);
                                _dr["MTD Receipts Collect"] = Convert.ToString(sdr["MtdAct"]);
                                _dr["Dishonrs Amount"] = Convert.ToString(sdr["DishonrsAmt"]);
                                _dr["No of Cheques"] = Convert.ToString(sdr["Cnt"]);
                                _dr["Actuals in BNK"] = Convert.ToString(sdr["ActInBank"]);
                                _dr["MTD + or -"] = Convert.ToString(sdr["MtdDiff"]);
                                _dr["Achvd%"] = Convert.ToString(sdr["Achvd"]);
                                _dr["Tar Prorata month"] = Convert.ToString(sdr["TotParMon"]);
                                _dr["Trgt per Day"] = Convert.ToString(sdr["TotParDat"]);
                                _dr["Tar Rem working days"] = Convert.ToString(sdr["TotParRem"]);

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
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ZSD_COLLN_SRV.xlsx");
                    }
                }
            }

           
            if (InputID == "S")
            {
                lstsrvdeal =  GetCollectionDetails(startDate, endDate);


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

                List<ZSD_COLLN_SRV> lstsrvdeal = new List<ZSD_COLLN_SRV>();
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
                    //var url = "https://netwaver-prd.pennacement.com:443/sap/opu/odata/sap/ZSD_COLLN_SRV/COLLECTIONSet/?$filter=(BillDate ge '" + startDateOrig.Trim() + "' and BillDate le '" + endDateOrig.Trim() + "')&$format=json";
                    //string userName = "NWGW037";
                    //string passwd = "Admin@123456";


                    //Dev
                    var url = "https://netwaver-dev.pennacement.com:443/sap/opu/odata/sap/ZSD_COLLN_SRV/COLLECTIONSet/?$filter=(BillDate ge '" + startDateOrig.Trim() + "' and BillDate le '" + endDateOrig.Trim() + "')&$format=json";
                    string userName = "NWGW001";
                    string passwd = "Penna@123";

                    log1.WriteLine("Insert Table : ZSD_COLLN_SRV");

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
                        List<ZSD_COLLN_SRV> varoutput = men1.ToObject<List<ZSD_COLLN_SRV>>();
                        var o = JsonConvert.DeserializeObject<List<ZSD_COLLN_SRV>>(men1.ToString());

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
                        query = " Delete from ZSD_COLLN_SRV ";
                        query += " where date_format(cast( str_to_date(Billdate,'%d.%m.%Y') as date),'%Y%m%d')  ";
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


                                query = "Insert into ZSD_COLLN_SRV(BILLDATE,DEPART,SNO,REGIO,";
                                query += "DAYTAGT,DAYACTLS,DAYDIF,MTAR,MTDTAR,MTDACT,DISHONRSAMT,";
                                query += "CNT,ACTINBANK,MTDDIFF,ACHVD,TOTPARMON,TOTPARDAT,TOTPARREM) Values ";
                                query += "(@BILLDATE,@DEPART,@SNO,@REGIO,@DAYTAGT,@DAYACTLS,@DAYDIF,";
                                query += "@MTAR,@MTDTAR,@MTDACT,@DISHONRSAMT,@CNT,@ACTINBANK,";
                                query += "@MTDDIFF,@ACHVD,@TOTPARMON,@TOTPARDAT,@TOTPARREM);";

                                MySqlCommand cmd = new MySqlCommand(query, con);

                                cmd.Parameters.AddWithValue("@BILLDATE", row["BILLDATE"].ToString());
                                cmd.Parameters.AddWithValue("@DEPART", row["DEPART"].ToString());
                                cmd.Parameters.AddWithValue("@SNO", row["SNO"].ToString());
                                cmd.Parameters.AddWithValue("@REGIO", row["REGIO"].ToString());
                                cmd.Parameters.AddWithValue("@DAYTAGT", row["DAYTAGT"].ToString());
                                cmd.Parameters.AddWithValue("@DAYACTLS", row["DAYACTLS"].ToString());
                                cmd.Parameters.AddWithValue("@DAYDIF", row["DAYDIF"].ToString());
                                cmd.Parameters.AddWithValue("@MTAR", row["MTAR"].ToString());
                                cmd.Parameters.AddWithValue("@MTDTAR", row["MTDTAR"].ToString());
                                cmd.Parameters.AddWithValue("@MTDACT", row["MTDACT"].ToString());
                                cmd.Parameters.AddWithValue("@DISHONRSAMT", row["DISHONRSAMT"].ToString());
                                cmd.Parameters.AddWithValue("@CNT", row["CNT"].ToString());
                                cmd.Parameters.AddWithValue("@ACTINBANK", row["ACTINBANK"].ToString());
                                cmd.Parameters.AddWithValue("@MTDDIFF", row["MTDDIFF"].ToString());
                                cmd.Parameters.AddWithValue("@ACHVD", row["ACHVD"].ToString());
                                cmd.Parameters.AddWithValue("@TOTPARMON", row["TOTPARMON"].ToString());
                                cmd.Parameters.AddWithValue("@TOTPARDAT", row["TOTPARDAT"].ToString());
                                cmd.Parameters.AddWithValue("@TOTPARREM", row["TOTPARREM"].ToString());

                                cmd.CommandType = CommandType.Text;
                                int result = cmd.ExecuteNonQuery();

                                if (result == 1)
                                {
                                    i = i + 1;
                                }

                            }

                        }
                        log1.WriteLine("Executed End : " + DateTime.Now);
                        query = "";
                        query = " Select Count(*) from ZSD_COLLN_SRV ";
                        query += " where date_format(cast( str_to_date(Billdate,'%d.%m.%Y') as date),'%Y%m%d')  ";
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
                            query = " Delete from ZSD_COLLN_SRV ";
                            query += " where date_format(cast( str_to_date(Billdate,'%d.%m.%Y') as date),'%Y%m%d')  ";
                            query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";

                            using (MySqlConnection sqlCon = new MySqlConnection(CS))
                            {
                                sqlCon.Open();
                                MySqlCommand Cmnd = new MySqlCommand(query, sqlCon);

                                int result = Cmnd.ExecuteNonQuery();

                                sqlCon.Close();
                            }

                            query = "";
                            query = " Select Count(*) from ZSD_COLLN_SRV ";
                            query += " where date_format(cast( str_to_date(Billdate,'%d.%m.%Y') as date),'%Y%m%d')  ";
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


                lstsrvdeal = GetCollectionDetails(startDate, endDate);
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
                log1.WriteLine("ZSD_COLLN_SRV Error Message : " + ex.Message);
                log1.WriteLine("===========================================");
                log1.Close();


                return View();


            }


        }

        private List<ZSD_COLLN_SRV> GetCollectionDetails(string startDate, string endDate)
        {
            List<ZSD_COLLN_SRV> lstsrvdeal = new List<ZSD_COLLN_SRV>();

            using (MySqlConnection con = new MySqlConnection(CS))
            {
                string query = " Select * from ZSD_COLLN_SRV ";
                query += " where date_format(cast( str_to_date(Billdate,'%d.%m.%Y') as date),'%Y%m%d')  ";
                query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";
                query += " order by date_format(cast( str_to_date(Billdate,'%d.%m.%Y') as date),'%Y%m%d') ";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {

                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            lstsrvdeal.Add(new ZSD_COLLN_SRV
                            {
                                BillDate = Convert.ToString(sdr["BillDate"]),
                                Depart = Convert.ToString(sdr["Depart"]),
                                Sno = Convert.ToString(sdr["Sno"]),
                                Regio = Convert.ToString(sdr["Regio"]),
                                DayTagt = Convert.ToString(sdr["DayTagt"]),
                                DayActls = Convert.ToString(sdr["DayActls"]),
                                DayDif = Convert.ToString(sdr["DayDif"]),
                                MTar = Convert.ToString(sdr["MTar"]),
                                MtdTar = Convert.ToString(sdr["MtdTar"]),
                                MtdAct = Convert.ToString(sdr["MtdAct"]),
                                DishonrsAmt = Convert.ToString(sdr["DishonrsAmt"]),
                                Cnt = Convert.ToString(sdr["Cnt"]),
                                ActInBank = Convert.ToString(sdr["ActInBank"]),
                                MtdDiff = Convert.ToString(sdr["MtdDiff"]),
                                Achvd = Convert.ToString(sdr["Achvd"]),
                                TotParMon = Convert.ToString(sdr["TotParMon"]),
                                TotParDat = Convert.ToString(sdr["TotParDat"]),
                                TotParRem = Convert.ToString(sdr["TotParRem"]),


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