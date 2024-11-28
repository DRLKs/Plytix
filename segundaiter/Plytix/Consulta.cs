using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plytix
{
    internal class Consulta
    {
        private ConexionMySQL conexionMySQL;

        public Consulta()
        {
            conexionMySQL = new ConexionMySQL();
        }

        // Método para SELECT
        public List<object[]> Select(string consulta)
        {
            List<object[]> resultados = new List<object[]>();
            try
            {
                var connection = conexionMySQL.GetConnection();
                using (var command = new MySqlCommand(consulta, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        object[] fila = new object[reader.FieldCount];
                        reader.GetValues(fila);
                        resultados.Add(fila);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error en SELECT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultados;
        }

        // Método para INSERT
        public void Insert(string consulta)
        {
            EjecutarConsulta(consulta, "INSERT");
        }

        // Método para UPDATE
        public void Update(string consulta)
        {
            EjecutarConsulta(consulta, "UPDATE");
        }

        // Método para DELETE
        public void Delete(string consulta)
        {
            EjecutarConsulta(consulta, "DELETE");
        }

        private void EjecutarConsulta(string consulta, string tipoOperacion)
        {
            try
            {
                var connection = conexionMySQL.GetConnection();
                using (var command = new MySqlCommand(consulta, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), $"Error en {tipoOperacion}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
