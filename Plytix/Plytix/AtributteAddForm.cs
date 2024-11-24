using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Plytix
{
    public partial class AtributteAddForm : Form
    {
        private string sku;
        private int id;
        private grupo11DBEntities conexion;
        public AtributteAddForm( string sku, int id )
        {
            InitializeComponent();
            TipoBoxCargar();
            this.sku = sku;
            this.id = id;
            this.conexion = new grupo11DBEntities();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ATRIBUTO a;
            if( id > 0)
            {
                a = (from atributo in conexion.ATRIBUTO select atributo).FirstOrDefault();
            }
            else
            {   
                a = new ATRIBUTO();
                int idSig = 1 + (conexion.ATRIBUTO.Any() ? conexion.ATRIBUTO.Max(atributo => atributo.ID) : 0);
                a.ID = idSig;
                a.PRODUCTO.Add((from producto in conexion.PRODUCTO select producto).FirstOrDefault());
            }
            try
            {
                string tipoSeleccionado = comboBoxTipo.Text;
                if (tipoSeleccionado != null)
                {
                    a.TIPO_ATRIBUTO = (from t in conexion.TIPO_ATRIBUTO where t.NOMBRE == tipoSeleccionado select t).FirstOrDefault();
                }

                if( a.TIPO_ATRIBUTO == null)
                {
                    throw new Exception("You must choose the type of attribute");
                }

                if( descriptionText.Text != null && descriptionText.Text != "")
                {
                    a.DESCRIPCION = descriptionText.Text;
                }
                else
                {
                    throw new Exception("You must fill out the description section");
                }

                conexion.ATRIBUTO.Add(a);
                conexion.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            
        }

        private void TipoBoxCargar()
        {
            comboBoxTipo.AutoCompleteMode = AutoCompleteMode.SuggestAppend; // Sugerir opciones mientras se escribe
            comboBoxTipo.AutoCompleteSource = AutoCompleteSource.ListItems; // Usar la lista de ítems como fuente de autocompletado

            List<TIPO_ATRIBUTO> tipos = (from t in conexion.TIPO_ATRIBUTO select t).ToList();
            foreach (TIPO_ATRIBUTO tipo in tipos)
            {
                comboBoxTipo.Items.Add(tipo.NOMBRE);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
