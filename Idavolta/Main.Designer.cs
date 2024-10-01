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
            components = new System.ComponentModel.Container();
            lblValorPassagem = new Label();
            txtboxValorPassagem = new TextBox();
            lblDataHoje = new Label();
            txtboxDatadeHoje = new TextBox();
            btnAlterar = new Button();
            imageList1 = new ImageList(components);
            notifyIcon1 = new NotifyIcon(components);
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
            txtboxDatadeHoje.Enabled = false;
            txtboxDatadeHoje.Location = new Point(664, 47);
            txtboxDatadeHoje.Name = "txtboxDatadeHoje";
            txtboxDatadeHoje.ReadOnly = true;
            txtboxDatadeHoje.Size = new Size(100, 23);
            txtboxDatadeHoje.TabIndex = 4;
            txtboxDatadeHoje.Text = "01/10/2024";
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
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAlterar);
            Controls.Add(txtboxDatadeHoje);
            Controls.Add(lblDataHoje);
            Controls.Add(txtboxValorPassagem);
            Controls.Add(lblValorPassagem);
            Name = "Main";
            Text = "Ida e Volta";
            Load += Form1_Load;
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
    }
}
