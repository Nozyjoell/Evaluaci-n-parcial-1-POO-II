using AlquilerDeVehiculos.Base_Datos;
using AlquilerDeVehiculos.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlquilerDeVehiculos.Controladores
{
    public class ClientesControllers
    {
        private readonly ConexionMysql _mysql = new ConexionMysql();

        public ClientesModel insertar(ClientesModel cliente)
        {
            using (MySqlConnection cn = _mysql.ObtenerConexion())
            {
                cn.Open();

                String cadena = "INSERT INTO Clientes " +
                    "(nombre, cedula, telefono) " +
                    "VALUES (@nombre, @cedula, @telefono)";

                using (MySqlCommand cmd = new MySqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", cliente.nombre);
                    cmd.Parameters.AddWithValue("@cedula", cliente.cedula);
                    cmd.Parameters.AddWithValue("@telefono", cliente.telefono);

                    try
                    {
                        int filas = cmd.ExecuteNonQuery();
                        if (filas > 0)
                        {
                            cliente.id_cliente = Convert.ToInt32(cmd.LastInsertedId);
                            return cliente;
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

        public List<ClientesModel> todos()
        {
            List<ClientesModel> lista = new List<ClientesModel>();

            using (MySqlConnection cn = _mysql.ObtenerConexion())
            {
                try
                {
                    if (cn.State != System.Data.ConnectionState.Open)
                    {
                        cn.Open();
                    }

                    string cadena = "SELECT id_cliente, nombre, " +
                    "cedula, telefono FROM clientes";
                    using (MySqlCommand cmd = new MySqlCommand(cadena, cn))
                    {
                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                ClientesModel cliente = new ClientesModel
                                {
                                    id_cliente = lector.GetInt32("id_cliente"),
                                    nombre = lector.GetString("nombre"),
                                    cedula = lector.GetString("cedula"),
                                    telefono = lector.IsDBNull(
                                    lector.GetOrdinal("telefono"))
                                    ? ""
                                    : lector.GetString("telefono")
                                };
                                lista.Add(cliente);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al consultar clientes: " + ex.Message);
                }
            }
            return lista;
        }

        public bool eliminar(int idCliente)
        {
            using (MySqlConnection cn = _mysql.ObtenerConexion())
            {
                cn.Open();

                string cadena =
                    "DELETE FROM clientes WHERE id_cliente = @id";

                using (MySqlCommand cmd = new MySqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@id", idCliente);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
        }

    }
}
