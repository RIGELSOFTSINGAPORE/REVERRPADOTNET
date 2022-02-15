﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vasthu_Models
{
    public class Feedback
    {
        public int FEEDBACK_ID { get; set; }
        public string NAME { get; set; }
        public string ADDRESS_LINE { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string COUNTRY { get; set; }
        public string COMMENTS_1 { get; set; }
        public string COMMENTS_2 { get; set; }
        public string COMMENTS_3 { get; set; }
        public string IMAGE_URL_1 { get; set; }
        public bool DELETE_FLAG { get; set; }

        public int STATUS_ID { get; set; }

        public string DISPLAYNAME { get; set; }

        public string LNAME { get; set; }

        public string CREATED_DATE { get; set; }
    }
}
