using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_Models;
using Vasthu_DataAccess;

namespace Vastu_Business
{
    public class UserVastuBusinessLayer
    {
        private UserVastuDataAccess _UserDataAccess { get; set; }

        public UserVastuBusinessLayer()
        {
            _UserDataAccess = new UserVastuDataAccess();
        }

        public List<USER_MST> GetUser()
        {
            try
            {
                return _UserDataAccess.GetUser();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public List<USER_MST> CreateUser(USER_MST Usermst)
        {
            try
            {
                return _UserDataAccess.CreateUser(Usermst);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<USER_MST> Update(int ID)
        {
            try
            {
                return _UserDataAccess.Update(ID);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<USER_MST> UpdateDetails(USER_MST Update)
        {
            try
            {
                return _UserDataAccess.UpdateDetails(Update);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
