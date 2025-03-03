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

                return endereco;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Erro ao adicionar endereço: {ex.Message}");
                throw;
            }
        }


        public async Task<Endereco> BuscarEnderecoDoCandidato(int candidatoId)
        {
            try
            {
                return await _context.Endereco
                    .Include(e => e.Cidade)
                    .AsNoTracking() 
                    .FirstOrDefaultAsync(e => e.CandidatoId == candidatoId && e.Ativo == 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar endereço: {ex.Message}");
                throw;
            }
        }

        // Método para atualizar um endereço
        public async Task AtualizarEndereco(Endereco enderecoAtualizado)
        {
            if (enderecoAtualizado == null)
            {
                throw new ArgumentNullException(nameof(enderecoAtualizado), "O endereço atualizado não pode ser nulo.");
            }

            try
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        if (enderecoAtualizado.Id <= 0) // Verifica se é um novo endereço
                        {
                            // Buscar o último endereço ativo do candidato
                            var enderecoAntigo = await _context.Endereco
                                .Where(e => e.CandidatoId == enderecoAtualizado.CandidatoId && e.Ativo == 1)
                                .OrderByDescending(e => e.Id)
                                .FirstOrDefaultAsync();

                            // Desativar o endereço antigo, se existir
                            if (enderecoAntigo != null)
                            {
                                _context.Entry(enderecoAntigo).State = EntityState.Modified;
                                enderecoAntigo.Ativo = 0;
                                _context.Endereco.Update(enderecoAntigo);
                            }

                            // Adicionar o novo endereço
                            enderecoAtualizado.Ativo = 1;
                            _context.Endereco.Add(enderecoAtualizado);
                        }
                        else
                        {
                            // Atualizar endereço existente
                            _context.Endereco.Update(enderecoAtualizado);
                        }

                        await _context.SaveChangesAsync();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Erro ao atualizar/adicionar endereço: {ex.Message} - Detalhes: {ex.InnerException?.Message}");
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar/adicionar endereço: {ex.Message} - Detalhes: {ex.InnerException?.Message}");
                throw;
            }
        }
        //
    }
}