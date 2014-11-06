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
                cmd.Parameters.AddWithValue("@Cont_Nome",u.Nome);
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    u.Foto.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    cmd.Parameters.AddWithValue("@Cont_Foto", ms.ToArray());
                }
                cmd.Parameters.AddWithValue("@Usu_Email",u.Email);
                cmd.Parameters.AddWithValue("@Usu_Senha",u.Senha);
                cmd.Parameters.AddWithValue("@Usu_Texto_Status",u.Texto_Status);
                cmd.Parameters.Add("@Cont_Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                BD_SQL.ExecutaSQL(cmd);
                return u.IDContato = (int)cmd.Parameters["@Cont_Id"].Value;
            }
            catch(SqlException sql_ex)
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

        public static Usuario MontaVO(DataRow registro)
        {
            Usuario retorno=new Usuario();
            retorno.IDContato = (int)registro["cont_id"];
            retorno.Nome = registro["cont_nome"].ToString();
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                byte[] a = Convert.FromBase64String(registro["cont_foto"].ToString());
                ms.Write(a,0,a.Length);
                retorno.Foto = System.Drawing.Image.FromStream(ms);
            }
            retorno.Inativo = (bool)registro["cont_inativo"];

            return retorno;
        }
    }
}
