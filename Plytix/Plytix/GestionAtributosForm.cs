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
        private grupo11DBEntities conexion;
        List<ATRIBUTO> listaAtributos;
        public GestionAtributosForm()
        {
            InitializeComponent();
            conexion = new grupo11DBEntities();
            GridViewAtributos.AllowUserToAddRows = false;
            listaAtributos = (from atributo in conexion.ATRIBUTO
                              select atributo).ToList();

            CargarAtributos();
        }
        public void CargarAtributos()
        {
            GridViewAtributos.Show();



             (from atributo in conexion.ATRIBUTO select atributo).ToList();
            int numeroAtributos = listaAtributos.Count;
            if (numeroAtributos > 0 && numeroAtributos <= 5)
            {
                // Configura columnas
                if (GridViewAtributos.Columns.Count == 0)
                {
                    GridViewAtributos.Columns.Add("ID", "ID");
                    GridViewAtributos.Columns.Add("TYPE", "tipo");
                    GridViewAtributos.Columns.Add("DESCRIPTION", "Descripcion");
                    GridViewAtributos.Columns.Add(new DataGridViewButtonColumn
                    {
                        Name = "Edit",
                        HeaderText = "Edit",
                        Text = "✏️",
                        UseColumnTextForButtonValue = true
                    });

                    GridViewAtributos.Columns.Add(new DataGridViewButtonColumn
                    {
                        Name = "Delete",
                        HeaderText = "Delete",
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
            else
            {
                GridViewAtributos.Hide();
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
                var addAtributeForm = new AtributteAddForm();
                addAtributeForm.Show();
            }
            
        }
    }
}
