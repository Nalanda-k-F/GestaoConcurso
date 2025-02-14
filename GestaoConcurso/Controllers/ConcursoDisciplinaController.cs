using GestaoConcurso.Contexto;
using GestaoConcurso.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoConcurso.Controllers
{
    public class ConcursoDisciplinaController : Controller
    {
        private readonly ContextoBD _context;

        public ConcursoDisciplinaController(ContextoBD context)
        {
            _context = context;
        }


        // Métodos 
        public async Task Add(ConcursoDisciplina concursoDisciplina)
        {
            await _context.ConcursoDisciplina.AddAsync(concursoDisciplina);
        }
        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
    }
    
}
