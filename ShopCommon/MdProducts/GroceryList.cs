using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCommon.MdProducts
{
    /// <summary>
    /// Modelo de la GroceryList
    /// </summary>
    public class GroceryList
    {
        public int idProducto { get; set; }

        public bool Tag { get; set; }

        public string NameProduct { get; set; }

        public int Cod { get; set; }

        public int Price { get; set; }
    }
}
