using Org.BouncyCastle.Crypto.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Plytix
{
    public partial class GestionAtributosForm : Form
    {
        private int numeroAtributos = 0;
        private grupo11DBEntities conexion;
        List<ATRIBUTO> listaAtributos;
        private string sku;

        public GestionAtributosForm( string sku )
        {
            InitializeComponent();
            conexion = new grupo11DBEntities();
            this.sku = sku;
            CargarAtributos();
        }

        public void CargarAtributos()
        {
            if (sku != null)
            {
                listaAtributos = (from atributo in conexion.ATRIBUTO
                                  where atributo.PRODUCTOID == this.sku
                                  select atributo).ToList();
            }
            else
            {
                listaAtributos = (from atributo in conexion.ATRIBUTO
                                                   select atributo).ToList();
            }

            GridViewAtributos.DataSource = listaAtributos;

            RemainingAtributesLabel.Text = "Remaining available attributes: " + (5 - listaAtributos.Count);
            if (listaAtributos.Count >= 5)
            {
                AddAtributoBotton.Hide();
                AddAttributesLabel.Hide();
            }
            else AddAtributoBotton.Show();

            // Configura columnas
            GridViewAtributos.Columns.Add("ID", "ID");
            GridViewAtributos.Columns.Add("TIPO", "TYPE");
            GridViewAtributos.Columns.Add("Valor", "VALUE");

            GridViewAtributos.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "EDIT",
                Text = "✏️",
                UseColumnTextForButtonValue = true
            });

            GridViewAtributos.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "DELETE",
                Text = "🗑️",
                UseColumnTextForButtonValue = true
            });

            // Agregar filas
            foreach (ATRIBUTO a in listaAtributos)
            {
                switch (a.TIPO)
                {
                    case "IMAGE":
                        Image img = ConvertirBlobAImagen( a.IMAGEN );
                        GridViewAtributos.Rows.Add(a.ID, a.Resumen, a.TIPO, img);
                        break;

                    case "DESCRIPTION":
                        GridViewAtributos.Rows.Add(a.ID, a.Resumen, a.TIPO, a.DESCRIPCION);
                        break;

                    case "PRICE":
                        GridViewAtributos.Rows.Add(a.ID, a.Resumen, a.TIPO, a.PRECIO);
                        break;

                    default:
                        throw new Exception("Tipo de atributo no soportado.");
                }
            }
        }

        private void plytixLabel_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForms();
            mainForm.Show();
            this.Hide();
        }

        private void AddAtributoBotton_Click(object sender, EventArgs e)
        {
            int numAtributos = listaAtributos.Count;
            if (numAtributos < 5) {
                var addAtributeForm = new AtributteAddForm(sku,-1,this);
                addAtributeForm.Show();
                numAtributos++;
            }
            
        }
        private void AtributosGridClickar(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // Identificar la columna donde ocurrió el clic
            String resume = GridViewAtributos.Rows[e.RowIndex].Cells["Resumen"].Value.ToString();
            int id = (from atributo in conexion.ATRIBUTO where atributo.Resumen == resume select atributo.ID).FirstOrDefault();

            string columnName = GridViewAtributos.Columns[e.ColumnIndex].Name;

            if (columnName == "Edit") // Columna Editar
            {
                // Obtener datos del producto seleccionado
                EditarAtributo(id);
            }
            else if (columnName == "Delete") // Columna Eliminar
            {
                // Confirmar antes de eliminar
                DialogResult result = MessageBox.Show("Are you sure you want to delete this product?",
                                                        "Confirm deletion", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    EliminarAtributo(id);
                }
            }
        }
        private void EditarAtributo(int id)
        {
            var addAForms = new AtributteAddForm(sku,id, this);
            addAForms.Show();
        }
        private void EliminarAtributo(int id)
        {
            ATRIBUTO p = (from atributo in conexion.ATRIBUTO
                          where atributo.ID == id
                          select atributo).FirstOrDefault();

            conexion.ATRIBUTO.Remove(p);
            conexion.SaveChanges();
            CargarAtributos();
        }
        private Image ConvertirBlobAImagen(byte[] blob)
        {
            using (MemoryStream ms = new MemoryStream(blob))
            {
                return Image.FromStream(ms);
            }
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForms();
            mainForm.Show();
            this.Hide();
        }
    }
}
