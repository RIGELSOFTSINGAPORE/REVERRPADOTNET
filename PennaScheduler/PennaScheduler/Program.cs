using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace PennaScheduler
{
  
    class Program
    {
        
        static void Main(string[] args)
        {
           // var yesterday = DateTime.Today.AddDays(-1).ToString("yyyyMMdd");
            //string noofDays = ConfigurationManager.AppSettings["NoofDays"].ToString();
            //var yesterday = "20210922" ;
            string filename = System.Configuration.ConfigurationManager.AppSettings["LogFile"].ToString();

            //20220128
            StreamWriter log1;



            if (!File.Exists(filename))
            {
                log1 = new StreamWriter(filename, append: true);
            }
            else
            {
                log1 = File.AppendText(filename);
            }
            //20220128
            //Console.WriteLine("Enter From Date : ");
            //string FromDate = Console.ReadLine();
            //Console.WriteLine("Enter To Date : ");
            //string ToDate = Console.ReadLine();
            var FromDate = DateTime.Today.AddDays(-31).ToString("yyyyMMdd");
            var ToDate = DateTime.Today.AddDays(-1).ToString("yyyyMMdd");
            log1.WriteLine("===========================================");
            log1.WriteLine("Scheduler From Date  " + FromDate);
            log1.WriteLine("Scheduler To Date  " + ToDate);
            //log1.WriteLine("Scheduler From Date  " + yesterday);
            //log1.WriteLine("Scheduler To Date  " + yesterday);
            log1.Close();
            Console.WriteLine(FromDate);
            Console.WriteLine(ToDate);
            PennaScdlr t = new PennaScdlr();
            //List<Schdates> schdt = new List<Schdates>();
            //schdt = PennaScdlr.schdat(FromDate, ToDate);
            //t.Index(yesterday, yesterday, "I");
            //t.LogiCost(yesterday, yesterday, "I");

            // t.Index(yesterday, yesterday, "I");
            //t.LogiCost(yesterday, yesterday, "I");
             t.Index(FromDate, ToDate, "I");
             t.LogiCost(FromDate, ToDate, "I");
             t.Export_Mismatch(FromDate, ToDate);
            //t.Index("20210901", "20210930", "I");
            //t.LogiCost("20210901", "20210930", "I");
            Console.WriteLine("Execution completed");
            //Console.ReadLine();
        }
    }

    class PennaScdlr
    {
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ToString();
        StreamWriter log1;
//        string noofDays = ConfigurationManager.ConnectionStrings["NoofDays"].ConnectionString;
       // static string daySplit = ConfigurationManager.AppSettings["DaySplit"].ToString();
        public static DataTable dtYREALIZATION;
        public static DataTable dtZSD_LCOST_DATA_SRV;
        public void Index(string startDate, string endDate, string InputID)

        {
            try
            {

                string filename = System.Configuration.ConfigurationManager.AppSettings["LogFile"].ToString();

                if (!File.Exists(filename))
                {
                    log1 = new StreamWriter(filename, append: true);
                }
                else
                {
                    log1 = File.AppendText(filename);
                }

                log1.WriteLine("Executed on : " + DateTime.Now);



                var url = "";
                string query = "";
                int reccount = 0;
                int result = 0;
                List<ZSD_REAL_DATA_SRV_REAL> lstsrvdeal = new List<ZSD_REAL_DATA_SRV_REAL>();
                
                var formats = new[] { "ddMMyyyy", "yyyyMMdd", "yyyyMMdd" };

                List<Schdates> schdt = new List<Schdates>();
                schdt = PennaScdlr.schdat(startDate, endDate);

                log1.WriteLine("Insert / Upddate Table : YREALIZATION");
                Console.WriteLine("YREALIZATION");
                query = "";

                query += " truncate table yrealization_Temp ";

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

                query = "";
                reccount = 0;

                foreach (Schdates scdat in schdt)
                {
                    if (InputID == "I")
                    {

                        Console.WriteLine(scdat.startdate);
                        Console.WriteLine(scdat.enddate);


                        //Test Service
                        //url = "https://netwaver-dev.pennacement.com:443/sap/opu/odata/sap/ZSD_REAL_DATA_SRV/REALSet?$format=json&$filter=Erdat ge '" + startDate.Trim() + "' and Erdat le '" + endDate.Trim() + "'";
                        //Production Service 
                        url = "https://netwaver-prd.pennacement.com:443/sap/opu/odata/sap/ZSD_REAL_DATA_SRV/REALSet?$format=json&$filter=Erdat ge '" + scdat.startdate.Trim() + "' and Erdat le '" + scdat.enddate.Trim() + "'";
                        string userName = "NWGW037";
                        string passwd = "Admin@123456";

                        

                        HttpClient client = new HttpClient();

                        string authInfo = userName + ":" + passwd;
                        authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);

                        client.BaseAddress = new Uri(url);

                        HttpResponseMessage response = client.GetAsync(url).ContinueWith(task => task.Result).Result;
                        // Parse the response body. Blocking!
                        if (response.IsSuccessStatusCode)
                        {

                            Console.WriteLine("HTTP Response : "+ response.IsSuccessStatusCode);
                            var httpResponseResult = response.Content.ReadAsStringAsync().ContinueWith(task => task.Result).Result;


                            JToken token1 = JToken.Parse(httpResponseResult);
                            JArray men1 = (JArray)token1.SelectToken("['d']['results']");
                            List<ZSD_REAL_DATA_SRV_REAL> varoutput = men1.ToObject<List<ZSD_REAL_DATA_SRV_REAL>>();
                            //var o = JsonConvert.DeserializeObject<List<ZSD_REAL_DATA_SRV_REAL>>(men1.ToString());

                            Common converter = new Common();


                            DataTable dt = converter.ToDataTable(varoutput);
                            Console.WriteLine("Row Count : " +dt.Rows.Count);
                            if (dtYREALIZATION == null)
                            {
                                dtYREALIZATION = converter.ToDataTable(varoutput);
                            }
                            else
                            {
                                dtYREALIZATION.Merge(dt);
                            }
                            //dtYREALIZATION = new DataTable();
                            //dtYREALIZATION.Rows.Add(dt);





                            int i = 0;
                            using (MySqlConnection con = new MySqlConnection(CS))
                            {

                                con.Open();
                                foreach (DataRow row in dt.Rows)
                                {
                                    /* new Added code 2022/01/31 */
                                    query = "";
                                    query = "Insert into yrealization_Temp(VBELN,VGBEL,AUBEL,ERDAT,FKART,REGIO,VKGRP,DSTRC,MNFPLANT,PLANT,GRADE,MATKL,KALKS,KDGRP,";
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

                                    MySqlCommand cmdt = new MySqlCommand(query, con);

                                    cmdt.Parameters.AddWithValue("@VBELN", row["VBELN"].ToString());
                                    cmdt.Parameters.AddWithValue("@VGBEL", row["VGBEL"].ToString());
                                    cmdt.Parameters.AddWithValue("@AUBEL", row["AUBEL"].ToString());
                                    cmdt.Parameters.AddWithValue("@ERDAT", row["ERDAT"].ToString());
                                    cmdt.Parameters.AddWithValue("@FKART", row["FKART"].ToString());
                                    cmdt.Parameters.AddWithValue("@REGIO", row["REGIO"].ToString());
                                    cmdt.Parameters.AddWithValue("@VKGRP", row["VKGRP"].ToString());
                                    cmdt.Parameters.AddWithValue("@DSTRC", row["DSTRC"].ToString());
                                    cmdt.Parameters.AddWithValue("@MNFPLANT", row["MNFPLANT"].ToString());
                                    cmdt.Parameters.AddWithValue("@PLANT", row["PLANT"].ToString());
                                    cmdt.Parameters.AddWithValue("@GRADE", row["GRADE"].ToString());
                                    cmdt.Parameters.AddWithValue("@MATKL", row["MATKL"].ToString());
                                    cmdt.Parameters.AddWithValue("@KALKS", row["KALKS"].ToString());
                                    cmdt.Parameters.AddWithValue("@KDGRP", row["KDGRP"].ToString());
                                    cmdt.Parameters.AddWithValue("@FKDAT", row["FKDAT"].ToString());
                                    cmdt.Parameters.AddWithValue("@MATNR", row["MATNR"].ToString());
                                    cmdt.Parameters.AddWithValue("@CUSTCODE1", row["CUSTCODE1"].ToString());
                                    cmdt.Parameters.AddWithValue("@CNAME1", row["CNAME1"].ToString());
                                    cmdt.Parameters.AddWithValue("@CUSTCODE2", row["CUSTCODE2"].ToString());
                                    cmdt.Parameters.AddWithValue("@CNAME2", row["CNAME2"].ToString());
                                    cmdt.Parameters.AddWithValue("@CUSTCODE3", row["CUSTCODE3"].ToString());
                                    cmdt.Parameters.AddWithValue("@CNAME3", row["CNAME3"].ToString());
                                    cmdt.Parameters.AddWithValue("@COM_AG", row["COMAG"].ToString());
                                    cmdt.Parameters.AddWithValue("@COM_NAME", row["COMNAME"].ToString());
                                    cmdt.Parameters.AddWithValue("@TRANS", row["TRANS"].ToString());
                                    cmdt.Parameters.AddWithValue("@TRANS_NAME", row["TRANSNAME"].ToString());
                                    cmdt.Parameters.AddWithValue("@LGORT", row["LGORT"].ToString());
                                    cmdt.Parameters.AddWithValue("@LGOBE", row["LGOBE"].ToString());
                                    cmdt.Parameters.AddWithValue("@FKIMG", row["FKIMG"].ToString());
                                    cmdt.Parameters.AddWithValue("@GROSSTURN", row["GROSSTURN"].ToString());
                                    cmdt.Parameters.AddWithValue("@INCO1", row["INCO1"].ToString());
                                    cmdt.Parameters.AddWithValue("@INCO2", row["INCO2"].ToString());
                                    cmdt.Parameters.AddWithValue("@STPRS", row["STPRS"].ToString());
                                    cmdt.Parameters.AddWithValue("@PRIMARYFRI", row["PRIMARYFRI"].ToString());
                                    cmdt.Parameters.AddWithValue("@SECONDARYFRI", row["SECONDARYFRI"].ToString());
                                    cmdt.Parameters.AddWithValue("@EXWPF", row["EXWPF"].ToString());
                                    cmdt.Parameters.AddWithValue("@EXGSF", row["EXGSF"].ToString());
                                    cmdt.Parameters.AddWithValue("@SALESTAX", row["SALESTAX"].ToString());
                                    cmdt.Parameters.AddWithValue("@COMMISSION", row["COMMISSION"].ToString());
                                    cmdt.Parameters.AddWithValue("@EXCISEDUTY", row["EXCISEDUTY"].ToString());
                                    cmdt.Parameters.AddWithValue("@PDDISCOUNT", row["PDDISCOUNT"].ToString());
                                    cmdt.Parameters.AddWithValue("@ODDISCOUNT", row["ODDISCOUNT"].ToString());
                                    cmdt.Parameters.AddWithValue("@CFCHARGES", row["CFCHARGES"].ToString());
                                    cmdt.Parameters.AddWithValue("@CDDISCOUNT", row["CDDISCOUNT"].ToString());
                                    cmdt.Parameters.AddWithValue("@PACKING", row["PACKING"].ToString());
                                    cmdt.Parameters.AddWithValue("@UNLOADING", row["UNLOADING"].ToString());
                                    cmdt.Parameters.AddWithValue("@OCTRAI", row["OCTRAI"].ToString());
                                    cmdt.Parameters.AddWithValue("@VAT", row["VAT"].ToString());
                                    cmdt.Parameters.AddWithValue("@IGST", row["IGST"].ToString());
                                    cmdt.Parameters.AddWithValue("@CGST", row["CGST"].ToString());
                                    cmdt.Parameters.AddWithValue("@SGST", row["SGST"].ToString());
                                    cmdt.Parameters.AddWithValue("@UGST", row["UGST"].ToString());
                                    cmdt.Parameters.AddWithValue("@EXP_HAND", row["EXPHAND"].ToString());
                                    cmdt.Parameters.AddWithValue("@TRANSPORT", row["TRANSPORT"].ToString());
                                    cmdt.Parameters.AddWithValue("@AMT_DW_FRT", row["AMTDWFRT"].ToString());
                                    cmdt.Parameters.AddWithValue("@PLT_FRT", row["PLTFRT"].ToString());
                                    cmdt.Parameters.AddWithValue("@NETTURN", row["NETTURN"].ToString());
                                    cmdt.Parameters.AddWithValue("@NAKEDREAL", row["NAKEDREAL"].ToString());
                                    cmdt.Parameters.AddWithValue("@STATEDESC", row["STATEDESC"].ToString());
                                    cmdt.Parameters.AddWithValue("@SGRPDESC", row["SGRPDESC"].ToString());
                                    cmdt.Parameters.AddWithValue("@DISDESC", row["DISDESC"].ToString());
                                    cmdt.Parameters.AddWithValue("@GRADDESC", row["GRADDESC"].ToString());
                                    cmdt.Parameters.AddWithValue("@MNFDESC", row["MNFDESC"].ToString());
                                    cmdt.Parameters.AddWithValue("@PLANTDESC", row["PLANTDESC"].ToString());
                                    cmdt.Parameters.AddWithValue("@PGRPDESC", row["PGRPDESC"].ToString());
                                    cmdt.Parameters.AddWithValue("@CDATE", row["CDATE"].ToString());
                                    cmdt.Parameters.AddWithValue("@TIME", row["TIME"].ToString());
                                    cmdt.Parameters.AddWithValue("@SUSER", row["SUSER"].ToString());
                                    cmdt.Parameters.AddWithValue("@BLOCK_CT", row["BLOCKCT"].ToString());
                                    cmdt.Parameters.AddWithValue("@ROUTE", row["ROUTE"].ToString());
                                    cmdt.Parameters.AddWithValue("@CANCELDATE", row["CANCELDATE"].ToString());
                                    cmdt.Parameters.AddWithValue("@CANCELFLAG", row["CANCELFLAG"].ToString());
                                    cmdt.Parameters.AddWithValue("@ZZLGORT1", row["ZZLGORT1"].ToString());
                                    cmdt.Parameters.AddWithValue("@BZIRK", row["BZIRK"].ToString());
                                    cmdt.Parameters.AddWithValue("@VKBUR", row["VKBUR"].ToString());
                                    cmdt.Parameters.AddWithValue("@ZZZONE1", row["ZZZONE1"].ToString());
                                    cmdt.Parameters.AddWithValue("@ZZBRANCH", row["ZZBRANCH"].ToString());
                                    cmdt.Parameters.AddWithValue("@PERNR_ER", row["PERNRER"].ToString());
                                    cmdt.Parameters.AddWithValue("@ENAME_ER", row["ENAMEER"].ToString());
                                    cmdt.Parameters.AddWithValue("@PERNR_Y1", row["PERNRY1"].ToString());
                                    cmdt.Parameters.AddWithValue("@ENAME_Y1", row["ENAMEY1"].ToString());
                                    cmdt.Parameters.AddWithValue("@PERNR_Y2", row["PERNRY2"].ToString());
                                    cmdt.Parameters.AddWithValue("@ENAME_Y2", row["ENAMEY2"].ToString());
                                    cmdt.Parameters.AddWithValue("@PERNR_Y3", row["PERNRY3"].ToString());
                                    cmdt.Parameters.AddWithValue("@ENAME_Y3", row["ENAMEY3"].ToString());
                                    cmdt.Parameters.AddWithValue("@PERNR_Y4", row["PERNRY4"].ToString());
                                    cmdt.Parameters.AddWithValue("@ENAME_Y4", row["ENAMEY4"].ToString());
                                    cmdt.Parameters.AddWithValue("@PERNR_Y5", row["PERNRY5"].ToString());
                                    cmdt.Parameters.AddWithValue("@ENAME_Y5", row["ENAMEY5"].ToString());
                                    cmdt.Parameters.AddWithValue("@PERNR_Y6", row["PERNRY6"].ToString());
                                    cmdt.Parameters.AddWithValue("@ENAME_Y6", row["ENAMEY6"].ToString());
                                    cmdt.Parameters.AddWithValue("@PERNR_Y7", row["PERNRY7"].ToString());
                                    cmdt.Parameters.AddWithValue("@ENAME_Y7", row["ENAMEY7"].ToString());
                                    cmdt.Parameters.AddWithValue("@PERNR_Y8", row["PERNRY8"].ToString());
                                    cmdt.Parameters.AddWithValue("@ENAME_Y8", row["ENAMEY8"].ToString());
                                    cmdt.Parameters.AddWithValue("@UPFRNT_DISCOUNT", row["UPFRNTDISCOUNT"].ToString());
                                    cmdt.Parameters.AddWithValue("@IND_PRI_FRT", row["INDPRIFRT"].ToString());
                                    cmdt.Parameters.AddWithValue("@SHIP_FRT_CHRGS", row["SHIPFRTCHRGS"].ToString());
                                    cmdt.Parameters.AddWithValue("@SHIP_HAND_CHRGS", row["SHIPHANDCHRGS"].ToString());
                                    cmdt.Parameters.AddWithValue("@ZCUST_GRP", row["ZCUSTGRP"].ToString());
                                    cmdt.Parameters.AddWithValue("@ZCUST_GRP_DESC", row["ZCUSTGRPDESC"].ToString());
                                    cmdt.Parameters.AddWithValue("@Vc", row["Vc"].ToString());
                                    cmdt.Parameters.AddWithValue("@ZsalePromValue", row["ZsalePromValue"].ToString());
                                    cmdt.Parameters.AddWithValue("@Waers", row["Waers"].ToString());
                                    cmdt.Parameters.AddWithValue("@Msehi", row["Msehi"].ToString());
                                    cmdt.Parameters.AddWithValue("@PayFreight", row["PayFreight"].ToString());
                                    cmdt.Parameters.AddWithValue("@ExFreight", row["ExFreight"].ToString());

                                    cmdt.CommandType = CommandType.Text;
                                    result = cmdt.ExecuteNonQuery();

                                    /* new Added code 2022/01/31*/
                                    i += 1;
                                    Console.WriteLine("Row No : " + i);
                                    query = "";
                                    int isExists = 0;
                                    query += " SELECT EXISTS(SELECT vbeln FROM YREALIZATION WHERE vbeln = '" + row["VBELN"].ToString() + "') isexist";

                                    using (MySqlConnection sqlCon = new MySqlConnection(CS))
                                    {
                                        sqlCon.Open();
                                        MySqlCommand Cmnd = new MySqlCommand(query, sqlCon);

                                        object resultexscalar = Cmnd.ExecuteScalar();

                                        if (resultexscalar != null)
                                        {
                                            isExists = Convert.ToInt32(resultexscalar);
                                        }

                                        sqlCon.Close();
                                    }
                                    query = "";
                                    if (isExists == 0)
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
                                    }
                                    else
                                    {
                                        query = "";
                                        query += "update yrealization set VGBEL=@VGBEL,AUBEL=@AUBEL,ERDAT=@ERDAT,FKART=@FKART,";
                                        query += "REGIO=@REGIO,VKGRP=@VKGRP,DSTRC=@DSTRC,MNFPLANT=@MNFPLANT,PLANT=@PLANT,";
                                        query += "GRADE=@GRADE,MATKL=@MATKL,KALKS=@KALKS,KDGRP=@KDGRP,FKDAT=@FKDAT,";
                                        query += "MATNR=@MATNR,CUSTCODE1=@CUSTCODE1,CNAME1=@CNAME1,CUSTCODE2=@CUSTCODE2,";
                                        query += "CNAME2=@CNAME2,CUSTCODE3=@CUSTCODE3,CNAME3=@CNAME3,COM_AG=@COM_AG,";
                                        query += "COM_NAME=@COM_NAME,TRANS=@TRANS,TRANS_NAME=@TRANS_NAME,LGORT=@LGORT,";
                                        query += "LGOBE=@LGOBE,FKIMG=@FKIMG,GROSSTURN=@GROSSTURN,INCO1=@INCO1,";
                                        query += "INCO2=@INCO2,STPRS=@STPRS,PRIMARYFRI=@PRIMARYFRI,SECONDARYFRI=@SECONDARYFRI,";
                                        query += "EXWPF=@EXWPF,EXGSF=@EXGSF,SALESTAX=@SALESTAX,COMMISSION=@COMMISSION,";
                                        query += "EXCISEDUTY=@EXCISEDUTY,PDDISCOUNT=@PDDISCOUNT,ODDISCOUNT=@ODDISCOUNT,";
                                        query += "CFCHARGES=@CFCHARGES,CDDISCOUNT=@CDDISCOUNT,PACKING=@PACKING,";
                                        query += "UNLOADING=@UNLOADING,OCTRAI=@OCTRAI,VAT=@VAT,IGST=@IGST,CGST=@CGST,";
                                        query += "SGST=@SGST,UGST=@UGST,EXP_HAND=@EXP_HAND,TRANSPORT=@TRANSPORT,";
                                        query += "AMT_DW_FRT=@AMT_DW_FRT,PLT_FRT=@PLT_FRT,NETTURN=@NETTURN,";
                                        query += "NAKEDREAL=@NAKEDREAL,STATEDESC=@STATEDESC,SGRPDESC=@SGRPDESC,";
                                        query += "DISDESC=@DISDESC,GRADDESC=@GRADDESC,MNFDESC=@MNFDESC,";
                                        query += "PLANTDESC=@PLANTDESC,PGRPDESC=@PGRPDESC,CDATE=@CDATE,TIME=@TIME,";
                                        query += "SUSER=@SUSER,BLOCK_CT=@BLOCK_CT,ROUTE=@ROUTE,CANCELDATE=@CANCELDATE,";
                                        query += "CANCELFLAG=@CANCELFLAG,ZZLGORT1=@ZZLGORT1,BZIRK=@BZIRK,VKBUR=@VKBUR,";
                                        query += "ZZZONE1=@ZZZONE1,ZZBRANCH=@ZZBRANCH,PERNR_ER=@PERNR_ER,ENAME_ER=@ENAME_ER,";
                                        query += "PERNR_Y1=@PERNR_Y1,ENAME_Y1=@ENAME_Y1,PERNR_Y2=@PERNR_Y2,ENAME_Y2=@ENAME_Y2,";
                                        query += "PERNR_Y3=@PERNR_Y3,ENAME_Y3=@ENAME_Y3,PERNR_Y4=@PERNR_Y4,ENAME_Y4=@ENAME_Y4,";
                                        query += "PERNR_Y5=@PERNR_Y5,ENAME_Y5=@ENAME_Y5,PERNR_Y6=@PERNR_Y6,ENAME_Y6=@ENAME_Y6,";
                                        query += "PERNR_Y7=@PERNR_Y7,ENAME_Y7=@ENAME_Y7,PERNR_Y8=@PERNR_Y8,ENAME_Y8=@ENAME_Y8,";
                                        query += "UPFRNT_DISCOUNT=@UPFRNT_DISCOUNT,IND_PRI_FRT=@IND_PRI_FRT,";
                                        query += "SHIP_FRT_CHRGS=@SHIP_FRT_CHRGS,SHIP_HAND_CHRGS=@SHIP_HAND_CHRGS,";
                                        query += "ZCUST_GRP=@ZCUST_GRP,ZCUST_GRP_DESC=@ZCUST_GRP_DESC,Vc=@Vc,ZsalePromValue=@ZsalePromValue,";
                                        query += "Waers=@Waers,Msehi=@Msehi,PayFreight=@PayFreight,ExFreight=@ExFreight ";
                                        query += " Where VBELN=@VBELN";

                                    }

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
                                     result = cmd.ExecuteNonQuery();


                                }

                            }



                        }
                        else
                        {
                            Console.WriteLine("Web API Response Status Code: " + Convert.ToInt16(response.StatusCode) + ", Status : " + response.StatusCode);
                             log1.WriteLine("Web API Response Status Code: " + Convert.ToInt16(response.StatusCode) + ", Status : " + response.StatusCode);
                        }


                    }
                }

                DataView view = new DataView(dtYREALIZATION);
                DataTable distinctValues = view.ToTable(true, "VBELN");

                if (distinctValues.Rows.Count > 0)
                {
                    log1.WriteLine("WebApi Record Count : " + distinctValues.Rows.Count);
                    Console.WriteLine("WebApi Record Count : " + distinctValues.Rows.Count);
                }
                else
                {
                    log1.WriteLine("WebApi Record Count : 0");
                    Console.WriteLine("WebApi Record Count : 0");
                }

                query = "";
                query += " Select Count(*) Cnt from YREALIZATION ";
                query += " where VBELN in (select distinct VBELN from yrealization_Temp) and date_format(cast(Erdat as date),'%Y%m%d') ";
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



                if (distinctValues.Rows.Count == reccount)
                {
                    log1.WriteLine("Table record Count : " + reccount);
                    log1.WriteLine("Record Mathing");
                    Console.WriteLine("Table record Count : " + reccount);
                    Console.WriteLine("Record Mathing");

                }
                else
                {
                    log1.WriteLine("Table record Count : " + reccount);
                    log1.WriteLine("Record Insert Failed");
                    Console.WriteLine("Table record Count : " + reccount);
                    Console.WriteLine("Record Insert Failed");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("YREALIZATION Error Message : " + ex.Message);
                log1.WriteLine("YREALIZATION Error Message : " +  ex.Message);
                log1.Close();
         
            }
            log1.Close();
        
        }

        public void LogiCost(string startDate, string endDate, string InputID)
        {
            try
            {

                string filename = System.Configuration.ConfigurationManager.AppSettings["LogFile"].ToString();

                if (!File.Exists(filename))
                {
                    log1 = new StreamWriter(filename, append: true);
                }
                else
                {
                    log1 = File.AppendText(filename);
                }

                log1.WriteLine("Executed on : " + DateTime.Now);






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


                //ViewData["Category"] = mySkills;
                //var url = "";
                string query = "";
                int reccount = 0;
                List<ZSD_LCOST_DATA_SRV> lstsrvdeal = new List<ZSD_LCOST_DATA_SRV>();
                
                var formats = new[] { "ddMMyyyy", "yyyyMMdd", "yyyyMMdd" };
                //if (!DateTime.TryParseExact(startDate.Trim(), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue) || !(DateTime.TryParseExact(endDate.Trim(), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue)))
                //{
                //    return RedirectToAction("About");
                //    //return View("About");
                //}

                string startDateOrig = startDate;
                string endDateOrig = endDate;
                startDate = DateTime.ParseExact(startDate, "yyyyMMdd", null).ToString("yyyyMMdd");
                endDate = DateTime.ParseExact(endDate, "yyyyMMdd", null).ToString("yyyyMMdd");

                log1.WriteLine("Insert/Update Table : ZSD_LCOST_DATA_SRV");

                List<Schdates> schdt = new List<Schdates>();
                schdt = PennaScdlr.schdat(startDate, endDate);
                Console.WriteLine("zsd_lcost_data_srv");

                query = "";

                query += " truncate table zsd_lcost_data_srv_Temp ";

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

                query = "";
                reccount = 0;


                foreach (Schdates scdat in schdt)
                {

                    Console.WriteLine(scdat.startdate);
                    Console.WriteLine(scdat.enddate);

                    if (InputID == "I")
                    {
                        //url = "https://netwaver-dev.pennacement.com:443/sap/opu/odata/sap/ZSD_REAL_DATA_SRV/REALSet?$format=json&$filter=Erdat ge '" + startDate.Trim() + "' and Erdat le '" + endDate.Trim() + "'";
                        //var url = "https://netwaver-dev.pennacement.com:443/sap/opu/odata/sap/ZSD_LCOST_DATA_SRV/LOGI_COSTSet?$format=json&$filter=Fkdat ge '" + startDate.Trim() + "' and Erdat le '"+ endDate.Trim() + "'";
                        //Test Service
                        //var url = "https://netwaver-dev.pennacement.com:443/sap/opu/odata/sap/ZSD_LCOST_DATA_SRV/LOGI_COSTSet?$format=json&$filter=Fkdat ge '" + startDateOrig.Trim() + "' and Fkdat le '" + endDateOrig.Trim() + "'";
                        // Prod Service
                        var url = "https://netwaver-prd.pennacement.com:443/sap/opu/odata/sap/ZSD_LCOST_DATA_SRV/LOGI_COSTSet?$format=json&$filter=Fkdat ge '" + scdat.startdate.Trim() + "' and Fkdat le '" + scdat.enddate.Trim() + "'";

                        string userName = "NWGW037";
                        string passwd = "Admin@123456";



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
                            List<ZSD_LCOST_DATA_SRV> varoutput = men1.ToObject<List<ZSD_LCOST_DATA_SRV>>();
                            var o = JsonConvert.DeserializeObject<List<ZSD_LCOST_DATA_SRV>>(men1.ToString());

                            //DataTable dt = (DataTable)JsonConvert.DeserializeObject(men1.ToString(), (typeof(DataTable)));
                            //var qry = from idata in varoutput select idata;
                            //DataTable dtable = 
                            Common converter = new Common();


                            DataTable dt = converter.ToDataTable(varoutput);
                            Console.WriteLine("Row Count : " + dt.Rows.Count);
                            if (dtZSD_LCOST_DATA_SRV == null)
                            {
                                dtZSD_LCOST_DATA_SRV = converter.ToDataTable(varoutput);
                            }
                            else
                            {
                                dtZSD_LCOST_DATA_SRV.Merge(dt);
                            }
                            //if (dt.Rows.Count > 0)
                            //{
                            //    Console.WriteLine();
                            //    log1.WriteLine("WebApi Record Count : " + dt.Rows.Count);

                            //}
                            //else
                            //{
                            //    log1.WriteLine("WebApi Record Count : 0");
                            //}
                            //query = " declare @maxid int ";
                            //query += " set @maxid = (select max(GroupID) from [ZSD_REAL_DATA_SRV_REAL]) ";
                            //query += " select isnull(@maxid,0) +1 ";

                            //using (MySqlConnection sqlCon = new MySqlConnection(CS))
                            //{
                            //    sqlCon.Open();
                            //    MySqlCommand Cmnd = new MySqlCommand(query, sqlCon);

                            //    object result = Cmnd.ExecuteScalar();
                            //    if (result != null)
                            //    {
                            //        Maxid = Convert.ToInt32(result.ToString());
                            //    }
                            //    sqlCon.Close();
                            //}
                            ////objbulk.ColumnMappings.Add("GroupID", 1);
                            //DataColumn dc = new DataColumn("GroupID");
                            //dc.DataType = typeof(int);
                            //dc.DefaultValue = Maxid;
                            //dt.Columns.Add(dc);
                            //ViewData["GroupID"] = Maxid;


                            //dt.Columns.Add("GroupID", typeof(int));
                            //dt.Columns["GroupID"].DefaultValue = 0;
                            //dt.Columns.Add("GroupID", typeof(long)).DefaultValue = 1;


                            //query = "";
                            //query = " Delete from ZSD_LCOST_DATA_SRV ";
                            //query += " where date_format(cast(Fkdat as date),'%Y%m%d') ";
                            //query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";

                            //using (MySqlConnection sqlCon = new MySqlConnection(CS))
                            //{
                            //    sqlCon.Open();
                            //    MySqlCommand Cmnd = new MySqlCommand(query, sqlCon);

                            //    int result = Cmnd.ExecuteNonQuery();

                            //    sqlCon.Close();
                            //}

                            //using (SqlConnection con = new SqlConnection(CS))
                            //{
                            //    con.Open();
                            //    SqlBulkCopy objbulk = new SqlBulkCopy(con);
                            //    //assigning Destination table name    
                            //    objbulk.DestinationTableName = "ZSD_LCOST_DATA_SRV";
                            //    //Mapping Table column    

                            //    objbulk.ColumnMappings.Add("Vbeln", "VBELN");
                            //    objbulk.ColumnMappings.Add("Fkart", "FKART");
                            //    objbulk.ColumnMappings.Add("Fkdat", "FKDAT");
                            //    objbulk.ColumnMappings.Add("Fkimg", "FKIMG");
                            //    objbulk.ColumnMappings.Add("Meins", "MEINS");
                            //    objbulk.ColumnMappings.Add("Werks", "WERKS");
                            //    objbulk.ColumnMappings.Add("WName1", "W_NAME1");
                            //    objbulk.ColumnMappings.Add("Zsource", "ZSOURCE");
                            //    objbulk.ColumnMappings.Add("Zsourced", "ZSOURCED");
                            //    objbulk.ColumnMappings.Add("Ztratyp", "ZTRATYP");
                            //    objbulk.ColumnMappings.Add("Ztratypd", "ZTRATYPD");
                            //    objbulk.ColumnMappings.Add("Kunnr", "KUNNR");
                            //    objbulk.ColumnMappings.Add("KunnrN", "KUNNR_N");
                            //    objbulk.ColumnMappings.Add("Kunag", "KUNAG");
                            //    objbulk.ColumnMappings.Add("KunagN", "KUNAG_N");
                            //    objbulk.ColumnMappings.Add("Ptnr", "PTNR");
                            //    objbulk.ColumnMappings.Add("PtnrN", "PTNR_N");
                            //    objbulk.ColumnMappings.Add("Salsrep", "SALSREP");
                            //    objbulk.ColumnMappings.Add("SalsrepN", "SALSREP_N");
                            //    objbulk.ColumnMappings.Add("Regio", "REGIO");
                            //    objbulk.ColumnMappings.Add("RegioN", "REGIO_N");
                            //    objbulk.ColumnMappings.Add("Dstrc", "DSTRC");
                            //    objbulk.ColumnMappings.Add("DstrcN", "DSTRC_N");
                            //    objbulk.ColumnMappings.Add("Block", "BLOCK");
                            //    objbulk.ColumnMappings.Add("BlockN", "BLOCK_N");
                            //    objbulk.ColumnMappings.Add("Destint", "DESTINT");
                            //    objbulk.ColumnMappings.Add("DestintN", "DESTINT_N");
                            //    objbulk.ColumnMappings.Add("Kdgrp", "KDGRP");
                            //    objbulk.ColumnMappings.Add("Ktext", "KTEXT");
                            //    objbulk.ColumnMappings.Add("PrimaryFrt", "PRIMARY_FRT");
                            //    objbulk.ColumnMappings.Add("SecondryFrt", "SECONDRY_FRT");
                            //    objbulk.ColumnMappings.Add("Rakno", "RAKNO");
                            //    objbulk.ColumnMappings.Add("Rakpt", "RAKPT");
                            //    objbulk.ColumnMappings.Add("Matkl", "MATKL");
                            //    objbulk.ColumnMappings.Add("Lgort", "LGORT");
                            //    objbulk.ColumnMappings.Add("Lgobe", "LGOBE");
                            //    objbulk.ColumnMappings.Add("Inco1", "INCO1");
                            //    objbulk.ColumnMappings.Add("Inco2", "INCO2");
                            //    objbulk.ColumnMappings.Add("UldgChgs", "ULDG_CHGS");
                            //    objbulk.ColumnMappings.Add("TrnsChgs", "TRNS_CHGS");
                            //    objbulk.ColumnMappings.Add("DpulChgs", "DPUL_CHGS");
                            //    objbulk.ColumnMappings.Add("DpldChgs", "DPLD_CHGS");
                            //    objbulk.ColumnMappings.Add("DivrChgs", "DIVR_CHGS");
                            //    objbulk.ColumnMappings.Add("LdngChgs", "LDNG_CHGS");
                            //    objbulk.ColumnMappings.Add("CfagChgs", "CFAG_CHGS");
                            //    objbulk.ColumnMappings.Add("RksrChgs", "RKSR_CHGS");
                            //    objbulk.ColumnMappings.Add("PuldChgs", "PULD_CHGS");
                            //    objbulk.ColumnMappings.Add("RkclChgs", "RKCL_CHGS");
                            //    objbulk.ColumnMappings.Add("ShntChgs", "SHNT_CHGS");
                            //    objbulk.ColumnMappings.Add("RkcfChgs", "RKCF_CHGS");
                            //    objbulk.ColumnMappings.Add("BlndChgs", "BLND_CHGS");
                            //    objbulk.ColumnMappings.Add("BlnbChgs", "BLNB_CHGS");
                            //    objbulk.ColumnMappings.Add("MiscMisc", "MISC_MISC");
                            //    objbulk.ColumnMappings.Add("Zzzone1", "ZZZONE1");
                            //    objbulk.ColumnMappings.Add("Zzzone1N", "ZZZONE1_N");
                            //    objbulk.ColumnMappings.Add("Zzbzirk", "ZZBZIRK");
                            //    objbulk.ColumnMappings.Add("ZzbzirkN", "ZZBZIRK_N");
                            //    objbulk.ColumnMappings.Add("Zzregio", "ZZREGIO");
                            //    objbulk.ColumnMappings.Add("ZzregioN", "ZZREGIO_N");
                            //    objbulk.ColumnMappings.Add("Vkbur", "VKBUR");
                            //    objbulk.ColumnMappings.Add("VkburN", "VKBUR_N");
                            //    objbulk.ColumnMappings.Add("Vkgrp", "VKGRP");
                            //    objbulk.ColumnMappings.Add("VkgrpN", "VKGRP_N");
                            //    objbulk.ColumnMappings.Add("Zzbranch", "ZZBRANCH");
                            //    objbulk.ColumnMappings.Add("ZzbranchN", "ZZBRANCH_N");
                            //    objbulk.ColumnMappings.Add("Pdstn", "PDSTN");
                            //    objbulk.ColumnMappings.Add("Sdstn", "SDSTN");
                            //    objbulk.ColumnMappings.Add("BlockCt", "BLOCK_CT");
                            //    objbulk.ColumnMappings.Add("Belnr", "BELNR");
                            //    objbulk.ColumnMappings.Add("Gjahr", "GJAHR");
                            //    objbulk.ColumnMappings.Add("InvType", "INV_TYPE");
                            //    objbulk.ColumnMappings.Add("FrtType", "FRT_TYPE");
                            //    objbulk.ColumnMappings.Add("Zzvlfkz", "ZZVLFKZ");
                            //    objbulk.ColumnMappings.Add("SuppPlantName", "SUPP_PLANT_NAME");
                            //    objbulk.ColumnMappings.Add("DepoRkMvt", "DEPO_RK_MVT");
                            //    objbulk.ColumnMappings.Add("IndPriFrt", "IND_PRI_FRT");
                            //    objbulk.ColumnMappings.Add("ShipFrtChrgs", "SHIP_FRT_CHRGS");
                            //    objbulk.ColumnMappings.Add("ShipHandChrgs", "SHIP_HAND_CHRGS");
                            //    objbulk.ColumnMappings.Add("Clkmnfplant", "CLKMNFPLANT");
                            //    objbulk.ColumnMappings.Add("Suppplant", "SUPPPLANT");
                            //    objbulk.ColumnMappings.Add("Distance", "DISTANCE");
                            //    objbulk.ColumnMappings.Add("Indpdistance", "INDPDISTANCE");
                            //    objbulk.ColumnMappings.Add("ClkPltName", "CLK_PLT_NAME");
                            //    objbulk.ColumnMappings.Add("MnfPltName", "MNF_PLT_NAME");
                            //    objbulk.ColumnMappings.Add("GeindPlt", "GEIND_PLT");
                            //    objbulk.ColumnMappings.Add("GeindPltName", "GEIND_PLT_NAME");
                            //    objbulk.ColumnMappings.Add("SupplDepo", "SUPPL_DEPO");
                            //    objbulk.ColumnMappings.Add("SupplDepoName", "SUPPL_DEPO_NAME");
                            //    objbulk.ColumnMappings.Add("Waerk", "WAERK");
                            //    objbulk.ColumnMappings.Add("Rent", "RENT");
                            //    objbulk.ColumnMappings.Add("Rakedemchrg", "RAKEDEMCHRG");
                            //    objbulk.ColumnMappings.Add("Ldistance", "LDISTANCE");
                            //    objbulk.ColumnMappings.Add("LdistanceClk", "LDISTANCE_CLK");
                            //    objbulk.ColumnMappings.Add("Matnr", "MATNR");
                            //    objbulk.ColumnMappings.Add("Vtext", "VTEXT");
                            //    objbulk.ColumnMappings.Add("Matnr1", "MATNR1");
                            //    objbulk.ColumnMappings.Add("Maktx", "MAKTX");
                            //    objbulk.ColumnMappings.Add("Incurredcost", "INCURREDCOST");
                            //    objbulk.ColumnMappings.Add("Unincurredcost", "UNINCURREDCOST");
                            //    objbulk.ColumnMappings.Add("ShRegio", "SH_REGIO");
                            //    objbulk.ColumnMappings.Add("ShDstrc", "SH_DSTRC");
                            //    objbulk.ColumnMappings.Add("ShBlock", "SH_BLOCK");
                            //    objbulk.ColumnMappings.Add("ShDestint", "SH_DESTINT");
                            //    objbulk.ColumnMappings.Add("Kalks", "KALKS");
                            //    objbulk.ColumnMappings.Add("DeliveryNo", "DELIVERY_NO");
                            //    objbulk.ColumnMappings.Add("Tknum", "TKNUM");
                            //    objbulk.ColumnMappings.Add("Mnfplant", "MNFPLANT");
                            //    objbulk.ColumnMappings.Add("Mnfdesc", "MNFDESC");
                            //    objbulk.ColumnMappings.Add("Mvgr1", "MVGR1");
                            //    objbulk.ColumnMappings.Add("Grossturn", "GROSSTURN");
                            //    objbulk.ColumnMappings.Add("Netturn", "NETTURN");
                            //    objbulk.ColumnMappings.Add("Nakedreal", "NAKEDREAL");
                            //    objbulk.ColumnMappings.Add("TransIncentive", "TRANS_INCENTIVE");
                            //    objbulk.ColumnMappings.Add("PltFrt", "PLT_FRT");
                            //    objbulk.ColumnMappings.Add("SpRegio", "SP_REGIO");
                            //    objbulk.ColumnMappings.Add("SpDstrc", "SP_DSTRC");
                            //    objbulk.ColumnMappings.Add("SpBlock", "SP_BLOCK");
                            //    objbulk.ColumnMappings.Add("SpDestint", "SP_DESTINT");
                            //    objbulk.ColumnMappings.Add("Traid", "TRAID");
                            //    objbulk.ColumnMappings.Add("TruckType", "TRUCK_TYPE");
                            //    objbulk.ColumnMappings.Add("EwbNo", "EWB_NO");
                            //    objbulk.ColumnMappings.Add("Edate", "EDATE");
                            //    objbulk.ColumnMappings.Add("Evdate", "EVDATE");
                            //    objbulk.ColumnMappings.Add("Steuc", "STEUC");
                            //    objbulk.ColumnMappings.Add("PaidPrice", "PAID_PRICE");
                            //    objbulk.ColumnMappings.Add("KalksDesc", "KALKS_DESC");
                            //    objbulk.ColumnMappings.Add("SpRegioDesc", "SP_REGIO_DESC");
                            //    objbulk.ColumnMappings.Add("SpDstrcDesc", "SP_DSTRC_DESC");
                            //    objbulk.ColumnMappings.Add("SpBlockDesc", "SP_BLOCK_DESC");
                            //    objbulk.ColumnMappings.Add("SpDestintDesc", "SP_DESTINT_DESC");
                            //    objbulk.ColumnMappings.Add("MfPlantType", "MF_PLANT_TYPE");
                            //    objbulk.ColumnMappings.Add("TotalTdcCost", "TOTAL_TDC_COST");
                            //    objbulk.ColumnMappings.Add("TotalDistance", "TOTAL_DISTANCE");
                            //    objbulk.ColumnMappings.Add("DepotIndFrieght", "DEPOT_IND_FRIEGHT");
                            //    objbulk.ColumnMappings.Add("TotalInvoiceFrt", "TOTAL_INVOICE_FRT");
                            //    objbulk.ColumnMappings.Add("RoadPfIncurred", "ROAD_PF_INCURRED");
                            //    objbulk.ColumnMappings.Add("RoadPfUnincurred", "ROAD_PF_UNINCURRED");
                            //    objbulk.ColumnMappings.Add("RoadSfIncurred", "ROAD_SF_INCURRED");
                            //    objbulk.ColumnMappings.Add("RoadSfUnincurred", "ROAD_SF_UNINCURRED");
                            //    objbulk.ColumnMappings.Add("RailPfIncurred", "RAIL_PF_INCURRED");
                            //    objbulk.ColumnMappings.Add("RailPfUnincurred", "RAIL_PF_UNINCURRED");
                            //    objbulk.ColumnMappings.Add("DrdlChgs", "DRDL_CHGS");
                            //    objbulk.ColumnMappings.Add("DbLabChgs", "DB_LAB_CHGS");
                            //    objbulk.ColumnMappings.Add("ZinvCancel", "ZINV_CANCEL");
                            //    objbulk.ColumnMappings.Add("ShDestintDesc", "SH_DESTINT_DESC");
                            //    objbulk.ColumnMappings.Add("ShipDistance", "SHIP_DISTANCE");


                            //    //objbulk.ColumnMappings.Add("FileName", "Filename + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffff")");

                            //    //inserting Datatable Records to DataBase    
                            //    //con.Open();
                            //    objbulk.WriteToServer(dt);




                            //    con.Close();

                            //}


                            int i = 0;
                            int result = 0;
                            using (MySqlConnection con = new MySqlConnection(CS))
                            {
                                
                                con.Open();
                                foreach (DataRow row in dt.Rows)
                                {

                                    query = "";
                                    query = "Insert into zsd_lcost_data_srv_Temp(VBELN,FKART,FKDAT,FKIMG,MEINS,WERKS,W_NAME1,ZSOURCE,ZSOURCED,ZTRATYP,ZTRATYPD,KUNNR,KUNNR_N,KUNAG,";
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
                                    cmd.Parameters.AddWithValue("@YREALIZATION_PKID", i);
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

                                    result = cmd.ExecuteNonQuery();

                                    query = "";
                                    result = 0;

                                    i += 1;
                                    Console.WriteLine("Row No : " + i);
                                    query = "";
                                    int isExists = 0;
                                    query += " SELECT EXISTS(SELECT vbeln FROM zsd_lcost_data_srv WHERE vbeln = '" + row["VBELN"].ToString() + "') isexist";

                                    using (MySqlConnection sqlCon = new MySqlConnection(CS))
                                    {
                                        sqlCon.Open();
                                        MySqlCommand Cmnd = new MySqlCommand(query, sqlCon);

                                        object resultexscalar = Cmnd.ExecuteScalar();

                                        if (resultexscalar != null)
                                        {
                                            isExists = Convert.ToInt32(resultexscalar);
                                        }

                                        sqlCon.Close();
                                    }
                                    query = "";
                                    if (isExists == 0)
                                    {
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
                                    }
                                    else
                                    {
                                        query = "update ZSD_LCOST_DATA_SRV set ";
                                        query += "FKART=@FKART,FKDAT=@FKDAT,FKIMG=@FKIMG,MEINS=@MEINS,WERKS=@WERKS,W_NAME1=@W_NAME1,";
                                        query += "ZSOURCE=@ZSOURCE,ZSOURCED=@ZSOURCED,ZTRATYP=@ZTRATYP,ZTRATYPD=@ZTRATYPD,KUNNR=@KUNNR,";
                                        query += "KUNNR_N=@KUNNR_N,KUNAG=@KUNAG,KUNAG_N=@KUNAG_N,PTNR=@PTNR,PTNR_N=@PTNR_N,";
                                        query += "SALSREP=@SALSREP,SALSREP_N=@SALSREP_N,REGIO=@REGIO,REGIO_N=@REGIO_N,DSTRC=@DSTRC,";
                                        query += "DSTRC_N=@DSTRC_N,BLOCK=@BLOCK,BLOCK_N=@BLOCK_N,DESTINT=@DESTINT,DESTINT_N=@DESTINT_N,";
                                        query += "KDGRP=@KDGRP,KTEXT=@KTEXT,PRIMARY_FRT=@PRIMARY_FRT,SECONDRY_FRT=@SECONDRY_FRT,";
                                        query += "RAKNO=@RAKNO,RAKPT=@RAKPT,MATKL=@MATKL,LGORT=@LGORT,LGOBE=@LGOBE,INCO1=@INCO1,";
                                        query += "INCO2=@INCO2,ULDG_CHGS=@ULDG_CHGS,TRNS_CHGS=@TRNS_CHGS,DPUL_CHGS=@DPUL_CHGS,";
                                        query += "DPLD_CHGS=@DPLD_CHGS,DIVR_CHGS=@DIVR_CHGS,LDNG_CHGS=@LDNG_CHGS,CFAG_CHGS=@CFAG_CHGS,";
                                        query += "RKSR_CHGS=@RKSR_CHGS,PULD_CHGS=@PULD_CHGS,RKCL_CHGS=@RKCL_CHGS,SHNT_CHGS=@SHNT_CHGS,";
                                        query += "RKCF_CHGS=@RKCF_CHGS,BLND_CHGS=@BLND_CHGS,BLNB_CHGS=@BLNB_CHGS,MISC_MISC=@MISC_MISC,";
                                        query += "ZZZONE1=@ZZZONE1,ZZZONE1_N=@ZZZONE1_N,ZZBZIRK=@ZZBZIRK,ZZBZIRK_N=@ZZBZIRK_N,";
                                        query += "ZZREGIO=@ZZREGIO,ZZREGIO_N=@ZZREGIO_N,VKBUR=@VKBUR,VKBUR_N=@VKBUR_N,VKGRP=@VKGRP,";
                                        query += "VKGRP_N=@VKGRP_N,ZZBRANCH=@ZZBRANCH,ZZBRANCH_N=@ZZBRANCH_N,PDSTN=@PDSTN,SDSTN=@SDSTN,";
                                        query += "BLOCK_CT=@BLOCK_CT,BELNR=@BELNR,GJAHR=@GJAHR,INV_TYPE=@INV_TYPE,FRT_TYPE=@FRT_TYPE,";
                                        query += "ZZVLFKZ=@ZZVLFKZ,SUPP_PLANT_NAME=@SUPP_PLANT_NAME,DEPO_RK_MVT=@DEPO_RK_MVT,";
                                        query += "IND_PRI_FRT=@IND_PRI_FRT,SHIP_FRT_CHRGS=@SHIP_FRT_CHRGS,SHIP_HAND_CHRGS=@SHIP_HAND_CHRGS,";
                                        query += "CLKMNFPLANT=@CLKMNFPLANT,SUPPPLANT=@SUPPPLANT,DISTANCE=@DISTANCE,INDPDISTANCE=@INDPDISTANCE,";
                                        query += "CLK_PLT_NAME=@CLK_PLT_NAME,MNF_PLT_NAME=@MNF_PLT_NAME,GEIND_PLT=@GEIND_PLT,";
                                        query += "GEIND_PLT_NAME=@GEIND_PLT_NAME,SUPPL_DEPO=@SUPPL_DEPO,SUPPL_DEPO_NAME=@SUPPL_DEPO_NAME,";
                                        query += "WAERK=@WAERK,RENT=@RENT,RAKEDEMCHRG=@RAKEDEMCHRG,LDISTANCE=@LDISTANCE,";
                                        query += "LDISTANCE_CLK=@LDISTANCE_CLK,MATNR=@MATNR,VTEXT=@VTEXT,MATNR1=@MATNR1,";
                                        query += "MAKTX=@MAKTX,INCURREDCOST=@INCURREDCOST,UNINCURREDCOST=@UNINCURREDCOST,SH_REGIO=@SH_REGIO,";
                                        query += "SH_DSTRC=@SH_DSTRC,SH_BLOCK=@SH_BLOCK,SH_DESTINT=@SH_DESTINT,KALKS=@KALKS,";
                                        query += "DELIVERY_NO=@DELIVERY_NO,TKNUM=@TKNUM,MNFPLANT=@MNFPLANT,MNFDESC=@MNFDESC,MVGR1=@MVGR1,";
                                        query += "GROSSTURN=@GROSSTURN,NETTURN=@NETTURN,NAKEDREAL=@NAKEDREAL,TRANS_INCENTIVE=@TRANS_INCENTIVE,";
                                        query += "PLT_FRT=@PLT_FRT,SP_REGIO=@SP_REGIO,SP_DSTRC=@SP_DSTRC,SP_BLOCK=@SP_BLOCK,";
                                        query += "SP_DESTINT=@SP_DESTINT,TRAID=@TRAID,TRUCK_TYPE=@TRUCK_TYPE,EWB_NO=@EWB_NO,";
                                        query += "EDATE=@EDATE,EVDATE=@EVDATE,STEUC=@STEUC,PAID_PRICE=@PAID_PRICE,";
                                        query += "KALKS_DESC=@KALKS_DESC,SP_REGIO_DESC=@SP_REGIO_DESC,SP_DSTRC_DESC=@SP_DSTRC_DESC,";
                                        query += "SP_BLOCK_DESC=@SP_BLOCK_DESC,SP_DESTINT_DESC=@SP_DESTINT_DESC,";
                                        query += "MF_PLANT_TYPE=@MF_PLANT_TYPE,TOTAL_TDC_COST=@TOTAL_TDC_COST,";
                                        query += "TOTAL_DISTANCE=@TOTAL_DISTANCE,DEPOT_IND_FRIEGHT=@DEPOT_IND_FRIEGHT,";
                                        query += "TOTAL_INVOICE_FRT=@TOTAL_INVOICE_FRT,ROAD_PF_INCURRED=@ROAD_PF_INCURRED,";
                                        query += "ROAD_PF_UNINCURRED=@ROAD_PF_UNINCURRED,ROAD_SF_INCURRED=@ROAD_SF_INCURRED,";
                                        query += "ROAD_SF_UNINCURRED=@ROAD_SF_UNINCURRED,RAIL_PF_INCURRED=@RAIL_PF_INCURRED,";
                                        query += "RAIL_PF_UNINCURRED=@RAIL_PF_UNINCURRED,DRDL_CHGS=@DRDL_CHGS,";
                                        query += "DB_LAB_CHGS=@DB_LAB_CHGS,ZINV_CANCEL=@ZINV_CANCEL,SH_DESTINT_DESC=@SH_DESTINT_DESC,";
                                        query += "SHIP_DISTANCE=@SHIP_DISTANCE";
                                        query += " Where VBELN=@VBELN";
                                    }
                                    //flag = false;

                                    MySqlCommand cmdt = new MySqlCommand(query, con);
                                    //cmd.Parameters.AddWithValue("@YREALIZATION_PKID", i);
                                    cmdt.Parameters.AddWithValue("@VBELN", row["VBELN"].ToString());
                                    cmdt.Parameters.AddWithValue("@FKART", row["FKART"].ToString());
                                    cmdt.Parameters.AddWithValue("@FKDAT", row["FKDAT"].ToString());
                                    cmdt.Parameters.AddWithValue("@FKIMG", row["FKIMG"].ToString());
                                    cmdt.Parameters.AddWithValue("@MEINS", row["MEINS"].ToString());
                                    cmdt.Parameters.AddWithValue("@WERKS", row["WERKS"].ToString());

                                    cmdt.Parameters.AddWithValue("@W_NAME1", row["WNAME1"].ToString());
                                    cmdt.Parameters.AddWithValue("@ZSOURCE", row["ZSOURCE"].ToString());
                                    cmdt.Parameters.AddWithValue("@ZSOURCED", row["ZSOURCED"].ToString());
                                    cmdt.Parameters.AddWithValue("@ZTRATYP", row["ZTRATYP"].ToString());
                                    cmdt.Parameters.AddWithValue("@ZTRATYPD", row["ZTRATYPD"].ToString());
                                    cmdt.Parameters.AddWithValue("@KUNNR", row["KUNNR"].ToString());
                                    cmdt.Parameters.AddWithValue("@KUNNR_N", row["KUNNRN"].ToString());
                                    cmdt.Parameters.AddWithValue("@KUNAG", row["KUNAG"].ToString());
                                    cmdt.Parameters.AddWithValue("@KUNAG_N", row["KUNAGN"].ToString());
                                    cmdt.Parameters.AddWithValue("@PTNR", row["PTNR"].ToString());
                                    cmdt.Parameters.AddWithValue("@PTNR_N", row["PTNRN"].ToString());
                                    cmdt.Parameters.AddWithValue("@SALSREP", row["SALSREP"].ToString());
                                    cmdt.Parameters.AddWithValue("@SALSREP_N", row["SALSREPN"].ToString());
                                    cmdt.Parameters.AddWithValue("@REGIO", row["REGIO"].ToString());
                                    cmdt.Parameters.AddWithValue("@REGIO_N", row["REGION"].ToString());
                                    cmdt.Parameters.AddWithValue("@DSTRC", row["DSTRC"].ToString());
                                    cmdt.Parameters.AddWithValue("@DSTRC_N", row["DSTRCN"].ToString());
                                    cmdt.Parameters.AddWithValue("@BLOCK", row["BLOCK"].ToString());
                                    cmdt.Parameters.AddWithValue("@BLOCK_N", row["BLOCKN"].ToString());
                                    cmdt.Parameters.AddWithValue("@DESTINT", row["DESTINT"].ToString());
                                    cmdt.Parameters.AddWithValue("@DESTINT_N", row["DESTINTN"].ToString());
                                    cmdt.Parameters.AddWithValue("@KDGRP", row["KDGRP"].ToString());
                                    cmdt.Parameters.AddWithValue("@KTEXT", row["KTEXT"].ToString());
                                    cmdt.Parameters.AddWithValue("@PRIMARY_FRT", row["PRIMARYFRT"].ToString());
                                    cmdt.Parameters.AddWithValue("@SECONDRY_FRT", row["SECONDRYFRT"].ToString());
                                    cmdt.Parameters.AddWithValue("@RAKNO", row["RAKNO"].ToString());
                                    cmdt.Parameters.AddWithValue("@RAKPT", row["RAKPT"].ToString());
                                    cmdt.Parameters.AddWithValue("@MATKL", row["MATKL"].ToString());
                                    cmdt.Parameters.AddWithValue("@LGORT", row["LGORT"].ToString());
                                    cmdt.Parameters.AddWithValue("@LGOBE", row["LGOBE"].ToString());
                                    cmdt.Parameters.AddWithValue("@INCO1", row["INCO1"].ToString());
                                    cmdt.Parameters.AddWithValue("@INCO2", row["INCO2"].ToString());
                                    cmdt.Parameters.AddWithValue("@ULDG_CHGS", row["ULDGCHGS"].ToString());
                                    cmdt.Parameters.AddWithValue("@TRNS_CHGS", row["TRNSCHGS"].ToString());
                                    cmdt.Parameters.AddWithValue("@DPUL_CHGS", row["DPULCHGS"].ToString());
                                    cmdt.Parameters.AddWithValue("@DPLD_CHGS", row["DPLDCHGS"].ToString());
                                    cmdt.Parameters.AddWithValue("@DIVR_CHGS", row["DIVRCHGS"].ToString());
                                    cmdt.Parameters.AddWithValue("@LDNG_CHGS", row["LDNGCHGS"].ToString());
                                    cmdt.Parameters.AddWithValue("@CFAG_CHGS", row["CFAGCHGS"].ToString());
                                    cmdt.Parameters.AddWithValue("@RKSR_CHGS", row["RKSRCHGS"].ToString());
                                    cmdt.Parameters.AddWithValue("@PULD_CHGS", row["PULDCHGS"].ToString());
                                    cmdt.Parameters.AddWithValue("@RKCL_CHGS", row["RKCLCHGS"].ToString());
                                    cmdt.Parameters.AddWithValue("@SHNT_CHGS", row["SHNTCHGS"].ToString());
                                    cmdt.Parameters.AddWithValue("@RKCF_CHGS", row["RKCFCHGS"].ToString());
                                    cmdt.Parameters.AddWithValue("@BLND_CHGS", row["BLNDCHGS"].ToString());
                                    cmdt.Parameters.AddWithValue("@BLNB_CHGS", row["BLNBCHGS"].ToString());
                                    cmdt.Parameters.AddWithValue("@MISC_MISC", row["MISCMISC"].ToString());
                                    cmdt.Parameters.AddWithValue("@ZZZONE1", row["ZZZONE1"].ToString());
                                    cmdt.Parameters.AddWithValue("@ZZZONE1_N", row["ZZZONE1N"].ToString());
                                    cmdt.Parameters.AddWithValue("@ZZBZIRK", row["ZZBZIRK"].ToString());
                                    cmdt.Parameters.AddWithValue("@ZZBZIRK_N", row["ZZBZIRKN"].ToString());
                                    cmdt.Parameters.AddWithValue("@ZZREGIO", row["ZZREGIO"].ToString());
                                    cmdt.Parameters.AddWithValue("@ZZREGIO_N", row["ZZREGION"].ToString());
                                    cmdt.Parameters.AddWithValue("@VKBUR", row["VKBUR"].ToString());
                                    cmdt.Parameters.AddWithValue("@VKBUR_N", row["VKBURN"].ToString());
                                    cmdt.Parameters.AddWithValue("@VKGRP", row["VKGRP"].ToString());
                                    cmdt.Parameters.AddWithValue("@VKGRP_N", row["VKGRPN"].ToString());
                                    cmdt.Parameters.AddWithValue("@ZZBRANCH", row["ZZBRANCH"].ToString());
                                    cmdt.Parameters.AddWithValue("@ZZBRANCH_N", row["ZZBRANCHN"].ToString());
                                    cmdt.Parameters.AddWithValue("@PDSTN", row["PDSTN"].ToString());
                                    cmdt.Parameters.AddWithValue("@SDSTN", row["SDSTN"].ToString());
                                    cmdt.Parameters.AddWithValue("@BLOCK_CT", row["BLOCKCT"].ToString());
                                    cmdt.Parameters.AddWithValue("@BELNR", row["BELNR"].ToString());
                                    cmdt.Parameters.AddWithValue("@GJAHR", row["GJAHR"].ToString());
                                    cmdt.Parameters.AddWithValue("@INV_TYPE", row["INVTYPE"].ToString());
                                    cmdt.Parameters.AddWithValue("@FRT_TYPE", row["FRTTYPE"].ToString());
                                    cmdt.Parameters.AddWithValue("@ZZVLFKZ", row["ZZVLFKZ"].ToString());
                                    cmdt.Parameters.AddWithValue("@SUPP_PLANT_NAME", row["SUPPPLANTNAME"].ToString());
                                    cmdt.Parameters.AddWithValue("@DEPO_RK_MVT", row["DEPORKMVT"].ToString());
                                    cmdt.Parameters.AddWithValue("@IND_PRI_FRT", row["INDPRIFRT"].ToString());

                                    cmdt.Parameters.AddWithValue("@SHIP_FRT_CHRGS", row["SHIPFRTCHRGS"].ToString());
                                    cmdt.Parameters.AddWithValue("@SHIP_HAND_CHRGS", row["SHIPHANDCHRGS"].ToString());
                                    cmdt.Parameters.AddWithValue("@CLKMNFPLANT", row["CLKMNFPLANT"].ToString());
                                    cmdt.Parameters.AddWithValue("@SUPPPLANT", row["SUPPPLANT"].ToString());
                                    cmdt.Parameters.AddWithValue("@DISTANCE", row["DISTANCE"].ToString());
                                    cmdt.Parameters.AddWithValue("@INDPDISTANCE", row["INDPDISTANCE"].ToString());
                                    cmdt.Parameters.AddWithValue("@CLK_PLT_NAME", row["CLKPLTNAME"].ToString());
                                    cmdt.Parameters.AddWithValue("@MNF_PLT_NAME", row["MNFPLTNAME"].ToString());
                                    cmdt.Parameters.AddWithValue("@GEIND_PLT", row["GEINDPLT"].ToString());
                                    cmdt.Parameters.AddWithValue("@GEIND_PLT_NAME", row["GEINDPLTNAME"].ToString());
                                    cmdt.Parameters.AddWithValue("@SUPPL_DEPO", row["SUPPLDEPO"].ToString());
                                    cmdt.Parameters.AddWithValue("@SUPPL_DEPO_NAME", row["SUPPLDEPONAME"].ToString());
                                    cmdt.Parameters.AddWithValue("@WAERK", row["WAERK"].ToString());
                                    cmdt.Parameters.AddWithValue("@RENT", row["RENT"].ToString());
                                    cmdt.Parameters.AddWithValue("@RAKEDEMCHRG", row["RAKEDEMCHRG"].ToString());
                                    cmdt.Parameters.AddWithValue("@LDISTANCE", row["LDISTANCE"].ToString());
                                    cmdt.Parameters.AddWithValue("@LDISTANCE_CLK", row["LDISTANCECLK"].ToString());
                                    cmdt.Parameters.AddWithValue("@MATNR", row["MATNR"].ToString());
                                    cmdt.Parameters.AddWithValue("@VTEXT", row["VTEXT"].ToString());
                                    cmdt.Parameters.AddWithValue("@MATNR1", row["MATNR1"].ToString());
                                    cmdt.Parameters.AddWithValue("@MAKTX", row["MAKTX"].ToString());
                                    cmdt.Parameters.AddWithValue("@INCURREDCOST", row["INCURREDCOST"].ToString());
                                    cmdt.Parameters.AddWithValue("@UNINCURREDCOST", row["UNINCURREDCOST"].ToString());
                                    cmdt.Parameters.AddWithValue("@SH_REGIO", row["SHREGIO"].ToString());
                                    cmdt.Parameters.AddWithValue("@SH_DSTRC", row["SHDSTRC"].ToString());
                                    cmdt.Parameters.AddWithValue("@SH_BLOCK", row["SHBLOCK"].ToString());
                                    cmdt.Parameters.AddWithValue("@SH_DESTINT", row["SHDESTINT"].ToString());
                                    cmdt.Parameters.AddWithValue("@KALKS", row["KALKS"].ToString());
                                    cmdt.Parameters.AddWithValue("@DELIVERY_NO", row["DELIVERYNO"].ToString());
                                    cmdt.Parameters.AddWithValue("@TKNUM", row["TKNUM"].ToString());
                                    cmdt.Parameters.AddWithValue("@MNFPLANT", row["MNFPLANT"].ToString());
                                    cmdt.Parameters.AddWithValue("@MNFDESC", row["MNFDESC"].ToString());
                                    cmdt.Parameters.AddWithValue("@MVGR1", row["MVGR1"].ToString());
                                    cmdt.Parameters.AddWithValue("@GROSSTURN", row["GROSSTURN"].ToString());
                                    cmdt.Parameters.AddWithValue("@NETTURN", row["NETTURN"].ToString());
                                    cmdt.Parameters.AddWithValue("@NAKEDREAL", row["NAKEDREAL"].ToString());
                                    cmdt.Parameters.AddWithValue("@TRANS_INCENTIVE", row["TRANSINCENTIVE"].ToString());
                                    cmdt.Parameters.AddWithValue("@PLT_FRT", row["PLTFRT"].ToString());
                                    cmdt.Parameters.AddWithValue("@SP_REGIO", row["SPREGIO"].ToString());
                                    cmdt.Parameters.AddWithValue("@SP_DSTRC", row["SPDSTRC"].ToString());
                                    cmdt.Parameters.AddWithValue("@SP_BLOCK", row["SPBLOCK"].ToString());
                                    cmdt.Parameters.AddWithValue("@SP_DESTINT", row["SPDESTINT"].ToString());
                                    cmdt.Parameters.AddWithValue("@TRAID", row["TRAID"].ToString());
                                    cmdt.Parameters.AddWithValue("@TRUCK_TYPE", row["TRUCKTYPE"].ToString());
                                    cmdt.Parameters.AddWithValue("@EWB_NO", row["EWBNO"].ToString());
                                    cmdt.Parameters.AddWithValue("@EDATE", row["EDATE"].ToString());
                                    cmdt.Parameters.AddWithValue("@EVDATE", row["EVDATE"].ToString());
                                    cmdt.Parameters.AddWithValue("@STEUC", row["STEUC"].ToString());
                                    cmdt.Parameters.AddWithValue("@PAID_PRICE", row["PAIDPRICE"].ToString());
                                    cmdt.Parameters.AddWithValue("@KALKS_DESC", row["KALKSDESC"].ToString());
                                    cmdt.Parameters.AddWithValue("@SP_REGIO_DESC", row["SPREGIODESC"].ToString());
                                    cmdt.Parameters.AddWithValue("@SP_DSTRC_DESC", row["SPDSTRCDESC"].ToString());
                                    cmdt.Parameters.AddWithValue("@SP_BLOCK_DESC", row["SPBLOCKDESC"].ToString());
                                    cmdt.Parameters.AddWithValue("@SP_DESTINT_DESC", row["SPDESTINTDESC"].ToString());
                                    cmdt.Parameters.AddWithValue("@MF_PLANT_TYPE", row["TOTALTDCCOST"].ToString());

                                    cmdt.Parameters.AddWithValue("@TOTAL_TDC_COST", row["TOTALTDCCOST"].ToString());

                                    cmdt.Parameters.AddWithValue("@TOTAL_DISTANCE", row["TOTALDISTANCE"].ToString());
                                    cmdt.Parameters.AddWithValue("@DEPOT_IND_FRIEGHT", row["DEPOTINDFRIEGHT"].ToString());
                                    cmdt.Parameters.AddWithValue("@TOTAL_INVOICE_FRT", row["TOTALINVOICEFRT"].ToString());
                                    cmdt.Parameters.AddWithValue("@ROAD_PF_INCURRED", row["ROADPFINCURRED"].ToString());
                                    cmdt.Parameters.AddWithValue("@ROAD_PF_UNINCURRED", row["ROADPFUNINCURRED"].ToString());
                                    cmdt.Parameters.AddWithValue("@ROAD_SF_INCURRED", row["ROADSFINCURRED"].ToString());
                                    cmdt.Parameters.AddWithValue("@ROAD_SF_UNINCURRED", row["ROADSFUNINCURRED"].ToString());
                                    cmdt.Parameters.AddWithValue("@RAIL_PF_INCURRED", row["RAILPFINCURRED"].ToString());
                                    cmdt.Parameters.AddWithValue("@RAIL_PF_UNINCURRED", row["RAILPFUNINCURRED"].ToString());
                                    cmdt.Parameters.AddWithValue("@DRDL_CHGS", row["DRDLCHGS"].ToString());
                                    cmdt.Parameters.AddWithValue("@DB_LAB_CHGS", row["DBLABCHGS"].ToString());
                                    cmdt.Parameters.AddWithValue("@ZINV_CANCEL", row["ZINVCANCEL"].ToString());
                                    cmdt.Parameters.AddWithValue("@SH_DESTINT_DESC", row["SHDESTINTDESC"].ToString());
                                    cmdt.Parameters.AddWithValue("@SHIP_DISTANCE", row["SHIPDISTANCE"].ToString());

                                    cmdt.CommandType = CommandType.Text;

                                    result = cmdt.ExecuteNonQuery();

                                    

                                }

                            }

                           


                        }
                        else
                        {
                            log1.WriteLine("Web API Response Status Code: " + Convert.ToInt16(response.StatusCode) + ", Status : " + response.StatusCode);
                            //if (Convert.ToInt16(response.StatusCode) == 400)
                            //{
                            //    query = "";
                            //    query = " Delete from ZSD_LCOST_DATA_SRV ";
                            //    query += " where date_format(cast(Fkdat as date),'%Y%m%d') ";
                            //    query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";

                            //    using (MySqlConnection sqlCon = new MySqlConnection(CS))
                            //    {
                            //        sqlCon.Open();
                            //        MySqlCommand Cmnd = new MySqlCommand(query, sqlCon);

                            //        int result = Cmnd.ExecuteNonQuery();

                            //        sqlCon.Close();
                            //    }

                            //    query = "";
                            //    query += " Select Count(*) Cnt from YREALIZATION ";
                            //    query += " where date_format(cast(Fkdat as date),'%Y%m%d') ";
                            //    query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";

                            //    using (MySqlConnection sqlCon = new MySqlConnection(CS))
                            //    {
                            //        sqlCon.Open();
                            //        MySqlCommand Cmnd = new MySqlCommand(query, sqlCon);

                            //        object resultexscalar = Cmnd.ExecuteScalar();

                            //        if (resultexscalar != null)
                            //        {
                            //            reccount = Convert.ToInt32(resultexscalar);
                            //        }
                            //        sqlCon.Close();
                            //    }

                            //    if (reccount == 0)
                            //    {
                            //        log1.WriteLine("No Records found in API");
                            //    }
                            //}
                            //else
                            //{
                            //    log1.WriteLine("Web API Response Status Code: " + Convert.ToInt16(response.StatusCode) + ", Status : " + response.StatusCode);
                            //}
                        }
                    }
                }


                DataView view = new DataView(dtZSD_LCOST_DATA_SRV);
                DataTable distinctValues = view.ToTable(true, "VBELN");

                if (distinctValues.Rows.Count > 0)
                {
                    log1.WriteLine("WebApi Record Count : " + distinctValues.Rows.Count);
                    Console.WriteLine("WebApi Record Count : " + distinctValues.Rows.Count);
                }
                else
                {
                    log1.WriteLine("WebApi Record Count : 0");
                    Console.WriteLine("WebApi Record Count : 0");
                }

                query = "";
                query = " Select Count(*) from ZSD_LCOST_DATA_SRV ";
                query += " where VBELN in (select distinct VBELN from zsd_lcost_data_srv_Temp) and date_format(cast(Fkdat as date),'%Y%m%d') ";
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



                if (distinctValues.Rows.Count == reccount)
                {
                    log1.WriteLine("Table record Count : " + reccount);
                    log1.WriteLine("Record Mathing");
                    Console.WriteLine("Table record Count : " + reccount);
                    Console.WriteLine("Record Mathing");

                }
                else
                {
                    log1.WriteLine("Table record Count : " + reccount);
                    log1.WriteLine("Record Insert Failed");
                    Console.WriteLine("Table record Count : " + reccount);
                    Console.WriteLine("Record Mathing");
                }
                //Maxid = 19;

                // return View(lstsrvdeal);

            }
            catch (Exception ex)
            {
                
                Console.WriteLine("ZSD_LCOST_DATA_SRV Error Message : " + ex.Message);
                log1.WriteLine("ZSD_LCOST_DATA_SRV Error Message : " + ex.Message);
                log1.WriteLine("===========================================");
            }
            log1.WriteLine("===========================================");
            log1.Close();
    
        }


        public void Export_Mismatch(string startDate, string endDate)
        {
            try
            {
                string filename = System.Configuration.ConfigurationManager.AppSettings["LogFile"].ToString();
                string query = "";

                if (!File.Exists(filename))
                {
                    log1 = new StreamWriter(filename, append: true);
                }
                else
                {
                    log1 = File.AppendText(filename);
                }

                log1.WriteLine("Export Mismatch Executed on : " + DateTime.Now);


                DataTable dtYREALIZATION = new DataTable("YREALIZATION");
                dtYREALIZATION.Columns.AddRange(new DataColumn[107]
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

                DataTable dtzsd_lcost_data_srv = new DataTable("zsd_lcost_data_srv");
                dtzsd_lcost_data_srv.Columns.AddRange(new DataColumn[146]
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
                    query = "";
                    query += " Select * from YREALIZATION ";
                    query += " where VBELN not in ";
                    query += " (select VBELN from yrealization_temp) ";
                    query += " and date_format(cast(ERDAT as date),'%Y%m%d') ";
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
                                DataRow _dr = dtYREALIZATION.NewRow();


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


                                dtYREALIZATION.Rows.Add(_dr);

                            }
                        }
                        con.Close();
                    }

                    string fnameYREA = "Table_VS_API_YREALIZATION_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xlsx";

                    if (dtYREALIZATION.Rows.Count > 0)
                    {
                        log1.WriteLine("Table_VS_API_YREALIZATION Executed on : " + DateTime.Now);

                        if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["MisMatchPath"].ToString() + fnameYREA))
                        {
                            File.Delete(System.Configuration.ConfigurationManager.AppSettings["MisMatchPath"].ToString() + fnameYREA);
                        }

                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dtYREALIZATION);
                            wb.SaveAs(System.Configuration.ConfigurationManager.AppSettings["MisMatchPath"].ToString() + fnameYREA);
                        }
                    }

                    dtYREALIZATION.Rows.Clear();




                }

                using (MySqlConnection con = new MySqlConnection(CS))
                {
                    query = "";
                    query += " Select * from yrealization_temp ";
                    query += " where VBELN not in ";
                    query += " (select VBELN from yrealization ";
                    query += " Where date_format(cast(ERDAT as date),'%Y%m%d') ";
                    query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "')";
                    query += " order by date_format(cast(Erdat as date),'%Y%m%d') ";
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {

                        cmd.Connection = con;
                        con.Open();
                        using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                DataRow _dr = dtYREALIZATION.NewRow();


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


                                dtYREALIZATION.Rows.Add(_dr);

                            }
                        }
                        con.Close();
                    }

                    string fnameYREATemp = "API_VS_Table_YREALIZATION_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xlsx";

                    if (dtYREALIZATION.Rows.Count > 0)
                    {
                        log1.WriteLine("API_VS_Table_YREALIZATION Executed on : " + DateTime.Now);

                        if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["MisMatchPath"].ToString() + fnameYREATemp))
                        {
                            File.Delete(System.Configuration.ConfigurationManager.AppSettings["MisMatchPath"].ToString() + fnameYREATemp);
                        }

                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dtYREALIZATION);
                            wb.SaveAs(System.Configuration.ConfigurationManager.AppSettings["MisMatchPath"].ToString() + fnameYREATemp);
                        }
                    }
                }

                using (MySqlConnection con = new MySqlConnection(CS))
                {
                    query = "";
                    query += " Select * from zsd_lcost_data_srv ";
                    query += " where VBELN not in ";
                    query += " (select VBELN from zsd_lcost_data_srv_temp) ";
                    query += " and date_format(cast(FKdat as date),'%Y%m%d') ";
                    query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "'";
                    query += " order by date_format(cast(FKdat as date),'%Y%m%d') ";
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {

                        cmd.Connection = con;
                        con.Open();
                        using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                DataRow _dr = dtzsd_lcost_data_srv.NewRow();


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

                                dtzsd_lcost_data_srv.Rows.Add(_dr);

                            }
                        }
                        con.Close();
                    }

                    string fnamezsd_lcost = "Table_VS_API_zsd_lcost_data_srv_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xlsx";

                    if (dtzsd_lcost_data_srv.Rows.Count > 0)
                    {
                        log1.WriteLine("Table_VS_API_zsd_lcost_data_srv Executed on : " + DateTime.Now);

                        if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["MisMatchPath"].ToString() + fnamezsd_lcost))
                        {
                            File.Delete(System.Configuration.ConfigurationManager.AppSettings["MisMatchPath"].ToString() + fnamezsd_lcost);
                        }

                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dtzsd_lcost_data_srv);
                            wb.SaveAs(System.Configuration.ConfigurationManager.AppSettings["MisMatchPath"].ToString() + fnamezsd_lcost);
                        }
                    }

                    dtzsd_lcost_data_srv.Rows.Clear();




                }

                using (MySqlConnection con = new MySqlConnection(CS))
                {
                    query = "";
                    query += " Select * from zsd_lcost_data_srv_temp ";
                    query += " where VBELN not in ";
                    query += " (select VBELN from zsd_lcost_data_srv ";
                    query += " Where date_format(cast(FKdat as date),'%Y%m%d') ";
                    query += " between '" + startDate.Trim() + "' and '" + endDate.Trim() + "')";
                    query += " order by date_format(cast(FKdat as date),'%Y%m%d') ";
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {

                        cmd.Connection = con;
                        con.Open();
                        using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                DataRow _dr = dtzsd_lcost_data_srv.NewRow();


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

                                dtzsd_lcost_data_srv.Rows.Add(_dr);

                            }
                        }
                        con.Close();
                    }

                    string fnamezsd_lcostTemp = "API_VS_Table_zsd_lcost_data_srv_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xlsx";

                    if (dtzsd_lcost_data_srv.Rows.Count > 0)
                    {
                        log1.WriteLine("API_VS_Table_zsd_lcost_data_srv Executed on : " + DateTime.Now);

                        if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["MisMatchPath"].ToString() + fnamezsd_lcostTemp))
                        {
                            File.Delete(System.Configuration.ConfigurationManager.AppSettings["MisMatchPath"].ToString() + fnamezsd_lcostTemp);
                        }

                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dtzsd_lcost_data_srv);
                            wb.SaveAs(System.Configuration.ConfigurationManager.AppSettings["MisMatchPath"].ToString() + fnamezsd_lcostTemp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("MisMatch Report Error Message : " + ex.Message);
                log1.WriteLine("MisMatch Report Error Message : " + ex.Message);
                log1.WriteLine("===========================================");
                log1.Close();
            }
            log1.WriteLine("===========================================");
            log1.Close();
        }
        public static List<Schdates> schdat(string stdate, string eddate)
        {
            List<Schdates> schdat = new List<Schdates>();

            var FromDate = DateTime.Today.AddDays(-31).ToString("yyyyMMdd");
            var ToDate = DateTime.Today.AddDays(-1).ToString("yyyyMMdd");
            var tmpfrdate = DateTime.Today.AddDays(-31);
            for (int i = 0; i < 4; i++)
            {
                
                Schdates sch = new Schdates();
                if (i == 3)
                {
                    sch.RowNo = i + 1;
                    sch.startdate = tmpfrdate.ToString("yyyyMMdd");
                    sch.enddate = tmpfrdate.AddDays(6).ToString("yyyyMMdd");
                }
                else
                {
                    sch.RowNo = i + 1;
                    sch.startdate = tmpfrdate.ToString("yyyyMMdd");
                    sch.enddate = tmpfrdate.AddDays(7).ToString("yyyyMMdd");
                }
                schdat.Add(sch);
                tmpfrdate = tmpfrdate.AddDays(8);
            }

            //if (schdat.Count == 0)
            //{
            //    Schdates sdat = new Schdates();
            //    sdat.startdate = stdate;
            //    var newStDate = DateTime.ParseExact(stdate,
            //                  "yyyyMMdd",
            //                   CultureInfo.InvariantCulture);

            //    var ToSptDate = newStDate.AddDays(Convert.ToDouble(daySplit) - 1);

            //    var newEdDate = DateTime.ParseExact(eddate,
            //                  "yyyyMMdd",
            //                   CultureInfo.InvariantCulture);

            //    if (ToSptDate < newEdDate)
            //    {

            //    }
            //    //var FromDate = DateTime.Today.AddDays(Convert.ToDouble(noofDays)).ToString("yyyyMMdd");
            //    // sdat.enddate = startDate.
            //}

            return schdat;
        }
    }

    
    
}
