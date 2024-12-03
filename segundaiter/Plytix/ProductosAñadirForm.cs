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
            CargarFormulario();
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            try
            {
                ValidarGuardadoProducto();  // Comprueba que todos los datos sean correctos

                PRODUCTO productoNuevo = new PRODUCTO();
                /* OBLIGATORIOS */
                productoNuevo.NOMBRE = textBoxNombre.Text;
                productoNuevo.SKU = textBoxSKU.Text;
                productoNuevo.THUMBNAIL = ConvertirImagenABlob(imagePath);
                productoNuevo.FECHA_CREACION = DateTime.Now;
                productoNuevo.FECHA_EDICION  = DateTime.Now;

                /* OPCIONALES */
                if ( textBoxGTIN.Text.Length > 0 )
                {
                    productoNuevo.GTIN = textBoxGTIN.Text;
                }

                if( categoriaListBox.SelectedItems.Count > 0 )
                {   
                    foreach( CATEGORIA categoias in categoriaListBox.SelectedItems)
                    {
                        productoNuevo.CATEGORIA.Add( categoias );
                    }
                }

                bd.PRODUCTO.Add( productoNuevo );
                bd.SaveChanges();
                if (this.Owner is ProductosListarForm parentForm) parentForm.ProductosListarForm_Load(null, null); // Para recargar los datos del grid en la ventana abierta         
                Close();
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

        private bool ValidarGTIN(string gtin)
        {
            if (string.IsNullOrWhiteSpace(gtin) || (gtin.Length != 8 && gtin.Length != 12 && gtin.Length != 13 && gtin.Length != 14))
                return false;

            int sum = 0;
            bool isOdd = true; // Empieza desde el dígito más a la derecha

            for (int i = gtin.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(gtin[i].ToString());
                sum += isOdd ? digit * 3 : digit;
                isOdd = !isOdd;
            }

            return sum % 10 == 0;
        }

        private string GenerarGTINAleatorio()
        {
            int longitud = 14;
            if (longitud != 8 && longitud != 12 && longitud != 13 && longitud != 14)
                throw new ArgumentException("La longitud debe ser 8, 12, 13 o 14.");

            Random random = new Random();
            int[] gtin = new int[longitud];

            // Generar los primeros (longitud - 1) dígitos aleatorios
            for (int i = 0; i < longitud - 1; i++)
            {
                gtin[i] = random.Next(0, 10);
            }

            // Calcular el checksum para el último dígito
            int sum = 0;
            bool isOdd = true;

            for (int i = longitud - 2; i >= 0; i--)
            {
                sum += isOdd ? gtin[i] * 3 : gtin[i];
                isOdd = !isOdd;
            }

            int checksum = (10 - (sum % 10)) % 10;
            gtin[longitud - 1] = checksum;

            // Convertir el array a una cadena
            return string.Join("", gtin);
        }

        private void GenerateGTINClick(object sender, EventArgs e)
        {
            textBoxGTIN.Text = GenerarGTINAleatorio();
        }

        private void ValidarGuardadoProducto()
        {
            if (textBoxNombre.Text == "")
            {
                throw new Exception("Empty Product Name");
            }
            else if (textBoxSKU.Text == "")
            {
                throw new Exception("Empty SKU");
            }
            else if (imagePath == null)
            {
                throw new Exception("Empty Thumbnail");
            }
            else if (textBoxGTIN.Text != "")
            {
                if (!ValidarGTIN(textBoxGTIN.Text))
                {
                    throw new Exception("El GTIN no es válido");
                }
            }
        }

        private void CargarFormulario()
        {
            atributosListBox.DataSource = bd.ATRIBUTO.ToList();
            atributosListBox.SelectedItem = null;

            categoriaListBox.DataSource = bd.CATEGORIA .ToList();
            categoriaListBox.SelectedItem = null;
        }

    }
}
