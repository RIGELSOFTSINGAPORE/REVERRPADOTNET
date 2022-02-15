using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Vasthu_Models;

namespace Vasthu_DataAccess
{
    public class SearchVastuDataAccess : BaseDataAccess
    {
        #region Search Vastu
        public List<TypeVasthu> Type()
        {
            List<TypeVasthu> obj = new List<TypeVasthu>();
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                obj = AdoHelper.ExecuteReader<TypeVasthu>(CommandType.Text, "select VASTU_TYPE, VASTU_TYPE_ID from VS_VASTU_TYPE_MST where delete_flag='0' and status_id=4", sqlParameters);
                return obj;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion
        public List<AreaVasthu> Area()
        {
            List<AreaVasthu> obj = new List<AreaVasthu>();
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();


                obj = AdoHelper.ExecuteReader<AreaVasthu>(CommandType.Text, "select AREA,AREA_JN,AREA_ID,AREA_JN from VS_AREA_MST where delete_flag='0' and status_id=4 order by AREA asc", sqlParameters);



                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DirctionVasthu> Direction()
        {
            List<DirctionVasthu> obj = new List<DirctionVasthu>();
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                obj = AdoHelper.ExecuteReader<DirctionVasthu>(CommandType.Text, "select DIRECTION,DIRECTION_ID,DIRECTION_JN from VS_DIRECTION_MST where delete_flag='0' and status_id=4 order by DIRECTION_id asc", sqlParameters);
                return obj;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
       

        public List<Vasthumst> Getvalues(int aidvalue, int didvalue)
        {

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            try
            {
                SqlParameter p1 = new SqlParameter("@AREA_ID", aidvalue);
                SqlParameter p2 = new SqlParameter("@DIRECTION_ID", didvalue);
                //SqlParameter p3 = new SqlParameter("@VASTU_TYPE_ID", vidvalue);


                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                //sqlParameters.Add(p3);


                List<Vasthumst> obj = new List<Vasthumst>();

                //obj = AdoHelper.ExecuteReader<Vasthumst>(CommandType.Text, "Select VVM.LONG_DESCRIPTION, VSM.SCORE_TEXT, VSM.SCORE_ID from VS_VASTU_MST  as VVM inner join VS_SCORE_MST as VSM on VVM.SCORE_ID = VSM.SCORE_ID  where VVM.AREA_ID = @AREA_ID AND VVM.DIRECTION_ID = @DIRECTION_ID  AND VVM.delete_flag='0' and VVM.status_id=4 ", sqlParameters);

                obj = AdoHelper.ExecuteReader<Vasthumst>(CommandType.Text, "Select VSA.COMMENTS, VSM.SCORE_TEXT, VSM.SCORE_ID,VIM.IMAGE_URL from VS_VASTU_MST  as VVM join VS_SCORE_MST as VSM on VVM.SCORE_ID = VSM.SCORE_ID join VS_IMAGE_MST as VIM on VIM.IMAGE_ID = VSM.IMAGE_ID join vs_area_mst as VSA on VVM.AREA_ID = vsa.AREA_ID join VS_DIRECTION_MST as VDM on vvm.DIRECTION_ID = vdm.DIRECTION_ID where VVM.AREA_ID = @AREA_ID AND VVM.DIRECTION_ID = @DIRECTION_ID  AND VVM.delete_flag = '0' and VVM.status_id = 4 ", sqlParameters);



                return obj;



            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

    }
}
