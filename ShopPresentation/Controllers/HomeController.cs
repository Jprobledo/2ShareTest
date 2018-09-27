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
        public ActionResult Index()
        {
            GroceryListBLL objGroceryListBll = new GroceryListBLL();
            var lstGroceryList = objGroceryListBll.ListPersonal();
            return View(lstGroceryList);
        }

        public ActionResult ListProducts()
        {
            GroceryListBLL objGroceryListBll = new GroceryListBLL();
            var lstProductList = objGroceryListBll.ListProducts();
            return View(lstProductList);
        }
    }
}