using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Kaisokku_Sales.Models
{
    public class CRMEmail
    {
        public string CC { get; set; }
        public string SenderFrom { get; set; }
        public string EmailTo { get; set; }
        public string Subject { get; set; }
        [AllowHtml]
        public string Body { get; set; }
    }
}