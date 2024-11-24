﻿using Plytix.Properties;
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
            CategoriasBoxCargar();  // Cargamos el ComboBox que contiene las categorias
            CargarProductosRelacionados();  // Cargamos los Nombres de los productos relacionados
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
                        : Image.FromFile(@"..\..\Resources\sinImagen.jpg");
            pictureBox.Image = thumbnail;

            if (p.CATEGORIAID != null)
            {
                CategoriasComboBox.SelectedItem = ( from categoria in conexion.CATEGORIA where categoria.ID == p.CATEGORIAID select categoria.NOMBRE ).FirstOrDefault();
            }

            if (p.PRODUCTO2.Count() > 0)
            {
                
            }
        }

        private void SaveClick(object sender, EventArgs e)
        {
            if (textBoxSKU.Text.Length > 0 && textBoxNombre.Text.Length > 0)
            {

                PRODUCTO p;
                if (this.sku == null)
                {
                    p = new PRODUCTO
                    {
                        SKU = textBoxSKU.Text
                    };

                }
                else
                {
                    p = (from producto in conexion.PRODUCTO where producto.SKU == this.sku select producto).FirstOrDefault();
                    if (textBoxSKU.Text != sku)
                    {
                        conexion.PRODUCTO.Remove(p);
                        p.SKU = textBoxSKU.Text;
                    }
                }

                if (textBoxGTIN.Text.Length > 0) p.GTIN = textBoxGTIN.Text; 
                else p.GTIN = null;

                p.NOMBRE = textBoxNombre.Text;
                if (imagePath == null) p.THUMBNAIL = null;
                else p.THUMBNAIL = ConvertirImagenABlob(imagePath);

                if (CategoriasComboBox.SelectedItem != null && CategoriasComboBox.SelectedItem.ToString() != "")
                {
                    string categoriaNombre = CategoriasComboBox.SelectedItem.ToString();
                    p.CATEGORIAID = (from categoria in conexion.CATEGORIA where categoria.NOMBRE == categoriaNombre select categoria.ID).FirstOrDefault();
                }
                else
                {
                    p.CATEGORIAID = null;
                }

                /* Productos Relacionados */
                var seleccionadas = new List<string>();
                PRODUCTO pAux;
                p.PRODUCTO1.Add(p);
                foreach (String item in ProductosRelacionadoscheckedListBox.CheckedItems)
                {
                    seleccionadas.Add(item.ToString());
                    pAux = (from producto in conexion.PRODUCTO where producto.NOMBRE == item select producto).FirstOrDefault();
                    p.PRODUCTO2.Add(pAux);
                }
                /* Fin de Productos Relacionados */
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
        private Image ConvertirBlobAImagen(byte[] blob)
        {
            using (MemoryStream ms = new MemoryStream(blob))
            {
                return Image.FromStream(ms);
            }
        }

        private void CategoriasBoxCargar()
        {
            CategoriasComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend; // Sugerir opciones mientras se escribe
            CategoriasComboBox.AutoCompleteSource = AutoCompleteSource.ListItems; // Usar la lista de ítems como fuente de autocompletado
            
            List<CATEGORIA> categorias = (from categoria in conexion.CATEGORIA select categoria ).ToList();
            // Llenar el ComboBox con una lista de ejemplo
            foreach ( CATEGORIA c in categorias )
            {
                CategoriasComboBox.Items.Add( c.NOMBRE );
            }
        }

        private void CargarProductosRelacionados()
        {
            ProductosRelacionadoscheckedListBox.Items.Clear();
            ProductosRelacionadoscheckedListBox.Dock = DockStyle.Top;
            ProductosRelacionadoscheckedListBox.CheckOnClick = true; // Esto hace que al hacer clic en un elemento se marque o desmarque

            List<String> nombresProductos = (from producto in conexion.PRODUCTO select producto.NOMBRE).ToList();

            foreach ( String nombre in nombresProductos )
            {
                ProductosRelacionadoscheckedListBox.Items.Add(nombre);
            }
        }
    }
}
