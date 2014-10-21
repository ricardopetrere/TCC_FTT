using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TESTE_JSON
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSerializar_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.Nome = txtNome.Text;
            u.Idade=(int)numIdade.Value;
            String[] mensagens = txtMensagens.Text.Split('\n');//.ToList<String>();
            foreach(String mensagem in mensagens)
                u.Mensagens.Add(new Message(mensagem));
            String json = Util.Serializa<User>(u);
            System.IO.File.WriteAllText("User.json", json);
            MessageBox.Show("Salvo.");
        }

        private void btnDeserializar_Click(object sender, EventArgs e)
        {
            String json = System.IO.File.ReadAllText("User.json");
            User u = Util.Deserializa<User>(json);
            txtNome.Text = u.Nome;
            numIdade.Value = u.Idade;
            txtMensagens.ResetText();
            foreach (Message mensagem in u.Mensagens)
                txtMensagens.AppendText(mensagem.Texto+Environment.NewLine);
        }
    }
}
