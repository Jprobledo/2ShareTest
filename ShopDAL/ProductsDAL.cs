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
    public class ProductsDAL
    {
        #region [Insertar Productos]

        /// <summary>
        /// Método para insertar productos en la base de datos
        /// </summary>
        /// <param name="objProduct">Objeto con la información del producto a insertar</param>
        /// <returns>El resultado del query</returns>
        public int InsertProducts(Product objProduct)
        {
            using (IDbConnection Conexion = DbConection.Conexion())
            {
                Conexion.Open();

                //Entre comillas se pone el nombre del PS que tenemos en la BD
                SqlCommand command = new SqlCommand("InsertProducts", Conexion as SqlConnection);
                //Establecemos parametros que se van a llenar de esta manera
                command.CommandType = CommandType.StoredProcedure;
                //se empiezan a llamar los parametros
                command.Parameters.Add(new SqlParameter("@pNameProduct", objProduct.NameProduct));
                command.Parameters.Add(new SqlParameter("@pCod", objProduct.Cod));
                command.Parameters.Add(new SqlParameter("@pPrice", objProduct.Price));

                int result = command.ExecuteNonQuery();

                return result;
            }
        }
        #endregion

        #region [Listar Los Productos]
        public List<Product> ListProduct()
        {
            using (IDbConnection Conexion = DbConection.Conexion())
            {
                Conexion.Open();

                //Entre comillas se pone el nombre del PS que tenemos en la BD
                SqlCommand command = new SqlCommand("ListProduct", Conexion as SqlConnection);

                command.CommandType = CommandType.StoredProcedure;
                //Establecemos parametros que se van a llenar
                IDataReader productReader = command.ExecuteReader();

                // Se crea la lista o el objeto que la contiene
                List<Product> List = new List<Product>();

                // Lista a mostrar
                while (productReader.Read())
                {
                    Product objProduct = new Product();
                    objProduct.IdProduct = Convert.ToInt32(productReader["IdProduct"]);
                    objProduct.NameProduct = Convert.ToString(productReader["NameProduct"]);
                    objProduct.Cod = Convert.ToInt32(productReader["Cod"]);
                    objProduct.Price = Convert.ToInt32(productReader["Price"]);
                    List.Add(objProduct);
                }

                return List;
            }
        }
        #endregion

        #region [Editar Productos]
        public int ModifyProduct(Product objProduct)
        {

            using (IDbConnection Conexion = DbConection.Conexion())
            {
                Conexion.Open();

                SqlCommand command = new SqlCommand("ModifyProduct", Conexion as SqlConnection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@pIdProduct", objProduct.IdProduct));
                command.Parameters.Add(new SqlParameter("@pNameProduct", objProduct.NameProduct));
                command.Parameters.Add(new SqlParameter("@pCod", objProduct.Cod));
                command.Parameters.Add(new SqlParameter("@pPrice", objProduct.Price));

                int result = command.ExecuteNonQuery();

                return result;
            }
        }
        #endregion

        #region [Eliminar Productos]
        public int RemoveProduct(int IdProduct)
        {
            using (IDbConnection Conexion = DbConection.Conexion())
            {
                Conexion.Open();

                SqlCommand command = new SqlCommand("RemoveProduct", Conexion as SqlConnection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@pIdProduct", IdProduct));

                int result = command.ExecuteNonQuery();

                return result;
            }
        }

        #endregion

        //TODO: No entregar sin eliminar esta clase por completo
    }
}
