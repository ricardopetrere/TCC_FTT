using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace QTCC_Server.VO
{
    [DataContract]
    class Usuario : Contato
    {
        #region Propriedades
        #region Texto_Status
        [DataMember(Name = Campos.Texto_Status)]
        public String Texto_Status
        {
            get;
            set;
        }
        #endregion Texto_Status

        #region Contatos
        public List<Contato> Contatos
        {
            get;
            set;
        }
        [DataMember(Name = Campos.Contatos)]
        List<int> Contatos_Int
        {
            get
            {
                List<int> retorno = new List<int>();
                foreach (Contato c in Contatos)
                {
                    retorno.Add(c.IDContato);
                }
                return retorno;
            }
            set
            {
                List<Contato> retorno = new List<Contato>();
                foreach (int ID in value)
                {
                    Contato c = new Controller.ContatoController().Busca(ID);
                    if (c != null)
                    {
                        retorno.Add(c);
                    }
                    else
                    {
                        throw new Util.ConversaoJSONException(Contatos);
                    }
                }
                this.Contatos = retorno;
            }
        }
        #endregion Contatos

        #region Email
        [DataMember(Name = Campos.Email)]
        public String Email
        {
            get;
            set;
        }
        #endregion Email

        #region Senha
        [DataMember(Name = Campos.Senha)]
        public String Senha
        {
            get;
            set;
        }
        #endregion Senha
        #endregion Propriedades

        #region Campos em JSON
        public static class Campos
        {
            public const string Texto_Status = "Texto_Status";
            public const string Contatos = "Contatos";
            public const string Email = "Email";
            public const string Senha = "Senha";
        }
        #endregion Campos em JSON

        #region Métodos
        public Usuario()
            : base()
        {
            Texto_Status = "";
            Contatos = new List<Contato>();
            Email = "";
            Senha = "";
        }
        public Usuario(Contato c)
        {
            this.IDContato = c.IDContato;
            this.Nome = c.Nome;
            this.Foto = c.Foto;
            this.Inativo = c.Inativo;
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

        public static Usuario BuscaUsuario(int idcontato)
        {
            throw new NotImplementedException();
        }
        #endregion

        internal static Usuario BuscaUsuario(string email)
        {
            throw new NotImplementedException();
        }
    }
}
