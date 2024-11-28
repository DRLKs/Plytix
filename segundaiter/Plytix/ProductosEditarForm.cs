using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        // BOTÓN DE GUARDAR
        private void buttonSave_Click(object sender, EventArgs e)
        {
            var seleccionado = (from p in bd.PRODUCTO
                                where p.SKU == sku
                                select p).First();
            seleccionado.NOMBRE = textBoxNombre.Text;
            seleccionado.SKU = textBoxSKU.Text; // Es unico y no se debe cambiar a no ser que le asignemos al producto un identificador ID
                                                // Hay que hacer una función que valide si el SKU es válido
            seleccionado.GTIN = textBoxGTIN.Text;



            bd.SaveChanges();
            if (this.Owner is ProductosListarForm parentForm) parentForm.ProductosListarForm_Load(null, null); // Para recargar los datos del grid en la ventana abierta         
            Close();
        }
    }
}
