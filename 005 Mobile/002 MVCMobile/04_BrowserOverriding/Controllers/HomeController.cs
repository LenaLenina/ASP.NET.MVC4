using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace _04_BrowserOverriding.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            IList<IDisplayMode> model = DisplayModeProvider.Instance.Modes;
            ViewBag.Data = "You've requested for " + Request.Url.AbsoluteUri;
            return View(model);
        }

        [HttpPost]
        public RedirectToRouteResult Index(string value)
        {
            switch (value)
            {
                case "mobile":
                    HttpContext.SetOverriddenBrowser(BrowserOverride.Mobile);
                    break;
                case "desktop":
                    HttpContext.SetOverriddenBrowser(BrowserOverride.Desktop);
                    break;
                case "iPhone":
                    HttpContext.SetOverriddenBrowser(@"Mozilla/5.0 (iPhone; CPU iPhone OS 6_0 like Mac OS X) AppleWebKit/536.26 (KHTML, like Gecko) Version/6.0 Mobile/10A405 Safari/8536.25");
                    break;
                default:
                    HttpContext.ClearOverriddenBrowser();
                    break;
            }
            return RedirectToAction("Index");
        }
    }
}
