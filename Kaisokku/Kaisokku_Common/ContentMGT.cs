using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaisokku_Common
{
    public class Content
    {
       
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_date { get; set; }
        public string Updated_by { get; set; }        
        public DateTime Updated_date { get; set; }
        

    }
}
