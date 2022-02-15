using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaisokku_Common
{
   public class CRMList
    {        
            public int UserCustomId { get; set; }
            public string ContactName { get; set; }
            public string CompanyName { get; set; }
            public bool IsActive { get; set; }
            public string CreatedDate { get; set; }
            public string CreatedBy { get; set; }
            public string Email { get; set; }
            public int CustomerType { get; set; }
        
    }
}
