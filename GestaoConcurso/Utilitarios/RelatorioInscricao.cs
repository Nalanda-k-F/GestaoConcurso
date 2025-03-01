using GestaoConcurso.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace GestaoConcurso.Utilitarios
{
    public class RelatorioInscricao
    {
        
            public async Task GerarImpressao(Candidato candidato, List<Concurso> concursos, List<List<Disciplina>> disciplinasPorConcurso, NavigationManager nav, IJSRuntime jsRuntime)
            {
                try
                {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Relatorio\RelatorioInscricao.frx");

                Console.WriteLine($"Verificando arquivo .frx: {filePath}");
                    if (!File.Exists(filePath))
                    {
                        Console.WriteLine("Arquivo .frx não encontrado, criando...");
                        var report = new FastReport.Report();
                        report.Dictionary.RegisterBusinessObject(new List<Candidato> { candidato }, "candidato", 10, true);
                        report.Dictionary.RegisterBusinessObject(concursos, "concursos", 10, true);
                        report.Dictionary.RegisterBusinessObject(disciplinasPorConcurso, "disciplinasPorConcurso", 10, true);
                        report.Report.Save(filePath);
                        Console.WriteLine("Arquivo .frx criado com sucesso.");
                    try
                    {
                        report.Report.Save(filePath);
                        Console.WriteLine("Arquivo .frx criado com sucesso.");
                    }
                    catch (Exception saveEx)
                    {
                        Console.WriteLine($"Erro ao salvar o arquivo .frx: {saveEx.Message}");
                     }
                     
                }

                    var report1 = new FastReport.Report();
                    report1.Report.Load(filePath);
                    report1.Dictionary.RegisterBusinessObject(new List<Candidato> { candidato }, "candidato", 10, true);
                    report1.Dictionary.RegisterBusinessObject(concursos, "concursos", 10, true);
                    report1.Dictionary.RegisterBusinessObject(disciplinasPorConcurso, "disciplinasPorConcurso", 10, true);
                    report1.Prepare();

                    using var pdfExport = new FastReport.Export.PdfSimple.PDFSimpleExport();
                    using var reportStream = new MemoryStream();
                    pdfExport.Export(report1, reportStream);

                    var fileName = $"RelatorioInscricao_{Guid.NewGuid()}.pdf";
                    var filePathTemp = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "RelatoriosTemp", fileName);

                    Directory.CreateDirectory(Path.GetDirectoryName(filePathTemp));
                    File.WriteAllBytes(filePathTemp, reportStream.ToArray());

                    var url = nav.ToAbsoluteUri($"/RelatoriosTemp/{fileName}");
                    await jsRuntime.InvokeVoidAsync("NovaGuia", url.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro aqui!: " + ex.Message);
                    throw new Exception(ex.Message);
                }
            }

        }
    }

