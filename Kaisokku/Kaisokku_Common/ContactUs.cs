using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaisokku_Common
{
    public class ContactUs
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string EmailID { get; set; }
        public string Subject  { get; set; }
        public string Message  { get; set; }
        public string Created_by  { get; set; }
        public string Created_Date  { get; set; }
    }
}
