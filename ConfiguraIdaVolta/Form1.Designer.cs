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
            lblNomeArqExcel = new Label();
            lblDirArqExcel = new Label();
            lblDirArqLogs = new Label();
            lblValorPadrao = new Label();
            txtBoxTema = new TextBox();
            txtBoxValorPadraoPassagem = new TextBox();
            txtBoxNomeArqExcel = new TextBox();
            txtBoxDirArqExcel = new TextBox();
            txtBoxDirArqLogs = new TextBox();
            btnSalvarConfig = new Button();
            btnSelecionarPastaExcel = new Button();
            btnSelecionarPastaLogs = new Button();
            button1 = new Button();
            flowLayoutPanelCaronas = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // lblTema
            // 
            lblTema.AutoSize = true;
            lblTema.Location = new Point(649, 23);
            lblTema.Name = "lblTema";
            lblTema.Size = new Size(39, 15);
            lblTema.TabIndex = 0;
            lblTema.Text = "Tema:";
            // 
            // lblNomeArqExcel
            // 
            lblNomeArqExcel.AutoSize = true;
            lblNomeArqExcel.Location = new Point(12, 87);
            lblNomeArqExcel.Name = "lblNomeArqExcel";
            lblNomeArqExcel.Size = new Size(132, 15);
            lblNomeArqExcel.TabIndex = 7;
            lblNomeArqExcel.Text = "Nome do arquivo Excel:";
            // 
            // lblDirArqExcel
            // 
            lblDirArqExcel.AutoSize = true;
            lblDirArqExcel.Location = new Point(12, 26);
            lblDirArqExcel.Name = "lblDirArqExcel";
            lblDirArqExcel.Size = new Size(145, 15);
            lblDirArqExcel.TabIndex = 8;
            lblDirArqExcel.Text = "Diretório do arquivo Excel:";
            // 
            // lblDirArqLogs
            // 
            lblDirArqLogs.AutoSize = true;
            lblDirArqLogs.Location = new Point(12, 54);
            lblDirArqLogs.Name = "lblDirArqLogs";
            lblDirArqLogs.Size = new Size(160, 15);
            lblDirArqLogs.TabIndex = 9;
            lblDirArqLogs.Text = "Diretório do arquivo de Logs:";
            // 
            // lblValorPadrao
            // 
            lblValorPadrao.AutoSize = true;
            lblValorPadrao.Location = new Point(12, 123);
            lblValorPadrao.Name = "lblValorPadrao";
            lblValorPadrao.Size = new Size(148, 15);
            lblValorPadrao.TabIndex = 10;
            lblValorPadrao.Text = "Valor padrão da passagem:";
            // 
            // txtBoxTema
            // 
            txtBoxTema.Enabled = false;
            txtBoxTema.Location = new Point(694, 20);
            txtBoxTema.Name = "txtBoxTema";
            txtBoxTema.Size = new Size(100, 23);
            txtBoxTema.TabIndex = 11;
            // 
            // txtBoxValorPadraoPassagem
            // 
            txtBoxValorPadraoPassagem.Location = new Point(178, 123);
            txtBoxValorPadraoPassagem.Name = "txtBoxValorPadraoPassagem";
            txtBoxValorPadraoPassagem.Size = new Size(65, 23);
            txtBoxValorPadraoPassagem.TabIndex = 12;
            // 
            // txtBoxNomeArqExcel
            // 
            txtBoxNomeArqExcel.Location = new Point(178, 87);
            txtBoxNomeArqExcel.Name = "txtBoxNomeArqExcel";
            txtBoxNomeArqExcel.Size = new Size(199, 23);
            txtBoxNomeArqExcel.TabIndex = 13;
            // 
            // txtBoxDirArqExcel
            // 
            txtBoxDirArqExcel.Location = new Point(178, 23);
            txtBoxDirArqExcel.Name = "txtBoxDirArqExcel";
            txtBoxDirArqExcel.Size = new Size(324, 23);
            txtBoxDirArqExcel.TabIndex = 14;
            // 
            // txtBoxDirArqLogs
            // 
            txtBoxDirArqLogs.Location = new Point(178, 51);
            txtBoxDirArqLogs.Name = "txtBoxDirArqLogs";
            txtBoxDirArqLogs.Size = new Size(324, 23);
            txtBoxDirArqLogs.TabIndex = 16;
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
            btnSelecionarPastaExcel.Location = new Point(508, 23);
            btnSelecionarPastaExcel.Name = "btnSelecionarPastaExcel";
            btnSelecionarPastaExcel.Size = new Size(95, 23);
            btnSelecionarPastaExcel.TabIndex = 23;
            btnSelecionarPastaExcel.Text = "Pesquisar";
            btnSelecionarPastaExcel.UseVisualStyleBackColor = true;
            btnSelecionarPastaExcel.Click += btnSelecionarPastaExcel_Click;
            // 
            // btnSelecionarPastaLogs
            // 
            btnSelecionarPastaLogs.Location = new Point(508, 51);
            btnSelecionarPastaLogs.Name = "btnSelecionarPastaLogs";
            btnSelecionarPastaLogs.Size = new Size(95, 23);
            btnSelecionarPastaLogs.TabIndex = 24;
            btnSelecionarPastaLogs.Text = "Pesquisar";
            btnSelecionarPastaLogs.UseVisualStyleBackColor = true;
            btnSelecionarPastaLogs.Click += btnSelecionarPastaLogs_Click;
            // 
            // button1
            // 
            button1.Location = new Point(259, 201);
            button1.Name = "button1";
            button1.Size = new Size(118, 43);
            button1.TabIndex = 25;
            button1.Text = "Adicionar Carona";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnAdicionarCarona_Click;
            // 
            // flowLayoutPanelCaronas
            // 
            flowLayoutPanelCaronas.AutoScroll = true;
            flowLayoutPanelCaronas.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelCaronas.Location = new Point(383, 87);
            flowLayoutPanelCaronas.MaximumSize = new Size(220, 229);
            flowLayoutPanelCaronas.Name = "flowLayoutPanelCaronas";
            flowLayoutPanelCaronas.Size = new Size(220, 229);
            flowLayoutPanelCaronas.TabIndex = 26;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(flowLayoutPanelCaronas);
            Controls.Add(button1);
            Controls.Add(btnSelecionarPastaLogs);
            Controls.Add(btnSelecionarPastaExcel);
            Controls.Add(btnSalvarConfig);
            Controls.Add(txtBoxDirArqLogs);
            Controls.Add(txtBoxDirArqExcel);
            Controls.Add(txtBoxNomeArqExcel);
            Controls.Add(txtBoxValorPadraoPassagem);
            Controls.Add(txtBoxTema);
            Controls.Add(lblValorPadrao);
            Controls.Add(lblDirArqLogs);
            Controls.Add(lblDirArqExcel);
            Controls.Add(lblNomeArqExcel);
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
        private Label lblNomeArqExcel;
        private Label lblDirArqExcel;
        private Label lblDirArqLogs;
        private Label lblValorPadrao;
        private TextBox txtBoxTema;
        private TextBox txtBoxValorPadraoPassagem;
        private TextBox txtBoxNomeArqExcel;
        private TextBox txtBoxDirArqExcel;
        private TextBox txtBoxDirArqLogs;
        private Button btnSalvarConfig;
        private Button btnSelecionarPastaExcel;
        private Button btnSelecionarPastaLogs;
        private Button button1;
        private FlowLayoutPanel flowLayoutPanelCaronas;
    }
}
