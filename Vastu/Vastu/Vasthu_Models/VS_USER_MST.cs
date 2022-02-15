using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Vasthu_Models
{
    public class VS_USER_MST
    {
        [Key]
        [Display(Name = "User ID")]
        public decimal USER_ID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.EnterUserName ))]
        [MaxLength(100, ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.MaximumLength100))]
        [Display(Name = "Login Name")]
        public string LOGIN_NAME { get; set; }

        [Required(ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.EnterPassword))]
        [MaxLength(100, ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.MaximumLength100))]
        [Display(Name = "Password")]
        public string LOGIN_PASSWORD { get; set; }

        [Required(ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.EnterConfirmPassword))]
        [MaxLength(100, ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.MaximumLength100))]
        [Display(Name = "Confirm Password")]
        public string LOGIN_CONFIRM_PASSWORD { get; set; }

        [Required (ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.ConfirmNewPassword))]
        [MaxLength(100, ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.MaximumLength100))]
        [Display(Name = "Confirm New Password")]
        public string LOGIN_CONFIRM_NEW_PASSWORD { get; set; }

        [Required(ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.EnterFirstame))]
        [MaxLength(400,ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.MaximumLength400))]
        [Display(Name = "First Name")]
        public string FIRST_NAME { get; set; }

      
        [MaxLength(400,ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.MaximumLength400))]
        [Display(Name = "Middle Name")]
        public  string MIDDLE_NAME { get; set; }

        [MaxLength(400, ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.MaximumLength400))]
        [Display(Name = "Last Name")]
        public string LAST_NAME { get; set; }

        [MaxLength(400, ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.MaximumLength400))]
        [Display(Name = "Address 1")]
        [DataType(DataType.MultilineText)]
        public string ADDRESS_LINE1 { get; set; }

        [MaxLength(400,ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.MaximumLength400))]
        [Display(Name = "Address 2")]
        [DataType(DataType.MultilineText)]
        public string ADDRESS_LINE2 { get; set; }

        [MaxLength(400,ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.MaximumLength400))]
        [Display(Name = "City")]
        public string CITY { get; set; }

        [MaxLength(400, ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.MaximumLength400))]
        [Display(Name = "Country")]
        public string COUNTRY { get; set; }

        [Required(ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.EnterEmail))]
        [MaxLength(400, ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.MaximumLength400))]
        [Display(Name = "EMail")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$",ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.EnterValidEmail))]
        public string EMAIL_ID { get; set; }

       
        [MaxLength(400,ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.MaximumLength400))]
        [Display(Name = "Contact No")]
        public string CONTACT_NO { get; set; }


        [Required(ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.SelectUserType))]
        [Display(Name = "User Type")]
        public int USER_TYPE { get; set; }


        [Display(Name = "User Type")]
        
        public List<SelectListItem> USER_TYPE_NAME { get; set; }

        [Display(Name = "User Type")]
      
        public string USER_TYPE_NAME_STR { get; set; }

        [Required(ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.SelectStatus))]
        [Display(Name = "Status")]
        public int STATUS_ID { get; set; }

        [Display(Name = "Is Delete")]
        public bool DELETE_FLAG { get; set; }

        public int CREATED_USER { get; set; }

        [Display(Name = "Created User")]
        public string CREATED_USER_NAME { get; set; }

        [Display(Name = "Created Date")]
        public string C_USER_DATE { get; set; }
        public System.DateTime CREATED_DATE { get; set; }

        public int UPDATED_USER { get; set; }

        [Display(Name = "Updated Date")]
        public string U_USER_DATE { get; set; }

        [Display(Name = "Updated User")]
        public string UPDATED_USER_NAME { get; set; }

        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
    }



    
}
