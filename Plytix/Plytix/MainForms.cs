using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// ACTUALIZADO

namespace Plytix
{
    public partial class MainForms : Form
    {
        public MainForms()
        {
            InitializeComponent();
            DecorarForms();
        }

        private void DecorarForms()
        {
            // Configurar botón 1
            button1.BackColor = Color.FromArgb(63, 81, 181); // Azul moderno
            button1.ForeColor = Color.White; // Texto blanco
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0; // Sin borde
            button1.Font = new Font("Segoe UI", 12, FontStyle.Bold); // Fuente elegante

            // Agregar efectos al pasar el mouse
            button1.MouseEnter += (s, e) => button1.BackColor = Color.FromArgb(92, 107, 192); // Azul más claro
            button1.MouseLeave += (s, e) => button1.BackColor = Color.FromArgb(63, 81, 181); // Azul original

            // Configurar botón 2
            button2.BackColor = Color.FromArgb(76, 175, 80); // Verde moderno
            button2.ForeColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            button2.MouseEnter += (s, e) => button2.BackColor = Color.FromArgb(102, 187, 106); // Verde más claro
            button2.MouseLeave += (s, e) => button2.BackColor = Color.FromArgb(76, 175, 80);

            // Configurar botón 3
            button3.BackColor = Color.FromArgb(244, 67, 54); // Rojo moderno
            button3.ForeColor = Color.White;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button3.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            button3.MouseEnter += (s, e) => button3.BackColor = Color.FromArgb(229, 115, 115); // Rojo más claro
            button3.MouseLeave += (s, e) => button3.BackColor = Color.FromArgb(244, 67, 54);
        }

        private void ProductosClick(object sender, EventArgs e)
        {
            var productosForm = new GestionProductosForms();
            productosForm.Show();
            this.Hide();
        }

        private void CategoriasClick(object sender, EventArgs e)
        {
            var categoriasForm = new GestionCategoriasForms();
            categoriasForm.Show();
            this.Hide();
        }

        private void AtributosClick(object sender, EventArgs e)
        {
            var atributtesForm = new GestionAtributosForm( null );
            atributtesForm.Show();
            this.Hide();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(236, 239, 241), // Gris claro
                Color.FromArgb(144, 164, 174), // Gris oscuro
                System.Drawing.Drawing2D.LinearGradientMode.Vertical)) // Degradado vertical
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

    }
}
