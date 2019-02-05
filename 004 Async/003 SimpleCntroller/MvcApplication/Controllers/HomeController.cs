using _05_ModelLibrary.Clients;
using _05_ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        // Код в данном методе будет выполнен одинм потоком из пула потоков IIS сервера.

        public ActionResult Index()
        {
            ServicesModel model = new ServicesModel();
            NewsClient newsClient = new NewsClient();
            WeatherClient weatherClient = new WeatherClient();

            model.AddMessage("Index запущен");

            model.AddMessage("Выполнение задачи получения новостей");
            model.News = newsClient.GetNews();

            model.AddMessage("Выполнение задачи получения температуры");
            model.Weather = weatherClient.GetWeatherInfo();

            model.AddMessage("Index завершен");

            return View(model);
        }
    }
}
