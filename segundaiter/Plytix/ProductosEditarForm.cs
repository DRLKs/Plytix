using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlX.XDevAPI.Common;

namespace Plytix
{   
    public partial class ProductosEditarForm : Form
    {
        grupo11DBEntities bd = new grupo11DBEntities();
        private string sku;
        public ProductosEditarForm(String sku)
        {
            InitializeComponent();
            this.sku = sku;
        }
        private void ProductosEditarForm_Load(object sender, EventArgs e)
        {
            var seleccionado = (from p in bd.PRODUCTO
                                where p.SKU == sku
                                select p).First();
            textBoxNombre.Text = seleccionado.NOMBRE;
            textBoxSKU.Text = seleccionado.SKU;
            textBoxGTIN.Text = seleccionado.GTIN;

            var imgBlob = seleccionado.THUMBNAIL; // Para que aparezca la imagen
            if (imgBlob != null)
            {
                byte[] imageData = (byte[])imgBlob;
                MemoryStream ms = new MemoryStream(imageData);
                if (ms != null)
                {
                    pictureBox.Image = Image.FromStream(ms);
                }
            }

            // IMPORTANTE: METER DENTRO DE UN if(seleccionado.categorias != null) para que no pete si el producto no tiene ninguna categoría

            var categoriasProducto = seleccionado.CATEGORIA.ToList();
            categoriaListBox.DataSource = bd.CATEGORIA.ToList();

            var atributosProducto = new List<ATRIBUTO>();
            foreach (PRODUCTO_ATRIBUTO atr in seleccionado.PRODUCTO_ATRIBUTO)
            {
                atributosProducto.Add(atr.ATRIBUTO);
            }
            
            atributosListBox.DataSource = bd.ATRIBUTO.ToList();

            categoriaListBox.ClearSelected();

            if (categoriasProducto != null)
            {
                for (int i = 0; i < categoriaListBox.Items.Count; i++)
                {
                    if (categoriasProducto.Contains(categoriaListBox.Items[i]))
                    {
                        categoriaListBox.SetItemChecked(i, true);
                    }
                }
            }

            if (atributosProducto != null)
            {
                for (int i = 0; i < atributosListBox.Items.Count; i++)
                {
                    if (atributosProducto.Contains(atributosListBox.Items[i]))
                    {
                        atributosListBox.SetItemChecked(i, true);
                    }
                }
            }
        }

        // BOTÓN DE GUARDAR
        private void buttonSave_Click(object sender, EventArgs e)
        {   
            var productoSeleccionado = (from p in bd.PRODUCTO
                                where p.SKU == sku
                                select p).First();
            productoSeleccionado.NOMBRE = textBoxNombre.Text;
            productoSeleccionado.SKU = textBoxSKU.Text; 
            productoSeleccionado.GTIN = textBoxGTIN.Text;
            productoSeleccionado.FECHA_EDICION = DateTime.Now;

            /* Limpiamos las relaciones entre categorias y productos */
            productoSeleccionado.CATEGORIA.Clear();
            foreach( CATEGORIA categoria in categoriaListBox.Items)
            {
                categoria.PRODUCTO.Remove(productoSeleccionado);
            }

            /* Añadimos las relaciones entre categorías y productos seleccionados */
            foreach( CATEGORIA categoria in categoriaListBox.SelectedItems) /* FUNCIONA MAL */
            {
                Console.WriteLine(categoria.NOMBRE);    /* DEPURACIÓN */
                productoSeleccionado.CATEGORIA.Add(categoria);
                categoria.PRODUCTO.Add(productoSeleccionado);
            }

            bd.PRODUCTO.AddOrUpdate();
            try
            {
                bd.SaveChanges();
            }
            catch( Exception)
            {
                    MessageBox.Show("You haven't made any changes");
            }
            if (this.Owner is ProductosListarForm parentForm) parentForm.ProductosListarForm_Load(null, null); // Para recargar los datos del grid en la ventana abierta         
            Close();
        }
    }
}
