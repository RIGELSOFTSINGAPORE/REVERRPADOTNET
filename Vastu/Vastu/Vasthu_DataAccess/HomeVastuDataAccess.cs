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
    public class HomeVastuDataAccess : BaseDataAccess
    {
        public List<MasterHomeVastuContent> GetHomeVastuInformation()
        {
            List<MasterHomeVastuContent> obj = new List<MasterHomeVastuContent>();

            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                obj = AdoHelper.ExecuteReader<MasterHomeVastuContent>(CommandType.Text, "select CONTENT_ID as ContentID,CONTENT_DETAILS as ContentName  from VS_CONTENT_DETAILS where delete_flag='0' and status_id = 4  and CONTENT_ID in(4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,38,39,40,41) order by ContentID", sqlParameters);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return obj;
        }
    }
}
