using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;
namespace Vasthu_Models
{
    public class VS_IMAGE_MST
    {
        [Key]
        [Display(Name = "Image ID")]
        public int IMAGE_ID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.EnterImageDetails))]
        [MaxLength(200, ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.MaximumLength200))]
        [Display(Name = "Image Details")]
        public string IMAGE_DETAILS { get; set; }

        [Required(ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.SelectImageFile))]
        [MaxLength(200,ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.MaximumLength200))]
        [Display(Name = "Image File")]
        public string IMAGE_URL { get; set; }


        [Required(ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.SelectImageFile ))]
        [CustomExtn(ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.Onlyfilesareallowed), AllowedExtn = "bmp,gif,img,jpg,jpeg,png,tiff")]
        [AllowFileSize(FileSize = 3 * 1024 * 1024, ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.Maximumallowedfilesizeis3MB))]
        public HttpPostedFileBase PostedFile { get; set; }

        [CustomExtn(ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.Onlyfilesareallowed), AllowedExtn = "bmp,gif,img,jpg,jpeg,png,tiff")]
        [AllowFileSize(FileSize = 3 * 1024 * 1024, ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.Maximumallowedfilesizeis3MB))]
        public HttpPostedFileBase PostedEditFile { get; set; }

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

        
        [Required(ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.EnterSpecialCharacters))]
        //[RegularExpression(@"^[a-zA-Z0-9_.-]*$", ErrorMessage = "Allow Only Special Characters")]
        //[Range(0, 100), ErrorMessage = "Range Between 0 to  100")]
        [Display(Name = "Image Symbol")]
        public string IMAGE_SYMBOL { get; set; }
    }


}
