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

       
        public async Task Add(Inscricao inscricao)
        {
            await _context.Inscricao.AddAsync(inscricao);
            await _context.SaveChangesAsync();
        }


        public async Task<List<Inscricao>> ListarInscricao()
        {
            return await _context.Inscricao.ToListAsync();
        }
        //
        public async Task<List<Inscricao>> ListarInscricaoPorConcurso(int concursoId)
        {
            var inscricoes = await _context.Inscricao
                .Where(i => i.ConcursoId == concursoId)
                .Select(i => new Inscricao
                {
                    Id = i.Id,
                    DataInscricao = i.DataInscricao,
                    ConcursoId = i.ConcursoId, // Adicione esta linha
                    Candidato = new Candidato { Nome = i.Candidato.Nome }
                })
                .ToListAsync();

            Console.WriteLine($"Inscrições encontradas para ConcursoId {concursoId}: {inscricoes.Count}"); // Log adicionado

            return inscricoes;
        }
        //
        public async Task<ActionResult<Inscricao>> BuscarInscricaoId(int id)
        {
            var inscricao = await _context.Inscricao.FindAsync(id);

            if (inscricao == null)
                return NotFound("Inscrição não encontrada.");

            return Ok(inscricao);
        }
        public async Task<List<Inscricao>> ListarInscricoesPorCpf(string cpf)
        {
            return await _context.Inscricao
                .Where(i => i.Candidato.Cpf == cpf)
                .Include(i => i.Candidato)
                .ToListAsync();
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
