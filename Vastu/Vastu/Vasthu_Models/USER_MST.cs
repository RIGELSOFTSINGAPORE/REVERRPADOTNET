using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vasthu_Models
{
    public class USER_MST
    {        
            public int USER_ID { get; set; }           
            public string LOGIN_NAME { get; set; }
            public string LOGIN_PASSWORD { get; set; }           
            public string FIRST_NAME { get; set; }
            public string MIDDLE_NAME { get; set; }
            public string LAST_NAME { get; set; }           
            public string ADDRESS_LINE1 { get; set; }
            public string ADDRESS_LINE2 { get; set; }
            public string CITY { get; set; }
            public string COUNTRY { get; set; }
            public string EMAIL_ID { get; set; }
            public string CONTACT_NO { get; set; }
            public int USER_TYPE { get; set; }
            public int STATUS_ID { get; set; }
            public bool DELETE_FLAG { get; set; }
            public int CREATED_USER { get; set; }
            public DateTime CREATED_DATE { get; set; }
            public string UPDATED_USER { get; set; }
            public string UPDATED_DATE { get; set; }
            public string OldPassword { get; set; }
            public bool RememberMe { get; set; }           
            public string ConfrimPassword { get; set; }
            public string NewPassword { get; set; }

        
    }
}
