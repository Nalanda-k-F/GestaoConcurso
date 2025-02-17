using GestaoConcurso.Contexto;
using GestaoConcurso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoConcurso.Controllers
{
    public class ConcursoController : Controller
    {
        private readonly ContextoBD _context;

        public ConcursoController(ContextoBD context)
        {
            _context = context;
        }

        // Métodos 
        public async Task Add(Concurso concurso)
        {
            await _context.Concurso.AddAsync(concurso);
        }
        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IActionResult> Listar()
        {
            var concursos = await _context.Concurso.ToListAsync();
            return View(concursos);
        }
        // Exibe a página de edição de um concurso específico
        public async Task<IActionResult> Editar(int id)
        {
            var concurso = await _context.Concurso.FindAsync(id);
            if (concurso == null) return NotFound();

            return View(concurso);
        }

        // Atualiza um concurso
        public async Task<IActionResult> Atualizar(int id, string edital, DateTime dataConcurso)
        {
            var concurso = await _context.Concurso.FindAsync(id);
            if (concurso == null) return NotFound();

            concurso.Edital = edital;
            concurso.DataConcurso = dataConcurso;

            _context.Concurso.Update(concurso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }



    }
}
