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
    public class AboutDataAccess : BaseDataAccess
    {
        public List<MasterAboutContent> GetAboutPageInformation()
        {
            List<MasterAboutContent> obj = new List<MasterAboutContent>();

            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                obj = AdoHelper.ExecuteReader<MasterAboutContent>(CommandType.Text, "select CONTENT_ID as ContentID,CONTENT_DETAILS as ContentName  from VS_CONTENT_DETAILS where delete_flag='0' and status_id = 4  and CONTENT_ID in (21) order by ContentID", sqlParameters);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return obj;
        }
    }
}
