using GestaoConcurso.Contexto;
using GestaoConcurso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<List<Disciplina>>> ListarDisciplina()
        {
            var disciplinas = await _context.Disciplina.ToListAsync();
            return Ok(disciplinas);
        }
        public async Task<ActionResult<Disciplina>> BuscarDisciplinaId(int id)
        {
            var disciplina = await _context.Disciplina.FindAsync(id);

            if (disciplina == null)
                return NotFound("Disciplina não encontrado.");

            return Ok(disciplina);
        }
    }
   
}
