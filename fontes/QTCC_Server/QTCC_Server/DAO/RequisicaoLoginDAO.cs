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
        public static VO.Usuario RequisicaoLogin(RequisicaoLogin login)
        {
            SqlConnection c = BD_SQL.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand(string.Format("select cont_id,cont_nome,cont_foto,cont_inativo,usu_email,usu_texto_status from tbUsuario where usu_email=@Usu_Email and usu_senha=@Usu_Senha"), c);
                cmd.Parameters.AddWithValue("@Usu_Email", login.Login);
                cmd.Parameters.AddWithValue("@Usu_Senha", login.Senha);
                DataTable dt = BD_SQL.ExecutaSelect(cmd);
                if(dt.Rows.Count==1)
                {
                    return UsuarioDAO.MontaVO(dt.Rows[0]);
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
    }
}
