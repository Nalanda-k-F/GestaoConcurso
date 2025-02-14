using GestaoConcurso.Contexto;
using GestaoConcurso.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoConcurso.Controllers
{
    public class ConcursoController : Controller
    {
        private readonly ContextoBD _context;

        public ConcursoController(ContextoBD context)
        {
            _context = context;
        }

        // Métodos 
        public async Task Add(Concurso concurso)
        {
            await _context.Concurso.AddAsync(concurso);
        }
        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }




    }
}
