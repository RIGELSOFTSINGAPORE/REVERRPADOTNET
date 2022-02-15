using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Sockets;
using System.Web.Mvc;
using MujiStore.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using MujiStore.BLL;


namespace MujiStore.BLL
{
    public class AuthorizeIPAddressAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        string IpFilterStatus = System.Configuration.ConfigurationManager.AppSettings["IpFilter"];//ConfigurationManager.ConnectionStrings["IpFilter"].ConnectionString;
        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext context)
        {
            if (IpFilterStatus == "true")
            {
               
                string ipAddress = System.Web.HttpContext.Current.Request.UserHostAddress;
                if (ipAddress == "::1")
                {
                    MujiStore.BLL.IPAddressDtl Ipadd = new BLL.IPAddressDtl();
                    ipAddress = Ipadd.GetIPAddress();
                }
                Boolean blGip = true;
                if (!IsIpAddressAllowed(ipAddress.ToString().Trim()))
                {
                    blGip = false;
                    context.Result = new System.Web.Mvc.HttpStatusCodeResult(403, MujiStore.Resources.Resource.Error403Msg);
                    var viewResult = new ViewResult();
                    viewResult.ViewName = "~/Views/Shared/_Unauthorized.cshtml";
                    context.HttpContext.Response.StatusCode = 403;
                    context.Result = viewResult;
                }
            
            }
        }
        private bool IsIpAddressAllowed(string IpAddress)
        {
            bool IPAllowed = false;
            String SubnetID = HttpContext.Current.Session["SubnetID"].ToString();
            if (SubnetID != "-1")
            {
                IPAllowed =  true;
            }
            return IPAllowed;
            
        }
    }

    public class IPAddressDtl
    {
        public string GetIPAddress()
        {
            string IpAddress = "";
            System.Net.IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            System.Net.IPAddress ipAddress = host.AddressList.Where(ips => ips.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault();
            IpAddress = ipAddress.ToString().Trim();
            return IpAddress;
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


    }

    public class RolesAttribute : AuthorizeAttribute
    {
        public RolesAttribute(params string[] roles)
        {
            Roles = String.Join(",", roles);
        }

      

        
    }

    public class MUJICustomAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // If they are authorized, handle accordingly
            if (this.AuthorizeCore(filterContext.HttpContext))
            {
                base.OnAuthorization(filterContext);
            }
            else
            {
                // Otherwise redirect to your specific authorized area
                filterContext.Result = new RedirectResult("~/VideoFiles/ViewUploadDetails");
            }
        }
    }

    public class SessionExpireAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            // check  sessions here
            if (HttpContext.Current.Session["username"] == null)
            {
                filterContext.Result = new RedirectResult("~/Home/Index");
                return;
            }
            BLL.CommonLogic.SetCultureInfo();
            base.OnActionExecuting(filterContext);
        }
    }
}