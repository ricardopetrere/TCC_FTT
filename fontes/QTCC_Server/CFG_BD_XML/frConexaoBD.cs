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
    public partial class frConexaoBD : Form
    {
        public frConexaoBD()
        {
            InitializeComponent();
        }

        private void rbAutenticacaoSQLServer_CheckedChanged(object sender, EventArgs e)
        {
            txtLogin.Enabled = rbAutenticacaoSQLServer.Checked;
            txtSenha.Enabled = rbAutenticacaoSQLServer.Checked;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja cancelar as alterações realizadas?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                MessageBox.Show("O programa será encerrado.");
                DialogResult = DialogResult.Abort;
                this.Close();
            }
        }

        private void frConexaoBD_Load(object sender, EventArgs e)
        {
            rbAutenticacaoWindows.Checked = true;
        }

        private void cbBanco_Enter(object sender, EventArgs e)
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
    }
}