using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Net;
using Penna_Common;
using Penna_Business;

namespace Penna_MRP.Controllers
{
    [Authorize(Roles = "1")]
    public class ManageSettingsController : BaseController
    {
        private Penna_BusinessLayer _Penna_BusinessLayer;
        public ManageSettingsController()
        {
            _Penna_BusinessLayer = new Penna_BusinessLayer(base.ConnectionString);
        }

        public ActionResult Index()
        {
            Penna_ManageSettings penna_Settings = new Penna_ManageSettings();
            penna_Settings = getdata();
            return View(penna_Settings);
        }
        public ActionResult create(Penna_ManageSettings _ManageSettingsController)
        {
            int result=0;
            try
            {
                _ManageSettingsController.CreatedBy = Convert.ToInt32(Session["UserId"]);
                _ManageSettingsController.IsActive = 1;
                result = _Penna_BusinessLayer.InsertManagePrinters(_ManageSettingsController);
                
                result = _Penna_BusinessLayer.InsertManageSettings(_ManageSettingsController);
                
                
                result = _Penna_BusinessLayer.InsertManageCounter(_ManageSettingsController);
                ViewBag.suumsg = "success";
                TempData["SuccMsg"] = "Data Updated Successfully";
            }
            catch(Exception ex)
            {
                LogInfo.LogMsg = string.Format("Managesetting / Create : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                throw ex;
            }
            Penna_ManageSettings penna_Settings = new Penna_ManageSettings();
            penna_Settings = getdata();
            return View("Index", penna_Settings);
        }
        public Penna_ManageSettings getdata()
        {
            Penna_ManageSettings penna_Settings = new Penna_ManageSettings();
            try
            {
                int j = 0;
                List<Penna_ManageSettings> penna_ManageSettings = new List<Penna_ManageSettings>();
                //List<Penna_ManageSettings> penna_Settings = new List<Penna_ManageSettings>();



                penna_ManageSettings = _Penna_BusinessLayer.GetManageSetting();

                foreach (var i in penna_ManageSettings)
                {
                    penna_Settings.Polling_Timer_COunter = i.Polling_Timer_COunter;
                    penna_Settings.Polling_Timer_Printer = i.Polling_Timer_Printer;
                    penna_Settings.Database_Polling_Time = i.Database_Polling_Time;
                }
                ViewData["Setting"] = penna_Settings;
                penna_ManageSettings = _Penna_BusinessLayer.GetManagePrinter();
                j = 1;
                foreach (var i in penna_ManageSettings)
                {
                    if (j == 1)
                    {
                        penna_Settings.IP_Address1_Print = i.IP_Address;
                        penna_Settings.Port1_Print = i.Port_No;


                    }
                    if (j == 2)
                    {
                        penna_Settings.IP_Address2_Print = i.IP_Address;
                        penna_Settings.Port2_Print = i.Port_No;

                    }
                    if (j == 3)
                    {
                        penna_Settings.IP_Address3_Print = i.IP_Address;
                        penna_Settings.Port3_Print = i.Port_No;

                    }
                    if (j == 4)
                    {
                        penna_Settings.IP_Address4_Print = i.IP_Address;
                        penna_Settings.Port4_Print = i.Port_No;
                    }
                    j += 1;


                }
                ViewData["printers"] = penna_Settings;
                penna_ManageSettings = _Penna_BusinessLayer.GetManageCounter();
                j = 1;
                foreach (var i in penna_ManageSettings)
                {
                    if (j == 1)
                    {
                        penna_Settings.IP_Address1_counter1 = i.IP_Address;
                        penna_Settings.Port1_counter1 = i.Port_No;
                    }
                    if (j == 2)
                    {
                        penna_Settings.IP_Address1_counter2 = i.IP_Address;
                        penna_Settings.Port1_counter2 = i.Port_No;
                    }
                    if (j == 3)
                    {
                        penna_Settings.IP_Address2_counter1 = i.IP_Address;
                        penna_Settings.Port2_counter1 = i.Port_No;
                    }
                    if (j == 4)
                    {
                        penna_Settings.IP_Address2_counter2 = i.IP_Address;
                        penna_Settings.Port2_counter2 = i.Port_No;
                    }
                    if (j == 5)
                    {
                        penna_Settings.IP_Address3_counter1 = i.IP_Address;
                        penna_Settings.Port3_counter1 = i.Port_No;
                    }
                    if (j == 6)
                    {
                        penna_Settings.IP_Address3_counter2 = i.IP_Address;
                        penna_Settings.Port3_counter2 = i.Port_No;
                    }
                    if (j == 7)
                    {
                        penna_Settings.IP_Address4_counter1 = i.IP_Address;
                        penna_Settings.Port4_counter1 = i.Port_No;
                    }
                    if (j == 8)
                    {
                        penna_Settings.IP_Address4_counter2 = i.IP_Address;
                        penna_Settings.Port4_counter2 = i.Port_No;
                    }


                    j += 1;
                }
                ViewData["printers"] = penna_Settings;
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Managesettings / Index : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
            }
            return penna_Settings;
        }
    }


}