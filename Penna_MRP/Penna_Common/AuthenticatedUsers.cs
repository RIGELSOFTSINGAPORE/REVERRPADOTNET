using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penna_Common
{
    public class AuthenticatedUsers
    {
     
        public int User_Master_PKID { get; set; }
        public string User_Name { get; set; }      
        public string Password { get; set; }
        public string Display_Name { get; set; }
        public string Role_Name { get; set; }
        public int Role_FKID { get; set; }      
        public string IsActive { get; set; }
        public string Modified_By { get; set; }
        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Modified_Date { get; set; }


    }
}
