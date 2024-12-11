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
    public partial class ProductosRelacionadosListar : Form
    {
        grupo11DBEntities db;
        public ProductosRelacionadosListar()
        {
            InitializeComponent();
            db = new grupo11DBEntities();
            CargarProductosRelacionados();
        }

        public void CargarProductosRelacionados()
        {
            // Deja vacío el Grid view 
            ProductosRelaciondosdataGridView.DataSource = null;
            ProductosRelaciondosdataGridView.Columns.Clear();
            ProductosRelaciondosdataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            ProductosRelaciondosdataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Cargo las columnas de las categorías con los campos necesarios
            var seleccion = from PR in db.PRODRELACIONADOS
                            select new
                            {
                                NAME = PR.NAME
                            };
            ProductosRelaciondosdataGridView.DataSource = seleccion.ToList();
            ProductosRelaciondosdataGridView.ClearSelection();

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
            ProductosRelaciondosdataGridView.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "EDIT",
                Text = "✏️",
                UseColumnTextForButtonValue = true
            });

            ProductosRelaciondosdataGridView.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "DELETE",
                Text = "🗑️",
                UseColumnTextForButtonValue = true

            });
        }

        private void AddRelatedProduct_Click(object sender, EventArgs e)
        {
            ProductosRelacionadosAñadirForm categoriaEditarForm = new ProductosRelacionadosAñadirForm();
            categoriaEditarForm.Owner = this;
            categoriaEditarForm.ShowDialog();
        }
    }
}
