using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vasthu_Models
{
    public class VastuReportOutput
    {
        public int RowNumber { get; set; }
        public string Interior { get; set; }
        public string Direction { get; set; }
        public decimal  Judgment { get; set; }
        public string Comment { get; set; }
    }
}
