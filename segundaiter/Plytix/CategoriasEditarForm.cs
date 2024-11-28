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
    public partial class CategoriasEditarForm : Form
    {
        CATEGORIA categoria;
        grupo11DBEntities bd = new grupo11DBEntities();
        public CategoriasEditarForm(int id)
        {
            InitializeComponent();
            categoria = (from c in bd.CATEGORIA
                        where c.ID == id
                        select c).First();
        }

        private void CategoriaEditarForm_Load(object sender, EventArgs e)
        {
            textBoxNombre.Text = categoria.NOMBRE;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            categoria.NOMBRE = textBoxNombre.Text;
            bd.SaveChanges();
            if (this.Owner is CategoriasListarForm parentForm) parentForm.CategoriasListarForm_Load(null, null); // Para recargar los datos del grid en la ventana abierta         
            Close();
        }
    }
}
