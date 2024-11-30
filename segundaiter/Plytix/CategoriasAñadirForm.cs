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
    public partial class CategoriasAñadirForm : Form
    {
        grupo11DBEntities bd = new grupo11DBEntities();
        public CategoriasAñadirForm()
        {
            InitializeComponent();
            textBoxNombre.Focus();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            GuardarCategoria();
        }

        private void textBoxNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Detecta si se presionó Enter
            {
                e.SuppressKeyPress = true; // Previene el sonido "beep" que puede ocurrir
                GuardarCategoria();
            }
        }

        private void GuardarCategoria()
        {
            try
            {
                if (textBoxNombre.Text == "" || textBoxNombre.Text == null)
                {
                    throw new Exception("Debe rellenar antes el campo NAME");
                }
                CATEGORIA categoria = new CATEGORIA
                {
                    NOMBRE = textBoxNombre.Text,
                    PRODUCTO = new HashSet<PRODUCTO>()
                };
                bd.CATEGORIA.Add(categoria);
                bd.SaveChanges();

                if (this.Owner is CategoriasListarForm parentForm) parentForm.CategoriasListarForm_Load(null, null); // Para recargar los datos del grid en la ventana abierta         
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + ex.StackTrace);
            }
        }
    }
}
