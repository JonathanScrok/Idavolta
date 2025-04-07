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
        public static bool SomemteGui { get; set; }
        public static bool SomenteKamile { get; set; }
        public static bool SomenteRoger { get; set; }
        public static bool SomenteFelipe { get; set; }
        public static bool SomenteRogerFelipe { get; set; }
        #endregion

        #region CONSTRUTOR
        public Util(string caminhoArquivoLog, string diretorioArquivoExcel, string valorPassagemPadrao, string nomeArquivoExcel, bool somemteGui, bool somenteKamile, bool somenteRoger, bool somenteFelipe, bool somenteRogerFelipe)
        {
            int mes = DateTime.Now.Month;
            int ano = DateTime.Now.Year;
            string mesFormatado = mes < 10 ? "0" + mes : mes.ToString();

            CaminhoArquivoLog = caminhoArquivoLog + "\\";
            DiretorioArquivoExcel = diretorioArquivoExcel + "\\";
            NomeArquivoExcel = mesFormatado + "_" + ano + "_" + nomeArquivoExcel;
            ValorPassagemPadrao = Convert.ToDouble(valorPassagemPadrao);
            SomemteGui = somemteGui;
            SomenteKamile = somenteKamile;
            SomenteRoger = somenteRoger;
            SomenteFelipe = somenteFelipe;
            SomenteRogerFelipe = somenteRogerFelipe;
        }
        #endregion

        #region MÉTODOS

        #region LER OU CRIAR O EXECEL
        public static (double valoresGuilherme, double valoresKamile, double valoresRoger, double valoresFelipe, double valorPassagem) LerOuCriarExcel()
        {
            try
            {
                // Configurar o contexto de licença
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                double sumGuilherme = 0;
                double sumKamile = 0;
                double sumRoger = 0;
                double sumFelipe = 0;
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

                            if (double.TryParse(worksheet.Cells[row, 4].Value?.ToString(), out double valorRoger))
                            {
                                sumRoger += valorRoger;
                            }

                            if (double.TryParse(worksheet.Cells[row, 5].Value?.ToString(), out double valorFelipe))
                            {
                                sumFelipe += valorFelipe;
                            }

                            row++;
                        }

                        // Ler o valor da passagem
                        var valorPassagemCell = worksheet.Cells["H1"].Value;
                        if (valorPassagemCell != null && double.TryParse(valorPassagemCell.ToString(), out double valor))
                        {
                            valorPassagem = valor;
                        }

                        return (sumGuilherme, sumKamile, sumRoger, sumFelipe, valorPassagem);
                    }
                }
                else
                {
                    // Se o arquivo não existir, cria um novo arquivo com o cabeçalho e valor padrão
                    using (ExcelPackage package = new ExcelPackage())
                    {
                        GravarLog("Criando o novo arquivo Excel!");
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Planilha1");

                        worksheet.Cells["A1"].Value = "Data";
                        worksheet.Cells["B1"].Value = "Guilherme";
                        worksheet.Cells["C1"].Value = "Kamile";
                        worksheet.Cells["D1"].Value = "Roger";
                        worksheet.Cells["E1"].Value = "Felipe";
                        worksheet.Cells["F1"].Value = "Resumo das Caronas";
                        worksheet.Cells["G1"].Value = "Valor da Passagem:";
                        worksheet.Cells["H1"].Value = ValorPassagemPadrao;

                        #region PERSONALIZAÇÃO COLUNAS EXCEL 
                        // Definir largura das colunas
                        worksheet.Column(1).Width = 11; // A - Data
                        worksheet.Column(2).Width = 11; // B - Guilherme
                        worksheet.Column(3).Width = 10; // C - Kamile
                        worksheet.Column(4).Width = 9; // D - Roger
                        worksheet.Column(5).Width = 9; // E - Felipe
                        worksheet.Column(6).Width = 20; // F - Resumo das Caronas
                        worksheet.Column(7).Width = 18; // G - Valor da Passagem
                        worksheet.Column(8).Width = 5; // H - Valor da passagem armazenado

                        // Aplicar estilo ao cabeçalho
                        worksheet.Cells["A1:H1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells["A1:H1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        worksheet.Cells["A1:H1"].Style.Font.Bold = true;
                        worksheet.Cells["A1:H1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells["A1:H1"].Style.Fill.BackgroundColor.SetColor(Color.LimeGreen);

                        // Aplicar bordas a todas as células usadas (por enquanto só o cabeçalho)
                        using (ExcelRange range = worksheet.Cells["A1:H1"])
                        {
                            range.Style.Border.Top.Style = ExcelBorderStyle.Thick;
                            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                            range.Style.Border.Left.Style = ExcelBorderStyle.Thick;
                            range.Style.Border.Right.Style = ExcelBorderStyle.Thick;

                            range.Style.Border.Top.Color.SetColor(Color.Black);
                            range.Style.Border.Bottom.Color.SetColor(Color.Black);
                            range.Style.Border.Left.Color.SetColor(Color.Black);
                            range.Style.Border.Right.Color.SetColor(Color.Black);
                        }
                        #endregion

                        var fi = new FileInfo(DiretorioArquivoExcel + NomeArquivoExcel);
                        package.SaveAs(fi);
                        GravarLog("Fim da criação do novo arquivo Excel!");

                        return (0.0, 0.0, 0.0, 0.0, ValorPassagemPadrao);
                    }
                }
            }
            catch (Exception ex)
            {
                GravarLog("Erro no LerOuCriarExcel(): " + ex.Message);
                throw;
            }
        }
        #endregion

        #region ALTERA O ARQUIVO EXCEL
        public static void AlterarExcelDados(double valorPassagem, TipoCaronaGui TipodaCaronaGui, TipoCaronaKamile TipodaCaronaKamile, TipoCaronaRoger TipodaCaronaRoger, TipoCaronaFelipe TipodaCaronaFelipe, string DataCarona, double valorTotalAnteriorGui, double valorTotalAnteriorKamile, double valorTotalAnteriorRoger, double valorTotalAnteriorFelipe, out double valorKamile, out double valorGui, out double valorRoger, out double valorFelipe, char Opcao = '1')
        {
            try
            {
                valorGui = valorPassagem;
                if (TipodaCaronaGui == TipoCaronaGui.IdaVoltaGui)
                    valorGui += valorPassagem;
                else if (TipodaCaronaGui == TipoCaronaGui.SemCaronaGui)
                    valorGui = 0;

                valorKamile = valorPassagem;
                if (TipodaCaronaKamile == TipoCaronaKamile.IdaVoltaKamile)
                    valorKamile += valorPassagem;
                else if (TipodaCaronaKamile == TipoCaronaKamile.SemCaronaKamile)
                    valorKamile = 0;

                valorRoger = valorPassagem;
                if (TipodaCaronaRoger == TipoCaronaRoger.IdaVoltaRoger)
                    valorRoger += valorPassagem;
                else if (TipodaCaronaRoger == TipoCaronaRoger.SemCaronaRoger)
                    valorRoger = 0;

                valorFelipe = valorPassagem;
                if (TipodaCaronaFelipe == TipoCaronaFelipe.IdaVoltaFelipe)
                    valorFelipe += valorPassagem;
                else if (TipodaCaronaFelipe == TipoCaronaFelipe.SemCaronaFelipe)
                    valorFelipe = 0;

                string resumoCaronas = string.Empty;
                if (TipodaCaronaGui != TipoCaronaGui.SemCaronaGui)
                {
                    resumoCaronas = "G:" + GetEnumDescription(TipodaCaronaGui);
                }
                if (TipodaCaronaKamile != TipoCaronaKamile.SemCaronaKamile)
                {
                    resumoCaronas = "K:" + GetEnumDescription(TipodaCaronaKamile);
                }
                if (TipodaCaronaRoger != TipoCaronaRoger.SemCaronaRoger)
                {
                    resumoCaronas = "R:" + GetEnumDescription(TipodaCaronaRoger);
                }
                if (TipodaCaronaFelipe != TipoCaronaFelipe.SemCaronaFelipe)
                {
                    if (string.IsNullOrEmpty(resumoCaronas))
                        resumoCaronas = "F:" + GetEnumDescription(TipodaCaronaFelipe);
                    else
                        resumoCaronas = resumoCaronas + " F:" + 
                            GetEnumDescription(TipodaCaronaFelipe);
                }

                // Configurar o contexto de licença
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                if (File.Exists(DiretorioArquivoExcel + NomeArquivoExcel) && Opcao == '1')
                {
                    GravarLog("Alterando o arquivo Excel");

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

                        if (TipodaCaronaRoger == TipoCaronaRoger.SemCaronaRoger)
                            worksheet.Cells[linhaInicial, 4].Value = "";
                        else
                            worksheet.Cells[linhaInicial, 4].Value = valorRoger;

                        if (TipodaCaronaFelipe == TipoCaronaFelipe.SemCaronaFelipe)
                            worksheet.Cells[linhaInicial, 5].Value = "";
                        else
                            worksheet.Cells[linhaInicial, 5].Value = valorFelipe;

                        worksheet.Cells[linhaInicial, 6].Value = resumoCaronas;

                        if (valorTotalAnteriorFelipe > 0 || valorFelipe > 0)
                        {
                            worksheet.Cells[1, 10].Value = "VALOR TOTAL FELIPE: " + (valorTotalAnteriorFelipe + valorFelipe).ToString("F2");
                            worksheet.Column(10).Width = 26;
                            worksheet.Cells["J1"].Style.Font.Bold = true;
                            worksheet.Cells["J1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells["J1"].Style.Fill.BackgroundColor.SetColor(Color.Orange);
                        }

                        if (valorTotalAnteriorRoger > 0 || valorRoger > 0)
                        {
                            worksheet.Cells[1, 11].Value = "VALOR TOTAL ROGER: " + (valorTotalAnteriorRoger + valorRoger).ToString("F2");
                            worksheet.Column(11).Width = 26;
                            worksheet.Cells["K1"].Style.Font.Bold = true;
                            worksheet.Cells["K1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells["K1"].Style.Fill.BackgroundColor.SetColor(Color.Orange);
                        }

                        if (valorTotalAnteriorGui > 0 || valorGui > 0)
                            worksheet.Cells[1, 12].Value = "VALOR TOTAL GUI: " + (valorTotalAnteriorGui + valorGui).ToString("F2");

                        if (valorTotalAnteriorKamile > 0 || valorKamile > 0)
                            worksheet.Cells[1, 13].Value = "VALOR TOTAL KAMILE: " + (valorTotalAnteriorKamile + valorKamile).ToString("F2");

                        package.Save();
                        GravarLog("Finalizado! Dados adicionados ao arquivo Excel existente!");
                    }
                }
                else
                {
                    // Se não existir, cria um novo arquivo Excel e adiciona dados
                    using (ExcelPackage package = new ExcelPackage())
                    {
                        GravarLog("Criando o arquivo Excel");
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Planilha1");

                        worksheet.Cells["A1"].Value = "Data";
                        worksheet.Cells["B1"].Value = "Guilherme";
                        worksheet.Cells["C1"].Value = "Kamile";
                        worksheet.Cells["D1"].Value = "Roger";
                        worksheet.Cells["E1"].Value = "Felipe";
                        worksheet.Cells["F1"].Value = "Resumo das Caronas";
                        worksheet.Cells["G1"].Value = "Valor da Passagem:";
                        worksheet.Cells["H1"].Value = ValorPassagemPadrao;

                        worksheet.Cells[2, 1].Value = DataCarona;
                        worksheet.Cells[2, 2].Value = valorGui;
                        worksheet.Cells[2, 3].Value = valorKamile;
                        worksheet.Cells[2, 4].Value = valorRoger;
                        worksheet.Cells[2, 5].Value = valorFelipe;
                        worksheet.Cells[2, 6].Value = resumoCaronas;

                        if (valorTotalAnteriorFelipe > 0 || valorFelipe > 0)
                        {
                            worksheet.Cells[1, 10].Value = "VALOR TOTAL FELIPE: " + (valorTotalAnteriorFelipe + valorFelipe).ToString("F2");
                            worksheet.Column(10).Width = 26;
                            worksheet.Cells["J1"].Style.Font.Bold = true;
                            worksheet.Cells["J1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells["J1"].Style.Fill.BackgroundColor.SetColor(Color.Orange);
                        }

                        if (valorTotalAnteriorRoger > 0 || valorRoger > 0)
                        {
                            worksheet.Cells[1, 11].Value = "VALOR TOTAL ROGER: " + (valorTotalAnteriorRoger + valorRoger).ToString("F2");
                            worksheet.Column(11).Width = 26;
                            worksheet.Cells["K1"].Style.Font.Bold = true;
                            worksheet.Cells["K1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells["K1"].Style.Fill.BackgroundColor.SetColor(Color.Orange);
                        }

                        if (valorTotalAnteriorGui > 0 || valorGui > 0)
                            worksheet.Cells[1, 12].Value = "VALOR TOTAL GUI: " + (valorTotalAnteriorGui + valorGui).ToString("F2");

                        if (valorTotalAnteriorKamile > 0 || valorKamile > 0)
                            worksheet.Cells[1, 13].Value = "VALOR TOTAL KAMILE: " + (valorTotalAnteriorKamile + valorKamile).ToString("F2");

                        #region PERSONALIZAÇÃO COLUNAS EXCEL 
                        // Definir largura das colunas
                        worksheet.Column(1).Width = 11; // A - Data
                        worksheet.Column(2).Width = 10; // B - Guilherme
                        worksheet.Column(3).Width = 10; // C - Kamile
                        worksheet.Column(4).Width = 9; // D - Roger
                        worksheet.Column(5).Width = 9; // E - Felipe
                        worksheet.Column(6).Width = 19; // F - Resumo das Caronas
                        worksheet.Column(7).Width = 18; // G - Valor da Passagem
                        worksheet.Column(8).Width = 5; // H - Valor da passagem armazenado

                        // Aplicar estilo ao cabeçalho
                        worksheet.Cells["A1:H1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells["A1:H1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        worksheet.Cells["A1:H1"].Style.Font.Bold = true;
                        worksheet.Cells["A1:H1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells["A1:H1"].Style.Fill.BackgroundColor.SetColor(Color.LightGray);

                        // Aplicar bordas a todas as células usadas (por enquanto só o cabeçalho)
                        using (ExcelRange range = worksheet.Cells["A1:H1"])
                        {
                            range.Style.Border.Top.Style = ExcelBorderStyle.Thick;
                            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                            range.Style.Border.Left.Style = ExcelBorderStyle.Thick;
                            range.Style.Border.Right.Style = ExcelBorderStyle.Thick;

                            range.Style.Border.Top.Color.SetColor(Color.Black);
                            range.Style.Border.Bottom.Color.SetColor(Color.Black);
                            range.Style.Border.Left.Color.SetColor(Color.Black);
                            range.Style.Border.Right.Color.SetColor(Color.Black);
                        }
                        #endregion

                        var fi = new FileInfo(DiretorioArquivoExcel + NomeArquivoExcel);
                        package.SaveAs(fi);

                        GravarLog("Finalizado! Dados já no novo arquivo Excel!");
                    }
                }
            }
            catch (Exception ex)
            {
                GravarLog("Erro no AlterarExcelDados(): " + ex.Message);
                throw;
            }
        }
        #endregion

        #region ALTERAR O VALOR DA PASSAGEM
        public static void AlterarValorPassagemExcel(double valorPassagem)
        {
            try
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

                        worksheet.Cells[1, 8].Value = valorPassagem.ToString("F2");

                        package.Save();
                        GravarLog("Finalizado! Dados adicionados ao arquivo Excel existente!");
                    }
                }
            }
            catch (Exception ex)
            {
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
