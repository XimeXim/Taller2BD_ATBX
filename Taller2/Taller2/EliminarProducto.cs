using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace taller2
{
    public partial class EliminarProducto : Form
    { 
            public void MarcarProductoComoNoDisponible(int idProducto) { 
            string query = "UPDATE menu SET stock = 0 WHERE id_producto = @id_producto"; 
            MySqlParameter[] parameters = { new MySqlParameter("@id_producto", idProducto) };
            try {
                // Se ajusta el stock del producto a 0
                ConnectMySQL.Instance.ExecuteQuery(query, parameters);
                MessageBox.Show("Stock del producto ajustado a 0.");
            } 
            catch (MySqlException ex) {
                MessageBox.Show("Error al ajustar el stock del producto a 0: " + ex.Message); } 
            catch (Exception ex) { MessageBox.Show("Error al ajustar el stock del producto a 0: " + ex.Message);
            }
        }
    }
}

