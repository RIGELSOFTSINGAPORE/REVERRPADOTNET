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
using Kaisokku_Common;

namespace Kaisokku_Data
{
    public class Kaisokku_DataAccessLayer
    {
        readonly Kaisokku_SaleDBContext _dbContext = new Kaisokku_SaleDBContext();

        private string _ConnectionString;

        public Kaisokku_DataAccessLayer(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }




        #region Menu Management

        public List<Menu> GetMenus(string UserId)
        {
            var param1 = new SqlParameter
            {
                ParameterName = "@UserId",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = UserId
            };
            List<Menu> lstmenus = new List<Menu>();
            //lstmenus= _dbContext.Database.SqlQuery<Menu>("EXEC [dbo].[usp_GetMenuData] @UserId", param1).ToList();
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("UserId", UserId, DbType.Int32, ParameterDirection.Input);
            lstmenus = ExecuteSP<Menu>("usp_GetMenuData", parameter);

            return lstmenus;
        }


        public OutPut AddNewMenu(AddDynamicMenu dynamicmenu)
        {
            OutPut result = new OutPut();
            try
            {
                //var param1 = new SqlParameter
                //{
                //    ParameterName = "@MenuName",
                //    SqlDbType = SqlDbType.VarChar,
                //    Direction = ParameterDirection.Input,
                //    Value = dynamicmenu.MenuName,
                //};
                //var param2 = new SqlParameter
                //{
                //    ParameterName = "@ControllerName",
                //    SqlDbType = SqlDbType.VarChar,
                //    Direction = ParameterDirection.Input,
                //    Value = dynamicmenu.ControllerName,
                //};

                //var param3 = new SqlParameter
                //{
                //    ParameterName = "@ActionMethod",
                //    SqlDbType = SqlDbType.VarChar,
                //    Direction = ParameterDirection.Input,
                //    Value = dynamicmenu.ActionMethod,
                //};
                //var param4 = new SqlParameter
                //{
                //    ParameterName = "@MenuParentId",
                //    SqlDbType = SqlDbType.Int,
                //    Direction = ParameterDirection.Input,
                //    Value = dynamicmenu.MenuParentId,
                //};
                //var param5 = new SqlParameter
                //{
                //    ParameterName = "@IsActive",
                //    SqlDbType = SqlDbType.Bit,
                //    Direction = ParameterDirection.Input,
                //    Value = dynamicmenu.MenuParentId,
                //};
                //var param6 = new SqlParameter
                //{
                //    ParameterName = "@RoleId",
                //    SqlDbType = SqlDbType.Int,
                //    Direction = ParameterDirection.Input,
                //    Value = dynamicmenu.RoleId,
                //};

                //var param7 = new SqlParameter
                //{
                //    ParameterName = "@IpAddress",
                //    SqlDbType = SqlDbType.VarChar,
                //    Direction = ParameterDirection.Input,
                //    Value = dynamicmenu.IpAddress,
                //};

                //var param8 = new SqlParameter
                //{
                //    ParameterName = "@createddate",
                //    SqlDbType = SqlDbType.DateTime,
                //    Direction = ParameterDirection.Input,
                //    Value = dynamicmenu.createddate,
                //};
                //var param9 = new SqlParameter
                //{
                //    ParameterName = "@createdby",
                //    SqlDbType = SqlDbType.VarChar,
                //    Direction = ParameterDirection.Input,
                //    Value = dynamicmenu.createdby,
                //};

                //var param10 = new SqlParameter
                //{
                //    ParameterName = "@updateddate",
                //    SqlDbType = SqlDbType.DateTime,
                //    Direction = ParameterDirection.Input,
                //    Value = dynamicmenu.updateddate,
                //};

                //var param11 = new SqlParameter
                //{
                //    ParameterName = "@updatedby",
                //    SqlDbType = SqlDbType.VarChar,
                //    Direction = ParameterDirection.Input,
                //    Value = dynamicmenu.updatedby,
                //};

                //var param12 = new SqlParameter
                //{
                //    ParameterName = "@Result",
                //    SqlDbType = SqlDbType.Int,
                //    Direction = ParameterDirection.Output,
                //};


                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("MenuName", dynamicmenu.MenuName);
                parameter.Add("ControllerName", dynamicmenu.ControllerName);
                parameter.Add("ActionMethod", dynamicmenu.ActionMethod);
                parameter.Add("MenuParentId", dynamicmenu.MenuParentId);
                parameter.Add("IsActive", dynamicmenu.IsActive);
                parameter.Add("RoleId", dynamicmenu.RoleId);
                parameter.Add("IpAddress", dynamicmenu.IpAddress);
                parameter.Add("createddate", dynamicmenu.createddate);
                parameter.Add("createdby", dynamicmenu.createdby);
                parameter.Add("updateddate", dynamicmenu.updateddate);
                parameter.Add("updatedby", dynamicmenu.updatedby);

                result = ExecuteSPSingle<OutPut>("AddDynamicMenu", parameter);


                //var result = _dbContext.Database.ExecuteSqlCommand(" exec [AddDynamicMenu] @MenuName,@ControllerName,@ActionMethod,@MenuParentId,@IsActive,@RoleId," +
                //    "@IpAddress,@createddate,@createdby,@updateddate,@updatedby,       @Result OUT", param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12);
                //return Convert.ToInt32(param12.Value);

            }

            catch (Exception)
            {
                throw;
            }
            return result;

        }

        public List<ShowMenuGrid> GetMenusToGrid()
        {
            List<ShowMenuGrid> lstmenus = new List<ShowMenuGrid>();
            lstmenus = ExecuteQuery<ShowMenuGrid>("SELECT MenuId,MenuName,CreatedBy,IpAddress  FROM MenuMaster WHERE ControllerName='Home' AND ActionMethod='PageManagement' AND MenuParentId=7 ", null);
            return lstmenus;
        }

        public EditMenuDetails GetMenuById(EditMenuDetails editMenuDetails)
        {
            EditMenuDetails response = new EditMenuDetails();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("MenuId", editMenuDetails.MenuId);
            response = ExecuteQuerySingle<EditMenuDetails>("SELECT MenuId,MenuName,updatedby,IpAddress FROM MenuMaster Where MenuId=@MenuId", parameters);
            return response;
        }

        public OutPut SaveMenuListData(int MenuId, string MenuName, string updatedby)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("MenuId", MenuId);
                parameters.Add("MenuName", MenuName);
                parameters.Add("updateddate", DateTime.Now);
                parameters.Add("updatedby", updatedby);
                result = ExecuteSPSingle<OutPut>("EditMenuDetails", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public OutPut DeleteMenu(int MenuId)
        {

            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("MenuId", MenuId);
                result = ExecuteSPSingle<OutPut>("DeleteMenuDetails", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion

        #region Get Valid User
        public AuthenticatedUsers IsValidUser(Login obj)
        {
            try
            {
                //var param1 = new SqlParameter
                //{
                //    ParameterName = "@Name",
                //    SqlDbType = SqlDbType.VarChar,
                //    Direction = ParameterDirection.Input,
                //    Value = obj.Name
                //};
                //var param2 = new SqlParameter
                //{
                //    ParameterName = "@password",
                //    SqlDbType = SqlDbType.VarChar,
                //    Direction = ParameterDirection.Input,
                //    Value = obj.password
                //};
                AuthenticatedUsers AuthenticatedUser = new AuthenticatedUsers();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("UserName", obj.Name);
                parameters.Add("password", obj.password);

                AuthenticatedUser = ExecuteSPSingle<AuthenticatedUsers>("AuthenticatedUsers", parameters);



                //AuthenticatedUsers AuthenticatedUser = new AuthenticatedUsers();
                //AuthenticatedUser = _dbContext.Database.SqlQuery<AuthenticatedUsers>("EXEC [dbo].[AuthenticatedUsers] @Name,@password", param1, param2).FirstOrDefault();
                return AuthenticatedUser;

            }
            //catch (Exception)
            //{

            //    throw;
            //}
            catch (Exception )
            {
                throw;
                // LogInfo.LogMsg = string.Format("Login / SignIn : {0} Message: {1} ", "", ex.Message);
                //Log.Error(LogInfo.LogMsg, ex);
            }

        }
        #endregion

        #region Forgot Password
        public RecoveryPassword ForgotUserPassword(string Email)
        {
            try
            {
                var param1 = new SqlParameter
                {
                    ParameterName = "@Email",
                    SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Input,
                    Value = Email
                };
                RecoveryPassword obj = new RecoveryPassword();
                //obj = _dbContext.Database.SqlQuery<RecoveryPassword>("EXEC [dbo].[CheckEmailExists] @Email", param1).FirstOrDefault();
                return obj;
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region Bulk Email for CRM
        public List<CRMBulkEmail> GetAllEmails(int CustomerType)
        {
            //List<CRMBulkEmail> lstEmails = new List<CRMBulkEmail>();
            //DynamicParameters parameter = new DynamicParameters();
            //parameter.Add("CustomerType", CustomerType, DbType.Int32, ParameterDirection.Input);
            //lstEmails = ExecuteSP<CRMBulkEmail>("CRMBulkEmail", parameter);

            List<CRMBulkEmail> lstEmails = new List<CRMBulkEmail>();
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("CustomerType", CustomerType);
            lstEmails = ExecuteQuery<CRMBulkEmail>("SELECT[Email] FROM [UserMaster] WHERE CustomerType IN( @CustomerType,0) AND IsActive = 1  ", parameter);
            return lstEmails;
        }
        #endregion


        #region PageManagement

        public List<UserPageManagement> ShowClientPage(string PageFileName, int RoleId, string UserId)
        {
            List<UserPageManagement> response = new List<UserPageManagement>();
            DynamicParameters parameters = new DynamicParameters();
            string query = string.Empty;
            if (RoleId == 2)
            {
                query = "SELECT PageFileName,PageDescription,PageContent FROM PageManagement Where PageFileName = @PageFileName AND IsActive = 1";
                parameters.Add("PageFileName", PageFileName);
                response = ExecuteQuery<UserPageManagement>(query, parameters).ToList();
            }
            else
            {
                query = "SELECT PageFileName,PageDescription,PageContent FROM PageManagement Where PageFileName = @PageFileName AND UserId=@UserId AND IsActive=1";
                parameters.Add("PageFileName", PageFileName);
                parameters.Add("UserId", UserId);
                response = ExecuteQuery<UserPageManagement>(query, parameters).ToList();
            }
            return response;
        }

        public List<UserPageManagement> UserManagementForClients()
        {
            List<UserPageManagement> lstuserpage = new List<UserPageManagement>();
            try
            {
                lstuserpage = ExecuteSP<UserPageManagement>("UserManagementForClient", null);
                return lstuserpage;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public OutPut SavePageInforms(InsertPage obj)
        {
            OutPut result = new OutPut();
            try
            {
                if (obj.Editable == "EditTrue")
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("IsActive", obj.IsActive);
                    parameters.Add("UserId", obj.UserId);
                    parameters.Add("UpdatedBy", obj.UpdatedBy);
                    parameters.Add("pagecontent", obj.pagecontent);
                    parameters.Add("pagedescription", obj.pagedescription);
                    parameters.Add("PageId", obj.EditPageId);
                    result = ExecuteSPSingle<OutPut>("EditPage", parameters);
                }
                else
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("pagefilename", obj.pagefilename);
                    parameters.Add("pagedescription", obj.pagedescription);
                    parameters.Add("pagecontent", obj.pagecontent);

                    parameters.Add("createdby", obj.createdby);
                    parameters.Add("IsActive", obj.IsActive);
                    parameters.Add("UserId", obj.UserId);
                    parameters.Add("AdminRights", obj.AdminRights);
                    parameters.Add("IpAddress", obj.IpAddress);
                    parameters.Add("PageMenuId", obj.PageMenuId);
                    result = ExecuteSPSingle<OutPut>("InsertPage", parameters);
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ShowEditablePage GetPageListDataById(string PageId)
        {
            ShowEditablePage response = new ShowEditablePage();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("PageID", PageId);
            response = ExecuteQuerySingle<ShowEditablePage>("SELECT PM.PageId,PM.PageContent,PM.PageDescription,PM.IsActive,PM.UserId FROM PageManagement PM INNER JOIN USERMASTER UM ON PM.USERID=UM.USERID Where PM.PageId=@PageId", parameters);
            return response;
        }

        public List<ShowPageGrid> GetPageDetailsToGrid(string PageFileName)
        {
            try
            {
                List<ShowPageGrid> lstPageDetails = new List<ShowPageGrid>();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("PageFileName", PageFileName);
                lstPageDetails = ExecuteQuery<ShowPageGrid>("SELECT PM.PageId,PM.PageFileName,PM.CreatedDate,UM.UserName,PM.IsActive,PM.PageMenuId  FROM PageManagement PM INNER JOIN USERMASTER UM ON PM.USERID=UM.USERID" +
                    " WHERE AdminRights='YES' AND PageFileName=@PageFileName ", parameters);
                return lstPageDetails;
            }
            catch (Exception )
            {

                throw;
            }

        }

        public List<GetUsersName> ShowUserNames()
        {
            try
            {
                List<GetUsersName> lstUserNames = new List<GetUsersName>();
                lstUserNames = ExecuteQuery<GetUsersName>("SELECT UserId,UserName  FROM UserMaster WHERE ISACTIVE=1 AND ROLEID<>2", null);
                return lstUserNames;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public OutPut DeletePage(int PageId, int PageMenuId)
        {

            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("PageId", PageId);
                parameters.Add("PageMenuId", PageMenuId);
                result = ExecuteSPSingle<OutPut>("DeletePageDetails", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool PageMenuIdExists(int MID, string MenuName)
        {
            bool result = false;
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("MenuId", MID);
                parameters.Add("MenuName", MenuName);
                result = ExecuteQuerySingle<bool>("select MenuId from MenuMaster where MenuId=@MenuId AND MenuName=@MenuName ", parameters);
            }
            catch (Exception )
            {

                throw;
            }
            return result;
        }

        #endregion

        #region UserManagement
        public string GetLastUserId()
        {
            string LastUserId = string.Empty;
            try
            {
                LastUserId = ExecuteQuerySingle<string>(" select  top 1 Userid from [UserMaster] order by 1 desc", null);
                return LastUserId;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public OutPut AddUserInformation(UserManagements obj)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                int userid = Convert.ToInt32(obj.UserId) + 1;
                parameters.Add("UserId", Convert.ToString(userid));
                parameters.Add("UserName", obj.UserName);
                parameters.Add("Password", obj.Password);
                //parameters.Add("Email", obj.Email);
                parameters.Add("Active", obj.IsActive);
                parameters.Add("Createdby", obj.CreatedBy);
                parameters.Add("RoleId", 1);
                parameters.Add("Email", obj.Email);
                parameters.Add("CustomerType", obj.CustomerType);
                parameters.Add("IsClient", obj.IsClient);
                result = ExecuteSPSingle<OutPut>("InsertUser", parameters);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public List<UsersList> GetUserDetailsToGrid()
        {
            try
            {

                List<UsersList> lstUserDetails = new List<UsersList>();
                lstUserDetails = ExecuteQuery<UsersList>("SELECT UserMasterId,UserName,Password,IsActive,FORMAT(CreatedDate, 'yyyy-MM-dd hh:mm:ss tt') AS CreatedDate,Email,case CustomerType when 1 then 'Existing Customer' when 2 then 'General Cusotmer' end CustomerTypeName,CustomerType,case isclient when 1 then 'Client' else 'User' end [Client]  From UserMaster where roleid<>2  ", null);
                return lstUserDetails;
            }
            catch (Exception )
            {

                throw;
            }

        }

        public EditUserDetails GetUserListDataById(EditUserDetails edituserDetails)
        {
            EditUserDetails response = new EditUserDetails();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("UserMasterId", edituserDetails.UserMasterId);
            response = ExecuteQuerySingle<EditUserDetails>("SELECT UserMasterId,UserName,Password,IsActive as Active,Email,CustomerType,IsClient as Client FROM UserMaster Where UserMasterId=@UserMasterId", parameters);
            return response;
        }

        public OutPut SaveUserListData(int UserMasterId, string UserName, string Password, bool Active, string Updatedby, string Email, int CustomerType, bool Client)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UserMasterId", UserMasterId);
                parameters.Add("UserName", UserName);
                parameters.Add("Password", Password);
                parameters.Add("IsActive", Active);
                parameters.Add("Updatedby", Updatedby);
                parameters.Add("Email", Email);
                parameters.Add("CustomerType", CustomerType);
                parameters.Add("IsClient", Client);
                result = ExecuteSPSingle<OutPut>("SaveEditUserDetails", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public OutPut DeleteUserById(int UserMasterId)
        {

            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UserMasterId", UserMasterId);
                result = ExecuteSPSingle<OutPut>("DeleteUserDetails", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion


        #region HitCounter
        public List<VideoViewLog> GetHitscounter()
        {
            List<VideoViewLog> obj = new List<VideoViewLog>();

            try
            {

                obj = ExecuteSP<VideoViewLog>("[usp_GetHitCounter]", null);

                //obj = _dbContext.Database.SqlQuery<VideoViewLog>("usp_GetHitCounter").ToList();
                return obj;
            }
            catch (Exception )
            {
                throw;
            }

        }
        #endregion

        #region FrontPPT
        public GetPresentation Presentation(int MediaID)
        {
            try
            {
                var param1 = new SqlParameter
                {
                    ParameterName = "@MediaID",
                    SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Input,
                    Value = MediaID
                };

                GetPresentation lstmenus = new GetPresentation();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("MediaID", MediaID);
                lstmenus = ExecuteSPSingle<GetPresentation>("usp_GetPresentation", parameters);

                //lstmenus = _dbContext.Database.SqlQuery<GetPresentation>("EXEC [dbo].[usp_GetPresentation] @MediaID", param1).FirstOrDefault();

                return lstmenus;


            }
            catch (Exception )
            {
                throw;
            }
        }
        #endregion

        #region FrontVideo
        public GetVideo GetMediatable(int MediaID)
        {
            try
            {
                var param1 = new SqlParameter
                {
                    ParameterName = "@MediaID",
                    SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Input,
                    Value = MediaID
                };


                GetVideo lstmenus = new GetVideo();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("MediaId", MediaID);

                lstmenus = ExecuteSPSingle<GetVideo>("usp_GetVideo", parameters);
                //lstmenus = _dbContext.Database.SqlQuery<GetVideo>("EXEC [dbo].[usp_GetVideo] @MediaID", param1).FirstOrDefault();

                return lstmenus;


            }
            catch (Exception )
            {
                throw;
            }

        }
        #endregion



        #region Front Enquiry form
        public void Insertform(EnquiryForm obj)
        {
            try
            {

                //var param1 = new SqlParameter
                //{
                //    ParameterName = "@Name",
                //    SqlDbType = SqlDbType.VarChar,
                //    Direction = ParameterDirection.Input,
                //    Value = obj.Name,
                //};
                //var param2 = new SqlParameter
                //{
                //    ParameterName = "@Email",
                //    SqlDbType = SqlDbType.VarChar,
                //    Direction = ParameterDirection.Input,
                //    Value = obj.Email,
                //};

                //var param3 = new SqlParameter
                //{
                //    ParameterName = "@phoneno",
                //    SqlDbType = SqlDbType.Int,
                //    Direction = ParameterDirection.Input,
                //    Value = obj.phoneno,
                //};
                //var param4 = new SqlParameter
                //{
                //    ParameterName = "@comments",
                //    SqlDbType = SqlDbType.VarChar,
                //    Direction = ParameterDirection.Input,
                //    Value = obj.comments,
                //};

                OutPut obj1 = new OutPut();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("Name", obj.Name);
                parameters.Add("Email", obj.Email);
                parameters.Add("phoneno", obj.phoneno);
                parameters.Add("comments", obj.comments);
                obj1 = ExecuteSPSingle<OutPut>("InsertForm", parameters);

                //var result = _dbContext.Database.ExecuteSqlCommand("insert into  enquiryform (Name,Email,phoneno,comments) values(@Name,@Email,@phoneno,@comments) ", param1, param2, param3, param4);

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Front Select Address
        public clint Address()
        {

            clint lstaddress = new clint();

            lstaddress = ExecuteSPSingle<clint>("selectAddress", null);
            //lstaddress = _dbContext.Database.SqlQuery<clint>(" selectAddress ").FirstOrDefault();
            return lstaddress;
        }
        #endregion


        #region Front ClintUser
        public List<ClintUser> Userclint()

        {
            List<ClintUser> Clintimg = new List<ClintUser>();
            Clintimg = ExecuteSP<ClintUser>("[Select_Clint]", null);
            return Clintimg;
        }
        #endregion


        #region Sabeena Video Management
        public List<video> GetVideosToGrid()
        {
            List<video> lstmenus = new List<video>();
            lstmenus = ExecuteQuery<video>("SELECT mediaid,title,description,IpAddress,viewcount,case Usertype when 0 then 'None' when 1 then 'Existing Customer' when 2 then 'General Customer' end UserTypeName , Usertype   FROM tbl_VideoMedia WHERE isactive=1 ", null);
            return lstmenus;
        }
        public video GetVideoById(video editVideoDetails)
        {
            video response = new video();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("MediaId", editVideoDetails.MediaID);
            string query = " SELECT M.mediaid,M.title,M.description,V.filename PlayVideoFileName, ";
            query += " M.IpAddress,M.viewcount,M.UserType ";
            query += " FROM tbl_VideoMedia M ";
            query += " Left Join videofiles V on M.mediaid=V.mediaid ";
            query += " WHERE  M.MediaId=@MediaId ";
            response = ExecuteQuerySingle<video>(query, parameters);
            //response = ExecuteQuerySingle<video>("SELECT mediaid,title,description,filename,IpAddress,viewcount  FROM tbl_VideoMedia WHERE  MediaId=@MediaId", parameters);
            return response;
        }
        public List<video> GetVideoListById(video editVideoDetails)
        {
            List<video> lstvideos = new List<video>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("MediaId", editVideoDetails.MediaID);
            string query = " SELECT M.mediaid,M.title,M.description,V.filename PlayVideoFileName, ";
            query += " M.IpAddress,M.viewcount ";
            query += " FROM tbl_VideoMedia M ";
            query += " Left Join videofiles V on M.mediaid=V.mediaid ";
            query += " WHERE  M.MediaId=@MediaId ";
            lstvideos = ExecuteQuery<video>(query, parameters);
            //lstvideos = ExecuteQuery<video>("SELECT filename  FROM videofiles WHERE  MediaId=@MediaId", parameters);
            return lstvideos;
        }
        public video GetVideoId()
        {
            video response = new video();
            //DynamicParameters parameters = new DynamicParameters();
            //parameters.Add("MediaId", editVideoDetails.MediaID);
            response = ExecuteQuerySingle<video>("SELECT max(mediaid)MediaID from tbl_videomedia", null);
            return response;
        }
        public List<video> GetVideoRepId()
        {
            List<video> lstvideos = new List<video>();
            DynamicParameters parameters = new DynamicParameters();
            //parameters.Add("MediaId", editVideoDetails.MediaID);
            lstvideos = ExecuteQuery<video>("SELECT mediaid,title,description,filename,IpAddress,viewcount  FROM tbl_videomedia", null);
            return lstvideos;
        }
        public OutPut SaveVideoListData(int VideoId, string VideoTitle, string VideoDesc, int isNewVideo, string path, string name, string ext, string ExistingVideoName,int UserType, string userName, string ipAddress)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("VideoId", VideoId);
                parameters.Add("VideoTitle", VideoTitle);
                parameters.Add("VideoDesc", VideoDesc);
                parameters.Add("isNewVideo", isNewVideo);
                parameters.Add("path", path);
                parameters.Add("ext", ext);
                parameters.Add("ExistingVideoName", ExistingVideoName);
                parameters.Add("userName", userName);
                parameters.Add("ipAddress", ipAddress);
                parameters.Add("UserType", UserType);
                //  parameters.Add("VideoFile", updateVideoFile);
                result = ExecuteSPSingle<OutPut>("EditVideoDetails", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public OutPut SaveCreateVideoListData(string VideoTitle, string VideoDesc, string updateVideoFile, string FileName, string Extn,int UserType, string userName, string ipAddress)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("VideoName", VideoTitle);
                parameters.Add("updateddate", DateTime.Now);
                parameters.Add("VideoDesc", VideoDesc);
                parameters.Add("VideoFile", updateVideoFile);
                parameters.Add("FileName", FileName);
                parameters.Add("Extn", Extn);
                parameters.Add("userName", userName);
                parameters.Add("ipAddress", ipAddress);
                parameters.Add("UserType", UserType);
                result = ExecuteSPSingle<OutPut>("CreateVideoDetails", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public OutPut SaveCreateVideoFileList(string VideoTitle, int mediaid, bool IsResetCount, bool IsVideoChanged)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("VideoName", VideoTitle);
                parameters.Add("mediaid", mediaid);
                parameters.Add("IsResetCount", IsResetCount);
                parameters.Add("IsVideoChanged", IsVideoChanged);
                result = ExecuteSPSingle<OutPut>("CreateVideoFileDetails", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public OutPut DeleteVideo(int MediaId)
        {

            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("MediaId", MediaId);
                result = ExecuteSPSingle<OutPut>("DeleteVideoDetails", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        #endregion

        #region Sabeena PPT Management
        public List<PPT> GetPptsToGrid()
        {
            List<PPT> lstmenus = new List<PPT>();
            lstmenus = ExecuteQuery<PPT>("SELECT mediaid,title,description,IpAddress,viewcount  FROM tbl_PPTUPLOAD WHERE isactive=1 ", null);
            return lstmenus;
        }
        public PPT GetPPTById(PPT editPPTDetails)
        {
            PPT response = new PPT();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("MediaId", editPPTDetails.MediaID);
            response = ExecuteQuerySingle<PPT>("SELECT mediaid,title,description,filename,IpAddress,viewcount  FROM [tbl_PPTUPLOAD] WHERE  MediaId=@MediaId", parameters);
            return response;
        }
        public List<PPT> GetPPTListById(PPT editVideoDetails)
        {
            List<PPT> lstvideos = new List<PPT>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("MediaId", editVideoDetails.MediaID);
            lstvideos = ExecuteQuery<PPT>("SELECT filename  FROM PPTfiles WHERE  MediaId=@MediaId", parameters);
            return lstvideos;
        }
        public PPT GetPPTId()
        {
            PPT response = new PPT();
            //DynamicParameters parameters = new DynamicParameters();
            //parameters.Add("MediaId", editVideoDetails.MediaID);
            response = ExecuteQuerySingle<PPT>("SELECT max(mediaid)MediaID from tbl_PPTUPLOAD", null);
            return response;
        }
        public OutPut SavePPTListData(int VideoId, string VideoTitle, string VideoDesc)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("VideoId", VideoId);
                parameters.Add("VideoName", VideoTitle);
                parameters.Add("updateddate", DateTime.Now);
                parameters.Add("VideoDesc", VideoDesc);
                //  parameters.Add("VideoFile", updateVideoFile);
                result = ExecuteSPSingle<OutPut>("EditPPTDetails", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public OutPut SaveCreatePPTListData(string VideoTitle, string VideoDesc, string updateVideoFile)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("VideoName", VideoTitle);
                parameters.Add("updateddate", DateTime.Now);
                parameters.Add("VideoDesc", VideoDesc);
                parameters.Add("VideoFile", updateVideoFile);
                result = ExecuteSPSingle<OutPut>("CreatePPTDetails", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public OutPut SaveCreatePPTFileList(string VideoTitle, int mediaid)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("VideoName", VideoTitle);
                parameters.Add("mediaid", mediaid);
                result = ExecuteSPSingle<OutPut>("CreatePPTFileDetails", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public OutPut DeletePPT(int MediaId)
        {

            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("MediaId", MediaId);
                result = ExecuteSPSingle<OutPut>("DeletePPTDetails", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region Activity Management
        public OutPut SaveActivity(string UserId, string UserName, int MenuId, string MenuName)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UserId", UserId);
                parameters.Add("UserName", UserName);
                parameters.Add("MenuId", MenuId);
                parameters.Add("MenuName", MenuName);
                result = ExecuteSPSingle<OutPut>("InsertActivityReport", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<ViewLogHistory> ShowActivityCount()
        {
            List<ViewLogHistory> lstActivity = new List<ViewLogHistory>();
            try
            {
                lstActivity = ExecuteQuery<ViewLogHistory>("select T.*,MM.MenuName from (select ROW_NUMBER() OVER (ORDER BY MenuId) rownumber ,MenuId,count(MenuId) count from  ActivityReport group by MenuId)T Join MenuMaster MM on T.MenuId = MM.MenuId", null);
            }
            catch (Exception)
            {

                throw;
            }
            return lstActivity;
        }

        public List<ViewLogHistory> GetViewLogHistoryById(int MenuId)
        {
            List<ViewLogHistory> lstActivity = new List<ViewLogHistory>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@MenuId", MenuId);
            try
            {
                lstActivity = ExecuteQuery<ViewLogHistory>("select MenuId,MenuName,SerialNo,UserName,FORMAT(VisitedDate,'yyyy-MM-dd hh:mm:ss tt') AS VisitedDate  from  ActivityReport where MenuId = @MenuId", parameters);
            }
            catch (Exception)
            {

                throw;
            }
            return lstActivity;
        }
        #endregion


        #region Sabeena Reports
        public List<PPT> GetPPTRepId(string startdate, string enddate)
        {
            List<PPT> response = new List<PPT>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("startdate", startdate);
            parameters.Add("enddate", enddate);
            response = ExecuteQuery<PPT>("SELECT mediaid,title,description,filename,IpAddress,viewcount from tbl_PPTUPLOAD where createddate between @startdate and @enddate", parameters);
            return response;
        }
        public List<video> GetVideoRepId(string startdate, string enddate)
        {
            List<video> lstvideos = new List<video>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("startdate", startdate);
            parameters.Add("enddate", enddate);
            lstvideos = ExecuteQuery<video>("SELECT mediaid,title,description,filename,IpAddress,viewcount  FROM tbl_videomedia where createddate between @startdate and @enddate", parameters);
            return lstvideos;
        }
        #endregion

        public List<SearchDetails> MenuSearch(string SearchMenus)
        {
            List<SearchDetails> lstMenuSearch = new List<SearchDetails>();
            try
            {

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("SearchStr", SearchMenus);
                lstMenuSearch = ExecuteSP<SearchDetails>("SearchAllTables", parameters);
            }
            catch (Exception)
            {

                throw;
            }
            return lstMenuSearch;
        }


        public List<SearchDetailsClient> MenuSearchForClient(string SearchMenus)
        {
            List<SearchDetailsClient> lstMenuSearch = new List<SearchDetailsClient>();
            try
            {

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("SearchStr", SearchMenus);
                lstMenuSearch = ExecuteSP<SearchDetailsClient>("SearchAllTablesForClient", parameters);
            }
            catch (Exception)
            {

                throw;
            }
            return lstMenuSearch;
        }





        public GetVideo GetMediatable(int MediaID, string Username)
        {
            try
            {
                var param1 = new SqlParameter
                {
                    ParameterName = "@MediaID",
                    SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Input,
                    Value = MediaID
                };
                var param2 = new SqlParameter
                {
                    ParameterName = "@Username",
                    SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Input,
                    Value = Username
                };


                GetVideo lstmenus = new GetVideo();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("MediaID", MediaID);
                parameters.Add("Username", Username);

                lstmenus = ExecuteSPSingle<GetVideo>("usp_GetVideo", parameters);

                //lstmenus = _dbContext.Database.SqlQuery<GetVideo>("EXEC [dbo].[usp_GetVideo] @MediaID,@Username", param1, param2).FirstOrDefault();
                return lstmenus;


                //var feedBackDtl = getFeedBackDetails(VFeedback.VideoId);
                //ViewData["feedBackDtl"] = feedBackDtl;
                //var FileDtl = mediaFileDtl.Where(a => a.MediaID == MediaID).SingleOrDefault();
                //if (FileDtl == null)
                //{
                //    return View("DashBoard");
                //}



            }
            catch (Exception )
            {
                throw;
            }

        }

        public List<VideoComments> GetVideosForComments()
        {

            List<VideoComments> lstVideos = new List<VideoComments>();
            try
            {
                lstVideos = ExecuteQuery<VideoComments>("SELECT VM.MediaId, VF.filename   FROM tbl_videomedia VM inner join videofiles VF on VM.mediaid=VF.mediaid WHERE VM.IsActive=1  ", null);

            }
            catch (Exception)
            {

                throw;
            }
            return lstVideos;
        }


        public OutPut SaveVideoComments(int VideoId, string VideoName, string VideoComments, string FilePath, bool IsApproved, string VisitorId, string VisitorName, string FileName, bool IsDeleted)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("VideoId", VideoId);
                parameters.Add("VideoName", VideoName);
                parameters.Add("VideoComments", VideoComments);
                parameters.Add("FilePath", FilePath);

                parameters.Add("IsApproved", IsApproved);

                parameters.Add("UserId", VisitorId);
                parameters.Add("VisitorName", VisitorName);
                parameters.Add("FileName", FileName);
                parameters.Add("IsDeleted", IsDeleted);
                result = ExecuteSPSingle<OutPut>("InsertVideoComments", parameters);
                return result;
            }
            catch (Exception )
            {

                throw;
            }
        }


        public int UpdateVideoViewCount(int VideoId, string VideoFileName)
        {
            //OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("VideoId", VideoId);
                //parameters.Add("VideoFileName", VideoFileName);
                int result = ExecuteSPSingle<int>("UpdateVideoVisitingCount", parameters);
                return result;
            }
            catch (Exception )
            {

                throw;
            }
        }
        public int UpdateVideoCount(int VideoId)
        {
            //OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("VideoId", VideoId);
                //parameters.Add("VideoFileName", VideoFileName);
                int result = ExecuteSPSingle<int>("UpdateVideoVisitingCount", parameters);
                return result;
            }
            catch (Exception )
            {

                throw;
            }
        }
        public List<LoadVideoCommentsGrid> LoadVideoCommentsListData()
        {
            List<LoadVideoCommentsGrid> lstVideoComments = new List<LoadVideoCommentsGrid>();

            try
            {
                lstVideoComments = ExecuteQuery<LoadVideoCommentsGrid>("select Sno,VideoId,VideoName,VideoComments,FilePath,FORMAT(VisitedDate,'yyyy-MM-dd hh:mm:ss tt') AS VisitedDate,IsApproved,ApprovedBy,UserId,VisitorName,FileName,IsDeleted  from  VideoComments Where IsDeleted<>'true'", null);
            }
            catch (Exception )
            {

                throw;
            }
            return lstVideoComments;
        }

        public OutPut SaveVideoApprove(int Sno, bool IsApproved)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Sno", Sno);
                parameters.Add("IsApproved", IsApproved);
                result = ExecuteQuerySingle<OutPut>("UPDATE VideoComments Set IsApproved=@IsApproved WHERE Sno=@Sno", parameters);
                return result;
            }
            catch (Exception )
            {

                throw;
            }
        }

        public OutPut RejectVideoApprove(int Sno, bool IsDeleted)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Sno", Sno);
                parameters.Add("IsDeleted", IsDeleted);
                result = ExecuteQuerySingle<OutPut>("UPDATE VideoComments Set IsDeleted=@IsDeleted WHERE Sno=@Sno", parameters);
                return result;
            }
            catch (Exception )
            {

                throw;
            }
        }



        #region Monisha Task Management
        public List<Tasks> GetTasksToGrid()
        {
            List<Tasks> lstmenus = new List<Tasks>();
            lstmenus = ExecuteQuery<Tasks>("SELECT TaskMasterId,TaskName,TaskDescription,userid  FROM [TaskMaster] WHERE isactive=1 ", null);
            return lstmenus;
        }
        public Tasks GetTaskById(Tasks editVideoDetails)
        {
            Tasks response = new Tasks();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("TaskMasterId", editVideoDetails.TaskMasterId);
            response = ExecuteQuerySingle<Tasks>("SELECT taskname,taskdescription,userid,TaskMasterId  FROM taskmaster WHERE  TaskMasterId=@TaskMasterId", parameters);
            return response;
        }
        public OutPut SaveTaskListData(string TaskTitle, string TaskDesc, string UserID, int Taskid)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("TaskId", Taskid);
                parameters.Add("TaskName", TaskTitle);
                parameters.Add("updateddate", DateTime.Now);
                parameters.Add("TaskDesc", TaskDesc);
                parameters.Add("userid", UserID);
                result = ExecuteSPSingle<OutPut>("EditTaskDetails", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public OutPut SaveCreateTaskListData(string TaskName, string TaskDescription, int userid)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("TaskName", TaskName);
                parameters.Add("createddate", DateTime.Now);
                parameters.Add("taskdescription", TaskDescription);
                parameters.Add("userid", userid);
                result = ExecuteSPSingle<OutPut>("CreateTaskDetails", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public OutPut DeleteTask(int TaskId)
        {

            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("TaskId", TaskId);
                result = ExecuteSPSingle<OutPut>("DeleteTaskDetails", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<UserManagements> GetUserList()
        {
            List<UserManagements> lstvideos = new List<UserManagements>();
            DynamicParameters parameters = new DynamicParameters();
            //  parameters.Add("MediaId", editVideoDetails.MediaID);
            lstvideos = ExecuteQuery<UserManagements>("SELECT userid,username  FROM usermaster", null);
            return lstvideos;
        }
        #endregion


        #region Charts
        public List<PPTChart> ShowPPTChart()
        {
            List<PPTChart> lstppt = new List<PPTChart>();

            try
            {
                lstppt = ExecuteQuery<PPTChart>("select Title,CreatedDate from  tbl_PPTUPLOAD ", null);
            }
            catch (Exception )
            {

                throw;
            }
            return lstppt;
        }

        public List<ActivityReportChart> ShowActivityReportChart()
        {
            List<ActivityReportChart> lstActivityReportChart = new List<ActivityReportChart>();

            try
            {
                lstActivityReportChart = ExecuteQuery<ActivityReportChart>("select T.count as Hits,MM.MenuName from (select ROW_NUMBER() OVER (ORDER BY MenuId) rownumber ,MenuId,count(MenuId) count from  ActivityReport group by MenuId)T Join MenuMaster MM on T.MenuId = MM.MenuId order by Hits desc", null);
            }
            catch (Exception )
            {

                throw;
            }
            return lstActivityReportChart;
        }

        public List<ClientVisitedVideos> ShowClientVisitedVideos()
        {
            List<ClientVisitedVideos> lstclientVisitedVideos = new List<ClientVisitedVideos>();

            try
            {
                lstclientVisitedVideos = ExecuteQuery<ClientVisitedVideos>("SELECT VF.filename AS VideoName,ViewCount FROM videofiles VF INNER JOIN tbl_VideoMedia VM ON VF.mediaid=VM.MediaID WHERE VM.IsActive=1 ", null);
            }
            catch (Exception)
            {

                throw;
            }
            return lstclientVisitedVideos;
        }





        #endregion


        #region Prabhu
        public List<GetPresentation> Presentation()
        {
            try
            {
                //var param1 = new SqlParameter
                //{
                //    ParameterName = "@MediaID",
                //    SqlDbType = SqlDbType.VarChar,
                //    Direction = ParameterDirection.Input,
                //    Value = MediaID
                //};

                List<GetPresentation> Getpres = new List<GetPresentation>();


                Getpres = ExecuteSP<GetPresentation>("[usp_GetPresentation]", null);

                //Getpres = _dbContext.Database.SqlQuery<GetPresentation>("EXEC [dbo].[usp_GetPresentation]").ToList();

                return Getpres;


            }
            catch (Exception )
            {
                throw;
            }
        }

        public OutPut SaveCreateSocialMediaData(string Title, string Url, string ImageIcon)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("Title", Title);
                //parameters.Add("updateddate", DateTime.Now);
                parameters.Add("Url", Url);
                parameters.Add("Filename", ImageIcon);
                result = ExecuteSPSingle<OutPut>("CreateSocialMedia", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Social GetSocialMediaId()
        {
            Social response = new Social();
            //DynamicParameters parameters = new DynamicParameters();
            //parameters.Add("MediaId", editVideoDetails.MediaID);
            response = ExecuteQuerySingle<Social>("SELECT max(SocialMediaID) SocialMediaID from SocialMeida", null);
            return response;
        }

        public OutPut SaveCreateSocialFileList(string FileName, int SocialMediaId)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("FileName", FileName);
                parameters.Add("SocialMediaId", SocialMediaId);
                result = ExecuteSPSingle<OutPut>("CreateSocialFileDetails", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public OutPut CreateClient(string Description, string Image, string clintName, string Website)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("Description", Description);
                parameters.Add("Image", Image);
                parameters.Add("ClientName", clintName);
                parameters.Add("Website", Website);
                result = ExecuteSPSingle<OutPut>("Createclient", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public OutPut CreatePrice(string Productname, string Validity, decimal Price)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("Productname", Productname);
                parameters.Add("Validity", Validity);
                parameters.Add("Price", Price);

                result = ExecuteSPSingle<OutPut>("[CreatePrice]", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<ClintUser> GetSocialToGrid()
        {
            List<ClintUser> lstmenus = new List<ClintUser>();
            lstmenus = ExecuteSP<ClintUser>("[GetSocial]", null);
            return lstmenus;
        }

        public List<ClintUser> GetClient()
        {
            List<ClintUser> lstmenus = new List<ClintUser>();
            lstmenus = ExecuteQuery<ClintUser>("Select * from ClientMGT", null);
            return lstmenus;
        }

        public List<tbl_Video> GetDemoVideo(string Usertype)
        {
            List<tbl_Video> lstvideo = new List<tbl_Video>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Usertype", Usertype);
            string Query = "";
            Query = "select vm.MediaID,VF.Filename from videofiles ";
            Query += "VF join tbl_VideoMedia VM on vf.mediaid =vm.MediaID ";
            if (Usertype == "1")
            {
                Query += " where vm.Usertype=vm.Usertype  ";
            }
            else if(Usertype == "2")
            {
                Query += " where vm.Usertype!='1'  ";
            }
            else
            {
                Query += " where vm.Usertype=@Usertype  ";
            }
            
           
            lstvideo = ExecuteQuery<tbl_Video>(Query, parameters);
            return lstvideo;
        }
        public List<Pricemgt> GetPrice()
        {
            List<Pricemgt> lstmenus = new List<Pricemgt>();
            lstmenus = ExecuteSP<Pricemgt>("[Getprice]", null);
            return lstmenus;
        }
        public List<Social> Social()

        {
            List<Social> socialimag = new List<Social>();
            //socialimag = _dbContext.Database.SqlQuery<Social>("[GetSocialMedia]").ToList();
            socialimag = ExecuteSP<Social>("[GetSocialMedia]", null);

            return socialimag;
        }


        public OutPut SaveSocaialListData(int SocialMediaID, string Title, string URL, string Filename)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("SocialMediaID", SocialMediaID);
                parameters.Add("Title", Title);
                parameters.Add("URL", URL);
                parameters.Add("Filename", Filename);
                //  parameters.Add("VideoFile", updateVideoFile);
                result = ExecuteSPSingle<OutPut>("EditSocialMediaImages", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public OutPut SaveClintListData(int Id, string Description, string clintName, string Website, string fname)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", Id);
                parameters.Add("Description", Description);
                parameters.Add("Image", fname);
                parameters.Add("ClientName", clintName);
                parameters.Add("Website", Website);
                //  parameters.Add("VideoFile", updateVideoFile);
                //string query = "Update clintUser set Description=@Description, ";
                //query += "ClientName=@ClientName, Website=@Website where Id=@Id ";
                result = ExecuteSPSingle<OutPut>("[Updateclient]", parameters);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public OutPut SavePriceListData(int Id, string Productname, string Validity, decimal Price)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", Id);
                parameters.Add("Productname", Productname);
                parameters.Add("Validity", Validity);
                parameters.Add("Price", Price);
                result = ExecuteSPSingle<OutPut>("[UpdatePrice]", parameters);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public SocialMediaGrid GetSocialById(SocialMediaGrid editPPTDetails)
        {
            SocialMediaGrid response = new SocialMediaGrid();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SocialMediaID", editPPTDetails.SocialMediaID);
            response = ExecuteSPSingle<SocialMediaGrid>("[ViewSocialMedia]", parameters);
            return response;
        }
        public ClintUser GetClientId(ClintUser clint)
        {
            ClintUser response = new ClintUser();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", clint.Id);
            response = ExecuteQuerySingle<ClintUser>("Select * from ClientMGT where Id=@Id", parameters);
            return response;
        }
        public Pricemgt GetPriceId(Pricemgt price)
        {
            Pricemgt response = new Pricemgt();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", price.ID);
            response = ExecuteQuerySingle<Pricemgt>("Select * from PriceMGT where Id=@Id", parameters);
            return response;
        }
        public List<SocialMediaGrid> GetSocialListById(SocialMediaGrid editVideoDetails)
        {
            List<SocialMediaGrid> lstvideos = new List<SocialMediaGrid>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SocialMediaID", editVideoDetails.SocialMediaID);
            lstvideos = ExecuteQuery<SocialMediaGrid>("SELECT Filename  FROM SocialMediaFiles WHERE  SocialMediaID=@SocialMediaID", parameters);
            return lstvideos;
        }
        public List<ClintUser> GetClientListById(ClintUser clint)
        {
            List<ClintUser> lstvideos = new List<ClintUser>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", clint.Id);
            lstvideos = ExecuteQuery<ClintUser>("SELECT *  FROM ClientMGT WHERE  Id=@Id", parameters);
            return lstvideos;
        }

        public OutPut DeleteSocialId(int SocialMediaID)
        {

            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("SocialMediaID", SocialMediaID);
                result = ExecuteSPSingle<OutPut>("DeleteSocialMediaDetails", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public OutPut DeleteClientId(int Id)
        {

            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", Id);
                result = ExecuteSPSingle<OutPut>("[DeleteClientDetails]", parameters);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public OutPut DeletePriceId(int Id)
        {

            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", Id);
                result = ExecuteSPSingle<OutPut>("[DeletePriceDetails]", parameters);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public SocialMediaGrid GetSocialLById(SocialMediaGrid editPPTDetails)
        {
            SocialMediaGrid response = new SocialMediaGrid();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SocialMediaID", editPPTDetails.SocialMediaID);
            response = ExecuteQuerySingle<SocialMediaGrid>("SELECT Title,URL  FROM [SocialMeida] WHERE  SocialMediaId=@SocialMediaId", parameters);
            return response;
        }


        public List<SocialMediaGrid> GetSocialLListById(SocialMediaGrid editVideoDetails)
        {
            List<SocialMediaGrid> lstvideos = new List<SocialMediaGrid>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("MediaId", editVideoDetails.SocialMediaID);
            lstvideos = ExecuteQuery<SocialMediaGrid>("SELECT Filename  FROM SocialMediaFiles WHERE  SocialMediaId=@SocialMediaId", parameters);
            return lstvideos;
        }


        #endregion


        #region Sabeena Document Management
        public List<Document> GetDocsToGrid()
        {
            List<Document> lstmenus = new List<Document>();
            lstmenus = ExecuteQuery<Document>("SELECT mediaid,title,description,IpAddress,viewcount  FROM [tbl_Document] WHERE isactive=1 ", null);
            return lstmenus;
        }
        public Document GetDocById(Document editPPTDetails)
        {
            Document response = new Document();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("MediaId", editPPTDetails.MediaID);
            response = ExecuteQuerySingle<Document>("SELECT mediaid,title,description,filename,IpAddress,viewcount  FROM [tbl_Document] WHERE  MediaId=@MediaId", parameters);
            return response;
        }
        public List<Document> GetDocListById(Document editVideoDetails)
        {
            List<Document> lstvideos = new List<Document>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("MediaId", editVideoDetails.MediaID);
            lstvideos = ExecuteQuery<Document>("SELECT filename  FROM [Documentfiles] WHERE  MediaId=@MediaId", parameters);
            return lstvideos;
        }
        public Document GetDocId()
        {
            Document response = new Document();
            //DynamicParameters parameters = new DynamicParameters();
            //parameters.Add("MediaId", editVideoDetails.MediaID);
            response = ExecuteQuerySingle<Document>("SELECT max(mediaid)MediaID from [tbl_Document]", null);
            return response;
        }
        public OutPut SaveDocListData(int VideoId, string VideoTitle, string VideoDesc)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("VideoId", VideoId);
                parameters.Add("VideoName", VideoTitle);
                parameters.Add("updateddate", DateTime.Now);
                parameters.Add("VideoDesc", VideoDesc);
                //  parameters.Add("VideoFile", updateVideoFile);
                result = ExecuteSPSingle<OutPut>("EditDocDetails", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public OutPut SaveCreateDocListData(string VideoTitle, string VideoDesc, string updateVideoFile)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("VideoName", VideoTitle);
                parameters.Add("updateddate", DateTime.Now);
                parameters.Add("VideoDesc", VideoDesc);
                parameters.Add("VideoFile", updateVideoFile);
                result = ExecuteSPSingle<OutPut>("CreateDocDetails", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public OutPut SaveCreateDocFileList(string VideoTitle, int mediaid)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("VideoName", VideoTitle);
                parameters.Add("mediaid", mediaid);
                result = ExecuteSPSingle<OutPut>("CreateDocFileDetails", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public OutPut DeleteDoc(int MediaId)
        {

            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("MediaId", MediaId);
                result = ExecuteSPSingle<OutPut>("DeleteDocDetails", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion


        #region bulk crm
        public OutPut AddCRMContentInformation(CRMContent obj)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                int userid = Convert.ToInt32(obj.UserId) + 1;
                parameters.Add("UserId", Convert.ToString(userid));
                parameters.Add("ContactName", obj.ContactName);
                parameters.Add("CompanyName", obj.CompanyName);
                //parameters.Add("Email", obj.Email);
                parameters.Add("Active", 1);
                parameters.Add("Createdby", obj.CreatedBy);
                parameters.Add("RoleId", 1);
                parameters.Add("Email", obj.Email);
                parameters.Add("CustomerType", 1);
                result = ExecuteSPSingle<OutPut>("InsertCrmContent", parameters);
            }
            catch (Exception )
            {

                throw;
            }

            return result;
        }

        public string GetCRMLastUserId()
        {
            string LastUserId = string.Empty;
            try
            {
                LastUserId = ExecuteQuerySingle<string>(" select  top 1 Userid from [CrmContents] order by 1 desc", null);
                return LastUserId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetCRMBulkImport(DataTable dt)
        {
            // string LastUserId = string.Empty;
            try
            {
                //using (IDbConnection db = new SqlConnection(_ConnectionString))
                string conString = ConfigurationManager.ConnectionStrings["Kaisokku_SaleDBContext"].ConnectionString;
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (System.Data.SqlClient.SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name.
                        sqlBulkCopy.DestinationTableName = "dbo.CRMContents";

                        //[OPTIONAL]: Map the DataTable columns with that of the database table
                        sqlBulkCopy.ColumnMappings.Add("ContactName", "ContactName");
                        sqlBulkCopy.ColumnMappings.Add("CompanyName", "CompanyName");
                        sqlBulkCopy.ColumnMappings.Add("Email", "Email");

                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CRMList> GetCRMUserDetailsToGrid()
        {
            try
            {

                List<CRMList> lstUserDetails = new List<CRMList>();
                lstUserDetails = ExecuteQuery<CRMList>("SELECT UserCustomId,ContactName,CompanyName,IsActive,FORMAT(CreatedDate, 'yyyy-MM-dd hh:mm:ss tt') AS CreatedDate,Email From CrmContents  ", null);
                return lstUserDetails;
            }
            catch (Exception )
            {

                throw;
            }

        }

        public EditCRMDetails GetCRMListDataById(EditCRMDetails editCrmDetails)
        {
            EditCRMDetails response = new EditCRMDetails();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("UserCustomId", editCrmDetails.UserCustomId);
            response = ExecuteQuerySingle<EditCRMDetails>("SELECT UserCustomId,ContactName,CompanyName, Email  FROM CRMContents Where UserCustomId=@UserCustomId", parameters);
            return response;
        }
        public OutPut DeleteCRMById(int UserCustomId)
        {

            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UserCustomId", UserCustomId);
                result = ExecuteSPSingle<OutPut>("DeleteCRMDetails", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public OutPut SaveCRMListData(int UserCustomId, string ContactName, string CompanyName, string Email)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UserCustomId", UserCustomId);
                parameters.Add("ContactName", ContactName);
                parameters.Add("CompanyName", CompanyName);
                //parameters.Add("IsActive", Active);
                //parameters.Add("Updatedby", Updatedby);
                parameters.Add("Email", Email);
                //parameters.Add("CustomerType", CustomerType);

                result = ExecuteSPSingle<OutPut>("SaveEditCRMDetails", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion

        public OutPut UpdateLanguageType(string LangType)
        {
            int Ltype = 0;
            if (LangType == "en")
            {
                Ltype = 0;
            }
            else
            {
                Ltype = 1;
            }
            OutPut response = new OutPut();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Ltype", Ltype);
            response = ExecuteQuerySingle<OutPut>("UPDATE MENUMASTER SET IsJapanLang=@Ltype", parameters);
            return response;
        }


        //public OutPut DeleteCRMById(int UserCustomId)
        //{

        //    OutPut result = new OutPut();
        //    try
        //    {
        //        DynamicParameters parameters = new DynamicParameters();
        //        parameters.Add("UserCustomId", UserCustomId);
        //        result = ExecuteSPSingle<OutPut>("DeleteCRMDetails", parameters);
        //        return result;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        //Sabeena-Kaisokku_Upload_Download
        public List<DRS> GetDRSRep()
        {
            List<DRS> lstvideos = new List<DRS>();
            DynamicParameters parameters = new DynamicParameters();
            //parameters.Add("MediaId", editVideoDetails.MediaID);
            lstvideos = ExecuteQuery<DRS>("SELECT *  FROM [tbl_DRS_rep]", null);
            return lstvideos;
        }



        public List<Tasks> GetTasksRepToGrid(string username)
        {

            List<Tasks> lstmenus = new List<Tasks>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("username", username);
            lstmenus = ExecuteQuery<Tasks>("SELECT TaskMasterId,TaskName,TaskDescription,usm.username  FROM TaskMaster tsk join usermaster usm on tsk.UserId = usm.UserId WHERE tsk.isactive = 1 and usm.username = @username", parameters);
            return lstmenus;
        }

        public List<Content> GetContent()
        {
            List<Content> lstmenus = new List<Content>();
            lstmenus = ExecuteQuery<Content>("Select * from contentManagement order by id asc", null);
            return lstmenus;
        }
        public OutPut SaveContentListData(int ContentID, string Title, string Description, string Updated_By)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ContentID", ContentID);
                parameters.Add("Title", Title);
                parameters.Add("Description", Description);
                parameters.Add("Updated_by", Updated_By);
                parameters.Add("Updated_date", DateTime.Now);
                result = ExecuteSPSingle<OutPut>("EditContentMGT", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public Content GetContentId(Content content)
        {
            Content response = new Content();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", content.Id);
            response = ExecuteQuerySingle<Content>("Select * from contentManagement where Id=@Id", parameters);
            return response;
        }
        public List<Content> GetcontentListById(Content content)
        {
            List<Content> lstvideos = new List<Content>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", content.Id);
            lstvideos = ExecuteQuery<Content>("SELECT *  FROM ClientMGT WHERE  Id=@Id", parameters);
            return lstvideos;
        }
        public OutPut DeleteContentId(int Id)
        {

            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", Id);
                result = ExecuteSPSingle<OutPut>("[DeletecontentManagement]", parameters);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public OutPut Createcontent(string Title, string Description, string Creared_by)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("Title", Title);
                parameters.Add("Description", Description);
                parameters.Add("Created_by", Creared_by);
                parameters.Add("Created_date", DateTime.Now);

                result = ExecuteSPSingle<OutPut>("[CreateContent]", parameters);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public UserManagements GetUserById(UserManagements User)
        {
            UserManagements response = new UserManagements();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Email", User.Email);
            parameters.Add("Password", User.Password);
            //parameters.Add("CustomerType", User.CustomerType);
            string Query = "";
            Query = "SELECT * FROM UserMaster WHERE Email=@Email and Password=@Password and isactive=1";
            response = ExecuteQuerySingle<UserManagements>(Query, parameters);
            if (response == null)
            {
                Query = "";
                Query = "select 1 as errorcode";
                response = ExecuteQuerySingle<UserManagements>(Query, parameters);
            }
            return response;
        }
        public OutPut AddUser(UserManagements obj)
        {
            OutPut result = new OutPut();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                int userid = Convert.ToInt32(obj.UserId) + 1;
                parameters.Add("UserId", Convert.ToString(userid));
                parameters.Add("UserName", obj.UserName);
                parameters.Add("Password", obj.Password);
                //parameters.Add("Email", obj.Email);
                parameters.Add("Active", 1);
                parameters.Add("Createdby", "User");
                parameters.Add("RoleId", 1);
                parameters.Add("Email", obj.Email);
                parameters.Add("CustomerType", 1);
                parameters.Add("IsClient", 1);
                result = ExecuteSPSingle<OutPut>("InsertUser", parameters);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
        public UserManagements CheckEmail(string Email)
        {
            UserManagements result = new UserManagements();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Email", Email);
                result = ExecuteQuerySingle<UserManagements>("Select * from UserMaster WHERE Email=@Email ", parameters);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
        public video Updatevideoviewcount(int mediaId)
        {
            video result = new video();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("MediaID", mediaId);
                result = ExecuteQuerySingle<video>("UPDATE tbl_VideoMedia SET ViewCount =ViewCount+1 WHERE MediaID = @MediaID  ", parameters);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
        #region DapperClass
        public List<T> ExecuteSP<T>(string SPName, DynamicParameters parameters)
        {

            using (IDbConnection db = new SqlConnection(_ConnectionString))
            {
                return db.Query<T>(SPName, parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public T ExecuteSPSingle<T>(string SPName, DynamicParameters parameters)
        {

            using (IDbConnection db = new SqlConnection(_ConnectionString))
            {
                return db.Query<T>(SPName, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public List<T> ExecuteQuery<T>(string QueryText, DynamicParameters parameters)
        {

            using (IDbConnection db = new SqlConnection(_ConnectionString))
            {
                return db.Query<T>(QueryText, parameters, commandType: CommandType.Text).ToList();
            }
        }
        public T ExecuteQuerySingle<T>(string QueryText, DynamicParameters parameters)
        {

            using (IDbConnection db = new SqlConnection(_ConnectionString))
            {
                return db.Query<T>(QueryText, parameters, commandType: CommandType.Text).FirstOrDefault();
            }
        }
        #endregion



    }
}
