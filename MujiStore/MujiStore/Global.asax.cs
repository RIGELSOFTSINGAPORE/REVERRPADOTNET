using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Threading;
using System.Globalization;

namespace MujiStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            log4net.Config.XmlConfigurator.Configure();
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {

            HttpCookie cookie = HttpContext.Current.Request.Cookies["Language"];
            if (cookie != null && cookie.Value != null)
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookie.Value);
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookie.Value);
            }
            else // By Default
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ja");
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ja");
            }
        }

       
        protected void Session_Start()
        {
            Session["CreateSpecificCulture"] = "ja";
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Session["CreateSpecificCulture"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["CreateSpecificCulture"].ToString());
            string host = Request.Url.Host;
            Session["HostAddress"] = host;
            MujiStore.BLL.CommonLogic.GetSessionDetails();
            HttpContext.Current.Session["DefaultFormatID"] = "-1";
            HttpContext.Current.Session["scrolldata"] = "0"; 
            //GetSessionDetails();
        }
   
          
        public void Session_End()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ja");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ja");
            Session.Clear();
           
        }
    }

  
}
