using ShopCommon.MdProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopPesentation.Controllers.Api
{
    public class ProductsApiController : ApiController
    {
        // GET: api/ProductsApi
        public IEnumerable<Product> Get()
        {
            var prod = new Product()
            {
                Cod = 1,
                IdProduct = 1,
                NameProduct = "Tenis"
            };

            var lstProducts = new List<Product>();
            lstProducts.Add(prod);

            return lstProducts;
        }

        // GET: api/ProductsApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ProductsApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ProductsApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProductsApi/5
        public void Delete(int id)
        {
        }
    }
}
