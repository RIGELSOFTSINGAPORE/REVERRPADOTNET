using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vasthu_Models
{
    public class ShowFinalReport
    {
        public int SerialNo { get; set; }
        public string Area { get; set; }

        public string Direction { get; set; }
        public string Center { get; set; }

        public string North { get; set; }
        public string NorthEast { get; set; }

        public string East { get; set; }
        public string SouthEast { get; set; }

        public string South { get; set; }
        public string SouthWest { get; set; }

        public string West { get; set; }
        public string NorthWest { get; set; }

        public string Judgement { get; set; }

        public string ImageURL{ get; set; }
        public decimal PointsEarned { get; set; }
        
        public string MasterComments { get; set; }
        public string ResearcherComments { get; set; }
        

    }
    public static class GetVastuReportID
    {
        public static long VastuReportID { get; set; }
    }
    public class GetVastuEmailInformation
    {
        public string Name { get; set; }
        public string EmailID { get; set; }
        public DateTime VastuDate { get; set; }
    }
}
