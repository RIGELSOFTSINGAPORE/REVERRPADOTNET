using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MujiStore.Models;
using MujiStore.BLL;
using PagedList;
using System.IO;

using System.Configuration;
using System.Data.SqlClient;


namespace MujiStore.Controllers
{
    [SessionExpire]
    [Authorize]
    
    [Authorize(Roles = "16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31")]
    public class UserController : BaseController
    {
        private mujiEntities1 db = new mujiEntities1();
        
        static string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        // GET: User
        [NonAction]
        public ActionResult Index(int? page, string status)
        {

            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int pageSize;
            if (System.Configuration.ConfigurationManager.AppSettings["PageSize"] == null)
            {
                pageSize = 10;
            }
            else
            {
                pageSize = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["PageSize"].ToString());
            }

            int pageNumber = (page ?? 1);
            try
            {
                
                ViewData["RoleDtl"] = BindRole();
                List<tblUser> tblUser = new List<tblUser>();

                using (SqlConnection con = new SqlConnection(CS))
                {
                    string query = "";
                    SqlCommand cmd;

                    query = "select * from tbluser Order by UserID Desc";
                    cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        tblUser user = new tblUser();
                        
                        user.Authority = Convert.ToInt32(rdr["Authority"]);
                        user.ConfirmNewPassword = rdr["Password"].ToString();
                        user.IPAddress = rdr["IPAddress"].ToString();
                        user.Password = rdr["Password"].ToString();
                        user.RoleName = rdr["Role"].ToString();
                        user.UserName = rdr["UserName"].ToString();

                        user.CRTDT = Convert.ToDateTime(rdr["CRTDT"]);
                        user.CRTCD = rdr["CRTCD"].ToString();
                        user.DELFG = Convert.ToBoolean(rdr["DELFG"].ToString());
                        user.UserID = Convert.ToInt32(rdr["UserID"]);
                        user.UserEmail = rdr["UserEmail"].ToString();
                      

                        tblUser.Add(user);
                        ViewData["UserInfo"] = tblUser.ToPagedList(pageNumber, pageSize);
                    }
                   
                    if (status != null)
                    {
                        TempData["SuccMsg"] = MujiStore.Resources.Resource.UserDeletedSuccessfully;
                    }
                    return View(tblUser.ToPagedList(pageNumber, pageSize));
                }
             
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }


        // GET: User/Create
        [NonAction]
        public ActionResult Create()
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                ModelState.Clear();
                return View();
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName)); ;
            }

        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [NonAction]
        public ActionResult Create([Bind(Include = "UserId,UserName,UserEmail,Password,CreateUserId,CreateDate,UpdateUserId,UpdateDate,DELFG,Authority1,Authority2,Authority4,Authority8,Authority16")] tblUser tbl_User, string ConfirmPassword)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
         

            tbl_User.Authority = 0;
            try
            {
                
             
                if (ModelState.IsValid)
                {
                    if (tbl_User.Password.ToString().Trim() != ConfirmPassword.Trim())
                    {
                        TempData["ErrMsg"] = MujiStore.Resources.Resource.CntUserCreateErrMsg1;
                        return RedirectToAction("Index", new { id = tbl_User.UserID });
                    }

                    int UserCnt = CommonLogic.CheckUNameExists(tbl_User.UserName, 0);


                    if (UserCnt != 0)
                    {
                        TempData["ErrMsg"] = MujiStore.Resources.Resource.CntUserCreateErrMsg3;
                        return RedirectToAction("Index", new { id = tbl_User.UserID });
                    }

                    if (tbl_User.Authority1 == true)
                    {
                        tbl_User.Authority += 1;
                    }
                    if (tbl_User.Authority2 == true)
                    {
                        tbl_User.Authority += 2;
                    }
                    if (tbl_User.Authority4 == true)
                    {
                        tbl_User.Authority += 4;
                    }
                    if (tbl_User.Authority8 == true)
                    {
                        tbl_User.Authority += 8;
                    }
                    if (tbl_User.Authority16 == true)
                    {
                        tbl_User.Authority += 16;
                    }
                    tbl_User.CRTDT = DateTime.Now;
                    tbl_User.Role = "U";
                    tbl_User.CRTCD = Session["UserName"].ToString();
                    tbl_User.IPAddress = Session["IPAddress"].ToString();
                    db.tblUsers.Add(tbl_User);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                    db.Configuration.ValidateOnSaveEnabled = true;
                    LogInfo.Comments = "User Created - " + tbl_User.UserName.ToString();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.CntUserCreateSuccMsg;
                    ViewBag.result = 1;
                    return RedirectToAction("Index", new { id = 0 });
                }

                TempData["ErrMsg"] = MujiStore.Resources.Resource.CntUserCreateErrMsg2;
                return RedirectToAction("Index",new { id=tbl_User.UserID});
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                if (((System.Data.SqlClient.SqlException)ex.InnerException.InnerException).Number == 2627)
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntUserCreateErrMsg3;
                }
                else
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntUserCreateErrMsg2;
                }

                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }

        // GET: User/Edit/5
        [NonAction]
        public ActionResult Edit(int? id)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
             
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                
                List<tblUser> tbl_User = new List<tblUser>();
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string query = "";
                    SqlCommand cmd;

                    query = " select UserID,UserName,Password,DELFG,CRTDT,CRTCD, ";
                    query += " UPDDT,UPDCD,IPAddress,Authority,ID, ";
                    query += " case when (Authority & 1) = 0 then 'False' else 'True' end  Authority1, ";
                    query += " case when (Authority & 2) = 0 then 'False' else 'True' end Authority2, ";
                    query += " case when (Authority & 4) = 0 then 'False' else 'True' end Authority4, ";
                    query += " case when (Authority & 8) = 0 then 'False' else 'True' end Authority8, ";
                    query += " case when (Authority & 16) = 0 then 'False' else 'True' end Authority16 ";
                    
                    query += " from tblUser where UserID=@UserID ";


                    cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@UserID", id);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        tblUser user = new tblUser();
                        
                        user.Authority = Convert.ToInt32(rdr["Authority"]);
                        user.ConfirmNewPassword = rdr["Password"].ToString();
                        user.IPAddress = rdr["IPAddress"].ToString();
                        user.Password = rdr["Password"].ToString();
                        
                        user.UserName = rdr["UserName"].ToString();

                        user.CRTDT = Convert.ToDateTime(rdr["CRTDT"]);
                        user.CRTCD = rdr["CRTCD"].ToString();
                        user.DELFG = Convert.ToBoolean(rdr["DELFG"].ToString());
                        user.Authority1 = Convert.ToBoolean(rdr["Authority1"].ToString());
                        user.Authority2 = Convert.ToBoolean(rdr["Authority2"].ToString());
                        user.Authority4 = Convert.ToBoolean(rdr["Authority4"].ToString());
                        user.Authority8 = Convert.ToBoolean(rdr["Authority8"].ToString());
                        user.Authority16 = Convert.ToBoolean(rdr["Authority16"].ToString());
                        user.ID = (rdr["ID"]).ToString();
                        user.UserID = Convert.ToInt32(rdr["UserID"]);
                  
                        
                        user.OldPassword = "test";
                        user.NewPassword = "test";
                        user.ConfirmNewPassword = "test";
                        tbl_User.Add(user);
                        ViewData["UserEditInfo"] = user;

                    }
                }
                    if (tbl_User == null)
                {
                    
                    return HttpNotFound();
                }
               
                return View(tbl_User);
            }

            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [NonAction]
        public ActionResult Edit([Bind(Include = "UserID,UserName,UserEmail,Password,CreateUserId,CRTCD,CRTDT,DELFG,Authority1,Authority2,Authority4,Authority8,Authority16,OldPassword,NewPassword,ConfirmNewPassword")] tblUser tbl_User, string ConfirmPassword, string NewPwd)
        {

            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            tbl_User.Authority = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    if (NewPwd != "" || ConfirmPassword != "")
                    {
                        if (tbl_User.Password.Trim().ToLower() != ConfirmPassword.Trim().ToLower())
                        {
                            TempData["ErrMsg"] = MujiStore.Resources.Resource.CntUserEditErrMsg1;
                            return RedirectToAction("Edit", new { id = tbl_User.UserID });
                        }
                    }


                    if (tbl_User.DELFG == false)
                    {
                        int UserCnt = CommonLogic.CheckUNameExists(tbl_User.UserName, tbl_User.UserID);


                        if (UserCnt != 0)
                        {
                            TempData["ErrMsg"] = MujiStore.Resources.Resource.CntUserEditErrMsg3;
                            return View(tbl_User);
                        }
                    }


                    if (tbl_User.Authority1 == true)
                    {
                        tbl_User.Authority += 1;
                    }
                    if (tbl_User.Authority2 == true)
                    {
                        tbl_User.Authority += 2;
                    }
                    if (tbl_User.Authority4 == true)
                    {
                        tbl_User.Authority += 4;
                    }
                    if (tbl_User.Authority8 == true)
                    {
                        tbl_User.Authority += 8;
                    }
                    if (tbl_User.Authority16 == true)
                    {
                        tbl_User.Authority += 16;
                    }
                    
                    tbl_User.UPDDT = DateTime.Now;
                    tbl_User.UPDCD = Session["UserName"].ToString();
                    tbl_User.IPAddress = Session["IPAddress"].ToString();
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Entry(tbl_User).State = EntityState.Modified;
                    db.Configuration.ValidateOnSaveEnabled = true;
                    db.SaveChanges();
                    LogInfo.Comments = "User Updated - " + tbl_User.UserName.ToString();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.CntUserEditSuccMsg;
                    ViewBag.result = 1;
                    return RedirectToAction("Index");
                }
                TempData["ErrMsg"] = MujiStore.Resources.Resource.CntUserEditErrMsg2;
                return View(tbl_User);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                if (((System.Data.SqlClient.SqlException)ex.InnerException.InnerException).Number == 2627)
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntUserEditErrMsg3;
                }
                else
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntUserEditErrMsg2;
                }

                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

        }

        [HttpPost]
        public ActionResult Deleteuser(int UserID)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int result = 0;
            try
            {

                using (SqlConnection con = new SqlConnection(CS))
                {
                    string query = "";
                    con.Open();
                    SqlCommand cmd;
                    tblUser tblUser = new tblUser();

        
                    query = "Delete tbluser where UserID=@UserID;";
               
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@UserID", UserID);
            
                    cmd.CommandType = CommandType.Text;
                    result = cmd.ExecuteNonQuery();


                }
                if (result == 1)
                {

                    LogInfo.Comments = "User Updated - " + UserID.ToString();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.UserDeletedSuccessfully;
                    return RedirectToAction("Index_new",new { id=string.Empty});

                }
                else
                {
                    LogInfo.Comments = "User Updated - " + UserID.ToString();
                    CommonLogic.Log_info(LogInfo.MenuClick, LogInfo.Comments);
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.Unabletodeleteuser;
                    return RedirectToAction("Index_new", new { id = string.Empty });

                }
            }


            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                if (((System.Data.SqlClient.SqlException)ex.InnerException.InnerException).Number == 2627)
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.Unabletodeleteuser;
                }
                else
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.Unabletodeleteuser;
                }

                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //begins
        public void PopulateRole()
        {
            DataTable _dt = new DataTable();
            _dt.Columns.Add("Value");
            _dt.Columns.Add("Text");
            DataRow row = _dt.NewRow();
            row["Value"] = "U";
            row["Text"] = "User";
            _dt.Rows.Add(row);
            row = _dt.NewRow();
            row["Value"] = "A";
            row["Text"] = "Admin";
            _dt.Rows.Add(row);
            row = _dt.NewRow();

            ViewBag.RoleList = CommonLogic.ToSelectList(_dt, "Value", "Text");
        }
        public List<SelectListItem> BindRole()
        {
            var list = new List<SelectListItem>();

            list.Add(new SelectListItem { Text = "User", Value = "U" });
            list.Add(new SelectListItem { Text = "Admin", Value = "A" });
            return list;
        }
        public ActionResult Index_new(int? page, int? id, string status, tblUser usereditDtl, string ConfirmPassword)
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            int pageSize;
            if (System.Configuration.ConfigurationManager.AppSettings["PageSize"] == null)
            {
                pageSize = 10;
            }
            else
            {
                pageSize = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["PageSize"].ToString());
            }
            usereditDtl.ConfirmNewPassword = "123";
          
            
            int pageNumber = (page ?? 1);
            tblUser udtl = new tblUser();
            try
            {
                ViewData["RoleDtl"] = BindRole();
                List<tblUser> tblUser = new List<tblUser>();
                
                if (id == null||id==0)
                {
                    usereditDtl.OldPassword = "test";
                usereditDtl.NewPassword = "test";
                usereditDtl.ConfirmNewPassword = "test";
                usereditDtl.UserEmail = "test";
                ViewData["UserEditInfo"] = usereditDtl;
                }
                if(status=="delete")
                {
                    TempData["SuccMsg"] = MujiStore.Resources.Resource.UserDeletedSuccessfully;
                }

                Edit(id);
               
                
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string query = "";
                    SqlCommand cmd;

                    query = "select * from tbluser where Delfg=0 Order by UserID Desc";
                    cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        tblUser user = new tblUser();
              
                        user.Authority = Convert.ToInt32(rdr["Authority"]);
                        user.ConfirmNewPassword = rdr["Password"].ToString();
                        user.IPAddress = rdr["IPAddress"].ToString();
                        user.Password = rdr["Password"].ToString();
                        
                        user.UserName = rdr["UserName"].ToString();

                        user.CRTDT = Convert.ToDateTime(rdr["CRTDT"]);
                        user.CRTCD = rdr["CRTCD"].ToString();
                        user.DELFG = Convert.ToBoolean(rdr["DELFG"].ToString());
                        user.ID = (rdr["ID"]).ToString();
                        user.UserID = Convert.ToInt32(rdr["UserID"]);
                     

                        tblUser.Add(user);
                        ViewData["UserInfo"] = tblUser;
                      
                    }


                    if (Request.Form["Submit"] != null)
                    {

                        if (ModelState.IsValid)
                        {
                            int Usercheck = 0;
                            if (usereditDtl.DELFG == true)
                            {
                                TempData["Deletemsg"] = "Are you want to delete this user";
                                return View("");
                            }
                            else
                            {
                                udtl = CheckUserExists(usereditDtl);

                                if (udtl.UserID == 0 && udtl.ID == "I")
                                {
                                    if (ConfirmPassword == null || ConfirmPassword == "")
                                    {
                                        TempData["Confimmg"] = MujiStore.Resources.Resource.ModtblUserConfirmPasswordDataAnnaValida1;
                                        return View(tblUser);
                                    }
                                    Usercheck = CreateUser(usereditDtl, ConfirmPassword);
                                }
                                else if (udtl.UserID == 0 && udtl.ID == "U")
                                {
                                    Usercheck = UpdateUser(usereditDtl, ConfirmPassword, ConfirmPassword);
                                }
                                else
                                {
                                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntUserCreateErrMsg3;
                                }
                            }

                            if (Usercheck == 1)
                            {
                                return RedirectToAction("Index_new", new { id = string.Empty });
                            }
                        }

                    }

                   
                    return View(tblUser);
                }
               
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

        }

        public static tblUser CheckUserExists(tblUser Userdetails)
        {
            
            string query = "";
            tblUser usrdtl = new tblUser();
            using (SqlConnection con = new SqlConnection(CS))
            {

                query = "if exists (select UserID from tblUser where ID =@ID  and DELFG = 0) ";
                query += " begin ";
                query += " select count(*) Cnt, 'U' Type from tblUser where UserName = @UserName and ID <> @ID  and DELFG = 0 ";
                query += " end else begin ";
                query += " select count(*) Cnt , 'I' Type from tblUser where UserName = @UserName and DELFG = 0 end ";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@ID", Userdetails.ID);
                cmd.Parameters.AddWithValue("@UserName", Userdetails.UserName);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    
   
                        usrdtl.UserID = Convert.ToInt32(rdr["Cnt"]);
                        usrdtl.ID = (rdr["Type"]).ToString();
                        
                }
            }
            return usrdtl;
        }

        public  int UpdateUser(tblUser tbl_User, string ConfirmPassword, string NewPwd)
        {
            int result = 0;
            string query = "";
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            

            tbl_User.Authority = 0;
            try
            {
                if (ModelState.IsValid)
                {
                   if(ConfirmPassword!=""&& ConfirmPassword!=null)
                   {
                        if (tbl_User.Password.ToString().Trim() != ConfirmPassword.Trim())
                        {
                            TempData["ErrMsg"] = MujiStore.Resources.Resource.CntUserCreateErrMsg1;
                            return result;
                        }
                   }
                    int UserCnt = CommonLogic.CheckUNameExists(tbl_User.ID, tbl_User.UserID);


                    if (UserCnt != 0)
                    {
                        TempData["ErrMsg"] = MujiStore.Resources.Resource.CntUserEditErrMsg3;
                        return result;
                    }

                    if (tbl_User.Authority1 == true)
                    {
                        tbl_User.Authority += 1;
                    }
                    if (tbl_User.Authority2 == true)
                    {
                        tbl_User.Authority += 2;
                    }
                    if (tbl_User.Authority4 == true)
                    {
                        tbl_User.Authority += 4;
                    }
                    if (tbl_User.Authority8 == true)
                    {
                        tbl_User.Authority += 8;
                    }
                    if (tbl_User.Authority16 == true)
                    {
                        tbl_User.Authority += 16;
                    }
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        
                        query = "Update tbluser set ID=@ID, UserName=@UserName,Password=@Password,";
                        query += "DELFG=@DELFG,UPDDT=@UPDDT,UPDCD=@UPDCD,IPAddress=@IPAddress,Authority=@Authority ";
                 
                        query += " Where UserID=@UserID";
                        tbl_User.CRTDT = DateTime.Now;
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ID", tbl_User.ID);
                        cmd.Parameters.AddWithValue("@UserID", tbl_User.UserID);
                        cmd.Parameters.AddWithValue("@UserName", tbl_User.UserName);
                        cmd.Parameters.AddWithValue("@Password", tbl_User.Password);
                        
                        cmd.Parameters.AddWithValue("@DELFG", tbl_User.DELFG);
                        cmd.Parameters.AddWithValue("@UPDDT", DateTime.Now);
                        cmd.Parameters.AddWithValue("@UPDCD", Session["UserName"].ToString());
                        cmd.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());
                        
                        cmd.Parameters.AddWithValue("@Authority", tbl_User.Authority);
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        result = cmd.ExecuteNonQuery();
                        if(result==1)
                        {
                            TempData["ErrMsg"] = MujiStore.Resources.Resource.CntUserEditSuccMsg;
                        }
                        else
                        {
                            TempData["ErrMsg"] = MujiStore.Resources.Resource.CntUserEditErrMsg2;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                result = 0;
                if (((System.Data.SqlClient.SqlException)ex.InnerException.InnerException).Number == 2627)
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntUserEditErrMsg3;
                }
                else
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntUserEditErrMsg2;
                }
            }
            return result;
        }
        public int CreateUser (tblUser tbl_User, string ConfirmPassword)
        {
            int result = 0;
            string query = "";

            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            tbl_User.Authority = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    if (tbl_User.Password != "" || ConfirmPassword != "")
                    {
                        if (tbl_User.Password.Trim().ToLower() != ConfirmPassword.Trim().ToLower())
                        {
                            TempData["ErrMsg"] = MujiStore.Resources.Resource.CntUserEditErrMsg1;
                            return result;
                        }
                    }


                    if (tbl_User.DELFG == false)
                    {
                        int UserCnt = CommonLogic.CheckUNameExists(tbl_User.ID, 0);


                        if (UserCnt != 0)
                        {
                            TempData["ErrMsg"] = MujiStore.Resources.Resource.CntUserEditErrMsg3;
                            return result;
                        }
                    }
                    if (tbl_User.Authority1 == true)
                    {
                        tbl_User.Authority += 1;
                    }
                    if (tbl_User.Authority2 == true)
                    {
                        tbl_User.Authority += 2;
                    }
                    if (tbl_User.Authority4 == true)
                    {
                        tbl_User.Authority += 4;
                    }
                    if (tbl_User.Authority8 == true)
                    {
                        tbl_User.Authority += 8;
                    }
                    if (tbl_User.Authority16 == true)
                    {
                        tbl_User.Authority += 16;
                    }
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        query = "";
                        query = "Insert Into tbluser (ID,UserName,Password,DELFG,CRTDT,CRTCD,IPAddress,";
                      
                        query += " Authority)";
                        query += " Values (@ID,@UserName,@Password,@DELFG,@CRTDT,@CRTCD,@IPAddress,";
                      
                        query += " @Authority)";
                        tbl_User.CRTDT = DateTime.Now;
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ID", tbl_User.ID);
                        cmd.Parameters.AddWithValue("@UserName", tbl_User.UserName);
                        cmd.Parameters.AddWithValue("@Password", tbl_User.Password);
                      
                        cmd.Parameters.AddWithValue("@DELFG", 0);
                        cmd.Parameters.AddWithValue("@CRTDT", DateTime.Now);
                        cmd.Parameters.AddWithValue("@CRTCD", Session["UserName"].ToString());
                        cmd.Parameters.AddWithValue("@IPAddress", Session["IPAddress"].ToString());
                      
                        cmd.Parameters.AddWithValue("@Authority", tbl_User.Authority);
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        result = cmd.ExecuteNonQuery();
                        if (result == 1)
                        {
                            TempData["ErrMsg"] = MujiStore.Resources.Resource.CntUserCreateSuccMsg;
                        }
                        else
                        {
                            TempData["ErrMsg"] = MujiStore.Resources.Resource.CntUserCreateErrMsg2;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                result = 0;
                if (((System.Data.SqlClient.SqlException)ex.InnerException.InnerException).Number == 2627)
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntUserCreateErrMsg3;
                }
                else
                {
                    TempData["ErrMsg"] = MujiStore.Resources.Resource.CntUserCreateErrMsg2;
                }
            }
            return result;
        }
        //endshere
    }
}
