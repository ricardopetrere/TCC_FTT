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
        Util.ComunicacaoRede servidor = new Util.ComunicacaoRede();
        public Form1()
        {
            InitializeComponent();
            servidor.IniciarServidor();
            //txtMensagemRecebida.DataBindings.Add(new Binding("Text", servidor, "Texto_Recebido"));
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            lblStatusEnvio.Text = "Enviando";
            lblStatusEnvio.Text = Util.ComunicacaoRede.EnviarPacote(txtMensagemEnviada.Text);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            servidor.ParaThread();
        }

    }
}
