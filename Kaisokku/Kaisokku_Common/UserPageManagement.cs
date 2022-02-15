using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaisokku_Common
{
    public class UserPageManagement
    {
        public string pagefilename { get; set; }
        public string pagedescription { get; set; }
        public string pagecontent { get; set; }
        public string  UserId { get; set; }
        public int PageId { get; set; }
        public string AdminRights { get; set; }
        public bool IsActive { get; set; }
    }
}
