using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Threading.Tasks;
using Kaisokku_Business;
using Kaisokku_Common;
using Kaisokku_Sales.Models;
using System.Net.Mail;
using PagedList;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Mime;
using System.Data;
using ClosedXML.Excel;
using System.Text;
using Rotativa;
using System.Web.Helpers;

using Microsoft.Office.Core;
using System.Drawing;
using System.Threading;
using System.Globalization;
namespace Kaisokku_Sales.Controllers
{
    public class Kaisokku_HomeController : BaseController
    {
        private Kaisokku_BusinessLayer kaisokku_businesslayer;
        // GET: ClintMGT
        public Kaisokku_HomeController()
        {
            kaisokku_businesslayer = new Kaisokku_BusinessLayer(base.ConnectionString);
        }
        public ActionResult Index()
        {

            var PriceInfo = kaisokku_businesslayer.GetPrice();
            ViewData["PriceInfo"] = PriceInfo;
            var ClientInfo = kaisokku_businesslayer.GetClient();
            ViewData["ClientInfo"] = ClientInfo;

            var result = kaisokku_businesslayer.Getcontent();


            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(string));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Description", typeof(string));
            foreach (var str in result)
            {
                DataRow row = table.NewRow();
                row["Id"] = str.Id;
                row["Title"] = str.Title;
                row["Description"] = str.Description;
                table.Rows.Add(row);
            }

            //if(table.Rows.Count >= 1 &&  table.Rows[0]["Title"].ToString() == "Robotic Process Automation")
            //{
            //    ViewBag.FirstH1 = table.Rows[0]["Title"];
            //    ViewBag.Description1 = table.Rows[0]["Description"];
            //}
            //if(table.Rows.Count >= 2  &&  table.Rows[1]["Title"].ToString() == "RPA")
            //{
            //    ViewBag.FirstH2 = table.Rows[1]["Title"];
            //    ViewBag.Description2 = table.Rows[1]["Description"];
            //}
            //if(table.Rows.Count >= 3 &&  table.Rows[2]["Title"].ToString() == "Technology")
            //{
            //    ViewBag.FirstH3 = table.Rows[2]["Title"];
            //    ViewBag.Description3 = table.Rows[2]["Description"];
            //}

            //if(table.Rows.Count >= 4 &&  table.Rows[3]["Title"].ToString() == "Product and Services")
            //{
            //    ViewBag.FirstH3 = table.Rows[3]["Title"];
            //    ViewBag.Description3 = table.Rows[3]["Description"];
            //}


            if (table.Rows.Count >= 1)
            {
                if (table.Rows[0]["Title"].ToString() != "" || table.Rows[0]["Title"].ToString() != null)
                {
                    if (table.Rows[0]["Title"].ToString() == "Robotic Process Automation")
                    {
                        ViewBag.FirstH1 = table.Rows[0]["Title"];
                        ViewBag.Description1 = table.Rows[0]["Description"];
                    }
                }
            }
            if (table.Rows.Count >= 2)
            {
                if (table.Rows[1]["Title"].ToString() != "" || table.Rows[0]["Title"].ToString() != null)
                {

                    if (table.Rows[1]["Title"].ToString() == "RPA")
                    {
                        ViewBag.FirstH2 = table.Rows[1]["Title"];
                        ViewBag.Description2 = table.Rows[1]["Description"];
                    }
                }
            }
            if (table.Rows.Count >= 3)
            {
                if (table.Rows[2]["Title"].ToString() != "" || table.Rows[0]["Title"].ToString() != null)
                {
                    if (table.Rows[2]["Title"].ToString() == "Technology")
                    {
                        ViewBag.FirstH3 = table.Rows[2]["Title"];
                        ViewBag.Description3 = table.Rows[2]["Description"];
                    }
                }
            }

            if (table.Rows.Count >= 4)
            {
                if (table.Rows[3]["Title"].ToString() != "" || table.Rows[0]["Title"].ToString() != null)
                {

                    if (table.Rows[3]["Title"].ToString() == "Product and Services")
                    {
                        ViewBag.FirstH4 = table.Rows[3]["Title"];
                        ViewBag.Description4 = table.Rows[3]["Description"];
                    }
                }
            }


            var videoAllFiles = kaisokku_businesslayer.GetDemovideo();
            ViewData["DemoVideos"] = videoAllFiles.ToList();
            return View();
        }
    }
}