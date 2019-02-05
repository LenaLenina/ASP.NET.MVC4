using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _03_Routing.Controllers
{
    public class FirstController : ApiController
    {
        // Метод сработает при получении GET запроса.
        public string Get()
        {
            return "Сработал метод Get";
        }
    }
}
