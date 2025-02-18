using GestaoConcurso.Contexto;
using GestaoConcurso.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoConcurso.Controllers
{
    public class InscricaoController : Controller
    {
        private readonly ContextoBD _context;

        public InscricaoController(ContextoBD context)
        {
            _context = context;
        }

        // resolvendo
        // Métodos 
        public async Task Add(Inscricao inscricao)
        {
            await _context.Inscricao.AddAsync(inscricao);
        }
        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
    }
   
}
