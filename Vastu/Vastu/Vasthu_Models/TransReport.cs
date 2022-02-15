using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Vasthu_Models
{
   public class TransReport
    {
        public int VASTU_REPORT_ID { get; set; }
        public string VASTU_TYPE { get; set; }
        public string REPORT_TAKEN_BY { get; set; }

        public string EMAIL_ID { get; set; }
        public string VASTU_DATE { get; set; }

        public string DLANGUAGE { get; set; }
    }
}
