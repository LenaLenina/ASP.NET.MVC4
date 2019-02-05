using _05_ModelLibrary.Clients;
using _05_ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public async Task<ActionResult> Index()
        {
            ServicesModel model = new ServicesModel();
            NewsClient newsClient = new NewsClient();
            WeatherClient weatherClient = new WeatherClient();

            model.AddMessage("Index запущен");

            model.AddMessage("Выполнение задачи получения новостей");

            // После вызова метода newsClient.GetNewsAsync() поток IIS вернется в пул потоков.
            // Поток, который был создан в методе GetNewsAsync() получив ответ от службы продолжит выполнение 
            // данного метода действия.
            model.News = await newsClient.GetNewsAsync(); // задержка 2 секунды

            model.AddMessage("Выполнение задачи получения температуры");

            // На этом этапе будет создан еще один поток, предыдущий поток прекратит свою работу.
            model.Weather = await weatherClient.GetWeatherInfoAsync(); // задержка 2 секунды

            model.AddMessage("Index завершен");

            // ответ клиенту будет возвращать поток который был создан при вызове GetWeatherInfoAsync() 
            return View(model);
        }
    }
}
