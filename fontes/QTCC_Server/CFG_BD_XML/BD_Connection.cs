using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace CFG_BD_XML
{
    /// <summary>
    /// Classe referente ao objeto contido no arquivo BD.XML,
    /// responsável pela conexão do aplicativo com o banco de dados
    /// </summary>
    public class BD_Connection
    {
        /// <summary>
        /// Modos de autenticação no SQL Server
        /// </summary>
        public enum CONSTANTES_AUTENTICACAO { AUTENTICACAO_WINDOWS = 0, AUTENTICACAO_SQLSERVER = 2 }
        #region Atributos
        /// <summary>
        /// Caminho da Instância SQL
        /// </summary>
        public String Caminho { get; set; }
        /// <summary>
        /// Modo de Autenticação (0 = Windows, 2 = SQL Server)
        /// </summary>
        public int Autenticacao { get; set; }
        /// <summary>
        /// Login (Autenticação SQL Server)
        /// </summary>
        public String Login { get; set; }
        /// <summary>
        /// Senha (Autenticação SQL Server)
        /// </summary>
        public String Senha { get; set; }
        /// <summary>
        /// Nome do banco de dados a ser utilizado.
        /// </summary>
        public String Banco { get; set; }
        #endregion

        /// <summary>
        /// Inicializa um objeto do tipo BD_Connection em branco
        /// </summary>
        public BD_Connection() { }

        /// <summary>
        /// Inicializa um objeto do tipo BD_Connection, com os devidos atributos
        /// </summary>
        /// <param name="caminho">Caminho da instância SQL</param>
        /// <param name="autenticacao">Modo de autenticação no SQL Server</param>
        /// <param name="login">Login da conexão (Para modo de autenticação SQL)</param>
        /// <param name="senha">Senha da conexão (Para modo de autenticação SQL)</param>
        /// <param name="banco">Nome do banco de dados a se conectar</param>
        public BD_Connection(String caminho, int autenticacao, String login, String senha, String banco)
        {
            Caminho = caminho;
            Autenticacao = autenticacao;
            Login = login;
            Senha = senha;
            Banco = banco;
        }

        /// <summary>
        /// Nome do arquivo BD.XML
        /// </summary>
        private const String NomeArquivo = "BD.XML";

        /// <summary>
        /// Verifica se existe o arquivo BD.XML na pasta onde o programa está sendo executado
        /// </summary>
        /// <returns>Valor indicando se foi encontrado ou não o arquivo BD.XML</returns>
        public static bool ExisteBDXML()
        {
            return (File.Exists(NomeArquivo));
        }

        /// <summary>
        /// <para>Verifica se foi lido o arquivo BD.XML, abrindo a tela de configuração de acesso ao banco
        /// de dados caso não tenha sido encontrado o arquivo.</para>
        /// <para>No caso de falha, a aplicação que chamou o método deve chamar System.Windows.Forms.Application.Exit() e return
        /// para que o programa feche com sucesso.</para>
        /// </summary>
        /// <returns>Valor indicando se foi lido ou não o arquivo BD.XML</returns>
        public static bool LeuBDXML()
        {
            if (!BD_Connection.ExisteBDXML())
                if (new frConexaoBD().ShowDialog() == System.Windows.Forms.DialogResult.Abort)
                    return false;
            XmlSerializer reader = new XmlSerializer(typeof(BD_Connection));
            StreamReader arquivo = new StreamReader(NomeArquivo);
            try
            {
                BD_Connection conn = (BD_Connection)reader.Deserialize(arquivo);
                BD_SQL.ConnectionString = conn.ToString();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Erro ao ler arquivo BD.XML. O programa será encerrado.", "Erro!"
                    , System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                arquivo.Close();
            }
            return true;
        }

        /// <summary>
        /// Método responsável por gerar o arquivo BD.XML na pasta do programa
        /// </summary>
        /// <param name="connection">A Connection String na forma de objeto do tipo BD_Connection</param>
        public static void CriarBDXML(BD_Connection connection)
        {
            //Inicializa o serializador XML com base no tipo do objeto "connection"
            XmlSerializer writer = new XmlSerializer(connection.GetType());
            //Inicializa o objeto responsável por gravar o arquivo "BD.XML"
            StreamWriter arquivo = new StreamWriter(NomeArquivo);
            try
            {
                //Serializa a Connection String em XML
                writer.Serialize(arquivo, connection);
            }
            finally
            {
                //Fecha o buffer de "arquivo"
                arquivo.Close();
            }
        }

        /// <summary>
        /// Representação em String (ConnectionString) da conexão com o banco de dados
        /// </summary>
        /// <returns>A Connection String relacionada com o arquivo BD.XML</returns>
        public override string ToString()
        {
            String retorno = string.Format("Data Source = {0};Initial Catalog={1}", Caminho, Banco);
            switch (Autenticacao)
            {
                case (int)CONSTANTES_AUTENTICACAO.AUTENTICACAO_WINDOWS:
                    retorno += ";Integrated Security=True";
                    break;
                case (int)CONSTANTES_AUTENTICACAO.AUTENTICACAO_SQLSERVER:
                    retorno += string.Format(";User ID={0};Password={1}", Login, Senha);
                    break;
            }
            return retorno;
        }
    }
}