using GestaoConcurso.Components;
using GestaoConcurso.Contexto;
using Microsoft.EntityFrameworkCore;
using GestaoConcurso.Controllers;
using GestaoConcurso.Utilitarios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//
builder.Services.AddScoped<CandidatoController>();
builder.Services.AddScoped<CidadeController>();
builder.Services.AddScoped<ConcursoController>();
builder.Services.AddScoped<ConcursoDisciplinaController>();
builder.Services.AddScoped<DisciplinaController>();
builder.Services.AddScoped<EnderecoController>();
builder.Services.AddScoped<EstadoController>();
builder.Services.AddScoped<InscricaoController>();
builder.Services.AddScoped<PontuacaoController>();

builder.Services.AddScoped<RelatorioInscricao>();
builder.Services.AddScoped<RelatorioNotas>();
//

string mySqlConexao = builder.Configuration.GetConnectionString("BaseConexaoMySql");
builder.Services.AddDbContextPool<ContextoBD>(options =>
options.UseMySql(mySqlConexao, ServerVersion.AutoDetect(mySqlConexao)));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ContextoBD>();
    await context.Database.MigrateAsync(); // Aplica migrações

    if (!context.Estado.Any())
    {
        var estadoController = services.GetRequiredService<EstadoController>();
        await estadoController.AdicionarEstados();
    }
    if (!context.Cidade.Any())
    {
        var cidadeController = services.GetRequiredService<CidadeController>();
        await cidadeController.AdicionarCidades();
    }
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
