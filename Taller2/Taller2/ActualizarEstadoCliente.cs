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
    public partial class ActualizarEstadoCliente : Form
    {
        private ListView lstClientes;
        private ComboBox cmbEstado;
        private Button btnActualizar;

        public ActualizarEstadoCliente()
        {
            InitializeComponent();
            InitializeCustomControls();
        }

        private void InitializeCustomControls()
        {
            // ListView para mostrar los clientes
            lstClientes = new ListView();
            lstClientes.FullRowSelect = true;
            lstClientes.Dock = DockStyle.Top;
            Controls.Add(lstClientes);

            // ComboBox para seleccionar el estado
            cmbEstado = new ComboBox();
            cmbEstado.Items.AddRange(new string[] { "Activo", "Inactivo" });
            cmbEstado.Location = new Point(100, 100);
            Controls.Add(cmbEstado);

            // Botón para actualizar el estado
            btnActualizar = new Button();
            btnActualizar.Text = "Actualizar Estado";
            btnActualizar.Location = new Point(200, 100);
            btnActualizar.Click += BtnActualizar_Click;
            Controls.Add(btnActualizar);

            CargarClientes();
        }

        private void CargarClientes()
        {
            // Consulta para obtener los clientes
            string query = "SELECT codigo, nombre, ciudad, tipo_cliente, estado FROM Clientes";

        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (lstClientes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un cliente.");
                return;
            }

            string codigoCliente = lstClientes.SelectedItems[0].Text;
            string nuevoEstado = cmbEstado.SelectedItem.ToString();

            // Consulta para actualizar
            string query = "UPDATE Clientes SET estado = @nuevo_estado WHERE codigo = @codigo_cliente";
            MySqlParameter[] parameters = {
                new MySqlParameter("@codigo_cliente", codigoCliente),
                new MySqlParameter("@nuevo_estado", nuevoEstado)
            };

            // Ejecutar la consulta
            ConnectMySQL.Instance.ExecuteQuery(query, parameters);

            MessageBox.Show("Estado del cliente actualizado exitosamente.");
            CargarClientes(); 
    }
    }
}