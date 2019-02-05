using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace _03_DisplayModeProvider.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            // Получение списка режимов которые поддерживает текущее приложение.
            // В файле App_Start/DisplayModeConfig определены новые режимы отображеня для данного приложения.
            IList<IDisplayMode> model = DisplayModeProvider.Instance.Modes;
            ViewBag.Data = "You've requested for " + Request.Url.AbsoluteUri;
            return View(model);
        }

    }
}
