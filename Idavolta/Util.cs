using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
            CaminhoArquivoLog = caminhoArquivoLog;
            DiretorioArquivoExcel = diretorioArquivoExcel;
            NomeArquivoExcel = nomeArquivoExcel;
            ValorPassagemPadrao = Convert.ToDouble(valorPassagemPadrao);
        }
        #endregion

        public static void AlterarExcelDados(double valorPassagem, TipoCaronaGui TipodaCaronaGui, TipoCaronaKamile TipodaCaronaKamile, char Opcao = '1')
        {

            GravarLog("Criando ou alterando o arquivo Excel");

            double valorGui = valorPassagem;
            if (TipodaCaronaGui == TipoCaronaGui.IdaVoltaGui)
                valorGui += valorPassagem;

            double valorKamile = valorPassagem;
            if (TipodaCaronaKamile == TipoCaronaKamile.IdaVoltaKamile)
                valorKamile += valorPassagem;

            // Configurar o contexto de licença
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            if (File.Exists(DiretorioArquivoExcel + NomeArquivoExcel) && Opcao == '1')
            {
                // Se existir, abre o arquivo Excel existente e adiciona dados
                using (ExcelPackage package = new ExcelPackage(new FileInfo(DiretorioArquivoExcel + NomeArquivoExcel)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets["Planilha1"];
                    int linhaInicial = worksheet.Dimension.End.Row + 1;

                    worksheet.Cells[linhaInicial, 1].Value = DateTime.Now.ToString("dd/MM/yyyy");
                    worksheet.Cells[linhaInicial, 2].Value = valorGui;
                    worksheet.Cells[linhaInicial, 3].Value = valorKamile;


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
                    worksheet.Cells["D1"].Value = "";
                    worksheet.Cells["E1"].Value = "Valor da Passagem:";

                    worksheet.Cells[2, 1].Value = DateTime.Now.ToString("dd/MM/yyyy");
                    worksheet.Cells[2, 2].Value = valorGui;
                    worksheet.Cells[2, 3].Value = valorKamile;
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

        public static double LerOuCriarExcel()
        {
            // Configurar o contexto de licença
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            if (File.Exists(DiretorioArquivoExcel + NomeArquivoExcel))
            {
                // Se o arquivo existir, lê o valor da célula E2
                using (ExcelPackage package = new ExcelPackage(new FileInfo(DiretorioArquivoExcel + NomeArquivoExcel)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets["Planilha1"];
                    var valorPassagem = worksheet.Cells["F1"].Value;

                    if (valorPassagem != null && double.TryParse(valorPassagem.ToString(), out double valor))
                    {
                        Console.WriteLine($"Valor da Passagem lida: {valor}");
                        return valor;
                    }
                    else
                    {
                        Console.WriteLine("Valor da Passagem não encontrado ou inválido.");
                        return 0.0;
                    }
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
                    worksheet.Cells["D1"].Value = "";
                    worksheet.Cells["E1"].Value = "Valor da Passagem:";

                    worksheet.Cells["F1"].Value = ValorPassagemPadrao;

                    var fi = new FileInfo(DiretorioArquivoExcel + NomeArquivoExcel);
                    package.SaveAs(fi);

                    Console.WriteLine("Novo arquivo Excel criado com valor padrão na célula E2.");
                    return ValorPassagemPadrao;
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
    }
}
