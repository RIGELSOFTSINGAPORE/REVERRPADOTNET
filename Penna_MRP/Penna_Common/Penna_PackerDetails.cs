using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penna_Common
{
    public class Penna_PackerDetails
    {
        public int packing_Status_details_PKID { get; set; }
        public string Delivery_Number { get; set; }
        public string Vehicle_Number { get; set; }
        public string Message_Format { get; set; }
        public Decimal MRP { get; set; }
        public string Grade { get; set; }
        public int Set_Count { get; set; }
        public int Bag_Count { get; set; }
        public int Busted_Bag_Count { get; set; }
        public int InProgress_Bag_Count { get; set; }
        public DateTime Start_Date_Time { get; set; }
        public DateTime End_Date_Time { get; set; }
        public string Status { get; set; }
        public string IsActive { get; set; }
        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public int Modified_By { get; set; }
        public DateTime Modified_Date { get; set; }
        public int Packer { get; set; }
    }
    public class Penna_PackerDetails_send
    {
        public string Delivery_Number { get; set; }
        public string Vehicle_Number { get; set; }
        public string Message_Format { get; set; }
        public Decimal MRP { get; set; }
        public string Grade { get; set; }
        public int Set_Count { get; set; }
        public int Bag_Count { get; set; }
        public int Busted_Bags { get; set; }
    }
    public class Penna_PackerDetails_SAP {
        public string Plant { get; set; }
        public string Vbeln { get; set; }
        public string Bags { get; set; }
        public string Traid { get; set; }
        public string Vtext { get; set; }
        public string Mrp { get; set; }
    }

}
