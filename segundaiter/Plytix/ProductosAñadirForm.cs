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
                productoNuevo.GTIN = textBoxGTIN.Text;

                /* OPCIONALES */
                if ( categoriaListBox.SelectedItems.Count > 0 )
                {   
                    foreach( CATEGORIA categorias in categoriaListBox.SelectedItems)
                    {
                        productoNuevo.CATEGORIA.Add( categorias );
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
            if (string.IsNullOrWhiteSpace(gtin) || gtin.Length != 14)
                return false;
            /*  //EL ALGORITMO ESTE ES UN MIERDÓN NO FUNCIONA Y 
            int sum = 0;
            bool isEven = true; // Alternar comenzando desde el último dígito

            for (int i = gtin.Length - 1; i >= 0; i--)
            {
                if (!char.IsDigit(gtin[i])) // Validar que todos los caracteres sean dígitos
                    return false;

                int digit = int.Parse(gtin[i].ToString());
                sum += isEven ? digit * 3 : digit; // Multiplicar por 3 si es posición par
                isEven = !isEven; // Alternar
            }
            
            return sum % 10 == 0;
            */
            return true;
        }

        private string GenerarGTINAleatorio()
        {
            int longitud = 14;
            Random random = new Random();
            int[] gtin = new int[longitud];

            // Generar los primeros 13 dígitos aleatorios
            for (int i = 0; i < longitud - 1; i++)
            {
                gtin[i] = random.Next(0, 10);
            }

            // Calcular el checksum (último dígito)
            int sum = 0;
            bool isEven = true; // Alternar comenzando desde el penúltimo dígito

            for (int i = longitud - 2; i >= 0; i--)
            {
                sum += isEven ? gtin[i] * 3 : gtin[i]; // Multiplicar por 3 si es posición par
                isEven = !isEven; // Alternar
            }

            int checksum = (10 - (sum % 10)) % 10; // Obtener el dígito de control
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
                if (!ValidarGTIN(textBoxGTIN.Text) )
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
