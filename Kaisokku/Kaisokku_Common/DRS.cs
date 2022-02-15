using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaisokku_Common
{
   public class DRS
    {
        public int ServiceOrderNo { get; set; }
        public string LastUpdatedUser { get; set; }
        public string BillingUser { get; set; }
        public DateTime BillingDate { get; set; }
        public DateTime GoodsDeliveredDate { get; set; }
        public string Engineer { get; set; }
        public string Product { get; set; }
        public decimal inLabour { get; set; }
        public decimal inParts { get; set; }
        public decimal inTransport { get; set; }
        public decimal inothers { get; set; }
        public decimal inTax { get; set; }
        public decimal inTotal { get; set; }
        public decimal outLabour { get; set; }
        public decimal outParts { get; set; }
        public decimal outTransport { get; set; }
        public decimal outthers { get; set; }
        public decimal outTax { get; set; }
        public decimal outTotal { get; set; }
    }
}
