using Microsoft.EntityFrameworkCore;
using GestaoConcurso.Models;

namespace GestaoConcurso.Contexto
{
    public class ContextoBD:DbContext
    {
        public ContextoBD(DbContextOptions<ContextoBD> options) : base(options)
        {
        }

        public DbSet<Candidato>Candidato { get; set; }
        public DbSet<Cidade>Cidade { get; set; }
        public DbSet<Concurso>Concurso { get; set; }
        public DbSet<ConcursoDisciplina>ConcursoDisciplina { get; set; }
        public DbSet<Disciplina>Disciplina { get; set; }
        public DbSet<Endereco>Endereco { get; set; }
        public DbSet<Estado>Estado { get; set; }
        public DbSet<Inscricao>Inscricao { get; set; }
        public DbSet<Pontuacao>Pontuacao { get; set; }

    
    }
}
