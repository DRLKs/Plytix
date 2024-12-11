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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.FormClosing += MainForm_FormClosing;   // Para cerrar el programa no solo el FORMS
        }

        private void productosButton_Click(object sender, EventArgs e)
        {   
            panelMain.Controls.Clear();
            ProductosListarForm form = new ProductosListarForm();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Add(form);
            form.Show();
        }

        private void categoriasButton_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            CategoriasListarForm form = new CategoriasListarForm();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Add(form);
            form.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ProductosRelacionados_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            ProductosRelacionadosListar form = new ProductosRelacionadosListar();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Add(form);
            form.Show();
        }

        private void Atributos_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            AtributosListarForm form = new AtributosListarForm();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Add(form);
            form.Show();
        }

        private void Account_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            CuentaForm form = new CuentaForm();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Add(form);
            form.Show();
        }

        private void RelatedProducts_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            ProductosRelacionadosListar form = new ProductosRelacionadosListar();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Add(form);
            form.Show();
        }
    }
}

/* COSAS QUE FALTAN POR IMPLEMENTAR:
    
        FALLO al insertar categoria. Mirar si he copiado algo del modificar categoría que aquí no haga falta
        El thumbnail tiene que ser obligatorio (añadir imagen a todos los productos y cambiar la base de datos)
        Añadir descripciones corta y larga para cada producto y apartado para poder visualizar el producto con dichas descripciones
        
        Rodear todas las funciones con try catch para controlar errores
        Hacer funcion que compruebe la validez del SKU (implementar en añadir / editar producto)
        Que aparezca la imagen nueva cuando la seleccione de los archivos y se actualice al darle al boton de update (añadir / editar producto)
        Hacer que se modifiquen las categorias del producto (dentro del boton de guardar en añadir / editar producto)
        Añadir codigo atributos como un CheckedListBox (añadir / editar producto)
        Añadir codigo CheckedListBox de productos relacionados (añadir / editar producto)
        Cambiar base de datos para que un producto pueda tener mas de una categoria
        Añadir columna a la lista de productos que muestre los 3 primeros atributos de su lista
*/