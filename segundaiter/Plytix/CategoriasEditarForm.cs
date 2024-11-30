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

            textBoxNombre.Focus();
        }

        private void CategoriaEditarForm_Load(object sender, EventArgs e)
        {
            textBoxNombre.Text = categoria.NOMBRE;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            EditarCategoria();
        }

        private void textBoxNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Detecta si se presionó Enter
            {
                e.SuppressKeyPress = true; // Previene el sonido "beep" que puede ocurrir
                EditarCategoria(); 
            }
        }

        private void EditarCategoria()
        {
            categoria.NOMBRE = textBoxNombre.Text;
            bd.SaveChanges();
            if (this.Owner is CategoriasListarForm parentForm) parentForm.CategoriasListarForm_Load(null, null); // Para recargar los datos del grid en la ventana abierta         
            Close();
        }
    }
}
