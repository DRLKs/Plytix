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
    public partial class ProductosRelacionadosAñadirForm : Form
    {
        grupo11DBEntities db;

        public ProductosRelacionadosAñadirForm()
        {
            InitializeComponent();
            db = new grupo11DBEntities();
            CargarComboBox();
        }

        private void CargarComboBox()
        {
            comboBoxProducto1.DataSource = db.PRODUCTO.ToList();
            comboBoxProducto2.DataSource = db.PRODUCTO.ToList();

            comboBoxProducto1.SelectedItem = null;
            comboBoxProducto2.SelectedItem = null;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                ComprobarDatos();
                PRODRELACIONADOS nuevoProductoRelacionado = new PRODRELACIONADOS();
                nuevoProductoRelacionado.NAME = textBoxName.Text;
                if (comboBoxProducto1.SelectedItem != null)
                {
                    nuevoProductoRelacionado.PRODUCTO.Add((PRODUCTO)comboBoxProducto1.SelectedItem);
                    nuevoProductoRelacionado.PRODUCTO.Add((PRODUCTO)comboBoxProducto2.SelectedItem);
                }

                db.PRODRELACIONADOS.Add(nuevoProductoRelacionado);
                db.SaveChanges();
                if (this.Owner is ProductosRelacionadosListar parentForm) parentForm.CargarProductosRelacionados(); // Para recargar los datos del grid en la ventana abierta         
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ComprobarDatos()
        {
            if( textBoxName.Text == "" || textBoxName.Text == null)
            {
                throw new Exception("You must fill out the name section");
            }
            if (comboBoxProducto1.SelectedItem != null && comboBoxProducto2.SelectedItem == null)
            {
                throw new Exception("You must also select the second product for the relationship");
            }
            if(comboBoxProducto1.SelectedItem == null && comboBoxProducto2.SelectedItem != null )
            {
                throw new Exception("You must also select the first product for the relationship");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComboBoxProducto1SelectedChanged(object sender, EventArgs e)
        {
            if( comboBoxProducto1.SelectedIndex == comboBoxProducto2.SelectedIndex )
            {
                comboBoxProducto2.SelectedItem = null;
            }
        }

        private void ComboBoxProducto2SelectedChanged(object sender, EventArgs e)
        {
            if (comboBoxProducto1.SelectedIndex == comboBoxProducto2.SelectedIndex)
            {
                comboBoxProducto1.SelectedItem = null;
            }
        }
    }
}