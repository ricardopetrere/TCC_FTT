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
        public Form1()
        {
            InitializeComponent();
            Util.ComunicacaoRede.IniciarServidor();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            lblStatusEnvio.Text = "Enviando";
            lblStatusEnvio.Text = Util.ComunicacaoRede.EnviarPacote(txtMensagemEnviada.Text);
        }

    }
}
