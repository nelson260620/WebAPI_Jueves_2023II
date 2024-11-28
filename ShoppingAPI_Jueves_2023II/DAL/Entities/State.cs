using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI_Jueves_2023II.DAL.Entities
{
    public class State:AuditBase
    {
        [Display(Name = "Estado/Departamento")]
        [MaxLength(50, ErrorMessage = "el campo {0} debe tener maximo {1} caracteres")]//longitud maxima
        [Required(ErrorMessage = "el campo {0} es obligatorio")]//campo obligatorio

        public string Name { get; set; }

        //asi es como relaciono 2 tablas con EF Core
        [Display(Name = "Pais")]
        public Country? Country { get; set; }

        //FK
        [Display(Name = "Id Pais")]
        public Guid CountryId { get; set; }

    }
}
