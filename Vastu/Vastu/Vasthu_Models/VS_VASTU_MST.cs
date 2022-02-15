using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vasthu_Models
{
    public class VS_VASTU_MST
    {
        [Key]
        [Display(Name = "Vastu ID")]
        public int VASTU_ID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.selectArea))]
        [Display(Name = "Area")]
        public int AREA_ID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.SelectDirection))]
        [Display(Name = "Direction")]
        public int DIRECTION_ID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.SelectVastuType))]
        [Display(Name = "Vastu Type")]
        public int VASTU_TYPE_ID { get; set; }

       
        [Required(ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.SelectScore))]
        [Display(Name = "Score")]
        public int SCORE_ID { get; set; }

       
        [RegularExpression(@"^([0-9]{1,2}){1}(\.[0-9]{1,2})?$", ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.RangeBetween0to99))]
        [Display(Name = "Extra Score")]
        public string EXTRA_SCORE { get; set; }

        public string OLD_EXTRA_SCORE { get; set; }

        [MaxLength(2000, ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.MaximumLength2000))]
        [Display(Name = "Short Description")]
        [DataType(DataType.MultilineText)]
        public string SHORT_DESCRIPTION { get; set; }

        public string OLD_SHORT_DESCRIPTION { get; set; }


        [MaxLength(6000, ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.MaximumLength6000))]
        [Display(Name = "Long Description")]
        [DataType(DataType.MultilineText)]
        public string LONG_DESCRIPTION { get; set; }

        public string OLD_LONG_DESCRIPTION { get; set; }

        [Required(ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.SelectStatus))]
        [Display(Name = "Status")]
        public int STATUS_ID { get; set; }

        [Display(Name = "Is Delete")]
        public bool DELETE_FLAG { get; set; }

        
        public bool OLD_DELETE_FLAG { get; set; }

        public int CREATED_USER { get; set; }

        public System.DateTime CREATED_DATE { get; set; }

        public int UPDATED_USER { get; set; }

        public Nullable<System.DateTime> UPDATED_DATE { get; set; }

        [Display(Name = "Vastu Type")]
        public string VASTU_TYPE { get; set; }

        [Display(Name = "Area")]
        public string AREA { get; set; }

        [Display(Name = "Direction")]
        public string DIRECTION { get; set; }

        [Display(Name = "Score")]
        public string SCORE { get; set; }

        [Display(Name = "Score")]
        public string OLD_SCORE { get; set; }

        public int OLD_SCORE_ID { get; set; }

        [Display(Name = "Created User")]
        public string CREATED_USER_NAME { get; set; }

        [Display(Name = "Created Date")]
        public string C_USER_DATE { get; set; }

        [Display(Name = "Updated Date")]
        public string U_USER_DATE { get; set; }

        [Display(Name = "Updated User")]
        public string UPDATED_USER_NAME { get; set; }
    }

         
}
