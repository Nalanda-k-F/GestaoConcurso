using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoConcurso.Models
{
    [Table("cidade")]
    public class Cidade
    {
        [Key] 
        [Column("Id")]
        public int Id { get; set; }

        [Column("municipio")] 
        [MaxLength(45)]
        public string Municipio { get; set; } 


        [Required]
        [Column("EstadoId")] 
        public int EstadoId { get; set; }

        [ForeignKey(nameof(EstadoId))]
        public Estado Estado { get; set; }

        
    }
}
