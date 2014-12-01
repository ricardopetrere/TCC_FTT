using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CFG_BD_XML;
using QTCC_Server.VO;

namespace QTCC_Server.DAO
{
    class UsuarioDAO
    {
        public static int Insere(Usuario u)
        {
            SqlConnection c = BD_SQL.Connection;
            try
            {
                c.Open();
                SqlCommand cmd = new SqlCommand("spInsereUsuario", c);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cont_Nome", u.Nome);
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    u.Foto.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    cmd.Parameters.AddWithValue("@Cont_Foto", ms.ToArray());
                }
                cmd.Parameters.AddWithValue("@Usu_Email", u.Email);
                cmd.Parameters.AddWithValue("@Usu_Senha", u.Senha);
                cmd.Parameters.AddWithValue("@Usu_Texto_Status", u.Texto_Status);
                cmd.Parameters.Add("@Cont_Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                BD_SQL.ExecutaSQL(cmd);
                return u.IDContato = (int)cmd.Parameters["@Cont_Id"].Value;
            }
            finally
            {
                c.Close();
            }
        }

        public static Usuario MontaVO(DataRow registro)
        {
            Usuario retorno = new Usuario(ContatoDAO.MontaVO(registro));
            retorno.Texto_Status = registro["usu_texto_status"].ToString();
            retorno.Email = registro["usu_email"].ToString();
            retorno.Senha = registro["usu_senha"].ToString();
            retorno.Contatos = BuscaContatos(retorno.IDContato);
            return retorno;
        }

        public static List<Contato> BuscaContatos(int cont_id)
        {
            List<Contato> contatos = new List<Contato>();
            SqlConnection c = BD_SQL.Connection;
            try
            {
                c.Open();
                SqlCommand cmd = new SqlCommand("select cont_id,lst_id from tbListaContatos where cont_id=@Cont_Id", c);
                cmd.Parameters.AddWithValue("@Cont_Id", cont_id);
                foreach (DataRow contato in BD_SQL.ExecutaSelect(cmd).Rows)
                {
                    contatos.Add(ContatoDAO.BuscaContato((int)contato["lst_id"]));
                }
            }
            finally
            {
                c.Close();
            }
            return contatos;
        }
        public static Usuario BuscaPeloId(int cont_id)
        {
            Usuario retorno = new Usuario();
            SqlConnection c = BD_SQL.Connection;
            try
            {
                c.Open();
                SqlCommand cmd = new SqlCommand("select tbUsuario.cont_id,cont_nome,cont_foto,cont_inativo,usu_email,usu_senha,usu_texto_status from tbContato inner join tbUsuario on tbContato.cont_id = tbUsuario.cont_id and tbUsuario.cont_id=@Cont_Id", c);
                cmd.Parameters.AddWithValue("@Cont_Id", cont_id);
                using (DataTable select = BD_SQL.ExecutaSelect(cmd))
                {
                    if (select.Rows.Count > 0)
                        retorno = MontaVO(select.Rows[0]);
                }
            }
            finally
            {
                c.Close();
            }
            return retorno;
        }

        public static Usuario BuscaPeloEmail(string usu_email)
        {
            Usuario retorno = new Usuario();
            SqlConnection c = BD_SQL.Connection;
            try
            {
                c.Open();
                SqlCommand cmd = new SqlCommand("select tbUsuario.cont_id,cont_nome,cont_foto,cont_inativo,usu_email,usu_senha,usu_texto_status from tbContato inner join tbUsuario on tbContato.cont_id = tbUsuario.cont_id and usu_email=@Usu_Email", c);
                cmd.Parameters.AddWithValue("@Usu_Email", usu_email);
                using (DataTable select = BD_SQL.ExecutaSelect(cmd))
                {
                    if (select.Rows.Count > 0)
                        retorno = MontaVO(select.Rows[0]);
                }
            }
            finally
            {
                c.Close();
            }
            return retorno;
        }

        public static void AtualizaStatus(int cont_id)
        {
            SqlConnection c = BD_SQL.Connection;
            try
            {
                c.Open();
                SqlCommand cmd = new SqlCommand(string.Format(
                    "if exists (select * from tmpUsuariosLogados where cont_id = @Cont_Id)\n" +
                        "update tmpUsuariosLogados set log_visto_ultimo = getdate() where cont_id = @Cont_Id\n" +
                    "else\n" +
                        "insert into tmpUsuariosLogados(cont_id,log_visto_ultimo) values (@Cont_Id,getdate())"), c);
                cmd.Parameters.AddWithValue("@Cont_Id", cont_id);
                BD_SQL.ExecutaSQL(cmd);
            }
            finally
            {
                c.Close();
            }
        }
    }
}
