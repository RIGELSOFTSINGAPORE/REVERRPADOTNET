using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kaisokku_Upload_Download.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        private string _ConnectionString = ConfigurationManager.ConnectionStrings["Kaisokku_SaleDBContext"].ConnectionString;
        public string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
        }

        public BaseController()
        {

        }
    }
}