using System.Diagnostics;

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

            var valores = Util.LerOuCriarExcel();

            if (Util.SomemteGui)
            {
                groupBoxGuilherme.Location = new Point(307, 133);
                groupBoxKamile.Visible = false;
            }
            else if (Util.SomenteKamile)
            {
                groupBoxKamile.Location = new Point(307, 133);
                groupBoxGuilherme.Visible = false;
            }

            txtboxValorPassagem.Text = valores.valorPassagem.ToString("F2");
            lblValorTotalGui.Text = valores.valoresGuilherme.ToString("F2");
            lblValorTotalKamile.Text = valores.valoresKamile.ToString("F2");
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

        private async void btnSalvar_Click(object sender, EventArgs e)
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

            double valorGui = 0;
            double valorKamile = 0;
            Util.AlterarExcelDados(Convert.ToDouble(txtboxValorPassagem.Text), guilhermeSelection, kamileSelection, txtboxDatadeHoje.Text, Convert.ToDouble(lblValorTotalGui.Text), Convert.ToDouble(lblValorTotalKamile.Text), out valorKamile, out valorGui);

            double valorTotalGui = Convert.ToDouble(lblValorTotalGui.Text) + valorGui;
            double valorTotalKamile = Convert.ToDouble(lblValorTotalKamile.Text) + valorKamile;
            lblValorTotalGui.Text = valorTotalGui.ToString("F2");
            lblValorTotalKamile.Text = valorTotalKamile.ToString("F2");

            lblAviso.Text = "Sucesso!";
            lblAviso.ForeColor = Color.Green;
            lblAviso.Visible = true;
            await Task.Delay(2000); // Espera por 3 segundos
            lblAviso.Visible = false;
        }

        private void lblValorTotalGui_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string caminho = Util.DiretorioArquivoExcel;
            Process.Start("explorer.exe", caminho);
        }

        private void lblValorTotalKamile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string caminho = Util.DiretorioArquivoExcel;
            Process.Start("explorer.exe", caminho);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            txtboxDatadeHoje.Text = Util.DiaAnterior(Convert.ToDateTime(txtboxDatadeHoje.Text)).ToString("dd/MM/yyyy");
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            txtboxDatadeHoje.Text = Util.DiaSeguinte(Convert.ToDateTime(txtboxDatadeHoje.Text)).ToString("dd/MM/yyyy");
        }
    }
}
