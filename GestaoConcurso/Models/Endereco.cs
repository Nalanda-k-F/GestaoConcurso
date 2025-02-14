using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoConcurso.Models
{
    [Table("endereco")]
    public class Endereco
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Rua")]
        public string? Rua { get; set; }

        [Column("Numero")]
        public string? Numero { get; set; }

        [Column("Bairro")]
        public string? Bairro { get; set; }

        [Column("Complemento")]
        public string? Complemento { get; set; }

        [Column("Ativo")]
        public int? Ativo { get; set; }

        [Required]
        [Column("CandidatoId")]
        public int CandidatoId { get; set; }

        [ForeignKey(nameof(CandidatoId))]
        public Candidato? Candidato { get; set; }

        [Required]
        [Column("CidadeId")]
        public int CidadeId { get; set; }

        [ForeignKey(nameof(CidadeId))]
        public Cidade? Cidade{ get; set; }
    }
}
