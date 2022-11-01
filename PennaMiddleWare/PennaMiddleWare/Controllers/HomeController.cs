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
using Ionic.Zip;
using System.IO.Compression;
namespace PennaMiddleWare.Controllers
{
    public class HomeController : Controller
    {



        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        StreamWriter log1 = System.IO.StreamWriter.Null;

        public ActionResult Index(string startDate, string endDate, string InputID, int? page, int? page1)
        {
            //connection_open = false;

            //connection = new MySqlConnection();
            ////connection = DB_Connect.Make_Connnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString);
            //connection.ConnectionString = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;

            //string CS = connection.ConnectionString;
            ////            if (db_manage_connnection.DB_Connect.OpenTheConnection(connection))
            //if (Open_Local_Connection())
            //{
            //    connection_open = true;
            //}
            //else
            //{
            //    //					MessageBox::Show("No database connection connection made...\n Exiting now", "Database Connection Error");
            //    //					 Application::Exit();

            //}
            int pageSize;
           
           
            if(startDate!=null) {
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
        //    ViewData["Category"] = mySkills;

            //var url = "https://netwaver-dev.pennacement.com:443/sap/opu/odata/sap/ZSD_REAL_DATA_SRV/REALSet?$format=json&$filter=Erdat ge '20160701' and Erdat le '20161231'";
            //string userName = "NWGW001";
            //string passwd = "Penna@123";
            //string query = "";
            //Int32 Maxid = 0;

            //HttpClient client = new HttpClient();

            //string authInfo = userName + ":" + passwd;
            //authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);

            //client.BaseAddress = new Uri(url);

            //HttpResponseMessage response = client.GetAsync(url).ContinueWith(task => task.Result).Result;
            //// Parse the response body. Blocking!
            //if (response.IsSuccessStatusCode)
            //{
            //    var httpResponseResult = response.Content.ReadAsStringAsync().ContinueWith(task => task.Result).Result;


            //    JToken token1 = JToken.Parse(httpResponseResult);
            //    JArray men1 = (JArray)token1.SelectToken("['d']['results']");
            //    List<ZSD_REAL_DATA_SRV_REAL> varoutput = men1.ToObject<List<ZSD_REAL_DATA_SRV_REAL>>();
            //    var o = JsonConvert.DeserializeObject<List<ZSD_REAL_DATA_SRV_REAL>>(men1.ToString());

            //    //DataTable dt = (DataTable)JsonConvert.DeserializeObject(men1.ToString(), (typeof(DataTable)));
            //    //var qry = from idata in varoutput select idata;
            //    //DataTable dtable = 
            //    Common converter = new Common();


            //    DataTable dt = converter.ToDataTable(varoutput);

            //    query = " declare @maxid int ";
            //    query += " set @maxid = (select max(GroupID) from [ZSD_REAL_DATA_SRV_REAL]) ";
            //    query += " select isnull(@maxid,0) +1 ";

            //    using (SqlConnection sqlCon = new SqlConnection(CS))
            //    {
            //        sqlCon.Open();
            //        MySqlCommand Cmnd = new MySqlCommand(query, sqlCon);

            //        object result = Cmnd.ExecuteScalar();
            //        if (result != null)
            //        {
            //            Maxid = Convert.ToInt32(result.ToString());
            //        }
            //        sqlCon.Close();
            //    }
            //    //objbulk.ColumnMappings.Add("GroupID", 1);
            //    DataColumn dc = new DataColumn("GroupID");
            //    dc.DataType = typeof(int);
            //    dc.DefaultValue = Maxid;
            //    dt.Columns.Add(dc);
            //    //dt.Columns.Add("GroupID", typeof(int));
            //    //dt.Columns["GroupID"].DefaultValue = 0;
            //    //dt.Columns.Add("GroupID", typeof(long)).DefaultValue = 1;
            //    using (SqlConnection con = new SqlConnection(CS))
            //    {
            //        con.Open();
            //        SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //        //assigning Destination table name    
            //        objbulk.DestinationTableName = "ZSD_REAL_DATA_SRV_REAL";
            //        //Mapping Table column    
            //        objbulk.ColumnMappings.Add("Vbeln", "Vbeln");
            //        objbulk.ColumnMappings.Add("Vgbel", "Vgbel");
            //        objbulk.ColumnMappings.Add("Aubel", "Aubel");
            //        objbulk.ColumnMappings.Add("Erdat", "Erdat");
            //        objbulk.ColumnMappings.Add("Fkart", "Fkart");
            //        objbulk.ColumnMappings.Add("Regio", "Regio");
            //        objbulk.ColumnMappings.Add("Vkgrp", "Vkgrp");
            //        objbulk.ColumnMappings.Add("Dstrc", "Dstrc");
            //        objbulk.ColumnMappings.Add("Mnfplant", "Mnfplant");
            //        objbulk.ColumnMappings.Add("Plant", "Plant");
            //        objbulk.ColumnMappings.Add("Grade", "Grade");
            //        objbulk.ColumnMappings.Add("Matkl", "Matkl");
            //        objbulk.ColumnMappings.Add("Kalks", "Kalks");
            //        objbulk.ColumnMappings.Add("Kdgrp", "Kdgrp");
            //        objbulk.ColumnMappings.Add("Fkdat", "Fkdat");
            //        objbulk.ColumnMappings.Add("Matnr", "Matnr");
            //        objbulk.ColumnMappings.Add("Custcode1", "Custcode1");
            //        objbulk.ColumnMappings.Add("Cname1", "Cname1");
            //        objbulk.ColumnMappings.Add("Custcode2", "Custcode2");
            //        objbulk.ColumnMappings.Add("Cname2", "Cname2");
            //        objbulk.ColumnMappings.Add("Custcode3", "Custcode3");
            //        objbulk.ColumnMappings.Add("Cname3", "Cname3");
            //        objbulk.ColumnMappings.Add("ComAg", "ComAg");
            //        objbulk.ColumnMappings.Add("ComName", "ComName");
            //        objbulk.ColumnMappings.Add("Trans", "Trans");
            //        objbulk.ColumnMappings.Add("TransName", "TransName");
            //        objbulk.ColumnMappings.Add("Lgort", "Lgort");
            //        objbulk.ColumnMappings.Add("Lgobe", "Lgobe");
            //        objbulk.ColumnMappings.Add("Fkimg", "Fkimg");
            //        objbulk.ColumnMappings.Add("Grossturn", "Grossturn");
            //        objbulk.ColumnMappings.Add("Inco1", "Inco1");
            //        objbulk.ColumnMappings.Add("Inco2", "Inco2");
            //        objbulk.ColumnMappings.Add("Stprs", "Stprs");
            //        objbulk.ColumnMappings.Add("Primaryfri", "Primaryfri");
            //        objbulk.ColumnMappings.Add("Secondaryfri", "Secondaryfri");
            //        objbulk.ColumnMappings.Add("Exwpf", "Exwpf");
            //        objbulk.ColumnMappings.Add("Exgsf", "Exgsf");
            //        objbulk.ColumnMappings.Add("Salestax", "Salestax");
            //        objbulk.ColumnMappings.Add("Commission", "Commission");
            //        objbulk.ColumnMappings.Add("Exciseduty", "Exciseduty");
            //        objbulk.ColumnMappings.Add("Pddiscount", "Pddiscount");
            //        objbulk.ColumnMappings.Add("Oddiscount", "Oddiscount");
            //        objbulk.ColumnMappings.Add("Cfcharges", "Cfcharges");
            //        objbulk.ColumnMappings.Add("Cddiscount", "Cddiscount");
            //        objbulk.ColumnMappings.Add("Packing", "Packing");
            //        objbulk.ColumnMappings.Add("Unloading", "Unloading");
            //        objbulk.ColumnMappings.Add("Octrai", "Octrai");
            //        objbulk.ColumnMappings.Add("Vat", "Vat");
            //        objbulk.ColumnMappings.Add("Igst", "Igst");
            //        objbulk.ColumnMappings.Add("Cgst", "Cgst");
            //        objbulk.ColumnMappings.Add("Sgst", "Sgst");
            //        objbulk.ColumnMappings.Add("Ugst", "Ugst");
            //        objbulk.ColumnMappings.Add("ExpHand", "ExpHand");
            //        objbulk.ColumnMappings.Add("Transport", "Transport");
            //        objbulk.ColumnMappings.Add("AmtDwFrt", "AmtDwFrt");
            //        objbulk.ColumnMappings.Add("PltFrt", "PltFrt");
            //        objbulk.ColumnMappings.Add("Netturn", "Netturn");
            //        objbulk.ColumnMappings.Add("Nakedreal", "Nakedreal");
            //        objbulk.ColumnMappings.Add("Statedesc", "Statedesc");
            //        objbulk.ColumnMappings.Add("Sgrpdesc", "Sgrpdesc");
            //        objbulk.ColumnMappings.Add("Disdesc", "Disdesc");
            //        objbulk.ColumnMappings.Add("Graddesc", "Graddesc");
            //        objbulk.ColumnMappings.Add("Mnfdesc", "Mnfdesc");
            //        objbulk.ColumnMappings.Add("Plantdesc", "Plantdesc");
            //        objbulk.ColumnMappings.Add("Pgrpdesc", "Pgrpdesc");
            //        objbulk.ColumnMappings.Add("Cdate", "Cdate");
            //        objbulk.ColumnMappings.Add("Time", "Time");
            //        objbulk.ColumnMappings.Add("Suser", "Suser");
            //        objbulk.ColumnMappings.Add("BlockCt", "BlockCt");
            //        objbulk.ColumnMappings.Add("Route", "Route");
            //        objbulk.ColumnMappings.Add("Canceldate", "Canceldate");
            //        objbulk.ColumnMappings.Add("Cancelflag", "Cancelflag");
            //        objbulk.ColumnMappings.Add("Zzlgort1", "Zzlgort1");
            //        objbulk.ColumnMappings.Add("Bzirk", "Bzirk");
            //        objbulk.ColumnMappings.Add("Vkbur", "Vkbur");
            //        objbulk.ColumnMappings.Add("Zzzone1", "Zzzone1");
            //        objbulk.ColumnMappings.Add("Zzbranch", "Zzbranch");
            //        objbulk.ColumnMappings.Add("PernrEr", "PernrEr");
            //        objbulk.ColumnMappings.Add("EnameEr", "EnameEr");
            //        objbulk.ColumnMappings.Add("PernrY1", "PernrY1");
            //        objbulk.ColumnMappings.Add("EnameY1", "EnameY1");
            //        objbulk.ColumnMappings.Add("PernrY2", "PernrY2");
            //        objbulk.ColumnMappings.Add("EnameY2", "EnameY2");
            //        objbulk.ColumnMappings.Add("PernrY3", "PernrY3");
            //        objbulk.ColumnMappings.Add("EnameY3", "EnameY3");
            //        objbulk.ColumnMappings.Add("PernrY4", "PernrY4");
            //        objbulk.ColumnMappings.Add("EnameY4", "EnameY4");
            //        objbulk.ColumnMappings.Add("PernrY5", "PernrY5");
            //        objbulk.ColumnMappings.Add("EnameY5", "EnameY5");
            //        objbulk.ColumnMappings.Add("PernrY6", "PernrY6");
            //        objbulk.ColumnMappings.Add("EnameY6", "EnameY6");
            //        objbulk.ColumnMappings.Add("PernrY7", "PernrY7");
            //        objbulk.ColumnMappings.Add("EnameY7", "EnameY7");
            //        objbulk.ColumnMappings.Add("PernrY8", "PernrY8");
            //        objbulk.ColumnMappings.Add("EnameY8", "EnameY8");
            //        objbulk.ColumnMappings.Add("UpfrntDiscount", "UpfrntDiscount");
            //        objbulk.ColumnMappings.Add("IndPriFrt", "IndPriFrt");
            //        objbulk.ColumnMappings.Add("ShipFrtChrgs", "ShipFrtChrgs");
            //        objbulk.ColumnMappings.Add("ShipHandChrgs", "ShipHandChrgs");
            //        objbulk.ColumnMappings.Add("ZcustGrp", "ZcustGrp");
            //        objbulk.ColumnMappings.Add("ZcustGrpDesc", "ZcustGrpDesc");
            //        objbulk.ColumnMappings.Add("Vc", "Vc");
            //        objbulk.ColumnMappings.Add("ZsalePromValue", "ZsalePromValue");
            //        objbulk.ColumnMappings.Add("Waers", "Waers");
            //        objbulk.ColumnMappings.Add("Msehi", "Msehi");
            //        objbulk.ColumnMappings.Add("PayFreight", "PayFreight");
            //        objbulk.ColumnMappings.Add("ExFreight", "ExFreight");
            //        objbulk.ColumnMappings.Add("GroupID", "GroupID");
            //        //objbulk.ColumnMappings.Add("FileName", "Filename + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffff")");

            //        //inserting Datatable Records to DataBase    
            //        //con.Open();
            //        objbulk.WriteToServer(dt);




            //        con.Close();

            //    }
            //}
            int Maxid = 0;
            List<ZSD_REAL_DATA_SRV_REAL> lstsrvdeal = new List<ZSD_REAL_DATA_SRV_REAL>();
            using (MySqlConnection con = new MySqlConnection(CS))
            {
                using (MySqlCommand cmd = new MySqlCommand("Select * from YREALIZATION where  YREALIZATION_PKID = " + Maxid))
                {

                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            lstsrvdeal.Add(new ZSD_REAL_DATA_SRV_REAL
                            {
                                Vbeln = Convert.ToString(sdr["Vbeln"]),
                                Vgbel = Convert.ToString(sdr["Vgbel"]),
                                Aubel = Convert.ToString(sdr["Aubel"]),
                                Erdat = Convert.ToString(sdr["Erdat"]),
                                Fkart = Convert.ToString(sdr["Fkart"]),
                                Regio = Convert.ToString(sdr["Regio"]),
                                Vkgrp = Convert.ToString(sdr["Vkgrp"]),
                                Dstrc = Convert.ToString(sdr["Dstrc"]),
                                Mnfplant = Convert.ToString(sdr["Mnfplant"]),
                                Plant = Convert.ToString(sdr["Plant"]),
                                Grade = Convert.ToString(sdr["Grade"]),
                                Matkl = Convert.ToString(sdr["Matkl"]),
                                Kalks = Convert.ToString(sdr["Kalks"]),
                                Kdgrp = Convert.ToString(sdr["Kdgrp"]),
                                Fkdat = Convert.ToString(sdr["Fkdat"]),
                                Matnr = Convert.ToString(sdr["Matnr"]),
                                Custcode1 = Convert.ToString(sdr["Custcode1"]),
                                Cname1 = Convert.ToString(sdr["Cname1"]),
                                Custcode2 = Convert.ToString(sdr["Custcode2"]),
                                Cname2 = Convert.ToString(sdr["Cname2"]),
                                Custcode3 = Convert.ToString(sdr["Custcode3"]),
                                Cname3 = Convert.ToString(sdr["Cname3"]),
                                ComAg = Convert.ToString(sdr["ComAg"]),
                                ComName = Convert.ToString(sdr["ComName"]),
                                Trans = Convert.ToString(sdr["Trans"]),
                                TransName = Convert.ToString(sdr["TransName"]),
                                Lgort = Convert.ToString(sdr["Lgort"]),
                                Lgobe = Convert.ToString(sdr["Lgobe"]),
                                Fkimg = Convert.ToDecimal(sdr["Fkimg"]),
                                Grossturn = Convert.ToDecimal(sdr["Grossturn"]),
                                Inco1 = Convert.ToString(sdr["Inco1"]),
                                Inco2 = Convert.ToString(sdr["Inco2"]),
                                Stprs = Convert.ToDecimal(sdr["Stprs"]),
                                Primaryfri = Convert.ToDecimal(sdr["Primaryfri"]),
                                Secondaryfri = Convert.ToDecimal(sdr["Secondaryfri"]),
                                Exwpf = Convert.ToDecimal(sdr["Exwpf"]),
                                Exgsf = Convert.ToDecimal(sdr["Exgsf"]),
                                Salestax = Convert.ToDecimal(sdr["Salestax"]),
                                Commission = Convert.ToDecimal(sdr["Commission"]),
                                Exciseduty = Convert.ToDecimal(sdr["Exciseduty"]),
                                Pddiscount = Convert.ToDecimal(sdr["Pddiscount"]),
                                Oddiscount = Convert.ToDecimal(sdr["Oddiscount"]),
                                Cfcharges = Convert.ToDecimal(sdr["Cfcharges"]),
                                Cddiscount = Convert.ToDecimal(sdr["Cddiscount"]),
                                Packing = Convert.ToDecimal(sdr["Packing"]),
                                Unloading = Convert.ToDecimal(sdr["Unloading"]),
                                Octrai = Convert.ToDecimal(sdr["Octrai"]),
                                Vat = Convert.ToDecimal(sdr["Vat"]),
                                Igst = Convert.ToDecimal(sdr["Igst"]),
                                Cgst = Convert.ToDecimal(sdr["Cgst"]),
                                Sgst = Convert.ToDecimal(sdr["Sgst"]),
                                Ugst = Convert.ToDecimal(sdr["Ugst"]),
                                ExpHand = Convert.ToDecimal(sdr["ExpHand"]),
                                Transport = Convert.ToDecimal(sdr["Transport"]),
                                AmtDwFrt = Convert.ToDecimal(sdr["AmtDwFrt"]),
                                PltFrt = Convert.ToDecimal(sdr["PltFrt"]),
                                Netturn = Convert.ToDecimal(sdr["Netturn"]),
                                Nakedreal = Convert.ToDecimal(sdr["Nakedreal"]),
                                Statedesc = Convert.ToString(sdr["Statedesc"]),
                                Sgrpdesc = Convert.ToString(sdr["Sgrpdesc"]),
                                Disdesc = Convert.ToString(sdr["Disdesc"]),
                                Graddesc = Convert.ToString(sdr["Graddesc"]),
                                Mnfdesc = Convert.ToString(sdr["Mnfdesc"]),
                                Plantdesc = Convert.ToString(sdr["Plantdesc"]),
                                Pgrpdesc = Convert.ToString(sdr["Pgrpdesc"]),
                                Cdate = Convert.ToString(sdr["Cdate"]),
                                Time = Convert.ToString(sdr["Time"]),
                                Suser = Convert.ToString(sdr["Suser"]),
                                BlockCt = Convert.ToString(sdr["BlockCt"]),
                                Route = Convert.ToString(sdr["Route"]),
                                Canceldate = Convert.ToString(sdr["Canceldate"]),
                                Cancelflag = Convert.ToString(sdr["Cancelflag"]),
                                Zzlgort1 = Convert.ToString(sdr["Zzlgort1"]),
                                Bzirk = Convert.ToString(sdr["Bzirk"]),
                                Vkbur = Convert.ToString(sdr["Vkbur"]),
                                Zzzone1 = Convert.ToString(sdr["Zzzone1"]),
                                Zzbranch = Convert.ToString(sdr["Zzbranch"]),
                                PernrEr = Convert.ToString(sdr["PernrEr"]),
                                EnameEr = Convert.ToString(sdr["EnameEr"]),
                                PernrY1 = Convert.ToString(sdr["PernrY1"]),
                                EnameY1 = Convert.ToString(sdr["EnameY1"]),
                                PernrY2 = Convert.ToString(sdr["PernrY2"]),
                                EnameY2 = Convert.ToString(sdr["EnameY2"]),
                                PernrY3 = Convert.ToString(sdr["PernrY3"]),
                                EnameY3 = Convert.ToString(sdr["EnameY3"]),
                                PernrY4 = Convert.ToString(sdr["PernrY4"]),
                                EnameY4 = Convert.ToString(sdr["EnameY4"]),
                                PernrY5 = Convert.ToString(sdr["PernrY5"]),
                                EnameY5 = Convert.ToString(sdr["EnameY5"]),
                                PernrY6 = Convert.ToString(sdr["PernrY6"]),
                                EnameY6 = Convert.ToString(sdr["EnameY6"]),
                                PernrY7 = Convert.ToString(sdr["PernrY7"]),
                                EnameY7 = Convert.ToString(sdr["EnameY7"]),
                                PernrY8 = Convert.ToString(sdr["PernrY8"]),
                                EnameY8 = Convert.ToString(sdr["EnameY8"]),
                                UpfrntDiscount = Convert.ToDecimal(sdr["UpfrntDiscount"]),
                                IndPriFrt = Convert.ToDecimal(sdr["IndPriFrt"]),
                                ShipFrtChrgs = Convert.ToDecimal(sdr["ShipFrtChrgs"]),
                                ShipHandChrgs = Convert.ToDecimal(sdr["ShipHandChrgs"]),
                                ZcustGrp = Convert.ToString(sdr["ZcustGrp"]),
                                ZcustGrpDesc = Convert.ToString(sdr["ZcustGrpDesc"]),
                                Vc = Convert.ToDecimal(sdr["Vc"]),
                                ZsalePromValue = Convert.ToDecimal(sdr["ZsalePromValue"]),
                                Waers = Convert.ToString(sdr["Waers"]),
                                Msehi = Convert.ToString(sdr["Msehi"]),
                                PayFreight = Convert.ToDecimal(sdr["PayFreight"]),
                                ExFreight = Convert.ToDecimal(sdr["ExFreight"]),
                            });
                        }
                    }
                    con.Close();
                }
            }
            if (InputID == "S")
            {
                using (MySqlConnection con = new MySqlConnection(CS))
                {
                    string query = "";
                    query += " Select * from YREALIZATION ";
                    query += " where date_format(cast(ERDAT as date),'%Y%m%d') ";
                    query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";
                    query += " order by date_format(cast(Erdat as date),'%Y%m%d') ";
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {

                        cmd.Connection = con;
                        con.Open();
                        using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                lstsrvdeal.Add(new ZSD_REAL_DATA_SRV_REAL
                                {
                                    Vbeln = Convert.ToString(sdr["Vbeln"]),
                                    Vgbel = Convert.ToString(sdr["Vgbel"]),
                                    Aubel = Convert.ToString(sdr["Aubel"]),
                                    Erdat = Convert.ToString(sdr["Erdat"]),
                                    Fkart = Convert.ToString(sdr["Fkart"]),
                                    Regio = Convert.ToString(sdr["Regio"]),
                                    Vkgrp = Convert.ToString(sdr["Vkgrp"]),
                                    Dstrc = Convert.ToString(sdr["Dstrc"]),
                                    Mnfplant = Convert.ToString(sdr["Mnfplant"]),
                                    Plant = Convert.ToString(sdr["Plant"]),
                                    Grade = Convert.ToString(sdr["Grade"]),
                                    Matkl = Convert.ToString(sdr["Matkl"]),
                                    Kalks = Convert.ToString(sdr["Kalks"]),
                                    Kdgrp = Convert.ToString(sdr["Kdgrp"]),
                                    Fkdat = Convert.ToString(sdr["Fkdat"]),
                                    Matnr = Convert.ToString(sdr["Matnr"]),
                                    Custcode1 = Convert.ToString(sdr["Custcode1"]),
                                    Cname1 = Convert.ToString(sdr["Cname1"]),
                                    Custcode2 = Convert.ToString(sdr["Custcode2"]),
                                    Cname2 = Convert.ToString(sdr["Cname2"]),
                                    Custcode3 = Convert.ToString(sdr["Custcode3"]),
                                    Cname3 = Convert.ToString(sdr["Cname3"]),
                                    ComAg = Convert.ToString(sdr["COM_AG"]),
                                    ComName = Convert.ToString(sdr["COM_NAME"]),
                                    Trans = Convert.ToString(sdr["Trans"]),
                                    TransName = Convert.ToString(sdr["TRANS_NAME"]),
                                    Lgort = Convert.ToString(sdr["Lgort"]),
                                    Lgobe = Convert.ToString(sdr["Lgobe"]),
                                    Fkimg = Convert.ToDecimal(sdr["Fkimg"]),
                                    Grossturn = Convert.ToDecimal(sdr["Grossturn"]),
                                    Inco1 = Convert.ToString(sdr["Inco1"]),
                                    Inco2 = Convert.ToString(sdr["Inco2"]),
                                    Stprs = Convert.ToDecimal(sdr["Stprs"]),
                                    Primaryfri = Convert.ToDecimal(sdr["Primaryfri"]),
                                    Secondaryfri = Convert.ToDecimal(sdr["Secondaryfri"]),
                                    Exwpf = Convert.ToDecimal(sdr["Exwpf"]),
                                    Exgsf = Convert.ToDecimal(sdr["Exgsf"]),
                                    Salestax = Convert.ToDecimal(sdr["Salestax"]),
                                    Commission = Convert.ToDecimal(sdr["Commission"]),
                                    Exciseduty = Convert.ToDecimal(sdr["Exciseduty"]),
                                    Pddiscount = Convert.ToDecimal(sdr["Pddiscount"]),
                                    Oddiscount = Convert.ToDecimal(sdr["Oddiscount"]),
                                    Cfcharges = Convert.ToDecimal(sdr["Cfcharges"]),
                                    Cddiscount = Convert.ToDecimal(sdr["Cddiscount"]),
                                    Packing = Convert.ToDecimal(sdr["Packing"]),
                                    Unloading = Convert.ToDecimal(sdr["Unloading"]),
                                    Octrai = Convert.ToDecimal(sdr["Octrai"]),
                                    Vat = Convert.ToDecimal(sdr["Vat"]),
                                    Igst = Convert.ToDecimal(sdr["Igst"]),
                                    Cgst = Convert.ToDecimal(sdr["Cgst"]),
                                    Sgst = Convert.ToDecimal(sdr["Sgst"]),
                                    Ugst = Convert.ToDecimal(sdr["Ugst"]),
                                    ExpHand = Convert.ToDecimal(sdr["EXP_HAND"]),
                                    Transport = Convert.ToDecimal(sdr["Transport"]),
                                    AmtDwFrt = Convert.ToDecimal(sdr["AMT_DW_FRT"]),
                                    PltFrt = Convert.ToDecimal(sdr["PLT_FRT"]),
                                    Netturn = Convert.ToDecimal(sdr["Netturn"]),
                                    Nakedreal = Convert.ToDecimal(sdr["Nakedreal"]),
                                    Statedesc = Convert.ToString(sdr["Statedesc"]),
                                    Sgrpdesc = Convert.ToString(sdr["Sgrpdesc"]),
                                    Disdesc = Convert.ToString(sdr["Disdesc"]),
                                    Graddesc = Convert.ToString(sdr["Graddesc"]),
                                    Mnfdesc = Convert.ToString(sdr["Mnfdesc"]),
                                    Plantdesc = Convert.ToString(sdr["Plantdesc"]),
                                    Pgrpdesc = Convert.ToString(sdr["Pgrpdesc"]),
                                    Cdate = Convert.ToString(sdr["Cdate"]),
                                    Time = Convert.ToString(sdr["Time"]),
                                    Suser = Convert.ToString(sdr["Suser"]),
                                    BlockCt = Convert.ToString(sdr["BLOCK_CT"]),
                                    Route = Convert.ToString(sdr["Route"]),
                                    Canceldate = Convert.ToString(sdr["Canceldate"]),
                                    Cancelflag = Convert.ToString(sdr["Cancelflag"]),
                                    Zzlgort1 = Convert.ToString(sdr["Zzlgort1"]),
                                    Bzirk = Convert.ToString(sdr["Bzirk"]),
                                    Vkbur = Convert.ToString(sdr["Vkbur"]),
                                    Zzzone1 = Convert.ToString(sdr["Zzzone1"]),
                                    Zzbranch = Convert.ToString(sdr["Zzbranch"]),
                                    PernrEr = Convert.ToString(sdr["PERNR_ER"]),
                                    EnameEr = Convert.ToString(sdr["ENAME_ER"]),
                                    PernrY1 = Convert.ToString(sdr["PERNR_Y1"]),
                                    EnameY1 = Convert.ToString(sdr["ENAME_Y1"]),
                                    PernrY2 = Convert.ToString(sdr["PERNR_Y2"]),
                                    EnameY2 = Convert.ToString(sdr["ENAME_Y2"]),
                                    PernrY3 = Convert.ToString(sdr["PERNR_Y3"]),
                                    EnameY3 = Convert.ToString(sdr["ENAME_Y3"]),
                                    PernrY4 = Convert.ToString(sdr["PERNR_Y4"]),
                                    EnameY4 = Convert.ToString(sdr["ENAME_Y4"]),
                                    PernrY5 = Convert.ToString(sdr["PERNR_Y5"]),
                                    EnameY5 = Convert.ToString(sdr["ENAME_Y5"]),
                                    PernrY6 = Convert.ToString(sdr["PERNR_Y6"]),
                                    EnameY6 = Convert.ToString(sdr["ENAME_Y6"]),
                                    PernrY7 = Convert.ToString(sdr["PERNR_Y7"]),
                                    EnameY7 = Convert.ToString(sdr["ENAME_Y7"]),
                                    PernrY8 = Convert.ToString(sdr["PERNR_Y8"]),
                                    EnameY8 = Convert.ToString(sdr["ENAME_Y8"]),
                                    UpfrntDiscount = Convert.ToDecimal(sdr["UPFRNT_DISCOUNT"]),
                                    IndPriFrt = Convert.ToDecimal(sdr["IND_PRI_FRT"]),
                                    ShipFrtChrgs = Convert.ToDecimal(sdr["SHIP_FRT_CHRGS"]),
                                    ShipHandChrgs = Convert.ToDecimal(sdr["SHIP_HAND_CHRGS"]),
                                    ZcustGrp = Convert.ToString(sdr["ZCUST_GRP"]),
                                    ZcustGrpDesc = Convert.ToString(sdr["ZCUST_GRP_DESC"]),
                                    Vc = Convert.ToDecimal(sdr["Vc"]),
                                    ZsalePromValue = Convert.ToDecimal(sdr["ZsalePromValue"]),
                                    Waers = Convert.ToString(sdr["Waers"]),
                                    Msehi = Convert.ToString(sdr["Msehi"]),
                                    PayFreight = Convert.ToDecimal(sdr["PayFreight"]),
                                    ExFreight = Convert.ToDecimal(sdr["ExFreight"]),
                                });
                            }
                        }
                        con.Close();
                    }
                }
            }
            if (InputID == "E")
            {
                DataTable dt1 = new DataTable("YREALIZATION");
                dt1.Columns.AddRange(new DataColumn[107]
                {
                            new DataColumn("Billing Document"),
                            new DataColumn("Reference Document"),
                            new DataColumn("Sales Document"),
                            new DataColumn("Creation Date"),
                            new DataColumn("Billing Type"),
                            new DataColumn("State code"),
                            new DataColumn("Sales Group code"),
                            new DataColumn("District code"),
                            new DataColumn("Manfuacture Plant"),
                            new DataColumn("Plant"),
                            new DataColumn("Material Pricing Group"),
                            new DataColumn("Material Group"),
                            new DataColumn("Pricing procedure "),
                            new DataColumn("Customer group"),
                            new DataColumn("Billing Date "),
                            new DataColumn("Material Number"),
                            new DataColumn("Customer Code"),
                            new DataColumn("Customer Name"),
                            new DataColumn("Sales Rep code"),
                            new DataColumn("Sales Rep Name"),
                            new DataColumn("Consignee Code"),
                            new DataColumn("Consignee Name"),
                            new DataColumn("Commission Agent code"),
                            new DataColumn("Commission Agenet Name"),
                            new DataColumn("Transporter Code"),
                            new DataColumn("Transporter Name"),
                            new DataColumn("Storage Location"),
                            new DataColumn("Description of Storage Location"),
                            new DataColumn("Billed quantity"),
                            new DataColumn("Gross Turnover"),
                            new DataColumn("Incoterms1"),
                            new DataColumn("Incoterms2"),
                            new DataColumn("Standard price"),
                            new DataColumn("Primary Freight"),
                            new DataColumn("Secondary freight"),
                            new DataColumn("Ex-Works Primary Freight"),
                            new DataColumn("Ex-Works Secondary Freight"),
                            new DataColumn("Sales Tax"),
                            new DataColumn("Commission"),
                            new DataColumn("Excise Duty"),
                            new DataColumn("Price Discount"),
                            new DataColumn("Other Discount"),
                            new DataColumn("CFA charges"),
                            new DataColumn("Cash Discount"),
                            new DataColumn("Packing Charges"),
                            new DataColumn("Unloading Charges"),
                            new DataColumn("Octrai"),
                            new DataColumn("VAT"),
                            new DataColumn("IGST"),
                            new DataColumn("CGST"),
                            new DataColumn("SGST"),
                            new DataColumn("UGST"),
                            new DataColumn("Export Handling chgs"),
                            new DataColumn("Transport Incentive"),
                            new DataColumn("Demurrage Wharfage"),
                            new DataColumn("Plant freight"),
                            new DataColumn("Net Turnrover"),
                            new DataColumn("Realisation"),
                            new DataColumn("State Name"),
                            new DataColumn("Branch"),
                            new DataColumn("Distrct Name"),
                            new DataColumn("Grade"),
                            new DataColumn("Manfacture Plant name"),
                            new DataColumn("Plant Name"),
                            new DataColumn("Customer Group Name"),
                            new DataColumn("System Date"),
                            new DataColumn("System Time"),
                            new DataColumn("User Name"),
                            new DataColumn("Block Category"),
                            new DataColumn("Description of Route"),
                            new DataColumn("Date on Which Record Was Created"),
                            new DataColumn("Single-Character Flag"),
                            new DataColumn("Moving Storage loc "),
                            new DataColumn("Sales district"),
                            new DataColumn("Sales Office"),
                            new DataColumn("Transportation zone"),
                            new DataColumn("Branch Office"),
                            new DataColumn("Sales Officer Emp.No."),
                            new DataColumn("Sales Officer Emp.Name"),
                            new DataColumn("RM1"),
                            new DataColumn("RM1 Name"),
                            new DataColumn("RM2 "),
                            new DataColumn("RM2 Name"),
                            new DataColumn("RM3"),
                            new DataColumn("RM3 Name"),
                            new DataColumn("RM4"),
                            new DataColumn("RM4 Name"),
                            new DataColumn("RM5"),
                            new DataColumn("RM5 Name"),
                            new DataColumn("RM6"),
                            new DataColumn("RM6 Name"),
                            new DataColumn("RM7"),
                            new DataColumn("RM7 Name"),
                            new DataColumn("RM8"),
                            new DataColumn("RM8 Name"),
                            new DataColumn("Upfront Discount Amount"),
                            new DataColumn("Indirect Primary Freight"),
                            new DataColumn("Ship Freight"),
                            new DataColumn("Ship Handling Charges"),
                            new DataColumn("Customer group_1"),
                            new DataColumn("Customer Group Desc."),
                            new DataColumn("Varible Cost"),
                            new DataColumn("ZsalePromValue"),
                            new DataColumn("Waers"),
                            new DataColumn("Msehi"),
                            new DataColumn("PayFreight"),
                            new DataColumn("ExFreight")



                 });

                using (MySqlConnection con = new MySqlConnection(CS))
                {
                    string query = "";
                    query += " Select * from YREALIZATION ";
                    query += " where date_format(cast(ERDAT as date),'%Y%m%d') ";
                    query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";
                    query += " order by date_format(cast(Erdat as date),'%Y%m%d') ";
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {

                        cmd.Connection = con;
                        con.Open();
                        using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                DataRow _dr = dt1.NewRow();


                                _dr["Billing Document"] = Convert.ToString(sdr["VBELN"]);
                                _dr["Reference Document"] = Convert.ToString(sdr["VGBEL"]);
                                _dr["Sales Document"] = Convert.ToString(sdr["AUBEL"]);
                                _dr["Creation Date"] = Convert.ToString(sdr["ERDAT"]);
                                _dr["Billing Type"] = Convert.ToString(sdr["FKART"]);
                                _dr["State code"] = Convert.ToString(sdr["REGIO"]);
                                _dr["Sales Group code"] = Convert.ToString(sdr["VKGRP"]);
                                _dr["District code"] = Convert.ToString(sdr["DSTRC"]);
                                _dr["Manfuacture Plant"] = Convert.ToString(sdr["MNFPLANT"]);
                                _dr["Plant"] = Convert.ToString(sdr["PLANT"]);
                                _dr["Material Pricing Group"] = Convert.ToString(sdr["GRADE"]);
                                _dr["Material Group"] = Convert.ToString(sdr["MATKL"]);
                                _dr["Pricing procedure "] = Convert.ToString(sdr["KALKS"]);
                                _dr["Customer group"] = Convert.ToString(sdr["KDGRP"]);
                                _dr["Billing Date "] = Convert.ToString(sdr["FKDAT"]);
                                _dr["Material Number"] = Convert.ToString(sdr["MATNR"]);
                                _dr["Customer Code"] = Convert.ToString(sdr["CUSTCODE1"]);
                                _dr["Customer Name"] = Convert.ToString(sdr["CNAME1"]);
                                _dr["Sales Rep code"] = Convert.ToString(sdr["CUSTCODE2"]);
                                _dr["Sales Rep Name"] = Convert.ToString(sdr["CNAME2"]);
                                _dr["Consignee Code"] = Convert.ToString(sdr["CUSTCODE3"]);
                                _dr["Consignee Name"] = Convert.ToString(sdr["CNAME3"]);
                                _dr["Commission Agent code"] = Convert.ToString(sdr["COM_AG"]);
                                _dr["Commission Agenet Name"] = Convert.ToString(sdr["COM_NAME"]);
                                _dr["Transporter Code"] = Convert.ToString(sdr["TRANS"]);
                                _dr["Transporter Name"] = Convert.ToString(sdr["TRANS_NAME"]);
                                _dr["Storage Location"] = Convert.ToString(sdr["LGORT"]);
                                _dr["Description of Storage Location"] = Convert.ToString(sdr["LGOBE"]);
                                _dr["Billed quantity"] = Convert.ToDecimal(sdr["FKIMG"]);
                                _dr["Gross Turnover"] = Convert.ToDecimal(sdr["GROSSTURN"]);
                                _dr["Incoterms1"] = Convert.ToString(sdr["INCO1"]);
                                _dr["Incoterms2"] = Convert.ToString(sdr["INCO2"]);
                                _dr["Standard price"] = Convert.ToDecimal(sdr["STPRS"]);
                                _dr["Primary Freight"] = Convert.ToDecimal(sdr["PRIMARYFRI"]);
                                _dr["Secondary freight"] = Convert.ToDecimal(sdr["SECONDARYFRI"]);
                                _dr["Ex-Works Primary Freight"] = Convert.ToDecimal(sdr["EXWPF"]);
                                _dr["Ex-Works Secondary Freight"] = Convert.ToDecimal(sdr["EXGSF"]);
                                _dr["Sales Tax"] = Convert.ToDecimal(sdr["SALESTAX"]);
                                _dr["Commission"] = Convert.ToDecimal(sdr["COMMISSION"]);
                                _dr["Excise Duty"] = Convert.ToDecimal(sdr["EXCISEDUTY"]);
                                _dr["Price Discount"] = Convert.ToDecimal(sdr["PDDISCOUNT"]);
                                _dr["Other Discount"] = Convert.ToDecimal(sdr["ODDISCOUNT"]);
                                _dr["CFA charges"] = Convert.ToDecimal(sdr["CFCHARGES"]);
                                _dr["Cash Discount"] = Convert.ToDecimal(sdr["CDDISCOUNT"]);
                                _dr["Packing Charges"] = Convert.ToDecimal(sdr["PACKING"]);
                                _dr["Unloading Charges"] = Convert.ToDecimal(sdr["UNLOADING"]);
                                _dr["Octrai"] = Convert.ToDecimal(sdr["OCTRAI"]);
                                _dr["VAT"] = Convert.ToDecimal(sdr["VAT"]);
                                _dr["IGST"] = Convert.ToDecimal(sdr["IGST"]);
                                _dr["CGST"] = Convert.ToDecimal(sdr["CGST"]);
                                _dr["SGST"] = Convert.ToDecimal(sdr["SGST"]);
                                _dr["UGST"] = Convert.ToDecimal(sdr["UGST"]);
                                _dr["Export Handling chgs"] = Convert.ToDecimal(sdr["EXP_HAND"]);
                                _dr["Transport Incentive"] = Convert.ToDecimal(sdr["TRANSPORT"]);
                                _dr["Demurrage Wharfage"] = Convert.ToDecimal(sdr["AMT_DW_FRT"]);
                                _dr["Plant freight"] = Convert.ToDecimal(sdr["PLT_FRT"]);
                                _dr["Net Turnrover"] = Convert.ToDecimal(sdr["NETTURN"]);
                                _dr["Realisation"] = Convert.ToDecimal(sdr["NAKEDREAL"]);
                                _dr["State Name"] = Convert.ToString(sdr["STATEDESC"]);
                                _dr["Branch"] = Convert.ToString(sdr["SGRPDESC"]);
                                _dr["Distrct Name"] = Convert.ToString(sdr["DISDESC"]);
                                _dr["Grade"] = Convert.ToString(sdr["GRADDESC"]);
                                _dr["Manfacture Plant name"] = Convert.ToString(sdr["MNFDESC"]);
                                _dr["Plant Name"] = Convert.ToString(sdr["PLANTDESC"]);
                                _dr["Customer Group Name"] = Convert.ToString(sdr["PGRPDESC"]);
                                _dr["System Date"] = Convert.ToString(sdr["CDATE"]);
                                _dr["System Time"] = Convert.ToString(sdr["TIME"]);
                                _dr["User Name"] = Convert.ToString(sdr["SUSER"]);
                                _dr["Block Category"] = Convert.ToString(sdr["BLOCK_CT"]);
                                _dr["Description of Route"] = Convert.ToString(sdr["ROUTE"]);
                                _dr["Date on Which Record Was Created"] = Convert.ToString(sdr["CANCELDATE"]);
                                _dr["Single-Character Flag"] = Convert.ToString(sdr["CANCELFLAG"]);
                                _dr["Moving Storage loc "] = Convert.ToString(sdr["ZZLGORT1"]);
                                _dr["Sales district"] = Convert.ToString(sdr["BZIRK"]);
                                _dr["Sales Office"] = Convert.ToString(sdr["VKBUR"]);
                                _dr["Transportation zone"] = Convert.ToString(sdr["ZZZONE1"]);
                                _dr["Branch Office"] = Convert.ToString(sdr["ZZBRANCH"]);
                                _dr["Sales Officer Emp.No."] = Convert.ToString(sdr["PERNR_ER"]);
                                _dr["Sales Officer Emp.Name"] = Convert.ToString(sdr["ENAME_ER"]);
                                _dr["RM1"] = Convert.ToString(sdr["PERNR_Y1"]);
                                _dr["RM1 Name"] = Convert.ToString(sdr["ENAME_Y1"]);
                                _dr["RM2 "] = Convert.ToString(sdr["PERNR_Y2"]);
                                _dr["RM2 Name"] = Convert.ToString(sdr["ENAME_Y2"]);
                                _dr["RM3"] = Convert.ToString(sdr["PERNR_Y3"]);
                                _dr["RM3 Name"] = Convert.ToString(sdr["ENAME_Y3"]);
                                _dr["RM4"] = Convert.ToString(sdr["PERNR_Y4"]);
                                _dr["RM4 Name"] = Convert.ToString(sdr["ENAME_Y4"]);
                                _dr["RM5"] = Convert.ToString(sdr["PERNR_Y5"]);
                                _dr["RM5 Name"] = Convert.ToString(sdr["ENAME_Y5"]);
                                _dr["RM6"] = Convert.ToString(sdr["PERNR_Y6"]);
                                _dr["RM6 Name"] = Convert.ToString(sdr["ENAME_Y6"]);
                                _dr["RM7"] = Convert.ToString(sdr["PERNR_Y7"]);
                                _dr["RM7 Name"] = Convert.ToString(sdr["ENAME_Y7"]);
                                _dr["RM8"] = Convert.ToString(sdr["PERNR_Y8"]);
                                _dr["RM8 Name"] = Convert.ToString(sdr["ENAME_Y8"]);
                                _dr["Upfront Discount Amount"] = Convert.ToDecimal(sdr["UPFRNT_DISCOUNT"]);
                                _dr["Indirect Primary Freight"] = Convert.ToDecimal(sdr["IND_PRI_FRT"]);
                                _dr["Ship Freight"] = Convert.ToDecimal(sdr["SHIP_FRT_CHRGS"]);
                                _dr["Ship Handling Charges"] = Convert.ToDecimal(sdr["SHIP_HAND_CHRGS"]);
                                _dr["Customer group_1"] = Convert.ToString(sdr["ZCUST_GRP"]);
                                _dr["Customer Group Desc."] = Convert.ToString(sdr["ZCUST_GRP_DESC"]);
                                _dr["Varible Cost"] = Convert.ToDecimal(sdr["VC"]);
                                _dr["ZsalePromValue"] = Convert.ToDecimal(sdr["ZsalePromValue"]);
                                _dr["Waers"] = Convert.ToString(sdr["Waers"]);
                                _dr["Msehi"] = Convert.ToString(sdr["Msehi"]);
                                _dr["PayFreight"] = Convert.ToDecimal(sdr["PayFreight"]);
                                _dr["ExFreight"] = Convert.ToDecimal(sdr["ExFreight"]);


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
                        ViewBag.export = "success";
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "yrealization.xlsx");
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
         
           
            ViewData["videoList"] = lstsrvdeal.ToPagedList(pageNumber, pageSize);
            ViewData["GroupID"] = 0;
            //ViewData["lstsrvdeal"] = lstsrvdeal;
            //return JavaScript("window.close();");
            return View(lstsrvdeal);
            
        }




        [HttpPost]
        public ActionResult Index(string startDate, string endDate, string InputID, int? page)
        {

            string filename = System.Configuration.ConfigurationManager.AppSettings["LogFile"].ToString();

            try
            {


                var url = "";
                string query = "";
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

                List<ZSD_REAL_DATA_SRV_REAL> lstsrvdeal = new List<ZSD_REAL_DATA_SRV_REAL>();
                DateTime fromDateValue;
                var formats = new[] { "ddMMyyyy", "yyyyMMdd", "yyyyMMdd" };
                if (!DateTime.TryParseExact(startDate.Trim(), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue) || !(DateTime.TryParseExact(endDate.Trim(), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue)))
                {

                    TempData["ErrMsg"] = "From Date or to Date is not Valid.Unable Process Request.";
                    return RedirectToAction("Index");
                    //return View("About");
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

                    //Log.Info("===========================================");
                    //Log.Info("Application From Date  " + startDate);
                    //Log.Info("Application To Date  " + endDate);
                    //Log.Info("Executed on : " + DateTime.Now);
                    //LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);

                    log1.WriteLine("===========================================");
                    log1.WriteLine("Application From Date  " + startDate);
                    log1.WriteLine("Application To Date  " + endDate);
                    log1.WriteLine("Executed on : " + DateTime.Now);
                    //log1.WriteLine("Table Name : YREALIZATION");

                    //var url = "";
                    //string query = "";
                    int reccount = 0;
                    //List<ZSD_REAL_DATA_SRV_REAL> lstsrvdeal = new List<ZSD_REAL_DATA_SRV_REAL>();

                    //var formats = new[] { "ddMMyyyy", "yyyyMMdd", "yyyyMMdd" };

                    //Development
                    //url = "https://netwaver-dev.pennacement.com:443/sap/opu/odata/sap/ZSD_REAL_DATA_SRV/REALSet?$format=json&$filter=Erdat ge '" + startDate.Trim() + "' and Erdat le '" + endDate.Trim() + "'";
                    //string userName = "NWGW001";
                    //string passwd = "Penna@123";
                    //string logicostrpt = System.Configuration.ConfigurationManager.AppSettings["LogiCost"].ToString();
                    url = "https://netwaver-prd.pennacement.com:443/sap/opu/odata/sap/ZSD_REAL_DATA_SRV/REALSet?$format=json&$filter=Erdat ge '" + startDate.Trim() + "' and Erdat le '" + endDate.Trim() + "'";
                    string userName = "NWGW037";
                    string passwd = "Admin@123456";
                    log1.WriteLine("Insert Table : YREALIZATION");

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
                        List<ZSD_REAL_DATA_SRV_REAL> varoutput = men1.ToObject<List<ZSD_REAL_DATA_SRV_REAL>>();
                        var o = JsonConvert.DeserializeObject<List<ZSD_REAL_DATA_SRV_REAL>>(men1.ToString());

                        Common converter = new Common();


                        DataTable dt = converter.ToDataTable(varoutput);

                        if (dt.Rows.Count > 0)
                        {
                            log1.WriteLine("WebApi Record Count : " + dt.Rows.Count);
                        }
                        else
                        {
                            log1.WriteLine("WebApi Record Count : 0");
                        }

                        query = "";
                        query += " Delete from YREALIZATION ";
                        query += " where date_format(cast(Fkdat as date),'%Y%m%d') ";
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

                                query = "Insert into YREALIZATION(VBELN,VGBEL,AUBEL,ERDAT,FKART,REGIO,VKGRP,DSTRC,MNFPLANT,PLANT,GRADE,MATKL,KALKS,KDGRP,";
                                query += "FKDAT,MATNR,CUSTCODE1,CNAME1,CUSTCODE2,CNAME2,CUSTCODE3,CNAME3,COM_AG,COM_NAME,TRANS,TRANS_NAME,";
                                query += "LGORT,LGOBE,FKIMG,GROSSTURN,INCO1,INCO2,STPRS,PRIMARYFRI,SECONDARYFRI,EXWPF,EXGSF,SALESTAX,COMMISSION,";
                                query += "EXCISEDUTY,PDDISCOUNT,ODDISCOUNT,CFCHARGES,CDDISCOUNT,PACKING,UNLOADING,OCTRAI,VAT,IGST,CGST,";
                                query += "SGST,UGST,EXP_HAND,TRANSPORT,AMT_DW_FRT,PLT_FRT,NETTURN,NAKEDREAL,STATEDESC,SGRPDESC,DISDESC,GRADDESC,MNFDESC,";
                                query += "PLANTDESC,PGRPDESC,CDATE,TIME,SUSER,BLOCK_CT,ROUTE,CANCELDATE,CANCELFLAG,ZZLGORT1,BZIRK,VKBUR,ZZZONE1,";
                                query += "ZZBRANCH,PERNR_ER,ENAME_ER,PERNR_Y1,ENAME_Y1,PERNR_Y2,ENAME_Y2,PERNR_Y3,ENAME_Y3,PERNR_Y4,ENAME_Y4,PERNR_Y5,";
                                query += "ENAME_Y5,PERNR_Y6,ENAME_Y6,PERNR_Y7,ENAME_Y7,PERNR_Y8,ENAME_Y8,UPFRNT_DISCOUNT,IND_PRI_FRT,SHIP_FRT_CHRGS,";
                                query += "SHIP_HAND_CHRGS,ZCUST_GRP,ZCUST_GRP_DESC,Vc,ZsalePromValue,Waers,Msehi,PayFreight,ExFreight) Values ";
                                query += "(@VBELN,@VGBEL,@AUBEL,@ERDAT,@FKART,@REGIO,@VKGRP,@DSTRC,@MNFPLANT,@PLANT,@GRADE,@MATKL,@KALKS,@KDGRP,";
                                query += "@FKDAT,@MATNR,@CUSTCODE1,@CNAME1,@CUSTCODE2,@CNAME2,@CUSTCODE3,@CNAME3,@COM_AG,@COM_NAME,@TRANS,@TRANS_NAME,";
                                query += "@LGORT,@LGOBE,@FKIMG,@GROSSTURN,@INCO1,@INCO2,@STPRS,@PRIMARYFRI,@SECONDARYFRI,@EXWPF,@EXGSF,@SALESTAX,@COMMISSION,";
                                query += "@EXCISEDUTY,@PDDISCOUNT,@ODDISCOUNT,@CFCHARGES,@CDDISCOUNT,@PACKING,@UNLOADING,@OCTRAI,@VAT,@IGST,@CGST,";
                                query += "@SGST,@UGST,@EXP_HAND,@TRANSPORT,@AMT_DW_FRT,@PLT_FRT,@NETTURN,@NAKEDREAL,@STATEDESC,@SGRPDESC,@DISDESC,@GRADDESC,@MNFDESC,";
                                query += "@PLANTDESC,@PGRPDESC,@CDATE,@TIME,@SUSER,@BLOCK_CT,@ROUTE,@CANCELDATE,@CANCELFLAG,@ZZLGORT1,@BZIRK,@VKBUR,@ZZZONE1,";
                                query += "@ZZBRANCH,@PERNR_ER,@ENAME_ER,@PERNR_Y1,@ENAME_Y1,@PERNR_Y2,@ENAME_Y2,@PERNR_Y3,@ENAME_Y3,@PERNR_Y4,@ENAME_Y4,@PERNR_Y5,";
                                query += "@ENAME_Y5,@PERNR_Y6,@ENAME_Y6,@PERNR_Y7,@ENAME_Y7,@PERNR_Y8,@ENAME_Y8,@UPFRNT_DISCOUNT,@IND_PRI_FRT,@SHIP_FRT_CHRGS,";
                                query += "@SHIP_HAND_CHRGS,@ZCUST_GRP,@ZCUST_GRP_DESC,@Vc,@ZsalePromValue,@Waers,@Msehi,@PayFreight,@ExFreight);";
                                MySqlCommand cmd = new MySqlCommand(query, con);

                                cmd.Parameters.AddWithValue("@VBELN", row["VBELN"].ToString());
                                cmd.Parameters.AddWithValue("@VGBEL", row["VGBEL"].ToString());
                                cmd.Parameters.AddWithValue("@AUBEL", row["AUBEL"].ToString());
                                cmd.Parameters.AddWithValue("@ERDAT", row["ERDAT"].ToString());
                                cmd.Parameters.AddWithValue("@FKART", row["FKART"].ToString());
                                cmd.Parameters.AddWithValue("@REGIO", row["REGIO"].ToString());
                                cmd.Parameters.AddWithValue("@VKGRP", row["VKGRP"].ToString());
                                cmd.Parameters.AddWithValue("@DSTRC", row["DSTRC"].ToString());
                                cmd.Parameters.AddWithValue("@MNFPLANT", row["MNFPLANT"].ToString());
                                cmd.Parameters.AddWithValue("@PLANT", row["PLANT"].ToString());
                                cmd.Parameters.AddWithValue("@GRADE", row["GRADE"].ToString());
                                cmd.Parameters.AddWithValue("@MATKL", row["MATKL"].ToString());
                                cmd.Parameters.AddWithValue("@KALKS", row["KALKS"].ToString());
                                cmd.Parameters.AddWithValue("@KDGRP", row["KDGRP"].ToString());
                                cmd.Parameters.AddWithValue("@FKDAT", row["FKDAT"].ToString());
                                cmd.Parameters.AddWithValue("@MATNR", row["MATNR"].ToString());
                                cmd.Parameters.AddWithValue("@CUSTCODE1", row["CUSTCODE1"].ToString());
                                cmd.Parameters.AddWithValue("@CNAME1", row["CNAME1"].ToString());
                                cmd.Parameters.AddWithValue("@CUSTCODE2", row["CUSTCODE2"].ToString());
                                cmd.Parameters.AddWithValue("@CNAME2", row["CNAME2"].ToString());
                                cmd.Parameters.AddWithValue("@CUSTCODE3", row["CUSTCODE3"].ToString());
                                cmd.Parameters.AddWithValue("@CNAME3", row["CNAME3"].ToString());
                                cmd.Parameters.AddWithValue("@COM_AG", row["COMAG"].ToString());
                                cmd.Parameters.AddWithValue("@COM_NAME", row["COMNAME"].ToString());
                                cmd.Parameters.AddWithValue("@TRANS", row["TRANS"].ToString());
                                cmd.Parameters.AddWithValue("@TRANS_NAME", row["TRANSNAME"].ToString());
                                cmd.Parameters.AddWithValue("@LGORT", row["LGORT"].ToString());
                                cmd.Parameters.AddWithValue("@LGOBE", row["LGOBE"].ToString());
                                cmd.Parameters.AddWithValue("@FKIMG", row["FKIMG"].ToString());
                                cmd.Parameters.AddWithValue("@GROSSTURN", row["GROSSTURN"].ToString());
                                cmd.Parameters.AddWithValue("@INCO1", row["INCO1"].ToString());
                                cmd.Parameters.AddWithValue("@INCO2", row["INCO2"].ToString());
                                cmd.Parameters.AddWithValue("@STPRS", row["STPRS"].ToString());
                                cmd.Parameters.AddWithValue("@PRIMARYFRI", row["PRIMARYFRI"].ToString());
                                cmd.Parameters.AddWithValue("@SECONDARYFRI", row["SECONDARYFRI"].ToString());
                                cmd.Parameters.AddWithValue("@EXWPF", row["EXWPF"].ToString());
                                cmd.Parameters.AddWithValue("@EXGSF", row["EXGSF"].ToString());
                                cmd.Parameters.AddWithValue("@SALESTAX", row["SALESTAX"].ToString());
                                cmd.Parameters.AddWithValue("@COMMISSION", row["COMMISSION"].ToString());
                                cmd.Parameters.AddWithValue("@EXCISEDUTY", row["EXCISEDUTY"].ToString());
                                cmd.Parameters.AddWithValue("@PDDISCOUNT", row["PDDISCOUNT"].ToString());
                                cmd.Parameters.AddWithValue("@ODDISCOUNT", row["ODDISCOUNT"].ToString());
                                cmd.Parameters.AddWithValue("@CFCHARGES", row["CFCHARGES"].ToString());
                                cmd.Parameters.AddWithValue("@CDDISCOUNT", row["CDDISCOUNT"].ToString());
                                cmd.Parameters.AddWithValue("@PACKING", row["PACKING"].ToString());
                                cmd.Parameters.AddWithValue("@UNLOADING", row["UNLOADING"].ToString());
                                cmd.Parameters.AddWithValue("@OCTRAI", row["OCTRAI"].ToString());
                                cmd.Parameters.AddWithValue("@VAT", row["VAT"].ToString());
                                cmd.Parameters.AddWithValue("@IGST", row["IGST"].ToString());
                                cmd.Parameters.AddWithValue("@CGST", row["CGST"].ToString());
                                cmd.Parameters.AddWithValue("@SGST", row["SGST"].ToString());
                                cmd.Parameters.AddWithValue("@UGST", row["UGST"].ToString());
                                cmd.Parameters.AddWithValue("@EXP_HAND", row["EXPHAND"].ToString());
                                cmd.Parameters.AddWithValue("@TRANSPORT", row["TRANSPORT"].ToString());
                                cmd.Parameters.AddWithValue("@AMT_DW_FRT", row["AMTDWFRT"].ToString());
                                cmd.Parameters.AddWithValue("@PLT_FRT", row["PLTFRT"].ToString());
                                cmd.Parameters.AddWithValue("@NETTURN", row["NETTURN"].ToString());
                                cmd.Parameters.AddWithValue("@NAKEDREAL", row["NAKEDREAL"].ToString());
                                cmd.Parameters.AddWithValue("@STATEDESC", row["STATEDESC"].ToString());
                                cmd.Parameters.AddWithValue("@SGRPDESC", row["SGRPDESC"].ToString());
                                cmd.Parameters.AddWithValue("@DISDESC", row["DISDESC"].ToString());
                                cmd.Parameters.AddWithValue("@GRADDESC", row["GRADDESC"].ToString());
                                cmd.Parameters.AddWithValue("@MNFDESC", row["MNFDESC"].ToString());
                                cmd.Parameters.AddWithValue("@PLANTDESC", row["PLANTDESC"].ToString());
                                cmd.Parameters.AddWithValue("@PGRPDESC", row["PGRPDESC"].ToString());
                                cmd.Parameters.AddWithValue("@CDATE", row["CDATE"].ToString());
                                cmd.Parameters.AddWithValue("@TIME", row["TIME"].ToString());
                                cmd.Parameters.AddWithValue("@SUSER", row["SUSER"].ToString());
                                cmd.Parameters.AddWithValue("@BLOCK_CT", row["BLOCKCT"].ToString());
                                cmd.Parameters.AddWithValue("@ROUTE", row["ROUTE"].ToString());
                                cmd.Parameters.AddWithValue("@CANCELDATE", row["CANCELDATE"].ToString());
                                cmd.Parameters.AddWithValue("@CANCELFLAG", row["CANCELFLAG"].ToString());
                                cmd.Parameters.AddWithValue("@ZZLGORT1", row["ZZLGORT1"].ToString());
                                cmd.Parameters.AddWithValue("@BZIRK", row["BZIRK"].ToString());
                                cmd.Parameters.AddWithValue("@VKBUR", row["VKBUR"].ToString());
                                cmd.Parameters.AddWithValue("@ZZZONE1", row["ZZZONE1"].ToString());
                                cmd.Parameters.AddWithValue("@ZZBRANCH", row["ZZBRANCH"].ToString());
                                cmd.Parameters.AddWithValue("@PERNR_ER", row["PERNRER"].ToString());
                                cmd.Parameters.AddWithValue("@ENAME_ER", row["ENAMEER"].ToString());
                                cmd.Parameters.AddWithValue("@PERNR_Y1", row["PERNRY1"].ToString());
                                cmd.Parameters.AddWithValue("@ENAME_Y1", row["ENAMEY1"].ToString());
                                cmd.Parameters.AddWithValue("@PERNR_Y2", row["PERNRY2"].ToString());
                                cmd.Parameters.AddWithValue("@ENAME_Y2", row["ENAMEY2"].ToString());
                                cmd.Parameters.AddWithValue("@PERNR_Y3", row["PERNRY3"].ToString());
                                cmd.Parameters.AddWithValue("@ENAME_Y3", row["ENAMEY3"].ToString());
                                cmd.Parameters.AddWithValue("@PERNR_Y4", row["PERNRY4"].ToString());
                                cmd.Parameters.AddWithValue("@ENAME_Y4", row["ENAMEY4"].ToString());
                                cmd.Parameters.AddWithValue("@PERNR_Y5", row["PERNRY5"].ToString());
                                cmd.Parameters.AddWithValue("@ENAME_Y5", row["ENAMEY5"].ToString());
                                cmd.Parameters.AddWithValue("@PERNR_Y6", row["PERNRY6"].ToString());
                                cmd.Parameters.AddWithValue("@ENAME_Y6", row["ENAMEY6"].ToString());
                                cmd.Parameters.AddWithValue("@PERNR_Y7", row["PERNRY7"].ToString());
                                cmd.Parameters.AddWithValue("@ENAME_Y7", row["ENAMEY7"].ToString());
                                cmd.Parameters.AddWithValue("@PERNR_Y8", row["PERNRY8"].ToString());
                                cmd.Parameters.AddWithValue("@ENAME_Y8", row["ENAMEY8"].ToString());
                                cmd.Parameters.AddWithValue("@UPFRNT_DISCOUNT", row["UPFRNTDISCOUNT"].ToString());
                                cmd.Parameters.AddWithValue("@IND_PRI_FRT", row["INDPRIFRT"].ToString());
                                cmd.Parameters.AddWithValue("@SHIP_FRT_CHRGS", row["SHIPFRTCHRGS"].ToString());
                                cmd.Parameters.AddWithValue("@SHIP_HAND_CHRGS", row["SHIPHANDCHRGS"].ToString());
                                cmd.Parameters.AddWithValue("@ZCUST_GRP", row["ZCUSTGRP"].ToString());
                                cmd.Parameters.AddWithValue("@ZCUST_GRP_DESC", row["ZCUSTGRPDESC"].ToString());
                                cmd.Parameters.AddWithValue("@Vc", row["Vc"].ToString());
                                cmd.Parameters.AddWithValue("@ZsalePromValue", row["ZsalePromValue"].ToString());
                                cmd.Parameters.AddWithValue("@Waers", row["Waers"].ToString());
                                cmd.Parameters.AddWithValue("@Msehi", row["Msehi"].ToString());
                                cmd.Parameters.AddWithValue("@PayFreight", row["PayFreight"].ToString());
                                cmd.Parameters.AddWithValue("@ExFreight", row["ExFreight"].ToString());

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
                        query += " Select Count(*) Cnt from YREALIZATION ";
                        query += " where date_format(cast(Erdat as date),'%Y%m%d') ";
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
                            query += " Delete from YREALIZATION ";
                            query += " where date_format(cast(Erdat as date),'%Y%m%d') ";
                            query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";

                            using (MySqlConnection sqlCon = new MySqlConnection(CS))
                            {
                                sqlCon.Open();
                                MySqlCommand Cmnd = new MySqlCommand(query, sqlCon);

                                int result = Cmnd.ExecuteNonQuery();

                                sqlCon.Close();
                            }


                            query = "";
                            query += " Select Count(*) Cnt from YREALIZATION ";
                            query += " where date_format(cast(Fkdat as date),'%Y%m%d') ";
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
                    //Import_Data imp = new Import_Data();
                    //imp.Insert_YREALIZATION(startDate.Trim(), endDate.Trim());
                    //Insert_YREALIZATION(startDate.Trim(), endDate.Trim());
                }

                if (InputID == "I" || InputID == "S")
                {
                    using (MySqlConnection con = new MySqlConnection(CS))
                    {
                        query = "";
                        query += " Select * from YREALIZATION ";
                        query += " where date_format(cast(ERDAT as date),'%Y%m%d') ";
                        query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";
                        query += " order by date_format(cast(Erdat as date),'%Y%m%d') ";
                        using (MySqlCommand cmd = new MySqlCommand(query))
                        {

                            cmd.Connection = con;
                            con.Open();
                            using (MySqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    lstsrvdeal.Add(new ZSD_REAL_DATA_SRV_REAL
                                    {
                                        Vbeln = Convert.ToString(sdr["Vbeln"]),
                                        Vgbel = Convert.ToString(sdr["Vgbel"]),
                                        Aubel = Convert.ToString(sdr["Aubel"]),
                                        Erdat = Convert.ToString(sdr["Erdat"]),
                                        Fkart = Convert.ToString(sdr["Fkart"]),
                                        Regio = Convert.ToString(sdr["Regio"]),
                                        Vkgrp = Convert.ToString(sdr["Vkgrp"]),
                                        Dstrc = Convert.ToString(sdr["Dstrc"]),
                                        Mnfplant = Convert.ToString(sdr["Mnfplant"]),
                                        Plant = Convert.ToString(sdr["Plant"]),
                                        Grade = Convert.ToString(sdr["Grade"]),
                                        Matkl = Convert.ToString(sdr["Matkl"]),
                                        Kalks = Convert.ToString(sdr["Kalks"]),
                                        Kdgrp = Convert.ToString(sdr["Kdgrp"]),
                                        Fkdat = Convert.ToString(sdr["Fkdat"]),
                                        Matnr = Convert.ToString(sdr["Matnr"]),
                                        Custcode1 = Convert.ToString(sdr["Custcode1"]),
                                        Cname1 = Convert.ToString(sdr["Cname1"]),
                                        Custcode2 = Convert.ToString(sdr["Custcode2"]),
                                        Cname2 = Convert.ToString(sdr["Cname2"]),
                                        Custcode3 = Convert.ToString(sdr["Custcode3"]),
                                        Cname3 = Convert.ToString(sdr["Cname3"]),
                                        ComAg = Convert.ToString(sdr["COM_AG"]),
                                        ComName = Convert.ToString(sdr["COM_NAME"]),
                                        Trans = Convert.ToString(sdr["Trans"]),
                                        TransName = Convert.ToString(sdr["TRANS_NAME"]),
                                        Lgort = Convert.ToString(sdr["Lgort"]),
                                        Lgobe = Convert.ToString(sdr["Lgobe"]),
                                        Fkimg = Convert.ToDecimal(sdr["Fkimg"]),
                                        Grossturn = Convert.ToDecimal(sdr["Grossturn"]),
                                        Inco1 = Convert.ToString(sdr["Inco1"]),
                                        Inco2 = Convert.ToString(sdr["Inco2"]),
                                        Stprs = Convert.ToDecimal(sdr["Stprs"]),
                                        Primaryfri = Convert.ToDecimal(sdr["Primaryfri"]),
                                        Secondaryfri = Convert.ToDecimal(sdr["Secondaryfri"]),
                                        Exwpf = Convert.ToDecimal(sdr["Exwpf"]),
                                        Exgsf = Convert.ToDecimal(sdr["Exgsf"]),
                                        Salestax = Convert.ToDecimal(sdr["Salestax"]),
                                        Commission = Convert.ToDecimal(sdr["Commission"]),
                                        Exciseduty = Convert.ToDecimal(sdr["Exciseduty"]),
                                        Pddiscount = Convert.ToDecimal(sdr["Pddiscount"]),
                                        Oddiscount = Convert.ToDecimal(sdr["Oddiscount"]),
                                        Cfcharges = Convert.ToDecimal(sdr["Cfcharges"]),
                                        Cddiscount = Convert.ToDecimal(sdr["Cddiscount"]),
                                        Packing = Convert.ToDecimal(sdr["Packing"]),
                                        Unloading = Convert.ToDecimal(sdr["Unloading"]),
                                        Octrai = Convert.ToDecimal(sdr["Octrai"]),
                                        Vat = Convert.ToDecimal(sdr["Vat"]),
                                        Igst = Convert.ToDecimal(sdr["Igst"]),
                                        Cgst = Convert.ToDecimal(sdr["Cgst"]),
                                        Sgst = Convert.ToDecimal(sdr["Sgst"]),
                                        Ugst = Convert.ToDecimal(sdr["Ugst"]),
                                        ExpHand = Convert.ToDecimal(sdr["EXP_HAND"]),
                                        Transport = Convert.ToDecimal(sdr["Transport"]),
                                        AmtDwFrt = Convert.ToDecimal(sdr["AMT_DW_FRT"]),
                                        PltFrt = Convert.ToDecimal(sdr["PLT_FRT"]),
                                        Netturn = Convert.ToDecimal(sdr["Netturn"]),
                                        Nakedreal = Convert.ToDecimal(sdr["Nakedreal"]),
                                        Statedesc = Convert.ToString(sdr["Statedesc"]),
                                        Sgrpdesc = Convert.ToString(sdr["Sgrpdesc"]),
                                        Disdesc = Convert.ToString(sdr["Disdesc"]),
                                        Graddesc = Convert.ToString(sdr["Graddesc"]),
                                        Mnfdesc = Convert.ToString(sdr["Mnfdesc"]),
                                        Plantdesc = Convert.ToString(sdr["Plantdesc"]),
                                        Pgrpdesc = Convert.ToString(sdr["Pgrpdesc"]),
                                        Cdate = Convert.ToString(sdr["Cdate"]),
                                        Time = Convert.ToString(sdr["Time"]),
                                        Suser = Convert.ToString(sdr["Suser"]),
                                        BlockCt = Convert.ToString(sdr["BLOCK_CT"]),
                                        Route = Convert.ToString(sdr["Route"]),
                                        Canceldate = Convert.ToString(sdr["Canceldate"]),
                                        Cancelflag = Convert.ToString(sdr["Cancelflag"]),
                                        Zzlgort1 = Convert.ToString(sdr["Zzlgort1"]),
                                        Bzirk = Convert.ToString(sdr["Bzirk"]),
                                        Vkbur = Convert.ToString(sdr["Vkbur"]),
                                        Zzzone1 = Convert.ToString(sdr["Zzzone1"]),
                                        Zzbranch = Convert.ToString(sdr["Zzbranch"]),
                                        PernrEr = Convert.ToString(sdr["PERNR_ER"]),
                                        EnameEr = Convert.ToString(sdr["ENAME_ER"]),
                                        PernrY1 = Convert.ToString(sdr["PERNR_Y1"]),
                                        EnameY1 = Convert.ToString(sdr["ENAME_Y1"]),
                                        PernrY2 = Convert.ToString(sdr["PERNR_Y2"]),
                                        EnameY2 = Convert.ToString(sdr["ENAME_Y2"]),
                                        PernrY3 = Convert.ToString(sdr["PERNR_Y3"]),
                                        EnameY3 = Convert.ToString(sdr["ENAME_Y3"]),
                                        PernrY4 = Convert.ToString(sdr["PERNR_Y4"]),
                                        EnameY4 = Convert.ToString(sdr["ENAME_Y4"]),
                                        PernrY5 = Convert.ToString(sdr["PERNR_Y5"]),
                                        EnameY5 = Convert.ToString(sdr["ENAME_Y5"]),
                                        PernrY6 = Convert.ToString(sdr["PERNR_Y6"]),
                                        EnameY6 = Convert.ToString(sdr["ENAME_Y6"]),
                                        PernrY7 = Convert.ToString(sdr["PERNR_Y7"]),
                                        EnameY7 = Convert.ToString(sdr["ENAME_Y7"]),
                                        PernrY8 = Convert.ToString(sdr["PERNR_Y8"]),
                                        EnameY8 = Convert.ToString(sdr["ENAME_Y8"]),
                                        UpfrntDiscount = Convert.ToDecimal(sdr["UPFRNT_DISCOUNT"]),
                                        IndPriFrt = Convert.ToDecimal(sdr["IND_PRI_FRT"]),
                                        ShipFrtChrgs = Convert.ToDecimal(sdr["SHIP_FRT_CHRGS"]),
                                        ShipHandChrgs = Convert.ToDecimal(sdr["SHIP_HAND_CHRGS"]),
                                        ZcustGrp = Convert.ToString(sdr["ZCUST_GRP"]),
                                        ZcustGrpDesc = Convert.ToString(sdr["ZCUST_GRP_DESC"]),
                                        Vc = Convert.ToDecimal(sdr["Vc"]),
                                        ZsalePromValue = Convert.ToDecimal(sdr["ZsalePromValue"]),
                                        Waers = Convert.ToString(sdr["Waers"]),
                                        Msehi = Convert.ToString(sdr["Msehi"]),
                                        PayFreight = Convert.ToDecimal(sdr["PayFreight"]),
                                        ExFreight = Convert.ToDecimal(sdr["ExFreight"]),
                                    });
                                }
                            }
                            con.Close();
                        }
                    }
                }

                if (InputID == "E")
                {
                    DataTable dt1 = new DataTable("YREALIZATION");
                    dt1.Columns.AddRange(new DataColumn[107]
                    {
                            new DataColumn("Billing Document"),
                            new DataColumn("Reference Document"),
                            new DataColumn("Sales Document"),
                            new DataColumn("Creation Date"),
                            new DataColumn("Billing Type"),
                            new DataColumn("State code"),
                            new DataColumn("Sales Group code"),
                            new DataColumn("District code"),
                            new DataColumn("Manfuacture Plant"),
                            new DataColumn("Plant"),
                            new DataColumn("Material Pricing Group"),
                            new DataColumn("Material Group"),
                            new DataColumn("Pricing procedure "),
                            new DataColumn("Customer group"),
                            new DataColumn("Billing Date "),
                            new DataColumn("Material Number"),
                            new DataColumn("Customer Code"),
                            new DataColumn("Customer Name"),
                            new DataColumn("Sales Rep code"),
                            new DataColumn("Sales Rep Name"),
                            new DataColumn("Consignee Code"),
                            new DataColumn("Consignee Name"),
                            new DataColumn("Commission Agent code"),
                            new DataColumn("Commission Agenet Name"),
                            new DataColumn("Transporter Code"),
                            new DataColumn("Transporter Name"),
                            new DataColumn("Storage Location"),
                            new DataColumn("Description of Storage Location"),
                            new DataColumn("Billed quantity"),
                            new DataColumn("Gross Turnover"),
                            new DataColumn("Incoterms1"),
                            new DataColumn("Incoterms2"),
                            new DataColumn("Standard price"),
                            new DataColumn("Primary Freight"),
                            new DataColumn("Secondary freight"),
                            new DataColumn("Ex-Works Primary Freight"),
                            new DataColumn("Ex-Works Secondary Freight"),
                            new DataColumn("Sales Tax"),
                            new DataColumn("Commission"),
                            new DataColumn("Excise Duty"),
                            new DataColumn("Price Discount"),
                            new DataColumn("Other Discount"),
                            new DataColumn("CFA charges"),
                            new DataColumn("Cash Discount"),
                            new DataColumn("Packing Charges"),
                            new DataColumn("Unloading Charges"),
                            new DataColumn("Octrai"),
                            new DataColumn("VAT"),
                            new DataColumn("IGST"),
                            new DataColumn("CGST"),
                            new DataColumn("SGST"),
                            new DataColumn("UGST"),
                            new DataColumn("Export Handling chgs"),
                            new DataColumn("Transport Incentive"),
                            new DataColumn("Demurrage Wharfage"),
                            new DataColumn("Plant freight"),
                            new DataColumn("Net Turnrover"),
                            new DataColumn("Realisation"),
                            new DataColumn("State Name"),
                            new DataColumn("Branch"),
                            new DataColumn("Distrct Name"),
                            new DataColumn("Grade"),
                            new DataColumn("Manfacture Plant name"),
                            new DataColumn("Plant Name"),
                            new DataColumn("Customer Group Name"),
                            new DataColumn("System Date"),
                            new DataColumn("System Time"),
                            new DataColumn("User Name"),
                            new DataColumn("Block Category"),
                            new DataColumn("Description of Route"),
                            new DataColumn("Date on Which Record Was Created"),
                            new DataColumn("Single-Character Flag"),
                            new DataColumn("Moving Storage loc "),
                            new DataColumn("Sales district"),
                            new DataColumn("Sales Office"),
                            new DataColumn("Transportation zone"),
                            new DataColumn("Branch Office"),
                            new DataColumn("Sales Officer Emp.No."),
                            new DataColumn("Sales Officer Emp.Name"),
                            new DataColumn("RM1"),
                            new DataColumn("RM1 Name"),
                            new DataColumn("RM2 "),
                            new DataColumn("RM2 Name"),
                            new DataColumn("RM3"),
                            new DataColumn("RM3 Name"),
                            new DataColumn("RM4"),
                            new DataColumn("RM4 Name"),
                            new DataColumn("RM5"),
                            new DataColumn("RM5 Name"),
                            new DataColumn("RM6"),
                            new DataColumn("RM6 Name"),
                            new DataColumn("RM7"),
                            new DataColumn("RM7 Name"),
                            new DataColumn("RM8"),
                            new DataColumn("RM8 Name"),
                            new DataColumn("Upfront Discount Amount"),
                            new DataColumn("Indirect Primary Freight"),
                            new DataColumn("Ship Freight"),
                            new DataColumn("Ship Handling Charges"),
                            new DataColumn("Customer group_1"),
                            new DataColumn("Customer Group Desc."),
                            new DataColumn("Varible Cost"),
                            new DataColumn("ZsalePromValue"),
                            new DataColumn("Waers"),
                            new DataColumn("Msehi"),
                            new DataColumn("PayFreight"),
                            new DataColumn("ExFreight")



                     });

                    using (MySqlConnection con = new MySqlConnection(CS))
                    {
                        query = "";
                        query += " Select * from YREALIZATION ";
                        query += " where date_format(cast(ERDAT as date),'%Y%m%d') ";
                        query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";
                        query += " order by date_format(cast(Erdat as date),'%Y%m%d') ";
                        using (MySqlCommand cmd = new MySqlCommand(query))
                        {

                            cmd.Connection = con;
                            con.Open();
                            using (MySqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    DataRow _dr = dt1.NewRow();


                                    _dr["Billing Document"] = Convert.ToString(sdr["VBELN"]);
                                    _dr["Reference Document"] = Convert.ToString(sdr["VGBEL"]);
                                    _dr["Sales Document"] = Convert.ToString(sdr["AUBEL"]);
                                    _dr["Creation Date"] = Convert.ToString(sdr["ERDAT"]);
                                    _dr["Billing Type"] = Convert.ToString(sdr["FKART"]);
                                    _dr["State code"] = Convert.ToString(sdr["REGIO"]);
                                    _dr["Sales Group code"] = Convert.ToString(sdr["VKGRP"]);
                                    _dr["District code"] = Convert.ToString(sdr["DSTRC"]);
                                    _dr["Manfuacture Plant"] = Convert.ToString(sdr["MNFPLANT"]);
                                    _dr["Plant"] = Convert.ToString(sdr["PLANT"]);
                                    _dr["Material Pricing Group"] = Convert.ToString(sdr["GRADE"]);
                                    _dr["Material Group"] = Convert.ToString(sdr["MATKL"]);
                                    _dr["Pricing procedure "] = Convert.ToString(sdr["KALKS"]);
                                    _dr["Customer group"] = Convert.ToString(sdr["KDGRP"]);
                                    _dr["Billing Date "] = Convert.ToString(sdr["FKDAT"]);
                                    _dr["Material Number"] = Convert.ToString(sdr["MATNR"]);
                                    _dr["Customer Code"] = Convert.ToString(sdr["CUSTCODE1"]);
                                    _dr["Customer Name"] = Convert.ToString(sdr["CNAME1"]);
                                    _dr["Sales Rep code"] = Convert.ToString(sdr["CUSTCODE2"]);
                                    _dr["Sales Rep Name"] = Convert.ToString(sdr["CNAME2"]);
                                    _dr["Consignee Code"] = Convert.ToString(sdr["CUSTCODE3"]);
                                    _dr["Consignee Name"] = Convert.ToString(sdr["CNAME3"]);
                                    _dr["Commission Agent code"] = Convert.ToString(sdr["COM_AG"]);
                                    _dr["Commission Agenet Name"] = Convert.ToString(sdr["COM_NAME"]);
                                    _dr["Transporter Code"] = Convert.ToString(sdr["TRANS"]);
                                    _dr["Transporter Name"] = Convert.ToString(sdr["TRANS_NAME"]);
                                    _dr["Storage Location"] = Convert.ToString(sdr["LGORT"]);
                                    _dr["Description of Storage Location"] = Convert.ToString(sdr["LGOBE"]);
                                    _dr["Billed quantity"] = Convert.ToDecimal(sdr["FKIMG"]);
                                    _dr["Gross Turnover"] = Convert.ToDecimal(sdr["GROSSTURN"]);
                                    _dr["Incoterms1"] = Convert.ToString(sdr["INCO1"]);
                                    _dr["Incoterms2"] = Convert.ToString(sdr["INCO2"]);
                                    _dr["Standard price"] = Convert.ToDecimal(sdr["STPRS"]);
                                    _dr["Primary Freight"] = Convert.ToDecimal(sdr["PRIMARYFRI"]);
                                    _dr["Secondary freight"] = Convert.ToDecimal(sdr["SECONDARYFRI"]);
                                    _dr["Ex-Works Primary Freight"] = Convert.ToDecimal(sdr["EXWPF"]);
                                    _dr["Ex-Works Secondary Freight"] = Convert.ToDecimal(sdr["EXGSF"]);
                                    _dr["Sales Tax"] = Convert.ToDecimal(sdr["SALESTAX"]);
                                    _dr["Commission"] = Convert.ToDecimal(sdr["COMMISSION"]);
                                    _dr["Excise Duty"] = Convert.ToDecimal(sdr["EXCISEDUTY"]);
                                    _dr["Price Discount"] = Convert.ToDecimal(sdr["PDDISCOUNT"]);
                                    _dr["Other Discount"] = Convert.ToDecimal(sdr["ODDISCOUNT"]);
                                    _dr["CFA charges"] = Convert.ToDecimal(sdr["CFCHARGES"]);
                                    _dr["Cash Discount"] = Convert.ToDecimal(sdr["CDDISCOUNT"]);
                                    _dr["Packing Charges"] = Convert.ToDecimal(sdr["PACKING"]);
                                    _dr["Unloading Charges"] = Convert.ToDecimal(sdr["UNLOADING"]);
                                    _dr["Octrai"] = Convert.ToDecimal(sdr["OCTRAI"]);
                                    _dr["VAT"] = Convert.ToDecimal(sdr["VAT"]);
                                    _dr["IGST"] = Convert.ToDecimal(sdr["IGST"]);
                                    _dr["CGST"] = Convert.ToDecimal(sdr["CGST"]);
                                    _dr["SGST"] = Convert.ToDecimal(sdr["SGST"]);
                                    _dr["UGST"] = Convert.ToDecimal(sdr["UGST"]);
                                    _dr["Export Handling chgs"] = Convert.ToDecimal(sdr["EXP_HAND"]);
                                    _dr["Transport Incentive"] = Convert.ToDecimal(sdr["TRANSPORT"]);
                                    _dr["Demurrage Wharfage"] = Convert.ToDecimal(sdr["AMT_DW_FRT"]);
                                    _dr["Plant freight"] = Convert.ToDecimal(sdr["PLT_FRT"]);
                                    _dr["Net Turnrover"] = Convert.ToDecimal(sdr["NETTURN"]);
                                    _dr["Realisation"] = Convert.ToDecimal(sdr["NAKEDREAL"]);
                                    _dr["State Name"] = Convert.ToString(sdr["STATEDESC"]);
                                    _dr["Branch"] = Convert.ToString(sdr["SGRPDESC"]);
                                    _dr["Distrct Name"] = Convert.ToString(sdr["DISDESC"]);
                                    _dr["Grade"] = Convert.ToString(sdr["GRADDESC"]);
                                    _dr["Manfacture Plant name"] = Convert.ToString(sdr["MNFDESC"]);
                                    _dr["Plant Name"] = Convert.ToString(sdr["PLANTDESC"]);
                                    _dr["Customer Group Name"] = Convert.ToString(sdr["PGRPDESC"]);
                                    _dr["System Date"] = Convert.ToString(sdr["CDATE"]);
                                    _dr["System Time"] = Convert.ToString(sdr["TIME"]);
                                    _dr["User Name"] = Convert.ToString(sdr["SUSER"]);
                                    _dr["Block Category"] = Convert.ToString(sdr["BLOCK_CT"]);
                                    _dr["Description of Route"] = Convert.ToString(sdr["ROUTE"]);
                                    _dr["Date on Which Record Was Created"] = Convert.ToString(sdr["CANCELDATE"]);
                                    _dr["Single-Character Flag"] = Convert.ToString(sdr["CANCELFLAG"]);
                                    _dr["Moving Storage loc "] = Convert.ToString(sdr["ZZLGORT1"]);
                                    _dr["Sales district"] = Convert.ToString(sdr["BZIRK"]);
                                    _dr["Sales Office"] = Convert.ToString(sdr["VKBUR"]);
                                    _dr["Transportation zone"] = Convert.ToString(sdr["ZZZONE1"]);
                                    _dr["Branch Office"] = Convert.ToString(sdr["ZZBRANCH"]);
                                    _dr["Sales Officer Emp.No."] = Convert.ToString(sdr["PERNR_ER"]);
                                    _dr["Sales Officer Emp.Name"] = Convert.ToString(sdr["ENAME_ER"]);
                                    _dr["RM1"] = Convert.ToString(sdr["PERNR_Y1"]);
                                    _dr["RM1 Name"] = Convert.ToString(sdr["ENAME_Y1"]);
                                    _dr["RM2 "] = Convert.ToString(sdr["PERNR_Y2"]);
                                    _dr["RM2 Name"] = Convert.ToString(sdr["ENAME_Y2"]);
                                    _dr["RM3"] = Convert.ToString(sdr["PERNR_Y3"]);
                                    _dr["RM3 Name"] = Convert.ToString(sdr["ENAME_Y3"]);
                                    _dr["RM4"] = Convert.ToString(sdr["PERNR_Y4"]);
                                    _dr["RM4 Name"] = Convert.ToString(sdr["ENAME_Y4"]);
                                    _dr["RM5"] = Convert.ToString(sdr["PERNR_Y5"]);
                                    _dr["RM5 Name"] = Convert.ToString(sdr["ENAME_Y5"]);
                                    _dr["RM6"] = Convert.ToString(sdr["PERNR_Y6"]);
                                    _dr["RM6 Name"] = Convert.ToString(sdr["ENAME_Y6"]);
                                    _dr["RM7"] = Convert.ToString(sdr["PERNR_Y7"]);
                                    _dr["RM7 Name"] = Convert.ToString(sdr["ENAME_Y7"]);
                                    _dr["RM8"] = Convert.ToString(sdr["PERNR_Y8"]);
                                    _dr["RM8 Name"] = Convert.ToString(sdr["ENAME_Y8"]);
                                    _dr["Upfront Discount Amount"] = Convert.ToDecimal(sdr["UPFRNT_DISCOUNT"]);
                                    _dr["Indirect Primary Freight"] = Convert.ToDecimal(sdr["IND_PRI_FRT"]);
                                    _dr["Ship Freight"] = Convert.ToDecimal(sdr["SHIP_FRT_CHRGS"]);
                                    _dr["Ship Handling Charges"] = Convert.ToDecimal(sdr["SHIP_HAND_CHRGS"]);
                                    _dr["Customer group_1"] = Convert.ToString(sdr["ZCUST_GRP"]);
                                    _dr["Customer Group Desc."] = Convert.ToString(sdr["ZCUST_GRP_DESC"]);
                                    _dr["Varible Cost"] = Convert.ToDecimal(sdr["VC"]);
                                    _dr["ZsalePromValue"] = Convert.ToDecimal(sdr["ZsalePromValue"]);
                                    _dr["Waers"] = Convert.ToString(sdr["Waers"]);
                                    _dr["Msehi"] = Convert.ToString(sdr["Msehi"]);
                                    _dr["PayFreight"] = Convert.ToDecimal(sdr["PayFreight"]);
                                    _dr["ExFreight"] = Convert.ToDecimal(sdr["ExFreight"]);


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
                            ViewBag.export = "success";
                            wb.SaveAs(stream);
                            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "yrealization.xlsx");
                        }
                    }
                }
                //if (InputID == "I")
                //{
                //    log1.WriteLine("===========================================");
                //    log1.Close();

                //}
                //Maxid = 19;
                int pageSize;
                if (System.Configuration.ConfigurationManager.AppSettings["PageSize"] == null)
                {
                    pageSize = 10;
                }
                else
                {
                    pageSize = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["PageSize"].ToString());
                }
                int page1=1;
                int pageNumber = (page ?? 1);
                if (page1 != 0)
                {

                    pageNumber = Convert.ToInt16(page1);
                }

                ViewData["videoList"] = lstsrvdeal.ToPagedList(pageNumber, pageSize);
                return View(lstsrvdeal);
                //List<ZSD_REAL_DATA_SRV_REAL> results = new List<ZSD_REAL_DATA_SRV_REAL>();
                //results = lstsrvdeal;
                //return Json(new { errorcode = 1, errormessage = 1, Data = results }, JsonRequestBehavior.AllowGet);

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
                log1.WriteLine("YREALIZATION Error Message : " + ex.Message);
                log1.WriteLine("===========================================");
                log1.Close();
                return View();

            }


        }





        //[HttpPost]
        public ActionResult Export(string sdate, string edate)
        {
            List<ZSD_REAL_DATA_SRV_REAL> lstsrvdeal = new List<ZSD_REAL_DATA_SRV_REAL>();
            return View(lstsrvdeal);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult LogiCost(string startDate, string endDate, string InputID, int? page, int? page1)
        {
            string filename = System.Configuration.ConfigurationManager.AppSettings["LogFile"].ToString();


            //connection_open = false;

            //connection = new MyMySqlConnection();
            ////connection = DB_Connect.Make_Connnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString);
            //connection.ConnectionString = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;

            //string CS = connection.ConnectionString;
            ////            if (db_manage_connnection.DB_Connect.OpenTheConnection(connection))
            //if (Open_Local_Connection())
            //{
            //    connection_open = true;
            //}
            //else
            //{
            //    //					MessageBox::Show("No database connection connection made...\n Exiting now", "Database Connection Error");
            //    //					 Application::Exit();

            //}
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
        //    ViewData["Category"] = mySkills;


            int Maxid = 0;
            List<ZSD_LCOST_DATA_SRV> lstsrvdeal = new List<ZSD_LCOST_DATA_SRV>();
            using (MySqlConnection con = new MySqlConnection(CS))
            {
                using (MySqlCommand cmd = new MySqlCommand("Select * from ZSD_LCOST_DATA_SRV where  ZSD_LCOST_DATA_SRV_PKID = " + Maxid))
                {

                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            lstsrvdeal.Add(new ZSD_LCOST_DATA_SRV
                            {
                                Vbeln = Convert.ToString(sdr["Vbeln"]),
                                Fkart = Convert.ToString(sdr["Fkart"]),
                                Fkdat = Convert.ToString(sdr["Fkdat"]),
                                Fkimg = Convert.ToDecimal(sdr["Fkimg"]),
                                Meins = Convert.ToString(sdr["Meins"]),
                                Werks = Convert.ToString(sdr["Werks"]),
                                WName1 = Convert.ToString(sdr["WName1"]),
                                Zsource = Convert.ToString(sdr["Zsource"]),
                                Zsourced = Convert.ToString(sdr["Zsourced"]),
                                Ztratyp = Convert.ToString(sdr["Ztratyp"]),
                                Ztratypd = Convert.ToString(sdr["Ztratypd"]),
                                Kunnr = Convert.ToString(sdr["Kunnr"]),
                                KunnrN = Convert.ToString(sdr["KunnrN"]),
                                Kunag = Convert.ToString(sdr["Kunag"]),
                                KunagN = Convert.ToString(sdr["KunagN"]),
                                Ptnr = Convert.ToString(sdr["Ptnr"]),
                                PtnrN = Convert.ToString(sdr["PtnrN"]),
                                Salsrep = Convert.ToString(sdr["Salsrep"]),
                                SalsrepN = Convert.ToString(sdr["SalsrepN"]),
                                Regio = Convert.ToString(sdr["Regio"]),
                                RegioN = Convert.ToString(sdr["RegioN"]),
                                Dstrc = Convert.ToString(sdr["Dstrc"]),
                                DstrcN = Convert.ToString(sdr["DstrcN"]),
                                Block = Convert.ToString(sdr["Block"]),
                                BlockN = Convert.ToString(sdr["BlockN"]),
                                Destint = Convert.ToString(sdr["Destint"]),
                                DestintN = Convert.ToString(sdr["DestintN"]),
                                Kdgrp = Convert.ToString(sdr["Kdgrp"]),
                                Ktext = Convert.ToString(sdr["Ktext"]),
                                PrimaryFrt = Convert.ToDecimal(sdr["PrimaryFrt"]),
                                SecondryFrt = Convert.ToDecimal(sdr["SecondryFrt"]),
                                Rakno = Convert.ToString(sdr["Rakno"]),
                                Rakpt = Convert.ToString(sdr["Rakpt"]),
                                Matkl = Convert.ToString(sdr["Matkl"]),
                                Lgort = Convert.ToString(sdr["Lgort"]),
                                Lgobe = Convert.ToString(sdr["Lgobe"]),
                                Inco1 = Convert.ToString(sdr["Inco1"]),
                                Inco2 = Convert.ToString(sdr["Inco2"]),
                                UldgChgs = Convert.ToDecimal(sdr["UldgChgs"]),
                                TrnsChgs = Convert.ToDecimal(sdr["TrnsChgs"]),
                                DpulChgs = Convert.ToDecimal(sdr["DpulChgs"]),
                                DpldChgs = Convert.ToDecimal(sdr["DpldChgs"]),
                                DivrChgs = Convert.ToDecimal(sdr["DivrChgs"]),
                                LdngChgs = Convert.ToDecimal(sdr["LdngChgs"]),
                                CfagChgs = Convert.ToDecimal(sdr["CfagChgs"]),
                                RksrChgs = Convert.ToDecimal(sdr["RksrChgs"]),
                                PuldChgs = Convert.ToDecimal(sdr["PuldChgs"]),
                                RkclChgs = Convert.ToDecimal(sdr["RkclChgs"]),
                                ShntChgs = Convert.ToDecimal(sdr["ShntChgs"]),
                                RkcfChgs = Convert.ToDecimal(sdr["RkcfChgs"]),
                                BlndChgs = Convert.ToDecimal(sdr["BlndChgs"]),
                                BlnbChgs = Convert.ToDecimal(sdr["BlnbChgs"]),
                                MiscMisc = Convert.ToDecimal(sdr["MiscMisc"]),
                                Zzzone1 = Convert.ToString(sdr["Zzzone1"]),
                                Zzzone1N = Convert.ToString(sdr["Zzzone1N"]),
                                Zzbzirk = Convert.ToString(sdr["Zzbzirk"]),
                                ZzbzirkN = Convert.ToString(sdr["ZzbzirkN"]),
                                Zzregio = Convert.ToString(sdr["Zzregio"]),
                                ZzregioN = Convert.ToString(sdr["ZzregioN"]),
                                Vkbur = Convert.ToString(sdr["Vkbur"]),
                                VkburN = Convert.ToString(sdr["VkburN"]),
                                Vkgrp = Convert.ToString(sdr["Vkgrp"]),
                                VkgrpN = Convert.ToString(sdr["VkgrpN"]),
                                Zzbranch = Convert.ToString(sdr["Zzbranch"]),
                                ZzbranchN = Convert.ToString(sdr["ZzbranchN"]),
                                Pdstn = Convert.ToDecimal(sdr["Pdstn"]),
                                Sdstn = Convert.ToDecimal(sdr["Sdstn"]),
                                BlockCt = Convert.ToString(sdr["BlockCt"]),
                                Belnr = Convert.ToString(sdr["Belnr"]),
                                Gjahr = Convert.ToString(sdr["Gjahr"]),
                                InvType = Convert.ToString(sdr["InvType"]),
                                FrtType = Convert.ToString(sdr["FrtType"]),
                                Zzvlfkz = Convert.ToString(sdr["Zzvlfkz"]),
                                SuppPlantName = Convert.ToString(sdr["SuppPlantName"]),
                                DepoRkMvt = Convert.ToString(sdr["DepoRkMvt"]),
                                IndPriFrt = Convert.ToDecimal(sdr["IndPriFrt"]),
                                ShipFrtChrgs = Convert.ToDecimal(sdr["ShipFrtChrgs"]),
                                ShipHandChrgs = Convert.ToDecimal(sdr["ShipHandChrgs"]),
                                Clkmnfplant = Convert.ToString(sdr["Clkmnfplant"]),
                                Suppplant = Convert.ToString(sdr["Suppplant"]),
                                Distance = Convert.ToDecimal(sdr["Distance"]),
                                Indpdistance = Convert.ToDecimal(sdr["Indpdistance"]),
                                ClkPltName = Convert.ToString(sdr["ClkPltName"]),
                                MnfPltName = Convert.ToString(sdr["MnfPltName"]),
                                GeindPlt = Convert.ToString(sdr["GeindPlt"]),
                                GeindPltName = Convert.ToString(sdr["GeindPltName"]),
                                SupplDepo = Convert.ToString(sdr["SupplDepo"]),
                                SupplDepoName = Convert.ToString(sdr["SupplDepoName"]),
                                Waerk = Convert.ToString(sdr["Waerk"]),
                                Rent = Convert.ToDecimal(sdr["Rent"]),
                                Rakedemchrg = Convert.ToDecimal(sdr["Rakedemchrg"]),
                                Ldistance = Convert.ToDecimal(sdr["Ldistance"]),
                                LdistanceClk = Convert.ToDecimal(sdr["LdistanceClk"]),
                                Matnr = Convert.ToString(sdr["Matnr"]),
                                Vtext = Convert.ToString(sdr["Vtext"]),
                                Matnr1 = Convert.ToString(sdr["Matnr1"]),
                                Maktx = Convert.ToString(sdr["Maktx"]),
                                Incurredcost = Convert.ToDecimal(sdr["Incurredcost"]),
                                Unincurredcost = Convert.ToDecimal(sdr["Unincurredcost"]),
                                ShRegio = Convert.ToString(sdr["ShRegio"]),
                                ShDstrc = Convert.ToString(sdr["ShDstrc"]),
                                ShBlock = Convert.ToString(sdr["ShBlock"]),
                                ShDestint = Convert.ToString(sdr["ShDestint"]),
                                Kalks = Convert.ToString(sdr["Kalks"]),
                                DeliveryNo = Convert.ToString(sdr["DeliveryNo"]),
                                Tknum = Convert.ToString(sdr["Tknum"]),
                                Mnfplant = Convert.ToString(sdr["Mnfplant"]),
                                Mnfdesc = Convert.ToString(sdr["Mnfdesc"]),
                                Mvgr1 = Convert.ToString(sdr["Mvgr1"]),
                                Grossturn = Convert.ToDecimal(sdr["Grossturn"]),
                                Netturn = Convert.ToDecimal(sdr["Netturn"]),
                                Nakedreal = Convert.ToDecimal(sdr["Nakedreal"]),
                                TransIncentive = Convert.ToDecimal(sdr["TransIncentive"]),
                                PltFrt = Convert.ToDecimal(sdr["PltFrt"]),
                                SpRegio = Convert.ToString(sdr["SpRegio"]),
                                SpDstrc = Convert.ToString(sdr["SpDstrc"]),
                                SpBlock = Convert.ToString(sdr["SpBlock"]),
                                SpDestint = Convert.ToString(sdr["SpDestint"]),
                                Traid = Convert.ToString(sdr["Traid"]),
                                TruckType = Convert.ToString(sdr["TruckType"]),
                                EwbNo = Convert.ToString(sdr["EwbNo"]),
                                Edate = Convert.ToString(sdr["Edate"]),
                                Evdate = Convert.ToString(sdr["Evdate"]),
                                Steuc = Convert.ToString(sdr["Steuc"]),
                                PaidPrice = Convert.ToDecimal(sdr["PaidPrice"]),
                                KalksDesc = Convert.ToString(sdr["KalksDesc"]),
                                SpRegioDesc = Convert.ToString(sdr["SpRegioDesc"]),
                                SpDstrcDesc = Convert.ToString(sdr["SpDstrcDesc"]),
                                SpBlockDesc = Convert.ToString(sdr["SpBlockDesc"]),
                                SpDestintDesc = Convert.ToString(sdr["SpDestintDesc"]),
                                MfPlantType = Convert.ToString(sdr["MfPlantType"]),
                                TotalTdcCost = Convert.ToDecimal(sdr["TotalTdcCost"]),
                                TotalDistance = Convert.ToDecimal(sdr["TotalDistance"]),
                                DepotIndFrieght = Convert.ToDecimal(sdr["DepotIndFrieght"]),
                                TotalInvoiceFrt = Convert.ToDecimal(sdr["TotalInvoiceFrt"]),
                                RoadPfIncurred = Convert.ToDecimal(sdr["RoadPfIncurred"]),
                                RoadPfUnincurred = Convert.ToDecimal(sdr["RoadPfUnincurred"]),
                                RoadSfIncurred = Convert.ToDecimal(sdr["RoadSfIncurred"]),
                                RoadSfUnincurred = Convert.ToDecimal(sdr["RoadSfUnincurred"]),
                                RailPfIncurred = Convert.ToDecimal(sdr["RailPfIncurred"]),
                                RailPfUnincurred = Convert.ToDecimal(sdr["RailPfUnincurred"]),
                                DrdlChgs = Convert.ToDecimal(sdr["DrdlChgs"]),
                                DbLabChgs = Convert.ToDecimal(sdr["DbLabChgs"]),
                                ZinvCancel = Convert.ToString(sdr["ZinvCancel"]),
                                ShDestintDesc = Convert.ToString(sdr["ShDestintDesc"]),
                                ShipDistance = Convert.ToDecimal(sdr["ShipDistance"]),

                            });
                        }
                    }
                    con.Close();
                }
            }
            if (InputID == "E")
            {
                DataTable dt1 = new DataTable("ZSD_LCOST_DATA_SRV");
                dt1.Columns.AddRange(new DataColumn[146]
                {
                        new DataColumn("Billing Document"),
                        new DataColumn("Billing Type"),
                        new DataColumn("Billing Date"),
                        new DataColumn("Billed quantity"),
                        new DataColumn("Base Unit of Measure"),
                        new DataColumn("Plant"),
                        new DataColumn("Plant Description"),
                        new DataColumn("Source"),
                        new DataColumn("Source Description"),
                        new DataColumn("Movement Type"),
                        new DataColumn("Movement Description"),
                        new DataColumn("Ship-To Party"),
                        new DataColumn("Ship to party Name"),
                        new DataColumn("Sold-To Party"),
                        new DataColumn("Sold-To Party Name"),
                        new DataColumn("Transporter ID"),
                        new DataColumn("Transporter ID Name "),
                        new DataColumn("Sales Rep code"),
                        new DataColumn("Sales Rep Name 1"),
                        new DataColumn("State"),
                        new DataColumn("State Description"),
                        new DataColumn("District"),
                        new DataColumn("District Description"),
                        new DataColumn("Block"),
                        new DataColumn("Block Description"),
                        new DataColumn("Destination"),
                        new DataColumn("Destination Description"),
                        new DataColumn("Customer group Code"),
                        new DataColumn("Customer group Name"),
                        new DataColumn("Primary Frieght"),
                        new DataColumn("Secondary Frieght"),
                        new DataColumn("Rake No"),
                        new DataColumn("Rake Point"),
                        new DataColumn("Material Group"),
                        new DataColumn("Storage Location"),
                        new DataColumn("Storage Location Description"),
                        new DataColumn("Incoterms1"),
                        new DataColumn("Incoterms 2"),
                        new DataColumn("Unloading Charges"),
                        new DataColumn("Transshipment Charges"),
                        new DataColumn("Depot Unloading charges"),
                        new DataColumn("Depot Loading charges"),
                        new DataColumn("BLK CFA Charges"),
                        new DataColumn("Loading Charges"),
                        new DataColumn("C&F Agent Service Charges"),
                        new DataColumn("Railway Service Charge"),
                        new DataColumn("Party side Unloading Charges"),
                        new DataColumn("Rake Clearing Charges"),
                        new DataColumn("Shunting Charges"),
                        new DataColumn("Rake CFA Charges"),
                        new DataColumn("Blended A Charges"),
                        new DataColumn("Blended B Charges"),
                        new DataColumn("Misc Charges"),
                        new DataColumn("Transportation zone "),
                        new DataColumn("Transportation zone description"),
                        new DataColumn("Sales District"),
                        new DataColumn("Sales District Description"),
                        new DataColumn("Region code"),
                        new DataColumn("Region Description"),
                        new DataColumn("Sales Office"),
                        new DataColumn("Sales Office Description"),
                        new DataColumn("Sales Group"),
                        new DataColumn("Sales Group Description"),
                        new DataColumn("Branch Office"),
                        new DataColumn("Branch Office Description"),
                        new DataColumn("Primary Distance"),
                        new DataColumn("Secondary Distance"),
                        new DataColumn("Block Category"),
                        new DataColumn("Accounting Document Number"),
                        new DataColumn("Fiscal Year"),
                        new DataColumn("Invoice Type"),
                        new DataColumn("Freight Type"),
                        new DataColumn("Plant category"),
                        new DataColumn("Supplying Plant Name"),
                        new DataColumn("Depot Rake movement"),
                        new DataColumn("Indirect Primary Frieght"),
                        new DataColumn("Ship Frieght"),
                        new DataColumn("Ship Handling Charges"),
                        new DataColumn("Clinker Plant"),
                        new DataColumn("Supplying Plant"),
                        new DataColumn("Clinker Distance"),
                        new DataColumn("Indirect Primary Distance"),
                        new DataColumn("Clinker Plant name "),
                        new DataColumn("Manufacturing Plant Name"),
                        new DataColumn("Grinding unit plant code"),
                        new DataColumn("Grinding unit plant Name"),
                        new DataColumn("Supplying Depot"),
                        new DataColumn("Supplying Depot Name"),
                        new DataColumn("SD Document Currency"),
                        new DataColumn("Rent Per MT"),
                        new DataColumn("Rake Demurage Charges"),
                        new DataColumn("Lead Distance Without Clinkcer KM"),
                        new DataColumn("Lead Distance With Clinkcer KM"),
                        new DataColumn("Material Code"),
                        new DataColumn("Material Description"),
                        new DataColumn("Empty bags Material Code"),
                        new DataColumn("Empty bags Material Description"),
                        new DataColumn("Incurred Cost"),
                        new DataColumn("Unincurred Cost"),
                        new DataColumn("Ship to party Region"),
                        new DataColumn("Ship to party District"),
                        new DataColumn("Ship to party Block"),
                        new DataColumn("Ship to partyDestination"),
                        new DataColumn("Pricing procedure"),
                        new DataColumn("Delivery"),
                        new DataColumn("Shipment Number"),
                        new DataColumn("Manufacturing Plant"),
                        new DataColumn("Manufacturing Plant Description"),
                        new DataColumn("Material group_1"),
                        new DataColumn("Gross Turnover"),
                        new DataColumn("Net Turnover"),
                        new DataColumn("Net Value in Document Currency"),
                        new DataColumn("Transport Incentive"),
                        new DataColumn("Net Value in Document Currency_1"),
                        new DataColumn("Sold to Party Region"),
                        new DataColumn("Sold to Party District"),
                        new DataColumn("Sold to Party Block"),
                        new DataColumn("Sold to Party Destination"),
                        new DataColumn("Means of Transport ID"),
                        new DataColumn("Truck Type"),
                        new DataColumn("E-Waybill Number"),
                        new DataColumn("E-Waybill date"),
                        new DataColumn("E-WayBill Valid Till Date"),
                        new DataColumn("HSN Code"),
                        new DataColumn("Paid Price"),
                        new DataColumn("Description"),
                        new DataColumn("Sold to Party Region Description"),
                        new DataColumn("Sold to Party District Description"),
                        new DataColumn("Sold to Party Block Description"),
                        new DataColumn("Sold to Party Destination Description"),
                        new DataColumn("Manufacturing Plant Type"),
                        new DataColumn("TDC Cost"),
                        new DataColumn("Total Distance"),
                        new DataColumn("Depot In-direct primary frieght"),
                        new DataColumn("Total Invoice Frieght"),
                        new DataColumn("Road Primary frieght Incurred"),
                        new DataColumn("Road Primary frieght unIncurred"),
                        new DataColumn("Road Secondary frieght Incurred"),
                        new DataColumn("Road Secondary frieght unIncurred"),
                        new DataColumn("Rail Primary Frieght Incurred"),
                        new DataColumn("Rail Primary Frieght unIncurred"),
                        new DataColumn("Direct Delivery charges"),
                        new DataColumn("Double Labour Charges"),
                        new DataColumn("Invoice cancellation flag"),
                        new DataColumn("Ship to party Destination Description"),
                        new DataColumn("Ship Distance")


                 });

                using (MySqlConnection con = new MySqlConnection(CS))
                {
                    string query = " Select * from ZSD_LCOST_DATA_SRV ";
                    query += " where date_format(cast(Fkdat as date),'%Y%m%d') ";
                    query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";
                    query += " order by date_format(cast(Fkdat as date),'%Y%m%d') ";
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {

                        cmd.Connection = con;
                        con.Open();
                        using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                DataRow _dr = dt1.NewRow();


                                _dr["Billing Document"] = Convert.ToString(sdr["VBELN"]);
                                _dr["Billing Type"] = Convert.ToString(sdr["FKART"]);
                                _dr["Billing Date"] = Convert.ToString(sdr["FKDAT"]);
                                _dr["Billed quantity"] = Convert.ToDecimal(sdr["FKIMG"]);
                                _dr["Base Unit of Measure"] = Convert.ToString(sdr["MEINS"]);
                                _dr["Plant"] = Convert.ToString(sdr["WERKS"]);
                                _dr["Plant Description"] = Convert.ToString(sdr["W_NAME1"]);
                                _dr["Source"] = Convert.ToString(sdr["ZSOURCE"]);
                                _dr["Source Description"] = Convert.ToString(sdr["ZSOURCED"]);
                                _dr["Movement Type"] = Convert.ToString(sdr["ZTRATYP"]);
                                _dr["Movement Description"] = Convert.ToString(sdr["ZTRATYPD"]);
                                _dr["Ship-To Party"] = Convert.ToString(sdr["KUNNR"]);
                                _dr["Ship to party Name"] = Convert.ToString(sdr["KUNNR_N"]);
                                _dr["Sold-To Party"] = Convert.ToString(sdr["KUNAG"]);
                                _dr["Sold-To Party Name"] = Convert.ToString(sdr["KUNAG_N"]);
                                _dr["Transporter ID"] = Convert.ToString(sdr["PTNR"]);
                                _dr["Transporter ID Name "] = Convert.ToString(sdr["PTNR_N"]);
                                _dr["Sales Rep code"] = Convert.ToString(sdr["SALSREP"]);
                                _dr["Sales Rep Name 1"] = Convert.ToString(sdr["SALSREP_N"]);
                                _dr["State"] = Convert.ToString(sdr["REGIO"]);
                                _dr["State Description"] = Convert.ToString(sdr["REGIO_N"]);
                                _dr["District"] = Convert.ToString(sdr["DSTRC"]);
                                _dr["District Description"] = Convert.ToString(sdr["DSTRC_N"]);
                                _dr["Block"] = Convert.ToString(sdr["BLOCK"]);
                                _dr["Block Description"] = Convert.ToString(sdr["BLOCK_N"]);
                                _dr["Destination"] = Convert.ToString(sdr["DESTINT"]);
                                _dr["Destination Description"] = Convert.ToString(sdr["DESTINT_N"]);
                                _dr["Customer group Code"] = Convert.ToString(sdr["KDGRP"]);
                                _dr["Customer group Name"] = Convert.ToString(sdr["KTEXT"]);
                                _dr["Primary Frieght"] = Convert.ToDecimal(sdr["PRIMARY_FRT"]);
                                _dr["Secondary Frieght"] = Convert.ToDecimal(sdr["SECONDRY_FRT"]);
                                _dr["Rake No"] = Convert.ToString(sdr["RAKNO"]);
                                _dr["Rake Point"] = Convert.ToString(sdr["RAKPT"]);
                                _dr["Material Group"] = Convert.ToString(sdr["MATKL"]);
                                _dr["Storage Location"] = Convert.ToString(sdr["LGORT"]);
                                _dr["Storage Location Description"] = Convert.ToString(sdr["LGOBE"]);
                                _dr["Incoterms1"] = Convert.ToString(sdr["INCO1"]);
                                _dr["Incoterms 2"] = Convert.ToString(sdr["INCO2"]);
                                _dr["Unloading Charges"] = Convert.ToDecimal(sdr["ULDG_CHGS"]);
                                _dr["Transshipment Charges"] = Convert.ToDecimal(sdr["TRNS_CHGS"]);
                                _dr["Depot Unloading charges"] = Convert.ToDecimal(sdr["DPUL_CHGS"]);
                                _dr["Depot Loading charges"] = Convert.ToDecimal(sdr["DPLD_CHGS"]);
                                _dr["BLK CFA Charges"] = Convert.ToDecimal(sdr["DIVR_CHGS"]);
                                _dr["Loading Charges"] = Convert.ToDecimal(sdr["LDNG_CHGS"]);
                                _dr["C&F Agent Service Charges"] = Convert.ToDecimal(sdr["CFAG_CHGS"]);
                                _dr["Railway Service Charge"] = Convert.ToDecimal(sdr["RKSR_CHGS"]);
                                _dr["Party side Unloading Charges"] = Convert.ToDecimal(sdr["PULD_CHGS"]);
                                _dr["Rake Clearing Charges"] = Convert.ToDecimal(sdr["RKCL_CHGS"]);
                                _dr["Shunting Charges"] = Convert.ToDecimal(sdr["SHNT_CHGS"]);
                                _dr["Rake CFA Charges"] = Convert.ToDecimal(sdr["RKCF_CHGS"]);
                                _dr["Blended A Charges"] = Convert.ToDecimal(sdr["BLND_CHGS"]);
                                _dr["Blended B Charges"] = Convert.ToDecimal(sdr["BLNB_CHGS"]);
                                _dr["Misc Charges"] = Convert.ToDecimal(sdr["MISC_MISC"]);
                                _dr["Transportation zone "] = Convert.ToString(sdr["ZZZONE1"]);
                                _dr["Transportation zone description"] = Convert.ToString(sdr["ZZZONE1_N"]);
                                _dr["Sales District"] = Convert.ToString(sdr["ZZBZIRK"]);
                                _dr["Sales District Description"] = Convert.ToString(sdr["ZZBZIRK_N"]);
                                _dr["Region code"] = Convert.ToString(sdr["ZZREGIO"]);
                                _dr["Region Description"] = Convert.ToString(sdr["ZZREGIO_N"]);
                                _dr["Sales Office"] = Convert.ToString(sdr["VKBUR"]);
                                _dr["Sales Office Description"] = Convert.ToString(sdr["VKBUR_N"]);
                                _dr["Sales Group"] = Convert.ToString(sdr["VKGRP"]);
                                _dr["Sales Group Description"] = Convert.ToString(sdr["VKGRP_N"]);
                                _dr["Branch Office"] = Convert.ToString(sdr["ZZBRANCH"]);
                                _dr["Branch Office Description"] = Convert.ToString(sdr["ZZBRANCH_N"]);
                                _dr["Primary Distance"] = Convert.ToDecimal(sdr["PDSTN"]);
                                _dr["Secondary Distance"] = Convert.ToDecimal(sdr["SDSTN"]);
                                _dr["Block Category"] = Convert.ToString(sdr["BLOCK_CT"]);
                                _dr["Accounting Document Number"] = Convert.ToString(sdr["BELNR"]);
                                _dr["Fiscal Year"] = Convert.ToString(sdr["GJAHR"]);
                                _dr["Invoice Type"] = Convert.ToString(sdr["INV_TYPE"]);
                                _dr["Freight Type"] = Convert.ToString(sdr["FRT_TYPE"]);
                                _dr["Plant category"] = Convert.ToString(sdr["ZZVLFKZ"]);
                                _dr["Supplying Plant Name"] = Convert.ToString(sdr["SUPP_PLANT_NAME"]);
                                _dr["Depot Rake movement"] = Convert.ToString(sdr["DEPO_RK_MVT"]);
                                _dr["Indirect Primary Frieght"] = Convert.ToDecimal(sdr["IND_PRI_FRT"]);
                                _dr["Ship Frieght"] = Convert.ToDecimal(sdr["SHIP_FRT_CHRGS"]);
                                _dr["Ship Handling Charges"] = Convert.ToDecimal(sdr["SHIP_HAND_CHRGS"]);
                                _dr["Clinker Plant"] = Convert.ToString(sdr["CLKMNFPLANT"]);
                                _dr["Supplying Plant"] = Convert.ToString(sdr["SUPPPLANT"]);
                                _dr["Clinker Distance"] = Convert.ToDecimal(sdr["DISTANCE"]);
                                _dr["Indirect Primary Distance"] = Convert.ToDecimal(sdr["INDPDISTANCE"]);
                                _dr["Clinker Plant name "] = Convert.ToString(sdr["CLK_PLT_NAME"]);
                                _dr["Manufacturing Plant Name"] = Convert.ToString(sdr["MNF_PLT_NAME"]);
                                _dr["Grinding unit plant code"] = Convert.ToString(sdr["GEIND_PLT"]);
                                _dr["Grinding unit plant Name"] = Convert.ToString(sdr["GEIND_PLT_NAME"]);
                                _dr["Supplying Depot"] = Convert.ToString(sdr["SUPPL_DEPO"]);
                                _dr["Supplying Depot Name"] = Convert.ToString(sdr["SUPPL_DEPO_NAME"]);
                                _dr["SD Document Currency"] = Convert.ToString(sdr["WAERK"]);
                                _dr["Rent Per MT"] = Convert.ToDecimal(sdr["RENT"]);
                                _dr["Rake Demurage Charges"] = Convert.ToDecimal(sdr["RAKEDEMCHRG"]);
                                _dr["Lead Distance Without Clinkcer KM"] = Convert.ToDecimal(sdr["LDISTANCE"]);
                                _dr["Lead Distance With Clinkcer KM"] = Convert.ToDecimal(sdr["LDISTANCE_CLK"]);
                                _dr["Material Code"] = Convert.ToString(sdr["MATNR"]);
                                _dr["Material Description"] = Convert.ToString(sdr["VTEXT"]);
                                _dr["Empty bags Material Code"] = Convert.ToString(sdr["MATNR1"]);
                                _dr["Empty bags Material Description"] = Convert.ToString(sdr["MAKTX"]);
                                _dr["Incurred Cost"] = Convert.ToDecimal(sdr["INCURREDCOST"]);
                                _dr["Unincurred Cost"] = Convert.ToDecimal(sdr["UNINCURREDCOST"]);
                                _dr["Ship to party Region"] = Convert.ToString(sdr["SH_REGIO"]);
                                _dr["Ship to party District"] = Convert.ToString(sdr["SH_DSTRC"]);
                                _dr["Ship to party Block"] = Convert.ToString(sdr["SH_BLOCK"]);
                                _dr["Ship to partyDestination"] = Convert.ToString(sdr["SH_DESTINT"]);
                                _dr["Pricing procedure"] = Convert.ToString(sdr["KALKS"]);
                                _dr["Delivery"] = Convert.ToString(sdr["DELIVERY_NO"]);
                                _dr["Shipment Number"] = Convert.ToString(sdr["TKNUM"]);
                                _dr["Manufacturing Plant"] = Convert.ToString(sdr["MNFPLANT"]);
                                _dr["Manufacturing Plant Description"] = Convert.ToString(sdr["MNFDESC"]);
                                _dr["Material group_1"] = Convert.ToString(sdr["MVGR1"]);
                                _dr["Gross Turnover"] = Convert.ToDecimal(sdr["GROSSTURN"]);
                                _dr["Net Turnover"] = Convert.ToDecimal(sdr["NETTURN"]);
                                _dr["Net Value in Document Currency"] = Convert.ToDecimal(sdr["NAKEDREAL"]);
                                _dr["Transport Incentive"] = Convert.ToDecimal(sdr["TRANS_INCENTIVE"]);
                                _dr["Net Value in Document Currency_1"] = Convert.ToDecimal(sdr["PLT_FRT"]);
                                _dr["Sold to Party Region"] = Convert.ToString(sdr["SP_REGIO"]);
                                _dr["Sold to Party District"] = Convert.ToString(sdr["SP_DSTRC"]);
                                _dr["Sold to Party Block"] = Convert.ToString(sdr["SP_BLOCK"]);
                                _dr["Sold to Party Destination"] = Convert.ToString(sdr["SP_DESTINT"]);
                                _dr["Means of Transport ID"] = Convert.ToString(sdr["TRAID"]);
                                _dr["Truck Type"] = Convert.ToString(sdr["TRUCK_TYPE"]);
                                _dr["E-Waybill Number"] = Convert.ToString(sdr["EWB_NO"]);
                                _dr["E-Waybill date"] = Convert.ToString(sdr["EDATE"]);
                                _dr["E-WayBill Valid Till Date"] = Convert.ToString(sdr["EVDATE"]);
                                _dr["HSN Code"] = Convert.ToString(sdr["STEUC"]);
                                _dr["Paid Price"] = Convert.ToDecimal(sdr["PAID_PRICE"]);
                                _dr["Description"] = Convert.ToString(sdr["KALKS_DESC"]);
                                _dr["Sold to Party Region Description"] = Convert.ToString(sdr["SP_REGIO_DESC"]);
                                _dr["Sold to Party District Description"] = Convert.ToString(sdr["SP_DSTRC_DESC"]);
                                _dr["Sold to Party Block Description"] = Convert.ToString(sdr["SP_BLOCK_DESC"]);
                                _dr["Sold to Party Destination Description"] = Convert.ToString(sdr["SP_DESTINT_DESC"]);
                                _dr["Manufacturing Plant Type"] = Convert.ToString(sdr["MF_PLANT_TYPE"]);
                                _dr["TDC Cost"] = Convert.ToDecimal(sdr["TOTAL_TDC_COST"]);
                                _dr["Total Distance"] = Convert.ToDecimal(sdr["TOTAL_DISTANCE"]);
                                _dr["Depot In-direct primary frieght"] = Convert.ToDecimal(sdr["DEPOT_IND_FRIEGHT"]);
                                _dr["Total Invoice Frieght"] = Convert.ToDecimal(sdr["TOTAL_INVOICE_FRT"]);
                                _dr["Road Primary frieght Incurred"] = Convert.ToDecimal(sdr["ROAD_PF_INCURRED"]);
                                _dr["Road Primary frieght unIncurred"] = Convert.ToDecimal(sdr["ROAD_PF_UNINCURRED"]);
                                _dr["Road Secondary frieght Incurred"] = Convert.ToDecimal(sdr["ROAD_SF_INCURRED"]);
                                _dr["Road Secondary frieght unIncurred"] = Convert.ToDecimal(sdr["ROAD_SF_UNINCURRED"]);
                                _dr["Rail Primary Frieght Incurred"] = Convert.ToDecimal(sdr["RAIL_PF_INCURRED"]);
                                _dr["Rail Primary Frieght unIncurred"] = Convert.ToDecimal(sdr["RAIL_PF_UNINCURRED"]);
                                _dr["Direct Delivery charges"] = Convert.ToDecimal(sdr["DRDL_CHGS"]);
                                _dr["Double Labour Charges"] = Convert.ToDecimal(sdr["DB_LAB_CHGS"]);
                                _dr["Invoice cancellation flag"] = Convert.ToString(sdr["ZINV_CANCEL"]);
                                _dr["Ship to party Destination Description"] = Convert.ToString(sdr["SH_DESTINT_DESC"]);
                                _dr["Ship Distance"] = Convert.ToDecimal(sdr["SHIP_DISTANCE"]);

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
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ZSD_LCOST_DATA_SRV.xlsx");
                    }
                }
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
                //List<ZSD_LCOST_DATA_SRV> lstsrvdeal = new List<ZSD_LCOST_DATA_SRV>();

                //var formats = new[] { "ddMMyyyy", "yyyyMMdd", "yyyyMMdd" };


                string startDateOrig = startDate;
                string endDateOrig = endDate;
                startDate = DateTime.ParseExact(startDate, "yyyyMMdd", null).ToString("yyyyMMdd");
                endDate = DateTime.ParseExact(endDate, "yyyyMMdd", null).ToString("yyyyMMdd");

                //Development
                //var url = "https://netwaver-dev.pennacement.com:443/sap/opu/odata/sap/ZSD_LCOST_DATA_SRV/LOGI_COSTSet?$format=json&$filter=Fkdat ge '" + startDateOrig.Trim() + "' and Fkdat le '" + endDateOrig.Trim() + "'";
                //string userName = "NWGW001";
                //string passwd = "Penna@123";

                var url = "https://netwaver-prd.pennacement.com:443/sap/opu/odata/sap/ZSD_LCOST_DATA_SRV/LOGI_COSTSet?$format=json&$filter=Fkdat ge '" + startDateOrig.Trim() + "' and Fkdat le '" + endDateOrig.Trim() + "'";

                string userName = "NWGW037";
                string passwd = "Admin@123456";

                log1.WriteLine("Insert Table : ZSD_LCOST_DATA_SRV");

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
                    List<ZSD_LCOST_DATA_SRV> varoutput = men1.ToObject<List<ZSD_LCOST_DATA_SRV>>();
                    var o = JsonConvert.DeserializeObject<List<ZSD_LCOST_DATA_SRV>>(men1.ToString());

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



                    string query = "";
                    query = " Delete from ZSD_LCOST_DATA_SRV ";
                    query += " where date_format(cast(Fkdat as date),'%Y%m%d') ";
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
                            //flag = false;
                            query = "Insert into ZSD_LCOST_DATA_SRV(VBELN,FKART,FKDAT,FKIMG,MEINS,WERKS,W_NAME1,ZSOURCE,ZSOURCED,ZTRATYP,ZTRATYPD,KUNNR,KUNNR_N,KUNAG,";
                            query += "KUNAG_N,PTNR,PTNR_N,SALSREP,SALSREP_N,REGIO,REGIO_N,DSTRC,DSTRC_N,BLOCK,BLOCK_N,DESTINT,";
                            query += "DESTINT_N,KDGRP,KTEXT,PRIMARY_FRT,SECONDRY_FRT,RAKNO,RAKPT,MATKL,LGORT,LGOBE,INCO1,INCO2,ULDG_CHGS,";
                            query += "TRNS_CHGS,DPUL_CHGS,DPLD_CHGS,DIVR_CHGS,LDNG_CHGS,CFAG_CHGS,RKSR_CHGS,PULD_CHGS,RKCL_CHGS,SHNT_CHGS,RKCF_CHGS,";
                            query += "BLND_CHGS,BLNB_CHGS,MISC_MISC,ZZZONE1,ZZZONE1_N,ZZBZIRK,ZZBZIRK_N,ZZREGIO,ZZREGIO_N,VKBUR,VKBUR_N,VKGRP,VKGRP_N,";
                            query += "ZZBRANCH,ZZBRANCH_N,PDSTN,SDSTN,BLOCK_CT,BELNR,GJAHR,INV_TYPE,FRT_TYPE,ZZVLFKZ,SUPP_PLANT_NAME,DEPO_RK_MVT,IND_PRI_FRT,";
                            query += "SHIP_FRT_CHRGS,SHIP_HAND_CHRGS,CLKMNFPLANT,SUPPPLANT,DISTANCE,INDPDISTANCE,CLK_PLT_NAME,MNF_PLT_NAME,GEIND_PLT,GEIND_PLT_NAME,SUPPL_DEPO,SUPPL_DEPO_NAME,";
                            query += "WAERK,RENT,RAKEDEMCHRG,LDISTANCE,LDISTANCE_CLK,MATNR,VTEXT,MATNR1,MAKTX,INCURREDCOST,";
                            query += "UNINCURREDCOST,SH_REGIO,SH_DSTRC,SH_BLOCK,SH_DESTINT,KALKS,DELIVERY_NO,TKNUM,MNFPLANT,MNFDESC,MVGR1,GROSSTURN,NETTURN,";
                            query += "NAKEDREAL,TRANS_INCENTIVE,PLT_FRT,SP_REGIO,SP_DSTRC,SP_BLOCK,SP_DESTINT,TRAID,TRUCK_TYPE,EWB_NO,EDATE,EVDATE,STEUC,";
                            query += "PAID_PRICE,KALKS_DESC,SP_REGIO_DESC, SP_DSTRC_DESC,SP_BLOCK_DESC,SP_DESTINT_DESC,MF_PLANT_TYPE,TOTAL_TDC_COST,TOTAL_DISTANCE,DEPOT_IND_FRIEGHT,TOTAL_INVOICE_FRT,";
                            query += "ROAD_PF_INCURRED,ROAD_PF_UNINCURRED,ROAD_SF_INCURRED,ROAD_SF_UNINCURRED,RAIL_PF_INCURRED,RAIL_PF_UNINCURRED,DRDL_CHGS,DB_LAB_CHGS,ZINV_CANCEL,SH_DESTINT_DESC,SHIP_DISTANCE ) Values ";
                            query += "(@VBELN,@FKART,@FKDAT,@FKIMG,@MEINS,@WERKS,@W_NAME1,@ZSOURCE,@ZSOURCED,@ZTRATYP,@ZTRATYPD,@KUNNR,@KUNNR_N,@KUNAG,";
                            query += "@KUNAG_N,@PTNR,@PTNR_N,@SALSREP,@SALSREP_N,@REGIO,@REGIO_N,@DSTRC,@DSTRC_N,@BLOCK,@BLOCK_N,@DESTINT,";
                            query += "@DESTINT_N,@KDGRP,@KTEXT,@PRIMARY_FRT,@SECONDRY_FRT,@RAKNO,@RAKPT,@MATKL,@LGORT,@LGOBE,@INCO1,@INCO2,@ULDG_CHGS,";
                            query += "@TRNS_CHGS,@DPUL_CHGS,@DPLD_CHGS,@DIVR_CHGS,@LDNG_CHGS,@CFAG_CHGS,@RKSR_CHGS,@PULD_CHGS,@RKCL_CHGS,@SHNT_CHGS,@RKCF_CHGS,";
                            query += "@BLND_CHGS,@BLNB_CHGS,@MISC_MISC,@ZZZONE1,@ZZZONE1_N,@ZZBZIRK,@ZZBZIRK_N,@ZZREGIO,@ZZREGIO_N,@VKBUR,@VKBUR_N,@VKGRP,@VKGRP_N,";
                            query += "@ZZBRANCH,@ZZBRANCH_N,@PDSTN,@SDSTN,@BLOCK_CT,@BELNR,@GJAHR,@INV_TYPE,@FRT_TYPE,@ZZVLFKZ,@SUPP_PLANT_NAME,@DEPO_RK_MVT,@IND_PRI_FRT,";
                            query += "@SHIP_FRT_CHRGS,@SHIP_HAND_CHRGS,@CLKMNFPLANT,@SUPPPLANT,@DISTANCE,@INDPDISTANCE,@CLK_PLT_NAME,@MNF_PLT_NAME,@GEIND_PLT,@GEIND_PLT_NAME,@SUPPL_DEPO,@SUPPL_DEPO_NAME,";
                            query += "@WAERK,@RENT,@RAKEDEMCHRG,@LDISTANCE,@LDISTANCE_CLK,@MATNR,@VTEXT,@MATNR1,@MAKTX,@INCURREDCOST,";
                            query += "@UNINCURREDCOST,@SH_REGIO,@SH_DSTRC,@SH_BLOCK,@SH_DESTINT,@KALKS,@DELIVERY_NO,@TKNUM,@MNFPLANT,@MNFDESC,@MVGR1,@GROSSTURN,@NETTURN,";
                            query += "@NAKEDREAL,@TRANS_INCENTIVE,@PLT_FRT,@SP_REGIO,@SP_DSTRC,@SP_BLOCK,@SP_DESTINT,@TRAID,@TRUCK_TYPE,@EWB_NO,@EDATE,@EVDATE,@STEUC,";
                            query += "@PAID_PRICE,@KALKS_DESC,@SP_REGIO_DESC,@SP_DSTRC_DESC,@SP_BLOCK_DESC,@SP_DESTINT_DESC,@MF_PLANT_TYPE,@TOTAL_TDC_COST,@TOTAL_DISTANCE,@DEPOT_IND_FRIEGHT,@TOTAL_INVOICE_FRT,";
                            query += "@ROAD_PF_INCURRED,@ROAD_PF_UNINCURRED,@ROAD_SF_INCURRED,@ROAD_SF_UNINCURRED,@RAIL_PF_INCURRED,@RAIL_PF_UNINCURRED,@DRDL_CHGS,@DB_LAB_CHGS,@ZINV_CANCEL,@SH_DESTINT_DESC,@SHIP_DISTANCE);";
                            MySqlCommand cmd = new MySqlCommand(query, con);

                            cmd.Parameters.AddWithValue("@VBELN", row["VBELN"].ToString());
                            cmd.Parameters.AddWithValue("@FKART", row["FKART"].ToString());
                            cmd.Parameters.AddWithValue("@FKDAT", row["FKDAT"].ToString());
                            cmd.Parameters.AddWithValue("@FKIMG", row["FKIMG"].ToString());
                            cmd.Parameters.AddWithValue("@MEINS", row["MEINS"].ToString());
                            cmd.Parameters.AddWithValue("@WERKS", row["WERKS"].ToString());

                            cmd.Parameters.AddWithValue("@W_NAME1", row["WNAME1"].ToString());
                            cmd.Parameters.AddWithValue("@ZSOURCE", row["ZSOURCE"].ToString());
                            cmd.Parameters.AddWithValue("@ZSOURCED", row["ZSOURCED"].ToString());
                            cmd.Parameters.AddWithValue("@ZTRATYP", row["ZTRATYP"].ToString());
                            cmd.Parameters.AddWithValue("@ZTRATYPD", row["ZTRATYPD"].ToString());
                            cmd.Parameters.AddWithValue("@KUNNR", row["KUNNR"].ToString());
                            cmd.Parameters.AddWithValue("@KUNNR_N", row["KUNNRN"].ToString());
                            cmd.Parameters.AddWithValue("@KUNAG", row["KUNAG"].ToString());
                            cmd.Parameters.AddWithValue("@KUNAG_N", row["KUNAGN"].ToString());
                            cmd.Parameters.AddWithValue("@PTNR", row["PTNR"].ToString());
                            cmd.Parameters.AddWithValue("@PTNR_N", row["PTNRN"].ToString());
                            cmd.Parameters.AddWithValue("@SALSREP", row["SALSREP"].ToString());
                            cmd.Parameters.AddWithValue("@SALSREP_N", row["SALSREPN"].ToString());
                            cmd.Parameters.AddWithValue("@REGIO", row["REGIO"].ToString());
                            cmd.Parameters.AddWithValue("@REGIO_N", row["REGION"].ToString());
                            cmd.Parameters.AddWithValue("@DSTRC", row["DSTRC"].ToString());
                            cmd.Parameters.AddWithValue("@DSTRC_N", row["DSTRCN"].ToString());
                            cmd.Parameters.AddWithValue("@BLOCK", row["BLOCK"].ToString());
                            cmd.Parameters.AddWithValue("@BLOCK_N", row["BLOCKN"].ToString());
                            cmd.Parameters.AddWithValue("@DESTINT", row["DESTINT"].ToString());
                            cmd.Parameters.AddWithValue("@DESTINT_N", row["DESTINTN"].ToString());
                            cmd.Parameters.AddWithValue("@KDGRP", row["KDGRP"].ToString());
                            cmd.Parameters.AddWithValue("@KTEXT", row["KTEXT"].ToString());
                            cmd.Parameters.AddWithValue("@PRIMARY_FRT", row["PRIMARYFRT"].ToString());
                            cmd.Parameters.AddWithValue("@SECONDRY_FRT", row["SECONDRYFRT"].ToString());
                            cmd.Parameters.AddWithValue("@RAKNO", row["RAKNO"].ToString());
                            cmd.Parameters.AddWithValue("@RAKPT", row["RAKPT"].ToString());
                            cmd.Parameters.AddWithValue("@MATKL", row["MATKL"].ToString());
                            cmd.Parameters.AddWithValue("@LGORT", row["LGORT"].ToString());
                            cmd.Parameters.AddWithValue("@LGOBE", row["LGOBE"].ToString());
                            cmd.Parameters.AddWithValue("@INCO1", row["INCO1"].ToString());
                            cmd.Parameters.AddWithValue("@INCO2", row["INCO2"].ToString());
                            cmd.Parameters.AddWithValue("@ULDG_CHGS", row["ULDGCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@TRNS_CHGS", row["TRNSCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@DPUL_CHGS", row["DPULCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@DPLD_CHGS", row["DPLDCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@DIVR_CHGS", row["DIVRCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@LDNG_CHGS", row["LDNGCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@CFAG_CHGS", row["CFAGCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@RKSR_CHGS", row["RKSRCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@PULD_CHGS", row["PULDCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@RKCL_CHGS", row["RKCLCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@SHNT_CHGS", row["SHNTCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@RKCF_CHGS", row["RKCFCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@BLND_CHGS", row["BLNDCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@BLNB_CHGS", row["BLNBCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@MISC_MISC", row["MISCMISC"].ToString());
                            cmd.Parameters.AddWithValue("@ZZZONE1", row["ZZZONE1"].ToString());
                            cmd.Parameters.AddWithValue("@ZZZONE1_N", row["ZZZONE1N"].ToString());
                            cmd.Parameters.AddWithValue("@ZZBZIRK", row["ZZBZIRK"].ToString());
                            cmd.Parameters.AddWithValue("@ZZBZIRK_N", row["ZZBZIRKN"].ToString());
                            cmd.Parameters.AddWithValue("@ZZREGIO", row["ZZREGIO"].ToString());
                            cmd.Parameters.AddWithValue("@ZZREGIO_N", row["ZZREGION"].ToString());
                            cmd.Parameters.AddWithValue("@VKBUR", row["VKBUR"].ToString());
                            cmd.Parameters.AddWithValue("@VKBUR_N", row["VKBURN"].ToString());
                            cmd.Parameters.AddWithValue("@VKGRP", row["VKGRP"].ToString());
                            cmd.Parameters.AddWithValue("@VKGRP_N", row["VKGRPN"].ToString());
                            cmd.Parameters.AddWithValue("@ZZBRANCH", row["ZZBRANCH"].ToString());
                            cmd.Parameters.AddWithValue("@ZZBRANCH_N", row["ZZBRANCHN"].ToString());
                            cmd.Parameters.AddWithValue("@PDSTN", row["PDSTN"].ToString());
                            cmd.Parameters.AddWithValue("@SDSTN", row["SDSTN"].ToString());
                            cmd.Parameters.AddWithValue("@BLOCK_CT", row["BLOCKCT"].ToString());
                            cmd.Parameters.AddWithValue("@BELNR", row["BELNR"].ToString());
                            cmd.Parameters.AddWithValue("@GJAHR", row["GJAHR"].ToString());
                            cmd.Parameters.AddWithValue("@INV_TYPE", row["INVTYPE"].ToString());
                            cmd.Parameters.AddWithValue("@FRT_TYPE", row["FRTTYPE"].ToString());
                            cmd.Parameters.AddWithValue("@ZZVLFKZ", row["ZZVLFKZ"].ToString());
                            cmd.Parameters.AddWithValue("@SUPP_PLANT_NAME", row["SUPPPLANTNAME"].ToString());
                            cmd.Parameters.AddWithValue("@DEPO_RK_MVT", row["DEPORKMVT"].ToString());
                            cmd.Parameters.AddWithValue("@IND_PRI_FRT", row["INDPRIFRT"].ToString());

                            cmd.Parameters.AddWithValue("@SHIP_FRT_CHRGS", row["SHIPFRTCHRGS"].ToString());
                            cmd.Parameters.AddWithValue("@SHIP_HAND_CHRGS", row["SHIPHANDCHRGS"].ToString());
                            cmd.Parameters.AddWithValue("@CLKMNFPLANT", row["CLKMNFPLANT"].ToString());
                            cmd.Parameters.AddWithValue("@SUPPPLANT", row["SUPPPLANT"].ToString());
                            cmd.Parameters.AddWithValue("@DISTANCE", row["DISTANCE"].ToString());
                            cmd.Parameters.AddWithValue("@INDPDISTANCE", row["INDPDISTANCE"].ToString());
                            cmd.Parameters.AddWithValue("@CLK_PLT_NAME", row["CLKPLTNAME"].ToString());
                            cmd.Parameters.AddWithValue("@MNF_PLT_NAME", row["MNFPLTNAME"].ToString());
                            cmd.Parameters.AddWithValue("@GEIND_PLT", row["GEINDPLT"].ToString());
                            cmd.Parameters.AddWithValue("@GEIND_PLT_NAME", row["GEINDPLTNAME"].ToString());
                            cmd.Parameters.AddWithValue("@SUPPL_DEPO", row["SUPPLDEPO"].ToString());
                            cmd.Parameters.AddWithValue("@SUPPL_DEPO_NAME", row["SUPPLDEPONAME"].ToString());
                            cmd.Parameters.AddWithValue("@WAERK", row["WAERK"].ToString());
                            cmd.Parameters.AddWithValue("@RENT", row["RENT"].ToString());
                            cmd.Parameters.AddWithValue("@RAKEDEMCHRG", row["RAKEDEMCHRG"].ToString());
                            cmd.Parameters.AddWithValue("@LDISTANCE", row["LDISTANCE"].ToString());
                            cmd.Parameters.AddWithValue("@LDISTANCE_CLK", row["LDISTANCECLK"].ToString());
                            cmd.Parameters.AddWithValue("@MATNR", row["MATNR"].ToString());
                            cmd.Parameters.AddWithValue("@VTEXT", row["VTEXT"].ToString());
                            cmd.Parameters.AddWithValue("@MATNR1", row["MATNR1"].ToString());
                            cmd.Parameters.AddWithValue("@MAKTX", row["MAKTX"].ToString());
                            cmd.Parameters.AddWithValue("@INCURREDCOST", row["INCURREDCOST"].ToString());
                            cmd.Parameters.AddWithValue("@UNINCURREDCOST", row["UNINCURREDCOST"].ToString());
                            cmd.Parameters.AddWithValue("@SH_REGIO", row["SHREGIO"].ToString());
                            cmd.Parameters.AddWithValue("@SH_DSTRC", row["SHDSTRC"].ToString());
                            cmd.Parameters.AddWithValue("@SH_BLOCK", row["SHBLOCK"].ToString());
                            cmd.Parameters.AddWithValue("@SH_DESTINT", row["SHDESTINT"].ToString());
                            cmd.Parameters.AddWithValue("@KALKS", row["KALKS"].ToString());
                            cmd.Parameters.AddWithValue("@DELIVERY_NO", row["DELIVERYNO"].ToString());
                            cmd.Parameters.AddWithValue("@TKNUM", row["TKNUM"].ToString());
                            cmd.Parameters.AddWithValue("@MNFPLANT", row["MNFPLANT"].ToString());
                            cmd.Parameters.AddWithValue("@MNFDESC", row["MNFDESC"].ToString());
                            cmd.Parameters.AddWithValue("@MVGR1", row["MVGR1"].ToString());
                            cmd.Parameters.AddWithValue("@GROSSTURN", row["GROSSTURN"].ToString());
                            cmd.Parameters.AddWithValue("@NETTURN", row["NETTURN"].ToString());
                            cmd.Parameters.AddWithValue("@NAKEDREAL", row["NAKEDREAL"].ToString());
                            cmd.Parameters.AddWithValue("@TRANS_INCENTIVE", row["TRANSINCENTIVE"].ToString());
                            cmd.Parameters.AddWithValue("@PLT_FRT", row["PLTFRT"].ToString());
                            cmd.Parameters.AddWithValue("@SP_REGIO", row["SPREGIO"].ToString());
                            cmd.Parameters.AddWithValue("@SP_DSTRC", row["SPDSTRC"].ToString());
                            cmd.Parameters.AddWithValue("@SP_BLOCK", row["SPBLOCK"].ToString());
                            cmd.Parameters.AddWithValue("@SP_DESTINT", row["SPDESTINT"].ToString());
                            cmd.Parameters.AddWithValue("@TRAID", row["TRAID"].ToString());
                            cmd.Parameters.AddWithValue("@TRUCK_TYPE", row["TRUCKTYPE"].ToString());
                            cmd.Parameters.AddWithValue("@EWB_NO", row["EWBNO"].ToString());
                            cmd.Parameters.AddWithValue("@EDATE", row["EDATE"].ToString());
                            cmd.Parameters.AddWithValue("@EVDATE", row["EVDATE"].ToString());
                            cmd.Parameters.AddWithValue("@STEUC", row["STEUC"].ToString());
                            cmd.Parameters.AddWithValue("@PAID_PRICE", row["PAIDPRICE"].ToString());
                            cmd.Parameters.AddWithValue("@KALKS_DESC", row["KALKSDESC"].ToString());
                            cmd.Parameters.AddWithValue("@SP_REGIO_DESC", row["SPREGIODESC"].ToString());
                            cmd.Parameters.AddWithValue("@SP_DSTRC_DESC", row["SPDSTRCDESC"].ToString());
                            cmd.Parameters.AddWithValue("@SP_BLOCK_DESC", row["SPBLOCKDESC"].ToString());
                            cmd.Parameters.AddWithValue("@SP_DESTINT_DESC", row["SPDESTINTDESC"].ToString());
                            cmd.Parameters.AddWithValue("@MF_PLANT_TYPE", row["TOTALTDCCOST"].ToString());

                            cmd.Parameters.AddWithValue("@TOTAL_TDC_COST", row["TOTALTDCCOST"].ToString());

                            cmd.Parameters.AddWithValue("@TOTAL_DISTANCE", row["TOTALDISTANCE"].ToString());
                            cmd.Parameters.AddWithValue("@DEPOT_IND_FRIEGHT", row["DEPOTINDFRIEGHT"].ToString());
                            cmd.Parameters.AddWithValue("@TOTAL_INVOICE_FRT", row["TOTALINVOICEFRT"].ToString());
                            cmd.Parameters.AddWithValue("@ROAD_PF_INCURRED", row["ROADPFINCURRED"].ToString());
                            cmd.Parameters.AddWithValue("@ROAD_PF_UNINCURRED", row["ROADPFUNINCURRED"].ToString());
                            cmd.Parameters.AddWithValue("@ROAD_SF_INCURRED", row["ROADSFINCURRED"].ToString());
                            cmd.Parameters.AddWithValue("@ROAD_SF_UNINCURRED", row["ROADSFUNINCURRED"].ToString());
                            cmd.Parameters.AddWithValue("@RAIL_PF_INCURRED", row["RAILPFINCURRED"].ToString());
                            cmd.Parameters.AddWithValue("@RAIL_PF_UNINCURRED", row["RAILPFUNINCURRED"].ToString());
                            cmd.Parameters.AddWithValue("@DRDL_CHGS", row["DRDLCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@DB_LAB_CHGS", row["DBLABCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@ZINV_CANCEL", row["ZINVCANCEL"].ToString());
                            cmd.Parameters.AddWithValue("@SH_DESTINT_DESC", row["SHDESTINTDESC"].ToString());
                            cmd.Parameters.AddWithValue("@SHIP_DISTANCE", row["SHIPDISTANCE"].ToString());

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
                    query = " Select Count(*) from ZSD_LCOST_DATA_SRV ";
                    query += " where date_format(cast(Fkdat as date),'%Y%m%d') ";
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
                        string query = "";
                        query = " Delete from ZSD_LCOST_DATA_SRV ";
                        query += " where date_format(cast(Fkdat as date),'%Y%m%d') ";
                        query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";

                        using (MySqlConnection sqlCon = new MySqlConnection(CS))
                        {
                            sqlCon.Open();
                            MySqlCommand Cmnd = new MySqlCommand(query, sqlCon);

                            int result = Cmnd.ExecuteNonQuery();

                            sqlCon.Close();
                        }

                        query = "";
                        query += " Select Count(*) Cnt from ZSD_LCOST_DATA_SRV ";
                        query += " where date_format(cast(Fkdat as date),'%Y%m%d') ";
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
                // Import_Data imp = new Import_Data();
                //imp.Insert_ZSD_LCOST_DATA_SRV(startDate, endDate);
                //Insert_ZSD_LCOST_DATA_SRV(startDate, endDate);
            }

            if (InputID == "S")
            {

                using (MySqlConnection con = new MySqlConnection(CS))
                {
                    string query = " Select * from ZSD_LCOST_DATA_SRV ";
                    query += " where date_format(cast(Fkdat as date),'%Y%m%d') ";
                    query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";
                    query += " order by date_format(cast(Fkdat as date),'%Y%m%d') ";
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {

                        cmd.Connection = con;
                        con.Open();
                        using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                lstsrvdeal.Add(new ZSD_LCOST_DATA_SRV
                                {
                                    Vbeln = Convert.ToString(sdr["VBELN"]),
                                    Fkart = Convert.ToString(sdr["FKART"]),
                                    Fkdat = Convert.ToString(sdr["FKDAT"]),
                                    Fkimg = Convert.ToDecimal(sdr["FKIMG"]),
                                    Meins = Convert.ToString(sdr["MEINS"]),
                                    Werks = Convert.ToString(sdr["WERKS"]),
                                    WName1 = Convert.ToString(sdr["W_NAME1"]),
                                    Zsource = Convert.ToString(sdr["ZSOURCE"]),
                                    Zsourced = Convert.ToString(sdr["ZSOURCED"]),
                                    Ztratyp = Convert.ToString(sdr["ZTRATYP"]),
                                    Ztratypd = Convert.ToString(sdr["ZTRATYPD"]),
                                    Kunnr = Convert.ToString(sdr["KUNNR"]),
                                    KunnrN = Convert.ToString(sdr["KUNNR_N"]),
                                    Kunag = Convert.ToString(sdr["KUNAG"]),
                                    KunagN = Convert.ToString(sdr["KUNAG_N"]),
                                    Ptnr = Convert.ToString(sdr["PTNR"]),
                                    PtnrN = Convert.ToString(sdr["PTNR_N"]),
                                    Salsrep = Convert.ToString(sdr["SALSREP"]),
                                    SalsrepN = Convert.ToString(sdr["SALSREP_N"]),
                                    Regio = Convert.ToString(sdr["REGIO"]),
                                    RegioN = Convert.ToString(sdr["REGIO_N"]),
                                    Dstrc = Convert.ToString(sdr["DSTRC"]),
                                    DstrcN = Convert.ToString(sdr["DSTRC_N"]),
                                    Block = Convert.ToString(sdr["BLOCK"]),
                                    BlockN = Convert.ToString(sdr["BLOCK_N"]),
                                    Destint = Convert.ToString(sdr["DESTINT"]),
                                    DestintN = Convert.ToString(sdr["DESTINT_N"]),
                                    Kdgrp = Convert.ToString(sdr["KDGRP"]),
                                    Ktext = Convert.ToString(sdr["KTEXT"]),
                                    PrimaryFrt = Convert.ToDecimal(sdr["PRIMARY_FRT"]),
                                    SecondryFrt = Convert.ToDecimal(sdr["SECONDRY_FRT"]),
                                    Rakno = Convert.ToString(sdr["RAKNO"]),
                                    Rakpt = Convert.ToString(sdr["RAKPT"]),
                                    Matkl = Convert.ToString(sdr["MATKL"]),
                                    Lgort = Convert.ToString(sdr["LGORT"]),
                                    Lgobe = Convert.ToString(sdr["LGOBE"]),
                                    Inco1 = Convert.ToString(sdr["INCO1"]),
                                    Inco2 = Convert.ToString(sdr["INCO2"]),
                                    UldgChgs = Convert.ToDecimal(sdr["ULDG_CHGS"]),
                                    TrnsChgs = Convert.ToDecimal(sdr["TRNS_CHGS"]),
                                    DpulChgs = Convert.ToDecimal(sdr["DPUL_CHGS"]),
                                    DpldChgs = Convert.ToDecimal(sdr["DPLD_CHGS"]),
                                    DivrChgs = Convert.ToDecimal(sdr["DIVR_CHGS"]),
                                    LdngChgs = Convert.ToDecimal(sdr["LDNG_CHGS"]),
                                    CfagChgs = Convert.ToDecimal(sdr["CFAG_CHGS"]),
                                    RksrChgs = Convert.ToDecimal(sdr["RKSR_CHGS"]),
                                    PuldChgs = Convert.ToDecimal(sdr["PULD_CHGS"]),
                                    RkclChgs = Convert.ToDecimal(sdr["RKCL_CHGS"]),
                                    ShntChgs = Convert.ToDecimal(sdr["SHNT_CHGS"]),
                                    RkcfChgs = Convert.ToDecimal(sdr["RKCF_CHGS"]),
                                    BlndChgs = Convert.ToDecimal(sdr["BLND_CHGS"]),
                                    BlnbChgs = Convert.ToDecimal(sdr["BLNB_CHGS"]),
                                    MiscMisc = Convert.ToDecimal(sdr["MISC_MISC"]),
                                    Zzzone1 = Convert.ToString(sdr["ZZZONE1"]),
                                    Zzzone1N = Convert.ToString(sdr["ZZZONE1_N"]),
                                    Zzbzirk = Convert.ToString(sdr["ZZBZIRK"]),
                                    ZzbzirkN = Convert.ToString(sdr["ZZBZIRK_N"]),
                                    Zzregio = Convert.ToString(sdr["ZZREGIO"]),
                                    ZzregioN = Convert.ToString(sdr["ZZREGIO_N"]),
                                    Vkbur = Convert.ToString(sdr["VKBUR"]),
                                    VkburN = Convert.ToString(sdr["VKBUR_N"]),
                                    Vkgrp = Convert.ToString(sdr["VKGRP"]),
                                    VkgrpN = Convert.ToString(sdr["VKGRP_N"]),
                                    Zzbranch = Convert.ToString(sdr["ZZBRANCH"]),
                                    ZzbranchN = Convert.ToString(sdr["ZZBRANCH_N"]),
                                    Pdstn = Convert.ToDecimal(sdr["PDSTN"]),
                                    Sdstn = Convert.ToDecimal(sdr["SDSTN"]),
                                    BlockCt = Convert.ToString(sdr["BLOCK_CT"]),
                                    Belnr = Convert.ToString(sdr["BELNR"]),
                                    Gjahr = Convert.ToString(sdr["GJAHR"]),
                                    InvType = Convert.ToString(sdr["INV_TYPE"]),
                                    FrtType = Convert.ToString(sdr["FRT_TYPE"]),
                                    Zzvlfkz = Convert.ToString(sdr["ZZVLFKZ"]),
                                    SuppPlantName = Convert.ToString(sdr["SUPP_PLANT_NAME"]),
                                    DepoRkMvt = Convert.ToString(sdr["DEPO_RK_MVT"]),
                                    IndPriFrt = Convert.ToDecimal(sdr["IND_PRI_FRT"]),
                                    ShipFrtChrgs = Convert.ToDecimal(sdr["SHIP_FRT_CHRGS"]),
                                    ShipHandChrgs = Convert.ToDecimal(sdr["SHIP_HAND_CHRGS"]),
                                    Clkmnfplant = Convert.ToString(sdr["CLKMNFPLANT"]),
                                    Suppplant = Convert.ToString(sdr["SUPPPLANT"]),
                                    Distance = Convert.ToDecimal(sdr["DISTANCE"]),
                                    Indpdistance = Convert.ToDecimal(sdr["INDPDISTANCE"]),
                                    ClkPltName = Convert.ToString(sdr["CLK_PLT_NAME"]),
                                    MnfPltName = Convert.ToString(sdr["MNF_PLT_NAME"]),
                                    GeindPlt = Convert.ToString(sdr["GEIND_PLT"]),
                                    GeindPltName = Convert.ToString(sdr["GEIND_PLT_NAME"]),
                                    SupplDepo = Convert.ToString(sdr["SUPPL_DEPO"]),
                                    SupplDepoName = Convert.ToString(sdr["SUPPL_DEPO_NAME"]),
                                    Waerk = Convert.ToString(sdr["WAERK"]),
                                    Rent = Convert.ToDecimal(sdr["RENT"]),
                                    Rakedemchrg = Convert.ToDecimal(sdr["RAKEDEMCHRG"]),
                                    Ldistance = Convert.ToDecimal(sdr["LDISTANCE"]),
                                    LdistanceClk = Convert.ToDecimal(sdr["LDISTANCE_CLK"]),
                                    Matnr = Convert.ToString(sdr["MATNR"]),
                                    Vtext = Convert.ToString(sdr["VTEXT"]),
                                    Matnr1 = Convert.ToString(sdr["MATNR1"]),
                                    Maktx = Convert.ToString(sdr["MAKTX"]),
                                    Incurredcost = Convert.ToDecimal(sdr["INCURREDCOST"]),
                                    Unincurredcost = Convert.ToDecimal(sdr["UNINCURREDCOST"]),
                                    ShRegio = Convert.ToString(sdr["SH_REGIO"]),
                                    ShDstrc = Convert.ToString(sdr["SH_DSTRC"]),
                                    ShBlock = Convert.ToString(sdr["SH_BLOCK"]),
                                    ShDestint = Convert.ToString(sdr["SH_DESTINT"]),
                                    Kalks = Convert.ToString(sdr["KALKS"]),
                                    DeliveryNo = Convert.ToString(sdr["DELIVERY_NO"]),
                                    Tknum = Convert.ToString(sdr["TKNUM"]),
                                    Mnfplant = Convert.ToString(sdr["MNFPLANT"]),
                                    Mnfdesc = Convert.ToString(sdr["MNFDESC"]),
                                    Mvgr1 = Convert.ToString(sdr["MVGR1"]),
                                    Grossturn = Convert.ToDecimal(sdr["GROSSTURN"]),
                                    Netturn = Convert.ToDecimal(sdr["NETTURN"]),
                                    Nakedreal = Convert.ToDecimal(sdr["NAKEDREAL"]),
                                    TransIncentive = Convert.ToDecimal(sdr["TRANS_INCENTIVE"]),
                                    PltFrt = Convert.ToDecimal(sdr["PLT_FRT"]),
                                    SpRegio = Convert.ToString(sdr["SP_REGIO"]),
                                    SpDstrc = Convert.ToString(sdr["SP_DSTRC"]),
                                    SpBlock = Convert.ToString(sdr["SP_BLOCK"]),
                                    SpDestint = Convert.ToString(sdr["SP_DESTINT"]),
                                    Traid = Convert.ToString(sdr["TRAID"]),
                                    TruckType = Convert.ToString(sdr["TRUCK_TYPE"]),
                                    EwbNo = Convert.ToString(sdr["EWB_NO"]),
                                    Edate = Convert.ToString(sdr["EDATE"]),
                                    Evdate = Convert.ToString(sdr["EVDATE"]),
                                    Steuc = Convert.ToString(sdr["STEUC"]),
                                    PaidPrice = Convert.ToDecimal(sdr["PAID_PRICE"]),
                                    KalksDesc = Convert.ToString(sdr["KALKS_DESC"]),
                                    SpRegioDesc = Convert.ToString(sdr["SP_REGIO_DESC"]),
                                    SpDstrcDesc = Convert.ToString(sdr["SP_DSTRC_DESC"]),
                                    SpBlockDesc = Convert.ToString(sdr["SP_BLOCK_DESC"]),
                                    SpDestintDesc = Convert.ToString(sdr["SP_DESTINT_DESC"]),
                                    MfPlantType = Convert.ToString(sdr["MF_PLANT_TYPE"]),
                                    TotalTdcCost = Convert.ToDecimal(sdr["TOTAL_TDC_COST"]),
                                    TotalDistance = Convert.ToDecimal(sdr["TOTAL_DISTANCE"]),
                                    DepotIndFrieght = Convert.ToDecimal(sdr["DEPOT_IND_FRIEGHT"]),
                                    TotalInvoiceFrt = Convert.ToDecimal(sdr["TOTAL_INVOICE_FRT"]),
                                    RoadPfIncurred = Convert.ToDecimal(sdr["ROAD_PF_INCURRED"]),
                                    RoadPfUnincurred = Convert.ToDecimal(sdr["ROAD_PF_UNINCURRED"]),
                                    RoadSfIncurred = Convert.ToDecimal(sdr["ROAD_SF_INCURRED"]),
                                    RoadSfUnincurred = Convert.ToDecimal(sdr["ROAD_SF_UNINCURRED"]),
                                    RailPfIncurred = Convert.ToDecimal(sdr["RAIL_PF_INCURRED"]),
                                    RailPfUnincurred = Convert.ToDecimal(sdr["RAIL_PF_UNINCURRED"]),
                                    DrdlChgs = Convert.ToDecimal(sdr["DRDL_CHGS"]),
                                    DbLabChgs = Convert.ToDecimal(sdr["DB_LAB_CHGS"]),
                                    ZinvCancel = Convert.ToString(sdr["ZINV_CANCEL"]),
                                    ShDestintDesc = Convert.ToString(sdr["SH_DESTINT_DESC"]),
                                    ShipDistance = Convert.ToDecimal(sdr["SHIP_DISTANCE"]),


                                });
                            }
                        }
                        con.Close();
                    }
                }
            }
            ViewData["GroupID"] = 0;
            int pageSize;
            //ViewData["lstsrvdeal"] = lstsrvdeal;
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
        public ActionResult LogiCost(string startDate, string endDate, string InputID, int? page)
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

                List<ZSD_LCOST_DATA_SRV> lstsrvdeal = new List<ZSD_LCOST_DATA_SRV>();
                DateTime fromDateValue;
                var formats = new[] { "ddMMyyyy", "yyyyMMdd", "yyyyMMdd" };
                if (!DateTime.TryParseExact(startDate.Trim(), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue) || !(DateTime.TryParseExact(endDate.Trim(), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue)))
                {
                    TempData["ErrMsg"] = "From Date or to Date is not Valid.Unable Process Request.";
                    return RedirectToAction("LogiCost");
                }

                //string startDateOrig = startDate;
                //string endDateOrig = endDate;
                //startDate = DateTime.ParseExact(startDate, "yyyyMMdd", null).ToString("yyyyMMdd");
                //endDate = DateTime.ParseExact(endDate, "yyyyMMdd", null).ToString("yyyyMMdd");

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
                    //List<ZSD_LCOST_DATA_SRV> lstsrvdeal = new List<ZSD_LCOST_DATA_SRV>();

                    //var formats = new[] { "ddMMyyyy", "yyyyMMdd", "yyyyMMdd" };


                    string startDateOrig = startDate;
                    string endDateOrig = endDate;
                    startDate = DateTime.ParseExact(startDate, "yyyyMMdd", null).ToString("yyyyMMdd");
                    endDate = DateTime.ParseExact(endDate, "yyyyMMdd", null).ToString("yyyyMMdd");

                    //Development
                    //var url = "https://netwaver-dev.pennacement.com:443/sap/opu/odata/sap/ZSD_LCOST_DATA_SRV/LOGI_COSTSet?$format=json&$filter=Fkdat ge '" + startDateOrig.Trim() + "' and Fkdat le '" + endDateOrig.Trim() + "'";
                    //string userName = "NWGW001";
                    //string passwd = "Penna@123";

                    var url = "https://netwaver-prd.pennacement.com:443/sap/opu/odata/sap/ZSD_LCOST_DATA_SRV/LOGI_COSTSet?$format=json&$filter=Fkdat ge '" + startDateOrig.Trim() + "' and Fkdat le '" + endDateOrig.Trim() + "'";

                    string userName = "NWGW037";
                    string passwd = "Admin@123456";

                    log1.WriteLine("Insert Table : ZSD_LCOST_DATA_SRV");

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
                        List<ZSD_LCOST_DATA_SRV> varoutput = men1.ToObject<List<ZSD_LCOST_DATA_SRV>>();
                        var o = JsonConvert.DeserializeObject<List<ZSD_LCOST_DATA_SRV>>(men1.ToString());

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
                        query = " Delete from ZSD_LCOST_DATA_SRV ";
                        query += " where date_format(cast(Fkdat as date),'%Y%m%d') ";
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
                                //flag = false;
                                query = "Insert into ZSD_LCOST_DATA_SRV(VBELN,FKART,FKDAT,FKIMG,MEINS,WERKS,W_NAME1,ZSOURCE,ZSOURCED,ZTRATYP,ZTRATYPD,KUNNR,KUNNR_N,KUNAG,";
                                query += "KUNAG_N,PTNR,PTNR_N,SALSREP,SALSREP_N,REGIO,REGIO_N,DSTRC,DSTRC_N,BLOCK,BLOCK_N,DESTINT,";
                                query += "DESTINT_N,KDGRP,KTEXT,PRIMARY_FRT,SECONDRY_FRT,RAKNO,RAKPT,MATKL,LGORT,LGOBE,INCO1,INCO2,ULDG_CHGS,";
                                query += "TRNS_CHGS,DPUL_CHGS,DPLD_CHGS,DIVR_CHGS,LDNG_CHGS,CFAG_CHGS,RKSR_CHGS,PULD_CHGS,RKCL_CHGS,SHNT_CHGS,RKCF_CHGS,";
                                query += "BLND_CHGS,BLNB_CHGS,MISC_MISC,ZZZONE1,ZZZONE1_N,ZZBZIRK,ZZBZIRK_N,ZZREGIO,ZZREGIO_N,VKBUR,VKBUR_N,VKGRP,VKGRP_N,";
                                query += "ZZBRANCH,ZZBRANCH_N,PDSTN,SDSTN,BLOCK_CT,BELNR,GJAHR,INV_TYPE,FRT_TYPE,ZZVLFKZ,SUPP_PLANT_NAME,DEPO_RK_MVT,IND_PRI_FRT,";
                                query += "SHIP_FRT_CHRGS,SHIP_HAND_CHRGS,CLKMNFPLANT,SUPPPLANT,DISTANCE,INDPDISTANCE,CLK_PLT_NAME,MNF_PLT_NAME,GEIND_PLT,GEIND_PLT_NAME,SUPPL_DEPO,SUPPL_DEPO_NAME,";
                                query += "WAERK,RENT,RAKEDEMCHRG,LDISTANCE,LDISTANCE_CLK,MATNR,VTEXT,MATNR1,MAKTX,INCURREDCOST,";
                                query += "UNINCURREDCOST,SH_REGIO,SH_DSTRC,SH_BLOCK,SH_DESTINT,KALKS,DELIVERY_NO,TKNUM,MNFPLANT,MNFDESC,MVGR1,GROSSTURN,NETTURN,";
                                query += "NAKEDREAL,TRANS_INCENTIVE,PLT_FRT,SP_REGIO,SP_DSTRC,SP_BLOCK,SP_DESTINT,TRAID,TRUCK_TYPE,EWB_NO,EDATE,EVDATE,STEUC,";
                                query += "PAID_PRICE,KALKS_DESC,SP_REGIO_DESC, SP_DSTRC_DESC,SP_BLOCK_DESC,SP_DESTINT_DESC,MF_PLANT_TYPE,TOTAL_TDC_COST,TOTAL_DISTANCE,DEPOT_IND_FRIEGHT,TOTAL_INVOICE_FRT,";
                                query += "ROAD_PF_INCURRED,ROAD_PF_UNINCURRED,ROAD_SF_INCURRED,ROAD_SF_UNINCURRED,RAIL_PF_INCURRED,RAIL_PF_UNINCURRED,DRDL_CHGS,DB_LAB_CHGS,ZINV_CANCEL,SH_DESTINT_DESC,SHIP_DISTANCE ) Values ";
                                query += "(@VBELN,@FKART,@FKDAT,@FKIMG,@MEINS,@WERKS,@W_NAME1,@ZSOURCE,@ZSOURCED,@ZTRATYP,@ZTRATYPD,@KUNNR,@KUNNR_N,@KUNAG,";
                                query += "@KUNAG_N,@PTNR,@PTNR_N,@SALSREP,@SALSREP_N,@REGIO,@REGIO_N,@DSTRC,@DSTRC_N,@BLOCK,@BLOCK_N,@DESTINT,";
                                query += "@DESTINT_N,@KDGRP,@KTEXT,@PRIMARY_FRT,@SECONDRY_FRT,@RAKNO,@RAKPT,@MATKL,@LGORT,@LGOBE,@INCO1,@INCO2,@ULDG_CHGS,";
                                query += "@TRNS_CHGS,@DPUL_CHGS,@DPLD_CHGS,@DIVR_CHGS,@LDNG_CHGS,@CFAG_CHGS,@RKSR_CHGS,@PULD_CHGS,@RKCL_CHGS,@SHNT_CHGS,@RKCF_CHGS,";
                                query += "@BLND_CHGS,@BLNB_CHGS,@MISC_MISC,@ZZZONE1,@ZZZONE1_N,@ZZBZIRK,@ZZBZIRK_N,@ZZREGIO,@ZZREGIO_N,@VKBUR,@VKBUR_N,@VKGRP,@VKGRP_N,";
                                query += "@ZZBRANCH,@ZZBRANCH_N,@PDSTN,@SDSTN,@BLOCK_CT,@BELNR,@GJAHR,@INV_TYPE,@FRT_TYPE,@ZZVLFKZ,@SUPP_PLANT_NAME,@DEPO_RK_MVT,@IND_PRI_FRT,";
                                query += "@SHIP_FRT_CHRGS,@SHIP_HAND_CHRGS,@CLKMNFPLANT,@SUPPPLANT,@DISTANCE,@INDPDISTANCE,@CLK_PLT_NAME,@MNF_PLT_NAME,@GEIND_PLT,@GEIND_PLT_NAME,@SUPPL_DEPO,@SUPPL_DEPO_NAME,";
                                query += "@WAERK,@RENT,@RAKEDEMCHRG,@LDISTANCE,@LDISTANCE_CLK,@MATNR,@VTEXT,@MATNR1,@MAKTX,@INCURREDCOST,";
                                query += "@UNINCURREDCOST,@SH_REGIO,@SH_DSTRC,@SH_BLOCK,@SH_DESTINT,@KALKS,@DELIVERY_NO,@TKNUM,@MNFPLANT,@MNFDESC,@MVGR1,@GROSSTURN,@NETTURN,";
                                query += "@NAKEDREAL,@TRANS_INCENTIVE,@PLT_FRT,@SP_REGIO,@SP_DSTRC,@SP_BLOCK,@SP_DESTINT,@TRAID,@TRUCK_TYPE,@EWB_NO,@EDATE,@EVDATE,@STEUC,";
                                query += "@PAID_PRICE,@KALKS_DESC,@SP_REGIO_DESC,@SP_DSTRC_DESC,@SP_BLOCK_DESC,@SP_DESTINT_DESC,@MF_PLANT_TYPE,@TOTAL_TDC_COST,@TOTAL_DISTANCE,@DEPOT_IND_FRIEGHT,@TOTAL_INVOICE_FRT,";
                                query += "@ROAD_PF_INCURRED,@ROAD_PF_UNINCURRED,@ROAD_SF_INCURRED,@ROAD_SF_UNINCURRED,@RAIL_PF_INCURRED,@RAIL_PF_UNINCURRED,@DRDL_CHGS,@DB_LAB_CHGS,@ZINV_CANCEL,@SH_DESTINT_DESC,@SHIP_DISTANCE);";
                                MySqlCommand cmd = new MySqlCommand(query, con);

                                cmd.Parameters.AddWithValue("@VBELN", row["VBELN"].ToString());
                                cmd.Parameters.AddWithValue("@FKART", row["FKART"].ToString());
                                cmd.Parameters.AddWithValue("@FKDAT", row["FKDAT"].ToString());
                                cmd.Parameters.AddWithValue("@FKIMG", row["FKIMG"].ToString());
                                cmd.Parameters.AddWithValue("@MEINS", row["MEINS"].ToString());
                                cmd.Parameters.AddWithValue("@WERKS", row["WERKS"].ToString());

                                cmd.Parameters.AddWithValue("@W_NAME1", row["WNAME1"].ToString());
                                cmd.Parameters.AddWithValue("@ZSOURCE", row["ZSOURCE"].ToString());
                                cmd.Parameters.AddWithValue("@ZSOURCED", row["ZSOURCED"].ToString());
                                cmd.Parameters.AddWithValue("@ZTRATYP", row["ZTRATYP"].ToString());
                                cmd.Parameters.AddWithValue("@ZTRATYPD", row["ZTRATYPD"].ToString());
                                cmd.Parameters.AddWithValue("@KUNNR", row["KUNNR"].ToString());
                                cmd.Parameters.AddWithValue("@KUNNR_N", row["KUNNRN"].ToString());
                                cmd.Parameters.AddWithValue("@KUNAG", row["KUNAG"].ToString());
                                cmd.Parameters.AddWithValue("@KUNAG_N", row["KUNAGN"].ToString());
                                cmd.Parameters.AddWithValue("@PTNR", row["PTNR"].ToString());
                                cmd.Parameters.AddWithValue("@PTNR_N", row["PTNRN"].ToString());
                                cmd.Parameters.AddWithValue("@SALSREP", row["SALSREP"].ToString());
                                cmd.Parameters.AddWithValue("@SALSREP_N", row["SALSREPN"].ToString());
                                cmd.Parameters.AddWithValue("@REGIO", row["REGIO"].ToString());
                                cmd.Parameters.AddWithValue("@REGIO_N", row["REGION"].ToString());
                                cmd.Parameters.AddWithValue("@DSTRC", row["DSTRC"].ToString());
                                cmd.Parameters.AddWithValue("@DSTRC_N", row["DSTRCN"].ToString());
                                cmd.Parameters.AddWithValue("@BLOCK", row["BLOCK"].ToString());
                                cmd.Parameters.AddWithValue("@BLOCK_N", row["BLOCKN"].ToString());
                                cmd.Parameters.AddWithValue("@DESTINT", row["DESTINT"].ToString());
                                cmd.Parameters.AddWithValue("@DESTINT_N", row["DESTINTN"].ToString());
                                cmd.Parameters.AddWithValue("@KDGRP", row["KDGRP"].ToString());
                                cmd.Parameters.AddWithValue("@KTEXT", row["KTEXT"].ToString());
                                cmd.Parameters.AddWithValue("@PRIMARY_FRT", row["PRIMARYFRT"].ToString());
                                cmd.Parameters.AddWithValue("@SECONDRY_FRT", row["SECONDRYFRT"].ToString());
                                cmd.Parameters.AddWithValue("@RAKNO", row["RAKNO"].ToString());
                                cmd.Parameters.AddWithValue("@RAKPT", row["RAKPT"].ToString());
                                cmd.Parameters.AddWithValue("@MATKL", row["MATKL"].ToString());
                                cmd.Parameters.AddWithValue("@LGORT", row["LGORT"].ToString());
                                cmd.Parameters.AddWithValue("@LGOBE", row["LGOBE"].ToString());
                                cmd.Parameters.AddWithValue("@INCO1", row["INCO1"].ToString());
                                cmd.Parameters.AddWithValue("@INCO2", row["INCO2"].ToString());
                                cmd.Parameters.AddWithValue("@ULDG_CHGS", row["ULDGCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@TRNS_CHGS", row["TRNSCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@DPUL_CHGS", row["DPULCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@DPLD_CHGS", row["DPLDCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@DIVR_CHGS", row["DIVRCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@LDNG_CHGS", row["LDNGCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@CFAG_CHGS", row["CFAGCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@RKSR_CHGS", row["RKSRCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@PULD_CHGS", row["PULDCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@RKCL_CHGS", row["RKCLCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@SHNT_CHGS", row["SHNTCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@RKCF_CHGS", row["RKCFCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@BLND_CHGS", row["BLNDCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@BLNB_CHGS", row["BLNBCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@MISC_MISC", row["MISCMISC"].ToString());
                                cmd.Parameters.AddWithValue("@ZZZONE1", row["ZZZONE1"].ToString());
                                cmd.Parameters.AddWithValue("@ZZZONE1_N", row["ZZZONE1N"].ToString());
                                cmd.Parameters.AddWithValue("@ZZBZIRK", row["ZZBZIRK"].ToString());
                                cmd.Parameters.AddWithValue("@ZZBZIRK_N", row["ZZBZIRKN"].ToString());
                                cmd.Parameters.AddWithValue("@ZZREGIO", row["ZZREGIO"].ToString());
                                cmd.Parameters.AddWithValue("@ZZREGIO_N", row["ZZREGION"].ToString());
                                cmd.Parameters.AddWithValue("@VKBUR", row["VKBUR"].ToString());
                                cmd.Parameters.AddWithValue("@VKBUR_N", row["VKBURN"].ToString());
                                cmd.Parameters.AddWithValue("@VKGRP", row["VKGRP"].ToString());
                                cmd.Parameters.AddWithValue("@VKGRP_N", row["VKGRPN"].ToString());
                                cmd.Parameters.AddWithValue("@ZZBRANCH", row["ZZBRANCH"].ToString());
                                cmd.Parameters.AddWithValue("@ZZBRANCH_N", row["ZZBRANCHN"].ToString());
                                cmd.Parameters.AddWithValue("@PDSTN", row["PDSTN"].ToString());
                                cmd.Parameters.AddWithValue("@SDSTN", row["SDSTN"].ToString());
                                cmd.Parameters.AddWithValue("@BLOCK_CT", row["BLOCKCT"].ToString());
                                cmd.Parameters.AddWithValue("@BELNR", row["BELNR"].ToString());
                                cmd.Parameters.AddWithValue("@GJAHR", row["GJAHR"].ToString());
                                cmd.Parameters.AddWithValue("@INV_TYPE", row["INVTYPE"].ToString());
                                cmd.Parameters.AddWithValue("@FRT_TYPE", row["FRTTYPE"].ToString());
                                cmd.Parameters.AddWithValue("@ZZVLFKZ", row["ZZVLFKZ"].ToString());
                                cmd.Parameters.AddWithValue("@SUPP_PLANT_NAME", row["SUPPPLANTNAME"].ToString());
                                cmd.Parameters.AddWithValue("@DEPO_RK_MVT", row["DEPORKMVT"].ToString());
                                cmd.Parameters.AddWithValue("@IND_PRI_FRT", row["INDPRIFRT"].ToString());

                                cmd.Parameters.AddWithValue("@SHIP_FRT_CHRGS", row["SHIPFRTCHRGS"].ToString());
                                cmd.Parameters.AddWithValue("@SHIP_HAND_CHRGS", row["SHIPHANDCHRGS"].ToString());
                                cmd.Parameters.AddWithValue("@CLKMNFPLANT", row["CLKMNFPLANT"].ToString());
                                cmd.Parameters.AddWithValue("@SUPPPLANT", row["SUPPPLANT"].ToString());
                                cmd.Parameters.AddWithValue("@DISTANCE", row["DISTANCE"].ToString());
                                cmd.Parameters.AddWithValue("@INDPDISTANCE", row["INDPDISTANCE"].ToString());
                                cmd.Parameters.AddWithValue("@CLK_PLT_NAME", row["CLKPLTNAME"].ToString());
                                cmd.Parameters.AddWithValue("@MNF_PLT_NAME", row["MNFPLTNAME"].ToString());
                                cmd.Parameters.AddWithValue("@GEIND_PLT", row["GEINDPLT"].ToString());
                                cmd.Parameters.AddWithValue("@GEIND_PLT_NAME", row["GEINDPLTNAME"].ToString());
                                cmd.Parameters.AddWithValue("@SUPPL_DEPO", row["SUPPLDEPO"].ToString());
                                cmd.Parameters.AddWithValue("@SUPPL_DEPO_NAME", row["SUPPLDEPONAME"].ToString());
                                cmd.Parameters.AddWithValue("@WAERK", row["WAERK"].ToString());
                                cmd.Parameters.AddWithValue("@RENT", row["RENT"].ToString());
                                cmd.Parameters.AddWithValue("@RAKEDEMCHRG", row["RAKEDEMCHRG"].ToString());
                                cmd.Parameters.AddWithValue("@LDISTANCE", row["LDISTANCE"].ToString());
                                cmd.Parameters.AddWithValue("@LDISTANCE_CLK", row["LDISTANCECLK"].ToString());
                                cmd.Parameters.AddWithValue("@MATNR", row["MATNR"].ToString());
                                cmd.Parameters.AddWithValue("@VTEXT", row["VTEXT"].ToString());
                                cmd.Parameters.AddWithValue("@MATNR1", row["MATNR1"].ToString());
                                cmd.Parameters.AddWithValue("@MAKTX", row["MAKTX"].ToString());
                                cmd.Parameters.AddWithValue("@INCURREDCOST", row["INCURREDCOST"].ToString());
                                cmd.Parameters.AddWithValue("@UNINCURREDCOST", row["UNINCURREDCOST"].ToString());
                                cmd.Parameters.AddWithValue("@SH_REGIO", row["SHREGIO"].ToString());
                                cmd.Parameters.AddWithValue("@SH_DSTRC", row["SHDSTRC"].ToString());
                                cmd.Parameters.AddWithValue("@SH_BLOCK", row["SHBLOCK"].ToString());
                                cmd.Parameters.AddWithValue("@SH_DESTINT", row["SHDESTINT"].ToString());
                                cmd.Parameters.AddWithValue("@KALKS", row["KALKS"].ToString());
                                cmd.Parameters.AddWithValue("@DELIVERY_NO", row["DELIVERYNO"].ToString());
                                cmd.Parameters.AddWithValue("@TKNUM", row["TKNUM"].ToString());
                                cmd.Parameters.AddWithValue("@MNFPLANT", row["MNFPLANT"].ToString());
                                cmd.Parameters.AddWithValue("@MNFDESC", row["MNFDESC"].ToString());
                                cmd.Parameters.AddWithValue("@MVGR1", row["MVGR1"].ToString());
                                cmd.Parameters.AddWithValue("@GROSSTURN", row["GROSSTURN"].ToString());
                                cmd.Parameters.AddWithValue("@NETTURN", row["NETTURN"].ToString());
                                cmd.Parameters.AddWithValue("@NAKEDREAL", row["NAKEDREAL"].ToString());
                                cmd.Parameters.AddWithValue("@TRANS_INCENTIVE", row["TRANSINCENTIVE"].ToString());
                                cmd.Parameters.AddWithValue("@PLT_FRT", row["PLTFRT"].ToString());
                                cmd.Parameters.AddWithValue("@SP_REGIO", row["SPREGIO"].ToString());
                                cmd.Parameters.AddWithValue("@SP_DSTRC", row["SPDSTRC"].ToString());
                                cmd.Parameters.AddWithValue("@SP_BLOCK", row["SPBLOCK"].ToString());
                                cmd.Parameters.AddWithValue("@SP_DESTINT", row["SPDESTINT"].ToString());
                                cmd.Parameters.AddWithValue("@TRAID", row["TRAID"].ToString());
                                cmd.Parameters.AddWithValue("@TRUCK_TYPE", row["TRUCKTYPE"].ToString());
                                cmd.Parameters.AddWithValue("@EWB_NO", row["EWBNO"].ToString());
                                cmd.Parameters.AddWithValue("@EDATE", row["EDATE"].ToString());
                                cmd.Parameters.AddWithValue("@EVDATE", row["EVDATE"].ToString());
                                cmd.Parameters.AddWithValue("@STEUC", row["STEUC"].ToString());
                                cmd.Parameters.AddWithValue("@PAID_PRICE", row["PAIDPRICE"].ToString());
                                cmd.Parameters.AddWithValue("@KALKS_DESC", row["KALKSDESC"].ToString());
                                cmd.Parameters.AddWithValue("@SP_REGIO_DESC", row["SPREGIODESC"].ToString());
                                cmd.Parameters.AddWithValue("@SP_DSTRC_DESC", row["SPDSTRCDESC"].ToString());
                                cmd.Parameters.AddWithValue("@SP_BLOCK_DESC", row["SPBLOCKDESC"].ToString());
                                cmd.Parameters.AddWithValue("@SP_DESTINT_DESC", row["SPDESTINTDESC"].ToString());
                                cmd.Parameters.AddWithValue("@MF_PLANT_TYPE", row["TOTALTDCCOST"].ToString());

                                cmd.Parameters.AddWithValue("@TOTAL_TDC_COST", row["TOTALTDCCOST"].ToString());

                                cmd.Parameters.AddWithValue("@TOTAL_DISTANCE", row["TOTALDISTANCE"].ToString());
                                cmd.Parameters.AddWithValue("@DEPOT_IND_FRIEGHT", row["DEPOTINDFRIEGHT"].ToString());
                                cmd.Parameters.AddWithValue("@TOTAL_INVOICE_FRT", row["TOTALINVOICEFRT"].ToString());
                                cmd.Parameters.AddWithValue("@ROAD_PF_INCURRED", row["ROADPFINCURRED"].ToString());
                                cmd.Parameters.AddWithValue("@ROAD_PF_UNINCURRED", row["ROADPFUNINCURRED"].ToString());
                                cmd.Parameters.AddWithValue("@ROAD_SF_INCURRED", row["ROADSFINCURRED"].ToString());
                                cmd.Parameters.AddWithValue("@ROAD_SF_UNINCURRED", row["ROADSFUNINCURRED"].ToString());
                                cmd.Parameters.AddWithValue("@RAIL_PF_INCURRED", row["RAILPFINCURRED"].ToString());
                                cmd.Parameters.AddWithValue("@RAIL_PF_UNINCURRED", row["RAILPFUNINCURRED"].ToString());
                                cmd.Parameters.AddWithValue("@DRDL_CHGS", row["DRDLCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@DB_LAB_CHGS", row["DBLABCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@ZINV_CANCEL", row["ZINVCANCEL"].ToString());
                                cmd.Parameters.AddWithValue("@SH_DESTINT_DESC", row["SHDESTINTDESC"].ToString());
                                cmd.Parameters.AddWithValue("@SHIP_DISTANCE", row["SHIPDISTANCE"].ToString());

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
                        query = " Select Count(*) from ZSD_LCOST_DATA_SRV ";
                        query += " where date_format(cast(Fkdat as date),'%Y%m%d') ";
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
                            query = " Delete from ZSD_LCOST_DATA_SRV ";
                            query += " where date_format(cast(Fkdat as date),'%Y%m%d') ";
                            query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";

                            using (MySqlConnection sqlCon = new MySqlConnection(CS))
                            {
                                sqlCon.Open();
                                MySqlCommand Cmnd = new MySqlCommand(query, sqlCon);

                                int result = Cmnd.ExecuteNonQuery();

                                sqlCon.Close();
                            }

                            query = "";
                            query += " Select Count(*) Cnt from ZSD_LCOST_DATA_SRV ";
                            query += " where date_format(cast(Fkdat as date),'%Y%m%d') ";
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
                    // Import_Data imp = new Import_Data();
                    //imp.Insert_ZSD_LCOST_DATA_SRV(startDate, endDate);
                    //Insert_ZSD_LCOST_DATA_SRV(startDate, endDate);
                }


                //Maxid = 19;
                if (InputID == "I" || InputID == "S")
                {


                    using (MySqlConnection con = new MySqlConnection(CS))
                    {
                        query = " Select * from ZSD_LCOST_DATA_SRV ";
                        query += " where date_format(cast(Fkdat as date),'%Y%m%d') ";
                        query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";
                        query += " order by date_format(cast(Fkdat as date),'%Y%m%d') ";
                        using (MySqlCommand cmd = new MySqlCommand(query))
                        {

                            cmd.Connection = con;
                            con.Open();
                            using (MySqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    lstsrvdeal.Add(new ZSD_LCOST_DATA_SRV
                                    {
                                        Vbeln = Convert.ToString(sdr["VBELN"]),
                                        Fkart = Convert.ToString(sdr["FKART"]),
                                        Fkdat = Convert.ToString(sdr["FKDAT"]),
                                        Fkimg = Convert.ToDecimal(sdr["FKIMG"]),
                                        Meins = Convert.ToString(sdr["MEINS"]),
                                        Werks = Convert.ToString(sdr["WERKS"]),
                                        WName1 = Convert.ToString(sdr["W_NAME1"]),
                                        Zsource = Convert.ToString(sdr["ZSOURCE"]),
                                        Zsourced = Convert.ToString(sdr["ZSOURCED"]),
                                        Ztratyp = Convert.ToString(sdr["ZTRATYP"]),
                                        Ztratypd = Convert.ToString(sdr["ZTRATYPD"]),
                                        Kunnr = Convert.ToString(sdr["KUNNR"]),
                                        KunnrN = Convert.ToString(sdr["KUNNR_N"]),
                                        Kunag = Convert.ToString(sdr["KUNAG"]),
                                        KunagN = Convert.ToString(sdr["KUNAG_N"]),
                                        Ptnr = Convert.ToString(sdr["PTNR"]),
                                        PtnrN = Convert.ToString(sdr["PTNR_N"]),
                                        Salsrep = Convert.ToString(sdr["SALSREP"]),
                                        SalsrepN = Convert.ToString(sdr["SALSREP_N"]),
                                        Regio = Convert.ToString(sdr["REGIO"]),
                                        RegioN = Convert.ToString(sdr["REGIO_N"]),
                                        Dstrc = Convert.ToString(sdr["DSTRC"]),
                                        DstrcN = Convert.ToString(sdr["DSTRC_N"]),
                                        Block = Convert.ToString(sdr["BLOCK"]),
                                        BlockN = Convert.ToString(sdr["BLOCK_N"]),
                                        Destint = Convert.ToString(sdr["DESTINT"]),
                                        DestintN = Convert.ToString(sdr["DESTINT_N"]),
                                        Kdgrp = Convert.ToString(sdr["KDGRP"]),
                                        Ktext = Convert.ToString(sdr["KTEXT"]),
                                        PrimaryFrt = Convert.ToDecimal(sdr["PRIMARY_FRT"]),
                                        SecondryFrt = Convert.ToDecimal(sdr["SECONDRY_FRT"]),
                                        Rakno = Convert.ToString(sdr["RAKNO"]),
                                        Rakpt = Convert.ToString(sdr["RAKPT"]),
                                        Matkl = Convert.ToString(sdr["MATKL"]),
                                        Lgort = Convert.ToString(sdr["LGORT"]),
                                        Lgobe = Convert.ToString(sdr["LGOBE"]),
                                        Inco1 = Convert.ToString(sdr["INCO1"]),
                                        Inco2 = Convert.ToString(sdr["INCO2"]),
                                        UldgChgs = Convert.ToDecimal(sdr["ULDG_CHGS"]),
                                        TrnsChgs = Convert.ToDecimal(sdr["TRNS_CHGS"]),
                                        DpulChgs = Convert.ToDecimal(sdr["DPUL_CHGS"]),
                                        DpldChgs = Convert.ToDecimal(sdr["DPLD_CHGS"]),
                                        DivrChgs = Convert.ToDecimal(sdr["DIVR_CHGS"]),
                                        LdngChgs = Convert.ToDecimal(sdr["LDNG_CHGS"]),
                                        CfagChgs = Convert.ToDecimal(sdr["CFAG_CHGS"]),
                                        RksrChgs = Convert.ToDecimal(sdr["RKSR_CHGS"]),
                                        PuldChgs = Convert.ToDecimal(sdr["PULD_CHGS"]),
                                        RkclChgs = Convert.ToDecimal(sdr["RKCL_CHGS"]),
                                        ShntChgs = Convert.ToDecimal(sdr["SHNT_CHGS"]),
                                        RkcfChgs = Convert.ToDecimal(sdr["RKCF_CHGS"]),
                                        BlndChgs = Convert.ToDecimal(sdr["BLND_CHGS"]),
                                        BlnbChgs = Convert.ToDecimal(sdr["BLNB_CHGS"]),
                                        MiscMisc = Convert.ToDecimal(sdr["MISC_MISC"]),
                                        Zzzone1 = Convert.ToString(sdr["ZZZONE1"]),
                                        Zzzone1N = Convert.ToString(sdr["ZZZONE1_N"]),
                                        Zzbzirk = Convert.ToString(sdr["ZZBZIRK"]),
                                        ZzbzirkN = Convert.ToString(sdr["ZZBZIRK_N"]),
                                        Zzregio = Convert.ToString(sdr["ZZREGIO"]),
                                        ZzregioN = Convert.ToString(sdr["ZZREGIO_N"]),
                                        Vkbur = Convert.ToString(sdr["VKBUR"]),
                                        VkburN = Convert.ToString(sdr["VKBUR_N"]),
                                        Vkgrp = Convert.ToString(sdr["VKGRP"]),
                                        VkgrpN = Convert.ToString(sdr["VKGRP_N"]),
                                        Zzbranch = Convert.ToString(sdr["ZZBRANCH"]),
                                        ZzbranchN = Convert.ToString(sdr["ZZBRANCH_N"]),
                                        Pdstn = Convert.ToDecimal(sdr["PDSTN"]),
                                        Sdstn = Convert.ToDecimal(sdr["SDSTN"]),
                                        BlockCt = Convert.ToString(sdr["BLOCK_CT"]),
                                        Belnr = Convert.ToString(sdr["BELNR"]),
                                        Gjahr = Convert.ToString(sdr["GJAHR"]),
                                        InvType = Convert.ToString(sdr["INV_TYPE"]),
                                        FrtType = Convert.ToString(sdr["FRT_TYPE"]),
                                        Zzvlfkz = Convert.ToString(sdr["ZZVLFKZ"]),
                                        SuppPlantName = Convert.ToString(sdr["SUPP_PLANT_NAME"]),
                                        DepoRkMvt = Convert.ToString(sdr["DEPO_RK_MVT"]),
                                        IndPriFrt = Convert.ToDecimal(sdr["IND_PRI_FRT"]),
                                        ShipFrtChrgs = Convert.ToDecimal(sdr["SHIP_FRT_CHRGS"]),
                                        ShipHandChrgs = Convert.ToDecimal(sdr["SHIP_HAND_CHRGS"]),
                                        Clkmnfplant = Convert.ToString(sdr["CLKMNFPLANT"]),
                                        Suppplant = Convert.ToString(sdr["SUPPPLANT"]),
                                        Distance = Convert.ToDecimal(sdr["DISTANCE"]),
                                        Indpdistance = Convert.ToDecimal(sdr["INDPDISTANCE"]),
                                        ClkPltName = Convert.ToString(sdr["CLK_PLT_NAME"]),
                                        MnfPltName = Convert.ToString(sdr["MNF_PLT_NAME"]),
                                        GeindPlt = Convert.ToString(sdr["GEIND_PLT"]),
                                        GeindPltName = Convert.ToString(sdr["GEIND_PLT_NAME"]),
                                        SupplDepo = Convert.ToString(sdr["SUPPL_DEPO"]),
                                        SupplDepoName = Convert.ToString(sdr["SUPPL_DEPO_NAME"]),
                                        Waerk = Convert.ToString(sdr["WAERK"]),
                                        Rent = Convert.ToDecimal(sdr["RENT"]),
                                        Rakedemchrg = Convert.ToDecimal(sdr["RAKEDEMCHRG"]),
                                        Ldistance = Convert.ToDecimal(sdr["LDISTANCE"]),
                                        LdistanceClk = Convert.ToDecimal(sdr["LDISTANCE_CLK"]),
                                        Matnr = Convert.ToString(sdr["MATNR"]),
                                        Vtext = Convert.ToString(sdr["VTEXT"]),
                                        Matnr1 = Convert.ToString(sdr["MATNR1"]),
                                        Maktx = Convert.ToString(sdr["MAKTX"]),
                                        Incurredcost = Convert.ToDecimal(sdr["INCURREDCOST"]),
                                        Unincurredcost = Convert.ToDecimal(sdr["UNINCURREDCOST"]),
                                        ShRegio = Convert.ToString(sdr["SH_REGIO"]),
                                        ShDstrc = Convert.ToString(sdr["SH_DSTRC"]),
                                        ShBlock = Convert.ToString(sdr["SH_BLOCK"]),
                                        ShDestint = Convert.ToString(sdr["SH_DESTINT"]),
                                        Kalks = Convert.ToString(sdr["KALKS"]),
                                        DeliveryNo = Convert.ToString(sdr["DELIVERY_NO"]),
                                        Tknum = Convert.ToString(sdr["TKNUM"]),
                                        Mnfplant = Convert.ToString(sdr["MNFPLANT"]),
                                        Mnfdesc = Convert.ToString(sdr["MNFDESC"]),
                                        Mvgr1 = Convert.ToString(sdr["MVGR1"]),
                                        Grossturn = Convert.ToDecimal(sdr["GROSSTURN"]),
                                        Netturn = Convert.ToDecimal(sdr["NETTURN"]),
                                        Nakedreal = Convert.ToDecimal(sdr["NAKEDREAL"]),
                                        TransIncentive = Convert.ToDecimal(sdr["TRANS_INCENTIVE"]),
                                        PltFrt = Convert.ToDecimal(sdr["PLT_FRT"]),
                                        SpRegio = Convert.ToString(sdr["SP_REGIO"]),
                                        SpDstrc = Convert.ToString(sdr["SP_DSTRC"]),
                                        SpBlock = Convert.ToString(sdr["SP_BLOCK"]),
                                        SpDestint = Convert.ToString(sdr["SP_DESTINT"]),
                                        Traid = Convert.ToString(sdr["TRAID"]),
                                        TruckType = Convert.ToString(sdr["TRUCK_TYPE"]),
                                        EwbNo = Convert.ToString(sdr["EWB_NO"]),
                                        Edate = Convert.ToString(sdr["EDATE"]),
                                        Evdate = Convert.ToString(sdr["EVDATE"]),
                                        Steuc = Convert.ToString(sdr["STEUC"]),
                                        PaidPrice = Convert.ToDecimal(sdr["PAID_PRICE"]),
                                        KalksDesc = Convert.ToString(sdr["KALKS_DESC"]),
                                        SpRegioDesc = Convert.ToString(sdr["SP_REGIO_DESC"]),
                                        SpDstrcDesc = Convert.ToString(sdr["SP_DSTRC_DESC"]),
                                        SpBlockDesc = Convert.ToString(sdr["SP_BLOCK_DESC"]),
                                        SpDestintDesc = Convert.ToString(sdr["SP_DESTINT_DESC"]),
                                        MfPlantType = Convert.ToString(sdr["MF_PLANT_TYPE"]),
                                        TotalTdcCost = Convert.ToDecimal(sdr["TOTAL_TDC_COST"]),
                                        TotalDistance = Convert.ToDecimal(sdr["TOTAL_DISTANCE"]),
                                        DepotIndFrieght = Convert.ToDecimal(sdr["DEPOT_IND_FRIEGHT"]),
                                        TotalInvoiceFrt = Convert.ToDecimal(sdr["TOTAL_INVOICE_FRT"]),
                                        RoadPfIncurred = Convert.ToDecimal(sdr["ROAD_PF_INCURRED"]),
                                        RoadPfUnincurred = Convert.ToDecimal(sdr["ROAD_PF_UNINCURRED"]),
                                        RoadSfIncurred = Convert.ToDecimal(sdr["ROAD_SF_INCURRED"]),
                                        RoadSfUnincurred = Convert.ToDecimal(sdr["ROAD_SF_UNINCURRED"]),
                                        RailPfIncurred = Convert.ToDecimal(sdr["RAIL_PF_INCURRED"]),
                                        RailPfUnincurred = Convert.ToDecimal(sdr["RAIL_PF_UNINCURRED"]),
                                        DrdlChgs = Convert.ToDecimal(sdr["DRDL_CHGS"]),
                                        DbLabChgs = Convert.ToDecimal(sdr["DB_LAB_CHGS"]),
                                        ZinvCancel = Convert.ToString(sdr["ZINV_CANCEL"]),
                                        ShDestintDesc = Convert.ToString(sdr["SH_DESTINT_DESC"]),
                                        ShipDistance = Convert.ToDecimal(sdr["SHIP_DISTANCE"]),


                                    });
                                }
                            }
                            con.Close();
                        }
                    }
                }
                if (InputID == "E")
                {
                    DataTable dt1 = new DataTable("ZSD_LCOST_DATA_SRV");
                    dt1.Columns.AddRange(new DataColumn[146]
                    {
                        new DataColumn("Billing Document"),
                        new DataColumn("Billing Type"),
                        new DataColumn("Billing Date"),
                        new DataColumn("Billed quantity"),
                        new DataColumn("Base Unit of Measure"),
                        new DataColumn("Plant"),
                        new DataColumn("Plant Description"),
                        new DataColumn("Source"),
                        new DataColumn("Source Description"),
                        new DataColumn("Movement Type"),
                        new DataColumn("Movement Description"),
                        new DataColumn("Ship-To Party"),
                        new DataColumn("Ship to party Name"),
                        new DataColumn("Sold-To Party"),
                        new DataColumn("Sold-To Party Name"),
                        new DataColumn("Transporter ID"),
                        new DataColumn("Transporter ID Name "),
                        new DataColumn("Sales Rep code"),
                        new DataColumn("Sales Rep Name 1"),
                        new DataColumn("State"),
                        new DataColumn("State Description"),
                        new DataColumn("District"),
                        new DataColumn("District Description"),
                        new DataColumn("Block"),
                        new DataColumn("Block Description"),
                        new DataColumn("Destination"),
                        new DataColumn("Destination Description"),
                        new DataColumn("Customer group Code"),
                        new DataColumn("Customer group Name"),
                        new DataColumn("Primary Frieght"),
                        new DataColumn("Secondary Frieght"),
                        new DataColumn("Rake No"),
                        new DataColumn("Rake Point"),
                        new DataColumn("Material Group"),
                        new DataColumn("Storage Location"),
                        new DataColumn("Storage Location Description"),
                        new DataColumn("Incoterms1"),
                        new DataColumn("Incoterms 2"),
                        new DataColumn("Unloading Charges"),
                        new DataColumn("Transshipment Charges"),
                        new DataColumn("Depot Unloading charges"),
                        new DataColumn("Depot Loading charges"),
                        new DataColumn("BLK CFA Charges"),
                        new DataColumn("Loading Charges"),
                        new DataColumn("C&F Agent Service Charges"),
                        new DataColumn("Railway Service Charge"),
                        new DataColumn("Party side Unloading Charges"),
                        new DataColumn("Rake Clearing Charges"),
                        new DataColumn("Shunting Charges"),
                        new DataColumn("Rake CFA Charges"),
                        new DataColumn("Blended A Charges"),
                        new DataColumn("Blended B Charges"),
                        new DataColumn("Misc Charges"),
                        new DataColumn("Transportation zone "),
                        new DataColumn("Transportation zone description"),
                        new DataColumn("Sales District"),
                        new DataColumn("Sales District Description"),
                        new DataColumn("Region code"),
                        new DataColumn("Region Description"),
                        new DataColumn("Sales Office"),
                        new DataColumn("Sales Office Description"),
                        new DataColumn("Sales Group"),
                        new DataColumn("Sales Group Description"),
                        new DataColumn("Branch Office"),
                        new DataColumn("Branch Office Description"),
                        new DataColumn("Primary Distance"),
                        new DataColumn("Secondary Distance"),
                        new DataColumn("Block Category"),
                        new DataColumn("Accounting Document Number"),
                        new DataColumn("Fiscal Year"),
                        new DataColumn("Invoice Type"),
                        new DataColumn("Freight Type"),
                        new DataColumn("Plant category"),
                        new DataColumn("Supplying Plant Name"),
                        new DataColumn("Depot Rake movement"),
                        new DataColumn("Indirect Primary Frieght"),
                        new DataColumn("Ship Frieght"),
                        new DataColumn("Ship Handling Charges"),
                        new DataColumn("Clinker Plant"),
                        new DataColumn("Supplying Plant"),
                        new DataColumn("Clinker Distance"),
                        new DataColumn("Indirect Primary Distance"),
                        new DataColumn("Clinker Plant name "),
                        new DataColumn("Manufacturing Plant Name"),
                        new DataColumn("Grinding unit plant code"),
                        new DataColumn("Grinding unit plant Name"),
                        new DataColumn("Supplying Depot"),
                        new DataColumn("Supplying Depot Name"),
                        new DataColumn("SD Document Currency"),
                        new DataColumn("Rent Per MT"),
                        new DataColumn("Rake Demurage Charges"),
                        new DataColumn("Lead Distance Without Clinkcer KM"),
                        new DataColumn("Lead Distance With Clinkcer KM"),
                        new DataColumn("Material Code"),
                        new DataColumn("Material Description"),
                        new DataColumn("Empty bags Material Code"),
                        new DataColumn("Empty bags Material Description"),
                        new DataColumn("Incurred Cost"),
                        new DataColumn("Unincurred Cost"),
                        new DataColumn("Ship to party Region"),
                        new DataColumn("Ship to party District"),
                        new DataColumn("Ship to party Block"),
                        new DataColumn("Ship to partyDestination"),
                        new DataColumn("Pricing procedure"),
                        new DataColumn("Delivery"),
                        new DataColumn("Shipment Number"),
                        new DataColumn("Manufacturing Plant"),
                        new DataColumn("Manufacturing Plant Description"),
                        new DataColumn("Material group_1"),
                        new DataColumn("Gross Turnover"),
                        new DataColumn("Net Turnover"),
                        new DataColumn("Net Value in Document Currency"),
                        new DataColumn("Transport Incentive"),
                        new DataColumn("Net Value in Document Currency_1"),
                        new DataColumn("Sold to Party Region"),
                        new DataColumn("Sold to Party District"),
                        new DataColumn("Sold to Party Block"),
                        new DataColumn("Sold to Party Destination"),
                        new DataColumn("Means of Transport ID"),
                        new DataColumn("Truck Type"),
                        new DataColumn("E-Waybill Number"),
                        new DataColumn("E-Waybill date"),
                        new DataColumn("E-WayBill Valid Till Date"),
                        new DataColumn("HSN Code"),
                        new DataColumn("Paid Price"),
                        new DataColumn("Description"),
                        new DataColumn("Sold to Party Region Description"),
                        new DataColumn("Sold to Party District Description"),
                        new DataColumn("Sold to Party Block Description"),
                        new DataColumn("Sold to Party Destination Description"),
                        new DataColumn("Manufacturing Plant Type"),
                        new DataColumn("TDC Cost"),
                        new DataColumn("Total Distance"),
                        new DataColumn("Depot In-direct primary frieght"),
                        new DataColumn("Total Invoice Frieght"),
                        new DataColumn("Road Primary frieght Incurred"),
                        new DataColumn("Road Primary frieght unIncurred"),
                        new DataColumn("Road Secondary frieght Incurred"),
                        new DataColumn("Road Secondary frieght unIncurred"),
                        new DataColumn("Rail Primary Frieght Incurred"),
                        new DataColumn("Rail Primary Frieght unIncurred"),
                        new DataColumn("Direct Delivery charges"),
                        new DataColumn("Double Labour Charges"),
                        new DataColumn("Invoice cancellation flag"),
                        new DataColumn("Ship to party Destination Description"),
                        new DataColumn("Ship Distance")


                     });

                    using (MySqlConnection con = new MySqlConnection(CS))
                    {
                        query = " Select * from ZSD_LCOST_DATA_SRV ";
                        query += " where date_format(cast(Fkdat as date),'%Y%m%d') ";
                        query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";
                        query += " order by date_format(cast(Fkdat as date),'%Y%m%d') ";
                        using (MySqlCommand cmd = new MySqlCommand(query))
                        {

                            cmd.Connection = con;
                            con.Open();
                            using (MySqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    DataRow _dr = dt1.NewRow();


                                    _dr["Billing Document"] = Convert.ToString(sdr["VBELN"]);
                                    _dr["Billing Type"] = Convert.ToString(sdr["FKART"]);
                                    _dr["Billing Date"] = Convert.ToString(sdr["FKDAT"]);
                                    _dr["Billed quantity"] = Convert.ToDecimal(sdr["FKIMG"]);
                                    _dr["Base Unit of Measure"] = Convert.ToString(sdr["MEINS"]);
                                    _dr["Plant"] = Convert.ToString(sdr["WERKS"]);
                                    _dr["Plant Description"] = Convert.ToString(sdr["W_NAME1"]);
                                    _dr["Source"] = Convert.ToString(sdr["ZSOURCE"]);
                                    _dr["Source Description"] = Convert.ToString(sdr["ZSOURCED"]);
                                    _dr["Movement Type"] = Convert.ToString(sdr["ZTRATYP"]);
                                    _dr["Movement Description"] = Convert.ToString(sdr["ZTRATYPD"]);
                                    _dr["Ship-To Party"] = Convert.ToString(sdr["KUNNR"]);
                                    _dr["Ship to party Name"] = Convert.ToString(sdr["KUNNR_N"]);
                                    _dr["Sold-To Party"] = Convert.ToString(sdr["KUNAG"]);
                                    _dr["Sold-To Party Name"] = Convert.ToString(sdr["KUNAG_N"]);
                                    _dr["Transporter ID"] = Convert.ToString(sdr["PTNR"]);
                                    _dr["Transporter ID Name "] = Convert.ToString(sdr["PTNR_N"]);
                                    _dr["Sales Rep code"] = Convert.ToString(sdr["SALSREP"]);
                                    _dr["Sales Rep Name 1"] = Convert.ToString(sdr["SALSREP_N"]);
                                    _dr["State"] = Convert.ToString(sdr["REGIO"]);
                                    _dr["State Description"] = Convert.ToString(sdr["REGIO_N"]);
                                    _dr["District"] = Convert.ToString(sdr["DSTRC"]);
                                    _dr["District Description"] = Convert.ToString(sdr["DSTRC_N"]);
                                    _dr["Block"] = Convert.ToString(sdr["BLOCK"]);
                                    _dr["Block Description"] = Convert.ToString(sdr["BLOCK_N"]);
                                    _dr["Destination"] = Convert.ToString(sdr["DESTINT"]);
                                    _dr["Destination Description"] = Convert.ToString(sdr["DESTINT_N"]);
                                    _dr["Customer group Code"] = Convert.ToString(sdr["KDGRP"]);
                                    _dr["Customer group Name"] = Convert.ToString(sdr["KTEXT"]);
                                    _dr["Primary Frieght"] = Convert.ToDecimal(sdr["PRIMARY_FRT"]);
                                    _dr["Secondary Frieght"] = Convert.ToDecimal(sdr["SECONDRY_FRT"]);
                                    _dr["Rake No"] = Convert.ToString(sdr["RAKNO"]);
                                    _dr["Rake Point"] = Convert.ToString(sdr["RAKPT"]);
                                    _dr["Material Group"] = Convert.ToString(sdr["MATKL"]);
                                    _dr["Storage Location"] = Convert.ToString(sdr["LGORT"]);
                                    _dr["Storage Location Description"] = Convert.ToString(sdr["LGOBE"]);
                                    _dr["Incoterms1"] = Convert.ToString(sdr["INCO1"]);
                                    _dr["Incoterms 2"] = Convert.ToString(sdr["INCO2"]);
                                    _dr["Unloading Charges"] = Convert.ToDecimal(sdr["ULDG_CHGS"]);
                                    _dr["Transshipment Charges"] = Convert.ToDecimal(sdr["TRNS_CHGS"]);
                                    _dr["Depot Unloading charges"] = Convert.ToDecimal(sdr["DPUL_CHGS"]);
                                    _dr["Depot Loading charges"] = Convert.ToDecimal(sdr["DPLD_CHGS"]);
                                    _dr["BLK CFA Charges"] = Convert.ToDecimal(sdr["DIVR_CHGS"]);
                                    _dr["Loading Charges"] = Convert.ToDecimal(sdr["LDNG_CHGS"]);
                                    _dr["C&F Agent Service Charges"] = Convert.ToDecimal(sdr["CFAG_CHGS"]);
                                    _dr["Railway Service Charge"] = Convert.ToDecimal(sdr["RKSR_CHGS"]);
                                    _dr["Party side Unloading Charges"] = Convert.ToDecimal(sdr["PULD_CHGS"]);
                                    _dr["Rake Clearing Charges"] = Convert.ToDecimal(sdr["RKCL_CHGS"]);
                                    _dr["Shunting Charges"] = Convert.ToDecimal(sdr["SHNT_CHGS"]);
                                    _dr["Rake CFA Charges"] = Convert.ToDecimal(sdr["RKCF_CHGS"]);
                                    _dr["Blended A Charges"] = Convert.ToDecimal(sdr["BLND_CHGS"]);
                                    _dr["Blended B Charges"] = Convert.ToDecimal(sdr["BLNB_CHGS"]);
                                    _dr["Misc Charges"] = Convert.ToDecimal(sdr["MISC_MISC"]);
                                    _dr["Transportation zone "] = Convert.ToString(sdr["ZZZONE1"]);
                                    _dr["Transportation zone description"] = Convert.ToString(sdr["ZZZONE1_N"]);
                                    _dr["Sales District"] = Convert.ToString(sdr["ZZBZIRK"]);
                                    _dr["Sales District Description"] = Convert.ToString(sdr["ZZBZIRK_N"]);
                                    _dr["Region code"] = Convert.ToString(sdr["ZZREGIO"]);
                                    _dr["Region Description"] = Convert.ToString(sdr["ZZREGIO_N"]);
                                    _dr["Sales Office"] = Convert.ToString(sdr["VKBUR"]);
                                    _dr["Sales Office Description"] = Convert.ToString(sdr["VKBUR_N"]);
                                    _dr["Sales Group"] = Convert.ToString(sdr["VKGRP"]);
                                    _dr["Sales Group Description"] = Convert.ToString(sdr["VKGRP_N"]);
                                    _dr["Branch Office"] = Convert.ToString(sdr["ZZBRANCH"]);
                                    _dr["Branch Office Description"] = Convert.ToString(sdr["ZZBRANCH_N"]);
                                    _dr["Primary Distance"] = Convert.ToDecimal(sdr["PDSTN"]);
                                    _dr["Secondary Distance"] = Convert.ToDecimal(sdr["SDSTN"]);
                                    _dr["Block Category"] = Convert.ToString(sdr["BLOCK_CT"]);
                                    _dr["Accounting Document Number"] = Convert.ToString(sdr["BELNR"]);
                                    _dr["Fiscal Year"] = Convert.ToString(sdr["GJAHR"]);
                                    _dr["Invoice Type"] = Convert.ToString(sdr["INV_TYPE"]);
                                    _dr["Freight Type"] = Convert.ToString(sdr["FRT_TYPE"]);
                                    _dr["Plant category"] = Convert.ToString(sdr["ZZVLFKZ"]);
                                    _dr["Supplying Plant Name"] = Convert.ToString(sdr["SUPP_PLANT_NAME"]);
                                    _dr["Depot Rake movement"] = Convert.ToString(sdr["DEPO_RK_MVT"]);
                                    _dr["Indirect Primary Frieght"] = Convert.ToDecimal(sdr["IND_PRI_FRT"]);
                                    _dr["Ship Frieght"] = Convert.ToDecimal(sdr["SHIP_FRT_CHRGS"]);
                                    _dr["Ship Handling Charges"] = Convert.ToDecimal(sdr["SHIP_HAND_CHRGS"]);
                                    _dr["Clinker Plant"] = Convert.ToString(sdr["CLKMNFPLANT"]);
                                    _dr["Supplying Plant"] = Convert.ToString(sdr["SUPPPLANT"]);
                                    _dr["Clinker Distance"] = Convert.ToDecimal(sdr["DISTANCE"]);
                                    _dr["Indirect Primary Distance"] = Convert.ToDecimal(sdr["INDPDISTANCE"]);
                                    _dr["Clinker Plant name "] = Convert.ToString(sdr["CLK_PLT_NAME"]);
                                    _dr["Manufacturing Plant Name"] = Convert.ToString(sdr["MNF_PLT_NAME"]);
                                    _dr["Grinding unit plant code"] = Convert.ToString(sdr["GEIND_PLT"]);
                                    _dr["Grinding unit plant Name"] = Convert.ToString(sdr["GEIND_PLT_NAME"]);
                                    _dr["Supplying Depot"] = Convert.ToString(sdr["SUPPL_DEPO"]);
                                    _dr["Supplying Depot Name"] = Convert.ToString(sdr["SUPPL_DEPO_NAME"]);
                                    _dr["SD Document Currency"] = Convert.ToString(sdr["WAERK"]);
                                    _dr["Rent Per MT"] = Convert.ToDecimal(sdr["RENT"]);
                                    _dr["Rake Demurage Charges"] = Convert.ToDecimal(sdr["RAKEDEMCHRG"]);
                                    _dr["Lead Distance Without Clinkcer KM"] = Convert.ToDecimal(sdr["LDISTANCE"]);
                                    _dr["Lead Distance With Clinkcer KM"] = Convert.ToDecimal(sdr["LDISTANCE_CLK"]);
                                    _dr["Material Code"] = Convert.ToString(sdr["MATNR"]);
                                    _dr["Material Description"] = Convert.ToString(sdr["VTEXT"]);
                                    _dr["Empty bags Material Code"] = Convert.ToString(sdr["MATNR1"]);
                                    _dr["Empty bags Material Description"] = Convert.ToString(sdr["MAKTX"]);
                                    _dr["Incurred Cost"] = Convert.ToDecimal(sdr["INCURREDCOST"]);
                                    _dr["Unincurred Cost"] = Convert.ToDecimal(sdr["UNINCURREDCOST"]);
                                    _dr["Ship to party Region"] = Convert.ToString(sdr["SH_REGIO"]);
                                    _dr["Ship to party District"] = Convert.ToString(sdr["SH_DSTRC"]);
                                    _dr["Ship to party Block"] = Convert.ToString(sdr["SH_BLOCK"]);
                                    _dr["Ship to partyDestination"] = Convert.ToString(sdr["SH_DESTINT"]);
                                    _dr["Pricing procedure"] = Convert.ToString(sdr["KALKS"]);
                                    _dr["Delivery"] = Convert.ToString(sdr["DELIVERY_NO"]);
                                    _dr["Shipment Number"] = Convert.ToString(sdr["TKNUM"]);
                                    _dr["Manufacturing Plant"] = Convert.ToString(sdr["MNFPLANT"]);
                                    _dr["Manufacturing Plant Description"] = Convert.ToString(sdr["MNFDESC"]);
                                    _dr["Material group_1"] = Convert.ToString(sdr["MVGR1"]);
                                    _dr["Gross Turnover"] = Convert.ToDecimal(sdr["GROSSTURN"]);
                                    _dr["Net Turnover"] = Convert.ToDecimal(sdr["NETTURN"]);
                                    _dr["Net Value in Document Currency"] = Convert.ToDecimal(sdr["NAKEDREAL"]);
                                    _dr["Transport Incentive"] = Convert.ToDecimal(sdr["TRANS_INCENTIVE"]);
                                    _dr["Net Value in Document Currency_1"] = Convert.ToDecimal(sdr["PLT_FRT"]);
                                    _dr["Sold to Party Region"] = Convert.ToString(sdr["SP_REGIO"]);
                                    _dr["Sold to Party District"] = Convert.ToString(sdr["SP_DSTRC"]);
                                    _dr["Sold to Party Block"] = Convert.ToString(sdr["SP_BLOCK"]);
                                    _dr["Sold to Party Destination"] = Convert.ToString(sdr["SP_DESTINT"]);
                                    _dr["Means of Transport ID"] = Convert.ToString(sdr["TRAID"]);
                                    _dr["Truck Type"] = Convert.ToString(sdr["TRUCK_TYPE"]);
                                    _dr["E-Waybill Number"] = Convert.ToString(sdr["EWB_NO"]);
                                    _dr["E-Waybill date"] = Convert.ToString(sdr["EDATE"]);
                                    _dr["E-WayBill Valid Till Date"] = Convert.ToString(sdr["EVDATE"]);
                                    _dr["HSN Code"] = Convert.ToString(sdr["STEUC"]);
                                    _dr["Paid Price"] = Convert.ToDecimal(sdr["PAID_PRICE"]);
                                    _dr["Description"] = Convert.ToString(sdr["KALKS_DESC"]);
                                    _dr["Sold to Party Region Description"] = Convert.ToString(sdr["SP_REGIO_DESC"]);
                                    _dr["Sold to Party District Description"] = Convert.ToString(sdr["SP_DSTRC_DESC"]);
                                    _dr["Sold to Party Block Description"] = Convert.ToString(sdr["SP_BLOCK_DESC"]);
                                    _dr["Sold to Party Destination Description"] = Convert.ToString(sdr["SP_DESTINT_DESC"]);
                                    _dr["Manufacturing Plant Type"] = Convert.ToString(sdr["MF_PLANT_TYPE"]);
                                    _dr["TDC Cost"] = Convert.ToDecimal(sdr["TOTAL_TDC_COST"]);
                                    _dr["Total Distance"] = Convert.ToDecimal(sdr["TOTAL_DISTANCE"]);
                                    _dr["Depot In-direct primary frieght"] = Convert.ToDecimal(sdr["DEPOT_IND_FRIEGHT"]);
                                    _dr["Total Invoice Frieght"] = Convert.ToDecimal(sdr["TOTAL_INVOICE_FRT"]);
                                    _dr["Road Primary frieght Incurred"] = Convert.ToDecimal(sdr["ROAD_PF_INCURRED"]);
                                    _dr["Road Primary frieght unIncurred"] = Convert.ToDecimal(sdr["ROAD_PF_UNINCURRED"]);
                                    _dr["Road Secondary frieght Incurred"] = Convert.ToDecimal(sdr["ROAD_SF_INCURRED"]);
                                    _dr["Road Secondary frieght unIncurred"] = Convert.ToDecimal(sdr["ROAD_SF_UNINCURRED"]);
                                    _dr["Rail Primary Frieght Incurred"] = Convert.ToDecimal(sdr["RAIL_PF_INCURRED"]);
                                    _dr["Rail Primary Frieght unIncurred"] = Convert.ToDecimal(sdr["RAIL_PF_UNINCURRED"]);
                                    _dr["Direct Delivery charges"] = Convert.ToDecimal(sdr["DRDL_CHGS"]);
                                    _dr["Double Labour Charges"] = Convert.ToDecimal(sdr["DB_LAB_CHGS"]);
                                    _dr["Invoice cancellation flag"] = Convert.ToString(sdr["ZINV_CANCEL"]);
                                    _dr["Ship to party Destination Description"] = Convert.ToString(sdr["SH_DESTINT_DESC"]);
                                    _dr["Ship Distance"] = Convert.ToDecimal(sdr["SHIP_DISTANCE"]);

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
                            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ZSD_LCOST_DATA_SRV.xlsx");
                        }
                    }
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
                log1.WriteLine("ZSD_LCOST_DATA_SRV Error Message : " + ex.Message);
                log1.WriteLine("===========================================");
                log1.Close();


                return View();


            }


        }

        public void Insert_YREALIZATION(string startDate, string endDate)
        {
            //StreamWriter log1;
            try
            {
                log1.WriteLine("===========================================");
                log1.WriteLine("Application From Date  " + startDate);
                log1.WriteLine("Application To Date  " + endDate);

                string filename = System.Configuration.ConfigurationManager.AppSettings["LogFile"].ToString();

                if (!System.IO.File.Exists(filename))
                {
                    log1 = new StreamWriter(filename, append: true);
                }
                else
                {
                    log1 = System.IO.File.AppendText(filename);
                }

                log1.WriteLine("Executed on : " + DateTime.Now);


                var url = "";
                string query = "";
                int reccount = 0;
                List<ZSD_REAL_DATA_SRV_REAL> lstsrvdeal = new List<ZSD_REAL_DATA_SRV_REAL>();

                var formats = new[] { "ddMMyyyy", "yyyyMMdd", "yyyyMMdd" };


                url = "https://netwaver-dev.pennacement.com:443/sap/opu/odata/sap/ZSD_REAL_DATA_SRV/REALSet?$format=json&$filter=Erdat ge '" + startDate.Trim() + "' and Erdat le '" + endDate.Trim() + "'";
                string userName = "NWGW001";
                string passwd = "Penna@123";

                log1.WriteLine("Insert Table : YREALIZATION");

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
                    List<ZSD_REAL_DATA_SRV_REAL> varoutput = men1.ToObject<List<ZSD_REAL_DATA_SRV_REAL>>();
                    var o = JsonConvert.DeserializeObject<List<ZSD_REAL_DATA_SRV_REAL>>(men1.ToString());

                    Common converter = new Common();


                    DataTable dt = converter.ToDataTable(varoutput);

                    if (dt.Rows.Count > 0)
                    {
                        log1.WriteLine("WebApi Record Count : " + dt.Rows.Count);
                    }
                    else
                    {
                        log1.WriteLine("WebApi Record Count : 0");
                    }

                    query = "";
                    query += " Delete from YREALIZATION ";
                    query += " where date_format(cast(erdat as date),'%Y%m%d') ";
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

                            query = "Insert into YREALIZATION(VBELN,VGBEL,AUBEL,ERDAT,FKART,REGIO,VKGRP,DSTRC,MNFPLANT,PLANT,GRADE,MATKL,KALKS,KDGRP,";
                            query += "FKDAT,MATNR,CUSTCODE1,CNAME1,CUSTCODE2,CNAME2,CUSTCODE3,CNAME3,COM_AG,COM_NAME,TRANS,TRANS_NAME,";
                            query += "LGORT,LGOBE,FKIMG,GROSSTURN,INCO1,INCO2,STPRS,PRIMARYFRI,SECONDARYFRI,EXWPF,EXGSF,SALESTAX,COMMISSION,";
                            query += "EXCISEDUTY,PDDISCOUNT,ODDISCOUNT,CFCHARGES,CDDISCOUNT,PACKING,UNLOADING,OCTRAI,VAT,IGST,CGST,";
                            query += "SGST,UGST,EXP_HAND,TRANSPORT,AMT_DW_FRT,PLT_FRT,NETTURN,NAKEDREAL,STATEDESC,SGRPDESC,DISDESC,GRADDESC,MNFDESC,";
                            query += "PLANTDESC,PGRPDESC,CDATE,TIME,SUSER,BLOCK_CT,ROUTE,CANCELDATE,CANCELFLAG,ZZLGORT1,BZIRK,VKBUR,ZZZONE1,";
                            query += "ZZBRANCH,PERNR_ER,ENAME_ER,PERNR_Y1,ENAME_Y1,PERNR_Y2,ENAME_Y2,PERNR_Y3,ENAME_Y3,PERNR_Y4,ENAME_Y4,PERNR_Y5,";
                            query += "ENAME_Y5,PERNR_Y6,ENAME_Y6,PERNR_Y7,ENAME_Y7,PERNR_Y8,ENAME_Y8,UPFRNT_DISCOUNT,IND_PRI_FRT,SHIP_FRT_CHRGS,";
                            query += "SHIP_HAND_CHRGS,ZCUST_GRP,ZCUST_GRP_DESC,Vc,ZsalePromValue,Waers,Msehi,PayFreight,ExFreight) Values ";
                            query += "(@VBELN,@VGBEL,@AUBEL,@ERDAT,@FKART,@REGIO,@VKGRP,@DSTRC,@MNFPLANT,@PLANT,@GRADE,@MATKL,@KALKS,@KDGRP,";
                            query += "@FKDAT,@MATNR,@CUSTCODE1,@CNAME1,@CUSTCODE2,@CNAME2,@CUSTCODE3,@CNAME3,@COM_AG,@COM_NAME,@TRANS,@TRANS_NAME,";
                            query += "@LGORT,@LGOBE,@FKIMG,@GROSSTURN,@INCO1,@INCO2,@STPRS,@PRIMARYFRI,@SECONDARYFRI,@EXWPF,@EXGSF,@SALESTAX,@COMMISSION,";
                            query += "@EXCISEDUTY,@PDDISCOUNT,@ODDISCOUNT,@CFCHARGES,@CDDISCOUNT,@PACKING,@UNLOADING,@OCTRAI,@VAT,@IGST,@CGST,";
                            query += "@SGST,@UGST,@EXP_HAND,@TRANSPORT,@AMT_DW_FRT,@PLT_FRT,@NETTURN,@NAKEDREAL,@STATEDESC,@SGRPDESC,@DISDESC,@GRADDESC,@MNFDESC,";
                            query += "@PLANTDESC,@PGRPDESC,@CDATE,@TIME,@SUSER,@BLOCK_CT,@ROUTE,@CANCELDATE,@CANCELFLAG,@ZZLGORT1,@BZIRK,@VKBUR,@ZZZONE1,";
                            query += "@ZZBRANCH,@PERNR_ER,@ENAME_ER,@PERNR_Y1,@ENAME_Y1,@PERNR_Y2,@ENAME_Y2,@PERNR_Y3,@ENAME_Y3,@PERNR_Y4,@ENAME_Y4,@PERNR_Y5,";
                            query += "@ENAME_Y5,@PERNR_Y6,@ENAME_Y6,@PERNR_Y7,@ENAME_Y7,@PERNR_Y8,@ENAME_Y8,@UPFRNT_DISCOUNT,@IND_PRI_FRT,@SHIP_FRT_CHRGS,";
                            query += "@SHIP_HAND_CHRGS,@ZCUST_GRP,@ZCUST_GRP_DESC,@Vc,@ZsalePromValue,@Waers,@Msehi,@PayFreight,@ExFreight);";
                            MySqlCommand cmd = new MySqlCommand(query, con);

                            cmd.Parameters.AddWithValue("@VBELN", row["VBELN"].ToString());
                            cmd.Parameters.AddWithValue("@VGBEL", row["VGBEL"].ToString());
                            cmd.Parameters.AddWithValue("@AUBEL", row["AUBEL"].ToString());
                            cmd.Parameters.AddWithValue("@ERDAT", row["ERDAT"].ToString());
                            cmd.Parameters.AddWithValue("@FKART", row["FKART"].ToString());
                            cmd.Parameters.AddWithValue("@REGIO", row["REGIO"].ToString());
                            cmd.Parameters.AddWithValue("@VKGRP", row["VKGRP"].ToString());
                            cmd.Parameters.AddWithValue("@DSTRC", row["DSTRC"].ToString());
                            cmd.Parameters.AddWithValue("@MNFPLANT", row["MNFPLANT"].ToString());
                            cmd.Parameters.AddWithValue("@PLANT", row["PLANT"].ToString());
                            cmd.Parameters.AddWithValue("@GRADE", row["GRADE"].ToString());
                            cmd.Parameters.AddWithValue("@MATKL", row["MATKL"].ToString());
                            cmd.Parameters.AddWithValue("@KALKS", row["KALKS"].ToString());
                            cmd.Parameters.AddWithValue("@KDGRP", row["KDGRP"].ToString());
                            cmd.Parameters.AddWithValue("@FKDAT", row["FKDAT"].ToString());
                            cmd.Parameters.AddWithValue("@MATNR", row["MATNR"].ToString());
                            cmd.Parameters.AddWithValue("@CUSTCODE1", row["CUSTCODE1"].ToString());
                            cmd.Parameters.AddWithValue("@CNAME1", row["CNAME1"].ToString());
                            cmd.Parameters.AddWithValue("@CUSTCODE2", row["CUSTCODE2"].ToString());
                            cmd.Parameters.AddWithValue("@CNAME2", row["CNAME2"].ToString());
                            cmd.Parameters.AddWithValue("@CUSTCODE3", row["CUSTCODE3"].ToString());
                            cmd.Parameters.AddWithValue("@CNAME3", row["CNAME3"].ToString());
                            cmd.Parameters.AddWithValue("@COM_AG", row["COMAG"].ToString());
                            cmd.Parameters.AddWithValue("@COM_NAME", row["COMNAME"].ToString());
                            cmd.Parameters.AddWithValue("@TRANS", row["TRANS"].ToString());
                            cmd.Parameters.AddWithValue("@TRANS_NAME", row["TRANSNAME"].ToString());
                            cmd.Parameters.AddWithValue("@LGORT", row["LGORT"].ToString());
                            cmd.Parameters.AddWithValue("@LGOBE", row["LGOBE"].ToString());
                            cmd.Parameters.AddWithValue("@FKIMG", row["FKIMG"].ToString());
                            cmd.Parameters.AddWithValue("@GROSSTURN", row["GROSSTURN"].ToString());
                            cmd.Parameters.AddWithValue("@INCO1", row["INCO1"].ToString());
                            cmd.Parameters.AddWithValue("@INCO2", row["INCO2"].ToString());
                            cmd.Parameters.AddWithValue("@STPRS", row["STPRS"].ToString());
                            cmd.Parameters.AddWithValue("@PRIMARYFRI", row["PRIMARYFRI"].ToString());
                            cmd.Parameters.AddWithValue("@SECONDARYFRI", row["SECONDARYFRI"].ToString());
                            cmd.Parameters.AddWithValue("@EXWPF", row["EXWPF"].ToString());
                            cmd.Parameters.AddWithValue("@EXGSF", row["EXGSF"].ToString());
                            cmd.Parameters.AddWithValue("@SALESTAX", row["SALESTAX"].ToString());
                            cmd.Parameters.AddWithValue("@COMMISSION", row["COMMISSION"].ToString());
                            cmd.Parameters.AddWithValue("@EXCISEDUTY", row["EXCISEDUTY"].ToString());
                            cmd.Parameters.AddWithValue("@PDDISCOUNT", row["PDDISCOUNT"].ToString());
                            cmd.Parameters.AddWithValue("@ODDISCOUNT", row["ODDISCOUNT"].ToString());
                            cmd.Parameters.AddWithValue("@CFCHARGES", row["CFCHARGES"].ToString());
                            cmd.Parameters.AddWithValue("@CDDISCOUNT", row["CDDISCOUNT"].ToString());
                            cmd.Parameters.AddWithValue("@PACKING", row["PACKING"].ToString());
                            cmd.Parameters.AddWithValue("@UNLOADING", row["UNLOADING"].ToString());
                            cmd.Parameters.AddWithValue("@OCTRAI", row["OCTRAI"].ToString());
                            cmd.Parameters.AddWithValue("@VAT", row["VAT"].ToString());
                            cmd.Parameters.AddWithValue("@IGST", row["IGST"].ToString());
                            cmd.Parameters.AddWithValue("@CGST", row["CGST"].ToString());
                            cmd.Parameters.AddWithValue("@SGST", row["SGST"].ToString());
                            cmd.Parameters.AddWithValue("@UGST", row["UGST"].ToString());
                            cmd.Parameters.AddWithValue("@EXP_HAND", row["EXPHAND"].ToString());
                            cmd.Parameters.AddWithValue("@TRANSPORT", row["TRANSPORT"].ToString());
                            cmd.Parameters.AddWithValue("@AMT_DW_FRT", row["AMTDWFRT"].ToString());
                            cmd.Parameters.AddWithValue("@PLT_FRT", row["PLTFRT"].ToString());
                            cmd.Parameters.AddWithValue("@NETTURN", row["NETTURN"].ToString());
                            cmd.Parameters.AddWithValue("@NAKEDREAL", row["NAKEDREAL"].ToString());
                            cmd.Parameters.AddWithValue("@STATEDESC", row["STATEDESC"].ToString());
                            cmd.Parameters.AddWithValue("@SGRPDESC", row["SGRPDESC"].ToString());
                            cmd.Parameters.AddWithValue("@DISDESC", row["DISDESC"].ToString());
                            cmd.Parameters.AddWithValue("@GRADDESC", row["GRADDESC"].ToString());
                            cmd.Parameters.AddWithValue("@MNFDESC", row["MNFDESC"].ToString());
                            cmd.Parameters.AddWithValue("@PLANTDESC", row["PLANTDESC"].ToString());
                            cmd.Parameters.AddWithValue("@PGRPDESC", row["PGRPDESC"].ToString());
                            cmd.Parameters.AddWithValue("@CDATE", row["CDATE"].ToString());
                            cmd.Parameters.AddWithValue("@TIME", row["TIME"].ToString());
                            cmd.Parameters.AddWithValue("@SUSER", row["SUSER"].ToString());
                            cmd.Parameters.AddWithValue("@BLOCK_CT", row["BLOCKCT"].ToString());
                            cmd.Parameters.AddWithValue("@ROUTE", row["ROUTE"].ToString());
                            cmd.Parameters.AddWithValue("@CANCELDATE", row["CANCELDATE"].ToString());
                            cmd.Parameters.AddWithValue("@CANCELFLAG", row["CANCELFLAG"].ToString());
                            cmd.Parameters.AddWithValue("@ZZLGORT1", row["ZZLGORT1"].ToString());
                            cmd.Parameters.AddWithValue("@BZIRK", row["BZIRK"].ToString());
                            cmd.Parameters.AddWithValue("@VKBUR", row["VKBUR"].ToString());
                            cmd.Parameters.AddWithValue("@ZZZONE1", row["ZZZONE1"].ToString());
                            cmd.Parameters.AddWithValue("@ZZBRANCH", row["ZZBRANCH"].ToString());
                            cmd.Parameters.AddWithValue("@PERNR_ER", row["PERNRER"].ToString());
                            cmd.Parameters.AddWithValue("@ENAME_ER", row["ENAMEER"].ToString());
                            cmd.Parameters.AddWithValue("@PERNR_Y1", row["PERNRY1"].ToString());
                            cmd.Parameters.AddWithValue("@ENAME_Y1", row["ENAMEY1"].ToString());
                            cmd.Parameters.AddWithValue("@PERNR_Y2", row["PERNRY2"].ToString());
                            cmd.Parameters.AddWithValue("@ENAME_Y2", row["ENAMEY2"].ToString());
                            cmd.Parameters.AddWithValue("@PERNR_Y3", row["PERNRY3"].ToString());
                            cmd.Parameters.AddWithValue("@ENAME_Y3", row["ENAMEY3"].ToString());
                            cmd.Parameters.AddWithValue("@PERNR_Y4", row["PERNRY4"].ToString());
                            cmd.Parameters.AddWithValue("@ENAME_Y4", row["ENAMEY4"].ToString());
                            cmd.Parameters.AddWithValue("@PERNR_Y5", row["PERNRY5"].ToString());
                            cmd.Parameters.AddWithValue("@ENAME_Y5", row["ENAMEY5"].ToString());
                            cmd.Parameters.AddWithValue("@PERNR_Y6", row["PERNRY6"].ToString());
                            cmd.Parameters.AddWithValue("@ENAME_Y6", row["ENAMEY6"].ToString());
                            cmd.Parameters.AddWithValue("@PERNR_Y7", row["PERNRY7"].ToString());
                            cmd.Parameters.AddWithValue("@ENAME_Y7", row["ENAMEY7"].ToString());
                            cmd.Parameters.AddWithValue("@PERNR_Y8", row["PERNRY8"].ToString());
                            cmd.Parameters.AddWithValue("@ENAME_Y8", row["ENAMEY8"].ToString());
                            cmd.Parameters.AddWithValue("@UPFRNT_DISCOUNT", row["UPFRNTDISCOUNT"].ToString());
                            cmd.Parameters.AddWithValue("@IND_PRI_FRT", row["INDPRIFRT"].ToString());
                            cmd.Parameters.AddWithValue("@SHIP_FRT_CHRGS", row["SHIPFRTCHRGS"].ToString());
                            cmd.Parameters.AddWithValue("@SHIP_HAND_CHRGS", row["SHIPHANDCHRGS"].ToString());
                            cmd.Parameters.AddWithValue("@ZCUST_GRP", row["ZCUSTGRP"].ToString());
                            cmd.Parameters.AddWithValue("@ZCUST_GRP_DESC", row["ZCUSTGRPDESC"].ToString());
                            cmd.Parameters.AddWithValue("@Vc", row["Vc"].ToString());
                            cmd.Parameters.AddWithValue("@ZsalePromValue", row["ZsalePromValue"].ToString());
                            cmd.Parameters.AddWithValue("@Waers", row["Waers"].ToString());
                            cmd.Parameters.AddWithValue("@Msehi", row["Msehi"].ToString());
                            cmd.Parameters.AddWithValue("@PayFreight", row["PayFreight"].ToString());
                            cmd.Parameters.AddWithValue("@ExFreight", row["ExFreight"].ToString());

                            cmd.CommandType = CommandType.Text;

                            int result = cmd.ExecuteNonQuery();

                            if (result == 1)
                            {
                                i = i + 1;
                            }

                        }

                    }


                    query = "";
                    query += " Select Count(*) Cnt from YREALIZATION ";
                    query += " where date_format(cast(erdat as date),'%Y%m%d') ";
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
                        query += " Delete from YREALIZATION ";
                        query += " where date_format(cast(erdat as date),'%Y%m%d') ";
                        query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";

                        using (MySqlConnection sqlCon = new MySqlConnection(CS))
                        {
                            sqlCon.Open();
                            MySqlCommand Cmnd = new MySqlCommand(query, sqlCon);

                            int result = Cmnd.ExecuteNonQuery();

                            sqlCon.Close();
                        }


                        query = "";
                        query += " Select Count(*) Cnt from YREALIZATION ";
                        query += " where date_format(cast(erdat as date),'%Y%m%d') ";
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



            }
            catch (Exception ex)
            {
                log1.WriteLine("YREALIZATION Error Message : " + ex.Message);
                log1.Close();
            }
            log1.Close();
        }

        public void Insert_ZSD_LCOST_DATA_SRV(string startDate, string endDate)
        {
            try
            {
                log1.WriteLine("===========================================");
                log1.WriteLine("Application From Date  " + startDate);
                log1.WriteLine("Application To Date  " + endDate);

                string filename = System.Configuration.ConfigurationManager.AppSettings["LogFile"].ToString();

                if (!System.IO.File.Exists(filename))
                {
                    log1 = new StreamWriter(filename, append: true);
                }
                else
                {
                    log1 = System.IO.File.AppendText(filename);
                }

                log1.WriteLine("Executed on : " + DateTime.Now);

                string query = "";
                int reccount = 0;
                List<ZSD_LCOST_DATA_SRV> lstsrvdeal = new List<ZSD_LCOST_DATA_SRV>();

                var formats = new[] { "ddMMyyyy", "yyyyMMdd", "yyyyMMdd" };


                string startDateOrig = startDate;
                string endDateOrig = endDate;
                startDate = DateTime.ParseExact(startDate, "yyyyMMdd", null).ToString("yyyyMMdd");
                endDate = DateTime.ParseExact(endDate, "yyyyMMdd", null).ToString("yyyyMMdd");


                var url = "https://netwaver-dev.pennacement.com:443/sap/opu/odata/sap/ZSD_LCOST_DATA_SRV/LOGI_COSTSet?$format=json&$filter=Fkdat ge '" + startDateOrig.Trim() + "' and Fkdat le '" + endDateOrig.Trim() + "'";
                string userName = "NWGW001";
                string passwd = "Penna@123";

                log1.WriteLine("Insert Table : ZSD_LCOST_DATA_SRV");

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
                    List<ZSD_LCOST_DATA_SRV> varoutput = men1.ToObject<List<ZSD_LCOST_DATA_SRV>>();
                    var o = JsonConvert.DeserializeObject<List<ZSD_LCOST_DATA_SRV>>(men1.ToString());

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
                    query = " Delete from ZSD_LCOST_DATA_SRV ";
                    query += " where date_format(cast(Fkdat as date),'%Y%m%d') ";
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
                            //flag = false;
                            query = "Insert into ZSD_LCOST_DATA_SRV(VBELN,FKART,FKDAT,FKIMG,MEINS,WERKS,W_NAME1,ZSOURCE,ZSOURCED,ZTRATYP,ZTRATYPD,KUNNR,KUNNR_N,KUNAG,";
                            query += "KUNAG_N,PTNR,PTNR_N,SALSREP,SALSREP_N,REGIO,REGIO_N,DSTRC,DSTRC_N,BLOCK,BLOCK_N,DESTINT,";
                            query += "DESTINT_N,KDGRP,KTEXT,PRIMARY_FRT,SECONDRY_FRT,RAKNO,RAKPT,MATKL,LGORT,LGOBE,INCO1,INCO2,ULDG_CHGS,";
                            query += "TRNS_CHGS,DPUL_CHGS,DPLD_CHGS,DIVR_CHGS,LDNG_CHGS,CFAG_CHGS,RKSR_CHGS,PULD_CHGS,RKCL_CHGS,SHNT_CHGS,RKCF_CHGS,";
                            query += "BLND_CHGS,BLNB_CHGS,MISC_MISC,ZZZONE1,ZZZONE1_N,ZZBZIRK,ZZBZIRK_N,ZZREGIO,ZZREGIO_N,VKBUR,VKBUR_N,VKGRP,VKGRP_N,";
                            query += "ZZBRANCH,ZZBRANCH_N,PDSTN,SDSTN,BLOCK_CT,BELNR,GJAHR,INV_TYPE,FRT_TYPE,ZZVLFKZ,SUPP_PLANT_NAME,DEPO_RK_MVT,IND_PRI_FRT,";
                            query += "SHIP_FRT_CHRGS,SHIP_HAND_CHRGS,CLKMNFPLANT,SUPPPLANT,DISTANCE,INDPDISTANCE,CLK_PLT_NAME,MNF_PLT_NAME,GEIND_PLT,GEIND_PLT_NAME,SUPPL_DEPO,SUPPL_DEPO_NAME,";
                            query += "WAERK,RENT,RAKEDEMCHRG,LDISTANCE,LDISTANCE_CLK,MATNR,VTEXT,MATNR1,MAKTX,INCURREDCOST,";
                            query += "UNINCURREDCOST,SH_REGIO,SH_DSTRC,SH_BLOCK,SH_DESTINT,KALKS,DELIVERY_NO,TKNUM,MNFPLANT,MNFDESC,MVGR1,GROSSTURN,NETTURN,";
                            query += "NAKEDREAL,TRANS_INCENTIVE,PLT_FRT,SP_REGIO,SP_DSTRC,SP_BLOCK,SP_DESTINT,TRAID,TRUCK_TYPE,EWB_NO,EDATE,EVDATE,STEUC,";
                            query += "PAID_PRICE,KALKS_DESC,SP_REGIO_DESC, SP_DSTRC_DESC,SP_BLOCK_DESC,SP_DESTINT_DESC,MF_PLANT_TYPE,TOTAL_TDC_COST,TOTAL_DISTANCE,DEPOT_IND_FRIEGHT,TOTAL_INVOICE_FRT,";
                            query += "ROAD_PF_INCURRED,ROAD_PF_UNINCURRED,ROAD_SF_INCURRED,ROAD_SF_UNINCURRED,RAIL_PF_INCURRED,RAIL_PF_UNINCURRED,DRDL_CHGS,DB_LAB_CHGS,ZINV_CANCEL,SH_DESTINT_DESC,SHIP_DISTANCE ) Values ";
                            query += "(@VBELN,@FKART,@FKDAT,@FKIMG,@MEINS,@WERKS,@W_NAME1,@ZSOURCE,@ZSOURCED,@ZTRATYP,@ZTRATYPD,@KUNNR,@KUNNR_N,@KUNAG,";
                            query += "@KUNAG_N,@PTNR,@PTNR_N,@SALSREP,@SALSREP_N,@REGIO,@REGIO_N,@DSTRC,@DSTRC_N,@BLOCK,@BLOCK_N,@DESTINT,";
                            query += "@DESTINT_N,@KDGRP,@KTEXT,@PRIMARY_FRT,@SECONDRY_FRT,@RAKNO,@RAKPT,@MATKL,@LGORT,@LGOBE,@INCO1,@INCO2,@ULDG_CHGS,";
                            query += "@TRNS_CHGS,@DPUL_CHGS,@DPLD_CHGS,@DIVR_CHGS,@LDNG_CHGS,@CFAG_CHGS,@RKSR_CHGS,@PULD_CHGS,@RKCL_CHGS,@SHNT_CHGS,@RKCF_CHGS,";
                            query += "@BLND_CHGS,@BLNB_CHGS,@MISC_MISC,@ZZZONE1,@ZZZONE1_N,@ZZBZIRK,@ZZBZIRK_N,@ZZREGIO,@ZZREGIO_N,@VKBUR,@VKBUR_N,@VKGRP,@VKGRP_N,";
                            query += "@ZZBRANCH,@ZZBRANCH_N,@PDSTN,@SDSTN,@BLOCK_CT,@BELNR,@GJAHR,@INV_TYPE,@FRT_TYPE,@ZZVLFKZ,@SUPP_PLANT_NAME,@DEPO_RK_MVT,@IND_PRI_FRT,";
                            query += "@SHIP_FRT_CHRGS,@SHIP_HAND_CHRGS,@CLKMNFPLANT,@SUPPPLANT,@DISTANCE,@INDPDISTANCE,@CLK_PLT_NAME,@MNF_PLT_NAME,@GEIND_PLT,@GEIND_PLT_NAME,@SUPPL_DEPO,@SUPPL_DEPO_NAME,";
                            query += "@WAERK,@RENT,@RAKEDEMCHRG,@LDISTANCE,@LDISTANCE_CLK,@MATNR,@VTEXT,@MATNR1,@MAKTX,@INCURREDCOST,";
                            query += "@UNINCURREDCOST,@SH_REGIO,@SH_DSTRC,@SH_BLOCK,@SH_DESTINT,@KALKS,@DELIVERY_NO,@TKNUM,@MNFPLANT,@MNFDESC,@MVGR1,@GROSSTURN,@NETTURN,";
                            query += "@NAKEDREAL,@TRANS_INCENTIVE,@PLT_FRT,@SP_REGIO,@SP_DSTRC,@SP_BLOCK,@SP_DESTINT,@TRAID,@TRUCK_TYPE,@EWB_NO,@EDATE,@EVDATE,@STEUC,";
                            query += "@PAID_PRICE,@KALKS_DESC,@SP_REGIO_DESC,@SP_DSTRC_DESC,@SP_BLOCK_DESC,@SP_DESTINT_DESC,@MF_PLANT_TYPE,@TOTAL_TDC_COST,@TOTAL_DISTANCE,@DEPOT_IND_FRIEGHT,@TOTAL_INVOICE_FRT,";
                            query += "@ROAD_PF_INCURRED,@ROAD_PF_UNINCURRED,@ROAD_SF_INCURRED,@ROAD_SF_UNINCURRED,@RAIL_PF_INCURRED,@RAIL_PF_UNINCURRED,@DRDL_CHGS,@DB_LAB_CHGS,@ZINV_CANCEL,@SH_DESTINT_DESC,@SHIP_DISTANCE);";
                            MySqlCommand cmd = new MySqlCommand(query, con);

                            cmd.Parameters.AddWithValue("@VBELN", row["VBELN"].ToString());
                            cmd.Parameters.AddWithValue("@FKART", row["FKART"].ToString());
                            cmd.Parameters.AddWithValue("@FKDAT", row["FKDAT"].ToString());
                            cmd.Parameters.AddWithValue("@FKIMG", row["FKIMG"].ToString());
                            cmd.Parameters.AddWithValue("@MEINS", row["MEINS"].ToString());
                            cmd.Parameters.AddWithValue("@WERKS", row["WERKS"].ToString());

                            cmd.Parameters.AddWithValue("@W_NAME1", row["WNAME1"].ToString());
                            cmd.Parameters.AddWithValue("@ZSOURCE", row["ZSOURCE"].ToString());
                            cmd.Parameters.AddWithValue("@ZSOURCED", row["ZSOURCED"].ToString());
                            cmd.Parameters.AddWithValue("@ZTRATYP", row["ZTRATYP"].ToString());
                            cmd.Parameters.AddWithValue("@ZTRATYPD", row["ZTRATYPD"].ToString());
                            cmd.Parameters.AddWithValue("@KUNNR", row["KUNNR"].ToString());
                            cmd.Parameters.AddWithValue("@KUNNR_N", row["KUNNRN"].ToString());
                            cmd.Parameters.AddWithValue("@KUNAG", row["KUNAG"].ToString());
                            cmd.Parameters.AddWithValue("@KUNAG_N", row["KUNAGN"].ToString());
                            cmd.Parameters.AddWithValue("@PTNR", row["PTNR"].ToString());
                            cmd.Parameters.AddWithValue("@PTNR_N", row["PTNRN"].ToString());
                            cmd.Parameters.AddWithValue("@SALSREP", row["SALSREP"].ToString());
                            cmd.Parameters.AddWithValue("@SALSREP_N", row["SALSREPN"].ToString());
                            cmd.Parameters.AddWithValue("@REGIO", row["REGIO"].ToString());
                            cmd.Parameters.AddWithValue("@REGIO_N", row["REGION"].ToString());
                            cmd.Parameters.AddWithValue("@DSTRC", row["DSTRC"].ToString());
                            cmd.Parameters.AddWithValue("@DSTRC_N", row["DSTRCN"].ToString());
                            cmd.Parameters.AddWithValue("@BLOCK", row["BLOCK"].ToString());
                            cmd.Parameters.AddWithValue("@BLOCK_N", row["BLOCKN"].ToString());
                            cmd.Parameters.AddWithValue("@DESTINT", row["DESTINT"].ToString());
                            cmd.Parameters.AddWithValue("@DESTINT_N", row["DESTINTN"].ToString());
                            cmd.Parameters.AddWithValue("@KDGRP", row["KDGRP"].ToString());
                            cmd.Parameters.AddWithValue("@KTEXT", row["KTEXT"].ToString());
                            cmd.Parameters.AddWithValue("@PRIMARY_FRT", row["PRIMARYFRT"].ToString());
                            cmd.Parameters.AddWithValue("@SECONDRY_FRT", row["SECONDRYFRT"].ToString());
                            cmd.Parameters.AddWithValue("@RAKNO", row["RAKNO"].ToString());
                            cmd.Parameters.AddWithValue("@RAKPT", row["RAKPT"].ToString());
                            cmd.Parameters.AddWithValue("@MATKL", row["MATKL"].ToString());
                            cmd.Parameters.AddWithValue("@LGORT", row["LGORT"].ToString());
                            cmd.Parameters.AddWithValue("@LGOBE", row["LGOBE"].ToString());
                            cmd.Parameters.AddWithValue("@INCO1", row["INCO1"].ToString());
                            cmd.Parameters.AddWithValue("@INCO2", row["INCO2"].ToString());
                            cmd.Parameters.AddWithValue("@ULDG_CHGS", row["ULDGCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@TRNS_CHGS", row["TRNSCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@DPUL_CHGS", row["DPULCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@DPLD_CHGS", row["DPLDCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@DIVR_CHGS", row["DIVRCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@LDNG_CHGS", row["LDNGCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@CFAG_CHGS", row["CFAGCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@RKSR_CHGS", row["RKSRCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@PULD_CHGS", row["PULDCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@RKCL_CHGS", row["RKCLCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@SHNT_CHGS", row["SHNTCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@RKCF_CHGS", row["RKCFCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@BLND_CHGS", row["BLNDCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@BLNB_CHGS", row["BLNBCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@MISC_MISC", row["MISCMISC"].ToString());
                            cmd.Parameters.AddWithValue("@ZZZONE1", row["ZZZONE1"].ToString());
                            cmd.Parameters.AddWithValue("@ZZZONE1_N", row["ZZZONE1N"].ToString());
                            cmd.Parameters.AddWithValue("@ZZBZIRK", row["ZZBZIRK"].ToString());
                            cmd.Parameters.AddWithValue("@ZZBZIRK_N", row["ZZBZIRKN"].ToString());
                            cmd.Parameters.AddWithValue("@ZZREGIO", row["ZZREGIO"].ToString());
                            cmd.Parameters.AddWithValue("@ZZREGIO_N", row["ZZREGION"].ToString());
                            cmd.Parameters.AddWithValue("@VKBUR", row["VKBUR"].ToString());
                            cmd.Parameters.AddWithValue("@VKBUR_N", row["VKBURN"].ToString());
                            cmd.Parameters.AddWithValue("@VKGRP", row["VKGRP"].ToString());
                            cmd.Parameters.AddWithValue("@VKGRP_N", row["VKGRPN"].ToString());
                            cmd.Parameters.AddWithValue("@ZZBRANCH", row["ZZBRANCH"].ToString());
                            cmd.Parameters.AddWithValue("@ZZBRANCH_N", row["ZZBRANCHN"].ToString());
                            cmd.Parameters.AddWithValue("@PDSTN", row["PDSTN"].ToString());
                            cmd.Parameters.AddWithValue("@SDSTN", row["SDSTN"].ToString());
                            cmd.Parameters.AddWithValue("@BLOCK_CT", row["BLOCKCT"].ToString());
                            cmd.Parameters.AddWithValue("@BELNR", row["BELNR"].ToString());
                            cmd.Parameters.AddWithValue("@GJAHR", row["GJAHR"].ToString());
                            cmd.Parameters.AddWithValue("@INV_TYPE", row["INVTYPE"].ToString());
                            cmd.Parameters.AddWithValue("@FRT_TYPE", row["FRTTYPE"].ToString());
                            cmd.Parameters.AddWithValue("@ZZVLFKZ", row["ZZVLFKZ"].ToString());
                            cmd.Parameters.AddWithValue("@SUPP_PLANT_NAME", row["SUPPPLANTNAME"].ToString());
                            cmd.Parameters.AddWithValue("@DEPO_RK_MVT", row["DEPORKMVT"].ToString());
                            cmd.Parameters.AddWithValue("@IND_PRI_FRT", row["INDPRIFRT"].ToString());

                            cmd.Parameters.AddWithValue("@SHIP_FRT_CHRGS", row["SHIPFRTCHRGS"].ToString());
                            cmd.Parameters.AddWithValue("@SHIP_HAND_CHRGS", row["SHIPHANDCHRGS"].ToString());
                            cmd.Parameters.AddWithValue("@CLKMNFPLANT", row["CLKMNFPLANT"].ToString());
                            cmd.Parameters.AddWithValue("@SUPPPLANT", row["SUPPPLANT"].ToString());
                            cmd.Parameters.AddWithValue("@DISTANCE", row["DISTANCE"].ToString());
                            cmd.Parameters.AddWithValue("@INDPDISTANCE", row["INDPDISTANCE"].ToString());
                            cmd.Parameters.AddWithValue("@CLK_PLT_NAME", row["CLKPLTNAME"].ToString());
                            cmd.Parameters.AddWithValue("@MNF_PLT_NAME", row["MNFPLTNAME"].ToString());
                            cmd.Parameters.AddWithValue("@GEIND_PLT", row["GEINDPLT"].ToString());
                            cmd.Parameters.AddWithValue("@GEIND_PLT_NAME", row["GEINDPLTNAME"].ToString());
                            cmd.Parameters.AddWithValue("@SUPPL_DEPO", row["SUPPLDEPO"].ToString());
                            cmd.Parameters.AddWithValue("@SUPPL_DEPO_NAME", row["SUPPLDEPONAME"].ToString());
                            cmd.Parameters.AddWithValue("@WAERK", row["WAERK"].ToString());
                            cmd.Parameters.AddWithValue("@RENT", row["RENT"].ToString());
                            cmd.Parameters.AddWithValue("@RAKEDEMCHRG", row["RAKEDEMCHRG"].ToString());
                            cmd.Parameters.AddWithValue("@LDISTANCE", row["LDISTANCE"].ToString());
                            cmd.Parameters.AddWithValue("@LDISTANCE_CLK", row["LDISTANCECLK"].ToString());
                            cmd.Parameters.AddWithValue("@MATNR", row["MATNR"].ToString());
                            cmd.Parameters.AddWithValue("@VTEXT", row["VTEXT"].ToString());
                            cmd.Parameters.AddWithValue("@MATNR1", row["MATNR1"].ToString());
                            cmd.Parameters.AddWithValue("@MAKTX", row["MAKTX"].ToString());
                            cmd.Parameters.AddWithValue("@INCURREDCOST", row["INCURREDCOST"].ToString());
                            cmd.Parameters.AddWithValue("@UNINCURREDCOST", row["UNINCURREDCOST"].ToString());
                            cmd.Parameters.AddWithValue("@SH_REGIO", row["SHREGIO"].ToString());
                            cmd.Parameters.AddWithValue("@SH_DSTRC", row["SHDSTRC"].ToString());
                            cmd.Parameters.AddWithValue("@SH_BLOCK", row["SHBLOCK"].ToString());
                            cmd.Parameters.AddWithValue("@SH_DESTINT", row["SHDESTINT"].ToString());
                            cmd.Parameters.AddWithValue("@KALKS", row["KALKS"].ToString());
                            cmd.Parameters.AddWithValue("@DELIVERY_NO", row["DELIVERYNO"].ToString());
                            cmd.Parameters.AddWithValue("@TKNUM", row["TKNUM"].ToString());
                            cmd.Parameters.AddWithValue("@MNFPLANT", row["MNFPLANT"].ToString());
                            cmd.Parameters.AddWithValue("@MNFDESC", row["MNFDESC"].ToString());
                            cmd.Parameters.AddWithValue("@MVGR1", row["MVGR1"].ToString());
                            cmd.Parameters.AddWithValue("@GROSSTURN", row["GROSSTURN"].ToString());
                            cmd.Parameters.AddWithValue("@NETTURN", row["NETTURN"].ToString());
                            cmd.Parameters.AddWithValue("@NAKEDREAL", row["NAKEDREAL"].ToString());
                            cmd.Parameters.AddWithValue("@TRANS_INCENTIVE", row["TRANSINCENTIVE"].ToString());
                            cmd.Parameters.AddWithValue("@PLT_FRT", row["PLTFRT"].ToString());
                            cmd.Parameters.AddWithValue("@SP_REGIO", row["SPREGIO"].ToString());
                            cmd.Parameters.AddWithValue("@SP_DSTRC", row["SPDSTRC"].ToString());
                            cmd.Parameters.AddWithValue("@SP_BLOCK", row["SPBLOCK"].ToString());
                            cmd.Parameters.AddWithValue("@SP_DESTINT", row["SPDESTINT"].ToString());
                            cmd.Parameters.AddWithValue("@TRAID", row["TRAID"].ToString());
                            cmd.Parameters.AddWithValue("@TRUCK_TYPE", row["TRUCKTYPE"].ToString());
                            cmd.Parameters.AddWithValue("@EWB_NO", row["EWBNO"].ToString());
                            cmd.Parameters.AddWithValue("@EDATE", row["EDATE"].ToString());
                            cmd.Parameters.AddWithValue("@EVDATE", row["EVDATE"].ToString());
                            cmd.Parameters.AddWithValue("@STEUC", row["STEUC"].ToString());
                            cmd.Parameters.AddWithValue("@PAID_PRICE", row["PAIDPRICE"].ToString());
                            cmd.Parameters.AddWithValue("@KALKS_DESC", row["KALKSDESC"].ToString());
                            cmd.Parameters.AddWithValue("@SP_REGIO_DESC", row["SPREGIODESC"].ToString());
                            cmd.Parameters.AddWithValue("@SP_DSTRC_DESC", row["SPDSTRCDESC"].ToString());
                            cmd.Parameters.AddWithValue("@SP_BLOCK_DESC", row["SPBLOCKDESC"].ToString());
                            cmd.Parameters.AddWithValue("@SP_DESTINT_DESC", row["SPDESTINTDESC"].ToString());
                            cmd.Parameters.AddWithValue("@MF_PLANT_TYPE", row["TOTALTDCCOST"].ToString());

                            cmd.Parameters.AddWithValue("@TOTAL_TDC_COST", row["TOTALTDCCOST"].ToString());

                            cmd.Parameters.AddWithValue("@TOTAL_DISTANCE", row["TOTALDISTANCE"].ToString());
                            cmd.Parameters.AddWithValue("@DEPOT_IND_FRIEGHT", row["DEPOTINDFRIEGHT"].ToString());
                            cmd.Parameters.AddWithValue("@TOTAL_INVOICE_FRT", row["TOTALINVOICEFRT"].ToString());
                            cmd.Parameters.AddWithValue("@ROAD_PF_INCURRED", row["ROADPFINCURRED"].ToString());
                            cmd.Parameters.AddWithValue("@ROAD_PF_UNINCURRED", row["ROADPFUNINCURRED"].ToString());
                            cmd.Parameters.AddWithValue("@ROAD_SF_INCURRED", row["ROADSFINCURRED"].ToString());
                            cmd.Parameters.AddWithValue("@ROAD_SF_UNINCURRED", row["ROADSFUNINCURRED"].ToString());
                            cmd.Parameters.AddWithValue("@RAIL_PF_INCURRED", row["RAILPFINCURRED"].ToString());
                            cmd.Parameters.AddWithValue("@RAIL_PF_UNINCURRED", row["RAILPFUNINCURRED"].ToString());
                            cmd.Parameters.AddWithValue("@DRDL_CHGS", row["DRDLCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@DB_LAB_CHGS", row["DBLABCHGS"].ToString());
                            cmd.Parameters.AddWithValue("@ZINV_CANCEL", row["ZINVCANCEL"].ToString());
                            cmd.Parameters.AddWithValue("@SH_DESTINT_DESC", row["SHDESTINTDESC"].ToString());
                            cmd.Parameters.AddWithValue("@SHIP_DISTANCE", row["SHIPDISTANCE"].ToString());

                            cmd.CommandType = CommandType.Text;

                            int result = cmd.ExecuteNonQuery();

                            if (result == 1)
                            {
                                i = i + 1;
                            }

                        }

                    }

                    query = "";
                    query = " Select Count(*) from ZSD_LCOST_DATA_SRV ";
                    query += " where date_format(cast(Fkdat as date),'%Y%m%d') ";
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
                        query = " Delete from ZSD_LCOST_DATA_SRV ";
                        query += " where date_format(cast(Fkdat as date),'%Y%m%d') ";
                        query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";

                        using (MySqlConnection sqlCon = new MySqlConnection(CS))
                        {
                            sqlCon.Open();
                            MySqlCommand Cmnd = new MySqlCommand(query, sqlCon);

                            int result = Cmnd.ExecuteNonQuery();

                            sqlCon.Close();
                        }

                        query = "";
                        query += " Select Count(*) Cnt from ZSD_LCOST_DATA_SRV ";
                        query += " where date_format(cast(Fkdat as date),'%Y%m%d') ";
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

            }
            catch (Exception ex)
            {
                log1.WriteLine("ZSD_LCOST_DATA_SRV Error Message : " + ex.Message);
                log1.Close();
            }
            log1.Close();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Index_new(string startDate, string endDate, string InputID)
        {

            string filename = System.Configuration.ConfigurationManager.AppSettings["LogFile"].ToString();

            try
            {


                var url = "";
                string query = "";

                List<ZSD_REAL_DATA_SRV_REAL> lstsrvdeal = new List<ZSD_REAL_DATA_SRV_REAL>();
                DateTime fromDateValue;
                var formats = new[] { "ddMMyyyy", "yyyyMMdd", "yyyyMMdd" };
                if (!DateTime.TryParseExact(startDate.Trim(), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue) || !(DateTime.TryParseExact(endDate.Trim(), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue)))
                {

                    TempData["ErrMsg"] = "From Date or to Date is not Valid.Unable Process Request.";
                    return RedirectToAction("Index");
                    //return View("About");
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

                    //Log.Info("===========================================");
                    //Log.Info("Application From Date  " + startDate);
                    //Log.Info("Application To Date  " + endDate);
                    //Log.Info("Executed on : " + DateTime.Now);
                    //LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);

                    log1.WriteLine("===========================================");
                    log1.WriteLine("Application From Date  " + startDate);
                    log1.WriteLine("Application To Date  " + endDate);
                    log1.WriteLine("Executed on : " + DateTime.Now);
                    //log1.WriteLine("Table Name : YREALIZATION");

                    //var url = "";
                    //string query = "";
                    int reccount = 0;
                    //List<ZSD_REAL_DATA_SRV_REAL> lstsrvdeal = new List<ZSD_REAL_DATA_SRV_REAL>();

                    //var formats = new[] { "ddMMyyyy", "yyyyMMdd", "yyyyMMdd" };

                    //Development
                    //url = "https://netwaver-dev.pennacement.com:443/sap/opu/odata/sap/ZSD_REAL_DATA_SRV/REALSet?$format=json&$filter=Erdat ge '" + startDate.Trim() + "' and Erdat le '" + endDate.Trim() + "'";
                    //string userName = "NWGW001";
                    //string passwd = "Penna@123";

                    url = "https://netwaver-prd.pennacement.com:443/sap/opu/odata/sap/ZSD_REAL_DATA_SRV/REALSet?$format=json&$filter=Erdat ge '" + startDate.Trim() + "' and Erdat le '" + endDate.Trim() + "'";
                    string userName = "NWGW037";
                    string passwd = "Admin@123456";
                    log1.WriteLine("Insert Table : YREALIZATION");

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
                        List<ZSD_REAL_DATA_SRV_REAL> varoutput = men1.ToObject<List<ZSD_REAL_DATA_SRV_REAL>>();
                        var o = JsonConvert.DeserializeObject<List<ZSD_REAL_DATA_SRV_REAL>>(men1.ToString());

                        Common converter = new Common();


                        DataTable dt = converter.ToDataTable(varoutput);

                        if (dt.Rows.Count > 0)
                        {
                            log1.WriteLine("WebApi Record Count : " + dt.Rows.Count);
                        }
                        else
                        {
                            log1.WriteLine("WebApi Record Count : 0");
                        }

                        query = "";
                        query += " Delete from YREALIZATION ";
                        query += " where date_format(cast(Erdat as date),'%Y%m%d') ";
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

                                query = "Insert into YREALIZATION(VBELN,VGBEL,AUBEL,ERDAT,FKART,REGIO,VKGRP,DSTRC,MNFPLANT,PLANT,GRADE,MATKL,KALKS,KDGRP,";
                                query += "FKDAT,MATNR,CUSTCODE1,CNAME1,CUSTCODE2,CNAME2,CUSTCODE3,CNAME3,COM_AG,COM_NAME,TRANS,TRANS_NAME,";
                                query += "LGORT,LGOBE,FKIMG,GROSSTURN,INCO1,INCO2,STPRS,PRIMARYFRI,SECONDARYFRI,EXWPF,EXGSF,SALESTAX,COMMISSION,";
                                query += "EXCISEDUTY,PDDISCOUNT,ODDISCOUNT,CFCHARGES,CDDISCOUNT,PACKING,UNLOADING,OCTRAI,VAT,IGST,CGST,";
                                query += "SGST,UGST,EXP_HAND,TRANSPORT,AMT_DW_FRT,PLT_FRT,NETTURN,NAKEDREAL,STATEDESC,SGRPDESC,DISDESC,GRADDESC,MNFDESC,";
                                query += "PLANTDESC,PGRPDESC,CDATE,TIME,SUSER,BLOCK_CT,ROUTE,CANCELDATE,CANCELFLAG,ZZLGORT1,BZIRK,VKBUR,ZZZONE1,";
                                query += "ZZBRANCH,PERNR_ER,ENAME_ER,PERNR_Y1,ENAME_Y1,PERNR_Y2,ENAME_Y2,PERNR_Y3,ENAME_Y3,PERNR_Y4,ENAME_Y4,PERNR_Y5,";
                                query += "ENAME_Y5,PERNR_Y6,ENAME_Y6,PERNR_Y7,ENAME_Y7,PERNR_Y8,ENAME_Y8,UPFRNT_DISCOUNT,IND_PRI_FRT,SHIP_FRT_CHRGS,";
                                query += "SHIP_HAND_CHRGS,ZCUST_GRP,ZCUST_GRP_DESC,Vc,ZsalePromValue,Waers,Msehi,PayFreight,ExFreight) Values ";
                                query += "(@VBELN,@VGBEL,@AUBEL,@ERDAT,@FKART,@REGIO,@VKGRP,@DSTRC,@MNFPLANT,@PLANT,@GRADE,@MATKL,@KALKS,@KDGRP,";
                                query += "@FKDAT,@MATNR,@CUSTCODE1,@CNAME1,@CUSTCODE2,@CNAME2,@CUSTCODE3,@CNAME3,@COM_AG,@COM_NAME,@TRANS,@TRANS_NAME,";
                                query += "@LGORT,@LGOBE,@FKIMG,@GROSSTURN,@INCO1,@INCO2,@STPRS,@PRIMARYFRI,@SECONDARYFRI,@EXWPF,@EXGSF,@SALESTAX,@COMMISSION,";
                                query += "@EXCISEDUTY,@PDDISCOUNT,@ODDISCOUNT,@CFCHARGES,@CDDISCOUNT,@PACKING,@UNLOADING,@OCTRAI,@VAT,@IGST,@CGST,";
                                query += "@SGST,@UGST,@EXP_HAND,@TRANSPORT,@AMT_DW_FRT,@PLT_FRT,@NETTURN,@NAKEDREAL,@STATEDESC,@SGRPDESC,@DISDESC,@GRADDESC,@MNFDESC,";
                                query += "@PLANTDESC,@PGRPDESC,@CDATE,@TIME,@SUSER,@BLOCK_CT,@ROUTE,@CANCELDATE,@CANCELFLAG,@ZZLGORT1,@BZIRK,@VKBUR,@ZZZONE1,";
                                query += "@ZZBRANCH,@PERNR_ER,@ENAME_ER,@PERNR_Y1,@ENAME_Y1,@PERNR_Y2,@ENAME_Y2,@PERNR_Y3,@ENAME_Y3,@PERNR_Y4,@ENAME_Y4,@PERNR_Y5,";
                                query += "@ENAME_Y5,@PERNR_Y6,@ENAME_Y6,@PERNR_Y7,@ENAME_Y7,@PERNR_Y8,@ENAME_Y8,@UPFRNT_DISCOUNT,@IND_PRI_FRT,@SHIP_FRT_CHRGS,";
                                query += "@SHIP_HAND_CHRGS,@ZCUST_GRP,@ZCUST_GRP_DESC,@Vc,@ZsalePromValue,@Waers,@Msehi,@PayFreight,@ExFreight);";
                                MySqlCommand cmd = new MySqlCommand(query, con);

                                cmd.Parameters.AddWithValue("@VBELN", row["VBELN"].ToString());
                                cmd.Parameters.AddWithValue("@VGBEL", row["VGBEL"].ToString());
                                cmd.Parameters.AddWithValue("@AUBEL", row["AUBEL"].ToString());
                                cmd.Parameters.AddWithValue("@ERDAT", row["ERDAT"].ToString());
                                cmd.Parameters.AddWithValue("@FKART", row["FKART"].ToString());
                                cmd.Parameters.AddWithValue("@REGIO", row["REGIO"].ToString());
                                cmd.Parameters.AddWithValue("@VKGRP", row["VKGRP"].ToString());
                                cmd.Parameters.AddWithValue("@DSTRC", row["DSTRC"].ToString());
                                cmd.Parameters.AddWithValue("@MNFPLANT", row["MNFPLANT"].ToString());
                                cmd.Parameters.AddWithValue("@PLANT", row["PLANT"].ToString());
                                cmd.Parameters.AddWithValue("@GRADE", row["GRADE"].ToString());
                                cmd.Parameters.AddWithValue("@MATKL", row["MATKL"].ToString());
                                cmd.Parameters.AddWithValue("@KALKS", row["KALKS"].ToString());
                                cmd.Parameters.AddWithValue("@KDGRP", row["KDGRP"].ToString());
                                cmd.Parameters.AddWithValue("@FKDAT", row["FKDAT"].ToString());
                                cmd.Parameters.AddWithValue("@MATNR", row["MATNR"].ToString());
                                cmd.Parameters.AddWithValue("@CUSTCODE1", row["CUSTCODE1"].ToString());
                                cmd.Parameters.AddWithValue("@CNAME1", row["CNAME1"].ToString());
                                cmd.Parameters.AddWithValue("@CUSTCODE2", row["CUSTCODE2"].ToString());
                                cmd.Parameters.AddWithValue("@CNAME2", row["CNAME2"].ToString());
                                cmd.Parameters.AddWithValue("@CUSTCODE3", row["CUSTCODE3"].ToString());
                                cmd.Parameters.AddWithValue("@CNAME3", row["CNAME3"].ToString());
                                cmd.Parameters.AddWithValue("@COM_AG", row["COMAG"].ToString());
                                cmd.Parameters.AddWithValue("@COM_NAME", row["COMNAME"].ToString());
                                cmd.Parameters.AddWithValue("@TRANS", row["TRANS"].ToString());
                                cmd.Parameters.AddWithValue("@TRANS_NAME", row["TRANSNAME"].ToString());
                                cmd.Parameters.AddWithValue("@LGORT", row["LGORT"].ToString());
                                cmd.Parameters.AddWithValue("@LGOBE", row["LGOBE"].ToString());
                                cmd.Parameters.AddWithValue("@FKIMG", row["FKIMG"].ToString());
                                cmd.Parameters.AddWithValue("@GROSSTURN", row["GROSSTURN"].ToString());
                                cmd.Parameters.AddWithValue("@INCO1", row["INCO1"].ToString());
                                cmd.Parameters.AddWithValue("@INCO2", row["INCO2"].ToString());
                                cmd.Parameters.AddWithValue("@STPRS", row["STPRS"].ToString());
                                cmd.Parameters.AddWithValue("@PRIMARYFRI", row["PRIMARYFRI"].ToString());
                                cmd.Parameters.AddWithValue("@SECONDARYFRI", row["SECONDARYFRI"].ToString());
                                cmd.Parameters.AddWithValue("@EXWPF", row["EXWPF"].ToString());
                                cmd.Parameters.AddWithValue("@EXGSF", row["EXGSF"].ToString());
                                cmd.Parameters.AddWithValue("@SALESTAX", row["SALESTAX"].ToString());
                                cmd.Parameters.AddWithValue("@COMMISSION", row["COMMISSION"].ToString());
                                cmd.Parameters.AddWithValue("@EXCISEDUTY", row["EXCISEDUTY"].ToString());
                                cmd.Parameters.AddWithValue("@PDDISCOUNT", row["PDDISCOUNT"].ToString());
                                cmd.Parameters.AddWithValue("@ODDISCOUNT", row["ODDISCOUNT"].ToString());
                                cmd.Parameters.AddWithValue("@CFCHARGES", row["CFCHARGES"].ToString());
                                cmd.Parameters.AddWithValue("@CDDISCOUNT", row["CDDISCOUNT"].ToString());
                                cmd.Parameters.AddWithValue("@PACKING", row["PACKING"].ToString());
                                cmd.Parameters.AddWithValue("@UNLOADING", row["UNLOADING"].ToString());
                                cmd.Parameters.AddWithValue("@OCTRAI", row["OCTRAI"].ToString());
                                cmd.Parameters.AddWithValue("@VAT", row["VAT"].ToString());
                                cmd.Parameters.AddWithValue("@IGST", row["IGST"].ToString());
                                cmd.Parameters.AddWithValue("@CGST", row["CGST"].ToString());
                                cmd.Parameters.AddWithValue("@SGST", row["SGST"].ToString());
                                cmd.Parameters.AddWithValue("@UGST", row["UGST"].ToString());
                                cmd.Parameters.AddWithValue("@EXP_HAND", row["EXPHAND"].ToString());
                                cmd.Parameters.AddWithValue("@TRANSPORT", row["TRANSPORT"].ToString());
                                cmd.Parameters.AddWithValue("@AMT_DW_FRT", row["AMTDWFRT"].ToString());
                                cmd.Parameters.AddWithValue("@PLT_FRT", row["PLTFRT"].ToString());
                                cmd.Parameters.AddWithValue("@NETTURN", row["NETTURN"].ToString());
                                cmd.Parameters.AddWithValue("@NAKEDREAL", row["NAKEDREAL"].ToString());
                                cmd.Parameters.AddWithValue("@STATEDESC", row["STATEDESC"].ToString());
                                cmd.Parameters.AddWithValue("@SGRPDESC", row["SGRPDESC"].ToString());
                                cmd.Parameters.AddWithValue("@DISDESC", row["DISDESC"].ToString());
                                cmd.Parameters.AddWithValue("@GRADDESC", row["GRADDESC"].ToString());
                                cmd.Parameters.AddWithValue("@MNFDESC", row["MNFDESC"].ToString());
                                cmd.Parameters.AddWithValue("@PLANTDESC", row["PLANTDESC"].ToString());
                                cmd.Parameters.AddWithValue("@PGRPDESC", row["PGRPDESC"].ToString());
                                cmd.Parameters.AddWithValue("@CDATE", row["CDATE"].ToString());
                                cmd.Parameters.AddWithValue("@TIME", row["TIME"].ToString());
                                cmd.Parameters.AddWithValue("@SUSER", row["SUSER"].ToString());
                                cmd.Parameters.AddWithValue("@BLOCK_CT", row["BLOCKCT"].ToString());
                                cmd.Parameters.AddWithValue("@ROUTE", row["ROUTE"].ToString());
                                cmd.Parameters.AddWithValue("@CANCELDATE", row["CANCELDATE"].ToString());
                                cmd.Parameters.AddWithValue("@CANCELFLAG", row["CANCELFLAG"].ToString());
                                cmd.Parameters.AddWithValue("@ZZLGORT1", row["ZZLGORT1"].ToString());
                                cmd.Parameters.AddWithValue("@BZIRK", row["BZIRK"].ToString());
                                cmd.Parameters.AddWithValue("@VKBUR", row["VKBUR"].ToString());
                                cmd.Parameters.AddWithValue("@ZZZONE1", row["ZZZONE1"].ToString());
                                cmd.Parameters.AddWithValue("@ZZBRANCH", row["ZZBRANCH"].ToString());
                                cmd.Parameters.AddWithValue("@PERNR_ER", row["PERNRER"].ToString());
                                cmd.Parameters.AddWithValue("@ENAME_ER", row["ENAMEER"].ToString());
                                cmd.Parameters.AddWithValue("@PERNR_Y1", row["PERNRY1"].ToString());
                                cmd.Parameters.AddWithValue("@ENAME_Y1", row["ENAMEY1"].ToString());
                                cmd.Parameters.AddWithValue("@PERNR_Y2", row["PERNRY2"].ToString());
                                cmd.Parameters.AddWithValue("@ENAME_Y2", row["ENAMEY2"].ToString());
                                cmd.Parameters.AddWithValue("@PERNR_Y3", row["PERNRY3"].ToString());
                                cmd.Parameters.AddWithValue("@ENAME_Y3", row["ENAMEY3"].ToString());
                                cmd.Parameters.AddWithValue("@PERNR_Y4", row["PERNRY4"].ToString());
                                cmd.Parameters.AddWithValue("@ENAME_Y4", row["ENAMEY4"].ToString());
                                cmd.Parameters.AddWithValue("@PERNR_Y5", row["PERNRY5"].ToString());
                                cmd.Parameters.AddWithValue("@ENAME_Y5", row["ENAMEY5"].ToString());
                                cmd.Parameters.AddWithValue("@PERNR_Y6", row["PERNRY6"].ToString());
                                cmd.Parameters.AddWithValue("@ENAME_Y6", row["ENAMEY6"].ToString());
                                cmd.Parameters.AddWithValue("@PERNR_Y7", row["PERNRY7"].ToString());
                                cmd.Parameters.AddWithValue("@ENAME_Y7", row["ENAMEY7"].ToString());
                                cmd.Parameters.AddWithValue("@PERNR_Y8", row["PERNRY8"].ToString());
                                cmd.Parameters.AddWithValue("@ENAME_Y8", row["ENAMEY8"].ToString());
                                cmd.Parameters.AddWithValue("@UPFRNT_DISCOUNT", row["UPFRNTDISCOUNT"].ToString());
                                cmd.Parameters.AddWithValue("@IND_PRI_FRT", row["INDPRIFRT"].ToString());
                                cmd.Parameters.AddWithValue("@SHIP_FRT_CHRGS", row["SHIPFRTCHRGS"].ToString());
                                cmd.Parameters.AddWithValue("@SHIP_HAND_CHRGS", row["SHIPHANDCHRGS"].ToString());
                                cmd.Parameters.AddWithValue("@ZCUST_GRP", row["ZCUSTGRP"].ToString());
                                cmd.Parameters.AddWithValue("@ZCUST_GRP_DESC", row["ZCUSTGRPDESC"].ToString());
                                cmd.Parameters.AddWithValue("@Vc", row["Vc"].ToString());
                                cmd.Parameters.AddWithValue("@ZsalePromValue", row["ZsalePromValue"].ToString());
                                cmd.Parameters.AddWithValue("@Waers", row["Waers"].ToString());
                                cmd.Parameters.AddWithValue("@Msehi", row["Msehi"].ToString());
                                cmd.Parameters.AddWithValue("@PayFreight", row["PayFreight"].ToString());
                                cmd.Parameters.AddWithValue("@ExFreight", row["ExFreight"].ToString());

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
                        query += " Select Count(*) Cnt from YREALIZATION ";
                        query += " where date_format(cast(Erdat as date),'%Y%m%d') ";
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
                            query += " Delete from YREALIZATION ";
                            query += " where date_format(cast(Erdat as date),'%Y%m%d') ";
                            query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";

                            using (MySqlConnection sqlCon = new MySqlConnection(CS))
                            {
                                sqlCon.Open();
                                MySqlCommand Cmnd = new MySqlCommand(query, sqlCon);

                                int result = Cmnd.ExecuteNonQuery();

                                sqlCon.Close();
                            }


                            query = "";
                            query += " Select Count(*) Cnt from YREALIZATION ";
                            query += " where date_format(cast(Erdat as date),'%Y%m%d') ";
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
                    //Import_Data imp = new Import_Data();
                    //imp.Insert_YREALIZATION(startDate.Trim(), endDate.Trim());
                    //Insert_YREALIZATION(startDate.Trim(), endDate.Trim());
                }

                if (InputID == "I" || InputID == "S")
                {
                    using (MySqlConnection con = new MySqlConnection(CS))
                    {
                        query = "";
                        query += " Select * from YREALIZATION ";
                        query += " where date_format(cast(ERDAT as date),'%Y%m%d') ";
                        query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";
                        query += " order by date_format(cast(Erdat as date),'%Y%m%d') ";
                        using (MySqlCommand cmd = new MySqlCommand(query))
                        {

                            cmd.Connection = con;
                            con.Open();
                            using (MySqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    lstsrvdeal.Add(new ZSD_REAL_DATA_SRV_REAL
                                    {
                                        Vbeln = Convert.ToString(sdr["Vbeln"]),
                                        Vgbel = Convert.ToString(sdr["Vgbel"]),
                                        Aubel = Convert.ToString(sdr["Aubel"]),
                                        Erdat = Convert.ToString(sdr["Erdat"]),
                                        Fkart = Convert.ToString(sdr["Fkart"]),
                                        Regio = Convert.ToString(sdr["Regio"]),
                                        Vkgrp = Convert.ToString(sdr["Vkgrp"]),
                                        Dstrc = Convert.ToString(sdr["Dstrc"]),
                                        Mnfplant = Convert.ToString(sdr["Mnfplant"]),
                                        Plant = Convert.ToString(sdr["Plant"]),
                                        Grade = Convert.ToString(sdr["Grade"]),
                                        Matkl = Convert.ToString(sdr["Matkl"]),
                                        Kalks = Convert.ToString(sdr["Kalks"]),
                                        Kdgrp = Convert.ToString(sdr["Kdgrp"]),
                                        Fkdat = Convert.ToString(sdr["Fkdat"]),
                                        Matnr = Convert.ToString(sdr["Matnr"]),
                                        Custcode1 = Convert.ToString(sdr["Custcode1"]),
                                        Cname1 = Convert.ToString(sdr["Cname1"]),
                                        Custcode2 = Convert.ToString(sdr["Custcode2"]),
                                        Cname2 = Convert.ToString(sdr["Cname2"]),
                                        Custcode3 = Convert.ToString(sdr["Custcode3"]),
                                        Cname3 = Convert.ToString(sdr["Cname3"]),
                                        ComAg = Convert.ToString(sdr["COM_AG"]),
                                        ComName = Convert.ToString(sdr["COM_NAME"]),
                                        Trans = Convert.ToString(sdr["Trans"]),
                                        TransName = Convert.ToString(sdr["TRANS_NAME"]),
                                        Lgort = Convert.ToString(sdr["Lgort"]),
                                        Lgobe = Convert.ToString(sdr["Lgobe"]),
                                        Fkimg = Convert.ToDecimal(sdr["Fkimg"]),
                                        Grossturn = Convert.ToDecimal(sdr["Grossturn"]),
                                        Inco1 = Convert.ToString(sdr["Inco1"]),
                                        Inco2 = Convert.ToString(sdr["Inco2"]),
                                        Stprs = Convert.ToDecimal(sdr["Stprs"]),
                                        Primaryfri = Convert.ToDecimal(sdr["Primaryfri"]),
                                        Secondaryfri = Convert.ToDecimal(sdr["Secondaryfri"]),
                                        Exwpf = Convert.ToDecimal(sdr["Exwpf"]),
                                        Exgsf = Convert.ToDecimal(sdr["Exgsf"]),
                                        Salestax = Convert.ToDecimal(sdr["Salestax"]),
                                        Commission = Convert.ToDecimal(sdr["Commission"]),
                                        Exciseduty = Convert.ToDecimal(sdr["Exciseduty"]),
                                        Pddiscount = Convert.ToDecimal(sdr["Pddiscount"]),
                                        Oddiscount = Convert.ToDecimal(sdr["Oddiscount"]),
                                        Cfcharges = Convert.ToDecimal(sdr["Cfcharges"]),
                                        Cddiscount = Convert.ToDecimal(sdr["Cddiscount"]),
                                        Packing = Convert.ToDecimal(sdr["Packing"]),
                                        Unloading = Convert.ToDecimal(sdr["Unloading"]),
                                        Octrai = Convert.ToDecimal(sdr["Octrai"]),
                                        Vat = Convert.ToDecimal(sdr["Vat"]),
                                        Igst = Convert.ToDecimal(sdr["Igst"]),
                                        Cgst = Convert.ToDecimal(sdr["Cgst"]),
                                        Sgst = Convert.ToDecimal(sdr["Sgst"]),
                                        Ugst = Convert.ToDecimal(sdr["Ugst"]),
                                        ExpHand = Convert.ToDecimal(sdr["EXP_HAND"]),
                                        Transport = Convert.ToDecimal(sdr["Transport"]),
                                        AmtDwFrt = Convert.ToDecimal(sdr["AMT_DW_FRT"]),
                                        PltFrt = Convert.ToDecimal(sdr["PLT_FRT"]),
                                        Netturn = Convert.ToDecimal(sdr["Netturn"]),
                                        Nakedreal = Convert.ToDecimal(sdr["Nakedreal"]),
                                        Statedesc = Convert.ToString(sdr["Statedesc"]),
                                        Sgrpdesc = Convert.ToString(sdr["Sgrpdesc"]),
                                        Disdesc = Convert.ToString(sdr["Disdesc"]),
                                        Graddesc = Convert.ToString(sdr["Graddesc"]),
                                        Mnfdesc = Convert.ToString(sdr["Mnfdesc"]),
                                        Plantdesc = Convert.ToString(sdr["Plantdesc"]),
                                        Pgrpdesc = Convert.ToString(sdr["Pgrpdesc"]),
                                        Cdate = Convert.ToString(sdr["Cdate"]),
                                        Time = Convert.ToString(sdr["Time"]),
                                        Suser = Convert.ToString(sdr["Suser"]),
                                        BlockCt = Convert.ToString(sdr["BLOCK_CT"]),
                                        Route = Convert.ToString(sdr["Route"]),
                                        Canceldate = Convert.ToString(sdr["Canceldate"]),
                                        Cancelflag = Convert.ToString(sdr["Cancelflag"]),
                                        Zzlgort1 = Convert.ToString(sdr["Zzlgort1"]),
                                        Bzirk = Convert.ToString(sdr["Bzirk"]),
                                        Vkbur = Convert.ToString(sdr["Vkbur"]),
                                        Zzzone1 = Convert.ToString(sdr["Zzzone1"]),
                                        Zzbranch = Convert.ToString(sdr["Zzbranch"]),
                                        PernrEr = Convert.ToString(sdr["PERNR_ER"]),
                                        EnameEr = Convert.ToString(sdr["ENAME_ER"]),
                                        PernrY1 = Convert.ToString(sdr["PERNR_Y1"]),
                                        EnameY1 = Convert.ToString(sdr["ENAME_Y1"]),
                                        PernrY2 = Convert.ToString(sdr["PERNR_Y2"]),
                                        EnameY2 = Convert.ToString(sdr["ENAME_Y2"]),
                                        PernrY3 = Convert.ToString(sdr["PERNR_Y3"]),
                                        EnameY3 = Convert.ToString(sdr["ENAME_Y3"]),
                                        PernrY4 = Convert.ToString(sdr["PERNR_Y4"]),
                                        EnameY4 = Convert.ToString(sdr["ENAME_Y4"]),
                                        PernrY5 = Convert.ToString(sdr["PERNR_Y5"]),
                                        EnameY5 = Convert.ToString(sdr["ENAME_Y5"]),
                                        PernrY6 = Convert.ToString(sdr["PERNR_Y6"]),
                                        EnameY6 = Convert.ToString(sdr["ENAME_Y6"]),
                                        PernrY7 = Convert.ToString(sdr["PERNR_Y7"]),
                                        EnameY7 = Convert.ToString(sdr["ENAME_Y7"]),
                                        PernrY8 = Convert.ToString(sdr["PERNR_Y8"]),
                                        EnameY8 = Convert.ToString(sdr["ENAME_Y8"]),
                                        UpfrntDiscount = Convert.ToDecimal(sdr["UPFRNT_DISCOUNT"]),
                                        IndPriFrt = Convert.ToDecimal(sdr["IND_PRI_FRT"]),
                                        ShipFrtChrgs = Convert.ToDecimal(sdr["SHIP_FRT_CHRGS"]),
                                        ShipHandChrgs = Convert.ToDecimal(sdr["SHIP_HAND_CHRGS"]),
                                        ZcustGrp = Convert.ToString(sdr["ZCUST_GRP"]),
                                        ZcustGrpDesc = Convert.ToString(sdr["ZCUST_GRP_DESC"]),
                                        Vc = Convert.ToDecimal(sdr["Vc"]),
                                        ZsalePromValue = Convert.ToDecimal(sdr["ZsalePromValue"]),
                                        Waers = Convert.ToString(sdr["Waers"]),
                                        Msehi = Convert.ToString(sdr["Msehi"]),
                                        PayFreight = Convert.ToDecimal(sdr["PayFreight"]),
                                        ExFreight = Convert.ToDecimal(sdr["ExFreight"]),
                                    });
                                }
                            }
                            con.Close();
                        }
                    }
                }

                if (InputID == "E")
                {
                    DataTable dt1 = new DataTable("YREALIZATION");
                    dt1.Columns.AddRange(new DataColumn[107]
                    {
                            new DataColumn("Billing Document"),
                            new DataColumn("Reference Document"),
                            new DataColumn("Sales Document"),
                            new DataColumn("Creation Date"),
                            new DataColumn("Billing Type"),
                            new DataColumn("State code"),
                            new DataColumn("Sales Group code"),
                            new DataColumn("District code"),
                            new DataColumn("Manfuacture Plant"),
                            new DataColumn("Plant"),
                            new DataColumn("Material Pricing Group"),
                            new DataColumn("Material Group"),
                            new DataColumn("Pricing procedure "),
                            new DataColumn("Customer group"),
                            new DataColumn("Billing Date "),
                            new DataColumn("Material Number"),
                            new DataColumn("Customer Code"),
                            new DataColumn("Customer Name"),
                            new DataColumn("Sales Rep code"),
                            new DataColumn("Sales Rep Name"),
                            new DataColumn("Consignee Code"),
                            new DataColumn("Consignee Name"),
                            new DataColumn("Commission Agent code"),
                            new DataColumn("Commission Agenet Name"),
                            new DataColumn("Transporter Code"),
                            new DataColumn("Transporter Name"),
                            new DataColumn("Storage Location"),
                            new DataColumn("Description of Storage Location"),
                            new DataColumn("Billed quantity"),
                            new DataColumn("Gross Turnover"),
                            new DataColumn("Incoterms1"),
                            new DataColumn("Incoterms2"),
                            new DataColumn("Standard price"),
                            new DataColumn("Primary Freight"),
                            new DataColumn("Secondary freight"),
                            new DataColumn("Ex-Works Primary Freight"),
                            new DataColumn("Ex-Works Secondary Freight"),
                            new DataColumn("Sales Tax"),
                            new DataColumn("Commission"),
                            new DataColumn("Excise Duty"),
                            new DataColumn("Price Discount"),
                            new DataColumn("Other Discount"),
                            new DataColumn("CFA charges"),
                            new DataColumn("Cash Discount"),
                            new DataColumn("Packing Charges"),
                            new DataColumn("Unloading Charges"),
                            new DataColumn("Octrai"),
                            new DataColumn("VAT"),
                            new DataColumn("IGST"),
                            new DataColumn("CGST"),
                            new DataColumn("SGST"),
                            new DataColumn("UGST"),
                            new DataColumn("Export Handling chgs"),
                            new DataColumn("Transport Incentive"),
                            new DataColumn("Demurrage Wharfage"),
                            new DataColumn("Plant freight"),
                            new DataColumn("Net Turnrover"),
                            new DataColumn("Realisation"),
                            new DataColumn("State Name"),
                            new DataColumn("Branch"),
                            new DataColumn("Distrct Name"),
                            new DataColumn("Grade"),
                            new DataColumn("Manfacture Plant name"),
                            new DataColumn("Plant Name"),
                            new DataColumn("Customer Group Name"),
                            new DataColumn("System Date"),
                            new DataColumn("System Time"),
                            new DataColumn("User Name"),
                            new DataColumn("Block Category"),
                            new DataColumn("Description of Route"),
                            new DataColumn("Date on Which Record Was Created"),
                            new DataColumn("Single-Character Flag"),
                            new DataColumn("Moving Storage loc "),
                            new DataColumn("Sales district"),
                            new DataColumn("Sales Office"),
                            new DataColumn("Transportation zone"),
                            new DataColumn("Branch Office"),
                            new DataColumn("Sales Officer Emp.No."),
                            new DataColumn("Sales Officer Emp.Name"),
                            new DataColumn("RM1"),
                            new DataColumn("RM1 Name"),
                            new DataColumn("RM2 "),
                            new DataColumn("RM2 Name"),
                            new DataColumn("RM3"),
                            new DataColumn("RM3 Name"),
                            new DataColumn("RM4"),
                            new DataColumn("RM4 Name"),
                            new DataColumn("RM5"),
                            new DataColumn("RM5 Name"),
                            new DataColumn("RM6"),
                            new DataColumn("RM6 Name"),
                            new DataColumn("RM7"),
                            new DataColumn("RM7 Name"),
                            new DataColumn("RM8"),
                            new DataColumn("RM8 Name"),
                            new DataColumn("Upfront Discount Amount"),
                            new DataColumn("Indirect Primary Freight"),
                            new DataColumn("Ship Freight"),
                            new DataColumn("Ship Handling Charges"),
                            new DataColumn("Customer group_1"),
                            new DataColumn("Customer Group Desc."),
                            new DataColumn("Varible Cost"),
                            new DataColumn("ZsalePromValue"),
                            new DataColumn("Waers"),
                            new DataColumn("Msehi"),
                            new DataColumn("PayFreight"),
                            new DataColumn("ExFreight")



                     });

                    using (MySqlConnection con = new MySqlConnection(CS))
                    {
                        query = "";
                        query += " Select * from YREALIZATION ";
                        query += " where date_format(cast(ERDAT as date),'%Y%m%d') ";
                        query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";
                        query += " order by date_format(cast(Erdat as date),'%Y%m%d') ";
                        using (MySqlCommand cmd = new MySqlCommand(query))
                        {

                            cmd.Connection = con;
                            con.Open();
                            using (MySqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    DataRow _dr = dt1.NewRow();


                                    _dr["Billing Document"] = Convert.ToString(sdr["VBELN"]);
                                    _dr["Reference Document"] = Convert.ToString(sdr["VGBEL"]);
                                    _dr["Sales Document"] = Convert.ToString(sdr["AUBEL"]);
                                    _dr["Creation Date"] = Convert.ToString(sdr["ERDAT"]);
                                    _dr["Billing Type"] = Convert.ToString(sdr["FKART"]);
                                    _dr["State code"] = Convert.ToString(sdr["REGIO"]);
                                    _dr["Sales Group code"] = Convert.ToString(sdr["VKGRP"]);
                                    _dr["District code"] = Convert.ToString(sdr["DSTRC"]);
                                    _dr["Manfuacture Plant"] = Convert.ToString(sdr["MNFPLANT"]);
                                    _dr["Plant"] = Convert.ToString(sdr["PLANT"]);
                                    _dr["Material Pricing Group"] = Convert.ToString(sdr["GRADE"]);
                                    _dr["Material Group"] = Convert.ToString(sdr["MATKL"]);
                                    _dr["Pricing procedure "] = Convert.ToString(sdr["KALKS"]);
                                    _dr["Customer group"] = Convert.ToString(sdr["KDGRP"]);
                                    _dr["Billing Date "] = Convert.ToString(sdr["FKDAT"]);
                                    _dr["Material Number"] = Convert.ToString(sdr["MATNR"]);
                                    _dr["Customer Code"] = Convert.ToString(sdr["CUSTCODE1"]);
                                    _dr["Customer Name"] = Convert.ToString(sdr["CNAME1"]);
                                    _dr["Sales Rep code"] = Convert.ToString(sdr["CUSTCODE2"]);
                                    _dr["Sales Rep Name"] = Convert.ToString(sdr["CNAME2"]);
                                    _dr["Consignee Code"] = Convert.ToString(sdr["CUSTCODE3"]);
                                    _dr["Consignee Name"] = Convert.ToString(sdr["CNAME3"]);
                                    _dr["Commission Agent code"] = Convert.ToString(sdr["COM_AG"]);
                                    _dr["Commission Agenet Name"] = Convert.ToString(sdr["COM_NAME"]);
                                    _dr["Transporter Code"] = Convert.ToString(sdr["TRANS"]);
                                    _dr["Transporter Name"] = Convert.ToString(sdr["TRANS_NAME"]);
                                    _dr["Storage Location"] = Convert.ToString(sdr["LGORT"]);
                                    _dr["Description of Storage Location"] = Convert.ToString(sdr["LGOBE"]);
                                    _dr["Billed quantity"] = Convert.ToDecimal(sdr["FKIMG"]);
                                    _dr["Gross Turnover"] = Convert.ToDecimal(sdr["GROSSTURN"]);
                                    _dr["Incoterms1"] = Convert.ToString(sdr["INCO1"]);
                                    _dr["Incoterms2"] = Convert.ToString(sdr["INCO2"]);
                                    _dr["Standard price"] = Convert.ToDecimal(sdr["STPRS"]);
                                    _dr["Primary Freight"] = Convert.ToDecimal(sdr["PRIMARYFRI"]);
                                    _dr["Secondary freight"] = Convert.ToDecimal(sdr["SECONDARYFRI"]);
                                    _dr["Ex-Works Primary Freight"] = Convert.ToDecimal(sdr["EXWPF"]);
                                    _dr["Ex-Works Secondary Freight"] = Convert.ToDecimal(sdr["EXGSF"]);
                                    _dr["Sales Tax"] = Convert.ToDecimal(sdr["SALESTAX"]);
                                    _dr["Commission"] = Convert.ToDecimal(sdr["COMMISSION"]);
                                    _dr["Excise Duty"] = Convert.ToDecimal(sdr["EXCISEDUTY"]);
                                    _dr["Price Discount"] = Convert.ToDecimal(sdr["PDDISCOUNT"]);
                                    _dr["Other Discount"] = Convert.ToDecimal(sdr["ODDISCOUNT"]);
                                    _dr["CFA charges"] = Convert.ToDecimal(sdr["CFCHARGES"]);
                                    _dr["Cash Discount"] = Convert.ToDecimal(sdr["CDDISCOUNT"]);
                                    _dr["Packing Charges"] = Convert.ToDecimal(sdr["PACKING"]);
                                    _dr["Unloading Charges"] = Convert.ToDecimal(sdr["UNLOADING"]);
                                    _dr["Octrai"] = Convert.ToDecimal(sdr["OCTRAI"]);
                                    _dr["VAT"] = Convert.ToDecimal(sdr["VAT"]);
                                    _dr["IGST"] = Convert.ToDecimal(sdr["IGST"]);
                                    _dr["CGST"] = Convert.ToDecimal(sdr["CGST"]);
                                    _dr["SGST"] = Convert.ToDecimal(sdr["SGST"]);
                                    _dr["UGST"] = Convert.ToDecimal(sdr["UGST"]);
                                    _dr["Export Handling chgs"] = Convert.ToDecimal(sdr["EXP_HAND"]);
                                    _dr["Transport Incentive"] = Convert.ToDecimal(sdr["TRANSPORT"]);
                                    _dr["Demurrage Wharfage"] = Convert.ToDecimal(sdr["AMT_DW_FRT"]);
                                    _dr["Plant freight"] = Convert.ToDecimal(sdr["PLT_FRT"]);
                                    _dr["Net Turnrover"] = Convert.ToDecimal(sdr["NETTURN"]);
                                    _dr["Realisation"] = Convert.ToDecimal(sdr["NAKEDREAL"]);
                                    _dr["State Name"] = Convert.ToString(sdr["STATEDESC"]);
                                    _dr["Branch"] = Convert.ToString(sdr["SGRPDESC"]);
                                    _dr["Distrct Name"] = Convert.ToString(sdr["DISDESC"]);
                                    _dr["Grade"] = Convert.ToString(sdr["GRADDESC"]);
                                    _dr["Manfacture Plant name"] = Convert.ToString(sdr["MNFDESC"]);
                                    _dr["Plant Name"] = Convert.ToString(sdr["PLANTDESC"]);
                                    _dr["Customer Group Name"] = Convert.ToString(sdr["PGRPDESC"]);
                                    _dr["System Date"] = Convert.ToString(sdr["CDATE"]);
                                    _dr["System Time"] = Convert.ToString(sdr["TIME"]);
                                    _dr["User Name"] = Convert.ToString(sdr["SUSER"]);
                                    _dr["Block Category"] = Convert.ToString(sdr["BLOCK_CT"]);
                                    _dr["Description of Route"] = Convert.ToString(sdr["ROUTE"]);
                                    _dr["Date on Which Record Was Created"] = Convert.ToString(sdr["CANCELDATE"]);
                                    _dr["Single-Character Flag"] = Convert.ToString(sdr["CANCELFLAG"]);
                                    _dr["Moving Storage loc "] = Convert.ToString(sdr["ZZLGORT1"]);
                                    _dr["Sales district"] = Convert.ToString(sdr["BZIRK"]);
                                    _dr["Sales Office"] = Convert.ToString(sdr["VKBUR"]);
                                    _dr["Transportation zone"] = Convert.ToString(sdr["ZZZONE1"]);
                                    _dr["Branch Office"] = Convert.ToString(sdr["ZZBRANCH"]);
                                    _dr["Sales Officer Emp.No."] = Convert.ToString(sdr["PERNR_ER"]);
                                    _dr["Sales Officer Emp.Name"] = Convert.ToString(sdr["ENAME_ER"]);
                                    _dr["RM1"] = Convert.ToString(sdr["PERNR_Y1"]);
                                    _dr["RM1 Name"] = Convert.ToString(sdr["ENAME_Y1"]);
                                    _dr["RM2 "] = Convert.ToString(sdr["PERNR_Y2"]);
                                    _dr["RM2 Name"] = Convert.ToString(sdr["ENAME_Y2"]);
                                    _dr["RM3"] = Convert.ToString(sdr["PERNR_Y3"]);
                                    _dr["RM3 Name"] = Convert.ToString(sdr["ENAME_Y3"]);
                                    _dr["RM4"] = Convert.ToString(sdr["PERNR_Y4"]);
                                    _dr["RM4 Name"] = Convert.ToString(sdr["ENAME_Y4"]);
                                    _dr["RM5"] = Convert.ToString(sdr["PERNR_Y5"]);
                                    _dr["RM5 Name"] = Convert.ToString(sdr["ENAME_Y5"]);
                                    _dr["RM6"] = Convert.ToString(sdr["PERNR_Y6"]);
                                    _dr["RM6 Name"] = Convert.ToString(sdr["ENAME_Y6"]);
                                    _dr["RM7"] = Convert.ToString(sdr["PERNR_Y7"]);
                                    _dr["RM7 Name"] = Convert.ToString(sdr["ENAME_Y7"]);
                                    _dr["RM8"] = Convert.ToString(sdr["PERNR_Y8"]);
                                    _dr["RM8 Name"] = Convert.ToString(sdr["ENAME_Y8"]);
                                    _dr["Upfront Discount Amount"] = Convert.ToDecimal(sdr["UPFRNT_DISCOUNT"]);
                                    _dr["Indirect Primary Freight"] = Convert.ToDecimal(sdr["IND_PRI_FRT"]);
                                    _dr["Ship Freight"] = Convert.ToDecimal(sdr["SHIP_FRT_CHRGS"]);
                                    _dr["Ship Handling Charges"] = Convert.ToDecimal(sdr["SHIP_HAND_CHRGS"]);
                                    _dr["Customer group_1"] = Convert.ToString(sdr["ZCUST_GRP"]);
                                    _dr["Customer Group Desc."] = Convert.ToString(sdr["ZCUST_GRP_DESC"]);
                                    _dr["Varible Cost"] = Convert.ToDecimal(sdr["VC"]);
                                    _dr["ZsalePromValue"] = Convert.ToDecimal(sdr["ZsalePromValue"]);
                                    _dr["Waers"] = Convert.ToString(sdr["Waers"]);
                                    _dr["Msehi"] = Convert.ToString(sdr["Msehi"]);
                                    _dr["PayFreight"] = Convert.ToDecimal(sdr["PayFreight"]);
                                    _dr["ExFreight"] = Convert.ToDecimal(sdr["ExFreight"]);


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
                            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "yrealization.xlsx");
                        }
                    }
                }
                //if (InputID == "I")
                //{
                //    log1.WriteLine("===========================================");
                //    log1.Close();

                //}
                //Maxid = 19;
                //return View(lstsrvdeal);
                List<ZSD_REAL_DATA_SRV_REAL> results = new List<ZSD_REAL_DATA_SRV_REAL>();
                results = lstsrvdeal;
                return Json(new { errorcode = 1, errormessage = 1, Data = results }, JsonRequestBehavior.AllowGet);

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
                log1.WriteLine("YREALIZATION Error Message : " + ex.Message);
                log1.WriteLine("===========================================");
                log1.Close();
                return View();

            }


        }
        public JsonResult getdata(string startDate, string endDate)
        {
            string filename = System.Configuration.ConfigurationManager.AppSettings["LogFile"].ToString();
            try
            {
                
                List<ZSD_REAL_DATA_SRV_REAL> lstsrvdeal = new List<ZSD_REAL_DATA_SRV_REAL>();
                using (MySqlConnection con = new MySqlConnection(CS))
                {
                    string query = "";
                    query += " Select * from YREALIZATION ";
                    query += " where date_format(cast(ERDAT as date),'%Y%m%d') ";
                    query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";
                    query += " order by date_format(cast(Erdat as date),'%Y%m%d') ";
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {

                        cmd.Connection = con;
                        con.Open();
                        using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                lstsrvdeal.Add(new ZSD_REAL_DATA_SRV_REAL
                                {
                                    Vbeln = Convert.ToString(sdr["Vbeln"]),
                                    Vgbel = Convert.ToString(sdr["Vgbel"]),
                                    Aubel = Convert.ToString(sdr["Aubel"]),
                                    Erdat = Convert.ToString(sdr["Erdat"]),
                                    Fkart = Convert.ToString(sdr["Fkart"]),
                                    Regio = Convert.ToString(sdr["Regio"]),
                                    Vkgrp = Convert.ToString(sdr["Vkgrp"]),
                                    Dstrc = Convert.ToString(sdr["Dstrc"]),
                                    Mnfplant = Convert.ToString(sdr["Mnfplant"]),
                                    Plant = Convert.ToString(sdr["Plant"]),
                                    Grade = Convert.ToString(sdr["Grade"]),
                                    Matkl = Convert.ToString(sdr["Matkl"]),
                                    Kalks = Convert.ToString(sdr["Kalks"]),
                                    Kdgrp = Convert.ToString(sdr["Kdgrp"]),
                                    Fkdat = Convert.ToString(sdr["Fkdat"]),
                                    Matnr = Convert.ToString(sdr["Matnr"]),
                                    Custcode1 = Convert.ToString(sdr["Custcode1"]),
                                    Cname1 = Convert.ToString(sdr["Cname1"]),
                                    Custcode2 = Convert.ToString(sdr["Custcode2"]),
                                    Cname2 = Convert.ToString(sdr["Cname2"]),
                                    Custcode3 = Convert.ToString(sdr["Custcode3"]),
                                    Cname3 = Convert.ToString(sdr["Cname3"]),
                                    ComAg = Convert.ToString(sdr["COM_AG"]),
                                    ComName = Convert.ToString(sdr["COM_NAME"]),
                                    Trans = Convert.ToString(sdr["Trans"]),
                                    TransName = Convert.ToString(sdr["TRANS_NAME"]),
                                    Lgort = Convert.ToString(sdr["Lgort"]),
                                    Lgobe = Convert.ToString(sdr["Lgobe"]),
                                    Fkimg = Convert.ToDecimal(sdr["Fkimg"]),
                                    Grossturn = Convert.ToDecimal(sdr["Grossturn"]),
                                    Inco1 = Convert.ToString(sdr["Inco1"]),
                                    Inco2 = Convert.ToString(sdr["Inco2"]),
                                    Stprs = Convert.ToDecimal(sdr["Stprs"]),
                                    Primaryfri = Convert.ToDecimal(sdr["Primaryfri"]),
                                    Secondaryfri = Convert.ToDecimal(sdr["Secondaryfri"]),
                                    Exwpf = Convert.ToDecimal(sdr["Exwpf"]),
                                    Exgsf = Convert.ToDecimal(sdr["Exgsf"]),
                                    Salestax = Convert.ToDecimal(sdr["Salestax"]),
                                    Commission = Convert.ToDecimal(sdr["Commission"]),
                                    Exciseduty = Convert.ToDecimal(sdr["Exciseduty"]),
                                    Pddiscount = Convert.ToDecimal(sdr["Pddiscount"]),
                                    Oddiscount = Convert.ToDecimal(sdr["Oddiscount"]),
                                    Cfcharges = Convert.ToDecimal(sdr["Cfcharges"]),
                                    Cddiscount = Convert.ToDecimal(sdr["Cddiscount"]),
                                    Packing = Convert.ToDecimal(sdr["Packing"]),
                                    Unloading = Convert.ToDecimal(sdr["Unloading"]),
                                    Octrai = Convert.ToDecimal(sdr["Octrai"]),
                                    Vat = Convert.ToDecimal(sdr["Vat"]),
                                    Igst = Convert.ToDecimal(sdr["Igst"]),
                                    Cgst = Convert.ToDecimal(sdr["Cgst"]),
                                    Sgst = Convert.ToDecimal(sdr["Sgst"]),
                                    Ugst = Convert.ToDecimal(sdr["Ugst"]),
                                    ExpHand = Convert.ToDecimal(sdr["EXP_HAND"]),
                                    Transport = Convert.ToDecimal(sdr["Transport"]),
                                    AmtDwFrt = Convert.ToDecimal(sdr["AMT_DW_FRT"]),
                                    PltFrt = Convert.ToDecimal(sdr["PLT_FRT"]),
                                    Netturn = Convert.ToDecimal(sdr["Netturn"]),
                                    Nakedreal = Convert.ToDecimal(sdr["Nakedreal"]),
                                    Statedesc = Convert.ToString(sdr["Statedesc"]),
                                    Sgrpdesc = Convert.ToString(sdr["Sgrpdesc"]),
                                    Disdesc = Convert.ToString(sdr["Disdesc"]),
                                    Graddesc = Convert.ToString(sdr["Graddesc"]),
                                    Mnfdesc = Convert.ToString(sdr["Mnfdesc"]),
                                    Plantdesc = Convert.ToString(sdr["Plantdesc"]),
                                    Pgrpdesc = Convert.ToString(sdr["Pgrpdesc"]),
                                    Cdate = Convert.ToString(sdr["Cdate"]),
                                    Time = Convert.ToString(sdr["Time"]),
                                    Suser = Convert.ToString(sdr["Suser"]),
                                    BlockCt = Convert.ToString(sdr["BLOCK_CT"]),
                                    Route = Convert.ToString(sdr["Route"]),
                                    Canceldate = Convert.ToString(sdr["Canceldate"]),
                                    Cancelflag = Convert.ToString(sdr["Cancelflag"]),
                                    Zzlgort1 = Convert.ToString(sdr["Zzlgort1"]),
                                    Bzirk = Convert.ToString(sdr["Bzirk"]),
                                    Vkbur = Convert.ToString(sdr["Vkbur"]),
                                    Zzzone1 = Convert.ToString(sdr["Zzzone1"]),
                                    Zzbranch = Convert.ToString(sdr["Zzbranch"]),
                                    PernrEr = Convert.ToString(sdr["PERNR_ER"]),
                                    EnameEr = Convert.ToString(sdr["ENAME_ER"]),
                                    PernrY1 = Convert.ToString(sdr["PERNR_Y1"]),
                                    EnameY1 = Convert.ToString(sdr["ENAME_Y1"]),
                                    PernrY2 = Convert.ToString(sdr["PERNR_Y2"]),
                                    EnameY2 = Convert.ToString(sdr["ENAME_Y2"]),
                                    PernrY3 = Convert.ToString(sdr["PERNR_Y3"]),
                                    EnameY3 = Convert.ToString(sdr["ENAME_Y3"]),
                                    PernrY4 = Convert.ToString(sdr["PERNR_Y4"]),
                                    EnameY4 = Convert.ToString(sdr["ENAME_Y4"]),
                                    PernrY5 = Convert.ToString(sdr["PERNR_Y5"]),
                                    EnameY5 = Convert.ToString(sdr["ENAME_Y5"]),
                                    PernrY6 = Convert.ToString(sdr["PERNR_Y6"]),
                                    EnameY6 = Convert.ToString(sdr["ENAME_Y6"]),
                                    PernrY7 = Convert.ToString(sdr["PERNR_Y7"]),
                                    EnameY7 = Convert.ToString(sdr["ENAME_Y7"]),
                                    PernrY8 = Convert.ToString(sdr["PERNR_Y8"]),
                                    EnameY8 = Convert.ToString(sdr["ENAME_Y8"]),
                                    UpfrntDiscount = Convert.ToDecimal(sdr["UPFRNT_DISCOUNT"]),
                                    IndPriFrt = Convert.ToDecimal(sdr["IND_PRI_FRT"]),
                                    ShipFrtChrgs = Convert.ToDecimal(sdr["SHIP_FRT_CHRGS"]),
                                    ShipHandChrgs = Convert.ToDecimal(sdr["SHIP_HAND_CHRGS"]),
                                    ZcustGrp = Convert.ToString(sdr["ZCUST_GRP"]),
                                    ZcustGrpDesc = Convert.ToString(sdr["ZCUST_GRP_DESC"]),
                                    Vc = Convert.ToDecimal(sdr["Vc"]),
                                    ZsalePromValue = Convert.ToDecimal(sdr["ZsalePromValue"]),
                                    Waers = Convert.ToString(sdr["Waers"]),
                                    Msehi = Convert.ToString(sdr["Msehi"]),
                                    PayFreight = Convert.ToDecimal(sdr["PayFreight"]),
                                    ExFreight = Convert.ToDecimal(sdr["ExFreight"]),
                                });
                            }
                        }
                        con.Close();
                    }
                }
                List<ZSD_REAL_DATA_SRV_REAL> results = new List<ZSD_REAL_DATA_SRV_REAL>();
                results = lstsrvdeal;



                //return Json(new { errorcode = 1, errormessage = 1, Data = results }, JsonRequestBehavior.AllowGet);
                //return Json(new { data = results,length=999999 },"application/json",Encoding.UTF8,JsonRequestBehavior.AllowGet);
                //return new JsonResult() { Data = results, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                var jsonResult = Json(new { data = results, iTotalRecords = results.Count, iTotalDisplayRecords = results.Count }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;

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
                log1.WriteLine("YREALIZATION Error Message : " + ex.Message);
                log1.WriteLine("===========================================");
                log1.Close();
                return Json(new { errorcode=1 }, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

            }

        }
        public ActionResult Importdata(string startDate, String endDate)
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


                var url = "";
                string query = "";

                if (!System.IO.File.Exists(filename))
                {
                    log1 = new StreamWriter(filename, append: true);
                }
                else
                {
                    log1 = System.IO.File.AppendText(filename);
                }

                //Log.Info("===========================================");
                //Log.Info("Application From Date  " + startDate);
                //Log.Info("Application To Date  " + endDate);
                //Log.Info("Executed on : " + DateTime.Now);
                //LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);

                log1.WriteLine("===========================================");
                log1.WriteLine("Application From Date  " + startDate);
                log1.WriteLine("Application To Date  " + endDate);
                log1.WriteLine("Executed on : " + DateTime.Now);
                //log1.WriteLine("Table Name : YREALIZATION");

                //var url = "";
                //string query = "";
                int reccount = 0;
                //List<ZSD_REAL_DATA_SRV_REAL> lstsrvdeal = new List<ZSD_REAL_DATA_SRV_REAL>();

                //var formats = new[] { "ddMMyyyy", "yyyyMMdd", "yyyyMMdd" };

                //Development
                //url = "https://netwaver-dev.pennacement.com:443/sap/opu/odata/sap/ZSD_REAL_DATA_SRV/REALSet?$format=json&$filter=Erdat ge '" + startDate.Trim() + "' and Erdat le '" + endDate.Trim() + "'";
                //string userName = "NWGW001";
                //string passwd = "Penna@123";

                url = "https://netwaver-prd.pennacement.com:443/sap/opu/odata/sap/ZSD_REAL_DATA_SRV/REALSet?$format=json&$filter=Erdat ge '" + startDate.Trim() + "' and Erdat le '" + endDate.Trim() + "'";
                string userName = "NWGW037";
                string passwd = "Admin@123456";
                log1.WriteLine("Insert Table : YREALIZATION");

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
                    List<ZSD_REAL_DATA_SRV_REAL> varoutput = men1.ToObject<List<ZSD_REAL_DATA_SRV_REAL>>();
                    var o = JsonConvert.DeserializeObject<List<ZSD_REAL_DATA_SRV_REAL>>(men1.ToString());

                    Common converter = new Common();


                    DataTable dt = converter.ToDataTable(varoutput);

                    if (dt.Rows.Count > 0)
                    {
                        log1.WriteLine("WebApi Record Count : " + dt.Rows.Count);
                    }
                    else
                    {
                        log1.WriteLine("WebApi Record Count : 0");
                    }

                    query = "";
                    query += " Delete from YREALIZATION ";
                    query += " where date_format(cast(Erdat as date),'%Y%m%d') ";
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
                            query = "Insert into YREALIZATION(VBELN,VGBEL,AUBEL,ERDAT,FKART,REGIO,VKGRP,DSTRC,MNFPLANT,PLANT,GRADE,MATKL,KALKS,KDGRP,";
                            query += "FKDAT,MATNR,CUSTCODE1,CNAME1,CUSTCODE2,CNAME2,CUSTCODE3,CNAME3,COM_AG,COM_NAME,TRANS,TRANS_NAME,";
                            query += "LGORT,LGOBE,FKIMG,GROSSTURN,INCO1,INCO2,STPRS,PRIMARYFRI,SECONDARYFRI,EXWPF,EXGSF,SALESTAX,COMMISSION,";
                            query += "EXCISEDUTY,PDDISCOUNT,ODDISCOUNT,CFCHARGES,CDDISCOUNT,PACKING,UNLOADING,OCTRAI,VAT,IGST,CGST,";
                            query += "SGST,UGST,EXP_HAND,TRANSPORT,AMT_DW_FRT,PLT_FRT,NETTURN,NAKEDREAL,STATEDESC,SGRPDESC,DISDESC,GRADDESC,MNFDESC,";
                            query += "PLANTDESC,PGRPDESC,CDATE,TIME,SUSER,BLOCK_CT,ROUTE,CANCELDATE,CANCELFLAG,ZZLGORT1,BZIRK,VKBUR,ZZZONE1,";
                            query += "ZZBRANCH,PERNR_ER,ENAME_ER,PERNR_Y1,ENAME_Y1,PERNR_Y2,ENAME_Y2,PERNR_Y3,ENAME_Y3,PERNR_Y4,ENAME_Y4,PERNR_Y5,";
                            query += "ENAME_Y5,PERNR_Y6,ENAME_Y6,PERNR_Y7,ENAME_Y7,PERNR_Y8,ENAME_Y8,UPFRNT_DISCOUNT,IND_PRI_FRT,SHIP_FRT_CHRGS,";
                            query += "SHIP_HAND_CHRGS,ZCUST_GRP,ZCUST_GRP_DESC,Vc,ZsalePromValue,Waers,Msehi,PayFreight,ExFreight) Values ";
                            query += "(@VBELN,@VGBEL,@AUBEL,@ERDAT,@FKART,@REGIO,@VKGRP,@DSTRC,@MNFPLANT,@PLANT,@GRADE,@MATKL,@KALKS,@KDGRP,";
                            query += "@FKDAT,@MATNR,@CUSTCODE1,@CNAME1,@CUSTCODE2,@CNAME2,@CUSTCODE3,@CNAME3,@COM_AG,@COM_NAME,@TRANS,@TRANS_NAME,";
                            query += "@LGORT,@LGOBE,@FKIMG,@GROSSTURN,@INCO1,@INCO2,@STPRS,@PRIMARYFRI,@SECONDARYFRI,@EXWPF,@EXGSF,@SALESTAX,@COMMISSION,";
                            query += "@EXCISEDUTY,@PDDISCOUNT,@ODDISCOUNT,@CFCHARGES,@CDDISCOUNT,@PACKING,@UNLOADING,@OCTRAI,@VAT,@IGST,@CGST,";
                            query += "@SGST,@UGST,@EXP_HAND,@TRANSPORT,@AMT_DW_FRT,@PLT_FRT,@NETTURN,@NAKEDREAL,@STATEDESC,@SGRPDESC,@DISDESC,@GRADDESC,@MNFDESC,";
                            query += "@PLANTDESC,@PGRPDESC,@CDATE,@TIME,@SUSER,@BLOCK_CT,@ROUTE,@CANCELDATE,@CANCELFLAG,@ZZLGORT1,@BZIRK,@VKBUR,@ZZZONE1,";
                            query += "@ZZBRANCH,@PERNR_ER,@ENAME_ER,@PERNR_Y1,@ENAME_Y1,@PERNR_Y2,@ENAME_Y2,@PERNR_Y3,@ENAME_Y3,@PERNR_Y4,@ENAME_Y4,@PERNR_Y5,";
                            query += "@ENAME_Y5,@PERNR_Y6,@ENAME_Y6,@PERNR_Y7,@ENAME_Y7,@PERNR_Y8,@ENAME_Y8,@UPFRNT_DISCOUNT,@IND_PRI_FRT,@SHIP_FRT_CHRGS,";
                            query += "@SHIP_HAND_CHRGS,@ZCUST_GRP,@ZCUST_GRP_DESC,@Vc,@ZsalePromValue,@Waers,@Msehi,@PayFreight,@ExFreight);";
                            MySqlCommand cmd = new MySqlCommand(query, con);

                            cmd.Parameters.AddWithValue("@VBELN", row["VBELN"].ToString());
                            cmd.Parameters.AddWithValue("@VGBEL", row["VGBEL"].ToString());
                            cmd.Parameters.AddWithValue("@AUBEL", row["AUBEL"].ToString());
                            cmd.Parameters.AddWithValue("@ERDAT", row["ERDAT"].ToString());
                            cmd.Parameters.AddWithValue("@FKART", row["FKART"].ToString());
                            cmd.Parameters.AddWithValue("@REGIO", row["REGIO"].ToString());
                            cmd.Parameters.AddWithValue("@VKGRP", row["VKGRP"].ToString());
                            cmd.Parameters.AddWithValue("@DSTRC", row["DSTRC"].ToString());
                            cmd.Parameters.AddWithValue("@MNFPLANT", row["MNFPLANT"].ToString());
                            cmd.Parameters.AddWithValue("@PLANT", row["PLANT"].ToString());
                            cmd.Parameters.AddWithValue("@GRADE", row["GRADE"].ToString());
                            cmd.Parameters.AddWithValue("@MATKL", row["MATKL"].ToString());
                            cmd.Parameters.AddWithValue("@KALKS", row["KALKS"].ToString());
                            cmd.Parameters.AddWithValue("@KDGRP", row["KDGRP"].ToString());
                            cmd.Parameters.AddWithValue("@FKDAT", row["FKDAT"].ToString());
                            cmd.Parameters.AddWithValue("@MATNR", row["MATNR"].ToString());
                            cmd.Parameters.AddWithValue("@CUSTCODE1", row["CUSTCODE1"].ToString());
                            cmd.Parameters.AddWithValue("@CNAME1", row["CNAME1"].ToString());
                            cmd.Parameters.AddWithValue("@CUSTCODE2", row["CUSTCODE2"].ToString());
                            cmd.Parameters.AddWithValue("@CNAME2", row["CNAME2"].ToString());
                            cmd.Parameters.AddWithValue("@CUSTCODE3", row["CUSTCODE3"].ToString());
                            cmd.Parameters.AddWithValue("@CNAME3", row["CNAME3"].ToString());
                            cmd.Parameters.AddWithValue("@COM_AG", row["COMAG"].ToString());
                            cmd.Parameters.AddWithValue("@COM_NAME", row["COMNAME"].ToString());
                            cmd.Parameters.AddWithValue("@TRANS", row["TRANS"].ToString());
                            cmd.Parameters.AddWithValue("@TRANS_NAME", row["TRANSNAME"].ToString());
                            cmd.Parameters.AddWithValue("@LGORT", row["LGORT"].ToString());
                            cmd.Parameters.AddWithValue("@LGOBE", row["LGOBE"].ToString());
                            cmd.Parameters.AddWithValue("@FKIMG", row["FKIMG"].ToString());
                            cmd.Parameters.AddWithValue("@GROSSTURN", row["GROSSTURN"].ToString());
                            cmd.Parameters.AddWithValue("@INCO1", row["INCO1"].ToString());
                            cmd.Parameters.AddWithValue("@INCO2", row["INCO2"].ToString());
                            cmd.Parameters.AddWithValue("@STPRS", row["STPRS"].ToString());
                            cmd.Parameters.AddWithValue("@PRIMARYFRI", row["PRIMARYFRI"].ToString());
                            cmd.Parameters.AddWithValue("@SECONDARYFRI", row["SECONDARYFRI"].ToString());
                            cmd.Parameters.AddWithValue("@EXWPF", row["EXWPF"].ToString());
                            cmd.Parameters.AddWithValue("@EXGSF", row["EXGSF"].ToString());
                            cmd.Parameters.AddWithValue("@SALESTAX", row["SALESTAX"].ToString());
                            cmd.Parameters.AddWithValue("@COMMISSION", row["COMMISSION"].ToString());
                            cmd.Parameters.AddWithValue("@EXCISEDUTY", row["EXCISEDUTY"].ToString());
                            cmd.Parameters.AddWithValue("@PDDISCOUNT", row["PDDISCOUNT"].ToString());
                            cmd.Parameters.AddWithValue("@ODDISCOUNT", row["ODDISCOUNT"].ToString());
                            cmd.Parameters.AddWithValue("@CFCHARGES", row["CFCHARGES"].ToString());
                            cmd.Parameters.AddWithValue("@CDDISCOUNT", row["CDDISCOUNT"].ToString());
                            cmd.Parameters.AddWithValue("@PACKING", row["PACKING"].ToString());
                            cmd.Parameters.AddWithValue("@UNLOADING", row["UNLOADING"].ToString());
                            cmd.Parameters.AddWithValue("@OCTRAI", row["OCTRAI"].ToString());
                            cmd.Parameters.AddWithValue("@VAT", row["VAT"].ToString());
                            cmd.Parameters.AddWithValue("@IGST", row["IGST"].ToString());
                            cmd.Parameters.AddWithValue("@CGST", row["CGST"].ToString());
                            cmd.Parameters.AddWithValue("@SGST", row["SGST"].ToString());
                            cmd.Parameters.AddWithValue("@UGST", row["UGST"].ToString());
                            cmd.Parameters.AddWithValue("@EXP_HAND", row["EXPHAND"].ToString());
                            cmd.Parameters.AddWithValue("@TRANSPORT", row["TRANSPORT"].ToString());
                            cmd.Parameters.AddWithValue("@AMT_DW_FRT", row["AMTDWFRT"].ToString());
                            cmd.Parameters.AddWithValue("@PLT_FRT", row["PLTFRT"].ToString());
                            cmd.Parameters.AddWithValue("@NETTURN", row["NETTURN"].ToString());
                            cmd.Parameters.AddWithValue("@NAKEDREAL", row["NAKEDREAL"].ToString());
                            cmd.Parameters.AddWithValue("@STATEDESC", row["STATEDESC"].ToString());
                            cmd.Parameters.AddWithValue("@SGRPDESC", row["SGRPDESC"].ToString());
                            cmd.Parameters.AddWithValue("@DISDESC", row["DISDESC"].ToString());
                            cmd.Parameters.AddWithValue("@GRADDESC", row["GRADDESC"].ToString());
                            cmd.Parameters.AddWithValue("@MNFDESC", row["MNFDESC"].ToString());
                            cmd.Parameters.AddWithValue("@PLANTDESC", row["PLANTDESC"].ToString());
                            cmd.Parameters.AddWithValue("@PGRPDESC", row["PGRPDESC"].ToString());
                            cmd.Parameters.AddWithValue("@CDATE", row["CDATE"].ToString());
                            cmd.Parameters.AddWithValue("@TIME", row["TIME"].ToString());
                            cmd.Parameters.AddWithValue("@SUSER", row["SUSER"].ToString());
                            cmd.Parameters.AddWithValue("@BLOCK_CT", row["BLOCKCT"].ToString());
                            cmd.Parameters.AddWithValue("@ROUTE", row["ROUTE"].ToString());
                            cmd.Parameters.AddWithValue("@CANCELDATE", row["CANCELDATE"].ToString());
                            cmd.Parameters.AddWithValue("@CANCELFLAG", row["CANCELFLAG"].ToString());
                            cmd.Parameters.AddWithValue("@ZZLGORT1", row["ZZLGORT1"].ToString());
                            cmd.Parameters.AddWithValue("@BZIRK", row["BZIRK"].ToString());
                            cmd.Parameters.AddWithValue("@VKBUR", row["VKBUR"].ToString());
                            cmd.Parameters.AddWithValue("@ZZZONE1", row["ZZZONE1"].ToString());
                            cmd.Parameters.AddWithValue("@ZZBRANCH", row["ZZBRANCH"].ToString());
                            cmd.Parameters.AddWithValue("@PERNR_ER", row["PERNRER"].ToString());
                            cmd.Parameters.AddWithValue("@ENAME_ER", row["ENAMEER"].ToString());
                            cmd.Parameters.AddWithValue("@PERNR_Y1", row["PERNRY1"].ToString());
                            cmd.Parameters.AddWithValue("@ENAME_Y1", row["ENAMEY1"].ToString());
                            cmd.Parameters.AddWithValue("@PERNR_Y2", row["PERNRY2"].ToString());
                            cmd.Parameters.AddWithValue("@ENAME_Y2", row["ENAMEY2"].ToString());
                            cmd.Parameters.AddWithValue("@PERNR_Y3", row["PERNRY3"].ToString());
                            cmd.Parameters.AddWithValue("@ENAME_Y3", row["ENAMEY3"].ToString());
                            cmd.Parameters.AddWithValue("@PERNR_Y4", row["PERNRY4"].ToString());
                            cmd.Parameters.AddWithValue("@ENAME_Y4", row["ENAMEY4"].ToString());
                            cmd.Parameters.AddWithValue("@PERNR_Y5", row["PERNRY5"].ToString());
                            cmd.Parameters.AddWithValue("@ENAME_Y5", row["ENAMEY5"].ToString());
                            cmd.Parameters.AddWithValue("@PERNR_Y6", row["PERNRY6"].ToString());
                            cmd.Parameters.AddWithValue("@ENAME_Y6", row["ENAMEY6"].ToString());
                            cmd.Parameters.AddWithValue("@PERNR_Y7", row["PERNRY7"].ToString());
                            cmd.Parameters.AddWithValue("@ENAME_Y7", row["ENAMEY7"].ToString());
                            cmd.Parameters.AddWithValue("@PERNR_Y8", row["PERNRY8"].ToString());
                            cmd.Parameters.AddWithValue("@ENAME_Y8", row["ENAMEY8"].ToString());
                            cmd.Parameters.AddWithValue("@UPFRNT_DISCOUNT", row["UPFRNTDISCOUNT"].ToString());
                            cmd.Parameters.AddWithValue("@IND_PRI_FRT", row["INDPRIFRT"].ToString());
                            cmd.Parameters.AddWithValue("@SHIP_FRT_CHRGS", row["SHIPFRTCHRGS"].ToString());
                            cmd.Parameters.AddWithValue("@SHIP_HAND_CHRGS", row["SHIPHANDCHRGS"].ToString());
                            cmd.Parameters.AddWithValue("@ZCUST_GRP", row["ZCUSTGRP"].ToString());
                            cmd.Parameters.AddWithValue("@ZCUST_GRP_DESC", row["ZCUSTGRPDESC"].ToString());
                            cmd.Parameters.AddWithValue("@Vc", row["Vc"].ToString());
                            cmd.Parameters.AddWithValue("@ZsalePromValue", row["ZsalePromValue"].ToString());
                            cmd.Parameters.AddWithValue("@Waers", row["Waers"].ToString());
                            cmd.Parameters.AddWithValue("@Msehi", row["Msehi"].ToString());
                            cmd.Parameters.AddWithValue("@PayFreight", row["PayFreight"].ToString());
                            cmd.Parameters.AddWithValue("@ExFreight", row["ExFreight"].ToString());

                            cmd.CommandType = CommandType.Text;

                            int result = cmd.ExecuteNonQuery();

                            if (result == 1)
                            {
                                i = i + 1;
                            }
                            else
                            {
                                return Json(new { errorcode = 1, errormessage = 1 }, JsonRequestBehavior.AllowGet);

                            }

                        }

                    }

                    log1.WriteLine("Executed End : " + DateTime.Now);
                    query = "";
                    query += " Select Count(*) Cnt from YREALIZATION ";
                    query += " where date_format(cast(Erdat as date),'%Y%m%d') ";
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
                        query += " Delete from YREALIZATION ";
                        query += " where date_format(cast(Erdat as date),'%Y%m%d') ";
                        query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";

                        using (MySqlConnection sqlCon = new MySqlConnection(CS))
                        {
                            sqlCon.Open();
                            MySqlCommand Cmnd = new MySqlCommand(query, sqlCon);

                            int result = Cmnd.ExecuteNonQuery();

                            sqlCon.Close();
                        }


                        query = "";
                        query += " Select Count(*) Cnt from YREALIZATION ";
                        query += " where date_format(cast(Erdat as date),'%Y%m%d') ";
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
                //Import_Data imp = new Import_Data();
                //imp.Insert_YREALIZATION(startDate.Trim(), endDate.Trim());
                //Insert_YREALIZATION(startDate.Trim(), endDate.Trim());
                return Json(new { errorcode = 0, errormessage = 0 }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {
                return Json(new { errorcode = 1, errormessage = 1 }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Exportdata(string startDate, string endDate)
        {
            string filename = System.Configuration.ConfigurationManager.AppSettings["LogFile"].ToString();

            try
            {

                DataTable dt1 = new DataTable("YREALIZATION");
                dt1.Columns.AddRange(new DataColumn[107]
                {
                            new DataColumn("Billing Document"),
                            new DataColumn("Reference Document"),
                            new DataColumn("Sales Document"),
                            new DataColumn("Creation Date"),
                            new DataColumn("Billing Type"),
                            new DataColumn("State code"),
                            new DataColumn("Sales Group code"),
                            new DataColumn("District code"),
                            new DataColumn("Manfuacture Plant"),
                            new DataColumn("Plant"),
                            new DataColumn("Material Pricing Group"),
                            new DataColumn("Material Group"),
                            new DataColumn("Pricing procedure "),
                            new DataColumn("Customer group"),
                            new DataColumn("Billing Date "),
                            new DataColumn("Material Number"),
                            new DataColumn("Customer Code"),
                            new DataColumn("Customer Name"),
                            new DataColumn("Sales Rep code"),
                            new DataColumn("Sales Rep Name"),
                            new DataColumn("Consignee Code"),
                            new DataColumn("Consignee Name"),
                            new DataColumn("Commission Agent code"),
                            new DataColumn("Commission Agenet Name"),
                            new DataColumn("Transporter Code"),
                            new DataColumn("Transporter Name"),
                            new DataColumn("Storage Location"),
                            new DataColumn("Description of Storage Location"),
                            new DataColumn("Billed quantity"),
                            new DataColumn("Gross Turnover"),
                            new DataColumn("Incoterms1"),
                            new DataColumn("Incoterms2"),
                            new DataColumn("Standard price"),
                            new DataColumn("Primary Freight"),
                            new DataColumn("Secondary freight"),
                            new DataColumn("Ex-Works Primary Freight"),
                            new DataColumn("Ex-Works Secondary Freight"),
                            new DataColumn("Sales Tax"),
                            new DataColumn("Commission"),
                            new DataColumn("Excise Duty"),
                            new DataColumn("Price Discount"),
                            new DataColumn("Other Discount"),
                            new DataColumn("CFA charges"),
                            new DataColumn("Cash Discount"),
                            new DataColumn("Packing Charges"),
                            new DataColumn("Unloading Charges"),
                            new DataColumn("Octrai"),
                            new DataColumn("VAT"),
                            new DataColumn("IGST"),
                            new DataColumn("CGST"),
                            new DataColumn("SGST"),
                            new DataColumn("UGST"),
                            new DataColumn("Export Handling chgs"),
                            new DataColumn("Transport Incentive"),
                            new DataColumn("Demurrage Wharfage"),
                            new DataColumn("Plant freight"),
                            new DataColumn("Net Turnrover"),
                            new DataColumn("Realisation"),
                            new DataColumn("State Name"),
                            new DataColumn("Branch"),
                            new DataColumn("Distrct Name"),
                            new DataColumn("Grade"),
                            new DataColumn("Manfacture Plant name"),
                            new DataColumn("Plant Name"),
                            new DataColumn("Customer Group Name"),
                            new DataColumn("System Date"),
                            new DataColumn("System Time"),
                            new DataColumn("User Name"),
                            new DataColumn("Block Category"),
                            new DataColumn("Description of Route"),
                            new DataColumn("Date on Which Record Was Created"),
                            new DataColumn("Single-Character Flag"),
                            new DataColumn("Moving Storage loc "),
                            new DataColumn("Sales district"),
                            new DataColumn("Sales Office"),
                            new DataColumn("Transportation zone"),
                            new DataColumn("Branch Office"),
                            new DataColumn("Sales Officer Emp.No."),
                            new DataColumn("Sales Officer Emp.Name"),
                            new DataColumn("RM1"),
                            new DataColumn("RM1 Name"),
                            new DataColumn("RM2 "),
                            new DataColumn("RM2 Name"),
                            new DataColumn("RM3"),
                            new DataColumn("RM3 Name"),
                            new DataColumn("RM4"),
                            new DataColumn("RM4 Name"),
                            new DataColumn("RM5"),
                            new DataColumn("RM5 Name"),
                            new DataColumn("RM6"),
                            new DataColumn("RM6 Name"),
                            new DataColumn("RM7"),
                            new DataColumn("RM7 Name"),
                            new DataColumn("RM8"),
                            new DataColumn("RM8 Name"),
                            new DataColumn("Upfront Discount Amount"),
                            new DataColumn("Indirect Primary Freight"),
                            new DataColumn("Ship Freight"),
                            new DataColumn("Ship Handling Charges"),
                            new DataColumn("Customer group_1"),
                            new DataColumn("Customer Group Desc."),
                            new DataColumn("Varible Cost"),
                            new DataColumn("ZsalePromValue"),
                            new DataColumn("Waers"),
                            new DataColumn("Msehi"),
                            new DataColumn("PayFreight"),
                            new DataColumn("ExFreight")



                 });

                using (MySqlConnection con = new MySqlConnection(CS))
                {
                    string query = "";
                    query += " Select * from YREALIZATION ";
                    query += " where date_format(cast(ERDAT as date),'%Y%m%d') ";
                    query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";
                    query += " order by date_format(cast(Erdat as date),'%Y%m%d') ";
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {

                        cmd.Connection = con;
                        con.Open();
                        using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                DataRow _dr = dt1.NewRow();


                                _dr["Billing Document"] = Convert.ToString(sdr["VBELN"]);
                                _dr["Reference Document"] = Convert.ToString(sdr["VGBEL"]);
                                _dr["Sales Document"] = Convert.ToString(sdr["AUBEL"]);
                                _dr["Creation Date"] = Convert.ToString(sdr["ERDAT"]);
                                _dr["Billing Type"] = Convert.ToString(sdr["FKART"]);
                                _dr["State code"] = Convert.ToString(sdr["REGIO"]);
                                _dr["Sales Group code"] = Convert.ToString(sdr["VKGRP"]);
                                _dr["District code"] = Convert.ToString(sdr["DSTRC"]);
                                _dr["Manfuacture Plant"] = Convert.ToString(sdr["MNFPLANT"]);
                                _dr["Plant"] = Convert.ToString(sdr["PLANT"]);
                                _dr["Material Pricing Group"] = Convert.ToString(sdr["GRADE"]);
                                _dr["Material Group"] = Convert.ToString(sdr["MATKL"]);
                                _dr["Pricing procedure "] = Convert.ToString(sdr["KALKS"]);
                                _dr["Customer group"] = Convert.ToString(sdr["KDGRP"]);
                                _dr["Billing Date "] = Convert.ToString(sdr["FKDAT"]);
                                _dr["Material Number"] = Convert.ToString(sdr["MATNR"]);
                                _dr["Customer Code"] = Convert.ToString(sdr["CUSTCODE1"]);
                                _dr["Customer Name"] = Convert.ToString(sdr["CNAME1"]);
                                _dr["Sales Rep code"] = Convert.ToString(sdr["CUSTCODE2"]);
                                _dr["Sales Rep Name"] = Convert.ToString(sdr["CNAME2"]);
                                _dr["Consignee Code"] = Convert.ToString(sdr["CUSTCODE3"]);
                                _dr["Consignee Name"] = Convert.ToString(sdr["CNAME3"]);
                                _dr["Commission Agent code"] = Convert.ToString(sdr["COM_AG"]);
                                _dr["Commission Agenet Name"] = Convert.ToString(sdr["COM_NAME"]);
                                _dr["Transporter Code"] = Convert.ToString(sdr["TRANS"]);
                                _dr["Transporter Name"] = Convert.ToString(sdr["TRANS_NAME"]);
                                _dr["Storage Location"] = Convert.ToString(sdr["LGORT"]);
                                _dr["Description of Storage Location"] = Convert.ToString(sdr["LGOBE"]);
                                _dr["Billed quantity"] = Convert.ToDecimal(sdr["FKIMG"]);
                                _dr["Gross Turnover"] = Convert.ToDecimal(sdr["GROSSTURN"]);
                                _dr["Incoterms1"] = Convert.ToString(sdr["INCO1"]);
                                _dr["Incoterms2"] = Convert.ToString(sdr["INCO2"]);
                                _dr["Standard price"] = Convert.ToDecimal(sdr["STPRS"]);
                                _dr["Primary Freight"] = Convert.ToDecimal(sdr["PRIMARYFRI"]);
                                _dr["Secondary freight"] = Convert.ToDecimal(sdr["SECONDARYFRI"]);
                                _dr["Ex-Works Primary Freight"] = Convert.ToDecimal(sdr["EXWPF"]);
                                _dr["Ex-Works Secondary Freight"] = Convert.ToDecimal(sdr["EXGSF"]);
                                _dr["Sales Tax"] = Convert.ToDecimal(sdr["SALESTAX"]);
                                _dr["Commission"] = Convert.ToDecimal(sdr["COMMISSION"]);
                                _dr["Excise Duty"] = Convert.ToDecimal(sdr["EXCISEDUTY"]);
                                _dr["Price Discount"] = Convert.ToDecimal(sdr["PDDISCOUNT"]);
                                _dr["Other Discount"] = Convert.ToDecimal(sdr["ODDISCOUNT"]);
                                _dr["CFA charges"] = Convert.ToDecimal(sdr["CFCHARGES"]);
                                _dr["Cash Discount"] = Convert.ToDecimal(sdr["CDDISCOUNT"]);
                                _dr["Packing Charges"] = Convert.ToDecimal(sdr["PACKING"]);
                                _dr["Unloading Charges"] = Convert.ToDecimal(sdr["UNLOADING"]);
                                _dr["Octrai"] = Convert.ToDecimal(sdr["OCTRAI"]);
                                _dr["VAT"] = Convert.ToDecimal(sdr["VAT"]);
                                _dr["IGST"] = Convert.ToDecimal(sdr["IGST"]);
                                _dr["CGST"] = Convert.ToDecimal(sdr["CGST"]);
                                _dr["SGST"] = Convert.ToDecimal(sdr["SGST"]);
                                _dr["UGST"] = Convert.ToDecimal(sdr["UGST"]);
                                _dr["Export Handling chgs"] = Convert.ToDecimal(sdr["EXP_HAND"]);
                                _dr["Transport Incentive"] = Convert.ToDecimal(sdr["TRANSPORT"]);
                                _dr["Demurrage Wharfage"] = Convert.ToDecimal(sdr["AMT_DW_FRT"]);
                                _dr["Plant freight"] = Convert.ToDecimal(sdr["PLT_FRT"]);
                                _dr["Net Turnrover"] = Convert.ToDecimal(sdr["NETTURN"]);
                                _dr["Realisation"] = Convert.ToDecimal(sdr["NAKEDREAL"]);
                                _dr["State Name"] = Convert.ToString(sdr["STATEDESC"]);
                                _dr["Branch"] = Convert.ToString(sdr["SGRPDESC"]);
                                _dr["Distrct Name"] = Convert.ToString(sdr["DISDESC"]);
                                _dr["Grade"] = Convert.ToString(sdr["GRADDESC"]);
                                _dr["Manfacture Plant name"] = Convert.ToString(sdr["MNFDESC"]);
                                _dr["Plant Name"] = Convert.ToString(sdr["PLANTDESC"]);
                                _dr["Customer Group Name"] = Convert.ToString(sdr["PGRPDESC"]);
                                _dr["System Date"] = Convert.ToString(sdr["CDATE"]);
                                _dr["System Time"] = Convert.ToString(sdr["TIME"]);
                                _dr["User Name"] = Convert.ToString(sdr["SUSER"]);
                                _dr["Block Category"] = Convert.ToString(sdr["BLOCK_CT"]);
                                _dr["Description of Route"] = Convert.ToString(sdr["ROUTE"]);
                                _dr["Date on Which Record Was Created"] = Convert.ToString(sdr["CANCELDATE"]);
                                _dr["Single-Character Flag"] = Convert.ToString(sdr["CANCELFLAG"]);
                                _dr["Moving Storage loc "] = Convert.ToString(sdr["ZZLGORT1"]);
                                _dr["Sales district"] = Convert.ToString(sdr["BZIRK"]);
                                _dr["Sales Office"] = Convert.ToString(sdr["VKBUR"]);
                                _dr["Transportation zone"] = Convert.ToString(sdr["ZZZONE1"]);
                                _dr["Branch Office"] = Convert.ToString(sdr["ZZBRANCH"]);
                                _dr["Sales Officer Emp.No."] = Convert.ToString(sdr["PERNR_ER"]);
                                _dr["Sales Officer Emp.Name"] = Convert.ToString(sdr["ENAME_ER"]);
                                _dr["RM1"] = Convert.ToString(sdr["PERNR_Y1"]);
                                _dr["RM1 Name"] = Convert.ToString(sdr["ENAME_Y1"]);
                                _dr["RM2 "] = Convert.ToString(sdr["PERNR_Y2"]);
                                _dr["RM2 Name"] = Convert.ToString(sdr["ENAME_Y2"]);
                                _dr["RM3"] = Convert.ToString(sdr["PERNR_Y3"]);
                                _dr["RM3 Name"] = Convert.ToString(sdr["ENAME_Y3"]);
                                _dr["RM4"] = Convert.ToString(sdr["PERNR_Y4"]);
                                _dr["RM4 Name"] = Convert.ToString(sdr["ENAME_Y4"]);
                                _dr["RM5"] = Convert.ToString(sdr["PERNR_Y5"]);
                                _dr["RM5 Name"] = Convert.ToString(sdr["ENAME_Y5"]);
                                _dr["RM6"] = Convert.ToString(sdr["PERNR_Y6"]);
                                _dr["RM6 Name"] = Convert.ToString(sdr["ENAME_Y6"]);
                                _dr["RM7"] = Convert.ToString(sdr["PERNR_Y7"]);
                                _dr["RM7 Name"] = Convert.ToString(sdr["ENAME_Y7"]);
                                _dr["RM8"] = Convert.ToString(sdr["PERNR_Y8"]);
                                _dr["RM8 Name"] = Convert.ToString(sdr["ENAME_Y8"]);
                                _dr["Upfront Discount Amount"] = Convert.ToDecimal(sdr["UPFRNT_DISCOUNT"]);
                                _dr["Indirect Primary Freight"] = Convert.ToDecimal(sdr["IND_PRI_FRT"]);
                                _dr["Ship Freight"] = Convert.ToDecimal(sdr["SHIP_FRT_CHRGS"]);
                                _dr["Ship Handling Charges"] = Convert.ToDecimal(sdr["SHIP_HAND_CHRGS"]);
                                _dr["Customer group_1"] = Convert.ToString(sdr["ZCUST_GRP"]);
                                _dr["Customer Group Desc."] = Convert.ToString(sdr["ZCUST_GRP_DESC"]);
                                _dr["Varible Cost"] = Convert.ToDecimal(sdr["VC"]);
                                _dr["ZsalePromValue"] = Convert.ToDecimal(sdr["ZsalePromValue"]);
                                _dr["Waers"] = Convert.ToString(sdr["Waers"]);
                                _dr["Msehi"] = Convert.ToString(sdr["Msehi"]);
                                _dr["PayFreight"] = Convert.ToDecimal(sdr["PayFreight"]);
                                _dr["ExFreight"] = Convert.ToDecimal(sdr["ExFreight"]);


                                dt1.Rows.Add(_dr);

                            }
                        }
                        con.Close();
                    }



                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dt1);
                        using (MemoryStream stream = new MemoryStream())
                        {
                            wb.SaveAs(stream);
                           // return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "yrealization.xlsx");
                            return Json(new { errorcode = 0,stream= stream.ToArray(),Name= "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",filename= "yrealization.xlsx" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
               //return Json(new { errorcode = 0, errormessage = 0 }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {
                return Json(new { errorcode = 0, errormessage = 0 }, JsonRequestBehavior.AllowGet);


            }
        }
        public ActionResult LogiImport(string startDate,string endDate)
        {
            string filename = System.Configuration.ConfigurationManager.AppSettings["LogFile"].ToString();

            try
            {

                string query = "";

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
                    //List<ZSD_LCOST_DATA_SRV> lstsrvdeal = new List<ZSD_LCOST_DATA_SRV>();

                    //var formats = new[] { "ddMMyyyy", "yyyyMMdd", "yyyyMMdd" };


                    string startDateOrig = startDate;
                    string endDateOrig = endDate;
                    startDate = DateTime.ParseExact(startDate, "yyyyMMdd", null).ToString("yyyyMMdd");
                    endDate = DateTime.ParseExact(endDate, "yyyyMMdd", null).ToString("yyyyMMdd");

                    //Development
                    //var url = "https://netwaver-dev.pennacement.com:443/sap/opu/odata/sap/ZSD_LCOST_DATA_SRV/LOGI_COSTSet?$format=json&$filter=Fkdat ge '" + startDateOrig.Trim() + "' and Fkdat le '" + endDateOrig.Trim() + "'";
                    //string userName = "NWGW001";
                    //string passwd = "Penna@123";

                    var url = "https://netwaver-prd.pennacement.com:443/sap/opu/odata/sap/ZSD_LCOST_DATA_SRV/LOGI_COSTSet?$format=json&$filter=Fkdat ge '" + startDateOrig.Trim() + "' and Fkdat le '" + endDateOrig.Trim() + "'";

                    string userName = "NWGW037";
                    string passwd = "Admin@123456";

                    log1.WriteLine("Insert Table : ZSD_LCOST_DATA_SRV");

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
                        List<ZSD_LCOST_DATA_SRV> varoutput = men1.ToObject<List<ZSD_LCOST_DATA_SRV>>();
                        var o = JsonConvert.DeserializeObject<List<ZSD_LCOST_DATA_SRV>>(men1.ToString());

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
                        query = " Delete from ZSD_LCOST_DATA_SRV ";
                        query += " where date_format(cast(Fkdat as date),'%Y%m%d') ";
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
                                //flag = false;
                                query = "Insert into ZSD_LCOST_DATA_SRV(VBELN,FKART,FKDAT,FKIMG,MEINS,WERKS,W_NAME1,ZSOURCE,ZSOURCED,ZTRATYP,ZTRATYPD,KUNNR,KUNNR_N,KUNAG,";
                                query += "KUNAG_N,PTNR,PTNR_N,SALSREP,SALSREP_N,REGIO,REGIO_N,DSTRC,DSTRC_N,BLOCK,BLOCK_N,DESTINT,";
                                query += "DESTINT_N,KDGRP,KTEXT,PRIMARY_FRT,SECONDRY_FRT,RAKNO,RAKPT,MATKL,LGORT,LGOBE,INCO1,INCO2,ULDG_CHGS,";
                                query += "TRNS_CHGS,DPUL_CHGS,DPLD_CHGS,DIVR_CHGS,LDNG_CHGS,CFAG_CHGS,RKSR_CHGS,PULD_CHGS,RKCL_CHGS,SHNT_CHGS,RKCF_CHGS,";
                                query += "BLND_CHGS,BLNB_CHGS,MISC_MISC,ZZZONE1,ZZZONE1_N,ZZBZIRK,ZZBZIRK_N,ZZREGIO,ZZREGIO_N,VKBUR,VKBUR_N,VKGRP,VKGRP_N,";
                                query += "ZZBRANCH,ZZBRANCH_N,PDSTN,SDSTN,BLOCK_CT,BELNR,GJAHR,INV_TYPE,FRT_TYPE,ZZVLFKZ,SUPP_PLANT_NAME,DEPO_RK_MVT,IND_PRI_FRT,";
                                query += "SHIP_FRT_CHRGS,SHIP_HAND_CHRGS,CLKMNFPLANT,SUPPPLANT,DISTANCE,INDPDISTANCE,CLK_PLT_NAME,MNF_PLT_NAME,GEIND_PLT,GEIND_PLT_NAME,SUPPL_DEPO,SUPPL_DEPO_NAME,";
                                query += "WAERK,RENT,RAKEDEMCHRG,LDISTANCE,LDISTANCE_CLK,MATNR,VTEXT,MATNR1,MAKTX,INCURREDCOST,";
                                query += "UNINCURREDCOST,SH_REGIO,SH_DSTRC,SH_BLOCK,SH_DESTINT,KALKS,DELIVERY_NO,TKNUM,MNFPLANT,MNFDESC,MVGR1,GROSSTURN,NETTURN,";
                                query += "NAKEDREAL,TRANS_INCENTIVE,PLT_FRT,SP_REGIO,SP_DSTRC,SP_BLOCK,SP_DESTINT,TRAID,TRUCK_TYPE,EWB_NO,EDATE,EVDATE,STEUC,";
                                query += "PAID_PRICE,KALKS_DESC,SP_REGIO_DESC, SP_DSTRC_DESC,SP_BLOCK_DESC,SP_DESTINT_DESC,MF_PLANT_TYPE,TOTAL_TDC_COST,TOTAL_DISTANCE,DEPOT_IND_FRIEGHT,TOTAL_INVOICE_FRT,";
                                query += "ROAD_PF_INCURRED,ROAD_PF_UNINCURRED,ROAD_SF_INCURRED,ROAD_SF_UNINCURRED,RAIL_PF_INCURRED,RAIL_PF_UNINCURRED,DRDL_CHGS,DB_LAB_CHGS,ZINV_CANCEL,SH_DESTINT_DESC,SHIP_DISTANCE ) Values ";
                                query += "(@VBELN,@FKART,@FKDAT,@FKIMG,@MEINS,@WERKS,@W_NAME1,@ZSOURCE,@ZSOURCED,@ZTRATYP,@ZTRATYPD,@KUNNR,@KUNNR_N,@KUNAG,";
                                query += "@KUNAG_N,@PTNR,@PTNR_N,@SALSREP,@SALSREP_N,@REGIO,@REGIO_N,@DSTRC,@DSTRC_N,@BLOCK,@BLOCK_N,@DESTINT,";
                                query += "@DESTINT_N,@KDGRP,@KTEXT,@PRIMARY_FRT,@SECONDRY_FRT,@RAKNO,@RAKPT,@MATKL,@LGORT,@LGOBE,@INCO1,@INCO2,@ULDG_CHGS,";
                                query += "@TRNS_CHGS,@DPUL_CHGS,@DPLD_CHGS,@DIVR_CHGS,@LDNG_CHGS,@CFAG_CHGS,@RKSR_CHGS,@PULD_CHGS,@RKCL_CHGS,@SHNT_CHGS,@RKCF_CHGS,";
                                query += "@BLND_CHGS,@BLNB_CHGS,@MISC_MISC,@ZZZONE1,@ZZZONE1_N,@ZZBZIRK,@ZZBZIRK_N,@ZZREGIO,@ZZREGIO_N,@VKBUR,@VKBUR_N,@VKGRP,@VKGRP_N,";
                                query += "@ZZBRANCH,@ZZBRANCH_N,@PDSTN,@SDSTN,@BLOCK_CT,@BELNR,@GJAHR,@INV_TYPE,@FRT_TYPE,@ZZVLFKZ,@SUPP_PLANT_NAME,@DEPO_RK_MVT,@IND_PRI_FRT,";
                                query += "@SHIP_FRT_CHRGS,@SHIP_HAND_CHRGS,@CLKMNFPLANT,@SUPPPLANT,@DISTANCE,@INDPDISTANCE,@CLK_PLT_NAME,@MNF_PLT_NAME,@GEIND_PLT,@GEIND_PLT_NAME,@SUPPL_DEPO,@SUPPL_DEPO_NAME,";
                                query += "@WAERK,@RENT,@RAKEDEMCHRG,@LDISTANCE,@LDISTANCE_CLK,@MATNR,@VTEXT,@MATNR1,@MAKTX,@INCURREDCOST,";
                                query += "@UNINCURREDCOST,@SH_REGIO,@SH_DSTRC,@SH_BLOCK,@SH_DESTINT,@KALKS,@DELIVERY_NO,@TKNUM,@MNFPLANT,@MNFDESC,@MVGR1,@GROSSTURN,@NETTURN,";
                                query += "@NAKEDREAL,@TRANS_INCENTIVE,@PLT_FRT,@SP_REGIO,@SP_DSTRC,@SP_BLOCK,@SP_DESTINT,@TRAID,@TRUCK_TYPE,@EWB_NO,@EDATE,@EVDATE,@STEUC,";
                                query += "@PAID_PRICE,@KALKS_DESC,@SP_REGIO_DESC,@SP_DSTRC_DESC,@SP_BLOCK_DESC,@SP_DESTINT_DESC,@MF_PLANT_TYPE,@TOTAL_TDC_COST,@TOTAL_DISTANCE,@DEPOT_IND_FRIEGHT,@TOTAL_INVOICE_FRT,";
                                query += "@ROAD_PF_INCURRED,@ROAD_PF_UNINCURRED,@ROAD_SF_INCURRED,@ROAD_SF_UNINCURRED,@RAIL_PF_INCURRED,@RAIL_PF_UNINCURRED,@DRDL_CHGS,@DB_LAB_CHGS,@ZINV_CANCEL,@SH_DESTINT_DESC,@SHIP_DISTANCE);";
                                MySqlCommand cmd = new MySqlCommand(query, con);

                                cmd.Parameters.AddWithValue("@VBELN", row["VBELN"].ToString());
                                cmd.Parameters.AddWithValue("@FKART", row["FKART"].ToString());
                                cmd.Parameters.AddWithValue("@FKDAT", row["FKDAT"].ToString());
                                cmd.Parameters.AddWithValue("@FKIMG", row["FKIMG"].ToString());
                                cmd.Parameters.AddWithValue("@MEINS", row["MEINS"].ToString());
                                cmd.Parameters.AddWithValue("@WERKS", row["WERKS"].ToString());

                                cmd.Parameters.AddWithValue("@W_NAME1", row["WNAME1"].ToString());
                                cmd.Parameters.AddWithValue("@ZSOURCE", row["ZSOURCE"].ToString());
                                cmd.Parameters.AddWithValue("@ZSOURCED", row["ZSOURCED"].ToString());
                                cmd.Parameters.AddWithValue("@ZTRATYP", row["ZTRATYP"].ToString());
                                cmd.Parameters.AddWithValue("@ZTRATYPD", row["ZTRATYPD"].ToString());
                                cmd.Parameters.AddWithValue("@KUNNR", row["KUNNR"].ToString());
                                cmd.Parameters.AddWithValue("@KUNNR_N", row["KUNNRN"].ToString());
                                cmd.Parameters.AddWithValue("@KUNAG", row["KUNAG"].ToString());
                                cmd.Parameters.AddWithValue("@KUNAG_N", row["KUNAGN"].ToString());
                                cmd.Parameters.AddWithValue("@PTNR", row["PTNR"].ToString());
                                cmd.Parameters.AddWithValue("@PTNR_N", row["PTNRN"].ToString());
                                cmd.Parameters.AddWithValue("@SALSREP", row["SALSREP"].ToString());
                                cmd.Parameters.AddWithValue("@SALSREP_N", row["SALSREPN"].ToString());
                                cmd.Parameters.AddWithValue("@REGIO", row["REGIO"].ToString());
                                cmd.Parameters.AddWithValue("@REGIO_N", row["REGION"].ToString());
                                cmd.Parameters.AddWithValue("@DSTRC", row["DSTRC"].ToString());
                                cmd.Parameters.AddWithValue("@DSTRC_N", row["DSTRCN"].ToString());
                                cmd.Parameters.AddWithValue("@BLOCK", row["BLOCK"].ToString());
                                cmd.Parameters.AddWithValue("@BLOCK_N", row["BLOCKN"].ToString());
                                cmd.Parameters.AddWithValue("@DESTINT", row["DESTINT"].ToString());
                                cmd.Parameters.AddWithValue("@DESTINT_N", row["DESTINTN"].ToString());
                                cmd.Parameters.AddWithValue("@KDGRP", row["KDGRP"].ToString());
                                cmd.Parameters.AddWithValue("@KTEXT", row["KTEXT"].ToString());
                                cmd.Parameters.AddWithValue("@PRIMARY_FRT", row["PRIMARYFRT"].ToString());
                                cmd.Parameters.AddWithValue("@SECONDRY_FRT", row["SECONDRYFRT"].ToString());
                                cmd.Parameters.AddWithValue("@RAKNO", row["RAKNO"].ToString());
                                cmd.Parameters.AddWithValue("@RAKPT", row["RAKPT"].ToString());
                                cmd.Parameters.AddWithValue("@MATKL", row["MATKL"].ToString());
                                cmd.Parameters.AddWithValue("@LGORT", row["LGORT"].ToString());
                                cmd.Parameters.AddWithValue("@LGOBE", row["LGOBE"].ToString());
                                cmd.Parameters.AddWithValue("@INCO1", row["INCO1"].ToString());
                                cmd.Parameters.AddWithValue("@INCO2", row["INCO2"].ToString());
                                cmd.Parameters.AddWithValue("@ULDG_CHGS", row["ULDGCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@TRNS_CHGS", row["TRNSCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@DPUL_CHGS", row["DPULCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@DPLD_CHGS", row["DPLDCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@DIVR_CHGS", row["DIVRCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@LDNG_CHGS", row["LDNGCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@CFAG_CHGS", row["CFAGCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@RKSR_CHGS", row["RKSRCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@PULD_CHGS", row["PULDCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@RKCL_CHGS", row["RKCLCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@SHNT_CHGS", row["SHNTCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@RKCF_CHGS", row["RKCFCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@BLND_CHGS", row["BLNDCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@BLNB_CHGS", row["BLNBCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@MISC_MISC", row["MISCMISC"].ToString());
                                cmd.Parameters.AddWithValue("@ZZZONE1", row["ZZZONE1"].ToString());
                                cmd.Parameters.AddWithValue("@ZZZONE1_N", row["ZZZONE1N"].ToString());
                                cmd.Parameters.AddWithValue("@ZZBZIRK", row["ZZBZIRK"].ToString());
                                cmd.Parameters.AddWithValue("@ZZBZIRK_N", row["ZZBZIRKN"].ToString());
                                cmd.Parameters.AddWithValue("@ZZREGIO", row["ZZREGIO"].ToString());
                                cmd.Parameters.AddWithValue("@ZZREGIO_N", row["ZZREGION"].ToString());
                                cmd.Parameters.AddWithValue("@VKBUR", row["VKBUR"].ToString());
                                cmd.Parameters.AddWithValue("@VKBUR_N", row["VKBURN"].ToString());
                                cmd.Parameters.AddWithValue("@VKGRP", row["VKGRP"].ToString());
                                cmd.Parameters.AddWithValue("@VKGRP_N", row["VKGRPN"].ToString());
                                cmd.Parameters.AddWithValue("@ZZBRANCH", row["ZZBRANCH"].ToString());
                                cmd.Parameters.AddWithValue("@ZZBRANCH_N", row["ZZBRANCHN"].ToString());
                                cmd.Parameters.AddWithValue("@PDSTN", row["PDSTN"].ToString());
                                cmd.Parameters.AddWithValue("@SDSTN", row["SDSTN"].ToString());
                                cmd.Parameters.AddWithValue("@BLOCK_CT", row["BLOCKCT"].ToString());
                                cmd.Parameters.AddWithValue("@BELNR", row["BELNR"].ToString());
                                cmd.Parameters.AddWithValue("@GJAHR", row["GJAHR"].ToString());
                                cmd.Parameters.AddWithValue("@INV_TYPE", row["INVTYPE"].ToString());
                                cmd.Parameters.AddWithValue("@FRT_TYPE", row["FRTTYPE"].ToString());
                                cmd.Parameters.AddWithValue("@ZZVLFKZ", row["ZZVLFKZ"].ToString());
                                cmd.Parameters.AddWithValue("@SUPP_PLANT_NAME", row["SUPPPLANTNAME"].ToString());
                                cmd.Parameters.AddWithValue("@DEPO_RK_MVT", row["DEPORKMVT"].ToString());
                                cmd.Parameters.AddWithValue("@IND_PRI_FRT", row["INDPRIFRT"].ToString());

                                cmd.Parameters.AddWithValue("@SHIP_FRT_CHRGS", row["SHIPFRTCHRGS"].ToString());
                                cmd.Parameters.AddWithValue("@SHIP_HAND_CHRGS", row["SHIPHANDCHRGS"].ToString());
                                cmd.Parameters.AddWithValue("@CLKMNFPLANT", row["CLKMNFPLANT"].ToString());
                                cmd.Parameters.AddWithValue("@SUPPPLANT", row["SUPPPLANT"].ToString());
                                cmd.Parameters.AddWithValue("@DISTANCE", row["DISTANCE"].ToString());
                                cmd.Parameters.AddWithValue("@INDPDISTANCE", row["INDPDISTANCE"].ToString());
                                cmd.Parameters.AddWithValue("@CLK_PLT_NAME", row["CLKPLTNAME"].ToString());
                                cmd.Parameters.AddWithValue("@MNF_PLT_NAME", row["MNFPLTNAME"].ToString());
                                cmd.Parameters.AddWithValue("@GEIND_PLT", row["GEINDPLT"].ToString());
                                cmd.Parameters.AddWithValue("@GEIND_PLT_NAME", row["GEINDPLTNAME"].ToString());
                                cmd.Parameters.AddWithValue("@SUPPL_DEPO", row["SUPPLDEPO"].ToString());
                                cmd.Parameters.AddWithValue("@SUPPL_DEPO_NAME", row["SUPPLDEPONAME"].ToString());
                                cmd.Parameters.AddWithValue("@WAERK", row["WAERK"].ToString());
                                cmd.Parameters.AddWithValue("@RENT", row["RENT"].ToString());
                                cmd.Parameters.AddWithValue("@RAKEDEMCHRG", row["RAKEDEMCHRG"].ToString());
                                cmd.Parameters.AddWithValue("@LDISTANCE", row["LDISTANCE"].ToString());
                                cmd.Parameters.AddWithValue("@LDISTANCE_CLK", row["LDISTANCECLK"].ToString());
                                cmd.Parameters.AddWithValue("@MATNR", row["MATNR"].ToString());
                                cmd.Parameters.AddWithValue("@VTEXT", row["VTEXT"].ToString());
                                cmd.Parameters.AddWithValue("@MATNR1", row["MATNR1"].ToString());
                                cmd.Parameters.AddWithValue("@MAKTX", row["MAKTX"].ToString());
                                cmd.Parameters.AddWithValue("@INCURREDCOST", row["INCURREDCOST"].ToString());
                                cmd.Parameters.AddWithValue("@UNINCURREDCOST", row["UNINCURREDCOST"].ToString());
                                cmd.Parameters.AddWithValue("@SH_REGIO", row["SHREGIO"].ToString());
                                cmd.Parameters.AddWithValue("@SH_DSTRC", row["SHDSTRC"].ToString());
                                cmd.Parameters.AddWithValue("@SH_BLOCK", row["SHBLOCK"].ToString());
                                cmd.Parameters.AddWithValue("@SH_DESTINT", row["SHDESTINT"].ToString());
                                cmd.Parameters.AddWithValue("@KALKS", row["KALKS"].ToString());
                                cmd.Parameters.AddWithValue("@DELIVERY_NO", row["DELIVERYNO"].ToString());
                                cmd.Parameters.AddWithValue("@TKNUM", row["TKNUM"].ToString());
                                cmd.Parameters.AddWithValue("@MNFPLANT", row["MNFPLANT"].ToString());
                                cmd.Parameters.AddWithValue("@MNFDESC", row["MNFDESC"].ToString());
                                cmd.Parameters.AddWithValue("@MVGR1", row["MVGR1"].ToString());
                                cmd.Parameters.AddWithValue("@GROSSTURN", row["GROSSTURN"].ToString());
                                cmd.Parameters.AddWithValue("@NETTURN", row["NETTURN"].ToString());
                                cmd.Parameters.AddWithValue("@NAKEDREAL", row["NAKEDREAL"].ToString());
                                cmd.Parameters.AddWithValue("@TRANS_INCENTIVE", row["TRANSINCENTIVE"].ToString());
                                cmd.Parameters.AddWithValue("@PLT_FRT", row["PLTFRT"].ToString());
                                cmd.Parameters.AddWithValue("@SP_REGIO", row["SPREGIO"].ToString());
                                cmd.Parameters.AddWithValue("@SP_DSTRC", row["SPDSTRC"].ToString());
                                cmd.Parameters.AddWithValue("@SP_BLOCK", row["SPBLOCK"].ToString());
                                cmd.Parameters.AddWithValue("@SP_DESTINT", row["SPDESTINT"].ToString());
                                cmd.Parameters.AddWithValue("@TRAID", row["TRAID"].ToString());
                                cmd.Parameters.AddWithValue("@TRUCK_TYPE", row["TRUCKTYPE"].ToString());
                                cmd.Parameters.AddWithValue("@EWB_NO", row["EWBNO"].ToString());
                                cmd.Parameters.AddWithValue("@EDATE", row["EDATE"].ToString());
                                cmd.Parameters.AddWithValue("@EVDATE", row["EVDATE"].ToString());
                                cmd.Parameters.AddWithValue("@STEUC", row["STEUC"].ToString());
                                cmd.Parameters.AddWithValue("@PAID_PRICE", row["PAIDPRICE"].ToString());
                                cmd.Parameters.AddWithValue("@KALKS_DESC", row["KALKSDESC"].ToString());
                                cmd.Parameters.AddWithValue("@SP_REGIO_DESC", row["SPREGIODESC"].ToString());
                                cmd.Parameters.AddWithValue("@SP_DSTRC_DESC", row["SPDSTRCDESC"].ToString());
                                cmd.Parameters.AddWithValue("@SP_BLOCK_DESC", row["SPBLOCKDESC"].ToString());
                                cmd.Parameters.AddWithValue("@SP_DESTINT_DESC", row["SPDESTINTDESC"].ToString());
                                cmd.Parameters.AddWithValue("@MF_PLANT_TYPE", row["TOTALTDCCOST"].ToString());

                                cmd.Parameters.AddWithValue("@TOTAL_TDC_COST", row["TOTALTDCCOST"].ToString());

                                cmd.Parameters.AddWithValue("@TOTAL_DISTANCE", row["TOTALDISTANCE"].ToString());
                                cmd.Parameters.AddWithValue("@DEPOT_IND_FRIEGHT", row["DEPOTINDFRIEGHT"].ToString());
                                cmd.Parameters.AddWithValue("@TOTAL_INVOICE_FRT", row["TOTALINVOICEFRT"].ToString());
                                cmd.Parameters.AddWithValue("@ROAD_PF_INCURRED", row["ROADPFINCURRED"].ToString());
                                cmd.Parameters.AddWithValue("@ROAD_PF_UNINCURRED", row["ROADPFUNINCURRED"].ToString());
                                cmd.Parameters.AddWithValue("@ROAD_SF_INCURRED", row["ROADSFINCURRED"].ToString());
                                cmd.Parameters.AddWithValue("@ROAD_SF_UNINCURRED", row["ROADSFUNINCURRED"].ToString());
                                cmd.Parameters.AddWithValue("@RAIL_PF_INCURRED", row["RAILPFINCURRED"].ToString());
                                cmd.Parameters.AddWithValue("@RAIL_PF_UNINCURRED", row["RAILPFUNINCURRED"].ToString());
                                cmd.Parameters.AddWithValue("@DRDL_CHGS", row["DRDLCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@DB_LAB_CHGS", row["DBLABCHGS"].ToString());
                                cmd.Parameters.AddWithValue("@ZINV_CANCEL", row["ZINVCANCEL"].ToString());
                                cmd.Parameters.AddWithValue("@SH_DESTINT_DESC", row["SHDESTINTDESC"].ToString());
                                cmd.Parameters.AddWithValue("@SHIP_DISTANCE", row["SHIPDISTANCE"].ToString());

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
                        query = " Select Count(*) from ZSD_LCOST_DATA_SRV ";
                        query += " where date_format(cast(Fkdat as date),'%Y%m%d') ";
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
                            query = " Delete from ZSD_LCOST_DATA_SRV ";
                            query += " where date_format(cast(Fkdat as date),'%Y%m%d') ";
                            query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";

                            using (MySqlConnection sqlCon = new MySqlConnection(CS))
                            {
                                sqlCon.Open();
                                MySqlCommand Cmnd = new MySqlCommand(query, sqlCon);

                                int result = Cmnd.ExecuteNonQuery();

                                sqlCon.Close();
                            }

                            query = "";
                            query += " Select Count(*) Cnt from YREALIZATION ";
                            query += " where date_format(cast(Erdat as date),'%Y%m%d') ";
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
                    // Import_Data imp = new Import_Data();
                    //imp.Insert_ZSD_LCOST_DATA_SRV(startDate, endDate);
                    //Insert_ZSD_LCOST_DATA_SRV(startDate, endDate);
                
                return View();;

            }
            catch (Exception)
            {
                return View();
            }
        }


        public ActionResult DownloadLogRealization()
        {


            try
            {
                string filename = System.Configuration.ConfigurationManager.AppSettings["LogFile"].ToString();
                string SchLogFile = System.Configuration.ConfigurationManager.AppSettings["SchLogFile"].ToString();
                string OSODSchLogFile = System.Configuration.ConfigurationManager.AppSettings["OSODSchLogFile"].ToString();

                //string destinationFile = System.IO.Path.GetDirectoryName(SchLogFile) + @"\PennaScheduler.log";
                List<PennaMiddleWare.BLL.FileInfo> listFiles = new List<PennaMiddleWare.BLL.FileInfo>();
                //using (ZipFile zip = new ZipFile())
                //{
                //    zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                //    //zip.AddDirectoryByName("Files");
                //    if (System.IO.File.Exists(filename))
                //    {
                //        //return File(filename, "text/plain", "Pennalog.txt");
                //        zip.AddFile(filename);
                //        //return File(toWrite, "text/plain", );
                //        //return File(destinationFile, "video/" + fileextn, filename);

                //    }
                //    if (System.IO.File.Exists(SchLogFile))
                //    {
                //        //return File(filename, "text/plain", "Pennalog.txt");
                //        zip.AddFile(SchLogFile);
                //        //return File(toWrite, "text/plain", );
                //        //return File(destinationFile, "video/" + fileextn, filename);

                //    }


                //    string zipName = String.Format("PennaLog_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                //    using (MemoryStream memoryStream = new MemoryStream())
                //    {
                //        zip.Save(memoryStream);
                //        return File(memoryStream.ToArray(), "application/zip", zipName);
                //    }
                //}
               
                if (System.IO.File.Exists(filename))
                {
                    //return File(filename, "text/plain", "Pennalog.txt");
                    listFiles.Add(new PennaMiddleWare.BLL.FileInfo()
                    {

                        FileId = listFiles.Count +1,
                        FileName = Path.GetFileName(filename),
                        FilePath = filename

                    });
                    //return File(toWrite, "text/plain", );
                    //return File(destinationFile, "video/" + fileextn, filename);

                }

                if (System.IO.File.Exists(SchLogFile))
                {
                    //if (System.IO.File.Exists(destinationFile))
                    //{
                    //    System.IO.File.Delete(destinationFile);
                    //}
                    ////return File(filename, "text/plain", "Pennalog.txt");
                    //System.IO.File.Copy(SchLogFile, destinationFile, true);
                    listFiles.Add(new PennaMiddleWare.BLL.FileInfo()
                    {

                        FileId = listFiles.Count + 1,
                        FileName = Path.GetFileName(SchLogFile),
                        FilePath = SchLogFile

                    });
                    //return File(toWrite, "text/plain", );
                    //return File(destinationFile, "video/" + fileextn, filename);

                }

                if (System.IO.File.Exists(OSODSchLogFile))
                {

                    listFiles.Add(new PennaMiddleWare.BLL.FileInfo()
                    {

                        FileId = listFiles.Count + 1,
                        FileName = Path.GetFileName(OSODSchLogFile),
                        FilePath = OSODSchLogFile

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
                    //if (System.IO.File.Exists(destinationFile))
                    //{
                    //    System.IO.File.Delete(destinationFile);
                    //}
                    return File(memoryStream.ToArray(), "application/zip", "Attachments.zip");
                }
                //if (System.IO.File.Exists(filename))
                //{
                //    return File(filename, "text/plain", "Pennalog.txt");
                //    //return File(toWrite, "text/plain", );
                //    //return File(destinationFile, "video/" + fileextn, filename);

                //}
                //else
                //{


                //    TempData["ErrMsg"] = "File Not Found";
                //    return RedirectToAction("Index", "Home");

                //}
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}