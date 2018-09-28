using ShopBLL;
using ShopCommon.MdProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopPresentation.Controllers
{
    public class HomeController : Controller
    {   
        /// <summary>
        /// Método para mostrar la Grocery List
        /// </summary>
        /// <returns> retorna una vista con la Grocery List</returns>
        public ActionResult Index()
        {
            try
            {
                GroceryListBLL objGroceryListBll = new GroceryListBLL();
                var lstGroceryList = objGroceryListBll.ListPersonal();
                return View(lstGroceryList);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Método para mostrar la lista de productos 
        /// </summary>
        /// <returns>Retorna una vista con la lista de productos</returns>
        public ActionResult ListProducts()
        {
            try
            {
                GroceryListBLL objGroceryListBll = new GroceryListBLL();
                var lstProductList = objGroceryListBll.ListProducts();
                return View(lstProductList);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}