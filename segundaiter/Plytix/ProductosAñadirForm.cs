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
    public partial class ProductosAñadirForm : Form
    {
        grupo11DBEntities bd;
        string imagePath;

        public ProductosAñadirForm()
        {
            InitializeComponent();
            bd = new grupo11DBEntities();
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (textBoxNombre.Text != "")
                {
                    throw new Exception("Empty Product Name");
                }
                else if (textBoxSKU.Text != "")
                {
                    throw new Exception("Empty SKU");
                }else if( imagePath == null)
                {
                    throw new Exception("Empty Thumbnail");
                }
                else
                {
                    PRODUCTO productoNuevo = new PRODUCTO();
                    productoNuevo.NOMBRE = textBoxNombre.Text;
                    productoNuevo.SKU = textBoxSKU.Text; // Es unico y no se debe cambiar a no ser que le asignemos al producto un identificador ID
                                                         // Hay que hacer una función que valide si el SKU es válido
                    productoNuevo.GTIN = textBoxGTIN.Text;
                    productoNuevo.THUMBNAIL = ConvertirImagenABlob(imagePath);




                    bd.SaveChanges();
                    if (this.Owner is ProductosListarForm parentForm) parentForm.ProductosListarForm_Load(null, null); // Para recargar los datos del grid en la ventana abierta         
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void SaveImage(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                // Establecer el filtro para mostrar solo archivos de imagen
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;";

                // Mostrar el cuadro de diálogo
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obtener la ruta del archivo seleccionado
                    imagePath = openFileDialog.FileName;

                    // Mostrar la imagen en un PictureBox (si tienes uno en tu formulario)
                    pictureBox.Image = Image.FromFile(imagePath);
                }
            }
            catch
            {
                MessageBox.Show("Error. No ha sido posible cargar la imagen");
            }
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
    }
}
