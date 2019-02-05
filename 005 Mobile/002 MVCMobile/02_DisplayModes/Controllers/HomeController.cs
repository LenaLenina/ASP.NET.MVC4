using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02_DisplayModes.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Uri = string.Format("You've requested for {0}.", Request.Url.AbsoluteUri);
            ViewBag.Time = string.Format("Current time is: {0}", DateTime.Now.ToLongTimeString());

            return View();
        }

    }
}
