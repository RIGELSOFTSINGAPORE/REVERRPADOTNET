using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasthu_Models;
using Vasthu_DataAccess;

namespace Vastu_Business
{
    public class TransactionReportBusinessLayer
    {
        private TransactionReportDataAccess _TransactionReportDataAccess { get; set; }
        public TransactionReportBusinessLayer()
        {
            _TransactionReportDataAccess = new TransactionReportDataAccess();
        }
        public List<TransReport> SearchTrans()
        {
            try
            {
                return _TransactionReportDataAccess.SearchTrans();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<TransReport> SearchTransDate(DateTime frmdate, DateTime todate)
        {
            try
            {
                return _TransactionReportDataAccess.SearchFeedbackAdmin(frmdate, todate);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
