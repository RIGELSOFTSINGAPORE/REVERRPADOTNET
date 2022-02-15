using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vasthu_Models
{
    public class VS_VASTU_TYPE_MST
    {
        [Key]
        [Display(Name = "Vastu Type ID")]
        public int VASTU_TYPE_ID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.EnterVastuType))]
        [MaxLength(400,ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.MaximumLength400))]
        [Display(Name = "Vastu Type")]
        public string VASTU_TYPE { get; set; }

        [Required(ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.SelectStatus))]
        [Display(Name = "Status")]
        public int STATUS_ID { get; set; }

        [Display(Name = "Is Delete")]
        public bool DELETE_FLAG { get; set; }

        public int CREATED_USER { get; set; }

        public System.DateTime CREATED_DATE { get; set; }

        public int UPDATED_USER { get; set; }

        public Nullable<System.DateTime> UPDATED_DATE { get; set; }

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
