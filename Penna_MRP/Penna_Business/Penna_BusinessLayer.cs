using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Penna_Data;
using Penna_Common;
using System.Data;

namespace Penna_Business
{
    public class Penna_BusinessLayer
    {
        private Penna_DataAccessLayer _PennaDataAccessLayer { get; set; }

        //private string _ConnectionString;

        public Penna_BusinessLayer(string ConnectionString)
        {
            _PennaDataAccessLayer = new Penna_DataAccessLayer(ConnectionString);
        }


        public AuthenticatedUsers IsValidUser(Login login)
        {
            try
            {
                return _PennaDataAccessLayer.IsValidUser(login);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<PennaUser_Master> Get_UserMaster()
        {
            try
            {
                return _PennaDataAccessLayer.Get_UserMaster();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<PennaUser_Master> GetAdminRole()
        {
            try
            {
                return _PennaDataAccessLayer.GetAdminRole();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PennaUser_Master Get_UserMasterDetails(int? RoleId)
        {
            try
            {
                return _PennaDataAccessLayer.Get_UserMasterDetails(RoleId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int CheckUname(int UserID, string UserName)
        {
            try
            {
                return _PennaDataAccessLayer.CheckUserName(UserID, UserName);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int UpdateUserMaster(PennaUser_Master _PennaUser_Master)
        {
            try
            {
                return _PennaDataAccessLayer.UpdateUserMaster(_PennaUser_Master);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int CreateUserMaster(PennaUser_Master obj)
        {
            try
            {
                return _PennaDataAccessLayer.CreateUserMaster(obj);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PennaUser_Master DeleteUser(int? id)
        {
            try
            {
                return _PennaDataAccessLayer.DeleteUser(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Penna_PackerDetails> GetPackerDetails(Penna_PackerDetails penna_PackerDetails)
        {
            return _PennaDataAccessLayer.GetPackerDetails(penna_PackerDetails);
        }
        public List<Penna_PackerDetails> GetBustedbag(Penna_PackerDetails penna_PackerDetails)
        {
            return _PennaDataAccessLayer.GetBustedbag(penna_PackerDetails);
        }
        public List<Penna_ManageSettings> GetIP(string packer_id)
        {
            return _PennaDataAccessLayer.GetIP(packer_id);
        }
        public int insertpacker(Penna_PackerDetails penna_PackerDetails)
        {
            return _PennaDataAccessLayer.insertpacker(penna_PackerDetails);
        }
        public int Startpacker(Penna_PackerDetails penna_PackerDetails)
        {
            return _PennaDataAccessLayer.Startpacker(penna_PackerDetails);
        }
        public int Stoppacker(Penna_PackerDetails penna_PackerDetails)
        {
            return _PennaDataAccessLayer.Stoppacker(penna_PackerDetails);
        }
        public int InsertManagePrinters(Penna_ManageSettings _Penna_ManageSettings)
        {
            return _PennaDataAccessLayer.InsertManagePrinters(_Penna_ManageSettings);
        }
        public int InsertManageSettings(Penna_ManageSettings _Penna_ManageSettings)
        {
            return _PennaDataAccessLayer.InsertManageSettings(_Penna_ManageSettings);
        }
        public int InsertManageCounter(Penna_ManageSettings _Penna_ManageSettings)
        {
            return _PennaDataAccessLayer.InsertManageCounter(_Penna_ManageSettings);
        }
        public List<Penna_ManageSettings> GetManageSetting()
        {
            return _PennaDataAccessLayer.GetManageSetting();
        }
        public List<Penna_ManageSettings> GetManageCounter()
        {
            return _PennaDataAccessLayer.GetManageCounter();
        }
        public List<Penna_ManageSettings> GetManagePrinter()
        {
            return _PennaDataAccessLayer.GetManagePrinter();
        }
    }


}
