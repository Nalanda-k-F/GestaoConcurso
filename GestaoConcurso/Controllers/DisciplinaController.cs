using GestaoConcurso.Contexto;
using GestaoConcurso.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoConcurso.Controllers
{
    public class DisciplinaController : Controller
    {
        private readonly ContextoBD _context;

        public DisciplinaController(ContextoBD context)
        {
            _context = context;
        }


        // Métodos 
        public async Task Add(Disciplina disciplina)
        {
            await _context.Disciplina.AddAsync(disciplina);
        }
        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
    }
   
}
