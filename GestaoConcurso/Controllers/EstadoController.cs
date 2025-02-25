using GestaoConcurso.Contexto;
using GestaoConcurso.Models;
using Microsoft.EntityFrameworkCore;

public class EstadoController
{
    private readonly ContextoBD _context;

    public EstadoController(ContextoBD context)
    {
        _context = context;
    }

    // Método para adicionar estados ao banco de dados
    public async Task AdicionarEstados()
    {
        if (await _context.Estado.AnyAsync())
        {
            Console.WriteLine("Estados já foram adicionados anteriormente.");
            return;
        }

        var estados = new List<Estado>
        {
            new Estado { Id = 1, Nome = "Acre", UF = "AC", Regiao = "Norte" },
            new Estado { Id = 2, Nome = "Alagoas", UF = "AL", Regiao = "Nordeste" },
            new Estado { Id = 3, Nome = "Amapá", UF = "AP", Regiao = "Norte" },
            new Estado { Id = 4, Nome = "Amazonas", UF = "AM", Regiao = "Norte" },
            new Estado { Id = 5, Nome = "Bahia", UF = "BA", Regiao = "Nordeste" },
            new Estado { Id = 6, Nome = "Ceará", UF = "CE", Regiao = "Nordeste" },
            new Estado { Id = 7, Nome = "Distrito Federal", UF = "DF", Regiao = "Centro-Oeste" },
            new Estado { Id = 8, Nome = "Espírito Santo", UF = "ES", Regiao = "Sudeste" },
            new Estado { Id = 9, Nome = "Goiás", UF = "GO", Regiao = "Centro-Oeste" },
            new Estado { Id = 10, Nome = "Maranhão", UF = "MA", Regiao = "Nordeste" },
            new Estado { Id = 11, Nome = "Mato Grosso", UF = "MT", Regiao = "Centro-Oeste" },
            new Estado { Id = 12, Nome = "Mato Grosso do Sul", UF = "MS", Regiao = "Centro-Oeste" },
            new Estado { Id = 13, Nome = "Minas Gerais", UF = "MG", Regiao = "Sudeste" },
            new Estado { Id = 14, Nome = "Pará", UF = "PA", Regiao = "Norte" },
            new Estado { Id = 15, Nome = "Paraíba", UF = "PB", Regiao = "Nordeste" },
            new Estado { Id = 16, Nome = "Paraná", UF = "PR", Regiao = "Sul" },
            new Estado { Id = 17, Nome = "Pernambuco", UF = "PE", Regiao = "Nordeste" },
            new Estado { Id = 18, Nome = "Piauí", UF = "PI", Regiao = "Nordeste" },
            new Estado { Id = 19, Nome = "Rio de Janeiro", UF = "RJ", Regiao = "Sudeste" },
            new Estado { Id = 20, Nome = "Rio Grande do Norte", UF = "RN", Regiao = "Nordeste" },
            new Estado { Id = 21, Nome = "Rio Grande do Sul", UF = "RS", Regiao = "Sul" },
            new Estado { Id = 22, Nome = "Rondônia", UF = "RO", Regiao = "Norte" },
            new Estado { Id = 23, Nome = "Roraima", UF = "RR", Regiao = "Norte" },
            new Estado { Id = 24, Nome = "Santa Catarina", UF = "SC", Regiao = "Sul" },
            new Estado { Id = 25, Nome = "São Paulo", UF = "SP", Regiao = "Sudeste" },
            new Estado { Id = 26, Nome = "Sergipe", UF = "SE", Regiao = "Nordeste" },
            new Estado { Id = 27, Nome = "Tocantins", UF = "TO", Regiao = "Norte" }
        };

        await _context.Estado.AddRangeAsync(estados);
        await _context.SaveChangesAsync();

        Console.WriteLine("Estados adicionados com sucesso.");
    }

    // Método para listar todos os estados
    public async Task<List<Estado>> ListarEstados()
    {
        return await _context.Estado.ToListAsync();
    }

    // Método para buscar um estado por ID
    public async Task<Estado> BuscarEstadoPorId(int id)
    {
        var estado = await _context.Estado.FindAsync(id);

        if (estado == null)
        {
            throw new KeyNotFoundException($"Estado com ID {id} não encontrado.");
        }

        return estado;
    }

    // Método para buscar estados por nome
    public async Task<List<Estado>> BuscarEstadosPorNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("O nome do estado não pode ser vazio.");
        }

        return await _context.Estado
            .Where(e => e.Nome.Contains(nome))
            .ToListAsync();
    }
}