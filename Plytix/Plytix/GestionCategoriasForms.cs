using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting.Contexts;

namespace Plytix
{
    public partial class GestionCategoriasForms : Form
    {
        private String filtro;
        private grupo11DBEntities conexion;
        public GestionCategoriasForms()
        {
            InitializeComponent();
            conexion = new grupo11DBEntities();
            this.FormClosing += MainForm_FormClosing;   // Para cerrar el programa no solo el FORMS
            filtro = "";
            CargarCategorias();
        }

        public void CargarCategorias()
        {
            NoProductsLabel.Hide();
            CategoriasGridView.Show();

            CategoriasGridView.Columns.Clear(); // Asegúrate de que no haya columnas duplicadas
            CategoriasGridView.Rows.Clear();    // Limpia filas anteriores, si las hubiera

            List<CATEGORIA> listaCategorias;
            if (filtro == "")
            {
                listaCategorias = (from c in conexion.CATEGORIA select c).ToList();
            }
            else
            {
                listaCategorias = (from c in conexion.CATEGORIA
                                  where c.NOMBRE.Contains(filtro)
                                  select c).ToList();
            }

            if (listaCategorias.Count > 0)
            {
                // Configura columnas
                if (CategoriasGridView.Columns.Count == 0)
                {

                    CategoriasGridView.Columns.Add("Category Name", "Nombre");
                    CategoriasGridView.Columns.Add("Assets", "Assets");
                    CategoriasGridView.Columns.Add("Number of Products", "Products");
                    CategoriasGridView.Columns.Add(new DataGridViewButtonColumn
                    {
                        Name = "Edit",
                        HeaderText = "Edit",
                        Text = "✏️",
                        UseColumnTextForButtonValue = true
                    });

                    CategoriasGridView.Columns.Add(new DataGridViewButtonColumn
                    {
                        Name = "Delete",
                        HeaderText = "Delete",
                        Text = "🗑️",
                        UseColumnTextForButtonValue = true
                    });
                }
                int numProd;
                // Agrega los datos al DataGridView
                foreach (var c in listaCategorias)
                {
                    numProd = (from p in conexion.PRODUCTO
                               where p.CATEGORIAID == c.ID
                               select p).Count();
                    CategoriasGridView.Rows.Add(c.NOMBRE, "0", numProd);
                }

                CategoriasGridView.Show();
            }
            else
            {
                NoProductsLabel.Show();
                CategoriasGridView.Hide();
            }

        }

        private void Volver_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForms();
            mainForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var AddCform = new CategoriesForms(-1,this);
            AddCform.Show();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cierra toda la aplicación
            Application.Exit();
        }
    }
}
