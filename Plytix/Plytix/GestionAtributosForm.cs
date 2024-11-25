using Org.BouncyCastle.Crypto.Utilities;
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
            
            GridViewAtributos.AllowUserToAddRows = false;
            listaAtributos = (from atributo in conexion.ATRIBUTO
                              select atributo).ToList();
            this.sku = sku;
            CargarAtributos();
        }

        public void CargarAtributos()
        {
            GridViewAtributos.Show();
            (from atributo in conexion.ATRIBUTO select atributo).ToList();
            
            RemainingAtributesLabel.Text = "Remaining available attributes: " + (5 - numeroAtributos);
            GridViewAtributos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (numeroAtributos >= 0 && numeroAtributos < 5)
            {

                // Configura columnas
                if (GridViewAtributos.Columns.Count == 0)
                {
                    GridViewAtributos.Columns.Add("ID", "ID");
                    GridViewAtributos.Columns.Add("RESUME", "RESUME");
                    GridViewAtributos.Columns.Add("TYPE", "TYPE");
                    GridViewAtributos.Columns.Add("DESCRIPTION", "DESCRIPTION");
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
                }



                foreach (var a in listaAtributos)
                {
                    GridViewAtributos.Rows
                        .Add(a.ID, a.DESCRIPCION, a.TIPO);
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
            String resume = GridViewAtributos.Rows[e.RowIndex].Cells["RESUME"].Value.ToString();
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
    }
}
