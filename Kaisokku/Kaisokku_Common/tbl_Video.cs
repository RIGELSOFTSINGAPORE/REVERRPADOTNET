using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaisokku_Common
{
    public class tbl_Video
    {
        public int MediaID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IPaddress { get; set; }
        public int Viewcount { get; set; }
        public string uploadtype { get; set; }
        public string Filename { get; set; }
        public int Folderid { get; set; }
        public List<tbl_Video> video { get; set; }
    }
}
