using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoConcurso.Models
{
    [Table("candidato")]
    public class Candidato
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("NumeroInscricao")]
        public int? NumeroInsc { get; set; }

        [Column("Nome")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Column("Cpf")]
        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve ter 11 dígitos.")]
        public string Cpf { get; set; } = string.Empty;

        public Endereco? Endereco { get; set; }
    }
}
