using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class GestionProductosForm : Form
    {
        public GestionProductosForm()
        {
            InitializeComponent();
        }

        private void volverClick(object sender, EventArgs e)
        {
            var main = new MainForm();
            main.Show();
            this.Close();
        }
    }
}
