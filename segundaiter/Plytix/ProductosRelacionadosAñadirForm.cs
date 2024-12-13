﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plytix
{
    public partial class ProductosRelacionadosAñadirForm : Form
    {
        grupo11DBEntities db;

        public ProductosRelacionadosAñadirForm()
        {
            InitializeComponent();
            db = new grupo11DBEntities();
            CargarProductos();
        }

        private void CargarProductos()
        {
            listBoxProductos.DataSource = db.PRODUCTO.ToList();

            listBoxProductos.SelectedItem = null;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                ComprobarDatos();
                PRODRELACIONADOS nuevoProductoRelacionado = new PRODRELACIONADOS();
                nuevoProductoRelacionado.NAME = textBoxName.Text;
                foreach( PRODUCTO producto in listBoxProductos.SelectedItems)
                {
                    nuevoProductoRelacionado.PRODUCTO.Add(producto);
                }

                db.PRODRELACIONADOS.Add(nuevoProductoRelacionado);
                db.SaveChanges();
                if (this.Owner is ProductosRelacionadosListar parentForm) parentForm.CargarProductosRelacionados(); // Para recargar los datos del grid en la ventana abierta         
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ComprobarDatos()
        {
            if( textBoxName.Text == "" || textBoxName.Text == null)
            {
                throw new Exception("You must fill out the name section");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}