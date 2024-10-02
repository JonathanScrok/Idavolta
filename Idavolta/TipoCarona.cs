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
}
