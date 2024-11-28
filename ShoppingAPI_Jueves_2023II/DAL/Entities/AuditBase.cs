using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI_Jueves_2023II.DAL.Entities
{
    public class AuditBase
    {
        [Key]
        [Required]

        public virtual Guid Id { get; set; }//esta es la pk de todas las tablas
        public virtual DateTime CreatedDate { get; set; }// guardar los registros nuevos con sus datos
        public virtual DateTime ModifiedDate { get; set; }// guardar los registros que se modificaron con sus datos
    }
}
