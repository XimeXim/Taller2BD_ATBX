using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace taller2
{
    public partial class ListarClientes : Form
    {
        public ListarClientes()
        {
            public List<string> ListarClientes()
            {
                List<string> clientes = new List<string>();
                string query = "SELECT id_cliente, codigo, nombre, ciudad, tipo_cliente FROM Clientes";
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, ConnectMySQL.Instance))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string cliente = $"ID: {reader["id_cliente"]}," +
                                    $" " + $"Código: {reader["codigo"]}, " +
                                    $"Nombre: {reader["nombre"]}, " +
                                    $"Ciudad: {reader["ciudad"]}, " +
                                    $"Tipo: {reader["tipo_cliente"]}";
                                clientes.Add(cliente);
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al listar los clientes: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al listar los clientes: " + ex.Message);
                }
                return clientes;
            }
        }
    }
}



