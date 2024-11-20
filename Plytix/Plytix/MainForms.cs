using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plytix
{
    public partial class MainForms : Form
    {
        public MainForms()
        {
            InitializeComponent();
        }



        private void ProductosClick(object sender, EventArgs e)
        {
            var productosForm = new GestionProductosForms();
            productosForm.Show();
            this.Hide();
        }

        private void CategoriasClick(object sender, EventArgs e)
        {

        }

        private void AtributosClick(object sender, EventArgs e)
        {

        }
    }
}
