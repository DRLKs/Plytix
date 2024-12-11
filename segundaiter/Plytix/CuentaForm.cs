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
    public partial class CuentaForm : Form
    {
        grupo11DBEntities bd;

        public CuentaForm()
        {
            InitializeComponent();
            bd = new grupo11DBEntities();
            CargarLabels();
        }

        public void CargarLabels()
        {
            int numProductos = bd.PRODUCTO.Count();
            numeroProductos.Text = "Number of Products = " + numProductos;

            int numCategories = bd.CATEGORIA.Count();
            numeroCategorias.Text = "Number of Categories = " + numCategories;

            int numAtributes = bd.ATRIBUTO.Count();
            numeroAtributos.Text = "Number of Atributtes = " + numAtributes;

            numeroAssets.Text = "Number os Assets = 0";
        }
    }
}
