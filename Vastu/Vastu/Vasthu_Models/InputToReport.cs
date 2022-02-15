using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vasthu_Models
{
    public class InputToReport
    {
        public List<Inputs> GetInputs { get; set; }
        
    }
    public class Inputs
    {
        public string AreaId { get; set; }
        public string DirectionId { get; set; }
    }

    
}
