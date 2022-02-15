using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaisokku_Common
{
    public class video
    {
        public int MediaID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IPaddress { get; set; }
        public int Viewcount { get; set; }
        public string uploadtype { get; set; }
        public string UserTypeName { get; set; }
        public string Filename { get; set; }
        public int Folderid { get; set; }
        public int Usertype { get; set; }
        //public string  startdate { get; set; }
        //public string enddate { get; set; }

        //public List<SelectListItem> showvideos { get; set; }

        public string PlayVideoFileName { get; set; }
        public List<video> Showall { get; set; }
    }

   
}
