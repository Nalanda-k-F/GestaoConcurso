using GestaoConcurso.Contexto;
using GestaoConcurso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoConcurso.Controllers
{
    public class CidadeController : Controller
    {
        private readonly ContextoBD _context;

        public CidadeController(ContextoBD context)
        {
            _context = context;
        }

        // Métodos 
        public async Task Add(Cidade cidade)
        {
            await _context.Cidade.AddAsync(cidade);
        }
        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<IActionResult> EditarCidade(int id)
        {
            var cidade = await _context.Cidade.FindAsync(id);
            if (cidade == null) return NotFound();

            return View(cidade);
        }
        public async Task<ActionResult<List<Cidade>>> ListarCidades()
        {
            var cidade = await _context.Cidade.ToListAsync();
            return Ok(cidade);
        }
        public async Task<ActionResult<Cidade>> BuscarCidadeId(int id)
        {
            var cidade = await _context.Candidato.FindAsync(id);

            if (cidade == null)
                return NotFound("Cidade não encontrada.");

            return Ok(cidade);
        }
        public async Task<IActionResult> Atualizar(int id, [FromBody] Cidade cidadeAtualizado)
        {
            var cidade = await _context.Cidade.FindAsync(id);

            if (cidade == null)
                return NotFound("Cidade não encontrada.");

            // Atualiza os campos necessários
            cidade.Municipio = cidadeAtualizado.Municipio;
            
            await _context.SaveChangesAsync();
            return Ok("Cidade atualizada com sucesso.");
        }
    }
}

