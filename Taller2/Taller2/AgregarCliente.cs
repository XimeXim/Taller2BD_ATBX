using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static taller_2_2024.SesionActual;
using Taller2;
using MySql.Data.MySqlClient;

namespace taller2
{
    public partial class AgregarCliente : Form
    {
        private Label lblTitulo;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblCiudad;
        private TextBox txtCiudad;
        private Label lblTipoCliente;
        private ComboBox cmbTipoCliente;
        private Button btnAgregar;

        public AgregarCliente()
        {
            InitializeComponent();
            InitializeCustomControls();
        }

        private void InitializeCustomControls()
        {
           
            // Tipo Cliente Combobox
            cmbTipoCliente = new ComboBox();
            cmbTipoCliente.Items.AddRange(new string[] { "Normal", "Premium" });
            cmbTipoCliente.SelectedIndex = 0; // Default selection: Normal
            cmbTipoCliente.Location = new Point(150, 170);
            Controls.Add(cmbTipoCliente);

            // Agregar Button
            btnAgregar = new Button();
            btnAgregar.Text = "Agregar Cliente";
            btnAgregar.Location = new Point(120, 220);
            btnAgregar.Click += BtnAgregar_Click;
            Controls.Add(btnAgregar);
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            string nombreCliente = txtNombre.Text;
            string ciudadCliente = txtCiudad.Text;
            string tipoCliente = cmbTipoCliente.SelectedItem.ToString();

            if (string.IsNullOrEmpty(nombreCliente))
            {
                MessageBox.Show("Por favor, ingresa un nombre para el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(ciudadCliente))
            {
                MessageBox.Show("Por favor, ingresa la ciudad del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "INSERT INTO clientes (codigo, nombre, ciudad, tipo_cliente) VALUES (@codigo, @nombre, @ciudad, @tipo_cliente)";

            string clientCode = GenerateUniqueClientCode();

            MySqlParameter[] parameters = {
                new MySqlParameter("@codigo", clientCode),
                new MySqlParameter("@nombre", nombreCliente),
                new MySqlParameter("@ciudad", ciudadCliente),
                new MySqlParameter("@tipo_cliente", tipoCliente)
            };

            ConnectMySQL.Instance.ExecuteQuery(query, parameters);

            MessageBox.Show("Cliente agregado exitosamente.", "Cliente Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtNombre.Text = "";
            txtCiudad.Text = "";
        }

        private string GenerateUniqueClientCode()
        {
            return Guid.NewGuid().ToString().Substring(0, 10);
        }
    }
}