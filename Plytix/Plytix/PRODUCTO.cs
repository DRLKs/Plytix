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
            this.PRODUCTO1 = new HashSet<PRODUCTO>();
            this.PRODUCTO2 = new HashSet<PRODUCTO>();
        }
    
        public byte[] THUMBNAIL { get; set; }
        public string NOMBRE { get; set; }
        public string SKU { get; set; }
        public string GTIN { get; set; }
        public Nullable<int> CATEGORIAID { get; set; }
    
        public virtual ICollection<PRODUCTO> PRODUCTO1 { get; set; }
        public virtual ICollection<PRODUCTO> PRODUCTO2 { get; set; }
    }
}
