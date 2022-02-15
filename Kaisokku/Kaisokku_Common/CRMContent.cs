using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaisokku_Common
{
   public class CRMContent
    {
            public string UserId { get; set; }
            public string ContactName { get; set; }
            public string CompanyName { get; set; }
            //public string Email{ get; set; }
            public bool IsActive { get; set; }
            public string CreatedBy { get; set; }
            public int RoleId { get; set; }
            public string Email { get; set; }
            public int CustomerType { get; set; }
        
    }
}
