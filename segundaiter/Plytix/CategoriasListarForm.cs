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
    public partial class CategoriasListarForm : Form
    {
        grupo11DBEntities bd = new grupo11DBEntities();
        public CategoriasListarForm()
        {
            InitializeComponent();
        }

        public void CategoriasListarForm_Load(object sender, EventArgs e)
        {
            // Deja vacío el Grid view 
            CategoriasGridView.DataSource = null;
            CategoriasGridView.Columns.Clear();

            // Cargo las columnas de las categorías con los campos necesarios
            var seleccion = from c in bd.CATEGORIA
                            select new
                            {
                                NAME = c.NOMBRE,
                                PRODUCTS = c.PRODUCTO.Count,
                            };
            CategoriasGridView.DataSource = seleccion.ToList();
            CategoriasGridView.ClearSelection();

            // Oculto el botón de añadir categoría si ya hay 3 creadas
            if(seleccion.Count() >= 3)
            {
                addLabel.Hide();
                button1.Hide();
            }
            else
            {
                addLabel.Show();
                button1.Show();
            }

            // Añado las columnas con los botones de editar y eliminar
            CategoriasGridView.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "EDIT",
                Text = "✏️",
                UseColumnTextForButtonValue = true
            });

            CategoriasGridView.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "DELETE",
                Text = "🗑️",
                UseColumnTextForButtonValue = true

            });
        }

        // Si se ha pulsado alguna celda (nos interesan las de editar y eliminar)
        private void CategoriasGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = CategoriasGridView.Columns[e.ColumnIndex].Name; // Columna desde la que ocurrió el click
            string nombreCategoria = (CategoriasGridView.Rows[e.RowIndex].Cells[0].Value).ToString();
            CATEGORIA categoria = (from c in bd.CATEGORIA
                                  where c.NOMBRE.Equals(nombreCategoria)
                                  select c).First();

            if (columnName == "Edit") // Columna Editar
            {
                CategoriasEditarForm categoriaEditarForm = new CategoriasEditarForm(categoria.ID);
                categoriaEditarForm.Owner = this;
                categoriaEditarForm.ShowDialog();
                
            }
            else if (columnName == "Delete") // Columna Eliminar
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this category?",
                                                      "Confirmation", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    bd.CATEGORIA.Remove(categoria);
                    bd.SaveChanges();
                    CategoriasGridView.ClearSelection();
                    CategoriasListarForm_Load(null, null);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CategoriasAñadirForm categoriasAñadirForm = new CategoriasAñadirForm();
            categoriasAñadirForm.Owner = this;
            categoriasAñadirForm.ShowDialog();
        }

        private void plytixLabel_Click(object sender, EventArgs e)
        {
            MainForm form = new MainForm();
            form.Show();
            Close();
        }
    }
}
