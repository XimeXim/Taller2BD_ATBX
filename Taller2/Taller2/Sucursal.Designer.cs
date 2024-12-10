using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Taller2;
using MySql.Data.MySqlClient;

namespace Taller2
{
    public partial class EliminarProd : Form
    {
        public EliminarProd()
        {
            InitializeComponent();
        }

        private void EliminarProd_Load(object sender, EventArgs e)
        {
            string query = "SELECT ID, Nombre FROM producto WHERE SucursalID = @codigo_sucursal AND Estado = 1";

            string[] parameters = { "@codigo_sucursal", SesionActual.CodigoSucursal.ToString() };
            DataTable productos = ConnectMySQL.Instance.SelectQuery(query, parameters);

            // Asocia los resultados al ComboBox
            ListadoProd.DataSource = productos; // Asigna la tabla como origen de datos
            ListadoProd.DisplayMember = "Nombre"; // Muestra el nombre del producto
            ListadoProd.ValueMember = "ID"; // Asigna el ID como valor asociado
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Verifica que haya un valor seleccionado
            if (ListadoProd.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecciona un producto para eliminar.");
                return;
            }

            string query = "UPDATE producto SET estado = 0 WHERE SucursalID = @codigo_sucursal AND ID = @id_producto";

            MySqlParameter[] parameters = {
        new MySqlParameter("@codigo_sucursal", SesionActual.CodigoSucursal.ToString()),
        new MySqlParameter("@id_producto", ListadoProd.SelectedValue) // Obtén el valor seleccionado
    };

            ConnectMySQL.Instance.ExecuteQuery(query, parameters);

            MessageBox.Show("Producto eliminado exitosamente.");

            // Recarga el ComboBox
            EliminarProd_Load(sender, e);
        }
    }
}

