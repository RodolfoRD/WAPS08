using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WAPS08.Models.ViewModels
{
    public class UserTableViewModel
    {
        // ---------------------------------------------------------------------------------------------------------
        // esta variable son las que utilizaremos para representar los campos de entrada de datos en la vista 'Index'
        // y en el controller 'UserController'
        // ---------------------------------------------------------------------------------------------------------
        public int _Id { get; set; }
        public string _Email { get; set; }    // declara la variable a usar en la vista 'Index'
        public int? _Edad { get; set; }
    }

    public class AddUserViewModels
    {
        [Required(ErrorMessage ="Este campo es requerido")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Debe colocar su correo electronico")]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Debe confirmar su contraseña")]
        [Compare(nameof(Password), ErrorMessage = "Las contraseñas no coinciden")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirma Password")]
        public string ConfirmaPassword { get; set; }

        [Required(ErrorMessage = "Debe indicar su edad")]
        [Range(1, 99, ErrorMessage = "Su edad no puede ser 0")]
        [Display(Name = "Edad")]
        public int Edad { get; set; }
    }

    public class EditUserViewModels
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar su correo electronico")]
        [Display(Name = "Correo Electronico")]        
        public string Email { get; set; }

        [Required(ErrorMessage ="Debe ingresar una contraseña")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Debe confirmar su contraseña")]
        [Compare(nameof(Password), ErrorMessage = "Las contraseñas no coinciden")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirma Password")]        
        public string ConfirmaPassword { get; set; }


        [Required(ErrorMessage = "Debe indicar su edad")]
        [Range(1,99 , ErrorMessage = "Su edad no puede ser 0")]
        [Display(Name = "Edad")]
        public int Edad { get; set; }
    }
}