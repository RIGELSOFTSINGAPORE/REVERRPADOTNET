using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaisokku_Common
{
    public class AuthenticatedUsers
    {
        [StringLength(20)]
        public string UserId { get; set; }
        public string UserMasterID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        public int RoleId { get; set; }

        public bool IsActive { get; set; }

      

        [StringLength(100)]
        public string RoleName { get; set; }

    }
}
