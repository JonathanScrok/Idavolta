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
            radiobtnIdaGui = new RadioButton();
            radiobtnVoltaGui = new RadioButton();
            radiobtnIdaVoltaGui = new RadioButton();
            groupBoxKamile = new GroupBox();
            lblKamile = new Label();
            radiobtnIdaKamile = new RadioButton();
            radiobtnVoltaKamile = new RadioButton();
            radiobtnIdaVoltaKamile = new RadioButton();
            btnSalvar = new Button();
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
            groupBoxGuilherme.Controls.Add(radiobtnIdaGui);
            groupBoxGuilherme.Controls.Add(radiobtnVoltaGui);
            groupBoxGuilherme.Controls.Add(radiobtnIdaVoltaGui);
            groupBoxGuilherme.Location = new Point(138, 162);
            groupBoxGuilherme.Name = "groupBoxGuilherme";
            groupBoxGuilherme.Size = new Size(200, 150);
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
            groupBoxKamile.Controls.Add(radiobtnIdaKamile);
            groupBoxKamile.Controls.Add(radiobtnVoltaKamile);
            groupBoxKamile.Controls.Add(radiobtnIdaVoltaKamile);
            groupBoxKamile.Location = new Point(463, 162);
            groupBoxKamile.Name = "groupBoxKamile";
            groupBoxKamile.Size = new Size(200, 150);
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
            btnSalvar.Location = new Point(310, 342);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(167, 44);
            btnSalvar.TabIndex = 16;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}
