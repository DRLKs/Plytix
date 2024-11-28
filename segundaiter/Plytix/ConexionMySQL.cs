using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plytix
{
    internal class ConexionMySQL : Conexion
    {
        private MySqlConnection connexion;
        private string cadenaConexion;

        public ConexionMySQL()
        {
            cadenaConexion = "Database=" + database +
                             "; DataSource=" + server +
                             "; User Id=" + user +
                             "; Password=" + password;
            connexion = new MySqlConnection(cadenaConexion);
        }

        public MySqlConnection GetConnection()
        {
            try
            {
                if (connexion.State != System.Data.ConnectionState.Open)
                {
                    connexion.Open(); // Conectar a la base de datos
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return connexion;
        }
    }
}
