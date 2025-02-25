using GestaoConcurso.Contexto;
using GestaoConcurso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoConcurso.Controllers
{
    public class PontuacaoController : Controller
    {
        private readonly ContextoBD _context;

        public PontuacaoController(ContextoBD context)
        {
            _context = context;
        }


        // Métodos 
        public async Task Add(Pontuacao pontuacao)
        {
            await _context.Pontuacao.AddAsync(pontuacao);
        }
        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<ActionResult<List<Pontuacao>>> ListarPontuacao()
        {
            var pontuacao = await _context.Pontuacao.ToListAsync();
            return Ok(pontuacao);
        }
        //
        public async Task<ActionResult<Pontuacao>> BuscarPontuacaoId(int id)
        {
            var pontuacao = await _context.Pontuacao.FindAsync(id);

            if (pontuacao == null)
                return NotFound("Pontuacao não encontrada.");

            return Ok(pontuacao);
        }
        //
        public async Task<IActionResult> EditarPontuacao(int id)
        {
            var pontuacao = await _context.Pontuacao.FindAsync(id);
            if (pontuacao == null) return NotFound();

            return View(pontuacao);
        }
        public async Task<IActionResult> Atualizar(int id, [FromBody] Pontuacao pontuacaoAtualizado)
        {
            var pontuacao = await _context.Pontuacao.FindAsync(id);

            if (pontuacao == null)
                return NotFound("Pontuação não encontrada.");

            // Atualiza os campos necessários
            pontuacao.Nota = pontuacaoAtualizado.Nota;

            await _context.SaveChangesAsync();
            return Ok("Pontuação atualizada com sucesso.");
        }
    }
   
}
