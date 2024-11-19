using BDLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{   

    class Producto
    {
        private static string BD_SERVER = "localhost";
        private static string BD_NAME = "IngenieriaRequisitos";

        private string sku;
        private string gtin;
        private string nombre;
        private string thumbnail;   // Es la url de una imagen
        private int categoriaId;
        private List<String> productosRelacionados;

        public Producto(string sku, string gtin, string nombre, string thumbnail, int categoriaID, List<String> productosRelacionados)
        {
            SQLSERVERDB db = new SQLSERVERDB(BD_SERVER, BD_NAME);
            db.Insert("INSERT INTO PRODUCTO VALUES(" + ");");
            this.sku = sku;
            if (gtin != null) this.gtin = gtin;
            this.nombre = nombre;
            if (thumbnail != null) this.thumbnail = thumbnail;
            if (categoriaID != -1) this.categoriaId = categoriaID;

            foreach (String skuProd in productosRelacionados)
            {
                db.Insert("INSERT INTO PRODUCTOSRELACIONADOS VALUES('" + sku + "','" + skuProd + "');");
                productosRelacionados.Add(skuProd);
            }
        }

        public Producto(string sku)
        {
            SQLSERVERDB db = new SQLSERVERDB(BD_SERVER, BD_NAME);
            Object[] tupla = db.Select("SELECT * FROM PRODUCTO WHERE SKU = '" + sku + "';")[0];
   
            this.sku = tupla[0].ToString();
            if (tupla[1] != null) this.gtin = tupla[1].ToString();
            this.nombre = tupla[2].ToString();
            if (tupla[3] != null)  this.thumbnail = tupla[3].ToString();
            if (tupla[4] != null)  this.categoriaId = (int)tupla[4];

            List<Object[]> listaTuplas = db.Select("SELECT * FROM PRODUCTOSRELACIONADOS WHERE PRODUCTOSKU1 = '" + sku + "' OR PRODUCTOSKU2 = '" + sku + "';");
            
            productosRelacionados = new List<string>();

            foreach( Object[] t in listaTuplas ){
                if (t[0].ToString().Equals(sku))
                {
                    productosRelacionados.Add( t[1].ToString() );
                }else{
                    productosRelacionados.Add( t[0].ToString() );
                }
            }
        }
    }

}
