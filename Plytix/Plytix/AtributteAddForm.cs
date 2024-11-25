using System;
using System.Collections.Generic;
using System.Data.Entity.Validation; // Importar para capturar errores de validación
using System.Linq;
using System.Windows.Forms;

namespace Plytix
{
    public partial class AtributteAddForm : Form
    {
        private string sku;
        private int id;
        private grupo11DBEntities conexion;
        private GestionAtributosForm padreForm;

        public AtributteAddForm(string sku, int id, GestionAtributosForm padre)
        {
            InitializeComponent();
            TipoBoxCargar();
            this.sku = sku;
            this.id = id;
            padreForm = padre;
            conexion = new grupo11DBEntities();

            if (id > 0) // Si se pasa un ID válido, cargar los datos existentes.
            {
                CargarDatos();
            }
        }

        private void TipoBoxCargar()
        {
            // Configuración del ComboBox para autocompletar.
            comboBoxTipo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxTipo.AutoCompleteSource = AutoCompleteSource.ListItems;

            // Lista de tipos permitidos.
            List<string> tipos = new List<string> { "IMAGE", "DESCRIPTION", "PRICE" };
            foreach (string tipo in tipos)
            {
                comboBoxTipo.Items.Add(tipo);
            }
        }

        private void CargarDatos()
        {
            try
            {
                // Buscar el atributo en la base de datos.
                ATRIBUTO a = (from atributo in conexion.ATRIBUTO
                              where atributo.ID == id
                              select atributo).FirstOrDefault();

                if (a == null)
                {
                    throw new Exception("The attribute could not be found in the database.");
                }

                // Asignar los valores del atributo a los campos de la interfaz.
                comboBoxTipo.Text = a.TIPO;

                switch (a.TIPO)
                {
                    case "IMAGE":
                        // Aquí puedes cargar la imagen si es necesario.
                        break;
                    case "DESCRIPTION":
                        descriptionText.Text = a.DESCRIPCION;
                        break;
                    case "PRICE":
                        descriptionText.Text = a.PRECIO.ToString();
                        break;
                    default:
                        throw new Exception("Unknown attribute type.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Crear o actualizar el objeto ATRIBUTO.
                ATRIBUTO a;
                if (id > 0) // Actualizar un atributo existente.
                {
                    a = (from atributo in conexion.ATRIBUTO
                         where atributo.ID == id
                         select atributo).FirstOrDefault();

                    if (a == null)
                    {
                        throw new Exception("The attribute could not be found for updating.");
                    }
                }
                else // Crear un nuevo atributo.
                {
                    a = new ATRIBUTO
                    {
                        ID = conexion.ATRIBUTO.Any() ? conexion.ATRIBUTO.Max(atributo => atributo.ID) + 1 : 1
                    };
                    if (sku != null) a.PRODUCTO = conexion.PRODUCTO.FirstOrDefault(producto => producto.SKU == sku);

                    conexion.ATRIBUTO.Add(a);
                }

                // Validar y asignar los datos del atributo.
                string tipoSeleccionado = comboBoxTipo.Text;
                if (string.IsNullOrEmpty(tipoSeleccionado))
                {
                    throw new Exception("You must choose the type of attribute.");
                }
                a.TIPO = tipoSeleccionado;

                if (string.IsNullOrEmpty(descriptionText.Text))
                {
                    throw new Exception("The description field cannot be empty.");
                }

                switch (tipoSeleccionado)
                {
                    case "IMAGE":
                        a.IMAGEN = null; // Aquí podrías cargar una imagen si fuera necesario.
                        break;
                    case "DESCRIPTION":
                        a.DESCRIPCION = descriptionText.Text;
                        break;
                    case "PRICE":
                        if (!float.TryParse(descriptionText.Text, out float precio))
                        {
                            throw new Exception("Invalid price format. Please enter a valid number.");
                        }
                        a.PRECIO = precio;
                        break;
                    default:
                        throw new Exception("Unknown attribute type.");
                }

                // Guardar los cambios en la base de datos.
                conexion.SaveChanges();
                MessageBox.Show("Attribute saved successfully.");
                this.Close(); // Cerrar la ventana al guardar.
            }
            catch (DbEntityValidationException dbEx)
            {
                // Capturar errores de validación específicos de Entity Framework.
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        MessageBox.Show($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
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
