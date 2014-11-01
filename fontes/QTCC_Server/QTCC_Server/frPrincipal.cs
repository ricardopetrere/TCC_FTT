using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CFG_BD_XML;
using QTCC_Server.VO;
using QTCC_Server.Util;

namespace QTCC_Server
{
    public partial class frPrincipal : Form
    {
        public frPrincipal()
        {
            InitializeComponent();
            //ComunicacaoRede.onPacoteRecebido += ComunicacaoController.ComunicacaoRede_onPacoteRecebido;
        }
        
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarListaContatos(listView1.SelectedIndices.Count>0);
        }

        private void MostrarListaContatos(bool mostrar)
        {
            if (mostrar)
            {
                groupBox1.Visible = true;
            }
            else
            {
                groupBox1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja reconfigurar o acesso ao banco de dados?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                ComunicacaoRede.FechaConexao();
                if (new frConexaoBD().ShowDialog() == DialogResult.OK)
                {

                }
                ComunicacaoRede.IniciarServidor();
            }
        }

        private void frPrincipal_Load(object sender, EventArgs e)
        {
            //Se conseguiu ler o BD.XML, faz as configurações necessárias e escuta a porta. Caso contrário, o próprio CFG_BD_XML trata de sair da aplicação.
            if (BD_Connection.LeuBDXML())
            {
                ComunicacaoRede.IniciarServidor();
            }
        }

        private void frPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            //ComunicacaoRede.FechaConexao();
        }
    }
}
