using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace Kaisokku_Common
{
    public class GetVideo
    {
        
        public string Title { get; set; }

        public string Description { get; set; }
        
        public string Filename { get; set; }

        public int FolderID { get; set; }

        public string FolderName { get; set; }

        public int ViewCount { get; set; }
    }
}
