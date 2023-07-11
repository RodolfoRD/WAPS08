using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace WAPS08.Models.ViewModels
{
	public class AutoTableViewModel
	{
		public int _Idauto { get; set; }
		public string _Marca { get; set; }
		public string _Modelo { get; set; }
		public string _Anio { get; set; }
		public string _Imagen { get; set; }
		public string _Direccion { get; set; }

		public string _TipoVehiculo { get; set; }

		public string _Color { get; set; }

		public float _Precio { get; set; }
	}

	public class AddAutoViewModels
	{
		[Required]
		[Display(Name = "Marca")]
		public string Marca { get; set; }

		[Required]
		[Display(Name = "Modelo Del Vehiculo")]
		public string Modelo { get; set; }

		[Required]
		[Display(Name = "Ano Del Vehiculo")]
		public string Anio { get; set; }

		[Required]
		[Display(Name = "Ruta de la Imagen")]
		public string Imagen { get; set; }

		[Required]
		[Display(Name = "Direccion")]
		public string Direccion { get; set; }
		[Required]
		[Display(Name = "Tipo de vehiculo")]
		public string TipoVehiculo { get; set; }
		[Required]
		[Display(Name = "Color")]
		public string Color { get; set; }
		[Required]
		[Display(Name = "Precio")]
		public float Precio { get; set; }

		public  HttpPostedFileBase ImageFile { get; set; }
	}

	public class EditAutoViewModels
	{
		public int IdAuto { get; set; }

		[Required]
		[Display(Name = "Marca")]
		public string Marca { get; set; }

		[Required]
		[Display(Name = "Modelo Del Vehiculo")]
		public string Modelo { get; set; }

		[Required]
		[Display(Name = "Ano Del Vehiculo")]
		public string Anio { get; set; }

		[Required]
		[Display(Name = "Ruta de la Imagen")]
		public string Imagen { get; set; }

		[Required]
		[Display(Name = "Direccion")]
		public string Direccion { get; set; }
		[Required]
		[Display(Name = "Tipo de vehiculo")]
		public string TipoVehiculo { get; set; }
		[Required]
		[Display(Name = "Color")]
		public string Color { get; set; }
		[Required]
		[Display(Name = "Precio")]
		public float Precio { get; set; }
	}
}