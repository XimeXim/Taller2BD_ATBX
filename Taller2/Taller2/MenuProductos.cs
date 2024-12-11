using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taller2
{
    public partial class MenuProductos : Form
    {
        public MenuProductos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarProd agregarProd = new AgregarProd();
            agregarProd.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EliminarProd eliminarProd = new EliminarProd();
            eliminarProd.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ModificarProd modificarProd = new ModificarProd();
            modificarProd.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListarProductos lista = new ListarProductos();
            lista.Show();
        }
    }
}

