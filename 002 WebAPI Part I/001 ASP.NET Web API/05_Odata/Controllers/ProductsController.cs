using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _05_Odata.Models;

namespace _05_Odata.Controllers
{
    public class ProductsController : ApiController
    {
        // GET api/values
        // Для того, чтоб работал OData протокол необходимо через NuGet добавить в проект библиотеку OData

        [HttpGet]
        [Queryable]
        public IQueryable<Product> AllProducts()
        {
            return Products.GetAllProducts().AsQueryable<Product>();
        }

    }
}