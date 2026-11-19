using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace AlquilerDeVehiculos.Base_Datos
{
    public class ConexionMysql
    {
        private readonly string cn = "server=localhost;" +
            "database=alquiler_vehiculos;" +
            "user=root;" +
            "password=";

        public MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(cn);
        }
    }
}
