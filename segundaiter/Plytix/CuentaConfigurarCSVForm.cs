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
    public partial class CuentaConfigurarCSVForm : Form
    {
        grupo11DBEntities bd;

        public CuentaConfigurarCSVForm()
        {
            InitializeComponent();
            bd = new grupo11DBEntities();
            CargarListBox();
        }

        private void CargarListBox()
        {
            listBoxCategorias.DataSource = bd.CATEGORIA.ToList();
            listBoxCategorias.DataSource = bd.CATEGORIA.ToList();

            listBoxAtributtes.SelectedItem = null;
            listBoxCategorias.SelectedItem = null;
        }

        private void CategoriaElegida_Click(object sender, EventArgs e)
        {
            if (listBoxCategorias.SelectedItems.Count > 0)
            {
                List<ATRIBUTO> atributos = new List<ATRIBUTO>();
                /*
                foreach( ATRIBUTO atributo in listBoxCategorias.SelectedItems)
                {
                    atributos.Add(atributo);
                }
                */
                if (this.Owner is CuentaForm parentForm) parentForm.ElegirDirectorioCSV((CATEGORIA)listBoxCategorias.SelectedItem, atributos); // Para recargar los datos del grid en la ventana abierta         
                Close();
            }
            else
            {
                MessageBox.Show("Select at least one Category");
            }
        }
    }
}
