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
using MySql.Data.MySqlClient;

namespace taller2
{
	public partial class EliminarCliente : Form
	{
		private ListView lstClientes;
		private Button btnEliminar;

		public EliminarCliente()
		{
			InitializeComponent();
			InitializeCustomControls();
		}

		private void InitializeCustomControls()
		{
			// ListView ver cliente
			lstClientes = new ListView();
			lstClientes.View = View.Details;
			lstClientes.Columns.Add("Código", 70);
			lstClientes.Columns.Add("Nombre", 200);
			lstClientes.Columns.Add("Ciudad", 100);
			lstClientes.Columns.Add("Tipo Cliente", 100);
			lstClientes.FullRowSelect = true;
			lstClientes.Dock = DockStyle.Top;
			Controls.Add(lstClientes);

			// Button eliminar cliente
			btnEliminar = new Button();
			btnEliminar.Text = "Eliminar Cliente";
			btnEliminar.Enabled = false;
			btnEliminar.Click += BtnEliminar_Click;
			btnEliminar.Dock = DockStyle.Bottom;
			Controls.Add(btnEliminar);

			CargarClientes();
		}

		private void CargarClientes()
		{
			string query = "SELECT codigo, nombre, ciudad, tipo_cliente FROM Clientes";
			DataTable clientes = ConnectMySQL.Instance.SelectQuery(query);

			lstClientes.Items.Clear();
			foreach (DataRow row in clientes.Rows)
			{
				ListViewItem item = new ListViewItem(row["codigo"].ToString());
				item.SubItems.Add(row["nombre"].ToString());
				item.SubItems.Add(row["ciudad"].ToString());
				item.SubItems.Add(row["tipo_cliente"].ToString());
				lstClientes.Items.Add(item);
			}
		}

		private void BtnEliminar_Click(object sender, EventArgs e)
		{
			if (lstClientes.SelectedItems.Count == 0)
			{
				MessageBox.Show("Por favor, selecciona un cliente para eliminar.");
				return;
			}

			string codigoCliente = lstClientes.SelectedItems[0].Text;

			if (MessageBox.Show($"¿Estás seguro de eliminar al cliente {codigoCliente}?", "Confirmar eliminación", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				string query = "DELETE FROM Clientes WHERE codigo = @codigo_cliente";
				MySqlParameter[] parameters = {
					new MySqlParameter("@codigo_cliente", codigoCliente)
				};

				ConnectMySQL.Instance.ExecuteQuery(query, parameters);

				MessageBox.Show("Cliente eliminado exitosamente.");
				CargarClientes(); 
			}
		}
	}
}