using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QTCC_Server.VO;
using System.Data;
using System.Data.SqlClient;
using CFG_BD_XML;

namespace QTCC_Server.DAO
{
    class ContatoDAO
    {
        public static Contato MontaVO(DataRow registro)
        {
            Contato retorno = new Contato();
            retorno.IDContato = (int)registro["cont_id"];
            retorno.Nome = registro["cont_nome"].ToString();
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                byte[] a = (byte[])registro["cont_foto"];
                ms.Write(a, 0, a.Length);
                retorno.Foto = System.Drawing.Image.FromStream(ms);
            }
            retorno.Inativo = (bool)registro["cont_inativo"];
            return retorno;
        }

        public static Contato BuscaContato(int cont_id)
        {
            Contato retorno = null;
            SqlConnection c = BD_SQL.Connection;
            try
            {
                c.Open();
                SqlCommand cmd = new SqlCommand("select cont_id, cont_nome, cont_foto, cont_inativo from tbContato where cont_id = @Cont_Id", c);
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

        /// <summary>
        /// Método responsável por adicionar um contato à lista de contatos de outro contato
        /// </summary>
        /// <param name="cont_id">Contato que irá adicionar um contato à lista (Usuário ou grupo)</param>
        /// <param name="lst_id">Contato a ser adicionado à lista (Usuário ou Grupo)</param>
        /// <returns>Se a inserção do contato à lista de contatos foi concluída com sucesso</returns>
        public static bool AdicionaContatoListaContatos(int cont_id, int lst_id)
        {
            bool retorno = false;
            //Inicializa a conexão com base na Connection String utilizada na aplicação inteira
            SqlConnection c = BD_SQL.Connection;
            try
            {
                c.Open();
                //Construção de um comando SQL parametrizado. Previne contra SQL Injection
                SqlCommand cmd = new SqlCommand("insert into tbListaContatos(cont_id,lst_id)values(@Cont_Id,@Lst_Id)",c);
                cmd.Parameters.AddWithValue("@Cont_Id", cont_id);
                cmd.Parameters.AddWithValue("@Lst_Id", lst_id);
                //Retorna se a quantidade de registros afetados (inseridos, no caso) foi maior que zero
                retorno = BD_SQL.ExecutaSQL(cmd) > 0;
            }
            finally
            {
                //Fecha a conexão
                c.Close();
            }
            return retorno;
        }
    }
}
