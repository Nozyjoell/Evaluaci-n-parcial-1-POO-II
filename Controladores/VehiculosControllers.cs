using AlquilerDeVehiculos.Base_Datos;
using AlquilerDeVehiculos.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace AlquilerDeVehiculos.Controladores
{
    public class VehiculosControllers
    {
        private readonly ConexionMysql _mysql = new ConexionMysql();

        public VehiculosModel insertar(VehiculosModel vehiculos)
        {
            using(MySqlConnection cn = _mysql.ObtenerConexion())
            {
                cn.Open();
                StringBuilder cadena = new StringBuilder();
                cadena.Append("INSERT INTO vehiculos ");
                cadena.Append("(marca, modelo, placa, estado)");
                cadena.Append("VALUES");
                cadena.Append("(@marca, @modelo, @placa, @estado)");

                using (MySqlCommand cmd= new MySqlCommand(cadena.ToString(), cn))
                {
                    cmd.Parameters.AddWithValue("@marca", vehiculos.marca);
                    cmd.Parameters.AddWithValue("@modelo", vehiculos.modelo);
                    cmd.Parameters.AddWithValue("@placa", vehiculos.placa);
                    cmd.Parameters.AddWithValue("@estado", vehiculos.estado);

                    try
                    {
                        int filas = cmd.ExecuteNonQuery();

                        if(filas > 0)
                        {
                            vehiculos.id_vehiculo = Convert.ToInt32(cmd.LastInsertedId);
                            return vehiculos;
                        }
                        return null;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al registrar vehiculo: " + ex.Message);
                    }
                }
            }
            return vehiculos;
        }

        public List<VehiculosModel> todos()
        {
            List<VehiculosModel> lista = new List<VehiculosModel>();

            using(MySqlConnection cn = _mysql.ObtenerConexion())
            {
                try
                {
                    if(cn.State != System.Data.ConnectionState.Open)
                    {
                        cn.Open();
                    }

                    string cadena = "SELECT id_vehiculo, marca, modelo, " +
                            "placa, estado FROM Vehiculos";
                    using (MySqlCommand cmd = new MySqlCommand(cadena, cn))
                    {
                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                VehiculosModel vehiculo = new VehiculosModel
                                {
                                    id_vehiculo = lector.GetInt32("id_vehiculo"),
                                    marca = lector.GetString("marca"),
                                    modelo = lector.GetString("modelo"),
                                    placa = lector.GetString("placa"),
                                    estado = lector.GetString("estado")
                                };
                                lista.Add(vehiculo);
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception("Error al consultar vehículos: " + ex.Message);
                }
            }
            return lista;
        }

        public bool eliminar(int idVehiculo)
        {
            using(MySqlConnection cn = _mysql.ObtenerConexion())
            {
                cn.Open();
                string cadena = "DELETE FROM vehiculos WHERE id_vehiculo = @id";
                using(MySqlCommand cmd = new MySqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@id", idVehiculo);
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }
    }
}
