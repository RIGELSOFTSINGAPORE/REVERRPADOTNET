//using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using OfficeOpenXml;
//using OfficeOpenXml.Style;
using Vasthu_Models;
using Vastu_Business;

//using iTextSharp.text.pdf;
//using iTextSharp.text;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
//using HiQPdf;
//using PdfSharp.Charting;
using ClosedXML.Excel;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Drawing;

using System.Configuration;
using System.Threading;
using ClosedXML;

namespace Vastu.Controllers
{
    [SessionExpire]
    [Authorize]
    [VASTUCustomAuthorize(Roles = "1,2")]
    public class VastuReportController : Controller
    {
        private VastuReportBusinessLayer _VastuReportBusinessLayer;
        public VastuReportController()
        {

            _VastuReportBusinessLayer = new VastuReportBusinessLayer();
        }



        public ActionResult Index()
        {
            ViewBag.VastuReport = "VastuReport";
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            List<AreaReport> interior = new List<AreaReport>();
            List<DirectionReport> direction = new List<DirectionReport>();
            List<VasthuReportType> vasthutype = new List<VasthuReportType>();

            try
            {

                interior = _VastuReportBusinessLayer.Interior();
                direction = _VastuReportBusinessLayer.Direction();
                vasthutype = _VastuReportBusinessLayer.VasthuType();

                ViewBag.Interior = interior;
                ViewBag.Direction = direction;
                ViewBag.VasthuType = vasthutype;
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("VastuReport / Index : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                TempData["ErrMsg"] = "error msg";
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
            return View();
        }

        [HttpPost]
        public ActionResult DownLoadReport(InputToReport obj, InputTextToReport obj2, int VasthuType, string EmailId, string ResearcherName)
        {
            try
            {
                Session["VastuReportData"] = null;
                string SessionReportId = Convert.ToString(Session["SessionIdReport"]);
                string IPAddress = Convert.ToString(Session["IPAddress"]);
                List<ShowFinalReport> result = new List<ShowFinalReport>();
                List<GetVastuEmailInformation> getmail = new List<GetVastuEmailInformation>();

               
                string language = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
                int UserID = Convert.ToInt32(Session["USER_ID"].ToString());
                result = _VastuReportBusinessLayer.DownLoadReport(obj, obj2, VasthuType, EmailId, SessionReportId, IPAddress, ResearcherName, language, UserID);
                long VastuReportID = GetVastuReportID.VastuReportID;
                getmail = _VastuReportBusinessLayer.GetEmailInformation(VastuReportID);

                TempData["TempVastuReportData"] = result;
                TempData["TempVastuEmail"] = getmail;
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DownLoadExcel(string lan)
        {
            List<ShowFinalReport> result1 = (List<ShowFinalReport>)TempData["TempVastuReportData"];
            System.Data.DataTable dt = new System.Data.DataTable("Report");
            System.Data.DataTable dttmp = new System.Data.DataTable("Report");
            List<GetVastuEmailInformation> obj = new List<GetVastuEmailInformation>();
            obj = (List<GetVastuEmailInformation>)TempData["TempVastuEmail"];
            string EmailID = Convert.ToString(obj[0].EmailID);
            string Name = Convert.ToString(obj[0].Name);
            DateTime dttime = obj[0].VastuDate;
            try
            {

                dttmp.Columns.AddRange(new DataColumn[16]
                                            {
                                            new DataColumn("SerialNumber",typeof(int)),
                                            new DataColumn("Interior"),
                                            new DataColumn("Direction"),
                                            new DataColumn("Center"),
                                            new DataColumn("North"),
                                            new DataColumn ("NorthEast"),
                                            new DataColumn("East"),
                                            new DataColumn("SouthEast"),
                                            new DataColumn("South"),
                                            new DataColumn("SouthWest"),
                                            new DataColumn("West"),
                                            new DataColumn("NorthWest"),
                                            new DataColumn("Judgement"),
                                            new DataColumn("Points Earned"),
                                            new DataColumn("Master Comments"),
                                            new DataColumn("Researcher Comments")

                                            }
                                            );

                

                foreach (var Results in result1)
                {
                    dttmp.Rows.Add
                        (
                        
                         Results.SerialNo, Results.Area, Results.Direction,
                        Results.Center, Results.North, Results.NorthEast, Results.East,
                        Results.SouthEast, Results.South, Results.SouthWest,
                        Results.West, Results.NorthWest, 
                        Results.Judgement, Results.PointsEarned, Results.MasterComments,
                        Results.ResearcherComments
                        );
                }

                DataView dv = dttmp.DefaultView;
                dv.Sort = "SerialNumber asc";
                dt = dv.ToTable();

                #region ClosedXML_Report
                string fileName = Guid.NewGuid().ToString();

                var MyWorkBook = new XLWorkbook();
                var MyWorkSheet = MyWorkBook.Worksheets.Add("Sheet 1");
                int TotalColumns = dt.Columns.Count;

                //Header:Vasthu Shasthra Report
                var headLine = MyWorkSheet.Range(MyWorkSheet.Cell(1, 1).Address, MyWorkSheet.Cell(1, 16).Address);
                headLine.Style.Font.Bold = true;
                headLine.Style.Font.FontSize = 15;
                headLine.Style.Font.FontColor = XLColor.White;
                headLine.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                headLine.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                headLine.Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent1, 0.25);
                headLine.Style.Border.TopBorder = XLBorderStyleValues.Medium;
                headLine.Style.Border.BottomBorder = XLBorderStyleValues.Medium;
                headLine.Style.Border.LeftBorder = XLBorderStyleValues.Medium;
                headLine.Style.Border.RightBorder = XLBorderStyleValues.Medium;
                headLine.Merge();
                //if(lan == "ja")
                //{
                    headLine.Value = "ヴァストゥシャストラレポート";
                //}
                //else
                //{
                //    headLine.Value = "Vastu Shastra Report";
                //}
                


                //Header:A1
                //var headLine1 = MyWorkSheet.Range(MyWorkSheet.Cell(2, 1).Address, MyWorkSheet.Cell(2, 1).Address);
                //headLine1.Style.Font.Bold = true;
                //headLine1.Style.Font.FontSize = 15;
                //headLine1.Style.Font.FontColor = XLColor.Black;
                //headLine1.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                //headLine1.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ////headLine1.Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent1, 0.25);
                //headLine1.Style.Border.TopBorder = XLBorderStyleValues.Medium;
                //headLine1.Style.Border.BottomBorder = XLBorderStyleValues.Medium;
                //headLine1.Style.Border.LeftBorder = XLBorderStyleValues.Medium;
                //headLine1.Style.Border.RightBorder = XLBorderStyleValues.Medium;



                var headLineUserInformation = MyWorkSheet.Range(MyWorkSheet.Cell(2, 1).Address, MyWorkSheet.Cell(2, 16).Address);
                headLineUserInformation.Style.Font.Bold = true;
                headLineUserInformation.Style.Font.FontSize = 15;
                headLineUserInformation.Style.Font.FontColor = XLColor.Black;
                headLineUserInformation.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                headLineUserInformation.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //headLine1.Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent1, 0.25);
                headLineUserInformation.Style.Border.TopBorder = XLBorderStyleValues.Medium;
                headLineUserInformation.Style.Border.BottomBorder = XLBorderStyleValues.Medium;
                headLineUserInformation.Style.Border.LeftBorder = XLBorderStyleValues.Medium;
                headLineUserInformation.Style.Border.RightBorder = XLBorderStyleValues.Medium;
                headLineUserInformation.Merge();
                //if (lan == "ja")
                //{
                    headLineUserInformation.Value = "名前: " + Name + "      電子メールID: " + EmailID + "    日付: " + dttime.ToString("yyyy/MM/dd HH:mm:ss");
                //}
                //else
                //{
                //    headLineUserInformation.Value = "Name: " + Name + "      EmailID: " + EmailID + "    Date: " + dttime.ToString("yyyy/MM/dd hh:mm:ss");
                //}
                




                ////2nd row heading(merging M to P)
                //var secondRowHeading = MyWorkSheet.Range(MyWorkSheet.Cell(2, 13).Address, MyWorkSheet.Cell(2, 16).Address);
                //secondRowHeading.Style.Font.Bold = true;
                //secondRowHeading.Style.Font.FontSize = 15;
                //secondRowHeading.Style.Font.FontColor = XLColor.Black;
                //secondRowHeading.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                //secondRowHeading.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ////headLine1.Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent1, 0.25);
                //secondRowHeading.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                //secondRowHeading.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                //secondRowHeading.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                //secondRowHeading.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                //secondRowHeading.Merge();


                var headLine1 = MyWorkSheet.Range(MyWorkSheet.Cell(3, 1).Address, MyWorkSheet.Cell(3, 1).Address);
                headLine1.Style.Font.Bold = true;
                headLine1.Style.Font.FontSize = 15;
                headLine1.Style.Font.FontColor = XLColor.Black;
                headLine1.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                headLine1.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //headLine1.Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent1, 0.25);
                headLine1.Style.Border.TopBorder = XLBorderStyleValues.Medium;
                headLine1.Style.Border.BottomBorder = XLBorderStyleValues.Medium;
                headLine1.Style.Border.LeftBorder = XLBorderStyleValues.Medium;
                headLine1.Style.Border.RightBorder = XLBorderStyleValues.Medium;



                //Input
                var headLine2 = MyWorkSheet.Range(MyWorkSheet.Cell(3, 2).Address, MyWorkSheet.Cell(3, 3).Address);
                headLine2.Style.Font.Bold = true;
                headLine2.Style.Font.FontSize = 15;
                headLine2.Style.Font.FontColor = XLColor.Black;
                headLine2.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                headLine2.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                headLine2.Style.Border.TopBorder = XLBorderStyleValues.Medium;
                headLine2.Style.Border.BottomBorder = XLBorderStyleValues.Medium;
                headLine2.Style.Border.LeftBorder = XLBorderStyleValues.Medium;
                headLine2.Style.Border.RightBorder = XLBorderStyleValues.Medium;
                headLine2.Merge();
                //if (lan == "ja")
                //{
                    headLine2.Value = "入力";
                //}
                //else
                //{
                //    headLine2.Value = "Input";
                //}
                

                //Master Data
                var headLine3 = MyWorkSheet.Range(MyWorkSheet.Cell(3, 4).Address, MyWorkSheet.Cell(3, 12).Address);
                headLine3.Style.Font.Bold = true;
                headLine3.Style.Font.FontSize = 15;
                headLine3.Style.Font.FontColor = XLColor.Black;
                headLine3.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                headLine3.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //headLine3.Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent1, 0.25);
                headLine3.Style.Border.TopBorder = XLBorderStyleValues.Medium;
                headLine3.Style.Border.BottomBorder = XLBorderStyleValues.Medium;
                headLine3.Style.Border.LeftBorder = XLBorderStyleValues.Medium;
                headLine3.Style.Border.RightBorder = XLBorderStyleValues.Medium;
                headLine3.Merge();
                //if (lan == "ja")
                //{
                    headLine3.Value = "マスターデータ";
                //}
                //else
                //{
                //    headLine3.Value = "Master Data";
                //}
                

                //Header:M-N
                var headLine4 = MyWorkSheet.Range(MyWorkSheet.Cell(3, 13).Address, MyWorkSheet.Cell(3, 14).Address);
                headLine4.Style.Font.Bold = true;
                headLine4.Style.Font.FontSize = 15;
                headLine4.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                headLine4.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                headLine4.Style.Border.TopBorder = XLBorderStyleValues.Medium;
                headLine4.Style.Border.BottomBorder = XLBorderStyleValues.Medium;
                headLine4.Style.Border.LeftBorder = XLBorderStyleValues.Medium;
                headLine4.Style.Border.RightBorder = XLBorderStyleValues.Medium;
                headLine4.Merge();
                //if (lan == "ja")
                //{
                    headLine4.Value = "判定";
                //}
                //else
                //{
                //    headLine4.Value = "Judgement";
                //}
                


                //Header:O-P
                var headLine5 = MyWorkSheet.Range(MyWorkSheet.Cell(3, 15).Address, MyWorkSheet.Cell(3, 16).Address);
                headLine5.Style.Font.Bold = true;
                headLine5.Style.Font.FontSize = 15;
                headLine5.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                headLine5.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                headLine5.Style.Border.TopBorder = XLBorderStyleValues.Medium;
                headLine5.Style.Border.BottomBorder = XLBorderStyleValues.Medium;
                headLine5.Style.Border.LeftBorder = XLBorderStyleValues.Medium;
                headLine5.Style.Border.RightBorder = XLBorderStyleValues.Medium;
                headLine5.Merge();
                //if (lan == "ja")
                //{
                    headLine5.Value = "コメント";
                //}
                //else
                //{
                //    headLine5.Value = "Comments";
                //}
                

                //--> column settings
                //for (int i = 1; i < dt.Columns.Count + 1; i++)
                //{
                //    String combinedHeaderText = dt.Columns[i - 1].ColumnName.ToString();
                //    string separatedColumnHeader = "";
                //    foreach (char letter in combinedHeaderText)
                //    {
                //        if (Char.IsUpper(letter) && separatedColumnHeader.Length > 0)
                //            separatedColumnHeader += " " + letter;
                //        else
                //            separatedColumnHeader += letter;
                //    }
                //    MyWorkSheet.Cell(4, i).Value = separatedColumnHeader;
                //    MyWorkSheet.Cell(4, i).Style.Alignment.WrapText = true;
                //}
                DataTable dtcol = new DataTable();
                
                //if(lan == "ja")
                //{
                    dtcol.Columns.Add("No.");
                    dtcol.Columns.Add("エリア");
                    dtcol.Columns.Add("方角");
                    dtcol.Columns.Add("北");
                    dtcol.Columns.Add("北東");
                    dtcol.Columns.Add("東");
                    dtcol.Columns.Add("南東");
                    dtcol.Columns.Add("南");
                    dtcol.Columns.Add("南西");
                    dtcol.Columns.Add("西");
                    dtcol.Columns.Add("北西");
                    dtcol.Columns.Add("センター");
                    dtcol.Columns.Add("判定");
                    dtcol.Columns.Add("得点");
                    dtcol.Columns.Add("マスターコメント");
                    dtcol.Columns.Add("研究者コメント");
                    for (int i = 1; i < dt.Columns.Count + 1; i++)
                    {
                        MyWorkSheet.Cell(4, i).Value = dtcol.Columns[i - 1].ColumnName.ToString();
                        MyWorkSheet.Cell(4, i).Style.Alignment.WrapText = true;
                    }
                    

                //}
                //else
                //{
                //    dtcol.Columns.Add("Serial Number");
                //    dtcol.Columns.Add("Interior");
                //    dtcol.Columns.Add("Direction");
                //    dtcol.Columns.Add("C");
                //    dtcol.Columns.Add("N");
                //    dtcol.Columns.Add("NE");
                //    dtcol.Columns.Add("E");
                //    dtcol.Columns.Add("SE");
                //    dtcol.Columns.Add("S");
                //    dtcol.Columns.Add("SW");
                //    dtcol.Columns.Add("W");
                //    dtcol.Columns.Add("NW");
                //    dtcol.Columns.Add("Judgement");
                //    dtcol.Columns.Add("Points Earned");
                //    dtcol.Columns.Add("Master Comments");
                //    dtcol.Columns.Add("Researcher Comments");
                //    for (int i = 1; i < dt.Columns.Count + 1; i++)
                //    {
                //        MyWorkSheet.Cell(4, i).Value = dtcol.Columns[i - 1].ColumnName.ToString();
                //        MyWorkSheet.Cell(4, i).Style.Alignment.WrapText = true;
                //    }
                //}
                //string language = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;

                var columnRange = MyWorkSheet.Range(MyWorkSheet.Cell(4, 1).Address, MyWorkSheet.Cell(4, TotalColumns).Address);
                columnRange.Style.Font.Bold = true;
                columnRange.Style.Font.FontSize = 10;
                columnRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                columnRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                columnRange.Style.Fill.BackgroundColor = XLColor.Yellow;
                columnRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                columnRange.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                columnRange.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                columnRange.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                //<-- column settings
                //Creating excelsheet and adding workbook with name Picture
                // XLWorkbook workbook1 = new XLWorkbook();
                //IXLWorksheet worksheet1 = workbook1.Worksheets.Add("Picture");
                //--> row data & settings



                int rowid = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    rowid += 1;
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if(j == 0)
                        {
                            MyWorkSheet.Cell(i + 5, j + 1).Value = rowid.ToString();
                        }
                        else
                        {
                            MyWorkSheet.Cell(i + 5, j + 1).Value = row[j].ToString();
                        }
                        //MyWorkSheet.Cell(i + 4, j + 1).Value = row[j].ToString();
                        //if (j != 0)
                        //{
                        //    MyWorkSheet.Cell(i + 4, j + 1).Style.NumberFormat.Format = "0.00";
                        //}

                    }
                  
                }
                 //MyWorkSheet.Rows(5, dt.Rows.Count + 4).Height = 20;
                //MyWorkSheet.Columns("A1", "P37").AdjustToContents();
                //MyWorkSheet,.SetRowHeight(5, dt.Rows.Count + 4, 20);
                //MyWorkSheet.Rows(5, dt.Rows.Count + 4).Height = 20;
                //MyWorkSheet.Rows().AdjustToContents();
                // MyWorkSheet.Rows().Cells().Style.Alignment.ShrinkToFit = true; VJ 2020/09/10


                var dataRowRange = MyWorkSheet.Range(MyWorkSheet.Cell(5, 1).Address, MyWorkSheet.Cell(dt.Rows.Count + 4, TotalColumns).Address);
                dataRowRange.Style.Font.Bold = false;
                dataRowRange.Style.Font.FontSize = 10;
                dataRowRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                dataRowRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;


                dataRowRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                dataRowRange.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                dataRowRange.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                dataRowRange.Style.Border.RightBorder = XLBorderStyleValues.Thin;



               // MyWorkSheet.Columns("A:A").AdjustToContents();

                //Input
                var headLine6 = MyWorkSheet.Range(MyWorkSheet.Cell(5, 2).Address, MyWorkSheet.Cell(dt.Rows.Count + 4, 2).Address);
                headLine6.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                headLine6.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                var headLine9 = MyWorkSheet.Range(MyWorkSheet.Cell(5, 3).Address, MyWorkSheet.Cell(dt.Rows.Count + 4, 3).Address);
                headLine9.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                headLine9.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;


                var headLine7 = MyWorkSheet.Range(MyWorkSheet.Cell(5, 15).Address, MyWorkSheet.Cell(dt.Rows.Count + 4, 15).Address);
                headLine7.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                headLine7.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;


                //MyWorkSheet.Columns("B:B").AdjustToContents();
                //MyWorkSheet.Columns("C:C").AdjustToContents();
                //MyWorkSheet.Columns("D:D").AdjustToContents();
                //MyWorkSheet.Columns("E:E").AdjustToContents();
                //MyWorkSheet.Columns("F:F").AdjustToContents();
                //MyWorkSheet.Columns("G:G").AdjustToContents();
                //MyWorkSheet.Columns("H:H").AdjustToContents();
                //MyWorkSheet.Columns("I:I").AdjustToContents();
                //MyWorkSheet.Columns("J:J").AdjustToContents();
                //MyWorkSheet.Columns("K:K").AdjustToContents();
                //MyWorkSheet.Columns("L:L").AdjustToContents();
                //MyWorkSheet.Columns("M:M").AdjustToContents();

                //foreach (DataRow dr in dt.Rows )
                //{
                //    if(Convert.ToString( dr["Judgement"])== "Circle.png")
                //    {
                //        string filenam = Path.Combine(Server.MapPath("~/ScoreImage/"), "Circle.png");
                //        var image = MyWorkSheet.AddPicture(filenam).MoveTo((IXLCell)MyWorkSheet.Cell("M").Address).Scale(0.5); // optional: resize picture

                //        //var image = MyWorkSheet.AddPicture(filenam).MoveTo((IXLCell)MyWorkSheet.Cell(3, 3).Address);
                //        //image.Name = "Logo";
                //        ////Scaling down image as per our cell size
                //        //image.ScaleWidth(.5);
                //        //image.ScaleHeight(.3);

                //    }

                //}

                //MyWorkSheet.Columns("N:N").AdjustToContents();
                MyWorkSheet.Columns("O:O").Width = 60;
                MyWorkSheet.Columns("O:O").Style.Alignment.WrapText = true;


                var headLine8 = MyWorkSheet.Range(MyWorkSheet.Cell(5, 16).Address, MyWorkSheet.Cell(dt.Rows.Count + 4, 16).Address);
                headLine8.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                headLine8.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                MyWorkSheet.Columns("P:P").Width = 60;
                MyWorkSheet.Columns("P:P").Style.Alignment.WrapText = true;

                //VJ 2020 / 09 / 10
                //MyWorkSheet.Rows().Cells().Style.Alignment.ShrinkToFit = true;// .AdjustToContents();
                //MyWorkSheet.Rows(4, 34).AdjustToContents();
                // MyWorkSheet.Rows(4, dt.Rows.Count+4).AdjustToContents();

                //Footer:Total
                var dataRowRange1 = MyWorkSheet.Range(MyWorkSheet.Cell(dt.Rows.Count + 5, 1).Address, MyWorkSheet.Cell(dt.Rows.Count + 5, 12).Address);
                dataRowRange1.Style.Font.Bold = true;
                dataRowRange1.Style.Font.FontSize = 15;
                dataRowRange1.Style.Font.FontColor = XLColor.Black;
                dataRowRange1.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                dataRowRange1.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                dataRowRange1.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                dataRowRange1.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                dataRowRange1.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                dataRowRange1.Style.Border.RightBorder = XLBorderStyleValues.Thin;
               

                //if (lan == "ja")
                //{
                    dataRowRange1.Value = "合計";
                //}
                //else
                //{
                //    dataRowRange1.Value = "Total";
                //}
                dataRowRange1.Merge();


                //Footer:Total Points
                var dataRowRange2 = MyWorkSheet.Range(MyWorkSheet.Cell(dt.Rows.Count + 5, 13).Address, MyWorkSheet.Cell(dt.Rows.Count + 5, 14).Address);
                dataRowRange2.Style.Font.Bold = true;
                dataRowRange2.Style.Font.FontSize = 15;
                dataRowRange2.Style.Font.FontColor = XLColor.Black;
                dataRowRange2.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                dataRowRange2.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                dataRowRange2.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                dataRowRange2.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                dataRowRange2.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                dataRowRange2.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                //dataRowRange2.Style.Alignment.ShrinkToFit = true;
                
                MyWorkSheet.Columns("A:N").Width = 7;
                MyWorkSheet.Columns("A:N").Style.Alignment.WrapText = true;
                //MyWorkSheet.Columns("N:N").Width = 25;
                // Calculate footer totals
                /* ////dataRowRange2.Cells("N34").FormulaR1C1 = "=SUM(N4:N33)";
                 string totalRows = "N" + Convert.ToString(Convert.ToInt32(dt.Rows.Count) + 4);
                 string excluderow = Convert.ToString(Convert.ToInt32(dt.Rows.Count) + 3);
                 string totalsum1 = "=SUM(N4:N" + excluderow + ")";
                 dataRowRange2.Cells(totalRows).FormulaR1C1 = totalsum1;
                 ////var sheetRow = MyWorkSheet.Row(34);
                 var sheetRow = MyWorkSheet.Row(dt.Rows.Count + 4);
                 var sheetcell = sheetRow.Cell(14);
                 string cellvalue = sheetcell.GetValue<string>();
                 ////dataRowRange2.Value = cellvalue + "/300";
                 ///dataRowRange2.Value = cellvalue + "/"+ MaximumPoints+"";
                 /// */
                Decimal MaximumPoints = 0.00m;
                Decimal PointsEarned = 0.00m;
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    var MaxPoint = dt.Rows[i].ItemArray.Skip(3).ToArray().Take(dt.Rows[i].ItemArray.Skip(3).ToArray().Length - 4).ToArray().Max();
                    MaximumPoints = Decimal.Add(Convert.ToDecimal(MaxPoint), MaximumPoints);

                    var GetsPoints = dt.Rows[i].ItemArray.Skip(3).ToArray().Take(dt.Rows[i].ItemArray.Skip(3).ToArray().Length - 2).ToArray()[dt.Rows[i].ItemArray.Skip(3).ToArray().Take(dt.Rows[i].ItemArray.Skip(3).ToArray().Length - 2).ToArray().Length - 1];
                    PointsEarned = Decimal.Add(Convert.ToDecimal(GetsPoints), PointsEarned);
                }
                if(MaximumPoints == 0.00m || MaximumPoints == null)
                {
                    dataRowRange2.Value = "0";
                }
                else
                {
                    //dataRowRange2.Value = Math.Round(PointsEarned,2) + "/" + Math.Round(MaximumPoints,2) + "";
                    dataRowRange2.Value = "'"+ decimal.Truncate(PointsEarned).ToString() + "/" + decimal.Truncate(MaximumPoints).ToString();
                }

                dataRowRange2.Merge();

                //Colspan of O AND P
                var MergeOP = MyWorkSheet.Range(MyWorkSheet.Cell(dt.Rows.Count + 5, 15).Address, MyWorkSheet.Cell(dt.Rows.Count + 5, 16).Address);
                MergeOP.Style.Font.Bold = true;
                MergeOP.Style.Font.FontSize = 15;
                MergeOP.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                MergeOP.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                MergeOP.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                MergeOP.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                MergeOP.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                MergeOP.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                MergeOP.Merge();

                //show average in footer 
                var dataRowRangeAverage = MyWorkSheet.Range(MyWorkSheet.Cell(dt.Rows.Count + 6, 1).Address, MyWorkSheet.Cell(dt.Rows.Count + 6, 12).Address);
                dataRowRangeAverage.Style.Font.Bold = true;
                dataRowRangeAverage.Style.Font.FontSize = 15;
                dataRowRangeAverage.Style.Font.FontColor = XLColor.Black;
                dataRowRangeAverage.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                dataRowRangeAverage.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                dataRowRangeAverage.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                dataRowRangeAverage.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                dataRowRangeAverage.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                dataRowRangeAverage.Style.Border.RightBorder = XLBorderStyleValues.Thin;

                //if (lan == "ja")
                //{
                    dataRowRangeAverage.Value = "平均";
                //}
                //else
                //{
                //    dataRowRangeAverage.Value = "Average";
                //}
                
                dataRowRangeAverage.Merge();


                //Average points in footer
                var dataRowRangeAvg = MyWorkSheet.Range(MyWorkSheet.Cell(dt.Rows.Count + 6, 13).Address, MyWorkSheet.Cell(dt.Rows.Count + 6, 14).Address);
                dataRowRangeAvg.Style.Font.Bold = true;
                dataRowRangeAvg.Style.Font.FontSize = 15;
                dataRowRangeAvg.Style.Font.FontColor = XLColor.Black;
                dataRowRangeAvg.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                dataRowRangeAvg.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                dataRowRangeAvg.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                dataRowRangeAvg.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                dataRowRangeAvg.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                dataRowRangeAvg.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                //dataRowRangeAvg.Style.Alignment.ShrinkToFit = true; VJ 2020/09/10


                if (MaximumPoints == 0)
                {
                    dataRowRangeAvg.Value = "0.00%";
                }
                else
                {
                    Decimal TotalValue = Decimal.Divide(PointsEarned, MaximumPoints);
                    dataRowRangeAvg.Value = Math.Round(TotalValue * 100, 2) + "%";
                }


               

                dataRowRangeAvg.Merge();
                //Colspan of O AND P
                var MergeOPS = MyWorkSheet.Range(MyWorkSheet.Cell(dt.Rows.Count + 6, 15).Address, MyWorkSheet.Cell(dt.Rows.Count + 6, 16).Address);
                MergeOPS.Style.Font.Bold = true;
                MergeOPS.Style.Font.FontSize = 15;
                MergeOPS.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                MergeOPS.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                MergeOPS.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                MergeOPS.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                MergeOPS.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                MergeOPS.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                MergeOPS.Merge();


				MyWorkSheet.Rows(1, 4).Height = 30;
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{

                //    DataRow row = dt.Rows[i];
                //    for (int j = 0; j < dt.Columns.Count; j++)
                //    {

                //        if (dt.Columns[j].ColumnName == "Master Comments")
                //        {
                //            if (row[j].ToString().Length > 50)
                //            {
                //                string test = "";

                //            }
                //            else
                //            {
                //                MyWorkSheet.Row(i + 1).Height = 26;
                //            }
                //        }

                
                MyWorkSheet.Rows(dt.Rows.Count + 5, dt.Rows.Count + 6).Height = 20;
                //MyWorkSheet.Rows()



                 
                //Highlight the selected direction
                //int k = 0;
                //if (lan == "ja")
                //{
                    for (int i = 4; i <= dt.Rows.Count + 4; i++)
                    {
                        var wksrow = MyWorkSheet.Row(i);
                        var selectedcell = wksrow.Cell(3).GetValue<string>();
                        switch (selectedcell.Trim())
                        {
                            case "北東":
                                wksrow.Cell(5).Style.Fill.BackgroundColor = XLColor.Green;
                                break;
                            case "東":
                                wksrow.Cell(6).Style.Fill.BackgroundColor = XLColor.Green;
                                break;
                            case "南東":
                                wksrow.Cell(7).Style.Fill.BackgroundColor = XLColor.Green;
                                break;
                            case "南":
                                wksrow.Cell(8).Style.Fill.BackgroundColor = XLColor.Green;
                                break;
                            case "南西":
                                wksrow.Cell(9).Style.Fill.BackgroundColor = XLColor.Green;
                                break;
                            case "西":
                                wksrow.Cell(10).Style.Fill.BackgroundColor = XLColor.Green;
                                break;
                            case "北西":
                                wksrow.Cell(11).Style.Fill.BackgroundColor = XLColor.Green;
                                break;
                            case "センター":
                                wksrow.Cell(12).Style.Fill.BackgroundColor = XLColor.Green;
                                break;
                            case "北":
                                wksrow.Cell(4).Style.Fill.BackgroundColor = XLColor.Green;
                                break;
                        }
                    }
                //}
                //else
                //{
                //    for (int i = 4; i <= dt.Rows.Count + 4; i++)
                //    {
                //        var wksrow = MyWorkSheet.Row(i);
                //        var selectedcell = wksrow.Cell(3).GetValue<string>();
                //        switch (selectedcell.Trim())
                //        {
                //            case "North":
                //                wksrow.Cell(5).Style.Fill.BackgroundColor = XLColor.Green;
                //                break;
                //            case "NorthEast":
                //                wksrow.Cell(6).Style.Fill.BackgroundColor = XLColor.Green;
                //                break;
                //            case "East":
                //                wksrow.Cell(7).Style.Fill.BackgroundColor = XLColor.Green;
                //                break;
                //            case "SouthEast":
                //                wksrow.Cell(8).Style.Fill.BackgroundColor = XLColor.Green;
                //                break;
                //            case "South":
                //                wksrow.Cell(9).Style.Fill.BackgroundColor = XLColor.Green;
                //                break;
                //            case "SouthWest":
                //                wksrow.Cell(10).Style.Fill.BackgroundColor = XLColor.Green;
                //                break;
                //            case "West":
                //                wksrow.Cell(11).Style.Fill.BackgroundColor = XLColor.Green;
                //                break;
                //            case "NorthWest":
                //                wksrow.Cell(12).Style.Fill.BackgroundColor = XLColor.Green;
                //                break;
                //            case "Center":
                //                wksrow.Cell(4).Style.Fill.BackgroundColor = XLColor.Green;
                //                break;
                //        }
                //    }
                //}
                //IXLRange contents = MyWorkSheet.Range("A1:L50");
                //contents.Style.Alignment.WrapText = true;
                //MyWorkSheet.Rows().AdjustToContents();
                // Prepare the response
                //MyWorkSheet.Rows().AdjustToContents();
                //MyWorkSheet.Columns().AdjustToContents();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=\"" + "Vastu" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xlsx\"");
                //Response.AddHeader("content-disposition", "attachment;filename=\"" + "Vastu" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".pdf\"");
                // Flush the workbook to the Response.OutputStream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    MyWorkBook.SaveAs(memoryStream);
                    memoryStream.WriteTo(Response.OutputStream);
                    memoryStream.Close();
                }
                Response.End();
                return Json(true, JsonRequestBehavior.AllowGet);
                #endregion
            }
            catch (Exception ex)
            {

                LogInfo.LogMsg = string.Format("VastuReport / DownLoadExcel : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }

        [NonAction]
        public ActionResult DownLoadPPT()
        {
            System.Data.DataTable dt = new System.Data.DataTable("Report");
            try
            {
                dt.Columns.AddRange(new DataColumn[16]
                                            {
                                            new DataColumn("SerialNumber"),
                                            new DataColumn("Interior"),
                                            new DataColumn("Direction"),
                                            new DataColumn("North"),
                                            new DataColumn ("NorthEast"),
                                            new DataColumn("East"),
                                            new DataColumn("SouthEast"),
                                            new DataColumn("South"),
                                            new DataColumn("SouthWest"),
                                            new DataColumn("West"),
                                            new DataColumn("NorthWest"),
                                             new DataColumn("Center"),
                                            new DataColumn("Judgement"),
                                            new DataColumn("Points Earned"),
                                            new DataColumn("Master Comments"),
                                            new DataColumn("Researcher Comments")

                                            }
                                            );

                List<ShowFinalReport> result = (List<ShowFinalReport>)TempData["TempVastuReportData"];



                int SerialNo=1; 
                foreach (var Results in result)
                {
                    dt.Rows.Add
                        (
                        SerialNo, Results.Area, Results.Direction,
                        //Results.SerialNo, Results.Area, Results.Direction,
                        Results.North, Results.NorthEast, Results.East,
                        Results.SouthEast, Results.South, Results.SouthWest,
                        Results.West, Results.NorthWest, Results.Center,
                        Results.Judgement, Results.PointsEarned, Results.MasterComments,
                        Results.ResearcherComments
                        );
                    SerialNo++;
                }

                List<GetVastuEmailInformation> obj = new List<GetVastuEmailInformation>();
                obj = (List<GetVastuEmailInformation>)TempData["TempVastuEmail"];
                string EmailID = Convert.ToString(obj[0].EmailID);
                string Name = Convert.ToString(obj[0].Name);
                DateTime dttime = obj[0].VastuDate;



                StringBuilder sb = new StringBuilder();
                sb.Append("<html>");
                sb.Append("<table style='border: 1px solid #ccc;font-size: 17pt;font-family:Arial;border-collapse: collapse;'>");
                sb.Append("<tr><th colspan='16' style='background-color: #B8DBFD;'>Vasthu Shastra Report</th></tr>");

                sb.Append("<tr>");
                sb.Append("<th colspan='16' style='text-align: center; border: 1px solid black;'>" + "Name: " + Name + "      EmailID: " + EmailID + "    Date: " + dttime.ToString("yyyy/MM/dd hh:mm:ss tt") + "</th>");
                sb.Append("</tr>");



                //sb.Append("<tr>" +
                //    "<th></th>" +
                //    "<th colspan='2'>Input</th>" +
                //    "<th colspan='8'>Master Data</th>" +
                //    "<th colspan='4'></th></tr>");

                sb.Append("<tr>" +
                   "<th></th>" +
                    "<th colspan='2'>Input</th>" +
                    "<th colspan='8'>Master Data</th>" +
                    "<th colspan='3'>Judgement</th>" +
                    "<th colspan='2'>Comments</th></tr>");




                sb.Append("<tr>" +
                    "<td style='background-color:yellow; padding-left: 15px;text-align: center; border: 1px solid black;'>SerialNumber</td>" +
                    "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>Interior</td>" +
                    "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>Direction</td>" +
                    "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>North</td>" +
                     "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>NorthEast</td>" +
                    "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>East</td>" +
                     "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>SouthEast</td>" +
                    "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>South</td>" +
                     "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>SouthWest</td>" +
                    "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>West</td>" +
                     "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>NorthWest</td>" +
                    "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>Center</td>" +
                     "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>Judgement</td>" +
                    "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>Points Earned</td>" +
                     "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>Master Comments</td>" +
                    "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>Researcher Comments</td>" +
                    "</tr>");
                foreach (DataRow row in dt.Rows)
                {
                    string DirectionName = string.Empty;

                    if (row["Master Comments"].ToString().Length >= 200)
                    {
                        sb.Append("<tr>");
                    }
                    else
                    {
                        sb.Append("<tr style='line-height: 45px'>");
                    }


                    foreach (DataColumn column in dt.Columns)
                    {

                        if (column.ColumnName == "Interior" || column.ColumnName == "Direction" || column.ColumnName == "Master Comments" || column.ColumnName == "Researcher Comments")
                        {
                            if (column.ColumnName == "Direction")
                            {
                                DirectionName = row[column.ColumnName].ToString();
                            }
                            sb.Append("<td style='padding-left: 6px;text-align: left; border: 1px solid black;'>" + row[column.ColumnName].ToString() + "</td>");
                        }
                        else
                        {
                            if (DirectionName.Trim() == column.ColumnName.ToString().Trim())
                            {
                                sb.Append("<td style='text-align: center; border: 1px solid black; background-color:green;'>" + row[column.ColumnName].ToString() + "</td>");
                            }
                            else
                            {
                                sb.Append("<td style='text-align: center; border: 1px solid black;'>" + row[column.ColumnName].ToString() + "</td>");
                            }


                        }
                    }
                    sb.Append("</tr>");
                }

                int GetColumnUpToJudgement = 0;
                foreach (DataColumn column in dt.Columns)
                {
                    if (column.ColumnName == "Judgement")
                    {
                        GetColumnUpToJudgement++;
                        break;
                    }
                    GetColumnUpToJudgement++;
                }

                Decimal MaximumPoints = 0.00m;
                Decimal PointsEarned = 0.00m;
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    var MaxPoint = dt.Rows[i].ItemArray.Skip(3).ToArray().Take(dt.Rows[i].ItemArray.Skip(3).ToArray().Length - 4).ToArray().Max();
                    MaximumPoints = Decimal.Add(Convert.ToDecimal(MaxPoint), MaximumPoints);

                    var GetsPoints = dt.Rows[i].ItemArray.Skip(3).ToArray().Take(dt.Rows[i].ItemArray.Skip(3).ToArray().Length - 2).ToArray()[dt.Rows[i].ItemArray.Skip(3).ToArray().Take(dt.Rows[i].ItemArray.Skip(3).ToArray().Length - 2).ToArray().Length - 1];
                    PointsEarned = Decimal.Add(Convert.ToDecimal(GetsPoints), PointsEarned);
                }


                sb.Append("<tr style='border: 1px solid black; line-height: 45px'>");
                //sb.Append("<td colspan='" + GetColumnUpToJudgement + "'style='text-align: right; border: 1px solid black;'>Total</td>");
                sb.Append("<td colspan='" + 12 + "'style='text-align: center; border: 1px solid black;'></td>");
                sb.Append("<td style='text-align: center; border: 1px solid black;'>Total</td>");
                sb.Append("<td style='padding-left: 6px;text-align: left; border: 1px solid black;'>" + decimal.Truncate(PointsEarned) + "/" + decimal.Truncate(MaximumPoints) + "" + "</td>");
                //sb.Append("<td style='padding-left: 6px;text-align: left; border: 1px solid black;'></td>");
                //sb.Append("<td style='padding-left: 6px;text-align: left; border: 1px solid black;'></td>");
                sb.Append("</tr>");


                Decimal TotalValue = Decimal.Divide(PointsEarned, MaximumPoints);
                sb.Append("<tr style='border: 1px solid black; line-height: 45px'>");
                //sb.Append("<td colspan='" + GetColumnUpToJudgement + "'style='text-align: right; border: 1px solid black;'>Average</td>");
                sb.Append("<td colspan='" + 12 + "'style='text-align: center; border: 1px solid black;'></td>");
                sb.Append("<td style='text-align: center; border: 1px solid black;'>Average</td>");
                sb.Append("<td style='padding-left: 6px;text-align: left; border: 1px solid black;'>" + Math.Round(TotalValue * 100, 2) + "%" + "" + "</td>");





                //sb.Append("<td style='padding-left: 6px;text-align: left; border: 1px solid black;'></td>");
                //sb.Append("<td style='padding-left: 6px;text-align: left; border: 1px solid black;'></td>");
                sb.Append("</tr>");


                sb.Append("</table>");
                sb.Append("</html>");
                return File(PdfSharpConvert(sb.ToString()), "application/pdf", "Vastu" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".pdf");



            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("VastuReport / DownLoadPPT : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }



        public void ExportReportToExcel()
        {
            ShowExcelReport();
        }


        public void ShowExcelReport()
        {
            System.Data.DataTable dt = new System.Data.DataTable("Report");
            dt.Columns.AddRange(new DataColumn[16]
                                            {
                                            new DataColumn("SerialNumber"),
                                            new DataColumn("Interior"),
                                            new DataColumn("Direction"),
                                            new DataColumn("North"),
                                            new DataColumn ("NorthEast"),
                                            new DataColumn("East"),
                                            new DataColumn("SouthEast"),
                                            new DataColumn("South"),
                                            new DataColumn("SouthWest"),
                                            new DataColumn("West"),
                                            new DataColumn("NorthWest"),
                                             new DataColumn("Center"),
                                            new DataColumn("Judgement"),
                                            new DataColumn("Points Earned"),
                                            new DataColumn("Master Comment"),
                                            new DataColumn("Researcher Comments")

                                            }
                                            );


            List<ShowFinalReport> result = (List<ShowFinalReport>)Session["VastuReportData"];

            foreach (var Results in result)
            {
                dt.Rows.Add
                    (
                    Results.SerialNo, Results.Area, Results.Direction,
                    Results.North, Results.NorthEast, Results.East,
                    Results.SouthEast, Results.South, Results.SouthWest,
                    Results.West, Results.NorthWest, Results.Center,
                    Results.Judgement, Results.PointsEarned, Results.MasterComments,
                    Results.ResearcherComments
                    );
            }



            #region ClosedXML_Report
            string fileName = Guid.NewGuid().ToString();
            try
            {
                var MyWorkBook = new XLWorkbook();
                var MyWorkSheet = MyWorkBook.Worksheets.Add("Sheet 1");
                int TotalColumns = dt.Columns.Count;

                //Header:Vasthu Shasthra Report
                var headLine = MyWorkSheet.Range(MyWorkSheet.Cell(1, 1).Address, MyWorkSheet.Cell(1, 16).Address);
                headLine.Style.Font.Bold = true;
                headLine.Style.Font.FontSize = 15;
                headLine.Style.Font.FontColor = XLColor.White;
                headLine.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                headLine.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                headLine.Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent1, 0.25);
                headLine.Style.Border.TopBorder = XLBorderStyleValues.Medium;
                headLine.Style.Border.BottomBorder = XLBorderStyleValues.Medium;
                headLine.Style.Border.LeftBorder = XLBorderStyleValues.Medium;
                headLine.Style.Border.RightBorder = XLBorderStyleValues.Medium;
                headLine.Merge();
                headLine.Value = "Vastu Shastra Report";


                //Header:A2
                var headLine1 = MyWorkSheet.Range(MyWorkSheet.Cell(2, 1).Address, MyWorkSheet.Cell(2, 1).Address);
                headLine1.Style.Font.Bold = true;
                headLine1.Style.Font.FontSize = 15;
                headLine1.Style.Font.FontColor = XLColor.Black;
                headLine1.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                headLine1.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //headLine1.Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent1, 0.25);
                headLine1.Style.Border.TopBorder = XLBorderStyleValues.Medium;
                headLine1.Style.Border.BottomBorder = XLBorderStyleValues.Medium;
                headLine1.Style.Border.LeftBorder = XLBorderStyleValues.Medium;
                headLine1.Style.Border.RightBorder = XLBorderStyleValues.Medium;


                //Input
                var headLine2 = MyWorkSheet.Range(MyWorkSheet.Cell(2, 2).Address, MyWorkSheet.Cell(2, 3).Address);
                headLine2.Style.Font.Bold = true;
                headLine2.Style.Font.FontSize = 15;
                headLine2.Style.Font.FontColor = XLColor.Black;
                headLine2.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                headLine2.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                // headLine2.Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent1, 0.25);
                headLine2.Style.Border.TopBorder = XLBorderStyleValues.Medium;
                headLine2.Style.Border.BottomBorder = XLBorderStyleValues.Medium;
                headLine2.Style.Border.LeftBorder = XLBorderStyleValues.Medium;
                headLine2.Style.Border.RightBorder = XLBorderStyleValues.Medium;
                headLine2.Merge();
                headLine2.Value = "Input";

                //Master Data
                var headLine3 = MyWorkSheet.Range(MyWorkSheet.Cell(2, 4).Address, MyWorkSheet.Cell(2, 12).Address);
                headLine3.Style.Font.Bold = true;
                headLine3.Style.Font.FontSize = 15;
                headLine3.Style.Font.FontColor = XLColor.Black;
                headLine3.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                headLine3.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //headLine3.Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent1, 0.25);
                headLine3.Style.Border.TopBorder = XLBorderStyleValues.Medium;
                headLine3.Style.Border.BottomBorder = XLBorderStyleValues.Medium;
                headLine3.Style.Border.LeftBorder = XLBorderStyleValues.Medium;
                headLine3.Style.Border.RightBorder = XLBorderStyleValues.Medium;
                headLine3.Merge();
                headLine3.Value = "Master Data";

                //Header:M-N
                var headLine4 = MyWorkSheet.Range(MyWorkSheet.Cell(2, 13).Address, MyWorkSheet.Cell(2, 14).Address);
                headLine4.Style.Font.Bold = true;
                headLine4.Style.Font.FontSize = 15;

                headLine4.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                headLine4.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                headLine4.Style.Border.TopBorder = XLBorderStyleValues.Medium;
                headLine4.Style.Border.BottomBorder = XLBorderStyleValues.Medium;
                headLine4.Style.Border.LeftBorder = XLBorderStyleValues.Medium;
                headLine4.Style.Border.RightBorder = XLBorderStyleValues.Medium;
                headLine4.Merge();
                headLine4.Value = "Judgement";


                //Header:O-P
                var headLine5 = MyWorkSheet.Range(MyWorkSheet.Cell(2, 15).Address, MyWorkSheet.Cell(2, 16).Address);
                headLine5.Style.Font.Bold = true;
                headLine5.Style.Font.FontSize = 15;

                headLine5.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                headLine5.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                headLine5.Style.Border.TopBorder = XLBorderStyleValues.Medium;
                headLine5.Style.Border.BottomBorder = XLBorderStyleValues.Medium;
                headLine5.Style.Border.LeftBorder = XLBorderStyleValues.Medium;
                headLine5.Style.Border.RightBorder = XLBorderStyleValues.Medium;
                headLine5.Merge();



                //--> column settings
                for (int i = 1; i < dt.Columns.Count + 1; i++)
                {
                    String combinedHeaderText = dt.Columns[i - 1].ColumnName.ToString();
                    string separatedColumnHeader = "";
                    foreach (char letter in combinedHeaderText)
                    {
                        if (Char.IsUpper(letter) && separatedColumnHeader.Length > 0)
                            separatedColumnHeader += " " + letter;
                        else
                            separatedColumnHeader += letter;
                    }
                    MyWorkSheet.Cell(3, i).Value = separatedColumnHeader;
                    MyWorkSheet.Cell(3, i).Style.Alignment.WrapText = true;
                }

                var columnRange = MyWorkSheet.Range(MyWorkSheet.Cell(3, 1).Address, MyWorkSheet.Cell(3, TotalColumns).Address);
                columnRange.Style.Font.Bold = true;
                columnRange.Style.Font.FontSize = 10;
                columnRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                columnRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                columnRange.Style.Fill.BackgroundColor = XLColor.Yellow;
                columnRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                columnRange.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                columnRange.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                columnRange.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                //<-- column settings

                //--> row data & settings
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {

                        MyWorkSheet.Cell(i + 4, j + 1).Value = row[j].ToString();
                    }
                }

                var dataRowRange = MyWorkSheet.Range(MyWorkSheet.Cell(4, 1).Address, MyWorkSheet.Cell(dt.Rows.Count + 4, TotalColumns).Address);
                dataRowRange.Style.Font.Bold = false;
                dataRowRange.Style.Font.FontSize = 10;
                dataRowRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                dataRowRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //dataRowRange.Style.Fill.BackgroundColor = XLColor.FromArgb(219, 229, 241);

                dataRowRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                dataRowRange.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                dataRowRange.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                dataRowRange.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                // dataRowRange.Style.Alignment.WrapText = true;
                // dataRowRange.Style.Alignment.ShrinkToFit = true; VJ 2020/09/10
                //MyWorkSheet.Columns().Width = 10;
                //MyWorkSheet.Columns("A:D").Width = 10;


                MyWorkSheet.Columns("A:A").AdjustToContents();


                //MyWorkSheet.Columns("B:B").Width = 22;
                MyWorkSheet.Columns("B:B").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                MyWorkSheet.Columns("B:B").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                MyWorkSheet.Columns("B:B").AdjustToContents();




                //MyWorkSheet.Columns("C:C").Width = 15;
                MyWorkSheet.Columns("C:C").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                MyWorkSheet.Columns("C:C").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                MyWorkSheet.Columns("C:C").AdjustToContents();

                MyWorkSheet.Columns("D:D").AdjustToContents();
                MyWorkSheet.Columns("E:E").AdjustToContents();
                MyWorkSheet.Columns("F:F").AdjustToContents();
                MyWorkSheet.Columns("G:G").AdjustToContents();
                MyWorkSheet.Columns("H:H").AdjustToContents();
                MyWorkSheet.Columns("I:I").AdjustToContents();
                MyWorkSheet.Columns("J:J").AdjustToContents();
                MyWorkSheet.Columns("K:K").AdjustToContents();
                MyWorkSheet.Columns("L:L").AdjustToContents();
                MyWorkSheet.Columns("M:M").AdjustToContents();
                MyWorkSheet.Columns("N:N").AdjustToContents();

                MyWorkSheet.Columns("A:N").Width = 4;
                MyWorkSheet.Columns("A:N").Style.Alignment.WrapText = true;

                MyWorkSheet.Columns("O:O").Width = 60;
                MyWorkSheet.Columns("O:O").Style.Alignment.WrapText = true;
                //MyWorkSheet.Columns("O:O").AdjustToContents();

                //MyWorkSheet.Columns("P:P").Width = 40;
                MyWorkSheet.Columns("P:P").Style.Alignment.WrapText = true;
                MyWorkSheet.Columns("P:P").AdjustToContents();


                MyWorkSheet.Rows(4, 34).AdjustToContents();





                //Footer:Total
                var dataRowRange1 = MyWorkSheet.Range(MyWorkSheet.Cell(34, 1).Address, MyWorkSheet.Cell(34, 13).Address);
                dataRowRange1.Style.Font.Bold = false;
                dataRowRange1.Style.Font.FontSize = 10;
                dataRowRange1.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                dataRowRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //dataRowRange.Style.Fill.BackgroundColor = XLColor.FromArgb(219, 229, 241);

                dataRowRange1.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                dataRowRange1.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                dataRowRange1.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                dataRowRange1.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                // dataRowRange.Style.Alignment.WrapText = true;
                // dataRowRange1.Style.Alignment.ShrinkToFit = true; VJ 2020/09/10
                dataRowRange1.Value = "Total";
                dataRowRange1.Merge();


                //Footer:Total Points

                var dataRowRange2 = MyWorkSheet.Range(MyWorkSheet.Cell(34, 14).Address, MyWorkSheet.Cell(34, 14).Address);
                dataRowRange2.Style.Font.Bold = false;
                dataRowRange2.Style.Font.FontSize = 10;
                dataRowRange2.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                dataRowRange2.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //dataRowRange.Style.Fill.BackgroundColor = XLColor.FromArgb(219, 229, 241);
                dataRowRange2.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                dataRowRange2.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                dataRowRange2.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                dataRowRange2.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                // dataRowRange.Style.Alignment.WrapText = true;
                // dataRowRange2.Style.Alignment.ShrinkToFit = true; VJ 2020/09/10
                string AdjustedPriceFormula = string.Empty;
                dataRowRange2.Cells("N34").FormulaR1C1 = "=SUM(N4:N33)";
                var sheetRow = MyWorkSheet.Row(34);
                var sheetcell = sheetRow.Cell(14);
                string cellvalue = sheetcell.GetValue<string>();
                dataRowRange2.Value = cellvalue + "/300";



                //Highlight the selected direction


                int k = 0;
                for (int i = 4; i <= 33; i++)
                {
                    var wksrow = MyWorkSheet.Row(i);
                    var selectedcell = wksrow.Cell(3).GetValue<string>();
                    switch (selectedcell.Trim())
                    {
                        case "North":
                            wksrow.Cell(4).Style.Fill.BackgroundColor = XLColor.Green;
                            break;
                        case "NorthEast":
                            wksrow.Cell(5).Style.Fill.BackgroundColor = XLColor.Green;
                            break;
                        case "East":
                            wksrow.Cell(6).Style.Fill.BackgroundColor = XLColor.Green;
                            break;
                        case "SouthEast":
                            wksrow.Cell(7).Style.Fill.BackgroundColor = XLColor.Green;
                            break;
                        case "South":
                            wksrow.Cell(8).Style.Fill.BackgroundColor = XLColor.Green;
                            break;
                        case "SouthWest":
                            wksrow.Cell(9).Style.Fill.BackgroundColor = XLColor.Green;
                            break;
                        case "West":
                            wksrow.Cell(10).Style.Fill.BackgroundColor = XLColor.Green;
                            break;
                        case "NorthWest":
                            wksrow.Cell(11).Style.Fill.BackgroundColor = XLColor.Green;
                            break;
                        case "Center":
                            wksrow.Cell(12).Style.Fill.BackgroundColor = XLColor.Green;
                            break;

                    }

                }


                // Prepare the response
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=\"" + "Vasthu_Shasthra_Report" + ".xlsx\"");

                // Flush the workbook to the Response.OutputStream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    MyWorkBook.SaveAs(memoryStream);
                    memoryStream.WriteTo(Response.OutputStream);
                    memoryStream.Close();
                }
                Response.End();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }



        #region PDF0
        public ActionResult ExportReportToPDF()
        {
            //List<VastuReportOutput> result = (List<VastuReportOutput>)Session["VastuReportData"];

            System.Data.DataTable dt = new System.Data.DataTable("Report");
            dt.Columns.AddRange(new DataColumn[16]
                                            {
                                            new DataColumn("SerialNumber"),
                                            new DataColumn("Interior"),
                                            new DataColumn("Direction"),
                                            new DataColumn("North"),
                                            new DataColumn ("NorthEast"),
                                            new DataColumn("East"),
                                            new DataColumn("SouthEast"),
                                            new DataColumn("South"),
                                            new DataColumn("SouthWest"),
                                            new DataColumn("West"),
                                            new DataColumn("NorthWest"),
                                             new DataColumn("Center"),
                                            new DataColumn("Judgement"),
                                            new DataColumn("Points Earned"),
                                            new DataColumn("Master Comment"),
                                            new DataColumn("Researcher Comments")

                                            }
                                            );


            List<ShowFinalReport> result = (List<ShowFinalReport>)Session["VastuReportData"];

            foreach (var Results in result)
            {
                dt.Rows.Add
                    (
                    Results.SerialNo, Results.Area, Results.Direction,
                    Results.North, Results.NorthEast, Results.East,
                    Results.SouthEast, Results.South, Results.SouthWest,
                    Results.West, Results.NorthWest, Results.Center,
                    Results.Judgement, Results.PointsEarned, Results.MasterComments,
                    Results.ResearcherComments
                    );
            }

            StringBuilder sb = new StringBuilder();
            //Table start.
            //sb.Append("<table cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-size: 9pt;font-family:Arial'>");
            sb.Append("<html>");
            sb.Append("<table style='border: 1px solid #ccc;font-size: 17pt;font-family:Arial'>");
            sb.Append("<tr><th colspan='15' style='background-color: #B8DBFD;border: 1px solid #ccc'>Vasthu Shastra Report</th></tr>");

            sb.Append("<tr>" +
                "<th></th>" +
                "<th colspan='2' style='border: 1px solid #ccc'>Input</th>" +
                "<th colspan='8' style='border: 1px solid #ccc'>Master Data</th>" +
                "<th colspan='4' style='border: 1px solid #ccc'></th></tr>");

            sb.Append("<tr>" +
                "<td style='background-color:yellow;width:100px;border: 1px solid #ccc'>SerialNumber</td>" +
                "<td style='background-color:yellow;width:100px;border: 1px solid #ccc'>Interior</td>" +
                "<td style='background-color:yellow;width:100px;border: 1px solid #ccc'>Direction</td>" +
                "<td style='background-color:yellow;width:100px;border: 1px solid #ccc'>North</td>" +
                 "<td style='background-color:yellow;width:100px;border: 1px solid #ccc'>NorthEast</td>" +
                "<td style='background-color:yellow;width:100px;border: 1px solid #ccc'>East</td>" +
                 "<td style='background-color:yellow;width:100px;border: 1px solid #ccc'>SouthEast</td>" +
                "<td style='background-color:yellow;width:100px;border: 1px solid #ccc'>South</td>" +
                 "<td style='background-color:yellow;width:100px;border: 1px solid #ccc'>SouthWest</td>" +
                "<td style='background-color:yellow;width:100px;border: 1px solid #ccc'>West</td>" +
                 "<td style='background-color:yellow;width:100px;border: 1px solid #ccc'>NorthWest</td>" +
                "<td style='background-color:yellow;width:100px;border: 1px solid #ccc'>Center</td>" +
                 "<td style='background-color:yellow;width:100px;border: 1px solid #ccc'>Judgement</td>" +
                "<td style='background-color:yellow;width:100px;border: 1px solid #ccc'>Points Earned</td>" +
                 "<td style='background-color:yellow;width:100px;border: 1px solid #ccc'>Master Comment</td>" +
                "<td style='background-color:yellow;width:100px;border: 1px solid #ccc'>Researcher Comments</td>" +
                "</tr>");

            ////Adding HeaderRow.
            //sb.Append("<tr>");
            //foreach (DataColumn column in dt.Columns)
            //{
            //    sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>" + column.ColumnName + "</th>");
            //}
            //sb.Append("</tr>");


            //Adding DataRow.
            foreach (DataRow row in dt.Rows)
            {
                sb.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    sb.Append("<td style='width:100px;border: 1px solid #ccc'>" + row[column.ColumnName].ToString() + "</td>");
                }
                sb.Append("</tr>");
            }

            //Table end.
            sb.Append("</table>");
            sb.Append("</html>");
            //return File(PdfSharpConvert(sb.ToString()), "application/pdf", "VasthuShastra.pdf");
            //return File(PdfSharpConvert1(sb.ToString()), "application/pdf", "VasthuShastra.pdf");
            return File(PdfSharpConvert(sb.ToString()), "application/pdf", "VasthuShastra.pdf");


        }
        #endregion
        //public static void  PdfSharpConvert(String html)
        //{
        //    XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
        //    PdfDocument document = new PdfDocument();
        //    XFont font = new XFont("Times New Roman", 12, XFontStyle.Regular, options);
        //    string texts;
        //        texts = "PDFsharp is a .NET library モハン  for creating and processing PDF documents 'on the fly'. ";
        //    // Draw text in different languages

        //    for (int idx = 0; idx < texts.Length; idx++)

        //    {

        //        PdfPage page = document.AddPage();

        //        XGraphics gfx = XGraphics.FromPdfPage(page);

        //        XTextFormatter tf = new XTextFormatter(gfx);

        //        tf.Alignment = XParagraphAlignment.Left;

        //        tf.DrawString(texts[idx], font, XBrushes.Black,

        //        new XRect(100, 100, page.Width - 200, 600), XStringFormats.TopLeft);

        //    }

        //    const string filename = "Unicode_tempfile.pdf";

        //    // Save the document...

        //    document.Save(filename);

        //    // Set font encoding to unicode



        //    XFont font = new XFont("Times New Roman", 12, XFontStyle.Regular, options);

        //    for (int idx = 0; idx < texts.Length; idx++)

        //    {

        //        PdfPage page = document.AddPage();

        //        XGraphics gfx = XGraphics.FromPdfPage(page);

        //        XTextFormatter tf = new XTextFormatter(gfx);

        //        tf.Alignment = XParagraphAlignment.Left;



        //        tf.DrawString(texts[idx], font, XBrushes.Black,

        //        new XRect(100, 100, page.Width - 200, 600), XStringFormats.TopLeft);

        //    }


        //}
        #region PDF1
        public static Byte[] PdfSharpConvert(String html)
        {
            Byte[] res = null;
            using (MemoryStream ms = new MemoryStream())
            {
                //Configure page settings
                var configurationOptions = new PdfGenerateConfig();

                //Page is in Landscape mode, other option is Portrait
                configurationOptions.PageOrientation = PdfSharp.PageOrientation.Landscape;

                //Set page type as Letter. Other options are A4 ...
                configurationOptions.PageSize = PdfSharp.PageSize.A2;
                //configurationOptions.PageSize = PdfSharp.PageSize.A2;
                //This is to fit Chrome Auto Margins when printing.Yours may be different
                configurationOptions.MarginBottom = 19;
                configurationOptions.MarginLeft = 2;

                //XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);

                //The actual PDF generation
                var OurPdfPage = PdfGenerator.GeneratePdf(html.ToString(), configurationOptions);
                //var OurPdfPage1 = PdfGenerator.GeneratePdf()
                //var OurPdfPage = PdfGenerator.GeneratePdf(html.ToString(), configurationOptions);
                //var OurPdfPage = PdfGenerator.GeneratePdf("Mohan &#12514;&#12495;&#12531; 1234 モハン", configurationOptions);
                //PdfDocument document = new PdfDocument();

                //Setting Font for our footer
                XFont font = new XFont("Segoe UI,Open Sans, sans-serif, serif", 7);
                //XFont font = new XFont("Arial Unicode MS", 12, XFontStyle.Regular, options);

                XBrush brush = XBrushes.Black;

                //Loop through our generated PDF pages, one by one
                for (int i = 0; i < OurPdfPage.PageCount; i++)
                {
                    //Get each page
                    PdfSharp.Pdf.PdfPage page = OurPdfPage.Pages[i];

                    //Create rectangular area that will hold our footer - play with dimensions according to your page'scontent height and width
                    // XRect layoutRectangle = new XRect(0/*X*/, page.Height - (font.Height + 9)/*Y*/, page.Width/*Width*/, (font.Height - 7)/*Height*/);
                    XRect layoutRectangle = new XRect(0/*X*/, page.Height - (font.Height + 9)/*Y*/, page.Width/*Width*/, (font.Height - 7)/*Height*/);

                    //Draw the footer on each page
                    using (XGraphics gfx = XGraphics.FromPdfPage(page))
                    {
                        gfx.DrawString(
                            "Page " + (i + 1) + " of " + OurPdfPage.PageCount,
                            font,
                            brush,
                            layoutRectangle,
                            XStringFormats.Center);
                    }
                }

                OurPdfPage.Save(ms);
                res = ms.ToArray();
            }
            return res;
        }
        #endregion

        #region PDF2
        public static Byte[] PdfSharpConvert1(String html)
        {
            Byte[] res = null;
            Bitmap bitmap = new Bitmap(790, 1800);
            Graphics g = Graphics.FromImage(bitmap);
            XGraphics xg = XGraphics.FromGraphics(g, new XSize(bitmap.Width, bitmap.Height));
            TheArtOfDev.HtmlRenderer.PdfSharp.HtmlContainer c = new TheArtOfDev.HtmlRenderer.PdfSharp.HtmlContainer();
            c.SetHtml(html);

            PdfDocument pdf = new PdfDocument();
            PdfPage page = new PdfPage();
            XImage img = XImage.FromGdiPlusImage(bitmap);
            pdf.Pages.Add(page);
            XGraphics xgr = XGraphics.FromPdfPage(pdf.Pages[0]);
            c.PerformLayout(xgr);
            c.PerformPaint(xgr);
            xgr.DrawImage(img, 0, 0);

            using (MemoryStream ms = new MemoryStream())
            {
                pdf.Save(ms);
                res = ms.ToArray();
            }
            return res;
        }
        #endregion


        #region PDF3
        public static Byte[] PdfSharpConvert3(string htmls)
        {
            //create a pdf document
            byte[] bin = null;
            using (PdfDocument doc = new PdfDocument())
            {
                doc.Info.Title = "StackOverflow Demo PDF";

                //add a page
                PdfPage page = doc.AddPage();
                page.Size = PageSize.A4;

                //fonts and styles
                XFont font = new XFont("Arial", 10, XFontStyle.Regular);
                XSolidBrush brush = new XSolidBrush(XColor.FromArgb(0, 0, 0));

                using (XGraphics gfx = XGraphics.FromPdfPage(page))
                {
                    //write a normal string
                    gfx.DrawString("A normal string written to the PDF.", font, brush, new XRect(15, 15, page.Width, page.Height), XStringFormats.TopLeft);

                    //write the html string to the pdf
                    using (var container = new HtmlContainer())
                    {
                        var pageSize = new XSize(page.Width, page.Height);

                        container.Location = new XPoint(15, 45);
                        container.MaxSize = pageSize;
                        //container.PageSize = pageSize;
                        container.SetHtml(htmls);

                        using (var measure = XGraphics.CreateMeasureContext(pageSize, XGraphicsUnit.Point, XPageDirection.Downwards))
                        {
                            container.PerformLayout(measure);
                        }

                        gfx.IntersectClip(new XRect(0, 0, page.Width, page.Height));

                        container.PerformPaint(gfx);
                    }
                }

                //write the pdf to a byte array to serve as download, attach to an email etc.

                using (MemoryStream stream = new MemoryStream())
                {
                    doc.Save(stream, false);
                    bin = stream.ToArray();
                }
            }
            return bin;
        }
        #endregion


        #region PDF4
        public static Byte[] PdfSharpConvert4(String html)
        {
            Byte[] res = null;
            using (MemoryStream ms = new MemoryStream())
            {

                var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                htmlToPdf.PageWidth = 1000.0f;



                htmlToPdf.Orientation = (NReco.PdfGenerator.PageOrientation)PageOrientation.Landscape;
                htmlToPdf.Size = (NReco.PdfGenerator.PageSize)PageSize.A4;


                res = htmlToPdf.GeneratePdf(html);

            }
            return res;
        }
        #endregion




        #region S_Report
        public ActionResult DownLoadReport_His(int? id, int? exp)
        {
            try
            {
                string lan = "en";
                Session["VastuReportData"] = null;
                string SessionReportId = Convert.ToString(Session["SessionIdReport"]);
                string IPAddress = Convert.ToString(Session["IPAddress"]);
                //List<VastuReportOutput> result = new List<VastuReportOutput>();
                List<ShowFinalReport> result = new List<ShowFinalReport>();
                List<GetVastuEmailInformation> getmail = new List<GetVastuEmailInformation>();
                int ID = Convert.ToInt16(id);
                int EXP = Convert.ToInt16(exp);
                result = _VastuReportBusinessLayer.DownLoadReport_His(ID, lan);


                //long VastuReportID = GetVastuReportID.VastuReportID;
                getmail = _VastuReportBusinessLayer.GetEmailInformation(ID);
                TempData["TempVastuEmail"] = getmail;
                TempData["TempVastuReportData"] = result;
                if (exp == 1)
                { 

                    DownLoadExcel(lan);

                   
                }
                if (exp == 2)
                {
                    System.Data.DataTable dt = new System.Data.DataTable("Report");
                    try
                    {
                        dt.Columns.AddRange(new DataColumn[16]
                                                    {
                                            new DataColumn("SerialNumber"),
                                            new DataColumn("Interior"),
                                            new DataColumn("Direction"),
                                            new DataColumn("North"),
                                            new DataColumn ("NorthEast"),
                                            new DataColumn("East"),
                                            new DataColumn("SouthEast"),
                                            new DataColumn("South"),
                                            new DataColumn("SouthWest"),
                                            new DataColumn("West"),
                                            new DataColumn("NorthWest"),
                                             new DataColumn("Center"),
                                            new DataColumn("Judgement"),
                                            new DataColumn("Points Earned"),
                                            new DataColumn("Master Comments"),
                                            new DataColumn("Researcher Comments")

                                                    }
                                                    );

                        //  List<ShowFinalReport> result = (List<ShowFinalReport>)TempData["TempVastuReportData="];

                        int SerialNo = 1;
                        foreach (var Results in result)
                        {
                            dt.Rows.Add
                                (
                               //Results.SerialNo, Results.Area, Results.Direction,
                               SerialNo, Results.Area, Results.Direction,
                                Results.North, Results.NorthEast, Results.East,
                                Results.SouthEast, Results.South, Results.SouthWest,
                                Results.West, Results.NorthWest, Results.Center,
                                Results.Judgement, Results.PointsEarned, Results.MasterComments,
                                Results.ResearcherComments
                                );
                            SerialNo++;
                        }
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<html><meta charset='ISO - 8859 - 1'>");
                        sb.Append("<table style='border: 1px solid #ccc;font-size: 17pt;font-family:Arial;border-collapse: collapse;'>");
                        sb.Append("<tr><th colspan='16' style='background-color: #B8DBFD;'>Vasthu Shastra Report</th></tr>");

                        //sb.Append("<tr>" +
                        //    "<th></th>" +
                        //    "<th colspan='2'>Input</th>" +
                        //    "<th colspan='8'>Master Data</th>" +
                        //    "<th colspan='4'></th></tr>");

                        sb.Append("<tr>" +
                   "<th></th>" +
                    "<th colspan='2'>Input</th>" +
                    "<th colspan='8'>Master Data</th>" +
                    "<th colspan='3'>Judgement</th>" +
                    "<th colspan='2'>Comments</th></tr>");


                        sb.Append("<tr>" +
                            "<td style='background-color:yellow; padding-left: 15px;text-align: center; border: 1px solid black;'>SerialNumber</td>" +
                            "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>Interior</td>" +
                            "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>Direction</td>" +
                            "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>North</td>" +
                             "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>NorthEast</td>" +
                            "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>East</td>" +
                             "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>SouthEast</td>" +
                            "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>South</td>" +
                             "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>SouthWest</td>" +
                            "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>West</td>" +
                             "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>NorthWest</td>" +
                            "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>Center</td>" +
                             "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>Judgement</td>" +
                            "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>Points Earned</td>" +
                             "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>Master Comments</td>" +
                            "<td style='background-color:yellow;text-align: center;border: 1px solid black;'>Researcher Comments</td>" +
                            "</tr>");
                        foreach (DataRow row in dt.Rows)
                        {
                            string DirectionName = string.Empty;


                            if (row["Master Comments"].ToString().Length >= 200)
                            {
                                sb.Append("<tr>");
                            }
                            else
                            {
                                sb.Append("<tr style='line-height: 45px'>");
                            }

                            foreach (DataColumn column in dt.Columns)
                            {
                                if (column.ColumnName == "Interior" || column.ColumnName == "Direction" || column.ColumnName == "Master Comments" || column.ColumnName == "Researcher Comments")
                                {
                                    if (column.ColumnName == "Direction")
                                    {
                                        DirectionName = row[column.ColumnName].ToString();
                                        //DirectionName = "Mohan";
                                    }
                                    //sb.Append("<td style='padding-left: 6px;text-align: left; border: 1px solid black;'>" + row[column.ColumnName].ToString() + "</td>");
                                    //sb.Append("<td style='padding-left: 6px;text-align: left; border: 1px solid black;'> Mohan &#12514;&#12495;&#12531; 1234</td>");
                                    sb.Append("<td style='padding-left: 6px;text-align: left; border: 1px solid black;'>" + row[column.ColumnName].ToString() + "</td>");
                                }
                                else
                                {
                                    if (DirectionName.Trim() == column.ColumnName.ToString().Trim())
                                    {
                                        sb.Append("<td style='text-align: center; border: 1px solid black; background-color:green;'>" + row[column.ColumnName].ToString() + "</td>");
                                    }
                                    else
                                    {
                                        sb.Append("<td style='text-align: center; border: 1px solid black;'>" + row[column.ColumnName].ToString() + "</td>");
                                    }


                                }
                            }
                            sb.Append("</tr>");
                        }

                        int GetColumnUpToJudgement = 0;
                        foreach (DataColumn column in dt.Columns)
                        {
                            if (column.ColumnName == "Judgement")
                            {
                                GetColumnUpToJudgement++;
                                break;
                            }
                            GetColumnUpToJudgement++;
                        }

                        Decimal MaximumPoints = 0.00m;
                        Decimal PointsEarned = 0.00m;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            var MaxPoint = dt.Rows[i].ItemArray.Skip(3).ToArray().Take(dt.Rows[i].ItemArray.Skip(3).ToArray().Length - 4).ToArray().Max();
                            MaximumPoints = Decimal.Add(Convert.ToDecimal(MaxPoint), MaximumPoints);

                            var GetsPoints = dt.Rows[i].ItemArray.Skip(3).ToArray().Take(dt.Rows[i].ItemArray.Skip(3).ToArray().Length - 2).ToArray()[dt.Rows[i].ItemArray.Skip(3).ToArray().Take(dt.Rows[i].ItemArray.Skip(3).ToArray().Length - 2).ToArray().Length - 1];
                            PointsEarned = Decimal.Add(Convert.ToDecimal(GetsPoints), PointsEarned);
                        }

                        sb.Append("<tr style='border: 1px solid black; line-height: 45px'>");
                        //sb.Append("<td colspan='" + GetColumnUpToJudgement + "'style='text-align: right; border: 1px solid black;'>Total</td>");
                        sb.Append("<td colspan='" + 12 + "'style='text-align: center; border: 1px solid black;'></td>");
                        sb.Append("<td style='text-align: center; border: 1px solid black;'>Total</td>");
                        sb.Append("<td style='padding-left: 6px;text-align: left; border: 1px solid black;'>" + decimal.Truncate(PointsEarned) + "/" + decimal.Truncate(MaximumPoints) + "" + "</td>");
                        //sb.Append("<td style='padding-left: 6px;text-align: left; border: 1px solid black;'></td>");
                        //sb.Append("<td style='padding-left: 6px;text-align: left; border: 1px solid black;'></td>");
                        sb.Append("</tr>");


                        Decimal TotalValue = Decimal.Divide(PointsEarned, MaximumPoints);
                        sb.Append("<tr style='border: 1px solid black; line-height: 45px'>");
                        //sb.Append("<td colspan='" + GetColumnUpToJudgement + "'style='text-align: right; border: 1px solid black;'>Average</td>");
                        sb.Append("<td colspan='" + 12 + "'style='text-align: center; border: 1px solid black;'></td>");
                        sb.Append("<td style='text-align: center; border: 1px solid black;'>Average</td>");
                        sb.Append("<td style='padding-left: 6px;text-align: left; border: 1px solid black;'>" + Math.Round(TotalValue * 100, 2) + "%" + "" + "</td>");





                        //sb.Append("<td style='padding-left: 6px;text-align: left; border: 1px solid black;'></td>");
                        //sb.Append("<td style='padding-left: 6px;text-align: left; border: 1px solid black;'></td>");
                        sb.Append("</tr>");


                        sb.Append("</table>");
                        sb.Append("</html>");
                        return File(PdfSharpConvert(sb.ToString()), "application/pdf", "Vastu" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".pdf");

                    }
                    catch (Exception ex)
                    {
                        LogInfo.LogMsg = string.Format("VastuReport / DownLoadPPT : {0} Message: {1} ", "", ex.Message);
                        Log.Error(LogInfo.LogMsg, ex);
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                }

                return Json(true, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        //public void ExportListToTable()
        //{
        //    List<VastuReportOutput> result = (List<VastuReportOutput>)Session["VastuReportData"];

        //    System.Data.DataTable dt = new System.Data.DataTable("Report");
        //    dt.Columns.AddRange(new DataColumn[5] { new DataColumn("RowNumber"),
        //                                    new DataColumn("Interior"),
        //                                    new DataColumn("Direction"),
        //                                    new DataColumn ("Judgment"),
        //                                    new DataColumn("Comment") });
        //    foreach (var Results in result)
        //    {
        //        dt.Rows.Add(Results.RowNumber, Results.Interior, Results.Direction, Results.Judgment, Results.Comment);
        //    }

        //    #region ClosedXML_Report
        //    string fileName = Guid.NewGuid().ToString();
        //    String reportHeader = "Vastu Shastra Report.";
        //    try
        //    {

        //        var MyWorkBook = new XLWorkbook();
        //        var MyWorkSheet = MyWorkBook.Worksheets.Add("Sheet 1");
        //        int TotalColumns = dt.Columns.Count;

        //        //-->headline
        //        //first row is intentionaly left blank.
        //        var headLine = MyWorkSheet.Range(MyWorkSheet.Cell(2, 1).Address, MyWorkSheet.Cell(2, TotalColumns).Address);
        //        headLine.Style.Font.Bold = true;
        //        headLine.Style.Font.FontSize = 15;
        //        headLine.Style.Font.FontColor = XLColor.White;
        //        headLine.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        //        headLine.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        //        headLine.Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent1, 0.25);
        //        headLine.Style.Border.TopBorder = XLBorderStyleValues.Medium;
        //        headLine.Style.Border.BottomBorder = XLBorderStyleValues.Medium;
        //        headLine.Style.Border.LeftBorder = XLBorderStyleValues.Medium;
        //        headLine.Style.Border.RightBorder = XLBorderStyleValues.Medium;

        //        headLine.Merge();
        //        headLine.Value = reportHeader;
        //        //<-- headline

        //        //--> column settings
        //        for (int i = 1; i < dt.Columns.Count + 1; i++)
        //        {
        //            String combinedHeaderText = dt.Columns[i - 1].ColumnName.ToString();
        //            string separatedColumnHeader = "";
        //            foreach (char letter in combinedHeaderText)
        //            {
        //                if (Char.IsUpper(letter) && separatedColumnHeader.Length > 0)
        //                    separatedColumnHeader += " " + letter;
        //                else
        //                    separatedColumnHeader += letter;
        //            }
        //            MyWorkSheet.Cell(4, i).Value = separatedColumnHeader;
        //            MyWorkSheet.Cell(4, i).Style.Alignment.WrapText = true;
        //        }

        //        var columnRange = MyWorkSheet.Range(MyWorkSheet.Cell(4, 1).Address, MyWorkSheet.Cell(4, TotalColumns).Address);
        //        columnRange.Style.Font.Bold = true;
        //        columnRange.Style.Font.FontSize = 10;
        //        columnRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        //        columnRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        //        columnRange.Style.Fill.BackgroundColor = XLColor.Yellow;
        //        columnRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
        //        columnRange.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
        //        columnRange.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
        //        columnRange.Style.Border.RightBorder = XLBorderStyleValues.Thin;
        //        //<-- column settings

        //        //--> row data & settings
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            DataRow row = dt.Rows[i];
        //            for (int j = 0; j < dt.Columns.Count; j++)
        //            {
        //                MyWorkSheet.Cell(i + 5, j + 1).Value = row[j].ToString();
        //            }
        //        }

        //        var dataRowRange = MyWorkSheet.Range(MyWorkSheet.Cell(5, 1).Address, MyWorkSheet.Cell(dt.Rows.Count + 4, TotalColumns).Address);
        //        dataRowRange.Style.Font.Bold = false;
        //        dataRowRange.Style.Font.FontSize = 10;
        //        dataRowRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        //        dataRowRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        //        //dataRowRange.Style.Fill.BackgroundColor = XLColor.FromArgb(219, 229, 241);

        //        dataRowRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
        //        dataRowRange.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
        //        dataRowRange.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
        //        dataRowRange.Style.Border.RightBorder = XLBorderStyleValues.Thin;
        //        // dataRowRange.Style.Alignment.WrapText = true;
        //        dataRowRange.Style.Alignment.ShrinkToFit = true;
        //        //MyWorkSheet.Columns().Width = 10;
        //        MyWorkSheet.Columns("A:D").Width = 10;
        //        MyWorkSheet.Columns("E:E").Width = 80;
        //        MyWorkSheet.Columns("E:E").Style.Alignment.WrapText = true;
        //        // MyWorkSheet.Columns().AdjustToContents();
        //        // MyWorkSheet.Rows().AdjustToContents();
        //        //<-- row data & settings

        //        // Prepare the response
        //        Response.Clear();
        //        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //        Response.AddHeader("content-disposition", "attachment;filename=\"" + reportHeader + ".xlsx\"");

        //        // Flush the workbook to the Response.OutputStream
        //        using (MemoryStream memoryStream = new MemoryStream())
        //        {
        //            MyWorkBook.SaveAs(memoryStream);
        //            memoryStream.WriteTo(Response.OutputStream);
        //            memoryStream.Close();
        //        }
        //        Response.End();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    #endregion
        //}







        //public void ExportListToTable()
        //{
        //    List<VastuReportOutput> result = (List<VastuReportOutput>)Session["VastuReportData"];

        //    System.Data.DataTable dt = new System.Data.DataTable("Report");
        //    dt.Columns.AddRange(new DataColumn[5] { new DataColumn("RowNumber"),
        //                                    new DataColumn("Interior"),
        //                                    new DataColumn("Direction"),
        //                                    new DataColumn ("Judgment"),
        //                                    new DataColumn("Comment") });
        //    foreach (var Results in result)
        //    {
        //        dt.Rows.Add(Results.RowNumber, Results.Interior, Results.Direction, Results.Judgment, Results.Comment);
        //    }

        //    #region ClosedXML_Report
        //    string fileName = Guid.NewGuid().ToString();
        //    String reportHeader = "Vastu Shastra Report.";
        //    try
        //    {

        //        var MyWorkBook = new XLWorkbook();
        //        var MyWorkSheet = MyWorkBook.Worksheets.Add("Sheet 1");
        //        int TotalColumns = dt.Columns.Count;

        //        //-->headline
        //        //first row is intentionaly left blank.
        //        var headLine = MyWorkSheet.Range(MyWorkSheet.Cell(2, 1).Address, MyWorkSheet.Cell(2, TotalColumns).Address);
        //        headLine.Style.Font.Bold = true;
        //        headLine.Style.Font.FontSize = 15;
        //        headLine.Style.Font.FontColor = XLColor.White;
        //        headLine.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        //        headLine.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        //        headLine.Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent1, 0.25);
        //        headLine.Style.Border.TopBorder = XLBorderStyleValues.Medium;
        //        headLine.Style.Border.BottomBorder = XLBorderStyleValues.Medium;
        //        headLine.Style.Border.LeftBorder = XLBorderStyleValues.Medium;
        //        headLine.Style.Border.RightBorder = XLBorderStyleValues.Medium;

        //        headLine.Merge();
        //        headLine.Value = reportHeader;
        //        //<-- headline

        //        //--> column settings
        //        for (int i = 1; i < dt.Columns.Count + 1; i++)
        //        {
        //            String combinedHeaderText = dt.Columns[i - 1].ColumnName.ToString();
        //            string separatedColumnHeader = "";
        //            foreach (char letter in combinedHeaderText)
        //            {
        //                if (Char.IsUpper(letter) && separatedColumnHeader.Length > 0)
        //                    separatedColumnHeader += " " + letter;
        //                else
        //                    separatedColumnHeader += letter;
        //            }
        //            MyWorkSheet.Cell(4, i).Value = separatedColumnHeader;
        //            MyWorkSheet.Cell(4, i).Style.Alignment.WrapText = true;
        //        }

        //        var columnRange = MyWorkSheet.Range(MyWorkSheet.Cell(4, 1).Address, MyWorkSheet.Cell(4, TotalColumns).Address);
        //        columnRange.Style.Font.Bold = true;
        //        columnRange.Style.Font.FontSize = 10;
        //        columnRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        //        columnRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        //        columnRange.Style.Fill.BackgroundColor = XLColor.Yellow;
        //        columnRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
        //        columnRange.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
        //        columnRange.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
        //        columnRange.Style.Border.RightBorder = XLBorderStyleValues.Thin;
        //        //<-- column settings

        //        //--> row data & settings
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            DataRow row = dt.Rows[i];
        //            for (int j = 0; j < dt.Columns.Count; j++)
        //            {
        //                MyWorkSheet.Cell(i + 5, j + 1).Value = row[j].ToString();
        //            }
        //        }

        //        var dataRowRange = MyWorkSheet.Range(MyWorkSheet.Cell(5, 1).Address, MyWorkSheet.Cell(dt.Rows.Count + 4, TotalColumns).Address);
        //        dataRowRange.Style.Font.Bold = false;
        //        dataRowRange.Style.Font.FontSize = 10;
        //        dataRowRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        //        dataRowRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        //        //dataRowRange.Style.Fill.BackgroundColor = XLColor.FromArgb(219, 229, 241);

        //        dataRowRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
        //        dataRowRange.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
        //        dataRowRange.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
        //        dataRowRange.Style.Border.RightBorder = XLBorderStyleValues.Thin;
        //        // dataRowRange.Style.Alignment.WrapText = true;
        //        dataRowRange.Style.Alignment.ShrinkToFit = true;
        //        //MyWorkSheet.Columns().Width = 10;
        //        MyWorkSheet.Columns("A:D").Width = 10;
        //        MyWorkSheet.Columns("E:E").Width = 80;
        //        MyWorkSheet.Columns("E:E").Style.Alignment.WrapText = true;
        //        // MyWorkSheet.Columns().AdjustToContents();
        //        // MyWorkSheet.Rows().AdjustToContents();
        //        //<-- row data & settings

        //        // Prepare the response
        //        Response.Clear();
        //        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //        Response.AddHeader("content-disposition", "attachment;filename=\"" + reportHeader + ".xlsx\"");

        //        // Flush the workbook to the Response.OutputStream
        //        using (MemoryStream memoryStream = new MemoryStream())
        //        {
        //            MyWorkBook.SaveAs(memoryStream);
        //            memoryStream.WriteTo(Response.OutputStream);
        //            memoryStream.Close();
        //        }
        //        Response.End();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    #endregion
        //}



    }
}


