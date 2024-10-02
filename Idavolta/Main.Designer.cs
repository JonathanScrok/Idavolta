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
            lblValorPassagem = new Label();
            txtboxValorPassagem = new TextBox();
            lblDataHoje = new Label();
            txtboxDatadeHoje = new TextBox();
            btnAlterar = new Button();
            groupBoxGuilherme = new GroupBox();
            lblGuilherme = new Label();
            radioSemCaronaGui = new RadioButton();
            radiobtnIdaGui = new RadioButton();
            radiobtnVoltaGui = new RadioButton();
            radiobtnIdaVoltaGui = new RadioButton();
            groupBoxKamile = new GroupBox();
            lblKamile = new Label();
            radioSemCaronaKamile = new RadioButton();
            radiobtnIdaKamile = new RadioButton();
            radiobtnVoltaKamile = new RadioButton();
            radiobtnIdaVoltaKamile = new RadioButton();
            btnSalvar = new Button();
            lblValorTotalGui = new LinkLabel();
            lblValorTotalKamile = new LinkLabel();
            lblTxtValorTotalGui = new Label();
            lblTxtValorTotalKamile = new Label();
            btnAnterior = new Button();
            btnProximo = new Button();
            lblAviso = new Label();
            groupBoxGuilherme.SuspendLayout();
            groupBoxKamile.SuspendLayout();
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
            lblDataHoje.Location = new Point(664, 29);
            lblDataHoje.Name = "lblDataHoje";
            lblDataHoje.Size = new Size(78, 15);
            lblDataHoje.TabIndex = 2;
            lblDataHoje.Text = "Data de Hoje:";
            // 
            // txtboxDatadeHoje
            // 
            txtboxDatadeHoje.Location = new Point(664, 47);
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
            // groupBoxGuilherme
            // 
            groupBoxGuilherme.Controls.Add(lblGuilherme);
            groupBoxGuilherme.Controls.Add(radioSemCaronaGui);
            groupBoxGuilherme.Controls.Add(radiobtnIdaGui);
            groupBoxGuilherme.Controls.Add(radiobtnVoltaGui);
            groupBoxGuilherme.Controls.Add(radiobtnIdaVoltaGui);
            groupBoxGuilherme.Location = new Point(140, 133);
            groupBoxGuilherme.Name = "groupBoxGuilherme";
            groupBoxGuilherme.Size = new Size(200, 175);
            groupBoxGuilherme.TabIndex = 14;
            groupBoxGuilherme.TabStop = false;
            // 
            // lblGuilherme
            // 
            lblGuilherme.AutoSize = true;
            lblGuilherme.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGuilherme.Location = new Point(45, 0);
            lblGuilherme.MinimumSize = new Size(50, 30);
            lblGuilherme.Name = "lblGuilherme";
            lblGuilherme.Size = new Size(110, 30);
            lblGuilherme.TabIndex = 9;
            lblGuilherme.Text = "Guilherme";
            // 
            // radioSemCaronaGui
            // 
            radioSemCaronaGui.AutoSize = true;
            radioSemCaronaGui.Font = new Font("Segoe UI", 14F);
            radioSemCaronaGui.Location = new Point(6, 138);
            radioSemCaronaGui.Name = "radioSemCaronaGui";
            radioSemCaronaGui.Size = new Size(132, 29);
            radioSemCaronaGui.TabIndex = 10;
            radioSemCaronaGui.TabStop = true;
            radioSemCaronaGui.Text = "Sem Carona";
            radioSemCaronaGui.UseVisualStyleBackColor = true;
            // 
            // radiobtnIdaGui
            // 
            radiobtnIdaGui.AutoSize = true;
            radiobtnIdaGui.Font = new Font("Segoe UI", 14F);
            radiobtnIdaGui.Location = new Point(6, 33);
            radiobtnIdaGui.Name = "radiobtnIdaGui";
            radiobtnIdaGui.Size = new Size(56, 29);
            radiobtnIdaGui.TabIndex = 6;
            radiobtnIdaGui.TabStop = true;
            radiobtnIdaGui.Text = "Ida";
            radiobtnIdaGui.UseVisualStyleBackColor = true;
            // 
            // radiobtnVoltaGui
            // 
            radiobtnVoltaGui.AutoSize = true;
            radiobtnVoltaGui.Font = new Font("Segoe UI", 14F);
            radiobtnVoltaGui.Location = new Point(6, 68);
            radiobtnVoltaGui.Name = "radiobtnVoltaGui";
            radiobtnVoltaGui.Size = new Size(73, 29);
            radiobtnVoltaGui.TabIndex = 7;
            radiobtnVoltaGui.TabStop = true;
            radiobtnVoltaGui.Text = "Volta";
            radiobtnVoltaGui.UseVisualStyleBackColor = true;
            // 
            // radiobtnIdaVoltaGui
            // 
            radiobtnIdaVoltaGui.AutoSize = true;
            radiobtnIdaVoltaGui.Font = new Font("Segoe UI", 14F);
            radiobtnIdaVoltaGui.Location = new Point(6, 103);
            radiobtnIdaVoltaGui.Name = "radiobtnIdaVoltaGui";
            radiobtnIdaVoltaGui.Size = new Size(119, 29);
            radiobtnIdaVoltaGui.TabIndex = 8;
            radiobtnIdaVoltaGui.TabStop = true;
            radiobtnIdaVoltaGui.Text = "Ida e Volta";
            radiobtnIdaVoltaGui.UseVisualStyleBackColor = true;
            // 
            // groupBoxKamile
            // 
            groupBoxKamile.Controls.Add(lblKamile);
            groupBoxKamile.Controls.Add(radioSemCaronaKamile);
            groupBoxKamile.Controls.Add(radiobtnIdaKamile);
            groupBoxKamile.Controls.Add(radiobtnVoltaKamile);
            groupBoxKamile.Controls.Add(radiobtnIdaVoltaKamile);
            groupBoxKamile.Location = new Point(465, 133);
            groupBoxKamile.Name = "groupBoxKamile";
            groupBoxKamile.Size = new Size(200, 175);
            groupBoxKamile.TabIndex = 15;
            groupBoxKamile.TabStop = false;
            // 
            // lblKamile
            // 
            lblKamile.AutoSize = true;
            lblKamile.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblKamile.Location = new Point(58, 0);
            lblKamile.MinimumSize = new Size(50, 30);
            lblKamile.Name = "lblKamile";
            lblKamile.Size = new Size(77, 30);
            lblKamile.TabIndex = 10;
            lblKamile.Text = "Kamile";
            // 
            // radioSemCaronaKamile
            // 
            radioSemCaronaKamile.AutoSize = true;
            radioSemCaronaKamile.Font = new Font("Segoe UI", 14F);
            radioSemCaronaKamile.Location = new Point(6, 138);
            radioSemCaronaKamile.Name = "radioSemCaronaKamile";
            radioSemCaronaKamile.Size = new Size(132, 29);
            radioSemCaronaKamile.TabIndex = 11;
            radioSemCaronaKamile.TabStop = true;
            radioSemCaronaKamile.Text = "Sem Carona";
            radioSemCaronaKamile.UseVisualStyleBackColor = true;
            // 
            // radiobtnIdaKamile
            // 
            radiobtnIdaKamile.AutoSize = true;
            radiobtnIdaKamile.Font = new Font("Segoe UI", 14F);
            radiobtnIdaKamile.Location = new Point(6, 33);
            radiobtnIdaKamile.Name = "radiobtnIdaKamile";
            radiobtnIdaKamile.Size = new Size(56, 29);
            radiobtnIdaKamile.TabIndex = 11;
            radiobtnIdaKamile.TabStop = true;
            radiobtnIdaKamile.Text = "Ida";
            radiobtnIdaKamile.UseVisualStyleBackColor = true;
            // 
            // radiobtnVoltaKamile
            // 
            radiobtnVoltaKamile.AutoSize = true;
            radiobtnVoltaKamile.Font = new Font("Segoe UI", 14F);
            radiobtnVoltaKamile.Location = new Point(6, 68);
            radiobtnVoltaKamile.Name = "radiobtnVoltaKamile";
            radiobtnVoltaKamile.Size = new Size(73, 29);
            radiobtnVoltaKamile.TabIndex = 12;
            radiobtnVoltaKamile.TabStop = true;
            radiobtnVoltaKamile.Text = "Volta";
            radiobtnVoltaKamile.UseVisualStyleBackColor = true;
            // 
            // radiobtnIdaVoltaKamile
            // 
            radiobtnIdaVoltaKamile.AutoSize = true;
            radiobtnIdaVoltaKamile.Font = new Font("Segoe UI", 14F);
            radiobtnIdaVoltaKamile.Location = new Point(6, 103);
            radiobtnIdaVoltaKamile.Name = "radiobtnIdaVoltaKamile";
            radiobtnIdaVoltaKamile.Size = new Size(119, 29);
            radiobtnIdaVoltaKamile.TabIndex = 13;
            radiobtnIdaVoltaKamile.TabStop = true;
            radiobtnIdaVoltaKamile.Text = "Ida e Volta";
            radiobtnIdaVoltaKamile.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            btnSalvar.Font = new Font("Segoe UI", 15F);
            btnSalvar.Location = new Point(324, 314);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(159, 44);
            btnSalvar.TabIndex = 16;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // lblValorTotalGui
            // 
            lblValorTotalGui.AutoSize = true;
            lblValorTotalGui.Font = new Font("Segoe UI", 17F);
            lblValorTotalGui.LinkColor = Color.Navy;
            lblValorTotalGui.Location = new Point(203, 404);
            lblValorTotalGui.MinimumSize = new Size(100, 50);
            lblValorTotalGui.Name = "lblValorTotalGui";
            lblValorTotalGui.Size = new Size(100, 50);
            lblValorTotalGui.TabIndex = 17;
            lblValorTotalGui.TabStop = true;
            lblValorTotalGui.Text = "ValorGui";
            lblValorTotalGui.LinkClicked += lblValorTotalGui_LinkClicked;
            // 
            // lblValorTotalKamile
            // 
            lblValorTotalKamile.AutoSize = true;
            lblValorTotalKamile.Font = new Font("Segoe UI", 17F);
            lblValorTotalKamile.LinkColor = Color.Navy;
            lblValorTotalKamile.Location = new Point(716, 404);
            lblValorTotalKamile.MinimumSize = new Size(100, 50);
            lblValorTotalKamile.Name = "lblValorTotalKamile";
            lblValorTotalKamile.Size = new Size(134, 50);
            lblValorTotalKamile.TabIndex = 18;
            lblValorTotalKamile.TabStop = true;
            lblValorTotalKamile.Text = "ValorKamile";
            lblValorTotalKamile.LinkClicked += lblValorTotalKamile_LinkClicked;
            // 
            // lblTxtValorTotalGui
            // 
            lblTxtValorTotalGui.AutoSize = true;
            lblTxtValorTotalGui.Font = new Font("Segoe UI", 15F);
            lblTxtValorTotalGui.Location = new Point(5, 406);
            lblTxtValorTotalGui.Name = "lblTxtValorTotalGui";
            lblTxtValorTotalGui.Size = new Size(203, 28);
            lblTxtValorTotalGui.TabIndex = 19;
            lblTxtValorTotalGui.Text = "Valor Total Guilherme:";
            // 
            // lblTxtValorTotalKamile
            // 
            lblTxtValorTotalKamile.AutoSize = true;
            lblTxtValorTotalKamile.Font = new Font("Segoe UI", 15F);
            lblTxtValorTotalKamile.Location = new Point(434, 406);
            lblTxtValorTotalKamile.Name = "lblTxtValorTotalKamile";
            lblTxtValorTotalKamile.Size = new Size(287, 28);
            lblTxtValorTotalKamile.TabIndex = 20;
            lblTxtValorTotalKamile.Text = "Valor Total a pagar para Kamile:";
            // 
            // btnAnterior
            // 
            btnAnterior.Location = new Point(635, 76);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(75, 23);
            btnAnterior.TabIndex = 21;
            btnAnterior.Text = "Anterior";
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnProximo
            // 
            btnProximo.Location = new Point(716, 76);
            btnProximo.Name = "btnProximo";
            btnProximo.Size = new Size(75, 23);
            btnProximo.TabIndex = 22;
            btnProximo.Text = "Próximo";
            btnProximo.UseVisualStyleBackColor = true;
            btnProximo.Click += btnProximo_Click;
            // 
            // lblAviso
            // 
            lblAviso.AutoSize = true;
            lblAviso.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblAviso.ForeColor = SystemColors.ControlText;
            lblAviso.Location = new Point(358, 88);
            lblAviso.Name = "lblAviso";
            lblAviso.Size = new Size(76, 28);
            lblAviso.TabIndex = 23;
            lblAviso.Text = "Aviso";
            lblAviso.Visible = false;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblAviso);
            Controls.Add(btnProximo);
            Controls.Add(btnAnterior);
            Controls.Add(lblTxtValorTotalKamile);
            Controls.Add(lblTxtValorTotalGui);
            Controls.Add(lblValorTotalKamile);
            Controls.Add(lblValorTotalGui);
            Controls.Add(btnSalvar);
            Controls.Add(groupBoxKamile);
            Controls.Add(groupBoxGuilherme);
            Controls.Add(btnAlterar);
            Controls.Add(txtboxDatadeHoje);
            Controls.Add(lblDataHoje);
            Controls.Add(txtboxValorPassagem);
            Controls.Add(lblValorPassagem);
            Name = "Main";
            Text = "Ida e Volta";
            Load += Form1_Load;
            groupBoxGuilherme.ResumeLayout(false);
            groupBoxGuilherme.PerformLayout();
            groupBoxKamile.ResumeLayout(false);
            groupBoxKamile.PerformLayout();
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
        private RadioButton radiobtnIdaGui;
        private RadioButton radiobtnVoltaGui;
        private RadioButton radiobtnIdaVoltaGui;
        private Label lblGuilherme;
        private Label lblKamile;
        private RadioButton radiobtnIdaKamile;
        private RadioButton radiobtnVoltaKamile;
        private RadioButton radiobtnIdaVoltaKamile;
        private GroupBox groupBoxGuilherme;
        private GroupBox groupBoxKamile;
        private Button btnSalvar;
        private LinkLabel lblValorTotalGui;
        private LinkLabel lblValorTotalKamile;
        private Label lblTxtValorTotalGui;
        private Label lblTxtValorTotalKamile;
        private RadioButton radioSemCaronaGui;
        private RadioButton radioSemCaronaKamile;
        private Button btnAnterior;
        private Button btnProximo;
        private Label lblAviso;
    }
}
