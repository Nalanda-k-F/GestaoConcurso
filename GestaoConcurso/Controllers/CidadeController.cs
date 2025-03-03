using GestaoConcurso.Contexto;
using GestaoConcurso.Models;
using Microsoft.EntityFrameworkCore;

public class CidadeController
{
    private readonly ContextoBD _context;

    public CidadeController(ContextoBD context)
    {
        _context = context;
    }

    public async Task AdicionarCidades()
    {
        Console.WriteLine("Adicionando cidades...");
        if (!await _context.Cidade.AnyAsync()) // Verifica se não existe nenhuma cidade no banco
        {
            var cidades = new List<Cidade>
            {
                            // Acre
new Cidade { Id = 1, Municipio = "Rio Branco", EstadoId = 1 },
new Cidade { Id = 2, Municipio = "Cruzeiro do Sul", EstadoId = 1 },
new Cidade { Id = 3, Municipio = "Sena Madureira", EstadoId = 1 },
new Cidade { Id = 4, Municipio = "Tarauacá", EstadoId = 1 },
new Cidade { Id = 5, Municipio = "Feijó", EstadoId = 1 },
new Cidade { Id = 6, Municipio = "Brasileia", EstadoId = 1 },
new Cidade { Id = 7, Municipio = "Plácido de Castro", EstadoId = 1 },

// Alagoas
new Cidade { Id = 8, Municipio = "Maceió", EstadoId = 2 },
new Cidade { Id = 9, Municipio = "Arapiraca", EstadoId = 2 },
new Cidade { Id = 10, Municipio = "Palmeira dos Índios", EstadoId = 2 },
new Cidade { Id = 11, Municipio = "Delmiro Gouveia", EstadoId = 2 },
new Cidade { Id = 12, Municipio = "Penedo", EstadoId = 2 },
new Cidade { Id = 13, Municipio = "Rio Largo", EstadoId = 2 },
new Cidade { Id = 14, Municipio = "Paripueira", EstadoId = 2 },

// Amapá
new Cidade { Id = 15, Municipio = "Macapá", EstadoId = 3 },
new Cidade { Id = 16, Municipio = "Santana", EstadoId = 3 },
new Cidade { Id = 17, Municipio = "Laranjal do Jari", EstadoId = 3 },
new Cidade { Id = 18, Municipio = "Oiapoque", EstadoId = 3 },
new Cidade { Id = 19, Municipio = "Porto Grande", EstadoId = 3 },
new Cidade { Id = 20, Municipio = "Tartarugalzinho", EstadoId = 3 },
new Cidade { Id = 21, Municipio = "Calçoene", EstadoId = 3 },

// Amazonas
new Cidade { Id = 22, Municipio = "Manaus", EstadoId = 4 },
new Cidade { Id = 23, Municipio = "Parintins", EstadoId = 4 },
new Cidade { Id = 24, Municipio = "Itacoatiara", EstadoId = 4 },
new Cidade { Id = 25, Municipio = "Coari", EstadoId = 4 },
new Cidade { Id = 26, Municipio = "Manacapuru", EstadoId = 4 },
new Cidade { Id = 27, Municipio = "Tabatinga", EstadoId = 4 },
new Cidade { Id = 28, Municipio = "Maués", EstadoId = 4 },

// Bahia
new Cidade { Id = 29, Municipio = "Salvador", EstadoId = 5 },
new Cidade { Id = 30, Municipio = "Feira de Santana", EstadoId = 5 },
new Cidade { Id = 31, Municipio = "Vitória da Conquista", EstadoId = 5 },
new Cidade { Id = 32, Municipio = "Camaçari", EstadoId = 5 },
new Cidade { Id = 33, Municipio = "Ilhéus", EstadoId = 5 },
new Cidade { Id = 34, Municipio = "Juazeiro", EstadoId = 5 },
new Cidade { Id = 35, Municipio = "Jequié", EstadoId = 5 },

// Ceará
new Cidade { Id = 36, Municipio = "Fortaleza", EstadoId = 6 },
new Cidade { Id = 37, Municipio = "Juazeiro do Norte", EstadoId = 6 },
new Cidade { Id = 38, Municipio = "Caucaia", EstadoId = 6 },
new Cidade { Id = 39, Municipio = "Sobral", EstadoId = 6 },
new Cidade { Id = 40, Municipio = "Crato", EstadoId = 6 },
new Cidade { Id = 41, Municipio = "Maracanaú", EstadoId = 6 },
new Cidade { Id = 42, Municipio = "Iguatu", EstadoId = 6 },

// Distrito Federal
new Cidade { Id = 43, Municipio = "Brasília", EstadoId = 7 },
new Cidade { Id = 44, Municipio = "Ceilândia", EstadoId = 7 },
new Cidade { Id = 45, Municipio = "Taguatinga", EstadoId = 7 },
new Cidade { Id = 46, Municipio = "Samambaia", EstadoId = 7 },
new Cidade { Id = 47, Municipio = "Gama", EstadoId = 7 },
new Cidade { Id = 48, Municipio = "Planaltina", EstadoId = 7 },
new Cidade { Id = 49, Municipio = "Águas Claras", EstadoId = 7 },

// Espírito Santo
new Cidade { Id = 50, Municipio = "Vitória", EstadoId = 8 },
new Cidade { Id = 51, Municipio = "Vila Velha", EstadoId = 8 },
new Cidade { Id = 52, Municipio = "Serra", EstadoId = 8 },
new Cidade { Id = 53, Municipio = "Cariacica", EstadoId = 8 },
new Cidade { Id = 54, Municipio = "Linhares", EstadoId = 8 },
new Cidade { Id = 55, Municipio = "Colatina", EstadoId = 8 },
new Cidade { Id = 56, Municipio = "Guarapari", EstadoId = 8 },

// Goiás
new Cidade { Id = 57, Municipio = "Goiânia", EstadoId = 9 },
new Cidade { Id = 58, Municipio = "Aparecida de Goiânia", EstadoId = 9 },
new Cidade { Id = 59, Municipio = "Anápolis", EstadoId = 9 },
new Cidade { Id = 60, Municipio = "Rio Verde", EstadoId = 9 },
new Cidade { Id = 61, Municipio = "Luziânia", EstadoId = 9 },
new Cidade { Id = 62, Municipio = "Águas Lindas de Goiás", EstadoId = 9 },
new Cidade { Id = 63, Municipio = "Novo Gama", EstadoId = 9 },

// Maranhão
new Cidade { Id = 64, Municipio = "São Luís", EstadoId = 10 },
new Cidade { Id = 65, Municipio = "Imperatriz", EstadoId = 10 },
new Cidade { Id = 66, Municipio = "São José de Ribamar", EstadoId = 10 },
new Cidade { Id = 67, Municipio = "Timon", EstadoId = 10 },
new Cidade { Id = 68, Municipio = "Caxias", EstadoId = 10 },
new Cidade { Id = 69, Municipio = "Bacabal", EstadoId = 10 },
new Cidade { Id = 70, Municipio = "Paço do Lumiar", EstadoId = 10 },

// Mato Grosso
new Cidade { Id = 71, Municipio = "Cuiabá", EstadoId = 11 },
new Cidade { Id = 72, Municipio = "Várzea Grande", EstadoId = 11 },
new Cidade { Id = 73, Municipio = "Rondonópolis", EstadoId = 11 },
new Cidade { Id = 74, Municipio = "Sinop", EstadoId = 11 },
new Cidade { Id = 75, Municipio = "Tangará da Serra", EstadoId = 11 },
new Cidade { Id = 76, Municipio = "Lucas do Rio Verde", EstadoId = 11 },
new Cidade { Id = 77, Municipio = "Primavera do Leste", EstadoId = 11 },
// Mato Grosso do Sul
new Cidade { Id = 78, Municipio = "Campo Grande", EstadoId = 12 },
new Cidade { Id = 79, Municipio = "Dourados", EstadoId = 12 },
new Cidade { Id = 80, Municipio = "Três Lagoas", EstadoId = 12 },
new Cidade { Id = 81, Municipio = "Corumbá", EstadoId = 12 },
new Cidade { Id = 82, Municipio = "Ponta Porã", EstadoId = 12 },
new Cidade { Id = 83, Municipio = "Nova Andradina", EstadoId = 12 },
new Cidade { Id = 84, Municipio = "Coxim", EstadoId = 12 },

// Minas Gerais
new Cidade { Id = 85, Municipio = "Belo Horizonte", EstadoId = 13 },
new Cidade { Id = 86, Municipio = "Uberlândia", EstadoId = 13 },
new Cidade { Id = 87, Municipio = "Contagem", EstadoId = 13 },
new Cidade { Id = 88, Municipio = "Juiz de Fora", EstadoId = 13 },
new Cidade { Id = 89, Municipio = "Montes Claros", EstadoId = 13 },
new Cidade { Id = 90, Municipio = "Betim", EstadoId = 13 },
new Cidade { Id = 91, Municipio = "Ipatinga", EstadoId = 13 },

// Pará
new Cidade { Id = 92, Municipio = "Belém", EstadoId = 14 },
new Cidade { Id = 93, Municipio = "Ananindeua", EstadoId = 14 },
new Cidade { Id = 94, Municipio = "Marabá", EstadoId = 14 },
new Cidade { Id = 95, Municipio = "Parauapebas", EstadoId = 14 },
new Cidade { Id = 96, Municipio = "Santarem", EstadoId = 14 },
new Cidade { Id = 97, Municipio = "Castanhal", EstadoId = 14 },
new Cidade { Id = 98, Municipio = "Bragança", EstadoId = 14 },

// Paraíba
new Cidade { Id = 99, Municipio = "João Pessoa", EstadoId = 15 },
new Cidade { Id = 100, Municipio = "Campina Grande", EstadoId = 15 },
new Cidade { Id = 101, Municipio = "Santa Rita", EstadoId = 15 },
new Cidade { Id = 102, Municipio = "Patos", EstadoId = 15 },
new Cidade { Id = 103, Municipio = "Bayeux", EstadoId = 15 },
new Cidade { Id = 104, Municipio = "Sousa", EstadoId = 15 },
new Cidade { Id = 105, Municipio = "Cajazeiras", EstadoId = 15 },

// Paraná
new Cidade { Id = 106, Municipio = "Curitiba", EstadoId = 16 },
new Cidade { Id = 107, Municipio = "Londrina", EstadoId = 16 },
new Cidade { Id = 108, Municipio = "Maringá", EstadoId = 16 },
new Cidade { Id = 109, Municipio = "Foz do Iguaçu", EstadoId = 16 },
new Cidade { Id = 110, Municipio = "Ponta Grossa", EstadoId = 16 },
new Cidade { Id = 111, Municipio = "Cascavel", EstadoId = 16 },
new Cidade { Id = 112, Municipio = "Araucária", EstadoId = 16 },

// Pernambuco
new Cidade { Id = 113, Municipio = "Recife", EstadoId = 17 },
new Cidade { Id = 114, Municipio = "Olinda", EstadoId = 17 },
new Cidade { Id = 115, Municipio = "Jaboatão dos Guararapes", EstadoId = 17 },
new Cidade { Id = 116, Municipio = "Caruaru", EstadoId = 17 },
new Cidade { Id = 117, Municipio = "Petrolina", EstadoId = 17 },
new Cidade { Id = 118, Municipio = "Cabo de Santo Agostinho", EstadoId = 17 },
new Cidade { Id = 119, Municipio = "Igarassu", EstadoId = 17 },

// Piauí
new Cidade { Id = 120, Municipio = "Teresina", EstadoId = 18 },
new Cidade { Id = 121, Municipio = "Parnaíba", EstadoId = 18 },
new Cidade { Id = 122, Municipio = "Picos", EstadoId = 18 },
new Cidade { Id = 123, Municipio = "Floriano", EstadoId = 18 },
new Cidade { Id = 124, Municipio = "Piripiri", EstadoId = 18 },
new Cidade { Id = 125, Municipio = "Campo Maior", EstadoId = 18 },
new Cidade { Id = 126, Municipio = "José de Freitas", EstadoId = 18 },

// Rio de Janeiro
new Cidade { Id = 127, Municipio = "Rio de Janeiro", EstadoId = 19 },
new Cidade { Id = 128, Municipio = "Niterói", EstadoId = 19 },
new Cidade { Id = 129, Municipio = "Duque de Caxias", EstadoId = 19 },
new Cidade { Id = 130, Municipio = "Nova Iguaçu", EstadoId = 19 },
new Cidade { Id = 131, Municipio = "Belford Roxo", EstadoId = 19 },
new Cidade { Id = 132, Municipio = "São Gonçalo", EstadoId = 19 },
new Cidade { Id = 133, Municipio = "Cabo Frio", EstadoId = 19 },

// Rio Grande do Norte
new Cidade { Id = 134, Municipio = "Natal", EstadoId = 20 },
new Cidade { Id = 135, Municipio = "Mossoró", EstadoId = 20 },
new Cidade { Id = 136, Municipio = "Parnamirim", EstadoId = 20 },
new Cidade { Id = 137, Municipio = "São Gonçalo do Amarante", EstadoId = 20 },
new Cidade { Id = 138, Municipio = "Macau", EstadoId = 20 },
new Cidade { Id = 139, Municipio = "Caicó", EstadoId = 20 },
new Cidade { Id = 140, Municipio = "Santa Cruz", EstadoId = 20 },

// Rio Grande do Sul
new Cidade { Id = 141, Municipio = "Porto Alegre", EstadoId = 21 },
new Cidade { Id = 142, Municipio = "Caxias do Sul", EstadoId = 21 },
new Cidade { Id = 143, Municipio = "Pelotas", EstadoId = 21 },
new Cidade { Id = 144, Municipio = "Santa Maria", EstadoId = 21 },
new Cidade { Id = 145, Municipio = "Viamão", EstadoId = 21 },
new Cidade { Id = 146, Municipio = "Gravataí", EstadoId = 21 },
new Cidade { Id = 147, Municipio = "Novo Hamburgo", EstadoId = 21 },

// Rondônia
new Cidade { Id = 148, Municipio = "Porto Velho", EstadoId = 22 },
new Cidade { Id = 149, Municipio = "Ji-Paraná", EstadoId = 22 },
new Cidade { Id = 150, Municipio = "Ariquemes", EstadoId = 22 },
new Cidade { Id = 151, Municipio = "Cacoal", EstadoId = 22 },
new Cidade { Id = 152, Municipio = "Rolim de Moura", EstadoId = 22 },
new Cidade { Id = 153, Municipio = "Vilhena", EstadoId = 22 },
new Cidade { Id = 154, Municipio = "Guajará-Mirim", EstadoId = 22 },

// Roraima
new Cidade { Id = 155, Municipio = "Boa Vista", EstadoId = 23 },
new Cidade { Id = 156, Municipio = "Rorainópolis", EstadoId = 23 },
new Cidade { Id = 157, Municipio = "Caracaraí", EstadoId = 23 },
new Cidade { Id = 158, Municipio = "Mucajaí", EstadoId = 23 },
new Cidade { Id = 159, Municipio = "Cantá", EstadoId = 23 },
new Cidade { Id = 160, Municipio = "Normandia", EstadoId = 23 },
new Cidade { Id = 161, Municipio = "São João da Baliza", EstadoId = 23 },

// Santa Catarina
new Cidade { Id = 162, Municipio = "Florianópolis", EstadoId = 24 },
new Cidade { Id = 163, Municipio = "Joinville", EstadoId = 24 },
new Cidade { Id = 164, Municipio = "Blumenau", EstadoId = 24 },
new Cidade { Id = 165, Municipio = "São José", EstadoId = 24 },
new Cidade { Id = 166, Municipio = "Criciúma", EstadoId = 24 },
new Cidade { Id = 167, Municipio = "Chapecó", EstadoId = 24 },
new Cidade { Id = 168, Municipio = "Lages", EstadoId = 24 },

// São Paulo
new Cidade { Id = 169, Municipio = "São Paulo", EstadoId = 25 },
new Cidade { Id = 170, Municipio = "Campinas", EstadoId = 25 },
new Cidade { Id = 171, Municipio = "São Bernardo do Campo", EstadoId = 25 },
new Cidade { Id = 172, Municipio = "Santo André", EstadoId = 25 },
new Cidade { Id = 173, Municipio = "São José dos Campos", EstadoId = 25 },
new Cidade { Id = 174, Municipio = "Ribeirão Preto", EstadoId = 25 },
new Cidade { Id = 175, Municipio = "Sorocaba", EstadoId = 25 },

// Sergipe
new Cidade { Id = 176, Municipio = "Aracaju", EstadoId = 26 },
new Cidade { Id = 177, Municipio = "Nossa Senhora do Socorro", EstadoId = 26 },
new Cidade { Id = 178, Municipio = "Lagarto", EstadoId = 26 },
new Cidade { Id = 179, Municipio = "Itabaiana", EstadoId = 26 },
new Cidade { Id = 180, Municipio = "Estância", EstadoId = 26 },
new Cidade { Id = 181, Municipio = "Propriá", EstadoId = 26 },
new Cidade { Id = 182, Municipio = "Japaratuba", EstadoId = 26 },

// Tocantins
new Cidade { Id = 183, Municipio = "Palmas", EstadoId = 27 },
new Cidade { Id = 184, Municipio = "Araguaína", EstadoId = 27 },
new Cidade { Id = 185, Municipio = "Gurupi", EstadoId = 27 },
new Cidade { Id = 186, Municipio = "Paraíso do Tocantins", EstadoId = 27 },
new Cidade { Id = 187, Municipio = "Porto Nacional", EstadoId = 27 },
new Cidade { Id = 188, Municipio = "Colinas do Tocantins", EstadoId = 27 },
new Cidade { Id = 189, Municipio = "Miracema do Tocantins", EstadoId = 27 }
            };

            await _context.Cidade.AddRangeAsync(cidades);
            await _context.SaveChangesAsync();

            Console.WriteLine($"{cidades.Count} cidades adicionadas.");
        }
        else
        {
            Console.WriteLine("As cidades já foram adicionadas anteriormente.");
        }
    }

    public async Task<List<Cidade>> ListarCidade(int estadoId)
    {
        try
        {
            var cidades = await _context.Cidade
                .Include(c => c.Estado) 
                .Where(c => c.EstadoId == estadoId)
                .ToListAsync();

            return cidades;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao carregar cidades: {ex.Message}");
            return new List<Cidade>();
        }
    }

    public async Task<List<Cidade>> ListarTodasCidades(int estadoId)
    {
        Console.WriteLine($"ListarTodasCidades chamado com estadoId: {estadoId}");

        try
        {
            var cidades = await _context.Cidade
                .Include(c => c.Estado)
                .Where(c => c.EstadoId == estadoId)
                .ToListAsync();

            Console.WriteLine($"Encontradas {cidades.Count} cidades para estadoId: {estadoId}");
            return cidades;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro em ListarTodasCidades: {ex.Message}");
            return new List<Cidade>();
        }
    }


    public async Task<List<Cidade>> BuscarCidadesPorNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("O nome da cidade não pode ser vazio.");
            return new List<Cidade>();
        }

        var cidades = await _context.Cidade
            .Include(c => c.Estado) 
            .Where(c => c.Municipio.Contains(nome))
            .ToListAsync();

        return cidades;
    }
}