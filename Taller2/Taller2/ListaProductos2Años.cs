using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace taller2
{
    public partial class ListaProductos2Años : Form
    {
        public List<string> ListarProductosVendidosUltimosDosAnios() { 
            List<string> productosVendidos = new List<string>();
            string query = @" 
                SELECT p.id_producto, p.codigo, p.nombre, p.precio, SUM(dv.cantidad) AS total_vendido 
                FROM Productos p 
                JOIN Detalle_Ventas dv ON p.id_producto = dv.id_producto 
                JOIN Ventas v ON dv.id_venta = v.id_venta 
                WHERE v.fecha >= DATE_SUB(CURDATE(), INTERVAL 2 YEAR) 
                GROUP BY p.id_producto, p.codigo, p.nombre, p.precio 
                ORDER BY total_vendido DESC"; 
            try { 
                using (MySqlCommand cmd = new MySqlCommand(query, ConnectMySQL.Instance)) { 
                    using (MySqlDataReader reader = cmd.ExecuteReader()) { 
                        while (reader.Read()) { 
                            string producto = $"ID: {reader["id_producto"]}, " +
                                $"Código: {reader["codigo"]}, " +
                                $"Nombre: {reader["nombre"]}, " +
                                $"Precio: {reader["precio"]}, " +
                                $"Total Vendido: {reader["total_vendido"]}"; 
                            productosVendidos.Add(producto); 
                        }
                    }
                }
            }
            catch (MySqlException ex) { 
                MessageBox.Show("Error al listar los productos vendidos: " + ex.Message); } 
            catch (Exception ex) { 
                MessageBox.Show("Error al listar los productos vendidos: " + ex.Message); } 
            return productosVendidos; 
        }
    }
}


