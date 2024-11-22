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
        public CategoriesForms( int id, GestionProductosForms forms)
        {
            InitializeComponent();
        }

        private void SaveClick(object sender, EventArgs e)
        {
            if( textBoxId.Text != "" && textBoxNombre.Text != "")
            {
                grupo11DBEntities conexion = new grupo11DBEntities();

                CATEGORIA c = new CATEGORIA();
                c.ID =  Int32.Parse( textBoxId.Text );
                c.NOMBRE = textBoxNombre.Text;
                conexion.CATEGORIA.AddOrUpdate();
                conexion.SaveChanges();
            }
        }
    }
}
