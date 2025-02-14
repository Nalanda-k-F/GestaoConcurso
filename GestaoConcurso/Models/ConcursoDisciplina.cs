using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoConcurso.Models
{
    [Table("concursodisciplina")]
   
    public class ConcursoDisciplina
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("DataRegistro")]
        public DateTime? DataRegistro { get; set; }

        [Required]
        [Column("DisciplinaId")]
        public int DisciplinaId { get; set; }

        [ForeignKey(nameof(DisciplinaId))]
        public Disciplina? Disciplina { get; set; }

        [Required]
        [Column("ConcursoId")]
        public int ConcursoId { get; set; }

        [ForeignKey(nameof(ConcursoId))]
        public Concurso? Concurso { get; set; }

        public List<Pontuacao> Pontuacoes { get; set; }
    }
}
