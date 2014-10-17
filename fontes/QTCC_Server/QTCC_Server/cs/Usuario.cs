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
            throw new NotImplementedException();
        }

        public int AdicionaContato(Contato novo_contato)
        {
            throw new NotImplementedException();
        }

        public int RemoveContato(Contato contato)
        {
            throw new NotImplementedException();
        }

        public Contato BuscaContato(String contato_email)
        {
            throw new NotImplementedException();
        }

        public Boolean PossuiContato(Contato contato)
        {
            throw new NotImplementedException();
        }

        public int AlterarSenha(String senha_antiga, String senha_nova)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
