using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace QTCC_Server.VO
{
    [DataContract]
    class Grupo : Contato
    {
        #region Propriedades
        #region Membros
        public List<Usuario> Membros
        {
            get;
            set;
        }
        [DataMember(Name=Campos.Membros)]
        List<int> Membros_int
        {
            get
            {
                List<int> retorno=new List<int>();
                foreach (Usuario u in Membros)
                {
                    retorno.Add(u.IDContato);
                }
                return retorno;
            }
            set
            {
                List<Usuario> retorno = new List<Usuario>();
                foreach (int ID in value)
                {
                    Usuario u = Usuario.BuscaUsuario(ID);
                    if (u != null)
                    {
                        retorno.Add(u);
                    }
                    else
                    {
                        throw new Util.ConversaoJSONException(Membros);
                    }
                }
                this.Membros = retorno;
            }
        }
        #endregion Membros

        #region Administrador
        public Usuario Administrador
        {
            get;
            set;
        }
        [DataMember(Name=Campos.Administrador)]
        int Administrador_Int
        {
            get
            {
                return Administrador.IDContato;
            }
            set
            {
                Usuario adm;
                if ((adm = Usuario.BuscaUsuario(value)) != null)
                {
                    this.Administrador = adm;
                }
                else
                {
                    throw new Util.ConversaoJSONException(Administrador);
                }
            }
        }
        #endregion Administrador
        #endregion

        public static class Campos
        {
            public const string Membros = "Membros";
            public const string Administrador = "Administrador";
        }

        #region Métodos
        public Grupo()
            : base()
        {
            Membros = new List<Usuario>();
            Administrador = new Usuario();
        }
        

        public int AdicionaMembro(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public int RemoveMembro(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public int TrocarAdministrador(Usuario novo_administrador)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
