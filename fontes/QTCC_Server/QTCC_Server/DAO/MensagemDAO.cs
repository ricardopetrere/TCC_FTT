using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using QTCC_Server.VO;
using System.Data.SqlClient;
using CFG_BD_XML;

namespace QTCC_Server.DAO
{
    class MensagemDAO
    {
        public static Mensagem MontaVOMensagemPendente(DataRow registro)
        {
            Mensagem retorno = new Mensagem();
            retorno.Contato_De = ContatoDAO.BuscaContato(Convert.ToInt32(registro["msg_usu_ori"]));
            retorno.Contato_Para = ContatoDAO.BuscaContato(Convert.ToInt32(registro["cont_id"]));
            retorno.Data_Envio = Convert.ToDateTime(registro["msg_dta_envio"]);
            retorno.Dados = (byte[])registro["msg_texto"];//Encoding.Default.GetBytes(registro["msg_texto"].ToString());
            retorno.Status_Envio = CONSTANTES.StatusEnvioEnum.EnviadoAoServidor;
            //A princípio fica assim.
            retorno.Tipo_Mensagem = CONSTANTES.TipoMensagemEnum.Texto;
            return retorno;
        }
        public static List<Mensagem> ReceberNovasMensagens(int cont_id)
        {
            List<Mensagem> retorno = new List<Mensagem>();
            SqlConnection c = BD_SQL.Connection;
            try
            {
                c.Open();
                SqlCommand cmd = new SqlCommand("select cont_id, msg_usu_ori, msg_dta_envio, msg_texto from tmpMensagensPendentes where cont_id = @Cont_Id"
                    + ";delete from tmpMensagensPendentes where cont_id = @Cont_Id", c);
                cmd.Parameters.AddWithValue("@Cont_Id", cont_id);
                foreach (DataRow registro in BD_SQL.ExecutaSelect(cmd).Rows)
                {
                    retorno.Add(MontaVOMensagemPendente(registro));
                }
                UsuarioDAO.AtualizaStatus(cont_id);
            }
            finally
            {
                c.Close();
            }
            return retorno;
        }
        public static string EnviarNovaMensagem(Mensagem mensagem)
        {
            String retorno = "Falha no envio da mensagem";
            SqlConnection c = BD_SQL.Connection;
            try
            {
                c.Open();
                SqlCommand cmd = new SqlCommand("spInsereMensagem", c);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cont_Id", mensagem.Contato_Para.IDContato);
                cmd.Parameters.AddWithValue("@Msg_Usu_Ori", mensagem.Contato_De.IDContato);
                cmd.Parameters.AddWithValue("@Msg_Dta_Envio", mensagem.Data_Envio);
                cmd.Parameters.AddWithValue("@Msg_Texto", mensagem.Dados);
                BD_SQL.ExecutaSQL(cmd);
                UsuarioDAO.AtualizaStatus(mensagem.Contato_De.IDContato);
                retorno = "Enviado com sucesso";
            }
            finally
            {
                c.Close();
            }
            return retorno;
        }
        public static int StatusMensagem(Mensagem mensagem)
        {
            int retorno = 0;
            SqlConnection c = BD_SQL.Connection;
            try
            {
                //Vai que...
                if (mensagem.Status_Envio == CONSTANTES.StatusEnvioEnum.EntregaPendente)
                    return 1;
                c.Open();
                SqlCommand cmd = new SqlCommand("if exists "
                    +"(select cont_id, msg_usu_ori, msg_dta_envio from tmpMensagensPendentes where "
                    +"cont_id = @Cont_Id and msg_usu_ori = @Msg_Usu_Ori and msg_dta_envio = @Msg_Dta_Envio)"
                    + "\nselect 2 as Status"
                    +"\nelse\nselect 3 as Status", c);
                cmd.Parameters.AddWithValue("@Cont_Id", mensagem.Contato_Para.IDContato);
                cmd.Parameters.AddWithValue("@Msg_Usu_Ori", mensagem.Contato_De.IDContato);
                cmd.Parameters.AddWithValue("@Msg_Dta_Envio", mensagem.Data_Envio);
                retorno = Convert.ToInt32(BD_SQL.ExecutaSelect(cmd).Rows[0]["Status"]);
                UsuarioDAO.AtualizaStatus(mensagem.Contato_De.IDContato);
            }
            finally
            {
                c.Close();
            }
            return retorno;
        }
    }
}
