using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaisokku_Common
{
    public class UsersList
    {
        public int UserMasterId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string Email { get; set; }
        public int CustomerType { get; set; }
        public string CustomerTypeName { get; set; }
        public string Client { get; set; }
    }
}
