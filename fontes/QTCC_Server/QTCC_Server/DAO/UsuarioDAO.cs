using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CFG_BD_XML;

namespace QTCC_Server.DAO
{
    class UsuarioDAO
    {
        public static int Insere(VO.Usuario u)
        {
            SqlConnection c = BD_SQL.Connection;
            try
            {
                c.Open();
                SqlCommand cmd = new SqlCommand(string.Format("spInsereUsuario"), c);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cont_Nome",u.Nome);
                cmd.Parameters.AddWithValue("@Cont_Foto",u.Foto);
                cmd.Parameters.AddWithValue("@Usu_Email",u.Email);
                cmd.Parameters.AddWithValue("@Usu_Senha",u.Senha);
                cmd.Parameters.AddWithValue("@Usu_Texto_Status",u.Texto_Status);
                cmd.Parameters.Add("@Cont_Id", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                //cmd.Parameters.AddWithValue("@Cont_Id",u.IDContato).Direction = ParameterDirection.Output;

                BD_SQL.ExecutaSQL(cmd);
                //cmd.ExecuteNonQuery();
                return u.IDContato = (int)cmd.Parameters["@Cont_Id"].Value;
                //return u.IDContato;
            }
            catch(SqlException sql_ex)
            {
                throw sql_ex;
            }
            finally
            {
                c.Close();
            }

        }
    }
}
