using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaisokku_Data;
using Kaisokku_Common;
using System.Data;

namespace Kaisokku_Business
{
    public class Kaisokku_BusinessLayer
    {
        private Kaisokku_DataAccessLayer _kaisokkuDataAccessLayer { get; set; }

        //private string _ConnectionString;

        public Kaisokku_BusinessLayer(string ConnectionString)
        {
            _kaisokkuDataAccessLayer = new Kaisokku_DataAccessLayer(ConnectionString);
        }



        public List<Menu> ShowMenus(string userID)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetMenus(userID);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<ShowMenuGrid> ShowGridMenus()
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetMenusToGrid();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<ShowPageGrid> ShowPageDetails(string PageFileName)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetPageDetailsToGrid(PageFileName);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<GetUsersName> PageUsers()
        {
            try
            {
                return _kaisokkuDataAccessLayer.ShowUserNames();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public string GetLastUserId()
        {
            return _kaisokkuDataAccessLayer.GetLastUserId();
        }

        public OutPut AddUserInformation(UserManagements obj)
        {
            return _kaisokkuDataAccessLayer.AddUserInformation(obj);
        }

        public List<UsersList> GetUserDetails()
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetUserDetailsToGrid();
            }
            catch (Exception)
            {

                throw;
            }

        }



        public OutPut SaveMenuListData(int MenuId, string MenuName, string updatedby)
        {
            try
            {
                return _kaisokkuDataAccessLayer.SaveMenuListData(MenuId, MenuName, updatedby);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public OutPut DeleteMenu(int MenuId)
        {
            try
            {
                return _kaisokkuDataAccessLayer.DeleteMenu(MenuId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public OutPut DeletePage(int MenuId, int PageMenuId)
        {
            try
            {
                return _kaisokkuDataAccessLayer.DeletePage(MenuId, PageMenuId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<UserPageManagement> UserManagementForClients()
        {
            try
            {
                return _kaisokkuDataAccessLayer.UserManagementForClients();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<UserPageManagement> ShowClientPage(string PageFileName, int RoleId, string UserId)
        {
            try
            {
                return _kaisokkuDataAccessLayer.ShowClientPage(PageFileName, RoleId, UserId);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool PageMenuIdExists(int MID, string MenuName)
        {
            try
            {
                return _kaisokkuDataAccessLayer.PageMenuIdExists(MID, MenuName);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public OutPut SavePageInformation(InsertPage obj)
        {
            try
            {
                return _kaisokkuDataAccessLayer.SavePageInforms(obj);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public EditMenuDetails GetMenuById(EditMenuDetails editMenuDetails)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetMenuById(editMenuDetails);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ShowEditablePage GetPageListDataById(string PageId)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetPageListDataById(PageId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public OutPut CreateDynamicMenu(AddDynamicMenu dynamicmenu, int RoleId, bool IsActive, string userName)
        {
            try
            {
                dynamicmenu.ControllerName = "Home";
                dynamicmenu.ActionMethod = "PageManagement";
                dynamicmenu.MenuParentId = 7;

                //dynamicmenu.RoleId = 2;
                dynamicmenu.RoleId = RoleId;
                dynamicmenu.IsActive = IsActive;//true
                dynamicmenu.IpAddress = "ip";
                dynamicmenu.createdby = userName;
                dynamicmenu.updatedby = userName;
                dynamicmenu.createddate = DateTime.Now;
                dynamicmenu.updateddate = DateTime.Now;

                return _kaisokkuDataAccessLayer.AddNewMenu(dynamicmenu);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public AuthenticatedUsers IsValidUser(Login login)
        {
            try
            {
                return _kaisokkuDataAccessLayer.IsValidUser(login);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public RecoveryPassword PassWordRecovery(string Email)
        {
            try
            {
                return _kaisokkuDataAccessLayer.ForgotUserPassword(Email);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<CRMBulkEmail> CRMMails(int CustomerType)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetAllEmails(CustomerType);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public EditUserDetails GetUserListDataById(EditUserDetails edituserDetails)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetUserListDataById(edituserDetails);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public OutPut SaveUserListData(int UserMasterId, string UserName, string Password, bool Active, string Updatedby, string Email, int CustomerTYpe, bool Client)
        {
            try
            {
                return _kaisokkuDataAccessLayer.SaveUserListData(UserMasterId, UserName, Password, Active, Updatedby, Email, CustomerTYpe, Client);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public OutPut DeleteUserById(int UserMasterId)
        {
            try
            {
                return _kaisokkuDataAccessLayer.DeleteUserById(UserMasterId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<VideoViewLog> GetHitCounter()
        {
            return _kaisokkuDataAccessLayer.GetHitscounter();
        }

        public GetPresentation Presentationgetvalues(int MediaID)
        {
            return _kaisokkuDataAccessLayer.Presentation(MediaID);
        }

        public GetVideo Mediagetvalues(int MediaID)
        {
            return _kaisokkuDataAccessLayer.GetMediatable(MediaID);
        }

        public void insertEnquiry(EnquiryForm EnquiryForm)
        {
            try
            {
                _kaisokkuDataAccessLayer.Insertform(EnquiryForm);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public clint Selectadd()
        {
            try
            {
                return _kaisokkuDataAccessLayer.Address();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<ClintUser> SelectClint()
        {
            try
            {
                return _kaisokkuDataAccessLayer.Userclint();
            }
            catch (Exception)
            {
                throw;
            }

        }

        #region Sabeena Video Management
        public List<video> ShowGridVideos()
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetVideosToGrid();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public OutPut SaveVideoListData(int VideoId, string VideoTitle, string VideoDesc, int isNewVideo, string path, string name, string ext, string ExistingVideoName, int UserType, string userName, string ipAddress)
        {
            try
            {
                return _kaisokkuDataAccessLayer.SaveVideoListData(VideoId, VideoTitle, VideoDesc, isNewVideo, path, name, ext, ExistingVideoName, UserType, userName, ipAddress);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public OutPut SaveCreateVideoListData(string VideoTitle, string VideoDesc, string updateVideoFile, string FileName, string Extn,int UserType, string userName, string ipAddress)
        {
            try
            {
                return _kaisokkuDataAccessLayer.SaveCreateVideoListData(VideoTitle, VideoDesc, updateVideoFile, FileName, Extn, UserType, userName, ipAddress);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public OutPut SaveCreateVideoFileList(string VideoTitle, int mediaid, bool IsResetCount, bool IsVideoChanged)
        {
            try
            {
                return _kaisokkuDataAccessLayer.SaveCreateVideoFileList(VideoTitle, mediaid, IsResetCount, IsVideoChanged);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public OutPut DeleteVideo(int MediaId)
        {
            try
            {
                return _kaisokkuDataAccessLayer.DeleteVideo(MediaId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public video GetVideoById(video editVideoDetails)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetVideoById(editVideoDetails);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<video> GetVideoListById(video editVideoDetails)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetVideoListById(editVideoDetails);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public video GetVideoId()
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetVideoId();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<video> GetVideoRepId()
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetVideoRepId();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


        #region Sabeena PPT Management

        public List<PPT> ShowGridPpts()
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetPptsToGrid();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public OutPut SavePPTListData(int VideoId, string VideoTitle, string VideoDesc)
        {
            try
            {
                return _kaisokkuDataAccessLayer.SavePPTListData(VideoId, VideoTitle, VideoDesc);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public OutPut SaveCreatePPTListData(string VideoTitle, string VideoDesc, string updateVideoFile)
        {
            try
            {
                return _kaisokkuDataAccessLayer.SaveCreatePPTListData(VideoTitle, VideoDesc, updateVideoFile);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public OutPut SaveCreatePPTFileList(string VideoTitle, int mediaid)
        {
            try
            {
                return _kaisokkuDataAccessLayer.SaveCreatePPTFileList(VideoTitle, mediaid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public OutPut DeletePPT(int MediaId)
        {
            try
            {
                return _kaisokkuDataAccessLayer.DeletePPT(MediaId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public PPT GetPPTById(PPT editVideoDetails)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetPPTById(editVideoDetails);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<PPT> GetPPTListById(PPT editVideoDetails)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetPPTListById(editVideoDetails);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public PPT GetPPTId()
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetPPTId();
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
            try
            {
                return _kaisokkuDataAccessLayer.SaveActivity(UserId, UserName, MenuId, MenuName);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ViewLogHistory> ShowActivityCount()
        {
            return _kaisokkuDataAccessLayer.ShowActivityCount();
        }

        public List<ViewLogHistory> GetViewLogHistoryById(int MenuId)
        {
            return _kaisokkuDataAccessLayer.GetViewLogHistoryById(MenuId);
        }
        #endregion


        #region Sabeena Reports
        public List<video> GetVideoRepId(string startdate, string enddate)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetVideoRepId(startdate, enddate);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<PPT> GetPPTRepId(string startdate, string enddate)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetPPTRepId(startdate, enddate);
            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion

        public GetVideo Mediagetvalues(int MediaID, string Username)
        {

            return _kaisokkuDataAccessLayer.GetMediatable(MediaID, Username);
        }


        public List<SearchDetails> MenuSearch(string SearchMenus)
        {
            return _kaisokkuDataAccessLayer.MenuSearch(SearchMenus);
        }

        public List<SearchDetailsClient> MenuSearchForClient(string SearchMenus)
        {
            return _kaisokkuDataAccessLayer.MenuSearchForClient(SearchMenus);
        }





        public List<VideoComments> GetVideosForComments()
        {
            return _kaisokkuDataAccessLayer.GetVideosForComments();
        }


        public OutPut SaveVideoComments(int VideoId, string VideoName, string VideoComments, string path, bool IsApproved, string VisitorId, string VisitorName, string FileName, bool IsDeleted)
        {
            try
            {
                return _kaisokkuDataAccessLayer.SaveVideoComments(VideoId, VideoName, VideoComments, path, IsApproved, VisitorId, VisitorName, FileName, IsDeleted);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int UpdateVideoViewCount(int VideoId, string VideoFileName)
        {
            try
            {
                return _kaisokkuDataAccessLayer.UpdateVideoViewCount(VideoId, VideoFileName);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int UpdateVideoCount(int VideoId)
        {
            try
            {
                return _kaisokkuDataAccessLayer.UpdateVideoCount(VideoId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<LoadVideoCommentsGrid> LoadVideoCommentsListData()
        {
            return _kaisokkuDataAccessLayer.LoadVideoCommentsListData();
        }

        public OutPut SaveVideoApprove(int Sno, bool IsApproved)
        {
            try
            {
                return _kaisokkuDataAccessLayer.SaveVideoApprove(Sno, IsApproved);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public OutPut RejectVideoApprove(int Sno, bool IsDeleted)
        {
            try
            {
                return _kaisokkuDataAccessLayer.RejectVideoApprove(Sno, IsDeleted);
            }
            catch (Exception)
            {

                throw;
            }

        }

        #region Monisha Task Management
        public List<Tasks> ShowGridTasks()
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetTasksToGrid();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public OutPut SaveTaskListData(string TaskTitle, string TaskDesc, string UserID, int Taskid)
        {
            try
            {
                return _kaisokkuDataAccessLayer.SaveTaskListData(TaskTitle, TaskDesc, UserID, Taskid);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public OutPut SaveCreateTaskListData(string TaskName, string TaskDescription, int Userid)
        {
            try
            {
                return _kaisokkuDataAccessLayer.SaveCreateTaskListData(TaskName, TaskDescription, Userid);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public OutPut DeleteTask(int TaskId)
        {
            try
            {
                return _kaisokkuDataAccessLayer.DeleteTask(TaskId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Tasks GetTaskById(Tasks editVideoDetails)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetTaskById(editVideoDetails);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<UserManagements> GetUserList()
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetUserList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Show Charts

        public List<PPTChart> ShowPPTChart()
        {
            return _kaisokkuDataAccessLayer.ShowPPTChart();
        }


        public List<ActivityReportChart> ShowActivityReportChart()
        {
            return _kaisokkuDataAccessLayer.ShowActivityReportChart();
        }

        public List<ClientVisitedVideos> ShowClientVisitedVideos()
        {
            return _kaisokkuDataAccessLayer.ShowClientVisitedVideos();
        }
        #endregion


        #region Prabhu
        public List<GetPresentation> GetPresentationgetvalues()
        {
            return _kaisokkuDataAccessLayer.Presentation();
        }


        public OutPut SaveCreateSocialMeida(string Title, string Url, string ImageIcon)
        {
            try
            {
                return _kaisokkuDataAccessLayer.SaveCreateSocialMediaData(Title, Url, ImageIcon);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public Social GetSocialMediaId()
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetSocialMediaId();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public OutPut SaveCreateSocialFileList(string FileName, int SocialMediaId)
        {
            try
            {
                return _kaisokkuDataAccessLayer.SaveCreateSocialFileList(FileName, SocialMediaId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public OutPut CreateClient(string Description, string Image, string clintName, string Website)
        {
            try
            {
                return _kaisokkuDataAccessLayer.CreateClient(Description, Image, clintName, Website);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public OutPut CreatePrice(string Productname, string Validity, decimal Price)
        {
            try
            {
                return _kaisokkuDataAccessLayer.CreatePrice(Productname, Validity, Price);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ClintUser> ShowGridSocialMedia()
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetSocialToGrid();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<ClintUser> GetClient()
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetClient();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<tbl_Video> GetDemovideo(string Usertype)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetDemoVideo(Usertype);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<Pricemgt> GetPrice()
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetPrice();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<Social> Selectsocial()
        {
            try
            {
                return _kaisokkuDataAccessLayer.Social();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public OutPut SaveSocialMediaListData(int SocialMediaID, string Title, string URL, string Filename)
        {
            try
            {
                return _kaisokkuDataAccessLayer.SaveSocaialListData(SocialMediaID, Title, URL, Filename);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public OutPut SavePriceListData(int Id, string Productname, string Validity, decimal Price)
        {
            try
            {
                return _kaisokkuDataAccessLayer.SavePriceListData(Id, Productname, Validity, Price);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public OutPut SaveClintListData(int Id, string Description, string clintName, string Website, string fname)
        {
            try
            {
                return _kaisokkuDataAccessLayer.SaveClintListData(Id, Description, clintName, Website, fname);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public SocialMediaGrid GetSocialById(SocialMediaGrid editVideoDetails)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetSocialById(editVideoDetails);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<SocialMediaGrid> GetSocialListById(SocialMediaGrid editVideoDetails)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetSocialListById(editVideoDetails);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<ClintUser> GetClintListById(ClintUser client)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetClientListById(client);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public OutPut DeleteSocialMediaId(int SocialMediaID)
        {
            try
            {
                return _kaisokkuDataAccessLayer.DeleteSocialId(SocialMediaID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public OutPut DeleteClientId(int Id)
        {
            try
            {
                return _kaisokkuDataAccessLayer.DeleteClientId(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public OutPut DeletePriceId(int Id)
        {
            try
            {
                return _kaisokkuDataAccessLayer.DeletePriceId(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public List<Social> GetSocialListById(Social editVideoDetails)
        //{
        //    try
        //    {
        //        return KaisokkuDataAccessLayer.GetSocialListById(editVideoDetails);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public SocialMediaGrid GetSocialLiById(SocialMediaGrid editVideoDetails)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetSocialById(editVideoDetails);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ClintUser GetClientLiById(ClintUser clint)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetClientId(clint);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Pricemgt GetPriceLiById(Pricemgt Price)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetPriceId(Price);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<SocialMediaGrid> GetSocialLListById(SocialMediaGrid editVideoDetails)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetSocialListById(editVideoDetails);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Sabeena Document Management

        public List<Document> ShowGridDocs()
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetDocsToGrid();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public OutPut SaveDocListData(int VideoId, string VideoTitle, string VideoDesc)
        {
            try
            {
                return _kaisokkuDataAccessLayer.SaveDocListData(VideoId, VideoTitle, VideoDesc);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public OutPut SaveCreateDocListData(string VideoTitle, string VideoDesc, string updateVideoFile)
        {
            try
            {
                return _kaisokkuDataAccessLayer.SaveCreateDocListData(VideoTitle, VideoDesc, updateVideoFile);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public OutPut SaveCreateDocFileList(string VideoTitle, int mediaid)
        {
            try
            {
                return _kaisokkuDataAccessLayer.SaveCreateDocFileList(VideoTitle, mediaid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public OutPut DeleteDoc(int MediaId)
        {
            try
            {
                return _kaisokkuDataAccessLayer.DeleteDoc(MediaId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Document GetDocById(Document editVideoDetails)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetDocById(editVideoDetails);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Document> GetDocListById(Document editVideoDetails)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetDocListById(editVideoDetails);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Document GetDocId()
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetDocId();
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region bulkCRM
        public OutPut AddCRMContentInformation(CRMContent obj)
        {
            return _kaisokkuDataAccessLayer.AddCRMContentInformation(obj);
        }
        public string GetCRMLastUserId()
        {
            return _kaisokkuDataAccessLayer.GetCRMLastUserId();
        }

        public List<CRMList> GetCRMUserDetails()
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetCRMUserDetailsToGrid();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public DataTable GetCRMBulkImport(DataTable dt)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetCRMBulkImport(dt);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public EditCRMDetails GetCRMListDataById(EditCRMDetails editCrmDetails)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetCRMListDataById(editCrmDetails);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public OutPut DeleteCRMById(int UserCustomId)
        {
            try
            {
                return _kaisokkuDataAccessLayer.DeleteCRMById(UserCustomId);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public OutPut SaveCRMListData(int UserCustomId, string ContactName, string CompanyName, string Email)
        {
            try
            {
                return _kaisokkuDataAccessLayer.SaveCRMListData(UserCustomId, ContactName, CompanyName, Email);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        public OutPut UpdateLanguageType(string LangType)
        {
            try
            {
                return _kaisokkuDataAccessLayer.UpdateLanguageType(LangType);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<DRS> GetDRSRep()
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetDRSRep();
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public List<Tasks> ShowGridRepTasks(string username)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetTasksRepToGrid(username);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Content> Getcontent()
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetContent();
            }
            catch (Exception)
            {

                throw;




            }



        }
        public OutPut Createcontent(string Title, string Description, string Created_by)
        {
            try
            {
                return _kaisokkuDataAccessLayer.Createcontent(Title, Description, Created_by);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Content GetcontentId(Content content)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetContentId(content);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Content> GetContentListById(Content content)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetcontentListById(content);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public OutPut SaveContentListData(int Id, string Title, string Description, string Updatedby)
        {
            try
            {
                return _kaisokkuDataAccessLayer.SaveContentListData(Id, Title, Description, Updatedby);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public OutPut DeleteContentId(int Id)
        {
            try
            {
                return _kaisokkuDataAccessLayer.DeleteContentId(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public UserManagements GetUserById(UserManagements user)
        {
            try
            {
                return _kaisokkuDataAccessLayer.GetUserById(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public OutPut AddUser(UserManagements obj)
        {
            return _kaisokkuDataAccessLayer.AddUser(obj);
        }
        public UserManagements CheckEmail(String Email)
        {
            return _kaisokkuDataAccessLayer.CheckEmail(Email);
        }
        public video UpdateVideoView(int MediaId )
        {
            return _kaisokkuDataAccessLayer.Updatevideoviewcount(MediaId);
        }
    }


}
