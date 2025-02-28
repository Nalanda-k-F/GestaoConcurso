using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoConcurso.Models
{
    [Table("inscricao")]
    public class Inscricao
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("DataInscricao")]
        public DateTime? DataInscricao { get; set; }

        [Required]
        [Column("CandidatoId")]
        public int CandidatoId { get; set; }

        [ForeignKey(nameof(CandidatoId))]
        public Candidato Candidato { get; set; }

        [Required]
        [Column("ConcursoId")]
        public int ConcursoId { get; set; }

        [ForeignKey(nameof(ConcursoId))]
        public Concurso Concurso { get; set; }

        public List<Pontuacao> Pontuacoes { get; set; }
    }
}
