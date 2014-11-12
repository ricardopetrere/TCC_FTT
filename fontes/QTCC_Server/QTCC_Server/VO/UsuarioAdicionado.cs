using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace QTCC_Server.VO
{
    [DataContract]
    class UsuarioAdicionado
    {
        #region Propriedades
        #region IDContato
        [DataMember(Name = Campos.IDContato)]
        public int IDContato
        {
            get;
            set;
        }
        #endregion IDContato

        #region NovoUsuario
        [DataMember(Name = Campos.NovoUsuario)]
        public String NovoUsuario_Email
        {
            get
            {
                return NovoUsuario.Email;
            }
            set
            {
                NovoUsuario = Usuario.BuscaUsuario(value);
            }
        }
        public Usuario NovoUsuario
        {
            get;
            set;
        }
        #endregion NovoUsuario

        #endregion Propriedades

        #region Campos em JSON
        public static class Campos
        {
            public const string IDContato = EntidadeBase.Campos.ID;
            public const string NovoUsuario = "NovoUsuario";
        }
        #endregion Campos em JSON
    }
}
