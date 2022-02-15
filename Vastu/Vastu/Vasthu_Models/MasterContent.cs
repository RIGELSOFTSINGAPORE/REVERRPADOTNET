using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vasthu_Models
{
    public class MasterContent
    {
        public int ContentID { get; set; }
        public string ContentName { get; set; }
    }
    public class MstrContent
    {
        public string ContentDescription { get; set; }
    }


    public class SaveContent
    {
        public int ContentID { get; set; }
        public string ContentDescription { get; set; }
    }
}
