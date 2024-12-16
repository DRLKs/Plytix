using Org.BouncyCastle.Asn1.Cms;
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

        /* ATRIBUTOS PARA MANEJAR LA INSERCIÓN DE LOS ATRIBUTOS */
        ATRIBUTO atributoSeleccionado;
        Dictionary<ATRIBUTO , string > atributos;
        int indiceMap;

        public ProductosAñadirForm()
        {
            InitializeComponent();
            bd = new grupo11DBEntities();
            atributoSeleccionado = null;
            atributos = new Dictionary<ATRIBUTO, string> ();
            indiceMap = -1;
            CargarFormulario();
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            try
            {
                ValidarGuardadoProducto();  // Comprueba que todos los datos sean correctos

                /* INTERFACES PARA LOS ATRIBUTOS */
                LabelNombreAtributo.Hide();
                TextBoxAtributtesRellenar.Hide();

                PRODUCTO productoNuevo = new PRODUCTO();
                /* OBLIGATORIOS */
                productoNuevo.NOMBRE = textBoxNombre.Text;
                productoNuevo.SKU = textBoxSKU.Text;
                productoNuevo.THUMBNAIL = ConvertirImagenABlob(imagePath);
                productoNuevo.FECHA_CREACION = DateTime.Now;
                productoNuevo.FECHA_EDICION  = DateTime.Now;
                productoNuevo.GTIN = textBoxGTIN.Text;

                /* OPCIONALES */
                /* Añadimos las relaciones entre categorías y productos seleccionados*/
                foreach (CATEGORIA categoria in categoriaListBox.SelectedItems)
                {
                    productoNuevo.CATEGORIA.Add(categoria);
                    categoria.PRODUCTO.Add(productoNuevo);
                }

                /* Añadimos los atributos */
                foreach( var map in atributos)
                {
                    PRODUCTO_ATRIBUTO nuevaRelacionP_A = new PRODUCTO_ATRIBUTO();
                    nuevaRelacionP_A.id_atributo = map.Key.ID;
                    nuevaRelacionP_A.PRODUCTO = productoNuevo;
                    nuevaRelacionP_A.valor = map.Value;
                    nuevaRelacionP_A.ATRIBUTO = map.Key;
                    productoNuevo.PRODUCTO_ATRIBUTO.Add(nuevaRelacionP_A);
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

        /* FUNCIONES PARA TRBAJAR CON LOS ATRIBUTOS */
        private void AtributoSeleccionado(object sender, ItemCheckEventArgs e)
        {
            indiceMap = e.Index;
            atributoSeleccionado = (ATRIBUTO)atributosListBox.Items[indiceMap];

            if ( !atributosListBox.GetItemChecked(indiceMap) )  /* No está con el tick*/
            {
                LabelNombreAtributo.Text = atributoSeleccionado.NOMBRE;
                LabelNombreAtributo.Show();
                TextBoxAtributtesRellenar.Show();
                TextBoxAtributtesRellenar.Text = "";
            }
            else
            {
                atributos.Remove(atributoSeleccionado);
                LabelNombreAtributo.Text = "";
                LabelNombreAtributo.Hide();
                TextBoxAtributtesRellenar.Hide();
            }
        }

        private void PresionaTecla(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Detectar si se presionó Enter
            {
                e.SuppressKeyPress = true; // Opcional: evita el "beep" del sistema
                try
                {
                    if( atributoSeleccionado == null)   /* Esto es porque no se esconde a veces*/
                    {
                        TextBoxAtributtesRellenar.Hide();
                        return;
                    }

                    if( atributoSeleccionado.TIPO == "Decimal" && !double.TryParse(TextBoxAtributtesRellenar.Text, out _))
                    {
                        throw new Exception("You must select a number");
                    }
                    else if(atributoSeleccionado.TIPO == "Integer" && !int.TryParse(TextBoxAtributtesRellenar.Text, out _))
                    {

                        throw new Exception("You must select a number"); 
                        
                    }
                    atributosListBox.SetItemChecked(indiceMap, true);
                    indiceMap = -1;
                    atributos.Add(atributoSeleccionado, TextBoxAtributtesRellenar.Text);
                    LabelNombreAtributo.Hide();
                    TextBoxAtributtesRellenar.Hide();
                    TextBoxAtributtesRellenar.Text = "";
                    MessageBox.Show("Attribute Saved");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
