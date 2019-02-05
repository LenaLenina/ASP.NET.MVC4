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
        //
        public async Task<ActionResult> Index()
        {
            ServicesModel model = new ServicesModel();

            model.AddMessage("Запуск метода действия");

            #region Вызов асинхронных задач. Не корректное поведение контроллера

            GetLastNewsAsync(model);
            GetWeatherAsync(model);

            #endregion

            #region 1. Последовательное выполнение с await

            //await GetLastNewsAsync(model);
            //await GetWeatherAsync(model);
            #endregion

            #region 2. Параллельное выполнение c await

            //Task newsTask = GetLastNewsAsync(model);
            //Task weatherTask = GetWeatherAsync(model);
            //await Task.WhenAll(newsTask, weatherTask);
            
            #endregion

            model.AddMessage("Завершение метода действия");

            ViewBag.Header = "Асинхронный метод действия с параллельными задачами";
            return View(model);
        }

        async Task GetLastNewsAsync(ServicesModel model)
        {
            model.AddMessage("Запуск получения новостей");
            NewsClient newsClient = new NewsClient();
            model.News = await newsClient.GetNewsAsync();
            model.AddMessage("Завершение получения новостей");
        }

        async Task GetWeatherAsync(ServicesModel model)
        {
            model.AddMessage("Запуск получения погоды");
            WeatherClient weatherClient = new WeatherClient();
            model.Weather = await weatherClient.GetWeatherInfoAsync();
            model.AddMessage("Завершение получения погоды");
        }

    }
}
