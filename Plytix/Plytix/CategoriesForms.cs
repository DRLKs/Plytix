using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plytix
{
    public partial class CategoriesForms : Form
    {
        private int id;
        private GestionCategoriasForms forms;
        public CategoriesForms( int id, GestionCategoriasForms forms)
        {
            InitializeComponent();
            if( id >= 0 ) this.id = id;
            else          this.id = -1;
            this.forms = forms;
        }

        private void SaveClick(object sender, EventArgs e)
        {
            if(textBoxId.Text != null && textBoxId.Text != "" && textBoxNombre.Text != "")
            {
                grupo11DBEntities conexion = new grupo11DBEntities();

                CATEGORIA c = new CATEGORIA();
                c.ID =  Int32.Parse( textBoxId.Text );
                c.NOMBRE = textBoxNombre.Text;
                conexion.CATEGORIA.AddOrUpdate(c);
                conexion.SaveChanges();
                forms.CargarCategorias();
                this.Hide();
            }
        }
    }
}
