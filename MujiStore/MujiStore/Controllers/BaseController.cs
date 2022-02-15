using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Globalization;
namespace MujiStore.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
       
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
           Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Session["CreateSpecificCulture"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["CreateSpecificCulture"].ToString());


            return base.BeginExecuteCore(callback, state);
        }


      
    }
}