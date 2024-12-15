using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plytix
{
    public partial class RelacionEditarForm : Form
    {
        grupo11DBEntities bd = new grupo11DBEntities();
        RELACION relacion;
        public RelacionEditarForm(RELACION relacion)
        {
            InitializeComponent();
            this.relacion = relacion;
        }

        private void RelacionEditarForm_Load(object sender, EventArgs e)
        {
            listBoxIzq.DataSource = bd.PRODUCTO.ToList();
            listBoxDer.DataSource = bd.PRODUCTO.ToList();
            listBoxIzq.ClearSelected();
            listBoxDer.ClearSelected();
            textBoxName.Text = relacion.Nombre;
            if (relacion.ProductoDer != null)
            {
                var prodIzq = (from p in bd.PRODUCTO
                               where p.ID == relacion.ProductoIzq
                               select p).First();
                var prodDer = (from p in bd.PRODUCTO
                               where p.ID == relacion.ProductoDer
                               select p).First();
                listBoxIzq.SelectedItem = prodIzq;
                listBoxDer.SelectedItem = prodDer;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxName.Text == "")
                {
                    throw new Exception("Name can't be empty");
                }
                relacion.Nombre = textBoxName.Text;
                var prodIzq = listBoxIzq.SelectedItem as PRODUCTO;
                var prodDer = listBoxDer.SelectedItem as PRODUCTO;
                if (prodIzq != null && prodDer != null)
                {
                    if (prodIzq == prodDer)
                    {
                        throw new Exception("You must select different products");
                    }
                    relacion.ProductoIzq = prodIzq.ID;
                    relacion.ProductoDer = prodDer.ID;

                }
                else if ((prodIzq == null && prodDer != null) || (prodIzq != null && prodDer == null))
                {
                    throw new Exception("You must select a product from both columns");
                }
                bd.RELACION.AddOrUpdate(relacion);
                bd.SaveChanges();
                if (this.Owner is RelacionListarForm parentForm) parentForm.RelacionListarForm_Load(null, null);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
