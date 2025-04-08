using System.Diagnostics;

namespace Idavolta
{
    public partial class Main : Form
    {
        string TemaEscolhido { get; set; }

        public Main(string temaEscolhido)
        {
            TemaEscolhido = temaEscolhido;
            InitializeComponent();

            PersonalizarEstilo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                txtboxDatadeHoje.Text = DateTime.Now.ToString("dd/MM/yyyy");

                var valores = Util.LerOuCriarExcel();

                if (Util.SomemteGui)
                {
                    groupBoxGuilherme.Location = new Point(307, 133);
                    lblValorTotalGui.Location = new Point(344, 362);
                    lblTxtValorTotalGui.Location = new Point(344, 334);

                    groupBoxKamile.Visible = false;
                    lblTxtValorTotalKamile.Visible = false;
                    lblValorTotalKamile.Visible = false;

                    groupBoxFelipe.Visible = false;
                    lblTxtValorTotalFelipe.Visible = false;
                    lblValorTotalFelipe.Visible = false;

                    groupBoxRoger.Visible = false;
                    lblTxtValorTotalRoger.Visible = false;
                    lblValorTotalRoger.Visible = false;
                }
                else if (Util.SomenteKamile)
                {
                    groupBoxKamile.Location = new Point(307, 133);
                    lblValorTotalKamile.Location = new Point(344, 362);
                    lblTxtValorTotalKamile.Location = new Point(344, 334);

                    groupBoxGuilherme.Visible = false;
                    lblTxtValorTotalGui.Visible = false;
                    lblValorTotalGui.Visible = false;

                    groupBoxFelipe.Visible = false;
                    lblTxtValorTotalFelipe.Visible = false;
                    lblValorTotalFelipe.Visible = false;

                    groupBoxRoger.Visible = false;
                    lblTxtValorTotalRoger.Visible = false;
                    lblValorTotalRoger.Visible = false;
                }
                else if (Util.SomenteRoger)
                {
                    groupBoxRoger.Location = new Point(307, 133);
                    lblValorTotalRoger.Location = new Point(344, 362);
                    lblTxtValorTotalRoger.Location = new Point(344, 334);

                    groupBoxGuilherme.Visible = false;
                    lblTxtValorTotalGui.Visible = false;
                    lblValorTotalGui.Visible = false;

                    groupBoxKamile.Visible = false;
                    lblTxtValorTotalKamile.Visible = false;
                    lblValorTotalKamile.Visible = false;

                    groupBoxFelipe.Visible = false;
                    lblTxtValorTotalFelipe.Visible = false;
                    lblValorTotalFelipe.Visible = false;
                }
                else if (Util.SomenteFelipe)
                {
                    groupBoxFelipe.Location = new Point(322, 133);
                    lblValorTotalFelipe.Location = new Point(344, 362);
                    lblTxtValorTotalFelipe.Location = new Point(344, 334);

                    groupBoxGuilherme.Visible = false;
                    lblTxtValorTotalGui.Visible = false;
                    lblValorTotalGui.Visible = false;

                    groupBoxKamile.Visible = false;
                    lblTxtValorTotalKamile.Visible = false;
                    lblValorTotalKamile.Visible = false;

                    groupBoxRoger.Visible = false;
                    lblTxtValorTotalRoger.Visible = false;
                    lblValorTotalRoger.Visible = false;
                }

                else if (Util.SomenteRogerFelipe)
                {
                    groupBoxRoger.Location = new Point(218, 133);
                    groupBoxFelipe.Location = new Point(424, 133);

                    lblValorTotalRoger.Location = new Point(218, 362);
                    lblTxtValorTotalRoger.Location = new Point(218, 334);

                    lblValorTotalFelipe.Location = new Point(424, 362);
                    lblTxtValorTotalFelipe.Location = new Point(424, 334);

                    groupBoxGuilherme.Visible = false;
                    lblTxtValorTotalGui.Visible = false;
                    lblValorTotalGui.Visible = false;

                    groupBoxKamile.Visible = false;
                    lblTxtValorTotalKamile.Visible = false;
                    lblValorTotalKamile.Visible = false;
                }

                txtboxValorPassagem.Text = valores.valorPassagem.ToString("F2");
                lblValorTotalGui.Text = valores.valoresGuilherme.ToString("F2");
                lblValorTotalKamile.Text = valores.valoresKamile.ToString("F2");
                lblValorTotalRoger.Text = valores.valoresRoger.ToString("F2");
                lblValorTotalFelipe.Text = valores.valoresFelipe.ToString("F2");

                CentralizarControles();
            }
            catch (Exception ex)
            {
                Util.GravarLog("Erro no Form1_Load: " + ex.Message);
                throw;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            CentralizarControles();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Util.GravarLog("Erro no btnAlterar_Click: " + ex.Message);
                throw;
            }
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Util.SomenteFelipe || Util.SomenteRogerFelipe)
            {
                if (!radiobtnIdaFelipe.Checked &&
                    !radiobtnVoltaFelipe.Checked &&
                    !radiobtnIdaVoltaFelipe.Checked &&
                    !radiobtnSemCaronaFelipe.Checked)
                {
                    MessageBox.Show("Por favor, selecione uma opção para o Felipe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (Util.SomenteRoger || Util.SomenteRogerFelipe)
            {
                if (!radiobtnIdaRoger.Checked &&
                    !radiobtnVoltaRoger.Checked &&
                    !radiobtnIdaVoltaRoger.Checked &&
                    !radiobtnSemCaronaRoger.Checked)
                {
                    MessageBox.Show("Por favor, selecione uma opção para o Roger.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            TipoCaronaGui guilhermeSelection = TipoCaronaGui.SemCaronaGui;
            TipoCaronaKamile kamileSelection = TipoCaronaKamile.SemCaronaKamile;
            TipoCaronaRoger RogerSelection = TipoCaronaRoger.SemCaronaRoger;
            TipoCaronaFelipe FelipeSelection = TipoCaronaFelipe.SemCaronaFelipe;

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

            // Verificar qual RadioButton está marcado para Roger
            if (radiobtnIdaRoger.Checked)
            {
                RogerSelection = TipoCaronaRoger.IdaRoger;
            }
            else if (radiobtnVoltaRoger.Checked)
            {
                RogerSelection = TipoCaronaRoger.VoltaRoger;
            }
            else if (radiobtnIdaVoltaRoger.Checked)
            {
                RogerSelection = TipoCaronaRoger.IdaVoltaRoger;
            }

            // Verificar qual RadioButton está marcado para Felipe
            if (radiobtnIdaFelipe.Checked)
            {
                FelipeSelection = TipoCaronaFelipe.IdaFelipe;
            }
            else if (radiobtnVoltaFelipe.Checked)
            {
                FelipeSelection = TipoCaronaFelipe.VoltaFelipe;
            }
            else if (radiobtnIdaVoltaFelipe.Checked)
            {
                FelipeSelection = TipoCaronaFelipe.IdaVoltaFelipe;
            }

            try
            {
                double valorGui = 0;
                double valorKamile = 0;
                double valorRoger = 0;
                double valorFelipe = 0;
                Util.AlterarExcelDados(Convert.ToDouble(txtboxValorPassagem.Text), guilhermeSelection, kamileSelection, RogerSelection, FelipeSelection, txtboxDatadeHoje.Text, Convert.ToDouble(lblValorTotalGui.Text), Convert.ToDouble(lblValorTotalKamile.Text), Convert.ToDouble(lblValorTotalRoger.Text), Convert.ToDouble(lblValorTotalFelipe.Text), out valorKamile, out valorGui, out valorRoger, out valorFelipe);

                double valorTotalGui = Convert.ToDouble(lblValorTotalGui.Text) + valorGui;
                double valorTotalKamile = Convert.ToDouble(lblValorTotalKamile.Text) + valorKamile;
                double valorTotalRoger = Convert.ToDouble(lblValorTotalRoger.Text) + valorRoger;
                double valorTotalFelipe = Convert.ToDouble(lblValorTotalFelipe.Text) + valorFelipe;
                lblValorTotalGui.Text = valorTotalGui.ToString("F2");
                lblValorTotalKamile.Text = valorTotalKamile.ToString("F2");
                lblValorTotalRoger.Text = valorTotalRoger.ToString("F2");
                lblValorTotalFelipe.Text = valorTotalFelipe.ToString("F2");

                lblAviso.Text = "Sucesso!";
                lblAviso.ForeColor = Color.Green;
                lblAviso.Visible = true;
                await Task.Delay(2000); // Espera por 3 segundos
                lblAviso.Visible = false;
            }
            catch (Exception ex)
            {
                Util.GravarLog("Erro no btnSalvar_Click: " + ex.Message);
                throw;
            }
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
        private void lblValorTotalRoger_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string caminho = Util.DiretorioArquivoExcel;
            Process.Start("explorer.exe", caminho);
        }

        private void lblValorTotalFelipe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void CentralizarControles()
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // Centralizar botão Salvar
            int topoSalvar = 20;
            btnSalvar.Top = topoSalvar;
            btnSalvar.Left = (formWidth - btnSalvar.Width) / 2;

            // Arrays dos GroupBoxes e Labels
            GroupBox[] todosGrupos = { groupBoxFelipe, groupBoxGuilherme, groupBoxKamile, groupBoxRoger };
            Label[] labelsTxt = { lblTxtValorTotalFelipe, lblTxtValorTotalGui, lblTxtValorTotalKamile, lblTxtValorTotalRoger };
            Label[] labelsVal = { lblValorTotalFelipe, lblValorTotalGui, lblValorTotalKamile, lblValorTotalRoger };

            // Filtro apenas dos grupos visíveis
            var gruposVisiveis = todosGrupos
                .Select((g, i) => new { Grupo = g, LabelTxt = labelsTxt[i], LabelVal = labelsVal[i] })
                .Where(x => x.Grupo.Visible)
                .ToList();

            if (gruposVisiveis.Count == 0) return; // se nenhum estiver visível, não faz nada

            int espacamento = 40;

            // Largura total ocupada pelos grupos + espaçamentos
            int totalWidth = gruposVisiveis.Sum(x => x.Grupo.Width) + espacamento * (gruposVisiveis.Count - 1);

            // Posição inicial à esquerda para centralizar
            int leftInicial = (formWidth - totalWidth) / 2;
            int topBase = (formHeight - gruposVisiveis[0].Grupo.Height - 30) / 2;

            int leftAtual = leftInicial;
            foreach (var item in gruposVisiveis)
            {
                // Posicionar GroupBox
                item.Grupo.Left = leftAtual;
                item.Grupo.Top = topBase;

                // Posicionar labels abaixo do GroupBox
                item.LabelTxt.Top = item.Grupo.Bottom + 5;
                item.LabelTxt.Left = item.Grupo.Left;

                item.LabelVal.Top = item.LabelTxt.Top;
                item.LabelVal.Left = item.LabelTxt.Right + 5;

                // Avança para o próximo com margem
                leftAtual += item.Grupo.Width + espacamento;
            }

            // Posicionar os controles fixos à direita
            int margemDireitaLblData = 232;
            int margemDireitaAnterior = 264;
            int margemDireitaProximo = 174;

            lblDataHoje.Location = new Point(formWidth - margemDireitaLblData, 29);
            txtboxDatadeHoje.Location = new Point(formWidth - margemDireitaLblData, 47);
            btnAnterior.Location = new Point(formWidth - margemDireitaAnterior, 76);
            btnProximo.Location = new Point(formWidth - margemDireitaProximo, 76);
        }

        private void PersonalizarEstilo()
        {
            // Alterando o fundo para um bege um pouco mais escuro
            this.BackColor = Color.FromArgb(245, 230, 210); // Bege médio

            // Estilizando botões com bordas arredondadas e cor laranja mais escura
            Action<Button> estilizarBotao = (btn) =>
            {
                btn.BackColor = Color.FromArgb(230, 150, 70); // Laranja mais escuro
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Montserrat", 11F, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(210, 130, 50); // Efeito hover mais escuro
                btn.Region = new Region(new System.Drawing.Drawing2D.GraphicsPath());
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddArc(new Rectangle(0, 0, 20, 20), 180, 90);
                path.AddArc(new Rectangle(btn.Width - 20, 0, 20, 20), 270, 90);
                path.AddArc(new Rectangle(btn.Width - 20, btn.Height - 20, 20, 20), 0, 90);
                path.AddArc(new Rectangle(0, btn.Height - 20, 20, 20), 90, 90);
                path.CloseFigure();
                btn.Region = new Region(path);
            };

            estilizarBotao(btnAlterar);
            estilizarBotao(btnSalvar);
            estilizarBotao(btnAnterior);
            estilizarBotao(btnProximo);


            // Estilo para os Links
            lblValorTotalGui.LinkColor = Color.Chocolate;
            lblValorTotalKamile.LinkColor = Color.Chocolate;
            lblValorTotalRoger.LinkColor = Color.Chocolate;
            lblValorTotalFelipe.LinkColor = Color.Chocolate;

        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            string caminho = Util.CaminhoArquivoLog;
            Process.Start("explorer.exe", caminho);
        }
    }
}
