using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idavolta
{
    public class BlocoCarona
    {
        public RadioButton radioIda { get; set; }
        public RadioButton radioVolta { get; set; }
        public RadioButton radioIdaVolta { get; set; }
        public Panel PanelContainer { get; set; }
        public Label labelNome { get; set; }

        public BlocoCarona(RadioButton ida, RadioButton volta, RadioButton idaVolta, Label nome)
        {
            radioIda = ida;
            radioVolta = volta;
            radioIdaVolta = idaVolta;
            labelNome = nome;
        }
    }

}
