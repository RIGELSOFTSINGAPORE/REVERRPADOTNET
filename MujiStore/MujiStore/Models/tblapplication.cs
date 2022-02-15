using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MujiStore.Models
{
    public partial class tblapplication
    {
        public int ApplicationID { get; set; }

        public Nullable<int> MediaID { get; set; }

        public string Delete { get; set; }

        public string Register { get; set; }

        public string Accepter { get; set; }

        public string Registereddate { get; set; }

        public string Completedate { get; set; }

        public bool Approved { get; set; }

        public string status { get; set; }

        public string title { get; set; }

        public string description { get; set; }


        public string name { get; set; }

    }
}