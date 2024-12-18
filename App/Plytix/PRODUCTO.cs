//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Plytix
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRODUCTO
    {
        public PRODUCTO()
        {
            this.CATEGORIA = new HashSet<CATEGORIA>();
            this.PRODUCTO_ATRIBUTO = new HashSet<PRODUCTO_ATRIBUTO>();
            this.RELACION = new HashSet<RELACION>();
            this.RELACION1 = new HashSet<RELACION>();
        }
    
        public int ID { get; set; }
        public byte[] THUMBNAIL { get; set; }
        public string NOMBRE { get; set; }
        public string SKU { get; set; }
        public string GTIN { get; set; }
        public System.DateTime FECHA_CREACION { get; set; }
        public System.DateTime FECHA_EDICION { get; set; }
        public string DESCRIPCION_CORTA { get; set; }
        public string DESCRIPCION_LARGA { get; set; }
    
        public virtual ICollection<CATEGORIA> CATEGORIA { get; set; }
        public virtual ICollection<PRODUCTO_ATRIBUTO> PRODUCTO_ATRIBUTO { get; set; }
        public virtual ICollection<RELACION> RELACION { get; set; }
        public virtual ICollection<RELACION> RELACION1 { get; set; }

        public override string ToString()
        {
            return NOMBRE;
        }
    }
}
