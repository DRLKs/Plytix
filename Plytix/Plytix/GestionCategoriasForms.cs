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
            CategoriasGridView.AllowUserToAddRows = false;  // Limpia la última fila que no tiene nada

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
                    CategoriasGridView.Columns.Add("ID", "ID");
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

                    CategoriasGridView.Columns[2].Visible = false;  // Ocultar la columna de assets (No hay que implementarla)
                   
                }
                int numProd;
                // Agrega los datos al DataGridView
                foreach (var c in listaCategorias)
                {
                    numProd = (from p in conexion.PRODUCTO
                               where p.CATEGORIAID == c.ID
                               select p).Count();
                    CategoriasGridView.Rows.Add(c.ID,c.NOMBRE, "0", numProd);
                }
                
                CategoriasGridView.Show();
                CategoriasGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cierra toda la aplicación
            Application.Exit();
        }

        /*
         * Función que llama el DataGrid cuando selecciona la columna EDIT, DELETE 
         */
        private void CategoriasGridClickar(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // Identificar la columna donde ocurrió el clic
            string columnName = CategoriasGridView.Columns[e.ColumnIndex].Name;

            if (columnName == "Edit") // Columna Editar
            {
                // Obtener datos de la categoría seleccionada
                int id = (int) CategoriasGridView.Rows[e.RowIndex].Cells["ID"].Value;
                EditarCategoria(id);
            }
            else if (columnName == "Delete") // Columna Eliminar
            {
                // Confirmar antes de eliminar
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar esta categoría?",
                                                      "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int id = (int) CategoriasGridView.Rows[e.RowIndex].Cells["ID"].Value;
                    EliminarCategoria(id);
                }
            }
        }

        private void AddCategoryClick(object sender, EventArgs e)
        {
            var AddCform = new CategoriesForms(-1, this);
            AddCform.Show();
        }

        private void EditarCategoria( int id )
        {
            var AddCform = new CategoriesForms(id, this);
            AddCform.Show();
        }

        private void EliminarCategoria( int id)
        {
            var productosCategoriaEliminada = from prod in conexion.PRODUCTO
                                              where prod.CATEGORIAID == id
                                              select prod;

            CATEGORIA c = (from categoria in conexion.CATEGORIA
                           where categoria.ID == id
                           select categoria).FirstOrDefault();
            conexion.CATEGORIA.Remove(c);
            conexion.SaveChanges();
            CargarCategorias();
        }

        private void TextFiltro_TextChanged(object sender, EventArgs e)
        {
            filtro = textFiltroCategorias.Text;
            CargarCategorias();
        }
    }
}
