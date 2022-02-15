using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_DataAccess;
using Vasthu_Models;

namespace Vastu_Business
{
    
    public class UserMasterBusinessLayer
    {
        private UserMasterDataAccess _UserMasterDataAccess { get; set; }
        public UserMasterBusinessLayer()
        {
            _UserMasterDataAccess = new UserMasterDataAccess();
        }

        public List<VS_USER_MST> GetAllUser()
        {
            List<VS_USER_MST> obj = new List<VS_USER_MST>();
            try
            {
                
                

                obj = _UserMasterDataAccess.GetAllUser();


            }
            catch (Exception ex)
            {
                throw ex;
                

            }
            return obj;
        }

        public VS_USER_MST GetUserByID(decimal userID)
        {
            VS_USER_MST obj = new VS_USER_MST();
            try
            {


                obj = _UserMasterDataAccess.GetUserByID(userID);

            }
            catch (Exception ex)
            {
                throw ex;
                
            }
            return obj;


        }

        public int CreateUser(VS_USER_MST usermst)
        {
            int result = 0;
            try
            {
                //if(usermst.LOGIN_CONFIRM_PASSWORD != usermst.LOGIN_PASSWORD)
                //{
                //    result = 15;
                //    return result;
                //}
                
                List<VS_USER_MST> umst = new List<VS_USER_MST>();
                
                umst = _UserMasterDataAccess.CheckUserName(usermst.LOGIN_NAME,0);

                if(umst.Count > 0)
                {
                    result = 16;
                    return result;
                }

                result = _UserMasterDataAccess.CreateUser(usermst);
            }
            catch (Exception ex)
            {
                throw ex;
              
            }
            return result;
        }

        public int UpdateUser(VS_USER_MST usermst)
        {
            int result = 0;
            try
            {
                //if (usermst.LOGIN_CONFIRM_PASSWORD != usermst.LOGIN_PASSWORD)
                //{
                //    result = 15;
                //    return result;
                //}

                List<VS_USER_MST> umst = new List<VS_USER_MST>();

                umst = _UserMasterDataAccess.CheckUserName(usermst.LOGIN_NAME, usermst.USER_ID);

                if (umst.Count > 0)
                {
                    result = 16;
                    return result;
                }


                result = _UserMasterDataAccess.UpdateUser(usermst);

            }
            catch (Exception ex)
            {
                throw ex;
                
            }
            return result;
        }
    }
}
