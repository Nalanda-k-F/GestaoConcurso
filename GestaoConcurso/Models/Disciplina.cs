using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoConcurso.Models
{
    [Table("disciplina")]
    public class Disciplina
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Disciplina")] 
        public string? NomeDisc { get; set; } 

        public List<ConcursoDisciplina> ConcursosDisciplinas { get; set; }
    
    }
}
