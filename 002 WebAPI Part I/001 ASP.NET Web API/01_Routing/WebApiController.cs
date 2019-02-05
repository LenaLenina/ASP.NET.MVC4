using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace _01_Routing
{
    // Контроллер отвечает на запросы, сделанные по адресу localhost:port/webapi
    public class WebApiController : ApiController
    {
        // Метод выполнится при получении HTTP GET запроса
        public string Get()
        {
            return "Hello from WebApi at " + DateTime.Now.ToShortTimeString();
        }
    }
}