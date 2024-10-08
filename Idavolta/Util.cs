﻿using OfficeOpenXml;
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

            CaminhoArquivoLog = caminhoArquivoLog + "\\";
            DiretorioArquivoExcel = diretorioArquivoExcel + "\\";
            NomeArquivoExcel = mesFormatado + "_" + ano + "_" + nomeArquivoExcel;
            ValorPassagemPadrao = Convert.ToDouble(valorPassagemPadrao);
            SomemteGui = somemteGui;
            SomenteKamile = somenteKamile;
        }
        #endregion

        #region MÉTODOS

        #region LER OU CRIAR O EXECEL
        public static (double valoresGuilherme, double valoresKamile, double valorPassagem) LerOuCriarExcel()
        {
            try
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
                        GravarLog("Criando o novo arquivo Excel!");
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Planilha1");

                        worksheet.Cells["A1"].Value = "Data";
                        worksheet.Cells["B1"].Value = "Guilherme";
                        worksheet.Cells["C1"].Value = "Kamile";
                        worksheet.Cells["D1"].Value = "Resumo das Caronas";
                        worksheet.Cells["E1"].Value = "Valor da Passagem:";

                        worksheet.Cells["F1"].Value = ValorPassagemPadrao;

                        var fi = new FileInfo(DiretorioArquivoExcel + NomeArquivoExcel);
                        package.SaveAs(fi);
                        GravarLog("Fim da criação do novo arquivo Excel!");

                        return (0.0, 0.0, ValorPassagemPadrao);
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
        public static void AlterarExcelDados(double valorPassagem, TipoCaronaGui TipodaCaronaGui, TipoCaronaKamile TipodaCaronaKamile, string DataCarona, double valorTotalAnteriorGui, double valorTotalAnteriorKamile, out double valorKamile, out double valorGui, char Opcao = '1')
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

                        worksheet.Cells[linhaInicial, 4].Value = resumoCaronas;

                        if (valorTotalAnteriorGui > 0 || valorGui > 0)
                            worksheet.Cells[1, 7].Value = "VALOR TOTAL GUI: " + (valorTotalAnteriorGui + valorGui).ToString("F2");

                        if (valorTotalAnteriorKamile > 0 || valorKamile > 0)
                            worksheet.Cells[1, 8].Value = "VALOR TOTAL KAMILE: " + (valorTotalAnteriorKamile + valorKamile).ToString("F2");

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
                        worksheet.Cells["D1"].Value = "Resumo das Caronas";
                        worksheet.Cells["E1"].Value = "Valor da Passagem:";

                        worksheet.Cells[2, 1].Value = DataCarona;
                        worksheet.Cells[2, 2].Value = valorGui;
                        worksheet.Cells[2, 3].Value = valorKamile;
                        worksheet.Cells[2, 4].Value = resumoCaronas;
                        worksheet.Cells[1, 6].Value = ValorPassagemPadrao;

                        if (valorTotalAnteriorGui > 0 || valorGui > 0)
                            worksheet.Cells[1, 7].Value = "VALOR TOTAL GUI: " + (valorTotalAnteriorGui + valorGui).ToString("F2");

                        if (valorTotalAnteriorKamile > 0 || valorKamile > 0)
                            worksheet.Cells[1, 8].Value = "VALOR TOTAL KAMILE: " + (valorTotalAnteriorKamile + valorKamile).ToString("F2");



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

                        worksheet.Cells[1, 6].Value = valorPassagem.ToString("F2");

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
