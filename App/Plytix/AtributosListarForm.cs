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
    public partial class AtributosListarForm : Form
    {
        grupo11DBEntities bd;
        public AtributosListarForm()
        {
            InitializeComponent();
            bd = new grupo11DBEntities();
            AtributosListarForm_Load();
        }

        public void AtributosListarForm_Load()
        {
            // Deja vacío el Grid view 
            AtributosGridView.DataSource = null;
            AtributosGridView.Columns.Clear();

            // Cargo las columnas de las categorías con los campos necesarios
            var seleccion = from c in bd.ATRIBUTO
                            select new
                            {
                                NAME = c.NOMBRE,
                            };
            AtributosGridView.DataSource = seleccion.ToList();
            AtributosGridView.ClearSelection();

            // Oculto el botón de añadir categoría si ya hay 3 creadas
            if (seleccion.Count() >= 5)
            {
                addLabel.Hide();
                buttonAddLabel.Hide();
            }
            else
            {
                addLabel.Show();
                buttonAddLabel.Show();
            }

            // Añado las columnas con los botones de editar y eliminar
            AtributosGridView.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "EDIT",
                Text = "✏️",
                UseColumnTextForButtonValue = true
            });

            AtributosGridView.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "DELETE",
                Text = "🗑️",
                UseColumnTextForButtonValue = true

            });
        }

        private void AddAtributoClick(object sender, EventArgs e)
        {
            AtributosAñadirForm productosAddForm = new AtributosAñadirForm();
            productosAddForm.Owner = this;
            productosAddForm.ShowDialog();
        }

       private void AtributosGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string columnName = AtributosGridView.Columns[e.ColumnIndex].Name; // Columna desde la que ocurrió el click
                String nombre = AtributosGridView.Rows[e.RowIndex].Cells["NAME"].Value.ToString();
                ATRIBUTO atributo = (from a in bd.ATRIBUTO
                                     where a.NOMBRE == nombre
                                     select a).FirstOrDefault();

                if (columnName == "Edit") // Columna Editar
                {
                    AtributosEditarForm form = new AtributosEditarForm(atributo.ID);
                    form.Owner = this;
                    form.ShowDialog();
                }
                
                if (columnName == "Delete") // Columna Eliminar
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this attribute?",
                                                          "Confirmation", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        bd.ATRIBUTO.Remove(atributo);
                        bd.SaveChanges();
                        AtributosGridView.ClearSelection();
                        AtributosListarForm_Load();                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);

            }
         
        }
       
    }
}
