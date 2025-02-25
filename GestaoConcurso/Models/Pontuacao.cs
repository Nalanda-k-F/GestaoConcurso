using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoConcurso.Models
{
    [Table("pontuacao")]
    public class Pontuacao
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column(TypeName = "decimal(5, 2)")] 
        public decimal? Nota { get; set; }

        [Required]
        [Column("ConcursoDisciplinaId")]
        public int ConcursoDisciplinaId { get; set; }

        [ForeignKey(nameof(ConcursoDisciplinaId))]
        public ConcursoDisciplina? ConcursoDisciplina { get; set; }

        [Required]
        [Column("InscricaoId")]
        public int InscricaoId { get; set; }

        [ForeignKey(nameof(InscricaoId))]
        public Inscricao? Inscricao { get; set; }
    }
}
