using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vasthu_Models
{
    public class InputTextToReport
    {
        public List<InputText> GetInputsText { get; set; }
        public List<UpdateComments> UpdtComments { get; set; }
    }
    public class InputText
    {
        public long VASTU_REPORT_ID { get; set; }
        public string Area { get; set; }
       
        public string AreaId { get; set; }
        public string Direction { get; set; }

        public string DirectionId { get; set; }
        public bool DELETE_FLAG { get; set; }

        public long CREATED_USER { get; set; }

        public string CREATED_DATE { get; set; }

        public string RESEARCHER_COMMENTS { get; set; }
    }


    public class Vastuid1
    {
        public long VASTU_REPORT_ID { get; set; }
    }

    public class Vastuid2
    {
        public long VASTU_REPORT_ID { get; set; }
    }

    public class AreaDirectionComments
    {
        public string Area { get; set; }
        public string Direction { get; set; }

        public string RESEARCHER_COMMENTS { get; set; }

    }

    public class AreaDirectionComments2
    {
        public string Area { get; set; }
        public string Direction { get; set; }

        public string RESEARCHER_COMMENTS { get; set; }

    }

    public class UpdateComments
    {
        public long VASTU_REPORT_ID { get; set; }
        
        public string RESEARCHER_COMMENTS { get; set; }

        public string UPDATED_DATE { get; set; }

        public string Area { get; set; }

        public string Direction { get; set; }


    }
}


