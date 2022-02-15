using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_Models;
using Vasthu_DataAccess;

namespace Vastu_Business
{
    public class LoginBusiness
    {
        private LoginDataAccess _LoginDataAccess { get; set; }
        public LoginBusiness()
        {
            _LoginDataAccess = new LoginDataAccess();
        }
        public List<Login> Login(string LOGIN_NAME, string LOGIN_PASSWORD)
        {
            try
            {
                return _LoginDataAccess.Login(LOGIN_NAME, LOGIN_PASSWORD);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Login> Forgotten(Login Forgotten)
        {
            try
            {
                return _LoginDataAccess.Forgotten(Forgotten);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //public Login Login(Login login)
        //{
        //    try
        //    {
        //        return _LoginDataAccess.Login(login);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

    }
}
