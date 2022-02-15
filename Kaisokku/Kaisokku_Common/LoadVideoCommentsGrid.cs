using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaisokku_Common
{
    public class LoadVideoCommentsGrid
    {
        public int Sno { get; set; }
        public int  VideoId { get; set; }
        public string VideoName { get; set; }
        public string VideoComments { get; set; }
        public string FilePath { get; set; }
        public string VisitedDate { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public string UserId { get; set; }
        public string VisitorName { get; set; }
        public string FileName { get; set; }

        public bool IsDeleted { get; set; }
    }
}
