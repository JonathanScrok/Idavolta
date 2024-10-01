namespace Idavolta
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtboxValorPassagem.Text = Util.LerOuCriarExcel().ToString("F2");

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (btnAlterar.Text == "Salvar")
            {
                //Salvar Valor da Passagem

                Util.AlterarValorPassagemExcel(Convert.ToDouble(txtboxValorPassagem.Text));

                txtboxValorPassagem.Enabled = false;
                txtboxValorPassagem.ReadOnly = true;

                btnAlterar.Text = "Alterar";
            }
            else
            {
                txtboxValorPassagem.Enabled = true;
                txtboxValorPassagem.ReadOnly = false;

                btnAlterar.Text = "Salvar";
            }
        }
    }
}
