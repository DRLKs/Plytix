using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void gestionarProducotsClick(object sender, EventArgs e)
        {
            var productosForm = new GestionProductosForm();
            productosForm.Show();
            this.Hide();
        }

        private void gestionarCategoriasClick(object sender, EventArgs e)
        {

        }

        private void gestionarAtributosClick(object sender, EventArgs e)
        {

        }
    }
}
