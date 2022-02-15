using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaisokku_Common
{
    public class Menu
    {        
        public int MID { get; set; }
        public string MenuName { get; set; }
        public string ControllerName { get; set; }
        public string ActionMethod { get; set; }
        public int MenuParentID { get; set; }
        public string MenuParentCss1 { get; set; }
        public string LanguageJapanease { get; set; }
    }
}
