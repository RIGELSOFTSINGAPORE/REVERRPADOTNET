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
   public class ContactContentDataAccess : BaseDataAccess
    {
        public List<MasterContent> GetHomePageInformation()
        {
            List<MasterContent> obj = new List<MasterContent>();

            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                obj = AdoHelper.ExecuteReader<MasterContent>(CommandType.Text, "select CONTENT_ID as ContentID,CONTENT_DETAILS as ContentName  from VS_CONTENT_DETAILS where  status_id = 4  and CONTENT_ID in (42,44,45) order by ContentID", sqlParameters);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return obj;
        }
    }
}
