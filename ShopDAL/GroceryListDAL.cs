using ShopCommon.MdProducts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDAL
{
    public class GroceryListDAL
    {
        #region [Insertar Productos]

        /// <summary>
        /// Método para insertar productos a la lista
        /// </summary>
        /// <param name="objProduct">Objeto con la información del producto a insertar</param>
        /// <returns>El resultado del query</returns>
        public int AddProductToGroceryList(int idProducto)
        {
            using (IDbConnection Conexion = DbConection.Conexion())
            {
                Conexion.Open();

                SqlCommand command = new SqlCommand("spAddProductToGroceryList", Conexion as SqlConnection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@pIdProducto", idProducto));                

                int result = command.ExecuteNonQuery();

                return result;
            }
        }
        #endregion

        #region [Listar Productos Personales]
        /// <summary>
        /// Método para mostrar los productos en la Grocery List
        /// </summary>
        /// <returns>Una lista de los productos que hay en la BD en la tabla personal</returns>
        public List<GroceryList> GroceryList()
        {
            using (IDbConnection Conexion = DbConection.Conexion())
            {
                Conexion.Open();

                SqlCommand command = new SqlCommand("spGetGroceryList", Conexion as SqlConnection);
                command.CommandType = CommandType.StoredProcedure;

                IDataReader productsReader = command.ExecuteReader();

                List<GroceryList> lstProductsPersonal = new List<GroceryList>();

                while (productsReader.Read())
                {
                    GroceryList objListProductPersonal = new GroceryList();

                    objListProductPersonal.idProducto = Convert.ToInt32(productsReader["idProducto"]);
                    objListProductPersonal.Tag = Convert.ToBoolean(productsReader["Tag"]);
                    objListProductPersonal.NameProduct = Convert.ToString(productsReader["NameProduct"]);
                    objListProductPersonal.Cod = Convert.ToInt32(productsReader["Cod"]);
                    objListProductPersonal.Price = Convert.ToInt32(productsReader["Price"]);

                    lstProductsPersonal.Add(objListProductPersonal);
                }

                return lstProductsPersonal;
            }
        }
        #endregion

        #region [Listar Productos en General]
        /// <summary>
        /// Método para mostrar los productos de la lista de productos
        /// </summary>
        /// <returns>Una lista de todos los productos que hay en la BD</returns>
        public List<Product> ListProducts()
        {
            using (IDbConnection Conexion = DbConection.Conexion())
            {
                Conexion.Open();

                SqlCommand command = new SqlCommand("spListProduct", Conexion as SqlConnection);
                command.CommandType = CommandType.StoredProcedure;

                IDataReader productReader = command.ExecuteReader();

                List<Product> lstProducts = new List<Product>();

                while (productReader.Read())
                {
                    Product objListProduct = new Product();

                    objListProduct.IdProduct = Convert.ToInt32(productReader["IdProduct"]);
                    objListProduct.NameProduct = Convert.ToString(productReader["NameProduct"]);
                    objListProduct.Cod = Convert.ToInt32(productReader["Cod"]);
                    objListProduct.Price = Convert.ToInt32(productReader["Price"]);

                    lstProducts.Add(objListProduct);
                }

                return lstProducts;
            }
        }
        #endregion

        #region [Eliminar Productos de la pista personal]
        /// <summary>
        /// Método para eliminar productos de Grocery List
        /// </summary>
        /// <param name="IdProduct">Campo que se quiere eliminar</param>
        /// <returns>El resultado del Query</returns>
        public int DeleteProduct(int IdProduct)
        {
            using (IDbConnection Conexion = DbConection.Conexion())
            {
                Conexion.Open();

                SqlCommand command = new SqlCommand("spDeleteProductFromGroceryList", Conexion as SqlConnection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@pIdProduct", IdProduct));

                int result = command.ExecuteNonQuery();

                return result;
            }
        }
        #endregion

        #region [Marcar y Desmarcar Producto]
        /// <summary>
        /// Método para marcar y desmarcar producto mediante un checkbox
        /// </summary>
        /// <param name="IdProduct">Cambia valor en la tabla</param>
        /// <returns></returns>
        public int TagInGroceryList(int IdProducto)
        {
            using (IDbConnection Conexion = DbConection.Conexion())
            {
                Conexion.Open();

                SqlCommand command = new SqlCommand("spSetTagProductInGroceryList", Conexion as SqlConnection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@pIdProduct", IdProducto));

                int result = command.ExecuteNonQuery();

                return result;
            }            
        }
        #endregion
    }
}