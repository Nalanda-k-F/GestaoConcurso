using GestaoConcurso.Contexto;
using GestaoConcurso.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoConcurso.Controllers
{
    public class CandidatoController
    {
        private readonly ContextoBD _context;

        public CandidatoController(ContextoBD context)
        {
            _context = context;
        }

        // Método para adicionar um candidato
        public async Task<Candidato> Add(Candidato candidato)
        {
            if (candidato == null)
            {
                throw new ArgumentNullException(nameof(candidato), "O candidato não pode ser nulo.");
            }

            try
            {
                // Gera o próximo número de inscrição
                candidato.NumeroInsc = await GerarProximoNumeroInscricao();

                // Adiciona o candidato ao banco de dados
                _context.Candidato.Add(candidato);
                await _context.SaveChangesAsync();

                return candidato; // Retorna o candidato com o ID gerado
            }
            catch (Exception ex)
            {
                // Log do erro
                Console.WriteLine($"Erro ao adicionar candidato: {ex.Message}");
                throw; // Re-lança a exceção para ser tratada em um nível superior
            }
        }

        // Método para gerar o próximo número de inscrição
        private async Task<int> GerarProximoNumeroInscricao()
        {
            while (true)
            {
                try
                {
                    // Obtém o último número de inscrição
                    var ultimoCandidato = await _context.Candidato
                        .OrderByDescending(c => c.NumeroInsc)
                        .FirstOrDefaultAsync();

                    int novoNumeroInsc = ultimoCandidato?.NumeroInsc + 1 ?? 1;

                    // Cria um candidato "fantasma" para garantir que o número seja único
                    var novoCandidato = new Candidato { NumeroInsc = novoNumeroInsc };

                    _context.Candidato.Add(novoCandidato); // Adiciona o candidato fantasma
                    await _context.SaveChangesAsync(); // Salva no banco de dados

                    _context.Candidato.Remove(novoCandidato); // Remove o candidato fantasma
                    await _context.SaveChangesAsync(); // Salva as alterações

                    return novoNumeroInsc; // Retorna o número gerado
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Conflito! Tentar novamente
                    continue;
                }
            }
        }

        // Método para obter um candidato pelo ID
        public async Task<Candidato> ObterCandidatoPorId(int id)
        {
            var candidato = await _context.Candidato.FindAsync(id);

            if (candidato == null)
            {
                throw new KeyNotFoundException($"Candidato com ID {id} não encontrado.");
            }

            return candidato;
        }

        // Método para listar todos os candidatos
        public async Task<List<Candidato>> ListarCandidatos()
        {
            return await _context.Candidato.ToListAsync();
        }

        // Método para editar um candidato
        public async Task EditarCandidato(int id, Candidato candidatoAtualizado)
        {
            if (id != candidatoAtualizado.Id)
            {
                throw new ArgumentException("IDs não correspondem.");
            }

            var candidato = await _context.Candidato.FindAsync(id);

            if (candidato == null)
            {
                throw new KeyNotFoundException($"Candidato com ID {id} não encontrado.");
            }

            // Atualiza as propriedades do candidato
            candidato.Nome = candidatoAtualizado.Nome;
            candidato.Cpf = candidatoAtualizado.Cpf;
            // ... atualize outras propriedades conforme necessário

            await _context.SaveChangesAsync();
        }

        // Método para verificar se um candidato existe
        private bool CandidatoExiste(int id)
        {
            return _context.Candidato.Any(e => e.Id == id);
        }
    }
}