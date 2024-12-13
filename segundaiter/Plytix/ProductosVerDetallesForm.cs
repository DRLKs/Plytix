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

namespace Plytix
{
    public partial class ProductosVerDetallesForm : Form
    {
        grupo11DBEntities bd = new grupo11DBEntities();
        PRODUCTO producto;
        public ProductosVerDetallesForm(String sku)
        {
            InitializeComponent();
            try
            {
                producto = bd.PRODUCTO.First(x => x.SKU.Equals(sku));
                labelNombre.Text = producto.NOMBRE;
                labelSKU.Text = producto.SKU;
                labelGTIN.Text = producto.GTIN;
                String categorias = categoriasProducto();
                if (categorias.Length != 0)
                {
                    labelCategorias.Text = categorias.Remove(categorias.Length - 2); // Para eliminar la ultima coma
                }
                String atributos = atributosProducto();
                if (atributos.Length != 0)
                {
                    labelAtributos.Text = atributosProducto().Remove(atributosProducto().Length - 2);
                }
                if (producto.DESCRIPCION_CORTA != null)
                {
                    labelDescC.Text = producto.DESCRIPCION_CORTA;
                }
                if(producto.DESCRIPCION_CORTA != null)
                {
                    labelDescL.Text = producto.DESCRIPCION_LARGA;
                }              


                var imgBlob = producto.THUMBNAIL; // Para que aparezca la imagen
                if (imgBlob != null)
                {
                    byte[] imageData = (byte[])imgBlob;
                    MemoryStream ms = new MemoryStream(imageData);
                    if (ms != null)
                    {
                        pictureBox.Image = Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            
        }

        private String categoriasProducto()
        {
            StringBuilder sb = new StringBuilder();
            foreach (CATEGORIA c in producto.CATEGORIA.ToList())
            {
                sb.Append(c.NOMBRE + ", "); 
            }
            return sb.ToString();
        }

        private String atributosProducto()
        {
            StringBuilder sb = new StringBuilder();
            foreach (PRODUCTO_ATRIBUTO atr in producto.PRODUCTO_ATRIBUTO.ToList())
            {
                sb.Append(atr.ATRIBUTO.NOMBRE + ": ");
                sb.Append(atr.valor + ", ");
            }
            return sb.ToString();
        }
    }
}
