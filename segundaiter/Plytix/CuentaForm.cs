using System;
using System.Collections.Generic;
using System.Drawing;
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
            CargarProfilePic();
        }

        public void CargarLabels()
        {
            CUENTA cuenta = bd.CUENTA.First(p => p.ID == 0);
            NombreCuentaLabel.Text = cuenta.nombre;

            int numProductos = bd.PRODUCTO.Count();
            numeroProductos.Text = "Number of Products = " + numProductos;

            int numCategories = bd.CATEGORIA.Count();
            numeroCategorias.Text = "Number of Categories = " + numCategories;

            int numAtributes = bd.ATRIBUTO.Count();
            numeroAtributos.Text = "Number of Atributtes = " + numAtributes;

        }

        private void CargarProfilePic()
        {
            pictureBox1.Image = Image.FromFile(@"..\..\Resources\ProfilePIC.png");
        }

        private void CrearCSVClick(object sender, EventArgs e)
        {
            CuentaConfigurarCSVForm form = new CuentaConfigurarCSVForm();
            form.Owner = this;
            form.ShowDialog();
        }

        public void ElegirDirectorioCSV(CATEGORIA categoria)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Save CSV file";
                saveFileDialog.Filter = "Archivos CSV (*.csv)|*.csv";
                saveFileDialog.FileName = "accountProducts.csv"; // Nombre predeterminado del archivo

                // Mostrar el diálogo al usuario
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obtener la ruta completa seleccionada por el usuario
                    string rutaCompleta = saveFileDialog.FileName;

                    // Mostrar la ruta seleccionada
                    Console.WriteLine($"Ruta completa seleccionada: {rutaCompleta}");
                    try
                    {
                        string contenidoCSV = EscribirCSV(categoria);
                        File.WriteAllText(rutaCompleta, contenidoCSV);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    

                    Console.WriteLine("Archivo CSV guardado correctamente.");
                }
                else
                {
                    Console.WriteLine("No se seleccionó un archivo.");
                }
            }
        }

        private string EscribirCSV(CATEGORIA cateegoria)
        {   
            /* PRIMERA FILA DONDE MOSTRAMOS LOS DATOS DEL CSV */
            var csvBuilder = new StringBuilder();

            /* COMPROBAMOS QUE HAYA ATRIBUTOS PARA EL PRECIO EN EL SISTEMA */
            bool hayAlgunNumero = false;
            ATRIBUTO atributoPrecio = null;
            foreach( ATRIBUTO atributo in bd.ATRIBUTO.ToList())
            {
                if( !hayAlgunNumero && (atributo.TIPO == "Integer" || atributo.TIPO == "Decimal") )
                {
                    atributoPrecio = atributo;
                    hayAlgunNumero = true;
                }
            }
            if(!hayAlgunNumero)
            {
                throw new Exception("Any Atributte Price");
            }

            /* CREAMOS EL CSV */
            csvBuilder.AppendLine("SKU,Title,Fulfilled By,Amazon_SKU,Price,Offer Primer");

            var lineBuilder = new StringBuilder();
            string precio;
            /* MOSTRAMOS TODOS LOS DATOS DEL CSV*/
            foreach ( PRODUCTO producto in cateegoria.PRODUCTO )
            {            
                lineBuilder.Clear();

                lineBuilder.Append(producto.SKU + ",");         /* SKU */
                lineBuilder.Append(producto.NOMBRE + "," );     /* NOMBRE */
                lineBuilder.Append("MONSTERS INCS,");           /* NOMBRE TIENDA */
                lineBuilder.Append(producto.GTIN + ",");        /* GTIN */

                precio = (from atribProd in bd.PRODUCTO_ATRIBUTO where atribProd.id_producto == producto.ID && atribProd.id_atributo == atributoPrecio.ID select atribProd.valor).FirstOrDefault();
                
                if(precio != null)
                {
                    lineBuilder.Append(precio + ",");
                    lineBuilder.Append("false");
                    csvBuilder.AppendLine(lineBuilder.ToString());
                }
                
            }

            return csvBuilder.ToString();

        }

        private void CrearJSONClick(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Save JSON file";
                saveFileDialog.Filter = "Archivos JSON (*.json)|*.json";
                saveFileDialog.FileName = "accountInfo.json"; // Nombre predeterminado del archivo

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

            
            jsonBuilder.Append("[\n");
            List<PRODUCTO> productos = bd.PRODUCTO.ToList();
            List<CATEGORIA> categorias = bd.CATEGORIA.ToList();
            List<ATRIBUTO> atributos = bd.ATRIBUTO.ToList();
            CUENTA cuenta = bd.CUENTA.First(p => p.ID == 0);
            jsonBuilder.Append("\t{\n");
            jsonBuilder.Append("\t\t\"ACCOUNT ID\" : \"" + cuenta.ID + "\",\n");
            jsonBuilder.Append("\t\t\"ACCOUNT NAME\" : \"" + cuenta.nombre + "\",\n");
            jsonBuilder.Append("\t\t\"CREATION DATE\" : \"" + cuenta.fechaCreacion + "\",\n");
            jsonBuilder.Append("\t\t\"NUMBER OF PRODUCTS\" : " + productos.Count + ",\n");
            jsonBuilder.Append("\t\t\"NUMBER OF CATEGORIES\" : " + categorias.Count + ",\n");
            jsonBuilder.Append("\t\t\"NUMBER OF ATTRIBUTES\" : " + atributos.Count + "\n");
            jsonBuilder.Append("\t}\n");
            jsonBuilder.Append("]\n");
            return jsonBuilder.ToString();

            /*     
            
            ----------------------- HOMENAJE AL CÓDIGO ERRÓNEO DE DAVID EN HONOR A SU ESFUERZO -----------------------
            
            PRODUCTOS     
            for (int idx = 0; idx < productos.Count; ++idx)
            {
                jsonBuilder.Append("\t{\n");
                jsonBuilder.Append("\t\t\"ID\" : " + productos[idx].ID + ",\n");
                jsonBuilder.Append("\t\t\"NAME\" : \"" + productos[idx].NOMBRE + "\",\n");

                // Formatear las fechas a un formato legible (solo fecha)
                jsonBuilder.Append("\t\t\"CREATION_DATE\" : \"" + productos[idx].FECHA_CREACION.ToString("yyyy-MM-dd") + "\",\n");
                jsonBuilder.Append("\t\t\"EDITION_DATE\" : \"" + productos[idx].FECHA_EDICION.ToString("yyyy-MM-dd") + "\"\n");

                jsonBuilder.Append("\t}");
                if (idx < productos.Count - 1)
                {
                    jsonBuilder.Append(",");
                }
                jsonBuilder.Append("\n");
            }
            


            CATEGORIAS     
            
            jsonBuilder.Append("[\n");            
            for (int idx = 0; idx < categorias.Count; ++idx)
            {
                jsonBuilder.Append("\t{\n");
                jsonBuilder.Append("\t\t\"ID\" : " + categorias[idx].ID + ",\n");
                jsonBuilder.Append("\t\t\"NAME\" : \"" + categorias[idx].NOMBRE + "\"\n");

                jsonBuilder.Append("\t}");
                if (idx < categorias.Count - 1)
                {
                    jsonBuilder.Append(",");
                }
                jsonBuilder.Append("\n");
            }
            jsonBuilder.Append("]\n");
            

            ATRIBUTOS     
            
            jsonBuilder.Append("[\n");
            for (int idx = 0; idx < atributos.Count; ++idx)
            {
                jsonBuilder.Append("\t{\n");
                jsonBuilder.Append("\t\t\"ID\" : " + atributos[idx].ID + ",\n");
                jsonBuilder.Append("\t\t\"NAME\" : \"" + atributos[idx].NOMBRE + "\"\n");

                jsonBuilder.Append("\t}");
                if (idx < atributos.Count - 1)
                {
                    jsonBuilder.Append(",");
                }
                jsonBuilder.Append("\n");
            }
            jsonBuilder.Append("]\n");
            */

        }
        }
    }
