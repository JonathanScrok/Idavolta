namespace Idavolta
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtboxDatadeHoje.Text = DateTime.Now.ToString("dd/MM/yyyy");

            txtboxValorPassagem.Text = Util.LerOuCriarExcel().ToString("F2");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (btnAlterar.Text == "Salvar")
            {
                //Salvar Valor da Passagem

                Util.AlterarValorPassagemExcel(Convert.ToDouble(txtboxValorPassagem.Text));

                txtboxValorPassagem.Enabled = false;
                txtboxValorPassagem.ReadOnly = true;

                btnAlterar.Text = "Alterar";
            }
            else
            {
                txtboxValorPassagem.Enabled = true;
                txtboxValorPassagem.ReadOnly = false;

                btnAlterar.Text = "Salvar";
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            TipoCaronaGui guilhermeSelection = TipoCaronaGui.SemCaronaGui;
            TipoCaronaKamile kamileSelection = TipoCaronaKamile.SemCaronaKamile;

            // Verificar qual RadioButton está marcado para Guilherme
            if (radiobtnIdaGui.Checked)
            {
                guilhermeSelection = TipoCaronaGui.IdaGui;
            }
            else if (radiobtnVoltaGui.Checked)
            {
                guilhermeSelection = TipoCaronaGui.VoltaGui;
            }
            else if (radiobtnIdaVoltaGui.Checked)
            {
                guilhermeSelection = TipoCaronaGui.IdaVoltaGui;
            }

            // Verificar qual RadioButton está marcado para Kamile
            if (radiobtnIdaKamile.Checked)
            {
                kamileSelection = TipoCaronaKamile.IdaKamile;
            }
            else if (radiobtnVoltaKamile.Checked)
            {
                kamileSelection = TipoCaronaKamile.VoltaKamile;
            }
            else if (radiobtnIdaVoltaKamile.Checked)
            {
                kamileSelection = TipoCaronaKamile.IdaVoltaKamile;
            }

            Util.AlterarExcelDados(Convert.ToDouble(txtboxValorPassagem.Text), guilhermeSelection, kamileSelection, txtboxDatadeHoje.Text);
        }
    }
}
