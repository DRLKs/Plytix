using System;
using System.Data;
using System.Linq;
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

        public void ProductosListarForm_Load(object sender, EventArgs e)
        {
            // Deja vacío el Grid view 
            ProductosGridView.DataSource = null;
            ProductosGridView.Columns.Clear();  

            // Cargo las columnas de los productos con los campos necesarios
            var seleccion = from p in bd.PRODUCTO
                            select new
                            {
                                THUMBNAIL = p.THUMBNAIL,
                                NAME = p.NOMBRE,
                                p.SKU
                            };
            ProductosGridView.DataSource = seleccion.ToList();
            ProductosGridView.ClearSelection();

            // Añado las columnas con los botones de editar y eliminar
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

        // Si se ha pulsado alguna celda (nos interesan las de editar y eliminar)
        private void ProductosGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = ProductosGridView.Columns[e.ColumnIndex].Name; // Columna desde la que ocurrió el click
            String sku = ProductosGridView.Rows[e.RowIndex].Cells["SKU"].Value.ToString();
            if (columnName == "Edit") // Columna Editar
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
                    PRODUCTO dlt = (from p in bd.PRODUCTO
                                   where p.SKU == sku
                                   select p).FirstOrDefault();
                    bd.PRODUCTO.Remove(dlt);
                    bd.SaveChanges();
                    ProductosGridView.ClearSelection();
                    ProductosListarForm_Load(null, null);
                }
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
