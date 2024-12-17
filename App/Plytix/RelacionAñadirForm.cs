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
    public partial class RelacionAñadirForm : Form
    {
        grupo11DBEntities bd = new grupo11DBEntities();
        public RelacionAñadirForm()
        {
            InitializeComponent();
        }

        private void RelacionAñadirForm_Load(object sender, EventArgs e)
        {
            listBoxIzq.DataSource = bd.PRODUCTO.ToList();
            listBoxDer.DataSource = bd.PRODUCTO.ToList();

            listBoxIzq.ClearSelected();
            listBoxDer.ClearSelected();    

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                RELACION rel = new RELACION();
                if (textBoxName.Text == "")
                {
                    throw new Exception("Name can't be empty");
                }
                rel.Nombre = textBoxName.Text;
                var prodIzq = listBoxIzq.SelectedItem as PRODUCTO;
                var prodDer = listBoxDer.SelectedItem as PRODUCTO;
                if (prodIzq != null && prodDer != null)
                {
                    if (prodIzq == prodDer)
                    {
                        throw new Exception("You must select different products");
                    }
                    rel.ProductoIzq = prodIzq.ID;
                    rel.ProductoDer = prodDer.ID;
                    
                }
                else if ((prodIzq == null && prodDer != null) || (prodIzq != null && prodDer == null))
                {
                    throw new Exception("You must select a product from both columns");
                }                

                bd.RELACION.Add(rel);
                bd.SaveChanges();
                if (this.Owner is RelacionListarForm parentForm) parentForm.RelacionListarForm_Load(null,null);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
