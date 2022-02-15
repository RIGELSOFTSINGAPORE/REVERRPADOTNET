﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vasthu_Models
{
    public class VS_VASTU_MST_TRAN_DETAILS
    {
        [Key]
        [Display(Name = "Vastu Master Transaction ID")]
        public int VASTU_MST_TRAN_ID { get; set; }

        [Display(Name = "Vastu Type")]
        public string VASTU_TYPE { get; set; }

        [Display(Name = "Area")]
        public string AREA { get; set; }

        [Display(Name = "Direction")]
        public string DIRECTION { get; set; }

        [Display(Name = "Column Name")]
        public string COLUMN_NAME { get; set; }

        [Display(Name = "Old Value")]
        public string OLD_VALUE { get; set; }

        [Display(Name = "New Value")]
        public string NEW_VALUE { get; set; }

        [Display(Name = "Created User")]
        public string C_USER { get; set; }

        [Display(Name = "Created Date")]
        public string C_DATE { get; set; }
    }
}
