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
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(textBoxName.Text != null && textBoxName.Text != "")
            {
                PRODRELACIONADOS nuevoProductoRelacionado = new PRODRELACIONADOS
                {
                    NAME = textBoxName.Text
                    // FALTA ELEGIR TIPO
                    // NO LOS AÑADE
                };
                bd.PRODRELACIONADOS.Add(nuevoProductoRelacionado);
                bd.SaveChanges();
                if (this.Owner is ProductosRelacionadosListar parentForm) parentForm.CargarProductosRelacionados(); // Para recargar los datos del grid en la ventana abierta         
                Close();
            }
            else
            {
                MessageBox.Show("You must fill in the name of the relationship");
            }
        }
    }
}
