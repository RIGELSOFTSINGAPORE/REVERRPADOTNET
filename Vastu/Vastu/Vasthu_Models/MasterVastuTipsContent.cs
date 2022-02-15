using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vasthu_Models
{
    public class MasterVastuTipsContent
    {
        public int ContentID { get; set; }
        public string ContentName { get; set; }
    }
    public class MstrVastuTipsContent
    {
        public string ContentDescription { get; set; }
    }


    public class SaveVastuTipsContent
    {
        public int ContentID { get; set; }
        public string ContentDescription { get; set; }
    }
}
