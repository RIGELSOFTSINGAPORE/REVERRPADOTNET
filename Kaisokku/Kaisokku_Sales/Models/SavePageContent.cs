using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Kaisokku_Sales.Models
{
    public class SavePageContent
    {

        public string pagefilename { get; set; }
        public string pagedescription { get; set; }
        [AllowHtml]
        public string pagecontent { get; set; }
        public string createdby { get; set; }
        public bool IsActive { get; set; }
        public string UserId  { get; set; }
        public string Editable { get; set; }
        public int EditPageId { get; set; }
        public int PageMenuId { get; set; }
    }
}