using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taller2;

namespace Taller2
{
    public partial class ListarProductos : Form
    {
        public ListarProductos()
        {
            InitializeComponent();
        }

        private void ListarProductos_Load(object sender, EventArgs e)
        {

        }
        private void MostrarProductos()
        {
            string query = "";
            string[] parameters = { "@codigo_sucursal", SesionActual.CodigoSucursal.ToString() };

            // Verifica la selección del ComboBox
            if (comboBox1.SelectedItem.ToString() == "Todos los productos")
            {
                // Consulta para todos los productos activos
                query = "SELECT ID, Nombre, Precio, Stock FROM producto WHERE SucursalID = @codigo_sucursal AND Estado = 1";
            }
            else if (comboBox1.SelectedItem.ToString() == "Últimos 2 años")
            {
                // Consulta para productos vendidos en los últimos 2 años
                query = @"
            SELECT DISTINCT p.ID, p.Nombre, p.Precio
            FROM producto p
            JOIN detalleVenta vd ON p.ID = vd.ProductoID
            JOIN venta v ON vd.VentaID = v.ID
            WHERE p.SucursalID = @codigo_sucursal 
              AND v.Fecha >= DATE_SUB(CURDATE(), INTERVAL 2 YEAR)";
            }

            // Ejecuta la consulta y muestra los resultados en el DataGridView
            DataTable productos = ConnectMySQL.Instance.SelectQuery(query, parameters);

            dataGridProductos.DataSource = productos;

            // Opcional: Configuración de columnas
            if (dataGridProductos.Columns.Contains("ID"))
                dataGridProductos.Columns["ID"].Visible = false;

            dataGridProductos.Columns["Nombre"].HeaderText = "Producto";
            dataGridProductos.Columns["Precio"].HeaderText = "Precio Unitario";

            if (comboBox1.SelectedItem.ToString() == "Todos los productos" && dataGridProductos.Columns.Contains("Stock"))
            {
                dataGridProductos.Columns["Stock"].HeaderText = "Stock Disponible";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarProductos();
        }
    }
}

