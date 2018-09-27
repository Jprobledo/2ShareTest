using ShopBLL;
using ShopCommon.MdProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopPresentation.Controllers
{
    public class ListGroceryApiController : ApiController
    {
        // GET: api/ListGrocery
        public IEnumerable<Product> Get()
        {
            GroceryListBLL objGroceryListBll = new GroceryListBLL();
            var lstGroceryList = objGroceryListBll.ListProducts();
            return lstGroceryList;
        }

        // GET: api/ListGrocery/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ListGrocery
        public void Post(int IdProduct)
        {
            try
            {
                var groceryListBLL = new GroceryListBLL();
                groceryListBLL.AddProductToGroceryList(IdProduct);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT: api/ListGrocery/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ListGrocery/5
        public void Delete(int idProduct)
        {
            GroceryListBLL objGroceryListBLL = new GroceryListBLL();
            var deleteGroceryList = objGroceryListBLL.DeleteProduct(idProduct);
        }
    }
}
