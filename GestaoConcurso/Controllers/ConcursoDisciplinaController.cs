using GestaoConcurso.Contexto;
using GestaoConcurso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoConcurso.Controllers
{
    public class ConcursoDisciplinaController : Controller
    {
        private readonly ContextoBD _context;

        public ConcursoDisciplinaController(ContextoBD context)
        {
            _context = context;
        }
        //

        // Métodos 
        public async Task Add(ConcursoDisciplina concursoDisciplina)
        {
            await _context.ConcursoDisciplina.AddAsync(concursoDisciplina);
        }
        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<IActionResult> EditarConcursoDisciplina(int id)
        {
            var concursoDisciplina = await _context.ConcursoDisciplina.FindAsync(id);
            if (concursoDisciplina == null) return NotFound();

            return View(concursoDisciplina);
        }
        public async Task<ActionResult<List<ConcursoDisciplina>>> ListarConcursoDisciplina()
        {
            var concursoDisciplina = await _context.ConcursoDisciplina.ToListAsync();
            return Ok(concursoDisciplina);
        }
        public async Task<ActionResult<ConcursoDisciplina>> BuscarConcursoDisciplinaId(int id)
        {
            var concursoDisciplina = await _context.ConcursoDisciplina.FindAsync(id);

            if (concursoDisciplina == null)
                return NotFound("Concurso x Disciplina não encontrada.");

            return Ok(concursoDisciplina);
        }
        public async Task<IActionResult> Atualizar(int id, [FromBody] ConcursoDisciplina concursoDisciplinaAtualizado)
        {
            var concursoDisciplina = await _context.ConcursoDisciplina.FindAsync(id);

            if (concursoDisciplina == null)
                return NotFound("Concurso x Disciplina não encontrada.");

            // Atualiza os campos necessários
            concursoDisciplina.DataRegistro = concursoDisciplinaAtualizado.DataRegistro;

            await _context.SaveChangesAsync();
            return Ok("Concurso x Disciplina atualizada com sucesso.");
        }
    }
    
}
