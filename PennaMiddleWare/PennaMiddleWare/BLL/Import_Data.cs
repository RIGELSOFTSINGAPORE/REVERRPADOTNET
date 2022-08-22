using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.IO;
using MySql.Data.MySqlClient;
using PennaMiddleWare.Models;
using System.Net.Http;
using System.Text;
using System.Data;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace PennaMiddleWare.BLL
{
   
    public class Import_Data
    {
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        StreamWriter log1 = System.IO.StreamWriter.Null;

        public void Insert_YREALIZATION(string startDate, string endDate)
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
                log1.WriteLine("===========================================");
                log1.WriteLine("Application From Date  " + startDate);
                log1.WriteLine("Application To Date  " + endDate);
                log1.WriteLine("Executed on : " + DateTime.Now);


                var url = "";
                string query = "";
                int reccount = 0;
                List<ZSD_REAL_DATA_SRV_REAL> lstsrvdeal = new List<ZSD_REAL_DATA_SRV_REAL>();

                var formats = new[] { "ddMMyyyy", "yyyyMMdd", "yyyyMMdd" };


                url = "https://netwaver-dev.pennacement.com:443/sap/opu/odata/sap/ZSD_REAL_DATA_SRV/REALSet?$format=json&$filter=Erdat ge '" + startDate.Trim() + "' and Erdat le '" + endDate.Trim() + "'";
                string userName = "NWGW001";
                string passwd = "Penna@123";

                log1.WriteLine("Insert Tabel : YREALIZATION");

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
                    if (dt.Rows.Count == reccount)
                    {
                        log1.WriteLine("Tabel record Count : " + reccount);
                        log1.WriteLine("Record Mathing");


                    }
                    else
                    {
                        log1.WriteLine("Tabel record Count : " + reccount);
                        log1.WriteLine("Record Insert Failed");
                    }
                }
                else
                {
                    if (Convert.ToInt16(response.StatusCode) == 400)
                    {
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

            }
            catch (Exception ex)
            {
                log1.WriteLine("YREALIZATION Error Message : " + ex.Message);
                log1.WriteLine("===========================================");
                log1.Close();
            }
            log1.Close();
        }

        public void Insert_ZSD_LCOST_DATA_SRV(string startDate, string endDate)
        {
            try
            {
     

                string filename = System.Configuration.ConfigurationManager.AppSettings["LogFile"].ToString();

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

                log1.WriteLine("Insert Tabel : ZSD_LCOST_DATA_SRV");

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
                        log1.WriteLine("Tabel record Count : " + reccount);
                        log1.WriteLine("Record Mathing");


                    }
                    else
                    {
                        log1.WriteLine("Tabel record Count : " + reccount);
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
                log1.WriteLine("===========================================");
                log1.Close();
            }
            log1.WriteLine("===========================================");
            log1.Close();
        }
    }
}