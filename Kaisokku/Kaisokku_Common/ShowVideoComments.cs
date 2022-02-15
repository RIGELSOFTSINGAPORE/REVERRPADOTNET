using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaisokku_Common
{
    public class ShowVideoComments
    {
        public int Sno { get; set; }
        public string VideoName { get; set; }
        public string FilePath { get; set; }
        public string VideoComments { get; set; }
        public string FileName { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDeleted { get; set; }
    }
}
