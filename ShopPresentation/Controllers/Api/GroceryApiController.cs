using ShopBLL;
using ShopCommon.MdProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopPresentation.Controllers.Api
{
    public class GroceryApiController : ApiController
    {
        // GET: api/GroceryApi
        public IEnumerable<Product> Get()
        {
            GroceryListBLL objGroceryListBll = new GroceryListBLL();
            var lstGroceryList = objGroceryListBll.ListProducts();
            return lstGroceryList;
        }

        // GET: api/GroceryApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GroceryApi
        public void Post(int IdProducto)
        {
            try
            {
                var groceryListBLL = new GroceryListBLL();
                groceryListBLL.AddProductToGroceryList(IdProducto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("api/GroceryApi/TagProduct/{IdProducto}")]
        // POST: api/GroceryApi/TagProduct
        public void TagProduct(int IdProducto)
        {
            try
            {
                var groceryListBLL = new GroceryListBLL();
                groceryListBLL.TagInGroceryList(IdProducto);
            }
            catch (Exception ex)
            {                
            }
        }

        // DELETE: api/GroceryApi/5
        public void Delete(int idProducto)
        {
            try
            {
                var groceryListBLL = new GroceryListBLL();
                groceryListBLL.DeleteProduct(idProducto);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
