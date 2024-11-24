using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plytix
{
    public partial class GestionProductosForms : Form
    {
        private grupo11DBEntities conexion;
        private String filtro;

        public GestionProductosForms()
        {
            InitializeComponent();
            conexion = new grupo11DBEntities();
            ProductosGridView.AllowUserToAddRows = false;
            this.FormClosing += MainForm_FormClosing;   // Para cerrar el programa no solo el FORMS
            filtro = "";
            CargarProductos();
        }

        public void CargarProductos()
        {
            NoProductsLabel.Hide();
            ProductosGridView.Show();

            ProductosGridView.Columns.Clear(); // Asegúrate de que no haya columnas duplicadas
            ProductosGridView.Rows.Clear();    // Limpia filas anteriores, si las hubiera

            List<PRODUCTO> listaProductos;
            if ( filtro == "")
            {
                listaProductos = (from producto in conexion.PRODUCTO select producto).ToList();
            }
            else
            {
                listaProductos = (from producto in conexion.PRODUCTO
                                  where producto.NOMBRE.Contains(filtro)
                                  select producto).ToList();
            }

            if (listaProductos.Count > 0)
            {
                ProductosGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                // Configura columnas
                if (ProductosGridView.Columns.Count == 0)
                {
                    ProductosGridView.Columns.Add(new DataGridViewImageColumn
                    {
                        Name = "Thumbnail",
                        HeaderText = "Thumbnail",
                        ImageLayout = DataGridViewImageCellLayout.Zoom
                    });

                    ProductosGridView.Columns.Add("Name", "Nombre");
                    ProductosGridView.Columns.Add("SKU", "SKU");
                    ProductosGridView.Columns.Add("GTIN", "GTIN");
                    ProductosGridView.Columns.Add("Related products", "Related products");
                    ProductosGridView.Columns.Add("Categoria", "Category");

                    ProductosGridView.Columns.Add(new DataGridViewButtonColumn
                    {
                        Name = "Edit",
                        HeaderText = "Edit",
                        Text = "✏️",
                        UseColumnTextForButtonValue = true
                    });

                    ProductosGridView.Columns.Add(new DataGridViewButtonColumn
                    {
                        Name = "Delete",
                        HeaderText = "Delete",
                        Text = "🗑️",
                        UseColumnTextForButtonValue = true
                    });
                }

                // Agrega los datos al DataGridView
                foreach (var p in listaProductos)
                {
                    var thumbnail = p.THUMBNAIL != null
                        ? ConvertirBlobAImagen(p.THUMBNAIL)
                        : Image.FromFile(@"..\..\Resources\sinImagen.jpg");
                    
                    StringBuilder sb = new StringBuilder();
                    foreach (var producto in p.PRODUCTO2)
                    {
                        sb.Append(producto.NOMBRE).Append(", "); // Agregamos el producto seguido de una coma
                    }

                    String categoriaNombre = (from categoria in conexion.CATEGORIA where categoria.ID == p.CATEGORIAID select categoria.NOMBRE).FirstOrDefault();

                    ProductosGridView.Rows.Add(thumbnail, p.NOMBRE, p.SKU, p.GTIN, sb.ToString() , categoriaNombre );
                }

                ProductosGridView.Show();
            }
            else
            {
                NoProductsLabel.Show();
                ProductosGridView.Hide();
            }

        }

        private void VolverClick(object sender, EventArgs e)
        {
            var mainForm = new MainForms();
            mainForm.Show();
            this.Hide();
        }

        private void AddProductButton(object sender, EventArgs e)
        {
            var addPForms = new ProductsForms(null, this);
            addPForms.Show();
        }

        public byte[] ConvertirImagenABlob(string rutaImagen)
        {
            byte[] imagenBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                // Cargar la imagen en un MemoryStream
                Image imagen = Image.FromFile(rutaImagen);
                imagen.Save(ms, imagen.RawFormat); // Guardar la imagen en el stream
                imagenBytes = ms.ToArray(); // Obtener el arreglo de bytes
            }
            return imagenBytes;
        }

        public Image ConvertirBlobAImagen(byte[] blob)
        {
            using (MemoryStream ms = new MemoryStream(blob))
            {
                return Image.FromStream(ms);
            }
        }

        private void ProductosGridClickar(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // Identificar la columna donde ocurrió el clic
            string columnName = ProductosGridView.Columns[e.ColumnIndex].Name;

            if (columnName == "Edit") // Columna Editar
            {
                // Obtener datos del producto seleccionado
                String  sku = ProductosGridView.Rows[e.RowIndex].Cells["SKU"].Value.ToString();
                EditarProducto(sku);
            }
            else if (columnName == "Delete") // Columna Eliminar
            {
                // Confirmar antes de eliminar
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?",
                                                      "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    String sku = ProductosGridView.Rows[e.RowIndex].Cells["SKU"].Value.ToString();
                    EliminarProducto(sku);
                }
            }
        }
        private void EliminarProducto(String sku)
        {
            PRODUCTO p = (from producto in conexion.PRODUCTO
                          where producto.SKU == sku
                          select producto).FirstOrDefault();

            conexion.PRODUCTO.Remove(p);
            conexion.SaveChanges();
            CargarProductos();
        }

        private void EditarProducto(String sku)
        {
            var addPForms = new ProductsForms(sku, this);
            addPForms.Show();
        }

        private void NuevoFiltroProductos(object sender, EventArgs e)
        {
            filtro = textFiltroProductos.Text;
            CargarProductos();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cierra toda la aplicación
            Application.Exit();
        }

    }

    
}
