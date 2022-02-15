using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.IO;
namespace Vasthu_Models
{
    public class Common
    {
        public static string ModifiedFileName(string OrigFileName)
        {
            var ext = Path.GetExtension(OrigFileName);
            var name = Path.GetFileNameWithoutExtension(OrigFileName);
            var fileName = name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
            return fileName;
        }
    }
    public class CustomExtn : ValidationAttribute
    {
        private readonly string _DefaultErrorMessage = "Only the following file types are allowed: {0}";
        private IEnumerable<string> _ValidTypes { get; set; }
        public string AllowedExtn { get; set; }



        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            else
            {
                HttpPostedFileBase uploadFile = value as HttpPostedFileBase;
                string extn = System.IO.Path.GetExtension(uploadFile.FileName); //.txt
                extn = extn.TrimStart('.').ToLower();
                return AllowedExtn.Contains(extn);
            }

            //return base.IsValid(value);
        }

    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class AllowFileSizeAttribute : ValidationAttribute
    {
        #region Public / Protected Properties  

        /// <summary>  
        /// Gets or sets file size property. Default is 1GB (the value is in Bytes).  
        /// </summary>  
        //public int FileSize { get; set; } = 1 * 1024 * 1024 * 1024;
        public int FileSize { get; set; } = 3 * 1024;

        #endregion

        #region Is valid method  

        /// <summary>  
        /// Is valid method.  
        /// </summary>  
        /// <param name="value">Value parameter</param>  
        /// <returns>Returns - true is specify extension    matches.</returns>  
        public override bool IsValid(object value)
        {
            // Initialization  
            HttpPostedFileBase file = value as HttpPostedFileBase;
            bool isValid = true;

            // Settings.  
            int allowedFileSize = this.FileSize;

            // Verification.  
            if (file != null)
            {
                // Initialization.  
                var fileSize = file.ContentLength;

                // Settings.  
                isValid = fileSize <= allowedFileSize;
            }

            // Info  
            return isValid;
        }

        #endregion
    }
}
