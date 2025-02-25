using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
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
        public string Nome { get; set; }

        [Column("regiao")]
        [MaxLength(45)]
        public string Regiao { get; set; }

        [Column("uf")] 
        [MaxLength(2)]
        public string UF { get; set; }

        public List<Cidade> Cidades { get; set; }
    }

}


