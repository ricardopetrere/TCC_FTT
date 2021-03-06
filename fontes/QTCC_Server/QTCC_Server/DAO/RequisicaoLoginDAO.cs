﻿using System;
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
                    UsuarioDAO.AtualizaStatus(retorno.IDContato);
                    return retorno;
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                c.Close();
            }
        }
    }
}
