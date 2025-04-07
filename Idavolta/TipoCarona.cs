using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idavolta
{
    public enum TipoCaronaGui
    {
        [Description("SemCarona")]
        SemCaronaGui,
        [Description("Ida")]
        IdaGui,
        [Description("Volta")]
        VoltaGui,
        [Description("IdaVolta")]
        IdaVoltaGui
    }

    public enum TipoCaronaKamile
    {
        [Description("SemCarona")]
        SemCaronaKamile,
        [Description("Ida")]
        IdaKamile,
        [Description("Volta")]
        VoltaKamile,
        [Description("IdaVolta")]
        IdaVoltaKamile,
    }

    public enum TipoCaronaRoger
    {
        [Description("SemCarona")]
        SemCaronaRoger,
        [Description("Ida")]
        IdaRoger,
        [Description("Volta")]
        VoltaRoger,
        [Description("IdaVolta")]
        IdaVoltaRoger
    }

    public enum TipoCaronaFelipe
    {
        [Description("SemCarona")]
        SemCaronaFelipe,
        [Description("Ida")]
        IdaFelipe,
        [Description("Volta")]
        VoltaFelipe,
        [Description("IdaVolta")]
        IdaVoltaFelipe
    }
}
