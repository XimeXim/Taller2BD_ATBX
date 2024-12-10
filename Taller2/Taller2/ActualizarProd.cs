using MySql.Data.MySqlClient;
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

namespace taller_2_2024
{
    public partial class ModificarProd : Form
    {
        public ModificarProd()
        {
            InitializeComponent();
        }

        private void ModificarProd_Load(object sender, EventArgs e)
        {
            string query = "SELECT ID, Nombre, Precio FROM producto WHERE SucursalID = @codigo_sucursal AND Estado = 1";
            string[] parameters = { "@codigo_sucursal", SesionActual.CodigoSucursal.ToString() };

            DataTable productos = ConnectMySQL.Instance.SelectQuery(query, parameters);
            dataProd.DataSource = productos;

            // Ajuste de las columnas
            dataProd.Columns["ID"].Visible = false; // Oculta el ID, puesto que no lo necesitamos
            dataProd.Columns["Nombre"].HeaderText = "Nombre del Producto";
            dataProd.Columns["Precio"].HeaderText = "Precio Unitario";
            dataProd.Columns["Precio"].DefaultCellStyle.Format = "C0"; // Formato moneda
            // Permite editar directamente en la celda
            dataProd.Columns["Precio"].ReadOnly = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Verifica que haya una fila seleccionada
            if (dataProd.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un producto para actualizar el precio.");
                return;
            }

            // Obtén los valores de la fila seleccionada
            int idProducto = (int)dataProd.SelectedRows[0].Cells["ID"].Value;
            int newPrecio;

            // Valida que el usuario ingrese un precio válido
            if (!int.TryParse(nuevoPrecio.Text, out newPrecio) || newPrecio <= 0)
            {
                MessageBox.Show("Por favor, ingresa un precio válido.");
                return;
            }

            // Consulta para actualizar el precio
            string query = "UPDATE producto SET Precio = @nuevo_precio WHERE SucursalID = @codigo_sucursal AND ID = @id_producto";

            MySqlParameter[] parameters = {
                new MySqlParameter("@codigo_sucursal", SesionActual.CodigoSucursal.ToString()),
                new MySqlParameter("@id_producto", idProducto),
                new MySqlParameter("@nuevo_precio", newPrecio)
    };

            ConnectMySQL.Instance.ExecuteQuery(query, parameters);
            MessageBox.Show("Precio actualizado exitosamente.");

            ModificarProd_Load(sender, e);
        }
    }
}

