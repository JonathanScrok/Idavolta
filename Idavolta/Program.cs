using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Idavolta
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region CARREGA AS CHAVES DO APPSETTINGS
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("Config/appsettings.json", optional: false, reloadOnChange: true)
            .Build();
            #endregion

            #region Par�metros AppSettings
            string DiretorioArquivoExcel = configuration.GetSection("AppSettings")["DiretorioArquivoExcel"];
            string DiretorioLOG = configuration.GetSection("AppSettings")["DiretorioLOG"];
            string ValorPassagemPadrao = configuration.GetSection("AppSettings")["ValorPassagemPadrao"];
            string NomeArquivoExcel = configuration.GetSection("AppSettings")["NomeArquivoExcel"];
            #endregion

            #region Inje��o de Dependencia

            Util ferramenta = new Util(DiretorioLOG, DiretorioArquivoExcel, ValorPassagemPadrao, NomeArquivoExcel);

            #endregion

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Main());
        }
    }
}