using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace taller2
{
    public class ListarCiudades
    {
        public List<string> ListarCiudadesConSucursal() { 
            List<string> ciudades = new List<string>(); 
            string query = "SELECT DISTINCT ciudad FROM Sucursales WHERE nombre = 'Vitoko’s Coffee'"; 
            try { 
                using (MySqlCommand cmd = new MySqlCommand(query, ConnectMySQL.Instance)) { 
                    using (MySqlDataReader reader = cmd.ExecuteReader()) { 
                        while (reader.Read()) { 
                            ciudades.Add(reader["ciudad"].ToString()); 
                        }
                    }
                }
            }
            catch (MySqlException ex) { 
                MessageBox.Show("Error al listar las ciudades con sucursales: " + ex.Message); } 
            catch (Exception ex) { MessageBox.Show("Error al listar las ciudades con sucursales: " + ex.Message); 
            } return ciudades; 
        }
    }
}


