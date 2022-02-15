using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vasthu_Models
{
    public class VS_STATUS_MST
    {
        [Key]
        [Display(Name = "Status ID")]
        public int STATUS_ID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.EnterDescription))]
        [MaxLength(100,ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.MaximumLength100))]
        [Display(Name = "Description")]
        public string STATUS { get; set; }

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
