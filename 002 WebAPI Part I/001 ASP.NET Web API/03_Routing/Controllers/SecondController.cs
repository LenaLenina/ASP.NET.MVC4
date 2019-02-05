using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _03_Routing.Controllers
{
    public class SecondController : ApiController
    {
        // Метод сработает при получении GET запроса.
        [HttpGet]
        public string SayHello()
        {
            return "Сработал метод SayHello c атрибутом HttpGet";
        }
    }
}
