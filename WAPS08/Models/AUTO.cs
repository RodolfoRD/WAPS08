//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WAPS08.Models
{
    using System;
    using System.Web;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    public partial class AUTO
    {
        public int IDauto { get; set; }
        public string Marca { get; set; }
        public Nullable<int> miEstatus { get; set; }
        public string ImgRuta { get; set; }
        public string Modelo { get; set; }
        public string Anio { get; set; }
        public string Color { get; set; }
        public string TipoVehiculo { get; set; }
        public Nullable<double> Precio { get; set; }
        public string Direccion { get; set; }

		public HttpPostedFileBase ImageFile { get; set; }


		public virtual VHESTATU VHESTATU { get; set; }
    }
}
