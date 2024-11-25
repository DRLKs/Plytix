using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation; // Importar para capturar errores de validación
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static Devart.Common.Utils;

namespace Plytix
{
    public partial class AtributteAddForm : Form
    {
        private string sku;
        private string imagePath;
        private int id;
        private grupo11DBEntities conexion;
        private GestionAtributosForm padreForm;

        public AtributteAddForm(string sku, int id, GestionAtributosForm padre)
        {
            InitializeComponent();
            TipoBoxCargar();
            imagePath = null;
            pictureBox.Hide();
            BotonSubir.Hide();
            label3.Hide();
            descriptionText.Hide();
            // Establecer el filtro para mostrar solo archivos de imagen

            this.sku = sku;
            this.id = id;
            if ( id >= 0)
            {
                CargarEditor();
            }
            padreForm = padre;
            conexion = new grupo11DBEntities();
        }

        private void TipoBoxCargar()
        {
            // Configuración del ComboBox para autocompletar.
            comboBoxTipo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxTipo.AutoCompleteSource = AutoCompleteSource.ListItems;

            // Lista de tipos permitidos.
            List<string> tipos = new List<string> { "IMAGE", "DESCRIPTION", "PRICE" };
            foreach (string tipo in tipos)
            {
                comboBoxTipo.Items.Add(tipo);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Crear o actualizar el objeto ATRIBUTO.
                ATRIBUTO a;
                if (id >= 0) // Actualizar un atributo existente.
                {
                    a = (from atributo in conexion.ATRIBUTO
                         where atributo.ID == id
                         select atributo).FirstOrDefault();

                    if (a == null)
                    {
                        throw new Exception("The attribute could not be found for updating.");
                    }
                }
                else // Crear un nuevo atributo.
                {
                    a = new ATRIBUTO();
                    
                    if (sku != null)
                    {
                        a.PRODUCTOID = sku;
                        a.PRODUCTO = conexion.PRODUCTO.FirstOrDefault(producto => producto.SKU == sku);
                    }
                    else
                    {
                        a.PRODUCTOID = null;
                        a.PRODUCTO = null;
                    }
                }

                // Validar y asignar los datos del atributo.
                string tipoSeleccionado = comboBoxTipo.Text;
                
                if (string.IsNullOrEmpty(tipoSeleccionado))
                {
                    throw new Exception("You must choose the type of attribute.");
                }
                a.TIPO = tipoSeleccionado;
                
                if (string.IsNullOrEmpty(ResumeText.Text))
                {
                    throw new Exception("The resume field cannot be empty.");
                }
                a.Resumen = ResumeText.Text;

                if (!new[] { "IMAGE", "DESCRIPTION", "PRICE" }.Contains(tipoSeleccionado))
                {
                    throw new Exception("Tipo de atributo no válido.");
                }

                switch (tipoSeleccionado)
                {
                    case "IMAGE":
                        if (string.IsNullOrEmpty(imagePath))
                        {
                            throw new Exception("Image Path null.");
                        }
                        a.IMAGEN = ConvertirImagenABlob(imagePath);
                        break;
                    case "DESCRIPTION":
                        if (string.IsNullOrEmpty(descriptionText.Text))
                        {
                            throw new Exception("Description is null");
                        }
                        a.DESCRIPCION = descriptionText.Text;
                        break;
                    case "PRICE":
                        if (!float.TryParse(descriptionText.Text, out float precio))
                        {
                            throw new Exception("Invalid price format. Please enter a valid number.");
                        }
                        a.PRECIO = precio;
                        break;
                    default:
                        throw new Exception("Unknown attribute type.");
                }

                // Guardar los cambios en la base de datos.

                conexion.ATRIBUTO.AddOrUpdate(a);
                System.Console.WriteLine(a.ID +  a.TIPO + a.DESCRIPCION + a.Resumen);
                conexion.SaveChanges();
                MessageBox.Show("Attribute saved successfully.");
                padreForm.CargarAtributos();
                this.Close(); // Cerrar la ventana al guardar.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CargarEditor()
        {
            ATRIBUTO a = (from atributo in conexion.ATRIBUTO where atributo.ID == id select atributo ).FirstOrDefault();

            ResumeText.Text = a.Resumen;

            string tipoSeleccionado = a.TIPO;
            switch (tipoSeleccionado)
            {
                case "IMAGE":
                    comboBoxTipo.SelectedIndex = 0;
                    /* Añadir cosas */
                    break;
                case "DESCRIPTION":
                    comboBoxTipo.SelectedIndex = 1;

                    descriptionText.Text = a.DESCRIPCION;
                    break;
                case "PRICE":
                    comboBoxTipo.SelectedIndex = 2;
                    descriptionText.Text = a.PRECIO.ToString();
                    break;
                default:
                    throw new Exception("Unknown attribute type.");
            }
        }

        private void SubirImagen_Click(object sender, EventArgs e)
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

        private void CambiaSeleccionTipo(object sender, EventArgs e)
        {
            string tipoSeleccionado = comboBoxTipo.Text;
            switch (tipoSeleccionado)
            {
                case "IMAGE":
                    pictureBox.Show();
                    BotonSubir.Show();
                    label3.Hide();
                    descriptionText.Hide();
                    break;
                case "DESCRIPTION":
                    pictureBox.Hide();
                    BotonSubir.Hide();
                    label3.Show();
                    descriptionText.Show();
                    break;
                case "PRICE":
                    pictureBox.Hide();
                    BotonSubir.Hide();
                    label3.Show();
                    descriptionText.Show();
                    break;
                default:
                    throw new Exception("Unknown attribute type.");
            }
        }
    }
}
