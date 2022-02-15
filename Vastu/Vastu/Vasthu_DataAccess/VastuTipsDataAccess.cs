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
    public class VastuTipsDataAccess : BaseDataAccess
    {
        
        public List<MasterVastuTipsContent> GetVastuTipsInformation()
        {
            List<MasterVastuTipsContent> obj = new List<MasterVastuTipsContent>();

            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                obj = AdoHelper.ExecuteReader<MasterVastuTipsContent>(CommandType.Text, "select CONTENT_ID as ContentID,CONTENT_DETAILS as ContentName  from VS_CONTENT_DETAILS where delete_flag='0' and status_id = 4  and CONTENT_ID in(22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37) order by ContentID", sqlParameters);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return obj;
        }
    }
}
