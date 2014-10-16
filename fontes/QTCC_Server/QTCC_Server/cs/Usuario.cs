using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QTCC_Server.CS
{
    class Usuario : Contato
    {
        #region Propriedades
        public String Texto_Status
        {
            get;
            set;
        }

        public List<Contato> Contatos
        {
            get;
            set;
        }

        public String Email
        {
            get;
            set;
        }

        private String Senha
        {
            get;
            set;
        }
        #endregion
        #region Métodos
        public Usuario()
            : base()
        {
            Texto_Status = "";
            Contatos = new List<Contato>();
            Email = "";
            Senha = "";
        }

        public int AlteraStatus(String novo_status)
        {

        }

        public int AdicionaContato(Contato novo_contato)
        {

        }

        public int RemoveContato(Contato contato)
        {

        }

        public Contato BuscaContato(String contato_email)
        {

        }

        public Boolean PossuiContato(Contato contato)
        {

        }

        public int AlterarSenha(String senha_antiga, String senha_nova)
        {

        }
        #endregion
    }
}
