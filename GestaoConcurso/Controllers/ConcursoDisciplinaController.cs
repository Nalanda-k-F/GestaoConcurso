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
            // Obtém a disciplina pelo ID
            var disciplina = await _context.Disciplina.FindAsync(concursoDisciplina.DisciplinaId);

            if (disciplina == null)
            {
                throw new Exception("Disciplina não encontrada.");
            }

            // Verifica se já existe uma disciplina com o mesmo nome para o mesmo concurso
            if (await _context.ConcursoDisciplina
                .Include(cd => cd.Disciplina)
                .AnyAsync(cd => cd.ConcursoId == concursoDisciplina.ConcursoId && cd.Disciplina.NomeDisc == disciplina.NomeDisc))
            {
                throw new Exception("Disciplina com este nome já cadastrada para este concurso.");
            }

            await _context.ConcursoDisciplina.AddAsync(concursoDisciplina);
        }
        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<ConcursoDisciplina>> ListarConcursoDisciplinasPorConcurso(int concursoId)
        {
            var disciplinas = await _context.ConcursoDisciplina
                .Where(cd => cd.ConcursoId == concursoId)
                .Include(cd => cd.Disciplina)
                .ToListAsync();

            foreach (var disciplina in disciplinas)
            {
                Console.WriteLine($"ConcursoDisciplinaId: {disciplina.Id}, DisciplinaId: {disciplina.DisciplinaId}, DisciplinaNome: {disciplina.Disciplina?.NomeDisc}");
            }

            return disciplinas;
        }


        public async Task<IActionResult> EditarConcursoDisciplina(int id)
        {
            var concursoDisciplina = await _context.ConcursoDisciplina.FindAsync(id);
            if (concursoDisciplina == null) return NotFound();

            return View(concursoDisciplina);
        }
        public async Task<List<ConcursoDisciplina>> ListarConcursoDisciplinas()
        {
            return await _context.ConcursoDisciplina.Include(cd => cd.Disciplina).ToListAsync();
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
