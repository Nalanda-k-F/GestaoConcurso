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
            await _context.SaveChangesAsync(); 
        }

        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }


        public async Task<List<Concurso>> ListarConcurso()
        {
            return await _context.Concurso.ToListAsync();
        }

        
        public async Task<Concurso?> BuscarPorId(int id)
        {
            return await _context.Concurso.FindAsync(id);
        }

        public async Task Editar(Concurso concursoAtualizado)
        {
            var concursoExistente = await _context.Concurso.FindAsync(concursoAtualizado.Id);
            if (concursoExistente != null)
            {
                   concursoExistente.Edital = concursoAtualizado.Edital;
                concursoExistente.DataConcurso = concursoAtualizado.DataConcurso;

                _context.Concurso.Update(concursoExistente);
                await _context.SaveChangesAsync();
            }
        }
    }
}