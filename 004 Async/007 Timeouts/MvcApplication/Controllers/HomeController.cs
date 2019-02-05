using _05_ModelLibrary.Clients;
using _05_ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        // Если выполнение асинхронных задач не завершится в течении 1 секунды произойдет исключение TimeoutException
        // Для того что бы таймаут сработал метод действия должен принимать параметр типа CancellationToken
        [AsyncTimeout(1000)]

        // Для того что бы отображались пользовательские страницы ошибок, в файл web.config нужно добавить
        // <customErrors mode="On"></customErrors>
        [HandleError(ExceptionType = typeof(TimeoutException), View = "TimeoutError")]
        public async Task<ActionResult> Index(CancellationToken ctk)
        {
            ServicesModel model = new ServicesModel();
            NewsClient newsClient = new NewsClient();
            WeatherClient weatherClient = new WeatherClient();

            model.AddMessage("Index запущен");

            Task<NewsModel> newsTask = newsClient.GetNewsAsync();
            Task<WeatherModel> weatherTask = weatherClient.GetWeatherInfoAsync();
            await Task.WhenAll(newsTask, weatherTask);

            model.News = newsTask.Result;
            model.Weather = weatherTask.Result;

            model.AddMessage("Index завершен");


            return View(model);
        }
    }
}