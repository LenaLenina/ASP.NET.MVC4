
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace _05_WebAPISample.Controllers
{
    public class FruitsController : ApiController
    {
        static string[] _fruits =  
        { 
            "Orange", 
            "Apple", 
            "Plum",
            "Apricot"
        };

        // GET api/name
        public IEnumerable<string> Get()
        {
            return _fruits;
        }

        // GET api/values/5

        #region  Такой метод возвращает ошибку сервера, если пользователь запрашивает id значения, не попадающий в размер коллекции
        //public string Get(int id)
        //{
        //    return _fruits[id];
        //} 
        #endregion

        #region Такая реализация возвращает правильный ответ: 404 - Not Found
        public HttpResponseMessage Get(int id)
        {
            if (id < _fruits.Length)
            {
                return Request.CreateResponse(HttpStatusCode.OK, _fruits[id]);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Item not found"); //Status code 404
            }
        }
        #endregion

    }
}