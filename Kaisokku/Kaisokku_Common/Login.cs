using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaisokku_Common
{
    public class Login
    {
        [StringLength(50)]
       
        [Required(AllowEmptyStrings = false,ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false,ErrorMessage = "Password is Required")]
        [StringLength(10)]
        public string password { get; set; }

        public bool RememberMe { get; set; }

        //[Required(ErrorMessage = "Email is Required")]
        [StringLength(150)]
        public string Email { get; set; }
    }
}
