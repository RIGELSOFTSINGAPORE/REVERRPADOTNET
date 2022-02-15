﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;

using System.Data.SqlClient;
using System.IO;
using System.Web.Mvc;
using MujiStore.Models;
using System.Reflection;
using System.Threading;
using System.Globalization;
using System.Text;
using MujiVBFunction;
namespace MujiStore.BLL
{
    public class CommonLogic
    {
        static string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        
        internal static string ModifiedFileName(string OrigFileName)
        {
            var ext = Path.GetExtension(OrigFileName);
            var name = Path.GetFileNameWithoutExtension(OrigFileName);
            var fileName = name + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ext;
            return fileName;
            
        }
       
        internal static string GetFileNameMp4(string OrigFileName)
        {

            var ext = Path.GetExtension(OrigFileName);
            var name = Path.GetFileNameWithoutExtension(OrigFileName);
            var fileName = name + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".mp4";
            return fileName;
        }

        internal static string GetFileNameActualMp4(string OrigFileName)
        {
            var ext = Path.GetExtension(OrigFileName);
            var name = Path.GetFileNameWithoutExtension(OrigFileName);
            var fileName = name + ".mp4";
            return fileName;
        }
        internal static void Log_info( string menuclick, string Comments)
        {
            string query = "";
           
            string storename = HttpContext.Current.Session["StoreName"].ToString();
            string ipaddress = HttpContext.Current.Session["IPAddress"].ToString();
            string countryname = "Japan";
            string user;
            if (HttpContext.Current.Session["UserName"] == null || HttpContext.Current.Session["UserName"] == "")
            {
                user = "";
            }
            else
            {
                user = HttpContext.Current.Session["UserName"].ToString();
            }
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    query = "Insert into tblVideoLogReport(StoreName,CountryName,IPAddress,UserName,MenuClick,DELFG,CRTDT,CRTCD,Comments) Values ";
                    query += "(@storename,@countryname,@ipaddress,@UserName,@menuclick,@DELFG,@CRTDT,@CRTCD,@Comments);";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@storename", storename);
                    cmd.Parameters.AddWithValue("@countryname", countryname);
                    cmd.Parameters.AddWithValue("@ipaddress", ipaddress);
                    cmd.Parameters.AddWithValue("@UserName", user);
                    cmd.Parameters.AddWithValue("@menuclick", menuclick);
                    cmd.Parameters.AddWithValue("@DELFG", "0");
                    cmd.Parameters.AddWithValue("@CRTDT", DateTime.Now);
                    cmd.Parameters.AddWithValue("@CRTCD", user);
                    cmd.Parameters.AddWithValue("@Comments", Comments);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    int result = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Not inserted due to error");
            }

        }

        internal static SelectList ToSelectList(DataTable table, string valueField, string textField)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Text = row[textField].ToString(),
                    Value = row[valueField].ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }

        internal static List<SelectListItem> GetPageSize()
        {
            List<SelectListItem> lstpagesizeList = new List<SelectListItem>()
            {
            new SelectListItem() { Value="1", Text= "1" },
            new SelectListItem() { Value="3", Text= "3" },
            new SelectListItem() { Value="4", Text= "4" },
             new SelectListItem() { Value="5", Text= "5" },
             new SelectListItem() { Value="10", Text= "10" },
             new SelectListItem() { Value="15", Text= "15" },
             new SelectListItem() { Value="25", Text= "25" },
             new SelectListItem() { Value="50", Text= "50" },
            };

            return lstpagesizeList;

        }

        internal static int EnsureLngValue(string value, Int16 def)
        {
            int result;
            int intParsed;
            
            if (string.IsNullOrEmpty(value))
            {
                result = def;
            }
            else if (int.TryParse(value.Trim(), out intParsed))
            {
                result = Convert.ToInt16(value);
            }
            else
            {
                result = def;
            }
       
            return result;

        }

        public static string GetMenuName(string ContollerName,string ActionName)
        {
            string result = "";
            if (ContollerName.ToLower() == "menus".ToLower())
            {
                if (ActionName.ToLower() == "index".ToLower())
                {
                    result = "- " + MujiStore.Resources.Resource.Managementmenu;
                }
                else if (ActionName.ToLower() == "infomenus".ToLower())
                {
                    result = "- " + MujiStore.Resources.Resource.Systeminformationmaintenance;
                }
            }
            else if (ContollerName.ToLower() == "login".ToLower())
            {
                if (ActionName.ToLower() == "index".ToLower())
                {
                    result = "- " + MujiStore.Resources.Resource.Login;
                }
                else if (ActionName.ToLower() == "ChangePassword".ToLower())
                {
                    result = "- " + MujiStore.Resources.Resource.Breadcrumbchangepassword;
                }
            }
            else if (ContollerName.ToLower() == "VideoDemo".ToLower())
            {
                result = "- " + MujiStore.Resources.Resource.Breadcrumbchangepassword;
            }
            else if (ContollerName.ToLower() == "MediaApproval".ToLower())
            {
                result = "- " + MujiStore.Resources.Resource.VideoChangeApproval;
            }
            else if (ContollerName.ToLower() == "StoreSubnetBatchReg".ToLower())
            {
                result = "- " + MujiStore.Resources.Resource.StoreSubnetBatchRegistration;
            }
            else if (ContollerName.ToLower() == "SubnetAll".ToLower())
            {
                result = "- " + MujiStore.Resources.Resource.MenuSubnet;
            }
            else if (ContollerName.ToLower() == "StoreAll".ToLower())
            {
                result = "- " + MujiStore.Resources.Resource.StoreMgt;
            }
            else if (ContollerName.ToLower() == "Folders".ToLower())
            {
                result = "- " + MujiStore.Resources.Resource.FolderMgt;
            }
            else if (ContollerName.ToLower() == "StoreSubnets".ToLower())
            {
                result = "- " + MujiStore.Resources.Resource.StoreSubnetMgt;
            }
            else if (ContollerName.ToLower() == "StoregroupAll".ToLower())
            {
                result = "- " + MujiStore.Resources.Resource.StoreGroupMgt;
            }
            else if (ContollerName.ToLower() == "User".ToLower())
            {
                result = "- " + MujiStore.Resources.Resource.UserMgt;
            }
            else if (ContollerName.ToLower() == "TroubleShoot".ToLower())
            {
                result = "- " + MujiStore.Resources.Resource.VieSearchH2;
            }
            else if (ContollerName.ToLower() == "Language".ToLower())
            {
                result = "- " + MujiStore.Resources.Resource.Language;
            }
         

            return result;
        }
        public static string GetFileDuration(int duration)
        {

            string sdur = "";
            if ((duration > 3600))
            {
               
                if (HttpContext.Current.Session["CreateSpecificCulture"].ToString() == "en")
                {
                    sdur = (duration / 3600) + "time";
                }
                else
                {
                    sdur = (duration / 3600) + "時間";
                }

                
                duration = (duration % 3600);
            }

            if ((duration > 60))
            {
                if (HttpContext.Current.Session["CreateSpecificCulture"].ToString() == "en")
                {
                    sdur = (sdur + ((duration / 60)) + "Minutes");
                }
                else
                {
                    sdur = (sdur + ((duration / 60)) + "分");
                }

                
                duration = (duration % 60);
            }

            if (HttpContext.Current.Session["CreateSpecificCulture"].ToString() == "en")
            {
                sdur = (sdur + (duration + "Seconds"));
            }
            else
            {
                sdur = (sdur + (duration + "秒"));
            }
            
            return sdur;
        }

        public static string ApplySubnetMask(string ipaddr, string netmask)
        {
            string ipAddress = "";
            string[] ipaddrst = ipaddr.Split('.');
            string[] netmaskst = netmask.Split('.');
            for (int i = 0; i < ipaddrst.Length; i++)
            {
                ipAddress += (Convert.ToInt16(ipaddrst[i]) & Convert.ToInt16(netmaskst[i])).ToString() + ".";
            }

            return ipAddress.Substring(0, ipAddress.Length - 1);
        }

        public static string GetFileExtnFromConfig()
        {
            string result = System.Configuration.ConfigurationManager.AppSettings["VideoOutputFormat"].ToString();
            return result;
        }
        
        public static List<string> GetFileExtn(string type)
        {
            List<string> list = new List<string>();

            if(type.ToLower() == "video")
            {
                
                string[] values = System.Configuration.ConfigurationManager.AppSettings["VideoOutputFormat"].ToString().Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    list.Add("."+values[i].Trim());
                    //values[i] = values[i].Trim();
                }
               
            }
            return list;
        }

        public static List<tblSubnet> getSubNetDetailsIPDtl(string IPAddress)
        {
            List<tblSubnet> snetlist = new List<tblSubnet>();
            List<tblSubnet> snetMasklist = new List<tblSubnet>();
            MujiVBFunction.MujiClass mujicls = new MujiClass();
            string querySDtl = "";
            querySDtl = " Select Distinct SubnetMask from tblSubnet ";
            querySDtl += " where DELFG = 0 order by SubnetMask DESC ";
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(querySDtl, con);
                cmd.CommandType = CommandType.Text;

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    tblSubnet snet = new tblSubnet();
                    snet.SubnetMask = rdr["SubnetMask"].ToString();
                    snetMasklist.Add(snet);
                }
                rdr.Close();
            }

            if (snetMasklist.Count > 0)
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    foreach (tblSubnet items in snetMasklist)
                    {
                        querySDtl = "SELECT SubnetID,SNIPAddress,SubnetMask,WANBandWidth,LANBandWidth ";
                        querySDtl += " From [dbo].[tblSubnet]  where DELFG = 0 ";
                        //querySDtl += " and SNIPAddress = '" + CommonLogic.ApplySubnetMask(IPAddress, items.SubnetMask) + "' and SubnetMask ='" + items.SubnetMask + "'";
                        querySDtl += " and SNIPAddress = '" + mujicls.ApplySubnetMaskNew(IPAddress, items.SubnetMask) + "' and SubnetMask ='" + items.SubnetMask + "'";
                        SqlCommand cmd = new SqlCommand(querySDtl, con);
                        cmd.CommandType = CommandType.Text;

                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            tblSubnet snet = new tblSubnet();
                            snet.SubnetID = Convert.ToInt32(rdr["SubnetID"]);
                            snet.SNIPAddress = rdr["SNIPAddress"].ToString();
                            snet.SubnetMask = rdr["SubnetMask"].ToString();
                            snet.WANBandWidth = Convert.ToInt64(rdr["WANBandWidth"]);
                            snet.LANBandWidth = Convert.ToInt64(rdr["LANBandWidth"]);
                            snetlist.Add(snet);
                        }
                        rdr.Close();
                    }

                }
            }
            return snetlist;
        }
        public static List<tblSubnet> getSubNetDetailsIP(string IPAddress)
        {
            
            string querySDtl = "";

         
            string[] ipAddressSplit = IPAddress.Split('.');
            
         
            List<tblSubnet> snetlist = new List<tblSubnet>();

            List<tblStore> stelist = new List<tblStore>();
            tblMedia media = new tblMedia();

            
            
           
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    
                        querySDtl = "SELECT top 1 PARSENAME(SNIPAddress, 4) as part1,PARSENAME(SNIPAddress, 3) as part2, ";
                        querySDtl += "PARSENAME(SNIPAddress, 2) as part3,PARSENAME(SNIPAddress, 1) as part4, ";
                        querySDtl += "SubnetID,SNIPAddress,SubnetMask,WANBandWidth,LANBandWidth ";
                        querySDtl += " From [dbo].[tblSubnet]  where DELFG = 0 ";
                        querySDtl += "and PARSENAME(SNIPAddress, 4) = '" + ipAddressSplit[0] + "' ";
                        querySDtl += "and PARSENAME(SNIPAddress, 3) = '" + ipAddressSplit[1] + "' ";
                        querySDtl += "and PARSENAME(SNIPAddress, 2) = '" + ipAddressSplit[2] + "' ";
                        querySDtl += "and " + Convert.ToInt16(ipAddressSplit[3]) + " between ";
                        querySDtl += " cast(PARSENAME(SNIPAddress, 1) as int) and cast(255 as int) ";
                        querySDtl += " order by cast(PARSENAME(SNIPAddress, 1) as int) desc";


                        SqlCommand cmd = new SqlCommand(querySDtl, con);
                        cmd.CommandType = CommandType.Text;

                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            tblSubnet snet = new tblSubnet();
                            snet.SubnetID = Convert.ToInt32(rdr["SubnetID"]);
                            snet.SNIPAddress = rdr["SNIPAddress"].ToString();
                            snet.SubnetMask = rdr["SubnetMask"].ToString();
                            snet.WANBandWidth = Convert.ToInt64(rdr["WANBandWidth"]);
                            snet.LANBandWidth = Convert.ToInt64(rdr["LANBandWidth"]);
                            snetlist.Add(snet);
                        }
                        rdr.Close();
                   


                }
           
            return snetlist;
        }

        public static List<tblSubnet> getSubNetDetails(string IPAddress)
        {
            string querySDtnt = "";
            string querySDtl = "";
            
            
             List<tblSubnet> subnetMask = new List<tblSubnet>();
            List<tblSubnet> snetlist = new List<tblSubnet>();

            List<tblStore> stelist = new List<tblStore>();
            tblMedia media = new tblMedia();
            
            using (SqlConnection con = new SqlConnection(CS))
            {

                querySDtnt = "select distinct SubnetMask  from [dbo].[tblSubnet] where DELFG = 0  ";
                SqlCommand cmd = new SqlCommand(querySDtnt, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    tblSubnet snet = new tblSubnet();
                    snet.SubnetMask = rdr["SubnetMask"].ToString();
                    subnetMask.Add(snet);
                }

            }
            
            if (subnetMask.Count > 0)
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    foreach (tblSubnet items in subnetMask)
                    {
                        querySDtl = "SELECT SubnetID,SNIPAddress,SubnetMask,WANBandWidth,LANBandWidth ";
                        querySDtl += " From [dbo].[tblSubnet]  where DELFG = 0 ";
                        querySDtl += " and SNIPAddress = '" + CommonLogic.ApplySubnetMask(IPAddress, items.SubnetMask) + "' and SubnetMask ='" + items.SubnetMask + "'";
                        //querySDtl += " and SNIPAddress = '" + mujicls.ApplySubnetMaskNew(IPAddress, items.SubnetMask) + "' and SubnetMask ='" + items.SubnetMask + "'";
                        SqlCommand cmd = new SqlCommand(querySDtl, con);
                        cmd.CommandType = CommandType.Text;

                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            tblSubnet snet = new tblSubnet();
                            snet.SubnetID = Convert.ToInt32(rdr["SubnetID"]);
                            snet.SNIPAddress = rdr["SNIPAddress"].ToString();
                            snet.SubnetMask = rdr["SubnetMask"].ToString();
                            snet.WANBandWidth = Convert.ToInt64(rdr["WANBandWidth"]);
                            snet.LANBandWidth = Convert.ToInt64(rdr["LANBandWidth"]);
                            snetlist.Add(snet);
                        }
                        rdr.Close();
                    }

                }
            }
            return snetlist;
        }

        public static tblDeployStatu GetAutoFormat(int SubNetID)
        {
            tblDeployStatu depAuto = new tblDeployStatu();
            string query = "";
            using (SqlConnection con = new SqlConnection(CS))
            {
                query = "select top 1 formatid from tblFormat ";
                query += "where RequiredBandWidth >= ( SELECT top 1 [wanBandWidth] ";
                query += "FROM [dbo].[tblSubnet] where SubnetID=@SubNetID) ";
                query += "order by RequiredBandWidth asc ";
            

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@SubNetID", SubNetID);

                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    depAuto.FormatID = Convert.ToInt32(rdr["formatid"]);
                }
            }

            return depAuto;
        }
        public static List<tblDeployStatu> GetAllFormat(int SubNetID)
        {
            List<tblDeployStatu> deplist = new List<tblDeployStatu>();
            string query = "";
            using (SqlConnection con = new SqlConnection(CS))
            {
                query = "select formatid,case when Wanbandwidth > RequiredBandWidth then 1 else 0 end recommend ";
                query += "from ( ";
                query += "select tblFormat.formatid,tblFormat.RequiredBandWidth, ";
                query += "@SubNetID subnetID from tblFormat ) tmpformat ";
                query += "left join [tblSubnet] on tmpformat.subnetID = [tblSubnet].SubnetID ";
                query += "where [tblSubnet].SubnetID = @SubNetID ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@SubNetID", SubNetID);

                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    tblDeployStatu Depstat = new tblDeployStatu();
                    Depstat.FormatID = Convert.ToInt32(rdr["FormatID"]);
                    Depstat.Recommend = Convert.ToBoolean(rdr["recommend"]);
                    deplist.Add(Depstat);
                }
            }

            return deplist;
        }
        public static List<tblDeployStatu> GetDSWithSS(int MediaID, int SubNetID)
        {
            List<tblDeployStatu> deplist = new List<tblDeployStatu>();
            string query = "";
            using (SqlConnection con = new SqlConnection(CS))
            {
                query = "SELECT DS.[DSServer], SS.IPAddress AS ServerIP, DS.FormatID, F.Name AS FormatName ";
                query += "FROM tblDeployStatus AS DS ";
                query += "LEFT JOIN [tblFormat] AS F ON DS.FormatID = F.FormatID ";
                query += "LEFT JOIN tblStreamServer AS SS ON DS.[DSServer] = SS.SSServer ";
                query += "WHERE DS.MediaID =@MediaID ";
                query += "AND DS.[IsExists] = 1 ";
                query += "AND SS.BelongingSubnet = @SubNetID AND DS.DELFG = 0 AND F.DELFG = 0 AND SS.DELFG = 0 ";


                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MediaID", MediaID);
                cmd.Parameters.AddWithValue("@SubNetID", SubNetID);

                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    tblDeployStatu Depstat = new tblDeployStatu();
                    Depstat.DSServer = rdr["DSServer"].ToString();
                    Depstat.IPAddress = rdr["ServerIP"].ToString();
                    Depstat.FormatID = Convert.ToInt32(rdr["FormatID"]);
                    Depstat.FormatName = rdr["FormatName"].ToString();
                    Depstat.Recommend = true;
                    deplist.Add(Depstat);
                }
            }

            return deplist;
        }

        public static List<tblDeployStatu> GetDSWithSNSS(int MediaID, int SubNetID)
        {
            List<tblDeployStatu> deplist = new List<tblDeployStatu>();
            string query = "";
            using (SqlConnection con = new SqlConnection(CS))
            {
                query = "SELECT DS.[DSServer], SS.IPAddress AS ServerIP, SS.BelongingSubnet AS ServerSubnet, ";
                query += "DS.FormatID, F.Name AS FormatName, F.RequiredBandWidth, SN.WANBandWidth AS ServerWANBandWidth  ";
                query += "FROM tblDeployStatus AS DS ";
                query += "LEFT JOIN [tblFormat] AS F ON DS.FormatID = F.FormatID ";
                query += "LEFT JOIN tblStreamServer AS SS ON DS.[DSServer] = SS.[SSServer] ";
                query += "LEFT JOIN tblSubnet AS SN ON SS.BelongingSubnet = SN.SubnetID  ";
                query += "WHERE DS.[DSServer] IN ";
                query += " ( ";
                query += "SELECT [SSSServer] FROM [tblStreamServerSubnet] WHERE Subnet = @SubNetID ";
                query += "AND DELFG = 0 ";
                query += " ) ";
                query += "AND MediaID = @MediaID AND [IsExists] = 1 AND SS.BelongingSubnet <> @SubNetID  ";

                query += "AND DS.DELFG = 0 AND F.DELFG = 0 AND SS.DELFG = 0 AND SN.DELFG = 0 ";
                query += "ORDER BY F.RequiredBandWidth ASC ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MediaID", MediaID);
                cmd.Parameters.AddWithValue("@SubNetID", SubNetID);

                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    tblDeployStatu Depstat = new tblDeployStatu();
                    Depstat.DSServer = rdr["DSServer"].ToString();
                    Depstat.IPAddress = rdr["ServerIP"].ToString();
                    Depstat.FormatID = Convert.ToInt32(rdr["FormatID"]);
                    Depstat.RequiredBandWidth = Convert.ToInt64(rdr["RequiredBandWidth"]);
                    Depstat.FormatName = rdr["FormatName"].ToString();
                    if ((Convert.ToInt32(rdr["ServerWANBandWidth"]) > Convert.ToInt32(rdr["RequiredBandWidth"])) &&
                        (Convert.ToInt32(HttpContext.Current.Session["WANBandWidth"].ToString()) > Convert.ToInt32(rdr["RequiredBandWidth"])))
                    {
                        Depstat.Recommend = true;
                    }
                    else
                    {
                        Depstat.Recommend = false;
                    }

                    deplist.Add(Depstat);
                }
            }

            return deplist;
        }

        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        // pro.SetValue(obj, dr[column.ColumnName], null);
                        pro.SetValue(obj, dr[column.ColumnName]);
                    else
                        continue;
                }
            }
            return obj;
        }

        public static void SetCultureInfo()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(HttpContext.Current.Session["CreateSpecificCulture"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(HttpContext.Current.Session["CreateSpecificCulture"].ToString());
        }


        public static List<SelectListItem> FillStoreGroupList()
        {
            string query = "";
            var list = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                query = "Select StoreGroupID,Name ";
                query += " from ";
                query += " tblstoregroup where DELFG = 0";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                
                while (rdr.Read())
                {
                    list.Add(new SelectListItem { Text = Convert.ToString(rdr["Name"]), Value = Convert.ToInt32(rdr["StoreGroupID"]).ToString() });

                }
            }

            return list;
        }
        public static List<SelectListItem> FillFolderListNew()
        {
            string query = "";
            var list = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(CS))
            {

                query = "  WITH foldercte(FolderId, [Name], ParentID, LEVEL, treepath,treepath1) AS  (  ";
                query +="  SELECT FolderID AS FolderId, [Name], ParentID, 1 AS LEVEL,  CAST([Name] AS NVARCHAR(4000)) AS treepath,CAST([Name] AS NVARCHAR(4000)) AS treepath1   ";
                query += " FROM ";
                query += " ( ";
                if (HttpContext.Current.Session["CreateSpecificCulture"].ToString() == "en")
                {
                query += " select -1 FolderID,-2 ParentID,N'(Root folder)' Name ";
                }
                else
                {
                query += " select -1 FolderID,-2 ParentID,N'（ルートフォルダ）' Name ";
                }
                query += " union all ";
                query += " select FolderID,ParentID,Name from [tblFolder] where DELFG = 0 ";
                query += " ) ";
                query += " [tblFolder] WHERE ParentID = -2 ";
                query += " UNION ALL ";
                query += " SELECT d.FolderID AS FolderId, d.[Name], d.ParentID,  foldercte.LEVEL + 1 AS LEVEL,  CAST(foldercte.treepath + ' -> ' +CAST(d.[Name] AS NVARCHAR(4000)) AS NVARCHAR(4000)) AS treepath,  CAST(SPACE(10 * foldercte.LEVEL + 1)  +CAST(d.[Name] AS NVARCHAR(4000)) AS NVARCHAR(4000)) AS treepath1  ";
                query += " FROM ";
                query += " ( ";
                if (HttpContext.Current.Session["CreateSpecificCulture"].ToString() == "en")
                {
                    query += " select -1 FolderID,-2 ParentID,N'(Root folder)' Name ";
                }
                else
                {
                    query += " select -1 FolderID,-2 ParentID,N'（ルートフォルダ）' Name ";
                }
                query += " union all ";
                query += " select FolderID,ParentID,Name from [tblFolder] where DELFG = 0 ";
                query += " )  d  ";
                query += " INNER JOIN foldercte ON foldercte.FolderId = d.ParentID) ";
                query += " SELECT * FROM foldercte where FolderId in  ";
                query += " ( ";
                query += " select -1 ";
                query += " union ";
                query += " select FolderID from [tblFolder] where DELFG = 0 ";
                query += " ) ORDER BY treepath ";
 
                SqlCommand cmd = new SqlCommand(query, con);
				cmd.CommandType = CommandType.Text;
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();

			while (rdr.Read())
			{
				list.Add(new SelectListItem { Text = rdr["Name"].ToString(), Value = Convert.ToInt32(rdr["FolderId"]).ToString() });

			}
		}



		return list;


	}
	public static List<SelectListItem> FillFolderList()
	{
	string query = "";
	var list = new List<SelectListItem>();
	using (SqlConnection con = new SqlConnection(CS))
	{
					
					query = "  WITH foldercte(FolderId, [Name], ParentID, LEVEL, treepath,treepath1) AS  (  ";
					query += "  SELECT FolderID AS FolderId, [Name], ParentID, 1 AS LEVEL,  CAST([Name] AS NVARCHAR(4000)) AS treepath,CAST([Name] AS NVARCHAR(4000)) AS treepath1   ";
					query += " FROM ";
					query += " ( ";
					if (HttpContext.Current.Session["CreateSpecificCulture"].ToString() == "en")
					{
						query += " select -1 FolderID,-2 ParentID,N'(Root folder)' Name ";
					}
					else
					{
						query += " select -1 FolderID,-2 ParentID,N'（ルートフォルダ）' Name ";
					}
					query += " union all ";
					query += " select FolderID,ParentID,Name from [tblFolder] where DELFG = 0 ";
					query += " ) ";
					query += " [tblFolder] WHERE ParentID = -2 ";
					query += " UNION ALL ";
					query += " SELECT d.FolderID AS FolderId, d.[Name], d.ParentID,  foldercte.LEVEL + 1 AS LEVEL,  CAST(foldercte.treepath + ' -> ' +CAST(d.[Name] AS NVARCHAR(4000)) AS NVARCHAR(4000)) AS treepath,  CAST(SPACE(10 * foldercte.LEVEL + 1)  +CAST(d.[Name] AS NVARCHAR(4000)) AS NVARCHAR(4000)) AS treepath1  ";
					query += " FROM ";
					query += " ( ";
					if (HttpContext.Current.Session["CreateSpecificCulture"].ToString() == "en")
					{
						query += " select -1 FolderID,-2 ParentID,N'(Root folder)' Name ";
					}
					else
					{
						query += " select -1 FolderID,-2 ParentID,N'（ルートフォルダ）' Name ";
					}
					query += " union all ";
					query += " select FolderID,ParentID,Name from [tblFolder] where DELFG = 0 ";
					query += " )  d  ";
					query += " INNER JOIN foldercte ON foldercte.FolderId = d.ParentID) ";
					query += " SELECT * FROM foldercte where FolderId in  ";
					query += " ( ";
					query += " select -1 ";
					query += " union ";
					query += " select FolderID from [tblFolder] where DELFG = 0 ";
					query += " ) ORDER BY treepath ";

					SqlCommand cmd = new SqlCommand(query, con);
					cmd.CommandType = CommandType.Text;
					con.Open();
					SqlDataReader rdr = cmd.ExecuteReader();

		while (rdr.Read())
		{
			list.Add(new SelectListItem { Text = rdr["treepath1"].ToString().Replace(' ', Convert.ToChar(160)), Value = Convert.ToInt32(rdr["FolderId"]).ToString() });

		}
	}


	return list;


	}

	public static List<tblFolder> GetFolderStructure()
	{
				string query = "";
				var list = new List<tblFolder>();
				using (SqlConnection con = new SqlConnection(CS))
				{




								query = "  WITH foldercte(FolderId, [Name], ParentID, LEVEL, treepath,treepath1) AS  (  ";
								query += "  SELECT FolderID AS FolderId, [Name], ParentID, 1 AS LEVEL,  CAST([Name] AS NVARCHAR(4000)) AS treepath,CAST([Name] AS NVARCHAR(4000)) AS treepath1   ";
								query += " FROM ";
								query += " ( ";
								if (HttpContext.Current.Session["CreateSpecificCulture"].ToString() == "en")
								{
									query += " select -1 FolderID,-2 ParentID,N'(Root folder)' Name ";
								}
								else
								{
									query += " select -1 FolderID,-2 ParentID,N'（ルートフォルダ）' Name ";
								}
								query += " union all ";
								query += " select FolderID,ParentID,Name from [tblFolder] where DELFG = 0 ";
								query += " ) ";
								query += " [tblFolder] WHERE ParentID = -2 ";
								query += " UNION ALL ";
								query += " SELECT d.FolderID AS FolderId, d.[Name], d.ParentID,  foldercte.LEVEL + 1 AS LEVEL,  CAST(foldercte.treepath + ' -> ' +CAST(d.[Name] AS NVARCHAR(4000)) AS NVARCHAR(4000)) AS treepath,  CAST(SPACE(10 * foldercte.LEVEL + 1)  +CAST(d.[Name] AS NVARCHAR(4000)) AS NVARCHAR(4000)) AS treepath1  ";
								query += " FROM ";
								query += " ( ";
								if (HttpContext.Current.Session["CreateSpecificCulture"].ToString() == "en")
								{
									query += " select -1 FolderID,-2 ParentID,N'(Root folder)' Name ";
								}
								else
								{
									query += " select -1 FolderID,-2 ParentID,N'（ルートフォルダ）' Name ";
								}
								query += " union all ";
								query += " select FolderID,ParentID,Name from [tblFolder] where DELFG = 0 ";
								query += " )  d  ";
								query += " INNER JOIN foldercte ON foldercte.FolderId = d.ParentID) ";
								query += " SELECT * FROM foldercte where FolderId in  ";
								query += " ( ";
								query += " select -1 ";
								query += " union ";
								query += " select FolderID from [tblFolder] where DELFG = 0 ";
								query += " ) ORDER BY treepath ";
								SqlCommand cmd = new SqlCommand(query, con);
				cmd.CommandType = CommandType.Text;
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();

				while (rdr.Read())
				{
									
						list.Add(new tblFolder { FolderID = Convert.ToInt32(rdr["FolderId"]), Name = rdr["Name"].ToString(), ParentID = Convert.ToInt32(rdr["ParentID"]), Level = Convert.ToInt32(rdr["LEVEL"]), ParentFolderName = rdr["treepath1"].ToString(), STRCRTDT= rdr["treepath1"].ToString().Replace(rdr["Name"].ToString(),"") });

				}
				}

	 
				return list;


	}

	public static int CheckUNameExists(string ID, int UserID)
	{
		int result = 0;
		string query = "";

			using (SqlConnection con = new SqlConnection(CS))
			{

			query = "select count(*) Cnt from tblUser where ID =@ID and UserID <> @UserID and DELFG = 0";
			SqlCommand cmd = new SqlCommand(query, con);
			cmd.Parameters.AddWithValue("@ID", ID);
			cmd.Parameters.AddWithValue("@UserID", UserID);
			cmd.CommandType = CommandType.Text;
			con.Open();
			result = Convert.ToInt32(cmd.ExecuteScalar());


			}
		return result;
	}

	public static void GetSessionDetails()
	{
		string query = "";
		bool isValidStore = false;




            


        MujiStore.BLL.IPAddressDtl Ipadd = new BLL.IPAddressDtl();
		string strIp = Ipadd.GetIp();
        //string strIp = "10.10.171.103";
		HttpContext.Current.Session["IPAddress"] = strIp;

		HttpContext.Current.Session["SubnetID"] = "-1";
		HttpContext.Current.Session["SNIPAddress"] = "-1";
		HttpContext.Current.Session["WANBandWidth"] = "0";
		HttpContext.Current.Session["FolderID"] = "0";
		HttpContext.Current.Session["VideoIPAddress"] = "-1";
		HttpContext.Current.Session["StoreGroupID"] = "0";


		List<MujiStore.Models.tblSubnet> snetlist = new List<MujiStore.Models.tblSubnet>();
        //snetlist = MujiStore.BLL.CommonLogic.getSubNetDetailsIP(HttpContext.Current.Session["IPAddress"].ToString());
        snetlist = MujiStore.BLL.CommonLogic.getSubNetDetailsIPDtl(HttpContext.Current.Session["IPAddress"].ToString());

        if (snetlist.Count > 0)
		{
			foreach (MujiStore.Models.tblSubnet items in snetlist)
			{
				HttpContext.Current.Session["SubnetID"] = Convert.ToInt32(items.SubnetID).ToString();
				HttpContext.Current.Session["SNIPAddress"] = items.SNIPAddress.ToString();
				HttpContext.Current.Session["WANBandWidth"] = items.WANBandWidth.ToString();
				//break;
			}
		}

		using (SqlConnection conss = new SqlConnection(CS))
		{
			query = " select Top 1 IPAddress  ";
			query += " from tblStreamServer ";
			query += "WHERE BelongingSubnet = " + Convert.ToInt32(HttpContext.Current.Session["SubnetID"]);
			query += " AND DELFG = 0";
			SqlCommand cmd = new SqlCommand(query, conss);
			cmd.CommandType = CommandType.Text;
			conss.Open();
			SqlDataReader rdrss = cmd.ExecuteReader();
				while (rdrss.Read())
				{
					HttpContext.Current.Session["VideoIPAddress"] = rdrss["IPAddress"].ToString();
					break;
				}
		}

		query = "";

		using (SqlConnection constr = new SqlConnection(CS))
		{
			query = " select Top 1 SGF.FolderID,SG.StoreGroupID  ";
			query += " from tblStoreSubnet SS ";
			query += " Join tblStore S on SS.Store = S.StoreID ";
			query += " JOIN tblSubnet SN on SN.SubnetID = SS.Subnet ";
			query += " Join tblStoreGroup SG on SG.StoreGroupID = S.StoreGroupID ";
			query += " JOIN tblStoreGroupFolder SGF ON S.StoreGroupID = SGF.StoreGroupID ";
			query += " WHERE Subnet = " + Convert.ToInt32(HttpContext.Current.Session["SubnetID"]);
			query += " AND SS.DELFG = 0 AND S.DELFG = 0 AND SGF.DELFG = 0 ";
			query += " AND SG.DELFG = 0 AND SN.DELFG = 0 ";
			SqlCommand cmd = new SqlCommand(query, constr);
			cmd.CommandType = CommandType.Text;
			constr.Open();
			SqlDataReader rdrstr = cmd.ExecuteReader();
			while (rdrstr.Read())
			{
				HttpContext.Current.Session["FolderID"] = rdrstr["FolderID"].ToString();
				HttpContext.Current.Session["StoreGroupID"] = rdrstr["StoreGroupID"].ToString();
				 break;
			}
		}


	query = "";

		using (SqlConnection con = new SqlConnection(CS))
		{
			query = "SELECT Top 1 StoreID,SNIPAddress StoreIPAddress,StoreName,PARSENAME(SNIPAddress, 4)+'.'+";
			query += "PARSENAME(SNIPAddress, 3)+'.'+PARSENAME(SNIPAddress, 2) ipcuripAdd,";
			query += "PARSENAME(SNIPAddress, 1) lastPort FROM tblStore S ";
			query += "JOIN tblStoreSubnet SS on SS.Store = S.StoreID ";
			query += "JOIN tblSubnet SN on SN.SubnetID = SS.Subnet ";
			query += "WHERE SN.SubnetID = " + Convert.ToInt32(HttpContext.Current.Session["SubnetID"]);
			query += " AND S.DELFG=0 AND SS.DELFG = 0  AND SN.DELFG = 0 ";
			SqlCommand cmd = new SqlCommand(query, con);
			cmd.CommandType = CommandType.Text;
			con.Open();
			SqlDataReader rdr = cmd.ExecuteReader();
			while (rdr.Read())
			{
				HttpContext.Current.Session["StoreName"] = rdr["StoreName"].ToString();
				HttpContext.Current.Session["StoreUserName"] = rdr["StoreName"].ToString();
				HttpContext.Current.Session["StoreIPAddress"] = rdr["StoreIPAddress"].ToString();
				HttpContext.Current.Session["StoreID"] = rdr["StoreID"].ToString();
				isValidStore = true;
				break;


			}

			if (isValidStore == false)
			{
				HttpContext.Current.Session["StoreName"] = "Unknown";//"Unknown";
				HttpContext.Current.Session["StoreUserName"] = "Unknown";
				HttpContext.Current.Session["StoreIPAddress"] = HttpContext.Current.Session["IPAddress"];
				HttpContext.Current.Session["StoreID"] = 0;
			}
		}
	}

	}


}




