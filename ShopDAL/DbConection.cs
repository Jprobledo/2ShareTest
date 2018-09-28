using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDAL
{
    public static class DbConection
    {
        //Conexion con la Base de Datos llamando la ConnectionString de webconfig
        private static string conn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static IDbConnection Conexion()
        {
            return new SqlConnection(conn);
        }
    }
}
