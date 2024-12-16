using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Plytix
{
    public partial class ProductosListarForm : Form
    {
        grupo11DBEntities bd = new grupo11DBEntities();
        public ProductosListarForm()
        {
            InitializeComponent();
            this.FormClosing += MainForm_FormClosing;   // Para cerrar el programa no solo el FORMS
        }

        private String atributosProductos(PRODUCTO prod)
        {
            StringBuilder sb = new StringBuilder();
            foreach (PRODUCTO_ATRIBUTO atr in prod.PRODUCTO_ATRIBUTO.ToList())
            {
                sb.Append(atr.ATRIBUTO.NOMBRE + ": ");
                sb.Append(atr.valor + " ");
            }
            return sb.ToString();
        }

        public void ProductosListarForm_Load(object sender, EventArgs e)
        {
            // Deja vacío el Grid view 
            ProductosGridView.DataSource = null;
            ProductosGridView.Columns.Clear();

            // Tamaño: 45, Precio: 78, Altura: 78
            // Cargo las columnas de los productos con los campos necesarios
            var seleccion = bd.PRODUCTO
                            .ToList()
                            .Select(p => new
                            {
                                THUMBNAIL = p.THUMBNAIL,
                                NAME = p.NOMBRE,
                                SKU = p.SKU,
                                //bd.ATRIBUTO[0].NOMBRE = mostrarValor(bd.ATRIBUTO[0].ID, p.ID)
                                ATTRIBUTES = atributosProductos(p)
                            }).ToList();
            ProductosGridView.DataSource = seleccion;
            ProductosGridView.ClearSelection();

            // Añado las columnas con los botones de ver, editar y eliminar
            ProductosGridView.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Details",
                HeaderText = "DETAILS",
                Text = "👁️",
                UseColumnTextForButtonValue = true
            });

            ProductosGridView.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "EDIT",
                Text = "✏️",
                UseColumnTextForButtonValue = true
            });

            ProductosGridView.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "DELETE",
                Text = "🗑️",
                UseColumnTextForButtonValue = true

            });
        }
        

        // Si se ha pulsado alguna celda (nos interesan las de editar, eliminar y ver detalles)
        private void ProductosGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string columnName = ProductosGridView.Columns[e.ColumnIndex].Name; // Columna desde la que ocurrió el click
                String sku = ProductosGridView.Rows[e.RowIndex].Cells["SKU"].Value.ToString();
                PRODUCTO producto = bd.PRODUCTO.First(x => x.SKU.Equals(sku));

                if (columnName == "Details") // Columna Eliminar
                {
                    ProductosVerDetallesForm productosVerDetallesForm = new ProductosVerDetallesForm(sku);
                    productosVerDetallesForm.Owner = this;
                    productosVerDetallesForm.ShowDialog();
                }
                else if (columnName == "Edit") // Columna Editar
                {
                    ProductosEditarForm productosEditarForm = new ProductosEditarForm(sku);
                    productosEditarForm.Owner = this;
                    productosEditarForm.ShowDialog();
                }
                else if (columnName == "Delete") // Columna Eliminar
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this product?",
                                                          "Confirmation", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        bd.PRODUCTO.Remove(producto);
                        bd.SaveChanges();
                        ProductosGridView.ClearSelection();
                        ProductosListarForm_Load(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);

            }

        }

        private void plytixLabel_Click(object sender, EventArgs e)
        {
            MainForm form = new MainForm();
            form.Show();
            Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            AbrirFormularioAddProducto();
        }
        private void AddProductLabel_Click(object sender, EventArgs e)
        {
            AbrirFormularioAddProducto();
        }

        private void AbrirFormularioAddProducto()
        {
            ProductosAñadirForm productosAddForm = new ProductosAñadirForm();
            productosAddForm.Owner = this;
            productosAddForm.ShowDialog();
        }
    }
}
