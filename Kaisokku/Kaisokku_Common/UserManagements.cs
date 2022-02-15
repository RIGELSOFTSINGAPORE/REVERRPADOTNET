using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaisokku_Common
{
    public class UserManagements
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        //public string Email{ get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public int RoleId { get; set; }
        public string  Email { get; set; }
        public int CustomerType { get; set; }
        public int errorcode { get; set; }

        public string CustomerTypeName { get; set; }
        public bool IsClient { get; set; }
    }
}
