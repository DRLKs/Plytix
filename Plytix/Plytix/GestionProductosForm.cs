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
    public partial class GestionProductosForms : Form
    {
        private grupo11DBEntities conexion;

        public GestionProductosForms()
        {
            InitializeComponent();
            conexion = new grupo11DBEntities();
            inicializarGridView();
            cargarProductos();
        }

        private void inicializarGridView()
        {
            ProductosGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false, // Desactivar fila de "nueva entrada"
                RowTemplate = { Height = 60 } // Altura de fila para miniaturas
            };

            var imageColumn = new DataGridViewImageColumn
            {
                Name = "Thumbnail",
                HeaderText = "Thumbnail",
                ImageLayout = DataGridViewImageCellLayout.Zoom // Ajustar imagen
            };
            ProductosGridView.Columns.Add(imageColumn);

            ProductosGridView.Columns.Add("Name", "Name");
            ProductosGridView.Columns.Add("SKU", "SKU");
            ProductosGridView.Columns.Add("GTIN", "GTIN");
            ProductosGridView.Columns.Add("RelatedProducts", "Related Products");
            ProductosGridView.Columns.Add("Category", "Category");

            var editButton = new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "",
                Text = "✏️", // Icono o texto para editar
                UseColumnTextForButtonValue = true
            };
            ProductosGridView.Columns.Add(editButton);

            var deleteButton = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "",
                Text = "🗑️", // Icono o texto para eliminar
                UseColumnTextForButtonValue = true
            };
            ProductosGridView.Columns.Add(deleteButton);
        }

        public void cargarProductos()
        {
            ProductosGridView.AutoGenerateColumns = false;

            ProductosGridView.Columns.Add(new DataGridViewImageColumn
            {
                DataPropertyName = "ImagenUrl", // Solo si usas URL para imágenes
                HeaderText = "Thumbnail"
            });

            ProductosGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre"
            });

            ProductosGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SKU",
                HeaderText = "SKU"
            });

            ProductosGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GTIN",
                HeaderText = "GTIN"
            });

            ProductosGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CATEGORIAID",
                HeaderText = "CATEGORIA"
            });


            List<PRODUCTO> listaProductos = (from producto in conexion.PRODUCTO select producto).ToList();

            foreach (PRODUCTO p in listaProductos)
            {
            }
            ProductosGridView.DataSource = listaProductos;
        }

        private void VolverClick(object sender, EventArgs e)
        {
            var mainForm = new MainForms();
            mainForm.Show();
            this.Hide();
        }

        private void AddProductButton(object sender, EventArgs e)
        {
            var addPForms = new AddProductForm();
            addPForms.Width = 300;
            addPForms.Height = 700;
            addPForms.Show();
        }
    }
}
