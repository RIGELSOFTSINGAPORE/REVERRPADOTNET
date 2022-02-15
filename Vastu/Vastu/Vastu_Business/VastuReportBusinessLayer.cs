using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_Models;
using Vasthu_DataAccess;

namespace Vastu_Business
{
    public class VastuReportBusinessLayer
    {
        private VastuReportDataAccess_New _VastuReportDataAccess { get; set; }

        public VastuReportBusinessLayer()
        {
            _VastuReportDataAccess = new VastuReportDataAccess_New();
        }

        // write your own business logic
        public List<AreaReport> Interior()
        {
            try
            {
                return _VastuReportDataAccess.Interior();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public List<DirectionReport> Direction()
        {
            try
            {
                return _VastuReportDataAccess.Direction();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        //public List<VastuReportOutput> DownLoadReport(InputToReport obj)
        // {
        //     try
        //     {
        //         return  _VastuReportDataAccess.DownLoadReport(obj);
        //     }
        //     catch (Exception ex)
        //     {

        //         throw ex;
        //     }
        // }
        public List<ShowFinalReport> DownLoadReport(InputToReport obj, InputTextToReport obj2, int VasthuType, string EmailId, string SessionReportId, string IPAddress, string ResearcherName,string language,int UserID)
        {
            try
            {
                return _VastuReportDataAccess.DownLoadReport(obj, obj2,VasthuType, EmailId, SessionReportId, IPAddress, ResearcherName, language, UserID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<VasthuReportType> VasthuType()
        {
            try
            {
                return _VastuReportDataAccess.VasthuType();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<GetVastuEmailInformation> GetEmailInformation(long VastuReportID)
        {
            try
            {
                return _VastuReportDataAccess.GetEmailInformation(VastuReportID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        #region Report
        public List<ShowFinalReport> DownLoadReport_His(int id, string lan)
        {
            try
            {
                return _VastuReportDataAccess.DownLoadReport_His(id, lan);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
