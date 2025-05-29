using System.Xml;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;

namespace ConfiguraIdaVolta
{
    public partial class Form1 : Form
    {
        private string caminhoJson = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "appsettings.json");

        private Config configuracoes;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = btnSalvarConfig;

            string caminhoOriginal = caminhoJson;

            // Substituições com Regex
            string caminhoAtualizado = Regex.Replace(caminhoOriginal, "ConfiguraIdaVolta", "Idavolta");
            caminhoJson = caminhoAtualizado;

            if (File.Exists(caminhoJson))
            {
                string json = File.ReadAllText(caminhoJson);
                configuracoes = JsonConvert.DeserializeObject<Config>(json);

                AppSettings app = new AppSettings();
                app = configuracoes.AppSettings;

                var caronas = ConfigHelper.ObterListaCaronas();
                foreach (var nome in caronas)
                {
                    CriarControleCarona(nome);
                }

                // Preencher os TextBox
                txtBoxTema.Text = app.Tema;
                txtBoxValorPadraoPassagem.Text = app.ValorPassagemPadrao;
                txtBoxNomeArqExcel.Text = app.NomeArquivoExcel.Replace(@".xlsx", @""); ;

                txtBoxDirArqExcel.Text = app.DiretorioArquivoExcel.Replace(@"\\", @"\");
                txtBoxDirArqLogs.Text = app.DiretorioLOG.Replace(@"\\", @"\");
            }
            else
            {
                MessageBox.Show("Arquivo config.json não encontrado!");
            }
        }

        private void PreencherComboBox(ComboBox combo, string valor)
        {
            combo.Items.Clear();
            combo.Items.Add("SIM");
            combo.Items.Add("NÃO");
            combo.SelectedItem = valor == "S" ? "SIM" : "NÃO";
        }

        private void btnSalvarConfig_Click(object sender, EventArgs e)
        {
            try
            {
                if (configuracoes == null)
                    configuracoes = new Config();

                if (txtBoxValorPadraoPassagem.Text.Contains("."))
                    txtBoxValorPadraoPassagem.Text = txtBoxValorPadraoPassagem.Text.Replace(".", ",");

                var app = new AppSettings
                {
                    Tema = txtBoxTema.Text,
                    ValorPassagemPadrao = txtBoxValorPadraoPassagem.Text,
                    NomeArquivoExcel = txtBoxNomeArqExcel.Text + ".xlsx",
                    DiretorioArquivoExcel = txtBoxDirArqExcel.Text,
                    DiretorioLOG = txtBoxDirArqLogs.Text
                };

                configuracoes.AppSettings = app;

                string json = JsonConvert.SerializeObject(configuracoes, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(caminhoJson, json);

                MessageBox.Show("Configurações salvas com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
        }

        private string ObterValorCombo(ComboBox combo)
        {
            return combo.SelectedItem?.ToString() == "SIM" ? "S" : "N";
        }

        private void btnSelecionarPastaExcel_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Selecione o diretório do arquivo Excel";
                dialog.ShowNewFolderButton = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtBoxDirArqExcel.Text = dialog.SelectedPath;
                }
            }
        }

        private void btnSelecionarPastaLogs_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Selecione o diretório do arquivo de Logs";
                dialog.ShowNewFolderButton = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtBoxDirArqLogs.Text = dialog.SelectedPath;
                }
            }
        }
        private void btnAdicionarCarona_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Digite o nome da nova carona:", "Nova Carona", "");

            if (!string.IsNullOrWhiteSpace(input))
            {
                input = input.Trim();
                string nomeFormatado = input.Replace(" ", "_");
                // Adiciona na lista e salva
                AdicionarNovaCarona(nomeFormatado);

                //// Cria controle visual
                //CriarControleCarona(input);
            }
        }

        private void AdicionarNovaCarona(string nome)
        {
            var caronas = ConfigHelper.ObterListaCaronas();

            if (!caronas.Contains(nome))
            {
                caronas.Add(nome);
                ConfigHelper.SalvarListaCaronas(caronas);
                CriarControleCarona(nome);
                MessageBox.Show($"{nome} adicionado!");
            }
            else
            {
                MessageBox.Show("Carona já existe.");
            }
        }

        private void RemoverCarona(string nome)
        {
            var caronas = ConfigHelper.ObterListaCaronas();

            if (caronas.Contains(nome))
            {
                caronas.Remove(nome);
                ConfigHelper.SalvarListaCaronas(caronas);
                MessageBox.Show($"{nome} removido.");
            }
        }

        private void CriarControleCarona(string nome)
        {
            // Painel individual para nome + botão X
            Panel panel = new Panel
            {
                Width = 200,
                Height = 30,
                Margin = new Padding(5)
            };

            // Botão X
            Button btnExcluir = new Button
            {
                Text = "X",
                Width = 30,
                Height = 25,
                BackColor = Color.Maroon,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(0, 2)
            };

            btnExcluir.Click += (s, e) =>
            {
                flowLayoutPanelCaronas.Controls.Remove(panel);
                RemoverCarona(nome);
            };

            // Label com nome
            Label lblNome = new Label
            {
                Text = nome,
                AutoSize = false,
                Width = 150,
                Height = 25,
                Location = new Point(35, 5),
                BackColor = Color.Black,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft
            };

            panel.Controls.Add(btnExcluir);
            panel.Controls.Add(lblNome);
            flowLayoutPanelCaronas.Controls.Add(panel);
        }
    }
}
