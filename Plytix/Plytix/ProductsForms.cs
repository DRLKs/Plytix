using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plytix
{
    public partial class ProductsForms : Form
    {
        private grupo11DBEntities conexion;
        private string imagePath;
        private GestionProductosForms formsQueLoLlama;
        private readonly String sku = null;
        public ProductsForms(String sku, GestionProductosForms formsQueLoLlama )
        {
            InitializeComponent();
            btnCerrar_Paint();
            this.FormBorderStyle = FormBorderStyle.None;  // Elimina los bordes
            this.MaximizeBox = false;  // Evita que el formulario pueda maximizarse
            this.MinimizeBox = false;  // Evita que el formulario pueda minimizarse
            this.formsQueLoLlama = formsQueLoLlama;
            conexion = new grupo11DBEntities();
            if (sku != null)
            {
                this.sku = sku;
                PrepararEditor();
            }
            
            imagePath = null;
        }
        /*
         *  Actualiza los textBoxes para que carguen los datos del elemento a editar
         */
        private void PrepararEditor()
        {
            PRODUCTO p = (from producto in conexion.PRODUCTO
                          where producto.SKU == sku
                          select producto).FirstOrDefault(); textBoxSKU.Text = sku.ToString();
            
            if(p.GTIN != null) textBoxGTIN.Text = p.GTIN.ToString();
            textBoxNombre.Text = p.NOMBRE.ToString();
            textBoxSKU.Text = p.SKU.ToString();
            
            var thumbnail = p.THUMBNAIL != null
                        ? ConvertirBlobAImagen(p.THUMBNAIL)
                        : Image.FromFile(@"C:\Users\David\Documents\GIT\Plytix\Plytix\Plytix\Resources\sinImagen.jpg");
            pictureBox.Image = thumbnail;
        }

        private void SaveClick(object sender, EventArgs e)
        {
            if (textBoxSKU.Text.Length > 0 && textBoxNombre.Text.Length > 0)
            {

                PRODUCTO p = new PRODUCTO();
                p.SKU = textBoxSKU.Text;
                if (textBoxGTIN.Text.Length > 0) p.GTIN = textBoxGTIN.Text; 
                else p.GTIN = null;

                p.NOMBRE = textBoxNombre.Text;
                if (imagePath == null) p.THUMBNAIL = null;
                else p.THUMBNAIL = ConvertirImagenABlob(imagePath);

                p.CATEGORIAID = null;

                try
                {
                    conexion.PRODUCTO.AddOrUpdate(p);
                    if( sku != null)   // Estamos ante un update
                    {
                        if (textBoxGTIN.TextLength == 0) p.GTIN = null;
                    }
                    conexion.SaveChanges();
                    this.Hide();
                    formsQueLoLlama.CargarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                
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
        public Image ConvertirBlobAImagen(byte[] blob)
        {
            using (MemoryStream ms = new MemoryStream(blob))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
