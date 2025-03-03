using GestaoConcurso.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace GestaoConcurso.Utilitarios
{
    public class RelatorioNotas
    {
        public async Task GerarNotasAprovados(List<Candidato> candidato, List<Concurso> concursos, DataTable aprovados, NavigationManager nav, IJSRuntime jsRuntime)
        {
            try
            {
                // Caminho para o arquivo .frx
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Relatorio\RelatorioNotasAprovados.frx");

                // Verifica se a pasta existe, caso contrário, cria
                var directoryPath = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                    Console.WriteLine($"Pasta criada: {directoryPath}");
                }

                if (!File.Exists(filePath))
                {
                    var report = new FastReport.Report();
                    report.Dictionary.RegisterBusinessObject(candidato, "candidato", 10, true);
                    report.Dictionary.RegisterBusinessObject(concursos, "concursos", 10, true);
                    var aprovadosList = aprovados.AsEnumerable().Select(row => new
                    {
                        Inscricao = row.Field<Inscricao>("Inscricao"),
                        Nota = row.Field<decimal>("Nota")
                    }).ToList();
                    report.Dictionary.RegisterBusinessObject(aprovadosList, "aprovados", 10, true);
                    report.Report.Save(filePath);
                    Console.WriteLine("Arquivo .frx criado com sucesso.");
                }

                var report1 = new FastReport.Report();
                report1.Report.Load(filePath);
                report1.Dictionary.RegisterBusinessObject(candidato, "candidato", 10, true);
                report1.Dictionary.RegisterBusinessObject(concursos, "concursos", 10, true);

                // Converter DataTable para lista de objetos anônimos
                var aprovadosLista = aprovados.AsEnumerable().Select(row => new
                {
                    Inscricao = row.Field<Inscricao>("Inscricao"),
                    Nota = row.Field<decimal>("Nota")
                }).ToList();

                report1.Dictionary.RegisterBusinessObject(aprovadosLista, "aprovados", 10, true);
                report1.Prepare();

                using var pdfExport = new FastReport.Export.PdfSimple.PDFSimpleExport();
                using var reportStream = new MemoryStream();
                pdfExport.Export(report1, reportStream);

                var fileName = $"RelatorioNotasAprovados_{Guid.NewGuid()}.pdf";
                var filePathTemp = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "RelatoriosTemp", fileName);

                // Cria a pasta se não existir
                Directory.CreateDirectory(Path.GetDirectoryName(filePathTemp));

                // Salva o arquivo PDF temporariamente na pasta wwwroot/RelatoriosTemp
                File.WriteAllBytes(filePathTemp, reportStream.ToArray());

                // Gera a URL para o arquivo temporário
                var url = nav.ToAbsoluteUri($"/RelatoriosTemp/{fileName}");

                // Abre o relatório em uma nova guia
                await jsRuntime.InvokeVoidAsync("NovaGuia", url.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gerar relatório: {ex.Message}");
                throw;
            }
        }
    }
}