using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Kaisokku_Common
{
    public class EnquiryForm
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string phoneno { get; set; }
        public string comments { get; set; }

    }
    public class clint { 
        public string CompanyName { get; set; }
        public string BuildingName { get; set; }
        public string BuidingNo { get; set; }
        public string street { get; set; }
        public string Area { get; set; }
        public string state_pin_Country { get; set; }
    }
    public class UserContactUsViewModel
    {
        public EnquiryForm EnquiryFormDetails{ get; set; }
        public clint ClientDetails { get; set; }
    }
}
