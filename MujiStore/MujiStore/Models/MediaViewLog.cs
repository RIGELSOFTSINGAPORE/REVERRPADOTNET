using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MujiStore.Models
{
    public class MediaViewLog
    {
        public int MediaViewLogID { get; set; }
        public int MediaID { get; set; }
        public string UserName { get; set; }
        public string ClientIP { get; set; }
        public string UserAgent { get; set; }
        public bool DELFG { get; set; }
        public System.DateTime CRTDT { get; set; }
        public string CRTCD { get; set; }
        public System.DateTime UPDDT { get; set; }
        public string UPDCD { get; set; }
        public string IPAddress { get; set; }
    }
    public class SSDetails
    {
        public string SSServer { get; set; }
        public string IPAddress { get; set; }
        public string BelongingSubnet { get; set; }

        public string DeploySchedule { get; set; }

        public string DriveCTotal { get; set; }

        public string DriveCFree { get; set; }

        public string DriveDTotal { get; set; }

        public string DriveDFree { get; set; }

        public string FormatType { get; set; }

       public string CRTDT { get; set; }
        public string CRTDTTIME { get; set; }
        public string CRTCD { get; set; }

        public string FileType { get; set; }

        public string FileName { get; set; }

        public string RecStatus { get; set; }

        public string Remarks { get; set; }
        public string Remarks_ja { get; set; }

        public string StoreName { get; set; }
        public string StoreNumber { get; set; }
        public string FolderName { get; set; }
        public string SubnetNumber { get; set; }
        public string StoreGroupName { get; set; }
        public string UserIPAddress { get; set; }
      
    }

    public class SubnetDetails
    {
        public string SubnetID { get; set; }

        [Required(ErrorMessageResourceType = typeof(MujiStore.Resources.Resource), ErrorMessageResourceName = nameof(MujiStore.Resources.Resource.ModtblSubnetSNIPAddressDataAnnaValida1))]
        [RegularExpression(@"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$", ErrorMessageResourceType = typeof(MujiStore.Resources.Resource), ErrorMessageResourceName = nameof(MujiStore.Resources.Resource.ModtblSubnetSNIPAddressDataAnnaValida2))]
        public string SNIPAddress { get; set; }

        [Required(ErrorMessageResourceType = typeof(MujiStore.Resources.Resource), ErrorMessageResourceName = nameof(MujiStore.Resources.Resource.ModtblSubnetSubMaskDataAnnaValida1))]
        [RegularExpression(@"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$", ErrorMessageResourceType = typeof(MujiStore.Resources.Resource), ErrorMessageResourceName = nameof(MujiStore.Resources.Resource.ModtblSubnetSubMaskDataAnnaValida2))]
        public string SubnetMask { get; set; }

        [Required(ErrorMessageResourceType = typeof(MujiStore.Resources.Resource), ErrorMessageResourceName = nameof(MujiStore.Resources.Resource.ModtblSubnetWANBandWDataAnnaValida1))]
        [Range(1000, 50000, ErrorMessageResourceType = typeof(MujiStore.Resources.Resource), ErrorMessageResourceName = nameof(MujiStore.Resources.Resource.ModtblSubnetWANBandWDataAnnaValida2))]
        public float WANBandWidth { get; set; }

        [Required(ErrorMessageResourceType = typeof(MujiStore.Resources.Resource), ErrorMessageResourceName = nameof(MujiStore.Resources.Resource.ModtblSubnetLANBandWDataAnnaValida1))]
        [Range(1000, 50000, ErrorMessageResourceType = typeof(MujiStore.Resources.Resource), ErrorMessageResourceName = nameof(MujiStore.Resources.Resource.ModtblSubnetLANBandWDataAnnaValida2))]
        public float LANBandWidth { get; set; }

        public bool DELFG { get; set; }

        public System.DateTime CRTDT { get; set; }

        public string CRTCD { get; set; }

        public System.DateTime UPDDT { get; set; }

        public string UPDCD { get; set; }

        public string IPAddress { get; set; }

    }

    public class DeployDetails
    {
        public int DeployScheduleID { get; set; }
        public string Name { get; set; }
        public string Schedule { get; set; }

        public bool DELFG { get; set; }

        public System.DateTime CRTDT { get; set; }

        public string CRTCD { get; set; }

        public System.DateTime UPDDT { get; set; }

        public string UPDCD { get; set; }

        public string IPAddress { get; set; }

    }

    public class FormatDetails
    {
        public int FormatID { get; set; }
        public string Name { get; set; }
        public string RequiredBandWidth { get; set; }

        public bool DELFG { get; set; }

        public System.DateTime CRTDT { get; set; }

        public string CRTCD { get; set; }

        public System.DateTime UPDDT { get; set; }

        public string UPDCD { get; set; }

        public string IPAddress { get; set; }

    }

    public class StreamServerDetails
    {
        public int StreamServerID { get; set; }

        public string SSServer { get; set; }
        public string IPAddress { get; set; }

        public int BelongingSubnet { get; set; }

        public int DeploySchedule { get; set; }

        public int status { get; set; }

      
        public Nullable<System.DateTime> LastDeployDate { get; set; }
        public Nullable<long> LastStatusCheckDateDatetime { get; set; }

        public int DriveCTotal { get; set; }
        public int DriveCFree { get; set; }
        public int DriveDTotal { get; set; }
        public int DriveDFree { get; set; }
        public bool DELFG { get; set; }


        public System.DateTime CRTDT { get; set; }

        public string CRTCD { get; set; }

        public System.DateTime UPDDT { get; set; }

        public string UPDCD { get; set; }

        public string UserIPAddress { get; set; }


    }

    public class StreamServerFormatDetails
    {
        public int StreamServerFormatID { get; set; }

        public string SSFServer { get; set; }

        public int FormatID { get; set; }

        public bool DELFG { get; set; }


        public System.DateTime CRTDT { get; set; }

        public string CRTCD { get; set; }

        public System.DateTime UPDDT { get; set; }

        public string UPDCD { get; set; }

        public string IPAddress { get; set; }

    }
}