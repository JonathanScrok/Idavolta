namespace Idavolta
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            lblValorPassagem = new Label();
            txtboxValorPassagem = new TextBox();
            lblDataHoje = new Label();
            txtboxDatadeHoje = new TextBox();
            btnAlterar = new Button();
            btnSalvar = new Button();
            btnAnterior = new Button();
            btnProximo = new Button();
            lblAviso = new Label();
            btnLogs = new Button();
            btnRecarregar = new Button();
            SuspendLayout();
            // 
            // lblValorPassagem
            // 
            lblValorPassagem.AutoSize = true;
            lblValorPassagem.Location = new Point(31, 29);
            lblValorPassagem.Name = "lblValorPassagem";
            lblValorPassagem.Size = new Size(108, 15);
            lblValorPassagem.TabIndex = 0;
            lblValorPassagem.Text = "Valor da Passagem:";
            // 
            // txtboxValorPassagem
            // 
            txtboxValorPassagem.Enabled = false;
            txtboxValorPassagem.Location = new Point(31, 47);
            txtboxValorPassagem.Name = "txtboxValorPassagem";
            txtboxValorPassagem.ReadOnly = true;
            txtboxValorPassagem.Size = new Size(108, 23);
            txtboxValorPassagem.TabIndex = 1;
            // 
            // lblDataHoje
            // 
            lblDataHoje.AutoSize = true;
            lblDataHoje.Location = new Point(832, 29);
            lblDataHoje.Name = "lblDataHoje";
            lblDataHoje.Size = new Size(78, 15);
            lblDataHoje.TabIndex = 2;
            lblDataHoje.Text = "Data de Hoje:";
            // 
            // txtboxDatadeHoje
            // 
            txtboxDatadeHoje.Location = new Point(832, 47);
            txtboxDatadeHoje.Name = "txtboxDatadeHoje";
            txtboxDatadeHoje.Size = new Size(100, 23);
            txtboxDatadeHoje.TabIndex = 4;
            // 
            // btnAlterar
            // 
            btnAlterar.Location = new Point(31, 76);
            btnAlterar.Name = "btnAlterar";
            btnAlterar.Size = new Size(108, 29);
            btnAlterar.TabIndex = 5;
            btnAlterar.Text = "Alterar";
            btnAlterar.UseVisualStyleBackColor = true;
            btnAlterar.Click += btnAlterar_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Font = new Font("Segoe UI", 15F);
            btnSalvar.Location = new Point(391, 29);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(159, 44);
            btnSalvar.TabIndex = 16;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.Location = new Point(800, 76);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(75, 23);
            btnAnterior.TabIndex = 21;
            btnAnterior.Text = "<";
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnProximo
            // 
            btnProximo.Location = new Point(890, 76);
            btnProximo.Name = "btnProximo";
            btnProximo.Size = new Size(75, 23);
            btnProximo.TabIndex = 22;
            btnProximo.Text = ">";
            btnProximo.UseVisualStyleBackColor = true;
            btnProximo.Click += btnProximo_Click;
            // 
            // lblAviso
            // 
            lblAviso.AutoSize = true;
            lblAviso.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblAviso.ForeColor = SystemColors.ControlText;
            lblAviso.Location = new Point(427, 87);
            lblAviso.Name = "lblAviso";
            lblAviso.Size = new Size(76, 28);
            lblAviso.TabIndex = 23;
            lblAviso.Text = "Aviso";
            lblAviso.Visible = false;
            // 
            // btnLogs
            // 
            btnLogs.BackColor = SystemColors.Info;
            btnLogs.Location = new Point(12, 473);
            btnLogs.Name = "btnLogs";
            btnLogs.Size = new Size(75, 23);
            btnLogs.TabIndex = 28;
            btnLogs.Text = "Logs";
            btnLogs.UseVisualStyleBackColor = false;
            btnLogs.Click += btnLogs_Click;
            // 
            // btnRecarregar
            // 
            btnRecarregar.Image = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\Imagem\\btnrecarregar.png"));
            this.btnRecarregar.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            btnRecarregar.Location = new Point(923, 462);
            btnRecarregar.Name = "btnRecarregar";
            btnRecarregar.Size = new Size(36, 34);
            btnRecarregar.TabIndex = 29;
            btnRecarregar.TextAlign = ContentAlignment.MiddleRight;
            btnRecarregar.UseVisualStyleBackColor = true;
            btnRecarregar.Click += btnRecarregar_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(971, 508);
            Controls.Add(btnRecarregar);
            Controls.Add(btnLogs);
            Controls.Add(lblAviso);
            Controls.Add(btnProximo);
            Controls.Add(btnAnterior);
            Controls.Add(btnSalvar);
            Controls.Add(btnAlterar);
            Controls.Add(txtboxDatadeHoje);
            Controls.Add(lblDataHoje);
            Controls.Add(txtboxValorPassagem);
            Controls.Add(lblValorPassagem);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Main";
            Text = "Ida e Volta";
            Load += Form1_Load;
            Resize += Form1_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblValorPassagem;
        private TextBox txtboxValorPassagem;
        private Label lblDataHoje;
        private TextBox txtboxDatadeHoje;
        private Button btnAlterar;
        private ImageList imageList1;
        private NotifyIcon notifyIcon1;
        private Button btnSalvar;
        private Button btnAnterior;
        private Button btnProximo;
        private Label lblAviso;
        private Button btnLogs;
        private Button btnRecarregar;

        public Label LblValorPassagem { get => lblValorPassagem; set => lblValorPassagem = value; }
        //public Label LblValorPassagem
        //{
        //    get { return lblValorPassagem; }
        //    set { lblValorPassagem = value; }
        //}
        public TextBox TxtboxValorPassagem { get => txtboxValorPassagem; set => txtboxValorPassagem = value; }
        public Label LblDataHoje { get => lblDataHoje; set => lblDataHoje = value; }
        public TextBox TxtboxDatadeHoje { get => txtboxDatadeHoje; set => txtboxDatadeHoje = value; }
        public Button BtnAlterar { get => btnAlterar; set => btnAlterar = value; }
        public ImageList ImageList1 { get => imageList1; set => imageList1 = value; }
        public NotifyIcon NotifyIcon1 { get => notifyIcon1; set => notifyIcon1 = value; }
        public Button BtnSalvar { get => btnSalvar; set => btnSalvar = value; }
        public Button BtnAnterior { get => btnAnterior; set => btnAnterior = value; }
        public Button BtnProximo { get => btnProximo; set => btnProximo = value; }
        public Label LblAviso { get => lblAviso; set => lblAviso = value; }
    }
}
