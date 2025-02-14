using GestaoConcurso.Contexto;
using GestaoConcurso.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoConcurso.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly ContextoBD _context;

        public EnderecoController(ContextoBD context)
        {
            _context = context;
        }


        // Métodos 
        public async Task Add(Endereco endereco)
        {
            await _context.Endereco.AddAsync(endereco);
        }
        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
    }
    
}
