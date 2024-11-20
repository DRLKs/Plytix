using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plytix
{
    internal class Conexion
    {
        protected string server = "database-minipim.cdwgeayaeh1v.eu-central-1.rds.amazonaws.com"; // Punto de enlace de AWS
        protected string database = "grupo11DB"; // Cambia esto por el nombre de la base de datos
        protected string user = "grupo11"; // Nombre de usuario de la base de datos
        protected string password = "xtDA3sPVFCE9BRhK"; // Contraseña del usuario
    }
}
