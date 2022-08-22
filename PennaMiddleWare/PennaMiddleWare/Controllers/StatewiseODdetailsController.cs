using context = System.Web.HttpContext;
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
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using PagedList;

using System.IO.Compression;

namespace PennaMiddleWare.Controllers
{
    public class StatewiseODdetailsController : Controller
    {
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        StreamWriter log1 = System.IO.StreamWriter.Null;
        public static DataTable dtZFI_AGEING_OD_SRV;
        // GET: StatewiseODdetails
        public ActionResult Index(string startDate, string endDate, string InputID, int? page, int? page1)
        {
            int pageSize;
            string query = "";
            List<ZFI_AGEING_OD_SRV> lstsrvageing = new List<ZFI_AGEING_OD_SRV>();

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

        //    ViewData["SelCategory"] = 0;
        //    List<SelectListItem> mySkills = new List<SelectListItem>() {
        //        new SelectListItem {
        //    Text = "Select", Value = "0"
        //},
        //new SelectListItem {
        //    Text = "Report 1", Value = "1"
        //},
        //new SelectListItem {
        //    Text = "Report 2", Value = "2"
        //},

        //};
            // ViewData["Category"] = mySkills;

            
            int Maxid = 0;
           
            if (InputID == "S")
            {
                query = "";
                query += " Select * from ZFI_AGEING_OD_SRV ";
                //query += " where date_format(cast(Budat as date),'%Y%m%d') ";
                query += " where date_format(cast( str_to_date(Budat,'%d.%m.%Y') as date),'%Y%m%d')  ";
                query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";

                using (MySqlConnection sqlCon = new MySqlConnection(CS))
                {

                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {

                        cmd.Connection = sqlCon;
                        sqlCon.Open();
                        using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                lstsrvageing.Add(new ZFI_AGEING_OD_SRV
                                {
                                    Bukrs = Convert.ToString(sdr["Bukrs"]),
                                    Budat = Convert.ToString(sdr["Budat"]),
                                    Kunnr = Convert.ToString(sdr["Kunnr"]),
                                    Ktokd = Convert.ToString(sdr["Ktokd"]),
                                    Name1 = Convert.ToString(sdr["Name1"]),
                                    Kunn2 = Convert.ToString(sdr["Kunn2"]),
                                    Name2 = Convert.ToString(sdr["Name2"]),
                                    Kunn3 = Convert.ToString(sdr["Kunn3"]),
                                    Name3 = Convert.ToString(sdr["Name3"]),
                                    Slab1 = Convert.ToDecimal(sdr["Slab1"]),
                                    Slab2 = Convert.ToDecimal(sdr["Slab2"]),
                                    Slab3 = Convert.ToDecimal(sdr["Slab3"]),
                                    Slab4 = Convert.ToDecimal(sdr["Slab4"]),
                                    Slab5 = Convert.ToDecimal(sdr["Slab5"]),
                                    Slab6 = Convert.ToDecimal(sdr["Slab6"]),
                                    Slab7 = Convert.ToDecimal(sdr["Slab7"]),
                                    Slab8 = Convert.ToDecimal(sdr["Slab8"]),
                                    Slab9 = Convert.ToDecimal(sdr["Slab9"]),
                                    Waers = Convert.ToString(sdr["Waers"]),
                                    Regio = Convert.ToString(sdr["Regio"]),
                                    Dstrc = Convert.ToString(sdr["Dstrc"]),
                                    Dstxt = Convert.ToString(sdr["Dstxt"]),
                                    Regtxt = Convert.ToString(sdr["Regtxt"]),
                                    Zzzone = Convert.ToString(sdr["Zzzone"]),
                                    Zzbranch = Convert.ToString(sdr["Zzbranch"]),
                                    Vkorg = Convert.ToString(sdr["Vkorg"]),
                                    Vkgrp = Convert.ToString(sdr["Vkgrp"]),
                                    Vkbur = Convert.ToString(sdr["Vkbur"]),
                                    Zzbzirk = Convert.ToString(sdr["Zzbzirk"]),
                                    CreditLimit = Convert.ToDecimal(sdr["CreditLimit"]),
                                    AvailableCl = Convert.ToDecimal(sdr["AvailableCl"]),
                                    CreditPeriod = Convert.ToString(sdr["CreditPeriod"]),
                                    OsDays = Convert.ToString(sdr["OsDays"]),
                                    OsAmt = Convert.ToDecimal(sdr["OsAmt"]),
                                    OsOdAmt = Convert.ToDecimal(sdr["OsOdAmt"]),
                                    OsOdDays = Convert.ToString(sdr["OsOdDays"]),
                                    SecurityDep = Convert.ToDecimal(sdr["SecurityDep"]),
                                    ChqnrAmt = Convert.ToDecimal(sdr["ChqnrAmt"]),
                                    CurrFyOdOs = Convert.ToDecimal(sdr["CurrFyOdOs"]),
                                    PreFyOdOs = Convert.ToDecimal(sdr["PreFyOdOs"]),
                                    PreFyClsOdOs = Convert.ToDecimal(sdr["PreFyClsOdOs"]),
                                    ActualOd = Convert.ToDecimal(sdr["ActualOd"]),
                                });
                            }
                        }
                        sqlCon.Close();
                    }



                }
            }
            if (InputID == "E")
            {
                DataTable dtZFI_AGEING_OD_SRV = new DataTable("ZFI_AGEING_OD_SRV");
                dtZFI_AGEING_OD_SRV.Columns.AddRange(new DataColumn[42]
                {
                            new DataColumn("Company Code"),
                            new DataColumn("Budate"),
                            new DataColumn("Customer"),
                            new DataColumn("Account group"),
                            new DataColumn("Customer Name"),
                            new DataColumn("Sales Representative"),
                            new DataColumn("Sales Rep Name"),
                            new DataColumn("Sales Organsier"),
                            new DataColumn("Sales Organiser Name"),
                            new DataColumn("Slab1"),
                            new DataColumn("Slab2"),
                            new DataColumn("Slab3"),
                            new DataColumn("Slab4"),
                            new DataColumn("Slab5"),
                            new DataColumn("Slab6"),
                            new DataColumn("Slab7"),
                            new DataColumn("Slab8"),
                            new DataColumn("Slab9"),
                            new DataColumn("Currency"),
                            new DataColumn("Region"),
                            new DataColumn("District"),
                            new DataColumn("District Name"),
                            new DataColumn("Region Text"),
                            new DataColumn("Transport Zone"),
                            new DataColumn("Branch Office"),
                            new DataColumn("Sales Org"),
                            new DataColumn("Sales Group"),
                            new DataColumn("Sales Office"),
                            new DataColumn("Sales district"),
                            new DataColumn("Credit Limit"),
                            new DataColumn("Available CI"),
                            new DataColumn("Credit Period"),
                            new DataColumn("OS Days"),
                            new DataColumn("OS Amount"),
                            new DataColumn("OS OD Amount"),
                            new DataColumn("OS OD Days"),
                            new DataColumn("Security Dep"),
                            new DataColumn("ChqnrAmt"),
                            new DataColumn("CurrFyOdOs"),
                            new DataColumn("PreFyOdOs"),
                            new DataColumn("PreFyClsOdOs"),
                            new DataColumn("ActualOd")
                 });

                using (MySqlConnection con = new MySqlConnection(CS))
                {
                    query = "";
                    query += " Select * from ZFI_AGEING_OD_SRV ";
                    //query += " where date_format(cast(Budat as date),'%Y%m%d') ";
                    query += " where date_format(cast( str_to_date(Budat,'%d.%m.%Y') as date),'%Y%m%d')  ";
                    query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";
                    query += " order by date_format(cast( str_to_date(Budat,'%d.%m.%Y') as date),'%Y%m%d'),Kunnr ";

                    //query += " Select * from zfi_ageing_od_srv";

                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {

                        cmd.Connection = con;
                        con.Open();
                        using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                DataRow _dr = dtZFI_AGEING_OD_SRV.NewRow();


                                _dr["Company Code"] = Convert.ToString(sdr["Bukrs"]);
                                _dr["Budate"] = Convert.ToString(sdr["Budat"]);
                                _dr["Customer"] = Convert.ToString(sdr["Kunnr"]);
                                _dr["Account group"] = Convert.ToString(sdr["Ktokd"]);
                                _dr["Customer Name"] = Convert.ToString(sdr["Name1"]);
                                _dr["Sales Representative"] = Convert.ToString(sdr["Kunn2"]);
                                _dr["Sales Rep Name"] = Convert.ToString(sdr["Name2"]);
                                _dr["Sales Organsier"] = Convert.ToString(sdr["Kunn3"]);
                                _dr["Sales Organiser Name"] = Convert.ToString(sdr["Name3"]);
                                _dr["Slab1"] = Convert.ToDecimal(sdr["Slab1"]);
                                _dr["Slab2"] = Convert.ToDecimal(sdr["Slab2"]);
                                _dr["Slab3"] = Convert.ToDecimal(sdr["Slab3"]);
                                _dr["Slab4"] = Convert.ToDecimal(sdr["Slab4"]);
                                _dr["Slab5"] = Convert.ToDecimal(sdr["Slab5"]);
                                _dr["Slab6"] = Convert.ToDecimal(sdr["Slab6"]);
                                _dr["Slab7"] = Convert.ToDecimal(sdr["Slab7"]);
                                _dr["Slab8"] = Convert.ToDecimal(sdr["Slab8"]);
                                _dr["Slab9"] = Convert.ToDecimal(sdr["Slab9"]);
                                _dr["Currency"] = Convert.ToString(sdr["Waers"]);
                                _dr["Region"] = Convert.ToString(sdr["Regio"]);
                                _dr["District"] = Convert.ToString(sdr["Dstrc"]);
                                _dr["District Name"] = Convert.ToString(sdr["Dstxt"]);
                                _dr["Region Text"] = Convert.ToString(sdr["Regtxt"]);
                                _dr["Transport Zone"] = Convert.ToString(sdr["Zzzone"]);
                                _dr["Branch Office"] = Convert.ToString(sdr["Zzbranch"]);
                                _dr["Sales Org"] = Convert.ToString(sdr["Vkorg"]);
                                _dr["Sales Group"] = Convert.ToString(sdr["Vkgrp"]);
                                _dr["Sales Office"] = Convert.ToString(sdr["Vkbur"]);
                                _dr["Sales district"] = Convert.ToString(sdr["Zzbzirk"]);
                                _dr["Credit Limit"] = Convert.ToDecimal(sdr["CreditLimit"]);
                                _dr["Available CI"] = Convert.ToDecimal(sdr["AvailableCl"]);
                                _dr["Credit Period"] = Convert.ToString(sdr["CreditPeriod"]);
                                _dr["OS Days"] = Convert.ToString(sdr["OsDays"]);
                                _dr["OS Amount"] = Convert.ToDecimal(sdr["OsAmt"]);
                                _dr["OS OD Amount"] = Convert.ToDecimal(sdr["OsOdAmt"]);
                                _dr["OS OD Days"] = Convert.ToString(sdr["OsOdDays"]);
                                _dr["Security Dep"] = Convert.ToDecimal(sdr["SecurityDep"]);
                                _dr["ChqnrAmt"] = Convert.ToDecimal(sdr["ChqnrAmt"]);
                                _dr["CurrFyOdOs"] = Convert.ToDecimal(sdr["CurrFyOdOs"]);
                                _dr["PreFyOdOs"] = Convert.ToDecimal(sdr["PreFyOdOs"]);
                                _dr["PreFyClsOdOs"] = Convert.ToDecimal(sdr["PreFyClsOdOs"]);
                                _dr["ActualOd"] = Convert.ToDecimal(sdr["ActualOd"]);

                                dtZFI_AGEING_OD_SRV.Rows.Add(_dr);

                            }
                        }
                        con.Close();
                    }

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dtZFI_AGEING_OD_SRV);
                        using (MemoryStream stream = new MemoryStream())
                        {
                            wb.SaveAs(stream);
                            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ZFI_AGEING_OD_SRV.xlsx");
                        }
                    }




                }
            }
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

            ViewData["lstsrvageing"] = lstsrvageing.ToPagedList(pageNumber, pageSize);

            return View(lstsrvageing);

        }




        [HttpPost]
        public ActionResult Index(string startDate, string endDate, string InputID, int? page)
        {

            string filename = System.Configuration.ConfigurationManager.AppSettings["LogFile"].ToString();
            DateTime nwstdate = DateTime.Now;
            DateTime nweddate = DateTime.Now;
            List<ZFI_AGEING_OD_SRV> lstsrvageing = new List<ZFI_AGEING_OD_SRV>();
            try
            {


                var url = "";
                string query = "";
                int result = 0;
               
                if (startDate != null)
                {
                    ViewBag.startDate = startDate;
                    ViewBag.endDate = endDate;
                    DateTime date = new DateTime();
                    DateTime.TryParseExact(startDate, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date);
                    startDate = date.ToString("yyyy-MM-dd");
                    nwstdate = date;
                    DateTime.TryParseExact(endDate, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date);
                    endDate = date.ToString("yyyy-MM-dd");
                    nweddate = date;
                    startDate = startDate.Replace("-", string.Empty);
                    endDate = endDate.Replace("-", string.Empty);

                }
                DateTime fromDateValue;
                var formats = new[] { "ddMMyyyy", "yyyyMMdd", "yyyyMMdd" };
                if (!DateTime.TryParseExact(startDate.Trim(), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue) || !(DateTime.TryParseExact(endDate.Trim(), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue)))
                {

                    TempData["ErrMsg"] = "From Date or to Date is not Valid.Unable Process Request.";
                    return RedirectToAction("Index");
                  
                }

                if (InputID == "I")
                {
                    log1.WriteLine("Insert Table : ZFI_AGEING_OD_SRV");

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
                    int WebApiCount = 0;
                    //startDate = DateTime.ParseExact(startDate, "yyyyMMdd", null).ToString("yyyyMMdd");
                    //endDate = DateTime.ParseExact(endDate, "yyyyMMdd", null).ToString("yyyyMMdd");


                    List<Schdates> schdt = new List<Schdates>();
                    schdt = Common.schdatNew(nwstdate, nweddate);
                    reccount = 0;
                    WebApiCount = 0;
                    foreach (Schdates scdat in schdt)
                    {
                        

                        query = "";
                        

                        query = "";
                        query += " Delete from ZFI_AGEING_OD_SRV ";
                        //query += " where date_format(cast(Budat as date),'%Y%m%d') ";
                        query += " WHERE date_format(cast( str_to_date(Budat,'%d.%m.%Y') as date),'%Y%m%d')  = '" + scdat.startdate + "'";
                        //query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";

                        using (MySqlConnection sqlCon = new MySqlConnection(CS))
                        {
                            sqlCon.Open();
                            MySqlCommand Cmnd = new MySqlCommand(query, sqlCon);

                            object resultexscalar = Cmnd.ExecuteNonQuery();

                            if (resultexscalar != null)
                            {
                                reccount = Convert.ToInt32(resultexscalar);
                            }

                            sqlCon.Close();
                        }

                        url = "https://netwaver-dev.pennacement.com/sap/opu/odata/sap/ZFI_AGEING_OD_SRV/OD_DETAILSSet?$format=json&$filter=(Budat eq  '" + scdat.startdate.Trim() + "')";
                        string userName = "NWGW001";
                        string passwd = "Penna@123";

                        HttpClient client = new HttpClient();

                        string authInfo = userName + ":" + passwd;
                        authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);

                        client.BaseAddress = new Uri(url);
                        HttpResponseMessage response = client.GetAsync(url).ContinueWith(task => task.Result).Result;
                        // Parse the response body. Blocking!
                        if (response.IsSuccessStatusCode)
                        {

                            Console.WriteLine("HTTP Response : " + response.IsSuccessStatusCode);
                            var httpResponseResult = response.Content.ReadAsStringAsync().ContinueWith(task => task.Result).Result;


                            JToken token1 = JToken.Parse(httpResponseResult);
                            JArray men1 = (JArray)token1.SelectToken("['d']['results']");
                            List<ZFI_AGEING_OD_SRV> varoutput = men1.ToObject<List<ZFI_AGEING_OD_SRV>>();
                            //var o = JsonConvert.DeserializeObject<List<ZSD_REAL_DATA_SRV_REAL>>(men1.ToString());

                            Common converter = new Common();


                            DataTable dt = converter.ToDataTable(varoutput);
                            Console.WriteLine("Row Count : " + dt.Rows.Count);
                            if (dtZFI_AGEING_OD_SRV == null)
                            {
                                dtZFI_AGEING_OD_SRV = converter.ToDataTable(varoutput);
                            }
                            else
                            {
                                dtZFI_AGEING_OD_SRV.Merge(dt);
                            }
                            //dtYREALIZATION = new DataTable();
                            //dtYREALIZATION.Rows.Add(dt);


                            WebApiCount += dt.Rows.Count;


                            int i = 0;
                            using (MySqlConnection con = new MySqlConnection(CS))
                            {

                                con.Open();
                                foreach (DataRow row in dt.Rows)
                                {
                                    

                                    /* new Added code 2022/01/31*/
                                    i += 1;
                                    // Console.WriteLine("Row No : " + i);
                                    query = "";


                                    query = "Insert into ZFI_AGEING_OD_SRV(BUKRS,BUDAT,KUNNR,KTOKD,NAME1,KUNN2,NAME2,";
                                    query += "KUNN3,NAME3,SLAB1,SLAB2,SLAB3,SLAB4,SLAB5,SLAB6,SLAB7,SLAB8,SLAB9,WAERS,REGIO,DSTRC,DSTXT,";
                                    query += "REGTXT,ZZZONE,ZZBRANCH,VKORG,VKGRP,VKBUR,ZZBZIRK,CREDITLIMIT,";
                                    query += "AVAILABLECL,CREDITPERIOD,OSDAYS,OSAMT,OSODAMT,OSODDAYS,SECURITYDEP,";
                                    query += "CHQNRAMT,CURRFYODOS,PREFYODOS,PREFYCLSODOS,ACTUALOD) Values ";
                                    query += "(@BUKRS,@BUDAT,@KUNNR,@KTOKD,@NAME1,@KUNN2,@NAME2,@KUNN3,@NAME3,";
                                    query += "@SLAB1,@SLAB2,@SLAB3,@SLAB4,@SLAB5,@SLAB6,@SLAB7,@SLAB8,@SLAB9,";
                                    query += "@WAERS,@REGIO,@DSTRC,@DSTXT,@REGTXT,@ZZZONE,@ZZBRANCH,@VKORG,";
                                    query += "@VKGRP,@VKBUR,@ZZBZIRK,@CREDITLIMIT,@AVAILABLECL,@CREDITPERIOD,";
                                    query += "@OSDAYS,@OSAMT,@OSODAMT,@OSODDAYS,@SECURITYDEP,@CHQNRAMT,";
                                    query += "@CURRFYODOS,@PREFYODOS,@PREFYCLSODOS,@ACTUALOD);";

                                    MySqlCommand cmd = new MySqlCommand(query, con);

                                    cmd.Parameters.AddWithValue("@BUKRS", row["BUKRS"].ToString());
                                    cmd.Parameters.AddWithValue("@BUDAT", row["BUDAT"].ToString());
                                    cmd.Parameters.AddWithValue("@KUNNR", row["KUNNR"].ToString());
                                    cmd.Parameters.AddWithValue("@KTOKD", row["KTOKD"].ToString());
                                    cmd.Parameters.AddWithValue("@NAME1", row["NAME1"].ToString());
                                    cmd.Parameters.AddWithValue("@KUNN2", row["KUNN2"].ToString());
                                    cmd.Parameters.AddWithValue("@NAME2", row["NAME2"].ToString());
                                    cmd.Parameters.AddWithValue("@KUNN3", row["KUNN3"].ToString());
                                    cmd.Parameters.AddWithValue("@NAME3", row["NAME3"].ToString());
                                    cmd.Parameters.AddWithValue("@SLAB1", row["SLAB1"].ToString());
                                    cmd.Parameters.AddWithValue("@SLAB2", row["SLAB2"].ToString());
                                    cmd.Parameters.AddWithValue("@SLAB3", row["SLAB3"].ToString());
                                    cmd.Parameters.AddWithValue("@SLAB4", row["SLAB4"].ToString());
                                    cmd.Parameters.AddWithValue("@SLAB5", row["SLAB5"].ToString());
                                    cmd.Parameters.AddWithValue("@SLAB6", row["SLAB6"].ToString());
                                    cmd.Parameters.AddWithValue("@SLAB7", row["SLAB7"].ToString());
                                    cmd.Parameters.AddWithValue("@SLAB8", row["SLAB8"].ToString());
                                    cmd.Parameters.AddWithValue("@SLAB9", row["SLAB9"].ToString());
                                    cmd.Parameters.AddWithValue("@WAERS", row["WAERS"].ToString());
                                    cmd.Parameters.AddWithValue("@REGIO", row["REGIO"].ToString());
                                    cmd.Parameters.AddWithValue("@DSTRC", row["DSTRC"].ToString());
                                    cmd.Parameters.AddWithValue("@DSTXT", row["DSTXT"].ToString());
                                    cmd.Parameters.AddWithValue("@REGTXT", row["REGTXT"].ToString());
                                    cmd.Parameters.AddWithValue("@ZZZONE", row["ZZZONE"].ToString());
                                    cmd.Parameters.AddWithValue("@ZZBRANCH", row["ZZBRANCH"].ToString());
                                    cmd.Parameters.AddWithValue("@VKORG", row["VKORG"].ToString());
                                    cmd.Parameters.AddWithValue("@VKGRP", row["VKGRP"].ToString());
                                    cmd.Parameters.AddWithValue("@VKBUR", row["VKBUR"].ToString());
                                    cmd.Parameters.AddWithValue("@ZZBZIRK", row["ZZBZIRK"].ToString());
                                    cmd.Parameters.AddWithValue("@CREDITLIMIT", row["CREDITLIMIT"].ToString());
                                    cmd.Parameters.AddWithValue("@AVAILABLECL", row["AVAILABLECL"].ToString());
                                    cmd.Parameters.AddWithValue("@CREDITPERIOD", row["CREDITPERIOD"].ToString());
                                    cmd.Parameters.AddWithValue("@OSDAYS", row["OSDAYS"].ToString());
                                    cmd.Parameters.AddWithValue("@OSAMT", row["OSAMT"].ToString());
                                    cmd.Parameters.AddWithValue("@OSODAMT", row["OSODAMT"].ToString());
                                    cmd.Parameters.AddWithValue("@OSODDAYS", row["OSODDAYS"].ToString());
                                    cmd.Parameters.AddWithValue("@SECURITYDEP", row["SECURITYDEP"].ToString());
                                    cmd.Parameters.AddWithValue("@CHQNRAMT", row["CHQNRAMT"].ToString());
                                    cmd.Parameters.AddWithValue("@CURRFYODOS", row["CURRFYODOS"].ToString());
                                    cmd.Parameters.AddWithValue("@PREFYODOS", row["PREFYODOS"].ToString());
                                    cmd.Parameters.AddWithValue("@PREFYCLSODOS", row["PREFYCLSODOS"].ToString());
                                    cmd.Parameters.AddWithValue("@ACTUALOD", row["ACTUALOD"].ToString());

                                    cmd.CommandType = CommandType.Text;
                                    result = cmd.ExecuteNonQuery();

                                }

                            }



                        }
                        else if (response.StatusCode.ToString() == "BadRequest")
                        {

                        }
                        else
                        {
                            Console.WriteLine("Web API Response Status Code: " + Convert.ToInt16(response.StatusCode) + ", Status : " + response.StatusCode);
                            log1.WriteLine("Web API Response Status Code: " + Convert.ToInt16(response.StatusCode) + ", Status : " + response.StatusCode);
                        }


                    }

                    log1.WriteLine("Executed End : " + DateTime.Now);
                    query = "";
                    query = " Select Count(*) from ZFI_AGEING_OD_SRV ";
                    query += " where date_format(cast( str_to_date(Budat,'%d.%m.%Y') as date),'%Y%m%d')  ";
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
                    if (WebApiCount == reccount)
                    {
                        log1.WriteLine("Table record Count : " + reccount);
                        log1.WriteLine("Record Mathing");


                    }
                    else
                    {
                        log1.WriteLine("Table Table Count : " + reccount);
                        log1.WriteLine("Record Insert Failed");
                    }


                    log1.WriteLine("===========================================");
                    log1.Close();

                }

                if (InputID == "I" || InputID == "S")
                {
                    query = "";
                    query += " Select * from ZFI_AGEING_OD_SRV ";
                    //query += " where date_format(cast(Budat as date),'%Y%m%d') ";
                    query += " where date_format(cast( str_to_date(Budat,'%d.%m.%Y') as date),'%Y%m%d')  ";
                    query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";

                    using (MySqlConnection sqlCon = new MySqlConnection(CS))
                    {

                        using (MySqlCommand cmd = new MySqlCommand(query))
                        {

                            cmd.Connection = sqlCon;
                            sqlCon.Open();
                            using (MySqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    lstsrvageing.Add(new ZFI_AGEING_OD_SRV
                                    {
                                        Bukrs = Convert.ToString(sdr["Bukrs"]),
                                        Budat = Convert.ToString(sdr["Budat"]),
                                        Kunnr = Convert.ToString(sdr["Kunnr"]),
                                        Ktokd = Convert.ToString(sdr["Ktokd"]),
                                        Name1 = Convert.ToString(sdr["Name1"]),
                                        Kunn2 = Convert.ToString(sdr["Kunn2"]),
                                        Name2 = Convert.ToString(sdr["Name2"]),
                                        Kunn3 = Convert.ToString(sdr["Kunn3"]),
                                        Name3 = Convert.ToString(sdr["Name3"]),
                                        Slab1 = Convert.ToDecimal(sdr["Slab1"]),
                                        Slab2 = Convert.ToDecimal(sdr["Slab2"]),
                                        Slab3 = Convert.ToDecimal(sdr["Slab3"]),
                                        Slab4 = Convert.ToDecimal(sdr["Slab4"]),
                                        Slab5 = Convert.ToDecimal(sdr["Slab5"]),
                                        Slab6 = Convert.ToDecimal(sdr["Slab6"]),
                                        Slab7 = Convert.ToDecimal(sdr["Slab7"]),
                                        Slab8 = Convert.ToDecimal(sdr["Slab8"]),
                                        Slab9 = Convert.ToDecimal(sdr["Slab9"]),
                                        Waers = Convert.ToString(sdr["Waers"]),
                                        Regio = Convert.ToString(sdr["Regio"]),
                                        Dstrc = Convert.ToString(sdr["Dstrc"]),
                                        Dstxt = Convert.ToString(sdr["Dstxt"]),
                                        Regtxt = Convert.ToString(sdr["Regtxt"]),
                                        Zzzone = Convert.ToString(sdr["Zzzone"]),
                                        Zzbranch = Convert.ToString(sdr["Zzbranch"]),
                                        Vkorg = Convert.ToString(sdr["Vkorg"]),
                                        Vkgrp = Convert.ToString(sdr["Vkgrp"]),
                                        Vkbur = Convert.ToString(sdr["Vkbur"]),
                                        Zzbzirk = Convert.ToString(sdr["Zzbzirk"]),
                                        CreditLimit = Convert.ToDecimal(sdr["CreditLimit"]),
                                        AvailableCl = Convert.ToDecimal(sdr["AvailableCl"]),
                                        CreditPeriod = Convert.ToString(sdr["CreditPeriod"]),
                                        OsDays = Convert.ToString(sdr["OsDays"]),
                                        OsAmt = Convert.ToDecimal(sdr["OsAmt"]),
                                        OsOdAmt = Convert.ToDecimal(sdr["OsOdAmt"]),
                                        OsOdDays = Convert.ToString(sdr["OsOdDays"]),
                                        SecurityDep = Convert.ToDecimal(sdr["SecurityDep"]),
                                        ChqnrAmt = Convert.ToDecimal(sdr["ChqnrAmt"]),
                                        CurrFyOdOs = Convert.ToDecimal(sdr["CurrFyOdOs"]),
                                        PreFyOdOs = Convert.ToDecimal(sdr["PreFyOdOs"]),
                                        PreFyClsOdOs = Convert.ToDecimal(sdr["PreFyClsOdOs"]),
                                        ActualOd = Convert.ToDecimal(sdr["ActualOd"]),
                                    });
                                }
                            }
                            sqlCon.Close();
                        }
                                   

                        
                    }
                }

                if (InputID == "E")
                {
                   
                }

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
                if (page1 != null)
                {

                    pageNumber = Convert.ToInt16(page1);
                }
                ViewData["lstsrvageing"] = lstsrvageing.ToPagedList(pageNumber, pageSize);
                return View(lstsrvageing);
              
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
                log1.WriteLine("ZFI_AGEING_OD_SRV Error Message : " + ex.Message);
                log1.WriteLine("===========================================");
                log1.Close();
                return View();

            }


        }



        public ActionResult DownloadLogRealization()
        {


            try
            {
                string filename = System.Configuration.ConfigurationManager.AppSettings["LogFile"].ToString();
                string SchLogFile = System.Configuration.ConfigurationManager.AppSettings["SchLogFile"].ToString();
                //string destinationFile = System.IO.Path.GetDirectoryName(SchLogFile) + @"\PennaScheduler.log";
                List<PennaMiddleWare.BLL.FileInfo> listFiles = new List<PennaMiddleWare.BLL.FileInfo>();
                
                if (System.IO.File.Exists(filename))
                {
                    //return File(filename, "text/plain", "Pennalog.txt");
                    listFiles.Add(new PennaMiddleWare.BLL.FileInfo()
                    {

                        FileId = listFiles.Count + 1,
                        FileName = Path.GetFileName(filename),
                        FilePath = filename

                    });
                    

                }

                if (System.IO.File.Exists(SchLogFile))
                {
                    
                    listFiles.Add(new PennaMiddleWare.BLL.FileInfo()
                    {

                        FileId = listFiles.Count + 1,
                        FileName = Path.GetFileName(SchLogFile),
                        FilePath = SchLogFile

                    });
                    

                }
                using (var memoryStream = new MemoryStream())
                {
                    using (var ziparchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                    {
                        for (int i = 0; i < listFiles.Count; i++)
                        {
                            ziparchive.CreateEntryFromFile(listFiles[i].FilePath, listFiles[i].FileName);
                            //  ziparchive.CreateEntryFromFile(Server.MapPath("~/images/img_Download.PNG"), "img_Download.PNG");
                        }
                    }
                  
                    return File(memoryStream.ToArray(), "application/zip", "Attachments.zip");
                }
                
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "StatewiseODdetails");
            }
        }

    }
}