using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
//using System.Data.Entity;
//using System.Data.Entity.Core;
//using System.Data.Entity.Core.EntityClient;
//using System.Data.Entity.Core.Objects;
//using System.Data.Entity.Infrastructure;
//using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Penna_Common;
using MySql.Data.MySqlClient;

namespace Penna_Data
{
    public class Penna_DataAccessLayer
    {
        readonly Penna_SaleDBContext _dbContext = new Penna_SaleDBContext();

        private string _ConnectionString;

        public Penna_DataAccessLayer(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }




        #region DapperClass
        public List<T> ExecuteSP<T>(string SPName, DynamicParameters parameters)
        {

            using (IDbConnection db = new MySqlConnection(_ConnectionString))
            {
                return db.Query<T>(SPName, parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public T ExecuteSPSingle<T>(string SPName, DynamicParameters parameters)
        {

            using (IDbConnection db = new MySqlConnection(_ConnectionString))
            {
                return db.Query<T>(SPName, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public List<T> ExecuteQuery<T>(string QueryText, DynamicParameters parameters)
        {

            using (IDbConnection db = new MySqlConnection(_ConnectionString))
            {
                return db.Query<T>(QueryText, parameters, commandType: CommandType.Text).ToList();
            }
        }
        public T ExecuteQuerySingle<T>(string QueryText, DynamicParameters parameters)
        {

            using (IDbConnection db = new MySqlConnection(_ConnectionString))
            {
                return db.Query<T>(QueryText, parameters, commandType: CommandType.Text).FirstOrDefault();
            }
        }
        #endregion

        public AuthenticatedUsers IsValidUser(Login obj)
        {
            try
            {
                AuthenticatedUsers AuthenticatedUser = new AuthenticatedUsers();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("UserName", obj.Name);
                parameters.Add("password", obj.password);
                string qurey = "select user_master_pkid,user_name,display_name,role_fkid, Role_Name,lastlogindate ";
                qurey += " from user_master UM ";
                qurey += " left Join role_master RM on UM.role_fkid = RM.Role_Master_PKID ";
                qurey += " where User_Name=@UserName and password=@password and UM.IsActive=1 and RM.IsActive=1 ";

                AuthenticatedUser = ExecuteQuerySingle<AuthenticatedUsers>(qurey, parameters);

                if (AuthenticatedUser != null && AuthenticatedUser.User_Master_PKID > 0)
                {
                    parameters.Add("User_Master_PKID", AuthenticatedUser.User_Master_PKID);
                    parameters.Add("lastlogindate", DateTime.Now);
                    qurey = "";
                    qurey = "Update user_master set lastlogindate=@lastlogindate where  User_Master_PKID=@User_Master_PKID";
                    ExecuteQuerySingle<AuthenticatedUsers>(qurey, parameters);
                }

                return AuthenticatedUser;

            }

            catch (Exception ex)
            {                
                // LogInfo.LogMsg = string.Format("Login / SignIn : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                throw;
            }

        }
        public List<PennaUser_Master> Get_UserMaster()
        {
            List<PennaUser_Master> result = new List<PennaUser_Master>();
            try
            {
                string Query = "";
                Query = "SELECT um.User_Master_PKID  UserId, rm.role_master_PKID RoleId, ";
                Query += " um.User_Name UserName , rm.Role_Name, um.Password ,um.IsActive ";
                Query += "FROM user_master as um ";
                Query += "JOIN role_master as rm ON rm.role_master_PKID=um.role_FKID";
                result = ExecuteQuery<PennaUser_Master>(Query, null);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public List<PennaUser_Master> GetAdminRole()
        {
            List<PennaUser_Master> result = new List<PennaUser_Master>();
            try
            {

                result = ExecuteQuery<PennaUser_Master>("select role_master_PKID as RoleId,Role_Name from role_master;", null);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }

        public PennaUser_Master Get_UserMasterDetails(int? RoleId)
        {
            PennaUser_Master result = new PennaUser_Master();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("User_Master_PKID", RoleId);
                string Query = "";
                Query = "SELECT um.User_Master_PKID UserId, um.Role_FKID RoleId,";
                Query += "um.User_Name UserName, rm.Role_Name, um.Password,um.IsActive";
                Query += " FROM user_master as um  ";
                Query += " JOIN role_master as rm ON rm.role_master_PKID=um.role_FKID";
                Query += " where um.User_Master_PKID=@User_Master_PKID ";

                result = ExecuteQuerySingle<PennaUser_Master>(Query, parameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }
        public int CheckUserName(int UserId, String UserName)
        {
            PennaUser_Master result = new PennaUser_Master();
            int r = 0;
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("User_Master_PKID", UserId);
                parameters.Add("User_Name", UserName);
                string Query = "";
                Query = "SELECT count(*) cnt from user_master ";
                Query += " where User_Master_PKID<>@User_Master_PKID and User_Name=@User_Name";

                r = ExecuteQuerySingle<int>(Query, parameters);
            }
            catch (Exception)
            {

                throw;
            }
            return r;
        }
        public int CreateUserMaster(PennaUser_Master obj)
        {

            string Query = "";
            int result = 1;
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("User_Name", obj.UserName);
                parameters.Add("Password", obj.Password);
                parameters.Add("Display_Name", obj.DisplayName);
                parameters.Add("Role_FKID", obj.RoleId);
                parameters.Add("IsActive", obj.IsActive);
                parameters.Add("Created_By", obj.CreatedBy);
                Query = " Insert Into user_master";

                Query += "(User_Name";
                Query += ", Password";
                Query += ", Display_Name";
                Query += ", Role_FKID";
                Query += ", IsActive";
                Query += ", Created_By";

                Query += ") Values(";
                Query += "@User_Name";
                Query += ", @Password";
                Query += ", @Display_Name";
                Query += ", @Role_FKID";
                Query += ", @IsActive";
                Query += ", @Created_By";
                Query += " )";
                result = ExecuteQuerySingle<int>(Query, parameters);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public int UpdateUserMaster(PennaUser_Master obj)
        {

            string Query = "";
            int result = 1;
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("User_Master_PKID", obj.UserId);
                parameters.Add("User_Name", obj.UserName);
                parameters.Add("Password", obj.Password);
                parameters.Add("Display_Name", obj.UserName);
                parameters.Add("Role_FKID", obj.RoleId);
                parameters.Add("IsActive", obj.IsActive);
                parameters.Add("ModifiedBy", obj.ModifiedBy);
                parameters.Add("ModifiedDate", DateTime.Now);
                Query = " update user_master set";

                Query += " User_Name=@User_Name";
                Query += ", Password=@Password";
                Query += ", Display_Name=@Display_Name";
                Query += ", Role_FKID=@Role_FKID";
                Query += ", IsActive=@IsActive";
                Query += ", Modified_By=@ModifiedBy";
                Query += ", Modified_Date=@ModifiedDate";
                Query += " where User_Master_PKID=@User_Master_PKID";

                result = ExecuteQuerySingle<int>(Query, parameters);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public PennaUser_Master DeleteUser(int? id)
        {
            PennaUser_Master result = new PennaUser_Master();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("User_Master_PKID", id);
                result = ExecuteQuerySingle<PennaUser_Master>("delete from user_master where User_Master_PKID=@User_Master_PKID ", parameters);
                return result;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<Penna_PackerDetails> GetPackerDetails(Penna_PackerDetails penna_PackerDetails)
        {
            List<Penna_PackerDetails> response = new List<Penna_PackerDetails>();
            DynamicParameters parameters = new DynamicParameters();

            string query = "";
            query = "SELECT * from packing_status_details";
            query += " where  packing_Status_details_PKID like '%' ";
            if (penna_PackerDetails != null)
            {
                if (penna_PackerDetails.packing_Status_details_PKID != 0)
                {
                    query += "and packing_Status_details_PKID= @packing_Status_details_PKID";
                    parameters.Add("packing_Status_details_PKID", penna_PackerDetails.packing_Status_details_PKID);
                }
                if (penna_PackerDetails.Delivery_Number != "" && penna_PackerDetails.Delivery_Number != null)
                {
                    query += "and Delivery_Number= @Delivery_Number";
                    parameters.Add("Delivery_Number", penna_PackerDetails.Delivery_Number);
                }
                if (penna_PackerDetails.Status != "" && penna_PackerDetails.Status != null)
                {
                    query += " and Status = @Status";
                    parameters.Add("Status", penna_PackerDetails.Status);
                }
                if (penna_PackerDetails.Start_Date_Time > DateTime.MinValue && penna_PackerDetails.Start_Date_Time != null)
                {
                    query += " and Start_Date_Time = @Start_Date_Time";
                    parameters.Add("Start_Date_Time", penna_PackerDetails.Start_Date_Time);
                }
                if (penna_PackerDetails.End_Date_Time > DateTime.MinValue && penna_PackerDetails.End_Date_Time != null)
                {
                    query += " and End_Date_Time= @End_Date_Time";
                    parameters.Add("End_Date_Time", penna_PackerDetails.End_Date_Time);
                }
                if (penna_PackerDetails.Busted_Bag_Count != 0)
                {
                    query += " and Busted_Bag_Count = @Busted_Bag_Count";
                    parameters.Add("Busted_Bag_Count", penna_PackerDetails.Busted_Bag_Count);
                }
                if (penna_PackerDetails.Packer != 0)
                {
                    query += " and Packer_FKID = @Packer";
                    parameters.Add("Packer", penna_PackerDetails.Packer);
                }
            }
            response = ExecuteQuery<Penna_PackerDetails>(query, parameters);
            return response;
        }
        public List<Penna_ManageSettings> GetIP(string Packer)
        {
            List<Penna_ManageSettings> response = new List<Penna_ManageSettings>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Packer_FKID", Convert.ToInt32(Packer));
            parameters.Add("Packer_FKID1", Convert.ToInt32(Packer));
            string query = "";
            query = "select *, 2 as ips from manage_counters where Packer_FKID = @Packer_FKID1 ";
            query += "Union all ";
            query += "select*, 1 as ips from manage_printers where Packer_FKID =  @Packer_FKID ";

            response = ExecuteQuery<Penna_ManageSettings>(query, parameters);
            return response;
        }

        public int insertpacker(Penna_PackerDetails penna_PackerDetails)
        {
            try
            {
                string Query = "";
                int result = 0;
                int count = 0;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Delivery_Number ", penna_PackerDetails.Delivery_Number);
                parameters.Add("Vehicle_Number", penna_PackerDetails.Vehicle_Number);
                parameters.Add("Message_Format", penna_PackerDetails.Message_Format);
                parameters.Add("MRP", penna_PackerDetails.MRP);
                parameters.Add("Grade", penna_PackerDetails.Grade);
                parameters.Add("Set_Count", penna_PackerDetails.Set_Count);
                parameters.Add("Bag_Count", penna_PackerDetails.Bag_Count);
                parameters.Add("Status_", penna_PackerDetails.Status);
                parameters.Add("IsActive", penna_PackerDetails.IsActive);
                parameters.Add("Created_By", penna_PackerDetails.Created_By);
                //parameters.Add("Created_Date", penna_PackerDetails.Created_Date);

                Query = "Select count(*) from packing_status_details where Delivery_Number='" + penna_PackerDetails.Delivery_Number + "';";
                count = ExecuteQuerySingle<int>(Query, null);
                if (count == 0) { 
                Query = "INSERT INTO `packing_status_details`";
                Query += "(";
                Query += "`Delivery_Number`,";
                Query += "`Vehicle_Number`,";
                Query += "`Message_Format`,";
                Query += "`MRP`,";
                Query += "`Grade`,";
                Query += "`Set_Count`,";
                Query += "`Bag_Count`,";
                Query += "`Status`,";
                Query += "`IsActive`,";
                Query += "`Created_By`";
                Query += ")";
                Query += "VALUES";
                Query += "(";
                Query += "'" + penna_PackerDetails.Delivery_Number;
                Query += "','" + penna_PackerDetails.Vehicle_Number;
                Query += "','" + penna_PackerDetails.Message_Format;
                Query += "','" + penna_PackerDetails.MRP;
                Query += "','" + penna_PackerDetails.Grade;
                Query += "','" + penna_PackerDetails.Set_Count;
                Query += "','" + penna_PackerDetails.Set_Count;
                Query += "','" + penna_PackerDetails.Status;
                Query += "','" + penna_PackerDetails.IsActive;
                Query += "','" + penna_PackerDetails.Created_By;
                Query += "')";

                result = ExecuteQuerySingle<int>(Query, null);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public int Startpacker(Penna_PackerDetails penna_PackerDetails)
        {
            try
            {
                int result = 0;
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("Set_Count", penna_PackerDetails.Set_Count);
                parameters.Add("Status", penna_PackerDetails.Status);
                parameters.Add("Start_Date_Time", penna_PackerDetails.Start_Date_Time);
                parameters.Add("Packer", penna_PackerDetails.Packer);

                string Start_Date_Time = DateTime.Now.ToString("yyyy/MM/dd");
                string Query = "";
                Query = "Update `packing_status_details` set";
                Query += "`Bag_Count`=Bag_Count+1,";
                Query += "`InProgress_Bag_Count`=1,";
                Query += "`Status`='STARTED',";
                Query += "`Packer_FKID`=@Packer,";
                Query += "`Start_Date_Time`='" + Start_Date_Time + "'";
                Query += " where packing_Status_details_PKID=" + penna_PackerDetails.packing_Status_details_PKID;

                result = ExecuteQuerySingle<int>(Query, parameters);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public int Stoppacker(Penna_PackerDetails penna_PackerDetails)
        {
            try
            {
                int result = 1;
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("Set_Count", penna_PackerDetails.Set_Count);
                parameters.Add("Status_", penna_PackerDetails.Status);
                parameters.Add("End_Date_Time", penna_PackerDetails.End_Date_Time);
                string End_Date_Time = DateTime.Now.ToString("yyyy/MM/dd");
                string Query = "";
                Query = "Update `packing_status_details` set";
                Query += "`Status`='STOPED',";
                Query += "`Packer_FKID`=null,";
                Query += "`End_Date_Time`='" + End_Date_Time + "'";
                Query += " where packing_Status_details_PKID=" + penna_PackerDetails.packing_Status_details_PKID;

                result = ExecuteQuerySingle<int>(Query, null);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int InsertManagePrinters(Penna_ManageSettings obj)
        {

            string Query = "";
            int result = 1;
            try
            {
                for (int i = 0; i <= 3; i++)
                {
                    DynamicParameters parameters = new DynamicParameters();
                    string ipadd = "";
                    string port = "";
                    int packerID = 0;
                    if (i <= 0)
                    {
                        ipadd = obj.IP_Address1_Print;
                        port = obj.Port1_Print;
                        packerID = 1;
                    }
                    else if (i <= 1)
                    {
                        ipadd = obj.IP_Address2_Print;
                        port = obj.Port2_Print;
                        packerID = 2;
                    }
                    else if (i <= 2)
                    {
                        ipadd = obj.IP_Address3_Print;
                        port = obj.Port3_Print;
                        packerID = 3;
                    }
                    else if (i <= 3)
                    {
                        ipadd = obj.IP_Address4_Print;
                        port = obj.Port4_Print;
                        packerID = 4;
                    }
                    if (ipadd != "" && port != null && ipadd != null && port != "")
                    {
                        parameters.Add("IP_Address", ipadd);
                        parameters.Add("Port_No", port);
                        parameters.Add("IsActive", obj.IsActive);
                        parameters.Add("Packer_FKID", i + 1);
                        parameters.Add("Modified_By", obj.CreatedBy);
                        parameters.Add("Created_By", obj.CreatedBy);
                        //parameters.Add("Modified_Date", DateTime.Now);
                        parameters.Add("Packer_FKID", packerID);

                        //Query = " Insert Into manage_printers";
                        //Query += "(IP_Address";
                        //Query += ", Port_No";
                        //Query += ", IsActive";
                        //Query += ", Packer_FKID";
                        //Query += ", Created_By";

                        //Query += ") Values(";
                        //Query += " @IP_Address";
                        //Query += ", @Port_No";
                        //Query += ", @IsActive";
                        //Query += ", @Packer_FKID";
                        //Query += ", @Created_By";
                        //Query += " )";


                        Query = " update manage_printers set ";
                        Query += "IP_Address = @IP_Address";
                        Query += ", Port_No =@Port_No";
                        Query += ", IsActive =@IsActive";
                        //Query += ", Packer_FKID =@ Packer_FKID";
                        Query += ", Modified_By =@Modified_By";
                        //Query += ", Modified_Date =@Modified_Date";
                        Query += " where  Packer_FKID =@Packer_FKID";


                        result = ExecuteQuerySingle<int>(Query, parameters);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public int InsertManageCounter(Penna_ManageSettings obj)
        {

            string Query = "";
            int result = 1;
            int Manage_Counters_PKID = 1;
            try
            {
                for (int i = 0; i <= 7; i++)
                {
                    DynamicParameters parameters = new DynamicParameters();
                    string ipadd = "";
                    string port = "";
                    string Packer = "";
                    if (i <= 0)
                    {
                        ipadd = obj.IP_Address1_counter1;
                        port = obj.Port1_counter1;
                        Packer = "1";
                        Manage_Counters_PKID = 1;
                    }
                    else if (i <= 1)
                    {
                        ipadd = obj.IP_Address1_counter2;
                        port = obj.Port1_counter2;
                        Packer = "1";
                        Manage_Counters_PKID = 2;
                    }
                    else if (i <= 2)
                    {
                        ipadd = obj.IP_Address2_counter1;
                        port = obj.Port2_counter1;
                        Packer = "2";
                        Manage_Counters_PKID = 3;
                    }
                    else if (i <= 3)
                    {
                        ipadd = obj.IP_Address2_counter2;
                        port = obj.Port2_counter2;
                        Packer = "2";
                        Manage_Counters_PKID = 4;
                    }
                    else if (i <= 4)
                    {
                        ipadd = obj.IP_Address3_counter1;
                        port = obj.Port3_counter1;
                        Packer = "3";
                        Manage_Counters_PKID = 5;
                    }
                    else if (i <= 5)
                    {
                        ipadd = obj.IP_Address3_counter2;
                        port = obj.Port3_counter2;
                        Packer = "3";
                        Manage_Counters_PKID = 6;
                    }
                    else if (i <= 6)
                    {
                        ipadd = obj.IP_Address4_counter1;
                        port = obj.Port4_counter1;
                        Packer = "4";
                        Manage_Counters_PKID = 7;
                    }
                    else if (i <= 7)
                    {
                        ipadd = obj.IP_Address4_counter2;
                        port = obj.Port4_counter2;
                        Packer = "4";
                        Manage_Counters_PKID = 8;
                    }
                    if (ipadd != "" && port != null && ipadd != null && port != "")
                    {
                        parameters.Add("IP_Address", ipadd);
                        parameters.Add("Port_No", port);
                        parameters.Add("IsActive", obj.IsActive);
                        parameters.Add("Packer_FKID", Packer);
                        parameters.Add("ModifiedBy", obj.ModifiedBy);
                        parameters.Add("ModifiedDate", obj.ModifiedDate);
                        parameters.Add("Manage_Counters_PKID", Manage_Counters_PKID);

                        //Query = " Insert Into manage_counters";
                        //Query += "(IP_Address";
                        //Query += ", Port_No";
                        //Query += ", IsActive";
                        //Query += ", Packer_FKID";
                        //Query += ", Created_By";

                        //Query += ") Values(";
                        //Query += " @IP_Address";
                        //Query += ", @Port_No";
                        //Query += ", @IsActive";
                        //Query += ", @Packer_FKID";
                        //Query += ", @Created_By";
                        //Query += " )";
                        Query = " update manage_counters set";
                        Query += " IP_Address=@IP_Address";
                        Query += ", Port_No=@Port_No";                       
                        Query += ", Modified_By=@ModifiedBy";
                        //Query += ", ModifiedDate=@ModifiedDate";
                        Query += " Where Manage_Counters_PKID=@Manage_Counters_PKID";
                       
                        

                        result = ExecuteQuerySingle<int>(Query, parameters);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public int InsertManageSettings(Penna_ManageSettings obj)
        {

            string Query = "";
            int result = 1;
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                if (obj.Database_Polling_Time != "" && obj.Database_Polling_Time != null &&
                    obj.Polling_Timer_Printer != "" && obj.Polling_Timer_Printer != null &&
                    obj.Polling_Timer_COunter != "" && obj.Polling_Timer_COunter != null)
                {
                    parameters.Add("Database_Polling_Time", obj.Database_Polling_Time);
                    parameters.Add("Polling_Timer_Printer", obj.Polling_Timer_Printer);
                    parameters.Add("Polling_Timer_COunter", obj.Polling_Timer_COunter);
                    parameters.Add("IsActive", obj.IsActive);
                    parameters.Add("ModifiedBy", obj.ModifiedBy);
                    parameters.Add("ModifiedDate", obj.ModifiedDate);
                    parameters.Add("Master_Setting_PKID", 1);

                    //Query = " Insert Into master_setting";
                    //Query += "(Database_Polling_Time";
                    //Query += ", Polling_Timer_Printer";
                    //Query += ", Polling_Timer_COunter";
                    //Query += ", IsActive";
                    //Query += ", Created_By";

                    //Query += ") Values(";
                    //Query += " @Database_Polling_Time";
                    //Query += ", @Polling_Timer_Printer";
                    //Query += ", @Polling_Timer_COunter";
                    //Query += ", @IsActive";
                    //Query += ", @Created_By";
                    //Query += " )";

                    Query = " Update master_setting set";
                    Query += " Database_Polling_Time=@Database_Polling_Time";
                    Query += ", Polling_Timer_Printer=@Polling_Timer_Printer";
                    Query += ", Polling_Timer_COunter=@Polling_Timer_COunter";
                    Query += ", Modified_By=@ModifiedBy";
                    //Query += ", ModifiedDate=@ModifiedDate";
                    Query += " where Master_Setting_PKID=@Master_Setting_PKID";
                   
                    result = ExecuteQuerySingle<int>(Query, parameters);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<Penna_ManageSettings> GetManagePrinter()
        {

            List<Penna_ManageSettings> response = new List<Penna_ManageSettings>();
            DynamicParameters parameters = new DynamicParameters();
            
            string query = "";
            query = "SELECT * from manage_printers";           

            response = ExecuteQuery<Penna_ManageSettings>(query, null);
            return response;
        }
        public List<Penna_ManageSettings> GetManageCounter()
        {

            List<Penna_ManageSettings> response = new List<Penna_ManageSettings>();
            DynamicParameters parameters = new DynamicParameters();

            string query = "";
            query = "SELECT * from manage_counters";

            response = ExecuteQuery<Penna_ManageSettings>(query, null);
            return response;
        }
        public List<Penna_ManageSettings> GetManageSetting()
        {
            List<Penna_ManageSettings> response = new List<Penna_ManageSettings>();
            DynamicParameters parameters = new DynamicParameters();
            string query = "";
            query = "SELECT * from master_setting";
            response = ExecuteQuery<Penna_ManageSettings>(query, null);
            return response;
        }
        public List<Penna_PackerDetails> GetBustedbag(Penna_PackerDetails obj)
        {
            List<Penna_PackerDetails> response = new List<Penna_PackerDetails>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Packer", obj.Packer);
            parameters.Add("setcount", obj.Busted_Bag_Count);
            string query = "";
            query = "SELECT * from packing_status_details where Packer_FKID="+ obj.Packer;
            response = ExecuteQuery<Penna_PackerDetails>(query, parameters);
            return response;
        }
    }
}
