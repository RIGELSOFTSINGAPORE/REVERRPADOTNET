using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Vastu
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
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
            string strIp = System.Web.HttpContext.Current.Request.UserHostAddress;
            if (strIp == "::1")
            {
                string IpAddress = "";
                System.Net.IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                System.Net.IPAddress ipAddress = host.AddressList.Where(ips => ips.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault();
                IpAddress = ipAddress.ToString().Trim();
                strIp = IpAddress;
            }
            Session["IPAddress"] = strIp;
            Session["SessionIdReport"] = Guid.NewGuid().ToString().ToUpper();
            HttpCookie cookie = HttpContext.Current.Request.Cookies["Language"];
            Session["Lan"] = cookie;
        }
        public void Session_End()
        {
            Session.Clear();
            
        }
    }
}
