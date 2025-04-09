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
            caminhoAtualizado = Regex.Replace(caminhoAtualizado, "net9\\.0-windows", "net8.0-windows");
            caminhoJson = caminhoAtualizado;

            if (File.Exists(caminhoJson))
            {
                string json = File.ReadAllText(caminhoJson);
                configuracoes = JsonConvert.DeserializeObject<Config>(json);

                AppSettings app = new AppSettings();
                app = configuracoes.AppSettings;

                // Preencher os TextBox
                txtBoxTema.Text = app.Tema;
                txtBoxValorPadraoPassagem.Text = app.ValorPassagemPadrao;
                txtBoxNomeArqExcel.Text = app.NomeArquivoExcel.Replace(@".xlsx", @""); ;

                txtBoxDirArqExcel.Text = app.DiretorioArquivoExcel.Replace(@"\\", @"\");
                txtBoxDirArqLogs.Text = app.DiretorioLOG.Replace(@"\\", @"\");

                // Preencher os ComboBox (S = true = "SIM")
                PreencherComboBox(cmbBoxSomenteGui, app.SomemteGui);
                PreencherComboBox(cmbBoxSomenteKamile, app.SomenteKamile);
                PreencherComboBox(cmbBoxSomenteRoger, app.SomenteRoger);
                PreencherComboBox(cmbBoxSomenteFelipe, app.SomenteFelipe);
                PreencherComboBox(cmbBoxSomenteRogerFelipe, app.SomenteRogerFelipe);

                cmbBoxSomenteGui.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbBoxSomenteKamile.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbBoxSomenteRoger.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbBoxSomenteFelipe.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbBoxSomenteRogerFelipe.DropDownStyle = ComboBoxStyle.DropDownList;

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

        private void AtualizarCombosExclusivos(ComboBox comboAlterado)
        {
            // Se o valor selecionado for "SIM"
            if (comboAlterado.SelectedItem?.ToString() == "SIM")
            {
                // Lista com todos os ComboBoxes
                ComboBox[] todosCombos = {
            cmbBoxSomenteGui,
            cmbBoxSomenteKamile,
            cmbBoxSomenteRoger,
            cmbBoxSomenteFelipe,
            cmbBoxSomenteRogerFelipe
        };

                // Atualiza os outros para "NÃO"
                foreach (var cmb in todosCombos)
                {
                    if (cmb != comboAlterado)
                    {
                        cmb.SelectedItem = "NÃO";
                    }
                }
            }
        }

        private void btnSalvarConfig_Click(object sender, EventArgs e)
        {
            try
            {
                if (configuracoes == null)
                    configuracoes = new Config();

                var app = new AppSettings
                {
                    Tema = txtBoxTema.Text,
                    ValorPassagemPadrao = txtBoxValorPadraoPassagem.Text,
                    NomeArquivoExcel = txtBoxNomeArqExcel.Text + ".xlsx",
                    DiretorioArquivoExcel = txtBoxDirArqExcel.Text,
                    DiretorioLOG = txtBoxDirArqLogs.Text,
                    SomemteGui = ObterValorCombo(cmbBoxSomenteGui),
                    SomenteKamile = ObterValorCombo(cmbBoxSomenteKamile),
                    SomenteRoger = ObterValorCombo(cmbBoxSomenteRoger),
                    SomenteFelipe = ObterValorCombo(cmbBoxSomenteFelipe),
                    SomenteRogerFelipe = ObterValorCombo(cmbBoxSomenteRogerFelipe)
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

        private void cmbBoxSomenteGui_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarCombosExclusivos(cmbBoxSomenteGui);
        }

        private void cmbBoxSomenteKamile_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarCombosExclusivos(cmbBoxSomenteKamile);
        }

        private void cmbBoxSomenteRoger_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarCombosExclusivos(cmbBoxSomenteRoger);
        }

        private void cmbBoxSomenteFelipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarCombosExclusivos(cmbBoxSomenteFelipe);
        }

        private void cmbBoxSomenteRogerFelipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarCombosExclusivos(cmbBoxSomenteRogerFelipe);
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
    }
}
