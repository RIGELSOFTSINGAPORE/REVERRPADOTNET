using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using PennaMiddleWare.Models;
namespace PennaMiddleWare.BLL
{
    public class Common
    {
        public DataTable ToDataTable<T>(List<T> items)

        {

            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties

            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in Props)

            {

                //Setting column names as Property names

                dataTable.Columns.Add(prop.Name);

            }

            foreach (T item in items)

            {

                var values = new object[Props.Length];

                for (int i = 0; i < Props.Length; i++)

                {

                    //inserting property values to datatable rows

                    values[i] = Props[i].GetValue(item, null);

                }

                dataTable.Rows.Add(values);

            }

            //put a breakpoint here and check datatable

            return dataTable;

        }

        public static List<Schdates> schdatNew(DateTime stdate, DateTime eddate)
        {
            List<Schdates> schdat = new List<Schdates>();

            int i = 0;
            DateTime StartDate = stdate;
            DateTime EndDate = eddate;
            foreach (DateTime day in Common.EachCalendarDay(StartDate, EndDate))
            {
                Schdates sch = new Schdates();
                sch.RowNo = i;
                sch.startdate = day.ToString("yyyyMMdd");

                if (EndDate < day.AddDays(1))
                {
                    sch.enddate = EndDate.ToString("yyyyMMdd");
                }
                else
                {
                    sch.enddate = day.AddDays(Convert.ToInt16(1) - 1).ToString("yyyyMMdd");
                }
                //Console.WriteLine("Date is : " + day.ToString("dd-MM-yyyy"));
                i += 1;
                schdat.Add(sch);
            }

            return schdat;
        }

        public static IEnumerable<DateTime> EachCalendarDay(DateTime startDate, DateTime endDate)
        {
            for (var date = startDate.Date; date.Date <= endDate.Date; date = date.AddDays(1)) yield
            return date;
        }
    }
    public class FileInfo
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }

    
}