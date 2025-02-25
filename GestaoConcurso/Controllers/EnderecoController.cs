using GestaoConcurso.Contexto;
using GestaoConcurso.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoConcurso.Controllers
{
    public class EnderecoController
    {
        private readonly ContextoBD _context;

        public EnderecoController(ContextoBD context)
        {
            _context = context;
        }

        // Método para adicionar um endereço
        public async Task<Endereco> Add(Endereco endereco)
        {
            if (endereco == null)
            {
                throw new ArgumentNullException(nameof(endereco), "O endereço não pode ser nulo.");
            }

            try
            {
                // Adiciona o endereço ao banco de dados
                _context.Endereco.Add(endereco);
                await _context.SaveChangesAsync();

                return endereco; // Retorna o endereço com o ID gerado
            }
            catch (Exception ex)
            {
                // Log do erro
                Console.WriteLine($"Erro ao adicionar endereço: {ex.Message}");
                throw; // Re-lança a exceção para ser tratada em um nível superior
            }
        }

        // Método para atualizar um endereço
        public async Task AtualizarEndereco(int candidatoId, Endereco enderecoAtualizado)
        {
            if (enderecoAtualizado == null)
            {
                throw new ArgumentNullException(nameof(enderecoAtualizado), "O endereço atualizado não pode ser nulo.");
            }

            try
            {
                // 1. Desativar o endereço antigo (se existir)
                var enderecoAntigo = await _context.Endereco
                    .FirstOrDefaultAsync(e => e.CandidatoId == candidatoId && e.Ativo == 1);

                if (enderecoAntigo != null)
                {
                    enderecoAntigo.Ativo = 0; // Desativa o endereço antigo
                    _context.Endereco.Update(enderecoAntigo);
                }

                // 2. Ativar o novo endereço
                enderecoAtualizado.CandidatoId = candidatoId;
                enderecoAtualizado.Ativo = 1;

                // Adiciona o novo endereço ao banco de dados
                await _context.Endereco.AddAsync(enderecoAtualizado);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log do erro
                Console.WriteLine($"Erro ao atualizar endereço: {ex.Message}");
                throw; // Re-lança a exceção para ser tratada em um nível superior
            }
        }
    }
}