using GestaoConcurso.Contexto;
using GestaoConcurso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<List<Inscricao>>> ListarInscricao()
        {
            var inscricao = await _context.Inscricao.ToListAsync();
            return Ok(inscricao);
        }
        //
        public async Task<ActionResult<Inscricao>> BuscarInscricaoId(int id)
        {
            var inscricao = await _context.Inscricao.FindAsync(id);

            if (inscricao == null)
                return NotFound("Inscrição não encontrada.");

            return Ok(inscricao);
        }
        //
        public async Task<IActionResult> EditarInscricao(int id)
        {
            var inscricao = await _context.Inscricao.FindAsync(id);
            if (inscricao == null) return NotFound();

            return View(inscricao);
        }
        public async Task<IActionResult> Atualizar(int id, [FromBody] Inscricao inscricaoAtualizado)
        {
            var inscricao = await _context.Inscricao.FindAsync(id);

            if (inscricao == null)
                return NotFound("Inscrição não encontrada.");

            // Atualiza os campos necessários
            inscricao.DataInscricao = inscricaoAtualizado.DataInscricao;
            
            await _context.SaveChangesAsync();
            return Ok("Inscrição atualizada com sucesso.");
        }
    }
   
}
