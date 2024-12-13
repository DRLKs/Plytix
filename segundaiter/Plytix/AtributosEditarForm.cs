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
    public partial class AtributosEditarForm : Form
    {
        ATRIBUTO atributoSeleccionado;
        grupo11DBEntities bd;
        public AtributosEditarForm(int id)
        {
            InitializeComponent();
            bd = new grupo11DBEntities();
            atributoSeleccionado = bd.ATRIBUTO.First(a=>a.ID == id);
            CargarDatos();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var tiposDisponibles = new[] { "Text", "Integer", "Decimal", "Image" };

            if (!tiposDisponibles.Contains(comboBoxTipos.SelectedItem))
            {
                MessageBox.Show("You must select a type from those available");
            }
            else if (textBoxName.Text != null && textBoxName.Text != "")
            {
                atributoSeleccionado.NOMBRE = textBoxName.Text;
                atributoSeleccionado.TIPO = comboBoxTipos.SelectedItem.ToString();
                
                bd.ATRIBUTO.AddOrUpdate(atributoSeleccionado);
                bd.SaveChanges();
                if (this.Owner is ProductosRelacionadosListar parentForm) parentForm.CargarProductosRelacionados(); // Para recargar los datos del grid en la ventana abierta         
                Close();
            }
            else
            {
                MessageBox.Show("You must fill in the name of the relationship");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CargarDatos()
        {
            var tipos = new[] { "Text", "Integer", "Decimal", "Image" };
            textBoxName.Text = atributoSeleccionado.NOMBRE;
            comboBoxTipos.DataSource = tipos;
            comboBoxTipos.SelectedItem = atributoSeleccionado.TIPO;
        }
    }
}
