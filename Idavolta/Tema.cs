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
                main.ResumeLayout(false);
                main.PerformLayout();
            }
            return main;

        }
    }
}
