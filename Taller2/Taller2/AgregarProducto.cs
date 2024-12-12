using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace taller2
{
    public partial class AgregarProducto : Form
    {
        public void AgregarProductoMenu(int idProducto, string codigo, string nombre, decimal precio, int stock, int idSucursal)
        {
            // Instrucción SQL para agregar un producto nuevo
            string query = "INSERT INTO menu (id_producto, codigo, nombre, precio, stock, id_sucursal) " +
                           "VALUES (@id_producto, @codigo, @nombre, @precio, @stock, @id_sucursal)";

            // Se establecen los parámetros del producto a agregar
            MySqlParameter[] parameters = {
                new MySqlParameter("@id_producto", idProducto),
                new MySqlParameter("@codigo", codigo),
                new MySqlParameter("@nombre", nombre),
                new MySqlParameter("@precio", precio),
                new MySqlParameter("@stock", stock),
                new MySqlParameter("@id_sucursal", idSucursal)
            };

            try
            {
                // Se logra agregar el nuevo producto
                ConnectMySQL.Instance.ExecuteQuery(query, parameters);
                MessageBox.Show("Producto agregado exitosamente al menú.");
            }
            catch (MySqlException ex)
            {
                // Se presentan problemas al agregar el nuevo producto
                string errorMessage = "Error al agregar el producto: "; if (ex.Message.Contains("@id_producto")) { errorMessage += "ID del producto inválido. "; }
                if (ex.Message.Contains("@codigo")) { errorMessage += "Código del producto inválido. "; }
                if (ex.Message.Contains("@nombre")) { errorMessage += "Nombre del producto inválido. "; }
                if (ex.Message.Contains("@precio")) { errorMessage += "Precio del producto inválido. "; }
                if (ex.Message.Contains("@stock")) { errorMessage += "Stock del producto inválido. "; }
                if (ex.Message.Contains("@id_sucursal")) { errorMessage += "ID de la sucursal inválido. "; }
                errorMessage += ex.Message; 
                MessageBox.Show(errorMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el producto: " + ex.Message); 
            }
        }
    }
}
