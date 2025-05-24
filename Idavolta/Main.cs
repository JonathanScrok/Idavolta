using System.Diagnostics;

namespace Idavolta
{
    public partial class Main : Form
    {
        string TemaEscolhido { get; set; }
        List<string> ? nomesCaronas { get; set; }

        private Dictionary<string, BlocoCarona> blocosCaronas;

        private Panel panelCaronas;

        public Main(string temaEscolhido)
        {
            TemaEscolhido = temaEscolhido;
            InitializeComponent();

            nomesCaronas = ConfigHelper.ObterListaCaronas();

            InicializarPanelCaronas();
            InicializarBlocosCaronas();
            PersonalizarEstilo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            blocosCaronas = new Dictionary<string, BlocoCarona>();
            this.ActiveControl = btnLogs;

            try
            {
                txtboxDatadeHoje.Text = DateTime.Now.ToString("dd/MM/yyyy");
                var (valoresPorPessoa, valorPassagem) = Util.LerOuCriarExcelDinamico(nomesCaronas);

                CriarBlocosCaronasDinamicamente(nomesCaronas);
                AtualizarTotais(valoresPorPessoa);

                txtboxValorPassagem.Text = valorPassagem.ToString("F2");
                //CentralizarControles();
            }
            catch (Exception ex)
            {
                Util.GravarLog("Erro no Form1_Load: " + ex.Message);
                throw;
            }
        }

        private void AtualizarTotais(Dictionary<string, double> valores)
        {
            // Limpa os rótulos existentes (opcional)
            foreach (Control control in this.Controls)
            {
                if (control is Label && control.Name.StartsWith("lblValorTotal"))
                {
                    control.Text = "0,00";
                }
            }

            // Itera sobre o dicionário e atualiza os rótulos correspondentes
            foreach (var valor in valores)
            {
                // Verifica se existe um Label com o nome adequado e atualiza o texto
                Label label = this.Controls.Find("lblValorTotal" + valor.Key, true).FirstOrDefault() as Label;

                if (label != null)
                {
                    label.Text = valor.Value.ToString("F2");
                }
                else
                {
                    // Caso o Label não exista, você pode criar um rótulo dinamicamente, se necessário
                    Label novoLabel = new Label
                    {
                        Name = "lblValorTotal" + valor.Key,
                        Text = valor.Value.ToString("F2"),
                        AutoSize = true
                    };

                    // Você pode adicionar esse rótulo ao painel ou ao formulário
                    panelCaronas.Controls.Add(novoLabel); // Adicionando ao painel, se você tiver um
                    novoLabel.Location = new Point(10, panelCaronas.Controls.Count * 30); // Ajuste a posição
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            CentralizarControles();
            panelCaronas.Width = this.ClientSize.Width;
            CriarBlocosCaronasDinamicamente(nomesCaronas);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnAlterar.Text == "Salvar")
                {
                    //Salvar Valor da Passagem

                    if (txtboxValorPassagem.Text.Contains("."))
                        txtboxValorPassagem.Text = txtboxValorPassagem.Text.Replace(".", ",");

                    double valorPassagemAnterior = 0;
                    bool ValorAlterado = Util.AlterarValorPassagemExcel(Convert.ToDouble(txtboxValorPassagem.Text), out valorPassagemAnterior);

                    if (!ValorAlterado)
                        txtboxValorPassagem.Text = valorPassagemAnterior.ToString("F2"); ;

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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtboxValorPassagem.Text, out double valorPassagem))
            {
                MessageBox.Show("Valor da passagem inválido.");
                return;
            }

            // Coleta as seleções de caronas
            Dictionary<string, TipoCarona> caronasSelecionadas = new Dictionary<string, TipoCarona>();

            foreach (var nome in nomesCaronas)
            {
                if (blocosCaronas.TryGetValue(nome, out var bloco))
                {
                    if (bloco.radioIda.Checked)
                        caronasSelecionadas[nome] = TipoCarona.Ida;
                    else if (bloco.radioVolta.Checked)
                        caronasSelecionadas[nome] = TipoCarona.Volta;
                    else if (bloco.radioIdaVolta.Checked)
                        caronasSelecionadas[nome] = TipoCarona.IdaVolta;
                    else if (bloco.radioNenhum.Checked)
                        caronasSelecionadas[nome] = TipoCarona.Nenhum;
                    else
                        bloco.radioNenhum.Checked = true;
                }
            }

            // Chama o método para salvar os dados no Excel
            bool DadosAlterados = Util.AlterarExcelDadosDinamico(caronasSelecionadas, valorPassagem, nomesCaronas, txtboxDatadeHoje.Text);

            var (valoresPorPessoa, valorPassagem2) = Util.LerOuCriarExcelDinamico(nomesCaronas);
            AtualizarTotais(valoresPorPessoa);

            if (DadosAlterados)
                MessageBox.Show("Dados salvos com sucesso!");
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

            // Centralizar os blocos no panelCaronas
            var gruposVisiveis = panelCaronas.Controls.OfType<GroupBox>()
                .Where(g => g.Visible && g.Name.StartsWith("groupBox"))
                .Select(g =>
                {
                    string nome = g.Name.Replace("groupBox", "");
                    Label lblTxt = panelCaronas.Controls.Find("lblTxtValorTotal" + nome, true).FirstOrDefault() as Label;
                    LinkLabel lblVal = panelCaronas.Controls.Find("lblValorTotal" + nome, true).FirstOrDefault() as LinkLabel;
                    return new { Grupo = g, LabelTxt = lblTxt, LabelVal = lblVal };
                })
                .Where(x => x.LabelTxt != null && x.LabelVal != null)
                .ToList();

            if (gruposVisiveis.Count == 0) return;

            int espacamento = 40;
            int totalWidth = gruposVisiveis.Sum(x => x.Grupo.Width) + espacamento * (gruposVisiveis.Count - 1);
            int leftInicial = (panelCaronas.Width - totalWidth) / 2;
            int topBase = 20;

            int leftAtual = leftInicial;
            foreach (var item in gruposVisiveis)
            {
                item.Grupo.Left = leftAtual;
                item.Grupo.Top = topBase;

                item.LabelTxt.Top = item.Grupo.Bottom + 5;
                item.LabelTxt.Left = item.Grupo.Left;

                item.LabelVal.Top = item.LabelTxt.Top;
                item.LabelVal.Left = item.LabelTxt.Right + 5;

                leftAtual += item.Grupo.Width + espacamento;
            }

            // Posicionar lblDataHoje e txtboxDatadeHoje acima dos botões de navegação
            int espacamentoBotoes = 6;
            int topBotoes = 76;

            int larguraBotoes = btnAnterior.Width + espacamentoBotoes + btnProximo.Width;
            int leftBotoes = formWidth - larguraBotoes - 20;

            btnAnterior.Location = new Point(leftBotoes, topBotoes);
            btnProximo.Location = new Point(btnAnterior.Right + espacamentoBotoes, topBotoes);

            txtboxDatadeHoje.Location = new Point(
                btnAnterior.Left + (btnProximo.Right - btnAnterior.Left - txtboxDatadeHoje.Width) / 2,
                btnAnterior.Top - txtboxDatadeHoje.Height - 4
            );

            lblDataHoje.Location = new Point(
                txtboxDatadeHoje.Left,
                txtboxDatadeHoje.Top - lblDataHoje.Height - 2
            );

            // Posicionar botão Logs no canto inferior esquerdo
            btnLogs.Location = new Point(10, formHeight - btnLogs.Height - 10);

            // Posicionar botão Recarregar no canto inferior direito
            btnRecarregar.Location = new Point(formWidth - btnRecarregar.Width - 10, formHeight - btnRecarregar.Height - 10);
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
            //lblValorTotalGui.LinkColor = Color.Chocolate;
            //lblValorTotalKamile.LinkColor = Color.Chocolate;
            //lblValorTotalRoger.LinkColor = Color.Chocolate;
            //lblValorTotalFelipe.LinkColor = Color.Chocolate;
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            string caminho = Util.CaminhoArquivoLog;
            Process.Start("explorer.exe", caminho);
        }

        private void btnRecarregar_Click(object sender, EventArgs e)
        {
            txtboxDatadeHoje.Text = DateTime.Now.ToString("dd/MM/yyyy");
            var (valoresPorPessoa, valorPassagem) = Util.LerOuCriarExcelDinamico(nomesCaronas);
            AtualizarTotais(valoresPorPessoa);

            foreach (var nome in nomesCaronas)
            {
                if (blocosCaronas.TryGetValue(nome, out var bloco))
                {
                    bloco.radioIda.Checked = false;
                    bloco.radioVolta.Checked = false;
                    bloco.radioIdaVolta.Checked = false;
                    bloco.radioNenhum.Checked = false;
                }
            }
        }

        private void AdicionarNovaCarona(string nome)
        {
            var caronas = ConfigHelper.ObterListaCaronas();

            if (!caronas.Contains(nome))
            {
                caronas.Add(nome);
                ConfigHelper.SalvarListaCaronas(caronas);
                MessageBox.Show($"{nome} adicionado!");
                //this.Controls.Clear();
                //InitializeComponent();

                nomesCaronas = ConfigHelper.ObterListaCaronas();
                CriarBlocosCaronasDinamicamente(nomesCaronas);
                CentralizarControles();

            }
            else
            {
                MessageBox.Show("Carona já existe.");
            }
        }

        private void CriarBlocosCaronasDinamicamente(List<string> nomesCaronas)
        {
            // 1. Salvar os valores atuais dos totais
            Dictionary<string, string> totaisAnteriores = new Dictionary<string, string>();
            foreach (Control control in panelCaronas.Controls)
            {
                if (control is GroupBox groupBox)
                {
                    string nome = groupBox.Name.Replace("groupBox", "");
                    var lblValor = groupBox.Controls.Find($"lblValorTotal{nome}", true).FirstOrDefault() as LinkLabel;
                    if (lblValor != null)
                        totaisAnteriores[nome] = lblValor.Text;
                }
            }

            // 2. Limpar controles e dicionário
            panelCaronas.Controls.Clear();
            blocosCaronas.Clear();

            int espacamentoHorizontal = 40;
            int groupBoxWidth = 200;
            int groupBoxHeight = 230;

            int totalWidth = nomesCaronas.Count * groupBoxWidth + (nomesCaronas.Count - 1) * espacamentoHorizontal;
            int xInicial = (panelCaronas.Width - totalWidth) / 2;
            int yInicial = 20;

            for (int i = 0; i < nomesCaronas.Count; i++)
            {
                string nome = nomesCaronas[i];

                GroupBox groupBox = new GroupBox
                {
                    Name = $"groupBox{nome}",
                    Size = new Size(groupBoxWidth, groupBoxHeight),
                    Location = new Point(xInicial + i * (groupBoxWidth + espacamentoHorizontal), yInicial)
                };

                Label lblNome = new Label
                {
                    Text = nome,
                    Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point((groupBox.Width - TextRenderer.MeasureText(nome, new Font("Segoe UI", 15F, FontStyle.Bold)).Width) / 2, 5)
                };
                groupBox.Controls.Add(lblNome);

                RadioButton radioIda = CriarRadioButton("Ida", 35, nome);
                RadioButton radioVolta = CriarRadioButton("Volta", 65, nome);
                RadioButton radioIdaVolta = CriarRadioButton("Ida e Volta", 95, nome);
                RadioButton radioNenhum = CriarRadioButton("Sem Carona", 125, nome);

                groupBox.Controls.Add(radioIda);
                groupBox.Controls.Add(radioVolta);
                groupBox.Controls.Add(radioIdaVolta);
                groupBox.Controls.Add(radioNenhum);

                blocosCaronas[nome] = new BlocoCarona(radioIda, radioVolta, radioIdaVolta, radioNenhum, lblNome);

                Label lblTxt = new Label
                {
                    Text = $"Total {nome}:",
                    Font = new Font("Segoe UI", 12F),
                    AutoSize = true,
                    Name = $"lblTxtValorTotal{nome}",
                    Location = new Point(10, groupBoxHeight - 45)
                };
                groupBox.Controls.Add(lblTxt);

                LinkLabel lblValor = new LinkLabel
                {
                    Text = totaisAnteriores.ContainsKey(nome) ? totaisAnteriores[nome] : "0,00",
                    Font = new Font("Segoe UI", 14F, FontStyle.Underline),
                    MinimumSize = new Size(70, 30),
                    Name = $"lblValorTotal{nome}",
                    Location = new Point(lblTxt.Right + 5, groupBoxHeight - 47)
                };
                groupBox.Controls.Add(lblValor);

                lblValor.LinkClicked += (s, e) =>
                {
                    string caminho = Util.DiretorioArquivoExcel;
                    Process.Start("explorer.exe", caminho);
                };

                panelCaronas.Controls.Add(groupBox);
            }
        }


        private RadioButton CriarRadioButton(string texto, int top, string nome)
        {
            return new RadioButton
            {
                Text = texto,
                Font = new Font("Segoe UI", 14F),
                AutoSize = true,
                Location = new Point(10, top),
                Name = $"radiobtn{texto.Replace(" ", "")}{nome}"
            };
        }


        private void InicializarBlocosCaronas()
        {
            blocosCaronas = new Dictionary<string, BlocoCarona>();

            foreach (var nome in nomesCaronas)
            {
                // Criação dos RadioButtons
                var radioIda = new RadioButton { Text = "Ida", AutoSize = true };
                var radioVolta = new RadioButton { Text = "Volta", AutoSize = true };
                var radioIdaVolta = new RadioButton { Text = "Ida e Volta", AutoSize = true };
                var radioNenhum = new RadioButton { Text = "Sem Carona", AutoSize = true, Checked = true };

                // Nome
                var labelNome = new Label
                {
                    Text = nome,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Dock = DockStyle.Top,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                // GroupBox para agrupar os RadioButtons
                var groupBox = new GroupBox
                {
                    Name = "groupBox" + nome,
                    Width = 200,
                    Height = 120,
                    Visible = true
                };

                // Posicionamento interno
                radioIda.Top = 30;
                radioVolta.Top = 50;
                radioIdaVolta.Top = 70;
                radioNenhum.Top = 90;

                radioIda.Left = radioVolta.Left = radioIdaVolta.Left = radioNenhum.Left = 10;

                groupBox.Controls.Add(labelNome);
                groupBox.Controls.Add(radioIda);
                groupBox.Controls.Add(radioVolta);
                groupBox.Controls.Add(radioIdaVolta);
                groupBox.Controls.Add(radioNenhum);

                // Adiciona ao painel
                panelCaronas.Controls.Add(groupBox);

                // Cria e salva o bloco
                var blocoCarona = new BlocoCarona(radioIda, radioVolta, radioIdaVolta, radioNenhum, labelNome);
                blocosCaronas.Add(nome, blocoCarona);
            }
        }


        private void InicializarPanelCaronas()
        {
            panelCaronas = new Panel
            {
                Location = new Point(0, 100),
                Width = this.ClientSize.Width,
                Height = 300,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                AutoScroll = true
            };

            this.Controls.Add(panelCaronas);
        }
    }
}
