using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vasthu_Models
{
    public class VS_CONTENT_MST
    {
        [Key]
        [Display(Name = "Content ID")]
        public int CONTENT_ID { get; set; }


        [Required(ErrorMessage = "Enter Content Name")]
        [MaxLength(400, ErrorMessage = "Maximum Length 400")]
        [Display(Name = "Content Name")]
        public string CONTENT_NAME { get; set; }

        
        [Required(ErrorMessage = "Select Status")]
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
