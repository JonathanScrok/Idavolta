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
            try
            {
                #region CARREGA AS CHAVES DO APPSETTINGS
                IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("Config/appsettings.json", optional: false, reloadOnChange: true)
                .Build();
                #endregion

                #region Parâmetros AppSettings
                string Tema = configuration.GetSection("AppSettings")["Tema"];
                string DiretorioArquivoExcel = configuration.GetSection("AppSettings")["DiretorioArquivoExcel"];
                string DiretorioLOG = configuration.GetSection("AppSettings")["DiretorioLOG"];
                string ValorPassagemPadrao = configuration.GetSection("AppSettings")["ValorPassagemPadrao"];
                string NomeArquivoExcel = configuration.GetSection("AppSettings")["NomeArquivoExcel"];
                bool SomenteRogerFelipe = configuration.GetSection("AppSettings")["SomenteRogerFelipe"].ToUpper() == "S" ? true : false;
                bool SomenteFelipe = configuration.GetSection("AppSettings")["SomenteFelipe"].ToUpper() == "S" ? true : false;
                bool SomemteGui = configuration.GetSection("AppSettings")["SomemteGui"].ToUpper() == "S" ? true : false;
                bool SomenteKamile = configuration.GetSection("AppSettings")["SomenteKamile"].ToUpper() == "S" ? true : false;
                bool SomenteRoger = configuration.GetSection("AppSettings")["SomenteRoger"].ToUpper() == "S" ? true : false;
                #endregion

                #region Injeção de Dependencia

                new Util(DiretorioLOG,
                         DiretorioArquivoExcel,
                         ValorPassagemPadrao,
                         NomeArquivoExcel,
                         SomemteGui,
                         SomenteKamile,
                         SomenteRoger,
                         SomenteFelipe,
                         SomenteRogerFelipe);

                #endregion

                ApplicationConfiguration.Initialize();
                Application.Run(new Main(Tema));
            }
            catch (Exception ex)
            {
                Util.GravarLog("Erro ao executar: " + ex.Message);
                throw;
            }
        }
    }
}