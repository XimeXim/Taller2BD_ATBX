nusing System;
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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void buttonProd_Click(object sender, EventArgs e)
        {
            MenuProd menuProductos = new MenuProd();
            menuProductos.Show(this);

        }
    }
}

