using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoConcurso.Models
{
    [Table("concurso")]
    public class Concurso
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Edital")]
        public string? Edital { get; set; }

        [Column("DataConcurso")]
        public DateTime? DataConcurso { get; set; } 

        public List<ConcursoDisciplina> ConcursosDisciplinas { get; set; }
        public List<Inscricao> Inscricoes { get; set; }
    }

}

