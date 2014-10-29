using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Teste_Rede
{
    public partial class Form1 : Form
    {
        internal static Form1 entidade;
        //Util.ComunicacaoRede servidor = new Util.ComunicacaoRede();
        public Form1()
        {
            InitializeComponent();
            entidade = this;
            numPorta.Value = Util.ComunicacaoRede.Porta_TCP;
            //servidor.IniciarServidor();
            Util.ComunicacaoRede.onAtualizaTela += ComunicacaoRede_onAtualizaTela;
            Util.ComunicacaoRede.IniciarServidor();
        }

        void ComunicacaoRede_onAtualizaTela(object sender, EventArgs e)
        {
            this.Invoke(new System.Windows.Forms.MethodInvoker(delegate()
            {
                txtMensagemRecebida.Text = sender.ToString();
            }));
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            lblStatusEnvio.Text = "Enviando";
            lblStatusEnvio.Text = Util.ComunicacaoRede.EnviarPacote(txtMensagemEnviada.Text);
        }
    }
}
