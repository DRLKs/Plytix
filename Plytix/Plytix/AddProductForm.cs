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
        public AddProductForm()
        {
            InitializeComponent();
        }

        private void SaveClick(object sender, EventArgs e)
        {
            string imagePath = Path.Combine(Application.StartupPath, "Resources", "sinImagen.jpg");
            if (textBoxSKU.Text.Length > 0 && textBoxNombre.Text.Length > 0)
            {
                PRODUCTO p = new PRODUCTO
                {
                    SKU = textBoxSKU.Text,
                    GTIN = textBoxNombre.Text,
                    NOMBRE = textBoxNombre.Text,
                    THUMBNAIL = ConvertImageToBytes(imagePath),
                    CATEGORIAID = null

                };
                this.Hide();
            }
            else
            {
                MessageBox.Show("Debes rellenar obligatoriamente los apartados de SKU y NOMBRE");
            }
        }

        private byte[] ConvertImageToBytes(string imagePath)
        {
            try
            {
                // Leer la imagen en un arreglo de bytes
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                return imageBytes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al convertir la imagen a bytes: " + ex.Message);
                return null;
            }
        }

    }
}
