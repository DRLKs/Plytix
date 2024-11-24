using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plytix
{
    public partial class CategoriesForms : Form
    {
        private int id;
        private GestionCategoriasForms formularioPadre;
        public CategoriesForms( int id, GestionCategoriasForms forms)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.formularioPadre = forms;
            // Configurar el tamaño automático del formulario
            this.AutoSize = true;                // Ajustar el tamaño automáticamente al contenido
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink; // Evitar que se agrande manualmente

            // Deshabilitar el cambio de tamaño
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Fija el tamaño y deshabilita el redimensionamiento
            this.MaximizeBox = false;           // Deshabilitar el botón de maximizar
            this.MinimizeBox = false;           // Opcional: deshabilitar el botón de minimizar

            // Centrar el formulario respecto al formulario padre
            this.StartPosition = FormStartPosition.CenterParent;

            // Asignar el formulario padre como dueño (opcional)
            this.Owner = formularioPadre;

            if (id >= 0)
            {
                textBoxId.ReadOnly = true;
                this.id = id;
                RellenarTextBoxes();
            }
            else
            {
                this.id = -1;
                textBoxId.Text = "";
                textBoxNombre.Text = "";
            }
        }

        private void SaveClick(object sender, EventArgs e)
        {
            if(textBoxId.Text != null && textBoxId.Text != "" && textBoxNombre.Text != "")
            {
                grupo11DBEntities conexion = new grupo11DBEntities();

                try
                {
                    CATEGORIA c;
                    if (this.id >= 0 )
                    {
                        c = (from categoria in conexion.CATEGORIA
                             where categoria.ID == this.id
                             select categoria).FirstOrDefault();

                        if ( c.NOMBRE != textBoxNombre.Text ) c.NOMBRE = textBoxNombre.Text;
                    }
                    else
                    {
                        c = new CATEGORIA   // Inicializamos la Categoría con el nuevo ID
                        {
                            ID = Int32.Parse(textBoxId.Text),
                            NOMBRE = textBoxNombre.Text
                        };
                    }

                    if (this.id < 0)    // Estamos añadiendo una categoría
                    {
                        conexion.CATEGORIA.Add(c);
                    }
                    conexion.SaveChanges();
                    formularioPadre.CargarCategorias();
                    this.Hide();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Error: El ID no es válido");
                }
                catch (Exception)   // Deberiamos añadir más excepciones
                {
                    // Manejar otras excepciones generales
                    MessageBox.Show("Error: ID o Nombre ya existen");
                }

            }
            else
            {
                MessageBox.Show("Rellene antes los parámetros");
            }
        }

        private void RellenarTextBoxes()
        {
            grupo11DBEntities conexion = new grupo11DBEntities();

            CATEGORIA c = (from categoria in conexion.CATEGORIA
                           where categoria.ID == id
                           select categoria).FirstOrDefault();

            textBoxId.Text = c.ID.ToString();
            textBoxNombre.Text = c.NOMBRE;
        }
    }
}
