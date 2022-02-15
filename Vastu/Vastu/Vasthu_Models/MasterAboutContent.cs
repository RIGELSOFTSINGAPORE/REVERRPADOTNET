using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vasthu_Models
{
    public class MasterAboutContent
    {
        public int ContentID { get; set; }
        public string ContentName { get; set; }
    }
    public class MstrAboutContent
    {
        public string ContentDescription { get; set; }
    }


    public class SaveAboutContent
    {
        public int ContentID { get; set; }
        public string ContentDescription { get; set; }
    }
}
