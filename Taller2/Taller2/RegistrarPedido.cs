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
    public partial class RegistrarPedido : Form
    {
        private ComboBox cmbClientes;
        private DateTimePicker dtpFecha;
        private ListView lstProductosCarrito;
        private TextBox txtBuscarProducto;
        private Button btnAgregarProducto;
        private Label lblSubtotal;
        private Label lblImpuesto;
        private Label lblTotal;
        private Button btnRegistrarPedido;

        private DataTable dtProductosDisponibles;
        private List<ProductoCarrito> productosEnCarrito = new List<ProductoCarrito>();

        public RegistrarPedido()
        {
            InitializeComponent();
            InitializeCustomControls();
            CargarClientes();
            CargarProductosDisponibles();
        }

        private void InitializeCustomControls()
        {
            // ListView para mostrar los productos en el carrito
            lstProductosCarrito.View = View.Details;
            lstProductosCarrito.Columns.Add("Producto", 200);
            lstProductosCarrito.Columns.Add("Precio", 80);
            lstProductosCarrito.Columns.Add("Cantidad", 80);
            lstProductosCarrito.Columns.Add("Subtotal", 100);
        }

        private void CargarClientes()
        {
            string query = "SELECT codigo, nombre FROM Clientes";
        }

        private void CargarProductosDisponibles()
        {
            string query = "SELECT id_producto, nombre, precio FROM Productos";
            dtProductosDisponibles = new DataTable();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            // Obtener el producto seleccionado y la cantidad
            int idProducto = 
            int cantidad = int.Parse(txtCantidad.Text);

            // Buscar el producto en el DataTable
            DataRow[] rows = dtProductosDisponibles.Select($"id_producto = {idProducto}");
            if (rows.Length == 0)
            {
                MessageBox.Show("Producto no encontrado.");
                return;
            }

            // Agregar el producto al carrito
            ProductoCarrito producto = new ProductoCarrito
            {
                Id = (int)rows[0]["id_producto"],
                Nombre = rows[0]["nombre"].ToString(),
                Precio = (decimal)rows[0]["precio"],
                Cantidad = cantidad,
                Subtotal = cantidad * (decimal)rows[0]["precio"]
            };
            productosEnCarrito.Add(producto);

            // Actualizar el ListView
            lstProductosCarrito.Items.Clear();
            foreach (var productoCarrito in productosEnCarrito)
            {
                ListViewItem item = new ListViewItem(productoCarrito.Nombre);
                item.SubItems.Add(productoCarrito.Precio.ToString());
                item.SubItems.Add(productoCarrito.Cantidad.ToString());
                item.SubItems.Add(productoCarrito.Subtotal.ToString());
                lstProductosCarrito.Items.Add(item);
            }
        }

        private void btnRegistrarPedido_Click(object sender, EventArgs e)
        {
            // Obtener los datos del pedido
            int idCliente = 
            DateTime fecha = dtpFecha.Value;
            decimal subtotal = 
            decimal descuento = 
            decimal total = subtotal + descuento;

            // Insertar un nuevo registro en la tabla Ventas
            string queryVentas = "INSERT INTO Ventas (id_cliente, fecha, propina, total) VALUES (@id_cliente, @fecha, 0, @total)";

            // Obtener el ID de la venta recién insertada
            int idVenta = (int)ConnectMySQL.Instance.ExecuteScalar(queryVentas);

            // Insertar los detalles del pedido en la tabla Detalle_Ventas
            foreach (var producto in productosEnCarrito)
            {
                string queryDetalleVentas = "INSERT INTO Detalle_Ventas (id_venta, id_producto, cantidad, total_calculado) VALUES (@id_venta, @id_producto, @cantidad, @subtotal)";
            }

            MessageBox.Show("Pedido registrado exitosamente.");
        }

        // Clase para representar un producto en el carrito
        private class ProductoCarrito
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public int Cantidad { get; set; }
            public decimal Subtotal { get; set; }
        }
    }
}