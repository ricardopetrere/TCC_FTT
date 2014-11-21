using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CFG_BD_XML
{
    /// <summary>
    /// Form de conexão ao banco de dados
    /// </summary>
    public partial class frConexaoBD : Form
    {
        /// <summary>
        /// Instancia um objeto da classe <see cref="frConexaoBD"/>
        /// </summary>
        public frConexaoBD()
        {
            InitializeComponent();
        }

        #region Eventos
        private void rbAutenticacaoSQLServer_CheckedChanged(object sender, EventArgs e)
        {
            txtLogin.Enabled = rbAutenticacaoSQLServer.Checked;
            txtSenha.Enabled = rbAutenticacaoSQLServer.Checked;
            txtLogin.Text = !rbAutenticacaoSQLServer.Checked ? Environment.UserName : "";//Verificar se não dá problema com login de rede
            if (rbAutenticacaoSQLServer.Checked)
                txtLogin.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (PossuiTodosOsCampos())
            {
                SalvarConfiguracao();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ValidaSairSemSalvar();
        }

        private void frConexaoBD_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.Abort && DialogResult != DialogResult.OK)//Caso o usuário tenha clicado no botão "Salvar" ou "Cancelar"
                e.Cancel = !ValidaSairSemSalvar();
        }

        private void frConexaoBD_Load(object sender, EventArgs e)
        {
            rbAutenticacaoWindows.Checked = true;
        }

        private void cbBanco_Enter(object sender, EventArgs e)
        {
            ListarBancos();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método responsável por validar se o usuário preencheu todos os campos necessários
        /// para se salvar as configurações de acesso à base de dados.
        /// <para/>
        /// Será exibido um indicador de erro do <see cref="System.Windows.Forms.ErrorProvider"/> para cada campo necessário não preenchido.
        /// </summary>
        /// <returns>O resultado da validação (Se possui todos os campos ou não)</returns>
        private bool PossuiTodosOsCampos()
        {
            errorProvider1.Clear();
            bool retorno = true;
            if (txtCaminho.Text.Trim().Length < 1)
            {
                errorProvider1.SetError(txtCaminho, "Campo não preenchido.");
                retorno = false;
            }
            if (rbAutenticacaoSQLServer.Checked && (txtLogin.Text.Trim().Length < 1 && txtSenha.Text.Trim().Length < 1))
            {
                errorProvider1.SetError(txtLogin, "Campo não preenchido.");
                errorProvider1.SetError(txtSenha, "Campo não preenchido.");
                retorno = false;
            }
            if (cbBanco.SelectedIndex < 0)
            {
                errorProvider1.SetError(cbBanco, "Campo não preenchido.");
                retorno = false;
            }
            return retorno;
        }

        /// <summary>
        /// Indica se o usuário desejou sair sem salvar as configurações realizadas.
        /// </summary>
        /// <returns>O resultado da validação (Usuário saiu sem salvar as novas configurações ou não)</returns>
        private bool ValidaSairSemSalvar()
        {
            if (MessageBox.Show("Deseja cancelar as alterações realizadas?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                MessageBox.Show("O programa será encerrado.");
                DialogResult = DialogResult.Abort;
                Application.Exit();
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Salva as configurações de acesso realizadas
        /// </summary>
        private void SalvarConfiguracao()
        {
            BD_Connection conn = new BD_Connection();
            conn.Caminho = txtCaminho.Text;
            if (rbAutenticacaoWindows.Checked)
                conn.Autenticacao = (int)BD_Connection.CONSTANTES_AUTENTICACAO.AUTENTICACAO_WINDOWS;
            else if (rbAutenticacaoSQLServer.Checked)
                conn.Autenticacao = (int)BD_Connection.CONSTANTES_AUTENTICACAO.AUTENTICACAO_SQLSERVER;
            conn.Login = txtLogin.Text;
            conn.Senha = txtSenha.Text;
            conn.Banco = cbBanco.SelectedItem.ToString();
            BD_Connection.CriarBDXML(conn);
            DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Método responsável por listar os bancos de dados disponíveis com base na conexão especificada nos campos da tela.
        /// </summary>
        private void ListarBancos()
        {
            cbBanco.Items.Clear();
            String connString = "Data Source=" + txtCaminho.Text;
            if (rbAutenticacaoWindows.Checked)
                connString += ";Integrated Security=True";
            else
                connString += ";User ID=" + txtLogin.Text + ";Password=" + txtSenha.Text;
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                if ("".Equals(txtCaminho.Text.Trim()))
                    throw new Exception();
                conn.Open();
                SqlCommand cmd = new SqlCommand("select name from sys.databases"
                    , conn);

                //Não se pode usar BD_SQL.ExecutaSelect(String sql) porque não se pode usar a conexão atual, visto que é uma conexão temporária
                DataTable temp = BD_SQL.ExecutaSelect(cmd);
                foreach (DataRow registro in temp.Rows)
                {
                    cbBanco.Items.Add(registro[0].ToString());
                }
            }
            catch
            {
                MessageBox.Show("Falha ao listar os bancos de dados do servidor.");
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion
    }
}