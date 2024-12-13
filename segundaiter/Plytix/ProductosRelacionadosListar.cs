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
    public partial class ProductosRelacionadosListar : Form
    {
        grupo11DBEntities bd;
        public ProductosRelacionadosListar()
        {
            InitializeComponent();
            bd = new grupo11DBEntities();
            CargarProductosRelacionados();
        }

        public void CargarProductosRelacionados()
        {
            try
            {
                // Deja vacío el Grid view 
                ProductosRelaciondosdataGridView.DataSource = null;
                ProductosRelaciondosdataGridView.Columns.Clear();
                ProductosRelaciondosdataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                ProductosRelaciondosdataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Cargo las columnas de las categorías con los campos necesarios
                var seleccion = from PR in bd.PRODRELACIONADOS
                                select new
                                {
                                    NAME = PR
                                };
                ProductosRelaciondosdataGridView.DataSource = seleccion.ToList();
                ProductosRelaciondosdataGridView.ClearSelection();

                // Oculto el botón de añadir categoría si ya hay 3 creadas
                if (seleccion.Count() >= 5)
                {
                    addLabel.Hide();
                    buttonAddLabel.Hide();
                }
                else
                {
                    addLabel.Show();
                    buttonAddLabel.Show();
                }

                // Añado las columnas con los botones de editar y eliminar
                ProductosRelaciondosdataGridView.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "Edit",
                    HeaderText = "EDIT",
                    Text = "✏️",
                    UseColumnTextForButtonValue = true
                });

                ProductosRelaciondosdataGridView.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    HeaderText = "DELETE",
                    Text = "🗑️",
                    UseColumnTextForButtonValue = true

                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void AddRelatedProduct_Click(object sender, EventArgs e)
        {
            ProductosRelacionadosAñadirForm categoriaEditarForm = new ProductosRelacionadosAñadirForm();
            categoriaEditarForm.Owner = this;
            categoriaEditarForm.ShowDialog();
        }

        private void ProductosRelaciondosdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string columnName = ProductosRelaciondosdataGridView.Columns[e.ColumnIndex].Name; // Columna desde la que ocurrió el click
                string name = ProductosRelaciondosdataGridView.Rows[e.RowIndex].Cells["NAME"].Value.ToString();
                

                //ESTO FALLA POR ALGUN SUCEOS INTERNO, CREO QU LA BD VA TURULETA XD UWU

                PRODRELACIONADOS pr = (from p in bd.PRODRELACIONADOS
                                     where p.NAME == name
                                     select p).FirstOrDefault();

                if (columnName == "Edit") // Columna Editar
                {
                    ProductosEditarForm productosEditarForm = new ProductosEditarForm(name);
                    productosEditarForm.Owner = this;
                    productosEditarForm.ShowDialog();
                }
                else if (columnName == "Delete") // Columna Eliminar
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this relation?",
                                                          "Confirmation", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        bd.PRODRELACIONADOS.Remove(pr);
                        bd.SaveChanges();
                        ProductosRelaciondosdataGridView.ClearSelection();
                        CargarProductosRelacionados();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }

        
        }
        
    }
}
