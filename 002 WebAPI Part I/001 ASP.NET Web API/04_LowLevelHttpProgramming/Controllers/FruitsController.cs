using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _06_WebAPISample.Controllers
{
    public class FruitsController : ApiController
    {
        static List<string> _fruits = new List<string>() 
        { 
            "Orange", 
            "Apple", 
            "Plum",
            "Apricot"
        };

        // GET api/fruits
        public IEnumerable<string> Get()
        {
            return _fruits;
        }

        // GET api/fruits/5
        public string Get(int id)
        {
            return _fruits[id];
        }

        // POST api/fruits
        // FromBody - атрибут указывает что значение для параметра name должно извлекаться из тела запроса.
        public HttpResponseMessage Post([FromBody]string fruit)
        {
            _fruits.Add(fruit);

            HttpResponseMessage msg = Request.CreateResponse(HttpStatusCode.Created, fruit);
            // var msg = Request.CreateResponse(HttpStatusCode.BadRequest);

            // Location заголовок стоит создавать, если новый элемент был создан
            msg.Headers.Location = new Uri(Request.RequestUri + "/" + (_fruits.Count - 1));

            return msg;
        }

        // Для того что бы HTTP методы могли работать при запуске в IIS Express необходимо поменять файл конфигурации, который находится по пути
        // C:\\Users\<UserName>\Documents\IISExpress\config\applicationhost.config

        // <add name="ExtensionlessUrl-Integrated-4.0" path="*." verb="GET,HEAD,POST,DEBUG" type="System.Web.Handlers.TransferRequestHandler" preCondition="integratedMode,runtimeVersionv4.0" responseBufferLimit="0" />
        // В атрибут verb элемента указанного выше, необъодимо добавить необходимые глаголы.

        // Если на компьютере установлен WebDAV Publishing его нужно удалить через "программы и компоненты".
        // http://stackoverflow.com/questions/3946283/enabling-html-put-method-on-iis-7-5

        // PUT api/fruits/5
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            if (id > _fruits.Count)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                _fruits[id] = value;
                return Request.CreateResponse(HttpStatusCode.OK, _fruits[id]);
            }
        }

        // DELETE api/fruits/5
        public HttpResponseMessage Delete(int id)
        {
            if (id > _fruits.Count)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                string deleted = _fruits[id];
                _fruits.RemoveAt(id);
                return Request.CreateResponse(HttpStatusCode.OK, deleted);
            }
        }
    }
}