using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace _02_Routing
{
    public static class WebApiConfig
    {
        // ASP.NET маршрутизация необходима для связывания URI и методов контроллеров.
        // Регистрация маршрута происходить с помощью его добавления в коллекцию маршрутов 
        // класса HttpConfiguration с помощью мтода MapHttpRoute.

        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",                             // 1) Имя маршрута
                routeTemplate: "api/{controller}/{id}",         // 2) Шаблон маршрута
                defaults: new { id = RouteParameter.Optional }  // 3) объект, содержащий дополнительные параметры и их настройки
            );
        }
    }
}
// Шаблон содержит в начале "api/" - это не является необходимым, нужно для совместной работы маршрутизации MVC и Web API
// В ASP.NET MVC4 как контроллеры представлений, так и контроллеры Web API можно располагать в любых папках.