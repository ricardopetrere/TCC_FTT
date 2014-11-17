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
    class RequisicaoLoginDAO
    {
        public static Usuario RequisicaoLogin(RequisicaoLogin login)
        {
            SqlConnection c = BD_SQL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand(string.Format("select tbUsuario.cont_id,cont_nome,cont_foto,cont_inativo,usu_email,usu_senha,usu_texto_status from tbContato inner join tbUsuario on tbContato.cont_id = tbUsuario.cont_id where usu_email=@Usu_Login and usu_senha=@Usu_Senha"), c);
                cmd.Parameters.AddWithValue("@Usu_Login", login.Login);
                cmd.Parameters.AddWithValue("@Usu_Senha", login.Senha);
                DataTable dtUsuario = BD_SQL.ExecutaSelect(cmd);
                if(dtUsuario.Rows.Count==1)
                {
                    Usuario retorno = UsuarioDAO.MontaVO(dtUsuario.Rows[0]);
                    AtualizaStatus(retorno.IDContato);
                    return retorno;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sql_ex)
            {
                throw sql_ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                c.Close();
            }
        }

        public static void AtualizaStatus(int cont_id)
        {
            SqlConnection c = BD_SQL.Connection;
            try
            {
                c.Open();
                SqlCommand cmd = new SqlCommand(string.Format(
                    "if exists (select * from tmpUsuariosLogados where cont_id = @Cont_Id)\n"+
	                    "update tmpUsuariosLogados set log_visto_ultimo = getdate() where cont_id = @Cont_Id\n"+
                    "else\n"+
	                    "insert into tmpUsuariosLogados(cont_id,log_visto_ultimo) values (@Cont_Id,getdate())"), c);
                cmd.Parameters.AddWithValue("@Cont_Id", cont_id);
                BD_SQL.ExecutaSQL(cmd);
            }
            catch (SqlException sql_ex)
            {
                throw sql_ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                c.Close();
            }
        }

    }
}
