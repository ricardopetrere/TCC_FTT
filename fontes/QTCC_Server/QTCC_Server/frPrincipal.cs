using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CFG_BD_XML;
using QTCC_Server.Controller;
using QTCC_Server.VO;
using QTCC_Server.Util;

namespace QTCC_Server
{
    public partial class frPrincipal : Form
    {
        public frPrincipal()
        {
            InitializeComponent();
        }
        
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarListaContatos(lstUsuariosOnline.SelectedIndices.Count>0);
        }

        private void MostrarListaContatos(bool mostrar)
        {
            if (mostrar)
            {
                grpContatos.Visible = true;
                timerContatosUsuario.Start();
                LeContatosUsuarioSelecionado();
            }
            else
            {
                grpContatos.Visible = false;
                timerContatosUsuario.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja reconfigurar o acesso ao banco de dados?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                //Dessa forma, é possível alterar a conexão do banco sem comprometer os dados
                ComunicacaoRede.FechaConexao();
                timerUsuariosOnline.Stop();
                timerContatosUsuario.Stop(); //Só para garantir
                if (new frConexaoBD().ShowDialog() == DialogResult.OK)
                {
                    LeUsuariosOnline();
                }
                //Reinicia a conexão de rede, agora com as configurações de acesso ao banco de dados atualizadas.
                ComunicacaoRede.IniciarServidor();
                timerUsuariosOnline.Start();
            }
        }

        private void frPrincipal_Load(object sender, EventArgs e)
        {
            //Se conseguiu ler o BD.XML, faz as configurações necessárias e escuta a porta. Caso contrário, o próprio CFG_BD_XML trata de sair da aplicação.
            if (BD_Connection.LeuBDXML())
            {
                ComunicacaoRede.IniciarServidor();
                timerUsuariosOnline.Start();
                LeUsuariosOnline();
            }
        }

        private void frPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        void LeUsuariosOnline()
        {
            int usuario_selecionado = 0;
            if (lstUsuariosOnline.SelectedItems.Count > 0)
                usuario_selecionado = Convert.ToInt32(lstUsuariosOnline.SelectedItems[0].SubItems[2].Text);
            lstUsuariosOnline.Items.Clear();
            String sql = "select cont.cont_id,cont.cont_nome,tmp.log_visto_ultimo from tbContato cont inner join tbUsuario usu on usu.cont_id=cont.cont_id left join tmpUsuariosLogados tmp on tmp.cont_id = cont.cont_id where cont_inativo = 0";
            foreach(DataRow registro in  BD_SQL.ExecutaSelect(sql).Rows)
            {
                ListViewItem itmUsuarioOnline = new ListViewItem();
                itmUsuarioOnline.Text = registro["cont_nome"].ToString();
                DateTime dtaVistoUltimo = DateTime.MinValue;
                if((registro["log_visto_ultimo"]).GetType()!=typeof(System.DBNull))
                    dtaVistoUltimo = Convert.ToDateTime(registro["log_visto_ultimo"]);
                itmUsuarioOnline.SubItems.Add(DeterminarTempoOnline(dtaVistoUltimo));
                itmUsuarioOnline.SubItems.Add(registro["cont_id"].ToString());
                lstUsuariosOnline.Items.Add(itmUsuarioOnline);
            }
            if (usuario_selecionado > 0)
                lstUsuariosOnline.FindItemWithText(usuario_selecionado.ToString(), true, 0).Selected = true;
        }
        String DeterminarTempoOnline(DateTime dta_visto_ultimo)
        {
            DateTime agora = DateTime.Now;
            TimeSpan diferenca_tempo = agora.Subtract(dta_visto_ultimo);
            if (diferenca_tempo.TotalMinutes < 1)
                return "Online";
            else if (diferenca_tempo.TotalMinutes < 60)
                return "Há " + ((int)diferenca_tempo.TotalMinutes).ToString() + " minutos";
            else if (dta_visto_ultimo.Subtract(agora.Date).TotalDays >= 0)
                return "Hoje às " + dta_visto_ultimo.ToString("HH:mm");
            else if (dta_visto_ultimo.Subtract(agora.Date).TotalDays > -1)
                return "Ontem às " + dta_visto_ultimo.ToString("HH:mm");
            else if (dta_visto_ultimo == DateTime.MinValue)
                return "Nunca";
            return dta_visto_ultimo.ToString("dd/MM/yyyy HH:mm");
        }

        private void timerUsuariosOnline_Tick(object sender, EventArgs e)
        {
            LeUsuariosOnline();
        }

        private void timerContatosUsuario_Tick(object sender, EventArgs e)
        {
            LeContatosUsuarioSelecionado();
        }
        void LeContatosUsuarioSelecionado()
        {
            LeContatosUsuarioSelecionado(Convert.ToInt32(lstUsuariosOnline.SelectedItems[0].SubItems[2].Text));
        }
        void LeContatosUsuarioSelecionado(int cont_id)
        {
            lstContatos.Items.Clear();
            foreach(Contato contato in new UsuarioController().BuscaContatos(cont_id))
            {
                ListViewItem itmContatoUsuario = new ListViewItem();
                itmContatoUsuario.Text = contato.Nome;
                lstContatos.Items.Add(itmContatoUsuario);
            }
        }
    }
}
