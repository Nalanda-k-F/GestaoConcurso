using GestaoConcurso.Contexto;
using GestaoConcurso.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoConcurso.Controllers
{
    public class EstadoController : Controller
    {
        private readonly ContextoBD _context;

        public EstadoController(ContextoBD context)
        {
            _context = context;
        }

        // Métodos 
        public async Task Add(Estado estado)
        {
            await _context.Estado.AddAsync(estado);
        }
        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
    }
   
}
