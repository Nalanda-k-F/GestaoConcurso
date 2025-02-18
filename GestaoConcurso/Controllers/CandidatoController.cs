using GestaoConcurso.Contexto;
using Microsoft.AspNetCore.Mvc;
using GestaoConcurso.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoConcurso.Controllers
{
    public class CandidatoController : Controller
    {
        private readonly ContextoBD _context;

        public CandidatoController(ContextoBD context)
        {
            _context = context;
        }

        // Métodos 
        public async Task Add(Candidato candidato)
        {
            await _context.Candidato.AddAsync(candidato);
        }
        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<IActionResult> EditarCandidato(int id)
        {
            var candidato = await _context.Candidato.FindAsync(id);
            if (candidato == null) return NotFound();

            return View(candidato);
        }
        public async Task<ActionResult<List<Candidato>>> ListarTodos()
        {
            var candidatos = await _context.Candidato.ToListAsync();
            return Ok(candidatos);
        }
        public async Task<ActionResult<Candidato>> BuscarPorId(int id)
        {
            var candidato = await _context.Candidato.FindAsync(id);

            if (candidato == null)
                return NotFound("Candidato não encontrado.");

            return Ok(candidato);
        }
        public async Task<IActionResult> Atualizar(int id, [FromBody] Candidato candidatoAtualizado)
        {
            var candidato = await _context.Candidato.FindAsync(id);

            if (candidato == null)
                return NotFound("Candidato não encontrado.");

            // Atualiza os campos necessários
            candidato.Nome = candidatoAtualizado.Nome;
            candidato.Enderecos = candidatoAtualizado.Enderecos;

            await _context.SaveChangesAsync();
            return Ok("Candidato atualizado com sucesso.");
        }

    }
}
