using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Kaisokku_Sales.Models
{
    public class SaveContent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_date { get; set; }
        public string Updated_by { get; set; }
        public DateTime Updated_date { get; set; }
    }
}