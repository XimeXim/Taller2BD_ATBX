using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace taller2
{
	public partial class FormClientesPremium : Form
	{
		public FormClientesPremium()
		{
			InitializeComponent();
			CargarClientesPremium();
		}

		private void CargarClientesPremium()
		{
			string query = "SELECT codigo, nombre, ciudad FROM Clientes WHERE tipo_cliente = 'Premium'";
			DataTable dtClientes = ConnectMySQL.Instance.SelectQuery(query);
			dgvClientesPremium.DataSource = dtClientes;
		}
	}
}