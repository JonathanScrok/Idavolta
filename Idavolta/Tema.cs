using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Idavolta
{
    public class Tema
    {
        public static Main AlterarTema(string tema, Main main)
        {
            if (tema == "CORAL")
            {
                // 
                // lblValorPassagem
                // 
                main.LblValorPassagem.AutoSize = true;
                main.LblValorPassagem.Font = new Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
                main.LblValorPassagem.Location = new Point(40, 43);
                main.LblValorPassagem.Margin = new Padding(4, 0, 4, 0);
                main.LblValorPassagem.Name = "lblValorPassagem";
                main.LblValorPassagem.Size = new Size(137, 22);
                main.LblValorPassagem.TabIndex = 0;
                main.LblValorPassagem.Text = "Valor da Passagem:";
                // 
                // txtboxValorPassagem
                // 
                main.TxtboxValorPassagem.Enabled = false;
                main.TxtboxValorPassagem.Location = new Point(40, 69);
                main.TxtboxValorPassagem.Margin = new Padding(4);
                main.TxtboxValorPassagem.Name = "txtboxValorPassagem";
                main.TxtboxValorPassagem.ReadOnly = true;
                main.TxtboxValorPassagem.Size = new Size(138, 29);
                main.TxtboxValorPassagem.TabIndex = 1;
                // 
                // lblDataHoje
                // 
                main.LblDataHoje.AutoSize = true;
                main.LblDataHoje.Location = new Point(854, 43);
                main.LblDataHoje.Margin = new Padding(4, 0, 4, 0);
                main.LblDataHoje.Name = "lblDataHoje";
                main.LblDataHoje.Size = new Size(99, 22);
                main.LblDataHoje.TabIndex = 2;
                main.LblDataHoje.Text = "Data de Hoje:";
                // 
                // txtboxDatadeHoje
                // 
                main.TxtboxDatadeHoje.Location = new Point(854, 69);
                main.TxtboxDatadeHoje.Margin = new Padding(4);
                main.TxtboxDatadeHoje.Name = "txtboxDatadeHoje";
                main.TxtboxDatadeHoje.Size = new Size(127, 29);
                main.TxtboxDatadeHoje.TabIndex = 4;
                // 
                // btnAlterar
                // 
                main.BtnAlterar.BackColor = Color.Coral;
                main.BtnAlterar.Font = new Font("Sylfaen", 12F, FontStyle.Bold);
                main.BtnAlterar.ForeColor = Color.Snow;
                main.BtnAlterar.Location = new Point(40, 111);
                main.BtnAlterar.Margin = new Padding(4);
                main.BtnAlterar.Name = "btnAlterar";
                main.BtnAlterar.Size = new Size(139, 43);
                main.BtnAlterar.TabIndex = 5;
                main.BtnAlterar.Text = "Alterar";
                main.BtnAlterar.UseVisualStyleBackColor = false;
                // 
                // groupBoxGuilherme
                // 
                main.GroupBoxGuilherme.Controls.Add(main.LblGuilherme);
                main.GroupBoxGuilherme.Controls.Add(main.RadioSemCaronaGui);
                main.GroupBoxGuilherme.Controls.Add(main.RadiobtnIdaGui);
                main.GroupBoxGuilherme.Controls.Add(main.RadiobtnVoltaGui);
                main.GroupBoxGuilherme.Controls.Add(main.RadiobtnIdaVoltaGui);
                main.GroupBoxGuilherme.Location = new Point(180, 195);
                main.GroupBoxGuilherme.Margin = new Padding(4);
                main.GroupBoxGuilherme.Name = "main.GroupBoxGuilherme";
                main.GroupBoxGuilherme.Padding = new Padding(4);
                main.GroupBoxGuilherme.Size = new Size(257, 257);
                main.GroupBoxGuilherme.TabIndex = 14;
                main.GroupBoxGuilherme.TabStop = false;
                // 
                // lblGuilherme
                // 
                main.LblGuilherme.AutoSize = true;
                main.LblGuilherme.Font = new Font("Segoe UI Black", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
                main.LblGuilherme.Location = new Point(58, 0);
                main.LblGuilherme.Margin = new Padding(4, 0, 4, 0);
                main.LblGuilherme.MinimumSize = new Size(64, 44);
                main.LblGuilherme.Name = "lblGuilherme";
                main.LblGuilherme.Size = new Size(114, 44);
                main.LblGuilherme.TabIndex = 9;
                main.LblGuilherme.Text = "Guilherme";
                // 
                // radioSemCaronaGui
                // 
                main.RadioSemCaronaGui.AutoSize = true;
                main.RadioSemCaronaGui.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
                main.RadioSemCaronaGui.Location = new Point(8, 202);
                main.RadioSemCaronaGui.Margin = new Padding(4);
                main.RadioSemCaronaGui.Name = "radioSemCaronaGui";
                main.RadioSemCaronaGui.Size = new Size(133, 29);
                main.RadioSemCaronaGui.TabIndex = 10;
                main.RadioSemCaronaGui.TabStop = true;
                main.RadioSemCaronaGui.Text = "Sem Carona";
                main.RadioSemCaronaGui.UseVisualStyleBackColor = true;
                // 
                // radiobtnIdaGui
                // 
                main.RadiobtnIdaGui.AutoSize = true;
                main.RadiobtnIdaGui.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
                main.RadiobtnIdaGui.Location = new Point(8, 48);
                main.RadiobtnIdaGui.Margin = new Padding(4);
                main.RadiobtnIdaGui.Name = "radiobtnIdaGui";
                main.RadiobtnIdaGui.Size = new Size(57, 29);
                main.RadiobtnIdaGui.TabIndex = 6;
                main.RadiobtnIdaGui.TabStop = true;
                main.RadiobtnIdaGui.Text = "Ida";
                main.RadiobtnIdaGui.UseVisualStyleBackColor = true;
                // 
                // radiobtnVoltaGui
                // 
                main.RadiobtnVoltaGui.AutoSize = true;
                main.RadiobtnVoltaGui.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
                main.RadiobtnVoltaGui.Location = new Point(8, 100);
                main.RadiobtnVoltaGui.Margin = new Padding(4);
                main.RadiobtnVoltaGui.Name = "radiobtnVoltaGui";
                main.RadiobtnVoltaGui.Size = new Size(74, 29);
                main.RadiobtnVoltaGui.TabIndex = 7;
                main.RadiobtnVoltaGui.TabStop = true;
                main.RadiobtnVoltaGui.Text = "Volta";
                main.RadiobtnVoltaGui.UseVisualStyleBackColor = true;
                // 
                // radiobtnIdaVoltaGui
                // 
                main.RadiobtnIdaVoltaGui.AutoSize = true;
                main.RadiobtnIdaVoltaGui.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
                main.RadiobtnIdaVoltaGui.Location = new Point(8, 151);
                main.RadiobtnIdaVoltaGui.Margin = new Padding(4);
                main.RadiobtnIdaVoltaGui.Name = "radiobtnIdaVoltaGui";
                main.RadiobtnIdaVoltaGui.Size = new Size(121, 29);
                main.RadiobtnIdaVoltaGui.TabIndex = 8;
                main.RadiobtnIdaVoltaGui.TabStop = true;
                main.RadiobtnIdaVoltaGui.Text = "Ida e Volta";
                main.RadiobtnIdaVoltaGui.UseVisualStyleBackColor = true;
                // 
                // groupBoxKamile
                // 
                main.GroupBoxKamile.Controls.Add(main.LblKamile);
                main.GroupBoxKamile.Controls.Add(main.RadioSemCaronaKamile);
                main.GroupBoxKamile.Controls.Add(main.RadiobtnIdaKamile);
                main.GroupBoxKamile.Controls.Add(main.RadiobtnVoltaKamile);
                main.GroupBoxKamile.Controls.Add(main.RadiobtnIdaVoltaKamile);
                main.GroupBoxKamile.Location = new Point(598, 195);
                main.GroupBoxKamile.Margin = new Padding(4);
                main.GroupBoxKamile.Name = "groupBoxKamile";
                main.GroupBoxKamile.Padding = new Padding(4);
                main.GroupBoxKamile.Size = new Size(257, 257);
                main.GroupBoxKamile.TabIndex = 15;
                main.GroupBoxKamile.TabStop = false;
                // 
                // lblKamile
                // 
                main.LblKamile.AutoSize = true;
                main.LblKamile.Font = new Font("Segoe UI Black", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
                main.LblKamile.Location = new Point(75, 0);
                main.LblKamile.Margin = new Padding(4, 0, 4, 0);
                main.LblKamile.MinimumSize = new Size(64, 44);
                main.LblKamile.Name = "lblKamile";
                main.LblKamile.Size = new Size(79, 44);
                main.LblKamile.TabIndex = 10;
                main.LblKamile.Text = "Kamile";
                // 
                // radioSemCaronaKamile
                // 
                main.RadioSemCaronaKamile.AutoSize = true;
                main.RadioSemCaronaKamile.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
                main.RadioSemCaronaKamile.Location = new Point(8, 202);
                main.RadioSemCaronaKamile.Margin = new Padding(4);
                main.RadioSemCaronaKamile.Name = "radioSemCaronaKamile";
                main.RadioSemCaronaKamile.Size = new Size(133, 29);
                main.RadioSemCaronaKamile.TabIndex = 11;
                main.RadioSemCaronaKamile.TabStop = true;
                main.RadioSemCaronaKamile.Text = "Sem Carona";
                main.RadioSemCaronaKamile.UseVisualStyleBackColor = true;
                // 
                // radiobtnIdaKamile
                // 
                main.RadiobtnIdaKamile.AutoSize = true;
                main.RadiobtnIdaKamile.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
                main.RadiobtnIdaKamile.Location = new Point(8, 48);
                main.RadiobtnIdaKamile.Margin = new Padding(4);
                main.RadiobtnIdaKamile.Name = "radiobtnIdaKamile";
                main.RadiobtnIdaKamile.Size = new Size(57, 29);
                main.RadiobtnIdaKamile.TabIndex = 11;
                main.RadiobtnIdaKamile.TabStop = true;
                main.RadiobtnIdaKamile.Text = "Ida";
                main.RadiobtnIdaKamile.UseVisualStyleBackColor = true;
                // 
                // radiobtnVoltaKamile
                // 
                main.RadiobtnVoltaKamile.AutoSize = true;
                main.RadiobtnVoltaKamile.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
                main.RadiobtnVoltaKamile.Location = new Point(8, 100);
                main.RadiobtnVoltaKamile.Margin = new Padding(4);
                main.RadiobtnVoltaKamile.Name = "radiobtnVoltaKamile";
                main.RadiobtnVoltaKamile.Size = new Size(74, 29);
                main.RadiobtnVoltaKamile.TabIndex = 12;
                main.RadiobtnVoltaKamile.TabStop = true;
                main.RadiobtnVoltaKamile.Text = "Volta";
                main.RadiobtnVoltaKamile.UseVisualStyleBackColor = true;
                // 
                // radiobtnIdaVoltaKamile
                // 
                main.RadiobtnIdaVoltaKamile.AutoSize = true;
                main.RadiobtnIdaVoltaKamile.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
                main.RadiobtnIdaVoltaKamile.Location = new Point(8, 151);
                main.RadiobtnIdaVoltaKamile.Margin = new Padding(4);
                main.RadiobtnIdaVoltaKamile.Name = "radiobtnIdaVoltaKamile";
                main.RadiobtnIdaVoltaKamile.Size = new Size(121, 29);
                main.RadiobtnIdaVoltaKamile.TabIndex = 13;
                main.RadiobtnIdaVoltaKamile.TabStop = true;
                main.RadiobtnIdaVoltaKamile.Text = "Ida e Volta";
                main.RadiobtnIdaVoltaKamile.UseVisualStyleBackColor = true;
                // 
                // btnSalvar
                // 
                main.BtnSalvar.BackColor = Color.Coral;
                main.BtnSalvar.Font = new Font("Sylfaen", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
                main.BtnSalvar.ForeColor = Color.Snow;
                main.BtnSalvar.Location = new Point(417, 461);
                main.BtnSalvar.Margin = new Padding(4);
                main.BtnSalvar.Name = "btnSalvar";
                main.BtnSalvar.Size = new Size(204, 65);
                main.BtnSalvar.TabIndex = 16;
                main.BtnSalvar.Text = "Salvar";
                main.BtnSalvar.UseVisualStyleBackColor = false;
                // 
                // lblValorTotalGui
                // 
                main.LblValorTotalGui.AutoSize = true;
                main.LblValorTotalGui.Font = new Font("Segoe UI", 17F);
                main.LblValorTotalGui.LinkColor = Color.Navy;
                main.LblValorTotalGui.Location = new Point(207, 593);
                main.LblValorTotalGui.Margin = new Padding(4, 0, 4, 0);
                main.LblValorTotalGui.MinimumSize = new Size(129, 73);
                main.LblValorTotalGui.Name = "lblValorTotalGui";
                main.LblValorTotalGui.Padding = new Padding(5, 0, 0, 0);
                main.LblValorTotalGui.Size = new Size(129, 73);
                main.LblValorTotalGui.TabIndex = 17;
                main.LblValorTotalGui.TabStop = true;
                main.LblValorTotalGui.Text = "ValorGui";
                // 
                // lblValorTotalKamile
                // 
                main.LblValorTotalKamile.AutoSize = true;
                main.LblValorTotalKamile.Font = new Font("Segoe UI", 17F);
                main.LblValorTotalKamile.LinkColor = Color.Navy;
                main.LblValorTotalKamile.Location = new Point(872, 593);
                main.LblValorTotalKamile.Margin = new Padding(4, 0, 4, 0);
                main.LblValorTotalKamile.MinimumSize = new Size(129, 73);
                main.LblValorTotalKamile.Name = "lblValorTotalKamile";
                main.LblValorTotalKamile.Padding = new Padding(5, 0, 0, 0);
                main.LblValorTotalKamile.Size = new Size(139, 73);
                main.LblValorTotalKamile.TabIndex = 18;
                main.LblValorTotalKamile.TabStop = true;
                main.LblValorTotalKamile.Text = "ValorKamile";
                // 
                // lblTxtValorTotalGui
                // 
                main.LblTxtValorTotalGui.AutoSize = true;
                main.LblTxtValorTotalGui.Font = new Font("Segoe UI", 15F);
                main.LblTxtValorTotalGui.Location = new Point(6, 595);
                main.LblTxtValorTotalGui.Margin = new Padding(4, 0, 4, 0);
                main.LblTxtValorTotalGui.Name = "lblTxtValorTotalGui";
                main.LblTxtValorTotalGui.Size = new Size(203, 28);
                main.LblTxtValorTotalGui.TabIndex = 19;
                main.LblTxtValorTotalGui.Text = "Valor Total Guilherme:";
                // 
                // lblTxtValorTotalKamile
                // 
                main.LblTxtValorTotalKamile.AutoSize = true;
                main.LblTxtValorTotalKamile.Font = new Font("Segoe UI", 15F);
                main.LblTxtValorTotalKamile.Location = new Point(587, 595);
                main.LblTxtValorTotalKamile.Margin = new Padding(4, 0, 4, 0);
                main.LblTxtValorTotalKamile.Name = "lblTxtValorTotalKamile";
                main.LblTxtValorTotalKamile.Size = new Size(287, 28);
                main.LblTxtValorTotalKamile.TabIndex = 20;
                main.LblTxtValorTotalKamile.Text = "Valor Total a pagar para Kamile:";
                // 
                // btnAnterior
                // 
                main.BtnAnterior.BackColor = Color.Coral;
                main.BtnAnterior.Font = new Font("Sylfaen", 12F, FontStyle.Bold);
                main.BtnAnterior.ForeColor = Color.Snow;
                main.BtnAnterior.Location = new Point(817, 106);
                main.BtnAnterior.Margin = new Padding(4);
                main.BtnAnterior.Name = "btnAnterior";
                main.BtnAnterior.Size = new Size(96, 32);
                main.BtnAnterior.TabIndex = 21;
                main.BtnAnterior.Text = "Anterior";
                main.BtnAnterior.UseVisualStyleBackColor = false;
                // 
                // btnProximo
                // 
                main.BtnProximo.BackColor = Color.Coral;
                main.BtnProximo.Font = new Font("Sylfaen", 12F, FontStyle.Bold);
                main.BtnProximo.ForeColor = Color.Snow;
                main.BtnProximo.Location = new Point(920, 106);
                main.BtnProximo.Margin = new Padding(4);
                main.BtnProximo.Name = "btnProximo";
                main.BtnProximo.Size = new Size(96, 32);
                main.BtnProximo.TabIndex = 22;
                main.BtnProximo.Text = "Próximo";
                main.BtnProximo.UseVisualStyleBackColor = false;
                // 
                // lblAviso
                // 
                main.LblAviso.AutoSize = true;
                main.LblAviso.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
                main.LblAviso.ForeColor = SystemColors.ControlText;
                main.LblAviso.Location = new Point(460, 129);
                main.LblAviso.Margin = new Padding(4, 0, 4, 0);
                main.LblAviso.Name = "lblAviso";
                main.LblAviso.Size = new Size(76, 28);
                main.LblAviso.TabIndex = 23;
                main.LblAviso.Text = "Aviso";
                main.LblAviso.Visible = false;


                // 
                // Main
                // 
                main.AutoScaleDimensions = new SizeF(9F, 22F);
                main.BackColor = Color.Bisque;
                main.ClientSize = new Size(900, 470);
                main.Font = new Font("Sylfaen", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
                main.ForeColor = Color.Coral;
                main.Margin = new Padding(4);
                main.GroupBoxGuilherme.ResumeLayout(false);
                main.GroupBoxGuilherme.PerformLayout();
                main.GroupBoxKamile.ResumeLayout(false);
                main.GroupBoxKamile.PerformLayout();
                main.ResumeLayout(false);
                main.PerformLayout();
            }
            return main;

        }
    }
}
