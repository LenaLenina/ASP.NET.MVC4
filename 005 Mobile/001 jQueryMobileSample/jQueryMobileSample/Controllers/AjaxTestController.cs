using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace jQueryMobileSample.Controllers
{
    public class AjaxTestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult First()
        {
            Thread.Sleep(2000);
            return View();
        }

        public ActionResult Second()
        {
            Thread.Sleep(2000);
            return View();
        }
    }
}
