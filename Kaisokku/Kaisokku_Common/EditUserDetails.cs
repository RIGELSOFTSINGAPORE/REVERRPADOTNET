using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaisokku_Common
{
    public class EditUserDetails
    {
        public int UserMasterId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public string Email { get; set; }
        public int CustomerType { get; set; }
        public bool Client { get; set; }
    }
}
