using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plytix
{
    public partial class AddProductForm : Form
    {
        private string imagePath;
        public AddProductForm()
        {
            InitializeComponent();
            btnCerrar_Paint();
            this.FormBorderStyle = FormBorderStyle.None;  // Elimina los bordes
            this.MaximizeBox = false;  // Evita que el formulario pueda maximizarse
            this.MinimizeBox = false;  // Evita que el formulario pueda minimizarse

            imagePath = null;
        }



        private void SaveClick(object sender, EventArgs e)
        {   
            if (textBoxSKU.Text.Length > 0 && textBoxNombre.Text.Length > 0)
            {
                PRODUCTO p;
                if (imagePath == null) 
                {
                    p = new PRODUCTO
                    {
                        SKU = textBoxSKU.Text,
                        GTIN = textBoxNombre.Text,
                        NOMBRE = textBoxNombre.Text,
                        CATEGORIAID = null
                    };
                }
                else
                {
                    p = new PRODUCTO
                    {
                        SKU = textBoxSKU.Text,
                        GTIN = textBoxNombre.Text,
                        NOMBRE = textBoxNombre.Text,
                        THUMBNAIL = ConvertirImagenABlob(imagePath),
                        CATEGORIAID = null
                    };
                }

                
                grupo11DBEntities conexion = new grupo11DBEntities();
                conexion.PRODUCTO.Add(p);
                conexion.SaveChanges();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Debes rellenar obligatoriamente los apartados de SKU y NOMBRE");
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

        private void ExitButton(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_Paint()
        {
            btnCerrar.Width = 50;
            btnCerrar.Height = 50;
            btnCerrar.Region = new Region(new Rectangle(0, 0, btnCerrar.Width, btnCerrar.Height));
            btnCerrar.FlatStyle = FlatStyle.Flat;  // Elimina el borde
            btnCerrar.FlatAppearance.BorderSize = 0;  // Elimina el borde
            btnCerrar.BackColor = Color.Red;  // Puedes cambiar el color de fondo
        }

        private void SubirImagenClick(object sender, EventArgs e)
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
    }
}
