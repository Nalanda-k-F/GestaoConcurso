using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoConcurso.Models
{
    [Table("estado")]
    public class Estado
    {
        [Key] 
        [Column("Id")] 
        public int Id { get; set; }

        [Column("nome")]
        [MaxLength(45)] 
        public string? Nome { get; set; }

        [Column("regiao")]
        [MaxLength(45)]
        public string? Regiao { get; set; }

        [Column("uf")]
        [MaxLength(2)] // UF sempre tem 2 caracteres (exemplo: SP, RJ, MG)
        public string? Uf { get; set; }

        public List<Cidade> Cidades { get; set; }
    }
}
