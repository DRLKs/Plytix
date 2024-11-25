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
            this.FormClosing += MainForm_FormClosing;   // Para cerrar el programa no solo el FORMS
            GridViewAtributos.AllowUserToAddRows = false;
            CargarAtributos();
        }

        public void CargarAtributos()
        {
            GridViewAtributos.DataSource = null;

            GridViewAtributos.Columns.Clear(); // Asegúrate de que no haya columnas duplicadas
            GridViewAtributos.Rows.Clear();    // Limpia filas anteriores, si las hubiera

            if (sku != null)    /* Estaría especificado el producto */
            {
                listaAtributos = (from atributo in conexion.ATRIBUTO
                                  where atributo.PRODUCTOID == this.sku
                                  select atributo).ToList();
            }
            else                /* Todos los productos */
            {
                listaAtributos = (from atributo in conexion.ATRIBUTO select atributo).ToList();
            }

            if (this.sku != null) RemainingAtributesLabel.Text = "Remaining available attributes: " + (5 - listaAtributos.Count);  /* En los generales no sale */
            else RemainingAtributesLabel.Hide();

            if (listaAtributos.Count >= 5 && this.sku != null)  /* No permitimos añadir más productos */
            {
                AddAtributoBotton.Hide();
                AddAttributesLabel.Hide();
            }
            else AddAtributoBotton.Show();

            // Configura columnas
            GridViewAtributos.Columns.Add("ID", "ID");
            GridViewAtributos.Columns.Add("NOMBRE", "NAME");
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
                    case "ARCHIVO":
                        Image img = ConvertirBlobAImagen( a.ARCHIVO );
                        GridViewAtributos.Rows.Add(a.ID, a.NOMBRE, a.TIPO, img);
                        break;

                    case "STRING":
                        GridViewAtributos.Rows.Add(a.ID, a.NOMBRE, a.TIPO, a.STRING);
                        break;

                    case "FLOAT":
                        GridViewAtributos.Rows.Add(a.ID, a.NOMBRE, a.TIPO, a.FLOAT.ToString());
                        break;

                    case "INT":
                        GridViewAtributos.Rows.Add(a.ID, a.NOMBRE, a.TIPO, a.INT.ToString());
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

            int id = (int) GridViewAtributos.Rows[e.RowIndex].Cells["ID"].Value;

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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cierra toda la aplicación
            Application.Exit();
        }

    }
}
