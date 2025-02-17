using GestaoConcurso.Contexto;
using GestaoConcurso.Models;
using Microsoft.AspNetCore.Mvc;

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
        // testando
    }
}

