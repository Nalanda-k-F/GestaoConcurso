using GestaoConcurso.Contexto;
using GestaoConcurso.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoConcurso.Controllers
{
    public class PontuacaoController : Controller
    {
        private readonly ContextoBD _context;

        public PontuacaoController(ContextoBD context)
        {
            _context = context;
        }


        // Métodos 
        public async Task Add(Pontuacao pontuacao)
        {
            await _context.Pontuacao.AddAsync(pontuacao);
        }
        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
    }
   
}
