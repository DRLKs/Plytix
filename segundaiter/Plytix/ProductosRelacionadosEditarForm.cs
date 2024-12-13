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
    public partial class ProductosRelacionadosEditarForm : Form
    {
        grupo11DBEntities db;
        PRODRELACIONADOS seleccionado;

        public ProductosRelacionadosEditarForm( PRODRELACIONADOS seleccionado)
        {
            InitializeComponent();
            db = new grupo11DBEntities();
            this.seleccionado = seleccionado;
            CargarProductos();
        }

        private void CargarProductos()
        {
            textBoxName.Text = seleccionado.NAME;

            listBoxProductos.DataSource = db.PRODUCTO.ToList();
            listBoxProductos.SelectedItem = null;

            /* DEJAMOS SELECCIONADOS LOS PRODUCTOS */
            foreach( PRODUCTO producto in seleccionado.PRODUCTO)
            {
                listBoxProductos.SelectedItem = producto;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                ComprobarDatos();
                seleccionado.NAME = textBoxName.Text;
                seleccionado.PRODUCTO.Clear();
                foreach (PRODUCTO producto in listBoxProductos.SelectedItems)
                {
                    seleccionado.PRODUCTO.Add(producto);
                }

                db.PRODRELACIONADOS.AddOrUpdate(seleccionado);
                db.SaveChanges();
                if (this.Owner is ProductosRelacionadosListar parentForm) parentForm.CargarProductosRelacionados(); // Para recargar los datos del grid en la ventana abierta         
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComprobarDatos()
        {
            if (textBoxName.Text == "" || textBoxName.Text == null)
            {
                throw new Exception("You must fill out the name section");
            }
        }
    }
}
