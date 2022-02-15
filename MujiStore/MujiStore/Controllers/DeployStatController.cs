using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MujiStore.BLL;
using MujiStore.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace MujiStore.Controllers
{
    [SessionExpire]
    [Authorize]
    [MUJICustomAuthorize(Roles = "2,3,6,7,10,11,14,15,18,19,22,23,26,27,30,31")]
    public class DeployStatController : BaseController
    {
        string CS = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        // GET: DeployStat
        public ActionResult Index()
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                List<tblStreamServer> sslist = new List<tblStreamServer>();
                List<tblDeployStatu> deplist = new List<tblDeployStatu>();
                DataColumn column;
                DataTable SereamServerList = new DataTable("tblStreamServer");
                // DataColumn dtColumn;
                DataRow sserver;
                SereamServerList.Columns.Add("SSServer");
                SereamServerList.Columns.Add("StoreID", typeof(Int32));
                SereamServerList.Columns.Add("StoreName");
                SereamServerList.Columns.Add("StoreGroupName");

                SereamServerList.Columns.Add("DriveCTotal", typeof(long));
                SereamServerList.Columns.Add("DriveCFree", typeof(long));
               SereamServerList.Columns.Add("DriveDTotal", typeof(long));
               SereamServerList.Columns.Add("DriveDFree", typeof(long));
                 SereamServerList.Columns.Add("NotExistsMediaCount", typeof(long));
                SereamServerList.Columns.Add("ExistsMediaCount", typeof(long));
                SereamServerList.Columns.Add("NotExistsFileSize", typeof(long));
                SereamServerList.Columns.Add("ExistsFileSize", typeof(long));




                string querySDtnt = "";
                string SSDetails = "";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    querySDtnt = "SELECT SG.Name AS StoreGroupName, ST.StoreID AS StoreID, ST.StoreName AS StoreName,  ";
                    querySDtnt += " SSV.SSServer AS StreamServer, isnull(SSV.DriveCTotal,0) DriveCTotal, isnull(SSV.DriveCFree,0) DriveCFree,  ";
                    querySDtnt += " isnull(SSV.DriveDTotal,0) DriveDTotal, isnull(SSV.DriveDFree,0) DriveDFree, ";
                    querySDtnt += " 0 NotExistsMediaCount,0 ExistsMediaCount,0 NotExistsFileSize,0 ExistsFileSize ";
                    querySDtnt += " FROM tblStreamServer AS SSV ";
                    querySDtnt += " LEFT JOIN tblStoreSubnet AS SSN ON SSV.BelongingSubnet = SSN.Subnet ";
                    querySDtnt += " LEFT JOIN tblStore AS ST ON SSN.Store = ST.StoreID ";
                    querySDtnt += " LEFT JOIN tblStoreGroup AS SG ON ST.StoreGroupID = SG.StoreGroupID ";
                    querySDtnt += " where SSV.DELFG = 0 AND SSN.DELFG = 0 AND ST.DELFG = 0 AND SG.DELFG = 0 ";
                    querySDtnt += " ORDER BY ST.StoreID ASC ";

                    SqlCommand cmds = new SqlCommand(querySDtnt, con);
                    cmds.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdrs = cmds.ExecuteReader();
                    while (rdrs.Read())
                    {
                        sserver = SereamServerList.NewRow();
                        sserver["SSServer"] = rdrs["StreamServer"].ToString();
                        sserver["StoreID"] = Convert.ToInt32(rdrs["StoreID"]);
                        sserver["StoreName"] = rdrs["StoreName"].ToString();
                        sserver["StoreGroupName"] = rdrs["StoreGroupName"].ToString();
                        sserver["DriveCTotal"] = Convert.ToDouble(rdrs["DriveCTotal"]);
                        sserver["DriveCFree"] = Convert.ToDouble(rdrs["DriveCFree"]);
                        sserver["DriveDTotal"] = Convert.ToDouble(rdrs["DriveDTotal"]);
                        sserver["DriveDFree"] = Convert.ToDouble(rdrs["DriveDFree"]);
                        sserver["NotExistsMediaCount"] = Convert.ToDouble(rdrs["NotExistsMediaCount"]);
                        sserver["ExistsMediaCount"] = Convert.ToDouble(rdrs["ExistsMediaCount"]);
                        sserver["NotExistsFileSize"] = Convert.ToDouble(rdrs["NotExistsFileSize"]);
                        sserver["ExistsFileSize"] = Convert.ToDouble(rdrs["ExistsFileSize"]);
                        SereamServerList.Rows.Add(sserver);
                        sslist.Add(new tblStreamServer()
                        {
                            SSServer = rdrs["StreamServer"].ToString(),
                            StoreID = Convert.ToInt32(rdrs["StoreID"]),
                            StoreName = rdrs["StoreName"].ToString(),
                            StoreGroupName = rdrs["StoreGroupName"].ToString(),
                            DriveCTotal = Convert.ToInt64(rdrs["DriveCTotal"]),
                            DriveCFree = Convert.ToInt64(rdrs["DriveCFree"]),
                            DriveDTotal = Convert.ToInt64(rdrs["DriveDTotal"]),
                            DriveDFree = Convert.ToInt64(rdrs["DriveDFree"]),
                            NotExistsMediaCount = Convert.ToInt64(rdrs["NotExistsMediaCount"]),
                            ExistsMediaCount = Convert.ToInt64(rdrs["ExistsMediaCount"]),
                            NotExistsFileSize = Convert.ToInt64(rdrs["NotExistsFileSize"]),
                            ExistsFileSize = Convert.ToInt64(rdrs["ExistsFileSize"])
                        });

                        SSDetails += "'" + rdrs["StreamServer"].ToString() + "',";


                        //ste.StoreID = Convert.ToInt32(rdrs["StoreID"]);
                        //ste.StoreName = rdrs["StoreName"].ToString();
                        //stelist.Add(ste);
                    }

                    rdrs.Close();
                    if (SSDetails.Length > 0)
                    {
                        SSDetails = SSDetails.Remove(SSDetails.Length - 1);

                        querySDtnt = "";

                        querySDtnt = "SELECT SV.SSServer, isnull(DS.IsExists,0) IsExists, isnull(COUNT(M.MediaID),0) AS MediaCount, ";
                        querySDtnt += " isnull(SUM(MFI.FileSize),0) AS TotalFileSize ";
                        querySDtnt += " FROM tblStore AS ST ";
                        querySDtnt += " LEFT JOIN tblStoreSubnet AS STSN ON ST.StoreID = STSN.Store ";
                        querySDtnt += " LEFT JOIN tblStreamServer AS SV ON STSN.Subnet = SV.BelongingSubnet ";
                        querySDtnt += " LEFT JOIN tblStoreGroupFolder AS SGFL ON ST.StoreGroupID = SGFL.StoreGroupID ";
                        querySDtnt += " RIGHT JOIN tblMedia AS M ON SGFL.FolderID = M.FolderID ";
                        querySDtnt += " LEFT JOIN tblStreamServerFormat AS SF ON SV.SSServer = SF.SSFServer ";
                        querySDtnt += " LEFT JOIN tblMediaFormatInfo AS MFI ON M.MediaID = MFI.MediaID AND SF.FormatID = MFI.FormatID ";
                        querySDtnt += " LEFT JOIN tblDeployStatus AS DS ON M.MediaID = DS.MediaID AND SF.FormatID = DS.FormatID ";
                        querySDtnt += " AND DS.DSServer = SV.SSServer ";
                        querySDtnt += " WHERE M.DELFG = 0  AND SV.SSServer in (" + @SSDetails + ") ";
                        querySDtnt += " AND ST.DELFG = 0 AND STSN.DELFG = 0 AND SV.DELFG = 0 AND SGFL.DELFG = 0 ";
                        querySDtnt += " AND SF.DELFG = 0 AND MFI.DELFG = 0 "; // AND DS.DELFG = 0 ";
                        querySDtnt += " GROUP BY SV.SSServer, isnull(DS.IsExists,0) Order by SV.SSServer";

                        SqlCommand cmddss = new SqlCommand(querySDtnt, con);
                        cmddss.CommandType = CommandType.Text;

                        SqlDataReader rdrds = cmddss.ExecuteReader();

                        while (rdrds.Read())
                        {
                            deplist.Add(new tblDeployStatu()
                            {
                                DSServer = rdrds["SSServer"].ToString(),
                                FormatName = rdrds["IsExists"].ToString(),
                                MediaCount = Convert.ToInt64(rdrds["MediaCount"]),
                                TotalFileSize = Convert.ToInt64(rdrds["TotalFileSize"])

                            });

                            for (int i = 0; i < SereamServerList.Rows.Count; i++)
                            {
                                if (SereamServerList.Rows[i]["SSServer"].ToString() == rdrds["SSServer"].ToString())
                                {
                                    if (rdrds["IsExists"].ToString() == null || rdrds["IsExists"].ToString() == "" || rdrds["IsExists"].ToString() == string.Empty || rdrds["IsExists"].ToString() == "False")
                                    {
                                        SereamServerList.Rows[i]["NotExistsMediaCount"] = Convert.ToInt64(rdrds["MediaCount"]);
                                        SereamServerList.Rows[i]["NotExistsFileSize"] = Convert.ToInt64(rdrds["TotalFileSize"]);
                                        //  break;
                                    }
                                    else
                                    {
                                        SereamServerList.Rows[i]["ExistsMediaCount"] = Convert.ToInt64(rdrds["MediaCount"]);
                                        SereamServerList.Rows[i]["ExistsFileSize"] = Convert.ToInt64(rdrds["TotalFileSize"]);

                                    }
                                }


                            }

                        }
                    }





                }

                List<tblStreamServer> StreamServerDetails = new List<tblStreamServer>();
                StreamServerDetails = (from DataRow dr in SereamServerList.Rows
                                       select new tblStreamServer()
                                       {
                                           SSServer = dr["SSServer"].ToString(),
                                           StoreID = Convert.ToInt32(dr["StoreID"]),
                                           StoreName = dr["StoreName"].ToString(),
                                           StoreGroupName = dr["StoreGroupName"].ToString(),
                                           DriveCTotal = Convert.ToInt64(dr["DriveCTotal"]),
                                           DriveCFree = Convert.ToInt64(dr["DriveCFree"]),
                                           DriveDTotal = Convert.ToInt64(dr["DriveDTotal"]),
                                           DriveDFree = Convert.ToInt64(dr["DriveDFree"]),
                                           NotExistsMediaCount = Convert.ToInt64(dr["NotExistsMediaCount"]),
                                           ExistsMediaCount = Convert.ToInt64(dr["ExistsMediaCount"]),
                                           NotExistsFileSize = Convert.ToInt64(dr["NotExistsFileSize"]),
                                           ExistsFileSize = Convert.ToInt64(dr["ExistsFileSize"])
                                       }).ToList();



 
                return View(StreamServerDetails);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

        }

        

        public ActionResult ViewInsufficientlyRegistered()
        {
            LogInfo.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            LogInfo.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            LogInfo.MenuClick = LogInfo.ActionName + "_" + LogInfo.ControllerName;
            try
            {
                SqlCommand cmd;
                string querystr = "";

                List<tblSubnet> snlist = new List<tblSubnet>();
                List<tblStreamServer> sslist1 = new List<tblStreamServer>();
                List<tblStreamServer> sslist2 = new List<tblStreamServer>();
                List<tblStore> storelist = new List<tblStore>();
                bool RecExists = false;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    querystr = " SELECT Distinct SN.SubnetID AS SubnetID  ";
                    querystr += " FROM tblSubnet AS SN ";
                    querystr += " LEFT JOIN tblStoreSubnet AS SS ON SS.Subnet = SN.SubnetID  ";
                    querystr += " LEFT JOIN tblStore AS S ON S.StoreID = SS.Store  ";
                    querystr += " WHERE (isnull(SN.DELFG,1) = 1   ";
                    querystr += " OR isnull(SS.DELFG,1) = 1  ";
                    querystr += " OR isnull(S.DELFG,1) = 1  OR (S.DELFG = 1) ";
                    querystr += " OR S.StoreID IS NULL) ";

                    cmd = new SqlCommand(querystr, con);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader sndr = cmd.ExecuteReader();
                    while (sndr.Read())
                    {
                        RecExists = true;
                        snlist.Add(new tblSubnet { SubnetID = Convert.ToInt32(sndr["SubnetID"]) });
                        ViewData["snlist"] = snlist;
                    }
                    sndr.Close();

                    querystr = "";
                    querystr = " SELECT Distinct SV.[SSServer] ";
                    querystr += " FROM tblStreamServer AS SV ";
                    querystr += " LEFT JOIN tblSubnet AS SN ON SV.BelongingSubnet = SN.SubnetID ";
                    querystr += " WHERE (isnull(SV.DELFG,1) = 1 ";
                    querystr += " OR isnull(SN.DELFG,1) = 1  ";
                    querystr += " OR SN.SubnetID IS NULL ) ";

                    cmd = new SqlCommand(querystr, con);
                    cmd.CommandType = CommandType.Text;
                    //      con.Open();
                    SqlDataReader sslist1dr = cmd.ExecuteReader();
                    while (sslist1dr.Read())
                    {
                        RecExists = true;
                        sslist1.Add(new tblStreamServer { SSServer = sslist1dr["SSServer"].ToString() });
                        ViewData["sslist1"] = sslist1;
                    }
                    sslist1dr.Close();

                    querystr = "";
                    querystr = " SELECT Distinct SV.[SSServer] ";
                    querystr += " FROM tblStreamServer AS SV ";
                    querystr += " LEFT JOIN tblSubnet AS SN ON SV.BelongingSubnet = SN.SubnetID  ";
                    querystr += " WHERE (isnull(SV.DELFG,1) = 1 ";
                    querystr += " OR isnull(SN.DELFG,1) = 1  ";
                    querystr += " OR SN.SubnetID IS NULL) ";

                    cmd = new SqlCommand(querystr, con);
                    cmd.CommandType = CommandType.Text;
                    // con.Open();
                    SqlDataReader sslist2dr = cmd.ExecuteReader();
                    while (sslist2dr.Read())
                    {
                        RecExists = true;
                        sslist2.Add(new tblStreamServer { SSServer = sslist2dr["SSServer"].ToString() });
                        ViewData["sslist2"] = sslist2;
                    }
                    sslist2dr.Close();

                    querystr = "";
                    querystr = " SELECT Distinct ST.[StoreID] AS StoreID, ST.[StoreName] AS StoreName ";
                    querystr += " FROM tblStore AS ST ";
                    querystr += " LEFT JOIN tblStoreSubnet AS SS ON SS.Store = ST.StoreID ";
                    querystr += " LEFT JOIN tblSubnet AS SN ON SS.Subnet = SN.SubnetID ";
                    querystr += " WHERE (isnull(ST.DELFG,1) = 1 OR (ST.DELFG = 1) ";
                    querystr += " OR isnull(SS.DELFG,1) = 1  ";
                    querystr += " OR isnull(SN.DELFG,1) = 1  ";
                    querystr += " OR SN.SubnetID IS NULL) ";

                    cmd = new SqlCommand(querystr, con);
                    cmd.CommandType = CommandType.Text;
                    //   con.Open();
                    SqlDataReader storelistdr = cmd.ExecuteReader();
                    while (storelistdr.Read())
                    {
                        RecExists = true;
                        storelist.Add(new tblStore
                        {
                            StoreID = Convert.ToInt32(storelistdr["StoreID"]),
                            StoreName = storelistdr["StoreName"].ToString()
                        });

                        ViewData["storelist"] = storelist;
                    }
                    storelistdr.Close();

                }
                ViewData["RecExists"] = RecExists;
                return View("InsufficientlyRegistered");
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("User / Store : {0} Message: {1} ", Session["StoreUserName"].ToString(), ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View("Error", new HandleErrorInfo(ex, LogInfo.ControllerName, LogInfo.ActionName));
            }

        }

        
    }

}