using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penna_Common
{
     public class Penna_ManageSettings
    {

        public int ips { get; set; }
        public int Manage_Printers_PKID { get; set; }
        public string IP_Address { get; set; }
        public string IP_Address1_Print { get; set; }
        public string IP_Address2_Print { get; set; }
        public string IP_Address3_Print { get; set; }
        public string IP_Address4_Print { get; set; }
        public string Port_No { get; set; }
        public string Port1_Print { get; set; }
        public string Port2_Print { get; set; }
        public string Port3_Print { get; set; }
        public string Port4_Print { get; set; }

        public int Master_Setting_PKID { get; set; }
        public string Database_Polling_Time { get; set; }
        public string Polling_Timer_Printer { get; set; }
        public string Polling_Timer_COunter { get; set; }

        public string IP_Address1_counter1 { get; set; }
        public string IP_Address1_counter2 { get; set; }
        public string IP_Address2_counter1 { get; set; }
        public string IP_Address2_counter2 { get; set; }
        public string IP_Address3_counter1 { get; set; }
        public string IP_Address3_counter2 { get; set; }
        public string IP_Address4_counter1 { get; set; }
        public string IP_Address4_counter2 { get; set; }
              
        public string Port1_counter1 { get; set; }
        public string Port1_counter2 { get; set; }
        public string Port2_counter1 { get; set; }
        public string Port2_counter2 { get; set; }
        public string Port3_counter1 { get; set; }
        public string Port3_counter2 { get; set; }
        public string Port4_counter1 { get; set; }
        public string Port4_counter2 { get; set; }

        public int Packer_FKID { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
