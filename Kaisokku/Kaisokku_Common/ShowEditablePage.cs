using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaisokku_Common
{
    public class ShowEditablePage
    {
        public int PageID { get; set; }
        public string PageDescription { get; set; }
        public string PageContent { get; set; }
        public string UserId { get; set; }
        public bool IsActive { get; set; }
    }
}
