using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MujiStore.Models;
using MujiStore.BLL;
using PagedList;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

using System.Text;

namespace MujiStore.Controllers
{
    [SessionExpire]
    [Authorize]
    public class StreamServersLogsController : Controller
    {
        // GET: StreamServersLogsController
                

        private mujiEntities1 db = new mujiEntities1();
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;

        public ActionResult Index(int? page, string Filename, string SearchFromCRTDT, string ToDate,string Fname)
        {

            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            var lan = System.Threading.Thread.CurrentThread.CurrentCulture;
            ViewBag.Lan = lan.Parent.Name;
            int pageSize;

           
        
            ViewBag.SearchID = Fname;
            ViewBag.SearchFDate = SearchFromCRTDT;
            ViewBag.SearchTDate = ToDate;

            if (ViewBag.SearchFDate == null || ViewBag.SearchFDate == "")
            {
                SearchFromCRTDT = DateTime.Now.AddYears(-200).ToString("yyyy/MM/dd");
            }
            else
            {
                SearchFromCRTDT = ViewBag.SearchFDate;
            }
            if (ViewBag.SearchTDate == null || ViewBag.SearchTDate == "")
            {
                ToDate = DateTime.Now.AddYears(100).ToString("yyyy/MM/dd");
            }
            else
            {
                ToDate = ViewBag.SearchTDate;
            }

            try
            {
                var selectList = new List<SSDetails>();

                DataTable MyDT = new DataTable();
                if (Request.Form["submitbutton1"] != null)
                {
                    if(Fname==null || Fname=="0" )
                    {
                        ViewBag.filename = "StreamserverExport";
                    }
                    else 
                    {
         
                        ViewBag.filename = "StreamserverExport";
                    }
                    
                   DataTable DT = (DataTable)Session["dtTest"];
                    ExportCSV(DT);
                    
                }
                else 
                {
                    string querySDtnt = "";
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        querySDtnt = " SELECT SSServer,FolderName, SubnetNumber, ";
                        querySDtnt += " IPAddress,BelongingSubnet,CRTDT,Rtrim(StoreName) as StoreName,Rtrim(StoreGroupName) as StoreGroupName, ";
                        querySDtnt += " CRTCD,FileType,FileName,RecStatus,Remarks,Remarks_ja,UserIPAddress, StoreNumber";
                        querySDtnt += " from tblStreamServerImport  ";
                        querySDtnt += " where streamServerImportID like  '%'";

                        querySDtnt += " and FORMAT(CRTDT, 'yyyy-MM-dd')  between '" + SearchFromCRTDT + "' and '" + ToDate + "'";

                        if (ViewBag.SearchID != null && ViewBag.SearchID != "" && ViewBag.SearchID != string.Empty)
                        {
                            querySDtnt += " and FileName like @SearchID ";
                        }

                        querySDtnt += " ORDER BY streamServerImportID Desc";



                        SqlCommand cmds = new SqlCommand(querySDtnt, con);
                        cmds.Parameters.AddWithValue("@SearchID", "%" + ViewBag.SearchID + "%");
                        cmds.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader rdrs = cmds.ExecuteReader();
                        while (rdrs.Read())
                        {
                            string storenum= (rdrs["StoreNumber"]).ToString();
                            string SubnetNumber= (rdrs["SubnetNumber"]).ToString();
                            var column = rdrs.GetOrdinal("StoreNumber");

                           
                            if (storenum.All(char.IsDigit))
                            {
                                if (!rdrs.IsDBNull(column))
                                {

                                    storenum = (rdrs["StoreNumber"]).ToString();

                                }
                                else
                                {
                                    storenum = "0";
                                }
                                
                            }
                            else
                            {
                                storenum = "0";
                            }
                            if (storenum.All(char.IsDigit))
                            {
                                if ((rdrs["SubnetNumber"]) != System.DBNull.Value)
                                {

                                    SubnetNumber = (rdrs["SubnetNumber"]).ToString();
                                }
                                else
                                {
                                    SubnetNumber = "0";
                                }

                            }
                            else
                            {
                                SubnetNumber = "0";
                            }


                            selectList.Add(new SSDetails
                            {

                                SSServer = rdrs["SSServer"].ToString(),
                                IPAddress = rdrs["IPAddress"].ToString(),
                                SubnetNumber = SubnetNumber,
                                BelongingSubnet = rdrs["BelongingSubnet"].ToString(),
                                CRTDT = Convert.ToDateTime(rdrs["CRTDT"]).ToString("yyyy/MM/dd HH:mm:ss"),
                                CRTDTTIME = Convert.ToDateTime(rdrs["CRTDT"]).ToString("HH:mm:ss"),
                                CRTCD = rdrs["CRTCD"].ToString(),
                                StoreNumber = storenum,
                                FileType = rdrs["FileType"].ToString(),
                                FileName = rdrs["FileName"].ToString(),
                                StoreName = rdrs["StoreName"].ToString(),
                                StoreGroupName = rdrs["StoreGroupName"].ToString(),
                                RecStatus = rdrs["RecStatus"].ToString(),
                                Remarks = rdrs["Remarks"].ToString(),
                                Remarks_ja = rdrs["Remarks_ja"].ToString(),
                                FolderName = rdrs["FolderName"].ToString(),
                                UserIPAddress = rdrs["UserIPAddress"].ToString()

                            });


                        }

                    }
                    MyDT.Clear();

                    if (selectList.Count != 0)
                    {

                        MyDT.Clear();
                        MyDT.Columns.Add("SubnetNumber");
                        MyDT.Columns.Add("BelongingSubnet");
                        MyDT.Columns.Add("StoreName");
                        MyDT.Columns.Add("StoreGroupName");
                        MyDT.Columns.Add("StoreNumber");
                        MyDT.Columns.Add("FolderName");
                        MyDT.Columns.Add("RecStatus");
                        MyDT.Columns.Add("Remarks");
                        MyDT.Columns.Add("FileName");
                        MyDT.Columns.Add("CRTDT");
                        MyDT.Columns.Add("CRTCD");


                        for (int i = 0; i < selectList.Count; i++)
                        {
                            DataRow dr = MyDT.NewRow();
                            dr[0] = selectList[i].SubnetNumber;


                            dr[1] = selectList[i].BelongingSubnet;
                            dr[2] = selectList[i].StoreName;
                            dr[3] = selectList[i].StoreGroupName;
                       
                            dr[4] = selectList[i].StoreNumber;

                            dr[5] = selectList[i].FolderName;
                            
                            if (selectList[i].RecStatus == "I")
                            {
                                dr[6] = MujiStore.Resources.Resource.Insert;
                            }
                            else if (selectList[i].RecStatus == "E")
                            {
                                dr[6] = MujiStore.Resources.Resource.Error;

                            }
                            else if (selectList[i].RecStatus == "W")
                            {
                                dr[6] = MujiStore.Resources.Resource.Warning;

                            }
                            if (ViewBag.Lan=="ja")
                            {
                                dr[7] = selectList[i].Remarks_ja;
                            }
                            else
                            {
                                dr[7] = selectList[i].Remarks;
                            }
                            

                            dr[8] = selectList[i].FileName;
                            dr[9] = selectList[i].CRTDT ;
                            dr[10] = selectList[i].CRTCD;
                            MyDT.Rows.Add(dr);
                        }
                    }
                   
                    Session["dtTest"] = null;
                    Session["dtTest"] = MyDT;


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

                ViewData["videoList"] = selectList.ToPagedList(pageNumber, pageSize);
                return View(selectList.ToList());
            }


            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

        }
        public List<SelectListItem> BindFileDetails()
        {

            var selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem
            {
                Value = "0",
                Text = "All"
            });
            using (SqlConnection con = new SqlConnection(CS))
            {
                string query = "";
                query = "Select distinct FileName from tblStreamServerImport  ";
                SqlCommand cmds = new SqlCommand(query, con);
                cmds.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdrs = cmds.ExecuteReader();
                while (rdrs.Read())
                {
                        selectList.Add(new SelectListItem
                        {
                            Value = rdrs["FileName"].ToString(),
                            Text = rdrs["FileName"].ToString()
                        });
                }
             }
            return selectList;
        }

        [HttpPost]
        
        public ActionResult ExportCSV(DataTable CSV)
        {
            

            string Filename = ViewBag.filename;
            string csv = string.Empty;
            
            foreach (DataColumn column in CSV.Columns)
            {
                //Add the Header row for CSV file.
                csv += column.ColumnName + ',';
            }

            //Add new line.
            csv += "\r\n";

            foreach (DataRow row in CSV.Rows)
            {
                foreach (DataColumn column in CSV.Columns)
                {
                    //Add the Data rows.
                    csv += row[column.ColumnName].ToString().Replace(",", ";") + ',';
                }

                //Add new line.
                csv += "\r\n";
            }

            Response.Clear();
            Response.Buffer = true;
            Response.ContentEncoding = Encoding.UTF8;
            Response.AddHeader("content-disposition", "attachment;filename="+Filename+".csv");
            Response.Charset = "";
            Response.ContentType = "application/text";
            Response.Output.Write(csv," charset = utf - 8");
            Response.Flush();
            Response.End();
            return RedirectToAction("Index");
        }
    }
}