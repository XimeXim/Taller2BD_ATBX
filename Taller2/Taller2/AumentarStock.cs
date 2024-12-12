using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace taller2
{
    public class AumentarStock
    {
        public void AumentarStockEnSucursal(int idSucursal, int cantidadAumento) { 
            string query = "UPDATE menu SET stock = stock + @cantidadAumento WHERE id_sucursal = @idSucursal"; 
            MySqlParameter[] parameters = { 
                new MySqlParameter("@cantidadAumento", cantidadAumento), new MySqlParameter("@idSucursal", idSucursal) };
            try {
                ConnectMySQL.ExecuteQuery(query, parameters); 
                MessageBox.Show("Stock de los productos en la sucursal ha sido aumentado.");
            } 
            catch (MySqlException ex) { 
                MessageBox.Show("Error al aumentar el stock de los productos en la sucursal: " + ex.Message);
            } 
            catch (Exception ex) { 
                MessageBox.Show("Error al aumentar el stock de los productos en la sucursal: " + ex.Message);
            }
        }
    }
}


