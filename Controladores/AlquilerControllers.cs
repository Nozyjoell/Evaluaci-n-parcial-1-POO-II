using AlquilerDeVehiculos.Base_Datos;
using AlquilerDeVehiculos.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlquilerDeVehiculos.Controladores
{
    
    public class AlquilerControllers
    {
        private readonly ConexionMysql _mysql = new ConexionMysql();

        public AlquileresModel insertar(AlquileresModel alquiler)
        {
            using (MySqlConnection cn = _mysql.ObtenerConexion())
            {
                cn.Open();

                string cadena = "INSERT INTO alquileres " +
                    "(id_cliente, id_vehiculo, fecha_inicio, fecha_fin, costo) " +
                    "VALUES (@id_cliente, @id_vehiculo, @fecha_inicio, " +
                    "@fecha_fin, @costo)";

                using (MySqlCommand cmd = new MySqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@id_cliente", alquiler.id_cliente);
                    cmd.Parameters.AddWithValue("@id_vehiculo", alquiler.id_vehiculo);
                    cmd.Parameters.AddWithValue("@fecha_inicio", alquiler.fecha_inicio);
                    cmd.Parameters.AddWithValue("@fecha_fin", alquiler.fecha_fin);
                    cmd.Parameters.AddWithValue("@costo", alquiler.costo);

                    try
                    {
                        int filas = cmd.ExecuteNonQuery();
                        if (filas > 0)
                        {
                            alquiler.id_cliente = Convert.ToInt32(cmd.LastInsertedId);
                            return alquiler;
                        }
                        return null;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al registrar cliente: " + ex.Message);
                    }
                }

            }
        }

        public List<AlquileresModel> todos()
        {
            List<AlquileresModel> lista = new List<AlquileresModel>();

            using (MySqlConnection cn = _mysql.ObtenerConexion())
            {
                try
                {
                    if (cn.State != System.Data.ConnectionState.Open)
                    {
                        cn.Open();
                    }

                    string cadena = "SELECT a.id_alquiler, a.id_cliente, " +
                     "a.id_vehiculo, a.fecha_inicio, a.fecha_fin, a.costo, " +
                     "c.nombre AS nombre_cliente, v.placa AS placa_vehiculo " +
                     "FROM alquileres a " +
                     "INNER JOIN clientes c ON a.id_cliente = c.id_cliente " +
                     "INNER JOIN vehiculos v ON a.id_vehiculo = v.id_vehiculo";

                    using (MySqlCommand cmd = new MySqlCommand(cadena, cn))
                    {
                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                AlquileresModel alquiler = new AlquileresModel
                                {
                                    id_alquiler = lector.GetInt32("id_alquiler"),
                                    id_cliente = lector.GetInt32("id_cliente"),
                                    id_vehiculo = lector.GetInt32("id_vehiculo"),
                                    fecha_inicio = lector.GetDateTime("fecha_inicio"),
                                    fecha_fin = lector.GetDateTime("fecha_fin"),
                                    costo = lector.GetDecimal("costo"),
                                    nombre_cliente = lector.GetString("nombre_cliente"),
                                    placa_vehiculo = lector.GetString("placa_vehiculo")
                                };
                                lista.Add(alquiler);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al consultar el alquiler: " + ex.Message);
                }
            }
            return lista;
        }

        public bool eliminar(int idAlquiler)
        {
            using (MySqlConnection cn = _mysql.ObtenerConexion())
            {
                cn.Open();

                string cadena =
                   "DELETE FROM alquileres WHERE id_alquiler = @id";


                using (MySqlCommand cmd = new MySqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@id", idAlquiler);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
        }
    }
}
