using OfficeOpenXml;
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
        public static bool SomemteGui { get; set; }
        public static bool SomenteKamile { get; set; }
        #endregion

        #region CONSTRUTOR
        public Util(string caminhoArquivoLog, string diretorioArquivoExcel, string valorPassagemPadrao, string nomeArquivoExcel, bool somemteGui, bool somenteKamile)
        {
            int mes = DateTime.Now.Month;
            int ano = DateTime.Now.Year;
            string mesFormatado = mes < 10 ? "0" + mes : mes.ToString();

            CaminhoArquivoLog = caminhoArquivoLog;
            DiretorioArquivoExcel = diretorioArquivoExcel;
            NomeArquivoExcel = mesFormatado + "_" + ano + "_" + nomeArquivoExcel;
            ValorPassagemPadrao = Convert.ToDouble(valorPassagemPadrao);
            SomemteGui = somemteGui;
            SomenteKamile = somenteKamile;
        }
        #endregion

        public static void AlterarExcelDados(double valorPassagem, TipoCaronaGui TipodaCaronaGui, TipoCaronaKamile TipodaCaronaKamile, string DataCarona, char Opcao = '1')
        {
            GravarLog("Criando ou alterando o arquivo Excel");

            double valorGui = valorPassagem;
            if (TipodaCaronaGui == TipoCaronaGui.IdaVoltaGui)
                valorGui += valorPassagem;

            double valorKamile = valorPassagem;
            if (TipodaCaronaKamile == TipoCaronaKamile.IdaVoltaKamile)
                valorKamile += valorPassagem;

            string resumoCaronas = string.Empty;
            if (TipodaCaronaGui != TipoCaronaGui.SemCaronaGui)
            {
                resumoCaronas = "G:" + GetEnumDescription(TipodaCaronaGui);
            }
            if (TipodaCaronaKamile != TipoCaronaKamile.SemCaronaKamile)
            {
                if (string.IsNullOrEmpty(resumoCaronas))
                    resumoCaronas = "K:" + GetEnumDescription(TipodaCaronaKamile);
                else
                    resumoCaronas = resumoCaronas + " K:" + GetEnumDescription(TipodaCaronaKamile);
            }

            // Configurar o contexto de licença
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            if (File.Exists(DiretorioArquivoExcel + NomeArquivoExcel) && Opcao == '1')
            {
                // Se existir, abre o arquivo Excel existente e adiciona dados
                using (ExcelPackage package = new ExcelPackage(new FileInfo(DiretorioArquivoExcel + NomeArquivoExcel)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets["Planilha1"];
                    int linhaInicial = worksheet.Dimension.End.Row + 1;

                    worksheet.Cells[linhaInicial, 1].Value = DataCarona;
                    if (TipodaCaronaGui == TipoCaronaGui.SemCaronaGui)
                        worksheet.Cells[linhaInicial, 2].Value = "";
                    else
                        worksheet.Cells[linhaInicial, 2].Value = valorGui;

                    if (TipodaCaronaKamile == TipoCaronaKamile.SemCaronaKamile)
                        worksheet.Cells[linhaInicial, 3].Value = "";
                    else
                        worksheet.Cells[linhaInicial, 3].Value = valorKamile;

                    worksheet.Cells[linhaInicial, 4].Value = resumoCaronas;


                    package.Save();
                    Console.WriteLine("Arquivo Excel existente atualizado.");
                    GravarLog("Finalizado! Dados adicionados ao arquivo Excel existente!");
                }
            }
            else
            {
                // Se não existir, cria um novo arquivo Excel e adiciona dados
                using (ExcelPackage package = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Planilha1");

                    worksheet.Cells["A1"].Value = "Data";
                    worksheet.Cells["B1"].Value = "Guilherme";
                    worksheet.Cells["C1"].Value = "Kamile";
                    worksheet.Cells["D1"].Value = "Resumo das Caronas";
                    worksheet.Cells["E1"].Value = "Valor da Passagem:";

                    worksheet.Cells[2, 1].Value = DataCarona;
                    worksheet.Cells[2, 2].Value = valorGui;
                    worksheet.Cells[2, 3].Value = valorKamile;
                    worksheet.Cells[2, 4].Value = resumoCaronas;
                    worksheet.Cells[1, 6].Value = ValorPassagemPadrao;
                    

                    var fi = new FileInfo(DiretorioArquivoExcel + NomeArquivoExcel);
                    package.SaveAs(fi);

                    Console.WriteLine("Novo arquivo Excel criado.");
                    GravarLog("Finalizado! Dados já no novo arquivo Excel!");
                }
            }
        }

        public static void AlterarValorPassagemExcel(double valorPassagem)
        {

            GravarLog("Alterando Valor da Passagem Arquivo Excel");

            // Configurar o contexto de licença
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            if (File.Exists(DiretorioArquivoExcel + NomeArquivoExcel))
            {
                // Se existir, abre o arquivo Excel existente e adiciona dados
                using (ExcelPackage package = new ExcelPackage(new FileInfo(DiretorioArquivoExcel + NomeArquivoExcel)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets["Planilha1"];

                    worksheet.Cells[1, 6].Value = valorPassagem.ToString("F2");

                    package.Save();
                    Console.WriteLine("Arquivo Excel existente atualizado.");
                    GravarLog("Finalizado! Dados adicionados ao arquivo Excel existente!");
                }
            }
        }

        public static (double valoresGuilherme, double valoresKamile, double valorPassagem) LerOuCriarExcel()
        {
            // Configurar o contexto de licença
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            double sumGuilherme = 0;
            double sumKamile = 0;
            double valorPassagem = 0;

            int mes = DateTime.Now.Month;
            string mesFormatado = mes < 10 ? "0" + mes : mes.ToString();

            if (File.Exists(DiretorioArquivoExcel + NomeArquivoExcel))
            {
                // Se o arquivo existir
                using (ExcelPackage package = new ExcelPackage(new FileInfo(DiretorioArquivoExcel + NomeArquivoExcel)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets["Planilha1"];

                    // Calcular os valores para Guilherme e Kamile
                    int row = 2; // Inicia na segunda linha pois a primeira é o cabeçalho
                    while (worksheet.Cells[row, 2].Value != null || worksheet.Cells[row, 3].Value != null)
                    {
                        if (double.TryParse(worksheet.Cells[row, 2].Value?.ToString(), out double valorGuilherme))
                        {
                            sumGuilherme += valorGuilherme;
                        }

                        if (double.TryParse(worksheet.Cells[row, 3].Value?.ToString(), out double valorKamile))
                        {
                            sumKamile += valorKamile;
                        }

                        row++;
                    }

                    // Ler o valor da passagem
                    var valorPassagemCell = worksheet.Cells["F1"].Value;
                    if (valorPassagemCell != null && double.TryParse(valorPassagemCell.ToString(), out double valor))
                    {
                        valorPassagem = valor;
                    }

                    return (sumGuilherme, sumKamile, valorPassagem);
                }
            }
            else
            {
                // Se o arquivo não existir, cria um novo arquivo com o cabeçalho e valor padrão
                using (ExcelPackage package = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Planilha1");

                    worksheet.Cells["A1"].Value = "Data";
                    worksheet.Cells["B1"].Value = "Guilherme";
                    worksheet.Cells["C1"].Value = "Kamile";
                    worksheet.Cells["D1"].Value = "Resumo das Caronas";
                    worksheet.Cells["E1"].Value = "Valor da Passagem:";

                    worksheet.Cells["F1"].Value = ValorPassagemPadrao;

                    var fi = new FileInfo(DiretorioArquivoExcel + NomeArquivoExcel);
                    package.SaveAs(fi);

                    Console.WriteLine("Novo arquivo Excel criado com valor padrão na célula E2.");
                    return (0.0, 0.0, ValorPassagemPadrao);
                }
            }
        }

        public static void GravarLog(string mensagemLog)
        {
            try
            {
                int dia = DateTime.Now.Day;
                int mes = DateTime.Now.Month;

                // Adicionar um zero na frente do mês e dia se tiver apenas um caractere
                string mesFormatado = mes < 10 ? "0" + mes : mes.ToString();
                string diaFormatado = dia < 10 ? "0" + dia : dia.ToString();

                string CaminhoArqLogCompleto = CaminhoArquivoLog + "\\" + diaFormatado + "-" + mesFormatado + "_" + "ArquivoLog.txt";

                // Abre o arquivo para escrita (ou cria se não existir)
                using (StreamWriter writer = new StreamWriter(CaminhoArqLogCompleto, true))
                {
                    // Escreve a mensagem de log no arquivo
                    writer.WriteLine($"{DateTime.Now:dd/MM/yyyy HH:mm:ss} - {mensagemLog}");
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro, exibe a mensagem de exceção
                Console.WriteLine($"Erro ao gravar o log: {ex.Message}");
            }
        }

        public static DateTime DiaAnterior(DateTime data)
        {
            return data.AddDays(-1);
        }

        public static DateTime DiaSeguinte(DateTime data)
        {
            return data.AddDays(1);
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = (DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute));
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
