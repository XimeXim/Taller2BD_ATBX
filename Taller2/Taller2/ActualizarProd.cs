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

namespace taller2
{
    public partial class ActualizarProd : Form
    {
        private DataGridView dataProd;
        private TextBox txtNuevoPrecio;
        private Button btnActualizar;

        public ActualizarProd()
        {
            InitializeComponent();
            InitializeCustomControls();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void InitializeCustomControls()
        {
            dataProd = new DataGridView();
            dataProd.Dock = DockStyle.Fill;
            dataProd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataProd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataProd.CellClick += DataProd_CellClick;
            Controls.Add(dataProd);

            // TextBox para el nuevo precio
            txtNuevoPrecio = new TextBox();
            txtNuevoPrecio.Location = new Point(100, 100);
            txtNuevoPrecio.Enabled = false;
            txtNuevoPrecio.KeyPress += TxtNuevoPrecio_KeyPress;
            Controls.Add(txtNuevoPrecio);

            // Bot n Actualizar
            btnActualizar = new Button();
            btnActualizar.Text = "Actualizar Precio";
            btnActualizar.Location = new Point(200, 100);
            btnActualizar.Enabled = false;
            btnActualizar.Click += BtnActualizar_Click;
            Controls.Add(btnActualizar);

            // Cargar los datos iniciales
            CargarDatos();
        }

        private void CargarDatos()
        {
            string query = "SELECT ID, Nombre, Precio FROM producto WHERE SucursalID = @codigo_sucursal AND Estado = 1";
            string[] parameters = { "@codigo_sucursal", SesionActual.CodigoSucursal.ToString() };

            DataTable productos = ConnectMySQL.Instance.SelectQuery(query, parameters);
            dataProd.DataSource = productos;
        }

        private void DataProd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtNuevoPrecio.Enabled = true;
                btnActualizar.Enabled = true;
                txtNuevoPrecio.Text = dataProd.Rows[e.RowIndex].Cells["Precio"].Value.ToString();
                txtNuevoPrecio.Focus();
            }
        }

        private void TxtNuevoPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            int idProducto = (int)dataProd.SelectedRows[0].Cells["ID"].Value;
            if (!int.TryParse(txtNuevoPrecio.Text, out int newPrecio) || newPrecio <= 0)
            {
                MessageBox.Show("Por favor, ingresa un precio v lido.");
                return;
            }

            if (MessageBox.Show($" Est s seguro de actualizar el precio del producto {dataProd.SelectedRows[0].Cells["Nombre"].Value} a ${newPrecio}?", "Confirmar actualizaci n", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "UPDATE producto SET Precio = @nuevo_precio WHERE ID = @id_producto";
                MySqlParameter[] parameters = {
                    new MySqlParameter("@id_producto", idProducto),
                    new MySqlParameter("@nuevo_precio", newPrecio)
                };

                ConnectMySQL.Instance.ExecuteQuery(query, parameters);
                MessageBox.Show("Precio actualizado exitosamente.");
                CargarDatos(); // Recargar los datos para reflejar los cambios
            }
        }
    }
}