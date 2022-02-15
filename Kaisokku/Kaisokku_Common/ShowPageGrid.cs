using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaisokku_Common
{
    public class ShowPageGrid
    {
        public int PageID{ get; set; }
        public string PageFileName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public int PageMenuId { get; set; }
    }
}