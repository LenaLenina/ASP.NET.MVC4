using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _02_Routing.Controllers.WebApi
{
    public class DateController : ApiController
    {
        // GET api/date
        public string Get()
        {
            return DateTime.Now.ToString();
        }

    }
}
