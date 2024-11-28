using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI_Jueves_2023II.DAL.Entities
{
    public class Country : AuditBase
    {
        [Display]
        [MaxLength(50,ErrorMessage = "el campo {0} debe tener maximo {1} caracteres")]//longitud maxima
        [Required(ErrorMessage = "el campo {0} es obligatorio")]//campo obligatorio
        
        public String Name { get; set; }
    }
}
