﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vasthu_Models
{
    public class VS_SCORE_MST
    {
        [Key]
        [Display(Name = "Score ID")]
        public int SCORE_ID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.EnterScoreDetails))]
        [MaxLength(400,ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.MaximumLength400))]
        [Display(Name = "Score Details")]
        [DataType(DataType.MultilineText)]
        public string SCORE_TEXT { get; set; }


        //[RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage = "Range Between 0 to  99")]
        //[RegularExpression(@"[0-9]?[0 - 9]? (\.[0-9] [0-9]?)?", ErrorMessage = "Range Between 0 to  99")]
        //[RegularExpression(@"^\d{1,2}$|(?=^.{1,2}$)^\d+\.\d{0,2}$", ErrorMessage = "Range Between 0 to  99")]
        //[RegularExpression(@"^[1-9]\d* (\.\d+)?$", ErrorMessage = "Range Between 0 to  99")]
        [RegularExpression(@"^([0-9]{1,2}){1}(\.[0-9]{1,2})?$", ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.RangeBetween0to99))]
        //[Range(0, 100), ErrorMessage = "Range Between 0 to  100")]
        [Required(ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.SelectScore))]

        [Display(Name = "Score")]
        public decimal SCORE { get; set; }

        [Required(ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.SelectImageFile))]
        [Display(Name = "Score Image")]
        public int IMAGE_ID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.SelectStatus))]
        [Display(Name = "Status")]
        public int STATUS_ID { get; set; }

        [Display(Name = "Is Delete")]
        public bool DELETE_FLAG { get; set; }

        public int CREATED_USER { get; set; }

        
        public System.DateTime CREATED_DATE { get; set; }

        public int UPDATED_USER { get; set; }

        public Nullable<System.DateTime> UPDATED_DATE { get; set; }


        public string IMAGE_DETAILS { get; set; }

        [Display(Name = "Image Symbol")]
        public string IMAGE_SYMBOL { get; set; }

        public string IMAGE_URL { get; set; }

        [Display(Name = "Created User")]
        public string CREATED_USER_NAME { get; set; }

        [Display(Name = "Created Date")]
        public string C_USER_DATE { get; set; }

        [Display(Name = "Updated Date")]
        public string U_USER_DATE { get; set; }

        [Display(Name = "Updated User")]
        public string UPDATED_USER_NAME { get; set; }

        public bool IMG_DELETE_FLAG { get; set; }
    }
}


