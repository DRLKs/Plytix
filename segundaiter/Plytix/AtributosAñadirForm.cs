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
    public partial class AtributosAñadirForm : Form
    {
        grupo11DBEntities bd;
        public AtributosAñadirForm()
        {
            InitializeComponent();
            bd = new grupo11DBEntities();
            CargarComboBox();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var tiposDisponibles = new[] { "Text", "Integer", "Decimal", "Image" };

            if ( !tiposDisponibles.Contains(comboBoxTipos.SelectedItem))
            {
                MessageBox.Show("You must select a type from those available");
            }
            else if(textBoxName.Text != null && textBoxName.Text != "")
            {
                ATRIBUTO nuevoAtributo = new ATRIBUTO
                {
                    NOMBRE = textBoxName.Text,
                    TIPO = comboBoxTipos.SelectedItem.ToString()
                };
                bd.ATRIBUTO.Add(nuevoAtributo);
                bd.SaveChanges();
                if (this.Owner is ProductosRelacionadosListar parentForm) parentForm.CargarProductosRelacionados(); // Para recargar los datos del grid en la ventana abierta         
                Close();
            }
            else
            {
                MessageBox.Show("You must fill in the name of the relationship");
            }
        }

        private void CargarComboBox()
        {
            var tipos = new[] { "Text", "Integer", "Decimal", "Image" };
            comboBoxTipos.DataSource = tipos;
            comboBoxTipos.SelectedItem = null;
        }
    }
}
