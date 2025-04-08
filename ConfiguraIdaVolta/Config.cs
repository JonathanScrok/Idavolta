using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguraIdaVolta
{
    public class AppSettings
    {
        public string Tema { get; set; }
        public string ValorPassagemPadrao { get; set; }
        public string SomemteGui { get; set; }
        public string SomenteKamile { get; set; }
        public string SomenteRoger { get; set; }
        public string SomenteFelipe { get; set; }
        public string SomenteRogerFelipe { get; set; }
        public string NomeArquivoExcel { get; set; }
        public string DiretorioArquivoExcel { get; set; }
        public string DiretorioLOG { get; set; }
    }

    public class Config
    {
        public AppSettings AppSettings { get; set; }
    }

}
