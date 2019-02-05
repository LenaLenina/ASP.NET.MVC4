using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _07_BundlingAndMinification.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NotOptimized()
        {
            ViewBag.Message = "Загрузка НЕ оптимизированной страницы.";

            return View();
        }

        public ActionResult Optimized()
        {
            ViewBag.Message = "Загрузка оптимизированной страницы.";

            return View();
        }

    }
}
