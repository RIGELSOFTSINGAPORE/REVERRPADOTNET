using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vastu.Models
{
    public class SaveAboutContent
    {
        public int ContentID { get; set; }

        [AllowHtml]
        public string ContentDescription { get; set; }
    }
    public class ShowAboutContent
    {
        [AllowHtml]
        public string ContentDescription { get; set; }
    }
}