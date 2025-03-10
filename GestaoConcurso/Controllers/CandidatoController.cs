﻿using GestaoConcurso.Contexto;
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
                // Verifica se já existe um candidato com o mesmo CPF
                if (await _context.Candidato.AnyAsync(c => c.Cpf == candidato.Cpf))
                {
                    throw new Exception("CPF já cadastrado.");
                }

                
                candidato.NumeroInsc = await GerarProximoNumeroInscricao();

                _context.Candidato.Add(candidato);
                await _context.SaveChangesAsync();

                return candidato; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar candidato: {ex.Message}");
                throw;
            }
        }

        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }

        // Método para gerar o próximo número de inscrição
        private async Task<int> GerarProximoNumeroInscricao()
        {
            while (true)
            {
                try
                {
                    // Obtém o último número de inscrição usado
                    var ultimoCandidato = await _context.Candidato
                        .OrderByDescending(c => c.NumeroInsc)
                        .FirstOrDefaultAsync();

                    // Calcula o próximo número de inscrição
                    int novoNumeroInsc = ultimoCandidato?.NumeroInsc + 1 ?? 1;

                    // Verifica se o número já existe no banco de dados
                    if (!await _context.Candidato.AnyAsync(c => c.NumeroInsc == novoNumeroInsc))
                    {
                        return novoNumeroInsc; 
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Lida com exceções de concorrência, se necessário
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

        public async Task<Candidato> BuscarPorCpfOuNome(string cpfOuNome)
        {
            if (string.IsNullOrWhiteSpace(cpfOuNome))
            {
                return null;
            }

            return await _context.Candidato
                .FirstOrDefaultAsync(c => c.Cpf == cpfOuNome || c.Nome.Contains(cpfOuNome));
        }


        // Método para verificar se um candidato existe
        public bool CandidatoExiste(int id)
        {
            return _context.Candidato.Any(e => e.Id == id);
        }
    }
}