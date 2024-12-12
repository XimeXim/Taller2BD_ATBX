using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace taller2
{
    public partial class ListaProductos : Form
    {
        public List<string> ListarProductosDisponibles() { 
            List<string> productos = new List<string>(); 
            string query = "SELECT id_producto, codigo, nombre, precio, stock, id_sucursal FROM menu WHERE stock > 0"; 
            try { 
                using (MySqlCommand cmd = new MySqlCommand(query, ConnectMySQL.Instance)) { 
                    using (MySqlDataReader reader = cmd.ExecuteReader()) { 
                        while (reader.Read()) { 
                            string producto = $"ID: {reader["id_producto"]}, " + 
                                $"Código: {reader["codigo"]}, " + 
                                $"Nombre: {reader["nombre"]}, " + 
                                $"Precio: {reader["precio"]}, " + 
                                $"Stock: {reader["stock"]}, " + 
                                $"ID Sucursal: {reader["id_sucursal"]}"; 
                            productos.Add(producto); 
                        }
                    }
                }
            }
            catch (MySqlException ex) { 
                MessageBox.Show("Error al listar los productos: " + ex.Message); 
            } catch (Exception ex) { 
                MessageBox.Show("Error al listar los productos: " + ex.Message); 
            } 
            return productos; 
        }
    }
}

