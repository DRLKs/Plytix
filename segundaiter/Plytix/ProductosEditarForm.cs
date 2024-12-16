using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Asn1.Cms;

namespace Plytix
{   
    public partial class ProductosEditarForm : Form
    {
        grupo11DBEntities bd = new grupo11DBEntities();
        private string sku;

        /* ATRIBUTOS PARA MANEJAR LA INSERCIÓN DE LOS ATRIBUTOS */
        ATRIBUTO atributoSeleccionado;
        Dictionary<ATRIBUTO, string> atributos;
        int indiceMap;
        public ProductosEditarForm(String sku)
        {
            InitializeComponent();
            atributoSeleccionado = null;
            atributos = new Dictionary<ATRIBUTO, string>();
            indiceMap = -1;
            this.sku = sku;
        }
        private void ProductosEditarForm_Load(object sender, EventArgs e)
        {
            var seleccionado = (from p in bd.PRODUCTO
                                where p.SKU == sku
                                select p).First();
            /* TEXT BOXES */
            textBoxNombre.Text = seleccionado.NOMBRE;
            textBoxSKU.Text = seleccionado.SKU;
            textBoxGTIN.Text = seleccionado.GTIN;

            /* ATRIBUTOS INTERFACES*/
            LabelNombreAtributo.Hide();
            TextBoxAtributtesRellenar.Hide();

            /* IMAGENES */
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

            /* CATEGORIAS */
            List<CATEGORIA> categoriasProducto = seleccionado.CATEGORIA.ToList();
            if( categoriasProducto.Count > 0 ) categoriaListBox.DataSource = bd.CATEGORIA.ToList();

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

            /* ATRIBUTOS */
            foreach (PRODUCTO_ATRIBUTO atr in seleccionado.PRODUCTO_ATRIBUTO)
            {
                atributos.Add(atr.ATRIBUTO, atr.valor);
            }
            
            atributosListBox.DataSource = bd.ATRIBUTO.ToList();
            atributosListBox.ClearSelected();
            
            for (int i = 0; i < atributosListBox.Items.Count; i++)
            {
                if (atributos.Keys.Contains(atributosListBox.Items[i]))
                {
                    atributosListBox.SetItemChecked(i, true);
                }
            }
        }
            

        // BOTÓN DE GUARDAR
        private void buttonSave_Click(object sender, EventArgs e)
        {   
            var productoSeleccionado = (from p in bd.PRODUCTO
                                where p.SKU == sku
                                select p).FirstOrDefault();
             
            productoSeleccionado.NOMBRE = textBoxNombre.Text;
            productoSeleccionado.SKU = textBoxSKU.Text; 
            productoSeleccionado.GTIN = textBoxGTIN.Text;
            productoSeleccionado.FECHA_EDICION = DateTime.Now;

            /* Limpiamos las relaciones entre categorias y productos */
            productoSeleccionado.CATEGORIA.Clear();
            foreach( CATEGORIA categoria in categoriaListBox.Items)
            {
                categoria.PRODUCTO.Remove(productoSeleccionado);
            }

            /* Añadimos las relaciones entre categorías y productos seleccionados */
            foreach( CATEGORIA categoria in categoriaListBox.SelectedItems) /* FUNCIONA MAL */
            {
                Console.WriteLine(categoria.NOMBRE);    /* DEPURACIÓN */
                productoSeleccionado.CATEGORIA.Add(categoria);
                categoria.PRODUCTO.Add(productoSeleccionado);
            }

            productoSeleccionado.PRODUCTO_ATRIBUTO.Clear();
            /* Añadimos los atributos */
            foreach (var map in atributos)
            {
                PRODUCTO_ATRIBUTO nuevaRelacionP_A = new PRODUCTO_ATRIBUTO();
                nuevaRelacionP_A.id_atributo = map.Key.ID;
                nuevaRelacionP_A.PRODUCTO = productoSeleccionado;
                nuevaRelacionP_A.valor = map.Value;
                nuevaRelacionP_A.ATRIBUTO = map.Key;
                productoSeleccionado.PRODUCTO_ATRIBUTO.Add(nuevaRelacionP_A);
            }

            bd.PRODUCTO.AddOrUpdate(productoSeleccionado);
            try
            {
                bd.SaveChanges();
            }
            catch( Exception)
            {
                    MessageBox.Show("You haven't made any changes");
            }
            if (this.Owner is ProductosListarForm parentForm) parentForm.ProductosListarForm_Load(null, null); // NO FUNCIONA - Para recargar los datos del grid en la ventana abierta         
            Close();
        }

        /* FUNCIONES PARA EL MANEJO DE LOS ATRIBUTOS */
        private void AtributoSeleccionado(object sender, ItemCheckEventArgs e)
        {
            indiceMap = e.Index;
            atributoSeleccionado = (ATRIBUTO)atributosListBox.Items[indiceMap];

            if (!atributosListBox.GetItemChecked(indiceMap))  /* No está con el tick*/
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
                    if (atributoSeleccionado == null)   /* Esto es porque no se esconde a veces*/
                    {
                        TextBoxAtributtesRellenar.Hide();
                        return;
                    }

                    if (atributoSeleccionado.TIPO == "Decimal" && !double.TryParse(TextBoxAtributtesRellenar.Text, out _))
                    {
                        throw new Exception("You must select a number");
                    }
                    else if (atributoSeleccionado.TIPO == "Integer" && !int.TryParse(TextBoxAtributtesRellenar.Text, out _))
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
