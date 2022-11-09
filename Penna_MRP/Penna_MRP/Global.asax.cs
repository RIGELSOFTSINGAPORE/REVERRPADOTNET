﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace Penna_Sales
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Database.SetInitializer<Penna_SaleDBContext>(null);
            log4net.Config.XmlConfigurator.Configure();
          
            AuthorizeAttribute authorize = new AuthorizeAttribute();
           
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
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            }
        }
        protected void Session_Start()
        {
            string strIp = GetIp();

            HttpContext.Current.Session["IPAddress"] = strIp;
            //GetSessionDetails();
        }

        public string GetIp()
        {


            string ipaddress;
            ipaddress = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
            {
                ipaddress = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (ipaddress == "::1")
            {
                ipaddress = GetIPAddress();
            }
            return ipaddress;
        }
        public string GetIPAddress()
        {
            string IpAddress = "";
            System.Net.IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            System.Net.IPAddress ipAddress = host.AddressList.Where(ips => ips.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault();
            IpAddress = ipAddress.ToString().Trim();
            return IpAddress;
        }
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket != null && !authTicket.Expired)
                {
                    var roles = authTicket.UserData.Split(',');
                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(new FormsIdentity(authTicket), roles);
                }
            }
        }
        [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
        public class AuthorizeRoleAttribute : AuthorizeAttribute
        {
            public AuthorizeRoleAttribute(params object[] roles)
            {
                if (roles.Any(r => r.GetType().BaseType != typeof(Enum)))
                    throw new ArgumentException("roles");
                this.Roles =Convert.ToString(HttpContext.Current.Session["RoleId"]) ;
            }
        }
    }
}
