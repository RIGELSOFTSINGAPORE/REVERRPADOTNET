using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_Models;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Vasthu_DataAccess
{
    public class VastuTypeMasterDataAccess : BaseDataAccess
    {
        private string VastuTypeQuery(int vastutypeID)
        {
            string strcmd = "";

            strcmd += "Select M.VASTU_TYPE_ID,M.VASTU_TYPE,";
            strcmd += "M.DELETE_FLAG,C.LOGIN_NAME CREATED_USER_NAME,M.CREATED_DATE C_USER_DATE,";
            strcmd += "U.LOGIN_NAME UPDATED_USER_NAME, M.UPDATED_DATE U_USER_DATE";
            strcmd += " From  VS_VASTU_TYPE_MST M ";
            strcmd += " Left Join VS_USER_MST C on C.USER_ID = M.CREATED_USER ";
            strcmd += " Left Join VS_USER_MST U on U.USER_ID = M.UPDATED_USER ";
            if (vastutypeID != 0)
            {
                strcmd += " Where M.VASTU_TYPE_ID = @vastutypeID";
            }
            strcmd += " ORDER BY M.VASTU_TYPE_ID DESC ";

            return strcmd;
        }

       
   
        public List<VS_VASTU_TYPE_MST> GetAllVastuType()
        {
            string strcmd = "";
            List<VS_VASTU_TYPE_MST> obj = new List<VS_VASTU_TYPE_MST>();
            try
            {
                
                strcmd = VastuTypeQuery(0);
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                obj = AdoHelper.ExecuteReader<VS_VASTU_TYPE_MST>(CommandType.Text, strcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;
       
            }
            return obj;

        }
        public VS_VASTU_TYPE_MST GetVastuTypeByID(int vastutypeID)
        {
            string strcmd = "";
            VS_VASTU_TYPE_MST obj = new VS_VASTU_TYPE_MST();
            try
            {
  
                strcmd = VastuTypeQuery(vastutypeID);
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@vastutypeID", vastutypeID);
                sqlParameters.Add(p1);
                obj = AdoHelper.ExecuteReaderSingle<VS_VASTU_TYPE_MST>(CommandType.Text, strcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;
       
            }
            return obj;

        }

        public List<VS_VASTU_TYPE_MST> CheckVastuTypeDetail(string VastuTypedetail, int VastuTypeid)
        {
            List<VS_VASTU_TYPE_MST> obj = new List<VS_VASTU_TYPE_MST>();
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                if (VastuTypeid == 0)
                {
                    SqlParameter p1 = new SqlParameter("@VastuTypedetail", VastuTypedetail);
                    sqlParameters.Add(p1);
                    obj = AdoHelper.ExecuteReader<VS_VASTU_TYPE_MST>(CommandType.Text, "select VASTU_TYPE_ID,VASTU_TYPE from VS_VASTU_TYPE_MST Where VASTU_TYPE = @VastuTypedetail", sqlParameters);
                }
                else
                {
                    SqlParameter p1 = new SqlParameter("@VastuTypedetail", VastuTypedetail);
                    SqlParameter p2 = new SqlParameter("@VastuTypeid", VastuTypeid);
                    sqlParameters.Add(p1);
                    sqlParameters.Add(p2);
                    obj = AdoHelper.ExecuteReader<VS_VASTU_TYPE_MST>(CommandType.Text, "select VASTU_TYPE_ID,VASTU_TYPE from VS_VASTU_TYPE_MST Where VASTU_TYPE = @VastuTypedetail and VASTU_TYPE_ID != @VastuTypeid", sqlParameters);
                }


            }
            catch (Exception ex)
            {
                throw ex;
 
            }
            return obj;
        }

        public int CreateVastuType(VS_VASTU_TYPE_MST vastutypemst)
        {
            int result = 0;
   
            try
            {
                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@VASTU_TYPE", vastutypemst.VASTU_TYPE);
                SqlParameter p2 = new SqlParameter("@STATUS_ID", vastutypemst.STATUS_ID);
                SqlParameter p3 = new SqlParameter("@DELETE_FLAG", vastutypemst.DELETE_FLAG);
                SqlParameter p4 = new SqlParameter("@CREATED_USER", vastutypemst.CREATED_USER);
                SqlParameter p5 = new SqlParameter("@CREATED_DATE", c.dt);
   

                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                sqlParameters.Add(p3);
                sqlParameters.Add(p4);
                sqlParameters.Add(p5);
           

           

                string sqlcmd = "insert into VS_VASTU_TYPE_MST(VASTU_TYPE,STATUS_ID,";
                sqlcmd += "DELETE_FLAG,CREATED_USER,CREATED_DATE) values(@VASTU_TYPE,";
                sqlcmd +="@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE)";
                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;
   
            }
            return result;
       
        }

        public int UpdateVastuType(VS_VASTU_TYPE_MST vastutypemst)
        {
            int result = 0;
    
            try
            {
                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@VASTU_TYPE", vastutypemst.VASTU_TYPE);
                SqlParameter p2 = new SqlParameter("@STATUS_ID", vastutypemst.STATUS_ID);
                SqlParameter p3 = new SqlParameter("@DELETE_FLAG", vastutypemst.DELETE_FLAG);
                SqlParameter p4 = new SqlParameter("@UPDATED_USER", vastutypemst.UPDATED_USER);
                SqlParameter p5 = new SqlParameter("@UPDATED_DATE", c.dt);
                SqlParameter p6 = new SqlParameter("@VASTU_TYPE_ID", vastutypemst.VASTU_TYPE_ID);

                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                sqlParameters.Add(p3);
                sqlParameters.Add(p4);
                sqlParameters.Add(p5);
                sqlParameters.Add(p6);
       

                string sqlcmd = "Update VS_VASTU_TYPE_MST set VASTU_TYPE = @VASTU_TYPE,";
                sqlcmd += "STATUS_ID=@STATUS_ID,";
                sqlcmd += "DELETE_FLAG=@DELETE_FLAG,UPDATED_USER=@UPDATED_USER,UPDATED_DATE=@UPDATED_DATE";
                sqlcmd += " Where VASTU_TYPE_ID =@VASTU_TYPE_ID";



                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);
      


            }
            catch (Exception ex)
            {
                throw ex;
         
            }
            return result;
        }
    }
}
