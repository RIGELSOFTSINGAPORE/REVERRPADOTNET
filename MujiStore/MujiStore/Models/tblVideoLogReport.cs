//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MujiStore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblVideoLogReport
    {
        public int VideoLogID { get; set; }
        public string StoreName { get; set; }
        public string CountryName { get; set; }
        public string IPAddress { get; set; }
        public string UserName { get; set; }
        public string MenuClick { get; set; }
        public bool DELFG { get; set; }
        public Nullable<System.DateTime> CRTDT { get; set; }
        public string CRTCD { get; set; }
        public Nullable<System.DateTime> UPDDT { get; set; }
        public string UPDCD { get; set; }
        public string Comments { get; set; }
    }
}
