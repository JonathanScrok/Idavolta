using System.Resources;

namespace ConfiguraIdaVolta
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lblTema = new Label();
            lblSomenteGui = new Label();
            lblSomenteKamile = new Label();
            lblSomenteRoger = new Label();
            lblSomenteFelipe = new Label();
            lblSomenteRogerFelipe = new Label();
            lblNomeArqExcel = new Label();
            lblDirArqExcel = new Label();
            lblDirArqLogs = new Label();
            lblValorPadrao = new Label();
            txtBoxTema = new TextBox();
            txtBoxValorPadraoPassagem = new TextBox();
            txtBoxNomeArqExcel = new TextBox();
            txtBoxDirArqExcel = new TextBox();
            txtBoxDirArqLogs = new TextBox();
            cmbBoxSomenteGui = new ComboBox();
            cmbBoxSomenteKamile = new ComboBox();
            cmbBoxSomenteRoger = new ComboBox();
            cmbBoxSomenteFelipe = new ComboBox();
            cmbBoxSomenteRogerFelipe = new ComboBox();
            btnSalvarConfig = new Button();
            btnSelecionarPastaExcel = new Button();
            btnSelecionarPastaLogs = new Button();
            SuspendLayout();
            // 
            // lblTema
            // 
            lblTema.AutoSize = true;
            lblTema.Location = new Point(61, 35);
            lblTema.Name = "lblTema";
            lblTema.Size = new Size(39, 15);
            lblTema.TabIndex = 0;
            lblTema.Text = "Tema:";
            // 
            // lblSomenteGui
            // 
            lblSomenteGui.AutoSize = true;
            lblSomenteGui.Location = new Point(61, 108);
            lblSomenteGui.Name = "lblSomenteGui";
            lblSomenteGui.Size = new Size(78, 15);
            lblSomenteGui.TabIndex = 2;
            lblSomenteGui.Text = "Somente Gui:";
            // 
            // lblSomenteKamile
            // 
            lblSomenteKamile.AutoSize = true;
            lblSomenteKamile.Location = new Point(61, 143);
            lblSomenteKamile.Name = "lblSomenteKamile";
            lblSomenteKamile.Size = new Size(96, 15);
            lblSomenteKamile.TabIndex = 3;
            lblSomenteKamile.Text = "Somente Kamile:";
            // 
            // lblSomenteRoger
            // 
            lblSomenteRoger.AutoSize = true;
            lblSomenteRoger.Location = new Point(61, 174);
            lblSomenteRoger.Name = "lblSomenteRoger";
            lblSomenteRoger.Size = new Size(91, 15);
            lblSomenteRoger.TabIndex = 4;
            lblSomenteRoger.Text = "Somente Roger:";
            // 
            // lblSomenteFelipe
            // 
            lblSomenteFelipe.AutoSize = true;
            lblSomenteFelipe.Location = new Point(61, 207);
            lblSomenteFelipe.Name = "lblSomenteFelipe";
            lblSomenteFelipe.Size = new Size(91, 15);
            lblSomenteFelipe.TabIndex = 5;
            lblSomenteFelipe.Text = "Somente Felipe:";
            // 
            // lblSomenteRogerFelipe
            // 
            lblSomenteRogerFelipe.AutoSize = true;
            lblSomenteRogerFelipe.Location = new Point(61, 237);
            lblSomenteRogerFelipe.Name = "lblSomenteRogerFelipe";
            lblSomenteRogerFelipe.Size = new Size(134, 15);
            lblSomenteRogerFelipe.TabIndex = 6;
            lblSomenteRogerFelipe.Text = "Somente Roger e Felipe:";
            // 
            // lblNomeArqExcel
            // 
            lblNomeArqExcel.AutoSize = true;
            lblNomeArqExcel.Location = new Point(61, 280);
            lblNomeArqExcel.Name = "lblNomeArqExcel";
            lblNomeArqExcel.Size = new Size(132, 15);
            lblNomeArqExcel.TabIndex = 7;
            lblNomeArqExcel.Text = "Nome do arquivo Excel:";
            // 
            // lblDirArqExcel
            // 
            lblDirArqExcel.AutoSize = true;
            lblDirArqExcel.Location = new Point(61, 308);
            lblDirArqExcel.Name = "lblDirArqExcel";
            lblDirArqExcel.Size = new Size(145, 15);
            lblDirArqExcel.TabIndex = 8;
            lblDirArqExcel.Text = "Diretório do arquivo Excel:";
            // 
            // lblDirArqLogs
            // 
            lblDirArqLogs.AutoSize = true;
            lblDirArqLogs.Location = new Point(61, 336);
            lblDirArqLogs.Name = "lblDirArqLogs";
            lblDirArqLogs.Size = new Size(160, 15);
            lblDirArqLogs.TabIndex = 9;
            lblDirArqLogs.Text = "Diretório do arquivo de Logs:";
            // 
            // lblValorPadrao
            // 
            lblValorPadrao.AutoSize = true;
            lblValorPadrao.Location = new Point(61, 64);
            lblValorPadrao.Name = "lblValorPadrao";
            lblValorPadrao.Size = new Size(213, 15);
            lblValorPadrao.TabIndex = 10;
            lblValorPadrao.Text = " Iniciar com valor padrão da passagem:";
            // 
            // txtBoxTema
            // 
            txtBoxTema.Enabled = false;
            txtBoxTema.Location = new Point(106, 32);
            txtBoxTema.Name = "txtBoxTema";
            txtBoxTema.Size = new Size(100, 23);
            txtBoxTema.TabIndex = 11;
            // 
            // txtBoxValorPadraoPassagem
            // 
            txtBoxValorPadraoPassagem.Location = new Point(280, 61);
            txtBoxValorPadraoPassagem.Name = "txtBoxValorPadraoPassagem";
            txtBoxValorPadraoPassagem.Size = new Size(65, 23);
            txtBoxValorPadraoPassagem.TabIndex = 12;
            // 
            // txtBoxNomeArqExcel
            // 
            txtBoxNomeArqExcel.Location = new Point(227, 276);
            txtBoxNomeArqExcel.Name = "txtBoxNomeArqExcel";
            txtBoxNomeArqExcel.Size = new Size(185, 23);
            txtBoxNomeArqExcel.TabIndex = 13;
            // 
            // txtBoxDirArqExcel
            // 
            txtBoxDirArqExcel.Location = new Point(227, 305);
            txtBoxDirArqExcel.Name = "txtBoxDirArqExcel";
            txtBoxDirArqExcel.Size = new Size(324, 23);
            txtBoxDirArqExcel.TabIndex = 14;
            // 
            // txtBoxDirArqLogs
            // 
            txtBoxDirArqLogs.Location = new Point(227, 333);
            txtBoxDirArqLogs.Name = "txtBoxDirArqLogs";
            txtBoxDirArqLogs.Size = new Size(324, 23);
            txtBoxDirArqLogs.TabIndex = 16;
            // 
            // cmbBoxSomenteGui
            // 
            cmbBoxSomenteGui.FormattingEnabled = true;
            cmbBoxSomenteGui.Location = new Point(227, 105);
            cmbBoxSomenteGui.Name = "cmbBoxSomenteGui";
            cmbBoxSomenteGui.Size = new Size(121, 23);
            cmbBoxSomenteGui.TabIndex = 17;
            cmbBoxSomenteGui.SelectedIndexChanged += cmbBoxSomenteGui_SelectedIndexChanged;
            // 
            // cmbBoxSomenteKamile
            // 
            cmbBoxSomenteKamile.FormattingEnabled = true;
            cmbBoxSomenteKamile.Location = new Point(227, 140);
            cmbBoxSomenteKamile.Name = "cmbBoxSomenteKamile";
            cmbBoxSomenteKamile.Size = new Size(121, 23);
            cmbBoxSomenteKamile.TabIndex = 18;
            cmbBoxSomenteKamile.SelectedIndexChanged += cmbBoxSomenteKamile_SelectedIndexChanged;
            // 
            // cmbBoxSomenteRoger
            // 
            cmbBoxSomenteRoger.FormattingEnabled = true;
            cmbBoxSomenteRoger.Location = new Point(227, 174);
            cmbBoxSomenteRoger.Name = "cmbBoxSomenteRoger";
            cmbBoxSomenteRoger.Size = new Size(121, 23);
            cmbBoxSomenteRoger.TabIndex = 19;
            cmbBoxSomenteRoger.SelectedIndexChanged += cmbBoxSomenteRoger_SelectedIndexChanged;
            // 
            // cmbBoxSomenteFelipe
            // 
            cmbBoxSomenteFelipe.FormattingEnabled = true;
            cmbBoxSomenteFelipe.Location = new Point(227, 204);
            cmbBoxSomenteFelipe.Name = "cmbBoxSomenteFelipe";
            cmbBoxSomenteFelipe.Size = new Size(121, 23);
            cmbBoxSomenteFelipe.TabIndex = 20;
            cmbBoxSomenteFelipe.SelectedIndexChanged += cmbBoxSomenteFelipe_SelectedIndexChanged;
            // 
            // cmbBoxSomenteRogerFelipe
            // 
            cmbBoxSomenteRogerFelipe.FormattingEnabled = true;
            cmbBoxSomenteRogerFelipe.Location = new Point(227, 237);
            cmbBoxSomenteRogerFelipe.Name = "cmbBoxSomenteRogerFelipe";
            cmbBoxSomenteRogerFelipe.Size = new Size(121, 23);
            cmbBoxSomenteRogerFelipe.TabIndex = 21;
            cmbBoxSomenteRogerFelipe.SelectedIndexChanged += cmbBoxSomenteRogerFelipe_SelectedIndexChanged;
            // 
            // btnSalvarConfig
            // 
            btnSalvarConfig.BackColor = SystemColors.MenuHighlight;
            btnSalvarConfig.FlatStyle = FlatStyle.Flat;
            btnSalvarConfig.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalvarConfig.Location = new Point(315, 392);
            btnSalvarConfig.Name = "btnSalvarConfig";
            btnSalvarConfig.Size = new Size(170, 37);
            btnSalvarConfig.TabIndex = 22;
            btnSalvarConfig.Text = "Salvar";
            btnSalvarConfig.UseVisualStyleBackColor = false;
            btnSalvarConfig.Click += btnSalvarConfig_Click;
            // 
            // btnSelecionarPastaExcel
            // 
            btnSelecionarPastaExcel.Location = new Point(557, 305);
            btnSelecionarPastaExcel.Name = "btnSelecionarPastaExcel";
            btnSelecionarPastaExcel.Size = new Size(95, 23);
            btnSelecionarPastaExcel.TabIndex = 23;
            btnSelecionarPastaExcel.Text = "Pesquisar";
            btnSelecionarPastaExcel.UseVisualStyleBackColor = true;
            btnSelecionarPastaExcel.Click += btnSelecionarPastaExcel_Click;
            // 
            // btnSelecionarPastaLogs
            // 
            btnSelecionarPastaLogs.Location = new Point(557, 333);
            btnSelecionarPastaLogs.Name = "btnSelecionarPastaLogs";
            btnSelecionarPastaLogs.Size = new Size(95, 23);
            btnSelecionarPastaLogs.TabIndex = 24;
            btnSelecionarPastaLogs.Text = "Pesquisar";
            btnSelecionarPastaLogs.UseVisualStyleBackColor = true;
            btnSelecionarPastaLogs.Click += btnSelecionarPastaLogs_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSelecionarPastaLogs);
            Controls.Add(btnSelecionarPastaExcel);
            Controls.Add(btnSalvarConfig);
            Controls.Add(cmbBoxSomenteRogerFelipe);
            Controls.Add(cmbBoxSomenteFelipe);
            Controls.Add(cmbBoxSomenteRoger);
            Controls.Add(cmbBoxSomenteKamile);
            Controls.Add(cmbBoxSomenteGui);
            Controls.Add(txtBoxDirArqLogs);
            Controls.Add(txtBoxDirArqExcel);
            Controls.Add(txtBoxNomeArqExcel);
            Controls.Add(txtBoxValorPadraoPassagem);
            Controls.Add(txtBoxTema);
            Controls.Add(lblValorPadrao);
            Controls.Add(lblDirArqLogs);
            Controls.Add(lblDirArqExcel);
            Controls.Add(lblNomeArqExcel);
            Controls.Add(lblSomenteRogerFelipe);
            Controls.Add(lblSomenteFelipe);
            Controls.Add(lblSomenteRoger);
            Controls.Add(lblSomenteKamile);
            Controls.Add(lblSomenteGui);
            Controls.Add(lblTema);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Configurações Ida e Volta";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTema;
        private Label lblSomenteGui;
        private Label lblSomenteKamile;
        private Label lblSomenteRoger;
        private Label lblSomenteFelipe;
        private Label lblSomenteRogerFelipe;
        private Label lblNomeArqExcel;
        private Label lblDirArqExcel;
        private Label lblDirArqLogs;
        private Label lblValorPadrao;
        private TextBox txtBoxTema;
        private TextBox txtBoxValorPadraoPassagem;
        private TextBox txtBoxNomeArqExcel;
        private TextBox txtBoxDirArqExcel;
        private TextBox txtBoxDirArqLogs;
        private ComboBox cmbBoxSomenteGui;
        private ComboBox cmbBoxSomenteKamile;
        private ComboBox cmbBoxSomenteRoger;
        private ComboBox cmbBoxSomenteFelipe;
        private ComboBox cmbBoxSomenteRogerFelipe;
        private Button btnSalvarConfig;
        private Button btnSelecionarPastaExcel;
        private Button btnSelecionarPastaLogs;
    }
}
