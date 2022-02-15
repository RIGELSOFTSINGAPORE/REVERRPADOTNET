using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaisokku_Common
{
    public class ForgotPassword
    {
        [StringLength(30)]
        public string password { get; set; }
    }
}
