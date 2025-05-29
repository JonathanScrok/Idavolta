using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Idavolta
{
    public class Util
    {
        #region PARÂMETROS
        public static string CaminhoArquivoLog { get; set; }
        public static string DiretorioArquivoExcel { get; set; }
        public static string NomeArquivoExcel { get; set; }
        public static double ValorPassagemPadrao { get; set; }
        #endregion

        #region CONSTRUTOR
        public Util(string caminhoArquivoLog, string diretorioArquivoExcel, string valorPassagemPadrao, string nomeArquivoExcel)
        {
            int mes = DateTime.Now.Month;
            int ano = DateTime.Now.Year;
            string mesFormatado = mes < 10 ? "0" + mes : mes.ToString();

            CaminhoArquivoLog = caminhoArquivoLog + "\\";
            DiretorioArquivoExcel = diretorioArquivoExcel + "\\";
            NomeArquivoExcel = mesFormatado + "_" + ano + "_" + nomeArquivoExcel;
            ValorPassagemPadrao = Convert.ToDouble(valorPassagemPadrao);
        }
        #endregion

        #region MÉTODOS

        #region LER OU CRIAR O EXECEL
        public static (Dictionary<string, double> valoresPorPessoa, double valorPassagem) LerOuCriarExcelDinamico(List<string> nomes)
        {
            try
            {
                ExcelPackage.License.SetNonCommercialPersonal("Ida Volta");

                Dictionary<string, double> valores = nomes.ToDictionary(nome => nome, nome => 0.0);
                double valorPassagem = 0;

                string caminhoCompleto = Path.Combine(DiretorioArquivoExcel, NomeArquivoExcel);
                if (File.Exists(caminhoCompleto))
                {
                    using (var package = new ExcelPackage(new FileInfo(caminhoCompleto)))
                    {
                        var worksheet = package.Workbook.Worksheets["Planilha1"];
                        int row = 2;

                        while (worksheet.Cells[row, 1].Value != null)
                        {
                            for (int i = 0; i < nomes.Count; i++)
                            {
                                object cellVal = worksheet.Cells[row, i + 2].Value;
                                if (cellVal != null && double.TryParse(cellVal.ToString(), out double valor))
                                {
                                    valores[nomes[i]] += valor;
                                }
                            }
                            row++;
                        }

                        int ultimaColuna = worksheet.Dimension.End.Column;
                        var valorPassagemCell = worksheet.Cells[1, ultimaColuna].Value;

                        if (valorPassagemCell != null && double.TryParse(valorPassagemCell.ToString(), out double v))
                        {
                            valorPassagem = v;
                        }

                        return (valores, valorPassagem);
                    }
                }
                else
                {
                    using (var package = new ExcelPackage())
                    {
                        GravarLog("Criando novo Excel com nomes dinâmicos");

                        var worksheet = package.Workbook.Worksheets.Add("Planilha1");

                        // Cabeçalhos
                        worksheet.Cells[1, 1].Value = "Data";
                        for (int i = 0; i < nomes.Count; i++)
                        {
                            worksheet.Cells[1, i + 2].Value = nomes[i];
                        }
                        worksheet.Cells[1, nomes.Count + 2].Value = "Resumo das Caronas";
                        worksheet.Cells[1, nomes.Count + 3].Value = "Valor da Passagem:";
                        worksheet.Cells[1, nomes.Count + 4].Value = ValorPassagemPadrao;

                        // Estilo da primeira linha (cabeçalho)
                        using (var range = worksheet.Cells[1, 1, 1, nomes.Count + 4])
                        {
                            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 176, 80)); // Verde
                            range.Style.Font.Bold = true;
                            range.Style.Font.Color.SetColor(Color.Black);

                            // Bordas grossas em todas as laterais
                            range.Style.Border.Top.Style = ExcelBorderStyle.Thick;
                            range.Style.Border.Left.Style = ExcelBorderStyle.Thick;
                            range.Style.Border.Right.Style = ExcelBorderStyle.Thick;
                            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;

                            range.Style.Border.Top.Color.SetColor(Color.Black);
                            range.Style.Border.Left.Color.SetColor(Color.Black);
                            range.Style.Border.Right.Color.SetColor(Color.Black);
                            range.Style.Border.Bottom.Color.SetColor(Color.Black);
                        }


                        // Autoajuste das colunas
                        worksheet.Cells.AutoFitColumns();

                        // Salvar arquivo
                        var fi = new FileInfo(caminhoCompleto);
                        package.SaveAs(fi);

                        return (valores, ValorPassagemPadrao);
                    }
                }
            }
            catch (Exception ex)
            {
                GravarLog("Erro em LerOuCriarExcelDinamico(): " + ex.Message);
                throw;
            }
        }
        #endregion

        #region ALTERA O ARQUIVO EXCEL
        public static bool AlterarExcelDadosDinamico(Dictionary<string, TipoCarona> caronasSelecionadas, double valorPassagem, List<string> nomesCaronas, string DataCarona)
        {
            try
            {
                // Configurar o contexto de licença
                ExcelPackage.License.SetNonCommercialPersonal("Ida Volta");

                string caminhoCompleto = Path.Combine(DiretorioArquivoExcel, NomeArquivoExcel);
                var fileInfo = new FileInfo(caminhoCompleto);

                using (var package = new ExcelPackage(fileInfo))
                {
                    var worksheet = package.Workbook.Worksheets["Planilha1"];

                    // Descobrir a próxima linha vazia
                    int novaLinha = worksheet.Dimension?.End.Row + 1 ?? 2;

                    // Inserir data
                    worksheet.Cells[novaLinha, 1].Value = DataCarona; //DATAESCOLHIDA

                    // Preencher valores para cada nome dinamicamente
                    for (int i = 0; i < nomesCaronas.Count; i++)
                    {
                        string nome = nomesCaronas[i];
                        TipoCarona tipo = caronasSelecionadas.ContainsKey(nome) ? caronasSelecionadas[nome] : TipoCarona.Nenhum;

                        double valor = tipo switch
                        {
                            TipoCarona.Ida => valorPassagem,
                            TipoCarona.Volta => valorPassagem,
                            TipoCarona.IdaVolta => valorPassagem * 2,
                            _ => 0
                        };

                        worksheet.Cells[novaLinha, i + 2].Value = valor;
                    }

                    // Coluna de resumo
                    string resumo = string.Join(" | ", caronasSelecionadas
                        .Where(p => p.Value != TipoCarona.Nenhum)
                        .Select(p => $"{p.Key}: {p.Value}"));

                    worksheet.Cells[novaLinha, nomesCaronas.Count + 2].Value = resumo;

                    // Atualizar o valor da passagem
                    worksheet.Cells[1, nomesCaronas.Count + 4].Value = valorPassagem;

                    package.Save();
                }

                return true;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Feche a janela do arquivo Excel!", "Arquivo em uso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GravarLog("Erro: Arquivo em uso. Não foi possível salvar.");
                return false;
            }
            catch (Exception ex)
            {
                GravarLog("Erro ao alterar Excel dinamicamente: " + ex.Message);
                throw;
            }
        }
        #endregion

        #region ALTERAR O VALOR DA PASSAGEM
        public static bool AlterarValorPassagemExcel(double novoValorPassagem, out double valorPassagemAnterior)
        {
            valorPassagemAnterior = 0;
            try
            {
                GravarLog("Alterando Valor da Passagem Arquivo Excel");

                // Configurar o contexto de licença
                ExcelPackage.License.SetNonCommercialPersonal("Ida Volta");

                if (File.Exists(DiretorioArquivoExcel + NomeArquivoExcel))
                {
                    // Se existir, abre o arquivo Excel existente e adiciona dados
                    using (ExcelPackage package = new ExcelPackage(new FileInfo(DiretorioArquivoExcel + NomeArquivoExcel)))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets["Planilha1"];

                        // Busca a última coluna preenchida na linha 1
                        int ultimaColuna = worksheet.Dimension.End.Column;
                        var valorPassagemCell = worksheet.Cells[1, ultimaColuna].Value;

                        if (valorPassagemCell != null && double.TryParse(valorPassagemCell.ToString(), out double v))
                        {
                            valorPassagemAnterior = v;
                        }

                        worksheet.Cells[1, ultimaColuna].Value = novoValorPassagem.ToString("F2");

                        package.Save();
                        GravarLog("Finalizado! Dados adicionados ao arquivo Excel existente!");
                    }

                    return true;
                }

                return false;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Feche a janela do arquivo Excel!", "Arquivo em uso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GravarLog("Erro: Arquivo em uso. Não foi possível salvar.");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message);
                GravarLog("Erro no AlterarValorPassagemExcel(): " + ex.Message);
                throw;
            }
        }
        #endregion

        #region GRAVA LOG
        public static void GravarLog(string mensagemLog)
        {
            try
            {
                int dia = DateTime.Now.Day;
                int mes = DateTime.Now.Month;

                // Adicionar um zero na frente do mês e dia se tiver apenas um caractere
                string mesFormatado = mes < 10 ? "0" + mes : mes.ToString();
                string diaFormatado = dia < 10 ? "0" + dia : dia.ToString();

                string CaminhoArqLogCompleto = CaminhoArquivoLog + diaFormatado + "-" + mesFormatado + "_" + "ArquivoLog.txt";

                // Abre o arquivo para escrita (ou cria se não existir)
                using (StreamWriter writer = new StreamWriter(CaminhoArqLogCompleto, true))
                {
                    // Escreve a mensagem de log no arquivo
                    writer.WriteLine($"{DateTime.Now:dd/MM/yyyy HH:mm:ss} - {mensagemLog}");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region CARREGA O DIA ANTERIOR
        public static DateTime DiaAnterior(DateTime data)
        {
            return data.AddDays(-1);
        }
        #endregion

        #region CARREGA O DIA SEGUINTE
        public static DateTime DiaSeguinte(DateTime data)
        {
            return data.AddDays(1);
        }
        #endregion

        #region CARREGA A DESCRIÇÃO DO ENUM
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = (DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute));
            return attribute == null ? value.ToString() : attribute.Description;
        }
        #endregion

        #endregion
    }
}
