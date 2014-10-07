using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFG_BD_XML
{
    /// <summary>
    /// Classe que possui os métodos primordiais para realizar uma operação no banco de dados.
    /// Esta classe não pode ser instanciada
    /// </summary>
    public static class BD_SQL
    {
        /// <summary>
        /// Connection String a ser utilizada nas conexões com o banco de dados pela aplicação
        /// </summary>
        public static String ConnectionString { get; set; }

        /// <summary>
        /// Conexão com o banco de dados
        /// </summary>
        public static SqlConnection Connection
        {
            get { return new SqlConnection(ConnectionString); }
        }

        /// <summary>
        /// Executa um comando SQL de consulta (Select) e retorna o resultado da consulta
        /// </summary>
        /// <param name="sql">O comando SQL para realizar a consulta</param>
        /// <returns>O System.Data.DataTable contendo o resultado da consulta</returns>
        public static DataTable ExecutaSelect(String sql)
        {
            DataTable retorno = null;
            SqlConnection conn = Connection;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                retorno = ExecutaSelect(cmd);
            }
            finally
            {
                conn.Close();
            }
            return retorno;
        }
        /// <summary>
        /// Executa um comando SQL de consulta (Select) e retorna o resultado da consulta
        /// </summary>
        /// <param name="cmd">O System.Data.SqlClient.SqlCommand contendo o comando SQL, assim como a conexão pré-estabelecida</param>
        /// <returns>O System.Data.DataTable contendo o resultado da consulta</returns>
        public static DataTable ExecutaSelect(SqlCommand cmd)
        {
            DataTable retorno = new DataTable();
            new SqlDataAdapter(cmd).Fill(retorno);
            return retorno;
        }

        /// <summary>
        /// Executa um comando SQL e retorna o número de registros modificados no banco de dados
        /// </summary>
        /// <param name="sql">O comando SQL para ser executado</param>
        /// <returns>O número de registros modificados no banco de dados</returns>
        public static int ExecutaSQL(String sql)
        {
            int retorno = -1;
            SqlConnection conn = Connection;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                retorno = ExecutaSQL(cmd);
            }
            finally
            {
                conn.Close();
            }
            return retorno;
        }

        /// <summary>
        /// Executa um comando SQL e retorna o número de registros modificados no banco de dados
        /// </summary>
        /// <param name="cmd">O System.Data.SqlClient.SqlCommand contendo o comando SQL, assim como a conexão pré-estabelecida</param>
        /// <returns>O número de registros modificados no banco de dados</returns>
        public static int ExecutaSQL(SqlCommand cmd)
        {
            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Executa um comando SQL e retorna a primeira coluna do primeiro registro do resultado
        /// </summary>
        /// <param name="sql">O comando SQL para ser executado</param>
        /// <returns>A primeira coluna da primeira linha do resultado do comando</returns>
        public static object ExecutaScalar(String sql)
        {
            object retorno = null;
            SqlConnection conn = Connection;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                retorno = ExecutaScalar(cmd);
            }
            finally
            {
                conn.Close();
            }
            return retorno;
        }

        /// <summary>
        /// Executa um comando SQL e retorna a primeira coluna do primeiro registro do resultado
        /// </summary>
        /// <param name="cmd">O System.Data.SqlClient.SqlCommand contendo o comando SQL, assim como a conexão pré-estabelecida</param>
        /// <returns>A primeira coluna da primeira linha do resultado do comando</returns>
        public static object ExecutaScalar(SqlCommand cmd)
        {
            return cmd.ExecuteScalar();
        }
    }
}