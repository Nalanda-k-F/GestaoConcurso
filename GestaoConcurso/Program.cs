using GestaoConcurso.Components;
using GestaoConcurso.Contexto;
using Microsoft.EntityFrameworkCore;
using GestaoConcurso.Controllers;

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
//

string mySqlConexao = builder.Configuration.GetConnectionString("BaseConexaoMySql");
builder.Services.AddDbContextPool<ContextoBD>(options =>
options.UseMySql(mySqlConexao, ServerVersion.AutoDetect(mySqlConexao)));

var app = builder.Build();

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
