using System;
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
    public partial class RelacionListarForm : Form
    {
        grupo11DBEntities bd = new grupo11DBEntities();
        private readonly int MAX_RELACIONES = 3;
        public RelacionListarForm()
        {
            InitializeComponent();
        }

        public void RelacionListarForm_Load(object sender, EventArgs e)
        {
            relacionesDataGridView.DataSource = null;
            relacionesDataGridView.Columns.Clear();
            var infoRelaciones = from r in bd.RELACION
                                 select new
                                 {
                                     NAME = r.Nombre,
                                     NUMBER_OF_PRODUCTS = (r.ProductoIzq != null && r.ProductoDer != null) ? 2 : 0
                                 };
            relacionesDataGridView.DataSource = infoRelaciones.ToList();

            /* PERMITIMOS O NO PERMITIMOS LA CREACIÓN DE MÁS RELACIONES */
            if( infoRelaciones.Count() >= MAX_RELACIONES)
            {
                addLabel.Hide();
                buttonAddLabel.Hide();
            }
            else
            {
                addLabel.Show();
                buttonAddLabel.Show();
            }
            relacionesDataGridView.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "EDIT",
                Text = "✏️",
                UseColumnTextForButtonValue = true
            });

            relacionesDataGridView.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "DELETE",
                Text = "🗑️",
                UseColumnTextForButtonValue = true

            });

            relacionesDataGridView.ClearSelection();
        }

        private void buttonAddLabel_Click(object sender, EventArgs e)
        {
            RelacionAñadirForm form = new RelacionAñadirForm();
            form.Owner = this;
            form.ShowDialog();
        }

        private void relacionesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string columnName = relacionesDataGridView.Columns[e.ColumnIndex].Name; // Columna desde la que ocurrió el click
                string nombreRelacion = relacionesDataGridView.Rows[e.RowIndex].Cells["NAME"].Value.ToString();
                var relacion = (from r in bd.RELACION
                               where r.Nombre.Equals(nombreRelacion)
                               select r).First();

                if (columnName == "Edit") // Columna Editar
                {
                    RelacionEditarForm relacionEditarForm = new RelacionEditarForm(relacion);
                    relacionEditarForm.Owner = this;
                    relacionEditarForm.ShowDialog();

                }
                else if (columnName == "Delete") // Columna Eliminar
                {
                    if (relacion.ProductoIzq == null && relacion.ProductoDer == null)
                    {
                        bd.RELACION.Remove(relacion);
                        bd.SaveChanges();
                        RelacionListarForm_Load(null, null);

                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to delete this category?",
                                                              "Confirmation", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            bd.RELACION.Remove(relacion);
                            bd.SaveChanges();
                            RelacionListarForm_Load(null, null);
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            
        }
    }
}
