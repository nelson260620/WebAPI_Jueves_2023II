using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI_Jueves_2023II.DAL.Entities
{
    public class Country : AuditBase
    {
        [Display(Name = "Pais")]// Para identificar el nombre mas facil
        [MaxLength(50,ErrorMessage = "el campo {0} debe tener maximo {1} caracteres")]//longitud maxima
        [Required(ErrorMessage = "el campo {0} es obligatorio")]//campo obligatorio
        
        public String Name { get; set; }

        [Display(Name = "Estados/Departamento")]
        public ICollection<State>? States { get; set; }
    }
}
