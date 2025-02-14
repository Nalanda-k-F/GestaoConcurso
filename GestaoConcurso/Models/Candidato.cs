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
        public string? Nome { get; set; }

        [Column("Cpf")]
        public string? Cpf { get; set; }

        public List<Endereco> Enderecos { get; set; } = new List<Endereco>();
    }
}
