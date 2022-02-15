using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaisokku_Common
{
    public class ViewLogHistory
    {
        public int rownumber { get; set; }
        public int MenuId { get; set; }
        public int SerialNo { get; set; }
        public string MenuName { get; set; }
        public int count { get; set; }
        
        public string UserName { get; set; }
        public string VisitedDate { get; set; }
    }
}
