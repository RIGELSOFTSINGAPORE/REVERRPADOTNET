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
    public class ImageMasterDataAccess : BaseDataAccess
    {
        private string ImageQuery(int imageID)
        {
            string strcmd = "";

            strcmd += "Select M.IMAGE_ID,M.IMAGE_DETAILS,M.IMAGE_URL,M.IMAGE_SYMBOL,";
            strcmd += "M.DELETE_FLAG,C.LOGIN_NAME CREATED_USER_NAME,M.CREATED_DATE C_USER_DATE,";
            strcmd += "U.LOGIN_NAME UPDATED_USER_NAME, M.UPDATED_DATE U_USER_DATE";
            strcmd += " From  VS_IMAGE_MST M ";
            strcmd += " Left Join VS_USER_MST C on C.USER_ID = M.CREATED_USER ";
            strcmd += " Left Join VS_USER_MST U on U.USER_ID = M.UPDATED_USER ";
            if (imageID != 0)
            {
                strcmd += " Where M.IMAGE_ID = @imageID";
            }
            strcmd += " ORDER BY M.IMAGE_ID DESC ";

            return strcmd;
        }

        private string ImageList()
        {
            string strcmd = "";

            strcmd += "Select M.IMAGE_ID,M.IMAGE_URL,M.IMAGE_DETAILS,M.IMAGE_SYMBOL";
            strcmd += " From  VS_IMAGE_MST M ";
            strcmd += " Where STATUS_ID = 4 and DELETE_FLAG = 0";
            strcmd += " ORDER BY M.IMAGE_ID";

            return strcmd;
        }
        public List<VS_IMAGE_MST> GetAllImageList()
        {
            string strcmd = "";
            List<VS_IMAGE_MST> obj = new List<VS_IMAGE_MST>();
            try
            {
                
                strcmd = ImageList();
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                obj = AdoHelper.ExecuteReader<VS_IMAGE_MST>(CommandType.Text, strcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;
                

            }
            return obj;

        }
        public List<VS_IMAGE_MST> GetAllImage()
        {
            string strcmd = "";
            List<VS_IMAGE_MST> obj = new List<VS_IMAGE_MST>();
            try
            {
                
                strcmd = ImageQuery(0);
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                obj = AdoHelper.ExecuteReader<VS_IMAGE_MST>(CommandType.Text, strcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;
             

            }
            return obj;

        }
        public VS_IMAGE_MST GetImageByID(int imageID)
        {
            string strcmd = "";
            VS_IMAGE_MST obj = new VS_IMAGE_MST();
            try
            {
  
                strcmd = ImageQuery(imageID);
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter p1 = new SqlParameter("@imageID", imageID);
                sqlParameters.Add(p1);
                obj = AdoHelper.ExecuteReaderSingle<VS_IMAGE_MST>(CommandType.Text, strcmd, sqlParameters);


            }
            catch (Exception ex)
            {
                throw ex;
               

            }
            return obj;

        }

        public List<VS_IMAGE_MST> CheckImageDetail(string imagedetail, int imageid)
        {
            List<VS_IMAGE_MST> obj = new List<VS_IMAGE_MST>();
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                if (imageid == 0)
                {
                    SqlParameter p1 = new SqlParameter("@imagedetail", imagedetail);
                    sqlParameters.Add(p1);
                    obj = AdoHelper.ExecuteReader<VS_IMAGE_MST>(CommandType.Text, "select IMAGE_ID,IMAGE_DETAILS from VS_IMAGE_MST Where IMAGE_DETAILS = @imagedetail", sqlParameters);
                }
                else
                {
                    SqlParameter p1 = new SqlParameter("@imagedetail", imagedetail);
                    SqlParameter p2 = new SqlParameter("@imageid", imageid);
                    sqlParameters.Add(p1);
                    sqlParameters.Add(p2);
                    obj = AdoHelper.ExecuteReader<VS_IMAGE_MST>(CommandType.Text, "select IMAGE_ID,IMAGE_DETAILS from VS_IMAGE_MST Where IMAGE_DETAILS = @imagedetail and IMAGE_ID != @imageid", sqlParameters);
                }


            }
            catch (Exception ex)
            {
                throw ex;
 
            }
            return obj;
        }

        public int CreateImage(VS_IMAGE_MST imagemst)
        {
            int result = 0;
            
            try
            {
                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@IMAGE_DETAILS", imagemst.IMAGE_DETAILS);
                SqlParameter p2 = new SqlParameter("@IMAGE_URL", imagemst.IMAGE_URL);

        
                SqlParameter p3 = new SqlParameter("@STATUS_ID", imagemst.STATUS_ID);

                SqlParameter p4 = new SqlParameter("@DELETE_FLAG", imagemst.DELETE_FLAG);

                SqlParameter p5 = new SqlParameter("@CREATED_USER", imagemst.CREATED_USER);
                SqlParameter p6 = new SqlParameter("@CREATED_DATE", c.dt);
                SqlParameter p7 = new SqlParameter("@IMAGE_SYMBOL", imagemst.IMAGE_SYMBOL);


                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                sqlParameters.Add(p3);
                sqlParameters.Add(p4);
                sqlParameters.Add(p5);
                sqlParameters.Add(p6);
                sqlParameters.Add(p7);


                string sqlcmd = "insert into VS_IMAGE_MST(IMAGE_DETAILS,IMAGE_URL,STATUS_ID,";
                sqlcmd += "DELETE_FLAG,CREATED_USER,CREATED_DATE,IMAGE_SYMBOL) values(@IMAGE_DETAILS,@IMAGE_URL,";
                sqlcmd += "@STATUS_ID,@DELETE_FLAG,@CREATED_USER,@CREATED_DATE,@IMAGE_SYMBOL)";
                result = AdoHelper.ExecuteNonQuery(CommandType.Text, sqlcmd, sqlParameters);
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
            return result;
           
        }

        public int UpdateImage(VS_IMAGE_MST imagemst)
        {
            int result = 0;
            
            try
            {
                Common c = new Common();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                SqlParameter p1 = new SqlParameter("@IMAGE_DETAILS", imagemst.IMAGE_DETAILS);
                SqlParameter p2 = new SqlParameter("@IMAGE_URL", imagemst.IMAGE_URL);


                SqlParameter p3 = new SqlParameter("@STATUS_ID", imagemst.STATUS_ID);

                SqlParameter p4 = new SqlParameter("@DELETE_FLAG", imagemst.DELETE_FLAG);

                SqlParameter p5 = new SqlParameter("@UPDATED_USER", imagemst.UPDATED_USER);
                SqlParameter p6 = new SqlParameter("@UPDATED_DATE", c.dt);
                SqlParameter p7 = new SqlParameter("@IMAGE_ID", imagemst.IMAGE_ID);
                SqlParameter p8 = new SqlParameter("@IMAGE_SYMBOL", imagemst.IMAGE_SYMBOL);

                sqlParameters.Add(p1);
                sqlParameters.Add(p2);
                sqlParameters.Add(p3);
                sqlParameters.Add(p4);
                sqlParameters.Add(p5);
                sqlParameters.Add(p6);
                sqlParameters.Add(p7);
                sqlParameters.Add(p8);

                string sqlcmd = "Update VS_IMAGE_MST set IMAGE_DETAILS = @IMAGE_DETAILS,IMAGE_URL=@IMAGE_URL,";
                sqlcmd += "STATUS_ID=@STATUS_ID,";
                sqlcmd += "DELETE_FLAG=@DELETE_FLAG,UPDATED_USER=@UPDATED_USER,UPDATED_DATE=@UPDATED_DATE,IMAGE_SYMBOL=@IMAGE_SYMBOL";
                sqlcmd += " Where IMAGE_ID =@IMAGE_ID";



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
