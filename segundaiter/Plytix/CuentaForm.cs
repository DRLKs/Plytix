using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Plytix
{
    public partial class CuentaForm : Form
    {
        grupo11DBEntities bd;

        public CuentaForm()
        {
            InitializeComponent();
            bd = new grupo11DBEntities();
            CargarLabels();
        }

        public void CargarLabels()
        {
            int numProductos = bd.PRODUCTO.Count();
            numeroProductos.Text = "Number of Products = " + numProductos;

            int numCategories = bd.CATEGORIA.Count();
            numeroCategorias.Text = "Number of Categories = " + numCategories;

            int numAtributes = bd.ATRIBUTO.Count();
            numeroAtributos.Text = "Number of Atributtes = " + numAtributes;

            numeroAssets.Text = "Number os Assets = 0";
        }

        private void CrearCSVClick(object sender, EventArgs e)
        {

        }

        private void CrearJSONClick(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Guardar archivo JSON";
                saveFileDialog.Filter = "Archivos JSON (*.json)|*.json";
                saveFileDialog.FileName = "productos.json"; // Nombre predeterminado del archivo

                // Mostrar el diálogo al usuario
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obtener la ruta completa seleccionada por el usuario
                    string rutaCompleta = saveFileDialog.FileName;

                    // Mostrar la ruta seleccionada
                    Console.WriteLine($"Ruta completa seleccionada: {rutaCompleta}");
                    string contenidoJson = EscribirJSON();
                    File.WriteAllText(rutaCompleta, contenidoJson);

                    Console.WriteLine("Archivo JSON guardado correctamente.");
                }
                else
                {
                    Console.WriteLine("No se seleccionó un archivo.");
                }
            }
        }

        private string EscribirJSON()
        {
            var jsonBuilder = new StringBuilder();

            /*     PRODUCTOS     */
            jsonBuilder.Append("[\n");
            List<PRODUCTO> productos = bd.PRODUCTO.ToList();
            for ( int idx = 0; idx < productos.Count; ++idx)
            {
                jsonBuilder.Append("\t{\n");
                jsonBuilder.Append("\t\t\"ID\" : "+ productos[idx].ID + ",\n");
                jsonBuilder.Append("\t\t\"NAME\" : \"" + productos[idx].NOMBRE + "\",\n" );
                jsonBuilder.Append("\t\t\"CREATION_DATE\" : \"" + productos[idx].FECHA_CREACION + "\",\n");
                jsonBuilder.Append("\t\t\"EDITION_DATE\" : \"" + productos[idx].FECHA_EDICION + "\"\n");
                
                //jsonBuilder.Append("\t\t\"CATEGORIES\" : \"" + productos[idx].CATEGORIA.ToString() + "\"\n");


                jsonBuilder.Append("\t}");
                if (idx < productos.Count - 1)
                {
                    jsonBuilder.Append(",");
                }
                jsonBuilder.Append("\n");
            }
            jsonBuilder.Append("]\n");

            /*     CATEGORIAS     */
            jsonBuilder.Append("[\n");
            List<CATEGORIA> categorias = bd.CATEGORIA.ToList();
            for ( int idx = 0; idx < categorias.Count; ++idx)
            {
                jsonBuilder.Append("\t{\n");
                jsonBuilder.Append("\t\t\"ID\" : " + categorias[idx].ID + ",\n");
                jsonBuilder.Append("\t\t\"NAME\" : \"" + categorias[idx].NOMBRE + "\",\n");

                //jsonBuilder.Append("\t\t\"CATEGORIES\" : \"" + productos[idx].CATEGORIA.ToString() + "\"\n");


                jsonBuilder.Append("\t}");
                if (idx < categorias.Count - 1)
                {
                    jsonBuilder.Append(",");
                }
                jsonBuilder.Append("\n");

            }
            jsonBuilder.Append("]\n");

            /*     ATRIBUTOS     */
            jsonBuilder.Append("[\n");
            List<ATRIBUTO> atributos = bd.ATRIBUTO.ToList();
            for (int idx = 0; idx < atributos.Count; ++idx)
            {
                jsonBuilder.Append("\t{\n");
                jsonBuilder.Append("\t\t\"ID\" : " + atributos[idx].ID + ",\n");
                jsonBuilder.Append("\t\t\"NAME\" : \"" + atributos[idx].NOMBRE + "\",\n");

                jsonBuilder.Append("\t}");
                if (idx < atributos.Count - 1)
                {
                    jsonBuilder.Append(",");
                }
            }
            jsonBuilder.Append("]\n");

            return jsonBuilder.ToString();
        }
    }
}
