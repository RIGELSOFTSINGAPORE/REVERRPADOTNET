using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Vasthu_Models
{
    public class AreaVasthu
    {
        [Required(ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.selectArea))]
       
        public int AREA_ID { get; set; }
        public string AREA { get; set; }

        public string AREA_JN { get; set; }



    }
    public class DirctionVasthu
    {
        [Required(ErrorMessageResourceType = typeof(Vastu.Resources.Resource), ErrorMessageResourceName = nameof(Vastu.Resources.Resource.SelectDirection))]
        public int DIRECTION_ID { get; set; }
        public string DIRECTION { get; set; }
        public string DIRECTION_JN { get; set; }


    }

    public class TypeVasthu
    {

        public string VASTU_TYPE { get; set; }
        public int VASTU_TYPE_ID { get; set; }
       


    }


    public class Vasthumst
    {
        public int VASTU_ID { get; set; }
        public int AREA_ID { get; set; }
        public int DIRECTION_ID { get; set; }
        public int VASTU_TYPE_ID { get; set; }
        public int SCORE_ID { get; set; }
        public string EXTRA_SCORE { get; set; }
        public string SHORT_DESCRIPTION { get; set; }
        public string LONG_DESCRIPTION { get; set; }
        public int STATUS_ID { get; set; }
        public string DELETE_FLAG { get; set; }
        public string CREATED_USER { get; set; }
        public string CREATED_DATE { get; set; }
        public string UPDATED_USER { get; set; }
        public string UPDATED_DATE { get; set; }
        public string SCORE_TEXT { get; set; }
        public string COMMENTS { get; set; }

        public string IMAGE_URL { get; set; }

    }

    public class ScoreMaster
    {
        public int SCORE_ID { get; set; }
        public string SCORE_TEXT { get; set; }
        public string SCORE { get; set; }
        public int STATUS_ID { get; set; }
        public string DELETE_FLAG { get; set; }
        public string CREATED_USER { get; set; }
        public string UPDATED_USER { get; set; }
        public string UPDATED_DATE { get; set; }
    }
    public class VastuMaster
    {
        public int VASTU_ID { get; set; }
        public int AREA_ID { get; set; }
        public int DIRECTION_ID { get; set; }
        public int VASTU_TYPE_ID { get; set; }
        public int SCORE_ID { get; set; }
        public string EXTRA_SCORE { get; set; }
        public string SHORT_DESCRIPTION { get; set; }
        public string LONG_DESCRIPTION { get; set; }
        public int STATUS_ID { get; set; }
        public int DELETE_FLAG { get; set; }
        public string CREATED_USER { get; set; }
        public string CREATED_DATE { get; set; }
        public string UPDATED_USER { get; set; }
        public string UPDATED_DATE { get; set; }
    }




    public class ViewModel
    {
        public Vasthumst ShowThumbnail { get; set; }
        public AreaVasthu AreaVasthuDetail { get; set; }
        public DirctionVasthu DirctionVasthuDetail { get; set; }
        public TypeVasthu TypeVasthuDetail { get; set; }

        public List<AreaVasthu> lstViewModelAreaVasthu { get; set; }

        public List<DirctionVasthu> lstViewModelDirctionVasthu { get; set; }

        public List<TypeVasthu> lstViewModelTypeVasthu { get; set; }

        public List<Vasthumst> lstViewModelVasthumst { get; set; }

    }

   
}
