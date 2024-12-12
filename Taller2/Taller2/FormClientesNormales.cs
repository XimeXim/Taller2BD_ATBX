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
    public partial class FormClientesNormales : Form
    {
        public FormClientesNormales()
        {
            InitializeComponent();
            CargarClientesNormales();
        }

        private void CargarClientesNormales()
        {
            string query = "SELECT codigo, nombre, ciudad FROM Clientes WHERE tipo_cliente = 'Normal'";
            DataTable dtClientes = ConnectMySQL.Instance.SelectQuery(query);
            dgvClientesNormales.DataSource = dtClientes;
        }
    }
}