using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Penna_Common
{
    public class PennaUser_Master
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role_Name{ get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int RoleId { get; set; }
        public string  Email { get; set; }
        public string DisplayName { get; set; }
        //public int errorcode { get; set; }

        //public string CustomerTypeName { get; set; }
        //public bool IsClient { get; set; }
    }
}
