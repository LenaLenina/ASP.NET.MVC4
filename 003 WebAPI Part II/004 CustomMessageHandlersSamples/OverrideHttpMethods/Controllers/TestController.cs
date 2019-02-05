using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OverrideHttpMethods.Controllers
{
    public class TestController : ApiController
    {
        // GET api/test
        public IEnumerable<string> Get()
        {
            Debug.WriteLine("Get");
            return new string[] { "value1", "value2" };
        }

        // GET api/test/5
        public string Get(int id)
        {
            Debug.WriteLine("Get id");
            return "value";
        }

        // POST api/test
        public void Post([FromBody]string value)
        {
            Debug.WriteLine("Post");
        }

        // PUT api/test/5
        public void Put(int id, [FromBody]string value)
        {
            Debug.WriteLine("Put");
        }

        // DELETE api/test/5
        public void Delete(int id)
        {
            Debug.WriteLine("Delete");
        }
    }
}
