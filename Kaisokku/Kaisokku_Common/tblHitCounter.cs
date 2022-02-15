using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaisokku_Common
{
   public class tblHitCounter
    {
        public string CountryName { get; set; }

        public DateTime Visiteddate { get; set; }

        public string IpAddress { get; set; }

        public bool IsActive { get; set; }

        public string createdby { get; set; }

        public string updatedby { get; set; }

        public DateTime createddate { get; set; }


    }
}
