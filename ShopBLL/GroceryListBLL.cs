using ShopCommon.MdProducts;
using ShopDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBLL
{
    public class GroceryListBLL
    {
        GroceryListDAL _dal = new GroceryListDAL();

        public int AddProductToGroceryList(int idProducto)
        {
            return _dal.AddProductToGroceryList(idProducto);
        }

        public List<GroceryList> ListPersonal()
        {
            return _dal.GroceryList();
        }

        public List<Product> ListProducts()
        {
            return _dal.ListProducts();
        }

        public int DeleteProduct(int IdProduct)
        {
            return _dal.DeleteProduct(IdProduct);
        }

        public int TagInGroceryList(int IdProduct)
        {
            return _dal.TagInGroceryList(IdProduct);
        }
    }
}
