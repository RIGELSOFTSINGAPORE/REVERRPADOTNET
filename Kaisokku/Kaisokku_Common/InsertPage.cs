using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaisokku_Common
{
    public class InsertPage
    {
        public string pagefilename { get; set; }
        public string pagedescription { get; set; }
        public string pagecontent { get; set; }
        public bool IsActive { get; set; }
        public string createdby { get; set; }
        public string UserId { get; set; }
        public string AdminRights { get; set; }
        public string IpAddress { get; set; }
        public string UpdatedBy { get; set; }
       
        public string Editable { get; set; }
        public int EditPageId { get; set; }
        public int PageMenuId { get; set; }
    }
}
