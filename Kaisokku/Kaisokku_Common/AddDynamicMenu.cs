using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaisokku_Common
{
    public class AddDynamicMenu
    {
        [StringLength(50)]
        public string MenuName { get; set; }
        [StringLength(50)]
        public string ControllerName { get; set; }
        [StringLength(50)]
        public string ActionMethod { get; set; }

        public int MenuParentId { get; set; }

        public bool IsActive { get; set; }

        public int  RoleId { get; set; }

        public string IpAddress { get; set; }

        public DateTime createddate { get; set; }

        public string createdby { get; set; }

        public DateTime updateddate { get; set; }

        public string updatedby { get; set; }
      
    }
}
