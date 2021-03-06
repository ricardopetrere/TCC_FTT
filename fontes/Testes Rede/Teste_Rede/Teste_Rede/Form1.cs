﻿using System;
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
            numPorta.Value = Util.ComunicacaoRede.Porta_TCP;
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
